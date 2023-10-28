using FreeRoamProject.Client.Core.Utility;

namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public enum OrganizationColors
    {
        Black = 0,
        Gray = 1,
        Yellow = 2,
        Blue = 3,
        Orange = 5,
        Red = 6,
        Green = 7
    }

    public enum OrganizationFonts
    {
        Font1 = 0,
        Font2 = 1,
        Font3 = 2,
        Font4 = 3,
        Font5 = 4,
        Font6 = 5,
        Font7 = 6,
        Font8 = 7,
        Font9 = 8,
        Font10 = 9,
        Font11 = 10,
        Font12 = 11,
        Font13 = 12
    }
    public enum OrganizationStyle
    {
        Classic = 0,
        Light = 1,
        Normal = 3
    }
    public class FinanceOrganization
    {
        public OrganizationName Name { get; set; }
        public OrganizationOffice Office { get; set; }

        public FinanceOrganization()
        {
            Name = new();
            Office = new();
        }
    }

    public class OrganizationName
    {
        public string Name { get; set; }
        public OrganizationStyle Style { get; set; }
        public OrganizationColors Color { get; set; }
        public OrganizationFonts Font { get; set; }

        public void Set(string name, OrganizationStyle style, OrganizationColors color, OrganizationFonts font)
        {
            Name = name;
            Style = style;
            Color = color;
            Font = font;
            //FinanceOrganization.Office.stage = 0
        }
    }

    public class OrganizationOffice
    {
        public bool NeedToLoad = false;
        public bool Loaded = false;
        public string Target = "prop_ex_office_text";
        public string Prop = "ex_prop_ex_office_text";
        public int RenderId = -1;
        public Scaleform Movie = new("ORGANISATION_NAME");
        public int Stage = 0;

        public void Init()
        {
            IplManager.DrawEmptyRect(Target, Functions.HashUint(Prop));
        }

        public bool Enable
        {
            get => NeedToLoad;
            set => NeedToLoad = value;
        }

        public void Clear()
        {
            if (IsNamedRendertargetRegistered(Target))
                ReleaseNamedRendertarget(Target);
            if (Movie.IsLoaded)
                Movie.Dispose();
            RenderId = -1;
            Movie = null;
            Stage = 0;
        }
    }
}
