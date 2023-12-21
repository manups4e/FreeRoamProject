using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Shared
{
    public static class Tunables
    {
        public static async Task LoadTunables()
        {
            if (Global_262145 != null) return;
            string json = LoadResourceFile(GetCurrentResourceName(), "files/tunables.json");
            Global_262145 = JObject.Parse(json);
        }
        public static JObject Global_262145 { get; set; }
        public static Global_297959 Global_297959 { get; set; }
    }

    public class Global_297959
    {
        public float f_1 = 1f;
        public float f_2 = 1f;
        public float f_3 = 1f;
        public float f_4 = 1f;
        public float f_5 = 1f;
        public float f_6 = 1f;
        public float f_7 = 1f;
        public float f_8 = 1f;
        public float f_9 = 1f;
        public float f_10 = 1f;
        public float f_11 = 1f;
        public float f_12 = 1f;
        public float f_13 = 1f;
        public float f_14 = 1f;
        public float f_15 = 1f;
        public float f_16 = 1f;
        public float f_17 = 1f;
        public float f_18 = 1f;
        public float f_19 = 1f;
        public float f_20 = 1f;
        public float f_21 = 1f;
        public float f_22 = 1f;
        public float f_23 = 1f;
        public float f_24 = 1f;
        public float f_25 = 1f;
        public float f_26 = 1f;
        public float f_27 = 1f;
        public float f_28 = 1f;
        public float f_29 = 1f;
        public float f_30 = 1f;
        public float f_31 = 1f;
        public float f_32 = 1f;
        public float f_33 = 1f;
        public float f_34 = 1f;
        public float f_35 = 1f;
        public float f_36 = 1f;
        public float f_37 = 1f;
        public float f_38 = 1f;
        public float f_39 = 1f;
        public float f_40 = 1f;
        public float f_41 = 0f;
        public float f_42 = 1f;
        public float f_43 = 1f;
        public float f_44 = 1f;
        public float f_45 = 1f;
        public float f_46 = 1f;
        public float f_47 = 1f;
        public float f_48 = 1f;
        public float f_49 = 1f;
        public float f_50 = 1f;
        public float f_51 = 1f;
        public float f_52 = 1f;
        public float f_53 = 1f;
        public float f_54 = 1f;
        public float f_56 = 1f;
        public float f_57 = 1f;
        public float f_58 = 1f;
    }
}