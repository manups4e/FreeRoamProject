using System.Collections.Generic;

namespace Settings.Server.Configurazione.Main
{
    public class MainConfig
    {
        public string ServerName { get; set; }
        public string? WebHookLog { get; set; }
        public string? WebHookAnticheat { get; set; }
        public string NotWhitelisted { get; set; }
        public bool EnableAntiSpam { get; set; }
        public int PlayersToStartRocade { get; set; }
        public int PingMax { get; set; }
        public int SaveAll { get; set; }
        public int RentPriceGasPumps { get; set; }
        public int RentPriceShops { get; set; }
        public string WhitelistedRoles { get; set; }
        public string DiscordToken { get; set; }
        public long GuildId { get; set; }
        public Dictionary<string, string> BadWords { get; set; }
    }

    public class ConfigQueue
    {
        public Dictionary<string, string> Messages { get; set; }
        public List<string> Permissions { get; set; }
        public bool Whitelistonly { get; set; }
        public int LoadTime { get; set; }
        public int GraceTime { get; set; }
        public int QueueGraceTime { get; set; }
        public bool AddCountAfterServerName { get; set; }
        public bool AllowSymbols { get; set; }
        public bool StateChangeMessages { get; set; }
    }

}