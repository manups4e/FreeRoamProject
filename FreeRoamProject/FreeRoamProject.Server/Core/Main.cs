using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core
{
    public static class Main
    {
        private static DateTime Now;
        public static void Init()
        {
            ServerMain.Instance.AddTick(Playtime_Time);
            Now = DateTime.UtcNow;
        }

        private static async Task Playtime_Time()
        {
            try
            {
                // TODO: FOR SURE PLAYERS TIME HANDLER IS TO BE RE-DONE
                // gestione tempo players da rifare.. sicuramente!
                await BaseScript.Delay(10000);
                if (ServerMain.Instance.Clients.Count > 0)
                {
                    foreach (PlayerClient user in from user in ServerMain.Instance.Clients where user.User is not null where (user.Status is not null && user.Status.PlayerStates.Spawned) select user)
                    {
                        user.User.playTime += 10;
                    }
                }
                TimeSpan hour = DateTime.UtcNow - Now;
                SetConvarServerInfo("Active since:", $"{hour.Days} days {hour.Hours} Hours {hour.Minutes} Minutes");
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString() + e.StackTrace);
            }
        }
    }
}