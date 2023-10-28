using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers.Animations
{
    public class Animation
    {
        public string Group { get; set; }
        public string AnimationId { get; set; }
        public string Scenario { get; set; }
        public AnimationFlags Flags { get; set; } = AnimationFlags.None;
        public Position Position { get; set; }
        public Position Offset { get; set; }
        public float StartTime { get; set; }
        public int PositionTimeout { get; set; }
        public bool PositionInstant { get; set; }
        public int TaskDuration { get; set; } = -1;
        public bool ClearBefore { get; set; }
        public bool HasBeenPlayed { get; set; }
        public Action OnAnimStart { get; set; }
    }

    public class AnimationBuilder
    {
        public Animation Animation { get; set; } = new Animation();

        public AnimationBuilder Select(string group, string animation)
        {
            Animation.Group = group;
            Animation.AnimationId = animation;

            return this;
        }

        public AnimationBuilder Select(string scenario)
        {
            Animation.Scenario = scenario;

            return this;
        }

        public AnimationBuilder WithFlags(AnimationFlags flags)
        {
            Animation.Flags = flags;

            return this;
        }

        public AnimationBuilder AtPosition(Position position, int timeout = -1, bool instant = false)
        {
            Animation.Position = position;
            Animation.PositionTimeout = timeout;
            Animation.PositionInstant = instant;

            return this;
        }

        public AnimationBuilder WithOffset(Position position)
        {
            Animation.Offset = position;

            return this;
        }

        public AnimationBuilder AtTime(float time)
        {
            Animation.StartTime = time;

            return this;
        }

        public AnimationBuilder ClearBefore()
        {
            Animation.ClearBefore = true;

            return this;
        }

        public AnimationBuilder WithTaskDuration(int duration)
        {
            Animation.TaskDuration = duration;

            return this;
        }

        public AnimationBuilder SkipTask()
        {
            Animation.TaskDuration = 0;

            return this;
        }

        public AnimationBuilder On(Action action)
        {
            Animation.OnAnimStart = action;

            return this;
        }

        public async Task TaskWhenPlayed()
        {
            while (!Animation.HasBeenPlayed)
            {
                await BaseScript.Delay(10);
            }
        }
    }
}
