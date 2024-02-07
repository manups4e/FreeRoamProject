using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    internal class IdleChecker
    {
        internal static TimeSpan IdleTime;
        private static readonly int totalMilliseconds = 900000; // 15mins
        private static bool Global_2726600 = false;
        private static SharedTimeChecker secTimer;
        private static int switchController = 0;
        private static int countDown = 6000;
        /// <summary>
        /// We can control the AFK countdown from here, we can enable/disable it where we want it.. 
        /// for example when spectating players there can't be AFK checks
        /// </summary>
        public static bool EnableAFKCheck = true;
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += AccessingEvents_OnFreeRoamSpawn;
        }

        private static void AccessingEvents_OnFreeRoamSpawn(PlayerClient client)
        {
            IdleTime = TimeSpan.FromMilliseconds(0);
            secTimer = new SharedTimeChecker(1, TimerType.Seconds);
            TickController.TickGenerics.Add(IdleCheck);
        }

        private static async Task IdleCheck()
        {
            if (!EnableAFKCheck || PlayerCache.MyClient.User.group_level >= UserGroup.Admin) return;
            int timeSinceLastInput = (int)Math.Floor(GetTimeSinceLastInput(0) / 1000f);
            if (timeSinceLastInput < 30) return;
            // it works in a very simple way.. if the player has not pressed any key, control, mouse, moved, anything
            // for 30 seconds.. we start the countdown of 15mins.. the countdown is actually a countup (blame R*)
            // so basically everytime you stop touching your controller, keyboard, mouse...
            // after 15minutes and 30seconds you are kicked from the server
            if (Functions.IsAnyControlJustReleased())
            {
                if (IdleTime.TotalMilliseconds > 0)
                    IdleTime = TimeSpan.FromMilliseconds(0);
            }
            if (IdleTime.TotalMilliseconds < totalMilliseconds)
            {
                if (secTimer.IsPassed)
                {
                    IdleTime = IdleTime.Add(TimeSpan.FromSeconds(1));
                }
                int iVar1 = totalMilliseconds;
                int iVar2 = 120000;
                int iVar3 = 300000;
                int iVar4 = 600000;

                switch (switchController)
                {
                    case 0:
                        if (IdleTime.TotalMilliseconds >= iVar2)
                        {
                            PlaystatsIdleKick(iVar2);
                            BeginTextCommandThefeedPost("HUD_ILDETIME");
                            AddTextComponentSubstringTime(iVar1 - iVar2, 134);
                            EndTextCommandThefeedPostTicker(false, true);
                            switchController = 1;
                        }
                        break;
                    case 1:
                        if (IdleTime.TotalMilliseconds >= iVar3)
                        {
                            PlaystatsIdleKick(iVar3);
                            BeginTextCommandThefeedPost("HUD_ILDETIME");
                            AddTextComponentSubstringTime(iVar1 - iVar3, 134);
                            EndTextCommandThefeedPostTicker(false, true);
                            switchController = 2;
                        }
                        break;
                    case 2:
                        if (!Global_2726600)
                        {
                            if (IdleTime.TotalMilliseconds >= iVar4 - 5000)
                            {
                                ThefeedIsPaused();
                                ThefeedForceRenderOn();
                                ThefeedResume();
                                ThefeedFlushQueue();
                            }
                        }
                        if (IdleTime.TotalMilliseconds >= iVar4)
                        {
                            PlaystatsIdleKick(iVar4);
                            BeginTextCommandThefeedPost("HUD_ILDETIME");
                            AddTextComponentSubstringTime(iVar1 - iVar4, 134);
                            EndTextCommandThefeedPostTicker(false, true);
                            switchController = 3;
                        }
                        break;
                    case 3:
                        if (IdleTime.TotalMilliseconds >= iVar4 + 7000)
                        {
                            if (ThefeedIsPaused())
                            {
                                ThefeedPause();
                                ThefeedForceRenderOff();
                                ThefeedFlushQueue();
                            }
                        }
                        Global_2726600 = false;
                        if (countDown > 0)
                        {
                            if (IdleTime.TotalMilliseconds >= iVar1 - countDown)
                            {
                                Game.PlaySound("MP_IDLE_TIMER", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                                countDown -= 1000;
                            }
                        }
                        if (IdleTime.TotalMilliseconds >= iVar1)
                        {
                            Game.PlaySound("MP_IDLE_TIMER", "HUD_FRONTEND_DEFAULT_SOUNDSET");
                            PlaystatsIdleKick(iVar1);
                            await BaseScript.Delay(1000);
                            EventDispatcher.Send("tlg:kickPlayerClient", PlayerCache.MyClient.Handle, Game.GetGXTEntry("HUD_KICKRES"));
                        }
                        break;
                }

                //Global_1575072 to be checked
            }
        }
    }
}
