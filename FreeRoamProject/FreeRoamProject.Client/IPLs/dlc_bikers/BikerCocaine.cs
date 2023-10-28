using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerCocaine
    {
        public static int InteriorId = 247553;
        private bool _enabled = false;
        public string ipl = "bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public CocaineStyle Style = new CocaineStyle();
        public CocaineSecurity Security = new CocaineSecurity();
        public CocaineDetails Details = new CocaineDetails();

        public void LoadDefault()
        {
            Enabled = true;
            Style.Set(Style.Basic);
            Security.Set(Security.None);
            API.RefreshInterior(InteriorId);
        }
    }


    public class CocaineStyle
    {
        public List<string> None = new List<string>() { "" };
        public List<string> Basic = new List<string>() { "set_up", "equipment_basic", "coke_press_basic", "production_basic", "table_equipment" };
        public List<string> Upgrade = new List<string>() { "set_up", "equipment_upgrade", "coke_press_upgrade", "production_upgrade", "table_equipment_upgrade" };
        public void Set(List<string> style, bool refresh = true)
        {
            Clear(false);
            if (style != None)
                IplManager.SetIplPropState(BikerCocaine.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerCocaine.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerCocaine.InteriorId, Basic, false, refresh);
            IplManager.SetIplPropState(BikerCocaine.InteriorId, Upgrade, false, refresh);
        }
    }
    public class CocaineSecurity
    {
        public string None = "";
        public string Basic = "security_low";
        public string Upgrade = "security_high";
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            if (style != None)
                IplManager.SetIplPropState(BikerCocaine.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerCocaine.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerCocaine.InteriorId, Basic, false, refresh);
            IplManager.SetIplPropState(BikerCocaine.InteriorId, Upgrade, false, refresh);
        }
    }

    public class CocaineDetails
    {
        public string CokeBasic1 = "coke_cut_01";       // On the basic tables
        public string CokeBasic2 = "coke_cut_02";       // On the basic tables
        public string CokeBasic3 = "coke_cut_03";       // On the basic tables
        public string CokeUpgrade1 = "coke_cut_04";     // On the upgraded tables
        public string CokeUpgrade2 = "coke_cut_05";     // On the upgraded tables

        public void Enable(string detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(BikerCocaine.InteriorId, detail, state, refresh);
        }
    }
}
