using System;

namespace FreeRoamProject.Shared
{

    public class ServerTime
    {
        public TimeSpan TimeOfDay { get; set; }
        public DateTime Date { get; set; }
        public int SecondOfDay { get; set; }
        public bool Frozen { get; set; }
    }


    public class SharedWeather
    {
        public int CurrentWeather { get; set; }
        public bool Blackout { get; set; }
        public bool RainPossible { get; set; }
        public int WeatherTimer { get; set; }
        public int RainTimer { get; set; }
        public float RandomWindDirection { get; set; }
        public bool DynamicWeather { get; set; }
        public bool StartUp { get; set; }
        public float WindSpeed { get; set; }

        public SharedWeather() { }
    }
}
