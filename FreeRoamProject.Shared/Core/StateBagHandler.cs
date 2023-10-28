using System;

namespace FreeRoamProject.Shared
{
    public delegate void RoleplayStateBagChaged(int userId, string type, bool value);
    public delegate void PlayerStateBagChaged(int userId, string type, bool value);
    public delegate void InstanceBagChanged(int userId, InstanceBag value);
    public delegate void EntityStateBagChaged(Entity entity, string type, bool value);
    public delegate void TimeChangedEvent(ServerTime value);
    public delegate void WeatherChangedEvent(SharedWeather value);
    public delegate void PassiveModeEvent(bool value);

    public class StateBagsHandler
    {
        public event RoleplayStateBagChaged OnRoleplayStateBagChange;
        public event PlayerStateBagChaged OnPlayerStateBagChange;
        public event EntityStateBagChaged OnEntityStateBagChange;
        public event InstanceBagChanged OnInstanceBagChange;
        public event TimeChangedEvent OnTimeChange;
        public event WeatherChangedEvent OnWeatherChange;
        public event PassiveModeEvent OnPassiveMode;

        private readonly Logger.Log logger = new();
        public StateBagsHandler()
        {
            AddStateBagChangeHandler("", "", new Action<string, string, dynamic, dynamic, bool>((bagName, key, value, _unused, replicated) =>
            {
#if CLIENT
                if (replicated) return;
#elif SERVER    
                if (!replicated) return;
#endif

                if (bagName == "global")
                {
                    //logger.Warning($"{bagName}, {key}, {value}, {_unused}, {replicated}");
                    switch (key.ToLower())
                    {
                        case "orario":
                            ServerTime time = (value as byte[]).FromBytes<ServerTime>();
                            OnTimeChange?.Invoke(time);
                            break;
                        case "meteo":
                            SharedWeather meteo = (value as byte[]).FromBytes<SharedWeather>();
                            OnWeatherChange?.Invoke(meteo);
                            break;
                    }
                }
                else
                {
                    string entType = bagName.Substring(0, bagName.IndexOf(':'));
                    int userId = Convert.ToInt32(bagName.Substring(bagName.IndexOf(':') + 1));

                    //logger.Warning($"{bagName}, {key}, {value}, {_unused}, {replicated}");
                    switch (entType)
                    {
                        case "player":
                            PlayerClient player;
#if CLIENT
                            if (userId == Game.Player.ServerId)
                                player = PlayerCache.MyPlayer;
#elif SERVER
                            //player = ServerMain.Instance.Clients[userId];
#endif
                            string modeType = key.Contains(":") ? key.Substring(0, key.IndexOf(':')) : key;
                            string state = key.Substring(key.IndexOf(':') + 1);
                            switch (modeType)
                            {
                                case "PlayerStates":
                                    switch (state)
                                    {
                                        case "PassiveMode":
                                            {
                                                bool res = (value as byte[]).FromBytes<bool>();
                                                OnPlayerStateBagChange?.Invoke(userId, state, res);
                                            }
                                            break;
                                        case "Paused":
                                        case "InVehicle":
                                        case "Spawned":
                                            {
                                                bool res = (value as byte[]).FromBytes<bool>();
                                                OnPlayerStateBagChange?.Invoke(userId, state, res);
                                            }
                                            break;
                                    }
                                    break;
                                case "RolePlayStates":
                                    switch (state)
                                    {
                                        case "Fainted":
                                        case "Cuffed":
                                        case "AtHome":
                                        case "OnDuty":
                                        case "Dying":
                                        case "InVehicle":
                                            bool res = (value as byte[]).FromBytes<bool>();
                                            OnRoleplayStateBagChange?.Invoke(userId, state, res);
                                            break;
                                    }
                                    break;
                                case "PlayerInstance":
                                    {
                                        InstanceBag inst = (value as byte[]).FromBytes<InstanceBag>();
                                        OnInstanceBagChange?.Invoke(userId, inst);
                                        break;
                                    }
                            }
                            break;
                        case "entity":
                            break;
                    }
                }
            }));

            OnPlayerStateBagChange += (a, b, c) => logger.Debug($"OnPlayerStateBagChange => PlayerId:{a}, State:{b}, Value:{c}");

            OnRoleplayStateBagChange += (a, b, c) => logger.Debug($"OnRoleplayStateBagChange => PlayerId:{a}, State:{b}, Value:{c}");

            OnInstanceBagChange += (a, b) => logger.Debug($"OnInstanceBagChange => PlayerId:{a}, Data:{b.ToJson()}");
        }
    }
}
