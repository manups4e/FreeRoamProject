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
        private bool MessaggioAperto = false;
        public Messages(Phone phone) : base(Game.GetGXTEntry("CELL_1"), 2, phone)   // 8
        {
            ClientMain.Instance.AddEventHandler("tlg:riceviMessaggio", new Action<int, string>(RiceviMessaggio));
            this.phone = phone;

        }

        private async void RiceviMessaggio(int sender, string messaggio)
        {
            Tuple<int, string> mugshot = await Functions.GetPedMugshotAsync(ClientMain.Instance.Clients[sender].Ped);
            //Notifications.ShowAdvancedNotification("Messaggio Privato", Functions.GetPlayerCharFromPlayerId(sender).FullName, messaggio, mugshot.Item2);
            AddMessage(messageCount, messaggio, ClientMain.Instance.Clients[sender].Player.Name, false);
            messageCount += 1;
        }

        private async void AddMessage(int index, string sender, string messageTopic, bool sending)
        {
            phone.Scaleform.CallFunction("SET_DATA_SLOT", 8, index, sending ? 4 : 0, 0, messageTopic, sender);
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

        public override async Task Tick()
        {
            if (FirstTick)
            {
                FirstTick = false;
                await BaseScript.Delay(100);
                return;
            }

            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", 8);

            string appName = "Messaggi";

            foreach (Message messaggio in Phone.getCurrentCharPhone().Messages)
            {
                AddMessage(Phone.getCurrentCharPhone().Messages.IndexOf(messaggio), messaggio.From, messaggio.TxtMessage, false);
                messageCount += 1;
            }
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", 8, SelectedItem);

            bool navigated = true;
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                MoveFinger(1);
                if (SelectedItem > 0)
                    SelectedItem -= 1;
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                MoveFinger(2);
                if (SelectedItem < Phone.getCurrentCharPhone().Messages.Count - 1)
                    SelectedItem += 1;
                else
                    SelectedItem = 0;
            }
            else if (Input.IsControlJustPressed(Control.FrontendAccept))
                MoveFinger(5);
            else if (Input.IsControlJustPressed(Control.FrontendCancel))
            {
                MoveFinger(5);
                if (MessaggioAperto)
                {

                }
                else
                {
                    navigated = false;
                    PhoneMainClient.StartApp("Main");
                }
            }
            else
                navigated = false;
            if (navigated)
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            await Task.FromResult(0);
        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            FirstTick = true;
            SelectedItem = 0;
            Vector3 pos = Phone.Position2;
            pos.X -= 10f;
            pos.Y += 20f;
            await Phone.RotateAnimation(Phone.Position1, pos, new Vector3(-90f, 0f, 90f), new Vector3(-90f, 0f, 90f), 450f, true);
            //SetPhoneLean(false); used for camera
        }

        public override async void Kill()
        {
            Phone = phone;
            Vector3 pos = Phone.Position2;
            pos.X -= 10f;
            pos.Y += 20f;
            await Phone.RotateAnimation(pos, Phone.Position2, new Vector3(-90f, 0f, 0f), new Vector3(-90f, 0f, 0f), 450f, true);
        }

    }
}
