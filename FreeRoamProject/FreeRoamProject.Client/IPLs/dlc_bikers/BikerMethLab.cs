using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerMethLab
    {
        public static int InteriorId = 247041;
        private bool _enabled = false;
        public string ipl = "bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public MethStyle Style = new();
        public MethSecurity Security = new();
        public MethDetails Details = new();

        public void LoadDefault()
        {
            Enabled = true;
            Style.Set(Style.Empty);
            Security.Set(Security.None);
            Details.Enable(Details.Production, false);
            API.RefreshInterior(InteriorId);
        }
    }


    public class MethStyle
    {
        public string None = "";
        public string Empty = "meth_lab_empty";
        public List<string> Basic = ["meth_lab_basic", "meth_lab_setup"];
        public List<string> Upgrade = ["meth_lab_upgrade", "meth_lab_setup"];
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            if (style != None)
                IplManager.SetIplPropState(BikerMethLab.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerMethLab.InteriorId);
            }
        }
        public void Set(List<string> style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(BikerMethLab.InteriorId, style, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerMethLab.InteriorId, Empty, false, refresh);
            IplManager.SetIplPropState(BikerMethLab.InteriorId, Basic, false, refresh);
            IplManager.SetIplPropState(BikerMethLab.InteriorId, Upgrade, false, refresh);
        }
    }

    public class MethSecurity
    {
        public string None = "";
        public string Upgrade = "meth_lab_security_high";
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            if (style != None)
                IplManager.SetIplPropState(BikerMethLab.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerMethLab.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerMethLab.InteriorId, Upgrade, false, refresh);
        }
    }
    public class MethDetails
    {
        public string Production = "meth_lab_production";
        public void Enable(string detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(BikerMethLab.InteriorId, detail, state, refresh);
        }
    }
}