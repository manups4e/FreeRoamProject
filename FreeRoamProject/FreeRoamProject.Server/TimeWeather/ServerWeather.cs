using FreeRoamProject.Server.Core.Buckets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Server.TimeWeather
{
    static class ServerWeather
    {
        //public static SharedWeather Weather;
        private static long _timer = 0;
        private static bool isXmas = (DateTime.Now.Date.Month == 12 && DateTime.Now.Date.Day >= 8) || (DateTime.Now.Date.Month == 1 && DateTime.Now.Date.Day < 7);
        public static async void Init()
        {
            EventDispatcher.Mount("changeWeatherWithParams", new Action<PlayerClient, int, bool, bool>(ChangeWeatherWithParams));
            EventDispatcher.Mount("changeWeatherDynamic", new Action<PlayerClient, bool>(ChangeWeatherDynamic));
            EventDispatcher.Mount("changeWeather", new Action<int, bool>(ChangeWeather));
            EventDispatcher.Mount("SyncWeatherForMe", new Func<PlayerClient, bool, Task<SharedWeather>>(SyncWeatherForMe));

            ServerMain.Instance.AddTick(Count);
        }

        private static async Task<SharedWeather> SyncWeatherForMe([FromSource] PlayerClient p, bool startup)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(p.Handle);
            return server.Weather;
        }

        private static void ChangeWeatherWithParams([FromSource] PlayerClient p, int meteo, bool black, bool startup)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(p.Handle);
            server.Weather.CurrentWeather = meteo;
            server.Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.Weather_timer * 60;
            server.Weather.Blackout = black;

            ServerMain.Instance.ServerState.Set("Weather_" + server.ID, server.Weather.ToBytes(), true);
        }

        private static void ChangeWeatherDynamic([FromSource] PlayerClient p, bool dynamic)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetPlayerBucket(p.Handle);
            ConfigShared.SharedConfig.Main.Weather.Enable_dynamic_weather = dynamic;
            ServerMain.Instance.ServerState.Set("Weather_" + server.ID, server.Weather.ToBytes(), true);
        }

        public static void ChangeWeather(int id, bool startup)
        {
            Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.GetServerFromId(id);
            if (startup) server.Weather.StartUp = startup;
            byte[] bytes = server.Weather.ToBytes();
            ServerMain.Instance.ServerState.Set("Weather_" + id, bytes, true);
        }

        public static async Task Count()
        {
            // timer is set on every 10 seconds.. maybe we can add more time between each check?
            try
            {
                foreach (KeyValuePair<int, Shared.Core.Buckets.Bucket> server in BucketsHandler.FreeRoam.Servers)
                {
                    long tt = API.GetGameTimer();
                    Random rand = new Random((int)tt);
                    if (server.Value.Weather.WeatherTimer > 0)
                        server.Value.Weather.WeatherTimer -= 10;
                    if (server.Value.Weather.WeatherTimer == 0)
                    {
                        server.Value.Weather.RandomWindDirection = SharedMath.GetRandomFloat(0, 359);
                        server.Value.Weather.WindSpeed = SharedMath.GetRandomFloat(0, 12);
                        _timer = API.GetGameTimer();
                    }
                    if (server.Value.Weather.DynamicWeather)
                    {
                        if (!isXmas) // not xMas
                        {
                            if (server.Value.Weather.RainPossible)
                                server.Value.Weather.RainTimer = -1;
                            else
                                server.Value.Weather.RainTimer -= 5;
                            if (server.Value.Weather.WeatherTimer == 0)
                            {
                                if (ConfigShared.SharedConfig.Main.Weather.Enable_dynamic_weather)
                                {
                                    List<int> currentOptions = ConfigShared.SharedConfig.Main.Weather.Weather_Transition[server.Value.Weather.CurrentWeather];
                                    server.Value.Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                                    if (ConfigShared.SharedConfig.Main.Weather.Reduce_rain_chance)
                                    {
                                        foreach (int p in currentOptions)
                                        {
                                            if (p == 7 || p == 8)
                                            {
                                                server.Value.Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                                            }
                                        }
                                    }

                                    if (server.Value.Weather.RainPossible == false)
                                    {
                                        while (server.Value.Weather.CurrentWeather == 7 || server.Value.Weather.CurrentWeather == 8)
                                        {
                                            server.Value.Weather.CurrentWeather = currentOptions[rand.Next(currentOptions.Count - 1)];
                                        }
                                    }

                                    if (server.Value.Weather.CurrentWeather == 7 || server.Value.Weather.CurrentWeather == 8)
                                    {
                                        server.Value.Weather.RainTimer = ConfigShared.SharedConfig.Main.Weather.Rain_timeout * 60;
                                        server.Value.Weather.RainPossible = false;
                                    }
                                    server.Value.Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.Weather_timer * 60;
                                }
                            }
                            if (server.Value.Weather.RainTimer == 0)
                                server.Value.Weather.RainPossible = true;
                        }
                        else
                        {
                            if (server.Value.Weather.CurrentWeather != 13)
                            {
                                server.Value.Weather.CurrentWeather = 13;
                            }
                            if (server.Value.Weather.WeatherTimer == 0)
                                server.Value.Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.Weather_timer * 60;
                        }
                    }
                    if (server.Value.Weather.WeatherTimer == 0)
                    {
                        server.Value.Weather.RandomWindDirection = SharedMath.GetRandomFloat(0, 359);
                        server.Value.Weather.WindSpeed = SharedMath.GetRandomFloat(0, 12);
                        _timer = API.GetGameTimer();
                    }
                    ChangeWeather(server.Key, false);
                }

                await BaseScript.Delay(10000);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e + e.StackTrace);
            }
        }
    }
}