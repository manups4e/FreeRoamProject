namespace FreeRoamProject.Shared
{
    public class Timer
    {
        public long StartTime;
        public void New(int startTime = 0)
        {
#if CLIENT
            StartTime = API.GetNetworkTimeAccurate();
#elif SERVER
            StartTime = API.GetGameTimer();
#endif
            if (startTime > 0)
                StartTime += startTime;
        }

        public long Elapsed()
        {
#if CLIENT
            return API.GetNetworkTimeAccurate() - StartTime;
#elif SERVER
            return API.GetGameTimer() - StartTime;
#endif
        }

        public long Restart()
        {
            long elapsed = Elapsed();
#if CLIENT
            StartTime = API.GetNetworkTimeAccurate();
#elif SERVER
            StartTime = API.GetGameTimer();
#endif
            return elapsed;
        }
    }
}