using FreeRoamProject.Client.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    // veeeeery old class... 
    static class HudManager
    {
        public static bool MapEnabled = false;
        public static bool HudEnabled = false;
        public static bool ShowPlayerBlips = true;

        private static List<int> PlayerBlips = new List<int>();

        public static void Init()
        {
            //ClientMain.Instance.AddTick(OnHudTick);
            //ClientMain.Instance.AddEventHandler("onClientResourceStart", new Action<string>(OnClientResourceStart)); find new event name
            EventDispatcher.Mount("worldeventsManage.Client:GetLevelXp", new Action<int, int>(OnGetLevelXp));
        }

        public static void Stop()
        {
            //ClientMain.Instance.RemoveTick(OnHudTick);
            //ClientMain.Instance.AddEventHandler("onClientResourceStart", new Action<string>(OnClientResourceStart)); find new event name
            EventDispatcher.Unmount("worldeventsManage.Client:GetLevelXp");
        }

        private static async Task OnHudTick()
        {
            Screen.Hud.HideComponentThisFrame(HudComponent.AreaName);
            Screen.Hud.HideComponentThisFrame(HudComponent.StreetName);
            Screen.Hud.HideComponentThisFrame(HudComponent.VehicleName);
            /*
            if (Hud.WarningDisplayed)
            {
                Hud.ShowWarningMessage();
            }
            */
            DrawVehicleHud();

            if (ShowPlayerBlips)
            {
                DrawPlayerBlips();
            }

            await Task.FromResult(0);
        }

        private static void OnClientResourceStart(string resource)
        {
            if (GetCurrentResourceName() != resource) { return; }

            DisplayRadar(true);
        }

        public static void OnEnableMap(bool enable)
        {
            MapEnabled = enable;
            DisplayRadar(MapEnabled);
        }

        private static void OnGetLevelXp(int level, int xp)
        {
            PlayerCache.MyClient.User.Character.Level = level;
            PlayerCache.MyClient.User.Character.TotalXp = xp;
            ClientMain.Logger.Info($"OnGetLevelXp | Level [{level}] | XP [{xp}]");
            BaseScript.TriggerEvent("worldeventsManage.Client:UpdatedLevel", level, false); // to update because it does not exist in the code
        }

        private static void DrawVehicleHud()
        {
            if (VehicleChecker.CurrentVehicle != null)
            {
                double vehicleSpeed = Math.Round(VehicleChecker.CurrentVehicle.Speed * 3.6);
                SetTextFont(0);
                SetTextProportional(true);
                SetTextScale(0.0f, 0.35f);
                SetTextColour(255, 255, 255, 255);
                SetTextDropshadow(0, 0, 0, 0, 255);
                SetTextEdge(1, 0, 0, 0, 255);
                SetTextDropShadow();
                SetTextOutline();
                SetTextWrap(0f, 0.125f);
                SetTextRightJustify(true);
                SetTextEntry("STRING");
                AddTextComponentString(vehicleSpeed.ToString());
                DrawText(1f - 0.124f, 0.945f);

                SetTextFont(0);
                SetTextProportional(true);
                SetTextScale(0.0f, 0.35f);
                SetTextColour(255, 255, 255, 255);
                SetTextDropshadow(0, 0, 0, 0, 255);
                SetTextEdge(1, 0, 0, 0, 255);
                SetTextDropShadow();
                SetTextOutline();
                SetTextEntry("STRING");
                AddTextComponentString("km/h");
                DrawText(0.1275f, 0.945f);

            }
        }

        private static void DrawPlayerBlips()
        {
            for (int i = 0; i < 64; i++)
            {
                if (!NetworkIsPlayerActive(i) || GetPlayerPed(i) == PlayerPedId()) continue;
                int player = GetPlayerPed(i);
                int blip = GetBlipFromEntity(player);
                if (!DoesBlipExist(blip))
                {
                    blip = AddBlipForEntity(player);
                    SetBlipSprite(blip, 1);
                    ShowHeadingIndicatorOnBlip(blip, true);
                }
                else
                {
                    int playerVeh = GetVehiclePedIsUsing(player);
                    int blipSprite = GetBlipSprite(blip);
                    if (playerVeh != 0)
                    {
                        Vehicle currentVehicle = new Vehicle(playerVeh);
                        switch (currentVehicle.ClassType)
                        {
                            case VehicleClass.Helicopters:
                                if (blipSprite != (int)BlipSprite.HelicopterAnimated)
                                {
                                    SetBlipSprite(blip, (int)BlipSprite.HelicopterAnimated);
                                    ShowHeadingIndicatorOnBlip(blip, false);
                                }

                                break;
                            case VehicleClass.Planes:
                                if (currentVehicle.Model == VehicleHash.Besra ||
                                    currentVehicle.Model == VehicleHash.Lazer ||
                                    currentVehicle.Model == VehicleHash.Hydra)
                                {
                                    if (blipSprite != 424)
                                    {
                                        SetBlipSprite(blip, 424);
                                        ShowHeadingIndicatorOnBlip(blip, false);
                                    }
                                }
                                else if (blipSprite != (int)BlipSprite.Plane)
                                {
                                    SetBlipSprite(blip, (int)BlipSprite.Plane);
                                    ShowHeadingIndicatorOnBlip(blip, false);
                                }

                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (blipSprite != (int)BlipSprite.Standard)
                        {
                            SetBlipSprite(blip, (int)BlipSprite.Standard);
                            ShowHeadingIndicatorOnBlip(blip, true);
                        }
                    }

                    SetBlipRotation(blip, (int)Math.Ceiling(GetEntityHeading(player)));
                    SetBlipNameToPlayerName(blip, i);
                    SetBlipScale(blip, 0.85f);
                    if (Game.IsPaused)
                    {
                        SetBlipAlpha(blip, 255);
                    }
                    else
                    {
                        Vector3 playerCoords = GetEntityCoords(player, true);
                        Vector3 myCoords = Cache.PlayerCache.MyClient.Ped.Position;

                        int alpha = 0;
                        if (myCoords.DistanceToSquared(playerCoords) < 40000f)
                        {
                            alpha = 255;
                        }

                        SetBlipAlpha(blip, alpha);
                    }
                }
            }
        }
    }
}
