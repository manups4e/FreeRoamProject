﻿using System.Collections.Generic;

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

    public class ConfigPropertiesRP
    {
        public Dictionary<string, ConfigHouses> Apartments { get; set; }
        public ConfigGarages Garages { get; set; }
    }

    public class ConfigApartments
    {
        public Dictionary<string, ConfigHouses> LowEnd { get; set; }
        public Dictionary<string, ConfigHouses> MidEnd { get; set; }
        public Dictionary<string, ConfigHouses> HighEnd { get; set; }
    }

    public class ConfigGarages
    {
        public ConfigGarage LowEnd { get; set; }
        public ConfigGarage MidEnd4 { get; set; }
        public ConfigGarage MidEnd6 { get; set; }
        public ConfigGarage HighEnd { get; set; }
        public Dictionary<string, Garages> Garages { get; set; }
        // add offices
    }

    public class ConfigGarage
    {
        public Position Pos { get; set; }
        public int NVehs { get; set; }
        public Position OutMarker { get; set; }
        public Position ModifyMarker { get; set; }
        public Position[] ModifyCam { get; set; } = new Position[2];
        public Position SpawnInLocation { get; set; }
        public List<Position> PosVehs { get; set; }
    }

    public class Garages
    {
        public string Label { get; set; }
        public int Type { get; set; }
        public int VehCapacity { get; set; }
        public Position MarkerEntrance { get; set; }
        public Position MarkerExit { get; set; }
        public Position SpawnInside { get; set; }
        public Position SpawnOutside { get; set; }
        public ConfigHouseCamExt CameraOutside { get; set; }
        public ConfigHouseCamExt CameraEditorInside { get; set; }
        public int Price { get; set; }
    }

    public class ConfigHouses
    {
        public string Label { get; set; }
        public int VehCapacity { get; set; }
        public int Type { get; set; }
        public Position MarkerEntrance { get; set; }
        public Position MarkerExit { get; set; }
        public Position SpawnInside { get; set; }
        public Position SpawnOutside { get; set; }
        public ConfigHouseCamExt CameraOutside { get; set; }
        public ConfigCaseCamInt CameraInside { get; set; }
        public List<string> Ipls { get; set; }
        public string Gateway { get; set; }
        public bool Is_single { get; set; }
        public bool Is_room { get; set; }
        public bool Is_gateway { get; set; }
        public bool HasRoof { get; set; }
        public Position MarkerRoof { get; set; }
        public Position SpawnRoof { get; set; }
        public bool GarageIncluded { get; set; }
        public Position MarkerGarageExtern { get; set; }
        public Position MarkerGarageInternal { get; set; }
        public Position SpawnGarageWalkInside { get; set; }
        public Position SpawnGarageVehicleOutside { get; set; }
        public int Price { get; set; }
        public int Style { get; set; } = 0;
        public bool Strip { get; set; }
        public bool Booze { get; set; }
        public bool Smoke { get; set; }
    }

    public class ConfigCaseCamInt
    {
        public ConfigHouseCamExt Inside { get; set; }
        public ConfigHouseCamExt Bathroom { get; set; }
        public ConfigHouseCamExt Garage { get; set; }
    }

    public class ConfigHouseCamExt
    {
        public Position Pos { get; set; }
        public Position Rotation { get; set; }
    }

}
