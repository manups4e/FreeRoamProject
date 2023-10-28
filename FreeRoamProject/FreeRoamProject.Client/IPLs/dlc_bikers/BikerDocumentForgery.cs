using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerDocumentForgery
    {
        public static int InteriorId = 246785;

        private bool _enabled = false;
        public string ipl = "bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public DocumentStyle Style = new DocumentStyle();
        public DocumentEquipment Equipment = new DocumentEquipment();
        public DocumentSecurity Security = new DocumentSecurity();
        public DocumentDetails Details = new DocumentDetails();

        public void LoadDefault()
        {
            Enabled = true;
            Style.Set(Style.Basic);
            Security.Set(Security.Basic);
            Equipment.Set(Equipment.Basic);
            Details.Enable(Details.Production, false);
            Details.Enable(Details.Clutter, false);
            foreach (string s in Details.Chairs)
                Details.Enable(s, true);
            API.RefreshInterior(InteriorId);
        }

    }
    public class DocumentStyle
    {
        public string Basic = "interior_basic";
        public string Upgrade = "interior_upgrade";

        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, style, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, new List<string>() { "interior_basic", "interior_upgrade" }, false, refresh);
        }
    }

    public class DocumentEquipment
    {
        public string None = "";
        public string Basic = "equipment_basic";
        public string Upgrade = "equipment_upgrade";
        public void Set(string equip, bool refresh = true)
        {
            Clear(false);
            if (equip != None)
                IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, equip, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(BikerDocumentForgery.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, new List<string>() { "equipment_basic", "equipment_upgrade" }, true, refresh);
        }
    }
    public class DocumentSecurity
    {
        public string Basic = "security_low";
        public string Upgrade = "security_high";
        public void Set(string equip, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, equip, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, new List<string>() { "security_low", "security_high" }, true, refresh);
        }
    }
    public class DocumentDetails
    {
        public List<string> Chairs = new List<string>()
            {
                "chair01",
                "chair02",
                "chair03",
                "chair04",
                "chair05",
                "chair06",
                "chair07",
            };
        public string Production = "production";
        public string Fornitures = "set_up";
        public string Clutter = "clutter";
        public void Enable(string detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(BikerDocumentForgery.InteriorId, detail, state, refresh);
        }
    }

}
