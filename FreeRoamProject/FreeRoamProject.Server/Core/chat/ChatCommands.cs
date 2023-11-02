using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerChar;
using FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Server.Core
{
    internal static class ChatEvents
    {
        public static void Init()
        {
            ServerMain.Instance.AddCommand("giveweapon", new Action<PlayerClient, List<string>, string>(GiveWeapon), UserGroup.Moderator, new ChatSuggestion("Give a player a weapon", new SuggestionParam[3] { new("Player ID", "The player's Server ID"), new("Weapon", "The weapon to give to the player [e.g. weapon_pistol]"), new("Quantity", "Quantity of ammunition to give") }));
            ServerMain.Instance.AddCommand("removeweapon", new Action<PlayerClient, List<string>, string>(RemoveWeapon), UserGroup.Moderator, new ChatSuggestion("Remove a weapon from a player", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Weapon", "The weapon to take away from the player [e.g. weapon_pistol]") }));
            ServerMain.Instance.AddCommand("givemoney", new Action<PlayerClient, List<string>, string>(GiveMoney), UserGroup.Moderator, new ChatSuggestion("Give money in wallet to a player", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Amount", "How much money do you want to give him?") }));
            ServerMain.Instance.AddCommand("givebank", new Action<PlayerClient, List<string>, string>(GiveBank), UserGroup.Moderator, new ChatSuggestion("Give money in the bank to a player", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Amount", "How much money do you want to give him?") }));
            ServerMain.Instance.AddCommand("removemoney", new Action<PlayerClient, List<string>, string>(RemoveMoney), UserGroup.Moderator, new ChatSuggestion("Remove money from a player's wallet", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Amount", "How much money do you want to remove?") }));
            ServerMain.Instance.AddCommand("removebank", new Action<PlayerClient, List<string>, string>(RemoveBank), UserGroup.Moderator, new ChatSuggestion("Remove money from a player's bank", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Amount", "How much money do you want to remove?") }));
            ServerMain.Instance.AddCommand("setmoney", new Action<PlayerClient, List<string>, string>(SetFinances), UserGroup.Moderator, new ChatSuggestion("Permanently change a player's money account", new SuggestionParam[3] { new("Player ID", "The player's Server ID"), new("Account", "cash = money, bank = bank, dirty = dirty"), new("Quantity", "Be careful, if I have 10 and I put 1, the quantity becomes 1") }));
            ServerMain.Instance.AddCommand("announcement", new Action<PlayerClient, List<string>, string>(Announcement), UserGroup.Moderator, new ChatSuggestion("Announcement to all players", new SuggestionParam[1] { new("Announcement", "Message for everyone to read") }));
            ServerMain.Instance.AddCommand("revive", new Action<PlayerClient, List<string>, string>(Revive), UserGroup.Moderator, new ChatSuggestion("Revive a player", new SuggestionParam[1] { new("Player ID", "[Optional] The server ID of the player, if you do not enter anything you will revive yourself") }));
            ServerMain.Instance.AddCommand("setgroup", new Action<PlayerClient, List<string>, string>(SetGroup), UserGroup.Admin, new ChatSuggestion("Change group to player", new SuggestionParam[2] { new("Player ID", "The player's Server ID"), new("Group Id", "0 = User, 1 = Helper, 2 = Moderator, 3 = Admin, 4 = Founder, 5 = Developer") }));
            ServerMain.Instance.AddCommand("tp", new Action<PlayerClient, List<string>, string>(Teleport), UserGroup.Moderator, new ChatSuggestion("Teleport to coordinates", new SuggestionParam[3] { new("X", ""), new("Y", ""), new("Z", "") }));
            ServerMain.Instance.AddCommand("suicide", new Action<PlayerClient, List<string>, string>(Die), UserGroup.Moderator, new ChatSuggestion("Kill your character"));
            ServerMain.Instance.AddCommand("car", new Action<PlayerClient, List<string>, string>(SpawnVehicle), UserGroup.Moderator, new ChatSuggestion("Spawns a car and takes you inside it", new SuggestionParam[1] { new("Model", "The vehicle model to spawn") }));
            ServerMain.Instance.AddCommand("dv", new Action<PlayerClient, List<string>, string>(Dv), UserGroup.Moderator, new ChatSuggestion("Delete the current vehicle or the one you are looking at"));
            ServerMain.Instance.AddCommand("saveall", new Action<PlayerClient, List<string>, string>(Saveall), UserGroup.Moderator, new ChatSuggestion("Save all players now"));
            ServerMain.Instance.AddCommand("developer", new Action<PlayerClient, List<string>, string>(Developer), UserGroup.Developer, new ChatSuggestion("Enable developer functions", new SuggestionParam[1] { new("Power", "On/Off") }));
            ServerMain.Instance.AddCommand("setgang", new Action<PlayerClient, List<string>, string>(SetGang), UserGroup.Moderator, new ChatSuggestion("Change a player's gang", new SuggestionParam[3] { new("Player ID", "The player's Server ID"), new("Gang", "The gang to set"), new("Rank", "The gang rank") }));
            ServerMain.Instance.AddCommand("setmeteo", new Action<PlayerClient, List<string>, string>(Weather), UserGroup.Admin, new ChatSuggestion("Change the weather in game", new SuggestionParam[1] { new("Weather", "Enter the number") }));
            ServerMain.Instance.AddCommand("delchar", new Action<PlayerClient, List<string>, string>(delchar), UserGroup.Moderator);
            RegisterCommand("status", new Action<int, List<object>, string>(async (a, b, c) =>
            {
                if (a != 0) return;
                if (b.Count == 0)
                {
                    if (ServerMain.Instance.GetPlayers.Count() > 0)
                    {
                        ServerMain.Logger.Info($"Total Players: {ServerMain.Instance.GetPlayers.Count()}.");
                        foreach (PlayerClient player in ServerMain.Instance.Clients) ServerMain.Logger.Info($"ID:{player.Handle}, {player.Player.Name}, {player.Ped.Position}, Discord:{player.Player.Identifiers["discord"]}, Ping:{player.Player.Ping}, serverID:{GetPlayerRoutingBucket(player.Handle.ToString())}");
                    }
                    else
                        ServerMain.Logger.Warning("No players in the server");
                }
                else
                {
                    int.TryParse(b[0].ToString(), out int bucket);
                    Shared.Core.Buckets.Bucket server = BucketsHandler.FreeRoam.Servers[bucket];
                    if (server.Name == "freeroam")
                    {
                        ServerMain.Logger.Info($"FreeRoam -- Total Players: {ServerMain.Instance.GetPlayers.Count()}");
                        server.Players.ForEach(client =>
                        {
                            ServerMain.Logger.Info($"ID:{client.Handle}, {client.Player.Name}, Discord:{client.Identifiers.Discord}, Ping:{client.Player.Ping}");
                        });
                    }
                }
            }), true);
            RegisterCommand("showchar", new Action<int, List<object>, string>((a, b, c) =>
            {
                string res = GetResourceKvpString($"freeroam:player_306134422434873346:char_model");
                FreeRoamChar data = res.StringToBytes().FromBytes<FreeRoamChar>();
                ServerMain.Logger.Warning(data.ToJson());
            }), true);

            //			ServerMain.Instance.AddCommand("nome comando", new Action<PlayerClient, List<string>, string>(funzione comando), false, new ChatSuggestion("", new SuggestionParam[] { new SuggestionParam() }));
        }

        private static void delchar(PlayerClient sender, List<string> args, string rawCommand)
        {
            /*
            string bytes = GetResourceKvpString($"freeroam:player_{sender.User.Identifiers.Discord}:char_model");
            DeleteResourceKvpNoSync($"freeroam:player_{sender.User.Identifiers.Discord}:char_model");
            */
            string bytes = GetResourceKvpString($"freeroam:player_306134422434873346:char_model");
            DeleteResourceKvpNoSync($"freeroam:player_306134422434873346:char_model");
            ServerMain.Logger.Warning($"{bytes.StringToBytes().Length} bytes deleted successfully");
        }

        public static void GiveWeapon(PlayerClient sender, List<string> args, string rawCommand)
        {
            try
            {
                PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
                if (client != null)
                {
                    User player = client.User;
                    player.addWeapon(args[1].ToUpper(), Convert.ToInt32(args[2]));
                }
                else
                {
                    sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO giveweapon] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
                }
            }
            catch
            {
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO giveweapon] = ", "Parameters errors!" }, color = new[] { 255, 0, 0 } });
            }
        }

        public static void RemoveWeapon(PlayerClient sender, List<string> args, string rawCommand)
        {
            try
            {
                PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
                if (client != null)
                {
                    User player = client.User;
                    player.removeWeapon(args[1].ToUpper());
                }
                else
                {
                    sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO removeweapon] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
                }
            }
            catch
            {
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO removeweapon] = ", "Parameters errors!" }, color = new[] { 255, 0, 0 } });
            }
        }

        // END INVENTORY
        // ACCOUNTS
        public static void GiveMoney(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
            if (client != null)
                client.User.Money += Convert.ToInt32(args[1]);
            else
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO givemoney] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
        }

        public static void GiveBank(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
            if (client != null)
                client.User.Bank += Convert.ToInt32(args[1]);
            else
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO givebank] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
        }

        public static void RemoveMoney(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
            if (client != null)
                client.User.Money -= Convert.ToInt32(args[1]);
            else
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO givedirty] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
        }

        public static void RemoveBank(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
            if (client != null)
                client.User.Bank -= Convert.ToInt32(args[1]);
            else
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO givedirty] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
        }
        public static void SetFinances(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient client = Functions.GetClientFromPlayerId(int.Parse(args[0]));
            if (client != null)
            {
                User player = client.User;
                if (args[1] == "cash")
                {
                    player.Money -= player.Money;
                    player.Money += Convert.ToInt32(args[2]);
                }
                else if (args[1] == "bank")
                {
                    player.Bank -= player.Bank;
                    player.Bank += Convert.ToInt32(args[2]);
                }
                else
                {
                    sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO setmoney] = ", "L'account monetario '" + args[1] + "' non esiste!" }, color = new[] { 255, 0, 0 } });
                }
            }
            else
            {
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO setmoney] = ", "Player with ID " + args[0] + " is not online!" }, color = new[] { 255, 0, 0 } });
            }
        }

        // ANNOUNCE Players
        public static void Announcement(PlayerClient sender, List<string> args, string rawCommand)
        {
            EventDispatcher.Send(ServerMain.Instance.GetPlayers, "tlg:announce", string.Join(" ", args));
        }
        // end ANNOUNCE

        // REVIVE
        public static void Revive(PlayerClient sender, List<string> args, string rawCommand)
        {
            DateTime now = DateTime.Now;

            if (args != null && args.Count > 0)
            {
                if (GetPlayerName(args[0]) != ".")
                {
                    Player p = ServerMain.Instance.GetPlayers[Convert.ToInt32(args[0])];
                    ServerMain.Logger.Info("COMMANDS: " + sender.Player.Name + " used revive on " + GetPlayerName(args[0]));
                    p.TriggerSubsystemEvent("tlg:reviveChar");
                }
            }
            else
            {
                sender.TriggerSubsystemEvent("tlg:reviveChar");
            }
        }
        // FINE REVIVE

        // SETGROUP
        public static async void SetGroup(PlayerClient sender, List<string> args, string rawCommand)
        {
            await BaseScript.Delay(0);
            DateTime now = DateTime.Now;

            if (Convert.ToInt32(args[0]) > 0)
            {
                string group = "normal";
                int group_level = 0;
                Player ricevitore = Functions.GetPlayerFromId(args[0]);
                User user = Functions.GetUserFromPlayerId(ricevitore.Handle);

                if (ricevitore.Name.Length > 0)
                {
                    ServerMain.Logger.Info("Commands: " + sender.Player.Name + " used setgroup on " + ricevitore.Name);
                    BaseScript.TriggerEvent("tlg:serverlog", now.ToString("dd/MM/yyyy, HH:mm:ss") + " -- Commands: " + sender.Player.Name + " used setgroup on " + ricevitore.Name);

                    if (args[1] == "normal")
                    {
                        group = "normal";
                        group_level = (int)UserGroup.User;
                    }
                    else if (args[1] == "helper")
                    {
                        group = "helper";
                        group_level = (int)UserGroup.Helper;
                    }
                    else if (args[1] == "mod")
                    {
                        group = "moderatore";
                        group_level = (int)UserGroup.Moderator;
                    }
                    else if (args[1] == "admin")
                    {
                        group = "admin";
                        group_level = (int)UserGroup.Admin;
                    }
                    else if (args[1] == "founder")
                    {
                        group = "founder";
                        group_level = (int)UserGroup.Founder;
                    }
                    else if (args[1] == "dev")
                    {
                        group = "dev";
                        group_level = (int)UserGroup.Developer;
                    }

                    await ServerMain.Instance.Execute("UPDATE `users` SET `group` = @gruppo,  `group_level` = @groupL WHERE `discord` = @disc", new { gruppo = group, groupL = group_level, disc = user.Identifiers.Discord });
                    user.group = group;
                    user.group_level = (UserGroup)group_level;
                    ServerMain.Logger.Info($"Il player {ricevitore.Name} e' stato settato come gruppo {group}");
                    BaseScript.TriggerEvent("tlg:serverLog", now.ToString("dd/MM/yyyy, HH:mm:ss") + $" --  Il player {ricevitore.Name} e' stato settato come gruppo {group}");
                }
                else
                {
                    ServerMain.Logger.Error("Player with ID " + args[0] + " is not online!");
                }
            }
            else
            {
                ServerMain.Logger.Error("error setgroup..retry");
            }
        }
        // FINE SETGROUP

        public static void Teleport(PlayerClient sender, List<string> args, string rawCommand)
        {
            if (float.TryParse(args[0].Replace("f", "").Replace(",", ""), out float x) && float.TryParse(args[1].Replace("f", "").Replace(",", ""), out float y) && float.TryParse(args[2].Replace("f", ""), out float z))
                sender.TriggerSubsystemEvent("tlg:teleportCoords", new Position(x, y, z));
            else
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO tp] = ", "invalid coords.. retry!" }, color = new[] { 255, 0, 0 } });
        }

        public static void Die(PlayerClient sender, List<string> args, string rawCommand)
        {
            sender.TriggerSubsystemEvent("tlg:death");
        }

        public static void SpawnVehicle(PlayerClient sender, List<string> args, string rawCommand)
        {
            sender.TriggerSubsystemEvent("tlg:spawnVehicle", args[0]);
        }

        public static void Dv(PlayerClient sender, List<string> args, string rawCommand)
        {
            sender.TriggerSubsystemEvent("tlg:deleteVehicle");
        }

        public static void Delgun(PlayerClient sender, List<string> args, string rawCommand)
        {
            sender.TriggerSubsystemEvent("tlg:ObjectDeleteGun", args[0]);
        }

        private static async void Saveall(PlayerClient sender, List<string> args, string rawCommand)
        {
            try
            {
                DateTime now = DateTime.Now;

                foreach (PlayerClient player in ServerMain.Instance.Clients)
                {
                    int freer = 0;
                    int rp = 0;
                    if (player.Status.PlayerStates.Spawned)
                    {
                        player.TriggerSubsystemEvent("tlg:freeroam:showLoading", 4, "Synchronization", 5000);
                        FreeRoamEvents.SaveCharacter(player);
                        ServerMain.Logger.Info($"Saved character freeroam owned by '{player.Player.Name}' - {player.User.Identifiers.Discord}");
                        freer++;
                    }
                    ServerMain.Logger.Info($"Saved {freer} players FreeRoam and {rp} players RP");
                }
                //BaseScript.TriggerClientEvent("tlg:aggiornaPlayers", ServerSession.PlayerList.ToJson());
            }
            catch (Exception ex)
            {
                ServerMain.Logger.Fatal("" + ex);
            }
        }

        public static void Developer(PlayerClient sender, List<string> args, string rawCommand)
        {
            if (args.Count == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO Developer] = ", "Invalid argument error, please try again!" }, color = new[] { 255, 0, 0 } });
                return;
            }
            sender.TriggerSubsystemEvent("tlg:sviluppatoreOn", args[0].ToLower() == "on");
        }

        public static void SetGang(PlayerClient sender, List<string> args, string rawCommand)
        {
            PlayerClient p = Functions.GetClientFromPlayerId(args[0]);

            if (p != null)
            {
                if (p.Status.PlayerStates.Spawned)
                    p.User.SetGang(args[1], Convert.ToInt32(args[2]));
                else
                    sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO setgang] = ", "Error the player did not select a character, try again!" }, color = new[] { 255, 0, 0 } });
            }
            else
            {
                sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO setgang] = ", "Player id not found error, try again!" }, color = new[] { 255, 0, 0 } });
            }
        }

        public static void Weather(PlayerClient sender, List<string> args, string rawCommand)
        {
            if (sender.Handle == 0)
            {
                if (args.Count > 1 || Convert.ToInt32(args[0]) > 14 || !args[0].All(o => char.IsDigit(o)))
                {
                    ServerMain.Logger.Error("/weather <weathertype>\nCurrent Weather: " + TimeWeather.ServerWeather.Weather.CurrentWeather + "\nError weather, available arguments: 0 = EXTRASUNNY, 1 =  CLEAR, 2 = CLOUDS, 3 = SMOG, 4 = FOGGY, 5 = OVERCAST, 6 = RAIN, 7 = THUNDERSTORM, 8 = CLEARING, 9 = NEUTRAL, 10 = SNOW, 11 =  BLIZZARD, 12 = SNOWLIGHT, 13 = XMAS, 14 = HALLOWEEN");

                    return;
                }
                else
                {
                    TimeWeather.ServerWeather.Weather.CurrentWeather = Convert.ToInt32(args[0]);
                    ServerMain.Logger.Debug(TimeWeather.ServerWeather.Weather.CurrentWeather + "");
                    TimeWeather.ServerWeather.Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.Weather_timer * 60;
                    TimeWeather.ServerWeather.ChangeWeather(false);
                }
            }
            else
            {
                if (args.Count < 1 || Convert.ToInt32(args[0]) > 14 || !args[0].All(o => char.IsDigit(o)))
                {
                    sender.Player.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO weather] = ", "Error weather, vailable arguments: ~n~0 = EXTRASUNNY, 1 = CLEAR, 2 = CLOUDS, 3 = SMOG, 4 = FOGGY, 5 = OVERCAST 6 = RAIN, 7 = THUNDERSTORM, 8 = CLEARING, ~n~9 = NEUTRAL, 10 = SNOW, 11 = BLIZZARD, 12 = SNOWLIGHT, 13 = XMAS, 14 = HALLOWEEN!" }, color = new[] { 255, 0, 0 } });
                }
                else
                {
                    TimeWeather.ServerWeather.Weather.CurrentWeather = Convert.ToInt32(args[0]);
                    TimeWeather.ServerWeather.Weather.WeatherTimer = ConfigShared.SharedConfig.Main.Weather.Weather_timer * 60;
                    TimeWeather.ServerWeather.ChangeWeather(false);
                    string meteo = "";
                    int a = Convert.ToInt32(args[0]);

                    switch (a)
                    {
                        case 0:
                            meteo = "Extrasunny";

                            break;
                        case 1:
                            meteo = "Clear";

                            break;
                        case 2:
                            meteo = "Clouds";

                            break;
                        case 3:
                            meteo = "Smog";

                            break;
                        case 4:
                            meteo = "Foggy";

                            break;
                        case 5:
                            meteo = "Overcast ";

                            break;
                        case 6:
                            meteo = "Rain";

                            break;
                        case 7:
                            meteo = "Thunderstorm";

                            break;
                        case 8:
                            meteo = "Clearing";

                            break;
                        case 9:
                            meteo = "Neutral";

                            break;
                        case 10:
                            meteo = "Snow";

                            break;
                        case 11:
                            meteo = "Blizzard";

                            break;
                        case 12:
                            meteo = "Snowlight";

                            break;
                        case 13:
                            meteo = "Xmas";

                            break;
                        case 14:
                            meteo = "Halloween";

                            break;
                        default:
                            meteo = "Unknown";

                            break;
                    }

                    sender.TriggerSubsystemEvent("tlg:ShowNotification", "Weather changed to ~b~" + meteo + "~w~");
                }
            }
        }
    }
}