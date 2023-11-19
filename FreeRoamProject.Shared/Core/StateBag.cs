using System;

namespace FreeRoamProject.Shared
{
    public class EntityStateBag<T>
    {
        private readonly Entity _entity;
        public string Name { get; set; }
        public bool Replicated { get; set; } = true;
        internal T _value;
        public T State
        {
            get
            {
                _value = _entity.GetState<T>(Name);
                if (_value == null) return default;
                return _value;
            }
            set
            {
                _entity.SetState(Name, value, Replicated);
                _value = value;
            }
        }

        public EntityStateBag(Entity entity, string name, bool replicated = true)
        {
            _entity = entity;
            Name = name;
            Replicated = replicated;
        }
    }

    public class PlayerStateBag<T>
    {
        private Player _player;

        public string Name { get; set; }
        public bool Replicated { get; set; } = true;
        internal T _value;
        public T State
        {
            get
            {
                _value = _player.GetState<T>(Name);
                if (_value == null) return default;
                return _value;
            }
            set
            {
                _player.SetState(Name, value, true);
                _value = value;
            }
        }

        public PlayerStateBag(Player player, string name, bool replicated = true)
        {
            _player = player;
            Name = name;
            Replicated = replicated;
        }
    }

    public class BaseBag
    {
        internal Player player;

        internal string _name;

        public BaseBag(Player pl, string name)
        {
            player = pl;
            _name = name;
        }
        public BaseBag() { }
    }

    public class PlayerStates : BaseBag
    {
        internal readonly PlayerStateBag<bool> _spawned;
        internal readonly PlayerStateBag<bool> _adminSpectating;
        internal readonly PlayerStateBag<bool> _paused;
        internal readonly PlayerStateBag<bool> _wanted;
        internal readonly PlayerStateBag<bool> _inVeh;
        internal readonly PlayerStateBag<bool> _passive;

        public bool Spawned
        {
            get => _spawned.State;
            set => _spawned.State = value;
        }
        public bool InVehicle
        {
            get => _inVeh.State;
            set => _inVeh.State = value;
        }

        public bool Wanted
        {
            get => _wanted.State;
            set => _wanted.State = value;
        }

        public bool AdminSpectating
        {
            get => _adminSpectating.State;
            set => _adminSpectating.State = value;
        }
        public bool Paused
        {
            get => _paused.State;
            set => _paused.State = value;
        }

        public bool PassiveMode
        {
            get => _passive.State;
            set => _passive.State = value;
        }
        public PlayerStates() { }

        public PlayerStates(Player player, string name) : base(player, name)
        {
            _spawned = new(player, _name + ":Spawned", true);
            _adminSpectating = new(player, _name + ":AdminSpectating", true);
            _paused = new(player, _name + ":Paused", true);
            _wanted = new(player, _name + ":WantedActive", true);
            _inVeh = new(player, _name + ":InVehicle", true);
            _passive = new(player, _name + ":PassiveMode", true);
        }
    }

    public class FreeRoamStates : BaseBag
    {
        internal readonly PlayerStateBag<int> _illuminatedClothing;

        public int IlluminatedClothing
        {
            get => _illuminatedClothing.State;
            set => _illuminatedClothing.State = value;
        }

        public FreeRoamStates()
        {
        }
        public FreeRoamStates(Player player, string name) : base(player, name)
        {
            _illuminatedClothing = new(player, _name + ":IlluminatedClothing", true);
        }
    }

