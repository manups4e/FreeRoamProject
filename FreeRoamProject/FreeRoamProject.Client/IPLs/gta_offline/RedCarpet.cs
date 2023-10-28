using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class RedCarpet
    {
        private static bool _enabled = false;
        public static List<string> ipl = new List<string>() { "redCarpet" };
        public static bool Enabled
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
