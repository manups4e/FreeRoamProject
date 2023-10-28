using FreeRoamProject.Server.Properties;
using Settings.Server.Configurazione.Main;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Server
{
    static class ConfigServer
    {
        public static List<SharedWeapon> Weapons = new List<SharedWeapon>();
        public static async Task Init()
        {
            ServerMain.Settings = Resources.ServerConfig.FromJson<ServerConfiguration>();
            ConfigShared.SharedConfig = Resources.SharedConfig.FromJson<SharedConfig>();
            Weapons = Resources.Weapons.FromJson<List<SharedWeapon>>();
            EventDispatcher.Mount("Config.CallClientConfig", new Func<PlayerClient, Task<string>>(ClientConfigCallback));
            EventDispatcher.Mount("Config.CallSharedConfig", new Func<PlayerClient, Task<string>>(ClientSharedCallback));
            EventDispatcher.Mount("tlg:getWeaponsConfig", new Func<Task<List<SharedWeapon>>>(GiveWeaponsToClient));

            await Task.FromResult(0);
        }

        private static async Task<List<SharedWeapon>> GiveWeaponsToClient()
        {
            return Weapons;
        }

        private static async Task<string> ClientSharedCallback([FromSource] PlayerClient client)
        {
            return null;
        }
        private static async Task<string> ClientConfigCallback([FromSource] PlayerClient client)
        {
            return Resources.Client_FreeRoam;
        }

    }

    public class ServerConfiguration
    {
        public MainConfig Main = new();
        public ConfigQueue Queue = new();
    }
}