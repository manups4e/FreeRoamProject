using FreeRoamProject.Client.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    static class VehicleManager
    {
        private static List<Blip> ActiveBlips = new List<Blip>();
        private static List<int> ActiveVehicles = new List<int>();
        private static bool justDestroyed = false;
        private static int start = 0;

        public static void Init()
        {
            EventDispatcher.Mount("worldEventsManage.Client:DestroyEventVehicles", new Action(OnDestroySpawnedEventVehicles));
            ClientMain.Instance.AddTick(OnTick);

            DecorRegister("weEventVehicle", 2);
        }

        public static async Task SpawnEventVehicles(Dictionary<Vector4, VehicleHash> spawnLocations)
        {
            try
            {
                Vehicle[] veh = World.GetAllVehicles();
                if (veh.Count() != 0)
                {
                    foreach (Vehicle v in veh)
                    {
                        if (DecorExistOn(v.Handle, "weOwnedVeh") || v.Driver == Cache.PlayerCache.MyPlayer.Ped) continue;
                        v.Delete();
                    }
                }
                foreach (Vector4 location in spawnLocations.Keys)
                {
                    ClearAreaOfVehicles(location.X, location.Y, location.Z, 10000f, false, false, false, false, false);
                }


                if (NetworkIsHost())
                {
                    List<int> temp = new List<int>();

                    foreach (int activeVehicle in ActiveVehicles)
                    {
                        int reffie = activeVehicle;
                        SetEntityAsNoLongerNeeded(ref reffie);
                    }

                    foreach (KeyValuePair<Vector4, VehicleHash> vehicle in spawnLocations)
                    {
                        Vector3 vehPos = new Vector3(vehicle.Key.X, vehicle.Key.Y, vehicle.Key.Z);
                        bool playerInArea = false;
                        for (int i = 0; i < 64; i++)
                        {
                            if (NetworkIsPlayerActive(i))
                            {
                                int ped = GetPlayerPed(i);
                                Vector3 pos = GetEntityCoords(ped, true);
                                if (pos.DistanceToSquared(vehPos) < 100f)
                                {
                                    playerInArea = true;
                                }
                            }
                        }

                        if (playerInArea == false)
                        {
                            int spawnedVehicle = await ClearAndSpawnVehicles(vehicle);
                            if (spawnedVehicle != 0)
                            {
                                temp.Add(spawnedVehicle);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }

            await Task.FromResult(0);
        }

        private static async Task OnTick()
        {
            if (justDestroyed)
            {
                if (GetNetworkTime() - start < 25000)
                    Cache.PlayerCache.MyPlayer.Player.WantedLevel = 0;
                else
                    justDestroyed = false;
            }

            await BaseScript.Delay(0);
        }


        private static async void OnDestroySpawnedEventVehicles()
        {
            if (!VehicleChecker.IsInVehicle)
            {
                ClientMain.Logger.Debug("Player is not in a vehicle.");
                return;
            }

            Vehicle currentVehicle = VehicleChecker.CurrentVehicle;

            if (!DecorExistOn(currentVehicle.Handle, "weEventVehicle"))
            {
                ClientMain.Logger.Debug("Not in an Event Vehicle");
                return;
            }

            Notifications.ShowAdvancedNotification("Il tuo veicolo verrà distrutto in 10 secondi", "Attenzione!", "");
            await BaseScript.Delay(7000);

            if (DecorExistOn(currentVehicle.Handle, "weEventVehicle"))
            {
                ClientMain.Logger.Debug("Still in an event vehicle, destroying..");
                Audio.PlaySoundFrontend("BOATS_PLANES_HELIS_BOOM", "MP_LOBBY_SOUNDS");
                if (Cache.PlayerCache.MyPlayer.Ped.IsInFlyingVehicle)
                {
                    Notifications.ShowAdvancedNotification("Press ~INPUT_PARACHUTE_DEPLOY~ per usare il paracadute!", "Emergenza Paracadute", "");
                    Cache.PlayerCache.MyPlayer.Ped.Weapons.Give(WeaponHash.Parachute, 999, true, true);
                }

                Cache.PlayerCache.MyPlayer.Ped.Task.LeaveVehicle(LeaveVehicleFlags.BailOut);

                await BaseScript.Delay(5000);
                currentVehicle.ExplodeNetworked();

                if (Cache.PlayerCache.MyPlayer.Ped.IsFalling)
                    Cache.PlayerCache.MyPlayer.Ped.OpenParachute();

                Notifications.ShowAdvancedNotification("Sei stato cacciato dal tuo veicolo", "Attenzione!", "");
            }

            justDestroyed = true;
            start = GetNetworkTime();

            foreach (int activeVehicle in ActiveVehicles)
            {
                if (DoesEntityExist(activeVehicle))
                {
                    Vehicle veh = new Vehicle(activeVehicle);
                    veh.Delete();
                }
            }
        }

        private static async Task<int> ClearAndSpawnVehicles(KeyValuePair<Vector4, VehicleHash> vehicle)
        {
            try
            {
                ClearAreaOfVehicles(vehicle.Key.X, vehicle.Key.Y, vehicle.Key.Z, 2500f, false, false, false, false, false);
                int attempts = 0;
                do
                {
                    ClearAreaOfVehicles(vehicle.Key.X, vehicle.Key.Y, vehicle.Key.Z, 2500f, false, false, false, false, false);
                    attempts++;
                } while (attempts != 20);

                Vehicle newVeh = await World.CreateVehicle(vehicle.Value, new Vector3(vehicle.Key.X, vehicle.Key.Y, vehicle.Key.Z - 0.55f), vehicle.Key.W);
                if (newVeh == null)
                {
                    ClientMain.Logger.Debug("Something went wrong while creating a vehicle.");
                    return 0;
                }

                DecorSetBool(newVeh.Handle, "weEventVehicle", true);
                if (!DecorExistOn(newVeh.Handle, "weEventVehicle"))
                {
                    return 0;
                }
                return newVeh.Handle;
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }

            return 0;
        }
    }
}
