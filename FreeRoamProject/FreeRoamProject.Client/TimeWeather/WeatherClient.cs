using System;

namespace FreeRoamProject.Client.TimeWeather
{
    internal static class WeatherClient
    {
        public static SharedWeather Weather { get; set; }
        public static int OldWeather;
        public static bool Transitioning = false;
        private static float _windCostantDirectRad = 51.4285714286f;
        private static ParticleEffectsAssetNetworked snowFx;

        public static void Init()
        {
            EventDispatcher.Mount("tlg:getMeteo", new Action<SharedWeather>(SetWeather));
            ClientMain.Instance.StateBagsHandler.OnWeatherChange += SetWeather;
        }

        public static void Stop()
        {
            EventDispatcher.Unmount("tlg:getMeteo");
            ClientMain.Instance.StateBagsHandler.OnWeatherChange -= SetWeather;
        }

        public static void SetMeteoForMe(Weather met, bool black, bool startup)
        {
            World.TransitionToWeather(met, startup ? 15f : 45f);
            SetBlackout(black);
        }

        public static async void SetWeather(SharedWeather weather)
        {
            if (Weather != weather)
            {
                OldWeather = Weather != null ? Weather.CurrentWeather : 0;
                Weather = weather;
                if (weather.CurrentWeather != OldWeather)
                {
                    World.TransitionToWeather((Weather)Weather.CurrentWeather, Weather.StartUp ? 1f : 45f);
                    World.Weather = (Weather)Weather.CurrentWeather;
                    if (Weather.CurrentWeather == 10 || Weather.CurrentWeather == 11 || Weather.CurrentWeather == 12 || Weather.CurrentWeather == 13)
                    {
                        SetForceVehicleTrails(true);
                        SetForcePedFootstepsTracks(true);
                        ForceSnowPass(true);
                        RequestScriptAudioBank("ICE_FOOTSTEPS", false);
                        RequestScriptAudioBank("SNOW_FOOTSTEPS", false);
                        World.CloudHat = CloudHat.Snowy;
                        snowFx = new ParticleEffectsAssetNetworked("core_snow");
                        await snowFx.Request(1000);
                        while (!snowFx.IsLoaded) await BaseScript.Delay(0);
                        snowFx.SetNextCall();
                    }
                    else
                    {
                        SetForceVehicleTrails(false);
                        SetForcePedFootstepsTracks(false);
                        ForceSnowPass(false);
                        ReleaseScriptAudioBank();
                        if (snowFx is not null && snowFx.IsLoaded) snowFx.MarkAsNoLongerNeeded();
                    }
                }
            }

            if ((Weather.CurrentWeather == 10 || Weather.CurrentWeather == 11 || Weather.CurrentWeather == 12 || Weather.CurrentWeather == 13) && !IPLs.IplManager.Global.IsAnyInteriorActive)
            {
                if (snowFx is null)
                {
                    snowFx = new ParticleEffectsAssetNetworked("core_snow");
                    await snowFx.Request(1000);
                }
                if (!snowFx.IsLoaded) await snowFx.Request(1000);
                snowFx.SetNextCall();
            }

            SetBlackout(Weather.Blackout);
            SetWindDirection(Weather.RandomWindDirection);
            //do we need the wind in game? i think it's cool
            //SetWind(ConfigShared.SharedConfig.Main.Meteo.ss_wind_speed_Mult[newWeather] + 0.1f * ConfigShared.SharedConfig.Main.Meteo.ss_wind_speed_max);
            SetWindSpeed(Weather.WindSpeed);
        }
    }
}