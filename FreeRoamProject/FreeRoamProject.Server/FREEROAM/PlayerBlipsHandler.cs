namespace FreeRoamProject.Server.FreeRoam
{
    /*
    static class PlayerBlipsHandler
    {
        private static List<FRBlipsInfo> _blipsInfos = new();
        private static SharedTimer blipTimer;
        private static readonly List<int> JetHashes = new() { 970385471, -1281684762, 1824333165 };

        public static void Init()
        {
            blipTimer = new(500);
            ServerMain.Instance.AddTick(UpdatePlayersBlips);
            AccessingEvents.OnFreeRoamSpawn += (client) =>
            {
                int serverId = client.Handle;
                Vector3 pos = client.Ped.Position;
                Vector3 rot = client.Ped.Rotation;
                int netId = client.Ped.NetworkId;
                FRBlipsInfo user = new(client.Player.Name, new Position(pos, rot), netId, serverId);
                _blipsInfos.Add(user);
            };

            AccessingEvents.OnFreeRoamLeave += (client) =>
            {
                _blipsInfos.RemoveAll(x => client.Handle == x.ServerId);
            };
        }

        private static async Task UpdatePlayersBlips()
        {
            try
            {
                await BaseScript.Delay(500);
                if (BucketsHandler.FreeRoam.GetTotalPlayers() < 1) return; // CHANGE WITH <=, NOW IT'S JUST FOR TESTING ON MY OWN

                foreach (PlayerClient client in BucketsHandler.FreeRoam.Bucket.Players)
                {
                    if (!client.Status.PlayerStates.Spawned) continue;
                    int serverId = Convert.ToInt32(client.Player.Handle);
                    Vector3 pos = client.Ped.Position;
                    Vector3 rot = client.Ped.Rotation;
                    int netId = client.Ped.NetworkId;
                    Ped p = client.Ped;
                    if (_blipsInfos.Any(x => x.ServerId == serverId))
                    {
                        FRBlipsInfo blip = _blipsInfos.SingleOrDefault(x => x.ServerId == serverId);
                        blip.Pos = new(pos, rot);
                        int veh = GetVehiclePedIsIn(p.Handle, false);
                        int model = GetEntityModel(veh);
                        int sprite = 1;
                        if (veh != 0)
                        {
                            switch (GetVehicleType(veh))
                            {
                                case "heli":
                                    sprite = 422;
                                    break;
                                case "plane":
                                    sprite = 423;
                                    if (JetHashes.Contains(model))
                                        sprite = 424;
                                    break;
                                case "boat":
                                    sprite = 427;
                                    break;
                                case "bike":
                                    sprite = 226;
                                    break;
                                case "automobile":
                                    sprite = 225;
                                    break;
                            }
                        }
                        blip.Sprite = sprite;
                    }
                    client.User.Character.Position = new(pos, rot);
                }
                EventDispatcher.Send(BucketsHandler.FreeRoam.Bucket.Players, "freeroam.UpdatePlayerBlipInfos", _blipsInfos);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }
    }
    */
}
