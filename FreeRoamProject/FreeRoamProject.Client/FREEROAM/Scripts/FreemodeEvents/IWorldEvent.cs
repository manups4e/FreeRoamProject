using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public abstract class IWorldEvent
    {
        public TimerBarPool TimerBarPool { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ChallengeStartedLabelText { get; private set; }
        public string StatUnit { get; private set; }
        public PlayerStats PlayerStat { get; private set; }
        public PlayerStatType PlayerStatType { get; private set; }
        public bool IsActive { get; set; }
        public bool IsStarted { get; set; }
        public bool CountdownStarted { get; set; }
        public double EventTime { get; set; } = 300;
        public double EventCountdownTime { get; set; } = 90;
        public TimeSpan CountdownTime { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public TextTimerBar CountdownTimerBar = new("New event", "") { Enabled = true };
        public TextTimerBar TimeRemainingTimerBar = new("Event end", "") { Enabled = true };
        public TextTimerBar CurrentAttemptTimerBar = new("Current attempt", "0") { Enabled = true };
        public TextTimerBar YourBestTimerBar = new("Your best", "0") { Enabled = true };
        public TextTimerBar FirstPlaceTimerBar = new("~y~1°: Player 1", "~y~0") { Enabled = true };
        public TextTimerBar SecondPlaceTimerBar = new("~c~2°: Player 2", "~c~0") { Enabled = true };
        public TextTimerBar ThirdPlaceTimerBar = new("~o~3°: Player 3", "~o~0") { Enabled = true };
        public TextTimerBar EventNameTimerBar = new("Event name:", "") { Enabled = true };

        public virtual Dictionary<Vector4, VehicleHash> VehicleSpawnLocations { get; set; }

        public List<TimerBarBase> TimerBars = new List<TimerBarBase>();

        public float CurrentAttempt = 0;
        public float BestAttempt = 0;
        public bool FirstStartedTick = true;

        public IWorldEvent(int id, string name, double countdownTime, double eventTime, bool customLabel, string challengeStartedLabel, PlayerStats playerStat, string statUnit = "", PlayerStatType playerStatType = PlayerStatType.Int, bool isTimeEvent = false)
        {
            Id = id;
            Name = name;

            if (!customLabel)
                ChallengeStartedLabelText = GetLabelText(challengeStartedLabel);
            else
                ChallengeStartedLabelText = challengeStartedLabel;

            PlayerStat = playerStat;
            PlayerStatType = playerStatType;
            StatUnit = statUnit;
            IsActive = false;
            IsStarted = false;
            EventTime = eventTime;
            EventCountdownTime = countdownTime;
            CountdownTime = TimeSpan.FromSeconds(EventCountdownTime);
            TimeRemaining = TimeSpan.FromSeconds(EventTime);

            ClientMain.Instance.AddEventHandler("OnClientResourceStart", new Action<string>(OnClientResourceStart));

            ClientMain.Logger.Debug($"Added Event [{name}]");
            TimerBarPool = new TimerBarPool();
        }

        public virtual void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName)
            {
                return;
            }
        }

        public virtual void OnEventActivated()
        {
            if (PlayerStatType == PlayerStatType.Int)
                StatSetInt((uint)PlayerStat, 0, true);
            else if (PlayerStatType == PlayerStatType.Float)
                StatSetFloat((uint)PlayerStat, 0f, true);

            ClientMain.Logger.Debug($"{Name} Event Activated");
        }

        public void Activate(bool active)
        {
            ClientMain.Logger.Debug($"{(active ? "Activated" : "Deactivated")} Event {Name}.");
            IsActive = active;

            if (IsActive)
            {
                OnEventActivated();
                Screen.LoadingPrompt.Hide();
                ClientMain.Instance.AddTick(OnWorldEventTick);

                ActivateEventTimerBars();

                CountdownTimerBar.Caption = CountdownTime.ToString(@"mm\:ss");
                TimeRemainingTimerBar.Caption = TimeRemaining.ToString(@"mm\:ss");
                EventNameTimerBar.Label = Name;
            }
            else
            {
                ClientMain.Instance.RemoveTick(OnWorldEventTick);
                ResetEvent();
            }
        }

        private async Task OnWorldEventTick()
        {
            try
            {
                if (!IsActive) { return; }
                //if (Screen.LoadingPrompt.IsActive) { Screen.LoadingPrompt.Hide(); }
                if (IsStarted)
                {
                    await BaseScript.Delay(1000);
                    if (TimeRemaining == TimeSpan.Zero)
                    {
                        EventDispatcher.Send("worldEventsManage.Server:EventEnded", Id, CurrentAttempt, BestAttempt);
                        await BaseScript.Delay(5000);
                        ResetEvent();
                        return;
                    }

                    TimeRemaining = TimeRemaining.Subtract(TimeSpan.FromSeconds(1));

                    if (TimeRemaining.TotalSeconds < 10 && !CountdownStarted)
                    {
                        Game.PlaySound("10s", "MP_MISSION_COUNTDOWN_SOUNDSET");
                        CountdownStarted = true;
                    }

                    /*
                    if ((int)PlayerStat != -1)
                    {
                        var x = 0;
                        switch (PlayerStatType)
                        {
                            case PlayerStatType.Int:
                                StatGetInt(unchecked((uint)PlayerStat), ref x, 1);
                                CurrentAttempt = x;
                                break;
                            case PlayerStatType.Float:
                                var f = 0f;
                                StatGetFloat(unchecked((uint)PlayerStat), ref f, 1);
                                CurrentAttempt = f;
                                break;
                            default:
                                StatGetInt(unchecked((uint)PlayerStat), ref x, 1);
                                break;
                        }
                    }
                    */
                    if (CurrentAttempt > BestAttempt)
                    {
                        BestAttempt = CurrentAttempt;
                    }

                    EventDispatcher.Send("worldEventsManage.Server:UpdateCurrentEvent", Id, CurrentAttempt);

                    CurrentAttemptTimerBar.Caption = Math.Round(CurrentAttempt, 2).ToString() + " " + StatUnit;
                    YourBestTimerBar.Caption = Math.Round(BestAttempt, 2).ToString() + " " + StatUnit;

                    TimeRemainingTimerBar.Caption = $"{(TimeRemaining.TotalSeconds > 10 ? "~s~" : "~r~")} {TimeRemaining.ToString(@"mm\:ss")}";
                    return;
                }

                await BaseScript.Delay(1000);
                if (CountdownTime == TimeSpan.Zero)
                {
                    StartEventTimerBars();
                    ScaleformUI.Main.MedMessageInstance.ShowColoredShard("Challenge started", ChallengeStartedLabelText, HudColor.HUD_COLOUR_PURPLE, HudColor.HUD_COLOUR_PURPLE, true);
                    Audio.PlaySoundFrontend("FLIGHT_SCHOOL_LESSON_PASSED", "HUD_AWARDS");
                    IsStarted = true;
                    CountdownStarted = false;
                    return;
                }

                CountdownTime = CountdownTime.Subtract(TimeSpan.FromSeconds(1));

                if (CountdownTime.TotalSeconds < 6 && !CountdownStarted)
                {
                    Game.PlaySound("5s_To_Event_Start_Countdown", "GTAO_FM_Events_Soundset");
                    CountdownStarted = true;
                }

                CountdownTimerBar.Caption = $"{(CountdownTime.TotalSeconds > 5 ? "~s~" : "~r~")} {CountdownTime:mm\\:ss}";
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error(ex.ToString());
            }
        }

        public void StartEventTimerBars()
        {
            StatSetInt((uint)PlayerStat, 0, true);
            ActivateEventTimerBars(false);
        }

        public void ActivateEventTimerBars(bool isCountdown = true)
        {
            foreach (TimerBarBase bar in TimerBars)
            {
                TimerBarPool.Remove(bar);
            }

            TimerBars.Clear();

            if (isCountdown)
            {
                TimerBarPool.Add(CountdownTimerBar);
                TimerBars.Add(CountdownTimerBar);
            }
            else
            {
                TimerBarPool.Add(TimeRemainingTimerBar);
                TimerBars.Add(TimeRemainingTimerBar);

                TimerBarPool.Add(YourBestTimerBar);
                TimerBarPool.Add(CurrentAttemptTimerBar);

                TimerBarPool.Add(ThirdPlaceTimerBar);
                TimerBarPool.Add(SecondPlaceTimerBar);
                TimerBarPool.Add(FirstPlaceTimerBar);

                TimerBarPool.Add(EventNameTimerBar);

                TimerBars.Add(YourBestTimerBar);
                TimerBars.Add(CurrentAttemptTimerBar);

                TimerBars.Add(ThirdPlaceTimerBar);
                TimerBars.Add(SecondPlaceTimerBar);
                TimerBars.Add(FirstPlaceTimerBar);

                TimerBars.Add(EventNameTimerBar);
            }
        }

        public virtual void ResetEvent()
        {
            foreach (TimerBarBase bar in TimerBars)
            {
                TimerBarPool.Remove(bar);
            }

            CountdownTime = TimeSpan.FromSeconds(EventCountdownTime);
            TimeRemaining = TimeSpan.FromSeconds(EventTime);
            CurrentAttemptTimerBar.Caption = "0" + StatUnit;
            FirstPlaceTimerBar.Caption = "~y~0" + StatUnit;
            SecondPlaceTimerBar.Caption = "~c~0" + StatUnit;
            ThirdPlaceTimerBar.Caption = "~o~0" + StatUnit;
            TimerBars.Clear();

            IsActive = false;
            IsStarted = false;
            CountdownStarted = false;

            if (PlayerStatType == PlayerStatType.Int)
                StatSetInt((uint)PlayerStat, 0, true);
            else if (PlayerStatType == PlayerStatType.Float)
                StatSetFloat((uint)PlayerStat, 0f, true);

            CurrentAttempt = 0;
        }
    }
}
