using FreeRoamProject.Shared.PlayerChar;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Cache
{
    public static class PlayerCache
    {
        private static bool _paused;
        private static SharedTimeChecker _checkTimer;

        public static PlayerClient MyPlayer { get; private set; }
        public static FreeRoamChar Character => MyPlayer.User.Character;


        public static async Task InitPlayer()
        {
            Tuple<Snowflake, BasePlayerShared> player = await EventDispatcher.Get<Tuple<Snowflake, BasePlayerShared>>("tlg:setupUser");
            MyPlayer = new PlayerClient(player);
            _checkTimer = new(3000);
            ClientMain.Instance.AddTick(TickStatus);
        }
        public static async Task Loaded()
        {
            while (MyPlayer == null || MyPlayer != null && !MyPlayer.Ready) await BaseScript.Delay(0);
        }


        /*

        //private static SharedTimeChecker _checkTimer;
        //_checkTimer = new(3000);
        */

        public static async Task TickStatus()
        {
            #region Position
            // TODO: PLAYERS SAVED INSIDE INTERIORS HAVE SPAWNPOINTS INSIDE + THE CAMERA ANIMATION LIKE IN GTA:O

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