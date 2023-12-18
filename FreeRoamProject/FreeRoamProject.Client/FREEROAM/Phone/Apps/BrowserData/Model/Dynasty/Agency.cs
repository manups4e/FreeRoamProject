using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty
{
    internal class Agency : PropertyBase
    {

        public string Label(int n) => $"FIX_HQ_NME_{n}";
        public string Description(int n) => $"MP_FIX_{n}S";
        public string TXD(int n) => $"MP_AGENCY{n - 1}";

        public int[] ArtCost = [0, 0, 0];
        public int[] WallpaperCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] TintCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int ArmoryCost = 0;
        public int AccomodationCost = 0;
        public int VehWorkshopCost = 0;

        public int[] ArtSaleCost = [-1, -1, -1];
        public int[] WallpaperSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] TintSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int ArmorySaleCost = -1;
        public int AccomodationSaleCost = -1;
        public int VehWorkshopSaleCost = -1;



        public Agency(int slot, int id) : base(slot, id) //func_7339
        {
            Position = GetCurrentPosition(GetDefaultId(id), 0);
            BaseCost = GetDefaultPrice(id);
            ArtCost = [
                func_5735(0, Id, 0),
                func_5735(0, Id, 1),
                func_5735(0, Id, 2)
            ];
            WallpaperCost = [
                func_5735(1, Id, 0),
                func_5735(1, Id, 1),
                func_5735(1, Id, 2),
                func_5735(1, Id, 3),
                func_5735(1, Id, 4),
                func_5735(1, Id, 5),
                func_5735(1, Id, 6),
                func_5735(1, Id, 7),
                func_5735(1, Id, 8)
            ];
            TintCost = [
                func_5735(2, Id, 0),
                func_5735(2, Id, 1),
                func_5735(2, Id, 2),
                func_5735(2, Id, 3),
                func_5735(2, Id, 4),
                func_5735(2, Id, 5),
                func_5735(2, Id, 6),
                func_5735(2, Id, 7),
                func_5735(2, Id, 8)
            ];
            ArmoryCost = func_5735(3, Id, 1);
            AccomodationCost = func_5735(4, Id, 1);
            VehWorkshopCost = func_5735(5, Id, 1);

        }


        public void AddToScaleform(ScaleformWideScreen sc)
        {
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id + 20);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamInt(1);
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(ArtCost[0]);
            ScaleformMovieMethodAddParamInt(ArtCost[1]);
            ScaleformMovieMethodAddParamInt(ArtCost[2]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[0]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[1]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[2]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[3]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[4]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[5]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[6]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[7]);
            ScaleformMovieMethodAddParamInt(WallpaperCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
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
            ScaleformMovieMethodAddParamInt(ArmoryCost);
            ScaleformMovieMethodAddParamInt(AccomodationCost);
            ScaleformMovieMethodAddParamInt(VehWorkshopCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseSaleCost);
            ScaleformMovieMethodAddParamInt(ArtSaleCost[0]);
            ScaleformMovieMethodAddParamInt(ArtSaleCost[1]);
            ScaleformMovieMethodAddParamInt(ArtSaleCost[2]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[0]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[1]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[2]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[3]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[4]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[5]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[6]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[7]);
            ScaleformMovieMethodAddParamInt(WallpaperSaleCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
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
            ScaleformMovieMethodAddParamInt(ArmorySaleCost);
            ScaleformMovieMethodAddParamInt(AccomodationSaleCost);
            ScaleformMovieMethodAddParamInt(VehWorkshopSaleCost);
            EndScaleformMovieMethod();
        }

        int GetDefaultPrice(int iParam0)//Position - 0x1D477B
        {
            string sVar0 = "";
            int iVar16;
            int iVar17;

            func_5406(ref sVar0, iParam0);
            iVar16 = GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = NetGameserverGetPrice((uint)iVar16, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_32273") /* Tunable: FIXER_AGENCY_SALE_HAWICK */,
                2 => Tunables.Global_262145.Value<int>("f_32274") /* Tunable: FIXER_AGENCY_SALE_ROCKFORD_HILLS */,
                3 => Tunables.Global_262145.Value<int>("f_32275") /* Tunable: FIXER_AGENCY_SALE_LITTLE_SEOUL */,
                4 => Tunables.Global_262145.Value<int>("f_32276") /* Tunable: FIXER_AGENCY_SALE_VESPUCCI_CANALS */,
                _ => 0,
            };
        }
        void func_5406(ref string sParam0, int iParam1)//Position - 0x1BEBE9
        {
            sParam0 = $"FIXER_HQ_INDEX_{iParam1}_t0_v0";
        }
        int func_5735(int iParam0, int iParam1, int iParam2)//Position - 0x1D44CA
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;


            iVar0 = 0;
            func_5401(ref sVar1, iParam0, iParam2, iVar0);
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
                            return Tunables.Global_262145.Value<int>("f_32280") /* Tunable: FIXER_AGENCY_SALE_ART_POWER_MONEY */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32281") /* Tunable: FIXER_AGENCY_SALE_ART_POP_HYPE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_32282") /* Tunable: FIXER_AGENCY_SALE_ART_LOYALTY_RESPECT */;
                    }
                    break;

                case 1:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_32292") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32293") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_32294") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_3 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_32295") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_4 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_32296") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_5 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_32297") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_6 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_32298") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_7 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_32299") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_8 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_32300") /* Tunable: FIXER_AGENCY_SALE_WALLPAPER_9 */;
                    }
                    break;

                case 2:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_32310") /* Tunable: FIXER_AGENCY_SALE_TINT_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32311") /* Tunable: FIXER_AGENCY_SALE_TINT_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_32312") /* Tunable: FIXER_AGENCY_SALE_TINT_3 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_32313") /* Tunable: FIXER_AGENCY_SALE_TINT_4 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_32314") /* Tunable: FIXER_AGENCY_SALE_TINT_5 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_32315") /* Tunable: FIXER_AGENCY_SALE_TINT_6 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_32316") /* Tunable: FIXER_AGENCY_SALE_TINT_7 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_32317") /* Tunable: FIXER_AGENCY_SALE_TINT_8 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_32318") /* Tunable: FIXER_AGENCY_SALE_TINT_9 */;
                    }
                    break;

                case 3:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32324") /* Tunable: FIXER_AGENCY_SALE_VEHICLE_WORKSHOP */;
                    }
                    break;

                case 4:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32323") /* Tunable: FIXER_AGENCY_SALE_ARMORY */;
                    }
                    break;

                case 5:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_32322") /* Tunable: FIXER_AGENCY_SALE_ACCOMMODATION */;
                    }
                    break;
            }
            return 0;
        }
        void func_5401(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1BEA51
        {
            sParam0 = $"{func_5402(iParam1, iParam2)}_t0_v{iParam3}";
        }
        string func_5402(int iParam0, int iParam1)//Position - 0x1BEA74
        {
            string cVar0 = "FIXER_HQ_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "ART_";
                    cVar0 += iParam1 + 1;
                    break;

                case 1:
                    cVar0 += "WAL_";
                    cVar0 += iParam1 + 1;
                    break;

                case 2:
                    cVar0 += "TNT_";
                    cVar0 += iParam1 + 1;
                    break;

                case 3:
                    cVar0 += "VEH_";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "ARM_";
                    cVar0 += iParam1;
                    break;

                case 5:
                    cVar0 += "QTR_";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length);
        }
        Vector3 GetCurrentPosition(int iParam0, int iParam1)//Position - 0x285078
        {
            if (iParam1 == 0)
            {
                switch (iParam0)
                {
                    case 155:
                        return new(388.3036f, -74.6683f, 67.1805f);

                    case 156:
                        return new(-1016.5347f, -413.186f, 38.6161f);

                    case 157:
                        return new(-589.4908f, -707.4646f, 35.2844f);

                    case 158:
                        return new(-1039.0834f, -756.4792f, 18.8395f);
                }
            }
            else
            {
                switch (iParam0)
                {
                    case 155:
                        return new(359.35f, -74.67f, 66.12f);

                    case 156:
                        return new(-1031.25f, -411.55f, 32.27f);

                    case 157:
                        return new(-615.77f, -738.3f, 26.86f);

                    case 158:
                        return new(-986.94f, -765.11f, 14.74f);
                }
            }
            return new(0f, 0f, 0f);
        }

        int GetDefaultId(int iParam0)//Position - 0x285172
        {

            return iParam0 switch
            {
                1 => 155,
                2 => 156,
                3 => 157,
                4 => 158,
                _ => -1,
            };
        }
    }
}
