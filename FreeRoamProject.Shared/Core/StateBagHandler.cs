using FreeRoamProject.Shared.Core.Log;
using System;
using System.Linq;

#if CLIENT
using FreeRoamProject.Client;
#endif

namespace FreeRoamProject.Shared
{
    public delegate void FreeRoamStateBagChanged(int userId, string type, object value);
    public delegate void PlayerStateBagChaged(int userId, string type, bool value);
    public delegate void InstanceBagChanged(int userId, InstanceBag value);
    public delegate void EntityStateBagChaged(Entity entity, string type, bool value);
    public delegate void TimeChangedEvent(ServerTime value);
    public delegate void WeatherChangedEvent(SharedWeather value);
    public delegate void PassiveModeEvent(bool value);

    public class StateBagsHandler
    {
        public event FreeRoamStateBagChanged OnFreeRoamStateBagChange;
        public event PlayerStateBagChaged OnPlayerStateBagChange;
        public event EntityStateBagChaged OnEntityStateBagChange;
        public event InstanceBagChanged OnInstanceBagChange;
        public event TimeChangedEvent OnTimeChange;
        public event WeatherChangedEvent OnWeatherChange;
        public event PassiveModeEvent OnPassiveMode;

        //TODO: ADD FREEROAM EVENTS
        private readonly DebugLog logger = new();
        public StateBagsHandler()
        {
            AddStateBagChangeHandler("", "", new Action<string, string, dynamic, dynamic, bool>(async (bagName, key, value, _unused, replicated) =>
            {
#if CLIENT
                if (replicated) return;
#elif SERVER    
                if (!replicated) return;
#endif

                if (bagName == "global")
                {
                    if (key.ToLower().StartsWith("time"))
                    {
                        ServerTime time = (value as byte[]).FromBytes<ServerTime>();
                        OnTimeChange?.Invoke(time);
                    }
                    if (key.ToLower().StartsWith("weather"))
                    {
#if CLIENT
                        await PlayerCache.Loaded();
                        if (key.EndsWith(PlayerCache.MyPlayer.Player.State["serverID"] + ""))
                        {
                            SharedWeather meteo = (value as byte[]).FromBytes<SharedWeather>();
                            OnWeatherChange?.Invoke(meteo);
                        }
#elif SERVER
                        SharedWeather meteo = (value as byte[]).FromBytes<SharedWeather>();
                        OnWeatherChange?.Invoke(meteo);
#endif
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
                            PlayerClient player = null;
#if CLIENT
                            if (userId == Game.Player.ServerId)
                                player = PlayerCache.MyPlayer;
                            else
                                player = ClientMain.Instance.Clients.FirstOrDefault(x => x.Handle == userId);
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
                                case "FreeRoamStates":
                                    {
                                        switch (state)
                                        {
                                            case "IlluminatedClothing":
                                                {
                                                    int res = (value as byte[]).FromBytes<int>();
                                                    OnFreeRoamStateBagChange?.Invoke(userId, state, res);
                                                }
                                                break;
                                        }
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
            OnInstanceBagChange += (a, b) => logger.Debug($"OnInstanceBagChange => PlayerId:{a}, Data:{b.ToJson()}");
            OnFreeRoamStateBagChange += (a, b, c) => logger.Debug($"OnFreeRoamStateBagChange => PlayerId:{a}, State:{b}, Value:{c}");
            //OnTimeChange += (a) => logger.Debug($"OnTimeChange => {a.ToJson()}");
            //OnWeatherChange += (a) => logger.Debug($"OnWeatherChange => {a.ToJson()}");
        }
    }
}
