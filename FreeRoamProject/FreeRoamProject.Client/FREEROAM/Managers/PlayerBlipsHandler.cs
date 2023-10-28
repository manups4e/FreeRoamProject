using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeRoamProject.Client.GameMode.FREEROAM.Spawner;


namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    static class PlayerBlipsHandler
    {
        private static List<FRBlipsInfo> _fRBlipsInfos = new();
        private static Dictionary<int, Blip> playerBlips = new();
        private static readonly List<int> JetHashes = new() { 970385471, -1281684762, 1824333165 };

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += OnPlayerJoined;
            AccessingEvents.OnFreeRoamLeave += OnPlayerLeft;
        }

        private static void OnPlayerJoined(PlayerClient client)
        {
            //EventDispatcher.Mount("freeroam.UpdatePlayerBlipInfos", new Action<List<FRBlipsInfo>>(UpdateBlips));
            ///////// test /////////
            ClientMain.Instance.AddTick(Blips);
        }

        public static void OnPlayerLeft(PlayerClient client)
        {
            //EventDispatcher.Unmount("freeroam.UpdatePlayerBlipInfos");
            ClientMain.Instance.RemoveTick(Blips);
            //foreach (var bb in playerBlips) if (bb.Value.Exists()) bb.Value.Delete();
        }

        private static void UpdateBlips(List<FRBlipsInfo> info)
        {
            _fRBlipsInfos = info;
            //UpdatePlayerBlips();
        }

        public static async Task Blips()
        {
            await BaseScript.Delay(500);
            foreach(var client in ClientMain.Instance.Clients)
            {
                if (client.Status.PlayerStates.Spawned)
                {
                    if(client.Ped.AttachedBlip != null)
                    {
                        var blip = client.Ped.AttachedBlip;
                        var sprite = BlipSprite.Standard;
                        if (client.Status.PlayerStates.InVehicle)
                        {
                            var model = client.Ped.CurrentVehicle.Model;

                            if (model.IsHelicopter)
                                sprite = (BlipSprite)422;
                            else if (model.IsPlane)
                                sprite = (BlipSprite)423;
                            if (JetHashes.Contains(model))
                                sprite = (BlipSprite)424;
                            /*
                            else if (model.IsBoat)
                                sprite = (BlipSprite)427;
                            else if (model.IsBike)
                                sprite = (BlipSprite)226;
                            else if (model.IsCar)
                                sprite = (BlipSprite)225;
                            */
                        }
                        blip.Sprite = sprite;
                        blip.Name = client.Player.Name;
                    }
                    else
                    {
                        var blip = client.Ped.AttachBlip();
                        blip.Sprite = BlipSprite.Standard;
                        SetBlipCategory(blip.Handle, 7);
                        SetBlipDisplay(blip.Handle, 4);
                        SetBlipShrink(blip.Handle, false);
                        //SetBlipShowCone(blip.Handle, true);
                        //ShowHeadingIndicatorOnBlip(blip.Handle, true);
                        blip.Name = client.Player.Name;
                    }
                }
            }
        }

        public static void UpdatePlayerBlips()
        {
            playerBlips.Where(x => !_fRBlipsInfos.Any(y => y.ServerId == x.Key)).ToList().ForEach(x => x.Value.Delete());
            foreach (var player in _fRBlipsInfos)
            {
                Blip blip;
                //if (player.ServerId == PlayerCache.MyPlayer.Player.ServerId) continue; // ignora il mio pg fai solo gli altri

                if (playerBlips.ContainsKey(player.ServerId))
                {
                    blip = playerBlips[player.ServerId];
                    blip.Position = player.Pos.ToVector3;
                    //blip.Rotation = (int)Math.Ceiling(player.Pos.Heading);
                }
                else
                {
                    blip = World.CreateBlip(player.Pos.ToVector3);
                    SetBlipCategory(blip.Handle, 7);
                    SetBlipDisplay(blip.Handle, 6);
                    SetBlipShrink(blip.Handle, false);
                    SetBlipShowCone(blip.Handle, true);
                    ShowHeadingIndicatorOnBlip(blip.Handle, true);
                    playerBlips.Add(player.ServerId, blip);
                }

                blip.Name = player.Name;
                blip.Sprite = BlipSprite.Standard;
                if ((int)blip.Sprite != player.Sprite)
                    blip.Sprite = (BlipSprite)player.Sprite;
            }
        }
    }
}