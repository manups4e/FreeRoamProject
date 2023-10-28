namespace FreeRoamProject.Client
{
    internal static class PlayerStatesHandler
    {
        // THIS IS ANOTHER AMAZING CLASS THIS HANDLES PLAYER INSTANCING (CONCEALING PLAYERS) I LOVE THAT WITH THIS WE CAN DECIDE OR NOT WHO SHOW WHERE
        // HONESTLY WHE INSIDE APARTMENTS PLAYERS SHOULD STILL BE ABLE TO SEE EVERYONE IN WORLD MAP
        // BUT IN BUNKERS? AND MAPS UNDERGROUND? GARAGES? OTHER EVENTS THAT REQUIRE THE PLAYER TO BE ON ITS OWN BUT NOT IN ANOTHER BUCKET?
        // also yeah.. if the player is going to do things like races and minigames.. a new bucket would be made..
        // and another bucket would be found when player leaves the minigame/racing bucket
        public static void Init()
        {
            ClientMain.Instance.StateBagsHandler.OnInstanceBagChange += OnInstanceBagChange;
        }

        private static async void OnInstanceBagChange(int userId, InstanceBag value)
        {
            await PlayerCache.Loaded();
            if (userId != PlayerCache.MyPlayer.Handle)
            {
                PlayerClient client = Functions.GetPlayerClientFromServerId(userId);
                if (client == null || client.User == null || !client.Status.PlayerStates.Spawned) return;
                if (!value.Instanced)
                {
                    if (NetworkIsPlayerConcealed(client.Player.Handle))
                        NetworkConcealPlayer(client.Player.Handle, false, false);
                    return;
                }
                if (value.Instance != string.Empty)
                {
                    if (value.ServerIdOwner != 0 || PlayerCache.MyPlayer.Status.Instance.ServerIdOwner != 0)
                    {
                        if (value.ServerIdOwner != PlayerCache.MyPlayer.Player.ServerId && PlayerCache.MyPlayer.Status.Instance.ServerIdOwner != client.Handle)
                        {
                            if (!NetworkIsPlayerConcealed(client.Player.Handle))
                                NetworkConcealPlayer(client.Player.Handle, true, true);
                        }
                        else
                        {
                            if (value.ServerIdOwner == PlayerCache.MyPlayer.Player.ServerId || PlayerCache.MyPlayer.Player.ServerId == value.ServerIdOwner)
                                if (NetworkIsPlayerConcealed(client.Player.Handle))
                                    NetworkConcealPlayer(client.Player.Handle, false, false);
                        }
                    }
                    else if (NetworkIsPlayerConcealed(client.Player.Handle))
                    {
                        NetworkConcealPlayer(client.Player.Handle, false, false);
                    }
                }
                else if (!NetworkIsPlayerConcealed(client.Player.Handle))
                {
                    NetworkConcealPlayer(client.Player.Handle, true, true);
                }
            }
        }
    }
}