using FreeRoamProject.Client.Handlers;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class NumberOfNearMisses : IWorldEvent
    {
        public NumberOfNearMisses(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, false, "AMCH_8", PlayerStats.NumberNearMissesNoCrash)
        {
            ClientMain.Instance.AddEventHandler("DamageEvents:VehicleDamaged", new Action<int, int, uint, bool, int>(VehicleDamaged));
        }

        public override void OnEventActivated()
        {
            API.StatSetInt(unchecked((uint)PlayerStats.NumberNearMisses), 0, true);
            API.StatSetInt(unchecked((uint)PlayerStats.NumberNearMissesNoCrash), 0, true);
            ClientMain.Instance.AddTick(OnTick);
            base.OnEventActivated();
        }

        private void VehicleDamaged(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag)
        {
            if (IsStarted)
            {
                Vehicle veh = new(vehicle);
                if (veh == VehicleChecker.CurrentVehicle)
                {
                    API.StatSetInt(unchecked((uint)PlayerStats.NumberNearMisses), 0, true);
                    CurrentAttempt = 0;
                }
            }
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
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("AMCH_BIG_8"));
                    int x = 0;
                    int p = 0;
                    API.StatGetInt(unchecked((uint)PlayerStats.NumberNearMisses), ref x, -1);
                    if (x != 0)
                        CurrentAttempt = x;
                    API.StatGetInt(unchecked((uint)PlayerStats.NumberNearMissesNoCrash), ref p, -1);
                    BestAttempt = p;
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
            base.ResetEvent();
            ClientMain.Instance.RemoveTick(OnTick);
        }
    }
}
