using FreeRoamProject.Shared;

namespace FreeRoamProject.Server.Core
{
    public enum Identifier
    {
        Steam,
        License,
        Discord,
        Fivem,
        Ip
    }

    public static class License
    {
        public static string GetLicense(this Player player, Identifier identifier)
        {
            return identifier switch
            {
                Identifier.Steam => player.Identifiers["steam"],
                Identifier.License => player.Identifiers["license2"],
                Identifier.Discord => player.Identifiers["discord"],
                Identifier.Fivem => player.Identifiers["fivem"],
                Identifier.Ip => player.Identifiers["ip"],
                _ => null
            };
        }

        public static string GetLicense(this PlayerClient client, Identifier identifier)
        {
            return identifier switch
            {
                Identifier.Steam => client.Player.Identifiers["steam"],
                Identifier.License => client.Player.Identifiers["license2"],
                Identifier.Discord => client.Player.Identifiers["discord"],
                Identifier.Fivem => client.Player.Identifiers["fivem"],
                Identifier.Ip => client.Player.Identifiers["ip"],
                _ => null
            };
        }
    }
}