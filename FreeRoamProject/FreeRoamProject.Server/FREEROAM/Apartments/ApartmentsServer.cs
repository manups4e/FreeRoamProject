using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Server.FREEROAM.Apartments
{
    internal static class ApartmentsServer
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:buzzPlayer", new Action<PlayerClient, int, string>(buzzPlayer));
            EventDispatcher.Mount("tlg:buzz:canEnter", new Action<PlayerClient, int, string>(canEnter));
            EventDispatcher.Mount("tlg:loadPlayerProperties", new Action<PlayerClient>(LoadProperties));
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

        private static async void LoadProperties([FromSource] PlayerClient source)
        {
            // TODO: BETTER THE KVP OR THE DB? also the db call here is for the RP side of the old mode...
            // dynamic result = await ServerMain.Instance.Query<string>("SELECT * FROM PROPERTIES WHERE LICENSE = @id AND CHARACTER = @pers", new { id = p.GetLicense(Identifier.Discord), pers = p.Player.Name });

            // TODO: Apartment data must contain:
            // apartment type: apartment, office, club, bunker, etc...
            // apartment subtype: low, mid, high, executive, etc...
            // apartment connected garage: same as apartment low, mid, high, exec,  etc..
            // apartment name: example 0112SRD
            // apartment label: example 0112 South Rockford Drive
            // after that, we need the apartment settings, customizations.
            // apartments internal data such as coordinates for armories, wardrobes, garages, enter, exit, this kind of data goes in the settings..
            // no need to be saved
            // The settings are then applied when player decides to enter home.. not before or after..
            // there's a video and a camera animation for the player to see while waiting

            string sbytes = GetResourceKvpString($"freeroam:player_{source.User.Identifiers.License}:apartmentsList");
            //TODO: KEEP ONLY THE STRINGS? WE NEED ALL THE APARTMENTS DATA
            List<string> result = sbytes.StringToBytes().FromBytes<List<string>>();
            if (result.Count > 0)
            {
                foreach (string ap in result)
                {
                    source.User.Character.Properties.Add(ap);
                }
            }
            //p.TriggerEvent("tlg:sendUserInfo", p.GetCurrentChar().Characters.ToJson(includeEverything: true), p.GetCurrentChar().char_current, p.GetCurrentChar().group);
        }

        private static void EnterWithOwner([FromSource] PlayerClient p, Vector3 pos)
        {
            p.TriggerSubsystemEvent("tlg:enterGarageWithOwner", pos);
        }
    }
}