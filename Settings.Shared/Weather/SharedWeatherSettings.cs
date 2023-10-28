using System.Collections.Generic;

namespace Settings.Shared.Config.Generic
{
    public class SharedWeatherSettings
    {
        public bool ss_enable_wind_sync { get; set; }
        public float ss_wind_speed_max { get; set; }
        public float ss_night_time_speed_mult { get; set; }
        public float ss_day_time_speed_mult { get; set; }
        public bool ss_enable_dynamic_weather { get; set; }
        //public int ss_default_weather  { get; set; }
        public int ss_default_weather { get; set; }
        public int ss_weather_timer { get; set; }
        public bool ss_reduce_rain_chance { get; set; }
        public int ss_rain_timeout { get; set; }

        public List<float> ss_wind_speed_Mult { get; set; }

        public List<List<int>> ss_weather_Transition { get; set; }
    }
}