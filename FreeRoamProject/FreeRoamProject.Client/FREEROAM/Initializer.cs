using FreeRoamProject.Client.FREEROAM.PlayerList;
using FreeRoamProject.Client.GameMode.FREEROAM.Managers;
using FreeRoamProject.Client.GameMode.FREEROAM.Scripts.Negozi;
using FreeRoamProject.Client.GameMode.FREEROAM.Scripts.PauseMenu;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Client.IPLs;
using FreeRoamProject.Client.TimeWeather;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM
{
    class Initializer
    {
        public static async Task Init()
        {
            IPLInstance.Init();
            TickController.Init();
            HudManager.Init();
            ExperienceManager.Init();
            WorldEventsManager.Init();
            PlayerBlipsHandler.Init();
            BaseEventsFreeRoam.Init();
            PlayerListClient.Init();
            PlayerTags.Init();
            WeatherClient.Init();
            TimeClient.Init();
            PauseMenuFreeroam.Init();
            WeaponShops.Init();
            // TODO: ADD STATISTICS HANDLING
            // TODO: ADD VEHICLES HANDLING
            // TODO: ADD APARTMENTS AND IPLS HANDLING
            // TODO: ADD BETTER DEATH HANDLING?
            SetAmbientPedsDropMoney(true);
            await Task.FromResult(0);
        }

        public static async Task Stop()
        {
            WeatherClient.Stop();
            TimeClient.Stop();
            AccessingEvents.FreeRoamLeave(PlayerCache.MyPlayer);
            HudManager.Stop();
            WeaponShops.Stop();
            // TODO: SAME COMMENTS AS ABOVE
            SetAmbientPedsDropMoney(false);
            await Task.FromResult(0);
        }
    }
}
