using System;

namespace FreeRoamProject.Shared.Core.Log
{
    public class DebugLog : Logger.Log
    {
        public new void Debug(string text)
        {
#if DEBUG
            string text2 = $"{DateTime.Now:dd/MM/yyyy, HH:mm}";
            string text3 = "-- [DEBUG] -- ";
            string text4 = "^5";
            CitizenFX.Core.Debug.WriteLine(text4 + text2 + " " + text3 + " " + text + ".^7");
#endif
        }
    }
}
