using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode;


namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    static class WorldEventsManager
    {
        private static readonly List<IWorldEvent> WorldEvents = new();

        public static IWorldEvent ActiveWorldEvent;
        public static IWorldEvent NextWorldEvent;

        private static int JoinWaitTime = 0;
        private static int DownTime = 0;
        public static bool WarningMessageDisplayed = false;
        private static bool FirstSpawn = true;

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += OnPlayerJoined;
            AccessingEvents.OnFreeRoamLeave += OnPlayerLeft;
        }

        private static async void OnPlayerJoined(PlayerClient client)
        {
            //ClientMain.Instance.AddTick(OnDefaultTick);
            //ClientMain.Instance.AddTick(OnDiscordTick);
            ClientMain.Instance.AddTick(OnWaitTick);
            ClientMain.Instance.AddTick(SaveMe);

            EventDispatcher.Mount("worldEventsManage.Client:EventActivate", new Action<int, int>(OnActivateEvent));
            EventDispatcher.Mount("worldeventsManager.Client:GetEventData", new Action<int, float, float>(OnGetEventData));
            EventDispatcher.Mount("worldEventsManage.Client:NextEventIn", new Action<int>(OnNextEventIn));
            EventDispatcher.Mount("worldEventsManage.Client:GetTop3", new Action<string>(OnGetTop3));
            EventDispatcher.Mount("worldEventsManage.Client:FinalTop3", new Action<int, string>(OnGetFinalTop3));
            EventDispatcher.Mount("worldEventsManage.Client:PeriodicSync", new Action<int, bool>(OnPeriodicSync));
            EventDispatcher.Mount("tlg:freeroam:showLoading", new Action<int, string, int>(ShowDialog));

            //TODO: find all the labels for the titles
            WorldEvents.Add(new NumberOfNearMisses(1, Game.GetGXTEntry("AMCH_8SLC"), 60, 300));
            WorldEvents.Add(new FlyingUnderBridges(2, Game.GetGXTEntry("AMCH_9SLC"), 90, 300));
            WorldEvents.Add(new FastestSpeedInCar(3, Game.GetGXTEntry("AMCH_2SLC"), 60, 270));
            WorldEvents.Add(new MostPistolHeadshots(4, Game.GetGXTEntry("AMCH_19SLC"), 60, 300));
            WorldEvents.Add(new LongestSurvivedFreefall(5, Game.GetGXTEntry("AMCH_13SLC"), 60, 240));
            WorldEvents.Add(new HighestSkittles(6, Game.GetGXTEntry("HIGHEST_SKITTLES"), 60, 300));
            WorldEvents.Add(new FarthestJumpDistance(7, Game.GetGXTEntry("AMCH_0SLC"), 60, 270)); // not sure is the right name..
            WorldEvents.Add(new HighestJumpDistance(8, Game.GetGXTEntry("HIGHEST_JUMP_REACHED"), 60, 270)); // not sure is the right name..
            WorldEvents.Add(new KingOfTheCastle(9, Game.GetGXTEntry("FM_AE_TITL_9"), 60, 300));
            Tuple<int, int, int, int, bool> status = await EventDispatcher.Get<Tuple<int, int, int, int, bool>>("worldEventsManage.Server:GetStatus");
            OnGetStatus(status.Item1, status.Item2, status.Item3, status.Item4, status.Item5);
        }

        public static void OnPlayerLeft(PlayerClient client)
        {
            ClientMain.Instance.RemoveTick(OnWaitTick);
            ClientMain.Instance.RemoveTick(SaveMe);

            EventDispatcher.Unmount("worldEventsManage.Client:EventActivate");
            EventDispatcher.Unmount("worldeventsManager.Client:GetEventData");
            EventDispatcher.Unmount("worldEventsManage.Client:NextEventIn");
            EventDispatcher.Unmount("worldEventsManage.Client:GetTop3");
            EventDispatcher.Unmount("worldEventsManage.Client:FinalTop3");
            EventDispatcher.Unmount("worldEventsManage.Client:PeriodicSync");
            EventDispatcher.Unmount("tlg:freeroam:showLoading");
            WorldEvents.Clear();
            ActiveWorldEvent.ResetEvent();
        }

        public static async Task SaveMe()
        {
            await BaseScript.Delay(600000); // 600000
            EventDispatcher.Send("tlg:freeroam:SaveMe");
            if (!ScaleformUI.Main.InstructionalButtons.IsSaving)
                ScaleformUI.Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.SocialClubSaving, "Saving", 5000);

        }

        public static void ShowDialog(int type, string txt, int time)
        {
            if (!ScaleformUI.Main.InstructionalButtons.IsSaving)
                ScaleformUI.Main.InstructionalButtons.AddSavingText((LoadingSpinnerType)type, txt, time);
        }

        private static async Task OnWaitTick()
        {
            try
            {
                await BaseScript.Delay(1000);

                if (JoinWaitTime != 0)
                    JoinWaitTime--;

                if (DownTime != 0)
                    DownTime--;
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }

            await Task.FromResult(0);
        }

        private static void OnPeriodicSync(int eventTime, bool isStarted)
        {
            if (ActiveWorldEvent == null) { return; }

            if (isStarted)
            {
                if (ActiveWorldEvent.TimeRemaining.TotalSeconds != eventTime)
                    ActiveWorldEvent.TimeRemaining = TimeSpan.FromSeconds(eventTime);
            }
            else
            {
                if (ActiveWorldEvent.CountdownTime.TotalSeconds != eventTime)
                    ActiveWorldEvent.CountdownTime = TimeSpan.FromSeconds(eventTime);
            }
        }

        private static void OnGetEventData(int eventId, float currentAttempt, float bestAttempt)
        {
            if (ActiveWorldEvent == null) { return; }

            ActiveWorldEvent.CurrentAttempt = currentAttempt;
            ActiveWorldEvent.BestAttempt = bestAttempt;
        }

        private static async void OnGetFinalTop3(int eventId, string json)
        {
            try
            {
                ClientMain.Logger.Debug("first 3  = " + json);
                Dictionary<string, float> top3 = JsonConvert.DeserializeObject<Dictionary<string, float>>(json);

                int xp = 0;
                int place = 0;

                // Winner
                if (top3.ElementAt(0).Key == Cache.PlayerCache.MyClient.Player.Name)
                {
                    if (top3.ElementAt(0).Value != 0)
                    {
                        xp = Convert.ToInt32(top3.ElementAt(0).Value * 1.75);
                        place = 1;
                    }
                }
                // 2nd Place
                else if (top3.ElementAt(1).Key == Cache.PlayerCache.MyClient.Player.Name)
                {
                    if (top3.ElementAt(1).Value != 0)
                    {
                        xp = Convert.ToInt32(top3.ElementAt(1).Value * 1.5);
                        place = 2;
                    }
                }
                // 3rd Place
                else if (top3.ElementAt(2).Key == Cache.PlayerCache.MyClient.Player.Name)
                {
                    if (top3.ElementAt(2).Value != 0)
                    {
                        xp = Convert.ToInt32(top3.ElementAt(2).Value * 1.25);
                        place = 3;
                    }
                }
                // Out of top 3
                else
                {
                    place = 0;
                }

                string title = "Fine";
                string score = "";
                if (ActiveWorldEvent.PlayerStatType == PlayerStatType.Int)
                    score = Math.Round(ActiveWorldEvent.CurrentAttempt, 0).ToString();
                else if (ActiveWorldEvent.PlayerStatType == PlayerStatType.Float)
                    score = Math.Round(ActiveWorldEvent.CurrentAttempt, 2).ToString();

                string description = $"{top3.ElementAt(0).Key} won the challenge {ActiveWorldEvent.Name} with a score of {top3.ElementAt(2).Value}{ActiveWorldEvent.StatUnit}";
                if (top3.All(x => x.Key.StartsWith("-")))
                    description = "No one took part in the challenge, there are no winners!";
                switch (place)
                {
                    case 1:
                        title = "Winner";
                        description = $"You're the winner of the {ActiveWorldEvent.Name} Challenge with a score of {score}{ActiveWorldEvent.StatUnit}!";
                        Audio.PlaySoundFrontend("FIRST_PLACE", "HUD_MINI_GAME_SOUNDSET");
                        break;
                    case 2:
                        title = "Second";
                        description = $"So close!!, Yet so far... You came second in the {ActiveWorldEvent.Name} Challenge with a score of {score}{ActiveWorldEvent.StatUnit}";
                        Audio.PlaySoundFrontend("RACE_PLACED", "HUD_AWARDS");
                        break;
                    case 3:
                        title = "Third";
                        description = $"You came third in the {ActiveWorldEvent.Name} Challenge with a score of {score}{ActiveWorldEvent.StatUnit}";
                        Audio.PlaySoundFrontend("RACE_PLACED", "HUD_AWARDS");
                        break;
                    default:
                        Audio.PlaySoundFrontend("RACE_PLACED", "HUD_AWARDS");
                        break;
                }

                ScaleformUI.Main.MedMessageInstance.ShowColoredShard(title, description, HudColor.HUD_COLOUR_PURPLE, HudColor.HUD_COLOUR_PURPLE, true, false, 7500);
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }

            await Task.FromResult(0);
        }

        private static void OnGetTop3(string top3)
        {
            try
            {
                if (ActiveWorldEvent == null)
                {
                    return;
                }

                Dictionary<string, float> top3Players = JsonConvert.DeserializeObject<Dictionary<string, float>>(top3);

                if (top3Players.Count < 3) { return; }

                ActiveWorldEvent.FirstPlaceTimerBar.Label = $"~y~1°: {top3Players.ElementAt(0).Key}";
                ActiveWorldEvent.FirstPlaceTimerBar.Caption = $"~y~{Math.Round(top3Players.ElementAt(0).Value, 2)} {ActiveWorldEvent.StatUnit}";
                ActiveWorldEvent.SecondPlaceTimerBar.Label = $"~c~2°: {top3Players.ElementAt(1).Key}";
                ActiveWorldEvent.SecondPlaceTimerBar.Caption = $"~c~{Math.Round(top3Players.ElementAt(1).Value, 2)} {ActiveWorldEvent.StatUnit}";
                ActiveWorldEvent.ThirdPlaceTimerBar.Label = $"~o~3°: {top3Players.ElementAt(2).Key}";
                ActiveWorldEvent.ThirdPlaceTimerBar.Caption = $"~o~{Math.Round(top3Players.ElementAt(2).Value, 2)} {ActiveWorldEvent.StatUnit}";
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }
        }

        private static void OnActivateEvent(int currentId, int nextId)
        {
            JoinWaitTime = 0;
            ActiveWorldEvent = WorldEvents.Where(x => x.Id == currentId).FirstOrDefault();
            NextWorldEvent = WorldEvents.Where(x => x.Id == nextId).FirstOrDefault();

            if (ActiveWorldEvent != null)
                ActiveWorldEvent.Activate(true);
        }

        private static void OnNextEventIn(int seconds)
        {
            DownTime = seconds;

            if (DownTime > 0 && DownTime < 60) { ScaleformUI.Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.Clockwise1, "Preparing next event"); }
        }


        private static void OnGetStatus(int currentId, int nextId, int downTime, int joinWaitTime, bool isStarted)
        {
            ActiveWorldEvent = WorldEvents.Where(x => x.Id == currentId).FirstOrDefault();
            NextWorldEvent = WorldEvents.Where(x => x.Id == nextId).FirstOrDefault();

            DownTime = downTime;
            JoinWaitTime = joinWaitTime;

            if (DownTime > 0 && DownTime < 60)
            {
                ScaleformUI.Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.Clockwise1, "Preparing next event");
                return;
            }

            if (FirstSpawn)
            {
                ActiveWorldEvent.ResetEvent();

                if (JoinWaitTime > 0)
                {
                    ActiveWorldEvent.Activate(true);
                    ActiveWorldEvent.IsStarted = isStarted;

                    if (ActiveWorldEvent.IsStarted)
                    {
                        ActiveWorldEvent.ActivateEventTimerBars(false);
                        ActiveWorldEvent.TimeRemaining = TimeSpan.FromSeconds(JoinWaitTime);
                        ActiveWorldEvent.CountdownStarted = false;
                    }
                    else
                    {
                        ActiveWorldEvent.ActivateEventTimerBars(true);
                        ActiveWorldEvent.CountdownTime = TimeSpan.FromSeconds(JoinWaitTime);
                        ActiveWorldEvent.CountdownStarted = true;
                    }
                }
                FirstSpawn = false;
            }
            else
            {
                ActiveWorldEvent.IsStarted = isStarted;

                if (ActiveWorldEvent.IsStarted)
                    ActiveWorldEvent.TimeRemaining = TimeSpan.FromSeconds(JoinWaitTime);
                else
                    ActiveWorldEvent.CountdownTime = TimeSpan.FromSeconds(JoinWaitTime);
            }
        }
    }
}
