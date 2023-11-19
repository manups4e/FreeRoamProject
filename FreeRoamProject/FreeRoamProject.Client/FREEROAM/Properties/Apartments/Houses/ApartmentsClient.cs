using FreeRoamProject.Client.FREEROAM.Vehicles;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Properties.Appartamenti.Case
{
    // TODO: IMPLEMENT THE ONLINE SYSTEM, WHERE YOU GO NEAR THE DOORS AND THE ENTERING ANIMATION STARTS AUTOMATICALLY
    // IF THERE'S MULTIPLE PLAYERS IN THE BUILDING, CHECK THAT VIA MENU LIKE IN ONLINE.
    /*
      "MP_PROP_BUZ0": "Accept",
      "MP_PROP_BUZ1": "Reject",
      "MP_PROP_BUZZ_C": "Someone is buzzing your Clubhouse. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ_Y": "Someone is buzzing your Yacht. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0": "Someone is buzzing your Apartment. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0B": "Someone is buzzing your Garage. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0C": "Someone is buzzing your Apartment. ~n~Walk to the Apartment door to answer the buzzer.",
      "MP_PROP_BUZZ0D": "Someone is buzzing your Office Garage. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ1": "Press ~INPUT_CONTEXT~ to buzz Apartment.",
      "MP_PROP_BUZZ1B": "Press ~INPUT_CONTEXT~ to buzz Garage.",
      "MSG_BUZZ_RC": "Someone is buzzing Eclipse Blvd Garage.~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "PROP_OFF_M_6": "Someone is buzzing your Office. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer or speak to the Executive Assistant",
      "PROP_OFF_M_6F": "Someone is buzzing your Office. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer or speak to the Executive Assistant",
      "PROP_OFFG_M_6": "Someone is buzzing your Office Garage. ~n~Walk to the entrance to answer the buzzer.",
      "ARENA_BUZZ_RC": "Someone is buzzing your Arena Workshop. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer",
      "CAS_APT_BUZZ_RC": "Someone is buzzing your Penthouse. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "FHQ_BUZZ_RC": "Someone is buzzing your Agency. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "JH_BUZZ_RC": "Someone is buzzing The Freakshop.~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
     
      many other labels to check, for requesting buzz, and for menus.
     */

    internal static class ApartmentsClient
    {
        public static List<Vehicle> VeicoliParcheggio = new List<Vehicle>();

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }
        public static void Spawned(PlayerClient client)
        {
            ClientMain.Instance.AddEventHandler("tlg:enterRequest", new Action<int, string>(Request));
            ClientMain.Instance.AddEventHandler("tlg:buzz:canEnter", new Action<int, string>(CanEnter));
            ClientMain.Instance.AddEventHandler("tlg:enterGarageWithOwner", new Action<Vector3>(EnterGarageWithOwner));
            // TODO: THIS MUST BE LOADED FROM THE SETTINGS or even better.. this is from the RP side where you'd load the real estate apartments to sell..
            ClientMain.Instance.AddEventHandler("lprp:housedealer:caricaImmobiliDaDB", new Action<string, string>(LoadHousesFromDB));
        }

        public static void onPlayerLeft(PlayerClient client)
        {
            ClientMain.Instance.RemoveEventHandler("tlg:enterRequest", new Action<int, string>(Request));
            ClientMain.Instance.RemoveEventHandler("tlg:buzz:canEnter", new Action<int, string>(CanEnter));
            ClientMain.Instance.RemoveEventHandler("tlg:enterGarageWithOwner", new Action<Vector3>(EnterGarageWithOwner));
            ClientMain.Instance.RemoveEventHandler("lprp:housedealer:caricaImmobiliDaDB", new Action<string, string>(LoadHousesFromDB));

            ClientMain.Settings.FreeRoam.Properties.Apartments.Clear();
            ClientMain.Settings.FreeRoam.Properties.Garages.Garages.Clear();
        }

        private static async void LoadHousesFromDB(string JsonCase, string jsonGarage)
        {
            Dictionary<string, string> aparts = JsonCase.FromJson<Dictionary<string, string>>();
            Dictionary<string, string> garages = jsonGarage.FromJson<Dictionary<string, string>>();
            foreach (KeyValuePair<string, string> a in aparts) ClientMain.Settings.FreeRoam.Properties.Apartments.Add(a.Key, a.Value.FromJson<ConfigHouses>());
            foreach (KeyValuePair<string, string> a in garages) ClientMain.Settings.FreeRoam.Properties.Garages.Garages.Add(a.Key, a.Value.FromJson<Garages>());
        }

        public static async void EnterMenu(KeyValuePair<string, ConfigHouses> app)
        {
            Camera dummycam = World.CreateCamera(GameplayCamera.Position, GameplayCamera.Rotation, GameplayCamera.FieldOfView);
            World.RenderingCamera = dummycam;
            Camera cam = World.CreateCamera(app.Value.CameraOutside.Pos.ToVector3, new Vector3(0), GameplayCamera.FieldOfView);
            cam.PointAt(app.Value.CameraOutside.Rotation.ToVector3);
            RenderScriptCams(true, true, 1500, true, false);
            dummycam.InterpTo(cam, 1500, 1, 1);
            UIMenu home = new UIMenu(app.Value.Label, "Apartments", PointF.Empty, "thelastgalaxy", "bannerbackground", false, true);
            UIMenuItem buzzItem = new UIMenuItem("Intercom to residents");
            UIMenu buzzMenu = new("Intercom to residents", "");
            buzzItem.BindItemToMenu(buzzMenu);
            home.AddItem(buzzItem);
            UIMenuItem enter;

            if (Cache.PlayerCache.MyPlayer.User.Character.Properties.Contains(app.Key))
            {
                enter = new UIMenuItem("Enter the house");
                home.AddItem(enter);
                enter.Activated += async (_submenu, _subitem) =>
                {
                    Cache.PlayerCache.MyPlayer.Status.Instance.InstancePlayer(app.Key);
                    Screen.Fading.FadeOut(500);
                    while (!Screen.Fading.IsFadedOut) await BaseScript.Delay(0);
                    MenuHandler.CloseAndClearHistory();

                    while (cam.IsActive && cam.Exists() && cam != null)
                    {
                        RenderScriptCams(false, false, 1500, true, false);
                        World.RenderingCamera = null;
                        cam.IsActive = false;
                        cam.Delete();
                    }

                    RequestCollisionAtCoord(app.Value.SpawnInside.X, app.Value.SpawnInside.Y, app.Value.SpawnInside.Z);
                    Cache.PlayerCache.MyPlayer.Ped.Position = app.Value.SpawnInside.ToVector3;
                    while (!HasCollisionLoadedAroundEntity(PlayerPedId())) await BaseScript.Delay(1000);
                    await BaseScript.Delay(2000);
                    Screen.Fading.FadeIn(500);
                    NetworkFadeInEntity(PlayerPedId(), true);
                };
            }

            buzzMenu.OnMenuOpen += (_menu, b) =>
            {
                _menu.Clear();
                List<PlayerClient> gioc = (from p in ClientMain.Instance.Clients.ToList() where p != PlayerCache.MyPlayer let pl = p where pl.Status.Instance.Instanced where pl.Status.Instance.IsOwner where pl.Status.Instance.Instance == app.Key select p).ToList();

                if (gioc.Count > 0)
                {
                    foreach (PlayerClient p in gioc.ToList())
                    {
                        UIMenuItem it = new(p.Player.Name) { LabelFont = ScaleformFonts.CHALET_COMPRIME_COLOGNE_SIXTY };
                        _menu.AddItem(it);
                        it.Activated += (_submenu, _subitem) =>
                        {
                            Game.PlaySound("DOOR_BUZZ", "MP_PLAYER_APARTMENT");
                            // params: who's home.serverid, fromsource who buzz
                            EventDispatcher.Send("tlg:buzzPlayer", p.Handle, app.ToJson());
                            MenuHandler.CloseAndClearHistory();
                        };
                    }
                }
                else
                    _menu.AddItem(new UIMenuItem("There are no people home at the moment!"));
            };

            home.OnMenuClose += async (a) =>
            {
                await BaseScript.Delay(100);

                if (MenuHandler.IsAnyMenuOpen) return;
                if (cam.IsActive) RenderScriptCams(false, true, 1500, true, false);
                dummycam.Delete();
                cam.Delete();
            };

            while (dummycam.IsInterpolating) await BaseScript.Delay(0);
            while (cam.IsInterpolating) await BaseScript.Delay(0);
            home.Visible = true;
        }

        public static async void ExitMenu(ConfigHouses app, bool inGarage = false, bool inRoof = false)
        {
            UIMenu esci = new UIMenu(app.Label, "Apartments", PointF.Empty, "", "", false, true);
            UIMenuItem escisci = new UIMenuItem("Exit the apartment");
            esci.AddItem(escisci);
            UIMenuItem garage = new UIMenuItem("", "");
            UIMenuItem roof = new UIMenuItem("", "");
            UIMenuItem home = new UIMenuItem("", "");

            if (inGarage || inRoof)
            {
                home = new UIMenuItem("Enter the house");
                esci.AddItem(home);
            }

            if (app.GarageIncluded && !inGarage)
            {
                garage = new UIMenuItem("Go to the garage");
                esci.AddItem(garage);
            }

            if (app.HasRoof && !inRoof)
            {
                roof = new UIMenuItem("go to the roof");
                esci.AddItem(roof);
            }

            esci.OnItemSelect += async (_menu, _item, _index) =>
            {
                MenuHandler.CloseAndClearHistory();
                if (Cache.PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(PlayerPedId(), true, false);
                Screen.Fading.FadeOut(500);
                while (!Screen.Fading.IsFadedOut) await BaseScript.Delay(0);

                if (_item == escisci)
                {
                    Functions.Teleport(app.SpawnOutside.ToVector3);
                    Cache.PlayerCache.MyPlayer.Status.Instance.RemoveInstance();
                }
                else if (_item == home)
                {
                    Functions.Teleport(app.SpawnInside.ToVector3);
                }
                else if (_item == garage)
                {
                    ClearPedTasksImmediately(Cache.PlayerCache.MyPlayer.Ped.Handle);
                    Cache.PlayerCache.MyPlayer.Ped.IsPositionFrozen = true;
                    if (Cache.PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(PlayerPedId(), true, false);
                    DoScreenFadeOut(500);
                    while (!IsScreenFadedOut()) await BaseScript.Delay(0);
                    RequestCollisionAtCoord(app.SpawnGarageWalkInside.X, app.SpawnGarageWalkInside.Y, app.SpawnGarageWalkInside.Z);
                    NewLoadSceneStart(app.SpawnGarageWalkInside.X, app.SpawnGarageWalkInside.Y, app.SpawnGarageWalkInside.Z, app.SpawnGarageWalkInside.X, app.SpawnGarageWalkInside.Y, app.SpawnGarageWalkInside.Z, 50f, 0);
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

                    SetEntityCoords(PlayerPedId(), app.SpawnGarageWalkInside.X, app.SpawnGarageWalkInside.Y, app.SpawnGarageWalkInside.Z, false, false, false, false);
                    tempTimer = GetGameTimer();

                    // Wait for the collision to be loaded around the entity in this new location.
                    while (!HasCollisionLoadedAroundEntity(Cache.PlayerCache.MyPlayer.Ped.Handle))
                    {
                        // If this takes too long, then just abort, it's not worth waiting that long since we haven't found the real ground coord yet anyway.
                        if (GetGameTimer() - tempTimer > 1000)
                        {
                            ClientMain.Logger.Debug("Waiting for the collision is taking too long (more than 1s). Breaking from wait loop.");

                            break;
                        }

                        await BaseScript.Delay(0);
                    }

                    foreach (OwnedVehicle veh in Cache.PlayerCache.MyPlayer.User.Character.Vehicles)
                    {
                        if (veh.Garage.ID == Cache.PlayerCache.MyPlayer.Status.Instance.Instance)
                        {
                            if (veh.Garage.InGarage)
                            {
                                Vehicle veic = await Functions.SpawnLocalVehicle(veh.VehData.Props.Model, new Vector3(ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].X, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Y, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Z), ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Heading);
                                veic.SetVehicleProperties(veh.VehData.Props);
                                VeicoliParcheggio.Add(veic);
                            }
                        }
                    }

                    NetworkFadeInEntity(Cache.PlayerCache.MyPlayer.Ped.Handle, true);
                    Cache.PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
                    DoScreenFadeIn(500);
                    SetGameplayCamRelativePitch(0.0f, 1.0f);
                    ClientMain.Instance.AddTick(Garage);
                }
                else if (_item == roof)
                {
                    Functions.Teleport(app.SpawnRoof.ToVector3);
                    Cache.PlayerCache.MyPlayer.Status.Instance.RemoveInstance();
                }

                await BaseScript.Delay(2000);
                Screen.Fading.FadeIn(500);
                NetworkFadeInEntity(PlayerPedId(), true);
            };
            esci.Visible = true;
        }

        private static string nome;
        private static string appa;
        private static int serverIdRic;
        private static int tempo;

        public static void Request(int serverIdRichiedente, string app)
        {
            Game.PlaySound("DOOR_BUZZ", "MP_PLAYER_APARTMENT");
            nome = ClientMain.Instance.GetPlayers.ToList().FirstOrDefault(x => x.ServerId == serverIdRichiedente).Name;
            appa = app;
            serverIdRic = serverIdRichiedente;
            tempo = GetGameTimer();
            ClientMain.Instance.AddTick(AccRif);
        }

        private static async Task AccRif()
        {
            Notifications.ShowHelpNotification($"{nome} buzzed you.\n~INPUT_VEH_EXIT~ to accept");

            if (GetGameTimer() - tempo < 30000)
            {
                if (Input.IsControlJustPressed(Control.VehicleExit))
                {
                    EventDispatcher.Send("tlg:buzz:canEnter", serverIdRic, appa);
                    ClientMain.Instance.RemoveTick(AccRif);
                    nome = null;
                    appa = null;
                    serverIdRic = 0;
                    tempo = 0;
                }
            }
            else
            {
                ClientMain.Instance.RemoveTick(AccRif);
                nome = null;
                appa = null;
                serverIdRic = 0;
                tempo = 0;
            }
        }

        public static void CanEnter(int serverIdInCasa, string appartamento)
        {
            KeyValuePair<string, ConfigHouses> app = appartamento.FromJson<KeyValuePair<string, ConfigHouses>>();
            Player InCasa = ClientMain.Instance.GetPlayers.ToList().FirstOrDefault(x => x.ServerId == serverIdInCasa);

            if (InCasa == null) return;
            if (!Cache.PlayerCache.MyPlayer.Ped.IsInRangeOf(app.Value.MarkerEntrance.ToVector3, 3f)) return;
            if (Cache.PlayerCache.MyPlayer.Status.Instance.Instanced) return;
            Cache.PlayerCache.MyPlayer.Status.Instance.InstancePlayer(InCasa.ServerId, app.Key);
            Functions.Teleport(app.Value.SpawnInside.ToVector3);
        }

        public static async Task Garage()
        {
            if (Cache.PlayerCache.MyPlayer.Ped.IsInRangeOf(ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.ModifyMarker.ToVector3, 1.375f))
            {
                // TODO: TO BE HANDLED
            }

            if (Cache.PlayerCache.MyPlayer.Ped.IsInRangeOf(ClientMain.Settings.FreeRoam.Properties.Garages.MidEnd4.ModifyMarker.ToVector3, 1.375f))
            {
                // TODO: TO BE HANDLED
            }

            if (Cache.PlayerCache.MyPlayer.Ped.IsInRangeOf(ClientMain.Settings.FreeRoam.Properties.Garages.MidEnd6.ModifyMarker.ToVector3, 1.375f))
            {
                // TODO: TO BE HANDLED
            }

            if (Cache.PlayerCache.MyPlayer.Ped.IsInRangeOf(ClientMain.Settings.FreeRoam.Properties.Garages.HighEnd.ModifyMarker.ToVector3, 1.375f))
            {
                // TODO: TO BE HANDLED
            }

            if (Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVehicle)
            {
                Notifications.ShowHelpNotification("To select this vehicle and exit~n~~y~Start the engine~w~ and ~y~accelerate~w~.");

                if (Input.IsControlJustPressed(Control.VehicleAccelerate) && VehicleChecker.CurrentVehicle.IsEngineRunning)
                {
                    Screen.Fading.FadeOut(800);
                    await BaseScript.Delay(1000);
                    string plate = VehicleChecker.CurrentVehicle.Mods.LicensePlate;
                    foreach (Vehicle vehicle in VeicoliParcheggio) vehicle.Delete();
                    VeicoliParcheggio.Clear();
                    Vector4 exit = Vector4.Zero;
                    if (ClientMain.Settings.FreeRoam.Properties.Apartments.ContainsKey(Cache.PlayerCache.MyPlayer.Status.Instance.Instance))
                        exit = ClientMain.Settings.FreeRoam.Properties.Apartments[Cache.PlayerCache.MyPlayer.Status.Instance.Instance].SpawnGarageVehicleOutside.ToVector4;
                    else
                        exit = ClientMain.Settings.FreeRoam.Properties.Garages.Garages[Cache.PlayerCache.MyPlayer.Status.Instance.Instance].SpawnOutside.ToVector4;
                    int tempo = GetGameTimer();
                    Vector3 newPos = exit.ToVector3();
                    float Head = exit.W;

                    while (!Functions.IsSpawnPointClear(exit.ToVector3(), 2f))
                    {
                        if (GetGameTimer() - tempo > 5000)
                        {
                            ClientMain.Logger.Debug("Spawn point outside the garage occupied, new point found");
                            break;
                        }

                        await BaseScript.Delay(0);
                    }

                    if (!Functions.IsSpawnPointClear(exit.ToVector3(), 2f)) GetClosestVehicleNodeWithHeading(exit.X, exit.Y, exit.Z, ref newPos, ref Head, 1, 3, 0);
                    Vehicle vehi = await Functions.SpawnVehicle(Cache.PlayerCache.MyPlayer.User.Character.Vehicles.FirstOrDefault(x => x.Plate == plate).VehData.Props.Model, newPos, Head);
                    vehi.SetVehicleProperties(Cache.PlayerCache.MyPlayer.User.Character.Vehicles.FirstOrDefault(x => x.Plate == plate).VehData.Props);
                    VehicleChecker.CurrentVehicle.IsEngineRunning = true;
                    VehicleChecker.CurrentVehicle.IsDriveable = true;
                    EventDispatcher.Send("lprp:vehInGarage", plate, false);
                    Cache.PlayerCache.MyPlayer.Status.Instance.RemoveInstance();
                    await BaseScript.Delay(1000);
                    Screen.Fading.FadeIn(800);
                    ClientMain.Instance.RemoveTick(Garage);
                }
            }
        }

        private static async void EnterGarageWithOwner(Vector3 pos)
        {
            if (Cache.PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(VehicleChecker.CurrentVehicle.Handle, true, false);
            Screen.Fading.FadeOut(500);
            await BaseScript.Delay(1000);
            RequestCollisionAtCoord(pos.X, pos.Y, pos.Z);
            NewLoadSceneStart(pos.X, pos.Y, pos.Z, pos.X, pos.Y, pos.Z, 50f, 0);
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

            SetEntityCoords(PlayerPedId(), pos.X, pos.Y, pos.Z, false, false, false, false);
            tempTimer = GetGameTimer();

            // Wait for the collision to be loaded around the entity in this new location.
            while (!HasCollisionLoadedAroundEntity(Cache.PlayerCache.MyPlayer.Ped.Handle))
            {
                // If this takes too long, then just abort, it's not worth waiting that long since we haven't found the real ground coord yet anyway.
                if (GetGameTimer() - tempTimer > 1000)
                {
                    ClientMain.Logger.Debug("Waiting for the collision is taking too long (more than 1s). Breaking from wait loop.");
                    break;
                }

                await BaseScript.Delay(0);
            }

            foreach (OwnedVehicle veh in Cache.PlayerCache.MyPlayer.User.Character.Vehicles)
            {
                if (veh.Garage.ID == Cache.PlayerCache.MyPlayer.Status.Instance.Instance)
                {
                    if (veh.Garage.InGarage)
                    {
                        Vehicle veic = await Functions.SpawnLocalVehicle(veh.VehData.Props.Model, new Vector3(ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].X, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Y, ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Z), ClientMain.Settings.FreeRoam.Properties.Garages.LowEnd.PosVehs[veh.Garage.Place].Heading);
                        veic.SetVehicleProperties(veh.VehData.Props);
                        VeicoliParcheggio.Add(veic);
                    }
                }
            }

            NetworkFadeInEntity(Cache.PlayerCache.MyPlayer.Ped.Handle, true);
            Cache.PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
            DoScreenFadeIn(500);
            SetGameplayCamRelativePitch(0.0f, 1.0f);
            ClientMain.Instance.AddTick(Garage);
        }
    }
}