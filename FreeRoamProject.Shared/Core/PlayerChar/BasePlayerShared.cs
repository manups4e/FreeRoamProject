using System.Collections.Generic;
using Newtonsoft.Json;

#if CLIENT
using FreeRoamProject.Client.Core.PlayerChar;
#elif SERVER
using FreeRoamProject.Server.Core;
using FreeRoamProject.Server.Core.PlayerChar;
#endif

namespace FreeRoamProject.Shared.PlayerChar
{

    public class BasePlayerShared
    {
        public int ID { get; set; }

        [JsonIgnore]
        private ulong UserID
        {
            set => PlayerID = Snowflake.Parse(value);
        }

        public string? Name { get; set; }
        public Snowflake PlayerID { get; set; }
        public string? group { get; set; }
        public UserGroup group_level { get; set; }
        public long playTime { get; set; }

        [JsonIgnore] internal Player Player;
        public Identifiers Identifiers { get; set; }

        private FreeRoamChar character;
        public FreeRoamChar Character
        {
            get => character;
            set => character = value;

        }
        public List<PlayerScore> PlayerScores { get; set; } = new();
        public BasePlayerShared() { }
    }


    public class Identifiers
    {
        public string? Steam { get; set; }
        public string? License { get; set; }
        public string? Discord { get; set; }
        public string? Fivem { get; set; }
        public string? Ip { get; set; }

        public string?[] ToArray() => new string?[] { Steam, Discord, License, Fivem, Ip };
    }
}