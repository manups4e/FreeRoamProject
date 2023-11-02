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
                Player.TriggerEvent("tlg:changeMoney", var);
            }
        }


        [JsonIgnore]
        internal int Bank
        {
            get => Character.Finance.Bank;
            set
            {
                int var = value - Character.Finance.Bank;
                Character.Finance.Bank += var;
                if (var < 0) Player.TriggerEvent("tlg:rimuoviBank", var);
            }
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
                    Player.TriggerEvent("tlg:ShowNotification", "YOU ALREADY HAVE THE MOST OF ~w~" + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + "~w~!");
                }
            }
            else
            {
                CurrentChar.Inventory.Add(new Inventory(item, amount, weight));
            }

            Player.TriggerEvent("tlg:ShowNotification", "Received " + amount + " " + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + "!");
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

            Player.TriggerEvent("tlg:ShowNotification", amount + " " + ConfigShared.SharedConfig.Main.Generics.ItemList[item].label + " have been removed!");
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