using FivemPlayerlistServer;
using FreeRoamProject.Server.Core;
using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerJoining;
using FreeRoamProject.Server.Discord;
using FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents;
using FreeRoamProject.Server.FREEROAM.Banking;
using FreeRoamProject.Server.FREEROAM.Phone;
using FreeRoamProject.Server.TimeWeather;
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
            ChatEvents.Init();
            //ServerManager.Init();
            Main.Init();
            Events.Init();
            EntityCreation.Init();
            ChatServer.Init();
            PlayerListServer.Init();
            ServerWeather.Init();
            //TimeWeather.OrarioServer.Init();
            BotDiscordHandler.Init();
            WorldEventsManager.Init();
            VehicleManager.Init();
            BaseEventsFreeRoam.Init();
            FreeRoamEvents.Init();
            BankingServer.Init();
            PhoneServer.Init();
            await Task.FromResult(0);
        }
    }
}