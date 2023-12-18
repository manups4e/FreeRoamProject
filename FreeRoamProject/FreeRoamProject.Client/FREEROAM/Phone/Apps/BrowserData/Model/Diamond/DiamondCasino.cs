namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Diamond
{
    public class DiamondCasino
    {
        public int PenthouseCost = 0;
        public int[] PenthouseColorCost = [0, 0, 0];
        public int[] PenthousePatternCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int PenthouseLoungeCost = 0;
        public int PenthouseBarCost = 0;
        public int PenthouseDealerCost = 0;
        public int PenthouseSPACost = 0;
        public int PenthouseOfficeCost = 0;
        public int PenthouseGarageCost = 0;
        public int PenthouseBedroomCost = 0;
        public int PenthouseMediaCost = 0;
        public int MembershipCost = 0;

        public int PenthouseSaleCost = -1;
        public int[] PenthouseColorSaleCost = [-1, -1, -1];
        public int[] PenthousePatternSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int PenthouseLoungeSaleCost = -1;
        public int PenthouseBarSaleCost = -1;
        public int PenthouseDealerSaleCost = -1;
        public int PenthouseSPASaleCost = -1;
        public int PenthouseOfficeSaleCost = -1;
        public int PenthouseGarageSaleCost = -1;
        public int PenthouseBedroomSaleCost = -1;
        public int PenthouseMediaSaleCost = -1;
        public int MembershipSaleCost = -1;

        public DiamondCasino()
        {
            PenthouseCost = GetPenthousePrice(1);
            PenthouseColorCost = [
                GetPenthouseComponentPrice(0, 0),
                GetPenthouseComponentPrice(0, 1),
                GetPenthouseComponentPrice(0, 2)
            ];
            for (int i = 0; i < 9; i++)
            {
                PenthousePatternCost[i] = GetPenthouseComponentPrice(1, i);
            }
            PenthouseLoungeCost = GetPenthouseComponentPrice(2, 1);
            PenthouseBarCost = GetPenthouseComponentPrice(3, 1);
            PenthouseDealerCost = GetPenthouseComponentPrice(4, 1);
            PenthouseBedroomCost = GetPenthouseComponentPrice(5, 1);
            PenthouseMediaCost = GetPenthouseComponentPrice(6, 1);
            PenthouseSPACost = GetPenthouseComponentPrice(7, 1);
            PenthouseOfficeCost = GetPenthouseComponentPrice(8, 1);
            PenthouseGarageCost = GetPenthouseComponentPrice(9, 1);
            MembershipCost = 500;
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(11);
            ScaleformMovieMethodAddParamInt(PenthouseCost);
            ScaleformMovieMethodAddParamInt(PenthouseColorCost[0]);
            ScaleformMovieMethodAddParamInt(PenthouseColorCost[1]);
            ScaleformMovieMethodAddParamInt(PenthouseColorCost[2]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[0]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[1]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[2]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[3]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[4]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[5]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[6]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[7]);
            ScaleformMovieMethodAddParamInt(PenthousePatternCost[8]);
            ScaleformMovieMethodAddParamInt(PenthouseLoungeCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(11);
            ScaleformMovieMethodAddParamInt(PenthouseBarCost);
            ScaleformMovieMethodAddParamInt(PenthouseBarCost);
            ScaleformMovieMethodAddParamInt(PenthouseDealerCost);
            ScaleformMovieMethodAddParamInt(PenthouseBedroomCost);
            ScaleformMovieMethodAddParamInt(PenthouseMediaCost);
            ScaleformMovieMethodAddParamInt(PenthouseSPACost);
            ScaleformMovieMethodAddParamInt(PenthouseOfficeCost);
            ScaleformMovieMethodAddParamInt(PenthouseGarageCost);
            ScaleformMovieMethodAddParamInt(MembershipCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(12);
            ScaleformMovieMethodAddParamInt(PenthouseSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseColorSaleCost[0]);
            ScaleformMovieMethodAddParamInt(PenthouseColorSaleCost[1]);
            ScaleformMovieMethodAddParamInt(PenthouseColorSaleCost[2]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[0]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[1]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[2]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[3]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[4]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[5]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[6]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[7]);
            ScaleformMovieMethodAddParamInt(PenthousePatternSaleCost[8]);
            ScaleformMovieMethodAddParamInt(PenthouseLoungeSaleCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(12);
            ScaleformMovieMethodAddParamInt(PenthouseBarSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseBarSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseDealerSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseBedroomSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseMediaSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseSPASaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseOfficeSaleCost);
            ScaleformMovieMethodAddParamInt(PenthouseGarageSaleCost);
            ScaleformMovieMethodAddParamInt(MembershipSaleCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(13);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27182") /* Tunable: -188646595 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27183") /* Tunable: -2144399258 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27184") /* Tunable: 970583025 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27185") /* Tunable: -1755899894 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27186") /* Tunable: -779002937 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27187") /* Tunable: 1346569387 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27188") /* Tunable: 944569179 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27189") /* Tunable: -514752336 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27190") /* Tunable: -1529100936 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27191") /* Tunable: -1609882455 */);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(14);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27192") /* Tunable: 407681327 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27193") /* Tunable: 696962348 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27194") /* Tunable: 639478442 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27195") /* Tunable: 302646266 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27196") /* Tunable: 1288000813 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27197") /* Tunable: -581674034 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27198") /* Tunable: -1040437168 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27199") /* Tunable: -1725358036 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27200") /* Tunable: 533022276 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27201") /* Tunable: 1147565154 */);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(15);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27202") /* Tunable: -762194162 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27203") /* Tunable: 170439050 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27204") /* Tunable: 2016568071 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27205") /* Tunable: 1400843135 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27206") /* Tunable: 915743260 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27207") /* Tunable: 1112202860 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27208") /* Tunable: 44760023 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27209") /* Tunable: -1883210123 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27210") /* Tunable: -680727856 */);
            ScaleformMovieMethodAddParamInt(Tunables.Global_262145.Value<int>("f_27211") /* Tunable: -1655490432 */);
            EndScaleformMovieMethod();
        }
        int GetPenthousePrice(int iParam0)//Position - 0x1DD23E
        {
            string sVar0 = "";
            int PenthousePatternCost;
            int iVar17;

            sVar0 = $"MP_CASINO_1_t0_v0";
            PenthousePatternCost = GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)PenthousePatternCost))
            {
                iVar17 = NetGameserverGetPrice((uint)PenthousePatternCost, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_27052") /* Tunable: VC_PENTHOUSE_PROPERTY_BASE_PRICE */,
                _ => 0,
            };
        }
        int GetPenthouseComponentPrice(int iParam0, int iParam1)//Position - 0x1D22E2
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            iVar0 = 0;
            if (iParam0 == 3 || iParam0 == 4)
            {
                if (func_67(func_5447(iParam0), -1) != 0)
                {
                    iVar0 = 1;
                }
            }
            func_5450(ref sVar1, iParam0, iParam1, iVar0);
            iVar17 = GetHashKey(sVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = NetGameserverGetPrice((uint)iVar17, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar18;
            }

            switch (iParam0)
            {
                case 0:
                    switch (iParam1)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_27053") /* Tunable: VC_PENTHOUSE_PROPERTY_COLOR_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_27054") /* Tunable: VC_PENTHOUSE_PROPERTY_COLOR_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_27055") /* Tunable: VC_PENTHOUSE_PROPERTY_COLOR_3 */;
                    }
                    break;

                case 1:
                    switch (iParam1)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_27056") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_27057") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_27058") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_3 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_27059") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_4 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_27060") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_5 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_27061") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_6 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_27062") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_7 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_27063") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_8 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_27064") /* Tunable: VC_PENTHOUSE_PROPERTY_PATTERN_9 */;
                    }
                    break;

                case 2:
                    return Tunables.Global_262145.Value<int>("f_27067") /* Tunable: VC_PENTHOUSE_PROPERTY_LOUNGE */;
                case 3:
                    return Tunables.Global_262145.Value<int>("f_27069") /* Tunable: VC_PENTHOUSE_PROPERTY_BAR */;
                case 4:
                    return Tunables.Global_262145.Value<int>("f_27071") /* Tunable: VC_PENTHOUSE_PROPERTY_DEALER */;
                case 7:
                    return Tunables.Global_262145.Value<int>("f_27070") /* Tunable: VC_PENTHOUSE_PROPERTY_SPA */;
                case 8:
                    return Tunables.Global_262145.Value<int>("f_27072") /* Tunable: VC_PENTHOUSE_PROPERTY_OFFICE */;
                case 9:
                    return Tunables.Global_262145.Value<int>("f_27065") /* Tunable: VC_PENTHOUSE_PROPERTY_GARAGE */;
                case 5:
                    return Tunables.Global_262145.Value<int>("f_27066") /* Tunable: VC_PENTHOUSE_PROPERTY_BEDROOM */;
                case 6:
                    return Tunables.Global_262145.Value<int>("f_27068") /* Tunable: VC_PENTHOUSE_PROPERTY_MEDIA */;
            }
            return 0;
        }
        void func_5450(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1C0CAB
        {
            sParam0 = $"{func_5451(iParam1, iParam2)}_t0_v{iParam3}";
        }

        string func_5451(int iParam0, int iParam1)//Position - 0x1C0CCE
        {
            string cVar0 = "CASWEB_";

            switch (iParam0)
            {
                case 0:
                    cVar0 += "COLOUR_";
                    cVar0 += iParam1 + 1;
                    break;

                case 1:
                    cVar0 += "STYLE_";
                    cVar0 += iParam1 + 1;
                    break;

                case 2:
                    cVar0 += "LOUNGE_";
                    cVar0 += iParam1;
                    break;

                case 3:
                    cVar0 += "BAR_";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "DEALER_";
                    cVar0 += iParam1;
                    break;

                case 5:
                    cVar0 += "BEDRM_";
                    cVar0 += iParam1;
                    break;

                case 6:
                    cVar0 += "MEDRM_";
                    cVar0 += iParam1;
                    break;

                case 7:
                    cVar0 += "SPA_";
                    cVar0 += iParam1;
                    break;

                case 8:
                    cVar0 += "OFFICE_";
                    cVar0 += iParam1;
                    break;

                case 9:
                    cVar0 += "GARAGE_";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
                    break;
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length);
        }
        int func_5447(int iParam0)// some player stats hashes
        {
            return iParam0 switch
            {
                0 => 8253,
                1 => 8254,
                2 => 8255,
                3 => 8256,
                4 => 8257,
                5 => 8258,
                6 => 8259,
                7 => 8260,
                8 => 8261,
                9 => 8262,
                _ => 14385,
            };
        }
        int func_67(int iParam0, int iParam1)//Position - 0x4B07
        {
            int iVar0;
            int uVar1 = 0;

            if (iParam0 != 14385)
            {
                iVar0 = Function.Call<int>((Hash)0xD69CE161FE614531, 0, iParam0, 0);
                if (StatGetInt((uint)iVar0, ref uVar1, -1))
                {
                    return uVar1;
                }
            }
            return 0;
        }
    }
}
