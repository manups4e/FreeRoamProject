namespace FreeRoamProject.Shared
{
    public enum TimerType
    {
        Milliseconds,
        Seconds,
        Minutes,
    }
    public delegate void TimerTickEvent();
    public class SharedTimeChecker
    {
        private long Timer = 0;
        private readonly long _awaitable = 0;
        private readonly TimerType timerType;
        public event TimerTickEvent TimerTickEvent;

        public bool IsPassed
        {
            get
            {
                long await = _awaitable;
                switch (timerType)
                {
                    case TimerType.Milliseconds:
                        await = _awaitable;
                        break;
                    case TimerType.Seconds:
                        await = _awaitable * 1000;
                        break;
                    case TimerType.Minutes:
                        await = _awaitable * 1000 * 60;
                        break;
                }
#if CLIENT
                bool passed = GetNetworkTime() - Timer > await;
#elif SERVER
                bool passed = GetGameTimer() - Timer > await;
#endif

                if (passed) ResetTimer();
                return passed;
            }
        }

        public SharedTimeChecker(long time, TimerType type = TimerType.Milliseconds)
        {
            _awaitable = time;
            timerType = type;
            ResetTimer();
        }

        public void ResetTimer()
        {
#if CLIENT
            Timer = GetNetworkTime();
#elif SERVER
            Timer = GetGameTimer();
#endif
        }
    }
}
