using FreeRoamProject.Server.Core.PlayerChar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.FREEROAM.Banking
{
    internal static class BankingServer
    {
        public static void Init()
        {
            EventDispatcher.Mount("tlg:banking:atmwithdraw", new Func<PlayerClient, int, Task<KeyValuePair<bool, string>>>(Withdraw));
            EventDispatcher.Mount("tlg:banking:atmdeposit", new Func<PlayerClient, int, Task<KeyValuePair<bool, string>>>(Deposit));
        }
        private static async Task<KeyValuePair<bool, string>> Withdraw([FromSource] PlayerClient source, int amount)
        {
            User user = source.User;
            int bal = user.Bank;
            int newamt = bal - amount;

            if (bal >= amount)
            {
                user.Money += amount;
                user.Bank -= amount;
                return new KeyValuePair<bool, string>(true, newamt.ToString());
            }
            return new KeyValuePair<bool, string>(false, "MPATM_NODO2");
        }

        private static async Task<KeyValuePair<bool, string>> Deposit([FromSource] PlayerClient source, int amount)
        {
            User user = source.User;
            int money = user.Money;
            int bankmoney = user.Bank;
            int newamt = bankmoney + amount;

            if (amount <= money)
            {
                user.Money -= amount;
                user.Bank += amount;
                return new KeyValuePair<bool, string>(true, newamt.ToString());
            }
            return new KeyValuePair<bool, string>(false, "MPATM_NODO");
        }
    }
}