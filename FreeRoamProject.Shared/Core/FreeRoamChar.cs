using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;


namespace FreeRoamProject.Shared
{
    public enum PlayerStats : int
    {
        NumberNearMisses = -1058879197,
        NumberNearMissesNoCrash = -791767133,
        FastestSpeedInCar = -2133168010,
        MostPistolHeadshots = -252472232,
        LONGEST_2WHEEL_DIST = 1061163284,
        LONGEST_2WHEEL_TIME = 1575087458,
        LongestSurvivedFreefall = 742230262,
        HighestSkittles = -1411284426,
        FarthestJumpDistance = 908833912,
        HighestJumpDistance = 1831206202,
        FlyUnderBridges = -1169860382,
        MostFlipsInOneJump = 1172390698,
        MostSpinsInOneJump = -370868036,
    }



    public enum PlayerStatType
    {
        Int,
        Float,
        String,
        CustomInt,
        CustomFloat
    }


    public class FreeRoamChar
    {
        public ulong CharID { get; set; }
        public bool is_dead { get; set; }
        public Finance Finance { get; set; }
        public Position Position { get; set; }
        public Gang Gang { get; set; }
        public Skin Skin { get; set; }
        public List<Weapons> Weapons { get; set; }
        //TODO: SAVE ALSO PROPERTY PREFERENCES, MAKE A CLASS FOR IT
        public List<string?> Properties { get; set; }
        public List<OwnedVehicle> Vehicles { get; set; }
        public PhoneData PhoneData { get; set; }
        public Dressing Dressing { get; set; }
        public FreeRoamStats Statistics { get; set; }
        public GameStats Stats { get; set; }
        public int Level { get; set; } = 1;
        public int TotalXp { get; set; }

        public FreeRoamChar()
        { }

        public FreeRoamChar(ulong id)
        {
            CharID = id;
            Finance = new();
            Gang = new();
            Skin = new();
            PhoneData = new PhoneData();
            Dressing = new();
            Properties = new(); // to be added
            Vehicles = new(); // to be added
            Weapons = new();
            Statistics = new();
            Stats = new();
        }

        public FreeRoamChar(ulong id, Finance finance, Gang gang, Skin skin, Dressing dressing, FreeRoamStats statistiche, GameStats savedStates)
        {
            CharID = id;
            Finance = finance;
            Gang = gang;
            Skin = skin;
            Dressing = dressing;
            Weapons = new List<Weapons>();
            Properties = new List<string?>();
            Vehicles = new List<OwnedVehicle>();
            Statistics = statistiche;
            Stats = savedStates;
        }
    }


    public class FreeRoamStats
    {
        public float STAMINA { get; set; } = 0;
        public float STRENGTH { get; set; } = 0;
        public float LUNG_CAPACITY { get; set; } = 0;
        public float SHOOTING_ABILITY { get; set; } = 0;
        public float WHEELIE_ABILITY { get; set; } = 0;
        public float FLYING_ABILITY { get; set; } = 0;
        public float STEALTH_ABILITY { get; set; } = 0;
        public int Experience { get; set; } = 0;
        public int Prestige { get; set; } = 0;
        public int Kills { get; set; } = 0;
        public int Deaths { get; set; } = 0;
        public int Headshots { get; set; } = 0;
        public int MaxKillStreak { get; set; } = 0;
        public int MissionsDone { get; set; } = 0;
        public int EventsWon { get; set; } = 0;
        // to add madness like in gta:o?
        //TODO: IDEA, TO ADD KILLER CONTRACTS LIKE GTA:O
    }

    public class GameStats()
    {
        public int CurrentHoodSetting { get; set; }
        public int IlluminatedClothing { get; set; }
        public int VisorUpDown { get; set; }
        public int[] SavedHelmet { get; set; } = [16, 0];
        public int AutoShowHelmet { get; set; }
        public int AutoShowAircraft { get; set; }
        public int SavedAction { get; set; }
        public int SavedMood { get; set; } = 4;
        public int SavedWalkStyle { get; set; }
        public int SavedGlowIndex { get; set; }
        public int SavedHood { get; set; }
    }

    public class Helmet
    {
        public int Drawable { get; set; }
        public int Texture { get; set; }
    }


    public class PlayerScore
    {
        public int EventId { get; set; }
        public float EventXpMultiplier { get; set; } = 1.0f;
        public float CurrentAttempt { get; set; }
        public float BestAttempt { get; set; }
    }

    // old classes for old binary serialization
    public class FreeRoamChar_Metadata
    {
        public int money;/*{ set => Finance.Money = value; }*/
        public int bank;/*{ set => Finance.Bank = value; }*/
        public string location;/*{ set => Posizione = value.FromJson<Position>(); }*/
        public string gang;/*{ set => Gang.Name = value; }*/
        public int gang_grade;/*{ set => Gang.Grade = value; }*/
        public string skin;/*{ set => Skin = value.FromJson<Skin>(); }*/
        public string weapons;/*{ set => Weapons = value.FromJson<List<Weapons>>(); }*/
        public string dressing;/*{ set => Dressing = value.FromJson<Dressing>(); }*/
        public string statistiche;/*{ set => Statistiche = value.FromJson<Statistiche>(); }*/
        public int level;
        public int totalXp;
    }
}
