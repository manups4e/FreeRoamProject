using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class QuickJoin : App
    {
        public QuickJoin(Phone phone) : base("CELL_37", IconLabels.MULTIPLAYER, phone, 0)
        {

        }
        public override async Task TickControls() { }


        public override async void Initialize(Phone phone)
        {
            Phone = phone;
        }

        public override void Kill()
        {
        }
    }
}
