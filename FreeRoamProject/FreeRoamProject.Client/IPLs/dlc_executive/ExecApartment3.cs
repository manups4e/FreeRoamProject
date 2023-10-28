namespace FreeRoamProject.Client.IPLs.dlc_executive
{
    public class ExecApartment3 : ExecApartment
    {
        public ExecApartment3() : base()
        {
            Style = new StyleExec()
            {
                Theme = new()
                {
                    Modern = new ExecTheme(227841, "apa_v_mp_h_01_c"),
                    Moody = new ExecTheme(228609, "apa_v_mp_h_02_c"),
                    Vibrant = new ExecTheme(229377, "apa_v_mp_h_03_c"),
                    Sharp = new ExecTheme(230145, "apa_v_mp_h_04_c"),
                    Monochrome = new ExecTheme(230913, "apa_v_mp_h_05_c"),
                    Seductive = new ExecTheme(231681, "apa_v_mp_h_06_c"),
                    Regal = new ExecTheme(232449, "apa_v_mp_h_07_c"),
                    Aqua = new ExecTheme(233217, "apa_v_mp_h_08_c"),
                }
            };
        }
    }
}
