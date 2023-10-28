using FreeRoamProject.Client.TimeWeather;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.IPLs.dlc_casino
{
    public class Casino
    {
        private bool enabled;
        private Prop prop;
        private Prop platformHandle;
        private string _currentScreen;

        private string SCREEN_DIAMONDS = "CASINO_DIA_PL";
        private string SCREEN_SKULLS = "CASINO_HLW_PL";
        private string SCREEN_SNOW = "CASINO_SNWFLK_PL";
        private string SCREEN_WIN = "CASINO_WIN_PL";

        public Prop Wheel, Base, Lights1, Lights2, Arrow1, Arrow2;

        private int currentTime;
        private int renderTarget = 0;

        public int InteriorId = 275201;
        public List<string> Building = new()
        {
            "hei_dlc_casino_aircon",
            "hei_dlc_casino_aircon_lod",
            "hei_dlc_casino_door",
            "hei_dlc_casino_door_lod",
            "hei_dlc_vw_roofdoors_locked",
            "hei_dlc_windows_casino",
            "hei_dlc_windows_casino_lod",
            "vw_ch3_additions",
            "vw_ch3_additions_long_0",
            "vw_ch3_additions_strm_0",
            "vw_dlc_casino_door",
            "vw_dlc_casino_door_lod",
            "vw_casino_billboard",
            "vw_casino_billboard_lod(1)",
            "vw_casino_billboard_lod",
            "vw_int_placement_vw",
            "ch_h3_casino_cameras"
        };
        public string Main = "vw_casino_main";
        public string Garage = "vw_casino_garage";
        public string Carpark = "vw_casino_carpark";
        private bool showBigWin;

        public Vehicle ExpositionVeh { get; private set; }

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                IplManager.EnableIpl(Building, value);
                IplManager.EnableIpl(Main, value);
                IplManager.EnableIpl(Garage, value);
                IplManager.EnableIpl(Carpark, value);
                HandleProp(value);
            }
        }

        public bool ShowBigWin
        {
            get => showBigWin;
            set
            {
                showBigWin = value;
                if (value)
                {
                    SetCurrentScreen(SCREEN_WIN);
                    currentTime = Game.GameTime;
                }
            }
        }

        public async void HandleProp(bool value)
        {
            if (value)
            {
                int model = Functions.HashInt("vw_prop_vw_valet_01a");
                RequestModel((uint)model);
                while (!HasModelLoaded((uint)model)) await BaseScript.Delay(0);
                prop = await Functions.SpawnLocalProp(model, new Vector3(925.9088f, 51.24203f, 80.095f), false, true);
                prop.Heading = 58f;
                SetEntityProofs(prop.Handle, true, true, true, true, true, true, false, true);
                prop.IsInvincible = true;
                prop.IsPositionFrozen = true;
                SetModelAsNoLongerNeeded((uint)model);
            }
            else
            {
                if (prop is not null && prop.Exists()) prop.Delete();
            }
        }

        public async void CreateVehicleForDisplay(string model)
        {
            if (ExpositionVeh is not null && ExpositionVeh.Exists()) DeleteVehicle();
            ExpositionVeh = await Functions.SpawnLocalVehicle(model, new Vector3(1100f, 220f, -50f), 0);
            ExpositionVeh.IsCollisionEnabled = true;
            ExpositionVeh.IsInvincible = true;
            ExpositionVeh.IsDriveable = false;
            ExpositionVeh.IsEngineRunning = false;
            ExpositionVeh.AreLightsOn = false;
            ExpositionVeh.CanBeVisiblyDamaged = false;
            ExpositionVeh.Health = 1000;
            ExpositionVeh.EngineHealth = 1000;
            ExpositionVeh.PetrolTankHealth = 1000;
            ExpositionVeh.DirtLevel = 0;
            ExpositionVeh.IsRadioEnabled = false;
            ExpositionVeh.IsPersistent = true;
            ExpositionVeh.PlaceOnGround();
            SetVehicleFullbeam(ExpositionVeh.Handle, false);
            SetVehicleFixed(ExpositionVeh.Handle);
            SetEntityProofs(ExpositionVeh.Handle, true, true, true, true, true, true, true, true);
            SetVehicleDoorsLocked(ExpositionVeh.Handle, 2);
            N_0xab04325045427aae(ExpositionVeh.Handle, false);
            N_0xdbc631f109350b8c(ExpositionVeh.Handle, true);
            N_0x2311dd7159f00582(ExpositionVeh.Handle, true);
            if (platformHandle is null || !platformHandle.Exists())
            {
                await BaseScript.Delay(500);
                platformHandle = new(GetClosestObjectOfType(1100f, 220f, -50f, 1f, Functions.HashUint("vw_prop_vw_casino_podium_01a"), false, false, false));
            }
            Vector3 offset = ExpositionVeh.GetPositionOffset(platformHandle.Position);
            AttachEntityToEntity(ExpositionVeh.Handle, platformHandle.Handle, -1, 0f, 0f, -offset.Z, 0f, 0f, 0f, false, false, false, false, 2, true);
            ClientMain.Instance.AddTick(OnTurnTableTask);
        }

        public void DeleteVehicle()
        {
            ExpositionVeh.Delete();
            ExpositionVeh = null;
            ClientMain.Instance.RemoveTick(OnTurnTableTask);
        }

        private async Task OnTurnTableTask()
        {
            try
            {
                if (platformHandle is null || !platformHandle.Exists())
                {
                    await BaseScript.Delay(500);
                    platformHandle = new(GetClosestObjectOfType(1100f, 220f, -50f, 1f, Functions.HashUint("vw_prop_vw_casino_podium_01a"), false, false, false));
                }
                else
                {
                    platformHandle.Heading += 8 * Timestep();
                    if (platformHandle.Heading >= 360)
                        platformHandle.Heading -= 360;
                }
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error(ex.ToString());
            }
        }

        public async void CreateWheel()
        {
            RequestScriptAudioBank("DLC_VINEWOOD\\CASINO_GENERAL", false);
            int m1a = Functions.HashInt("vw_prop_vw_luckylight_off");
            int m1b = Functions.HashInt("vw_prop_vw_luckylight_on");
            int m2a = Functions.HashInt("vw_prop_vw_jackpot_off");
            int m2b = Functions.HashInt("vw_prop_vw_jackpot_on");
            Vector3 wheelPos = new(1111.05f, 229.85f, -50.37f);
            int model1 = Functions.HashInt("vw_prop_vw_luckywheel_02a");
            int model2 = Functions.HashInt("vw_prop_vw_luckywheel_01a");

            ClearArea(wheelPos.X, wheelPos.Y, wheelPos.Z, 5.0f, true, false, false, false);
            Wheel = await Functions.SpawnLocalProp(model1, new(wheelPos.X, wheelPos.Y, wheelPos.Z), false, false);
            Wheel.Heading = 0;
            Base = await Functions.SpawnLocalProp(model2, new(wheelPos.X, wheelPos.Y, wheelPos.Z - 0.26f), false, false);
            Base.Heading = 0;
            Lights1 = await Functions.SpawnLocalProp(m1a, new(wheelPos.X, wheelPos.Y, wheelPos.Z + 0.35f), false, false);
            Lights1.Heading = 0;
            Lights2 = await Functions.SpawnLocalProp(m1b, new(wheelPos.X, wheelPos.Y, wheelPos.Z + 0.35f), false, false);
            Lights2.IsVisible = false;
            Lights2.Heading = 0;
            Arrow1 = await Functions.SpawnLocalProp(m2a, new(wheelPos.X, wheelPos.Y, wheelPos.Z + 2.5f), false, false);
            Arrow1.Heading = 0;
            Arrow2 = await Functions.SpawnLocalProp(m2b, new(wheelPos.X, wheelPos.Y, wheelPos.Z + 2.5f), false, false);
            Arrow2.IsVisible = false;
            Arrow2.Heading = 0;
        }

        public async void RenderWalls(bool val)
        {
            while (Screen.Fading.IsFadedOut) await BaseScript.Delay(100);
            if (val)
            {
                RequestStreamedTextureDict("Prop_Screen_Vinewood", false);
                while (!HasStreamedTextureDictLoaded("Prop_Screen_Vinewood")) await BaseScript.Delay(0);
                renderTarget = RenderTargets.CreateNamedRenderTargetForModel("casinoscreen_01", Functions.HashUint("vw_vwint01_video_overlay"));
                await BaseScript.Delay(1000);
                SetCurrentScreen(WeatherClient.Weather.CurrentWeather switch
                {
                    (int)Weather.Christmas or (int)Weather.Snowing or (int)Weather.Snowlight or (int)Weather.Blizzard => SCREEN_SNOW,
                    (int)Weather.Halloween => SCREEN_SKULLS,
                    _ => SCREEN_DIAMONDS,
                });
                ClientMain.Instance.AddTick(RenderDiamonds);
            }
            else
            {
                ReleaseNamedRendertarget("casinoscreen_01");
                SetStreamedTextureDictAsNoLongerNeeded("Prop_Screen_Vinewood");
                SetTvChannel(-1);
                ClientMain.Instance.RemoveTick(RenderDiamonds);
            }
        }

        private void SetCurrentScreen(string value)
        {
            _currentScreen = value;
            SetTvChannelPlaylist(0, _currentScreen, true);
            SetTvAudioFrontend(true);
            SetTvVolume(-100);
            SetTvChannel(0);
        }

        private async Task RenderDiamonds()
        {
            if (ShowBigWin)
            {
                if (Game.GameTime - currentTime > 9000)
                {
                    ShowBigWin = false;
                    SetCurrentScreen(WeatherClient.Weather.CurrentWeather switch
                    {
                        (int)Weather.Christmas or (int)Weather.Snowing or (int)Weather.Snowlight or (int)Weather.Blizzard => SCREEN_SNOW,
                        (int)Weather.Halloween => SCREEN_SKULLS,
                        _ => SCREEN_DIAMONDS,
                    });
                }

            }
            else
            {
                if (Game.GameTime - currentTime > 42666)
                {
                    currentTime = Game.GameTime;
                    SetCurrentScreen(WeatherClient.Weather.CurrentWeather switch
                    {
                        (int)Weather.Christmas or (int)Weather.Snowing or (int)Weather.Snowlight or (int)Weather.Blizzard => SCREEN_SNOW,
                        (int)Weather.Halloween => SCREEN_SKULLS,
                        _ => SCREEN_DIAMONDS,
                    });
                }
            }

            renderTarget = RenderTargets.CreateNamedRenderTargetForModel("casinoscreen_01", Functions.HashUint("vw_vwint01_video_overlay"));
            SetTextRenderId(renderTarget);
            SetScriptGfxDrawOrder(4);
            SetScriptGfxDrawBehindPausemenu(true);
            DrawInteractiveSprite("Prop_Screen_Vinewood", "BG_Wall_Colour_4x4", 0.25f, 0.5f, 0.5f, 1.0f, 0.0f, 255, 255, 255, 255);
            DrawTvChannel(0.5f, 0.5f, 1.0f, 1.0f, 0.0f, 255, 255, 255, 255);
            SetTextRenderId(GetDefaultScriptRendertargetRenderId());
        }
    }
}
