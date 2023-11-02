using FreeRoamProject.Client.GameMode.FREEROAM.CharCreation;
using FreeRoamProject.Client.GameMode.FREEROAM.Spawner;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Core.Ingresso
{
    internal static class ServerJoining
    {
        private static bool _firstTick = true;

        public static async void Init()
        {
            EventDispatcher.Mount("tlg:SetBucketsPlayers", new Action<int>(UpdateCountPlayers));
#if DEBUG
            // this is to enable script restart.. without this script restart won't work.. (expected behaviour as we won't restart gamemode on production)
            ClientMain.Instance.AddTick(Entra);
#endif
            InternalGameEvents.PlayerJoined += InternalGameEvents_PlayerJoined;
        }

        private static void InternalGameEvents_PlayerJoined()
        {
            Screen.Fading.FadeIn(0);
            PlayerSpawned();
        }

        private static async Task Entra()
        {
            await BaseScript.Delay(100);
            if (NetworkIsSessionStarted() && _firstTick)
            {
                _firstTick = false;
                PlayerSpawned();
                ClientMain.Instance.RemoveTick(Entra);
            }

            await Task.FromResult(0);
        }

        private static void UpdateCountPlayers(int count)
        {
        }

        // this is the first thing happening when entering the server
        public static async void PlayerSpawned()
        {
            _firstTick = false;
            Screen.Fading.FadeOut(800);
            while (!Screen.Fading.IsFadedOut) await BaseScript.Delay(1000);
            await PlayerCache.InitPlayer();
            while (!NetworkIsPlayerActive(PlayerCache.MyPlayer.Player.Handle)) await BaseScript.Delay(0);
            if (PlayerCache.MyPlayer.Ped.Model.Hash != (int)PedHash.FreemodeMale01)
            {
                await PlayerCache.MyPlayer.Player.ChangeModel(new Model(PedHash.FreemodeMale01));
            }

            // utility events.. to be fixed (remove non utility events and move them)
            Events.Init();
            PlayerCache.MyPlayer.Ped.IsPositionFrozen = true;
            PlayerCache.MyPlayer.Player.IgnoredByPolice = true;
            PlayerCache.MyPlayer.Player.DispatchsCops = false;
            //Screen.Hud.IsRadarVisible = false;
            Screen.Hud.IsRadarVisible = true;
            // TODO: maybe this part too 🤔
            CharLoad();
        }

        // TODO: READ CAREFULLY
        // THIS METHOD WAS INTENDED TO SPAWN THE PLAYER INTO THE HANGAR FOR THE LOBBY...
        // SINCE AT THE END OF THIS WE CALL FreeRoamLogin.Initialize() THAT CHECKS FOR THE PLAYER DATA (CREATE OR LOGIN?) WE CAN DIRECTLY SHIFT TO THAT?
        // ALSO WE NEED TO ADD THE PLAYER TO A BUCKET BECAUSE.. GAME USES BUCKET 0 FOR PLAYER JOINING.. SO I WANT TO USE BUCKET 10 AND ABOVE FOR EVERYTHING ELSE..
        // WE CAN KEEP BUCKETS 1-9 FOR ANYTHING WE COULD USE THEM.. 
        public static async void CharLoad()
        {
            FreeRoamChar roamchar = await EventDispatcher.Get<FreeRoamChar>("tlg:Select_FreeRoamChar", Cache.PlayerCache.MyPlayer.User.ID);
            PlayerCache.MyPlayer.User.Character = roamchar;
            if (roamchar.CharID == 0 && roamchar.Skin is null)
            {
                DoScreenFadeOut(800);
                await BaseScript.Delay(800);
                StopPlayerSwitch();
                RequestModel((uint)PedHash.FreemodeMale01);
                RequestModel((uint)PedHash.FreemodeFemale01);
                FreeRoamCreator.Init();
                string sex = SharedMath.GetRandomInt(0, 100) > 50 ? "Male" : "Female";
                await FreeRoamCreator.CharCreationMenu(sex);
                return;
            }
            PlayerCache.MyPlayer.Player.CanControlCharacter = false;
            if (PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(PlayerCache.MyPlayer.Ped.Handle, true, false);
            RequestCollisionAtCoord(0, 0, -199);
            Vector3 vector = (await PlayerCache.MyPlayer.User.Character.Position.GetPositionWithGroundZ()).ToVector3;
            Vector3 loadVect = vector;
            GetSafeCoordForPed(loadVect.X, loadVect.Y, loadVect.Z, false, ref vector, 16);
            PlayerCache.MyPlayer.User.Character.Position = await new Position(vector, PlayerCache.MyPlayer.User.Character.Position.ToRotationVector).GetPositionWithGroundZ();
            PlayerCache.MyPlayer.Ped.Position = new Vector3(0);
            SwitchOutPlayer(PlayerPedId(), 0, 1);
            // wait until the camera has done the 3 steps.. only after we start
            while (GetPlayerSwitchState() != 5) await BaseScript.Delay(0);
            Ped p = PlayerCache.MyPlayer.Ped;
            p.Style.SetDefaultClothes();
            await PlayerCache.Loaded();
            PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
            ShutdownLoadingScreen();
            ShutdownLoadingScreenNui();
            ClampGameplayCamPitch(0, 0);
            ClampGameplayCamYaw(0, 0);
            Screen.Fading.FadeIn(1000);
            await FreeRoamLogin.LoadPlayer();
            //MainChooser.Bucket_n_Players = await EventDispatcher.Get<Dictionary<ModalitaServer, int>>("tlg:richiediContoBuckets");
            //SpawnParticle.StartNonLoopedOnEntityNetworked("scr_powerplay_beast_appear", PlayerCache.MyPlayer.Ped);
            //PlayerCache.MyPlayer.Status.PlayerStates.PassiveMode = true;
        }
    }
}