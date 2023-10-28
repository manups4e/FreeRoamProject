using CitizenFX.Core.Native;

namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class GTAOHouseLow1 : OnlineApartament
    {
        public GTAOHouseLow1() : base()
        {
            InteriorId = 149761;
            Strip = new Style(InteriorId, "Apart_Lo_Strip_A", "Apart_Lo_Strip_B", "Apart_Lo_Strip_C");
            Booze = new Style(InteriorId, "Apart_Lo_Booze_A", "Apart_Lo_Booze_B", "Apart_Lo_Booze_C");
            Smoke = new Style(InteriorId, "Apart_Lo_Smoke_A", "Apart_Lo_Smoke_B", "Apart_Lo_Smoke_C");
        }
        public void Set(string smoke, bool refresh)
        {
            if (smoke != "")
            {
                if (smoke.Contains("Smoke"))
                {
                    Clear(false);
                    IplManager.SetIplPropState(InteriorId, smoke, true, refresh);
                }
            }
            else
            {
                if (refresh) API.RefreshInterior(InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(InteriorId, Smoke.Stage1, false);
            IplManager.SetIplPropState(InteriorId, Smoke.Stage2, false);
            IplManager.SetIplPropState(InteriorId, Smoke.Stage3, false);
        }
    }
}
