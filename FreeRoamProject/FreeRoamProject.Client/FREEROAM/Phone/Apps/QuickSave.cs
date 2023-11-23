using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class QuickSave : App
    {
        public QuickSave(Phone phone) : base(Game.GetGXTEntry("CELL_32"), 43, phone)
        {

        }

        private static bool FirstTick = true;
        public override async Task Tick()
        {
            if (FirstTick)
            {
                FirstTick = false;
                await BaseScript.Delay(100);
                return;
            }
        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            Screen.LoadingPrompt.Show(spinnerType: LoadingSpinnerType.SocialClubSaving);
            EventDispatcher.Send("tlg:Save_FreeRoamChar");
            PhoneMainClient.StartApp("Main");
            await BaseScript.Delay(3000);
            Screen.LoadingPrompt.Hide();
        }

        public override void Kill()
        {
        }
    }
}
