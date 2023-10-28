using FreeRoamProject.Shared.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.Core.Buckets
{
    internal static class BucketsHandler
    {
        public static FreeRoamBucketContainer FreeRoam;

        public static void Init()
        {
            EventDispatcher.Mount("tlg:addPlayerToBucket", new Action<PlayerClient>(AddPlayerToBucket));
            EventDispatcher.Mount("tlg:removePlayerFromBucket", new Action<PlayerClient, string>(RemovePlayerFromBucket));
            EventDispatcher.Mount("tlg:checkAlreadyIn", new Func<PlayerClient, int, Task<bool>>(CheckIn));
            EventDispatcher.Mount("tlg:addEntityToBucket", new Action<int, int>(AddEntityToBucket));
            EventDispatcher.Mount("tlg:requestBucketsCount", new Func<PlayerClient, Task<int>>(CountPlayers));
            FreeRoam = new() /*{ LockdownMode = BucketLockdownMode.relaxed, PopulationEnabled = true }*/;
        }

        /// <summary>
        /// Adds a player to the bucket by removing it from the other buckets
        /// </summary>
        /// <param name="player">Player to add</param>
        /// <param name="id">Id of the bucket</param>
        private static void AddPlayerToBucket([FromSource] PlayerClient player)
        {
            FreeRoam.AddPlayer(player);
            Bucket bucket = FreeRoam.GetPlayerBucket(player.Handle);
            List<PlayerClient> clients = bucket.Players;
            EventDispatcher.Send(clients, "tlg:onPlayerEntrance", player);
            player.Status.Clear();
        }

        private static void RemovePlayerFromBucket([FromSource] PlayerClient player, string reason = "")
        {
            FreeRoam.RemovePlayer(player, reason);
        }

        /// <summary>
        /// Adds an Entity to the bucket by removing it from the other buckets
        /// </summary>
        /// <param name="entityNetId">Entity network ID</param>
        /// <param name="id">Bucket ID</param>
        private static void AddEntityToBucket(int entityNetId, int bucket)
        {
            Entity ent = Entity.FromNetworkId(entityNetId);
            Bucket server = FreeRoam.GetServerFromId(bucket);
            server.Entities.Add(ent);
        }

        private static async Task<int> CountPlayers([FromSource] PlayerClient player)
        {
            return FreeRoam.GetTotalPlayers();
        }

        private static async Task<bool> CheckIn([FromSource] PlayerClient player, int bucket)
        {
            Bucket server = FreeRoam.GetServerFromId(bucket);
            return server.Players.Any(x => x.Handle == player.Handle);
        }

    }
}