using FreeRoamProject.Server.Core.PlayerChar;
using FreeRoamProject.Shared.Core.Character;
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
            EventDispatcher.Mount("tlg:banking:requestTransactions", new Func<PlayerClient, Task<List<BankTransaction>>>(SendList));
        }
        private static async Task<KeyValuePair<bool, string>> Withdraw([FromSource] PlayerClient source, int amount)
        {
            User user = source.User;
            int bal = user.Bank;
            int newamt = bal - amount;
            ServerMain.Logger.Debug("withdraw: " + amount);
            if (bal >= amount)
            {
                user.Money += amount;
                user.PerformBankTransaction(-amount, BankTransactionType.Withdraw);
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

            ServerMain.Logger.Debug("deposit: " + amount);
            if (amount <= money)
            {
                user.Money -= amount;
                user.PerformBankTransaction(amount, BankTransactionType.Deposit);
                return new KeyValuePair<bool, string>(true, newamt.ToString());
            }
            return new KeyValuePair<bool, string>(false, "MPATM_NODO");
        }

        private static async Task<List<BankTransaction>> SendList([FromSource] PlayerClient source)
        {
            return source.User.Character.Finance.Transactions;
        }
    }
}