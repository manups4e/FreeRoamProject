using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_smuggler
{
    public enum HangarColors
    {
        Set1 = 1, // sable, red, gray
        Set2 = 2, // white, blue, gray
        Set3 = 3, // gray, orange, blue
        Set4 = 4, // gray, blue, orange
        Set5 = 5, // gray, light gray, red
        Set6 = 6, // yellow, gray, light gray
        Set7 = 7, // light Black and white
        Set8 = 8, // dark Black and white
        Set9 = 9  // sable and gray
    }
    public class SmugglerHangar
    {
        public static int InteriorId = 260353;
        private bool _enabled = false;
        public string ipl = "sm_smugdlc_interior_placement_interior_0_smugdlc_int_01_milo_";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public HWalls Walls = new();
        public HFloor Floor = new();
        public HCranes Cranes = new();
        public HModArea ModArea = new();
        public HOffice Office = new();
        public HBedroom Bedroom = new();
        public HLighting Lighting = new();
        public HDetails Details = new();

        public void LoadDefault()
        {
            Enabled = true;
            Walls.SetColor(HangarColors.Set1);
            Cranes.Set(Cranes.On, HangarColors.Set1);
            Floor.Style.Set(Floor.Style.Plain);
            Floor.Decals.Set(Floor.Decals.decal1, HangarColors.Set1);

            Lighting.Ceiling.Set(Lighting.Ceiling.Yellow);
            Lighting.Walls.Set(Lighting.Walls.Neutral);
            Lighting.FakeLights.Set(Lighting.FakeLights.Yellow);

            ModArea.Set(ModArea.On, HangarColors.Set1);

            Office.Set(Office.Basic);

            Bedroom.Style.Set(Bedroom.Style.Modern, HangarColors.Set1);
            Bedroom.Blinds.Set(Bedroom.Blinds.Opened);

            Details.Enable(Details.BedroomClutter, false);

            API.RefreshInterior(InteriorId);
        }
    }

    public class HWalls
    {
        public string Default = "set_tint_shell";
        public void SetColor(HangarColors color, bool refresh = true)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, Default, true, refresh);
            API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, Default, (int)color);
        }
    }

    public class HFloor
    {
        public HStyle Style = new();
        public HDecals Decals = new();
    }
    public class HStyle
    {
        public string Raw = "set_floor_1"; public string Plain = "set_floor_2";
        public void Set(string floor, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, floor, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_floor_1", "set_floor_2" }, false, refresh);
        }
    }
    public class HDecals
    {
        public string decal1 = "set_floor_decal_1"; public string decal2 = "set_floor_decal_2"; public string decal4 = "set_floor_decal_3"; public string decal3 = "set_floor_decal_4";
        public string decal5 = "set_floor_decal_5"; public string decal6 = "set_floor_decal_6"; public string decal7 = "set_floor_decal_7"; public string decal8 = "set_floor_decal_8";
        public string decal9 = "set_floor_decal_9";

        public void Set(string decal, HangarColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, decal, true, refresh);
            API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, decal, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_floor_decal_1", "set_floor_decal_2", "set_floor_decal_3", "set_floor_decal_4", "set_floor_decal_5", "set_floor_decal_6", "set_floor_decal_7", "set_floor_decal_8", "set_floor_decal_9" }, false, refresh);
        }
    }

    public class HCranes
    {
        public string On = "set_crane_tint";
        public string Off = "";
        public void Set(string crane, HangarColors color, bool refresh = false)
        {
            Clear(false);
            if (crane != Off)
            {
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, crane, true, refresh);
                API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, crane, (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, On, false, refresh);
        }
    }

    public class HModArea
    {
        public string On = "set_modarea";
        public string Off = "";
        public void Set(string mod, HangarColors color, bool refresh = false)
        {
            Clear(false);
            if (mod != Off)
            {
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, mod, true, refresh);
                API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, mod, (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, On, false, refresh);
        }
    }

    public class HOffice
    {
        public string Basic = "set_office_basic";
        public string Modern = "set_office_modern";
        public string Traditional = "set_office_traditional";
        public void Set(string office, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, office, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_office_basic", "set_office_modern", "set_office_traditional" }, false, refresh);
        }
    }

    public class HBedroom
    {
        public BStyle Style = new();
        public BBlinds Blinds = new();
    }
    public class BStyle
    {
        public List<string> None = [""];
        public List<string> Modern = ["set_bedroom_modern", "set_bedroom_tint"];
        public List<string> Traditional = ["set_bedroom_traditional", "set_bedroom_tint"];
        public void Set(List<string> style, HangarColors color, bool refresh = true)
        {
            Clear(false);
            if (style != None)
            {
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, style, true, refresh);
                API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, "set_bedroom_tint", (int)color);
            }
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, Modern, false, refresh);
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, Traditional, false, refresh);
        }
    }
    public class BBlinds
    {
        public string None = ""; public string Opened = "set_bedroom_blinds_open"; public string Closed = "set_bedroom_blinds_closed";
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            if (style != None)
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_bedroom_blinds_open", "set_bedroom_blinds_closed" }, false, refresh);
        }
    }
    public class HLighting
    {
        public FakeLight FakeLights = new();
        public Ceilings Ceiling = new();
        public Wall Walls = new();
    }

    public class FakeLight
    {
        public int None = -1;
        public int Yellow = 2;
        public int blue = 1;
        public int White = 0;

        public void Set(int light, bool refresh = true)
        {
            Clear(false);
            if (light != None)
            {
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, "set_lighting_tint_props", true, refresh);
                API.SetInteriorEntitySetColor(SmugglerHangar.InteriorId, "SetInteriorPropColor", light);
            }
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, "set_lighting_tint_props", false, refresh);
        }
    }
    public class Ceilings
    {
        public string None = ""; public string Yellow = "set_lighting_hangar_a"; public string Blue = "set_lighting_hangar_b"; public string White = "set_lighting_hangar_c";
        public void Set(string ceil, bool refresh = true)
        {
            Clear(false);
            if (ceil != None)
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, ceil, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_lighting_hangar_a", "set_lighting_hangar_b", "set_lighting_hangar_c" }, false, refresh);
        }
    }
    public class Wall
    {
        public string None = ""; public string Neutral = "set_lighting_wall_neutral"; public string Blue = "set_lighting_wall_tint01"; public string Orange = "set_lighting_wall_tint02";
        public string LightYellow = "set_lighting_wall_tint03"; public string LightYellow2 = "set_lighting_wall_tint04"; public string Dimmed = "set_lighting_wall_tint05";
        public string StrongYellow = "set_lighting_wall_tint06"; public string White = "set_lighting_wall_tint07"; public string LightGreen = "set_lighting_wall_tint08";
        public string Yellow = "set_lighting_wall_tint09";

        public void Set(string wall, bool refresh = true)
        {
            Clear(false);
            if (wall != None)
                IplManager.SetIplPropState(SmugglerHangar.InteriorId, wall, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(SmugglerHangar.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, new List<string>() { "set_lighting_wall_neutral", "set_lighting_wall_tint01", "set_lighting_wall_tint02", "set_lighting_wall_tint03", "set_lighting_wall_tint04", "set_lighting_wall_tint05", "set_lighting_wall_tint06", "set_lighting_wall_tint07", "set_lighting_wall_tint08", "set_lighting_wall_tint09" }, false, refresh);
        }
    }

    public class HDetails
    {
        public string BedroomClutter = "set_bedroom_clutter";
        public void Enable(string detail, bool state = true, bool refresh = true)
        {
            IplManager.SetIplPropState(SmugglerHangar.InteriorId, detail, state, refresh);
        }
    }

}
