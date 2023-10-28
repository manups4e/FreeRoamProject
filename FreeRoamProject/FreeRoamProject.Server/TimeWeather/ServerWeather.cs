using FreeRoamProject.Server.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.TimeWeather
{
    static class ServerWeather
    {
        public static SharedWeather Weather;
        private static long _timer = 0;
        private static SharedTimer WeatherTimer;
        public static async void Init()
        {
            EventDispatcher.Mount("changeWeatherWithParams", new Action<int, bool, bool>(ChangeWeatherWithParams));
            EventDispatcher.Mount("changeWeatherDynamic", new Action<bool>(ChangeWeatherDynamic));
            EventDispatcher.Mount("changeWeather", new Action<bool>(ChangeWeather));
            EventDispatcher.Mount("SyncWeatherForMe", new Action<PlayerClient, bool>(SyncWeatherForMe));
            Weather = new SharedWeather()
            {
                CurrentWeather = ConfigShared.SharedConfig.Main.Weather.ss_default_weather,
                WeatherTimer = ConfigShared.SharedConfig.Main.Weather.ss_weather_timer * 60,
                RainTimer = ConfigShared.SharedConfig.Main.Weather.ss_rain_timeout * 60,
                RandomWindDirection = Functions.RandomFloatInRange(0, 359),
                WindSpeed = Functions.RandomFloatInRange(0, 12),
            };

            WeatherTimer = new(1000);
            ServerMain.Instance.AddTick(Count);
        }

        private static void SyncWeatherForMe([FromSource] PlayerClient p, bool startup)
        {
            Weather.StartUp = startup;
            EventDispatcher.Send(p, "tlg:getMeteo", Weather);
            Weather.StartUp = false;
        }

        private static void ChangeWeatherWithParams(int meteo, bool black, bool startup)
        {
            Weather.CurrentWeather = meteo;
            Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.ss_weather_timer * 60;
            Weather.Blackout = black;
            ServerMain.Instance.ServerState.Set("Weather", Weather.ToBytes(), true);
        }

        private static void ChangeWeatherDynamic(bool dynamic)
        {
            ConfigShared.SharedConfig.Main.Weather.ss_enable_dynamic_weather = dynamic;
            ServerMain.Instance.ServerState.Set("Weather", Weather.ToBytes(), true);
        }

        public static void ChangeWeather(bool startup)
        {
            if (startup) Weather.StartUp = startup;
            byte[] bytes = Weather.ToBytes();
            ServerMain.Instance.ServerState.Set("Weather", bytes, true);
        }

        public static async Task Count()
        {
            try
            {
                await BaseScript.Delay(1000);
                long tt = API.GetGameTimer();
                Random rand = new Random((int)tt);
                if (Weather.DynamicMeteo)
                {
                    Weather.WeatherTimer--;
                    if (Weather.RainPossible) Weather.RainTimer = -1;
                    else Weather.RainTimer--;
                    if (Weather.WeatherTimer == 0)
                    {
                        if (ConfigShared.SharedConfig.Main.Weather.ss_enable_dynamic_weather)
                        {
                            List<int> currentOptions = ConfigShared.SharedConfig.Main.Weather.ss_weather_Transition[Weather.CurrentWeather];
                            Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                            if (ConfigShared.SharedConfig.Main.Weather.ss_reduce_rain_chance)
                            {
                                foreach (int p in currentOptions)
                                {
                                    if (p == 7 || p == 8)
                                    {
                                        Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                                    }
                                }
                            }

                            if (Weather.RainPossible == false)
                            {
                                while (Weather.CurrentWeather == 7 || Weather.CurrentWeather == 8)
                                {
                                    Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                                }
                            }

                            if (Weather.CurrentWeather == 7 || Weather.CurrentWeather == 8)
                            {
                                Weather.RainTimer = ConfigShared.SharedConfig.Main.Weather.ss_rain_timeout * 60;
                                Weather.RainPossible = false;
                            }
                            Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.ss_weather_timer * 60;
                        }
                    }
                    if (Weather.RainTimer == 0)
                        Weather.RainPossible = true;
                }
                if (tt - _timer > 600000)
                {
                    Weather.RandomWindDirection = Functions.RandomFloatInRange(0, 359);
                    Weather.WindSpeed = Functions.RandomFloatInRange(0, 12);
                    _timer = tt;
                }
                ChangeWeather(false);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e + e.StackTrace);
            }
        }
    }
}