using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class JobList : App
    {
        public JobList(Phone phone) : base("CELL_29", IconLabels.SIDE_TASKS, phone, 0)
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
