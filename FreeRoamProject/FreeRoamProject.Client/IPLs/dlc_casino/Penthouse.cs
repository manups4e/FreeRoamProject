using CitizenFX.Core.Native;

namespace FreeRoamProject.Client.IPLs.dlc_casino
{
    public enum PenthouseColor
    {
        Default = 0,
        Sharp = 1,
        Vibrant = 2,
        Timeless = 3

    }
    public class Penthouse
    {
        public static int InteriorId = 274689;
        public PenthouseIPL Ipl = new();
        public PenthouseInterior Interior = new();

        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                if (value)
                    LoadDefault();
                else
                {
                    Ipl.Remove();
                    Interior.SpaBar.Clear();
                    Interior.MediaBar.Clear();
                    Interior.Dealer.Clear();
                }
            }
        }

        public void LoadDefault()
        {
            Ipl.Load();
            Interior.Walls.SetColor(PenthouseColor.Default);
            Interior.SpaBar.Set(Interior.SpaBar.Open);
            Interior.MediaBar.Set(Interior.MediaBar.Open);
            Interior.Dealer.Set(Interior.Dealer.Open);
            API.RefreshInterior(InteriorId);
        }
    }

    public class PenthouseIPL
    {
        public string Ipl = "vw_casino_penthouse";
        public void Load()
        {
            IplManager.EnableIpl(Ipl, true);
            IplManager.SetIplPropState(Penthouse.InteriorId, "Set_Pent_Tint_Shell", true, true);
        }
        public void Remove()
        {
            IplManager.EnableIpl(Ipl, false);
        }
    }
    public class PenthouseInterior
    {
        public PenthouseWalls Walls = new();
        public PenthousePattern Pattern = new();
        public PenthouseSpaBar SpaBar = new();
        public PenthouseMediaBar MediaBar = new();
        public PenthouseDealer Dealer = new();
        public PenthouseArcade Arcade = new();
        public PenthouseClutter Clutter = new();
        public PenthouseBarLight BarLight = new();
        public PenthouseBarParty BarParty = new();
        public PentHouseBlockers Blockers = new();
    }

    public class PenthouseWalls
    {
        public void SetColor(PenthouseColor color, bool refresh = true)
        {
            API.SetInteriorEntitySetColor(Penthouse.InteriorId, "Set_Pent_Tint_Shell", (int)color);
            if (refresh) API.RefreshInterior(Penthouse.InteriorId);
        }
    }

    public class PenthousePattern : IPenthouseEnabler
    {
        public string Pattern01 = "Set_Pent_Pattern_01";
        public string Pattern02 = "Set_Pent_Pattern_02";
        public string Pattern03 = "Set_Pent_Pattern_03";
        public string Pattern04 = "Set_Pent_Pattern_04";
        public string Pattern05 = "Set_Pent_Pattern_05";
        public string Pattern06 = "Set_Pent_Pattern_06";
        public string Pattern07 = "Set_Pent_Pattern_07";
        public string Pattern08 = "Set_Pent_Pattern_08";
        public string Pattern09 = "Set_Pent_Pattern_09";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }

        public void Clear(bool refresh = true)
        {
            for (int i = 1; i < 10; i++)
            {
                var patt = "Set_Pent_Pattern_0" + i;
                IplManager.SetIplPropState(Penthouse.InteriorId, patt, false, refresh);
            }
        }
    }

    public class PenthouseSpaBar : IPenthouseEnabler
    {
        public string Open = "Set_Pent_Spa_Bar_Open";
        public string Closed = "Set_Pent_Spa_Bar_Closed";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, Open, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Closed, false, refresh);
        }
    }

    public class PenthouseMediaBar : IPenthouseEnabler
    {

        public string Open = "Set_Pent_Media_Bar_Open";
        public string Closed = "Set_Pent_Media_Bar_Closed";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, Open, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Closed, false, refresh);
        }

    }

    public class PenthouseDealer : IPenthouseEnabler
    {
        public string Open = "Set_Pent_Dealer";
        public string Closed = "Set_Pent_NoDealer";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, Open, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Closed, false, refresh);
        }
    }

    public class PenthouseArcade : IPenthouseEnabler
    {

        public string None = "";
        public string Retro = "Set_Pent_Arcade_Retro";
        public string Modern = "Set_Pent_Arcade_Modern";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, None, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Retro, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Modern, false, refresh);
        }
    }

    public class PenthouseClutter : IPenthouseEnabler
    {
        public string Bar = "Set_Pent_Bar_Clutter";
        public string Clutter01 = "Set_Pent_Clutter_01";
        public string Clutter02 = "Set_Pent_Clutter_02";
        public string Clutter03 = "Set_Pent_Clutter_03";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, Bar, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Clutter01, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Clutter02, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Clutter03, false, refresh);
        }
    }

    public class PenthouseBarLight : IPenthouseEnabler
    {
        public string None = "";
        public string Light1 = "set_pent_bar_light_0";
        public string Light2 = "set_pent_bar_light_01";
        public string Light3 = "set_pent_bar_light_02";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, None, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Light1, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Light2, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Light3, false, refresh);
        }
    }
    public class PenthouseBarParty : IPenthouseEnabler
    {
        public string None = "";
        public string Party1 = "set_pent_bar_party_0";
        public string Party2 = "set_pent_bar_party_1";
        public string Party3 = "set_pent_bar_party_2";
        public string PartyAfter = "set_pent_bar_party_after";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, None, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Party1, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Party2, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Party3, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, PartyAfter, false, refresh);
        }
    }

    public class PentHouseBlockers
    {
        public PHBlocker Guest = new("Set_Pent_GUEST_BLOCKER");
        public PHBlocker Lounge = new("Set_Pent_LOUNGE_BLOCKER");
        public PHBlocker Office = new("Set_Pent_OFFICE_BLOCKER");
        public PHBlocker Cinema = new("Set_Pent_CINE_BLOCKER");
        public PHBlocker Spa = new("Set_Pent_SPA_BLOCKER");
        public PHBlocker Bar = new("Set_Pent_BAR_BLOCKER");
        private bool allEnabled;
        public bool AllEnabled
        {
            get => allEnabled;
            set
            {
                allEnabled = value;
                Bar.Set(value ? Bar.Enabled : Bar.Disabled);
                Guest.Set(value ? Guest.Enabled : Guest.Disabled);
                Spa.Set(value ? Spa.Enabled : Spa.Disabled);
                Cinema.Set(value ? Cinema.Enabled : Cinema.Disabled);
                Lounge.Set(value ? Lounge.Enabled : Lounge.Disabled);
                Office.Set(value ? Office.Enabled : Office.Disabled);
            }
        }
    }

    public class PHBlocker
    {
        public string Enabled { get; set; }
        public string Disabled = "";

        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, Enabled, false, refresh);
            IplManager.SetIplPropState(Penthouse.InteriorId, Disabled, false, refresh);
        }

        public PHBlocker(string enabled)
        {
            Enabled = enabled;
        }
    }

    /*   
        public void Set(string value, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Penthouse.InteriorId, value, true, refresh);
        }
        public void Clear(bool refresh = true)
        {
            IplManager.SetIplPropState(Penthouse.InteriorId, , false, refresh);
        }
    */
    public interface IPenthouseEnabler
    {
        public void Set(string value, bool refresh = true);
        public void Clear(bool refresh = true);
    }
}
