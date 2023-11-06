﻿using FreeRoamProject.Client.GameMode.FREEROAM.CharCreation;
using FreeRoamProject.Client.GameMode.FREEROAM.Spawner;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Core.Ingresso
{
    internal static class ServerJoining
    {
        private static bool _firstTick = true;

        public static async void Init()
        {
#if DEBUG
            // this is to enable script restart.. without this script restart won't work.. (expected behaviour as we won't restart gamemode on production)
            ClientMain.Instance.AddTick(Entra);
#endif
            InternalGameEvents.PlayerJoined += InternalGameEvents_PlayerJoined;
        }

        private static void InternalGameEvents_PlayerJoined()
        {
            //Screen.Fading.FadeIn(0);
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

        // this is the first thing happening when entering the server
        public static async void PlayerSpawned()
        {
            _firstTick = false;
            Screen.Fading.FadeOut(800);
            while (!Screen.Fading.IsFadedOut) await BaseScript.Delay(1000);
            await PlayerCache.InitPlayer();
            await PlayerCache.Loaded();
            while (!NetworkIsPlayerActive(PlayerCache.MyPlayer.Player.Handle))
                await BaseScript.Delay(0);
            if (PlayerCache.MyPlayer.Ped.Model.Hash != (int)PedHash.FreemodeMale01)
            {
                await PlayerCache.MyPlayer.Player.ChangeModel(new Model(PedHash.FreemodeMale01));
                PlayerCache.MyPlayer.Ped.Style.SetDefaultClothes();
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
            if (PlayerCache.MyPlayer.Ped.IsVisible)
                NetworkFadeOutEntity(PlayerCache.MyPlayer.Ped.Handle, true, false);
            StopPlayerSwitch();
            RequestCollisionAtCoord(-103.310f, -1215.578f, 1000);
            PlayerCache.MyPlayer.Ped.Position = new Vector3(-103.310f, -1215.578f, 1000);
            PlayerCache.MyPlayer.Ped.Heading = 270.975f;
            PlayerCache.MyPlayer.Player.CanControlCharacter = false;
            if (PlayerCache.MyPlayer.Ped.IsVisible)
                NetworkFadeOutEntity(PlayerCache.MyPlayer.Ped.Handle, true, false);

            string settings = await EventDispatcher.Get<string>("Config.CallClientConfig");
            string sharedSettings = await EventDispatcher.Get<string>("Config.CallSharedConfig");
            ConfigShared.SharedConfig = sharedSettings.FromJson<SharedConfig>();
            ClientMain.Settings.LoadConfig(settings);

            FreeRoamChar roamchar = await EventDispatcher.Get<FreeRoamChar>("tlg:Select_FreeRoamChar", Cache.PlayerCache.MyPlayer.User.ID);
            PlayerCache.MyPlayer.User.Character = roamchar;
            if (roamchar.CharID == 0 && roamchar.Skin is null)
            {
                StopPlayerSwitch();
                ShutdownLoadingScreen();
                ShutdownLoadingScreenNui();
                RequestModel((uint)PedHash.FreemodeMale01);
                RequestModel((uint)PedHash.FreemodeFemale01);
                FreeRoamCreator.Init();
                string sex = SharedMath.GetRandomInt(0, 100) > 50 ? "Male" : "Female";
                await FreeRoamCreator.CharCreationMenu(sex);
                return;
            }
            await BaseScript.Delay(1000);
            if (PlayerCache.MyPlayer.User.Character.Position is not null)
            {
                Vector3 newVec = new Vector3();
                Position coords = PlayerCache.MyPlayer.User.Character.Position;
                SetFocusPosAndVel(coords.X, coords.Y, coords.Z, 0, 0, 0);
                RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
                Vector3 loadVect = (await PlayerCache.MyPlayer.User.Character.Position.GetPositionWithGroundZ()).ToVector3;
                int tempTimer = GetNetworkTimeAccurate();
                bool safe = GetSafeCoordForPed(loadVect.X, loadVect.Y, loadVect.Z, true, ref newVec, 0);
                while (!safe)
                {
                    safe = GetSafeCoordForPed(loadVect.X, loadVect.Y, loadVect.Z, true, ref newVec, 0);
                    if (GetNetworkTimeAccurate() - tempTimer > 5000)
                    {
                        ClientMain.Logger.Warning("Waiting for the safest coord to load is taking too long (more than 5s). Breaking from wait loop.");
                        break;
                    }
                    await BaseScript.Delay(1000);
                }
                if (safe)
                {
                    PlayerCache.MyPlayer.User.Character.Position = await new Position(newVec, PlayerCache.MyPlayer.User.Character.Position.ToRotationVector).GetPositionWithGroundZ();
                    ClearFocus();
                }
            }
            await BaseScript.Delay(1000);

            SwitchOutPlayer(PlayerCache.MyPlayer.Ped.Handle, 1, 1);
            // wait until the camera has done the 3 steps.. only after we start
            while (GetPlayerSwitchState() != 5) await BaseScript.Delay(0);

            await BaseScript.Delay(2000);

            ShutdownLoadingScreen();
            ShutdownLoadingScreenNui();
            ClampGameplayCamPitch(0, 0);
            ClampGameplayCamYaw(0, 0);
            Screen.Fading.FadeIn(1000);
            await FreeRoamLogin.LoadPlayer();
        }
    }
}