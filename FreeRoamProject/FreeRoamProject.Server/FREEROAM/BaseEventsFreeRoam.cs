using FreeRoamProject.Server.Core;
using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Generic;


namespace FreeRoamProject.Server
{
    static class BaseEventsFreeRoam
    {
        private static List<string> killedMessages = new List<string>()
        {
            "killed",
            "destroyed",
            "erased",
            "slaughtered",
            "annihilated",
            "dissolved",
            "pulverized",
            "devastated",
            "executed",
            "atomized",
            "murdered",
            "flattened",
            "scrapped",
        };

        public static void Init()
        {
            EventDispatcher.Mount("lpop:onPlayerDied", new Action<PlayerClient, int, int, Position>(OnPlayerDied));
        }

        private static void OnPlayerDied([FromSource] PlayerClient player, int tipo, int killer, Position victimCoords)
        {
            Shared.Core.Buckets.Bucket bucket = BucketsHandler.FreeRoam.GetPlayerBucket(player.Handle);
            string morte = "";
            Player Killer = Functions.GetPlayerFromId(killer);
            switch (tipo)
            {
                case 0:
                    morte = $"~h~{player.Player.Name}~h~ killed himself.";
                    break;
                case 1:
                    morte = $"~h~{Killer.Name}~h~ {killedMessages[new Random().Next(killedMessages.Count - 1)]} {player.Player.Name}";
                    break;
                case -1:
                    morte = $"~h~{player.Player.Name}~h~ died.";
                    break;
            }
            EventDispatcher.Send(bucket.Players, "lpop:ShowNotification", morte);
        }
    }
}
