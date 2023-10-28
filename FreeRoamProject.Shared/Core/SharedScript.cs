using FreeRoamProject.Shared.Core.Character;
using FreeRoamProject.Shared.Core.FREEROAM;
using System.Collections.Generic;

// ReSharper disable All

namespace FreeRoamProject.Shared
{
    public enum UserGroup
    {
        User = 0,
        Helper,
        Moderator,
        Admin,
        Founder,
        Developer
    }

    public class SharedScript
    {

        public static bool hasWeaponComponent(string weapon, string component)
        {
            foreach (KeyValuePair<string, Core.FREEROAM.Weapon> weap in FreeRoamWeapons.Weapons)
            {
                if (weap.Key == weapon)
                {
                    foreach (Components com in weap.Value.components)
                    {
                        if (com.name == component)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static bool hasWeaponTint(string weapon, int tint)
        {
            foreach (KeyValuePair<string, Core.FREEROAM.Weapon> weap in FreeRoamWeapons.Weapons)
            {
                if (weap.Key == weapon)
                {
                    foreach (Tints tin in weap.Value.tints)
                    {
                        if (tin.value == tint)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static bool hasComponents(string weapon)
        {
            foreach (KeyValuePair<string, Core.FREEROAM.Weapon> weap in FreeRoamWeapons.Weapons)
            {
                if (weap.Key == weapon)
                {
                    if (weap.Value.components.Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool hasTints(string weapon)
        {
            foreach (KeyValuePair<string, Core.FREEROAM.Weapon> weap in FreeRoamWeapons.Weapons)
            {
                if (weap.Key == weapon)
                {
                    if (weap.Value.tints.Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }


    public class PickupObject
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public ObjectHash ObjectHash { get; set; }
        public int PropObj { get; set; }
        public string Label { get; set; }
        public bool InRange { get; set; } = false;
        public Position Coords { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<Components> Components { get; set; }
        public int TintIndex { get; set; }


        public PickupObject(int _id, string _name, int _amount, ObjectHash _obj, int _propObj, string _label, Position _coords, string _type = "item", List<Components> _components = null, int _tintIndex = 0)
        {
            Id = _id;
            Name = _name;
            Type = _type;
            Amount = _amount;
            ObjectHash = _obj;
            PropObj = _propObj;
            Label = _label;
            Coords = _coords;
            Components = _components;
            TintIndex = _tintIndex;
        }
    }
}
