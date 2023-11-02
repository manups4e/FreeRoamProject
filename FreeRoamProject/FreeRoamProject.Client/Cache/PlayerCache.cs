using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.PlayerChar;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Cache
{
    public static class PlayerCache
    {
        internal static bool _inVeh;
        private static bool _paused;
        private static SharedTimer _checkTimer;

        public static PlayerClient MyPlayer { get; private set; }
        public static FreeRoamChar Character => MyPlayer.User.Character;


        public static async Task InitPlayer()
        {
            Tuple<Snowflake, BasePlayerShared> player = await EventDispatcher.Get<Tuple<Snowflake, BasePlayerShared>>("tlg:setupUser");
            MyPlayer = new PlayerClient(player);
            _checkTimer = new(5000);
            ClientMain.Instance.AddTick(TickStatus);
            await Task.FromResult(0);
            VehicleChecker.OnPedEnteredVehicle += OnPedEnteredVehicle;
            VehicleChecker.OnPedLeftVehicle += OnPedLeftVehicle;
        }

        private static void OnPedLeftVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex)
        {
            if (ped.Handle == MyPlayer.Ped.Handle)
            {
                MyPlayer.Status.PlayerStates.InVehicle = false;
                _inVeh = false;
            }
        }

        private static void OnPedEnteredVehicle(Ped ped, Vehicle vehicle, VehicleSeat seat)
        {
            if (ped.Handle == MyPlayer.Ped.Handle)
            {
                MyPlayer.Status.PlayerStates.InVehicle = true;
                _inVeh = true;
            }
        }

        public static async Task Loaded()
        {
            while (MyPlayer == null || MyPlayer != null && !MyPlayer.Ready) await BaseScript.Delay(0);
        }

        public static async Task TickStatus()
        {
            #region Position
            // TODO: DO NOT SAVE PLAYER IF INSIDE INTERIOR, ALWAYS SAVE PLAYER BEFORE ENTERING INTERIOR, AND SPAWNING OUTSIDE

            MyPlayer.Position = new Position(MyPlayer.Ped.Position, MyPlayer.Ped.Rotation);
            #endregion

            #region Check Pausa

            if (!_paused)
            {
                if (Game.IsPaused || MenuHandler.IsAnyPauseMenuOpen)
                {
                    _paused = true;
                    MyPlayer.Status.PlayerStates.Paused = true;
                }
            }
            else
            {
                if (!Game.IsPaused & !MenuHandler.IsAnyPauseMenuOpen)
                {
                    _paused = false;
                    MyPlayer.Status.PlayerStates.Paused = false;
                }
            }

            #endregion

            /*//auto save player singularly or handled serverside for all players at once in an async task?
            if (_checkTimer.IsPassed)
            {
                if (MyPlayer.Status.Istanza.Instance != "IngressoRoleplay")
                {
                    Eventi.AggiornaPlayers();
                }
            }
            */
            await Task.FromResult(0);
        }
    }
}