    /* // kept for reference
    public class RPStates : BaseBag
    {
        internal readonly PlayerStateBag<bool> _fainted;
        internal readonly PlayerStateBag<bool> _cuffed;
        internal readonly PlayerStateBag<bool> _inHome;
        internal readonly PlayerStateBag<bool> _onDuty;
        internal readonly PlayerStateBag<bool> _dying;

        public bool Fainted
        {
            get => _fainted.State;
            set => _fainted.State = value;
        }

        public bool Cuffed
        {
            get => _cuffed.State;
            set => _cuffed.State = value;
        }

        public bool InHome
        {
            get => _inHome.State;
            set => _inHome.State = value;
        }

        public bool OnDuty
        {
            get => _onDuty.State;
            set => _onDuty.State = value;
        }

        public bool Dying
        {
            get => _dying.State;
            set => _dying.State = value;
        }

        public RPStates()
        {
        }

        public RPStates(Player player, string name) : base(player, name)
        {
            _fainted = new(player, _name + ":Fainted", true);
            _cuffed = new(player, _name + ":Cuffed", true);
            _inHome = new(player, _name + ":AtHome", true);
            _onDuty = new(player, _name + ":OnDuty", true);
            _dying = new(player, _name + ":Dying", true);
        }
    }
    */

    public class InstanceBags : BaseBag
    {
        internal readonly PlayerStateBag<InstanceBag> _instanceBag;
        public InstanceBags() { }
        public InstanceBags(Player player, string name) : base(player, name)
        {
            _instanceBag = new PlayerStateBag<InstanceBag>(player, _name);
        }

        public bool Instanced { get; set; }
        public int ServerIdOwner { get; set; }
        public bool IsOwner { get; set; }
        public string? Instance { get; set; }

        /// <summary>
        /// Istanza generica
        /// </summary>
        public void InstancePlayer()
        {
            Instanced = true;
#if CLIENT
            ServerIdOwner = Game.Player.ServerId;
#elif SERVER
            ServerIdOwner = Convert.ToInt32(player.Handle);
#endif
            IsOwner = true;
            Instance = string.Empty;
            InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
            _instanceBag.State = bag;
        }

        /// <summary>
        /// Istanza generica specificando quale Istanza
        /// </summary>
        public void InstancePlayer(string instance)
        {
            Instanced = true;
#if CLIENT
            ServerIdOwner = Game.Player.ServerId;
#elif SERVER
            ServerIdOwner = Convert.ToInt32(player.Handle);
#endif
            IsOwner = true;
            this.Instance = instance;
            InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
            _instanceBag.State = bag;
        }

        /// <summary>
        /// Istanza specifica
        /// </summary>
        public void InstancePlayer(int ServerId, string instance)
        {
            Instanced = true;
            ServerIdOwner = ServerId;
            IsOwner = true;
            this.Instance = instance;
            InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
            _instanceBag.State = bag;
        }

        /// <summary>
        /// Rimuovi da istanza
        /// </summary>
        public void RemoveInstance()
        {
            Instanced = false;
            ServerIdOwner = 0;
            IsOwner = false;
            Instance = string.Empty;
            InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
            _instanceBag.State = bag;
        }

        /// <summary>
        /// Cambia Istanza con una nuova (es. casa e garage)
        /// </summary>
        /// <param name="instance">Specifica quale istanza</param>
        public void CambiaIstanza(string instance)
        {
            if (Instanced)
            {
                if (Instance != instance)
                {
                    Instance = instance;
                    InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
                    _instanceBag.State = bag;
                }
            }
        }

        /// <summary>
        /// Cambia Proprietario dell'istanza
        /// </summary>
        /// <param name="netId">networkId del proprietario</param>
        public void CambiaIstanza(int netId)
        {
            if (Instanced)
            {
                if (ServerIdOwner != netId)
                {
                    ServerIdOwner = netId; InstanceBag bag = new InstanceBag(Instanced, ServerIdOwner, IsOwner, Instance);
                    _instanceBag.State = bag;
                }
            }

        }
    }



    public class InstanceBag
    {
        public bool Instanced { get; set; }
        public int ServerIdOwner { get; set; }
        public bool IsOwner { get; set; }
        public string? Instance { get; set; }

        public InstanceBag() { }
        public InstanceBag(bool instanced, int serverId, bool isOwner, string instance)
        {
            Instanced = instanced;
            ServerIdOwner = serverId;
            IsOwner = isOwner;
            Instance = instance;
        }
    }
}