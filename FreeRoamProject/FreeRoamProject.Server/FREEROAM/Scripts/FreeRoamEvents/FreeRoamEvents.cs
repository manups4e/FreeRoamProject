using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents
{
    internal class FreeRoamEvents
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:freeroam:finishCharServer", new Action<PlayerClient, FreeRoamChar>(FinishChar));
            EventDispatcher.Mount("tlg:freeroam:saveCharacter", new Action<PlayerClient>(SaveCharacter));
            EventDispatcher.Mount("tlg:casino:getVehModel", new Func<PlayerClient, Task<string>>(ReturnCasinoPriceModelForPlayer));
        }

        public static void SaveCharacter([FromSource] PlayerClient client)
        {
            BucketsHandler.FreeRoam.SavePlayerData(client);
        }

        public static void FinishChar([FromSource] PlayerClient client, FreeRoamChar data)
        {
            try
            {
                client.User.Character = data;
                API.SetResourceKvp($"freeroam:player_{client.User.Identifiers.License}:char_model", data.ToBytes().BytesToString(true));
                //API.DeleteResourceKvpNoSync($"freeroam:player_{client.User.Identifiers.License}:char_model");
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error($"{e.Message}");
            }
        }
        public static async Task<string> ReturnCasinoPriceModelForPlayer([FromSource] PlayerClient client)
        {
            // TODO: FOR NOW WE USE A CAR THEN WE'LL SEE
            return "zentorno";
        }

        public static async void SpawnEventVehicles(Dictionary<Vector4, uint> vehicles)
        {

        }

    }
}
