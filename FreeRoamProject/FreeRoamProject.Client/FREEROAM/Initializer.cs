using FreeRoamProject.Client.FREEROAM.Phone;
using FreeRoamProject.Client.FREEROAM.PlayerList;
using FreeRoamProject.Client.FREEROAM.Properties;
using FreeRoamProject.Client.GameMode.FREEROAM.Managers;
using FreeRoamProject.Client.GameMode.FREEROAM.Scripts.Negozi;
using FreeRoamProject.Client.GameMode.FREEROAM.Scripts.PauseMenu;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Client.IPLs;
using FreeRoamProject.Client.TimeWeather;
using FreeRoamProject.FREEROAM.Banking;
using System.Threading.Tasks;
using TheLastPlanet.Client.GameMode.ROLEPLAY.Personale;

namespace FreeRoamProject.Client.GameMode.FREEROAM
{
    class Initializer
    {
        public static async Task Init()
        {
            IPLInstance.Init();
            //TODO: THE XP THINGS IN THERE SHOLUD BE SHIFTED IN THEIR OWN CLASSES
            HudManager.Init();
            InteractionMethods.Init();
            MinimapHandler.Init();
            ExperienceManager.Init();
            WorldEventsManager.Init();
            BaseEventsFreeRoam.Init();
            Scoreboard.Init();
            PlayerTags.Init();
            WeatherClient.Init();
            TimeClient.Init();
            PauseMenuFreeroam.Init();
            WeaponShops.Init();
            BankingClient.Init();
            PhoneMainClient.Init();
            IdleChecker.Init();
            PropertiesExteriorsManager.Init();
            DialogueControllerClient.Init();
            // TODO: ADD STATISTICS HANDLING
            // TODO: ADD VEHICLES HANDLING
            // TODO: ADD APARTMENTS AND IPLS HANDLING
            // TODO: ADD BETTER DEATH HANDLING?
            SetAmbientPedsDropMoney(true);
            TickController.Init();
            await Task.FromResult(0);
        }

        public static async Task Stop()
        {
            WeatherClient.Stop();
            TimeClient.Stop();
            AccessingEvents.FreeRoamLeave(PlayerCache.MyClient);
            HudManager.Stop();
            WeaponShops.Stop();
            // TODO: SAME COMMENTS AS ABOVE
            SetAmbientPedsDropMoney(false);
            await Task.FromResult(0);
        }
    }
}
