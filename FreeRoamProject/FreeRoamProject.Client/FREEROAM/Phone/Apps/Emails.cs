using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    internal class Emails : App
    {
        private int SelectedItem { get; set; } = 0;
        private bool TextOpened = false;
        private Email CurrentEmail { get; set; }
        public Emails(Phone phone) : base("CELL_5", IconLabels.EMAIL, phone, PhoneView.EMAIL_LIST)
        {
            EventDispatcher.Mount("tlg:phone:receiveEmail", new Action<int, Email>(ReceiveEmail));
        }

        private async void ReceiveEmail(int sender, Email mail)
        {
            // do we want to set the face of the player? dunno..
            //PlayerClient clSend = ClientMain.Instance.Clients[sender];
            PlayerCache.Character.PhoneData.Emails.Add(mail);
            bool attach = !(string.IsNullOrWhiteSpace(mail.PictureTXD) || string.IsNullOrWhiteSpace(mail.PictureTXN));
            Notifications.ShowAdvancedNotification(mail.From, "", mail.TxtMessage, NotificationChar.HumanDefault, NotificationChar.HumanDefault, type: NotificationType.Bubble);
            Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, Phone.getCurrentCharPhone().Emails.Count, (int)mail.Read, attach, mail.From, mail.TxtMessage);
        }
        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                if (Phone.getCurrentCharPhone().Emails.Count == 0) return;
                CellCamMoveFinger(1);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 1);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                if (Phone.getCurrentCharPhone().Emails.Count == 0) return;
                CellCamMoveFinger(2);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 3);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                if (Phone.getCurrentCharPhone().Emails.Count == 0) return;
                if (!TextOpened)
                {
                    CellCamMoveFinger(5);
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    CurrentEmail = Phone.getCurrentCharPhone().Emails[SelectedItem];
                    if (CurrentEmail.Read == MessageState.UNREAD_EMAIL)
                    {
                        CurrentEmail.Read = MessageState.READ_EMAIL;
                        EventDispatcher.Send("tlg:phone:setEmailRead", SelectedItem);
                    }
                    CurrentView = PhoneView.EMAIL_VIEW;
                    TextOpened = true;
                    OpenEmail();
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                CellCamMoveFinger(5);
                if (TextOpened)
                {
                    CurrentView = PhoneView.EMAIL_LIST;
                    TextOpened = false;
                    OpenEmailList();
                }
                else
                {
                    Phone.StartApp("MAINMENU");
                }
                Game.PlaySound("Menu_Back", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneExtraOption))
            {
                if (Phone.getCurrentCharPhone().Emails.Count == 0) return;
                Phone.getCurrentCharPhone().Emails.RemoveAt(SelectedItem);
                EventDispatcher.Send("tlg:phone:deleteEmail", SelectedItem);
                SelectedItem--;
            }
        }

        private void OpenEmailList()
        {
            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
            BeginTextCommandScaleformString(Title);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            foreach (Email mail in Phone.getCurrentCharPhone().Emails)
            {
                int idx = Phone.getCurrentCharPhone().Emails.IndexOf(mail);
                bool attach = !(string.IsNullOrWhiteSpace(mail.PictureTXD) || string.IsNullOrWhiteSpace(mail.PictureTXN));
                Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, idx, (int)mail.Read, attach, mail.From, mail.TxtMessage);
            }
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
        }
        private async void OpenEmail()
        {
            string message = CurrentEmail.TxtMessage;
            if (!(string.IsNullOrWhiteSpace(CurrentEmail.PictureTXD) || string.IsNullOrWhiteSpace(CurrentEmail.PictureTXN)))
            {
                if (!HasStreamedTextureDictLoaded(CurrentEmail.PictureTXD))
                {
                    RequestStreamedTextureDict(CurrentEmail.PictureTXD, true);
                    int time = GetGameTimer();
                    while (!HasStreamedTextureDictLoaded(CurrentEmail.PictureTXD))
                    {
                        if (GetGameTimer() - time > 250) break;
                        await BaseScript.Delay(100);
                    }
                }
                message.Insert(0, "\n<img src='img://" + CurrentEmail.PictureTXD + "/" + CurrentEmail.PictureTXN + "' height='80' width='320'/>\n");
            }
            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt((int)CurrentView);
            ScaleformMovieMethodAddParamInt(0);
            ScaleformMovieMethodAddParamInt(1);
            BeginTextCommandScaleformString("CELL_TO_FIELD");
            AddTextComponentSubstringPlayerName(CurrentEmail.To);
            EndTextCommandScaleformString();
            BeginTextCommandScaleformString("CELL_FROM_FIELD");
            AddTextComponentSubstringPlayerName(CurrentEmail.From);
            EndTextCommandScaleformString();
            BeginTextCommandScaleformString("CELL_EMAIL_BCON");
            AddTextComponentSubstringPlayerName(CurrentEmail.TxtMessage);
            EndTextCommandScaleformString();
            BeginTextCommandScaleformString("CELL_2000");
            AddTextComponentSubstringPlayerName(CurrentEmail.From);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, 0);
        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            OpenEmailList();
            await Phone.RotateAnimation(PhoneAnimation.SET_HORIZONTAL);
            SetPhoneLean(true);
            ClientMain.Instance.AddTick(TickControls);
            Phone.SetSoftKeys(1, SoftKeys.DELETE, true, SColor.HUD_Red);
            Phone.SetSoftKeys(2, SoftKeys.BLANK, false, SColor.HUD_Freemode);
            Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
        }
        public override async void Kill()
        {
            ClientMain.Instance.RemoveTick(TickControls);
            await Phone.RotateAnimation(PhoneAnimation.SET_VERTICAL);
            SetPhoneLean(false);
        }
    }
}
