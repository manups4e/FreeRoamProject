namespace FreeRoamProject.Shared
{
    public delegate void OnFreeRoamSpawn(PlayerClient client);
    public delegate void OnFreeRoamLeave(PlayerClient client);
    public class AccessingEvents
    {
        public static event OnFreeRoamSpawn OnFreeRoamSpawn;
        public static event OnFreeRoamLeave OnFreeRoamLeave;

        public static void FreeRoamSpawn(PlayerClient client)
        {
            OnFreeRoamSpawn?.Invoke(client);
        }
        public static void FreeRoamLeave(PlayerClient client)
        {
            OnFreeRoamLeave?.Invoke(client);
        }
    }
}
