using System.Collections.Generic;

namespace Settings.Shared.Config.Generic
{
    public class SharedWeatherSettings
    {
        public bool Enable_wind_sync { get; set; }
        public float Wind_speed_max { get; set; }
        public float Night_time_speed_mult { get; set; }
        public float Day_time_speed_mult { get; set; }
        public bool Enable_dynamic_weather { get; set; }
        //public int Default_weather  { get; set; }
        public int Default_weather { get; set; }
        public int Weather_timer { get; set; }
        public bool Reduce_rain_chance { get; set; }
        public int Rain_timeout { get; set; }

        public List<float> Wind_speed_Mult { get; set; }

        public List<List<int>> Weather_Transition { get; set; }
    }
}