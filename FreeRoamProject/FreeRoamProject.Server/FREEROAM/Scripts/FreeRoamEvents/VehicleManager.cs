using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Generic;


namespace FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents
{
    static class VehicleManager
    {
        public static List<int> SpawnedEventVehicles = new List<int>();

        public static void Init()
        {
            EventDispatcher.Mount("worldEventsManage.Server:SpawnedEventVehicles", new Action<PlayerClient, List<int>>(OnSpawnedEventVehicles));
        }

        private static void OnSpawnedEventVehicles([FromSource] PlayerClient client, List<int> dynamicVehicles)
        {
            try
            {
                SpawnedEventVehicles.Clear();
                foreach (int v in dynamicVehicles)
                {
                    SpawnedEventVehicles.Add(v);
                }

                Shared.Core.Buckets.Bucket bucket = BucketsHandler.FreeRoam.GetPlayerBucket(client.Handle);
                EventDispatcher.Send(bucket.Players, "worldEventsManage.Client:SetVehicleBlips", SpawnedEventVehicles);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }
    }
}
