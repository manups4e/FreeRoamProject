namespace FreeRoamProject.Client.IPLs.dlc_executive
{
    public class ExecApartment2 : ExecApartment
    {
        public ExecApartment2() : base()
        {
            Style = new StyleExec()
            {
                Theme = new()
                {
                    Modern = new ExecTheme(227585, "apa_v_mp_h_01_b"),
                    Moody = new ExecTheme(228353, "apa_v_mp_h_02_b"),
                    Vibrant = new ExecTheme(229121, "apa_v_mp_h_03_b"),
                    Sharp = new ExecTheme(229889, "apa_v_mp_h_04_b"),
                    Monochrome = new ExecTheme(230657, "apa_v_mp_h_05_b"),
                    Seductive = new ExecTheme(231425, "apa_v_mp_h_06_b"),
                    Regal = new ExecTheme(232193, "apa_v_mp_h_07_b"),
                    Aqua = new ExecTheme(232961, "apa_v_mp_h_08_b"),
                }
            };
        }
    }
}
