using FreeRoamProject.Shared.PlayerChar;
using FxEvents.Shared.EventSubsystem;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

#if CLIENT
using FreeRoamProject.Client.Core.PlayerChar;
#elif SERVER
using FreeRoamProject.Server.Core;
using FreeRoamProject.Server.Core.PlayerChar;
using FreeRoamProject.Server;
#endif

namespace FreeRoamProject.Shared
{

    public class PlayerClient : ISource
    {
        public Snowflake Id { get; set; }
        public int Handle { get; set; }
        public User User { get; set; }
        public Identifiers Identifiers => User.Identifiers;

        internal Status Status { get; set; }

        public PlayerClient()
        {
        }

        public override string ToString()
        {
            return $"{(Id != Snowflake.Empty ? Id.ToString() : Handle.ToString())} ({Player.Name})";
        }


        public bool Compare(Identifiers identifier)
        {
            return Identifiers == identifier;
        }

        public static explicit operator PlayerClient(string netId)
        {
            if (int.TryParse(netId.Replace("net:", string.Empty), out int handle))
            {
                return new PlayerClient(handle);
            }

            throw new Exception($"Could not parse net id: {netId}");
        }

        public bool Compare(PlayerClient client)
        {
            return client.Handle == Handle;
        }

#if CLIENT

        private Ped _ped;
        private Player _player;
        [JsonIgnore]
        internal Position Position { get; set; }

        [JsonIgnore]
        internal bool Ready => User != null;

        [JsonIgnore]
        internal Player Player
        {
            get
            {
                int handle = GetPlayerFromServerId(Handle);
                if (_player is null || _player.Handle != handle)
                    _player = new Player(handle);
                return _player;

            }
        }

        [JsonIgnore]
        internal Ped Ped
        {
            get
            {
                int handle = GetPlayerPed(GetPlayerFromServerId(Handle));
                if (_ped is null || _ped.Handle != handle)
                    _ped = new Ped(handle);
                return _ped;
            }
        }

        public PlayerClient(Tuple<Snowflake, BasePlayerShared> value)
        {
            Id = value.Item1;
            Handle = Game.Player.ServerId;
            User = new(value.Item2);
            Status = new(Player);
            Status.Clear();
        }

        public PlayerClient(Snowflake id)
        {
            Player owner = Game.Player;
            if (owner != null)
            {
                Id = id;
                Handle = owner.ServerId;
                LoadUser();
                Status = new(Player);
            }
            else
            {
                throw new Exception($"Could not find runtime client: {id}");
            }
        }

        public PlayerClient(int handle)
        {
            Handle = handle;
            Status = new(Player);
            //LoadUser();
        }

        // TODO: THIS IS USED TO LOAD USER DATA ON THE GO..
        // TO BE USED ONLY WHEN NECESSARY.. FOR EVERYTHING ELSE THERE'S THE STATEBAGS
        // AND NATIVES SINCE WE ARE ALL AWARE..
        public async Task LoadUserAsync()
        {
            BasePlayerShared bps = await EventDispatcher.Get<BasePlayerShared>("tlg:GetUserFromServerId", Handle);
            User = new User(bps);
            Id = User != null ? User.PlayerID : Snowflake.Empty;
        }


        public async void LoadUser()
        {
            BasePlayerShared bps = await EventDispatcher.Get<BasePlayerShared>("tlg:GetUserFromServerId", Handle);
            User = new User(bps);
            Id = User != null ? User.PlayerID : Snowflake.Empty;
        }

#elif SERVER

        [JsonIgnore]
        internal Player Player { get => Server.ServerMain.Instance.GetPlayers[Handle]; }


        [JsonIgnore]
        internal Ped Ped { get => Player.Character; }

        public static readonly PlayerClient Global = new(-1);

        public PlayerClient(Snowflake id)
        {
            Player owner = Server.ServerMain.Instance.GetPlayers.FirstOrDefault(x => x.Handle == Handle.ToString());
            if (owner != null)
            {
                Id = id;
                Handle = Convert.ToInt32(owner.Handle);
                User = Server.ServerMain.Instance.Clients.FirstOrDefault(x => x.Handle == Handle)?.User;
                Status = new(Player);
                //ClientStateBags = new(Player);
            }
            else
            {
                throw new Exception($"Could not find runtime client: {id}");
            }
        }
        public PlayerClient(int handle)
        {
            Handle = handle;
            User = Server.ServerMain.Instance.Clients.FirstOrDefault(x => x.Handle == Handle)?.User;
            Id = User != null ? User.PlayerID : Snowflake.Empty;
            Status = new(Player);
        }

        public PlayerClient(User user)
        {
            Handle = Convert.ToInt32(user.Player.Handle);
            User = user;
            Id = user.PlayerID;
            Status = new(Player);
        }

        public bool Compare(Player player)
        {
            return Compare(player.GetCurrentChar().Identifiers);
        }
#endif
        public static explicit operator PlayerClient(int handle) => new(handle);
    }

    public class Status
    {
        public PlayerStates PlayerStates { get; set; }
        public InstanceBags Instance { get; set; }
        public FreeRoamStates FreeRoamStates { get; set; }

        public Status(Player player)
        {
            PlayerStates = new(player, "PlayerStates");
            FreeRoamStates = new(player, "FreeRoamStates");
            Instance = new(player, "PlayerInstance");
        }

        public void Clear()
        {
            PlayerStates.Spawned = false;
            PlayerStates.InVehicle = false;
            PlayerStates.Paused = false;
            PlayerStates.AdminSpectating = false;
            PlayerStates.Wanted = false;
            FreeRoamStates.IlluminatedClothing = 0;
            Instance.RemoveInstance();
        }

        public void LoadFromChar(PlayerClient client)
        {
            FreeRoamStates.IlluminatedClothing = client.User.Character.Stats.IlluminatedClothing;
        }

        public void SaveToChar(PlayerClient client)
        {
            client.User.Character.Stats.IlluminatedClothing = FreeRoamStates.IlluminatedClothing;
        }
    }
}