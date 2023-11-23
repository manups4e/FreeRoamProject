using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class MainMenu : App
    {
        public int SelectedItem { get; set; }
        public List<App> AllApps { get; set; }

        public MainMenu(Phone phone, List<App> allApps) : base("Main", 0, phone, false)
        {
            AllApps = allApps;

            ClientMain.Logger.Debug($"Apps totali {AllApps.Count}");
        }

        public override async Task Tick()
        {
            try
            {
                if (Phone.Scaleform == null || AllApps == null) return;
                if (SelectedItem < AllApps.Count && !String.IsNullOrEmpty(AllApps[SelectedItem].Name))
                {
                    Name = AllApps[SelectedItem].Name;
                }

                for (int i = 0; i < 9; i++)
                {
                    int thirdParam = 3;
                    if (i < AllApps.Count)
                    {
                        if (AllApps[i].Icon != 0)
                        {
                            thirdParam = AllApps[i].Icon;
                        }
                    }
                    Phone.Scaleform.CallFunction("SET_DATA_SLOT", 1, i, thirdParam);
                }

                Phone.Scaleform.CallFunction("DISPLAY_VIEW", 1, SelectedItem);

                bool navigated = true;
                if (Input.IsControlJustPressed(Control.PhoneUp))
                {
                    SelectedItem -= 3;
                    CellCamMoveFinger(1);
                    Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 1);
                    if (SelectedItem < 0)
                        SelectedItem += 8;
                }
                else if (Input.IsControlJustPressed(Control.PhoneDown))
                {
                    SelectedItem += 3;
                    CellCamMoveFinger(2);
                    Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 3);
                    if (SelectedItem > 8)
                        SelectedItem -= 8;
                }
                else if (Input.IsControlJustPressed(Control.PhoneRight))
                {
                    SelectedItem += 1;
                    CellCamMoveFinger(3);
                    Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 2);
                    if (SelectedItem > 8)
                        SelectedItem = 0;
                }
                else if (Input.IsControlJustPressed(Control.PhoneLeft))
                {
                    SelectedItem -= 1;
                    CellCamMoveFinger(4);
                    Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 4);
                    if (SelectedItem < 0)
                        SelectedItem = 8;

                }
                else if (Input.IsControlJustPressed(Control.PhoneSelect))
                {
                    CellCamMoveFinger(5);
                    PhoneMainClient.StartApp(AllApps[SelectedItem].Name);
                }
                else if (Input.IsControlJustPressed(Control.PhoneCancel))
                {
                }
                else
                    navigated = false;

                if (navigated)
                {
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                }
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error($"{e.Message} : Exception thrown on Apps.Main.Tick()");
            }
        }

        public override void Initialize(Phone phone)
        {
            Phone = phone;
            SelectedItem = 0;
            SetMobilePhoneRotation(-90.0f, 0.0f, 0.0f, 0);
            SetPhoneLean(false);
        }

        public override void Kill()
        {
        }
    }
}
