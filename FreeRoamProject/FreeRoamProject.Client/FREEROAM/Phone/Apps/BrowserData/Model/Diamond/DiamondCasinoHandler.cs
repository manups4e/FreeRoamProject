using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Diamond;
namespace FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData.Model.Diamond
{
    internal class DiamondCasinoHandler
    {
        public static DiamondCasino Casino = new();
        public static void LoadCasino(WebBrowser parent) //func_7269
        {
            #region bought casino?
            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(10);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_1*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_2*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_3*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_4*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_5*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_6*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_7*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_8*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_9*/);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_10*/);
            ScaleformMovieMethodAddParamInt(-1);
            ScaleformMovieMethodAddParamInt(-1/*Global_77346.f_11*/);
            PushScaleformMovieMethodParameterString_2(""/*Global_77346.f_12*/);
            PushScaleformMovieMethodParameterString_2(""/*Global_77346.f_28*/);
            ScaleformMovieMethodAddParamBool(Tunables.Global_262145.Value<int>("f_27181") == 1 /* Tunable: 1206012266 */);
            ScaleformMovieMethodAddParamBool(false);
            ScaleformMovieMethodAddParamBool(false);
            EndScaleformMovieMethod();
            #endregion

            #region Casino

            Casino.AddToScaleform(parent.browser);

            #endregion
        }

        static bool func_118(int iParam0)//Position - 0x6878
        {
            int iVar0 = 0;
            switch (iParam0)
            {
                case 0:
                    iVar0 = GetHashKey("GTAO_CASINO_SLOTS");
                    break;

                case 1:
                    iVar0 = GetHashKey("GTAO_CASINO_BLACKJACK");
                    break;

                case 2:
                    iVar0 = GetHashKey("GTAO_CASINO_3CARDPOKER");
                    break;

                case 5:
                    iVar0 = GetHashKey("GTAO_CASINO_INSIDETRACK");
                    break;

                case 3:
                    iVar0 = GetHashKey("GTAO_CASINO_ROULETTE");
                    break;

                case 4:
                    iVar0 = GetHashKey("GTAO_CASINO_LUCKYWHEEL");
                    break;
            }
            if (!NetworkCasinoCanUseGamblingType((uint)iVar0))
            {
                return true;
            }
            return false;
        }
    }
}
