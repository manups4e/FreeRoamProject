using CitizenFX.Core.Native;

namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class GTAOHouseMid1 : OnlineApartament
    {
        public GTAOHouseMid1() : base()
        {
            InteriorId = 148225;
            Style Strip = new Style(InteriorId, "Apart_Mid_Strip_A", "Apart_Mid_Strip_B", "Apart_Mid_Strip_C");
            Style Booze = new Style(InteriorId, "Apart_Mid_Booze_A", "Apart_Mid_Booze_B", "Apart_Mid_Booze_C");
            Style Smoke = new Style(InteriorId, "Apart_Mid_Smoke_A", "Apart_Mid_Smoke_B", "Apart_Mid_Smoke_C");
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
