using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerChar;
using FreeRoamProject.Shared.PlayerChar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core
{
    internal static class Events
    {
        private static int EarlyRespawnFineAmount = 5000;

        public static void Init()
        {
            EventDispatcher.Mount("lprp:dropPlayer", new Action<PlayerClient, string>(Drop));
            EventDispatcher.Mount("lprp:kickPlayerClient", new Action<string, string, int>(Kick));
            EventDispatcher.Mount("lprp:CheckPing", new Action<PlayerClient>(Ping));
            EventDispatcher.Mount("lprp:checkAFK", new Action<PlayerClient>(AFK));
            EventDispatcher.Mount("lprp:bannaPlayer", new Action<string, string, bool, long, int>(BanPlayer));
            EventDispatcher.Mount("tlg:setStateBag", new Action<PlayerClient, string, string>(SetStateBag));
            EventDispatcher.Mount("tlg:GetUserFromServerId", new Func<int, Task<BasePlayerShared>>(GetUserFromHandle));
            EventDispatcher.Mount("tlg:getPlayers", new Func<Task<List<Player>>>(GetAllPlayers));
            EventDispatcher.Mount("tlg:getClients", new Func<PlayerClient, Task<List<PlayerClient>>>(GetAllClients));

            EventDispatcher.Mount("tlg:callPlayers", new Func<PlayerClient, Position, Task<int>>(
            async ([FromSource] a, b) =>
            {
                User user = a.User;
                if (a.Status.PlayerStates.Spawned)
                {
                    user.Character.Position = b;
                }
                return BucketsHandler.FreeRoam.GetTotalPlayers();
            }));
        }

        public static async Task<List<PlayerClient>> GetAllClients([FromSource] PlayerClient sender)
        {
            return BucketsHandler.FreeRoam.GetPlayerBucket(sender.Handle).Players;
        }

        public static async Task<List<Player>> GetAllPlayers()
        {
            return ServerMain.Instance.GetPlayers.OrderBy(x => Convert.ToInt32(x.Handle)).ToList();
        }
        // TODO: HANDLE ALL BUCKETS
        /*
        public static async Task<List<PlayerClient>> GetAllClients([FromSource] PlayerClient request)
        {
            switch (request.Status.PlayerStates.Mode)
            {
                case ServerMode.Roleplay:
                    return BucketsHandler.RolePlay.Bucket.Players;
                case ServerMode.FreeRoam:
                    return BucketsHandler.FreeRoam.Bucket.Players;
                case ServerMode.Lobby:
                    return BucketsHandler.Lobby.Bucket.Players;
                case ServerMode.Minigames:
                    return null;
                case ServerMode.Races:
                    return null;
                case ServerMode.Store:
                    return null;
                case ServerMode.UNKNOWN:
                    return ServerMain.Instance.Clients;
                default:
                    return ServerMain.Instance.Clients;
            }
        }
        */

        public static async Task<BasePlayerShared> GetUserFromHandle(int handle)
        {
            PlayerClient pla = ServerMain.Instance.Clients.FirstOrDefault(x => handle == x.Handle);
            if (pla != null)
            {
                return pla.User.basePlayer;
            }
            return null;
        }
        public static void SetStateBag([FromSource] PlayerClient client, string key, string value)
        {
            ServerMain.Logger.Debug(key);
            byte[] val = value.StringToBytes();
            client.Player.SetState(key, val, true);
        }
        public static void Drop([FromSource] PlayerClient client, string reason)
        {
            client.Player.Drop(reason);
        }

        public static void Ping([FromSource] PlayerClient client)
        {
            if (client.Player.Ping >= 500) //ServerMain.Impostazioni.Main.PingMax
                client.Player.Drop("Ping too high (Limit: " + 500 + ", your ping: " + client.Player.Ping + ")"); //ServerMain.Impostazioni.Main.PingMax
        }

        public static void AFK([FromSource] PlayerClient client)
        {
            client.Player.Drop("Last Galaxy Shield 2.0:\nYou have been detected for too long in AFK");
        }

        private static async void BanPlayer(string target, string reason, bool temp, long timeBan, int banner)
        {
            DateTime TempoBan = new DateTime(timeBan);
            Player Target = Functions.GetPlayerFromId(target);
            List<string> Tokens = new List<string>();
            for (int i = 0; i < GetNumPlayerTokens(target); i++) Tokens.Add(GetPlayerToken(target, i));
            RequestResponse pippo = await Discord.BotDiscordHandler.SendToBotAndReceive(new
            {
                tipo = "BanPlayer",
                RichiestaInterna = new
                {
                    Banner = banner > 0 ? Functions.GetPlayerFromId(banner).Name : "Last Galaxy Shield 2.0",
                    Banned = Target.Name,
                    IdMember = Target.Identifiers["discord"],
                    Reason = reason,
                    Temp = temp,
                    EndDate = timeBan,
                    Tokens = Tokens.ToJson()
                }
            });

            if (pippo.content.FromJson<bool>())
            {
                ServerMain.Logger.Warning($"{(banner > 0 ? $"Player {Functions.GetPlayerFromId(banner).Name}" : "The anticheat")} Banned {Target.Name}, end date {TempoBan.ToString("yyyy-MM-dd HH:mm:ss")}");
                BaseScript.TriggerEvent("lprp:serverLog", $"{(banner > 0 ? $"Okater {Functions.GetPlayerFromId(banner).Name}" : "The anticheat")} Banned {Target.Name}, end date {TempoBan.ToString("yyyy-MM-dd HH:mm:ss")}");
                //Target.Drop($"SHIELD 2.0 Sei stato bannato dal server:\nMotivazione: {motivazione},\nBannato da: {(banner > 0 ? Funzioni.GetPlayerFromId(banner).Name : "Sistema anticheat")}"); // modificare con introduzione in stile anticheat
            }
            else
            {
                ServerMain.Logger.Error("Ban fallito");
            }
        }

        private static void Kick(string target, string reason, int kicker)
        {
            Player Target = Functions.GetPlayerFromId(target);
            Player Kicker = Functions.GetPlayerFromId(kicker);
            ServerMain.Logger.Warning($"Player {Kicker.Name} kicked {Target.Name} out of the server, Reason: {reason}");
            BaseScript.TriggerEvent("lprp:serverLog", $"Player {Kicker.Name} kicked {Target.Name} out of the server, Reason: {reason}");
            Target.Drop($"SHIELD 2.0 You have been kicked off the server:\nReason: {reason},\nKicked by: {Kicker.Name}");
        }
    }
}