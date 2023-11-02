using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class LongestSurvivedFreefall : IWorldEvent
    {
        public new Dictionary<Vector4, VehicleHash> VehicleSpawnLocations = new Dictionary<Vector4, VehicleHash>
        {
            { new Vector4(-1158.893f, -1738.877f, 4.055f,215.483f), VehicleHash.Buzzard2 },
            { new Vector4(-1168.874f, -1746.419f, 3.998f,124.725f), VehicleHash.Buzzard2 },
            { new Vector4(-1603.944f, -2794.439f, 13.971f,240.045f), VehicleHash.Lazer },
            { new Vector4(-978.337f, -3349.99f, 13.944f,58.062f), VehicleHash.Stunt },
            { new Vector4(449.143f, -981.273f, 43.692f,90.059f), VehicleHash.Buzzard2 },
            { new Vector4(699.427f, -491.963f, 15.881f,176.157f), VehicleHash.Buzzard2 },
            { new Vector4(1264.816f, 188.245f, 81.863f,146.089f), VehicleHash.Stunt },
            { new Vector4(1053.443f, 3081.934f, 41.469f,241.713f), VehicleHash.Lazer },
            { new Vector4(1769.635f, 3239.461f, 42.125f,280.808f), VehicleHash.Buzzard2 },
            { new Vector4(2208.907f, 4651.732f, 31.229f,164.052f), VehicleHash.Dodo },
            { new Vector4(2131.084f, 4803.199f, 41.046f,118.359f), VehicleHash.Stunt },
            { new Vector4(-745.328f, -1468.634f, 5.001f,142.71f), VehicleHash.Buzzard2 },
            { new Vector4(568.12f, -739.669f, 11.996f,174.5f), VehicleHash.Lazer },
            { new Vector4(-1706.891f, -815.918f, 9.427f,45.216f), VehicleHash.Stunt },
            { new Vector4(1491.408f, -1973.71f, 70.816f,339.805f), VehicleHash.Stunt },
            { new Vector4(-252.804f, -2537.156f, 6.004f,158.885f),  VehicleHash.Buzzard2 },
            { new Vector4(313.394f, -1465.316f, 46.509f,43.926f), VehicleHash.Buzzard2 },
            { new Vector4(1175.107f, 278.744f, 81.871f,120.01f),  VehicleHash.Buzzard2 },
            { new Vector4(478.547f, -3370.131f, 6.07f,355.228f),  VehicleHash.Buzzard2 },
            { new Vector4(-1268.469f, -3375.488f, 13.94f,326.586f), VehicleHash.Lazer },
            { new Vector4(-1253.342f, -3385.56f, 13.94f,330.219f), VehicleHash.Lazer },
            { new Vector4(-1052.381f, -3493.217f, 14.143f,29.211f),VehicleHash.Buzzard2 },
            { new Vector4(-1231.069f, -2879.385f, 13.945f,148.996f), VehicleHash.Lazer },
            { new Vector4(-1340.997f, -2218.804f, 13.945f,146.772f), VehicleHash.Lazer },
            { new Vector4(-981.205f, -2990.385f, 13.945f,58.785f), VehicleHash.Stunt },
            { new Vector4(-321.589f, -2548.515f, 6.001f,50.188f), VehicleHash.Stunt },
            { new Vector4(1401.903f, 2998.903f, 40.553f,315.416f), VehicleHash.Lazer },
            { new Vector4(1077.437f, 3011.685f, 41.354f,285.25f), VehicleHash.Lazer },
            { new Vector4(1732.836f, 3305.026f, 41.224f,195.137f), VehicleHash.Stunt },
        };

        public LongestSurvivedFreefall(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, false, "AMCH_13", PlayerStats.LongestSurvivedFreefall, "m", PlayerStatType.Float)
        {
        }

        public override async void OnEventActivated()
        {
            FirstStartedTick = true;
            //Cache.PlayerCache.MyPlayer.Ped.Weapons.RemoveAll();
            //Cache.MyPlayer.Ped.Weapons.Give(WeaponHash.Parachute, 1, true, true);

            //HUD.ShowAdvancedNotification($"Ti è stato dato un paracadute per la sfida ~b~{Name}~w~", "Paracadute consegnato", "", "CHAR_AMMUNATION", "CHAR_AMMUNATION", HudColor.HUD_COLOUR_REDDARK, default(System.Drawing.Color), false, NotificationType.Bubble);
            //await VehicleManager.SpawnEventVehicles(VehicleSpawnLocations);
            //HUD.ShowAdvancedNotification("Velivoli di ogni genere avvistati in tutta Los Santos! Molti pronti per il decollo sono all'AILS.", "Fly By Intel", "From: Josef", "CHAR_JOSEF", "CHAR_JOSEF", HudColor.HUD_COLOUR_REDDARK, Color.FromArgb(255, 255, 255, 255), true, NotificationType.Mail);

            ClientMain.Instance.AddTick(OnTick);
            base.OnEventActivated();
        }
        private async Task OnTick()
        {
            try
            {
                if (!IsActive) { return; }

                if (!IsStarted)
                {
                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_PREPARE").Replace("~a~", Name), 50);
                }
                else
                {
                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_13"), 50);
                    if (Cache.PlayerCache.MyPlayer.Ped.IsInFlyingVehicle || !Cache.PlayerCache.MyPlayer.Ped.Weapons.HasWeapon(WeaponHash.Parachute))
                        Cache.PlayerCache.MyPlayer.Ped.Weapons.Give(WeaponHash.Parachute, 1, true, true);
                    float x = 0f;
                    StatGetFloat(unchecked((uint)PlayerStat), ref x, -1);
                    if (x != 0)
                    {
                        CurrentAttempt = x;
                        if (CurrentAttempt > BestAttempt)
                            BestAttempt = CurrentAttempt;
                        StatSetFloat(unchecked((uint)PlayerStat), 0, true);
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
            base.ResetEvent();
            ClientMain.Instance.RemoveTick(OnTick);
        }
    }
}
