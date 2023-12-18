using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal class AutoShop : PropertyBase
    {

        public string Label(int n) => $"AUT_SHP_NME_{n}";
        public string Description(int n) => $"MP_AUT_{n}S";
        public string TXD(int n) => $"MP_AUTOSHOP{n - 1}";

        public int[] StyleCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] TintCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] EmblemCost = [0, 0, 0, 0, 0, 0, 0];
        public int[] StaffCost = [0, 0];
        public int QuartersCost = 0;
        public int CarLiftCost = 0;
        public int MembershipCost = 0;

        public int[] StyleSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] TintSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] EmblemSaleCost = [-1, -1, -1, -1, -1, -1, -1];
        public int[] StaffSaleCost = [-1, -1];
        public int QuartersSaleCost = -1;
        public int CarLiftSaleCost = -1;
        public int MembershipSaleCost = -1;

        public AutoShop(int slot, int id) : base(slot, id)
        {
            Position = GetDefaultPosition(GetDefaultId(id));
            BaseCost = GetBasePrice(id);
            StyleCost = [
                func_5739(0, Id, 0), //iVar7 
                func_5739(0, Id, 1), //iVar8 
                func_5739(0, Id, 2), //iVar9 
                func_5739(0, Id, 3), //iVar10 
                func_5739(0, Id, 4), //iVar11 
                func_5739(0, Id, 5), //iVar12 
                func_5739(0, Id, 6), //iVar13 
                func_5739(0, Id, 7), //iVar14 
                func_5739(0, Id, 8) //iVar15 
            ];
            TintCost = [
                func_5739(1, Id, 0), //iVar16 
                func_5739(1, Id, 1), //iVar17 
                func_5739(1, Id, 2), //iVar18 
                func_5739(1, Id, 3), //iVar19 
                func_5739(1, Id, 4), //iVar20 
                func_5739(1, Id, 5), //iVar21 
                func_5739(1, Id, 6), //iVar22 
                func_5739(1, Id, 7), //iVar23 
                func_5739(1, Id, 8) //iVar24 
            ];
            EmblemCost = [
                func_5739(2, Id, 0), //iVar25 
                func_5739(2, Id, 1), //iVar26 
                func_5739(2, Id, 2), //iVar27 
                func_5739(2, Id, 3), //iVar28 
                func_5739(2, Id, 4), //iVar29 
                func_5739(2, Id, 5), //iVar30 
                func_5739(2, Id, 6), //iVar31 
                func_5739(2, Id, 7) //iVar32 
            ];
            MembershipCost = func_5739(3, Id, 1); //iVar34 
            StaffCost = [
                func_5739(4, Id, 1),//iVar35 
                func_5739(5, Id, 1)//iVar36 
            ];
            CarLiftCost = func_5739(6, Id, 1); //iVar37 
            QuartersCost = func_5739(7, Id, 1); //iVar38 

        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            int iVar39 = Tunables.Global_262145.Value<int>("f_31526");
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id + 70);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamInt(7);
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            Tools.SetScaleformString("");
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(StyleCost[0]);
            ScaleformMovieMethodAddParamInt(StyleCost[1]);
            ScaleformMovieMethodAddParamInt(StyleCost[2]);
            ScaleformMovieMethodAddParamInt(StyleCost[3]);
            ScaleformMovieMethodAddParamInt(StyleCost[4]);
            ScaleformMovieMethodAddParamInt(StyleCost[5]);
            ScaleformMovieMethodAddParamInt(StyleCost[6]);
            ScaleformMovieMethodAddParamInt(StyleCost[7]);
            ScaleformMovieMethodAddParamInt(StyleCost[8]);
            ScaleformMovieMethodAddParamInt(TintCost[0]);
            ScaleformMovieMethodAddParamInt(TintCost[1]);
            ScaleformMovieMethodAddParamInt(TintCost[2]);
            ScaleformMovieMethodAddParamInt(TintCost[3]);
            ScaleformMovieMethodAddParamInt(TintCost[4]);
            ScaleformMovieMethodAddParamInt(TintCost[5]);
            ScaleformMovieMethodAddParamInt(TintCost[6]);
            ScaleformMovieMethodAddParamInt(TintCost[7]);
            ScaleformMovieMethodAddParamInt(TintCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(EmblemCost[0]);
            ScaleformMovieMethodAddParamInt(EmblemCost[1]);
            ScaleformMovieMethodAddParamInt(EmblemCost[2]);
            ScaleformMovieMethodAddParamInt(EmblemCost[3]);
            ScaleformMovieMethodAddParamInt(EmblemCost[4]);
            ScaleformMovieMethodAddParamInt(EmblemCost[5]);
            ScaleformMovieMethodAddParamInt(EmblemCost[6]);
            ScaleformMovieMethodAddParamInt(EmblemCost[7]);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(MembershipCost);
            ScaleformMovieMethodAddParamInt(StaffCost[0]);
            ScaleformMovieMethodAddParamInt(StaffCost[1]);
            ScaleformMovieMethodAddParamInt(CarLiftCost);
            ScaleformMovieMethodAddParamInt(QuartersCost);
            ScaleformMovieMethodAddParamInt(iVar39);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseSaleCost);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[2]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[3]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[4]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[5]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[6]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[7]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[8]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[0]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[1]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[2]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[3]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[4]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[5]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[6]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[7]);
            ScaleformMovieMethodAddParamInt(TintSaleCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[0]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[1]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[2]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[3]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[4]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[5]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[6]);
            ScaleformMovieMethodAddParamInt(EmblemSaleCost[7]);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(MembershipSaleCost);
            ScaleformMovieMethodAddParamInt(StaffSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StaffSaleCost[1]);
            ScaleformMovieMethodAddParamInt(CarLiftSaleCost);
            ScaleformMovieMethodAddParamInt(QuartersSaleCost);
            ScaleformMovieMethodAddParamInt(-1);
            EndScaleformMovieMethod();
        }

        int GetDefaultId(int iParam0)//Position - 0x2847D5
        {
            return iParam0 switch
            {
                1 => 149,
                2 => 150,
                3 => 151,
                4 => 152,
                5 => 153,
                _ => -1,
            };
        }

        Vector3 GetDefaultPosition(int iParam0)//Position - 0x28473C
        {
            return iParam0 switch
            {
                149 => new(759.8774f, -677.6455f, 27.8356f),
                150 => new(-147.1386f, -1341.7018f, 28.9145f),
                151 => new(-171.7504f, -33.8705f, 51.256f),
                152 => new(233.9541f, -1873.8497f, 25.5283f),
                153 => new(489.2497f, -894.8347f, 24.7408f),
                _ => new(0f, 0f, 0f),
            };
        }

        int GetBasePrice(int iParam0)//Position - 0x1D4C2D
        {
            string sVar0 = "";
            int iVar16;
            int iVar17;

            func_5425(ref sVar0, iParam0);
            iVar16 = GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = NetGameserverGetPrice((uint)iVar16, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_31458") /* Tunable: TUNER_AUTOSHOP_SALE_LA_MESA */,
                2 => Tunables.Global_262145.Value<int>("f_31459") /* Tunable: TUNER_AUTOSHOP_SALE_STRAWBERRY */,
                3 => Tunables.Global_262145.Value<int>("f_31460") /* Tunable: TUNER_AUTOSHOP_SALE_BURTON */,
                4 => Tunables.Global_262145.Value<int>("f_31461") /* Tunable: TUNER_AUTOSHOP_SALE_RANCHO */,
                5 => Tunables.Global_262145.Value<int>("f_31462") /* Tunable: TUNER_AUTOSHOP_SALE_MISSION_ROW */,
                _ => 0,
            };
        }
        void func_5425(ref string sParam0, int iParam1)//Position - 0x1BF4AC
        {
            sParam0 = $"AUTO_SHOP_INDEX_{iParam1}_t0_v0";
        }


        int func_5739(int iParam0, int iParam1, int iParam2)//Position - 0x1D48CA
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            iVar0 = 0;
            func_5420(ref sVar1, iParam0, iParam2, iVar0);
            iVar17 = GetHashKey(sVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = NetGameserverGetPrice((uint)iVar17, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar18;
            }
            switch (iParam0)
            {
                case 0:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_31472") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_NAKED */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31473") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_CLEAN_LIGHT */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_31474") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_CLEAN_DARK */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_31475") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_CLEAN_MID */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_31476") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_NOSTALGIA */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_31477") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_AMERICANA */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_31478") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_SUPER_CARS */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_31479") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_WILDSTYLE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_31480") /* Tunable: TUNER_AUTOSHOP_SALE_STYLE_GAMING */;
                    }
                    break;

                case 1:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_31490") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31491") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_31492") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_3 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_31493") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_4 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_31494") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_5 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_31495") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_6 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_31496") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_7 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_31497") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_8 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_31498") /* Tunable: TUNER_AUTOSHOP_SALE_TINT_9 */;
                    }
                    break;

                case 2:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_31507") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_CREW */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31508") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_HOT_ROD */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_31509") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_AMERICANA */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_31510") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_EURO */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_31511") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_MODERN */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_31512") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_JPN */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_31513") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_WILDSTYLE */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_31514") /* Tunable: TUNER_AUTOSHOP_SALE_EMBLEM_JOYSTICK */;
                    }
                    break;

                case 3:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31516") /* Tunable: TUNER_AUTOSHOP_SALE_CREW_NAME */;
                    }
                    break;

                case 4:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31519") /* Tunable: TUNER_AUTOSHOP_SALE_STAFF_MEMBER1 */;
                    }
                    break;

                case 5:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31520") /* Tunable: TUNER_AUTOSHOP_SALE_STAFF_MEMBER2 */;
                    }
                    break;

                case 6:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31523") /* Tunable: TUNER_AUTOSHOP_SALE_ADDON_CARLIFT */;
                    }
                    break;

                case 7:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_31524") /* Tunable: TUNER_AUTOSHOP_SALE_ADDON_QUARTERS */;
                    }
                    break;
            }
            return 0;
        }
        void func_5420(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1BF32A
        {
            sParam0 = $"{func_5421(iParam1, iParam2)}_t0_v{iParam3}";
        }

        string func_5421(int iParam0, int iParam1)//Position - 0x1BF34D
        {

            string cVar0 = "AUTOSHOP_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "WAL_";
                    cVar0 += iParam1 + 1;
                    break;

                case 1:
                    cVar0 += "TNT_";
                    cVar0 += iParam1 + 1;
                    break;

                case 2:
                    cVar0 += "EMB_";
                    cVar0 += iParam1 + 1;
                    break;

                case 3:
                    cVar0 += "CRW_";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "ST1_";
                    cVar0 += iParam1;
                    break;

                case 5:
                    cVar0 += "ST2_";
                    cVar0 += iParam1;
                    break;

                case 6:
                    cVar0 += "CRL_";
                    cVar0 += iParam1;
                    break;

                case 7:
                    cVar0 += "QTR_";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length);
        }
    }
}

//func_7282

