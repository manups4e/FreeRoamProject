using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    public class Bunker : PropertyBase
    {
        /// <summary>
        /// Returns a label which can be read by the scaleform, you can create your own using AddTextEntry, defaults MP_BUNKER_1-12
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Label(int n)
        {
            return n switch
            {
                1 => "MP_BUNKER_1",
                2 => "MP_BUNKER_2",
                3 => "MP_BUNKER_3",
                4 => "MP_BUNKER_4",
                5 => "MP_BUNKER_5",
                6 => "MP_BUNKER_6",
                7 => "MP_BUNKER_7",
                8 => "MP_BUNKER_9",
                9 => "MP_BUNKER_10",
                10 => "MP_BUNKER_11",
                11 => "MP_BUNKER_12",
                _ => $"MP_BUNKER_{n}",
            };
        }

        /// <summary>
        /// Returns a description which can be read by the scaleform, you can create your own using AddTextEntry using MP_BWH_WEA_1D-12D or higher
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Description(int n)
        {
            return n switch
            {
                1 => "MP_BWH_WEA_0D",
                2 => "MP_BWH_WEA_1D",
                3 => "MP_BWH_WEA_2D",
                4 => "MP_BWH_WEA_3D",
                5 => "MP_BWH_WEA_4D",
                6 => "MP_BWH_WEA_5D",
                7 => "MP_BWH_WEA_6D",
                8 => "MP_BWH_WEA_7D",
                9 => "MP_BWH_WEA_8D",
                10 => "MP_BWH_WEA_9D",
                11 => "MP_BWH_WEA_10D",
                _ => $"MP_BWH_WEA_{n}D",
            };
        }
        public string Address => "";

        /// <summary>
        /// Returns a texture which can be used by the scaleform, you can create your own with AddReplaceTexture using MP_BNKR1-12 or create more and stream them.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string TXD(int n)
        {
            return n switch
            {
                21 => "MP_BNKR1",
                22 => "MP_BNKR2",
                23 => "MP_BNKR3",
                24 => "MP_BNKR4",
                25 => "MP_BNKR5",
                26 => "MP_BNKR6",
                27 => "MP_BNKR7",
                28 => "MP_BNKR9",
                29 => "MP_BNKR10",
                30 => "MP_BNKR11",
                31 => "MP_BNKR8",
                _ => $"MP_BNKR{n}",
            };
        }

        public eOfficePropertyType OfficeType { get; private set; } = eOfficePropertyType.Bunker;

        public int[] StyleCost = [0, 0];
        public int QuartersCost = 0;
        public int[] FiringRangeCost = [0, 0];
        public int GunLockerCost = 0;
        public int[] TransportationCost = [0, 0];

        public int[] StyleSaleCost = new int[2] { -1, -1 };
        public int QuartersSaleCost = -1;
        public int[] FiringRangeSaleCost = new int[2] { -1, -1 };
        public int GunLockerSaleCost = -1;
        public int[] TransportationSaleCost = [-1, -1];

        public bool StarterPack = false;

        public Bunker(int slot, int id) : base(slot, id)
        {
            Slot = slot;
            Id = id;
            Position = GetDefaultPosition(GetDefaultId(id));
            if (id == 23)
            {
                Position = new Vector3(19.5202f, 2968.9736f, 52.0321f);
            }
            BaseCost = func_5785(id);
            StyleCost = [func_5778(3, Id), func_5778(4, Id), func_5778(5, Id)];
            QuartersCost = func_5778(6, Id);
            FiringRangeCost = [func_5778(7, Id), func_5778(8, Id)];
            GunLockerCost = func_5778(9, Id);
            TransportationCost = [func_5778(10, Id), func_5778(11, Id)];

        }

        public void AddToScaleform(ScaleformWideScreen scaleform)
        {
            // These are near the same for all offices in setup
            API.BeginScaleformMovieMethod(scaleform.Handle, SET_DATA_SLOT);
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(Id);
            Tools.SetScaleformString(Label(Id));
            API.ScaleformMovieMethodAddParamInt((int)OfficeType); // TYPE
            API.ScaleformMovieMethodAddParamFloat(Position.X); // X
            API.ScaleformMovieMethodAddParamFloat(Position.Y); // X
            Tools.SetTextureDictionary(TXD(Id)); // TXD
            Tools.SetScaleformString(Description(Id)); // DESCRIPTION
            Tools.SetScaleformString(Address); // ADDRESS
            API.ScaleformMovieMethodAddParamInt(BaseCost); // BASE_COST
            // end of simalarities
            API.ScaleformMovieMethodAddParamInt(StyleCost[0]);
            API.ScaleformMovieMethodAddParamInt(StyleCost[1]);
            API.ScaleformMovieMethodAddParamInt(StyleCost[2]);
            API.ScaleformMovieMethodAddParamInt(QuartersCost);
            API.ScaleformMovieMethodAddParamInt(FiringRangeCost[0]);
            API.ScaleformMovieMethodAddParamInt(FiringRangeCost[1]);
            API.ScaleformMovieMethodAddParamInt(GunLockerCost);
            API.ScaleformMovieMethodAddParamInt(TransportationCost[0]);
            API.ScaleformMovieMethodAddParamInt(TransportationCost[1]);
            API.EndScaleformMovieMethod();

            API.BeginScaleformMovieMethod(scaleform.Handle, APPEND_OFFICE_DATA_SLOT);
            API.ScaleformMovieMethodAddParamInt(Slot);
            API.ScaleformMovieMethodAddParamInt(BaseSaleCost);
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[0]);
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[1]);
            API.ScaleformMovieMethodAddParamInt(StyleSaleCost[2]);
            API.ScaleformMovieMethodAddParamInt(QuartersSaleCost);
            API.ScaleformMovieMethodAddParamInt(FiringRangeSaleCost[0]);
            API.ScaleformMovieMethodAddParamInt(FiringRangeSaleCost[1]);
            API.ScaleformMovieMethodAddParamInt(GunLockerSaleCost);
            API.ScaleformMovieMethodAddParamInt(TransportationSaleCost[0]);
            API.ScaleformMovieMethodAddParamInt(TransportationSaleCost[1]);
            API.ScaleformMovieMethodAddParamBool(StarterPack);
            API.EndScaleformMovieMethod();
        }

        public int GetDefaultId(int bunker)
        {
            return bunker switch
            {
                21 => 70,
                22 => 71,
                23 => 72,
                24 => 73,
                25 => 74,
                26 => 75,
                27 => 76,
                28 => 77,
                29 => 78,
                30 => 79,
                31 => 80,
                _ => -1,
            };
        }

        public Vector3 GetDefaultPosition(int bunker)//Position - 0x279A56
        {
            return bunker switch
            {
                70 => new Vector3(492.8395f, 3014.057f, 39.9793f),
                71 => new Vector3(849.603f, 3021.697f, 40.3076f),
                72 => new Vector3(19.5202f, 2968.9736f, 52.0321f),
                73 => new Vector3(1572.0778f, 2226.001f, 77.2829f),
                74 => new Vector3(2110.019f, 3326.12f, 44.3526f),
                75 => new Vector3(2489.36f, 3162.1199f, 48.0015f),
                76 => new Vector3(1801.273f, 4705.483f, 38.8253f),
                77 => new Vector3(-763.3162f, 5941.4116f, 19.2857f),
                78 => new Vector3(-387.287f, 4334.919f, 54.7422f),
                79 => new Vector3(-3032.7036f, 3334.6924f, 9.2599f),
                80 => new Vector3(-3157.5989f, 1376.6952f, 15.866f),
                _ => Vector3.Zero,
            };

        }
        int func_5778(int iParam0, int iParam1)//Position - 0x1D6623
        {
            int iVar0;
            int iVar1;
            int iVar2;
            int iVar3;
            string sVar4 = "";
            int iVar20;
            int iVar21;

            iVar0 = func_5152(iParam1);
            Debug.WriteLine($"iVar0:{iVar0}, iParam0:{iParam0}");
            switch (iVar0)
            {
                case 0:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18249") /* Tunable: BIKER_FORGERY_BUSINESS_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18250") /* Tunable: BIKER_FORGERY_BUSINESS_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18251") /* Tunable: BIKER_FORGERY_BUSINESS_STAFF_UPGRADE */;
                    }
                    break;

                case 2:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18252") /* Tunable: BIKER_COUNTERFEITBUSINESS_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18253") /* Tunable: BIKER_COUNTERFEITBUSINESS_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18254") /* Tunable: BIKER_COUNTERFEITBUSINESS_STAFF_UPGRADE */;
                    }
                    break;

                case 4:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18255") /* Tunable: BIKER_COCAINE_BUSINESS_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18256") /* Tunable: BIKER_COCAINE_BUSINESS_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18257") /* Tunable: BIKER_COCAINE_BUSINESS_STAFF_UPGRADE */;
                    }
                    break;

                case 3:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18258") /* Tunable: BIKER_METH_BUSINESS_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18259") /* Tunable: BIKER_METH_BUSINESS_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18260") /* Tunable: BIKER_METH_BUSINESS_STAFF_UPGRADE */;
                    }
                    break;

                case 1:
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_18261") /* Tunable: BIKER_WEED_BUSINESS_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_18262") /* Tunable: BIKER_WEED_BUSINESS_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_18263") /* Tunable: BIKER_WEED_BUSINESS_STAFF_UPGRADE */;
                    }
                    break;

                case 5:
                    iVar1 = -1; //func_4415(API.PlayerId()) the owned id i think.. should be -1 if none.. or 0?

                    iVar2 = 0;
                    iVar3 = 0;
                    if (iParam0 == 8)
                    {
                        iVar2 = 2;
                        iVar3 = func_5505(iVar2, iParam1, iVar1);
                    }
                    else if (iParam0 == 7)
                    {
                        iVar2 = 1;
                        iVar3 = func_5505(iVar2, iParam1, iVar1);
                    }
                    else if (iParam0 == 5 || iParam0 == 11)
                    {
                        iVar2 = 2;
                    }
                    else if (iParam0 == 4 || iParam0 == 10 || iParam0 == 6 || iParam0 == 9 || iParam0 == 0 || iParam0 == 2 || iParam0 == 1)
                    {
                        iVar2 = 1;
                    }
                    func_5507(ref sVar4, iVar0, iParam0, iVar2, iVar3);
                    iVar20 = API.GetHashKey(sVar4);
                    if (API.NetGameserverCatalogItemExistsHash((uint)iVar20))
                    {
                        iVar21 = API.NetGameserverGetPrice((uint)iVar20, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
                        return iVar21;
                    }
                    switch (iParam0)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_21615") /* Tunable: GR_BUNKER_GUNRUNNING_BUSINESS_UPGRADES_EQUIPMENT_UPGRADE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_21616") /* Tunable: GR_BUNKER_GUNRUNNING_BUSINESS_UPGRADES_SECURITY_UPGRADE */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_21617") /* Tunable: GR_BUNKER_GUNRUNNING_BUSINESS_UPGRADES_STAFF_UPGRADE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_21605") /* Tunable: GR_BUNKER_STYLE_1 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_21606") /* Tunable: GR_BUNKER_STYLE_2 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_21607") /* Tunable: GR_BUNKER_STYLE_3 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_21608") /* Tunable: GR_BUNKER_ADD_ONS_PERSONAL_QUARTERS */;

                        case 7:
                            if (func_5505(1, iParam1, iVar1) == 0)
                            {
                                return Tunables.Global_262145.Value<int>("f_21609") /* Tunable: GR_BUNKER_ADD_ONS_FIRING_RANGE */;
                            }
                            else
                            {
                                return 0 + Tunables.Global_262145.Value<int>("f_21610") /* Tunable: GR_BUNKER_ADD_ONS_FIRING_RANGE_BLACK_TARGETS */;
                            }

                        case 8:
                            if (func_5505(2, iParam1, iVar1) == 0)
                            {
                                return Tunables.Global_262145.Value<int>("f_21609") /* Tunable: GR_BUNKER_ADD_ONS_FIRING_RANGE */ + Tunables.Global_262145.Value<int>("f_21611") /* Tunable: GR_BUNKER_ADD_ONS_FIRING_RANGE_WHITE_TARGETS */;
                            }
                            else
                            {
                                return 0 + Tunables.Global_262145.Value<int>("f_21611") /* Tunable: GR_BUNKER_ADD_ONS_FIRING_RANGE_WHITE_TARGETS */;
                            }

                        case 9:
                            return Tunables.Global_262145.Value<int>("f_21612") /* Tunable: GR_BUNKER_ADD_ONS_GUN_LOCKER */;

                        case 10:
                            return Tunables.Global_262145.Value<int>("f_21613") /* Tunable: GR_BUNKER_ADD_ONS_TRANSPORTATION_CADDY */;

                        case 11:
                            return Tunables.Global_262145.Value<int>("f_21614") /* Tunable: GR_BUNKER_ADD_ONS_TRANSPORTATION_UPDATED_CADDY */;
                    }
                    break;
            }
            return 0;
        }
        int func_5152(int iParam0)//Position - 0x1AAC57
        {
            return iParam0 switch
            {
                1 => 3,
                2 => 1,
                3 => 4,
                4 => 2,
                5 => 0,
                6 => 3,
                7 => 1,
                8 => 4,
                9 => 2,
                10 => 0,
                11 => 3,
                12 => 1,
                13 => 4,
                14 => 2,
                15 => 0,
                16 => 3,
                17 => 1,
                18 => 4,
                19 => 2,
                20 => 0,
                21 => 5,
                22 => 5,
                23 => 5,
                24 => 5,
                25 => 5,
                26 => 5,
                27 => 5,
                28 => 5,
                29 => 5,
                30 => 5,
                31 => 5,
                32 => 6,
                _ => -1,
            };
        }

        int func_5785(int iParam0)//Position - 0x1D6B3C
        {
            bool bVar0;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            bVar0 = false;
            if (VehicleSitesHandler.func_5728() && (iParam0 == 28 || iParam0 == 14))
            {
                bVar0 = true;
            }
            func_5509(ref sVar1, iParam0, bVar0);
            iVar17 = API.GetHashKey(sVar1);
            if (API.NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = API.NetGameserverGetPrice((uint)iVar17, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar18;
            }

            if (VehicleSitesHandler.func_5728() && (iParam0 == 28 || iParam0 == 14))
            {
                return 0;
            }
            switch (iParam0)
            {
                case 2:
                    return Tunables.Global_262145.Value<int>("f_18225") /* Tunable: BIKER_BUSINESS_PALETO_BAY_WEED_FARM */;

                case 1:
                    return Tunables.Global_262145.Value<int>("f_18221") /* Tunable: BIKER_BUSINESS_PALETO_BAY_METH_LAB */;

                case 3:
                    return Tunables.Global_262145.Value<int>("f_18217") /* Tunable: BIKER_BUSINESS_PALETO_BAY_COCAINE_LOCKUP */;

                case 5:
                    return Tunables.Global_262145.Value<int>("f_18209") /* Tunable: BIKER_BUSINESS_PALETO_BAY_DOCUMENT_FORGERY_OFFICE */;

                case 4:
                    return Tunables.Global_262145.Value<int>("f_18213") /* Tunable: BIKER_BUSINESS_PALETO_BAY_COUNTERFEIT_CASH_FACTOY */;

                case 7:
                    return Tunables.Global_262145.Value<int>("f_18226") /* Tunable: BIKER_BUSINESS_CITY_WEED_FARM */;

                case 6:
                    return Tunables.Global_262145.Value<int>("f_18222") /* Tunable: BIKER_BUSINESS_CITY_METH_LAB */;

                case 8:
                    return Tunables.Global_262145.Value<int>("f_18218") /* Tunable: BIKER_BUSINESS_CITY_COCAINE_LOCKUP */;

                case 10:
                    return Tunables.Global_262145.Value<int>("f_18210") /* Tunable: BIKER_BUSINESS_CITY_DOCUMENT_FORGERY_OFFICE */;

                case 9:
                    return Tunables.Global_262145.Value<int>("f_18214") /* Tunable: BIKER_BUSINESS_CITY_COUNTERFEIT_CASH_FACTOY */;

                case 12:
                    return Tunables.Global_262145.Value<int>("f_18227") /* Tunable: BIKER_BUSINESS_COUNTRYSIDE_WEED_FARM */;

                case 11:
                    return Tunables.Global_262145.Value<int>("f_18223") /* Tunable: BIKER_BUSINESS_COUNTRYSIDE_METH_LAB */;

                case 13:
                    return Tunables.Global_262145.Value<int>("f_18219") /* Tunable: BIKER_BUSINESS_COUNTRYSIDE_COCAINE_LOCKUP */;

                case 15:
                    return Tunables.Global_262145.Value<int>("f_18211") /* Tunable: BIKER_BUSINESS_COUNTRYSIDE_DOCUMENT_FORGERY_OFFICE */;

                case 14:
                    return Tunables.Global_262145.Value<int>("f_18215") /* Tunable: BIKER_BUSINESS_COUNTRYSIDE_COUNTERFEIT_CASH_FACTOY */;

                case 17:
                    return Tunables.Global_262145.Value<int>("f_18228") /* Tunable: BIKER_BUSINESS_ELYSIAN_WEED_FARM */;

                case 16:
                    return Tunables.Global_262145.Value<int>("f_18224") /* Tunable: BIKER_BUSINESS_ELYSIAN_METH_LAB */;

                case 18:
                    return Tunables.Global_262145.Value<int>("f_18220") /* Tunable: BIKER_BUSINESS_ELYSIAN_COCAINE_LOCKUP */;

                case 20:
                    return Tunables.Global_262145.Value<int>("f_18212") /* Tunable: BIKER_BUSINESS_ELYSIAN_DOCUMENT_FORGERY_OFFICE */;

                case 19:
                    return Tunables.Global_262145.Value<int>("f_18216") /* Tunable: BIKER_BUSINESS_ELYSIAN_COUNTERFEIT_CASH_FACTOY */;

                case 21:
                    return Tunables.Global_262145.Value<int>("f_21598") /* Tunable: GR_BUNKER_PROPERTY_GRAND_SENORA_OILFIELDS_BUNKER */;

                case 22:
                    return Tunables.Global_262145.Value<int>("f_21597") /* Tunable: GR_BUNKER_PROPERTY_GRAND_SENORA_DESERT_BUNKER */;

                case 23:
                    return Tunables.Global_262145.Value<int>("f_21599") /* Tunable: GR_BUNKER_PROPERTY_ROUTE_68_BUNKER */;

                case 24:
                    return Tunables.Global_262145.Value<int>("f_21594") /* Tunable: GR_BUNKER_PROPERTY_FARMHOUSE_BUNKER */;

                case 25:
                    return Tunables.Global_262145.Value<int>("f_21596") /* Tunable: GR_BUNKER_PROPERTY_SMOKE_TREE_ROAD_BUNKER */;

                case 26:
                    return Tunables.Global_262145.Value<int>("f_21595") /* Tunable: GR_BUNKER_PROPERTY_THOMSON_SCRAPYARD_BUNKER */;

                case 27:
                    return Tunables.Global_262145.Value<int>("f_21600") /* Tunable: GR_BUNKER_PROPERTY_GRAPESEED_BUNKER */;

                case 28:
                    return Tunables.Global_262145.Value<int>("f_21604") /* Tunable: GR_BUNKER_PROPERTY_PALETO_FOREST_BUNKER */;

                case 29:
                    return Tunables.Global_262145.Value<int>("f_21603") /* Tunable: GR_BUNKER_PROPERTY_RATON_CANYON_BUNKER */;

                case 30:
                    return Tunables.Global_262145.Value<int>("f_21602") /* Tunable: GR_BUNKER_PROPERTY_LAGO_ZANCUDO_BUNKER */;

                case 31:
                    return Tunables.Global_262145.Value<int>("f_21601") /* Tunable: GR_BUNKER_PROPERTY_CHUMASH_BUNKER */;

                case 32:
                    return Tunables.Global_262145.Value<int>("f_34172") /* Tunable: XM22_BIN_PRICE_BRICKADE2 */;
            }
            return 0;
        }

        string func_5786(int iParam0)//Position - 0x1D6DC0
        {
            string sVar0 = "";

            switch (iParam0)
            {
                case 2:
                    sVar0 = "MP_BWH_WEED_1" /* GXT: Mount Chiliad Weed Farm */;
                    break;

                case 1:
                    sVar0 = "MP_BWH_METH_1" /* GXT: Paleto Bay Meth Lab */;
                    break;

                case 3:
                    sVar0 = "MP_BWH_CRACK_1" /* GXT: Paleto Bay Cocaine Lockup */;
                    break;

                case 5:
                    sVar0 = "MP_BWH_FAKEID_1" /* GXT: Paleto Bay Forgery Office */;
                    break;

                case 4:
                    sVar0 = "MP_BWH_CASH_1" /* GXT: Paleto Bay Counterfeit Cash Factory */;
                    break;

                case 7:
                    sVar0 = "MP_BWH_WEED_2" /* GXT: Downtown Vinewood Weed Farm */;
                    break;

                case 6:
                    sVar0 = "MP_BWH_METH_2" /* GXT: El Burro Heights Meth Lab */;
                    break;

                case 8:
                    sVar0 = "MP_BWH_CRACK_2" /* GXT: Morningwood Cocaine Lockup */;
                    break;

                case 10:
                    sVar0 = "MP_BWH_FAKEID_2" /* GXT: Textile City Forgery Office */;
                    break;

                case 9:
                    sVar0 = "MP_BWH_CASH_2" /* GXT: Vespucci Canals Counterfeit Cash Factory */;
                    break;

                case 12:
                    sVar0 = "MP_BWH_WEED_3" /* GXT: San Chianski Weed Farm */;
                    break;

                case 11:
                    sVar0 = "MP_BWH_METH_3" /* GXT: Senora Desert Meth Lab */;
                    break;

                case 13:
                    sVar0 = "MP_BWH_CRACK_3" /* GXT: Zancudo River Cocaine Lockup */;
                    break;

                case 15:
                    sVar0 = "MP_BWH_FAKEID_3" /* GXT: Grapeseed Forgery Office */;
                    break;

                case 14:
                    sVar0 = "MP_BWH_CASH_3" /* GXT: Senora Desert Counterfeit Cash Factory */;
                    break;

                case 17:
                    sVar0 = "MP_BWH_WEED_4" /* GXT: Elysian Island Weed Farm */;
                    break;

                case 16:
                    sVar0 = "MP_BWH_METH_4" /* GXT: Terminal Meth Lab */;
                    break;

                case 18:
                    sVar0 = "MP_BWH_CRACK_4" /* GXT: Elysian Island Cocaine Lockup */;
                    break;

                case 20:
                    sVar0 = "MP_BWH_FAKEID_4" /* GXT: Elysian Island Forgery Office */;
                    break;

                case 19:
                    sVar0 = "MP_BWH_CASH_4" /* GXT: Cypress Flats Counterfeit Cash Factory */;
                    break;

                case 32:
                    sVar0 = "MP_BWH_ACID" /* GXT: Mobile Acid Lab */;
                    break;

                case 21:
                    sVar0 = "MP_BUNKER_1" /* GXT: Grand Senora Oilfields Bunker */;
                    break;

                case 22:
                    sVar0 = "MP_BUNKER_2" /* GXT: Grand Senora Desert Bunker */;
                    break;

                case 23:
                    sVar0 = "MP_BUNKER_3" /* GXT: Route 68 Bunker */;
                    break;

                case 24:
                    sVar0 = "MP_BUNKER_4" /* GXT: Farmhouse Bunker */;
                    break;

                case 25:
                    sVar0 = "MP_BUNKER_5" /* GXT: Smoke Tree Road Bunker */;
                    break;

                case 26:
                    sVar0 = "MP_BUNKER_6" /* GXT: Thomson Scrapyard Bunker */;
                    break;

                case 27:
                    sVar0 = "MP_BUNKER_7" /* GXT: Grapeseed Bunker */;
                    break;

                case 28:
                    sVar0 = "MP_BUNKER_9" /* GXT: Paleto Forest Bunker */;
                    break;

                case 29:
                    sVar0 = "MP_BUNKER_10" /* GXT: Raton Canyon Bunker */;
                    break;

                case 30:
                    sVar0 = "MP_BUNKER_11" /* GXT: Lago Zancudo Bunker */;
                    break;

                case 31:
                    sVar0 = "MP_BUNKER_12" /* GXT: Chumash Bunker */;
                    break;
            }
            return sVar0;
        }

        void func_5509(ref string sParam0, int iParam1, bool bParam2)//Position - 0x1C3C71
        {
            sParam0 = "FACTORY_INDEX_";
            sParam0 += iParam1;
            sParam0 += "_t0_v0";
            if (bParam2)
            {
                sParam0 += "_CESP";
            }
        }
        int func_5505(int iParam0, int iParam1, int iParam2)//Position - 0x1C371B
        {
            if (iParam0 != 0)
            {
                if (iParam1 != iParam2)
                {
                    return 0;
                }
                int hash = Function.Call<int>((Hash)0xD69CE161FE614531, 0, 5384, 0);
                int stat = 0;
                API.StatGetInt((uint)hash, ref stat, -1);
                if (stat == 0)
                {
                    return 0;
                }
                return 1;
            }
            return 0;
        }
        void func_5507(ref string sParam0, int iParam1, int iParam2, int iParam3, int iParam4)//Position - 0x1C3A29
        {
            switch (iParam1)
            {
                case 5:
                    switch (iParam2)
                    {
                        case 0:
                            sParam0 = "FA_UPGRADE_WEAPONS_EQUIP_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 1:
                            sParam0 = "FA_UPGRADE_WEAPONS_STAFF_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 2:
                            sParam0 = "FA_UPGRADE_WEAPONS_SEC_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 3:
                            sParam0 = "FA_UPGRADE_WEAPONS_DECOR_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 4:
                            sParam0 = "FA_UPGRADE_WEAPONS_DECOR_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 5:
                            sParam0 = "FA_UPGRADE_WEAPONS_DECOR_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 6:
                            sParam0 = "FA_UPGRADE_WEAPONS_ACCOM_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 7:
                            sParam0 = "FA_UPGRADE_WEAPONS_RANGE_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 8:
                            sParam0 = "FA_UPGRADE_WEAPONS_RANGE_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 9:
                            sParam0 = "FA_UPGRADE_WEAPONS_GNLCK_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 10:
                            sParam0 = "FA_UPGRADE_WEAPONS_TRNPT_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;

                        case 11:
                            sParam0 = "FA_UPGRADE_WEAPONS_TRNPT_";
                            sParam0 += iParam3;
                            sParam0 += "_t0_v";
                            sParam0 += iParam4;
                            break;
                    }
                    break;
            }
        }
    }
}
