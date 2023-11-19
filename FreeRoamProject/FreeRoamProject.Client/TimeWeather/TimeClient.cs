using System;

namespace FreeRoamProject.Client.TimeWeather
{
    // do we actually need this or is day/night time synced between players automatically?
    // we need to find better answer to this as i want each bucket to have their own time of day and their own weather... except on xMas / Halloween
    public static class TimeClient
    {
        private static TimeSpan currentDayTime;
        public static TimeSpan CurrentDayTime
        {
            get
            {
                if (NetworkIsClockTimeOverridden()) return OverriddenDayTime;
                int h = 0, m = 0, s = 0;
                NetworkGetGlobalMultiplayerClock(ref h, ref m, ref s);
                currentDayTime = new TimeSpan(h, m, s);
                return currentDayTime;
            }
            //set => currentDayTime = value;
        }
        public static TimeSpan OverriddenDayTime;

        public static void Init()
        {

        }

        public static void Stop()
        {

        }

        public static async void Override(int h, int m, int s)
        {

        }
        public static async void Override(int ticks)
        {

            /*
			_cambio = true;
			HUD.ShowLoadingSavingNotificationWithTime("Aggiornamento orario del server tra 3 secondi", LoadingSpinnerType.Clockwise1, 1000);
			await BaseScript.Delay(1000);
			HUD.ShowLoadingSavingNotificationWithTime("Aggiornamento orario del server tra 2 secondi", LoadingSpinnerType.Clockwise1, 1000);
			await BaseScript.Delay(1000);
			HUD.ShowLoadingSavingNotificationWithTime("Aggiornamento orario del server tra 1 secondo", LoadingSpinnerType.Clockwise1, 1000);
			await BaseScript.Delay(1000);
			NetworkClearClockTimeOverride();
			HUD.ShowLoadingSavingNotificationWithTime("Aggiornamento orario del server in corso...", LoadingSpinnerType.Clockwise1, 10000);
			await BaseScript.Delay(2000);
			Screen.Fading.FadeOut(800);
			if (Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVeicolo)
				VehicleChecker.CurrentVehicle.IsPositionFrozen = true;
			else
				Cache.PlayerCache.MyPlayer.Ped.IsPositionFrozen = true;
			await BaseScript.Delay(2000);
			TempoOrario.SecondOfDay = tempo;
			h = (int)Math.Floor(tempo / 3600f);
			m = (int)Math.Floor((tempo - h * 3600f) / 60);
			s = tempo - h * 3600 - m * 60;
			AdvanceClockTimeTo(h, m, s);
			await BaseScript.Delay(1950);
			if (Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVeicolo)
				VehicleChecker.CurrentVehicle.IsPositionFrozen = false;
			else
				Cache.PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
			Screen.Fading.FadeIn(800);
			_cambio = false;
			*/
        }
    }
}