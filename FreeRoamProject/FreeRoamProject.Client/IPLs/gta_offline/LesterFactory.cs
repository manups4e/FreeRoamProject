using CitizenFX.Core.Native;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class LesterFactory
    {
        public static int InteriorId = 92674;
        public LesterDetails Details = new LesterDetails();
        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                IplManager.EnableInterior(InteriorId, value);
            }
        }

        public void LoadDefault()
        {
            Details.Enable(Details.BluePrint, false);
            Details.Enable(Details.Bag, false);
            Details.Enable(Details.FireMan, false);
            Details.Enable(Details.Armour, false);
            Details.Enable(Details.GasMask, false);
            Details.Enable(Details.JanitorStuff, false);
            API.RefreshInterior(InteriorId);
        }
    }

    public class LesterDetails
    {
        public string BluePrint = "V_53_Agency_Blueprint";   // Blueprint on the office desk
        public string Bag = "V_35_KitBag";                   // Bag under the office desk
        public string FireMan = "V_35_Fireman";              // Firemans helmets in the office
        public string Armour = "V_35_Body_Armour";           // Body armor in storage
        public string GasMask = "Jewel_Gasmasks";                // Gas mask and suit in storage
        public string JanitorStuff = "v_53_agency _overalls";  // Janitor stuff in the storage(yes, there is a whitespace)

        public void Enable(string details, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(LesterFactory.InteriorId, details, state, refresh);
        }
    }
}
