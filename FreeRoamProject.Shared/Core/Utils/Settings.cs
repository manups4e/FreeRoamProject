using System.Collections.Generic;

namespace FreeRoamProject.Shared
{

    public class FreeRoamSettings
    {
    }


    public class WeaponTintSettings
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int Kills { get; set; }
        public int Cash { get; set; }
    }



    public class CratesSettings
    {
        public int Cash;
        public int NthRank;
        public EventReward Reward = new();
        public float Radius;
        public List<CratesWeapon> Weapons = [];
        public List<CrateLocations> Locations = [];
    }

    public class CratesWeapon
    {
        public string Id;
        public string Name;
        public int Ammo;
    }

    public class CrateLocations
    {
        public float[] Blip = new float[3];
        public List<float[]> Positions = [];
    }


    public class HeadHunterSettings
    {
        public int Time;
        public float Radius;
        public List<HeadHunterTarget> Targets = [];
        public List<string> Weapons = [];
        public int WantedLevel;
        public AssetRecoveryRewards Rewards = new();
    }

    public class HeadHunterTarget
    {
        public string PedModel;
        public float[] Location = new float[3];
    }


    public class AssetRecoveryMissionSettings
    {
        public int Time;
        public List<AssetRecoveryVariant> Variants = [];
        public float DropRadius;
    }

    public class AssetRecoveryVariant
    {
        public string Vehicle;
        public float[] VehicleLocation = new float[4];
        public float[] DropOffLocation = new float[3];
    }

    public class AssetRecoveryRewards
    {
        public AssetRecoveryReward Cash = new();
        public AssetRecoveryReward Exp = new();
    }

    public class AssetRecoveryReward
    {
        public int Min;
        public int Max;
    }



    public class MostWantedSettings
    {
        public int Time;
        public MostWantedRewards Rewards = new();
    }

    public class MostWantedRewards
    {
        public int MaxCash;
        public int MaxExp;
    }


    public class VelocityMissionSettings
    {
        public int EnterVehicleTime;
        public int PrepationTime;
        public int DriveTime;
        public int DetonationTime;
        public List<float[]> Locations = [];
        public int MinSpeed;
        public VelocityMissionRewards Rewards = new();
    }


    public class VelocityMissionRewards
    {
        public VelocityMissionReward Cash = new();
        public VelocityMissionReward Exp = new();
    }


    public class VelocityMissionReward
    {
        public int Min;
        public int Max;
        public int PerAboutToDetonate;
    }


    public class HeistMissionSettings
    {
        public int Time;
        public List<float[]> Places = [];
        public float Radius;
        public HeistTake Take = new();
    }


    public class HeistTake
    {
        public int Inverval;
        public HeistRate Rate = new();
    }

    public class HeistRate
    {
        public HeistCash Cash = new();
        public float Exp;
    }

    public class HeistCash
    {
        public int Min;
        public int Max;
        public int Limit;
    }


    public class SpecialCargoMissionSettings
    {
        public string MissionName;
        public int Time;
        public int WantedLevel;
        public EventReward RewardPerPlayer = new();
        public float DeliveryRadius;
        public List<string> Goods = [];
        public List<MissionCrate> Crates = [];
        public List<string> Vehicles = [];
        public List<CargoMissionLocation> Locations = [];
        public List<float[]> WareHouses = [];
    }


    public class CargoMissionLocation
    {
        public float[] Pos = new float[3];
        public float Heading;
        public bool Wanted;
    }


    public class MissionCrate
    {
        public string Name;
        public int Price;
        public EventReward Reward = new();
    }


    public class MissionsSettings
    {
        public int ResetTimeInterval;
        public List<float[]> Places = [];
        public EventReward FailedRewards = new();
        public EventReward FactionRewards = new();
    }


    public class AmmunationSpecialAmmoSettings
    {
        public int Ammo;
        public int Price;
        public string Type;
    }

    public class AmmunationRefillingWeaponsSettings
    {
        public List<string> Weapons = [];
        public int Ammo;
        public int Price;
    }

    public class HuntTheBeastSettings
    {
        public int Duration;
        public int Lives;
        public int TargetLandmarks;
        public List<float[]> Landmarks = [];
        public float Radius;
        public BeastRewardsSettings Rewards = new();
    }

    public class BeastRewardsSettings
    {
        public EventReward BeastLandmark = new();
        public EventReward Killer = new();
    }


    public class HotPropertySettings
    {
        public int Duration;
        public List<float[]> Places = [];
        public EventRewards Rewards = new();
    }


    public class KingOfTheCastleSettings
    {
        public int Duration;
        public List<float[]> Places = [];
        public float Radius;
        public EventRewards Rewards = new();
    }


    public class SharpShooterSettings
    {
        public int Duration;
        public EventRewards Rewards = new();
    }


    public class StockPilingSettings
    {
        public int Duration;
        public List<float[]> CheckPoints = [];
        public float Radius;
        public EventRewards Rewards = new();
    }


    public class GunSettings
    {
        public int Duration;
        public List<string> Categories = [];
        public EventRewards Rewards = new();
    }

    public class EventRewards
    {
        public List<EventReward> Top = [];
        public EventReward Point = new();
    }

    public class EventReward
    {
        public int Cash;
        public int Exp;
    }

    public class EventSettings
    {
        public int Interval;
        public int MinPlayers;
    }

    public class MarkerSettings
    {
        public float Radius;
        public int Opacity;
    }

    public class GTA2Cam
    {
        public float Min;
        public float Max;
        public float Step;
        public float MinSpeed;
        public int Key = 212; // home // INPUT_FRONTEND_SOCIAL_CLUB
    }


    public class SettingsSpawn
    {
        public List<float[]> SpawnPoints = [];
        public int DeathTime;
        public int Timeout;
        public int RespawnFasterPerControlPressed;
        public int TryCount;
        public SpawnRadius Radius = new();
    }


    public class SpawnRadius
    {
        public float Min;
        public float Max;
        public float MinDiscanceToPlayer;
    }
}
