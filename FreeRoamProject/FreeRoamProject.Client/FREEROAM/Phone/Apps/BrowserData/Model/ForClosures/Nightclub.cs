using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal class Nightclub : PropertyBase
    {
        public string Label(int n) => $"MP_NCLU_{n}";

        public string Description(int n) => $"MP_NCLUDES_{n}";

        public string GetAddress(int n) => "";

        public string TXD(int n) => $"MP_CLUB{(n - 1)}";

        public eOfficePropertyType OfficeType { get; private set; } = eOfficePropertyType.NightClub;

        public int[] StyleCost = [0, 0, 0];
        public int LightRigCost = 0;
        public int[] LightRigStyleCost = [0, 0, 0, 0];
        public int[] NameCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] StorageCost = [0, 0, 0, 0, 0];
        public int[] GarageCost = [0, 0, 0, 0];
        public int[] DancerStyleCost = [0, 0, 0];
        public int DryIceCost = 0;

        public int[] StyleSaleCost = [-1, -1, -1];
        public int LightRigSaleCost = -1;
        public int[] LightRigStyleSaleCost = [-1, -1, -1, -1];
        public int[] NameSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] StorageSaleCost = [-1, -1, -1, -1, -1];
        public int[] GarageSaleCost = [-1, -1, -1, -1];
        public int[] DancerStyleSaleCost = [-1, -1, -1];
        public int DryIceSaleCost = -1;

        public Nightclub(int slot, int id) : base(slot, id)
        {
            Slot = slot;
            Id = id;
            Position = GetDefaultPosition(GetDefaultId(Id));
            BaseCost = GetDefaultPrice(Id);
            StyleCost = [
                func_5751(0, Id, 0), //iVar8
                func_5751(0, Id, 1), //iVar9
                func_5751(0, Id, 2) //iVar10
            ];
            LightRigCost = func_5751(1, Id, 0); //iVar11
            LightRigStyleCost = [
                func_5751(1, Id, 1), //iVar12
                func_5751(1, Id, 2), //iVar13
                func_5751(1, Id, 3), //iVar14
                func_5751(1, Id, 4) //iVar15
            ];
            DryIceCost = func_5751(4, Id, 1); //iVar16
            DancerStyleCost = [
                func_5751(3, Id, 1), //iVar17
                func_5751(3, Id, 2), //iVar18
                func_5751(3, Id, 3), //iVar19
                func_5751(3, Id, 4), //iVar20
                func_5751(3, Id, 5), //iVar21
                func_5751(3, Id, 6), //iVar22
                func_5751(3, Id, 7), //iVar23
                func_5751(3, Id, 8), //iVar24
                func_5751(3, Id, 9) //iVar25
            ];
            StorageCost = [
                func_6083(1, Id, 1), //iVar26
                func_6083(1, Id, 2), //iVar27
                func_6083(1, Id, 3), //iVar28
                func_6083(1, Id, 4) //iVar29
            ];
            GarageCost = [
                func_6083(0, Id, 1), //iVar30
                func_6083(0, Id, 2), //iVar31
                func_6083(0, Id, 3), //iVar32
                func_6083(0, Id, 4) //iVar33
            ];
            NameCost = [
                func_5751(6, Id, 0), //iVar34
                func_5751(6, Id, 1), //iVar35
                func_5751(6, Id, 2), //iVar36
                func_5751(6, Id, 3), //iVar37
                func_5751(6, Id, 4), //iVar38
                func_5751(6, Id, 5), //iVar39
                func_5751(6, Id, 6), //iVar40
                func_5751(6, Id, 7), //iVar41
                func_5751(6, Id, 8) //iVar42
            ];
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {


            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id + 10);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamInt(5);
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
            ScaleformMovieMethodAddParamInt(LightRigCost);
            ScaleformMovieMethodAddParamInt(LightRigStyleCost[0]);
            ScaleformMovieMethodAddParamInt(LightRigStyleCost[1]);
            ScaleformMovieMethodAddParamInt(LightRigStyleCost[2]);
            ScaleformMovieMethodAddParamInt(LightRigStyleCost[3]);
            ScaleformMovieMethodAddParamInt(DryIceCost);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[0]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[1]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[2]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[3]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[4]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[5]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[6]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[7]);
            ScaleformMovieMethodAddParamInt(DancerStyleCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(StorageCost[0]);
            ScaleformMovieMethodAddParamInt(StorageCost[1]);
            ScaleformMovieMethodAddParamInt(StorageCost[2]);
            ScaleformMovieMethodAddParamInt(StorageCost[3]);
            ScaleformMovieMethodAddParamInt(GarageCost[0]);
            ScaleformMovieMethodAddParamInt(GarageCost[1]);
            ScaleformMovieMethodAddParamInt(GarageCost[2]);
            ScaleformMovieMethodAddParamInt(GarageCost[3]);
            ScaleformMovieMethodAddParamInt(NameCost[0]);
            ScaleformMovieMethodAddParamInt(NameCost[1]);
            ScaleformMovieMethodAddParamInt(NameCost[2]);
            ScaleformMovieMethodAddParamInt(NameCost[3]);
            ScaleformMovieMethodAddParamInt(NameCost[4]);
            ScaleformMovieMethodAddParamInt(NameCost[5]);
            ScaleformMovieMethodAddParamInt(NameCost[6]);
            ScaleformMovieMethodAddParamInt(NameCost[7]);
            ScaleformMovieMethodAddParamInt(NameCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseSaleCost);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(StyleSaleCost[2]);
            ScaleformMovieMethodAddParamInt(LightRigSaleCost);
            ScaleformMovieMethodAddParamInt(LightRigStyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(LightRigStyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(LightRigStyleSaleCost[2]);
            ScaleformMovieMethodAddParamInt(LightRigStyleSaleCost[3]);
            ScaleformMovieMethodAddParamInt(DryIceSaleCost);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[0]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[1]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[2]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[3]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[4]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[5]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[6]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[7]);
            ScaleformMovieMethodAddParamInt(DancerStyleSaleCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(StorageSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StorageSaleCost[1]);
            ScaleformMovieMethodAddParamInt(StorageSaleCost[2]);
            ScaleformMovieMethodAddParamInt(StorageSaleCost[3]);
            ScaleformMovieMethodAddParamInt(GarageSaleCost[0]);
            ScaleformMovieMethodAddParamInt(GarageSaleCost[1]);
            ScaleformMovieMethodAddParamInt(GarageSaleCost[2]);
            ScaleformMovieMethodAddParamInt(GarageSaleCost[3]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[0]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[1]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[2]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[3]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[4]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[5]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[6]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[7]);
            ScaleformMovieMethodAddParamInt(NameSaleCost[8]);
            EndScaleformMovieMethod();
        }

        Vector3 GetDefaultPosition(int iParam0)//Position - 0x2849B6
        {
            return iParam0 switch
            {
                102 => new(756.989f, -1332.463f, 26.2802f),
                103 => new(345.2846f, -977.7734f, 29.4634f),
                104 => new(-120.798f, -1260.488f, 28.3088f),
                105 => new(5.667f, 221.309f, 106.7566f),
                106 => new(871.312f, -2099.551f, 29.4768f),
                107 => new(-676.6141f, -2458.2104f, 12.9444f),
                108 => new(195.416f, -3167.381f, 4.7903f),
                109 => new(371.0099f, 252.2451f, 103.0081f),
                110 => new(-1285.0198f, -652.3701f, 25.6332f),
                111 => new(-1174.5742f, -1153.4714f, 4.6582f),
                _ => new(0f, 0f, 0f),
            };
        }
        int GetDefaultId(int iParam0)//Position - 0x284AB8
        {
            return iParam0 switch
            {
                1 => 102,
                2 => 103,
                3 => 104,
                4 => 105,
                5 => 106,
                6 => 107,
                7 => 108,
                8 => 109,
                9 => 110,
                10 => 111,
                _ => -1,
            };
        }

        int GetDefaultPrice(int iParam0)//Position - 0x1D56EB
        {
            string sVar0 = "";
            int iVar16;
            int iVar17;

            func_5483(ref sVar0, iParam0);
            iVar16 = API.GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = NetGameserverGetPrice((uint)iVar16, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_25024") /* Tunable: BB_NIGHTCLUB_PROPERTY_LA_MESA_WAREHOUSE */,
                2 => Tunables.Global_262145.Value<int>("f_25025") /* Tunable: BB_NIGHTCLUB_PROPERTY_MISSION_ROW_BUILDING */,
                3 => Tunables.Global_262145.Value<int>("f_25023") /* Tunable: BB_NIGHTCLUB_PROPERTY_STRAWBERRY_WAREHOUSE */,
                4 => Tunables.Global_262145.Value<int>("f_25020") /* Tunable: BB_NIGHTCLUB_PROPERTY_WEST_VINEWOOD_BUILDING */,
                5 => Tunables.Global_262145.Value<int>("f_25026") /* Tunable: BB_NIGHTCLUB_PROPERTY_CYPRESS_FLATS_WAREHOUSE */,
                6 => Tunables.Global_262145.Value<int>("f_25028") /* Tunable: BB_NIGHTCLUB_PROPERTY_LSIA_WAREHOUSE */,
                7 => Tunables.Global_262145.Value<int>("f_25029") /* Tunable: BB_NIGHTCLUB_PROPERTY_ELYSIAN_ISLAND_WAREHOUSE */,
                8 => Tunables.Global_262145.Value<int>("f_25021") /* Tunable: BB_NIGHTCLUB_PROPERTY_DOWNTOWN_VINEWOOD */,
                9 => Tunables.Global_262145.Value<int>("f_25022") /* Tunable: BB_NIGHTCLUB_PROPERTY_DEL_PERRO_BUILDING */,
                10 => Tunables.Global_262145.Value<int>("f_25027") /* Tunable: BB_NIGHTCLUB_PROPERTY_VESPUCCI_CANALS_BUILDING */,
                _ => 0,
            };
        }
        void func_5483(ref string sParam0, int iParam1)//Position - 0x1C2421
        {
            sParam0 = $"NCLU_INDEX_{iParam1}_t0_v0";
        }

        int func_6083(int iParam0, int iParam1, int iParam2)//Position - 0x1E6E7B
        {
            int iVar0;
            int iVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;

            iVar0 = 0;
            iVar1 = 0;
            func_5471(ref sVar2, iParam0, iParam2, iVar0, iVar1);
            iVar18 = GetHashKey(sVar2);
            if (NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                iVar19 = NetGameserverGetPrice((uint)iVar18, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar19;
            }

            switch (iParam0)
            {
                case 0:
                    return iParam2 switch
                    {
                        0 => 0,
                        1 => Tunables.Global_262145.Value<int>("f_25034") /* Tunable: BB_NIGHTCLUB_PROPERTY_GARAGE_B2 */,
                        2 => Tunables.Global_262145.Value<int>("f_25035") /* Tunable: BB_NIGHTCLUB_PROPERTY_GARAGE_B3 */,
                        3 => Tunables.Global_262145.Value<int>("f_25036") /* Tunable: BB_NIGHTCLUB_PROPERTY_GARAGE_B4 */,
                        4 => 0,
                        _ => 0,
                    };
                case 3:
                    if (iParam2 != 0)
                    {
                    }
                    return Tunables.Global_262145.Value<int>("f_24577") /* Tunable: -811916052 */;

                case 4:
                    if (iParam2 != 0)
                    {
                    }
                    return Tunables.Global_262145.Value<int>("f_24578") /* Tunable: -1137462330 */;

                case 2:
                    return iParam2 switch
                    {
                        0 => 0,
                        1 => Tunables.Global_262145.Value<int>("f_24587") /* Tunable: 785197557 */,
                        2 => Tunables.Global_262145.Value<int>("f_24588") /* Tunable: -588085068 */,
                        3 => Tunables.Global_262145.Value<int>("f_24589") /* Tunable: -723963067 */,
                        4 => Tunables.Global_262145.Value<int>("f_24590") /* Tunable: 2018353091 */,
                        _ => 0,
                    };
                case 1:
                    return iParam2 switch
                    {
                        0 => 0,
                        1 => Tunables.Global_262145.Value<int>("f_25030") /* Tunable: BB_NIGHTCLUB_PROPERTY_WAREHOUSE_B2 */,
                        2 => Tunables.Global_262145.Value<int>("f_25031") /* Tunable: BB_NIGHTCLUB_PROPERTY_WAREHOUSE_B3 */,
                        3 => Tunables.Global_262145.Value<int>("f_25032") /* Tunable: BB_NIGHTCLUB_PROPERTY_WAREHOUSE_B4 */,
                        4 => Tunables.Global_262145.Value<int>("f_25033") /* Tunable: BB_NIGHTCLUB_PROPERTY_WAREHOUSE_B5 */,
                        _ => 0,
                    };
                case 5:
                    if (iParam2 != 0)
                    {
                    }
                    return 95000;
            }
            return 0;
        }
        int func_5751(int iParam0, int iParam1, int iParam2)//Position - 0x1D52B6
        {
            int Id;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            Id = 0;
            func_5477(ref sVar1, iParam0, iParam2, Id);
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
                            return Tunables.Global_262145.Value<int>("f_25037") /* Tunable: BB_NIGHTCLUB_PROPERTY_STYLE_1_RENOVATION_ONLY */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_25038") /* Tunable: BB_NIGHTCLUB_PROPERTY_STYLE_2 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_25039") /* Tunable: BB_NIGHTCLUB_PROPERTY_STYLE_3 */;
                    }
                    break;

                case 1:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_25049") /* Tunable: BB_NIGHTCLUB_PROPERTY_LIGHTING_DEFAULT_RENOVATION_ONLY */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_25050") /* Tunable: BB_NIGHTCLUB_PROPERTY_LIGHTING_LED_TUBES */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_25051") /* Tunable: BB_NIGHTCLUB_PROPERTY_LIGHTING_GEOMETRIC */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_25052") /* Tunable: BB_NIGHTCLUB_PROPERTY_LIGHTING_RIBBON */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_25053") /* Tunable: BB_NIGHTCLUB_PROPERTY_LIGHTING_LASER_SHOW */;
                    }
                    break;

                case 2:
                    return Tunables.Global_262145.Value<int>("f_24580") /* Tunable: -438242317 */;

                case 7:
                    return Tunables.Global_262145.Value<int>("f_24581") /* Tunable: -1426095971 */;

                case 8:
                    return Tunables.Global_262145.Value<int>("f_24582") /* Tunable: 530619504 */;

                case 3:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_25054") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_1 */ + Tunables.Global_262145.Value<int>("f_25057") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_FEMALE */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_25054") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_1 */ + Tunables.Global_262145.Value<int>("f_25058") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MALE */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_25054") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_1 */ + Tunables.Global_262145.Value<int>("f_25059") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MIXED */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_25055") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_2 */ + Tunables.Global_262145.Value<int>("f_25057") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_FEMALE */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_25055") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_2 */ + Tunables.Global_262145.Value<int>("f_25058") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MALE */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_25055") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_2 */ + Tunables.Global_262145.Value<int>("f_25059") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MIXED */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_25056") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_3 */ + Tunables.Global_262145.Value<int>("f_25057") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_FEMALE */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_25056") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_3 */ + Tunables.Global_262145.Value<int>("f_25058") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MALE */;

                        case 9:
                            return Tunables.Global_262145.Value<int>("f_25056") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_STYLE_3 */ + Tunables.Global_262145.Value<int>("f_25059") /* Tunable: BB_NIGHTCLUB_PROPERTY_DANCERS_MIXED */;
                    }
                    break;

                case 4:
                    switch (iParam2)
                    {
                        case 0:
                            return 0;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_25060") /* Tunable: BB_NIGHTCLUB_PROPERTY_DRY_ICE */;
                    }
                    break;

                case 6:
                    switch (iParam2)
                    {
                        case 0:
                            return Tunables.Global_262145.Value<int>("f_25040") /* Tunable: 91858633 */;

                        case 1:
                            return Tunables.Global_262145.Value<int>("f_25041") /* Tunable: -1168036437 */;

                        case 2:
                            return Tunables.Global_262145.Value<int>("f_25042") /* Tunable: 1788794576 */;

                        case 3:
                            return Tunables.Global_262145.Value<int>("f_25043") /* Tunable: -1100638156 */;

                        case 4:
                            return Tunables.Global_262145.Value<int>("f_25044") /* Tunable: 1443977855 */;

                        case 5:
                            return Tunables.Global_262145.Value<int>("f_25045") /* Tunable: 176534428 */;

                        case 6:
                            return Tunables.Global_262145.Value<int>("f_25046") /* Tunable: -668591946 */;

                        case 7:
                            return Tunables.Global_262145.Value<int>("f_25047") /* Tunable: 2004204966 */;

                        case 8:
                            return Tunables.Global_262145.Value<int>("f_25048") /* Tunable: 1383136622 */;
                    }
                    break;

                case 5:
                    return Tunables.Global_262145.Value<int>("f_24579") /* Tunable: 1585043699 */;
            }
            return 0;
        }
        void func_5477(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1C2263
        {
            sParam0 = $"{func_5478(iParam1, iParam2)}_t0_v{iParam3}";
        }
        string func_5478(int iParam0, int iParam1)//Position - 0x1C2286
        {
            string cVar0 = "FCCLUB_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "STY_";
                    cVar0 += iParam1 + 1;
                    break;

                case 1:
                    cVar0 += "LGHT_";
                    cVar0 += iParam1 + 1;
                    break;

                case 2:
                    cVar0 += "DJ2_";
                    cVar0 += iParam1;
                    break;

                case 3:
                    cVar0 += "DNC_";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "ICE_";
                    cVar0 += iParam1;
                    break;

                case 6:
                    cVar0 += "NAME_";
                    cVar0 += iParam1 + 1;
                    break;

                case 5:
                    cVar0 += "STF_";
                    cVar0 += iParam1;
                    break;

                case 7:
                    cVar0 += "DJ3_";
                    cVar0 += iParam1;
                    break;

                case 8:
                    cVar0 += "DJ4_";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length); //GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME
        }

        void func_5471(ref string sParam0, int iParam1, int iParam2, int iParam3, int iParam4)//Position - 0x1C2016
        {
            sParam0 = func_5472(iParam1, iParam2);
            sParam0 += "_t";
            sParam0 += iParam3;
            sParam0 += "_v";
            sParam0 += iParam4;
        }
        string func_5472(int iParam0, int iParam1)//Position - 0x1C2048
        {
            string cVar0 = "";

            cVar0 += "FCHUB_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "FCCLUB_GARG_";
                    cVar0 += iParam1;
                    break;

                case 1:
                    cVar0 += "FCCLUB_STOR_";
                    cVar0 += iParam1;
                    break;

                case 2:
                    cVar0 += "STA_";
                    cVar0 += iParam1;
                    break;

                case 3:
                    cVar0 += "SEC_";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "EQU_";
                    cVar0 += iParam1;
                    break;

                case 5:
                    cVar0 += "MOD7_";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length);
        }
    }
}
