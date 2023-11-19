using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if SERVER
using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server;
#endif

namespace FreeRoamProject.Shared
{
    // TODO: WORK IN PROGRESS.. NOT WORKING YET BUT I WANT THIS TO BE BUCKETS COMPATIBLE
    public class ClientList : IEnumerable<PlayerClient>
    {
        public IEnumerator<PlayerClient> GetEnumerator()
        {
#if CLIENT
            IList<object> list = (IList<object>)(object)API.GetActivePlayers();
            foreach (object p in list)
            {
                yield return new PlayerClient(API.GetPlayerServerId(Convert.ToInt32(p)));
            }
#elif SERVER
            int numIndices = GetNumPlayerIndices();

            for (int i = 0; i < numIndices; i++)
            {
                yield return new PlayerClient(int.Parse(GetPlayerFromIndex(i)));
            }
#endif
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PlayerClient this[int netId] => this.FirstOrDefault(player => player.Handle == netId);

        public PlayerClient this[string name] => this.FirstOrDefault(player => player.Player.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }
}
