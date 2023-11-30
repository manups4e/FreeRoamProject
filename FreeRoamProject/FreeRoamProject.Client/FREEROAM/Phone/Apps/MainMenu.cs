using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class MainMenu : App
    {
        public int SelectedItem { get; set; } = 4;
        public List<App> AllApps { get; set; }
        int smsUnreadCount = 0;
        public MainMenu(Phone phone, List<App> allApps) : base("HOMEMENU", 0, phone, PhoneView.HOMEMENU, false)
        {
            AllApps = allApps;

            ClientMain.Logger.Debug($"Apps totali {AllApps.Count}");
        }

        public override async Task TickVisual()
        {
            try
            {
                if (Phone.Scaleform == null || AllApps == null) return;
                for (int i = 0; i < 9; i++)
                {
                    int icon = 3;
                    int unread = 0;
                    string name = "";
                    if (i < AllApps.Count)
                    {
                        if (AllApps[i].Icon != 0)
                        {
                            icon = (int)AllApps[i].Icon;
                        }
                        if (AllApps[i].Name == "CELL_1")
                        {
                            unread = AllApps[i].UnreadCount = Phone.getCurrentCharPhone().Messages.Count(x => x.Readed == Shared.Core.Character.MessageState.UNREAD_SMS);
                        }
                        name = AllApps[i].Name;
                    }
                    BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt((int)CurrentView);
                    ScaleformMovieMethodAddParamInt(i);
                    ScaleformMovieMethodAddParamInt(icon);
                    ScaleformMovieMethodAddParamInt(unread);
                    BeginTextCommandScaleformString(name);
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                }

                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
                // the error shouldn't happen if we have all the apps!!!! anyway..
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error($"{e}");
            }
        }
        public override async Task TickControls()
        {
            bool navigated = true;
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                CellCamMoveFinger(1);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 1);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                CellCamMoveFinger(2);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 3);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
            }
            else if (Input.IsControlJustPressed(Control.PhoneRight))
            {
                CellCamMoveFinger(3);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 2);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
            }
            else if (Input.IsControlJustPressed(Control.PhoneLeft))
            {
                CellCamMoveFinger(4);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 4);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                CellCamMoveFinger(5);
                Phone.StartApp(AllApps[SelectedItem].Name);
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                Phone.ClosePhone();
            }
        }
        public override void Initialize(Phone phone)
        {
            Phone = phone;
            SetPhoneLean(false);
            Phone.SetSoftKeys(1, SoftKeys.BLANK, false, SColor.HUD_Freemode);
            Phone.SetSoftKeys(2, SoftKeys.SELECT, true, SColor.HUD_Freemode);
            Phone.SetSoftKeys(3, SoftKeys.BACK, true, SColor.HUD_Red);
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
        }

        public override void Kill()
        {
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
        }
    }
}
