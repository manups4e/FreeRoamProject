namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class GTAOApartmentHi1 : OnlineApartament
    {
        public GTAOApartmentHi1() : base()
        {
            InteriorId = 141313;
            Strip = new Style(InteriorId, "Apart_Hi_Strip_A", "Apart_Hi_Strip_B", "Apart_Hi_Strip_C");
            Booze = new Style(InteriorId, "Apart_Hi_Booze_A", "Apart_Hi_Booze_B", "Apart_Hi_Booze_C");
            Smoke = new Style(InteriorId, "Apart_Hi_Smoke_A", "Apart_Hi_Smoke_B", "Apart_Hi_Smoke_C");
        }
    }
}
