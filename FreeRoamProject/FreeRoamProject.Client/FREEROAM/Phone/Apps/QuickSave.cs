using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class QuickSave : App
    {
        public QuickSave(Phone phone) : base("CELL_32", IconLabels.SAVE, phone, 0)
        {

        }

        private static readonly bool FirstTick = true;
        public override async Task TickControls() { }


        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            Screen.LoadingPrompt.Show(spinnerType: LoadingSpinnerType.SocialClubSaving);
            EventDispatcher.Send("tlg:Save_FreeRoamChar");
            Phone.StartApp("MAINMENU");
            await BaseScript.Delay(3000);
            Screen.LoadingPrompt.Hide();
        }

        public override void Kill()
        {
        }
    }
}
