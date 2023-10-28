using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class FarthestJumpDistance : IWorldEvent
    {
        private float tentativoCorrente = 0;
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
                    Screen.ShowSubtitle($"Find a ground vehicle and prepare for the ~b~{Name}~w~ challenge.", 50);
                else
                {
                    Screen.ShowSubtitle(GetLabelText("AMCH_BIG_0"), 50);
                    if (Cache.PlayerCache.MyPlayer.Ped.IsInVehicle())
                    {
                        StatGetFloat(unchecked((uint)PlayerStat), ref tentativoCorrente, -1);

                        if (tentativoCorrente != 0)
                            CurrentAttempt = tentativoCorrente;
                        if (CurrentAttempt > BestAttempt)
                            BestAttempt = CurrentAttempt;

                        if (tentativoCorrente == CurrentAttempt)
                        {
                            StatSetFloat((uint)PlayerStat, 0f, true);
                            tentativoCorrente = 0;
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

