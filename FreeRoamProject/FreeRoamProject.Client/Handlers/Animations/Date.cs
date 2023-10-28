using System;

namespace FreeRoamProject.Client.Handlers.Animations
{
    public class Date
    {
        public static long Timestamp => DateTime.UtcNow.Ticks / 10000;

        public static long TimestampToTicks(long timestamp)
        {
            return timestamp * 10000;
        }
    }
}
