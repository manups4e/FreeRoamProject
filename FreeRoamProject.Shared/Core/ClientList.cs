using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
#if SERVER
using FreeRoamProject.Server.Core.Buckets;
using FreeRoamProject.Server;
#endif

namespace FreeRoamProject.Shared
{
    // TODO: WORK IN PROGRESS.. NOT WORKING YET BUT I WANT THIS TO BE BUCKETS COMPATIBLE
    public interface IClientList : IEnumerable<PlayerClient>
    {
        void RequestPlayerList();

        void ReceivedPlayerList(IList<object> players);

        Task WaitRequested();
    }

    public class ClientList : IClientList
    {
        private List<PlayerClient> clientList;
        private bool updating = false;
        public ClientList()
        {
            RequestPlayerList();
        }

        public IEnumerator<PlayerClient> GetEnumerator()
        {
            /*
            if (clientList == null)
            {
#if CLIENT
                RequestPlayerList(PlayerCache.ModalitàAttuale);
#elif SERVER
                RequestPlayerList(ModalitaServerMain.UNKNOWN);
#endif
            }
            */

            foreach (PlayerClient player in clientList)
            {
                yield return player;
            }
        }

        public async void RequestPlayerList()
        {
            updating = true;
#if CLIENT
            clientList = await EventDispatcher.Get<List<PlayerClient>>("tlg:getClients");
#elif SERVER
            // TODO: REPLACE WITH THE PLAYERS IN THE CURRENT BUCKET AND THAT'S ALL..
            // USELESS TO KNOW PLAYERS IN OTHER BUCKETS.. UNLESS THEY'RE FRIENDS (BUT THAT CAN BE EASILY CHECKED IN OTHER WAYS)
            clientList = ServerMain.Instance.Clients;
#endif
            updating = false;
        }

        public void ReceivedPlayerList(IList<object> players)
        {

        }
        public async Task WaitRequested()
        {
            if (updating) while (updating) await BaseScript.Delay(0);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (PlayerClient player in clientList)
            {
                yield return player;
            }
        }

        public void Add(PlayerClient pl)
        {
            clientList.Add(pl);
        }

    }
}
