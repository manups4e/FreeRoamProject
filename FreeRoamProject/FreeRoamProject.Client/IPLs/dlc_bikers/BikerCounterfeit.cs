using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerCounterfeit
    {
        public static int InteriorId = 247809;
        private bool _enabled = false;
        public string ipl = "bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }
        public CounterfaitPrinter Printer = new CounterfaitPrinter();
        public CounterfaitSecurity Security = new CounterfaitSecurity();
        public CounterfaitDryer Dryer1 = new CounterfaitDryer("dryera_on", "dryera_off", "dryera_open");
        public CounterfaitDryer Dryer2 = new CounterfaitDryer("dryerb_on", "dryerb_off", "dryerb_open");
        public CounterfaitDryer Dryer3 = new CounterfaitDryer("dryerc_on", "dryerc_off", "dryerc_open");
        public CounterfaitDryer Dryer4 = new CounterfaitDryer("dryerd_on", "dryerd_off", "dryerd_open");
        public CounterfaitDetails Details = new CounterfaitDetails();

        public void LoadDefault()
        {
            Enabled = true;
            Printer.Set(Printer.BasicProd);
            Security.Set(Security.Upgrade);
            Dryer1.Set(Dryer1.Open);
            Dryer2.Set(Dryer2.On);
            Dryer3.Set(Dryer3.On);
            Dryer4.Set(Dryer4.Off);
            Details.Enable(Details.Cutter, true);
            Details.Enable(Details.Fornitures, true);
            Details.Enable(Details.Cash100, true);
            API.RefreshInterior(InteriorId);
        }
    }

    public class CounterfaitPrinter
    {
        public string None = "";
        public string Basic = "counterfeit_standard_equip_no_prod";
        public string BasicProd = "counterfeit_standard_equip";
        public string Upgrade = "counterfeit_upgrade_equip_no_prod";
        public string UpgradeProd = "counterfeit_upgrade_equip";
        public void Set(string printer, bool refresh = true)
        {
            Clear(false);
            if (printer != None)
                IplManager.SetIplPropState(BikerCounterfeit.InteriorId, printer, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerCounterfeit.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerCounterfeit.InteriorId, new List<string>() { "counterfeit_standard_equip_no_prod", "counterfeit_standard_equip", "counterfeit_upgrade_equip_no_prod", "counterfeit_upgrade_equip" }, false, refresh);
        }
    }

    public class CounterfaitSecurity
    {
        public string Basic = "counterfeit_low_security";
        public string Upgrade = "counterfeit_security";
        public void Set(string security, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(BikerCounterfeit.InteriorId, security, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerCounterfeit.InteriorId, new List<string>() { "counterfeit_low_security", "counterfeit_security" }, false, refresh);
        }
    }

    public class CounterfaitDryer
    {
        public string None = "";
        public string On;
        public string Off;
        public string Open;
        public CounterfaitDryer(string on, string off, string open)
        {
            On = on;
            Off = off;
            Open = open;
        }
        public void Set(string onoff, bool refresh = true)
        {
            if (onoff != None)
                IplManager.SetIplPropState(BikerCounterfeit.InteriorId, onoff, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerCounterfeit.InteriorId);
            }
        }
    }

    public class CounterfaitDetails
    {
        public List<string> Cash10 = new List<string>() { "counterfeit_cashpile10a", "counterfeit_cashpile10b", "counterfeit_cashpile10c", "counterfeit_cashpile10d" };
        public List<string> Cash20 = new List<string>() { "counterfeit_cashpile20a", "counterfeit_cashpile20b", "counterfeit_cashpile20c", "counterfeit_cashpile20d" };
        public List<string> Cash100 = new List<string>() { "counterfeit_cashpile100a", "counterfeit_cashpile100b", "counterfeit_cashpile100c", "counterfeit_cashpile100d" };
        public string Chairs = "special_chairs";
        public string Cutter = "money_cutter";
        public string Fornitures = "conunterfeit_setup";
        public void Enable(string detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(BikerCounterfeit.InteriorId, detail, state, refresh);
        }
        public void Enable(List<string> detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(BikerCounterfeit.InteriorId, detail, state, refresh);
        }
    }
}
