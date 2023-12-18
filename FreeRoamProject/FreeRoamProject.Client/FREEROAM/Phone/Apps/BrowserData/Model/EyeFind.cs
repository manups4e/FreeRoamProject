using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal class EyeFind
    {
        internal static void SetupWebBrowserHeader(Apps.WebBrowser parent, int currentPageId)
        {
            int uVar3 = 160;
            int clockDayOfWeek = GetClockDayOfWeek();
            Weather weather = World.Weather;

            int weatherId;

            switch (currentPageId)
            {
                case 1:
                case 4:
                case 5:
                    weatherId = weather switch
                    {
                        Weather.Clearing or Weather.Clear or Weather.Neutral => 1,
                        Weather.Clouds => 2,
                        Weather.Overcast or Weather.Smog or Weather.Foggy => 3,
                        Weather.Raining => 2,
                        Weather.ThunderStorm => 6,
                        Weather.Snowing => 7,
                        _ => 0,
                    };
                    parent.browser.CallFunction("SET_DATA_SLOT", 0, weatherId);
                    Vector3 playerPosition = Game.PlayerPed.Position;
                    string zone = GetNameOfZone(playerPosition.X, playerPosition.Y, playerPosition.Z);
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(2);
                    Tools.SetScaleformString(zone);
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(3);
                    switch (clockDayOfWeek)
                    {
                        case 0:
                            Tools.SetScaleformString("BS_PH_SU");
                            break;
                        case 1:
                            Tools.SetScaleformString("BS_PH_M");
                            break;
                        case 2:
                            Tools.SetScaleformString("BS_PH_TU");
                            break;
                        case 3:
                            Tools.SetScaleformString("BS_PH_W");
                            break;
                        case 4:
                            Tools.SetScaleformString("BS_PH_TH");
                            break;
                        case 5:
                            Tools.SetScaleformString("BS_PH_F");
                            break;
                        case 6:
                            Tools.SetScaleformString("BS_PH_SA");
                            break;
                    }
                    EndScaleformMovieMethod();

                    bool bVar11 = true;
                    string f_1 = "";
                    string f_9 = "";
                    int Local_254 = 0;

                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(4);
                    Tools.SetScaleformString(f_1);
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(5);
                    ScaleformMovieMethodAddParamInt(Local_254);
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(6);
                    Tools.SetScaleformString(f_9);
                    EndScaleformMovieMethod();

                    func_7486(ref f_1, ref f_9, ref Local_254);
                    int rand = GetRandomIntInRange(0, 477);
                    string Var0 = "BLE_" + rand;
                    string Var1 = "BLE_" + (rand + 1);

                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(7);
                    Tools.SetScaleformString(Var0);
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(8);
                    Tools.SetScaleformString(Var1);
                    EndScaleformMovieMethod();


                    if (Tunables.Global_262145.Value<int>("f_8318") == 1)
                    {
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(9);
                        func_7483(10, Tunables.Global_262145.Value<int>("f_9084") /* Tunable: LEGENDARY_DISPLAYED_DISCOUNT */);
                        func_7483(11, Tunables.Global_262145.Value<int>("f_9085") /* Tunable: ELITAS_DISPLAYED_DISCOUNT */);
                        func_7483(16, Tunables.Global_262145.Value<int>("f_9086") /* Tunable: SSASA_DISPLAYED_DISCOUNT */);
                        EndScaleformMovieMethod();
                    }
                    else
                    {

                        // Setup homepage
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(9);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23027") /* Tunable: -1765854872 */);
                        Tools.SetScaleformString("EYEDISC_SA");
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23028") /* Tunable: -2028629483 */);
                        Tools.SetScaleformString("EYEDISC_SA");
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23029") /* Tunable: 1985868434 */);
                        Tools.SetScaleformString("EYEDISC_SA");
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23030") /* Tunable: 771871949 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23031") /* Tunable: 1942216784 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23032") /* Tunable: 311827958 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23033") /* Tunable: 1519594991 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23034") /* Tunable: 1750649210 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23035") /* Tunable: -1398975998 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23036") /* Tunable: 1264291712 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23037") /* Tunable: -1834344932 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23038") /* Tunable: -1570456175 */);
                        ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_23039") /* Tunable: -398014124 */);
                        EndScaleformMovieMethod();
                    }
                    break;
                default:
                    break;
            }
            parent.UpdateText();
        }
        static void func_7483(int iParam0, float fParam1)//Position - 0x27DCBE
        {
            func_7484(iParam0, false);
            if (fParam1 == 0f)
            {
                Tools.SetScaleformString("EYEDISC_00" /* GXT: Discounts available on Selected Vehicles */);
            }
            else if (fParam1 == 5f)
            {
                Tools.SetScaleformString("EYEDISC_05" /* GXT: 5% Off Selected Vehicles */);
            }
            else if (fParam1 == 10f)
            {
                Tools.SetScaleformString("EYEDISC_10" /* GXT: 10% Off Selected Vehicles */);
            }
            else if (fParam1 == 15f)
            {
                Tools.SetScaleformString("EYEDISC_15" /* GXT: 15% Off Selected Vehicles */);
            }
            else if (fParam1 == 20f)
            {
                Tools.SetScaleformString("EYEDISC_20" /* GXT: 20% Off Selected Vehicles */);
            }
            else if (fParam1 == 25f)
            {
                Tools.SetScaleformString("EYEDISC_25" /* GXT: 25% Off Selected Vehicles */);
            }
            else
            {
                Tools.SetScaleformString("EYEDISC" /* GXT: ~1~% Off Selected Vehicles */);
                ScaleformMovieMethodAddParamInt(Ceil(fParam1));
            }
        }

        static void func_7484(int iParam0, bool bParam1)//Position - 0x27DD62
        {
            switch (iParam0)
            {
                case 13:
                    ScaleformMovieMethodAddParamInt(0);
                    break;

                case 18:
                    ScaleformMovieMethodAddParamInt(1);
                    break;

                case 11:
                    if (!bParam1)
                    {
                        ScaleformMovieMethodAddParamInt(2);
                    }
                    else
                    {
                        ScaleformMovieMethodAddParamInt(10);
                    }
                    break;

                case 10:
                    ScaleformMovieMethodAddParamInt(3);
                    break;

                case 26:
                    ScaleformMovieMethodAddParamInt(4);
                    break;

                case 15:
                    ScaleformMovieMethodAddParamInt(5);
                    break;

                case 16:
                    ScaleformMovieMethodAddParamInt(6);
                    break;

                case 12:
                    if (!bParam1)
                    {
                        ScaleformMovieMethodAddParamInt(7);
                    }
                    else
                    {
                        ScaleformMovieMethodAddParamInt(11);
                    }
                    break;

                case 27:
                    ScaleformMovieMethodAddParamInt(8);
                    break;

                case 28:
                    ScaleformMovieMethodAddParamInt(9);
                    break;

                case 29:
                    ScaleformMovieMethodAddParamInt(13);
                    break;

                case 30:
                    ScaleformMovieMethodAddParamInt(14);
                    break;

                default:
                    break;
            }
        }
        static int func_7486(ref string sParam0, ref string sParam1, ref int uParam2)//Position - 0x27DE7B
        {
            int iVar0;
            int iVar1;
            int iVar2;
            int iVar3;

            iVar0 = API.GetRandomIntInRange(0, 54);
            iVar1 = 1;
            if (iVar0 == 0)
            {
                iVar1 = 1;
                iVar2 = 6;
                sParam0 = "NWS_PRO_HL";
                sParam1 = "NWS_PRO_S";
            }
            else if (iVar0 == 1)
            {
                iVar1 = 1;
                iVar2 = 5;
                sParam0 = "NWS_AR2_HL";
                sParam1 = "NWS_AR2_S";
            }
            else if (iVar0 == 2)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_AR3_HL";
                sParam1 = "NWS_AR3_S";
            }
            else if (iVar0 == 3)
            {
                iVar1 = 1;
                iVar2 = 5;
                sParam0 = "NWS_FAM1_HL";
                sParam1 = "NWS_FAM1_S";
            }
            else if (iVar0 == 4)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_FAM3_HL";
                sParam1 = "NWS_FAM3_S";
            }
            else if (iVar0 == 5)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_LAM1_HL";
                sParam1 = "NWS_LAM1_S";
            }
            else if (iVar0 == 6)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_LST1_HL";
                sParam1 = "NWS_LST1_S";
            }
            else if (iVar0 == 7)
            {
                iVar1 = API.GetRandomIntInRange(1, 6);
                iVar2 = API.GetRandomIntInRange(1, 6);
                sParam0 = "NWS_JWLH_HL";
                sParam1 = "NWS_JWLH_S";
            }
            else if (iVar0 == 8)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_TRE2_HL";
                sParam1 = "NWS_TRE2_S";
            }
            else if (iVar0 == 9)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_CHI1_HL";
                sParam1 = "NWS_CHI1_S";
            }
            else if (iVar0 == 10)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_CHI2_HL";
                sParam1 = "NWS_CHI2_S";
            }
            else if (iVar0 == 11)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_TRE3_HL";
                sParam1 = "NWS_TRE3_S";
            }
            else if (iVar0 == 12)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_FAM4_HL";
                sParam1 = "NWS_FAM4_S";
            }
            else if (iVar0 == 13)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_FIB2_HL";
                sParam1 = "NWS_FIB2_S";
            }
            else if (iVar0 == 14)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_FIB3_HL";
                sParam1 = "NWS_FIB3_S";
            }
            else if (iVar0 == 15)
            {
                iVar1 = API.GetRandomIntInRange(1, 3);
                iVar2 = API.GetRandomIntInRange(1, 3);
                sParam0 = "NWS_FRA1_HL";
                sParam1 = "NWS_FRA1_S";
            }
            else if (iVar0 == 16)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_FIB4_HL";
                sParam1 = "NWS_FIB4_S";
            }
            else if (iVar0 == 17)
            {
                iVar1 = 1;
                iVar2 = 4;
                sParam0 = "NWS_DCKH_HL";
                sParam1 = "NWS_DCKH_S";
            }
            else if (iVar0 == 18)
            {
                iVar1 = API.GetRandomIntInRange(1, 8);
                iVar2 = API.GetRandomIntInRange(1, 8);
                sParam0 = "NWS_CARS2_HL";
                sParam1 = "NWS_CARS2_S";
            }
            else if (iVar0 == 19)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_SOL1_HL";
                sParam1 = "NWS_SOL1_S";
            }
            else if (iVar0 == 20)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_MTN1_HL";
                sParam1 = "NWS_MTN1_S";
            }
            else if (iVar0 == 21)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_CARS3_HL";
                sParam1 = "NWS_CARS3_S";
            }
            else if (iVar0 == 22)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_EXL1_HL";
                sParam1 = "NWS_EXL1_S";
            }
            else if (iVar0 == 23)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_RBH_HL";
                sParam1 = "NWS_RBH_S";
            }
            else if (iVar0 == 24)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_EXL3_HL";
                sParam1 = "NWS_EXL3_S";
            }
            else if (iVar0 == 25)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_FIB5_HL";
                sParam1 = "NWS_FIB5_S";
            }
            else if (iVar0 == 26)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_MIC1_HL";
                sParam1 = "NWS_MIC1_S";
            }
            else if (iVar0 == 27)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_SOL2_HL";
                sParam1 = "NWS_SOL2_S";
            }
            else if (iVar0 == 28)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_FAM6_HL";
                sParam1 = "NWS_FAM6_S";
            }
            else if (iVar0 == 29)
            {
                iVar1 = API.GetRandomIntInRange(1, 6);
                iVar2 = API.GetRandomIntInRange(1, 6);
                sParam0 = "NWS_AGH_HL";
                sParam1 = "NWS_AGH_S";
            }
            else if (iVar0 == 30)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_MIC3_HL";
                sParam1 = "NWS_MIC3_S";
            }
            else if (iVar0 == 31)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_SOL3_HL";
                sParam1 = "NWS_SOL3_S";
            }
            else if (iVar0 == 32)
            {
                iVar1 = 1;
                iVar2 = 3;
                sParam0 = "NWS_MIC4_HL";
                sParam1 = "NWS_MIC4_S";
            }
            else if (iVar0 == 33)
            {
                iVar1 = API.GetRandomIntInRange(1, 6);
                iVar2 = API.GetRandomIntInRange(1, 6);
                sParam0 = "NWS_BSH_HL";
                sParam1 = "NWS_BSH_S";
            }
            else if (iVar0 == 34)
            {
                iVar1 = 1;
                iVar2 = 5;
                sParam0 = "NWS_FIN_HL";
                sParam1 = "NWS_FIN_S";
            }
            else if (iVar0 == 35)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_PAP1_HL";
                sParam1 = "NWS_PAP1_S";
            }
            else if (iVar0 == 36)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_PAP3A_HL";
                sParam1 = "NWS_PAP3A_S";
            }
            else if (iVar0 == 37)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_PAP3B_HL";
                sParam1 = "NWS_PAP3B_S";
            }
            else if (iVar0 == 38)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_DRF1_HL";
                sParam1 = "NWS_DRF1_S";
            }
            else if (iVar0 == 39)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_EPN8_HL";
                sParam1 = "NWS_EPN8_S";
            }
            else if (iVar0 == 40)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_NIG1A_HL";
                sParam1 = "NWS_NIG1A_S";
            }
            else if (iVar0 == 41)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_NIG1B_HL";
                sParam1 = "NWS_NIG1B_S";
            }
            else if (iVar0 == 42)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_NIG1C_HL";
                sParam1 = "NWS_NIG1C_S";
            }
            else if (iVar0 == 43)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_NIG1D_HL";
                sParam1 = "NWS_NIG1D_S";
            }
            else if (iVar0 == 44)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_NIG2_HL";
                sParam1 = "NWS_NIG2_S";
            }
            else if (iVar0 == 45)
            {
                iVar1 = API.GetRandomIntInRange(1, 4);
                iVar2 = API.GetRandomIntInRange(1, 4);
                sParam0 = "NWS_NIG3_HL";
                sParam1 = "NWS_NIG3_S";
            }
            else if (iVar0 == 46)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_EXT4_HL";
                sParam1 = "NWS_EXT4_S";
            }
            else if (iVar0 == 47)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_ASS1_HL";
                sParam1 = "NWS_ASS1_S";
            }
            else if (iVar0 == 48)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_ASS2_HL";
                sParam1 = "NWS_ASS2_S";
            }
            else if (iVar0 == 49)
            {
                iVar1 = 1;
                iVar2 = 1;
                sParam0 = "NWS_ASS3_HL";
                sParam1 = "NWS_ASS3_S";
            }
            else if (iVar0 == 50)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_ASS4_HL";
                sParam1 = "NWS_ASS4_S";
            }
            else if (iVar0 == 51)
            {
                iVar1 = 1;
                iVar2 = 2;
                sParam0 = "NWS_ASS5_HL";
                sParam1 = "NWS_ASS5_S";
            }
            else if (iVar0 == 52)
            {
                iVar1 = 1;
                iVar2 = 1;
                sParam0 = "NWS_O_ATA_HL";
                sParam1 = "NWS_O_ATA_S";
            }
            else if (iVar0 == 53)
            {
                iVar1 = API.GetRandomIntInRange(1, 2);
                iVar2 = API.GetRandomIntInRange(1, 2);
                sParam0 = "NWS_SHK5_HL";
                sParam1 = "NWS_SHK5_S";
            }
            else if (iVar0 == 54)
            {
                iVar1 = 1;
                iVar2 = 1;
                sParam0 = "NWS_CULT_HL";
                sParam1 = "NWS_CULT_S";
            }
            else
            {
                iVar1 = 1;
                iVar2 = 6;
                sParam0 = "NWS_PRO_HL";
                sParam1 = "NWS_PRO_S";
            }
            if (iVar0 != 55)
            {
                iVar3 = API.GetRandomIntInRange(iVar1, iVar2 + 1);
                sParam0 += iVar3;
                sParam1 += iVar3;
                uParam2 = func_7487(iVar0, iVar3);
                return 1;
            }
            return 0;
        }
        static int func_7487(int iParam0, int iParam1)//Position - 0x27E74A
        {
            switch (iParam0)
            {
                case 0:
                    switch (iParam1)
                    {
                        case 1:
                            return 0;
                        case 2:
                            return 3;
                        case 3:
                            return 12;
                        case 4:
                            return 1;
                        case 5:
                            return 2;
                        case 6:
                            return 13;
                    }
                    break;
                case 1:
                    switch (iParam1)
                    {
                        case 1:
                        case 2:
                            return 3;
                        case 3:
                            return 12;
                        case 4:
                        case 5:
                            return 0;
                    }
                    break;
                case 2:
                    if (iParam1 == 1)
                    {
                        return 4;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 1;
                    }
                    else if (iParam1 == 4)
                    {
                        return 7;
                    }
                    break;
                case 3:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    else if (iParam1 == 3)
                    {
                        return 3;
                    }
                    else if (iParam1 == 4)
                    {
                        return 1;
                    }
                    else if (iParam1 == 5)
                    {
                        return 5;
                    }
                    break;
                case 4:
                    if (iParam1 == 1)
                    {
                        return 1;
                    }
                    else if (iParam1 == 2)
                    {
                        return 3;
                    }
                    else if (iParam1 == 3)
                    {
                        return 12;
                    }
                    else if (iParam1 == 4)
                    {
                        return 0;
                    }
                    break;
                case 5:
                    if (iParam1 == 1)
                    {
                        return 4;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 9;
                    }
                    else if (iParam1 == 4)
                    {
                        return 7;
                    }
                    break;
                case 6:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 2;
                    }
                    else if (iParam1 == 3)
                    {
                        return 13;
                    }
                    else if (iParam1 == 4)
                    {
                        return 12;
                    }
                    break;
                case 7:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 10;
                    }
                    else if (iParam1 == 3)
                    {
                        return 3;
                    }
                    else if (iParam1 == 4)
                    {
                        return 3;
                    }
                    else if (iParam1 == 5)
                    {
                        return 10;
                    }
                    else if (iParam1 == 6)
                    {
                        return 3;
                    }
                    break;
                case 8:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    else if (iParam1 == 4)
                    {
                        return 3;
                    }
                    break;
                case 9:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 4;
                    }
                    else if (iParam1 == 4)
                    {
                        return 3;
                    }
                    break;
                case 10:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 13;
                    }
                    else if (iParam1 == 4)
                    {
                        return 8;
                    }
                    break;
                case 11:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    else if (iParam1 == 2)
                    {
                        return 1;
                    }
                    else if (iParam1 == 3)
                    {
                        return 3;
                    }
                    break;
                case 12:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    else if (iParam1 == 3)
                    {
                        return 7;
                    }
                    else if (iParam1 == 4)
                    {
                        return 13;
                    }
                    break;
                case 13:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    else if (iParam1 == 4)
                    {
                        return 12;
                    }
                    break;
                case 14:
                    if (iParam1 == 1)
                    {
                        return 4;
                    }
                    else if (iParam1 == 2)
                    {
                        return 8;
                    }
                    else if (iParam1 == 3)
                    {
                        return 1;
                    }
                    else if (iParam1 == 4)
                    {
                        return 12;
                    }
                    break;
                case 15:
                    if (iParam1 == 1)
                    {
                        return 4;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    else if (iParam1 == 3)
                    {
                        return 5;
                    }
                    else if (iParam1 == 4)
                    {
                        return 0;
                    }
                    else if (iParam1 == 5)
                    {
                        return 5;
                    }
                    break;
                case 16:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 12;
                    }
                    else if (iParam1 == 4)
                    {
                        return 3;
                    }
                    break;
                case 17:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 1;
                    }
                    else if (iParam1 == 3)
                    {
                        return 9;
                    }
                    else if (iParam1 == 4)
                    {
                        return 12;
                    }
                    break;
                case 18:
                    if (iParam1 == 1)
                    {
                        return 10;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    else if (iParam1 == 3)
                    {
                        return 9;
                    }
                    else if (iParam1 == 4)
                    {
                        return 1;
                    }
                    else if (iParam1 == 5)
                    {
                        return 10;
                    }
                    else if (iParam1 == 6)
                    {
                        return 0;
                    }
                    else if (iParam1 == 7)
                    {
                        return 9;
                    }
                    else if (iParam1 == 8)
                    {
                        return 1;
                    }
                    break;
                case 19:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 5;
                    }
                    break;
                case 20:
                    if (iParam1 == 1)
                    {
                        return 1;
                    }
                    else if (iParam1 == 2)
                    {
                        return 5;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    break;
                case 21:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    else if (iParam1 == 3)
                    {
                        return 13;
                    }
                    break;
                case 22:
                    if (iParam1 == 1)
                    {
                        return 7;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    break;
                case 23:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 11;
                    }
                    break;
                case 24:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    break;
                case 25:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 1;
                    }
                    break;
                case 26:
                    if (iParam1 == 1)
                    {
                        return 6;
                    }
                    else if (iParam1 == 2)
                    {
                        return 7;
                    }
                    else if (iParam1 == 3)
                    {
                        return 0;
                    }
                    break;
                case 27:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 3;
                    }
                    break;
                case 28:
                    if (iParam1 == 1)
                    {
                        return 10;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    break;
                case 29:
                    if (iParam1 == 1)
                    {
                        return 13;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    else if (iParam1 == 3)
                    {
                        return 2;
                    }
                    else if (iParam1 == 4)
                    {
                        return 13;
                    }
                    else if (iParam1 == 5)
                    {
                        return 11;
                    }
                    else if (iParam1 == 6)
                    {
                        return 2;
                    }
                    break;
                case 30:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    break;
                case 31:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 8;
                    }
                    else if (iParam1 == 3)
                    {
                        return 7;
                    }
                    break;
                case 32:
                    if (iParam1 == 1)
                    {
                        return 5;
                    }
                    else if (iParam1 == 2)
                    {
                        return 1;
                    }
                    else if (iParam1 == 3)
                    {
                        return 2;
                    }
                    break;
                case 33:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    else if (iParam1 == 3)
                    {
                        return 13;
                    }
                    else if (iParam1 == 4)
                    {
                        return 12;
                    }
                    else if (iParam1 == 5)
                    {
                        return 12;
                    }
                    else if (iParam1 == 6)
                    {
                        return 13;
                    }
                    break;
                case 34:
                    if (iParam1 == 1)
                    {
                        return 4;
                    }
                    else if (iParam1 == 2)
                    {
                        return 1;
                    }
                    else if (iParam1 == 3)
                    {
                        return 3;
                    }
                    else if (iParam1 == 4)
                    {
                        return 2;
                    }
                    else if (iParam1 == 5)
                    {
                        return 12;
                    }
                    break;
                case 35:
                    if (iParam1 == 1)
                    {
                        return 10;
                    }
                    else if (iParam1 == 2)
                    {
                        return 3;
                    }
                    break;
                case 36:
                    if (iParam1 == 1)
                    {
                        return 8;
                    }
                    else if (iParam1 == 2)
                    {
                        return 13;
                    }
                    break;
                case 37:
                    if (iParam1 == 1)
                    {
                        return 13;
                    }
                    else if (iParam1 == 2)
                    {
                        return 5;
                    }
                    break;
                case 38:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    break;
                case 39:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 5;
                    }
                    break;
                case 40:
                    if (iParam1 == 1)
                    {
                        return 10;
                    }
                    else if (iParam1 == 2)
                    {
                        return 11;
                    }
                    break;
                case 41:
                    if (iParam1 == 1)
                    {
                        return 8;
                    }
                    else if (iParam1 == 2)
                    {
                        return 2;
                    }
                    break;
                case 42:
                    if (iParam1 == 1)
                    {
                        return 10;
                    }
                    else if (iParam1 == 2)
                    {
                        return 8;
                    }
                    break;
                case 43:
                    if (iParam1 == 1)
                    {
                        return 8;
                    }
                    else if (iParam1 == 2)
                    {
                        return 2;
                    }
                    break;
                case 44:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    break;
                case 45:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 1;
                    }
                    else if (iParam1 == 3)
                    {
                        return 3;
                    }
                    else if (iParam1 == 4)
                    {
                        return 1;
                    }
                    break;
                case 46:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 12;
                    }
                    break;
                case 47:
                    if (iParam1 == 1)
                    {
                        return 7;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    break;
                case 48:
                    if (iParam1 == 1)
                    {
                        return 7;
                    }
                    else if (iParam1 == 2)
                    {
                        return 0;
                    }
                    break;
                case 49:
                    if (iParam1 == 1)
                    {
                        return 2;
                    }
                    break;
                case 50:
                    if (iParam1 == 1)
                    {
                        return 12;
                    }
                    else if (iParam1 == 2)
                    {
                        return 3;
                    }
                    break;
                case 51:
                    if (iParam1 == 1)
                    {
                        return 13;
                    }
                    else if (iParam1 == 2)
                    {
                        return 4;
                    }
                    break;
                case 52:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    break;
                case 53:
                    if (iParam1 == 1)
                    {
                        return 3;
                    }
                    else if (iParam1 == 2)
                    {
                        return 13;
                    }
                    break;
                case 54:
                    if (iParam1 == 1)
                    {
                        return 9;
                    }
                    break;
                default:
                    if (iParam1 == 1)
                    {
                        return 0;
                    }
                    else if (iParam1 == 2)
                    {
                        return 3;
                    }
                    else if (iParam1 == 3)
                    {
                        return 12;
                    }
                    else if (iParam1 == 4)
                    {
                        return 1;
                    }
                    else if (iParam1 == 5)
                    {
                        return 2;
                    }
                    else if (iParam1 == 6)
                    {
                        return 13;
                    }

                    break;
            }
            return 0;
        }
    }
}
