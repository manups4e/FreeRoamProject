using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class Graffitis
    {
        private bool _enabled = false;
        public List<string> ipl = new List<string>()
        {
            "ch3_rd2_bishopschickengraffiti", // 1861.28, 2402.11, 58.53
			"cs5_04_mazebillboardgraffiti",  // 2697.32, 3162.18, 58.1
			"cs5_roads_ronoilgraffiti"   // 2119.12, 3058.21, 53.25
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
