namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class Style
    {
        protected readonly int interiorId;
        public string Stage1;
        public string Stage2;
        public string Stage3;

        public Style(int interior, string a, string b, string c)
        {
            interiorId = interior;
            Stage1 = a;
            Stage2 = b;
            Stage3 = c;
        }

        public void Enable(string details, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(interiorId, details, state, refresh);
        }
    }
}
