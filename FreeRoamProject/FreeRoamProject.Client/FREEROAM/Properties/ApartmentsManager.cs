using FreeRoamProject.Client.FREEROAM.Properties.Appartamenti.Case;
using FreeRoamProject.Client.FREEROAM.Vehicles;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Properties
{
    internal static class ApartmentsManager
    {
        private static ConfigPropertiesRP Properties;
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }
        public static void Spawned(PlayerClient client)
        {
            //Properties = ClientMain..Settings.RolePlay.Properties;
        }
        public static void onPlayerLeft(PlayerClient client)
        {
            //Properties = null;
        }

        public static async Task MarkerOutside()
        {
            Ped playerPed = Cache.PlayerCache.MyClient.Ped;

            foreach (KeyValuePair<string, ConfigHouses> app in Properties.Apartments)
            {
                if (playerPed.IsInRangeOf(app.Value.MarkerEntrance.ToVector3, 1.375f))
                {
                    Notifications.ShowHelpNotification("Press ~INPUT_CONTEXT~ to ~y~enter or buzz~w~.");
                    if (Input.IsControlJustPressed(Control.Context) && !MenuHandler.IsAnyMenuOpen)
                        ApartmentsClient.EnterMenu(app);
                    // TODO: TO BE ADDED A CHECK IF IT'S MY HOUSE OR NOT IN THE MENU AND LET THE PLAYER DECIDE WHAT TO DO
                }

                if (!playerPed.IsInRangeOf(app.Value.MarkerGarageExtern.ToVector3, 3f)) continue;
                if (!Cache.PlayerCache.MyClient.User.Character.Properties.Contains(app.Key)) continue;

                if (Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle)
                {
                    string plate = playerPed.CurrentVehicle.Mods.LicensePlate;
                    int model = playerPed.CurrentVehicle.Model.Hash;

                    if (Cache.PlayerCache.MyClient.User.Character.Vehicles.FirstOrDefault(x => x.Plate == plate && x.VehData.Props.Model == model) == null)
                        continue;
                    if (playerPed.IsVisible)
                        NetworkFadeOutEntity(playerPed.CurrentVehicle.Handle, true, false);
                    Screen.Fading.FadeOut(500);
                    await BaseScript.Delay(1000);
                    VehProp vehProps = await playerPed.CurrentVehicle.GetVehicleProperties();
                    EventDispatcher.Send("lprp:vehInGarage", plate, true, vehProps.ToJson(settings: JsonHelper.IgnoreJsonIgnoreAttributes));
                    Cache.PlayerCache.MyClient.Status.Instance.InstancePlayer(app.Key);
                    await BaseScript.Delay(1000);

                    if (playerPed.CurrentVehicle.PassengerCount > 0)
                    {
                        foreach (Ped p in playerPed.CurrentVehicle.Passengers)
                        {
                            Player pl = Functions.GetPlayerFromPed(p);
                            PlayerClient pp = Functions.GetPlayerClientFromServerId(pl.ServerId);
                            pp.Status.Instance.InstancePlayer(Cache.PlayerCache.MyClient.Player.ServerId, Cache.PlayerCache.MyClient.Status.Instance.Instance);
                            // TODO: DO WE REALLY NEED TO HANDLE THIS FROM THE SERVER?
                            EventDispatcher.Send("tlg:enterGarageWithOwner", app.Value.SpawnGarageWalkInside);
                        }
                    }

                    playerPed.CurrentVehicle.Delete();
                    RequestCollisionAtCoord(app.Value.SpawnGarageWalkInside.X, app.Value.SpawnGarageWalkInside.Y, app.Value.SpawnGarageWalkInside.Z);
                    NewLoadSceneStart(app.Value.SpawnGarageWalkInside.X, app.Value.SpawnGarageWalkInside.Y, app.Value.SpawnGarageWalkInside.Z, app.Value.SpawnGarageWalkInside.X, app.Value.SpawnGarageWalkInside.Y, app.Value.SpawnGarageWalkInside.Z, 50f, 0);
                    int tempTimer = GetGameTimer();

                    // Wait for the new scene to be loaded.
                    while (IsNetworkLoadingScene())
                    {
                        // If this takes longer than 1 second, just abort. It's not worth waiting that long.
                        if (GetGameTimer() - tempTimer > 1000)
                        {
                            ClientMain.Logger.Debug("Waiting for the scene to load is taking too long (more than 1s). Breaking from wait loop.");

                            break;
                        }

                        await BaseScript.Delay(0);
                    }

                    SetEntityCoords(PlayerPedId(), app.Value.SpawnGarageWalkInside.X, app.Value.SpawnGarageWalkInside.Y, app.Value.SpawnGarageWalkInside.Z, false, false, false, false);
                    tempTimer = GetGameTimer();

                    // Wait for the collision to be loaded around the entity in this new location.
                    while (!HasCollisionLoadedAroundEntity(playerPed.Handle))
                    {
                        // If this takes too long, then just abort, it's not worth waiting that long since we haven't found the real ground coord yet anyway.
                        if (GetGameTimer() - tempTimer > 1000)
                        {
                            ClientMain.Logger.Debug("Waiting for the collision is taking too long (more than 1s). Breaking from wait loop.");

                            break;
                        }

                        await BaseScript.Delay(0);
                    }

                    foreach (OwnedVehicle veh in Cache.PlayerCache.MyClient.User.Character.Vehicles.Where(veh => veh.Garage.ID == Cache.PlayerCache.MyClient.Status.Instance.Instance).Where(veh => veh.Garage.InGarage))
                    {
                        Vehicle veic = await Functions.SpawnLocalVehicle(veh.VehData.Props.Model, new Vector3(ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].X, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Y, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Z), ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Heading);
                        veic.SetVehicleProperties(veh.VehData.Props);
                        ApartmentsClient.VeicoliParcheggio.Add(veic);
                    }

                    NetworkFadeInEntity(playerPed.Handle, true);
                    playerPed.IsPositionFrozen = false;
                    DoScreenFadeIn(500);
                    SetGameplayCamRelativePitch(0.0f, 1.0f);
                    ClientMain.Instance.AddTick(ApartmentsClient.Garage);
                }
                else
                {
                    // TODO: CODE FOR ENTERING BY FOOT, DO WE WANT THE PLAYER TO ENTER BY FOOT HERE?
                }
            }

            foreach (KeyValuePair<string, Garages> gar in Properties.Garages.Garages.Where(gar => playerPed.IsInRangeOf(gar.Value.MarkerEntrance.ToVector3, 1.5f)).Where(gar => playerPed.IsOnFoot))
            {
                // TODO: GET IN THE GARAGES
            }
        }

        static bool exitMenuOpen = false;
        public static async Task MarkerInside()
        {
            Ped playerPed = Cache.PlayerCache.MyClient.Ped;

            if (Cache.PlayerCache.MyClient.Status.Instance.Instanced)
            {
                if (Properties.Apartments.ContainsKey(Cache.PlayerCache.MyClient.Status.Instance.Instance))
                {
                    ConfigHouses app = Properties.Apartments[Cache.PlayerCache.MyClient.Status.Instance.Instance];

                    if (playerPed.IsInRangeOf(app.MarkerExit.ToVector3, 1.375f) || playerPed.IsInRangeOf(app.MarkerGarageInternal.ToVector3, 1.375f))
                    {
                        if (!exitMenuOpen)
                        {
                            ApartmentsClient.ExitMenu(app, playerPed.IsInRangeOf(app.MarkerGarageInternal.ToVector3, 1.375f));
                            exitMenuOpen = true;
                        }
                    }
                }
            }
        }
    }
}