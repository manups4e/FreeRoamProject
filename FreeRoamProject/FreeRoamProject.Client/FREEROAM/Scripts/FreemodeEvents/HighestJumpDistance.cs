﻿using FreeRoamProject.Client.Handlers;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class HighestJumpDistance : IWorldEvent
    {
        private float tentativoCorrente = 0;
        public HighestJumpDistance(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, true, "Raggiungi l'altezza più elevata possibile durante un salto con un veicolo di terra", PlayerStats.HighestJumpDistance, "m", PlayerStatType.Float)
        {
        }
        public override void OnEventActivated()
        {
            Cache.PlayerCache.MyClient.Ped.Weapons.RemoveAll();
            ClientMain.Instance.AddTick(OnTick);
            base.OnEventActivated();
        }

        public override void ResetEvent()
        {
            base.ResetEvent();
            Game.Player.WantedLevel = 0;

            ClientMain.Instance.RemoveTick(OnTick);
            StatSetFloat((uint)PlayerStat, 0f, true);
            tentativoCorrente = 0;
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
                    Notifications.ShowHelpNotification("Make the highest jump with a land vehicle.");

                    if (VehicleChecker.IsInVehicle)
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

