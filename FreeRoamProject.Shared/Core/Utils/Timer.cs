namespace FreeRoamProject.Shared
{

    public class Timer
    {
        public long StartTime;
        public void New(int startTime = 0)
        {
            StartTime = API.GetGameTimer();
            if (startTime > 0)
                StartTime += startTime;
        }

        public long Elapsed()
        {
            return API.GetGameTimer() - StartTime;
        }

        public long Restart()
        {
            long elapsed = Elapsed();
            StartTime = API.GetGameTimer();
            return elapsed;
        }
    }
}