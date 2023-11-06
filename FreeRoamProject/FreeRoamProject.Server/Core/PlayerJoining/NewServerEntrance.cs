using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server.Core.PlayerChar;
using FreeRoamProject.Shared.PlayerChar;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Core.PlayerJoining
{
    internal static class NewServerEntrance
    {
        private static readonly string NoWhitelist = $@"{{""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",""type"": ""AdaptiveCard"",""version"": ""1.0"",""body"": [{{""type"": ""ColumnSet"",""columns"": [{{""type"": ""Column"",""width"": 2,""items"": [{{""type"": ""TextBlock"",""text"": ""Non sei whitelistato nel server"",""weight"": ""Bolder"",""size"": ""Medium""}},{{""type"": ""TextBlock"",""text"": ""Non hai i permessi necessari ad accedere al ServerMain."",""isSubtle"": true,""wrap"": true}},{{""type"": ""TextBlock"",""text"": ""We are in the Alpha Testing phase, do you want to participate in the testing and report bugs to help development? Enter your details below and join our Discord! (https://discord.gg/n4ep9Fq)"",""isSubtle"": true,""wrap"": true,""size"": ""Small""}},{{""type"": ""TextBlock"",""text"": ""Il tuo nome"",""wrap"": true}},{{""type"": ""Input.Text"",""id"": ""myName"",""placeholder"": ""Scrivi qui Nome o NickName""}},{{""type"": ""TextBlock"",""text"": ""Motivazione"",""wrap"": true}},{{""type"": ""Input.Text"",""id"": ""myMotivazione"",""placeholder"": ""Scrivi qui la motivazione"",""style"": ""Text""}},{{""type"": ""TextBlock"",""text"": ""Nome Discord""}}]}},{{""type"": ""Column"",""width"": 1,""items"": [{{""type"": ""Image"",""url"": ""https://miro.medium.com/max/1000/1*OQQLQscmbtr-xxxw5GKZ3w.jpeg"",""size"": ""auto""}}]}}]}},{{""type"": ""Input.Text"",""placeholder"": ""Scrivi qui NomeDiscord#0000"",""id"": ""MyDiscordId""}}],""actions"": [{{""type"": ""Action.Submit"",""title"": ""Invia""}}]}}";
        private static readonly string ControlloLicenza = $@"{{""$schema"":""http://adaptivecards.io/schemas/adaptive-card.json"",""type"": ""AdaptiveCard"",""version"": ""1.0"",""body"": [{{""type"": ""TextBlock"",""text"": ""Raccolta Informazioni..""}}],""backgroundImage"": {{""url"": ""https://64.media.tumblr.com/109134059fc40ed53f4f7d1ecdebc108/tumblr_p382z4i0va1qeyvpto1_500.gifv"",""horizontalAlignment"": ""Center""}},""minHeight"": ""360px"",""verticalContentAlignment"": ""Bottom""}}";
        private static readonly string IngressoConsentito = $@"{{""$schema"":""http://adaptivecards.io/schemas/adaptive-card.json"",""type"": ""AdaptiveCard"",""version"": ""1.0"",""body"": [{{""type"": ""TextBlock"",""text"": ""Shield 2.0: Accesso consentito, attendi...""}}],""backgroundImage"": {{""url"": ""https://64.media.tumblr.com/109134059fc40ed53f4f7d1ecdebc108/tumblr_p382z4i0va1qeyvpto1_500.gifv"",""horizontalAlignment"": ""Center""}},""minHeight"": ""360px"",""verticalContentAlignment"": ""Bottom""}}";
        private static readonly string Errore = $@"{{""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",""type"": ""AdaptiveCard"",""version"": ""1.3"",""body"": [{{""type"": ""ColumnSet"",""columns"": [{{""type"": ""Column"",""width"": 2,""items"": [{{""type"": ""TextBlock"",""text"": ""Errore sconosciuto"",""weight"": ""Bolder"",""size"": ""Medium""}},{{""type"": ""TextBlock"",""text"": ""Sorry, accessing the server or communicating with the bot experienced an unexpected error!"",""isSubtle"": true,""wrap"": true}},{{""type"": ""TextBlock"",""text"": ""To make it up to you, here's a picture of a kitten on a unicorn!"",""isSubtle"": true,""wrap"": true,""size"": ""Small""}}]}},{{""type"": ""Column"",""width"": 1,""items"": [{{""type"": ""Image"",""url"": ""https://iyanceres.files.wordpress.com/2018/02/cat-unicorn.jpg"",""size"": ""auto""}}]}}]}}]}}";
        private static readonly string InDevelopment = $@"{{""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",""type"": ""AdaptiveCard"",""version"": ""1.3"",""body"": [{{""type"": ""ColumnSet"",""columns"": [{{""type"": ""Column"",""width"": 2,""items"": [{{""type"": ""TextBlock"",""text"": ""Server is in development"",""weight"": ""Bolder"",""size"": ""Medium""}},{{""type"": ""TextBlock"",""text"": ""Siamo spiacenti, l'accesso al server al momento non è consentito, se vuoi aggiornamenti vai su https://discord.gg/n4ep9Fq"",""isSubtle"": true,""wrap"": true}},{{""type"": ""TextBlock"",""text"": ""To make it up to you, here's a picture of a kitten on a unicorn!"",""isSubtle"": true,""wrap"": true,""size"": ""Small""}}]}},{{""type"": ""Column"",""width"": 1,""items"": [{{""type"": ""Image"",""url"": ""https://iyanceres.files.wordpress.com/2018/02/cat-unicorn.jpg"",""size"": ""auto""}}]}}]}}]}}";

        public static void Init()
        {
            ServerMain.Instance.AddEventHandler("playerConnecting", new Action<Player, string, CallbackDelegate, ExpandoObject>(PlayerConnecting));
            ServerMain.Instance.AddEventHandler("playerJoining", new Action<Player, string>(PlayerJoining));
            ServerMain.Instance.AddEventHandler("playerDropped", new Action<Player, string>(Dropped));
            EventDispatcher.Mount("tlg:setupUser", new Func<PlayerClient, Task<Tuple<Snowflake, BasePlayerShared>>>(SetupUser));

#if DEBUG
            ServerMain.Instance.AddEventHandler("onResourceStart", new Action<string>(async (resName) =>
            {
                if (resName == GetCurrentResourceName())
                {
                    foreach (Player p in ServerMain.Instance.GetPlayers)
                    {
                        PlayerJoining(p, "");
                    }
                }
            }));
#endif
        }

        private static async void PlayerConnecting([FromSource] Player source, string playerName, dynamic denyWithReason, dynamic deferrals)
        {
            ServerMain.Logger.Warning($"{source.Name} is connecting.");
            deferrals.defer();
            await BaseScript.Delay(500);

            try
            {
                deferrals.presentCard(ControlloLicenza);
                await BaseScript.Delay(1000);
                List<string> PlayerTokens = new();
                int tokensNum = GetNumPlayerTokens(source.Handle);
                for (int i = 0; i < tokensNum; i++) PlayerTokens.Add(GetPlayerToken(source.Handle, i));
                //ServerMain.Logger.Warning(ServerMain.Impostazioni.ToJson());
                //JoinResponse canJoin = await BotDiscordHandler.DoesPlayerHaveRole(source.GetLicense(Identifier.Discord), ServerMain.Impostazioni.Queue.Permissions, PlayerTokens);

                if (true/*canJoin.allowed*/)
                {
                    if (!ServerMain.Debug)
                    {
                        if (ServerMain.Instance.Clients.Any(x => source.Identifiers["license"] == x.Identifiers.License))
                        {
                            deferrals.done($"Last Galaxy Shield 2.0\nWe're sorry.. but it appears that you are using a license that is already in use among online players.\n" + $"You - Lic.: {source.Identifiers["license"].Replace(source.Identifiers["license "].Substring(20), "")}...,\n" + $"other player - Lic.: {ServerMain.Instance.Clients.FirstOrDefault(x => source.Identifiers["license"] == x.Identifiers.License).Identifiers.License.Replace(ServerMain.Instance.Clients.FirstOrDefault(x => source.Identifiers["license"] == x.Identifiers.License).Identifiers.License.Substring(20), "")}..., name: {ServerMain.Instance.Clients.FirstOrDefault(x => source.Identifiers["license"] == x.Identifiers.License).Player.Name}\n" + $"Do a screenshot of this message and contact the server administrators.\nThank you");
                            return;
                        }
                    }

                    deferrals.presentCard(IngressoConsentito);
                    await BaseScript.Delay(2000);
                    deferrals.done();
                }
                else
                {
                    /*
                    if (canJoin.banned)
                    {
                        string banText = "Last Galaxy Shield 2.0.";

                        if (!string.IsNullOrEmpty(canJoin.endDate))
                        {
                            string endDate = "NEVER";
                            banText += "\nYou are currently banned from the server!";
                            if (canJoin.temp) banText += "\nYour ban is temporary, you will be able to re-enter after the ban end date and time.";
                            banText += "\n- BAN ID: " + canJoin.banId;
                            banText += "\n- Banned from: " + canJoin.banner;
                            banText += "\n- Reason: " + canJoin.reason;
                            banText += "\n- End date: " + canJoin.endDate;
                        }
                        else
                        {
                            banText += "\nYour access to the server has been blocked!";
                            banText += "\n\n- Reason: " + canJoin.reason;
                            banText += "\n- Banned by: ANTICHEAT SYSTEM";
                        }
                        banText += "\n\nIf you want to talk to the staff about your ban, remember to write down the BAN ID (if present, or take a screenshot of the error) and report it to the staff.";
                        deferrals.done(banText);

                        return;
                    }
                    else
                    {
                        if (false) //ServerMain.Impostazioni.Queue.Whitelistonly
                        {
                            deferrals.presentCard(InDevelopment);
                            return;
                        }
                    }
                    */
                }
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
                deferrals.presentCard(Errore);
            }
        }

        private static async void PlayerJoining([FromSource] Player source, string oldId)
        {
            try
            {
                Snowflake newone = SnowflakeGenerator.Instance.Next();
                const string procedure = "call IngressoPlayer(@disc, @lice, @name, @snow)"; // playerJoining on db
                await BaseScript.Delay(0);
                BasePlayerShared basePlayerShared = await MySQL.QuerySingleAsync<BasePlayerShared>(procedure, new { disc = Convert.ToInt64(source.GetLicense(Identifier.Discord)), lice = source.GetLicense(Identifier.License), name = source.Name, snow = newone.ToInt64() });
                User user = new(source, basePlayerShared);
                PlayerClient client = new(user);
                client.Status.Clear();
                ServerMain.Instance.Clients.Add(client);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        public static async void Dropped([FromSource] Player player, string reason)
        {
            Player p = player;
            string name = p.Name;
            string handle = p.Handle;
            string text = name + " left.";
            if (!string.IsNullOrWhiteSpace(reason))
                text = reason;
            try
            {
                PlayerClient client = ServerMain.Instance.Clients.FirstOrDefault(x => x.Handle.ToString() == player.Handle);
                User ped = client?.User;

                if (ped != null)
                {
                    string disc = ped.Identifiers.License;
                    BucketsHandler.FreeRoam.RemovePlayer(client, reason);
                }

                ServerMain.Instance.Clients.RemoveAll(x => x.Handle.ToString() == player.Handle);
                ServerMain.Logger.Info(text);
                // TODO: creare funzione per sapere il bucket del player come oggetto
                BaseScript.TriggerClientEvent("tlg:ShowNotification", "~r~" + text);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }

        private static async Task<Tuple<Snowflake, BasePlayerShared>> SetupUser([FromSource] PlayerClient source)
        {
            try
            {
                await ServerMain.Instance.Execute($"UPDATE users SET last_connection = @last WHERE license = @id", new { last = DateTime.Now, id = source.GetLicense(Identifier.License) });
                return new Tuple<Snowflake, BasePlayerShared>(source.Id, source.User);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());

                return default;
            }
        }

    }
}
