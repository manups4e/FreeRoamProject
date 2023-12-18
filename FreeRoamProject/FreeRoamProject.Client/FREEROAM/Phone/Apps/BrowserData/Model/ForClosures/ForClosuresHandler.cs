using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using System.Collections.Generic;
namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.ForClosures
{
    internal class ForClosuresHandler
    {
        public static List<Clubhouse> Clubhouses = // func_7325 (maybe apartments.. needs digging)
        [
            new Clubhouse(3, 91),
            new Clubhouse(4, 92),
            new Clubhouse(5, 93),
            new Clubhouse(6, 94),
            new Clubhouse(7, 95),
            new Clubhouse(8, 96),
            new Clubhouse(9, 97),
            new Clubhouse(10, 98),
            new Clubhouse(11, 99),
            new Clubhouse(12, 100),
            new Clubhouse(13, 101),
            new Clubhouse(14, 102)
        ];

        public static List<Bunker> Bunkers = //func_7319
     [
         new Bunker(16, 21),
         new Bunker(17, 22),
         new Bunker(18, 23),
         new Bunker(19, 24),
         new Bunker(20, 25),
         new Bunker(21, 26),
         new Bunker(22, 27),
         new Bunker(23, 28),
         new Bunker(24, 29),
         new Bunker(25, 30),
         new Bunker(26, 31),
     ];

        //public List<ClubBusiness> //func_7319
        public static List<Hangar> Hangars =
        [
            new Hangar(48, 1),
            new Hangar(49, 2),
            new Hangar(50, 3),
            new Hangar(51, 4),
            new Hangar(52, 5),
        ];

        // facilities func_7307
        // Nightclub func_7299
        // arcades func_7291
        // MP_AUTOSHOPs func_7282
        public static List<Facility> Facilities = [
            new Facility(61, 1),
            new Facility(62, 2),
            new Facility(63, 3),
            new Facility(64, 4),
            new Facility(65, 5),
            new Facility(66, 6),
            new Facility(67, 7),
            new Facility(68, 8),
            new Facility(69, 9),
        ];

        public static List<Nightclub> Nightclubs =
        [
            new Nightclub(71, 1),
            new Nightclub(72, 2),
            new Nightclub(73, 3),
            new Nightclub(74, 4),
            new Nightclub(75, 5),
            new Nightclub(76, 6),
            new Nightclub(77, 7),
            new Nightclub(78, 8),
            new Nightclub(79, 9),
            new Nightclub(80, 10),
        ];

        public static List<Arcade> Arcades = [
            new Arcade(91, 1),
            new Arcade(92, 2),
            new Arcade(93, 3),
            new Arcade(94, 4),
            new Arcade(95, 5),
            new Arcade(96, 6),
        ];

        public static List<AutoShop> AutoShops = [
            new AutoShop(101, 1),
            new AutoShop(102, 2),
            new AutoShop(103, 3),
            new AutoShop(104, 4),
            new AutoShop(105, 5),
        ];

        public static async void LoadProperties(Apps.WebBrowser parent)
        {

            int iVar0 = GetCurrentLanguage();
            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(0);
            ScaleformMovieMethodAddParamInt(-1);// purchased clubhouseId
            ScaleformMovieMethodAddParamInt(-1);// purchased Wall
            ScaleformMovieMethodAddParamInt(-1);// purchased Hanging
            ScaleformMovieMethodAddParamInt(-1);// purchased furniture
            ScaleformMovieMethodAddParamInt(-1);// purchased mural
            ScaleformMovieMethodAddParamInt(-1);// purchased font
            ScaleformMovieMethodAddParamInt(-1);// purchased fontColour
            ScaleformMovieMethodAddParamInt(-1);// purchased emblem
            ScaleformMovieMethodAddParamInt(-1);// purchased hide signature
            PushScaleformMovieMethodParameterString_2(GetLabelText("GB_REST_ACCM"));// purchased signage (default?)
            PushScaleformMovieMethodParameterString_2("");// signage
            ScaleformMovieMethodAddParamInt(-11);// purchased gunLocker
            ScaleformMovieMethodAddParamInt(-12);// purchased bikeShop
            if (iVar0 == 6 || iVar0 == 7 || iVar0 == 8 || iVar0 == 9 || iVar0 == 10 || iVar0 == 12)
            {
                ScaleformMovieMethodAddParamBool(false);// purchased fontsSupported
            }
            else
            {
                ScaleformMovieMethodAddParamBool(true);// purchased fontsSupported
            }
            PushScaleformMovieMethodParameterString_2("");// purchased crew Emblem?
            EndScaleformMovieMethod();

            foreach (Clubhouse clubhouse in Clubhouses)
            {
                clubhouse.AddToScaleform(parent.browser);
            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(15);
            ScaleformMovieMethodAddParamInt(-1);// purchased Bunker id
            ScaleformMovieMethodAddParamInt(-1);// purchased Style
            ScaleformMovieMethodAddParamInt(-1);// purchased Quarters
            ScaleformMovieMethodAddParamInt(-1);// purchased FiringRangeSale
            ScaleformMovieMethodAddParamInt(-1);// purchased GunLocker
            ScaleformMovieMethodAddParamInt(-1);// purchased Transportation
            EndScaleformMovieMethod();

            foreach (Bunker bunker in Bunkers)
            {
                bunker.AddToScaleform(parent.browser);
            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(47);
            ScaleformMovieMethodAddParamInt(-1);// purchased hangar id 
            ScaleformMovieMethodAddParamInt(-1);// purchased style
            ScaleformMovieMethodAddParamInt(-1);// purchased Lighting
            ScaleformMovieMethodAddParamInt(-1);// purchased decal
            ScaleformMovieMethodAddParamInt(-1);// purchased furniture
            ScaleformMovieMethodAddParamInt(-1);// purchased quarters
            ScaleformMovieMethodAddParamInt(-1);// purchased workshop
            EndScaleformMovieMethod();

            foreach (Hangar hangar in Hangars)
            {
                hangar.AddToScaleform(parent.browser);

            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(60);
            ScaleformMovieMethodAddParamInt(-1); // purchased Facility Id // ScaleformMovieMethodAddParamInt(Global_77259 + 40);
            ScaleformMovieMethodAddParamInt(-1); // purchased Styles id
            ScaleformMovieMethodAddParamInt(-1); // purchased Graphics id
            ScaleformMovieMethodAddParamInt(-1); // purchased SleepQuarters id
            ScaleformMovieMethodAddParamInt(-1); // purchased OrbitalCannon id
            ScaleformMovieMethodAddParamInt(-1); // purchased SecurityRoom id
            ScaleformMovieMethodAddParamInt(-1); // purchased Lounge id
            ScaleformMovieMethodAddParamInt(-1); // purchased PrivacyGlass id
            EndScaleformMovieMethod();

            foreach (Facility facility in Facilities)
            {
                facility.AddToScaleform(parent.browser);
            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(70);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            EndScaleformMovieMethod();

            foreach (Nightclub night in Nightclubs)
            {
                night.AddToScaleform(parent.browser);
            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(90);
            ScaleformMovieMethodAddParamInt(-1); // arcade id + 60
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            EndScaleformMovieMethod();

            foreach (Arcade arcade in Arcades)
            {
                arcade.AddToScaleform(parent.browser);
            }


            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(100);
            ScaleformMovieMethodAddParamInt(-1); // autoshop id + 70
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamTextureNameString_2(""); // NETWORK_CLAN_PLAYER_GET_DESC
            ScaleformMovieMethodAddParamTextureNameString_2(""); // NETWORK_CLAN_GET_EMBLEM_TXD_NAME
            EndScaleformMovieMethod();

            foreach (AutoShop autoshop in AutoShops)
            {
                autoshop.AddToScaleform(parent.browser);
            }
        }


        public static void GetPurchasedClubhouseData(int bitwiseValue, ref int clubHouseIndex, ref int wall, ref int hanging, ref int furniture, ref int mural, ref int font, ref int fontColour, ref int emblem, ref bool hideSignage, ref string signage, ref bool gunLocker, ref bool bikeShop)
        {
            Debug.WriteLine("bitwiseValue:" + bitwiseValue);
            clubHouseIndex = Tools.GetValueFromBitwiseValue(bitwiseValue, 0, 6);
            clubHouseIndex += 91;

            wall = Tools.GetValueFromBitwiseValue(bitwiseValue, 6, 1);
            hanging = Tools.GetValueFromBitwiseValue(bitwiseValue, 7, 1);
            furniture = Tools.GetValueFromBitwiseValue(bitwiseValue, 8, 1);
            mural = func_5600(clubHouseIndex, Tools.GetValueFromBitwiseValue(bitwiseValue, 9, 4));
            font = Tools.GetValueFromBitwiseValue(bitwiseValue, 13, 4);
            fontColour = Tools.GetValueFromBitwiseValue(bitwiseValue, 17, 4);
            emblem = Tools.GetValueFromBitwiseValue(bitwiseValue, 21, 4);
            hideSignage = Tools.GetValueFromBitwiseValue(bitwiseValue, 25, 1) == 1;
            gunLocker = Tools.GetValueFromBitwiseValue(bitwiseValue, 26, 1) == 1;
            bikeShop = Tools.GetValueFromBitwiseValue(bitwiseValue, 27, 1) == 1;

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
    }
}
