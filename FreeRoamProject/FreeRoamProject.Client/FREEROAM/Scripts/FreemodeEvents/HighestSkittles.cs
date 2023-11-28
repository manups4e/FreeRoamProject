using FreeRoamProject.Client.Handlers;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class HighestSkittles : IWorldEvent
    {
        public HighestSkittles(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, true, "Effettua più uccisioni possibile con un veicolo di terra", PlayerStats.HighestSkittles)
        {
        }

        public override void OnEventActivated()
        {
            FirstStartedTick = true;
            base.OnEventActivated();
            ClientMain.Instance.AddTick(OnTick);
        }

        public override void ResetEvent()
        {
            base.ResetEvent();
            ClientMain.Instance.AddTick(OnTick);
        }
        private async Task OnTick()
        {
            try
            {
                if (!IsActive) { return; }

                if (!IsStarted)
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("AMCH_PREPLAND").Replace("~a~", Name));
                else
                {
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("AMCH_20"));
                    // add a check for only players to be killed? in gta:o should be peds too right?
                    if (VehicleChecker.IsInVehicle)
                    {
                        int x = 0;
                        StatGetInt(unchecked((uint)PlayerStat), ref x, -1);
                        CurrentAttempt = x;
                        if (CurrentAttempt > BestAttempt)
                            BestAttempt = CurrentAttempt;
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
