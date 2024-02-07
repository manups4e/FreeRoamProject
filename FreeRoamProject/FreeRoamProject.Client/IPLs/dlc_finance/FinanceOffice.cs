using CitizenFX.Core.Native;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public class FinanceOffice
    {
        public int CurrentInteriorId = -1;
        public virtual OfficeFinanceStyle Style { get; set; }
        public virtual OfficeCassaForte Safe { get; set; }
        public OfficeSwag Swag = new();
        public OfficeChairs Chairs = new();
        public OfficeBooze Booze = new();
        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                if (value)
                    LoadDefault();
                else
                    Style.Clear();
            }
        }

        public virtual void LoadDefault()
        {
            Style.Set(Style.Warm, ref CurrentInteriorId);
            Chairs.Set(CurrentInteriorId, Chairs.On, true);
        }

        public void SetStyle(Theme style, bool refresh = true)
        {
            Style.Set(style, ref CurrentInteriorId);
        }
    }

    public class OfficeSafeDoors
    {
        public int HashL;
        public int HashR;
    }

    public class OfficeFinanceStyle
    {
        public static List<Theme> ThemeInternal = [];
        public Theme Warm { get; set; }
        public Theme Classical { get; set; }
        public Theme Vintage { get; set; }
        public Theme Contrast { get; set; }
        public Theme Rich { get; set; }
        public Theme Cool { get; set; }
        public Theme Ice { get; set; }
        public Theme Conservative { get; set; }
        public Theme Polished { get; set; }

        public void Set(Theme style, ref int interiorId, bool refresh = true)
        {
            Clear();
            interiorId = style.InteriorId;
            OfficeCassaForte.CurrentSafeDoors.HashL = API.GetHashKey(style.Safe + "_l");
            OfficeCassaForte.CurrentSafeDoors.HashR = API.GetHashKey(style.Safe + "_r");
            IplManager.EnableIpl(style.Ipl, true);
            if (refresh) API.RefreshInterior(interiorId);
        }

        public void Clear()
        {
            foreach (Theme themeValue in ThemeInternal)
            {
                foreach (Swagging swagValue in OfficeSwag.SwagInternal)
                {
                    IplManager.SetIplPropState(themeValue.InteriorId, swagValue.A, false);
                    IplManager.SetIplPropState(themeValue.InteriorId, swagValue.B, false);
                    IplManager.SetIplPropState(themeValue.InteriorId, swagValue.C, false);
                }
                IplManager.SetIplPropState(themeValue.InteriorId, "office_chairs", false, false);
                IplManager.SetIplPropState(themeValue.InteriorId, "office_booze", false, true);
                OfficeCassaForte.CurrentSafeDoors = new OfficeSafeDoors();
                IplManager.EnableIpl(themeValue.Ipl, false);
            }
        }
    }
    public class Theme
    {
        public int InteriorId { get; set; }
        public string Ipl { get; set; }
        public string Safe { get; set; }
        public Theme(int inter, string ipl, string safe)
        {
            InteriorId = inter;
            Ipl = ipl;
            Safe = safe;
            OfficeFinanceStyle.ThemeInternal.Add(this);
        }
    }
    public class OfficeCassaForte
    {
        public float DoorHeadingL { get; set; }
        public Vector3 Position { get; set; }
        public bool IsLeftDoorOpen = false;
        public bool IsRightDoorOpen = false;
        public static OfficeSafeDoors CurrentSafeDoors = new();

        public void Open(string side)
        {
            if (side.ToLower() == "left" || side.ToLower() == "sinistra") IsLeftDoorOpen = true;
            else if (side.ToLower() == "right" || side.ToLower() == "destra") IsRightDoorOpen = true;
            //				else
            ClientMain.Logger.Debug("Direzioni solo destra e sinistra (left right)");
        }
        public void Close(string side)
        {
            if (side.ToLower() == "left" || side.ToLower() == "sinistra") IsLeftDoorOpen = false;
            else if (side.ToLower() == "right" || side.ToLower() == "destra") IsRightDoorOpen = false;
            //				else
            ClientMain.Logger.Debug("Direzioni solo destra e sinistra (left right)");
        }
        public async void SetDoorState(string doorSide, bool open)
        {
            int doorHandle = 0;
            float heading = DoorHeadingL;
            if (doorSide.ToLower() == "left" || doorSide.ToLower() == "sinistra")
            {
                doorHandle = await GetDoorHandle(CurrentSafeDoors.HashL);
                if (open) heading -= 90;
            }
            else if (doorSide.ToLower() == "right" || doorSide.ToLower() == "destra")
            {
                doorHandle = await GetDoorHandle(CurrentSafeDoors.HashR);
                if (open) heading += 90;
            }

            if (doorHandle == 0)
                ClientMain.Logger.Debug("Errore nell'handle della porta");
            API.SetEntityHeading(doorHandle, heading);
        }

        public async Task<int> GetDoorHandle(int doorHash)
        {
            int timeout = 4;
            int doorHandle = API.GetClosestObjectOfType(Position.X, Position.Y, Position.Z, 5.0f, (uint)doorHash, false, false, false);

            while (doorHandle == 0)
            {
                await BaseScript.Delay(25);
                doorHandle = API.GetClosestObjectOfType(Position.X, Position.Y, Position.Z, 5.0f, (uint)doorHash, false, false, false);
                timeout--;
                if (timeout <= 0)
                    break;
            }
            return doorHandle;
        }
    }

    public class OfficeSwag
    {
        public static List<Swagging> SwagInternal = [];
        public Cashing CashPiles = new();
        public Swagging BoozeCigs = new("swag_booze_cigs", "swag_booze_cigs2", "swag_booze_cigs3");
        public Swagging Counterfeit = new("swag_counterfeit", "swag_counterfeit2", "swag_counterfeit3");
        public Swagging DrugBags = new("swag_drugbags", "swag_drugbags2", "swag_drugbags3");
        public Swagging DrugStatue = new("swag_drugstatue", "swag_drugstatue2", "swag_drugstatue3");
        public Swagging Electronic = new("swag_electronic", "swag_electronic2", "swag_electronic3");
        public Swagging FurCoats = new("swag_furcoats", "swag_furcoats2", "swag_furcoats3");
        public Swagging Gems = new("swag_gems", "swag_gems2", "swag_gems3");
        public Swagging Guns = new("swag_guns", "swag_guns2", "swag_guns3");
        public Swagging Ivory = new("swag_ivory", "swag_ivory2", "swag_ivory3");
        public Swagging Jewel = new("swag_jewelwatch", "swag_jewelwatch2", "swag_jewelwatch3");
        public Swagging Med = new("swag_med", "swag_med2", "swag_med3");
        public Swagging Painting = new("swag_art", "swag_art2", "swag_art3");
        public Swagging Pills = new("swag_pills", "swag_pills2", "swag_pills3");
        public Swagging Silver = new("swag_silver", "swag_silver2", "swag_silver3");

        public void Enable(int interior, string style, bool state, bool refresh)
        {
            IplManager.SetIplPropState(interior, style, state, refresh);
        }
    }
    public class Cashing
    {
        public string A = "cash_set_01"; public string B = "cash_set_02"; public string C = "cash_set_03"; public string D = "cash_set_04"; public string E = "cash_set_05";
        public string F = "cash_set_06"; public string G = "cash_set_07"; public string H = "cash_set_08"; public string I = "cash_set_09"; public string J = "cash_set_10";
        public string K = "cash_set_11"; public string L = "cash_set_12"; public string M = "cash_set_13"; public string N = "cash_set_14"; public string O = "cash_set_15";
        public string P = "cash_set_16"; public string Q = "cash_set_17"; public string R = "cash_set_18"; public string S = "cash_set_19"; public string T = "cash_set_20";
        public string U = "cash_set_21"; public string V = "cash_set_22"; public string W = "cash_set_23"; public string X = "cash_set_24";
        public List<string> All =
        [
            "cash_set_01",
            "cash_set_02",
            "cash_set_03",
            "cash_set_04",
            "cash_set_05",
            "cash_set_06",
            "cash_set_07",
            "cash_set_08",
            "cash_set_09",
            "cash_set_10",
            "cash_set_11",
            "cash_set_12",
            "cash_set_13",
            "cash_set_14",
            "cash_set_15",
            "cash_set_16",
            "cash_set_17",
            "cash_set_18",
            "cash_set_19",
            "cash_set_20",
            "cash_set_21",
            "cash_set_22",
            "cash_set_23",
            "cash_set_24",
        ];
    }
    public class Swagging
    {
        public string A;
        public string B;
        public string C;
        public Swagging(string a, string b, string c)
        {
            A = a;
            B = b;
            C = c;
            OfficeSwag.SwagInternal.Add(this);
        }
    }

    public class OfficeChairs
    {
        public string Off = "";
        public string On = "office_chairs";
        public void Set(int interior, string chair, bool refresh)
        {
            Clear(interior, false);
            if (chair != "")
                IplManager.SetIplPropState(interior, chair, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(interior);
            }
        }
        public void Clear(int interior, bool refresh)
        {
            IplManager.SetIplPropState(interior, On, false, refresh);
        }
    }

    public class OfficeBooze
    {
        public string Off = "";
        public string On = "office_booze";
        public void Set(int interior, string booze, bool refresh)
        {
            Clear(interior, false);
            if (booze != "")
                IplManager.SetIplPropState(interior, booze, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(interior);
            }
        }
        public void Clear(int interior, bool refresh)
        {
            IplManager.SetIplPropState(interior, On, false, refresh);
        }
    }

}
