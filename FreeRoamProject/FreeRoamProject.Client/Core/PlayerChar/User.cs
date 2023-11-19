using FreeRoamProject.Shared.Core.Character;
using FreeRoamProject.Shared.PlayerChar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Client.Core.PlayerChar
{
    public class User : BasePlayerShared
    {
        public User(BasePlayerShared result)
        {
            ID = result.ID;
            PlayerID = result.PlayerID;
            group = result.group;
            group_level = result.group_level;
            playTime = result.playTime;
            Player = Game.Player;
            Identifiers = result.Identifiers;
        }

        public User() { }

        [JsonIgnore] internal bool DeathStatus => Character.is_dead;

        [JsonIgnore] internal int Money => Character.Finance.Money;

        [JsonIgnore] internal int Bank => Character.Finance.Bank;

        public void SetPlayerStat(string statName, int statValue1, int statValue2 = 0)
        {
            switch (statName)
            {
                case "SavedHelmet":
                    Character.Stats.SavedHelmet = [statValue1, statValue2];
                    break;
                case "IlluminatedClothing":
                    Character.Stats.IlluminatedClothing = statValue1;
                    break;
                case "CHood":
                    Character.Stats.SavedHood = statValue1;
                    break;
                case "VisorUpDown":
                    Character.Stats.VisorUpDown = statValue1;
                    break;
                case "AutoShowHelmet":
                    Character.Stats.AutoShowHelmet = statValue1;
                    break;
                case "AutoShowAircraft":
                    Character.Stats.AutoShowAircraft = statValue1;
                    break;
                case "SavedAction":
                    Character.Stats.SavedAction = statValue1;
                    break;
                case "SavedMood":
                    Character.Stats.SavedMood = statValue1;
                    break;
                case "SavedWalkStyle":
                    Character.Stats.SavedWalkStyle = statValue1;
                    break;
            }
            EventDispatcher.Send("tlg:SetPlayerStat", statName, statValue1, statValue2);
        }
        public List<Weapons> GetCharWeapons()
        {
            return Character.Weapons;
        }

        public bool HasWeapon(string weaponName)
        {
            return Character.Weapons.Any(x => x.Name == weaponName);
        }

        public bool HasWeapon(WeaponHash weaponName)
        {
            return Character.Weapons.Any(x => Functions.HashInt(x.Name) == (int)weaponName);
        }

        public Tuple<int, Weapons> GetWeapon(WeaponHash weaponName)
        {
            Weapons weap = Character.Weapons.FirstOrDefault(x => Functions.HashInt(x.Name) == (int)weaponName);
            if (weap != null)
                return new Tuple<int, Weapons>(Character.Weapons.IndexOf(weap), weap);
            return default;

        }

        public Tuple<int, Weapons> GetWeapon(string weaponName)
        {
            for (int i = 0; i < Character.Weapons.Count; i++)
            {
                if (Character.Weapons[i].Name == weaponName)
                {
                    return new Tuple<int, Weapons>(i, Character.Weapons[i]);
                }
            }
            return new Tuple<int, Weapons>(0, null);
        }

        public bool HasWeaponTint(string weaponName, int tint)
        {
            Weapons weapon = GetWeapon(weaponName).Item2;
            return weapon != null && weapon.Tint == tint;
        }

        public bool HasWeaponComponent(string weaponName, string weaponComponent)
        {
            Weapons weapon = GetWeapon(weaponName).Item2;
            return weapon != null && weapon.Components.Any(x => x.name == weaponComponent);
        }
    }
}