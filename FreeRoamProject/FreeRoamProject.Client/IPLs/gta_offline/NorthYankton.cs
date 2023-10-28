using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class NorthYankton
    {
        private bool _enabled = false;
        public List<string> ipl = new List<string>()
        {
            "prologue01",
            "prologue01c",
            "prologue01d",
            "prologue01e",
            "prologue01f",
            "prologue01g",
            "prologue01h",
            "prologue01i",
            "prologue01j",
            "prologue01k",
            "prologue01z",
            "prologue02",
            "prologue03",
            "prologue03b",
            "prologue04",
            "prologue04b",
            "prologue05",
            "prologue05b",
            "prologue06",
            "prologue06b",
            "prologue06_int",
            "prologuerd",
            "prologuerdb ",
            "prologue_DistantLights",
            "prologue_LODLights",
            "prologue_m2_door"
        };

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }
    }
}
