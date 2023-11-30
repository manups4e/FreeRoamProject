using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    internal class Emails : App
    {
        private int SelectedItem { get; set; } = 0;

        public Emails(Phone phone) : base("CELL_5", IconLabels.EMAIL, phone, PhoneView.EMAIL_LIST)
        {
        }

        public override async Task TickVisual()
        {
            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
            BeginTextCommandScaleformString(Title);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);

            if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                Phone.StartApp("MAINMENU");
            }
        }
        public override async Task TickControls()
        {

        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            await Phone.RotateAnimation(PhoneAnimation.SET_HORIZONTAL);
            SetPhoneLean(true);
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
        }
        public override async void Kill()
        {
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
            await Phone.RotateAnimation(PhoneAnimation.SET_VERTICAL);
            SetPhoneLean(false);
        }
    }
}
