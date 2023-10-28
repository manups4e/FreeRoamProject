using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class BahamaMamas // -1388.0013, -618.41967, 30.819599
    {
        private bool _enabled = false;
        public List<string> ipl = new List<string>() { "hei_sm_16_interior_v_bahama_milo_" };
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
