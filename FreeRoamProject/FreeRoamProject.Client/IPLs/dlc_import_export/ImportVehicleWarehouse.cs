using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_import_export
{
    public class ImportVehicleWarehouse
    {
        public VehUpper Upper = new();
        public VehLower Lower = new();
        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                Upper.Enabled = value;
                Lower.Enabled = value;
            }
        }

        public void LoadDefault()
        {
            Upper.Enabled = true;
            Upper.Style.Set(Upper.Style.Branded);
            Upper.Details.Enable(Upper.Details.FloorHatch, true);
            Upper.Details.Enable(Upper.Details.DoorBlocker, false);
            API.RefreshInterior(VehUpper.InteriorId);

            Lower.Enabled = true;
            Lower.Details.Enable(Lower.Details.Pumps.pump1);
            Lower.Details.Enable(Lower.Details.Pumps.pump2);
            Lower.Details.Enable(Lower.Details.Pumps.pump3);
            Lower.Details.Enable(Lower.Details.Pumps.pump4);
            Lower.Details.Enable(Lower.Details.Pumps.pump5);
            Lower.Details.Enable(Lower.Details.Pumps.pump6);
            Lower.Details.Enable(Lower.Details.Pumps.pump7);
            Lower.Details.Enable(Lower.Details.Pumps.pump8);
        }

    }

    public class VehUpper
    {
        public static int InteriorId = 252673;
        private bool _enabled = false;
        public string ipl = "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public UpperStyle Style = new(InteriorId);
        public UpperDetails Details = new(InteriorId);
    }

    public class VehLower
    {
        public static int InteriorId = 253185;
        private bool _enabled = false;
        public string ipl = "imp_impexp_interior_placement_interior_3_impexp_int_02_milo_";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public LowerDetails Details = new(InteriorId);
    }
    public class LowerDetails
    {
        private readonly int interiorId;
        public LowerDetails(int interior) { interiorId = interior; }
        public DPumps Pumps = new();
        public void Enable(string detail, bool state = true, bool refresh = true)
        {
            IplManager.SetIplPropState(interiorId, detail, state, refresh);
        }
    }

    public class DPumps
    {
        public string pump1 = "pump_01";
        public string pump2 = "pump_02";
        public string pump3 = "pump_03";
        public string pump4 = "pump_04";
        public string pump5 = "pump_05";
        public string pump6 = "pump_06";
        public string pump7 = "pump_07";
        public string pump8 = "pump_08";
    }

    public class UpperStyle
    {
        private readonly int interiorId;
        public string Basic = "basic_style_set";
        public string Branded = "branded_style_set";
        public string Urban = "urban_style_set";

        public UpperStyle(int interior) { interiorId = interior; }
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(interiorId, style, true, refresh);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(interiorId, new List<string>() { "basic_style_set", "branded_style_set", "urban_style_set" }, false, refresh);
        }
    }

    public class UpperDetails
    {
        private readonly int interiorId;
        public string FloorHatch = "car_floor_hatch";
        public string DoorBlocker = "door_blocker";       // Invisible wall
        public UpperDetails(int interior) { interiorId = interior; }
        public void Enable(string detail, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(interiorId, detail, state, refresh);
        }
    }
}
