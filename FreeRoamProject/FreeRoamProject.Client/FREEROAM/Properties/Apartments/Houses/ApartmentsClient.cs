using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Properties.Appartamenti.Case
{
    // TODO: IMPLEMENT THE ONLINE SYSTEM, WHERE YOU GO NEAR THE DOORS AND THE ENTERING ANIMATION STARTS AUTOMATICALLY
    // IF THERE'S MULTIPLE PLAYERS IN THE BUILDING, CHECK THAT VIA MENU LIKE IN ONLINE.
    /*
      "MP_PROP_BUZ0": "Accept",
      "MP_PROP_BUZ1": "Reject",
      "MP_PROP_BUZZ_C": "Someone is buzzing your Clubhouse. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ_Y": "Someone is buzzing your Yacht. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0": "Someone is buzzing your Apartment. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0B": "Someone is buzzing your Garage. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ0C": "Someone is buzzing your Apartment. ~n~Walk to the Apartment door to answer the buzzer.",
      "MP_PROP_BUZZ0D": "Someone is buzzing your Office Garage. ~n~Walk to the door to answer the buzzer.",
      "MP_PROP_BUZZ1": "Press ~INPUT_CONTEXT~ to buzz Apartment.",
      "MP_PROP_BUZZ1B": "Press ~INPUT_CONTEXT~ to buzz Garage.",
      "MSG_BUZZ_RC": "Someone is buzzing Eclipse Blvd Garage.~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "PROP_OFF_M_6": "Someone is buzzing your Office. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer or speak to the Executive Assistant",
      "PROP_OFF_M_6F": "Someone is buzzing your Office. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer or speak to the Executive Assistant",
      "PROP_OFFG_M_6": "Someone is buzzing your Office Garage. ~n~Walk to the entrance to answer the buzzer.",
      "ARENA_BUZZ_RC": "Someone is buzzing your Arena Workshop. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer",
      "CAS_APT_BUZZ_RC": "Someone is buzzing your Penthouse. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "FHQ_BUZZ_RC": "Someone is buzzing your Agency. ~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
      "JH_BUZZ_RC": "Someone is buzzing The Freakshop.~n~Press ~INPUT_CONTEXT~ to answer the buzzer.",
     
      many other labels to check, for requesting buzz, and for menus.
     */

    internal static class ApartmentsClient
    {
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }
        public static void Spawned(PlayerClient client)
        {
            ClientMain.Instance.AddEventHandler("tlg:enterRequest", new Action<int, string>(Request));
            ClientMain.Instance.AddEventHandler("tlg:buzz:canEnter", new Action<int, string>(CanEnter));
            ClientMain.Instance.AddEventHandler("tlg:enterGarageWithOwner", new Action<Vector3>(EnterGarageWithOwner));
            // TODO: THIS MUST BE LOADED FROM THE SETTINGS or even better.. this is from the RP side where you'd load the real estate apartments to sell..
        }

        public static void onPlayerLeft(PlayerClient client)
        {
            ClientMain.Instance.RemoveEventHandler("tlg:enterRequest", new Action<int, string>(Request));
            ClientMain.Instance.RemoveEventHandler("tlg:buzz:canEnter", new Action<int, string>(CanEnter));
            ClientMain.Instance.RemoveEventHandler("tlg:enterGarageWithOwner", new Action<Vector3>(EnterGarageWithOwner));

            ClientMain.Settings.FreeRoam.Properties.Apartments.Clear();
            ClientMain.Settings.FreeRoam.Properties.Garages.Garages.Clear();
        }

        public static async void ExitMenu(ConfigHouses app, bool inGarage = false, bool inRoof = false)
        {
        }

        private static string nome;
        private static string appa;
        private static int serverIdRic;
        private static int tempo;

        public static void Request(int serverIdRichiedente, string app)
        {
            Game.PlaySound("DOOR_BUZZ", "MP_PLAYER_APARTMENT");
            nome = ClientMain.Instance.GetPlayers.ToList().FirstOrDefault(x => x.ServerId == serverIdRichiedente).Name;
            appa = app;
            serverIdRic = serverIdRichiedente;
            tempo = GetGameTimer();
            ClientMain.Instance.AddTick(AccRif);
        }

        private static async Task AccRif()
        {
        }

        public static void CanEnter(int serverIdInCasa, string appartamento)
        {
        }

        public static async Task Garage()
        {
        }

        private static async void EnterGarageWithOwner(Vector3 pos)
        {
        }
    }
}