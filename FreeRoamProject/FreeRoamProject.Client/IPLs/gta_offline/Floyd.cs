using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class Floyd
    {
        private bool enabled;
        public static int InteriorId = 171777;
        public FloydStyle Style = new()
        {
            Normal = new List<string>() { "swap_clean_apt", "layer_debra_pic", "layer_whiskey", "swap_sofa_A" },
            MessedUp = new List<string>() { "layer_mess_A", "layer_mess_B", "layer_mess_C", "layer_sextoys_a", "swap_sofa_B", "swap_wade_sofa_A", "layer_wade_shit", "layer_torture" },
        };
        public FloydStyle MrJam = new()
        {
            Normal = new List<string>() { "swap_mrJam_A" },
            Jammed = "swap_mrJam_B",
            JammedOnTable = "swap_mrJam_C"
        };
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                IplManager.EnableInterior(InteriorId, value);
            }
        }

        public void LoadDefault()
        {
            Style.Set(Style.Normal, false);
            MrJam.Set(MrJam.Normal, false);
            API.RefreshInterior(InteriorId);
        }
    }
    public class FloydStyle
    {
        public List<string> Normal = new();
        public List<string> MessedUp = new();
        public string Jammed;
        public string JammedOnTable;
        public void Set(List<string> style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Floyd.InteriorId, style, true, refresh);
        }

        public void Clear(bool refresh, int style = 1)
        {
            if (style == 1)
            {
                IplManager.SetIplPropState(Floyd.InteriorId, Normal, false, refresh);
                IplManager.SetIplPropState(Floyd.InteriorId, MessedUp, false, refresh);
            }
            else if (style == 2)
            {
                IplManager.SetIplPropState(Floyd.InteriorId, Normal, false, refresh);
                IplManager.SetIplPropState(Floyd.InteriorId, Jammed, false, refresh);
                IplManager.SetIplPropState(Floyd.InteriorId, JammedOnTable, false, refresh);
            }
        }
    }
}
