using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal class Facility : PropertyBase
    {
        public string Label(int n) => n switch
        {
            1 => "MP_DBASE_1" /* GXT: Grand Senora Desert Facility */,
            2 => "MP_DBASE_2" /* GXT: Route 68 Facility */,
            3 => "MP_DBASE_3" /* GXT: Sandy Shores Facility */,
            4 => "MP_DBASE_4" /* GXT: Mount Gordo Facility */,
            5 => "MP_DBASE_6" /* GXT: Paleto Bay Facility */,
            6 => "MP_DBASE_7" /* GXT: Lago Zancudo Facility */,
            7 => "MP_DBASE_8" /* GXT: Zancudo River Facility */,
            8 => "MP_DBASE_9" /* GXT: Ron Alternates Wind Farm Facility */,
            9 => "MP_DBASE_10" /* GXT: Land Act Reservoir Facility */,
            _ => "",
        };

        public string Description(int n) => n switch
        {
            1 => "MP_DBADES_1" /* GXT: A really fascinating site with lots of history and character. No need to worry about the small print, just tell your lawyer to sign.~n~We are legally required to give notice of documents suggesting this site was recently a nuclear testing facility. No steps have been taken to ensure its safety. */,
            2 => "MP_DBADES_2" /* GXT: When you're thinking of investing in a labyrinthine military-grade vault hundreds of feet below ground, the address is everything. Just off the iconic Route 68, surrounded by mountain peaks, this little number is just the country retreat you've been looking for. */,
            3 => "MP_DBADES_3" /* GXT: These days, Sandy Shores is an up and coming second home hotspot for the criminally deranged, and here's your chance to jump the waiting list. Act now: in this neighborhood an abandoned military installation won't be on the market for long. */,
            4 => "MP_DBADES_4" /* GXT: Forget the scare stories: there are no ghosts, and no one does yoga here. The foothills of Mount Gordo are the perfect backwater spot for an off-the-books, nuke-proof hideaway. */,
            5 => "MP_DBADES_6" /* GXT: If you're the kind of mastermind who likes the calming sound of the ocean to be audible beneath the maniacal laughter echoing through the cavernous halls of your secret lair, then this is the beauty spot for you. */,
            6 => "MP_DBADES_7" /* GXT: It might not occur to you to excavate a subterranean facility in marshland overlooked by the largest military base in the state. But now the idea's in your head, how can you resist? */,
            7 => "MP_DBADES_8" /* GXT: This charming riverside spot is cold in the winter, baking hot in the summer, and has swarms of malarial mosquitoes all year round. You wanted secluded, well here it is. */,
            8 => "MP_DBADES_9" /* GXT: You've always suspected the eco movement in San Andreas was a front for something, and now you know. The power from this wind farm has been redirected into your hot tub, and the turbines make an excellent deterrent to inquisitive police helicopters. */,
            9 => "MP_DBADES_10" /* GXT: The only thing edgier than owning a sprawling underground facility is owning one that could fill with water at any second. Just avoid target practice near the east wall, and you'll probably be fine. */,
            _ => "",
        };

        public string GetAddress(int n) => "";

        public string TXD(int n) => n switch
        {
            1 => "MP_BASE1",
            2 => "MP_BASE2",
            3 => "MP_BASE3",
            4 => "MP_BASE4",
            5 => "MP_BASE6",
            6 => "MP_BASE7",
            7 => "MP_BASE8",
            8 => "MP_BASE9",
            9 => "MP_BASE10",
            _ => "",
        };

        public eOfficePropertyType OfficeType { get; private set; } = eOfficePropertyType.Facility;

        public int[] StylesCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int[] GraphicsCost = [0, 0, 0, 0, 0, 0, 0, 0, 0];
        public int OrbitalCannonCost = 0;
        public int SecurityRoomCost = 0;
        public int PrivacyGlassCost = 0;
        public int[] LoungeCost = [0, 0, 0];
        public int[] SleepQuartersCost = [0, 0, 0];

        public int[] StylesSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int[] GraphicsSaleCost = [-1, -1, -1, -1, -1, -1, -1, -1, -1];
        public int OrbitalCannonSaleCost = -1;
        public int SecurityRoomSaleCost = -1;
        public int PrivacyGlassSaleCost = -1;
        public int[] LoungeSaleCost = [-1, -1, -1];
        public int[] SleepQuartersSaleCost = [-1, -1, -1];


        public Facility(int slot, int id) : base(slot, id)
        {
            Position = GetDefaultPosition(GetDefaultId(id));
            BaseCost = GetDefaultPrice(id);
            StylesCost = [
                func_5760(0, Id, 0), /*iVar7*/
                func_5760(0, Id, 1), /*iVar8*/
                func_5760(0, Id, 2), /*iVar9*/
                func_5760(0, Id, 3), /*iVar10*/
                func_5760(0, Id, 4), /*iVar11*/
                func_5760(0, Id, 5), /*iVar12*/
                func_5760(0, Id, 6), /*iVar13*/
                func_5760(0, Id, 7), /*iVar14*/
                func_5760(0, Id, 8) /*iVar15*/
            ];
            GraphicsCost = [
                func_5760(1, Id, 0), /*iVar16*/
                func_5760(1, Id, 1), /*iVar17*/
                func_5760(1, Id, 2), /*iVar18*/
                func_5760(1, Id, 3), /*iVar19*/
                func_5760(1, Id, 4), /*iVar20*/
                func_5760(1, Id, 5), /*iVar21*/
                func_5760(1, Id, 6), /*iVar22*/
                func_5760(1, Id, 7), /*iVar23*/
                func_5760(1, Id, 8), /*iVar24*/
            ];
            SleepQuartersCost = [
                func_5760(3, Id, 1), /*iVar25*/
                func_5760(3, Id, 2), /*iVar26*/
                func_5760(3, Id, 3) /*iVar27*/
            ];
            OrbitalCannonCost = func_5760(2, Id, -1); /*iVar28*/
            SecurityRoomCost = func_5760(4, Id, -1); /*iVar29*/
            LoungeCost = [
                func_5760(5, Id, 0), /*iVar30*/
                func_5760(5, Id, 1), /*iVar31*/
                func_5760(5, Id, 2) /*iVar32*/
            ];
            PrivacyGlassCost = func_5760(6, Id, -1); /*iVar33*/

        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(Id + 40);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamInt(4);
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            Tools.SetScaleformString("");
            ScaleformMovieMethodAddParamInt(BaseCost);
            ScaleformMovieMethodAddParamInt(StylesCost[0]);
            ScaleformMovieMethodAddParamInt(StylesCost[1]);
            ScaleformMovieMethodAddParamInt(StylesCost[2]);
            ScaleformMovieMethodAddParamInt(StylesCost[3]);
            ScaleformMovieMethodAddParamInt(StylesCost[4]);
            ScaleformMovieMethodAddParamInt(StylesCost[5]);
            ScaleformMovieMethodAddParamInt(StylesCost[6]);
            ScaleformMovieMethodAddParamInt(StylesCost[7]);
            ScaleformMovieMethodAddParamInt(StylesCost[8]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(GraphicsCost[0]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[1]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[2]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[3]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[4]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[5]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[6]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[7]);
            ScaleformMovieMethodAddParamInt(GraphicsCost[8]);
            ScaleformMovieMethodAddParamInt(OrbitalCannonCost);
            ScaleformMovieMethodAddParamInt(SecurityRoomCost);
            ScaleformMovieMethodAddParamInt(LoungeCost[0]);
            ScaleformMovieMethodAddParamInt(LoungeCost[1]);
            ScaleformMovieMethodAddParamInt(LoungeCost[2]);
            ScaleformMovieMethodAddParamInt(SleepQuartersCost[0]);
            ScaleformMovieMethodAddParamInt(SleepQuartersCost[1]);
            ScaleformMovieMethodAddParamInt(SleepQuartersCost[2]);
            ScaleformMovieMethodAddParamInt(PrivacyGlassCost);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(BaseSaleCost);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[0]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[1]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[2]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[3]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[4]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[5]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[6]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[7]);
            ScaleformMovieMethodAddParamInt(StylesSaleCost[8]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[0]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[1]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[2]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[3]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[4]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[5]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[6]);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[7]);
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(sc.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            ScaleformMovieMethodAddParamInt(GraphicsSaleCost[8]);
            ScaleformMovieMethodAddParamInt(OrbitalCannonSaleCost);
            ScaleformMovieMethodAddParamInt(SecurityRoomSaleCost);
            ScaleformMovieMethodAddParamInt(LoungeSaleCost[0]);
            ScaleformMovieMethodAddParamInt(LoungeSaleCost[1]);
            ScaleformMovieMethodAddParamInt(LoungeSaleCost[2]);
            ScaleformMovieMethodAddParamInt(SleepQuartersSaleCost[0]);
            ScaleformMovieMethodAddParamInt(SleepQuartersSaleCost[1]);
            ScaleformMovieMethodAddParamInt(SleepQuartersSaleCost[2]);
            ScaleformMovieMethodAddParamInt(PrivacyGlassSaleCost);
            ScaleformMovieMethodAddParamBool(false);
            EndScaleformMovieMethod();
        }

        public Vector3 GetDefaultPosition(int id)
        {
            return id switch
            {
                89 => new(1273.1376f, 2835.0068f, 48.0734f),
                90 => new(34.4699f, 2620.9768f, 84.6202f),
                91 => new(2755.9807f, 3907.2722f, 44.3148f),
                92 => new(3389.6028f, 5508.971f, 24.875f),
                93 => new(19.4492f, 6825.3613f, 14.4952f),
                94 => new(-2229.408f, 2399.4102f, 11.0106f),
                95 => new(-3.0095f, 3344.4888f, 40.2769f),
                96 => new(2086.0674f, 1761.3461f, 103.043f),
                97 => new(1864.8027f, 269.0474f, 163.0169f),
                _ => new(0f, 0f, 0f),
            };
        }

        int GetDefaultId(int iParam0)//Position - 0x284C20
        {
            return iParam0 switch
            {
                1 => 89,
                2 => 90,
                3 => 91,
                4 => 92,
                5 => 93,
                6 => 94,
                7 => 95,
                8 => 96,
                9 => 97,
                _ => -1,
            };
        }

        int GetDefaultPrice(int id)//Position - 0x1D5CC3
        {
            string sVar0 = "";
            int iVar16;
            int iVar17;

            func_5494(ref sVar0, id);
            iVar16 = API.GetHashKey(sVar0);
            if (API.NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = API.NetGameserverGetPrice((uint)iVar16, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return id switch
            {
                1 => Tunables.Global_262145.Value<int>("f_24110") /* Tunable: H2_FACILITY_GRAND_SENORA_DESERT */,
                2 => Tunables.Global_262145.Value<int>("f_24111") /* Tunable: H2_FACILITY_ROUTE_68 */,
                3 => Tunables.Global_262145.Value<int>("f_24109") /* Tunable: H2_FACILITY_SANDY_SHORES */,
                4 => Tunables.Global_262145.Value<int>("f_24115") /* Tunable: H2_FACILITY_MOUNT_GORDO */,
                5 => Tunables.Global_262145.Value<int>("f_24116") /* Tunable: H2_FACILITY_PALETO_BAY */,
                6 => Tunables.Global_262145.Value<int>("f_24114") /* Tunable: H2_FACILITY_LAGO_ZANCUDO */,
                7 => Tunables.Global_262145.Value<int>("f_24112") /* Tunable: H2_FACILITY_ZANCUDO_RIVER */,
                8 => Tunables.Global_262145.Value<int>("f_24113") /* Tunable: H2_FACILITY_WIND_FARM */,
                9 => Tunables.Global_262145.Value<int>("f_24108") /* Tunable: H2_FACILITY_LAND_ACT_RESERVOIR */,
                _ => 0,
            };
        }

        void func_5494(ref string sParam0, int iParam1)//Position - 0x1C2C11
        {
            sParam0 = $"DBASE_INDEX_{iParam1}_t0_v0";
        }

        int func_5760(int iParam0, int iParam1, int iParam2)//Position - 0x1D5924
        {
            int Id;
            string sVar1 = "";
            int iVar17;
            int iVar18;

            Id = 0;
            func_5490(ref sVar1, iParam0, iParam2, Id);
            iVar17 = API.GetHashKey(sVar1);
            if (API.NetGameserverCatalogItemExistsHash((uint)iVar17))
            {
                iVar18 = API.NetGameserverGetPrice((uint)iVar17, (uint)API.GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar18;
            }

            switch (iParam0)
            {
                case 0:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_24117") /* Tunable: H2_FACILITY_STYLE_STYLE_1 */,
                        1 => Tunables.Global_262145.Value<int>("f_24118") /* Tunable: H2_FACILITY_STYLE_STYLE_2 */,
                        2 => Tunables.Global_262145.Value<int>("f_24119") /* Tunable: H2_FACILITY_STYLE_STYLE_3 */,
                        3 => Tunables.Global_262145.Value<int>("f_24120") /* Tunable: H2_FACILITY_STYLE_STYLE_4 */,
                        4 => Tunables.Global_262145.Value<int>("f_24121") /* Tunable: H2_FACILITY_STYLE_STYLE_5 */,
                        5 => Tunables.Global_262145.Value<int>("f_24122") /* Tunable: H2_FACILITY_STYLE_STYLE_6 */,
                        6 => Tunables.Global_262145.Value<int>("f_24123") /* Tunable: H2_FACILITY_STYLE_STYLE_7 */,
                        7 => Tunables.Global_262145.Value<int>("f_24124") /* Tunable: H2_FACILITY_STYLE_STYLE_8 */,
                        8 => Tunables.Global_262145.Value<int>("f_24125") /* Tunable: H2_FACILITY_STYLE_STYLE_9 */,
                        _ => 0,
                    };
                case 1:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_24126") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_1 */,
                        1 => Tunables.Global_262145.Value<int>("f_24127") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_2 */,
                        2 => Tunables.Global_262145.Value<int>("f_24128") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_3 */,
                        3 => Tunables.Global_262145.Value<int>("f_24129") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_4 */,
                        4 => Tunables.Global_262145.Value<int>("f_24130") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_5 */,
                        5 => Tunables.Global_262145.Value<int>("f_24131") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_6 */,
                        6 => Tunables.Global_262145.Value<int>("f_24132") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_7 */,
                        7 => Tunables.Global_262145.Value<int>("f_24133") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_8 */,
                        8 => Tunables.Global_262145.Value<int>("f_24134") /* Tunable: H2_FACILITY_GRAPHICS_GRAPHIC_9 */,
                        _ => 0,
                    };
                case 4:
                    if (iParam2 != -1)
                    {
                    }
                    return Tunables.Global_262145.Value<int>("f_24136") /* Tunable: H2_FACILITY_ADD_ON_SECURITY_ROOM */;

                case 5:
                    return iParam2 switch
                    {
                        0 => Tunables.Global_262145.Value<int>("f_24137") /* Tunable: H2_FACILITY_ADD_ON_LOUNGE_1 */,
                        1 => Tunables.Global_262145.Value<int>("f_24138") /* Tunable: H2_FACILITY_ADD_ON_LOUNGE_2 */,
                        2 => Tunables.Global_262145.Value<int>("f_24139") /* Tunable: H2_FACILITY_ADD_ON_LOUNGE_3 */,
                        _ => 0,
                    };
                case 6:
                    if (iParam2 != -1)
                    {
                    }
                    return Tunables.Global_262145.Value<int>("f_24140") /* Tunable: H2_FACILITY_ADD_ON_PRIVACY_GLASS */;

                case 3:
                    return iParam2 switch
                    {
                        0 => 0,
                        1 => Tunables.Global_262145.Value<int>("f_24141") /* Tunable: H2_FACILITY_ADD_ON_SLEEPING_QUARTERS_1 */,
                        2 => Tunables.Global_262145.Value<int>("f_24142") /* Tunable: H2_FACILITY_ADD_ON_SLEEPING_QUARTERS_2 */,
                        3 => Tunables.Global_262145.Value<int>("f_24143") /* Tunable: H2_FACILITY_ADD_ON_SLEEPING_QUARTERS_3 */,
                        _ => 0,
                    };
                case 2:
                    if (iParam2 != -1)
                    {
                    }
                    return Tunables.Global_262145.Value<int>("f_24135") /* Tunable: H2_FACILITY_ADD_ON_ORBITAL_WEAPON */;
            }
            return 0;
        }

        void func_5490(ref string sParam0, int iParam1, int iParam2, int iParam3)//Position - 0x1C2A90
        {
            sParam0 = $"{func_5491(iParam1, iParam2)}_t0_v{iParam3}";
        }

        string func_5491(int iParam0, int iParam1)//Position - 0x1C2AB3
        {
            string cVar0 = "";

            if (iParam1 == -1)
            {
                if ((iParam0 == 2 || iParam0 == 4) || iParam0 == 6)
                {
                    iParam1 = 1;
                }
            }
            cVar0 = "FCBASE_";
            switch (iParam0)
            {
                case 0:
                    cVar0 += "STY";
                    cVar0 += iParam1 + 1;
                    break;

                case 1:
                    cVar0 += "GRA";
                    cVar0 += iParam1 + 1;
                    break;

                case 3:
                    cVar0 += "QRT";
                    cVar0 += iParam1;
                    break;

                case 2:
                    cVar0 += "WEA";
                    cVar0 += iParam1;
                    break;

                case 4:
                    cVar0 += "SEC";
                    cVar0 += iParam1;
                    break;

                case 5:
                    cVar0 += "LNG";
                    cVar0 += iParam1 + 1;
                    break;

                case 6:
                    cVar0 += "WIND";
                    cVar0 += iParam1;
                    break;

                default:
                    return "";
            }
            return GetTextSubstring(cVar0, 0, cVar0.Length); //GET_CHARACTER_FROM_AUDIO_CONVERSATION_FILENAME
        }

    }
}
