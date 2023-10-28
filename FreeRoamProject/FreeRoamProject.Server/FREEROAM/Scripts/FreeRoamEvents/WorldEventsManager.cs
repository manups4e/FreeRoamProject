using FreeRoamProject.Server.Core.Buckets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents
{
    static class WorldEventsManager
    {
        public static readonly List<WorldEvent> WorldEvents = new List<WorldEvent>
        {
            new WorldEvent{ Id = 1, Name = "Near Misses", CountdownTime = TimeSpan.FromSeconds(SharedMath.GetRandomInt(2700, 5400)), EventTime = TimeSpan.FromSeconds(300), EventXpMultiplier = 13.5f },
            new WorldEvent{ Id = 2, Name = "Fly Under Bridges", CountdownTime = TimeSpan.FromSeconds(90), EventTime = TimeSpan.FromSeconds(300), EventXpMultiplier = 35.25f },
            new WorldEvent{ Id = 3, Name = "Highest Speed", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(270), EventXpMultiplier = 1.5f},
            new WorldEvent{ Id = 4, Name = "Headshot Kills", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(300), EventXpMultiplier = 20.5f},
            new WorldEvent{ Id = 5, Name = "Longest Fall Survived", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(240), EventXpMultiplier = 100.5f},
            new WorldEvent{ Id = 6, Name = "Vehicular kills", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(300), EventXpMultiplier = 13.5f},
            new WorldEvent{ Id = 7, Name = "Longest Jump", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(270), EventXpMultiplier = 20.5f},
            new WorldEvent{ Id = 8, Name = "Highest vehicle jump", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(270), EventXpMultiplier = 25.5f},
            new WorldEvent{ Id = 9, Name = "King of the Castle", CountdownTime = TimeSpan.FromSeconds(60), EventTime = TimeSpan.FromSeconds(300), EventXpMultiplier = 25.5f},
        };

        private static readonly int SaveInterval = 5;

        private static WorldEvent CurrentEvent;
        private static WorldEvent NextEvent;
        private static SharedTimer PeriodicTimer;
        private static SharedTimer EventTimer;
        private static TimeSpan TimeUntilNextEvent = TimeSpan.FromMinutes(SharedMath.GetRandomInt(45, 90));
        private static long _savingTimer = 0;

        private static bool IsAnyEventActive = false;

        public static void Init()
        {
            EventDispatcher.Mount("worldEventsManage.Server:AddParticipant", new Action<PlayerClient>(OnAddParticipant));
            EventDispatcher.Mount("worldEventsManage.Server:EventEnded", new Action<PlayerClient, int, int, int>(OnEventEnded));
            EventDispatcher.Mount("worldEventsManage.Server:UpdateCurrentEvent", new Action<PlayerClient, int, float>(OnUpdateCurrentEvent));
            EventDispatcher.Mount("worldEventsManage.Server:GetStatus", new Func<PlayerClient, Task<Tuple<int, int, int, int, bool>>>(OnGetStatus));
            EventDispatcher.Mount("tlg:freeroam:SaveMe", new Action<PlayerClient>(SaveMe));
            PeriodicTimer = new(1000);
            EventTimer = new(1000);
            ServerMain.Instance.AddTick(OnPeriodicTick);
            ServerMain.Instance.AddTick(OnEventTick);
            ChooseNextEvent();

        }

        private static void OnUpdateCurrentEvent([FromSource] PlayerClient client, int eventId, float currentAttempt)
        {
            if (CurrentEvent == null) { return; }
            if (CurrentEvent.Id != eventId) { return; }
            BucketsHandler.FreeRoam.UpdateCurrentAttempt(client, eventId, currentAttempt);
        }

        private static async Task OnPeriodicTick()
        {
            await BaseScript.Delay(1000);
            try
            {
                if (CurrentEvent.CountdownTime > TimeSpan.Zero)
                {
                    // TODO: HANDLE EACH BUCKET ON ITS OWN..
                    foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                    {
                        EventDispatcher.Send(server.Players, "worldEventsManage.Client:PeriodicSync", (int)CurrentEvent.CountdownTime.TotalSeconds, false);
                    }
                    return;
                }
                // TODO: HANDLE EACH BUCKET ON ITS OWN..
                foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                {
                    EventDispatcher.Send(server.Players, "worldEventsManage.Client:PeriodicSync", (int)CurrentEvent.EventTime.TotalSeconds, true);
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error($"{e}");
            }
        }

        private static async Task OnEventTick()
        {
            await BaseScript.Delay(1000);
            try
            {
                if (!IsAnyEventActive)
                {

                    TimeUntilNextEvent = TimeUntilNextEvent.Subtract(TimeSpan.FromSeconds(1));
                    if (TimeUntilNextEvent == TimeSpan.Zero)
                    {
                        NextEvent.IsActive = true;
                        NextEvent.IsStarted = false;
                        IsAnyEventActive = NextEvent.IsActive;
                        CurrentEvent = NextEvent;
                        BucketsHandler.FreeRoam.SendEventData(CurrentEvent.Id);
                        ChooseNextEvent();

                        ServerMain.Logger.Info($"Current Event [{CurrentEvent.Name}] | Next Event [{NextEvent.Name}]");
                        foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                        {
                            EventDispatcher.Send(server.Players, "worldEventsManage.Client:EventActivate", CurrentEvent.Id, NextEvent.Id);
                        }
                    }
                }
                else
                {
                    if (!CurrentEvent.IsStarted)
                    {
                        CurrentEvent.CountdownTime = CurrentEvent.CountdownTime.Subtract(TimeSpan.FromSeconds(1));
                        if (CurrentEvent.CountdownTime == TimeSpan.Zero)
                        {
                            CurrentEvent.IsStarted = true;
                            foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                            {
                                EventDispatcher.Send(server.Players, "worldEventsManage.Client:EventStart", CurrentEvent.Id);
                            }
                        }
                    }
                    else
                    {
                        CurrentEvent.EventTime = CurrentEvent.EventTime.Subtract(TimeSpan.FromSeconds(1));
                        if (CurrentEvent.EventTime == TimeSpan.Zero)
                        {
                            IsAnyEventActive = false;
                            await BaseScript.Delay(1500); // Delay to let everyone send in their results

                            BucketsHandler.FreeRoam.SendFinalTop3Players(CurrentEvent.Id, CurrentEvent.EventXpMultiplier);

                            string cE = WorldEvents.Where(x => x.Id == CurrentEvent.Id).FirstOrDefault().ToJson();
                            CurrentEvent = JsonConvert.DeserializeObject<WorldEvent>(cE); // reset this element. it's actually the next event
                            CurrentEvent.IsStarted = false;
                            CurrentEvent.IsActive = false;
                            TimeUntilNextEvent = TimeSpan.FromMinutes(SharedMath.GetRandomInt(45, 90));
                            await BaseScript.Delay(3500); // Wait until we start the next event (total 5 seconds)
                            foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                            {
                                EventDispatcher.Send(server.Players, "worldEventsManage.Client:DestroyEventVehicles");
                                EventDispatcher.Send(server.Players, "worldEventsManage.Client:NextEventIn", (int)TimeUntilNextEvent.TotalSeconds);
                            }
                        }
                        else
                        {
                            BucketsHandler.FreeRoam.SendTop3Players(CurrentEvent.Id);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ServerMain.Logger.Error($"{e}");
            }

            await Task.FromResult(0);
        }

        private static void SaveMe([FromSource] PlayerClient client)
        {
            try
            {
                foreach (Shared.Core.Buckets.Bucket server in BucketsHandler.FreeRoam.Servers)
                {
                    if (server.Players.Any(x => x.Handle == client.Handle))
                    {
                        if (client.Status.PlayerStates.Spawned)
                        {
                            FreeRoamEvents.SaveCharacter(client);
                            ServerMain.Logger.Info($"Saved freeroam char owned by '{client.Player.Name}' - {client.User.Identifiers.Discord}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        private static void OnEventEnded([FromSource] PlayerClient client, int eventId, int currentAttempt, int bestAttempt)
        {
            try
            {
                if (eventId != CurrentEvent.Id) { return; }

                BucketsHandler.FreeRoam.UpdateCurrentAttempt(client, eventId, currentAttempt);
                BucketsHandler.FreeRoam.UpdateBestAttempt(client, eventId, bestAttempt);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error($"{e}");
            }
        }

        private static async Task<Tuple<int, int, int, int, bool>> OnGetStatus([FromSource] PlayerClient client)
        {
            try
            {
                int joinWaitTime = 0;
                bool isStarted = CurrentEvent.IsStarted;
                if (!CurrentEvent.IsActive)
                {
                    return new(CurrentEvent.Id, NextEvent.Id, (int)TimeUntilNextEvent.TotalSeconds, joinWaitTime, isStarted);
                }

                if (CurrentEvent.IsStarted)
                    joinWaitTime = (int)CurrentEvent.EventTime.TotalSeconds;
                else
                    joinWaitTime = (int)CurrentEvent.CountdownTime.TotalSeconds;

                return new(CurrentEvent.Id, NextEvent.Id, (int)TimeUntilNextEvent.TotalSeconds, joinWaitTime, isStarted);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
                return default;
            }
        }

        private static void OnAddParticipant([FromSource] PlayerClient client)
        {
            try
            {
                int xp = BucketsHandler.FreeRoam.GetCurrentExperiencePoints(client);
                int level = BucketsHandler.FreeRoam.GetCurrentLevel(client);
                EventDispatcher.Send(client, "worldeventsManage.Client:GetLevelXp", level, xp);
                AccessingEvents.FreeRoamSpawn(client);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        private static void ChooseNextEvent()
        {
            try
            {
                if (CurrentEvent == null)
                {
                    string cE = JsonConvert.SerializeObject(WorldEvents.OrderBy(x => SharedMath.GetRandomFloat()).First());
                    CurrentEvent = JsonConvert.DeserializeObject<WorldEvent>(cE);
                }

                string nE = JsonConvert.SerializeObject(WorldEvents.Where(x => x.Id != CurrentEvent.Id).OrderBy(x => SharedMath.GetRandomFloat()).First());
                NextEvent = JsonConvert.DeserializeObject<WorldEvent>(nE);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }
    }
}
