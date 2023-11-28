using FreeRoamProject.Client.Handlers;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    class FastestSpeedInCar : IWorldEvent
    {
        private float tentativoCorrente = 0;
        public FastestSpeedInCar(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, true, "Raggiungi la velocità più alta su un veicolo di terra", PlayerStats.FastestSpeedInCar, "km/h", PlayerStatType.Float)
        {
        }

        public override void OnEventActivated()
        {
            FirstStartedTick = true;
            base.OnEventActivated();
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
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("AMCH_2"));
                    if (VehicleChecker.IsInVehicle && VehicleChecker.CurrentVehicle.Speed > 0)
                    {
                        float speed = VehicleChecker.CurrentVehicle.Speed;
                        float speedKM = speed * 3.6f;
                        CurrentAttempt = speedKM;
                        StatGetFloat(unchecked((uint)PlayerStat), ref tentativoCorrente, -1);
                        if (tentativoCorrente != 0)
                            CurrentAttempt = tentativoCorrente;
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

        public override void ResetEvent()
        {
            FirstStartedTick = true;
            if (FirstStartedTick)
            {
                FirstStartedTick = false;
                uint hash = unchecked((uint)PlayerStats.FastestSpeedInCar);
                StatSetFloat(hash, 0, true);
            }
            base.ResetEvent();
            ClientMain.Instance.RemoveTick(OnTick);
        }
    }
}
