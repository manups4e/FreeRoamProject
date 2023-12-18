using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal class Arcade : PropertyBase
    {
        public string Label(int n) => $"MP_ARC_{n}";

        public string Description(int n) => $"MP_ARC_{n}S";

        public string TXD(int n) => $"MP_ARC{(n - 1)}";


        public int[] StyleCost = [0, 0, 0];
        public int[] MuralCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] FloorCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] NeonCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int PersonalQuartersCost = 0;
        public int HighScoreScreensCost = 0;
        public int GarageCost = 0;

        public int[] StyleSaleCost = [-1, -1, -1];
        public int[] MuralSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] FloorSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] NeonSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int PersonalQuartersSaleCost = -1;
        public int HighScoreScreensSaleCost = -1;
        public int GarageSaleCost = -1;

        public Arcade(int slot, int id) : base(slot, id)
        {
            Position = GetDefaultPosition(GetDefaultId(id), 0);
            BaseCost = GetBaseCost(id);

            StyleCost = [
                func_5744(1, Id, 0), //iVar7 
                func_5744(1, Id, 1), //iVar8 
                func_5744(1, Id, 2), //iVar9 
            ];

            FloorCost = [
                func_5744(0, Id, 0), //iVar10 
                func_5744(0, Id, 1), //iVar11 
                func_5744(0, Id, 2), //iVar12 
                func_5744(0, Id, 3), //iVar13 
                func_5744(0, Id, 4), //iVar14 
                func_5744(0, Id, 5), //iVar15 
                func_5744(0, Id, 6), //iVar16 
                func_5744(0, Id, 7), //iVar17 
                func_5744(0, Id, 8), //iVar18 
            ];
            MuralCost = [
                func_5744(2, Id, 0), //iVar19 
                func_5744(2, Id, 1), //iVar20 
                func_5744(2, Id, 2), //iVar21 
                func_5744(2, Id, 3), //iVar22 
                func_5744(2, Id, 4), //iVar23 
                func_5744(2, Id, 5), //iVar24 
                func_5744(2, Id, 6), //iVar25 
                func_5744(2, Id, 7), //iVar26 
                func_5744(2, Id, 8), //iVar27 
            ];
            PersonalQuartersCost = func_5744(3, Id, 1); //iVar28 
            GarageCost = func_5744(4, Id, 1); //iVar29 
            NeonCost = [
                func_5744(5, Id, 0), //iVar30 
                func_5744(5, Id, 1), //iVar31 
                func_5744(5, Id, 2), //iVar32 
                func_5744(5, Id, 3), //iVar33 
                func_5744(5, Id, 4), //iVar34 
                func_5744(5, Id, 5), //iVar35 
                func_5744(5, Id, 6), //iVar36 
                func_5744(5, Id, 7), //iVar37 
                func_5744(5, Id, 8), //iVar38 
            ];
            HighScoreScreensCost = func_5744(6, Id, 1); //iVar39 

        }




        int GetDefaultId(int iParam0)//Position - 0x284964
        {
            return iParam0 switch
            {
                1 => 128,
                2 => 129,
                3 => 130,
                4 => 131,
                5 => 132,
                6 => 133,
                _ => -1,
            };
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id + 60);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamInt(6);
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
            ScaleformMovieMethodAddParamInt(FloorCost[0]);
            ScaleformMovieMethodAddParamInt(FloorCost[1]);
            ScaleformMovieMethodAddParamInt(FloorCost[2]);
            ScaleformMovieMethodAddParamInt(FloorCost[3]);
            ScaleformMovieMethodAddParamInt(FloorCost[4]);
            ScaleformMovieMethodAddParamInt(FloorCost[5]);
            ScaleformMovieMethodAddParamInt(FloorCost[6]);
            ScaleformMovieMethodAddParamInt(FloorCost[7]);
            ScaleformMovieMethodAddParamInt(FloorCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(MuralCost[0]);
            ScaleformMovieMethodAddParamInt(MuralCost[1]);
            ScaleformMovieMethodAddParamInt(MuralCost[2]);
            ScaleformMovieMethodAddParamInt(MuralCost[3]);
            ScaleformMovieMethodAddParamInt(MuralCost[4]);
            ScaleformMovieMethodAddParamInt(MuralCost[5]);
            ScaleformMovieMethodAddParamInt(MuralCost[6]);
            ScaleformMovieMethodAddParamInt(MuralCost[7]);
            ScaleformMovieMethodAddParamInt(MuralCost[8]);
            ScaleformMovieMethodAddParamInt(PersonalQuartersCost);
            ScaleformMovieMethodAddParamInt(GarageCost);
            ScaleformMovieMethodAddParamInt(NeonCost[0]);
            ScaleformMovieMethodAddParamInt(NeonCost[1]);
            ScaleformMovieMethodAddParamInt(NeonCost[2]);
            ScaleformMovieMethodAddParamInt(NeonCost[3]);
            ScaleformMovieMethodAddParamInt(NeonCost[4]);
            ScaleformMovieMethodAddParamInt(NeonCost[5]);
            ScaleformMovieMethodAddParamInt(NeonCost[6]);
            ScaleformMovieMethodAddParamInt(NeonCost[7]);
            ScaleformMovieMethodAddParamInt(NeonCost[8]);
            ScaleformMovieMethodAddParamInt(HighScoreScreensCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseSaleCost);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[2]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[0]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[1]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[2]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[3]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[4]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[5]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[6]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[7]);
            ScaleformMovieMethodAddParamInt(FloorSaleCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[0]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[1]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[2]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[3]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[4]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[5]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[6]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[7]);
            ScaleformMovieMethodAddParamInt(MuralSaleCost[8]);
            ScaleformMovieMethodAddParamInt(PersonalQuartersSaleCost);
            ScaleformMovieMethodAddParamInt(GarageSaleCost);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[0]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[1]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[2]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[3]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[4]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[5]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[6]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[7]);
            ScaleformMovieMethodAddParamInt(NeonSaleCost[8]);
            ScaleformMovieMethodAddParamInt(HighScoreScreensSaleCost);
            EndScaleformMovieMethod();
        }

        Vector3 GetDefaultPosition(int iParam0, int Id)//Position - 0x28481C
        {
            switch (Id)
            {
                case 0:
                    switch (iParam0)
                    {
                        case 128:
                            return new(-247.6898f, 6212.915f, 30.944f);

                        case 129:
                            return new(1695.1714f, 4785.1177f, 40.9847f);

                        case 130:
                            return new(-116.3816f, -1772.1368f, 28.8592f);

                        case 131:
                            return new(-599.5152f, 279.6308f, 81.074f);

                        case 132:
                            return new(-1273.2231f, -304.1054f, 37.2289f);

                        case 133:
                            return new(758.3455f, -815.9312f, 25.2905f);
                    }
                    break;
                case 1:
                    switch (iParam0)
                    {
                        case 128:
                            return new(-236.1645f, 6227.5366f, 35.634f);

                        case 129:
                            return new(1710.9613f, 4761.0938f, 41.9967f);

                        case 130:
                            return new(-106.2879f, -1779.3842f, 29.0749f);

                        case 131:
                            return new(-617.5596f, 286.6166f, 85.5191f);

                        case 132:
                            return new(-1286.964f, -279.0526f, 39.0088f);

                        case 133:
                            return new(729.1619f, -822.7321f, 28.5876f);
                    }
                    break;
            }
            return new(0f, 0f, 0f);
        }
        int GetBaseCost(int iParam0)//Position - 0x1D5114
        {
            string sVar0 = "";
            int iVar16;
            int iVar17;

            func_5444(ref sVar0, iParam0);
            iVar16 = GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = NetGameserverGetPrice((uint)iVar16, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_28747") /* Tunable: CH_ARCADE_PALETOBAY_SALE_PRICE */,
                2 => Tunables.Global_262145.Value<int>("f_28745") /* Tunable: CH_ARCADE_GRAPESEED_SALE_PRICE */,
                3 => Tunables.Global_262145.Value<int>("f_28744") /* Tunable: CH_ARCADE_DAVIS_SALE_PRICE */,
                4 => Tunables.Global_262145.Value<int>("f_28749") /* Tunable: CH_ARCADE_WESTVINEWOOD_SALE_PRICE */,
                5 => Tunables.Global_262145.Value<int>("f_28748") /* Tunable: CH_ARCADE_ROCKFORDHILLS_SALE_PRICE */,
                6 => Tunables.Global_262145.Value<int>("f_28746") /* Tunable: CH_ARCADE_LAMESA_SALE_PRICE */,
                _ => 0,
            };
        }
        void func_5444(ref string sParam0, int Id)//Position - 0x1C04F9
        {
            sParam0 = $"ARC_INDEX_{Id}_t0_v0";
        }

        int func_5744(int iParam0, int Id, int iParam2)//Position - 0x1D4D75
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            iVar0 = 0;
            func_5440(ref sVar1, iParam0, iParam2, iVar0);
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
                            return Tunables.Global_262145.Value<int>("f_28762") /* Tunable: CH_ARCADE_FLOOR_NONE_RENOVATION_SALE_PRICE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28665") /* Tunable: CH_ARCADE_FLOOR_1_SALE_PRICE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_28666") /* Tunable: CH_ARCADE_FLOOR_2_SALE_PRICE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_28667") /* Tunable: CH_ARCADE_FLOOR_3_SALE_PRICE */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_28668") /* Tunable: CH_ARCADE_FLOOR_4_SALE_PRICE */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_28669") /* Tunable: CH_ARCADE_FLOOR_5_SALE_PRICE */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_28670") /* Tunable: CH_ARCADE_FLOOR_6_SALE_PRICE */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_28671") /* Tunable: CH_ARCADE_FLOOR_7_SALE_PRICE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_28672") /* Tunable: CH_ARCADE_FLOOR_8_SALE_PRICE */;
                    }
                    break;

                case 1:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_28750") /* Tunable: CH_ARCADE_STYLE_RETRO_RENOVATION_SALE_PRICE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28751") /* Tunable: CH_ARCADE_STYLE_MIRRORED_SALE_PRICE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_28752") /* Tunable: CH_ARCADE_STYLE_HIPSTER_SALE_PRICE */;
                    }
                    break;

                case 2:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_28753") /* Tunable: CH_ARCADE_MURAL_NONE_RENOVATION_SALE_PRICE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28656") /* Tunable: CH_ARCADE_MURAL_1_SALE_PRICE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_28657") /* Tunable: CH_ARCADE_MURAL_2_SALE_PRICE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_28658") /* Tunable: CH_ARCADE_MURAL_3_SALE_PRICE */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_28659") /* Tunable: CH_ARCADE_MURAL_4_SALE_PRICE */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_28660") /* Tunable: CH_ARCADE_MURAL_5_SALE_PRICE */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_28661") /* Tunable: CH_ARCADE_MURAL_6_SALE_PRICE */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_28662") /* Tunable: CH_ARCADE_MURAL_7_SALE_PRICE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_28663") /* Tunable: CH_ARCADE_MURAL_8_SALE_PRICE */;
                    }
                    break;

                case 3:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28683") /* Tunable: CH_ARCADE_QUARTERS_SALE_PRICE */;
                    }
                    break;

                case 4:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28684") /* Tunable: CH_ARCADE_GARAGE_SALE_PRICE */;
                    }
                    break;

                case 5:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_28771") /* Tunable: CH_ARCADE_NEON_NONE_RENOVATION_SALE_PRICE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28674") /* Tunable: CH_ARCADE_NEON_1_SALE_PRICE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_28675") /* Tunable: CH_ARCADE_NEON_2_SALE_PRICE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_28676") /* Tunable: CH_ARCADE_NEON_3_SALE_PRICE */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_28677") /* Tunable: CH_ARCADE_NEON_4_SALE_PRICE */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_28678") /* Tunable: CH_ARCADE_NEON_5_SALE_PRICE */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_28679") /* Tunable: CH_ARCADE_NEON_6_SALE_PRICE */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_28680") /* Tunable: CH_ARCADE_NEON_7_SALE_PRICE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_28681") /* Tunable: CH_ARCADE_NEON_8_SALE_PRICE */;
                    }
                    break;

                case 6:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_28682") /* Tunable: CH_ARCADE_HIGHSCORE_SALE_PRICE */;
                    }
                    break;

                case 8:
                    return Tunables.Global_262145.Value<int>("f_28742") /* Tunable: CH_ARCADE_UPGRADE_CONTROL_SALE_PRICE */;

                case 7:
                    return Tunables.Global_262145.Value<int>("f_28743") /* Tunable: CH_ARCADE_UPGRADE_DRONE_SALE_PRICE */;
            }
            return 0;
        }

        void func_5440(ref string sParam0, int Id, int iParam2, int iParam3)//Position - 0x1C037B
        {
            sParam0 = $"{func_5441(Id, iParam2)}_t0_v{iParam3}";
        }

        string func_5441(int iParam0, int Id)//Position - 0x1C039E
        {

            string cVar0 = "FCARCADE_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "FLR_";
                    cVar0 += Id + 1;
                    break;

                case 1:
                    cVar0 += "CEIL_";
                    cVar0 += Id + 1;
                    break;

                case 2:
                    cVar0 += "WALL_";
                    cVar0 += Id + 1;
                    break;

                case 3:
                    cVar0 += "QRT";
                    cVar0 += Id;
                    break;

                case 4:
                    cVar0 += "GRG";
                    cVar0 += Id;
                    break;

                case 5:
                    cVar0 += "NE";
                    cVar0 += Id + 1;
                    break;

                case 6:
                    cVar0 += "HS";
                    cVar0 += Id;
                    break;

                case 7:
                    cVar0 += "DS";
                    break;

                case 8:
                    cVar0 += "BH";
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length);
        }
        /* bitwise
              void func_5445(var uParam0)//Position - 0x1C0519
              {
                  *uParam0 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 0, 6);
                  uParam0->f_1 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 6, 4);
                  uParam0->f_2 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 10, 2);
                  uParam0->f_3 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 12, 4);
                  uParam0->f_4 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 16, 1);
                  uParam0->f_5 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 17, 1);
                  uParam0->f_6 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 18, 4);
                  uParam0->f_7 = func_5598(HUD::GET_GLOBAL_ACTIONSCRIPT_FLAG(13), 22, 1);
              }
           */
    }
}
