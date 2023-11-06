global using CitizenFX.Core;
global using CitizenFX.Core.Native;
global using FreeRoamProject.Shared;
global using FxEvents;
global using FxEvents.Shared;
global using FxEvents.Shared.Snowflakes;
global using Logger;
global using static CitizenFX.Core.Native.API;
using FreeRoamProject.Server.Core;
using FreeRoamProject.Shared.Core.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Server
{
    public class ServerMain : BaseScript
    {
        public static DebugLog Logger { get; set; }
        public static ServerMain Instance { get; protected set; }
        public static ServerConfiguration Settings { get; set; }
        public ExportDictionary GetExports => Exports;
        public PlayerList GetPlayers => Players;
        public List<PlayerClient> Clients = new();
        //public static Configurazione Impostazioni { get; set; }
        public static bool Debug { get; set; }
        public Request WebRequest { get; set; }
        public StateBag ServerState => GlobalState;
        public StateBagsHandler StateBagsHandler { get; set; }

        public ServerMain()
        {
            EventDispatcher.Initalize("qIFBYn6qv7ZxbGLT7uzpFHa1wPCpmIHbDTWGJ8fy", "QNrAF12UC1qOvnhL6JEShdEdNiCyASUbbNpvyZPG", "Pi5V5nvCki0BcwppyczIfgy3ZZCJPqaYAeQsLZOs");
            Instance = this;
            Logger = new DebugLog();
#if DEBUG
            SetConvarReplicated("DEBUG", "1");
            Debug = true;
#else
			SetConvarReplicated("DEBUG", "0");
#endif
            SnowflakeGenerator.Create(new Random().NextShort(100, 200));
            SetConvarServerInfo("sv_projectName", "^2THE ^0LAST ^1GALAXY.");
            SetConvarServerInfo("sv_projectDesc", "^5A server to tame them, a server to find them, a server to seize them and in the videogame chain them!");
            SetConvarServerInfo("tags", "GTAO style, MultiMode, MultiServer");
            SetGameType("FreeRoam");
            SetMapName("The Last Galaxy");
            StartServer();
        }

        private async void StartServer()
        {
            StateBagsHandler = new StateBagsHandler();
            WebRequest = new();
            await ClassCollector.Init();
        }

        /// <summary>
        /// Mount generic event (TriggerEvent)
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="action">Action binded</param>
        public void AddEventHandler(string eventName, Delegate action)
        {
            EventHandlers[eventName] += action;
        }

        /// <summary>
        /// Unmount generic event (TriggerEvent)
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="action">Action binded</param>
        public void RemoveEventHandler(string eventName, Delegate action)
        {
            EventHandlers[eventName] -= action;
        }

        /// <summary>
        /// Calls the db to fetch anything in a dynamic result
        /// </summary>
        /// <param name="query">Query text</param>
        /// <param name="parameters">Parameters to pass</param>
        /// <returns>dynamic List if more than one or a dynamic object if only one</returns>
        public async Task<dynamic> Query(string query, object parameters = null)
        {
            return await MySQL.QueryListAsync(query, parameters);
        }

        /// <summary>
        /// Calls the db to fetch anything in a T result
        /// </summary>
        /// <param name="query">Query text</param>
        /// <param name="parameters">Parameters to pass</param>
        /// <returns>dynamic List if more than one or a dynamic object if only one</returns>
        public async Task<IEnumerable<T>> Query<T>(string query, object parameters = null)
        {
            return await MySQL.QueryListAsync<T>(query, parameters);
        }

        /// <summary>
        /// Executes a query on the db modifying its contents
        /// </summary>
        /// <param name="query">Query text</param>
        /// <param name="parameters">Parameters to pass</param>
        /// <returns></returns>
        public async Task Execute(string query, object parameters = null)
        {
            await MySQL.ExecuteAsync(query, parameters);
        }

        /// <summary>
        /// Register an OnTick function
        /// </summary>
        /// <param name="action"></param>
        public void AddTick(Func<Task> onTick)
        {
            Tick += onTick;
        }

        /// <summary>
        /// Remove the OnTick function
        /// </summary>
        /// <param name="action"></param>
        public void RemoveTick(Func<Task> onTick)
        {
            Tick -= onTick;
        }

        /// <summary>
        /// register an export, Registered GetExports still have to be defined in the __resource.lua file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void RegisterExport(string name, Delegate action)
        {
            GetExports.Add(name, action);
        }

        /// <summary>
        /// register a chat command
        /// </summary>
        /// <param name="commandName">Command name</param>
        /// <param name="handler">A new Action<int source, List<dynamic> args, string rawCommand</param>
        /// <param name="restricted">everyone or just those who can?</param>
        //public void AddCommand(string commandName, InputArgument handler, bool restricted) => API.RegisterCommand(commandName, handler, restricted);
        public void AddCommand(string commandName, Delegate handler, UserGroup restricted = UserGroup.User, ChatSuggestion suggestion = null)
        {
            //API.RegisterCommand(commandName, handler, restricted);
            ChatServer.Commands.Add(new ChatCommand(commandName, restricted, handler));

            if (suggestion != null)
            {
                suggestion.name = "/" + commandName;
                ChatServer.Suggestions.Add(suggestion);
            }
        }

    }
}
