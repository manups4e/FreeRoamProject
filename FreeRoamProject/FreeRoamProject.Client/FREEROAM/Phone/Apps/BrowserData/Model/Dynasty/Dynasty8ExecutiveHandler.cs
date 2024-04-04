using System.Collections.Generic;
namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty
{
    internal class Dynasty8ExecutiveHandler
    {
        /*
            static var OWNED_OFFICE_DATA_INDEX = 0;
   static var OFFICE_DATA_START_INDEX = 3;
   static var OFFICE_DATA_END_INDEX = 6;
   static var OWNED_AGENCY_DATA_INDEX = 7;
   static var AGENCY_DATA_START_INDEX = 8;
   static var AGENCY_DATA_END_INDEX = 11;*/

        public static List<Office> Offices =
        [
            new Office(3, 87),
            new Office(4, 88),
            new Office(5, 89),
            new Office(6, 90),
        ];

        public static List<Agency> Agencies =
        [
            new Agency(8, 1),
            new Agency(9, 2),
            new Agency(10, 3),
            new Agency(11, 4),
        ];

        public static async void LoadOffices(Apps.WebBrowser parent)
        {
            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(0);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_1*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_2*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_3*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_4*/);
            PushScaleformMovieMethodParameterString_2(""/*&(Global_77119.f_5)*/);
            PushScaleformMovieMethodParameterString_2(""/*&(Global_77119.f_21)*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_37*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_38*/);
            ScaleformMovieMethodAddParamInt(-1 /*Global_77119.f_39*/);
            int iVar0 = GetCurrentLanguage();
            if (iVar0 == 6 || iVar0 == 7 || iVar0 == 8 || iVar0 == 9 || iVar0 == 10 || iVar0 == 12)
            {
                ScaleformMovieMethodAddParamBool(false);
            }
            else
            {
                ScaleformMovieMethodAddParamBool(true);
            }
            EndScaleformMovieMethod();
            BeginScaleformMovieMethod(parent.browser.Handle, "APPEND_OFFICE_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(0);
            //if (Global_77119.f_41 != -1)
            //{
            ScaleformMovieMethodAddParamInt(-1/*1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_41*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_42*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_43*/);
            //}
            //if (Global_77119.f_44 != -1)
            //{
            ScaleformMovieMethodAddParamInt(-1/*1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_44*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_45*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_46*/);
            //}
            //if (Global_77119.f_47 != -1)
            //{
            ScaleformMovieMethodAddParamInt(-1/*1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_47*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_48*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_49*/);
            //}
            //if (Global_77119.f_50 != -1)
            //{
            ScaleformMovieMethodAddParamInt(-1/*1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77119.f_50*/);
            //}
            EndScaleformMovieMethod();
            //}

            foreach (Office office in Offices)
            {
                office.AddToScaleform(parent.browser);
            }

            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(7);
            //if (Global_77170 == -1)
            //{
            ScaleformMovieMethodAddParamInt(-1);
            //}
            //else
            //{
            //    ScaleformMovieMethodAddParamInt(Global_77170 + 20);
            //}
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_2*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_3*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_4*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_5*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77170.f_6*/);
            EndScaleformMovieMethod();

            foreach (Agency agency in Agencies)
            {
                agency.AddToScaleform(parent.browser);
            }
        }
    }
}
