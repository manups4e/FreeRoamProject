namespace FreeRoamProject.Shared
{
    static class StateBagsExtensions
    {
        public static void SetState<T>(this PlayerClient client, string key, T value, bool replicated = true) => client.Player.SetState(key, value, replicated);
        public static T GetState<T>(this PlayerClient client, string key) => client.Player.GetState<T>(key);
        public static void SetState<T>(this Player player, string key, T val, bool replicated = true) => player.State.Set(key, val.ToBytes(), replicated);
        public static T GetState<T>(this Player player, string key) => (player.State.Get(key) as byte[]).FromBytes<T>();
        public static void SetState<T>(this Entity ent, string key, T val, bool replicated = true) => ent.State.Set(key, val.ToBytes(), replicated);
        public static T GetState<T>(this Entity ent, string key) => (ent.State.Get(key) as byte[]).FromBytes<T>();
    }
}
