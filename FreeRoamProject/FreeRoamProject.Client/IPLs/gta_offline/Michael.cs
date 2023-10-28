using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.gtav
{
    public class Michael
    {
        public static int InteriorId = 166657;
        public static int GarageId = 166401;
        public MichaelStyle Style = new MichaelStyle();
        public MichaelGarage Garage = new MichaelGarage();
        public MichaelBed Bed = new MichaelBed();
        public MichaelDetails Details = new MichaelDetails();
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
            Garage.Enable(false, true);
            Style.Set(Style.Normal);
            Bed.Set(Bed.Tidy);
            Details.Enable(Details.MoviePoster, false);
            Details.Enable(Details.FameShamePoste, false);
            Details.Enable(Details.SpyGlasses, false);
            Details.Enable(Details.PlaneTicket, false);
            Details.Enable(Details.Bugershot, false);
            API.RefreshInterior(InteriorId);
        }
    }
    public class MichaelStyle
    {
        public List<string> Normal = new List<string>() { "V_Michael_bed_tidy", "V_Michael_M_items", "V_Michael_D_items", "V_Michael_S_items", "V_Michael_L_Items" };
        public List<string> Moved = new List<string>() { "V_Michael_bed_Messy", "V_Michael_M_moved", "V_Michael_D_Moved", "V_Michael_L_Moved", "V_Michael_S_items_swap", "V_Michael_M_items_swap" };

        public void Set(List<string> style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Michael.InteriorId, style, true, refresh);
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(Michael.InteriorId, Normal, false, refresh);
            IplManager.SetIplPropState(Michael.InteriorId, Moved, false, refresh);
        }
    }

    public class MichaelBed
    {
        public string Tidy = "V_Michael_bed_tidy";
        public string Messy = "V_Michael_bed_Messy";
        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(Michael.InteriorId, style, true, refresh);
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(Michael.InteriorId, Tidy, false, refresh);
            IplManager.SetIplPropState(Michael.InteriorId, Messy, false, refresh);
        }
    }
    public class MichaelGarage
    {
        public string Scuba = "V_Michael_Scuba"; // accessorio scuba
        public void Enable(bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(Michael.GarageId, Scuba, state, refresh);
        }
    }

    public class MichaelDetails
    {
        public string MoviePoster = "Michael_Presser";          // Meltdown movie poster
        public string FameShamePoste = "V_Michael_FameShame";     // Next to Tracey's bed
        public string PlaneTicket = "V_Michael_plane_ticket";       // Plane ticket
        public string SpyGlasses = "V_Michael_JewelHeist";      // On the shelf inside Michael's bedroom
        public string Bugershot = "burgershot_yoga";                // Bag and cup in the kitchen, next to the sink

        public void Enable(string details, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(Michael.InteriorId, details, state, refresh);
        }

    }
}
