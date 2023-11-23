using FreeRoamProject.Client;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreeRoamProject.FREEROAM.Banking
{
    static class BankingClient
    {
        #region "mightBeUseful" variables
        private static List<Position> _atmpos = new List<Position>()
        {
            new Position(-717.651f, -915.619f, 19.215f),
            new Position(147.657f, -1035.346f, 29.343f),
            new Position(146.091f, -1035.148f, 29.343f),
            new Position(-1315.867f, -834.832f, 16.961f),
            new Position(288.923f, -1256.765f, 29.441f),
            new Position(-56.838f, -1752.119f, 29.421f),
            new Position(-845.966f, -341.163f, 38.681f),
            new Position(1153.797f, -326.707f, 69.205f),
            new Position(1769.342f, 3337.526f, 41.433f),
            new Position(1769.801f, 3336.802f, 41.433f),
            new Position(174.312f, 6637.667f, 31.573f),
            new Position(-2538.903f, 2317.082f, 33.215f),
            new Position(-2538.834f, 2315.985f, 33.215f),
            new Position(2559.105f, 350.899f, 108.621f),
            new Position(-386.733f, 6045.953f, 31.501f),
            new Position(-283.0f, 6225.99f, 31.49f),
            new Position(-135.165f, 6365.738f, 31.101f),
            new Position(-110.753f, 6467.703f, 31.784f),
            new Position(-94.9690f, 6455.301f, 31.784f),
            new Position(155.4300f, 6641.991f, 31.784f),
            new Position(174.6720f, 6637.218f, 31.784f),
            new Position(1703.138f, 6426.783f, 32.730f),
            new Position(1735.114f, 6411.035f, 35.164f),
            new Position(1702.842f, 4933.593f, 42.051f),
            new Position(1967.333f, 3744.293f, 32.272f),
            new Position(1821.917f, 3683.483f, 34.244f),
            new Position(1174.532f, 2705.278f, 38.027f),
            new Position(540.0420f, 2671.007f, 42.177f),
            new Position(2564.399f, 2585.100f, 38.016f),
            new Position(2558.683f, 349.6010f, 108.050f),
            new Position(2558.051f, 389.4817f, 108.660f),
            new Position(1077.692f, -775.796f, 58.218f),
            new Position(1139.018f, -469.886f, 66.789f),
            new Position(1168.975f, -457.241f, 66.641f),
            new Position(1153.884f, -326.540f, 69.245f),
            new Position(381.2827f, 323.2518f, 103.270f),
            new Position(236.4638f, 217.4718f, 106.840f),
            new Position(265.0043f, 212.1717f, 106.780f),
            new Position(285.2029f, 143.5690f, 104.970f),
            new Position(157.7698f, 233.5450f, 106.450f),
            new Position(-164.568f, 233.5066f, 94.919f),
            new Position(-1827.04f, 785.5159f, 138.020f),
            new Position(-1409.39f, -99.2603f, 52.473f),
            new Position(-1205.35f, -325.579f, 37.870f),
            new Position(-1215.64f, -332.231f, 37.881f),
            new Position(-2072.41f, -316.959f, 13.345f),
            new Position(-2975.72f, 379.7737f, 14.992f),
            new Position(-2962.60f, 482.1914f, 15.762f),
            new Position(-2955.70f, 488.7218f, 15.486f),
            new Position(-3044.22f, 595.2429f, 7.595f),
            new Position(-3144.13f, 1127.415f, 20.868f),
            new Position(-3241.10f, 996.6881f, 12.500f),
            new Position(-3241.11f, 1009.152f, 12.877f),
            new Position(-1305.40f, -706.240f, 25.352f),
            new Position(-538.225f, -854.423f, 29.234f),
            new Position(-711.156f, -818.958f, 23.768f),
            new Position(-526.566f, -1222.90f, 18.434f),
            new Position(-256.831f, -719.646f, 33.444f),
            new Position(-203.548f, -861.588f, 30.205f),
            new Position(114.205f, -776.737f, 31.418f),
            new Position(111.021f, -775.579f, 31.439f),
            new Position(112.9290f, -818.710f, 31.386f),
            new Position(119.9000f, -883.826f, 31.191f),
            new Position(149.4551f, -1038.95f, 29.366f),
            new Position(-846.304f, -340.402f, 38.687f),
            new Position(-1204.35f, -324.391f, 37.877f),
            new Position(-1216.27f, -331.461f, 37.773f),
            new Position(-261.692f, -2012.64f, 30.121f),
            new Position(-273.001f, -2025.60f, 30.197f),
            new Position(314.187f, -278.621f, 54.170f),
            new Position(-351.534f, -49.529f, 49.042f),
            new Position(24.589f, -946.056f, 29.357f),
            new Position(-254.112f, -692.483f, 33.616f),
            new Position(-1570.197f, -546.651f, 34.955f),
            new Position(-1415.909f, -211.825f, 46.500f),
            new Position(-1430.112f, -211.014f, 46.500f),
            new Position(33.232f, -1347.849f, 29.497f),
            new Position(129.216f, -1292.347f, 29.269f),
            new Position(288.58f, -1282.28f, 29.659f),
            new Position(295.839f, -895.640f, 29.217f),
            new Position(1686.753f, 4815.809f, 42.008f),
            new Position(-302.408f, -829.945f, 32.417f),
            new Position(5.134f, -919.949f, 29.557f),
            new Position(89.69f, 2.38f, 68.31f)
        };

        public static List<Vector3> bankCoordsVaults = new List<Vector3>() { new Vector3(-105.929f, 6477.292f, 31.626f), new Vector3(254.509f, 225.887f, 101.875f), new Vector3(-2957.678f, 480.944f, 15.706f), new Vector3(146.997f, -1045.069f, 29.368f) };

        public static List<Vector3> cleanspotcoords = new List<Vector3>() { new Vector3(1274.053f, -1711.756f, 54.771f), new Vector3(-1096.847f, 4947.532f, 218.354f) };

        private static List<ObjectHash> ATMs = new List<ObjectHash>() { ObjectHash.prop_atm_01, ObjectHash.prop_atm_02, ObjectHash.prop_atm_03, ObjectHash.prop_fleeca_atm };
        #endregion

        private static Prop ClosestATM;
        public static bool InterfaceOpen = false;
        public static bool MoneyHUDShowing = false;
        private static int transactionMoney = 0;
        private static int currentAnimState = 0;
        private static int iLocal_505 = -1;
        private static bool stopAnim = true;

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }

        public static void Spawned(PlayerClient client)
        {
            EventDispatcher.Mount("tlg:banking:transactionstatus", new Action<bool, string>(Status));
            EventDispatcher.Mount("tlg:changeMoney", new Action<int>(UpdateMoney));
            EventDispatcher.Mount("tlg:changeBank", new Action<int>(UpdateBank));
            HideMoney();
            /*
            foreach (Position pos in _atmpos) atmInputs.Add(new InputController(Control.Context, pos, "Press ~INPUT_CONTEXT~ to handle your bank account", new((MarkerType)(-1), pos, SColor.Transparent), ServerMode.Roleplay, PadCheck.Controller, action: new Action<Ped, object[]>(OpenCount)));
            InputHandler.AddInputList(atmInputs);
            */
            //AddTextEntry("MENU_PLYR_BANK", "Dirty money");
            TickController.TickOnFoot.Add(CheckATM);
        }
        public static void onPlayerLeft(PlayerClient client)
        {
            EventDispatcher.Unmount("tlg:banking:transactionstatus");
            EventDispatcher.Unmount("tlg:changeMoney");
            EventDispatcher.Unmount("tlg:changeBank");
            TickController.TickOnFoot.Remove(CheckATM);
            //InputHandler.RemoveInputList(atmInputs);
            //atmInputs.Clear();
            //AddTextEntry("MENU_PLYR_BANK", "Bank money");
        }

        private static async void UpdateMoney(int mon)
        {
            ShowMoney();
            PlayerCache.Character.Finance.Money += mon;
            N_0xe67c6dfd386ea5e7(false); //_ALLOW_ADDITIONAL_INFO_FOR_MULTIPLAYER_HUD_CASH
            StatSetInt(Functions.HashUint("MP0_WALLET_BALANCE"), PlayerCache.Character.Finance.Money, true);
            await BaseScript.Delay(5000);
            MoneyHUDShowing = false;
        }

        private static async void UpdateBank(int mon)
        {
            ShowMoney();
            PlayerCache.Character.Finance.Bank += mon;
            N_0xe67c6dfd386ea5e7(false); //_ALLOW_ADDITIONAL_INFO_FOR_MULTIPLAYER_HUD_CASH
            StatSetInt(Functions.HashUint("BANK_BALANCE"), PlayerCache.Character.Finance.Bank, true);
        }

        public static async void ShowMoney()
        {
            MoneyHUDShowing = true;
            N_0xe67c6dfd386ea5e7(false); //_ALLOW_ADDITIONAL_INFO_FOR_MULTIPLAYER_HUD_CASH
            SetMultiplayerWalletCash();
            SetMultiplayerBankCash();
            await BaseScript.Delay(5000);
            MoneyHUDShowing = false;
        }

        public static void HideMoney()
        {
            RemoveMultiplayerWalletCash();
            RemoveMultiplayerBankCash();
            MoneyHUDShowing = false;
        }

        public static async Task CheckATM()
        {
            if (ClosestATM == null)
            {
                ClosestATM = World.GetAllProps().Where(o => ATMs.Contains((ObjectHash)o.Model.Hash)).FirstOrDefault(o => PlayerCache.MyClient.Position.Distance(o.Position) < 1.5f);
                await BaseScript.Delay(250);
            }
            else
            {
                Vector3 pos = ClosestATM.Position;
                if (PlayerCache.MyClient.Position.Distance(pos) > 2f)
                    ClosestATM = null;

                if (!InterfaceOpen)
                {
                    //if not wearing ballistic equipment (SHOP_JUGG_NONE, GB_COUT_ATM)
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("FINH_ATMNEAR").Replace("~a~", "~INPUT_CONTEXT~"));
                    if (Input.IsControlJustPressed(Control.Context))
                    {
                        PlayerCache.MyPed.Weapons.Select(WeaponHash.Unarmed);
                        PlayerCache.MyPed.Task.GoTo(ClosestATM.Position);
                        await BaseScript.Delay(1000);
                        EnableBank();
                    }
                }
            }
        }

        public static void OpenCount(Ped _, object[] args)
        {
            if (ClosestATM != null && !InterfaceOpen) EnableBank();
        }
        public static void Status(bool success, string msg)
        {
        }

        private static Scaleform atm = new Scaleform("ATM");
        private static int _currentSelection;
        private static int _actualMenu;
        private static int iLocal_674;
        private static int iLocal_675;
        private static float fLocal_591 = -1f;
        private static float fLocal_592;
        private static string _recipient;

        private static async void EnableBank()
        {
            StartAudioScene("ATM_PLAYER_SCENE");
            atm = new Scaleform("ATM");
            _actualMenu = 0;
            _currentSelection = 0;
            TryBankingNew(true, 0);
            Main.InstructionalButtons.SetInstructionalButtons(new List<InstructionalButton>()
            {
                new InstructionalButton(Control.FrontendCancel, Game.GetGXTEntry("MPATM_BACK")),
                new InstructionalButton(Control.FrontendSelect, Game.GetGXTEntry("MPATM_SELECT"))
            });
            ClientMain.Instance.AddTick(BankControls);
            ClientMain.Instance.AddTick(AtmDraw);
            Vector3 coords = ClosestATM.Position;
            TaskUseNearestScenarioToCoord(PlayerPedId(), coords.X, coords.Y, coords.Z, 2f, -1);
            ShowMoney();
            InterfaceOpen = true;
        }

        private static async Task AtmDraw()
        {
            if (atm.IsLoaded)
            {
                HideHudAndRadarThisFrame();
                HideScriptedHudComponentThisFrame(19);
                SetGameplayCamRelativePitch(0f, 1f);
                SetGameplayCamRelativeHeading(0f);
                ShowHudComponentThisFrame(4);
                ShowHudComponentThisFrame(5);
                ShowHudComponentThisFrame(13);
                ShowHudComponentThisFrame(3);
                SetScriptGfxDrawOrder(1);
                atm.Render2D();
            }
        }

        private async static Task BankControls()
        {
            int iVar0 = 0;
            int iVar1 = 0;
            float fVar2;
            DisableAllControlActions(0);
            DisableAllControlActions(1);
            DisableAllControlActions(2);
            Game.EnableControlThisFrame(2, Control.FrontendPauseAlternate);
            Game.EnableControlThisFrame(2, Control.FrontendUp);
            Game.EnableControlThisFrame(2, Control.FrontendLeft);
            Game.EnableControlThisFrame(2, Control.FrontendDown);
            Game.EnableControlThisFrame(2, Control.FrontendRight);
            Game.EnableControlThisFrame(2, Control.CursorAccept);
            Game.EnableControlThisFrame(2, Control.CursorCancel);

            if (Game.IsControlJustPressed(2, Control.FrontendUp))
            {
                atm.CallFunction("SET_INPUT_EVENT", 8);
                Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
            }

            if (Game.IsControlJustPressed(2, Control.FrontendDown))
            {
                atm.CallFunction("SET_INPUT_EVENT", 9);
                Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
            }

            if (Game.IsControlJustPressed(2, Control.FrontendLeft))
            {
                atm.CallFunction("SET_INPUT_EVENT", 10);
                Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
            }

            if (Game.IsControlJustPressed(2, Control.FrontendRight))
            {
                atm.CallFunction("SET_INPUT_EVENT", 11);
                Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
            }

            if (IsInputDisabled(2))
            {
                Game.EnableControlThisFrame(2, Control.CursorX);
                Game.EnableControlThisFrame(2, Control.CursorY);
                Game.EnableControlThisFrame(2, Control.CursorScrollUp);
                Game.EnableControlThisFrame(2, Control.CursorScrollDown);
                float fVar0;
                float fVar1;

                if (fLocal_591 == -1f)
                {
                    fLocal_591 = Game.GetControlNormal(2, Control.CursorX);
                    fLocal_592 = Game.GetControlNormal(2, Control.CursorY);
                }
                else if (fLocal_591 != Game.GetControlNormal(2, Control.CursorX) || fLocal_592 != Game.GetControlNormal(2, Control.CursorY))
                {
                    atm.CallFunction("SHOW_CURSOR", true);
                }

                ShowCursorThisFrame();
                fVar0 = Game.GetControlNormal(2, Control.CursorX);
                fVar1 = Game.GetControlNormal(2, Control.CursorY);
                if (fVar0 >= 0f && fVar0 <= 1f && fVar1 >= 0f && fVar1 <= 1f) atm.CallFunction("SET_MOUSE_INPUT", fVar0, fVar1);
                fVar2 = 1f + 10f * Timestep();
                if (Game.IsControlPressed(2, Control.CursorScrollDown) || Game.IsControlPressed(2, Control.FrontendDown)) iVar1 = -200;
                if (Game.IsControlPressed(2, Control.CursorScrollUp) || Game.IsControlPressed(2, Control.FrontendUp)) iVar1 = 200;
                atm.CallFunction("SET_ANALOG_STICK_INPUT", 0f, 0f, iVar1 * fVar2);
            }
            else
            {
                atm.CallFunction("SHOW_CURSOR", false);
                fLocal_591 = -1f;
                Game.EnableControlThisFrame(2, Control.FrontendRightAxisX);
                Game.EnableControlThisFrame(2, Control.FrontendRightAxisY);
                iVar0 = Game.GetControlValue(0, Control.FrontendRightAxisX) - 128;
                iVar1 = Game.GetControlValue(0, Control.FrontendRightAxisY) - 128;
                if (iVar0 < 10 && iVar0 > -10) iVar0 = 0;
                if (iVar1 < 10 && iVar1 > -10) iVar1 = 0;
                fVar2 = 1f + 10f * Timestep();

                if (iLocal_674 != iVar0 || iLocal_675 != iVar1)
                {
                    atm.CallFunction("SET_ANALOG_STICK_INPUT", 0f, -iVar0 * fVar2, -iVar1 * fVar2);
                    iLocal_674 = iVar0;
                    iLocal_675 = iVar1;
                }
            }

            if (Game.IsControlJustPressed(2, Control.FrontendAccept) || Game.IsControlJustPressed(2, Control.CursorAccept))
            {
                atm.CallFunction("SET_INPUT_SELECT");
                BeginScaleformMovieMethod(atm.Handle, "GET_CURRENT_SELECTION");
                int ind = EndScaleformMovieMethodReturn();
                while (!IsScaleformMovieMethodReturnValueReady(ind)) await BaseScript.Delay(0);
                _currentSelection = GetScaleformMovieFunctionReturnInt(ind);
                Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
                ClientMain.Logger.Debug("_currentSelection: " + _currentSelection);
                switch (_actualMenu)
                {
                    case 0: // menu principale
                        switch (_currentSelection)
                        {
                            case 0:
                                TryBankingNew(false, 0); // Back to main menu
                                _actualMenu = 0;

                                break;
                            case 1:
                                TryBankingNew(false, 1); // withdraw
                                _actualMenu = 1;

                                break;
                            case 2:
                                TryBankingNew(false, 2); // deposit
                                _actualMenu = 2;

                                break;
                            case 3:
                                TryBankingNew(false, 3); // transaction lists (to be saved)
                                _actualMenu = 3;

                                break;
                            case 4:
                                {
                                    Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
                                    ClientMain.Instance.RemoveTick(AtmDraw);
                                    ClientMain.Instance.RemoveTick(BankControls);
                                    Main.InstructionalButtons.ClearButtonList();
                                    atm.Dispose();
                                    StopAudioScene("ATM_PLAYER_SCENE");
                                    InterfaceOpen = false;
                                    HideMoney();
                                    if (IsPedUsingAnyScenario(PlayerPedId()))
                                    {
                                        SetPedShouldPlayImmediateScenarioExit(PlayerPedId());
                                        if (!IsPedDeadOrDying(PlayerPedId(), true))
                                            ClearPedTasks(PlayerPedId());
                                    }
                                    string Var7 = func_63(3);
                                    Vector3 coords = PlayerCache.MyPed.Position;
                                    Vector3 rot = ClosestATM.Rotation;
                                    iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, false, 1f, 0f, 1f);
                                    NetworkAddPedToSynchronisedScene(PlayerPedId(), iLocal_505, Var7, "exit", 8f, -4f, 5, 0, 1000f, 0);
                                    NetworkStartSynchronisedScene(iLocal_505);
                                    RemoveAnimDict(Var7);
                                }
                                break;
                        }

                        break;
                    case 1: // witdraw
                        switch (_currentSelection)
                        {
                            case 1:
                                if (PlayerCache.MyClient.User.Bank >= func_21(0, false))
                                {
                                    TryBankingNew(false, 5, func_21(0, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }

                                break;
                            case 2:
                                if (PlayerCache.MyClient.User.Bank >= func_21(1, false))
                                {
                                    TryBankingNew(false, 5, func_21(1, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }

                                break;
                            case 3:
                                if (PlayerCache.MyClient.User.Bank >= func_21(2, false))
                                {
                                    TryBankingNew(false, 5, func_21(2, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }
                                break;
                            case 4:
                                switch (_actualMenu)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 13:
                                        _actualMenu = 0;

                                        break;
                                    case 5:
                                        _actualMenu = 1;

                                        break;
                                    case 6:
                                        _actualMenu = 2;

                                        break;
                                    case 7:
                                        _actualMenu = 3;

                                        break;
                                }

                                TryBankingNew(false, _actualMenu);
                                break;
                            case 5:
                                if (PlayerCache.MyClient.User.Bank >= func_21(3, false))
                                {
                                    TryBankingNew(false, 5, func_21(3, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }

                                break;
                            case 6:
                                if (PlayerCache.MyClient.User.Bank >= func_21(4, false))
                                {
                                    TryBankingNew(false, 5, func_21(4, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }

                                break;
                            case 7:
                                if (PlayerCache.MyClient.User.Bank >= func_21(5, false))
                                {
                                    TryBankingNew(false, 5, func_21(5, false));
                                    _actualMenu = 5;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO2"));
                                    _actualMenu = 1;
                                }
                                break;
                        }

                        break;
                    case 2: // deposit
                        switch (_currentSelection)
                        {
                            case 1:
                                if (PlayerCache.MyClient.User.Money >= func_21(0, true))
                                {
                                    TryBankingNew(false, 6, func_21(0, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }

                                break;
                            case 2:
                                if (PlayerCache.MyClient.User.Money >= func_21(1, true))
                                {
                                    TryBankingNew(false, 6, func_21(1, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }

                                break;
                            case 3:
                                if (PlayerCache.MyClient.User.Money >= func_21(2, true))
                                {
                                    TryBankingNew(false, 6, func_21(2, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }

                                break;
                            case 4:
                                switch (_actualMenu)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 13:
                                        _actualMenu = 0;

                                        break;
                                    case 5:
                                        _actualMenu = 1;

                                        break;
                                    case 6:
                                        _actualMenu = 2;

                                        break;
                                    case 7:
                                        _actualMenu = 3;

                                        break;
                                }

                                TryBankingNew(false, _actualMenu);
                                break;
                            case 5:
                                if (PlayerCache.MyClient.User.Money >= func_21(3, true))
                                {
                                    TryBankingNew(false, 6, func_21(3, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }

                                break;
                            case 6:
                                if (PlayerCache.MyClient.User.Money >= func_21(4, true))
                                {
                                    TryBankingNew(false, 6, func_21(4, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }

                                break;
                            case 7:
                                if (PlayerCache.MyClient.User.Money >= func_21(5, true))
                                {
                                    TryBankingNew(false, 6, func_21(5, true));
                                    _actualMenu = 6;
                                }
                                else
                                {
                                    TryBankingNew(false, 13, 0, Game.GetGXTEntry("MPATM_NODO"));
                                    _actualMenu = 2;
                                }


                                break;
                        }

                        break;
                    case 3:
                        switch (_currentSelection)
                        {
                            case 1:
                                _actualMenu = 0;
                                TryBankingNew(false, _actualMenu);
                                break;
                        }
                        break;
                    case 4: // Esci
                        {
                            Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
                            ClientMain.Instance.RemoveTick(AtmDraw);
                            ClientMain.Instance.RemoveTick(BankControls);
                            atm.Dispose();
                            StopAudioScene("ATM_PLAYER_SCENE");
                            InterfaceOpen = false;
                            if (IsPedUsingAnyScenario(PlayerPedId()))
                            {
                                SetPedShouldPlayImmediateScenarioExit(PlayerPedId());
                                if (!IsPedDeadOrDying(PlayerPedId(), true))
                                    ClearPedTasks(PlayerPedId());
                            }
                            string Var7 = func_63(3);
                            Vector3 coords = PlayerCache.MyPed.Position;
                            Vector3 rot = ClosestATM.Rotation;
                            iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, false, 1f, 0f, 1f);
                            NetworkAddPedToSynchronisedScene(PlayerPedId(), iLocal_505, Var7, "exit", 8f, -4f, 5, 0, 1000f, 0);
                            NetworkStartSynchronisedScene(iLocal_505);
                            RemoveAnimDict(Var7);
                        }
                        break;
                    case 5: // ritiro
                        switch (_currentSelection)
                        {
                            case 1:
                                TryBankingNew(false, 7, 0, "", "atmwithdraw"); // withdraw
                                _actualMenu = 0;

                                break;
                            case 2:
                                TryBankingNew(false, 1); // withdraw
                                _actualMenu = 1;

                                break;
                        }

                        break;
                    case 6:
                        switch (_currentSelection)
                        {
                            case 1:
                                TryBankingNew(false, 7, 0, "", "atmdeposit"); // deposit
                                _actualMenu = 0;

                                break;
                            case 2:
                                TryBankingNew(false, 2); // deposit
                                _actualMenu = 2;

                                break;
                        }

                        break;
                    case 9:
                        switch (_currentSelection)
                        {
                            case 1:
                                TryBankingNew(false, 10, 0, "", "sendMoney"); // send
                                _actualMenu = 0;

                                break;
                            case 2:
                                TryBankingNew(false, 3);
                                _actualMenu = 3;

                                break;
                        }

                        break;
                }
            }

            if (Game.IsControlJustPressed(2, Control.FrontendCancel) || Game.IsControlJustPressed(2, Control.CursorCancel))
            {
                if (_actualMenu == 0)
                {
                    Game.PlaySound("PIN_BUTTON", "ATM_SOUNDS");
                    ClientMain.Instance.RemoveTick(AtmDraw);
                    ClientMain.Instance.RemoveTick(BankControls);
                    Main.InstructionalButtons.ClearButtonList();
                    atm.Dispose();
                    StopAudioScene("ATM_PLAYER_SCENE");
                    InterfaceOpen = false;
                    HideMoney();
                    if (IsPedUsingAnyScenario(PlayerPedId()))
                    {
                        SetPedShouldPlayImmediateScenarioExit(PlayerPedId());
                        if (!IsPedDeadOrDying(PlayerPedId(), true))
                            ClearPedTasks(PlayerPedId());
                        string Var7 = func_63(3);
                        Vector3 coords = PlayerCache.MyPed.Position;
                        Vector3 rot = ClosestATM.Rotation;
                        iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, false, 1f, 0f, 1f);
                        NetworkAddPedToSynchronisedScene(PlayerPedId(), iLocal_505, Var7, "exit", 8f, -4f, 5, 0, 1000f, 0);
                        NetworkStartSynchronisedScene(iLocal_505);
                        RemoveAnimDict(Var7);
                    }
                }
                else
                {
                    switch (_actualMenu)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 13:
                            _actualMenu = 0;

                            break;
                        case 5:
                            _actualMenu = 1;

                            break;
                        case 6:
                            _actualMenu = 2;

                            break;
                        case 7:
                            _actualMenu = 3;

                            break;
                    }

                    TryBankingNew(false, _actualMenu);
                }
            }
        }

        private static async void TryBankingNew(bool firstload, int menu, int cash = 0, string msg = "", string @event = "")
        {
            while (!atm.IsLoaded) await BaseScript.Delay(0);

            if (firstload)
            {
                atm.CallFunction("enterPINanim");
                atm.CallFunction("pinBeep");
            }

            atm.CallFunction("SET_DATA_SLOT_EMPTY");

            switch (menu)
            {
                case 0:
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    AddText("MPATM_SER");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(2);
                    AddText("MPATM_DIDM");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(1);
                    AddText("MPATM_WITM");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(3);
                    AddText("MPATM_LOG");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(4);
                    AddText("MPATM_EXIT");
                    EndScaleformMovieMethod();
                    atm.CallFunction("DISPLAY_MENU");

                    break;
                case 1: // withdraw
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    AddText("MPATM_WITMT");
                    EndScaleformMovieMethod();
                    if (PlayerCache.Character.Finance.Bank >= func_21(0, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(1);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(0, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Bank >= func_21(1, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(2);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(1, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Bank >= func_21(2, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(3);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(2, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(4);
                    BeginTextCommandScaleformString("MPATM_BACK");
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                    if (PlayerCache.Character.Finance.Bank >= func_21(3, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(5);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(3, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Bank >= func_21(4, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(6);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(4, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Bank >= func_21(5, false))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(7);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(5, false), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    atm.CallFunction("DISPLAY_CASH_OPTIONS");
                    break;
                case 2: // deposit
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    AddText("MPATM_DITMT");
                    EndScaleformMovieMethod();
                    if (PlayerCache.Character.Finance.Money >= func_21(0, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(1);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(0, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Money >= func_21(1, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(2);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(1, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Money >= func_21(2, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(3);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(2, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(4);
                    BeginTextCommandScaleformString("MPATM_BACK");
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                    if (PlayerCache.Character.Finance.Money >= func_21(3, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(5);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(3, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Money >= func_21(4, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(6);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(4, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    if (PlayerCache.Character.Finance.Money >= func_21(5, true))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(7);
                        BeginTextCommandScaleformString("ESDOLLA");
                        AddTextComponentFormattedInteger(func_21(5, true), true);
                        EndTextCommandScaleformString();
                        EndScaleformMovieMethod();
                    }
                    atm.CallFunction("DISPLAY_CASH_OPTIONS");

                    break;
                case 3:
                    List<BankTransaction> transactions = await EventDispatcher.Get<List<BankTransaction>>("tlg:banking:requestTransactions");
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    AddText("MPATM_LOG");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(1);
                    AddText("MPATM_BACK");
                    EndScaleformMovieMethod();
                    int slot = 2;
                    foreach (BankTransaction trans in transactions.OrderByDescending(x => x.TransactionDate).Take(16))
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(slot);
                        ScaleformMovieMethodAddParamInt(trans.Paid ? 0 : 1);
                        ScaleformMovieMethodAddParamInt((int)trans.Amount);
                        if (string.IsNullOrWhiteSpace(trans.PlayerName))
                        {
                            BeginTextCommandScaleformString(trans.Label);
                            AddTextComponentSubstringPlayerName(trans.PlayerName);
                            EndTextCommandScaleformString();
                        }
                        else
                        {
                            if (trans.Label != "ADMIN_REGULATION")
                                AddText(trans.Label);
                            else
                            {
                                BeginTextCommandScaleformString("STRING");
                                AddTextComponentSubstringPlayerName("Admin transaction");
                                EndTextCommandScaleformString();
                            }
                        }
                        EndScaleformMovieMethod();
                        slot++;
                    }
                    //ATM_TIGGER.C func_29

                    atm.CallFunction("DISPLAY_TRANSACTIONS");
                    break;
                case 4:
                    break;
                case 5: // confirm withdraw
                case 6: // confirm deposit
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    BeginTextCommandScaleformString(menu == 5 ? "MPATC_CONFW" : "MPATM_CONF");
                    AddTextComponentFormattedInteger(cash, true);
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(1);
                    AddText("MO_YES");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(2);
                    AddText("MO_NO");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(atm.Handle, "DISPLAY_MESSAGE");
                    EndScaleformMovieMethod();
                    transactionMoney = cash;

                    break;
                case 7: // waiting
                    {
                        BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(0);
                        AddText("MPATM_PEND");
                        EndScaleformMovieMethod();
                        atm.CallFunction("DISPLAY_MESSAGE");
                        await BaseScript.Delay(SharedMath.GetRandomInt(2500, 4500));
                        KeyValuePair<bool, string> trans = await EventDispatcher.Get<KeyValuePair<bool, string>>("tlg:banking:" + @event, transactionMoney);
                        TryBankingNew(false, 13, 0, trans.Key ? "MPATM_TRANCOM" : "MPATM_ERR");
                        _actualMenu = 13;
                        _currentSelection = 0;
                    }
                    break;
                case 13: // display message
                    BeginScaleformMovieMethod(atm.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(0);
                    AddText(msg);
                    EndScaleformMovieMethod();
                    atm.CallFunction("DISPLAY_MESSAGE");
                    await BaseScript.Delay(2000);
                    TryBankingNew(false, 0);
                    _actualMenu = 0;
                    _currentSelection = 0;
                    break;
            }

            BeginScaleformMovieMethod(atm.Handle, "DISPLAY_BALANCE");
            PushScaleformMovieMethodParameterButtonName(PlayerCache.MyPlayer.Name);
            AddText("MPATM_ACBA");
            PushScaleformMovieMethodParameterButtonName(PlayerCache.MyClient.User.Bank.ToString());
            EndScaleformMovieMethod();

            //PlayerCache.Character.Finance.Transactions
        }

        static void AddText(string text)
        {
            BeginTextCommandScaleformString(text);
            EndTextCommandScaleformString();
        }

        /*
        static async void PerformAnimation()
        {
            string sVar0 = func_63(0);
            string sVar1 = func_63(1);
            string sVar2 = func_63(2);
            string sVar3 = func_63(3);
            int iVar4 = 3;
            int iVar5 = 0;
            int iVar6;

            RequestAnimDict(sVar3);
            while (!HasAnimDictLoaded(sVar3)) await BaseScript.Delay(0);

            Vector3 coords = PlayerCache.MyPed.Position;
            Vector3 rot = ClosestATM.Rotation;

            // ANIM 0

            RequestAnimDict(sVar0);
            while (!HasAnimDictLoaded(sVar0)) await BaseScript.Delay(0);
            if (IsSynchronizedSceneRunning(iLocal_505))
            {
                DetachSynchronizedScene(iLocal_505);
                iLocal_505 = -1;
            }
            iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, false, 1f, 0f, 1f);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar0, "enter", 4f, -2f, 5, 0, 1000f, 0);
            NetworkStartSynchronisedScene(iLocal_505);
            RemoveAnimDict(sVar0);
            currentAnimState = 1;

            // ANIM 1

            RequestAnimDict(sVar1);
            while (!HasAnimDictLoaded(sVar1)) await BaseScript.Delay(0);
            RequestAnimDict(sVar2);
            while (!HasAnimDictLoaded(sVar2)) await BaseScript.Delay(0);
            iVar5 = NetworkGetLocalSceneFromNetworkId(iLocal_505);
            while (GetSynchronizedScenePhase(iVar5) < 0.99f) await BaseScript.Delay(1);
            if (!IsSynchronizedSceneRunning(iLocal_505) || !IsSynchronizedSceneRunning(iVar5))
            {
                iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, true, 1f, 0f, 1f);
                NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar1, "base", 4f, -2f, 5, 0, 1000f, 0);
                NetworkStartSynchronisedScene(iLocal_505);
                currentAnimState = 2;
            }

            // ANIM 2

            RequestAnimDict(sVar1);
            while (!HasAnimDictLoaded(sVar1)) await BaseScript.Delay(0);
            RequestAnimDict(sVar2);
            while (!HasAnimDictLoaded(sVar2)) await BaseScript.Delay(0);
            iVar5 = NetworkGetLocalSceneFromNetworkId(iLocal_505);
            while (GetSynchronizedScenePhase(iVar5) < 0.99f) await BaseScript.Delay(1);
            if (!IsSynchronizedSceneRunning(iVar5) || IsSynchronizedSceneRunning(iVar5))
            {
                iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, true, 1f, 0f, 1f);
                iVar5 = NetworkGetLocalSceneFromNetworkId(iLocal_505);
                if (IsSynchronizedSceneRunning(iVar5))
                    SetSynchronizedScenePhase(iVar5, 0f);
                NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar1, "base", 4f, -2f, 5, 0, 1000f, 0);
                NetworkStartSynchronisedScene(iLocal_505);
            }
            while (GetSynchronizedScenePhase(iVar5) < 0.99f) await BaseScript.Delay(0);

            iVar6 = SharedMath.GetRandomInt(0, iVar4);
            string anim = "";
            anim = iVar6 switch
            {
                0 => "idle_a",
                1 => "idle_a",
                2 => "idle_a",
                3 => "idle_a",
                _ => "idle_XXX",
            };
            if (IsSynchronizedSceneRunning(iLocal_505))
            {
                DetachSynchronizedScene(iLocal_505);
                iLocal_505 = -1;
            }
            iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, true, 1f, 0f, 1f);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar2, anim, 4f, -2f, 5, 0, 1000f, 0);
            currentAnimState = 3;

            // ANIM 3

            iVar5 = NetworkGetLocalSceneFromNetworkId(iLocal_505);
            if (IsSynchronizedSceneRunning(iLocal_505) && !IsSynchronizedSceneRunning(iVar5))
            {
                if (IsSynchronizedSceneRunning(iLocal_505))
                {
                    DetachSynchronizedScene(iLocal_505);
                    iLocal_505 = -1;
                }
                iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, true, 1f, 0f, 1f);
                iVar5 = NetworkGetLocalSceneFromNetworkId(iLocal_505);
                if (IsSynchronizedSceneRunning(iVar5))
                {
                    SetSynchronizedScenePhase(iVar5, 0f);
                }
                NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar1, "base", 4f, -2f, 5, 0, 1000f, 0);
                NetworkStartSynchronisedScene(iLocal_505);
                currentAnimState = 2;
            }
            while (!IsSynchronizedSceneRunning(iVar5) || GetSynchronizedScenePhase(iVar5) < 0.99f) await BaseScript.Delay(0);

            if (IsSynchronizedSceneRunning(iLocal_505))
            {
                DetachSynchronizedScene(iLocal_505);
                iLocal_505 = -1;
            }
            iLocal_505 = NetworkCreateSynchronisedScene(coords.X, coords.Y, coords.Z, rot.X, rot.Y, rot.Z, 2, false, true, 1f, 0f, 1f);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPed.Handle, iLocal_505, sVar1, "base", 4f, -2f, 5, 0, 1000f, 0);
            NetworkStartSynchronisedScene(iLocal_505);
            currentAnimState = 2;

        }
        */
        static string func_63(int iParam0)//Position - 0x4B59
        {
            string sParam1 = "";

            if (PlayerCache.Character.Skin.Sex == "Male")
            {
                switch (iParam0)
                {
                    case 0:
                        sParam1 = "anim@amb@prop_human_atm@interior@male@enter";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "mini@atmenter";
                        }
                        break;

                    case 1:
                        sParam1 = "anim@amb@prop_human_atm@interior@male@base";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "mini@atmbase";
                        }
                        break;

                    case 2:
                        sParam1 = "anim@amb@prop_human_atm@interior@male@idle_a";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "anim@amb@prop_human_atm@interior@male@idle_a";
                        }
                        break;

                    case 3:
                        sParam1 = "anim@amb@prop_human_atm@interior@male@exit";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "mini@atmexit";
                        }
                        break;
                }
            }
            else
            {
                switch (iParam0)
                {
                    case 0:
                        sParam1 = "anim@amb@prop_human_atm@interior@female@enter";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "anim@amb@prop_human_atm@interior@female@enter";
                        }
                        break;

                    case 1:
                        sParam1 = "anim@amb@prop_human_atm@interior@female@base";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "anim@amb@prop_human_atm@interior@female@base";
                        }
                        break;

                    case 2:
                        sParam1 = "anim@amb@prop_human_atm@interior@female@idle_a";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "anim@amb@prop_human_atm@interior@female@idle_a";
                        }
                        break;

                    case 3:
                        sParam1 = "anim@amb@prop_human_atm@interior@female@exit";
                        if (!DoesAnimDictExist(sParam1))
                        {
                            sParam1 = "mini@atmexit";
                        }
                        break;
                }
            }
            return sParam1;
        }

        static int func_21(int slot, bool isWallet)//Position - 0x23E6
        {
            int iVar0;
            if (isWallet)
            {
                iVar0 = PlayerCache.Character.Finance.Money;
            }
            else
            {
                iVar0 = PlayerCache.Character.Finance.Bank;
            }
            if (iVar0 == 0)
            {
                return 1;
            }
            return slot switch
            {
                0 => 50 > iVar0 ? iVar0 : 50,
                1 => 500 > iVar0 && iVar0 > 50 ? iVar0 : 500,
                2 => 2500 > iVar0 && iVar0 > 500 ? iVar0 : 2500,
                3 => 10000 > iVar0 && iVar0 > 2500 ? iVar0 : 10000,
                4 => 100000 > iVar0 && iVar0 > 10000 ? iVar0 : 100000,
                5 => 10000000 > iVar0 && iVar0 > 100000 ? iVar0 : 10000000,
                _ => 0,
            };
        }
    }
}