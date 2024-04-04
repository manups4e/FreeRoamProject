using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs
{
    public class IPL
    {
        private readonly List<string> Ipls = [];
        private readonly string Ipl = "";
        private bool enabled;
        public Vector3 Position;
        public int Hash = -1;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                if (Ipls.Count > 0)
                    IplManager.EnableIpl(Ipls, value);
                else
                    IplManager.EnableIpl(Ipl, value);
            }
        }

        public IPL(List<string> ipls, Vector3 pos)
        {
            Ipls = ipls;
            Position = pos;
        }
        public IPL(string ipl, Vector3 pos)
        {
            Ipl = ipl;
            Position = pos;
        }
    }
}
