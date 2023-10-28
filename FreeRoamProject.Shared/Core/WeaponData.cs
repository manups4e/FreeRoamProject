using System.Collections.Generic;

namespace FreeRoamProject.Shared
{

    public class SharedWeapon
    {
        public string? Name { get; set; }
        public GameLabel Label { get; set; }
        public uint UintHash { get; set; }
        public int IntHash { get; set; }
        public string? DlcName { get; set; }
        public string? Category { get; set; }
        public GameLabel Description { get; set; }
        public bool IsVehicleWeapon { get; set; }
        public List<SharedTint> Tints { get; set; }
        public List<SharedWeaponComponent> Components { get; set; }
        public List<SharedWeaponLiverie> Liveries { get; set; }
    }

    public class SharedTint
    {
        public int Index { get; set; }
        public GameLabel Label { get; set; }
    }

    public class SharedWeaponComponent
    {
        public string? Name { get; set; }
        public bool IsDefault { get; set; }
        public GameLabel Label { get; set; }
        public GameLabel Description { get; set; }

        public uint UintHash { get; set; }
        public int IntHash { get; set; }
        public string? AttachBone { get; set; }
        public string? Type { get; set; }
        public string? DlcName { get; set; }
        public List<SharedWeaponComponentVariant> Variants { get; set; }
    }
    public class SharedWeaponComponentVariant
    {
        public string? Name { get; set; }
        public int Index { set; get; }
    }

    public class SharedWeaponLiverie
    {
        public string? Name { get; set; }
        public GameLabel Label { get; set; }
        public uint UintHash { get; set; }
        public int IntHash { get; set; }
        public string? DlcName { get; set; }
    }
}