using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Linq;

namespace FreeRoamProject.Server.FREEROAM.Apartments
{
    internal static class ApartmentsServer
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:buzzPlayer", new Action<PlayerClient, int, string>(buzzPlayer));
            EventDispatcher.Mount("tlg:buzz:canEnter", new Action<PlayerClient, int, string>(canEnter));
            //TODO: WE NEED TO DO THE SAME WITH APARTMENTS, AND WITH ANIMATIONS FOR WHEN YOU GO WITH THE CAR INTO YOUR GARAGE
            EventDispatcher.Mount("tlg:enterGarageWithOwner", new Action<PlayerClient, Vector3>(EnterWithOwner));
        }

        private static void buzzPlayer([FromSource] PlayerClient buzzer, int ownerId, string apartment)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(buzzer.Handle);
            PlayerClient buzzed = server.Players.FirstOrDefault(x => x.Handle == ownerId);
            buzzed.TriggerSubsystemEvent("tlg:enterRequest", buzzed.Handle, apartment);
        }

        private static void canEnter([FromSource] PlayerClient atHome, int buzzerServerId, string app)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(atHome.Handle);
            PlayerClient buzzer = server.Players.FirstOrDefault(x => x.Handle == buzzerServerId);
            buzzer.TriggerSubsystemEvent("tlg:buzz:canEnter", Convert.ToInt32(atHome.Handle), app);
        }

        private static void EnterWithOwner([FromSource] PlayerClient p, Vector3 pos)
        {
            p.TriggerSubsystemEvent("tlg:enterGarageWithOwner", pos);
        }
    }
}