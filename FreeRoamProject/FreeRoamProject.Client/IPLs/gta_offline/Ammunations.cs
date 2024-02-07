using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class Ammunations
    {
        public List<AmmunationIPL> AmmunationsList =
        [
            new(140289, "GunStoreHooks"),  // 249.8, -47.1, 70.0
            new(153857, "GunStoreHooks"),  // 844.0, -1031.5, 28.2
            new(168193, "GunStoreHooks"),  // -664.0, -939.2, 21.8
            new(164609, "GunStoreHooks"),  // -1308.7, -391.5, 36.7
            new(176385, "GunStoreHooks"),  // -3170.0, 1085.0, 20.8
            new(175617, "GunStoreHooks"),  // -1116.0, 2694.1, 18.6
            new(200961, "GunStoreHooks"),  // 1695.2, 3756.0, 34.7
            new(180481, "GunStoreHooks"),  // -328.7, 6079.0, 31.5
            new(178689, "GunStoreHooks")   // 2569.8, 297.8, 108.7
        ];
        public List<AmmunationIPL> GunClubsId =
        [
            new(137729, "GunClubWallHooks"),  // 19.1, -1110.0, 29.8
            new(248065, "GunClubWallHooks")   // 811.0, -2152.0, 29.6
        ];

    }

    public class AmmunationIPL
    {
        public int InteriorId { get; set; }
        public AmmunationsDetails Details { get; set; }
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

        public AmmunationIPL(int interior, string hook)
        {
            InteriorId = interior;
            Details = new(interior, hook);
        }

        public void LoadDefault()
        {
            Details.Enable(Details.Hooks, true, true);
        }
    }

    public class AmmunationsDetails
    {
        private readonly int interior;
        public string Hooks = ""; // ganci per mostrare le armi
        public void Enable(string details, bool state, bool refresh)
        {
            IplManager.SetIplPropState(interior, details, state, refresh);
        }
        public AmmunationsDetails(int interior, string hook)
        {
            this.interior = interior;
            Hooks = hook;
        }
    }
}
