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