﻿using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class Messages : App
    {
        private int SelectedItem { get; set; } = 0;
        private static bool FirstTick = true;
        private int messageCount = 0;
        private bool TextOpened = false;
        private Message CurrentText;
        public Messages(Phone phone) : base("CELL_1", IconLabels.TEXT_MESSAGE, phone, PhoneView.TEXT_MESSAGE_LIST)   // 8
        {
            EventDispatcher.Mount("tlg:phone:receiveTextMessage", new Action<int, Message>(ReceiveText));
        }

        private async void ReceiveText(int sender, Message msg)
        {
            // do we want to set the face of the player? dunno..
            //PlayerClient clSend = ClientMain.Instance.Clients[sender];
            PlayerCache.Character.PhoneData.Messages.Add(msg);
            Notifications.ShowAdvancedNotification(msg.From, "", msg.TxtMessage, NotificationChar.HumanDefault, NotificationChar.HumanDefault, type: NotificationType.Bubble);
            AddMessage(messageCount, msg, false);
            messageCount += 1;
        }

        private async void AddMessage(int index, Message msg, bool sending)
        {
            /*
            string fromto = sending
                ? Game.GetGXTEntry("CELL_TO_FIELD").Replace("~a~", "<C>" + msg.From + "</C>")
                : Game.GetGXTEntry("CELL_FROM_FIELD").Replace("~a~", "<C>" + msg.From + "</C>");
            */
            Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, index, msg.Date.Hour, msg.Date.Minute, (int)msg.Read, msg.From, msg.TxtMessage);
        }

        public void UpdateVisual()
        {
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
            BeginTextCommandScaleformString(Title);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();

            if (!TextOpened)
            {
                foreach (Message messaggio in Phone.getCurrentCharPhone().Messages)
                {
                    AddMessage(Phone.getCurrentCharPhone().Messages.IndexOf(messaggio), messaggio, false);
                    messageCount += 1;
                }
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
            }
            else
            {
                Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, 0, CurrentText.From, CurrentText.TxtMessage, NotificationChar.HumanDefault);
                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, 0);
            }

        }

        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                if (Phone.getCurrentCharPhone().Messages.Count == 0) return;
                CellCamMoveFinger(1);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 1);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                if (!TextOpened)
                    Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
                else
                    Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, 0);
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                if (Phone.getCurrentCharPhone().Messages.Count == 0) return;
                CellCamMoveFinger(2);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 3);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                if (!TextOpened)
                    Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
                else
                    Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, 0);

            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                if (Phone.getCurrentCharPhone().Messages.Count == 0) return;
                if (!TextOpened)
                {
                    MoveFinger(5);
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    CurrentText = Phone.getCurrentCharPhone().Messages[SelectedItem];
                    if (CurrentText.Read == MessageState.UNREAD_SMS)
                    {
                        CurrentText.Read = MessageState.READ_SMS;
                        EventDispatcher.Send("tlg:phone:setTextMessageRead", SelectedItem);
                    }
                    CurrentView = PhoneView.TEXT_MESSAGE_VIEW;
                    TextOpened = true;
                    if (ClientMain.Instance.Clients[CurrentText.From] != null)
                        Phone.SetSoftKeys(1, SoftKeys.REPLY, true, SColor.HUD_Freemode);
                    else
                        Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.HUD_Freemode);
                    Phone.SetSoftKeys(2, SoftKeys.BLANK, false, SColor.HUD_Freemode);
                    Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
                    UpdateVisual();
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                MoveFinger(5);
                if (TextOpened)
                {
                    CurrentView = PhoneView.TEXT_MESSAGE_LIST;
                    TextOpened = false;
                    Phone.SetSoftKeys(1, SoftKeys.DELETE, true, SColor.HUD_Red);
                    Phone.SetSoftKeys(2, SoftKeys.SELECT, true, SColor.HUD_Freemode);
                    Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
                    UpdateVisual();
                }
                else
                {
                    Phone.StartApp("MAINMENU");
                }
                Game.PlaySound("Menu_Back", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneExtraOption))
            {
                if (Phone.getCurrentCharPhone().Messages.Count == 0) return;
                if (TextOpened)
                {
                    if (ClientMain.Instance.Clients[CurrentText.From] != null)
                    {
                        PlayerClient client = ClientMain.Instance.Clients[CurrentText.From];
                        string title = "FMMC_KEY_TIP8";
                        int max = 60;
                        if (Game.Language == Language.Russian || Game.Language == Language.Chinese || Game.Language == Language.Korean || Game.Language == Language.Japanese || Game.Language == (Language)12)
                        {
                            title = "FMMC_KEY_TIP8S";
                            max = 20;
                        }
                        string text = (await Functions.GetUserInput(Game.GetGXTEntry(title), "", max)).Trim();
                        Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.Clockwise1, GetLabelText("ERROR_CHECKPROFANITY"));
                        await BaseScript.Delay(100);
                        ProfanityCheck profanityRes = await Functions.CheckStringHasProfanity(text);
                        await BaseScript.Delay(100);
                        Main.InstructionalButtons.HideSavingText();
                        if (profanityRes == ProfanityCheck.SAFE)
                        {
                            EventDispatcher.Send("tlg:phone:sendTextToPlayer", client.Handle, text);
                            Notifications.ShowNotification(Game.GetGXTEntry("CP_TM_SENT").Replace("~a~", $"<C>{client.Player.Name}</C>"));
                        }
                        else
                        {
                            Notifications.ShowHelpNotification(Game.GetGXTEntry("ERROR_FAILEDPROFANITY"), 5000);
                        }
                    }
                }
                else
                {
                    Phone.getCurrentCharPhone().Messages.RemoveAt(SelectedItem);
                    EventDispatcher.Send("tlg:phone:deleteTextMessage", SelectedItem);
                    SelectedItem--;
                }
            }
        }
        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            FirstTick = true;
            SelectedItem = 0;
            UpdateVisual();
            //await Phone.RotateAnimation(PhoneAnimation.SET_HORIZONTAL);
            //SetPhoneLean(true);
            ClientMain.Instance.AddTick(TickControls);
            Phone.SetSoftKeys(1, SoftKeys.DELETE, true, SColor.HUD_Red);
            Phone.SetSoftKeys(2, SoftKeys.SELECT, true, SColor.HUD_Freemode);
            Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
        }

        public override async void Kill()
        {
            ClientMain.Instance.RemoveTick(TickControls);
            /*
            Phone = phone;
            await Phone.RotateAnimation(PhoneAnimation.SET_VERTICAL);
            SetPhoneLean(false);
            */
        }

    }
}
