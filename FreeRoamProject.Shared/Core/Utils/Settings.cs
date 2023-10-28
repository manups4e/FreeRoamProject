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
        public EventReward Reward = new EventReward();
        public float Radius;
        public List<CratesWeapon> Weapons = new List<CratesWeapon>();
        public List<CrateLocations> Locations = new List<CrateLocations>();
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
        public List<float[]> Positions = new List<float[]>();
    }


    public class HeadHunterSettings
    {
        public int Time;
        public float Radius;
        public List<HeadHunterTarget> Targets = new List<HeadHunterTarget>();
        public List<string> Weapons = new List<string>();
        public int WantedLevel;
        public AssetRecoveryRewards Rewards = new AssetRecoveryRewards();
    }

    public class HeadHunterTarget
    {
        public string PedModel;
        public float[] Location = new float[3];
    }


    public class AssetRecoveryMissionSettings
    {
        public int Time;
        public List<AssetRecoveryVariant> Variants = new List<AssetRecoveryVariant>();
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
        public AssetRecoveryReward Cash = new AssetRecoveryReward();
        public AssetRecoveryReward Exp = new AssetRecoveryReward();
    }

    public class AssetRecoveryReward
    {
        public int Min;
        public int Max;
    }



    public class MostWantedSettings
    {
        public int Time;
        public MostWantedRewards Rewards = new MostWantedRewards();
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
        public List<float[]> Locations = new List<float[]>();
        public int MinSpeed;
        public VelocityMissionRewards Rewards = new VelocityMissionRewards();
    }


    public class VelocityMissionRewards
    {
        public VelocityMissionReward Cash = new VelocityMissionReward();
        public VelocityMissionReward Exp = new VelocityMissionReward();
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
        public List<float[]> Places = new List<float[]>();
        public float Radius;
        public HeistTake Take = new HeistTake();
    }


    public class HeistTake
    {
        public int Inverval;
        public HeistRate Rate = new HeistRate();
    }

    public class HeistRate
    {
        public HeistCash Cash = new HeistCash();
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
        public EventReward RewardPerPlayer = new EventReward();
        public float DeliveryRadius;
        public List<string> Goods = new List<string>();
        public List<MissionCrate> Crates = new List<MissionCrate>();
        public List<string> Vehicles = new List<string>();
        public List<CargoMissionLocation> Locations = new List<CargoMissionLocation>();
        public List<float[]> WareHouses = new List<float[]>();
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
        public EventReward Reward = new EventReward();
    }


    public class MissionsSettings
    {
        public int ResetTimeInterval;
        public List<float[]> Places = new List<float[]>();
        public EventReward FailedRewards = new EventReward();
        public EventReward FactionRewards = new EventReward();
    }


    public class AmmunationSpecialAmmoSettings
    {
        public int Ammo;
        public int Price;
        public string Type;
    }

    public class AmmunationRefillingWeaponsSettings
    {
        public List<string> Weapons = new List<string>();
        public int Ammo;
        public int Price;
    }

    public class HuntTheBeastSettings
    {
        public int Duration;
        public int Lives;
        public int TargetLandmarks;
        public List<float[]> Landmarks = new List<float[]>();
        public float Radius;
        public BeastRewardsSettings Rewards = new BeastRewardsSettings();
    }

    public class BeastRewardsSettings
    {
        public EventReward BeastLandmark = new EventReward();
        public EventReward Killer = new EventReward();
    }


    public class HotPropertySettings
    {
        public int Duration;
        public List<float[]> Places = new List<float[]>();
        public EventRewards Rewards = new EventRewards();
    }


    public class KingOfTheCastleSettings
    {
        public int Duration;
        public List<float[]> Places = new List<float[]>();
        public float Radius;
        public EventRewards Rewards = new EventRewards();
    }


    public class SharpShooterSettings
    {
        public int Duration;
        public EventRewards Rewards = new EventRewards();
    }


    public class StockPilingSettings
    {
        public int Duration;
        public List<float[]> CheckPoints = new List<float[]>();
        public float Radius;
        public EventRewards Rewards = new EventRewards();
    }


    public class GunSettings
    {
        public int Duration;
        public List<string> Categories = new List<string>();
        public EventRewards Rewards = new EventRewards();
    }

    public class EventRewards
    {
        public List<EventReward> Top = new List<EventReward>();
        public EventReward Point = new EventReward();
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
        public List<float[]> SpawnPoints = new List<float[]>();
        public int DeathTime;
        public int Timeout;
        public int RespawnFasterPerControlPressed;
        public int TryCount;
        public SpawnRadius Radius = new SpawnRadius();
    }


    public class SpawnRadius
    {
        public float Min;
        public float Max;
        public float MinDiscanceToPlayer;
    }
}
