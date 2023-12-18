using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class Securoserv : App
    {
        public Securoserv(Phone phone) : base("CELL_BOSSAGE", IconLabels.GANG, phone, 0)
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
