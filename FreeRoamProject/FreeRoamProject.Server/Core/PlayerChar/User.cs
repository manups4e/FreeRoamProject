using FreeRoamProject.Shared.Core;
using FreeRoamProject.Shared.Core.Character;
using FreeRoamProject.Shared.PlayerChar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Server.Core.PlayerChar
{
    public class User : BasePlayerShared
    {
        [JsonIgnore] internal string source;
        [JsonIgnore] internal DateTime LastSaved;
        [JsonIgnore] internal BasePlayerShared basePlayer;

        public User() { }
        public User(Player player, BasePlayerShared result)
        {
            basePlayer = result;
            Name = player.Name;
            source = player.Handle;
            ID = result.ID;
            PlayerID = result.PlayerID;
            group = result.group;
            group_level = result.group_level;
            playTime = result.playTime;
            LastSaved = DateTime.Now;
            Player = player;
            Identifiers = new()
            {
                Steam = player.GetLicense(Identifier.Steam),
                License = player.GetLicense(Identifier.License),
                Discord = player.GetLicense(Identifier.Discord),
                Fivem = player.GetLicense(Identifier.Fivem),
                Ip = player.GetLicense(Identifier.Ip),
            };
        }

        public User(Player player, dynamic result)
        {
            source = player.Handle;
            ID = result.UserID;
            group = result.group;
            group_level = (UserGroup)result.group_level;
            playTime = result.playTime;
            LastSaved = DateTime.Now;
        }

        public User(dynamic result)
        {
            //source = player.Handle;
            group = result.group;
            group_level = (UserGroup)result.group_level;
            playTime = result.playTime;
            //p = player;
            LastSaved = DateTime.Now;
        }


        [JsonIgnore]
        internal bool DeathStatus
        {
            get => Character.is_dead;
            set
            {
                Character.is_dead = value;
            }
        }


        [JsonIgnore]
        internal int Money
        {
            get => Character.Finance.Money;
            set
            {
                int var = value - Character.Finance.Money;
                Character.Finance.Money += var;
                if (var < 0)
                    if (Character.Finance.Money < 0)
                        Character.Finance.Money = 0;
                Player.TriggerSubsystemEvent("tlg:changeMoney", var);
            }
        }


        [JsonIgnore]
        internal int Bank
        {
            get => Character.Finance.Bank;
            private set
            {
                int var = value - Character.Finance.Bank;
                Character.Finance.Bank += var;
                Player.TriggerSubsystemEvent("tlg:changeBank", var);
            }
        }

        /// <summary>
        /// Performs a Bank transaction with automatic adding to player's transaction List
        /// </summary>
        /// <param name="amount">amount can be positive or negative</param>
        /// <param name="type">Type of transaction</param>
        /// <param name="transaction">Transaction hash, if None specified and type == MoneySpent / MoneyEarn, their default values will be used (purchase/refund labels)</param>
        /// <param name="playerName">(Optional) if the transaction was made from / to another player, specify the player's name</param>
        public void PerformBankTransaction(int amount, BankTransactionType type, BankingTransactionHash transaction = BankingTransactionHash.NONE, string playerName = null)
        {
            if (amount == 0) return;
            bool isPayment = false;
            string transactionLabel = "";
            switch (type)
            {
                case BankTransactionType.AdminAdd:
                    transactionLabel = "ADMIN_REGULATION";
                    isPayment = false;
                    break;
                case BankTransactionType.AdminRemove:
                    transactionLabel = "ADMIN_REGULATION";
                    isPayment = true;
                    break;
                case BankTransactionType.Withdraw:
                    transactionLabel = "MPATM_PLCHLDR_WDR";
                    isPayment = false;
                    break;
                case BankTransactionType.Deposit:
                    transactionLabel = "MPATM_PLCHLDR_CAD";
                    isPayment = true;
                    break;
                case BankTransactionType.DepositedBySomeone:
                    transactionLabel = "MPATM_PLCHLDR_CRF";
                    isPayment = true;
                    break;
                case BankTransactionType.CashSentToSomeone:
                    transactionLabel = "MPATM_PLCHLDR_CST";
                    isPayment = false;
                    break;
                case BankTransactionType.VirtualCurrencyBought:
                    transactionLabel = "MPATM_PLCHLDR_BRT";
                    isPayment = true;
                    break;
                case BankTransactionType.MoneySpent:
                    switch (transaction)
                    {
                        case BankingTransactionHash.MONEY_SPENT_CONTACT_SERVICE:
                            transactionLabel = "MONEY_SPENT_CONTACT_SERVICE";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_PROPERTY_UTIL:
                            transactionLabel = "MONEY_SPENT_PROPERTY_UTIL";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_JOB_ACTIVITY:
                            transactionLabel = "MONEY_SPENT_JOB_ACTIVITY";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_BETTING:
                            transactionLabel = "MONEY_SPENT_BETTING";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_STYLE_ENT:
                            transactionLabel = "MONEY_SPENT_STYLE_ENT";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_HEALTHCARE:
                            transactionLabel = "MONEY_SPENT_HEALTHCARE";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_FROM_DEBUG:
                            transactionLabel = "MONEY_SPENT_FROM_DEBUG";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_DROPPED_STOLEN:
                            transactionLabel = "MONEY_SPENT_DROPPED_STOLEN";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_VEH_MAINTENANCE:
                            transactionLabel = "MONEY_SPENT_VEH_MAINTENANCE";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_HOLDUPS:
                            transactionLabel = "MONEY_SPENT_HOLDUPS";
                            break;
                        case BankingTransactionHash.MONEY_SPENT_PASSIVEMODE:
                            transactionLabel = "MONEY_SPENT_PASSIVEMODE";
                            break;
                        default:
                            transactionLabel = "MPATM_PLCHLDR_PRCH";
                            break;
                    }
                    isPayment = true;
                    break;
                case BankTransactionType.MoneyEarn:
                    switch (transaction)
                    {
                        case BankingTransactionHash.MONEY_EARN_JOBS:
                            transactionLabel = "MONEY_EARN_JOBS";
                            break;
                        case BankingTransactionHash.MONEY_EARN_SELLING_VEH:
                            transactionLabel = "MONEY_EARN_SELLING_VEH";
                            break;
                        case BankingTransactionHash.MONEY_EARN_BETTING:
                            transactionLabel = "MONEY_EARN_BETTING";
                            break;
                        case BankingTransactionHash.MONEY_EARN_GOOD_SPORT:
                            transactionLabel = "MONEY_EARN_GOOD_SPORT";
                            break;
                        case BankingTransactionHash.MONEY_EARN_PICKED_UP:
                            transactionLabel = "MONEY_EARN_PICKED_UP";
                            break;
                        case BankingTransactionHash.MONEY_EARN_SHARED:
                            transactionLabel = "MONEY_EARN_SHARED";
                            break;
                        case BankingTransactionHash.MONEY_EARN_JOBSHARED:
                            transactionLabel = "MONEY_EARN_JOBSHARED";
                            break;
                        case BankingTransactionHash.MONEY_EARN_ROCKSTAR_AWARD:
                            transactionLabel = "MONEY_EARN_ROCKSTAR_AWARD";
                            break;
                        case BankingTransactionHash.MONEY_EARN_REFUND:
                            transactionLabel = "MONEY_EARN_REFUND";
                            break;
                        case BankingTransactionHash.MONEY_EARN_JOB_BONUS:
                            transactionLabel = "MONEY_EARN_JOB_BONUS";
                            break;
                        case BankingTransactionHash.MONEY_EARN_HEIST_JOB:
                            transactionLabel = "MONEY_EARN_HEIST_JOB";
                            break;
                        default:
                            transactionLabel = "MPATM_PLCHLDR_REF";
                            break;
                    }
                    isPayment = false;
                    break;
            }
            if (isPayment)
                Bank -= amount;
            else
                Bank += amount;
            Character.Finance.Transactions.Add(new BankTransaction(isPayment, amount, transactionLabel, playerName));
        }

        // TODO: Handle CEO, Motorcycle club, and all
        public void SetGang(string job, int grade)
        {
            Character.Gang.Name = job;
            Character.Gang.Grade = grade;
        }

        // TODO: inventory online is something else.. not RP Like
        /*
        public Tuple<bool, Inventory> getInventoryItem(string item)
        {
            for (int i = 0; i < CurrentChar.Inventory.Count; i++)
                if (CurrentChar.Inventory[i].Item == item)
                    return new Tuple<bool, Inventory>(true, CurrentChar.Inventory[i]);

            return new Tuple<bool, Inventory>(false, null);
        }

        public List<Inventory> getCharInventory(uint charId)
        {
            for (int i = 0; i < Characters.Count; i++)
                if (Characters[i].CharID == charId)
                    return Characters[i].Inventory;

            return null;
        }

        public void addInventoryItem(string item, int amount, float weight)
        {
            bool vero = getInventoryItem(item).Item1;
            Inventory checkedItem = getInventoryItem(item).Item2;

            if (vero)
            {
                checkedItem.Amount += amount;

                if (checkedItem.Amount == ConfigShared.SharedConfig.Main.Generics.ItemList[item].max)
                {
                    checkedItem.Amount = ConfigShared.SharedConfig.Main.Generics.ItemList[item].max;
                    Player.TriggerSubsystemEvent("tlg:ShowNotification", "YOU ALREADY HAVE THE MOST OF ~w~" + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + "~w~!");
                }
            }
            else
            {
                CurrentChar.Inventory.Add(new Inventory(item, amount, weight));
            }

            Player.TriggerSubsystemEvent("tlg:ShowNotification", "Received " + amount + " " + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + "!");
        }

        public void removeInventoryItem(string item, int amount)
        {
            bool vero = getInventoryItem(item).Item1;
            Inventory checkedItem = getInventoryItem(item).Item2;

            if (vero)
            {
                checkedItem.Amount -= amount;
                if (checkedItem.Amount <= 0) CurrentChar.Inventory.Remove(checkedItem);
            }
            else
            {
                CurrentChar.Inventory.ToList().Remove(checkedItem);
            }

            Player.TriggerSubsystemEvent("tlg:ShowNotification", amount + " " + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + " have been removed!");
        }

        public List<Weapons> getCharWeapons(uint charId)
        {
            for (int i = 0; i < Characters.Count; i++)
                if (Characters[i].CharID == charId)
                    return Characters[i].Weapons;

            return null;
        }*/

        public void addWeapon(string weaponName, int ammo)
        {
            if (!hasWeapon(weaponName))
            {
                Character.Weapons.Add(new Weapons(weaponName, ammo, new List<Components>(), 0));
                Player.TriggerSubsystemEvent("tlg:addWeapon", weaponName, ammo);
            }
        }

        public void updateWeaponAmmo(string weaponName, int ammo)
        {
            Tuple<int, Weapons> weapon = getWeapon(weaponName);
            if (weapon.Item2.Ammo > ammo) Character.Weapons[weapon.Item1].Ammo = ammo;
        }

        public void removeWeapon(string weaponName)
        {
            if (hasWeapon(weaponName))
            {
                Character.Weapons.Remove(getWeapon(weaponName).Item2);
                Player.TriggerSubsystemEvent("tlg:removeWeapon", weaponName);

            }
        }

        public void addWeaponComponent(string weaponName, string weaponComponent)
        {
            int num = getWeapon(weaponName).Item1;

            if (hasWeaponComponent(weaponName, weaponComponent))
            {
                Player.TriggerSubsystemEvent("tlg:possiediArma", weaponName, weaponComponent);
            }
            else
            {
                Character.Weapons[num].Components.Add(new Components(weaponComponent, true));
                Player.TriggerSubsystemEvent("tlg:addWeaponComponent", weaponName, weaponComponent);

            }
        }

        public void removeWeaponComponent(string weaponName, string weaponComponent)
        {
            int num = getWeapon(weaponName).Item1;
            Weapons weapon = getWeapon(weaponName).Item2;

            if (weapon != null)
                for (int i = 0; i < Character.Weapons[num].Components.Count; i++)
                    if (Character.Weapons[num].Components[i].name == weaponComponent)
                    {
                        Character.Weapons[num].Components.RemoveAt(i);
                        Player.TriggerSubsystemEvent("tlg:removeWeaponComponent", weaponName, weaponComponent);

                    }
        }

        public void addWeaponTint(string weaponName, int tint)
        {
            int num = getWeapon(weaponName).Item1;
            Weapons weapon = getWeapon(weaponName).Item2;

            if (weapon != null)
            {
                if (hasWeaponTint(weaponName, tint))
                {
                    Player.TriggerSubsystemEvent("tlg:possiediTinta", weaponName, tint);
                }
                else
                {
                    Character.Weapons[num].Tint = tint;
                    Player.TriggerSubsystemEvent("tlg:addWeaponTint", weaponName, tint);
                }
            }
        }

        public bool hasWeapon(string weaponName)
        {
            return Character.Weapons.Any(x => x.Name == weaponName);
        }

        public Tuple<int, Weapons> getWeapon(string weaponName)
        {
            Weapons weapon = Character.Weapons.FirstOrDefault(x => x.Name == weaponName);

            return weapon != null ? new Tuple<int, Weapons>(Character.Weapons.IndexOf(weapon), weapon) : new Tuple<int, Weapons>(0, null);
        }

        public bool hasWeaponTint(string weaponName, int tint)
        {
            Weapons weapon = getWeapon(weaponName).Item2;

            return weapon != null && weapon.Tint == tint;
        }

        public bool hasWeaponComponent(string weaponName, string weaponComponent)
        {
            Weapons weapon = getWeapon(weaponName).Item2;

            return weapon != null && weapon.Components.Any(x => x.name == weaponComponent);
        }

        [JsonIgnore] internal Vector3 getCoords => Character.Position.ToVector3;

        // TODO: vehicle system must emulate online.. so we need to store the vehicles owned by the player and their data
        // (data that will be loaded only when vehicle is spawned)
        /*
        public List<OwnedVehicle> GetCharVehicles()
        {
            return CurrentChar.Vehicles;
        }
        */

        public void AddExperience(int experiencePoints)
        {
            int nextLevelTotalXp = Experience.NextLevelExperiencePoints(Character.Level);

            if (Character.TotalXp + experiencePoints >= nextLevelTotalXp)
            {
                int remainder = Character.TotalXp + experiencePoints - nextLevelTotalXp;
                Character.Level++;
                if (remainder > 0)
                    AddExperience(remainder);
            }
            else
            {
                Character.TotalXp += experiencePoints;
            }
        }

        public void UpdateCurrentAttempt(int eventId, float currentAttempt)
        {
            try
            {
                PlayerScore data = PlayerScores.Where(x => x.EventId == eventId).FirstOrDefault();
                if (data != null)
                {
                    data.CurrentAttempt = currentAttempt;
                    if (currentAttempt > data.BestAttempt)
                        data.BestAttempt = currentAttempt;
                }
                else
                    ServerMain.Logger.Warning($"Data for Event {eventId} does not exist for Player {Player.Name}");
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public void showNotification(string text)
        {
            Player.TriggerSubsystemEvent("tlg:ShowNotification", text);
        }
    }
}