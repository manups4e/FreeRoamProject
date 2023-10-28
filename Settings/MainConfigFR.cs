using System.Collections.Generic;

namespace Settings.Client.FreeRoam
{
    public class MainConfigFR
    {
        public string ServerName { get; set; }
        public string DiscordAppId { get; set; }
        public string DiscordRichPresenceAsset { get; set; }
        public bool KickWarning { get; set; }
        public int AFKCheckTime { get; set; }

        public int AfkTimeout { get; set; }
        public int AutoSavingInterval { get; set; }
        public int PingThreshold { get; set; }
        public int MaxPlayerNameLength { get; set; }
        public bool EnableVoiceChat { get; set; }
        public int DiscordNotificationInterval { get; set; }
        public int MaxMenuOptionCount { get; set; }
        public int SpawnProtectionTime { get; set; }

        public int KillstreakTimeout { get; set; }

        public int MinPrestigeRank { get; set; }
        public int MaxPrestige { get; set; }
        public float PrestigeBonus { get; set; }

        public int CrewInvitationTimeout { get; set; }

        public int SpecialVehicleMinRank { get; set; }

        public List<string> BlackListVehicles { get; set; }

        public GTA2Cam Gta2Cam { get; set; }

        public SettingsSpawn Spawn { get; set; }
        public List<int> Ranks { get; set; }
        public MarkerSettings PlaceMarker { get; set; }

        public int KdRatioMinStat { get; set; }

        public int RewardNotificationTime { get; set; }

        public int CashPerKill { get; set; }
        public int CashPerKillstreak { get; set; }
        public int MaxCashPerKillstreak { get; set; }
        public int CashPerHeadshot { get; set; }
        public int CashPerMission { get; set; }
        public int CashPerFaction { get; set; }
        public int CashPerMelee { get; set; }

        public int ExpPerKill { get; set; }
        public int ExpPerKillstreak { get; set; }
        public int MaxExpPerKillstreak { get; set; }
        public int ExpPerHeadshot { get; set; }
        public int ExpPerMission { get; set; }
        public int ExpPerFaction { get; set; }
        public int ExpPerMelee { get; set; }

        public int ChallengeRequestTimeout { get; set; }

        public EventSettings Event { get; set; }
        public GunSettings Gun { get; set; }
        public StockPilingSettings StockPiling { get; set; }
        public SharpShooterSettings SharpShooter { get; set; }
        public KingOfTheCastleSettings Castle { get; set; }
        public HotPropertySettings Property { get; set; }
        public HuntTheBeastSettings HuntTheBeast { get; set; }
        public float SellWeaponRatio;
        public Dictionary<string, List<string>> AmmuNationWeapons { get; set; }
        public Dictionary<string, AmmunationRefillingWeaponsSettings> AmmuNationRefillAmmo { get; set; }
        public Dictionary<string, AmmunationSpecialAmmoSettings> AmmuNationSpecialAmmo { get; set; }
        public MissionsSettings Mission { get; set; }
        public SpecialCargoMissionSettings Cargo { get; set; }
        public HeistMissionSettings Heist { get; set; }
        public VelocityMissionSettings Velocity { get; set; }
        public MostWantedSettings MostWanted { get; set; }
        public AssetRecoveryMissionSettings AssetRecovery { get; set; }
        public HeadHunterSettings HeadHunter { get; set; }
        public CratesSettings Crate { get; set; }
        public List<WeaponTintSettings> WeaponTints { get; set; }
    }
}
