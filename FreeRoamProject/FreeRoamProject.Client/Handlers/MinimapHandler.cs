using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    internal static class MinimapHandler
    {
        private static bool hideRadar;
        private static bool enableMinimap;
        private static bool showPlayerBlips;

        public static bool HideRadar { get => hideRadar; set => hideRadar = value; }
        public static bool EnableMinimap { get => enableMinimap; set => enableMinimap = value; }
        public static bool ShowPlayerBlips { get => showPlayerBlips; set => showPlayerBlips = value; }

        public static void Init()
        {
            TickController.TickHUD.Add(MinimapTick);
            AccessingEvents.OnFreeRoamSpawn += OnPlayerJoined;
            AccessingEvents.OnFreeRoamLeave += OnPlayerLeft;
        }

        private static async Task MinimapTick()
        {
            if (hideRadar)
            {
                DisableRadarThisFrame();
            }
            if (!enableMinimap)
            {
                if (IsRadarEnabled() && !IsRadarHidden())
                {
                    DisplayRadar(false);
                }
            }
            else
            {
                if (!IsRadarEnabled() && IsRadarHidden())
                {
                    DisplayRadar(true);
                }
            }
            await Task.FromResult(0);
        }

        private static readonly List<int> JetHashes = new() { 970385471, -1281684762, 1824333165 };

        private static void OnPlayerJoined(PlayerClient client)
        {
            ClientMain.Instance.AddTick(Blips);
        }

        public static void OnPlayerLeft(PlayerClient client)
        {
            ClientMain.Instance.RemoveTick(Blips);
        }

        public static async Task Blips()
        {
            await BaseScript.Delay(15);
            foreach (PlayerClient client in ClientMain.Instance.Clients)
            {
                if (client.Handle == PlayerCache.MyClient.Handle) continue;
                if (client.Status != null && client.Status.PlayerStates.Spawned)
                {
                    if (client.Ped.AttachedBlip != null)
                    {
                        Blip blip = client.Ped.AttachedBlip;
                        BlipSprite sprite = BlipSprite.Standard;
                        ShowHeadingIndicatorOnBlip(blip.Handle, true);
                        if (client.Status.PlayerStates.InVehicle)
                        {
                            Vehicle vehicle = client.Ped.CurrentVehicle;
                            Model model = vehicle.Model;
                            //TODO: ADD CHECKS FOR OTHER VEHICLES LIKE TANK, KHANJALI, KURUMA2, DLC VEHICLES
                            //TODO: ADD CHECKS FOR WHEN PLAYER IS AT HOME AND ADD THE RELATIVE BLIP
                            if (model.IsHelicopter)
                            {
                                sprite = BlipSprite.HelicopterAnimated;
                                ShowHeadingIndicatorOnBlip(blip.Handle, false);
                                SetBlipSquaredRotation(blip.Handle, client.Ped.Heading);
                            }
                            else if (model.IsPlane && !JetHashes.Contains(model))
                            {
                                sprite = BlipSprite.Plane;
                                ShowHeadingIndicatorOnBlip(blip.Handle, false);
                                SetBlipSquaredRotation(blip.Handle, client.Ped.Heading);
                            }
                            else if (JetHashes.Contains(model))
                            {
                                sprite = BlipSprite.Jet;
                                ShowHeadingIndicatorOnBlip(blip.Handle, false);
                                SetBlipSquaredRotation(blip.Handle, client.Ped.Heading);
                            }
                            /*
                            else if (model.IsBoat)
                                sprite = (BlipSprite)427;
                            else if (model.IsBike)
                                sprite = (BlipSprite)226;
                            else if (model.IsCar)
                                sprite = (BlipSprite)225;
                            */
                        }
                        if (sprite != blip.Sprite)
                        {
                            blip.Sprite = sprite;
                            SetBlipNameToPlayerName(blip.Handle, client.Player.Handle);
                        }
                    }
                    else
                    {
                        Blip blip = client.Ped.AttachBlip();
                        blip.Sprite = BlipSprite.Standard;
                        SetBlipCategory(blip.Handle, 7);
                        SetBlipDisplay(blip.Handle, 4);
                        SetBlipShrink(blip.Handle, false);
                        SetBlipHighDetail(blip.Handle, true);
                        SetBlipPriority(blip.Handle, 1);
                        //SetBlipShowCone(blip.Handle, true);
                        ShowHeadingIndicatorOnBlip(blip.Handle, true);
                        SetBlipNameToPlayerName(blip.Handle, client.Player.Handle);
                        //TODO: ADD CHECK FOR FRIENDS BLIPS AND EXECUTION BLIPS AND ENEMIES BLIPS
                        // ShowCrewIndicatorOnBlip / ShowFriendIndicatorOnBlip
                    }
                }
            }
        }
    }
}
