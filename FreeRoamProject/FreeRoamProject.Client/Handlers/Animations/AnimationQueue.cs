using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers.Animations
{
    public class AnimationQueue
    {
        private int Entity { get; }
        private List<Animation> Queue { get; } = [];
        private bool PlayingQueue { get; set; }
        private Animation LastPlayed { get; set; }

        public AnimationQueue(int entity)
        {
            Entity = entity;
        }

        public async Task<AnimationQueue> PlayDirectInQueue(AnimationBuilder builder)
        {
            Queue.Add(builder.Animation);
            PlayQueue();

            while (!builder.Animation.HasBeenPlayed)
            {
                await BaseScript.Delay(10);
            }

            return this;
        }

        public AnimationQueue AddToQueue(AnimationBuilder builder)
        {
            Queue.Add(builder.Animation);

            return this;
        }

        public void PlayQueue()
        {
            if (!PlayingQueue) BeginQueue();
        }

        private async void BeginQueue()
        {
            Animation next;

            while ((next = Queue.FirstOrDefault()) != null)
            {
                PlayingQueue = true;

                var entity = CitizenFX.Core.Entity.FromHandle(Entity);

                if (entity == null || !entity.Exists())
                {
                    ClientMain.Logger.Warning($"[AnimationQueue] Could not find entity #{Entity}");

                    return;
                }

                var ped = (Ped)entity;

                if (next.Position != null)
                {
                    if (NetworkGetEntityIsNetworked(Entity))
                    {
                        NetworkRequestControlOfEntity(Entity);

                        while (!NetworkHasControlOfEntity(Entity))
                        {
                            await BaseScript.Delay(100);
                        }
                    }

                    if (!next.PositionInstant)
                    {
                        TaskGoStraightToCoord(Entity, next.Position.X, next.Position.Y, next.Position.Z,
                            1f,
                            -1,
                            next.Position.Heading, 0f);

                        var time = Date.Timestamp;

                        while ((next.Position.Distance(ped.Position) > 0.3 ||
                                Math.Abs(next.Position.Heading - ped.Heading) > 5) && next.PositionTimeout == -1 ||
                               time + next.PositionTimeout > Date.Timestamp)
                        {
                            await BaseScript.Delay(10);
                        }
                    }
                    else
                    {
                        SetEntityCoords(Entity, next.Position.X, next.Position.Y, next.Position.Z, false, false,
                            false, false);
                    }

                    ped.Task.ClearAllImmediately();

                    SetEntityHeading(Entity, next.Position.Heading);
                }

                next.OnAnimStart?.Invoke();

                if (next.ClearBefore) ped.Task.ClearAllImmediately();
                if (next.Scenario != null)
                {
                    TaskStartScenarioInPlace(ped.Handle, next.Scenario, 0, true);
                }
                else
                {
                    if (next.Offset == null && next.StartTime.Equals(0f))
                        await ped.Task.PlayAnimation(next.Group, next.AnimationId, 8f, -8f, -1, next.Flags, 0);
                    else
                    {
                        var offset = Position.Zero;

                        if (next.Offset != null)
                        {
                            var position = next.Position != null ? next.Position : ped.Position.ToPosition();

                            position.Heading = ped.Heading;

                            offset = position.Add(next.Offset);
                        }

                        RequestAnimDict(next.Group);

                        while (!HasAnimDictLoaded(next.Group))
                        {
                            await BaseScript.Delay(10);
                        }

                        TaskPlayAnimAdvanced(ped.Handle, next.Group, next.AnimationId, offset.X, offset.Y, offset.Z,
                            0f, 0f, offset.Heading, 8f, -8f, -1, (int)next.Flags, next.StartTime, 0, 0);
                        RemoveAnimDict(next.Group);
                    }

                    if (next.TaskDuration == -1)
                    {
                        await BaseScript.Delay(100);

                        while (IsEntityPlayingAnim(Entity, next.Group, next.AnimationId, 3))
                        {
                            await BaseScript.Delay(1);
                        }
                    }
                    else
                    {
                        await BaseScript.Delay(next.TaskDuration);
                    }
                }

                next.HasBeenPlayed = true;

                if (LastPlayed?.Group != next.Group)
                {
                    RemoveAnimDict(next.Group);
                }

                Queue.RemoveAt(0);

                LastPlayed = next;
            }

            if (LastPlayed != null) RemoveAnimDict(LastPlayed.Group);

            PlayingQueue = false;
        }
    }
}
