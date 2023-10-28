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
            // we spawn in the hangar.. but i'm not sure this is definitive.. i'd prefer somewhere else
            IPLs.IPLInstance.SmugglerHangar.LoadDefault();
            await PlayerCache.InitPlayer();
            while (!NetworkIsPlayerActive(PlayerCache.MyPlayer.Player.Handle)) await BaseScript.Delay(0);
            BaseScript.TriggerServerEvent("lprp:coda:playerConnected");
            ClientMain.Instance.NuiManager.SendMessage(new { resname = GetCurrentResourceName() });
            if (PlayerCache.MyPlayer.Ped.Model.Hash != (int)PedHash.FreemodeMale01)
                await PlayerCache.MyPlayer.Player.ChangeModel(new Model(PedHash.FreemodeMale01));
            NetworkSetTalkerProximity(-1000f);

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
        // ALSO WE NEED TO ADD THE PLAYER TO A BUCKET BECAUSE.. MY IDEA IS TO USE BUCKET 0 FOR PLAYER JOINING.. AND THEN FROM BUCKET 1 AND ABOVE FOR EVERYTHING ELSE
        public static async void CharLoad()
        {
            PlayerCache.MyPlayer.Player.CanControlCharacter = false;
            if (PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(PlayerCache.MyPlayer.Ped.Handle, true, false);
            RequestCollisionAtCoord(0, 0, 0);
            PlayerCache.MyPlayer.Ped.Position = new Vector3(0);
            SwitchOutPlayer(PlayerPedId(), 1 | 32 | 128 | 16384, 1);
            Ped p = PlayerCache.MyPlayer.Ped;
            p.Style.SetDefaultClothes();
            await PlayerCache.Loaded();
            PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
            ShutdownLoadingScreen();
            ShutdownLoadingScreenNui();
            ClampGameplayCamPitch(0, 0);
            ClampGameplayCamYaw(0, 0);
            Screen.Fading.FadeIn(1000);
            //MainChooser.Bucket_n_Players = await EventDispatcher.Get<Dictionary<ModalitaServer, int>>("tlg:richiediContoBuckets");
            //SpawnParticle.StartNonLoopedOnEntityNetworked("scr_powerplay_beast_appear", PlayerCache.MyPlayer.Ped);
            Function.Call(Hash.NETWORK_FADE_IN_ENTITY, PlayerCache.MyPlayer.Ped.Handle, true, 1);
            await BaseScript.Delay(10000);
            FreeRoamLogin.Initialize();
            PlayerCache.MyPlayer.Status.PlayerStates.PassiveMode = true;
        }
    }
}