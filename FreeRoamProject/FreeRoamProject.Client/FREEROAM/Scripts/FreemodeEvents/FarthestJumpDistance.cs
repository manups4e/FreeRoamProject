using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class FarthestJumpDistance : IWorldEvent
    {
        private float currentAttempt = 0;
        public FarthestJumpDistance(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, false, "AMCH_BIG_0", PlayerStats.FarthestJumpDistance, "m", PlayerStatType.Float)
        {
        }

        public override void OnEventActivated()
        {
            FirstStartedTick = true;
            Cache.PlayerCache.MyPlayer.Ped.Weapons.RemoveAll();
            base.OnEventActivated();
            ClientMain.Instance.AddTick(OnTick);
        }

        public override void ResetEvent()
        {
            base.ResetEvent();
            Cache.PlayerCache.MyPlayer.Player.WantedLevel = 0;
            ClientMain.Instance.RemoveTick(OnTick);
        }
        private async Task OnTick()
        {
            try
            {
                if (!IsActive) { return; }

                if (!IsStarted)

                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_PREPLAND").Replace("~a~", Name), 50);
                else
                {
                    Screen.ShowSubtitle(GetLabelText("AMCH_BIG_0"), 50);
                    if (Cache.PlayerCache.MyPlayer.Ped.IsInVehicle())
                    {
                        StatGetFloat(unchecked((uint)PlayerStat), ref currentAttempt, -1);

                        if (currentAttempt != 0)
                            CurrentAttempt = currentAttempt;
                        if (CurrentAttempt > BestAttempt)
                            BestAttempt = CurrentAttempt;

                        if (currentAttempt == CurrentAttempt)
                        {
                            StatSetFloat((uint)PlayerStat, 0f, true);
                            currentAttempt = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error(ex.ToString());
            }

            await Task.FromResult(0);
        }
    }
}

