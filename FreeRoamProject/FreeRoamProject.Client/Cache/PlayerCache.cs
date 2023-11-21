using FreeRoamProject.Shared.PlayerChar;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Cache
{
    public static class PlayerCache
    {
        private static bool _paused;
        private static SharedTimeChecker _checkTimer;

        public static PlayerClient MyClient { get; private set; }
        public static FreeRoamChar Character => MyClient.User.Character;
        public static Ped MyPed => MyClient.Ped;
        public static Player MyPlayer => MyClient.Player;



        public static async Task InitPlayer()
        {
            Tuple<Snowflake, BasePlayerShared> player = await EventDispatcher.Get<Tuple<Snowflake, BasePlayerShared>>("tlg:setupUser");
            MyClient = new PlayerClient(player);
            _checkTimer = new(3000);
            // TODO: THIS TICK STATUS... I DON'T LIKE IT HERE...
            // BUT THE POSITION THING IS LIKE A GLOBAL.. IT'S USED EVERYWHERE EVEN BEFORE SPAWNING SO...
            // WE CAN LEAVE IT HERE?
            ClientMain.Instance.AddTick(TickStatus);
        }
        public static async Task Loaded()
        {
            while (MyClient == null || MyClient != null && !MyClient.Ready) await BaseScript.Delay(0);
        }


        /*

        //private static SharedTimeChecker _checkTimer;
        //_checkTimer = new(3000);
        */

        public static async Task TickStatus()
        {
            #region Position
            // TODO: PLAYERS SAVED INSIDE INTERIORS HAVE SPAWNPOINTS INSIDE + THE CAMERA ANIMATION LIKE IN GTA:O

            MyClient.Position = new Position(MyClient.Ped.Position, MyClient.Ped.Rotation);
            #endregion

            #region Check Pausa

            if (!_paused)
            {
                if (Game.IsPaused || MenuHandler.IsAnyPauseMenuOpen)
                {
                    _paused = true;
                    MyClient.Status.PlayerStates.Paused = true;
                }
            }
            else
            {
                if (!Game.IsPaused & !MenuHandler.IsAnyPauseMenuOpen)
                {
                    _paused = false;
                    MyClient.Status.PlayerStates.Paused = false;
                }
            }

            #endregion

            /*
            #region PlayersUpdate
            if (_checkTimer != null && _checkTimer.IsPassed)
            {
                //TODO: DO WE NEED IT? IS THERE A BETTER WAY TO UPDATE PLAYER DATA CLIENTSIDE? DO WE WANT TO USE CALLBACKS EVERYTIME EVEN IN TICKS ON FRAME?
                Events.updatePlayers();
            }

            #endregion
            */
            await Task.FromResult(0);
        }
    }
}