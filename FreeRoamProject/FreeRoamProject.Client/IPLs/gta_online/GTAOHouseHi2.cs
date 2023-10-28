namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class GTAOHouseHi2 : OnlineApartament
    {
        public GTAOHouseHi2() : base()
        {
            InteriorId = 206081;
            Strip = new Style(InteriorId, "Apart_Hi_Strip_A", "Apart_Hi_Strip_B", "Apart_Hi_Strip_C");
            Booze = new Style(InteriorId, "Apart_Hi_Booze_A", "Apart_Hi_Booze_B", "Apart_Hi_Booze_C");
            Smoke = new Style(InteriorId, "Apart_Hi_Smoke_A", "Apart_Hi_Smoke_B", "Apart_Hi_Smoke_C");
        }
    }
}
