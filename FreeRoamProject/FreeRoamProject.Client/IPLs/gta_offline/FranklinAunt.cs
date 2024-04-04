namespace FreeRoamProject.Client.IPLs.gtav
{
    public class FranklinAunt
    {
        public static int InteriorId = 197889;
        public FranklinAuntStyle Style = new();
        public FranklinAuntDetails Details = new();
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
            Style.Set(Style.Empty);
            Details.Enable(Details.Bandana, false);
            Details.Enable(Details.Bag, false);
            API.RefreshInterior(InteriorId);
        }

    }
    public class FranklinAuntDetails
    {
        public string Bandana = "V_57_GangBandana"; // Bandana on the bed
        public string Bag = "V_57_Safari";          // Bag in the closet
        public void Enable(string details, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(FranklinAunt.InteriorId, details, state, refresh);
        }
    }
    public class FranklinAuntStyle
    {
        public string Empty = "";
        public string FranklinStuff = "V_57_FranklinStuff";
        public string FranklinLeft = "V_57_Franklin_LEFT";

        public void Set(string style, bool refresh = true)
        {
            Clear(false);
            if (style != "") IplManager.SetIplPropState(FranklinAunt.InteriorId, style, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(FranklinAunt.InteriorId);
            }
        }

        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(FranklinAunt.InteriorId, FranklinStuff, false, refresh);
            IplManager.SetIplPropState(FranklinAunt.InteriorId, FranklinLeft, false, refresh);
        }

    }
}
