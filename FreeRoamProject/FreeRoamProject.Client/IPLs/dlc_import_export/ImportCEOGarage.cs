using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_import_export
{
    public abstract class ImportCEOGarage
    {
        public GaragePart Part { get; set; }
        public GarageStyle Style { get; set; }
        public GarageNumbering Numbering { get; set; }
        public GarageLighting Lighting { get; set; }

        public virtual void LoadDefault()
        {
            Part.Load(Part.Garage1);
            Style.Set(Part.Garage1, Style.Concrete);
            Numbering.Set(Part.Garage1, Numbering.Level1.style1);
            Lighting.Set(Part.Garage1, Lighting.style1);
        }

        public void Unload()
        {
            Style.Clear(Part.Garage1);
            Numbering.Clear(Part.Garage1);
            Lighting.Clear(Part.Garage1);
            Style.Clear(Part.Garage2);
            Numbering.Clear(Part.Garage2);
            Lighting.Clear(Part.Garage2);
            Style.Clear(Part.Garage3);
            Numbering.Clear(Part.Garage3);
            Lighting.Clear(Part.Garage3);
            Part.ModShop.Clear();
            Part.Clear();
        }
    }
    public class GaragePart
    {
        public Garage Garage1 { get; set; }
        public Garage Garage2 { get; set; }
        public Garage Garage3 { get; set; }
        public GarageModShop ModShop { get; set; }

        public void Load(Garage gar) => IplManager.EnableIpl(gar.Ipl, true);
        public void Remove(Garage gar) => IplManager.EnableIpl(gar.Ipl, false);
        public void Clear()
        {
            IplManager.EnableIpl(Garage1.Ipl, false);
            IplManager.EnableIpl(Garage2.Ipl, false);
            IplManager.EnableIpl(Garage3.Ipl, false);
        }
    }

    public class Garage
    {
        public int InteriorId;
        public string Ipl;
        public Garage(int interior, string ipl)
        {
            InteriorId = interior;
            Ipl = ipl;
        }
    }

    public class GarageStyle
    {
        public string Concrete = "garage_decor_01";
        public string Plain = "garage_decor_02";
        public string Marble = "garage_decor_03";
        public string Wooden = "garage_decor_04";
        public void Set(Garage part, string style, bool refresh = true)
        {
            Clear(part);
            IplManager.SetIplPropState(part.InteriorId, style, true, refresh);
        }
        public void Clear(Garage part)
        {
            IplManager.SetIplPropState(part.InteriorId, new List<string>() { "garage_decor_01", "garage_decor_02", "garage_decor_03", "garage_decor_04" }, false, true);
        }

    }

    public class GarageNumbering
    {
        public string None = "";
        public Level Level1 = new Level("numbering_style01_n1", "numbering_style02_n1", "numbering_style03_n1", "numbering_style04_n1", "numbering_style05_n1", "numbering_style06_n1", "numbering_style07_n1", "numbering_style08_n1", "numbering_style09_n1");
        public Level Level2 = new Level("numbering_style01_n2", "numbering_style02_n2", "numbering_style03_n2", "numbering_style04_n2", "numbering_style05_n2", "numbering_style06_n2", "numbering_style07_n2", "numbering_style08_n2", "numbering_style09_n2");
        public Level Level3 = new Level("numbering_style01_n3", "numbering_style02_n3", "numbering_style03_n3", "numbering_style04_n3", "numbering_style05_n3", "numbering_style06_n3", "numbering_style07_n3", "numbering_style08_n3", "numbering_style09_n3");

        public void Set(Garage part, string num, bool refresh = true)
        {
            Clear(part);
            if (num != None)
                IplManager.SetIplPropState(part.InteriorId, num, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(part.InteriorId);
            }
        }
        public void Clear(Garage part)
        {
            IplManager.SetIplPropState(part.InteriorId, Level1.style1, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style2, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style3, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style4, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style5, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style6, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style7, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style8, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level1.style9, false, true);

            IplManager.SetIplPropState(part.InteriorId, Level2.style1, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style2, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style3, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style4, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style5, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style6, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style7, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style8, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level2.style9, false, true);

            IplManager.SetIplPropState(part.InteriorId, Level3.style1, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style2, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style3, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style4, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style5, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style6, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style7, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style8, false, true);
            IplManager.SetIplPropState(part.InteriorId, Level3.style9, false, true);
        }
    }
    public class Level
    {
        public string style1;
        public string style2;
        public string style3;
        public string style4;
        public string style5;
        public string style6;
        public string style7;
        public string style8;
        public string style9;
        public Level(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9)
        {
            style1 = s1;
            style2 = s2;
            style3 = s3;
            style4 = s4;
            style5 = s5;
            style6 = s6;
            style7 = s7;
            style8 = s8;
            style9 = s9;
        }
    }

    public class GarageLighting
    {
        public string None = "";
        public string style1 = "lighting_option01"; public string style2 = "lighting_option02"; public string style3 = "lighting_option03";
        public string style4 = "lighting_option04"; public string style5 = "lighting_option05"; public string style6 = "lighting_option06";
        public string style7 = "lighting_option07"; public string style8 = "lighting_option08"; public string style9 = "lighting_option09";

        public void Set(Garage part, string light, bool refresh = true)
        {
            Clear(part);
            if (light != None)
                IplManager.SetIplPropState(part.InteriorId, light, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(part.InteriorId);
            }
        }

        public void Clear(Garage part)
        {
            IplManager.SetIplPropState(part.InteriorId, new List<string>() { "lighting_option01", "lighting_option02", "lighting_option03", "lighting_option04", "lighting_option05", "lighting_option06", "lighting_option07", "lighting_option08", "lighting_option09" }, false, true);
        }
    }

    public class GarageModShop
    {
        public int InteriorId;
        public string Ipl;

        public string Default = "";
        public string city = "floor_vinyl_01";
        public string seabed = "floor_vinyl_02";
        public string aliens = "floor_vinyl_03";
        public string clouds = "floor_vinyl_04";
        public string money = "floor_vinyl_05";
        public string zebra = "floor_vinyl_06";
        public string blackWhite = "floor_vinyl_07";
        public string barcode = "floor_vinyl_08";
        public string paintbrushBW = "floor_vinyl_09";
        public string grid = "floor_vinyl_10";
        public string splashes = "floor_vinyl_11";
        public string squares = "floor_vinyl_12";
        public string mosaic = "floor_vinyl_13";
        public string paintbrushColor = "floor_vinyl_14";
        public string curvesColor = "floor_vinyl_15";
        public string marbleBrown = "floor_vinyl_16";
        public string marbleBlue = "floor_vinyl_17";
        public string marbleBW = "floor_vinyl_18";
        public string maze = "floor_vinyl_19";

        public GarageModShop(int interior, string ipl)
        {
            InteriorId = interior;
            Ipl = ipl;
        }
        public void Set(string floor, bool refresh = true)
        {
            Clear();
            if (floor != Default)
                IplManager.SetIplPropState(InteriorId, floor, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(InteriorId);
            }
        }
        public void Clear()
        {
            IplManager.SetIplPropState(InteriorId, new List<string>() { "floor_vinyl_01", "floor_vinyl_02", "floor_vinyl_03", "floor_vinyl_04", "floor_vinyl_05", "floor_vinyl_06", "floor_vinyl_07", "floor_vinyl_08", "floor_vinyl_09", "floor_vinyl_10", "floor_vinyl_11", "floor_vinyl_12", "floor_vinyl_13", "floor_vinyl_14", "floor_vinyl_15", "floor_vinyl_16", "floor_vinyl_17", "floor_vinyl_18" }, false, true);
        }
    }

}
