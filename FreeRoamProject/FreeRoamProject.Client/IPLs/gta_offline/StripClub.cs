namespace FreeRoamProject.Client.IPLs.gtav
{
    public class StripClub
    {
        public static int InteriorId = 197121;

        public string Mess = "V_19_Trevor_Mess";
        public void Enable(bool state)
        {
            IplManager.SetIplPropState(InteriorId, Mess, state, true);
        }

        public void LoadDefault()
        {
            Enable(false);
        }
    }
}
