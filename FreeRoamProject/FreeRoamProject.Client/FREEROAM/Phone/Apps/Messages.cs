using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class Messages : App
    {
        private int SelectedItem { get; set; } = 0;
        private static bool FirstTick = true;
        private Phone phone;
        private int messageCount = 0;
        private bool TextOpened = false;
        public Messages(Phone phone) : base(Game.GetGXTEntry("CELL_1"), IconLabels.TEXT_MESSAGE, phone, PhoneView.TEXT_MESSAGE_LIST)   // 8
        {
            ClientMain.Instance.AddEventHandler("tlg:receiveMessage", new Action<int, Message>(ReceiveText));
            this.phone = phone;

        }

        private async void ReceiveText(int sender, Message msg)
        {
            PlayerClient clSend = ClientMain.Instance.Clients[sender];
            Tuple<int, string> mugshot = await Functions.GetPedMugshotAsync(clSend.Ped);
            Notifications.ShowAdvancedNotification("", msg.From, msg.TxtMessage, mugshot.Item2, mugshot.Item2, type: NotificationType.Bubble);
            AddMessage(messageCount, msg.TxtMessage, msg.From, false);
            messageCount += 1;
        }

        private async void AddMessage(int index, string sender, string messageTopic, bool sending)
        {
            phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, index, sending ? 4 : 0, 0, messageTopic, sender);
            /*
			PushScaleformMovieFunction(phone.Scaleform.Handle, "SET_DATA_SLOT");
			PushScaleformMovieFunctionParameterInt(8);
			PushScaleformMovieFunctionParameterInt(index);
			if (sending)
				PushScaleformMovieFunctionParameterInt(4);
			else
				PushScaleformMovieFunctionParameterInt(0);
			PushScaleformMovieFunctionParameterInt(0);
			BeginTextCommandScaleformString("CELL_2000");
			AddTextComponentSubstringPlayerName("~l~" + messageTopic);
			EndTextComponent();
			BeginTextCommandScaleformString("CELL_EMAIL_SUBJ");
			AddTextComponentSubstringPlayerName("~l~" + sender);
			EndTextComponent();
			PopScaleformMovieFunctionVoid();
			*/
        }

        public override async Task TickVisual()
        {
            if (FirstTick)
            {
                FirstTick = false;
                await BaseScript.Delay(100);
                return;
            }

            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            Phone.Scaleform.CallFunction("SET_HEADER", Title);

            string appName = "Messaggi";

            foreach (Message messaggio in Phone.getCurrentCharPhone().Messages)
            {
                AddMessage(Phone.getCurrentCharPhone().Messages.IndexOf(messaggio), messaggio.From, messaggio.TxtMessage, false);
                messageCount += 1;
            }
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
        }
        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                MoveFinger(1);
                if (SelectedItem > 0)
                    SelectedItem -= 1;
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                MoveFinger(2);
                if (SelectedItem < Phone.getCurrentCharPhone().Messages.Count - 1)
                    SelectedItem += 1;
                else
                    SelectedItem = 0;
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                MoveFinger(5);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                MoveFinger(5);
                if (TextOpened)
                {

                }
                else
                {
                    Phone.StartApp("MAINMENU");
                }
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
        }
        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            FirstTick = true;
            SelectedItem = 0;
            //await Phone.RotateAnimation(PhoneAnimation.SET_HORIZONTAL);
            //SetPhoneLean(true);
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
        }

        public override async void Kill()
        {
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
            /*
            Phone = phone;
            await Phone.RotateAnimation(PhoneAnimation.SET_VERTICAL);
            SetPhoneLean(false);
            */
        }

    }
}
