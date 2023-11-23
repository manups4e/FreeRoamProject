using FreeRoamProject.Client.GameMode.FREEROAM.CharCreation;
using FreeRoamProject.Client.GameMode.FREEROAM.Spawner;
using FreeRoamProject.Client.Handlers;
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
            MinimapHandler.MinimapEnabled = false;
            await PlayerCache.InitPlayer();
            await PlayerCache.Loaded();
            while (!NetworkIsPlayerActive(PlayerCache.MyClient.Player.Handle))
                await BaseScript.Delay(0);
            if (PlayerCache.MyClient.Ped.Model.Hash != (int)PedHash.FreemodeMale01)
            {
                await PlayerCache.MyClient.Player.ChangeModel(new Model(PedHash.FreemodeMale01));
                PlayerCache.MyClient.Ped.Style.SetDefaultClothes();
            }

            // utility events.. to be fixed (remove non utility events and move them)
            Events.Init();
            PlayerCache.MyClient.Ped.IsPositionFrozen = true;
            PlayerCache.MyClient.Player.IgnoredByPolice = false;
            PlayerCache.MyClient.Player.DispatchsCops = true;
            //Screen.Hud.IsRadarVisible = false;
            Screen.Hud.IsRadarVisible = true;
            // TODO: maybe this part too 🤔
            CharLoad();
        }

        public static async void CharLoad()
        {
            if (PlayerCache.MyClient.Ped.IsVisible)
                await Functions.FadeEntityAsync(PlayerCache.MyClient.Ped, false, false, false);
            StopPlayerSwitch();
            RequestCollisionAtCoord(-103.310f, -1215.578f, 1000);
            PlayerCache.MyClient.Ped.Position = new Vector3(-103.310f, -1215.578f, 1000);
            PlayerCache.MyClient.Ped.Heading = 270.975f;
            PlayerCache.MyClient.Player.CanControlCharacter = false;

            string settings = await EventDispatcher.Get<string>("Config.CallClientConfig");
            string sharedSettings = await EventDispatcher.Get<string>("Config.CallSharedConfig");
            ConfigShared.SharedConfig = sharedSettings.FromJson<SharedConfig>();
            ClientMain.Settings.LoadConfig(settings);

            FreeRoamChar roamchar = await EventDispatcher.Get<FreeRoamChar>("tlg:Select_FreeRoamChar", Cache.PlayerCache.MyClient.User.ID);
            PlayerCache.MyClient.User.Character = roamchar;
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
            if (PlayerCache.MyClient.User.Character.Position is not null)
            {
                Vector3 newVec = new Vector3();
                Position coords = PlayerCache.MyClient.User.Character.Position;
                SetFocusPosAndVel(coords.X, coords.Y, coords.Z, 0, 0, 0);
                RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
                Vector3 loadVect = (await PlayerCache.MyClient.User.Character.Position.GetPositionWithGroundZ()).ToVector3;
                int tempTimer = GetNetworkTime();
                bool safe = GetSafeCoordForPed(loadVect.X, loadVect.Y, loadVect.Z, true, ref newVec, 0);
                while (!safe)
                {
                    safe = GetSafeCoordForPed(loadVect.X, loadVect.Y, loadVect.Z, true, ref newVec, 0);
                    if (GetNetworkTime() - tempTimer > 5000)
                    {
                        ClientMain.Logger.Warning("Waiting for the safest coord to load is taking too long (more than 5s). Breaking from wait loop.");
                        break;
                    }
                    await BaseScript.Delay(1000);
                }
                if (safe)
                {
                    PlayerCache.MyClient.User.Character.Position = await new Position(newVec, PlayerCache.MyClient.User.Character.Position.ToRotationVector).GetPositionWithGroundZ();
                    ClearFocus();
                }
            }
            await BaseScript.Delay(1000);

            SwitchOutPlayer(PlayerCache.MyClient.Ped.Handle, 1, 1);
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