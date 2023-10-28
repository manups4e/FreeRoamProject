using FreeRoamProject.Server.Core;
using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerJoining;
using FreeRoamProject.Server.Discord;
using FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents;
using System.Threading.Tasks;

namespace FreeRoamProject.Server
{
    internal static class ClassCollector
    {
        public static async Task Init()
        {
            BucketsHandler.Init();
            NewServerEntrance.Init();
            await ConfigServer.Init();
            while (ServerMain.Settings == null)
            {
                await BaseScript.Delay(0);
            }

            //ServerManager.Init();
            Main.Init();
            Events.Init();
            EntityCreation.Init();
            ChatServer.Init();
            TimeWeather.ServerWeather.Init();
            //TimeWeather.OrarioServer.Init();
            BotDiscordHandler.Init();
            WorldEventsManager.Init();
            VehicleManager.Init();
            //PlayerBlipsHandler.Init();
            BaseEventsFreeRoam.Init();
            FreeRoamEvents.Init();
            await Task.FromResult(0);
        }
    }
}