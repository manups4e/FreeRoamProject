using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class MainMenu : App
    {
        public int SelectedItem { get; set; } = 4;
        public List<App> AllApps { get; set; }

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
                if (SelectedItem < AllApps.Count && !String.IsNullOrEmpty(AllApps[SelectedItem].Name))
                {
                    Title = AllApps[SelectedItem].Name;
                }

                for (int i = 0; i < 9; i++)
                {
                    int thirdParam = 3;
                    if (i < AllApps.Count)
                    {
                        if (AllApps[i].Icon != 0)
                        {
                            thirdParam = (int)AllApps[i].Icon;
                        }
                    }
                    Phone.Scaleform.CallFunction("SET_DATA_SLOT", (int)CurrentView, i, thirdParam);
                }

                Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
                // the error shouldn't happen if we have all the apps!!!! anyway..
                Phone.Scaleform.CallFunction("SET_HEADER", SelectedItem >= AllApps.Count ? "" : AllApps[SelectedItem].Title);
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
            SetMobilePhoneRotation(-90.0f, 0.0f, 0.0f, 0);
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
