namespace FreeRoamProject.Client.IPLs.dlc_executive
{
    public class ExecApartment1 : ExecApartment
    {
        public ExecApartment1() : base()
        {
            Style = new StyleExec()
            {
                Theme = new()
                {
                    Modern = new ExecTheme(227329, "apa_v_mp_h_01_a"),
                    Moody = new ExecTheme(228097, "apa_v_mp_h_02_a"),
                    Vibrant = new ExecTheme(228865, "apa_v_mp_h_03_a"),
                    Sharp = new ExecTheme(229633, "apa_v_mp_h_04_a"),
                    Monochrome = new ExecTheme(230401, "apa_v_mp_h_05_a"),
                    Seductive = new ExecTheme(231169, "apa_v_mp_h_06_a"),
                    Regal = new ExecTheme(231937, "apa_v_mp_h_07_a"),
                    Aqua = new ExecTheme(232705, "apa_v_mp_h_08_a"),
                }
            };
        }
    }
}
