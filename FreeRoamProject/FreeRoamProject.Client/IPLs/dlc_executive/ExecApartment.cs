using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_executive
{
    public class ExecApartment
    {
        public int CurrentInteriorId = -1;
        public StyleExec Style { get; set; }
        public MainStyle Strip = new MainStyle("Apart_Hi_Strip_A", "Apart_Hi_Strip_B", "Apart_Hi_Strip_C");
        public MainStyle Booze = new MainStyle("Apart_Hi_Booze_A", "Apart_Hi_Booze_B", "Apart_Hi_Booze_C");
        public MainStyle Smoke = new MainStyle("Apart_Hi_Smokes_A", "Apart_Hi_Smokes_B", "Apart_Hi_Smokes_C");
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
            Style.Set(Style.Theme.Modern, ref CurrentInteriorId, true);
            Strip.Enable(CurrentInteriorId, Strip.Stage1, false);
            Strip.Enable(CurrentInteriorId, Strip.Stage2, false);
            Strip.Enable(CurrentInteriorId, Strip.Stage3, false);
            Booze.Enable(CurrentInteriorId, Booze.Stage1, false);
            Booze.Enable(CurrentInteriorId, Booze.Stage2, false);
            Booze.Enable(CurrentInteriorId, Booze.Stage3, false);
            Smoke.Set(CurrentInteriorId, Smoke.NoneSmoke);
        }
    }

    public class StyleExec
    {
        public ExecApartTheme Theme = new();

        public void Set(ExecTheme style, ref int interior, bool refresh)
        {
            Clear();
            interior = style.InteriorId;
            IplManager.EnableIpl(style.Ipl, true);
            if (refresh) API.RefreshInterior(interior);
        }
        public void Clear()
        {
            var stripList = new List<string>() { "Apart_Hi_Strip_A", "Apart_Hi_Strip_B", "Apart_Hi_Strip_C" };
            var boozeList = new List<string>() { "Apart_Hi_Booze_A", "Apart_Hi_Booze_B", "Apart_Hi_Booze_C" };
            var smokeList = new List<string>() { "Apart_Hi_Smokes_A", "Apart_Hi_Smokes_B", "Apart_Hi_Smokes_C" };

            IplManager.SetIplPropState(Theme.Modern.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Modern.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Modern.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Modern.Ipl, false);

            IplManager.SetIplPropState(Theme.Moody.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Moody.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Moody.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Moody.Ipl, false);

            IplManager.SetIplPropState(Theme.Vibrant.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Vibrant.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Vibrant.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Vibrant.Ipl, false);

            IplManager.SetIplPropState(Theme.Sharp.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Sharp.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Sharp.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Sharp.Ipl, false);

            IplManager.SetIplPropState(Theme.Monochrome.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Monochrome.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Monochrome.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Monochrome.Ipl, false);

            IplManager.SetIplPropState(Theme.Seductive.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Seductive.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Seductive.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Seductive.Ipl, false);

            IplManager.SetIplPropState(Theme.Regal.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Regal.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Regal.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Regal.Ipl, false);

            IplManager.SetIplPropState(Theme.Aqua.InteriorId, stripList, false);
            IplManager.SetIplPropState(Theme.Aqua.InteriorId, boozeList, false);
            IplManager.SetIplPropState(Theme.Aqua.InteriorId, smokeList, false);
            IplManager.EnableIpl(Theme.Aqua.Ipl, false);
        }
    }
    public class ExecApartTheme
    {
        public ExecTheme Modern { get; set; }
        public ExecTheme Moody { get; set; }
        public ExecTheme Vibrant { get; set; }
        public ExecTheme Sharp { get; set; }
        public ExecTheme Monochrome { get; set; }
        public ExecTheme Seductive { get; set; }
        public ExecTheme Regal { get; set; }
        public ExecTheme Aqua { get; set; }

    }
    public class ExecTheme
    {
        public int InteriorId;
        public string Ipl;
        public ExecTheme(int inter, string ipl)
        {
            InteriorId = inter;
            Ipl = ipl;
        }
    }


    public class MainStyle
    {
        public string NoneSmoke = "";
        public string Stage1;
        public string Stage2;
        public string Stage3;

        public MainStyle(string a, string b, string c)
        {
            Stage1 = a;
            Stage2 = b;
            Stage3 = c;
        }

        public void Enable(int interior, string details, bool state, bool refresh = true)
        {
            IplManager.SetIplPropState(interior, details, state, refresh);
        }

        public void Set(int interior, string style, bool refresh = true)
        {
            if (style != "")
            {
                if (style.Contains("Smoke"))
                {
                    Clear(interior, false);
                    IplManager.SetIplPropState(interior, style, true, refresh);
                }
            }
            else
            {
                if (refresh) API.RefreshInterior(interior);
            }
        }
        public void Clear(int interior, bool refresh = true)
        {
            IplManager.SetIplPropState(interior, Stage1, refresh);
            IplManager.SetIplPropState(interior, Stage2, refresh);
            IplManager.SetIplPropState(interior, Stage3, refresh);
        }
    }
}
