using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class PillboxHospital
    {
        private bool _enabled = false;
        public List<string> ipl = ["rc12b_default"];
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
