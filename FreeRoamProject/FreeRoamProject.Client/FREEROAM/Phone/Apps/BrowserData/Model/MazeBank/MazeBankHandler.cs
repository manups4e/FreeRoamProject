using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData.Model.MazeBank
{
    public static class MazeBankHandler
    {
        static bool withdrawDisabled = true;
        static int pageType = 0;
        static int moneyToHandle = -1;
        static int msgPage = 0;
        public static async void LoadBank(Apps.WebBrowser parent)
        {
            switch (parent.CurrentPageId)
            {
                case 1:
                    parent.browser.CallFunction("SET_DATA_SLOT", 1, PlayerCache.MyPlayer.Name);
                    break;
                case 2:
                    parent.browser.CallFunction("SET_DATA_SLOT", 0, PlayerCache.Character.Finance.Bank);
                    parent.browser.CallFunction("SET_DATA_SLOT", 1, PlayerCache.MyPlayer.Name);
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(2);
                    Tools.SetScaleformString("MPATM_LOG");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(3);
                    ScaleformMovieMethodAddParamInt(PlayerCache.Character.Finance.Bank);
                    Tools.SetScaleformString("MPATM_ACBA");
                    EndScaleformMovieMethod();
                    List<BankTransaction> transactions = await EventDispatcher.Get<List<BankTransaction>>("tlg:banking:requestTransactions");
                    int slot = 4;
                    foreach (BankTransaction trans in transactions.OrderByDescending(x => x.TransactionDate).Take(16))
                    {
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(slot);
                        ScaleformMovieMethodAddParamInt(trans.Paid ? 0 : 1);
                        ScaleformMovieMethodAddParamInt((int)trans.Amount);
                        if (string.IsNullOrWhiteSpace(trans.PlayerName))
                        {
                            BeginTextCommandScaleformString(trans.Label);
                            AddTextComponentSubstringPlayerName(trans.PlayerName);
                            EndTextCommandScaleformString();
                        }
                        else
                        {
                            if (trans.Label != "ADMIN_REGULATION")
                                Tools.SetScaleformString(trans.Label);
                            else
                            {
                                BeginTextCommandScaleformString("STRING");
                                AddTextComponentSubstringPlayerName("Admin transaction");
                                EndTextCommandScaleformString();
                            }
                        }
                        EndScaleformMovieMethod();
                        slot++;
                    }
                    parent.UpdateText();
                    break;
                case 3:
                    parent.browser.CallFunction("SET_DATA_SLOT", 0, PlayerCache.Character.Finance.Bank);
                    parent.browser.CallFunction("SET_DATA_SLOT", 1, PlayerCache.MyPlayer.Name);
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(2);
                    Tools.SetScaleformString("MPATM_SER");
                    EndScaleformMovieMethod();
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(3);
                    Tools.SetScaleformString("MPATM_DIDM");
                    EndScaleformMovieMethod();
                    if (PlayerCache.Character.Finance.Money >= func_7370(0, false, PlayerCache.Character.Finance.Money))
                    {
                        withdrawDisabled = false;
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(4);
                        Tools.SetScaleformString("MPATM_WITM");
                        EndScaleformMovieMethod();
                    }
                    else
                    {
                        BeginScaleformMovieMethod(parent.browser.Handle, "DISABLE_BUTTON");
                        ScaleformMovieMethodAddParamInt(4);
                        Tools.SetScaleformString("MPATM_WITM");
                        ScaleformMovieMethodAddParamBool(false);
                        EndScaleformMovieMethod();
                    }
                    withdrawDisabled = false;
                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt(5);
                    Tools.SetScaleformString("MPATM_LOG");
                    EndScaleformMovieMethod();
                    break;
                case 4:
                    if (PlayerCache.Character.Finance.Bank >= func_7370(0, false, PlayerCache.Character.Finance.Bank) && func_7370(0, true, PlayerCache.Character.Finance.Bank) != -1) // withdraw
                    {
                        parent.browser.CallFunction("SET_DATA_SLOT_EMPTY");
                        parent.browser.CallFunction("SET_DATA_SLOT", 0, PlayerCache.Character.Finance.Bank);
                        parent.browser.CallFunction("SET_DATA_SLOT", 1, PlayerCache.MyPlayer.Name);
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(2);
                        Tools.SetScaleformString("MPATM_WITMT");
                        EndScaleformMovieMethod();
                        for (int i = 0; i <= 5; i++)
                        {
                            if (PlayerCache.Character.Finance.Bank >= func_7370(i, false, PlayerCache.Character.Finance.Bank) && func_7370(i, true, PlayerCache.Character.Finance.Bank) != -1)
                            {
                                BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                                ScaleformMovieMethodAddParamInt(i + 3);
                                BeginTextCommandScaleformString("ESDOLLA");
                                AddTextComponentFormattedInteger(func_7370(i, true, PlayerCache.Character.Finance.Bank), true);
                                EndTextCommandScaleformString();
                                EndScaleformMovieMethod();
                            }
                        }
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(9);
                        Tools.SetScaleformString("MPATM_BACK");
                        EndScaleformMovieMethod();
                    }
                    else
                    {
                        pageType = 2;
                        parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                    }
                    break;
                case 5:
                    if (PlayerCache.Character.Finance.Money >= func_7370(0, true, PlayerCache.Character.Finance.Money) && func_7370(0, true, PlayerCache.Character.Finance.Money) != -1) // deposit
                    {
                        parent.browser.CallFunction("SET_DATA_SLOT_EMPTY");
                        parent.browser.CallFunction("SET_DATA_SLOT", 0, PlayerCache.Character.Finance.Bank);
                        parent.browser.CallFunction("SET_DATA_SLOT", 1, PlayerCache.MyPlayer.Name);
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(2);
                        Tools.SetScaleformString("MPATM_DITMT");
                        EndScaleformMovieMethod();
                        for (int i = 0; i <= 5; i++)
                        {
                            if (PlayerCache.Character.Finance.Money >= func_7370(i, true, PlayerCache.Character.Finance.Money) && func_7370(i, true, PlayerCache.Character.Finance.Money) != -1)
                            {
                                BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                                ScaleformMovieMethodAddParamInt(i + 3);
                                BeginTextCommandScaleformString("ESDOLLA");
                                AddTextComponentFormattedInteger(func_7370(i, true, PlayerCache.Character.Finance.Money), true);
                                EndTextCommandScaleformString();
                                EndScaleformMovieMethod();
                            }
                        }
                        BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                        ScaleformMovieMethodAddParamInt(9);
                        Tools.SetScaleformString("MPATM_BACK");
                        EndScaleformMovieMethod();
                    }
                    else
                    {
                        pageType = 1;
                        parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                    }
                    break;
                case 6:
                    switch (pageType)
                    {
                        case 1:
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(0);
                            Tools.SetScaleformString("MPATM_NODO2");
                            EndScaleformMovieMethod();
                            break;
                        case 2:
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(0);
                            Tools.SetScaleformString("MPATM_NODO");
                            EndScaleformMovieMethod();
                            break;
                        case 3:
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(0);
                            Tools.SetScaleformString("MPATM_ERR");
                            EndScaleformMovieMethod();
                            break;
                    }
                    break;
                case 7:
                    break;
                case 8:
                    msgPage = 0;
                    switch (pageType)
                    {
                        case 1:
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(0);
                            BeginTextCommandScaleformString("MPATC_CONFW");
                            AddTextComponentFormattedInteger(moneyToHandle, true);
                            EndTextCommandScaleformString();
                            EndScaleformMovieMethod();
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(1);
                            Tools.SetScaleformString("MO_YES");
                            EndScaleformMovieMethod();
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(2);
                            Tools.SetScaleformString("MO_NO");
                            EndScaleformMovieMethod();
                            break;
                        case 2:
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(0);
                            BeginTextCommandScaleformString("MPATM_CONF");
                            AddTextComponentFormattedInteger(moneyToHandle, true);
                            EndTextCommandScaleformString();
                            EndScaleformMovieMethod();
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(1);
                            Tools.SetScaleformString("MO_YES");
                            EndScaleformMovieMethod();
                            BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                            ScaleformMovieMethodAddParamInt(2);
                            Tools.SetScaleformString("MO_NO");
                            EndScaleformMovieMethod();
                            break;
                    }
                    break;
            }
        }

        public static async void HandleClick(Apps.WebBrowser parent)
        {
            if (parent.CurrentSelection == -1) return;
            switch (parent.CurrentPageId)
            {
                case 3:
                    switch (parent.CurrentSelection)
                    {
                        case 3:
                            if (PlayerCache.Character.Finance.Bank >= func_7370(0, false, PlayerCache.Character.Finance.Bank))
                            {
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_DEPOSIT");
                            }
                            else
                            {
                                pageType = 1;
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                            }
                            break;
                        case 4:
                            if (PlayerCache.Character.Finance.Money >= func_7370(0, false, PlayerCache.Character.Finance.Money))
                            {
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_WITHDRAW");
                            }
                            else
                            {
                                pageType = 2;
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                            }
                            break;
                        case 5:
                            parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_TRANSACTIONS");
                            break;
                    }
                    break;
                case 4:
                    {
                        pageType = 1;
                        if (parent.CurrentSelection > 2 && parent.CurrentSelection < 9)
                        {
                            moneyToHandle = func_7370(parent.CurrentSelection - 3, true, PlayerCache.Character.Finance.Bank);
                            parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_MESSAGE");
                        }
                        else
                        {
                            parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                        }
                    }
                    break;
                case 5:
                    {
                        pageType = 2;
                        if (parent.CurrentSelection > 2 && parent.CurrentSelection < 9)
                        {
                            moneyToHandle = func_7370(parent.CurrentSelection - 3, true, PlayerCache.Character.Finance.Bank);
                            parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_MESSAGE");
                        }
                        else
                        {
                            parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                        }
                    }
                    break;
                case 8:
                    {
                        if (msgPage == 0)
                        {
                            if (parent.CurrentSelection == 0)
                            {
                                string @event = "";
                                if (pageType == 1) // withdraw
                                {
                                    @event = "atmwithdraw";
                                }
                                else if (pageType == 2) // deposit
                                {
                                    @event = "atmdeposit";
                                }
                                KeyValuePair<bool, string> trans = await EventDispatcher.Get<KeyValuePair<bool, string>>("tlg:banking:" + @event, moneyToHandle);
                                if (trans.Key)
                                {
                                    msgPage = 1;
                                    parent.browser.CallFunction("SET_DATA_SLOT_EMPTY");
                                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                                    ScaleformMovieMethodAddParamInt(0);
                                    Tools.SetScaleformString("MPATM_TRANCOM");
                                    EndScaleformMovieMethod();
                                    BeginScaleformMovieMethod(parent.browser.Handle, "SET_DATA_SLOT");
                                    ScaleformMovieMethodAddParamInt(1);
                                    Tools.SetScaleformString("MPATM_MENU");
                                    EndScaleformMovieMethod();
                                    parent.UpdateText();
                                }
                                else
                                {
                                    pageType = 3;
                                    parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_ERROR");
                                }
                            }
                            else
                            {
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_MAINMENU");
                            }
                        }
                        else
                        {
                            if (parent.CurrentSelection == 0)
                                parent.GoToWebPage("WWW_MAZE_D_BANK_COM_S_MAINMENU");

                        }
                    }
                    break;
            }
        }

        static int func_7370(int iParam0, bool bParam1, int cash)//Position - 0x26D3F9
        {
            int iVar0;

            iVar0 = cash;
            ClientMain.Logger.Debug("cash:" + cash);
            switch (iParam0)
            {
                case 0:
                    if (bParam1)
                    {
                        if (iVar0 == 0)
                        {
                            return -1;
                        }
                        else if (iVar0 < 50)
                        {
                            return iVar0;
                        }
                        else
                        {
                            return 50;
                        }
                    }
                    else
                    {
                        return 50;
                    }
                case 1:
                    if (bParam1)
                    {
                        if (iVar0 <= 2500)
                        {
                            return -1;
                        }
                        else if (iVar0 > 2500 && iVar0 < 10000)
                        {
                            return iVar0;
                        }
                        else
                        {
                            return 10000;
                        }
                    }
                    else
                    {
                        return 10000;
                    }
                case 2:
                    if (bParam1)
                    {
                        if (iVar0 <= 50)
                        {
                            return -1;
                        }
                        else if (iVar0 > 50 && iVar0 < 500)
                        {
                            return iVar0;
                        }
                        else
                        {
                            return 500;
                        }
                    }
                    else
                    {
                        return 500;
                    }
                case 3:
                    if (bParam1)
                    {
                        if (iVar0 <= 10000)
                        {
                            return -1;
                        }
                        else if (iVar0 > 10000 && iVar0 < 100000)
                        {
                            return iVar0;
                        }
                        else
                        {
                            return 100000;
                        }
                    }
                    else
                    {
                        return 100000;
                    }
                case 4:
                    if (bParam1)
                    {
                        if (iVar0 <= 500)
                        {
                            return -1;
                        }
                        else if (iVar0 > 500 && iVar0 < 2500)
                        {
                            return iVar0;
                        }
                        else
                        {
                            return 2500;
                        }
                    }
                    else
                    {
                        return 2500;
                    }
                case 5:
                    if (bParam1)
                    {
                        if (iVar0 <= 100000)
                        {
                            return -1;
                        }
                        else
                        {
                            return iVar0;
                        }
                    }
                    else
                    {
                        return 1000000;
                    }
            }
            return 0;
        }
    }
}
