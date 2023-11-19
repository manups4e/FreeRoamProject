using FreeRoamProject.Client.GameMode.FREEROAM.Managers;
using FreeRoamProject.Client.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class FlyingUnderBridges : IWorldEvent
    {
        private static Dictionary<Vector3, bool> UnderBridgeLocations = new Dictionary<Vector3, bool>
        {
            {new Vector3(1083.0f, -231.0f, 60.0f), false},
            {new Vector3(1024.0f, -325.0f, 60.0f), false},
            {new Vector3(910.0f, -401.0f, 43.0f), false},
            {new Vector3(721.0f, -457.0f, 26.0f), false},
            {new Vector3(643.0f, -579.0f, 26.0f), false},
            {new Vector3(590.0f, -851.0f, 26.0f), false},
            {new Vector3(590.0f, -1023.0f, 16.0f), false},
            {new Vector3(582.0f, -1205.0f, 24.0f), false},
            {new Vector3(608.0f, -1335.0f, 16.0f), false},
            {new Vector3(640.0f, -1434.0f, 16.0f), false},
            {new Vector3(671.0f, -1742.0f, 20.0f), false},
            {new Vector3(651.0f, -2046.0f, 16.0f), false},
            {new Vector3(603.0f, -2505.0f, 9.0f), false},
            {new Vector3(673.0f, -2582.0f, 4.0f), false},
            {new Vector3(728.0f, -2594.0f, 10.0f), false},
            {new Vector3(794.0f, -2624.0f, 27.0f), false},
            {new Vector3(-2663.0f, 2594.0f, 7.5f), false},
            {new Vector3(-1902.0f, 4617.0f, 30.0f), false},
            {new Vector3(-513.0f, 4427.0f, 40.0f), false},
            {new Vector3(126.0f, 3366.0f, 40.0f), false},
            {new Vector3(143.0f, 3418.0f, 36.0f), false},
            {new Vector3(2822.0f, 4978.0f, 40.0f), false},
            {new Vector3(-162.0f, 4249.0f, 40.0f), false},
            {new Vector3(-408.0f, 2964.0f, 20.0f), false},
            {new Vector3(-181.0f, 2862.0f, 38.0f), false},
            {new Vector3(2558.0f, 2201.0f, 24.0f), false},
            {new Vector3(2950.0f, 803.0f, 8.0f), false},
            {new Vector3(2369.0f, -409.0f, 80.0f), false},
            {new Vector3(1906.0f, -755.0f, 84.0f), false},
            {new Vector3(-403.0f, -2333.0f, 40.0f), false},
            {new Vector3(-1429.0f, 2649.0f, 10.0f), false},
            {new Vector3(219.0f, -2315.0f, 5.0f), false},
            {new Vector3(350.0f, -2315.0f, 5.0f), false},
            {new Vector3(-1848.0f, -333.0f, 75.0f), false},
            {new Vector3(-693.0f, -608.0f, 69.0f), false},
            {new Vector3(-1461.0f, -582.0f, 53.0f), false},
            {new Vector3(-1553.0f, -546.0f, 59.0f), false},
            {new Vector3(338.0f, -2758.0f, 23.0f), false},
            {new Vector3(1985.0f, 6201.0f, 53.0f), false},
            {new Vector3(-713.0f, -1538.0f, 13.0f), false},
            {new Vector3(-659.0f, -1518.0f, 13.0f), false},
            {new Vector3(-620.0f, -1502.0f, 16.0f), false},
            {new Vector3(-445.0f, -1575.0f, 26.0f), false},
            {new Vector3(-373.0f, -1680.0f, 19.0f), false},
            {new Vector3(-212.0f, -1805.0f, 29.0f), false},
            {new Vector3(47.0f, -2040.0f, 18.0f), false},
            {new Vector3(-3080.0f, 766.0f, 25.0f), false},
            {new Vector3(-1478.0f, 2400.0f, 20.0f), false},
            {new Vector3(2308.0f, 1124.0f, 78.0f), false},
            {new Vector3(2349.0f, 1174.0f, 79.0f), false},
            {new Vector3(-1186.0f, -365.0f, 46.0f), false},
            {new Vector3(-916.0f, -407.0f, 93.0f), false},
            {new Vector3(-726.0f, 235.0f, 105.0f), false},
            {new Vector3(-774.0f, 286.0f, 112.0f), false},
            {new Vector3(271.0f, 134.0f, 125.0f), false},
            {new Vector3(377.0f, -28.0f, 125.0f), false},
            {new Vector3(121.0f, -703.0f, 150.0f), false},
            {new Vector3(-204.0f, -784.0f, 74.0f), false},
            {new Vector3(-287.0f, -774.0f, 72.0f), false},
            {new Vector3(-272.0f, -824.0f, 71.0f), false},
            {new Vector3(-230.0f, -723.0f, 80.0f), false},
            {new Vector3(1822.0f, 2044.0f, 62.0f), false},
            {new Vector3(2410.0f, 2907.0f, 44.0f), false},
            {new Vector3(2686.0f, 4858.0f, 36.0f), false},
            {new Vector3(-1046.0f, 4751.0f, 244.0f), false},
            {new Vector3(-213.0f, -2463.0f, 38.0f), false},
            {new Vector3(-597.0f, -2192.0f, 38.0f), false},
            {new Vector3(1036.0f, -980.0f, 41.0f), false},
            {new Vector3(980.0f, -837.0f, 42.0f), false},
            {new Vector3(1208.0f, -1173.0f, 38.0f), false}
        };

        public new Dictionary<Vector4, VehicleHash> VehicleSpawnLocations = new Dictionary<Vector4, VehicleHash>
        {
            {new Vector4(-1158.893f, -1738.877f, 4.055f,215.483f), VehicleHash.Buzzard2 },
            {new Vector4(-1168.874f, -1746.419f, 3.998f,124.725f), VehicleHash.Buzzard2},
            {new Vector4(-1603.944f, -2794.439f, 13.971f,240.045f), VehicleHash.Lazer},
            {new Vector4(-978.337f, -3349.99f, 13.944f,58.062f), VehicleHash.Stunt},
            {new Vector4(449.143f, -981.273f, 43.692f,90.059f), VehicleHash.Buzzard2},
            {new Vector4(699.427f, -491.963f, 15.881f,176.157f), VehicleHash.Buzzard2},
            {new Vector4(1264.816f, 188.245f, 81.863f,146.089f), VehicleHash.Stunt},
            {new Vector4(1053.443f, 3081.934f, 41.469f,241.713f), VehicleHash.Lazer },
            {new Vector4(1769.635f, 3239.461f, 42.125f,280.808f), VehicleHash.Buzzard2 },
            {new Vector4(2208.907f, 4651.732f, 31.229f,164.052f), VehicleHash.Dodo},
            {new Vector4(2131.084f, 4803.199f, 41.046f,118.359f), VehicleHash.Stunt},
            {new Vector4(-745.328f, -1468.634f, 5.001f,142.71f), VehicleHash.Buzzard2},
            {new Vector4(568.12f, -739.669f, 11.996f,174.5f), VehicleHash.Lazer},
            {new Vector4(-1706.891f, -815.918f, 9.427f,45.216f), VehicleHash.Stunt},
            {new Vector4(1491.408f, -1973.71f, 70.816f,339.805f), VehicleHash.Stunt},
            {new Vector4(-252.804f, -2537.156f, 6.004f,158.885f),  VehicleHash.Buzzard2},
            {new Vector4(313.394f, -1465.316f, 46.509f,43.926f), VehicleHash.Buzzard2},
            {new Vector4(1175.107f, 278.744f, 81.871f,120.01f),  VehicleHash.Buzzard2},
            {new Vector4(478.547f, -3370.131f, 6.07f,355.228f),  VehicleHash.Buzzard2},
            {new Vector4(-1268.469f, -3375.488f, 13.94f,326.586f), VehicleHash.Lazer},
            {new Vector4(-1253.342f, -3385.56f, 13.94f,330.219f), VehicleHash.Lazer},
            {new Vector4(-1052.381f, -3493.217f, 14.143f,29.211f),VehicleHash.Buzzard2 },
            {new Vector4(-1231.069f, -2879.385f, 13.945f,148.996f), VehicleHash.Lazer},
            {new Vector4(-1340.997f, -2218.804f, 13.945f,146.772f), VehicleHash.Lazer},
            {new Vector4(-981.205f, -2990.385f, 13.945f,58.785f), VehicleHash.Stunt},
            {new Vector4(-321.589f, -2548.515f, 6.001f,50.188f), VehicleHash.Stunt},
            {new Vector4(1401.903f, 2998.903f, 40.553f,315.416f), VehicleHash.Lazer},
            {new Vector4(1077.437f, 3011.685f, 41.354f,285.25f), VehicleHash.Lazer},
            { new Vector4(1732.836f, 3305.026f, 41.224f,195.137f), VehicleHash.Stunt},
        };

        private static List<Blip> ActiveBlips = new List<Blip>();

        public FlyingUnderBridges(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, false, "AMCH_BRBL2", PlayerStats.FlyUnderBridges)
        {
        }

        public async override void OnEventActivated()
        {
            uint hash = (uint)GetHashKey("mp0_fly_under_bridges");
            StatSetInt(hash, 0, true);

            MinimapHandler.EnableMinimap = true;
            //HudManager.OnEnableMap(true);
            ActiveBlips.Clear();

            await VehicleManager.SpawnEventVehicles(VehicleSpawnLocations);

            Notifications.ShowAdvancedNotification("Aircrafts of all kinds spotted all over Los Santos! Many ready for takeoff are at AILS.", "Fly By Intel", "From: Josef", "CHAR_JOSEF", "CHAR_JOSEF", HudColor.HUD_COLOUR_REDDARK, SColor.FromArgb(255, 255, 255, 255), true, NotificationType.Mail);

            base.OnEventActivated();

            await BaseScript.Delay(60000);
            foreach (Vector3 bridge in UnderBridgeLocations.Keys.ToList())
            {
                UnderBridgeLocations[bridge] = false;
                Blip blip = World.CreateBlip(bridge);
                blip.Sprite = BlipSprite.Standard;
                blip.Color = BlipColor.Yellow;
                blip.IsShortRange = true;
                blip.Name = "Bridge";

                ActiveBlips.Add(blip);
            }
            ClientMain.Instance.AddTick(OnTick);
        }

        public override void ResetEvent()
        {
            base.ResetEvent();
            foreach (Blip blip in ActiveBlips)
            {
                blip.Delete();
            }

            ActiveBlips.Clear();

            ClientMain.Instance.RemoveTick(OnTick);
        }

        private async Task OnTick()
        {
            try
            {
                if (!IsActive) { return; }

                if (!IsStarted)
                {
                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_PREPAIR").Replace("~a~", Name), 50);
                }
                else
                {
                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_BRBL2"), 50);

                    Vehicle currentVehicle = VehicleChecker.CurrentVehicle;
                    if (currentVehicle == null) { return; }

                    if (!Cache.PlayerCache.MyPlayer.Ped.IsInFlyingVehicle) { return; }

                    Vector3 vehiclePos = currentVehicle.Position;
                    foreach (Vector3 bridge in UnderBridgeLocations.Keys.ToList())
                    {
                        if (!UnderBridgeLocations[bridge])
                        {

                            float dist = vehiclePos.DistanceToSquared(bridge);
                            if (dist > 90000f) { continue; }
                            World.DrawMarker(MarkerType.HorizontalCircleFat, bridge, Vector3.Zero, new Vector3(90, 90, 0), new Vector3(22f), Color.FromArgb(150, 240, 200, 80), faceCamera: true);
                            World.DrawMarker(MarkerType.ChevronUpx2, bridge, Cache.PlayerCache.MyPlayer.Ped.ForwardVector, new Vector3(90, 90, 0), new Vector3(11f), Color.FromArgb(110, 93, 182, 229));

                            if (dist < 225f)
                            {
                                uint hash = (uint)GetHashKey("mp0_fly_under_bridges");

                                UnderBridgeLocations[bridge] = true;
                                Blip blip = ActiveBlips.Where(b => b.Position == bridge).FirstOrDefault();
                                if (blip != null)
                                {
                                    ActiveBlips.Remove(blip);
                                    blip.Delete();
                                }

                                int x = (int)CurrentAttempt;
                                int y = x + 1;
                                StatIncrement(hash, 1);

                                int p = 0;
                                StatGetInt(unchecked((uint)PlayerStat), ref p, -1);
                                CurrentAttempt = p;

                                if (CurrentAttempt > BestAttempt)
                                    BestAttempt = CurrentAttempt;

                                if (dist < 25f)
                                    Audio.PlaySoundFrontend("CHECKPOINT_PERFECT", "HUD_MINI_GAME_SOUNDSET");
                                else
                                    Audio.PlaySoundFrontend("CHECKPOINT_NORMAL", "HUD_MINI_GAME_SOUNDSET");
                            }
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
