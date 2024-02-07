using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class Simeon
    {
        private bool _enabled = false;
        public List<string> ipl = ["shr_int"];
        public static int InteriorId = 7170;
        public SimeonStyle Style = new();
        public SimeonShutter Shutter = new();
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public void LoadDefault()
        {
            Enabled = true;
            Style.Set(Style.Normal);
            Shutter.Set(Shutter.Opened);
            API.RefreshInterior(InteriorId);
        }

        public void Unload()
        {
            Style.Clear(true);
            Shutter.Clear(true);
            Enabled = false;
        }
    }

    public class SimeonStyle
    {
        public string Normal = "csr_beforeMission";
        public string NoGlass = "csr_inMission";
        public string Destroyed = "csr_afterMissionA";
        public string Fixed = "csr_afterMissionB";

        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Simeon.InteriorId, style, true, refresh);
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(Simeon.InteriorId, Normal, false, refresh);
            IplManager.SetIplPropState(Simeon.InteriorId, NoGlass, false, refresh);
            IplManager.SetIplPropState(Simeon.InteriorId, Destroyed, false, refresh);
            IplManager.SetIplPropState(Simeon.InteriorId, Fixed, false, refresh);
        }
    }

    public class SimeonShutter
    {
        public string None = "";
        public string Opened = "shutter_open";
        public string Closed = "shutter_closed";
        public void Set(string shutter, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Simeon.InteriorId, shutter, true, refresh);
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(Simeon.InteriorId, None, false, refresh);
            IplManager.SetIplPropState(Simeon.InteriorId, Opened, false, refresh);
            IplManager.SetIplPropState(Simeon.InteriorId, Closed, false, refresh);
        }
    }
}
