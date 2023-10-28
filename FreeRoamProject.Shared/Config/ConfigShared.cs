using Settings.Shared.Config.Generic;

namespace FreeRoamProject.Shared
{
    public class ConfigShared
    {
        public static SharedConfig SharedConfig = new();
    }

    public class SharedConfig
    {
        public MainShared Main = new();
    }

    public class MainShared
    {
        public SharedWeatherSettings Weather = new();
    }
}