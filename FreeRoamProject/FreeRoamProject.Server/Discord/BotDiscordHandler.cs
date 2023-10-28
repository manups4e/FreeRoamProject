using FreeRoamProject.Server.Discord.GuildData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Server.Discord
{
    internal static class BotDiscordHandler
    {
        //private static string serverUrl = "http://45.14.185.37:1337";
        private static string serverUrl = "http://localhost:1337";
        public static Guild TheLastServer;
        public static void Init()
        {
            //BotConnection();
        }

        private static async void BotConnection()
        {
            RequestResponse risposta = await SendToBotAndReceive(new { tipo = "ConnessioneAlServer" });
            await BaseScript.Delay(0);

            while (risposta.status != System.Net.HttpStatusCode.OK)
            {
                ServerMain.Logger.Warning("Connection to bot failed, check if bot is active..");
                risposta = await SendToBotAndReceive(new { tipo = "ConnessioneAlServer" });
                await BaseScript.Delay(5000);
            }

            if (risposta.status == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    TheLastServer = risposta.content.FromJson<Guild>();
                    ServerMain.Logger.Info($"Connected to {TheLastServer.name}, total members {TheLastServer.member_count}");
                }
                catch (Exception e)
                {
                    ServerMain.Logger.Error(e.ToString());
                }
            }
        }

        public static async Task SendToBot(object data) { await ServerMain.Instance.WebRequest.Http(serverUrl, "GET", data.ToJson()); }

        public static async Task<RequestResponse> SendToBotAndReceive(object data) { return await ServerMain.Instance.WebRequest.Http(serverUrl, "GET", data.ToJson()); }

        public static async Task<JoinResponse> DoesPlayerHaveRole(string discordId, List<string> Ruoli, List<string> tokens)
        {
            RequestResponse response = await SendToBotAndReceive(new { tipo = "RichiestaRuoloPlayer", RichiestaInterna = new { IdMember = discordId, Ruoli, Tokens = tokens.ToJson() } });

            return response.status == System.Net.HttpStatusCode.OK ? response.content.FromJson<JoinResponse>() : new JoinResponse() { allowed = false };
        }
    }

    internal class JoinResponse
    {
        public bool allowed;
        public bool banned;
        public string reason;
        public string banId;
        public bool temp;
        public string endDate;
        public string banner;
    }
}