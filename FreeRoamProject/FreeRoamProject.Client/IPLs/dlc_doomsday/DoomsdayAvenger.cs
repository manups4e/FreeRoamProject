using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_doomsday
{
    public enum AvengerColors
    {
        Utility = 1, Expertise = 2, Altitude = 3,
        Power = 4, Authority = 5, Influence = 6,
        Order = 7, Empire = 8, Supremacy = 9
    }
    public class DoomsdayAvenger
    {
        public static int InteriorId = 262145;
        private bool _enabled = false;
        public string ipl = "xm_x17dlc_int_placement_interior_9_x17dlc_int_01_milo_";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public DWalls Walls = new DWalls();
        public DTurret Turret = new DTurret();
        public DWeaponsMod WeaponsMod = new DWeaponsMod();
        public DVehicleMod VehicleMod = new DVehicleMod();
        public DDetailsAvenger Details = new DDetailsAvenger();

        public void LoadDefault()
        {
            Enabled = true;

            Walls.SetColor(AvengerColors.Expertise);

            Turret.Set(Turret.Back, (AvengerColors)1, false);
            WeaponsMod.Set(WeaponsMod.On, (AvengerColors)1, false);
            VehicleMod.Set(VehicleMod.On, (AvengerColors)1, false);

            Details.Enable(Details.Golden, false, false);

            API.RefreshInterior(InteriorId);
        }

    }

    public class DWalls
    {
        public void SetColor(AvengerColors color, bool refresh = true)
        {
            API.SetInteriorEntitySetColor(DoomsdayAvenger.InteriorId, "shell_tint", (int)color);
            if (refresh) API.RefreshInterior(DoomsdayAvenger.InteriorId);
        }
    }

    public class DTurret
    {
        public string None = "";
        public string Back = "control_1";
        public string Left = "control_2";
        public string Right = "control_3";
        public void Set(string turret, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            if (turret != None)
            {
                IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, turret, true, refresh);
                API.SetInteriorEntitySetColor(DoomsdayAvenger.InteriorId, turret, (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(DoomsdayAvenger.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, new List<string>() { "control_1", "control_2", "control_3" }, false, refresh);
        }
    }

    public class DWeaponsMod
    {
        public string Off = "";
        public string On = "weapons_mod";
        public void Set(string mod, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            if (mod != Off)
            {
                IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, mod, true, refresh);
                API.SetInteriorEntitySetColor(DoomsdayAvenger.InteriorId, mod, (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(DoomsdayAvenger.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, "weapons_mod", false, refresh);
        }
    }

    public class DVehicleMod
    {
        public string Off = "";
        public string On = "vehicle_mod";
        public void Set(string mod, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            if (mod != Off)
            {
                IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, mod, true, refresh);
                API.SetInteriorEntitySetColor(DoomsdayAvenger.InteriorId, mod, (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(DoomsdayAvenger.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, "vehicle_mod", false, refresh);
        }
    }

    public class DDetailsAvenger
    {
        public string Golden = "gold_bling";
        public void Enable(string detail, bool state = true, bool refresh = true)
        {
            IplManager.SetIplPropState(DoomsdayAvenger.InteriorId, detail, state, refresh);

        }
    }

}
