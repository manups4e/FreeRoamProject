using System;


namespace FreeRoamProject.Server
{
    static class BaseEventsFreeRoam
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:onPlayerDied", new Action<PlayerClient, int, int, Position>(OnPlayerDied));
        }

        private static void OnPlayerDied([FromSource] PlayerClient player, int deathType, int killer, Position victimCoords)
        {
            /*
            Shared.Core.Buckets.Bucket bucket = BucketsHandler.FreeRoam.GetPlayerBucket(player.Handle);
            //string death = func_19419(player)
            Player Killer = Functions.GetPlayerFromId(killer);
            //EventDispatcher.Send(bucket.Players, "lpop:ShowNotification", death);
            */
        }
    }
}
