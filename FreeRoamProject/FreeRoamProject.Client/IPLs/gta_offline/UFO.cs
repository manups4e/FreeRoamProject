namespace FreeRoamProject.Client.IPLs.gtav
{
    public class UFO
    {
        public UFOHippie Hippie = new UFOHippie();
        public UFOChiliad Chiliad = new UFOChiliad();
        public UFOZancudo Zancudo = new UFOZancudo();
    }

    public class UFOHippie
    {
        private bool _enabled = false;
        public string ipl = "ufo";
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
    public class UFOChiliad
    {
        private bool _enabled = false;
        public string ipl = "ufo_eye";
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
    public class UFOZancudo
    {
        private bool _enabled = false;
        public string ipl = "ufo_lod";
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
