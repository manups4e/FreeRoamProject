using System.Collections.Generic;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty
{
    public class Dynasty8RealEstateHandler
    {
        public static List<Apartment> Apartments = [];
        public static async void LoadApartments(Apps.WebBrowser parent) // func_7472
        {
            Apartments.Clear();
            int slot = 0;
            for (int i = 1; i <= 130; i++)
            {
                if (func_7324(i) == 1 || i == 86 || func_244(i) == 1 || func_247(i, -1) == 1 || func_7561(i, false, false) == 1 || i == 115 || i == 116 || i == 117 || i == 118 || func_7481(i) == 1 || func_7480(i) == 1 || i == 125 || i == 126)
                {
                    continue;
                }
                Apartment apart = new Apartment(slot, i);
                if (string.IsNullOrEmpty(apart.Label(apart.Id)) && apart.Id != 129)
                    continue;
                Debug.WriteLine($"slot:{apart.Slot}, id:{apart.Id}, name:{API.GetLabelText(apart.Label(apart.Id))}, price:{apart.BaseCost}");
                apart.AddToScaleform(parent.browser);
                slot++;
            }
        }

        static int func_7324(int iParam0)//Position - 0x266C6C
        {
            if (Tunables.Global_262145.Value<int>("f_13299") == 1 /* Tunable: APT_DISABLE_CUSTOM1 */ && iParam0 == 83)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13300") == 1 /* Tunable: APT_DISABLE_CUSTOM2 */ && iParam0 == 84)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13301") == 1 /* Tunable: APT_DISABLE_CUSTOM3 */ && iParam0 == 85)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13311") == 1 /* Tunable: APT_DISABLE_STILT1 */ && iParam0 == 73)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13312") == 1 /* Tunable: APT_DISABLE_STILT2 */ && iParam0 == 74)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13313") == 1 /* Tunable: APT_DISABLE_STILT3 */ && iParam0 == 75)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13314") == 1 /* Tunable: APT_DISABLE_STILT4 */ && iParam0 == 76)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13315") == 1 /* Tunable: APT_DISABLE_STILT5 */ && iParam0 == 77)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13316") == 1 /* Tunable: APT_DISABLE_STILT6 */ && iParam0 == 78)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13317") == 1 /* Tunable: APT_DISABLE_STILT7 */ && iParam0 == 79)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13318") == 1 /* Tunable: APT_DISABLE_STILT8 */ && iParam0 == 80)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13319") == 1 /* Tunable: APT_DISABLE_STILT9 */ && iParam0 == 81)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_13320") == 1 /* Tunable: APT_DISABLE_STILT10 */ && iParam0 == 82)
                return 1;
            if (Tunables.Global_262145.Value<int>("f_18379") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_0 */ && iParam0 == 91)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18380") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_1 */ && iParam0 == 92)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18381") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_2 */ && iParam0 == 93)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18382") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_3 */ && iParam0 == 94)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18383") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_4 */ && iParam0 == 95)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18384") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_5 */ && iParam0 == 96)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18385") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_6 */ && iParam0 == 97)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18386") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_7 */ && iParam0 == 98)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18387") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_8 */ && iParam0 == 99)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18388") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_9 */ && iParam0 == 100)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18389") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_10 */ && iParam0 == 101)
                return 1;
            else if (Tunables.Global_262145.Value<int>("f_18390") == 1 /* Tunable: BIKER_DISABLE_PURCHASE_CLUBHOUSE_11 */ && iParam0 == 102)
                return 1;
            return 0;
        }
        static int func_244(int iParam0)//Position - 0x25274
        {
            return iParam0 switch
            {
                87 or 88 or 89 or 90 => 1,
                _ => 0,
            };
        }
        static int func_247(int iParam0, int iParam1)//Position - 0x25306
        {
            switch (iParam1)
            {
                case -1:
                    switch (iParam0)
                    {
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                        case 97:
                        case 98:
                        case 99:
                        case 100:
                        case 101:
                        case 102:
                            return 1;
                            break;
                    }
                    break;
                case 91:
                    switch (iParam0)
                    {
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                            return 1;
                            break;
                    }
                    break;
                case 97:
                    switch (iParam0)
                    {
                        case 97:
                        case 98:
                        case 99:
                        case 100:
                        case 101:
                        case 102:
                            return 1;
                            break;
                    }
                    break;
            }
            return 0;
        }
        static int func_7561(int iParam0, bool bParam1, bool bParam2)//Position - 0x2851E5
        {
            return iParam0 switch
            {
                103 or 106 or 109 or 112 or 104 or 107 or 110 or 113 or 105 or 108 or 111 or 114 => 1,
                _ => 0,
            };
        }
        static int func_7480(int iParam0)//Position - 0x27D8B6
        {
            return iParam0 switch
            {
                122 or 123 or 124 => 1,
                _ => 0,
            };
        }

        static int func_7481(int iParam0)//Position - 0x27D8DF
        {
            return iParam0 switch
            {
                119 or 120 or 121 => 1,
                _ => 0,
            };
        }
    }
}
