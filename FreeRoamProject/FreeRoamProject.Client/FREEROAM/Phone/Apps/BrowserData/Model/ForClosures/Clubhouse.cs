using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;
namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    public class Clubhouse : PropertyBase // TODO: FUNC_55
    {
        /// <summary>
        /// Returns a label which can be read by the scaleform, you can create your own using AddTextEntry
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Label(int n) => n switch
        {
            91 => "MP_PROP_CLUBH1",
            92 => "MP_PROP_CLUBH2",
            93 => "MP_PROP_CLUBH3",
            94 => "MP_PROP_CLUBH4",
            95 => "MP_PROP_CLUBH5",
            96 => "MP_PROP_CLUBH6",
            97 => "MP_PROP_CLUBH7",
            98 => "MP_PROP_CLUBH8",
            99 => "MP_PROP_CLUBH9",
            100 => "MP_PROP_CLUBH10",
            101 => "MP_PROP_CLUBH11",
            102 => "MP_PROP_CLUBH12",
            _ => ""

        };

        /// <summary>
        /// Returns a description which can be read by the scaleform, you can create your own using AddTextEntry
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Description(int n) => n switch
        {
            91 => "MP_CLUBH1DES",
            92 => "MP_CLUBH2DES",
            93 => "MP_CLUBH3DES",
            94 => "MP_CLUBH4DES",
            95 => "MP_CLUBH5DES",
            96 => "MP_CLUBH6DES",
            97 => "MP_CLUBH7DES",
            98 => "MP_CLUBH8DES",
            99 => "MP_CLUBH9DES",
            100 => "MP_CLUBH10DES",
            101 => "MP_CLUBH11DES",
            102 => "MP_CLUBH12DES",
            _ => ""
        };
        public string GetAddress(int n) => n switch
        {
            91 => "MP_CLUBH1ADD",
            92 => "MP_CLUBH2ADD",
            93 => "MP_CLUBH3ADD",
            94 => "MP_CLUBH4ADD",
            95 => "MP_CLUBH5ADD",
            96 => "MP_CLUBH6ADD",
            97 => "MP_CLUBH7ADD",
            98 => "MP_CLUBH8ADD",
            99 => "MP_CLUBH9ADD",
            100 => "MP_CLUBH10ADD",
            101 => "MP_CLUBH11ADD",
            102 => "MP_CLUBH12ADD",
            _ => ""
        };

        /// <summary>
        /// Returns a texture which can be used by the scaleform, you can create your own with AddReplaceTexture using mp_hngr1-5 or create more and stream them.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string TXD(int n) => n switch
        {
            91 => "MP_CLUBH2",
            92 => "MP_CLUBH1",
            93 => "MP_CLUBH3",
            94 => "MP_CLUBH4",
            95 => "MP_CLUBH5",
            96 => "MP_CLUBH6",
            97 => "MP_CLUBH7",
            98 => "MP_CLUBH8",
            99 => "MP_CLUBH9",
            100 => "MP_CLUBH11",
            101 => "MP_CLUBH12",
            102 => "MP_CLUBH10",
            _ => "",
        };

        public eOfficePropertyType OfficeType { get; private set; } = eOfficePropertyType.ClubHouse;

        public int[] MuralsCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] WallStyleCost = [0, 0];
        public int[] WallHangingCost = [0, 0];
        public int[] WallFurnitureCost = [0, 0];
        public int[] ClubEmblemCost = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int ClubFontCost = 0;
        public int ClubNameCost = 0;
        public int GunLockerCost = 0;
        public int BikeShopCost = 0;


        public int[] MuralsSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] WallStyleSaleCost = [-1, -1];
        public int[] WallHangingSaleCost = [-1, -1];
        public int[] WallFurnitureSaleCost = [-1, -1];
        public int[] ClubEmblemSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int ClubFontSaleCost = -1;
        public int ClubNameSaleCost = -1;
        public int GunLockerSaleCost = -1;
        public int BikeShopSaleCost = -1;

        public bool StarterPack = false;
        public Clubhouse(int slot, int id) : base(slot, id)
        {
            BaseCost = Ceil(func_5723(id) * Tunables.Global_262145.Value<float>("f_78") /* Tunable: PROPERTY_MULTIPLIER */);

            Position = GetPosition(id);
            if (id == 94)
            {
                Position = new Vector3(55.4027f, 2760.846f, 56.6234f);
            }
            WallStyleCost = [func_5718(0, 0), func_5718(0, 1)];
            WallHangingCost = [func_5718(1, 0), func_5718(1, 1)];
            WallFurnitureCost = [func_5718(2, 0), func_5718(2, 1)];
            MuralsCost = [
                func_6347(0, Id),
                func_6347(1, Id),
                func_6347(2, Id),
                func_6347(3, Id),
                func_6347(4, Id),
                func_6347(5, Id),
                func_6347(6, Id),
                func_6347(7, Id),
                func_6347(8, Id),
            ];
            ClubEmblemCost = [
                func_5718(6, 0),
                func_5718(6, 1),
                func_5718(6, 2),
                func_5718(6, 3),
                func_5718(6, 4),
                func_5718(6, 5),
                func_5718(6, 6),
                func_5718(6, 7),
                func_5718(6, 8),
                func_5718(6, 9),
            ];
            ClubFontCost = func_5718(4, -1);
            ClubNameCost = func_5718(10, 1);
            GunLockerCost = func_5718(8, -1);
            BikeShopCost = func_5718(9, -1);
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            bool bVar5 = Tunables.Global_262145.Value<int>("f_13353") == 1/* Tunable: PROPERTYWEBSITE_SALE */; // is on sale?
            int iVar0 = Id;
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id);
            Tools.SetScaleformString(Label(Id));
            if (Id >= 91 && Id < 97)
            {
                ScaleformMovieMethodAddParamInt(0);
            }
            else if (Id >= 97)
            {
                ScaleformMovieMethodAddParamInt(1);
            }
            else
            {
                ScaleformMovieMethodAddParamInt(-1);
            }
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            Tools.SetScaleformString(GetAddress(Id));
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(WallStyleCost[0]);
            ScaleformMovieMethodAddParamInt(WallStyleCost[1]);
            ScaleformMovieMethodAddParamInt(WallHangingCost[0]);
            ScaleformMovieMethodAddParamInt(WallHangingCost[1]);
            ScaleformMovieMethodAddParamInt(WallFurnitureCost[0]);
            ScaleformMovieMethodAddParamInt(WallFurnitureCost[1]);
            ScaleformMovieMethodAddParamInt(MuralsCost[0]);
            ScaleformMovieMethodAddParamInt(MuralsCost[1]);
            ScaleformMovieMethodAddParamInt(MuralsCost[2]);
            ScaleformMovieMethodAddParamInt(MuralsCost[3]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(MuralsCost[4]);
            ScaleformMovieMethodAddParamInt(MuralsCost[5]);
            ScaleformMovieMethodAddParamInt(MuralsCost[6]);
            ScaleformMovieMethodAddParamInt(MuralsCost[7]);
            ScaleformMovieMethodAddParamInt(MuralsCost[8]);
            ScaleformMovieMethodAddParamInt(ClubFontCost);
            ScaleformMovieMethodAddParamInt(ClubNameCost);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[1]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[2]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[3]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[4]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[5]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[6]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[7]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[8]);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[9]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(ClubEmblemCost[0]);
            ScaleformMovieMethodAddParamInt(GunLockerCost);
            ScaleformMovieMethodAddParamInt(BikeShopCost);
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(WallStyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(WallStyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(WallHangingSaleCost[0]);
            ScaleformMovieMethodAddParamInt(WallHangingSaleCost[1]);
            ScaleformMovieMethodAddParamInt(WallFurnitureSaleCost[0]);
            ScaleformMovieMethodAddParamInt(WallFurnitureSaleCost[1]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[0]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[1]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[2]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[3]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[4]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[5]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[6]);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[7]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(MuralsSaleCost[8]);
            ScaleformMovieMethodAddParamInt(ClubFontSaleCost);
            ScaleformMovieMethodAddParamInt(ClubNameSaleCost);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[1]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[2]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[3]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[4]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[5]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[6]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[7]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[8]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[9]);
            ScaleformMovieMethodAddParamInt(ClubEmblemSaleCost[0]);
            ScaleformMovieMethodAddParamInt(GunLockerSaleCost);
            ScaleformMovieMethodAddParamInt(BikeShopSaleCost);
            if ((VehicleSitesHandler.func_5728() && func_5727(Id)) && func_5731(Id))
            {
                ScaleformMovieMethodAddParamBool(true);
            }
            else
            {
                ScaleformMovieMethodAddParamBool(false);
            }
            EndScaleformMovieMethod();
        }

        public static void GetPurchasedData(int bitwiseValue, ref int clubHouseIndex, ref int styleIndex, ref int lightingIndex, ref int decalIndex, ref int furnatureIndex, ref int quartersIndex, ref bool purchasedWorkshop)
        {
            clubHouseIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 0, 6);
            clubHouseIndex += 91;

            int uParam1 = Tools.GetValueFromBitwiseValue(bitwiseValue, 6, 1);
            int uParam2 = Tools.GetValueFromBitwiseValue(bitwiseValue, 7, 1);
            int uParam3 = Tools.GetValueFromBitwiseValue(bitwiseValue, 8, 1);
            int uParam4 = func_5600(clubHouseIndex, Tools.GetValueFromBitwiseValue(bitwiseValue, 9, 4));
            int uParam5 = Tools.GetValueFromBitwiseValue(bitwiseValue, 13, 4);
            int uParam6 = Tools.GetValueFromBitwiseValue(bitwiseValue, 17, 4);
            int uParam7 = Tools.GetValueFromBitwiseValue(bitwiseValue, 21, 4);
            int uParam8 = Tools.GetValueFromBitwiseValue(bitwiseValue, 25, 1);
            int uParam9 = Tools.GetValueFromBitwiseValue(bitwiseValue, 26, 1);
            int uParam10 = Tools.GetValueFromBitwiseValue(bitwiseValue, 27, 1);

            Debug.WriteLine($"uParam1:{uParam1}, uParam2:{uParam2}, uParam3:{uParam3}, uParam4:{uParam4}, uParam5:{uParam5}, uParam6:{uParam6}, uParam7:{uParam7}, uParam8:{uParam8}, uParam9:{uParam9}, uParam10:{uParam10}");
        }

        public int GetTotalValueOfPurchases(int bitwiseValue)
        {
            int hangarIndex = 0;
            int styleIndex = 0;
            int lightingIndex = 0;
            int decalIndex = 0;
            int furnatureIndex = 0;
            int quartersIndex = 0;
            bool purchasedWorkshop = false;

            GetPurchasedData(bitwiseValue, ref hangarIndex, ref styleIndex, ref lightingIndex, ref decalIndex, ref furnatureIndex, ref quartersIndex, ref purchasedWorkshop);
            /*
            int total = 0;
            total += Tools.GetBestPrice(BaseCost, BaseSaleCost);
            total += Tools.GetBestPrice(StyleCost[styleIndex], StyleSaleCost[styleIndex]);
            total += Tools.GetBestPrice(LightingCost[lightingIndex], LightingSaleCost[lightingIndex]);
            total += Tools.GetBestPrice(DecalCost[decalIndex], DecalSaleCost[decalIndex]);
            total += Tools.GetBestPrice(FurnatureCost[furnatureIndex], FurnatureSaleCost[furnatureIndex]);
            total += Tools.GetBestPrice(QuartersCost[quartersIndex], QuartersSaleCost[quartersIndex]);
            total += (purchasedWorkshop) ? Tools.GetBestPrice(WorkshopCost, WorkshopSaleCost) : 0;
            return total;*/
            return 0;
        }
        static int func_5600(int iParam0, int iParam1)//Position - 0x1CE699
        {
            if (func_5591(iParam0) == 91)
            {
                if (iParam1 == 0)
                {
                    return 0;
                }
                else if (iParam1 == 1)
                {
                    return 8;
                }
                else if (iParam1 == 2)
                {
                    return 2;
                }
                else if (iParam1 == 3)
                {
                    return 7;
                }
                else if (iParam1 == 4)
                {
                    return 3;
                }
                else if (iParam1 == 5)
                {
                    return 4;
                }
                else if (iParam1 == 6)
                {
                    return 6;
                }
                else if (iParam1 == 7)
                {
                    return 5;
                }
                else if (iParam1 == 8)
                {
                    return 1;
                }
            }
            else if (func_5591(iParam0) == 97)
            {
                if (iParam1 == 0)
                {
                    return 0;
                }
                else if (iParam1 == 1)
                {
                    return 1;
                }
                else if (iParam1 == 2)
                {
                    return 2;
                }
                else if (iParam1 == 3)
                {
                    return 3;
                }
                else if (iParam1 == 4)
                {
                    return 4;
                }
                else if (iParam1 == 5)
                {
                    return 5;
                }
                else if (iParam1 == 6)
                {
                    return 6;
                }
                else if (iParam1 == 7)
                {
                    return 7;
                }
                else if (iParam1 == 8)
                {
                    return 8;
                }
            }
            if (iParam1 == -1)
            {
                return -1;
            }
            return 0;
        }


        Vector3 GetPosition(int id)
        {
            return id switch
            {
                91 => new(254.0506f, -1809.112f, 26.2643f),
                92 => new(-1471.8319f, -920.1343f, 9.0249f),
                93 => new(37.272f, -1029.3018f, 28.5669f),
                94 => new(46.7547f, 2789.6455f, 57.1054f),
                95 => new(-342.0963f, 6065.6294f, 30.5093f),
                96 => new(1737.9225f, 3709.1099f, 33.1355f),
                97 => new(939.6351f, -1458.9806f, 30.47f),
                98 => new(189.8949f, 309.2079f, 104.3896f),
                99 => new(-22.0633f, -192.056f, 51.3638f),
                100 => new(2471.9436f, 4110.662f, 37.0647f),
                101 => new(-39.1115f, 6420.4746f, 30.6905f),
                102 => new(-1134.7958f, -1568.8192f, 3.4081f),
                _ => new(),
            };
        }

        public int GetPrice(int id)
        {
            return id switch
            {
                91 => 420000,
                92 => 365000,
                93 => 455000,
                94 => 200000,
                95 => 242000,
                96 => 210000,
                97 => 449000,
                98 => 472000,
                99 => 495000,
                100 => 225000,
                101 => 250000,
                102 => 395000,
                _ => 0,
            };
        }

        int func_5723(int iParam0)//Position - 0x1D3A85
        {
            int iVar0;
            bool bVar1;
            int iVar2;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            iVar2 = func_5724(iParam0, iVar0, bVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar2))
            {
                return NetGameserverGetPrice((uint)iVar2, 426439576, true); //(uint)GetHashKey("CATEGORY_PROPERTIE")
            }
            return GetPrice(iParam0);
        }

        internal bool func_5731(int iParam0)//Position - 0x1D43B6
        {
            if (iParam0 == 31)
            {
                return true;
            }
            if (VehicleSitesHandler.func_5728())
            {
                if (func_5727(iParam0))
                {
                    return true;
                }
            }
            return false;
        }
        bool func_5727(int iParam0)//Position - 0x1D4307
        {
            if (VehicleSitesHandler.func_5728())
            {
                if (((iParam0 == 88 || iParam0 == 94) || iParam0 == 18) || iParam0 == 56)
                {
                    return true;
                }
            }
            return false;
        }

        int func_5724(int iParam0, int iParam1, bool bParam2)//Position - 0x1D3AE5
        {
            string sVar0 = "";

            func_5725(ref sVar0, iParam0, iParam1, bParam2);
            return GetHashKey(sVar0);
        }

        void func_5725(ref string sParam0, int iParam1, int iParam2, bool bParam3)//Position - 0x1D3AFF
        {
            string Var0;

            //sParam0 = "FACTORY_INDEX_";
            Var0 = func_5726(iParam1);
            sParam0 += "PR_";
            sParam0 += Var0;
            sParam0 += "_t0_v";
            sParam0 += iParam2;
            if (bParam3)
            {
                sParam0 += "_CESP";
            }
        }

        string func_5726(int iParam0)//Position - 0x1D3B46
        {

            string Var0 = "";

            switch (iParam0)
            {
                case 1:
                    Var0 = "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */;
                    break;

                case 2:
                    Var0 = "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */;
                    break;

                case 3:
                    Var0 = "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */;
                    break;

                case 4:
                    Var0 = "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */;
                    break;

                case 5:
                    Var0 = "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */;
                    break;

                case 6:
                    Var0 = "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */;
                    break;

                case 7:
                    Var0 = "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */;
                    break;

                case 8:
                    Var0 = "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */;
                    break;

                case 9:
                    Var0 = "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */;
                    break;

                case 10:
                    Var0 = "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */;
                    break;

                case 11:
                    Var0 = "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */;
                    break;

                case 12:
                    Var0 = "MP_PROP_12" /* GXT: The Royale, Apt 19 */;
                    break;

                case 13:
                    Var0 = "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */;
                    break;

                case 14:
                    Var0 = "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */;
                    break;

                case 15:
                    Var0 = "MP_PROP_15" /* GXT: 0325 South Rockford Dr */;
                    break;

                case 16:
                    Var0 = "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */;
                    break;

                case 17:
                    Var0 = "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */;
                    break;

                case 18:
                    Var0 = "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */;
                    break;

                case 19:
                    Var0 = "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */;
                    break;

                case 20:
                    Var0 = "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */;
                    break;

                case 21:
                    Var0 = "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */;
                    break;

                case 22:
                    Var0 = "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */;
                    break;

                case 23:
                    Var0 = "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */;
                    break;

                case 24:
                    Var0 = "MP_PROP_24" /* GXT: 0120 Murrieta Heights */;
                    break;

                case 25:
                    Var0 = "MP_PROP_25" /* GXT: Unit 14 Popular St */;
                    break;

                case 26:
                    Var0 = "MP_PROP_26" /* GXT: Unit 2 Popular St */;
                    break;

                case 27:
                    Var0 = "MP_PROP_27" /* GXT: 331 Supply St */;
                    break;

                case 28:
                    Var0 = "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */;
                    break;

                case 29:
                    Var0 = "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */;
                    break;

                case 30:
                    Var0 = "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */;
                    break;

                case 31:
                    Var0 = "MP_PROP_31" /* GXT: Unit 124 Popular St */;
                    break;

                case 32:
                    Var0 = "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */;
                    break;

                case 33:
                    Var0 = "MP_PROP_33" /* GXT: 0432 Davis Ave */;
                    break;

                case 34:
                    Var0 = "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */;
                    break;

                case 35:
                    Var0 = "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */;
                    break;

                case 36:
                    Var0 = "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */;
                    break;

                case 37:
                    Var0 = "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */;
                    break;

                case 38:
                    Var0 = "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */;
                    break;

                case 39:
                    Var0 = "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */;
                    break;

                case 40:
                    Var0 = "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */;
                    break;

                case 41:
                    Var0 = "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */;
                    break;

                case 42:
                    Var0 = "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */;
                    break;

                case 43:
                    Var0 = "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */;
                    break;

                case 44:
                    Var0 = "MP_PROP_44" /* GXT: 142 Paleto Blvd */;
                    break;

                case 45:
                    Var0 = "MP_PROP_45" /* GXT: 1 Strawberry Ave */;
                    break;

                case 46:
                    Var0 = "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */;
                    break;

                case 47:
                    Var0 = "MP_PROP_48" /* GXT: 1920 Senora Way */;
                    break;

                case 48:
                    Var0 = "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */;
                    break;

                case 49:
                    Var0 = "MP_PROP_50" /* GXT: 197 Route 68 */;
                    break;

                case 50:
                    Var0 = "MP_PROP_51" /* GXT: 870 Route 68 Approach */;
                    break;

                case 51:
                    Var0 = "MP_PROP_52" /* GXT: 1200 Route 68 */;
                    break;

                case 52:
                    Var0 = "MP_PROP_57" /* GXT: 8754 Route 68 */;
                    break;

                case 53:
                    Var0 = "MP_PROP_59" /* GXT: 1905 Davis Ave */;
                    break;

                case 54:
                    Var0 = "MP_PROP_60" /* GXT: 1623 South Shambles St */;
                    break;

                case 55:
                    Var0 = "MP_PROP_61" /* GXT: 4531 Dry Dock St */;
                    break;

                case 56:
                    Var0 = "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */;
                    break;

                case 57:
                    Var0 = "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */;
                    break;

                case 58:
                    Var0 = "MP_PROP_64" /* GXT: Garage Innocence Blvd */;
                    break;

                case 59:
                    Var0 = "MP_PROP_65" /* GXT: 634 Blvd Del Perro */;
                    break;

                case 60:
                    Var0 = "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */;
                    break;

                case 61:
                    Var0 = "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */;
                    break;

                case 62:
                    Var0 = "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */;
                    break;

                case 63:
                    Var0 = "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */;
                    break;

                case 64:
                    Var0 = "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */;
                    break;

                case 65:
                    Var0 = "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */;
                    break;

                case 66:
                    Var0 = "MP_PROP_72" /* GXT: 4 Hangman Ave */;
                    break;

                case 67:
                    Var0 = "MP_PROP_73" /* GXT: 12 Sustancia Rd */;
                    break;

                case 68:
                    Var0 = "MP_PROP_74" /* GXT: 4584 Procopio Dr */;
                    break;

                case 69:
                    Var0 = "MP_PROP_75" /* GXT: 4401 Procopio Dr */;
                    break;

                case 70:
                    Var0 = "MP_PROP_76" /* GXT: 0232 Paleto Blvd */;
                    break;

                case 71:
                    Var0 = "MP_PROP_77" /* GXT: 140 Zancudo Ave */;
                    break;

                case 72:
                    Var0 = "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */;
                    break;

                case 83:
                    Var0 = "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */;
                    break;

                case 84:
                    Var0 = "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */;
                    break;

                case 85:
                    Var0 = "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */;
                    break;

                case 73:
                    Var0 = "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */;
                    break;

                case 74:
                    Var0 = "MP_PROP_84" /* GXT: 2044 North Conker Avenue */;
                    break;

                case 75:
                    Var0 = "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */;
                    break;

                case 76:
                    Var0 = "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */;
                    break;

                case 77:
                    Var0 = "MP_PROP_87" /* GXT: 3677 Whispymound Drive */;
                    break;

                case 78:
                    Var0 = "MP_PROP_89" /* GXT: 2117 Milton Road */;
                    break;

                case 79:
                    Var0 = "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */;
                    break;

                case 80:
                    Var0 = "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */;
                    break;

                case 81:
                    Var0 = "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */;
                    break;

                case 82:
                    Var0 = "MP_PROP_95" /* GXT: 2045 North Conker Avenue */;
                    break;

                case 86:
                    Var0 = "PM_SPAWN_Y" /* GXT: Private Yacht */;
                    break;

                case 87:
                    Var0 = "MP_PROP_OFF1" /* GXT: Lombank West */;
                    break;

                case 88:
                    Var0 = "MP_PROP_OFF2" /* GXT: Maze Bank West */;
                    break;

                case 89:
                    Var0 = "MP_PROP_OFF3" /* GXT: Arcadius Business Center */;
                    break;

                case 90:
                    Var0 = "MP_PROP_OFF4" /* GXT: Maze Bank Tower */;
                    break;

                case 91:
                    Var0 = "MP_PROP_CLUBH1" /* GXT: Rancho Clubhouse */;
                    break;

                case 92:
                    Var0 = "MP_PROP_CLUBH2" /* GXT: Del Perro Beach Clubhouse */;
                    break;

                case 93:
                    Var0 = "MP_PROP_CLUBH3" /* GXT: Pillbox Hill Clubhouse */;
                    break;

                case 94:
                    Var0 = "MP_PROP_CLUBH4" /* GXT: Great Chaparral Clubhouse */;
                    break;

                case 95:
                    Var0 = "MP_PROP_CLUBH5" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 96:
                    Var0 = "MP_PROP_CLUBH6" /* GXT: Sandy Shores Clubhouse */;
                    break;

                case 97:
                    Var0 = "MP_PROP_CLUBH7" /* GXT: La Mesa Clubhouse */;
                    break;

                case 98:
                    Var0 = "MP_PROP_CLUBH8" /* GXT: Downtown Vinewood Clubhouse */;
                    break;

                case 99:
                    Var0 = "MP_PROP_CLUBH9" /* GXT: Hawick Clubhouse */;
                    break;

                case 100:
                    Var0 = "MP_PROP_CLUBH10" /* GXT: Grapeseed Clubhouse */;
                    break;

                case 101:
                    Var0 = "MP_PROP_CLUBH11" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 102:
                    Var0 = "MP_PROP_CLUBH12" /* GXT: Vespucci Beach Clubhouse */;
                    break;

                case 103:
                case 106:
                case 109:
                case 112:
                    Var0 = "MP_PROP_OFFG1" /* GXT: Office Garage 1 */;
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    Var0 = "MP_PROP_OFFG2" /* GXT: Office Garage 2 */;
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    Var0 = "MP_PROP_OFFG3" /* GXT: Office Garage 3 */;
                    break;

                case 115:
                    Var0 = "IE_WARE_1" /* GXT: Vehicle Warehouse */;
                    break;
            }
            return Var0;
        }

        int func_6668(int iParam0, int iParam1)//Position - 0x2129BF
        {
            switch (iParam0)
            {
                case 0:
                    if (iParam1 == 0)
                    {
                        return 74000;
                    }
                    else if (iParam1 == 1)
                    {
                        return 138000;
                    }
                    return 0;

                case 1:
                    if (iParam1 == 0)
                    {
                        return 45000;
                    }
                    else if (iParam1 == 1)
                    {
                        return 98000;
                    }
                    return 0;

                case 2:
                    if (iParam1 == 0)
                    {
                        return 81000;
                    }
                    else if (iParam1 == 1)
                    {
                        return 164000;
                    }
                    return 0;

                case 3:
                    return 0;
                    break;

                case 4:
                    return 50000;

                case 5:
                    return 0;

                case 6:
                    switch (iParam1)
                    {
                        case 0:
                            return 100000;

                        case 1:
                            return 50000;

                        case 2:
                            return 51500;

                        case 3:
                            return 53000;

                        case 4:
                            return 54500;

                        case 5:
                            return 56000;

                        case 6:
                            return 57500;

                        case 7:
                            return 59000;

                        case 8:
                            return 60500;

                        case 9:
                            return 62000;

                        case 10:
                            return 63500;

                        case 11:
                            return 65000;

                        case 12:
                            return 70000;

                        case 13:
                            return 75000;

                        case 14:
                            return 80000;
                    }
                    break;

                case 7:
                    return 0;

                case 8:
                    return 320000;

                case 9:
                    return 530000;

                case 10:
                    return 50000;
            }
            return 0;
        }

        int func_5718(int iParam0, int iParam1)//Position - 0x1D3499
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            iVar0 = iParam1;
            if (iVar0 == -1)
            {
                iVar0 = 0;
            }
            func_5597(ref sVar1, iParam0, iVar0, 0);
            iVar17 = GetHashKey(sVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = NetGameserverGetPrice((uint)iVar17, (uint)GetHashKey("CATEGORY_PROPERTY_INTERIOR"), true);
                return iVar18;
            }

            switch (iParam0)
            {
                case 0:
                    if (iParam1 == 0)
                    {
                        return Tunables.Global_262145.Value<int>("f_18184") /* Tunable: BIKER_CLUBHOUSE_STYLE_WALL_STYLE_A */;
                    }
                    else if (iParam1 == 1)
                    {
                        return Tunables.Global_262145.Value<int>("f_18185") /* Tunable: BIKER_CLUBHOUSE_STYLE_WALL_STYLE_B */;
                    }
                    return 0;

                case 1:
                    if (iParam1 == 0)
                    {
                        return Tunables.Global_262145.Value<int>("f_18186") /* Tunable: BIKER_CLUBHOUSE_STYLE_WALL_HANGING_A */;
                    }
                    else if (iParam1 == 1)
                    {
                        return Tunables.Global_262145.Value<int>("f_18187") /* Tunable: BIKER_CLUBHOUSE_STYLE_WALL_HANGING_B */;
                    }
                    return 0;

                case 2:
                    if (iParam1 == 0)
                    {
                        return Tunables.Global_262145.Value<int>("f_18188") /* Tunable: BIKER_CLUBHOUSE_STYLE_FURNITURE_OPTION_A */;
                    }
                    else if (iParam1 == 1)
                    {
                        return Tunables.Global_262145.Value<int>("f_18189") /* Tunable: BIKER_CLUBHOUSE_STYLE_FURNITURE_OPTION_B */;
                    }
                    return 0;

                case 3:
                    return 0;

                case 4:
                    return Tunables.Global_262145.Value<int>("f_18206") /* Tunable: BIKER_CLUBHOUSE_CLUB_NAME_FONT */;

                case 5:
                    return 0;

                case 6:
                    switch (iParam1)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18190") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_CREW */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18191") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_1 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18192") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_2 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_18193") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_3 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_18194") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_4 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_18195") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_5 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_18196") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_6 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_18197") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_7 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_18198") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_8 */;

                        case 9:
                            return Tunables.Global_262145.Value<int>("f_18199") /* Tunable: BIKER_CLUBHOUSE_CLUB_SIGNAGE_9 */;
                    }
                    break;

                case 7:
                    return 0;

                case 8:
                    return Tunables.Global_262145.Value<int>("f_18207") /* Tunable: BIKER_CLUBHOUSE_GUN_LOCKER */;

                case 9:
                    return Tunables.Global_262145.Value<int>("f_18208") /* Tunable: BIKER_CLUBHOUSE_CUSTOM_BIKE_SHOP */;

                case 10:
                    return Tunables.Global_262145.Value<int>("f_18205") /* Tunable: BIKER_CLUBHOUSE_CLUB_NAME */;
            }
            return 0;
        }
        void func_5597(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1CE463
        {
            string cVar0 = "";

            switch (iParam1)
            {
                case 0:
                    cVar0 = "PM_BWALL_";
                    cVar0 += iParam2;
                    break;

                case 1:
                    cVar0 = "PM_BHANGING_";
                    cVar0 += iParam2;
                    break;

                case 2:
                    cVar0 = "PM_BFURNITURE_";
                    cVar0 += iParam2;
                    break;

                case 4:
                    cVar0 = "PM_BFONT_";
                    cVar0 += iParam2;
                    break;

                case 5:
                    cVar0 = "PM_BFCOLOUR_";
                    cVar0 += iParam2;
                    break;

                case 6:
                    cVar0 = "PM_BEMBLEM_";
                    cVar0 += iParam2;
                    break;

                case 7:
                    cVar0 = "PM_BHIDESINAGE_";
                    cVar0 += iParam2;
                    break;

                case 8:
                    cVar0 = "PM_BGUNLOCK_";
                    cVar0 += iParam2;
                    break;

                case 9:
                    cVar0 = "PM_BGARAGE_";
                    cVar0 += iParam2;
                    break;

                case 10:
                    cVar0 = "PM_BNAME_";
                    cVar0 += iParam2;
                    break;
            }
            sParam0 = "PR_";
            sParam0 += cVar0;
            sParam0 += "_t";
            sParam0 += iParam3;
            sParam0 += "_v0";
        }
        void func_5589(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1CD84F
        {
            string cVar0 = "";

            cVar0 = func_5590(iParam1, iParam2);
            sParam0 = "PR_";
            sParam0 += cVar0;
            sParam0 += "_t";
            sParam0 += iParam3;
            sParam0 += "_v0";
        }
        int func_6347(int iParam0, int iParam1)//Position - 0x1FF37B
        {
            int iVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            iVar0 = 0;
            func_5589(ref sVar1, iParam0, iParam1, iVar0);
            iVar17 = GetHashKey(sVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = NetGameserverGetPrice((uint)iVar17, (uint)GetHashKey("CATEGORY_PROPERTY_INTERIOR"), true);
                return iVar18;
            }

            switch (func_5591(iParam1))
            {
                case 83:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_13498") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MODERN */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_13499") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MOODY */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_13500") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_VIBRANT */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_13501") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_SHARP */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_13502") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_MONOCHROME */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_13503") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_SEDUCTIVE */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_13504") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_REGAL */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_13505") /* Tunable: APARTMENT_CAR_MODSHIGH_END_INTERIOR_AQUA */;
                    }
                    break;
                case 88:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_16079") /* Tunable: DYNASTY8_OFFICE_DECOR_WARM */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_16080") /* Tunable: DYNASTY8_OFFICE_DECOR_CLASSICAL */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_16081") /* Tunable: DYNASTY8_OFFICE_DECOR_VINTAGE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_16078") /* Tunable: DYNASTY8_OFFICE_DECOR_CONTRAST */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_16076") /* Tunable: DYNASTY8_OFFICE_DECOR_RICH */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_16077") /* Tunable: DYNASTY8_OFFICE_DECOR_COOL */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_16082") /* Tunable: DYNASTY8_OFFICE_DECOR_ICE */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_16083") /* Tunable: DYNASTY8_OFFICE_DECOR_CONSERVATIVE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_16084") /* Tunable: DYNASTY8_OFFICE_DECOR_POLISHED */;
                    }
                    break;
                case 91:
                case 97:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18175") /* Tunable: BIKER_CLUBHOUSE_MURAL_1 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18176") /* Tunable: BIKER_CLUBHOUSE_MURAL_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18177") /* Tunable: BIKER_CLUBHOUSE_MURAL_3 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_18178") /* Tunable: BIKER_CLUBHOUSE_MURAL_4 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_18179") /* Tunable: BIKER_CLUBHOUSE_MURAL_5 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_18180") /* Tunable: BIKER_CLUBHOUSE_MURAL_6 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_18181") /* Tunable: BIKER_CLUBHOUSE_MURAL_7 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_18182") /* Tunable: BIKER_CLUBHOUSE_MURAL_8 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_18183") /* Tunable: BIKER_CLUBHOUSE_MURAL_9 */;
                    }
                    break;
                case 109:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_19730") /* Tunable: IMPEXP_GARAGE_INTERIOR1_COST */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_19731") /* Tunable: IMPEXP_GARAGE_INTERIOR2_COST */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_19732") /* Tunable: IMPEXP_GARAGE_INTERIOR3_COST */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_19733") /* Tunable: IMPEXP_GARAGE_INTERIOR4_COST */;
                    }

                    break;
            }
            return 0;
        }
        string func_5590(int iParam0, int iParam1)//Position - 0x1CD889
        {
            if (func_5591(iParam1) == 83)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_APT_VAR_0" /* GXT: Modern */;
                    case 1:
                        return "PM_APT_VAR_1" /* GXT: Moody */;
                    case 2:
                        return "PM_APT_VAR_2" /* GXT: Vibrant */;
                    case 3:
                        return "PM_APT_VAR_3" /* GXT: Sharp */;
                    case 4:
                        return "PM_APT_VAR_4" /* GXT: Monochrome */;
                    case 5:
                        return "PM_APT_VAR_5" /* GXT: Seductive */;
                    case 6:
                        return "PM_APT_VAR_6" /* GXT: Regal */;
                    case 7:
                        return "PM_APT_VAR_7" /* GXT: Aqua */;
                }
            }
            else if (func_5591(iParam1) == 88)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_OFF_VAR_3" /* GXT: Old Spice: Warm */;
                    case 1:
                        return "PM_OFF_VAR_4" /* GXT: Old Spice: Classical */;
                    case 2:
                        return "PM_OFF_VAR_5" /* GXT: Old Spice: Vintage */;
                    case 3:
                        return "PM_OFF_VAR_2" /* GXT: Executive: Contrast */;
                    case 4:
                        return "PM_OFF_VAR_0" /* GXT: Executive: Rich */;
                    case 5:
                        return "PM_OFF_VAR_1" /* GXT: Executive: Cool */;
                    case 6:
                        return "PM_OFF_VAR_6" /* GXT: Power Broker: Ice */;
                    case 7:
                        return "PM_OFF_VAR_7" /* GXT: Power Broker: Conservative */;
                    case 8:
                        return "PM_OFF_VAR_8" /* GXT: Power Broker: Polished */;
                }
            }
            else if (func_5591(iParam1) == 91 || func_5591(iParam1) == 97)
            {
                switch (iParam0)
                {
                    case 0:
                        return "FC_MURAL_0" /* GXT: Mural 1 */;
                    case 1:
                        return "FC_MURAL_1" /* GXT: Mural 2 */;
                    case 2:
                        return "FC_MURAL_2" /* GXT: Mural 3 */;
                    case 3:
                        return "FC_MURAL_3" /* GXT: Mural 4 */;
                    case 4:
                        return "FC_MURAL_4" /* GXT: Mural 5 */;
                    case 5:
                        return "FC_MURAL_5" /* GXT: Mural 6 */;
                    case 6:
                        return "FC_MURAL_6" /* GXT: Mural 7 */;
                    case 7:
                        return "FC_MURAL_7" /* GXT: Mural 8 */;
                    case 8:
                        return "FC_MURAL_8" /* GXT: Mural 9 */;
                }
            }
            else if (func_5591(iParam1) == 109)
            {
                switch (iParam0)
                {
                    case 0:
                        return "PM_OFF_GAR_0" /* GXT: Garage Interior 1 */;
                    case 1:
                        return "PM_OFF_GAR_1" /* GXT: Garage Interior 2 */;
                    case 2:
                        return "PM_OFF_GAR_2" /* GXT: Garage Interior 3 */;
                    case 3:
                        return "PM_OFF_GAR_3" /* GXT: Garage Interior 4 */;
                }
            }
            return "NONE" /* GXT: None */;
        }

        static int func_5591(int iParam0)//Position - 0x1CDAF5
        {
            return iParam0 switch
            {
                1 or 2 or 3 or 4 or 5 or 6 or 7 => 1,
                8 or 9 or 10 or 11 or 12 or 13 or 14 or 15 or 16 or 69 or 68 or 66 or 67 => 8,
                17 or 18 or 19 or 20 or 21 or 22 or 23 or 70 or 71 or 72 => 17,
                61 or 62 or 63 or 64 or 65 => 61,
                73 or 74 or 75 or 76 => 73,
                77 or 78 or 79 or 80 or 81 or 82 => 77,
                83 or 84 or 85 => 83,
                86 => 86,
                87 or 88 or 89 or 90 => 88,
                91 or 92 or 93 or 94 or 95 or 96 => 91,
                97 or 98 or 99 or 100 or 101 or 102 => 97,
                103 or 106 or 109 or 112 or 104 or 107 or 110 or 113 or 105 or 108 or 111 or 114 => 109,
                _ => -1,
            };
        }


    }
}

