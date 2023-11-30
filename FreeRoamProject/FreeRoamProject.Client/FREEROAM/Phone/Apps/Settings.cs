using FreeRoamProject.Client.FREEROAM.Phone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public class Settings : App
    {
        private int SelectedItem { get; set; } = 0;
        private int LastSelection = 0;

        private SettingsSubMenu CurrentSubMenu = null;
        private static bool FirstTick = true;
        private static string numero;

        // bg
        // invite sound
        // ringtone
        // snapmatic 
        // theme
        // vibrate

        private static List<SettingsSubMenuItem> Themes = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_820", 1, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_821", 2, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_822", 3, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_823", 4, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_824", 5, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_825", 6, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_826", 7, IconLabels.SETTINGS_1),
        };

        private static List<SettingsSubMenuItem> Wallpapers = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_840", 0, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_844", 4, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_845", 5, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_846", 6, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_847", 7, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_848", 8, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_849", 9, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_850", 10, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_851", 11, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_852", 12, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_853", 13, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_854", 14, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_855", 15, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_856", 16, IconLabels.SETTINGS_1),
            new SettingsSubMenuItem("CELL_857", 17, IconLabels.SETTINGS_1)
        };

        private static List<SettingsSubMenuItem> Profile = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_800", 0, IconLabels.PROFILE),
            new SettingsSubMenuItem("CELL_801", 1, IconLabels.SLEEP_MODE),
        };

        private static List<SettingsSubMenuItem> InviteSound = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_831", 1, IconLabels.VIBRATE_OFF),
            new SettingsSubMenuItem("CELL_830", 2, IconLabels.VIBRATE_ON)
        };

        private static List<SettingsSubMenuItem> Ringtone = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_810", 1, IconLabels.RINGTONE), // PHONE_GENERIC_RING_01
            new SettingsSubMenuItem("CELL_811", 2, IconLabels.RINGTONE), // PHONE_GENERIC_RING_02
            new SettingsSubMenuItem("CELL_812", 3, IconLabels.RINGTONE), // PHONE_GENERIC_RING_03
            new SettingsSubMenuItem("CELL_813", 4, IconLabels.SILENT), // Silent Ringtone Dummy (yeah.. that's the name itself)
        };

        private static List<SettingsSubMenuItem> Vibrate = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_831", 1, IconLabels.VIBRATE_OFF),
            new SettingsSubMenuItem("CELL_830", 2, IconLabels.VIBRATE_ON)
        };
        private static List<SettingsSubMenuItem> Snapmatic = new List<SettingsSubMenuItem>
        {
            new SettingsSubMenuItem("CELL_704", 1, IconLabels.TEXT_TONE),
            new SettingsSubMenuItem("CELL_703", 2, IconLabels.TEXT_TONE)
        };

        private List<SettingsSubMenu> SettingsItems = new List<SettingsSubMenu>
        {
            new SettingsSubMenu("CELL_740", IconLabels.SETTINGS_1, Wallpapers),
            new SettingsSubMenu("CELL_700", IconLabels.PROFILE, Profile),
            new SettingsSubMenu("CELL_705", IconLabels.RINGTONE, InviteSound),
            new SettingsSubMenu("CELL_710", IconLabels.RINGTONE, Ringtone),
            new SettingsSubMenu("CELL_701", IconLabels.TEXT_TONE, Snapmatic),
            new SettingsSubMenu("CELL_720", IconLabels.SETTINGS_1, Themes),
            new SettingsSubMenu("CELL_730", IconLabels.VIBRATE_OFF, Vibrate),
        };

        public Settings(Phone phone) : base("CELL_16", IconLabels.SETTINGS_2, phone, PhoneView.SETTINGS)
        {
            numero = PlayerCache.MyPlayer.Name;
        }

        public override async Task TickVisual()
        {
            Phone.Scaleform.CallFunction("SET_DATA_SLOT_EMPTY", (int)CurrentView);
            if (CurrentSubMenu != null)
            {
                foreach (SettingsSubMenuItem item in CurrentSubMenu.Items)
                {
                    BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt((int)CurrentView);
                    ScaleformMovieMethodAddParamInt(CurrentSubMenu.Items.IndexOf(item));
                    ScaleformMovieMethodAddParamInt((int)item.Icon);
                    BeginTextCommandScaleformString(item.Name);
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                }
            }
            else
            {
                foreach (SettingsSubMenu subMenu in SettingsItems)
                {
                    BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_DATA_SLOT");
                    ScaleformMovieMethodAddParamInt((int)CurrentView);
                    ScaleformMovieMethodAddParamInt(SettingsItems.IndexOf(subMenu));
                    ScaleformMovieMethodAddParamInt((int)subMenu.Icon);
                    BeginTextCommandScaleformString(subMenu.Name);
                    EndTextCommandScaleformString();
                    EndScaleformMovieMethod();
                }
            }

            BeginScaleformMovieMethod(Phone.Scaleform.Handle, "SET_HEADER");
            BeginTextCommandScaleformString(Name);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();
            await Task.FromResult(0);
        }
        public override async Task TickControls()
        {
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                CellCamMoveFinger(1);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 1);
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                if (CurrentSubMenu != null)
                {
                    if (CurrentSubMenu.Name == "CELL_710")
                    {
                        StopPedRingtone(PlayerPedId());
                        await BaseScript.Delay(100);
                        string ringtone = CurrentSubMenu.Items[SelectedItem].Id switch
                        {
                            1 or 2 or 3 => "PHONE_GENERIC_RING_0" + (SelectedItem + 1),
                            _ => "Silent Ringtone Dummy",
                        };
                        PlayPedRingtone(ringtone, PlayerPedId(), true);
                    }
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                CellCamMoveFinger(2);
                Phone.Scaleform.CallFunction("SET_INPUT_EVENT", 3);
                SelectedItem = await Phone.Scaleform.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                if (CurrentSubMenu != null)
                {
                    if (CurrentSubMenu.Name == "CELL_710")
                    {
                        StopPedRingtone(PlayerPedId());
                        await BaseScript.Delay(100);
                        string ringtone = CurrentSubMenu.Items[SelectedItem].Id switch
                        {
                            1 or 2 or 3 => "PHONE_GENERIC_RING_0" + (SelectedItem + 1),
                            _ => "Silent Ringtone Dummy",
                        };
                        PlayPedRingtone(ringtone, PlayerPedId(), true);
                    }
                }
            }
            else if (Input.IsControlJustPressed(Control.FrontendAccept))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu == null)
                {
                    LastSelection = SelectedItem;
                    CurrentSubMenu = SettingsItems[SelectedItem];
                    SelectedItem = 0;
                    switch (LastSelection)
                    {
                        case 0:
                            Name = Wallpapers.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Wallpaper).Name;//Wallpapers
                            Wallpapers.ForEach(x => x.Icon = IconLabels.SETTINGS_1);
                            Wallpapers.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Wallpaper).Icon = IconLabels.TICKED;
                            break;
                        case 1:
                            Name = Profile.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().SleepMode).Name;//Standby
                            break;
                        case 2:
                            Name = InviteSound.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().InviteSound).Name;//InviteSound
                            break;
                        case 3:
                            Name = Ringtone.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Ringtone).Name;//Ringtone
                            Ringtone[0].Icon = IconLabels.RINGTONE;
                            Ringtone[1].Icon = IconLabels.RINGTONE;
                            Ringtone[2].Icon = IconLabels.RINGTONE;
                            Ringtone[3].Icon = IconLabels.SILENT;
                            Ringtone.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Ringtone).Icon = IconLabels.TICKED;
                            break;
                        case 4:
                            Name = Snapmatic.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().QuickLaunch).Name;//Snapmatic
                            Snapmatic.ForEach(x => x.Icon = IconLabels.TEXT_TONE);
                            Snapmatic.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().QuickLaunch).Icon = IconLabels.TICKED;
                            break;
                        case 5:
                            Name = Themes.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Theme).Name;//Themes
                            Themes.ForEach(x => x.Icon = IconLabels.SETTINGS_1);
                            Themes.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Theme).Icon = IconLabels.TICKED;
                            break;
                        case 6:
                            Name = Vibrate.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Vibration).Name;//Vibrate
                            break;
                    }
                }
                else
                {
                    switch (LastSelection)
                    {
                        case 0:
                            SetWallpaper(CurrentSubMenu.Items[SelectedItem].Id);
                            Name = Wallpapers.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Wallpaper).Name;//Wallpapers
                            break;
                        case 1:
                            SetSleep(CurrentSubMenu.Items[SelectedItem].Id);
                            Name = Profile.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().SleepMode).Name;//Standby
                            break;
                        case 2:
                            // TODO: INVITE
                            Name = InviteSound.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().InviteSound).Name;//InviteSound
                            SetInviteSound(CurrentSubMenu.Items[SelectedItem].Id);
                            break;
                        case 3:
                            SetRingtone(CurrentSubMenu.Items[SelectedItem].Id);
                            Name = Ringtone.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Ringtone).Name;//Ringtone
                            break;
                        case 4:
                            // TODO: SNAPMATIC 
                            Name = Snapmatic.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().QuickLaunch).Name;//Snapmatic
                            SetSnapmatic(CurrentSubMenu.Items[SelectedItem].Id);
                            break;
                        case 5:
                            SetTheme(CurrentSubMenu.Items[SelectedItem].Id);
                            Name = Themes.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Theme).Name;//Themes
                            break;
                        case 6:
                            SetVibration(CurrentSubMenu.Items[SelectedItem].Id);
                            Name = Vibrate.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Vibration).Name;//Vibrate
                            break;
                    }
                }
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
            }
            else if (Input.IsControlJustPressed(Control.FrontendCancel))
            {
                CellCamMoveFinger(5);
                if (CurrentSubMenu != null)
                {
                    if (IsPedRingtonePlaying(PlayerPedId()))
                        StopPedRingtone(PlayerPedId());
                    CurrentSubMenu = null;
                    SelectedItem = LastSelection;
                    Name = "CELL_16";
                }
                else
                {
                    Phone.StartApp("MAINMENU");
                }
                Game.PlaySound("Menu_Back", "Phone_SoundSet_Default");
            }
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", (int)CurrentView, SelectedItem);
        }

        public override void Initialize(Phone phone)
        {
            Phone = phone;
            CurrentSubMenu = null;
            FirstTick = true;
            SelectedItem = 0;
            ClientMain.Instance.AddTick(TickVisual);
            ClientMain.Instance.AddTick(TickControls);
        }

        public override void Kill()
        {
            ClientMain.Instance.RemoveTick(TickVisual);
            ClientMain.Instance.RemoveTick(TickControls);
        }

        public void SetTheme(int themeId)
        {
            Phone.getCurrentCharPhone().Theme = themeId;
            Themes.ForEach(x => x.Icon = IconLabels.SETTINGS_1);
            Themes.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Theme).Icon = IconLabels.TICKED;
            EventDispatcher.Send("tlg:phone:setSettings", "theme", themeId);
        }

        public void SetWallpaper(int wallpaperId)
        {
            Phone.getCurrentCharPhone().Wallpaper = wallpaperId;
            Wallpapers.ForEach(x => x.Icon = IconLabels.SETTINGS_1);
            Wallpapers.FirstOrDefault(x => x.Id == wallpaperId).Icon = IconLabels.TICKED;
            EventDispatcher.Send("tlg:phone:setSettings", "wall", wallpaperId);
        }
        public void SetInviteSound(int inviteId)
        {
            Phone.getCurrentCharPhone().InviteSound = inviteId;
            EventDispatcher.Send("tlg:phone:setSettings", "invite", inviteId);
        }

        public void SetRingtone(int ringtoneId)
        {
            Phone.getCurrentCharPhone().Ringtone = ringtoneId;
            Ringtone[0].Icon = IconLabels.RINGTONE;
            Ringtone[1].Icon = IconLabels.RINGTONE;
            Ringtone[2].Icon = IconLabels.RINGTONE;
            Ringtone[3].Icon = IconLabels.SILENT;
            Ringtone.FirstOrDefault(x => x.Id == Phone.getCurrentCharPhone().Ringtone).Icon = IconLabels.TICKED;
            EventDispatcher.Send("tlg:phone:setSettings", "ring", ringtoneId);
        }

        public void SetVibration(int Vibe)
        {
            if (Vibe == 2)
                SetPadShake(0, 300, 200);
            Phone.getCurrentCharPhone().Vibration = Vibe;
            EventDispatcher.Send("tlg:phone:setSettings", "vibe", Vibe);
        }

        public void SetSnapmatic(int snapmaticId)
        {
            Phone.getCurrentCharPhone().QuickLaunch = snapmaticId;
            EventDispatcher.Send("tlg:phone:setSettings", "snapmatic", snapmaticId);
        }

        public void SetSleep(int toggle)
        {
            if (toggle == 2)
                Notifications.ShowHelpNotification(Game.GetGXTEntry("CELL_7050"));
            Phone.getCurrentCharPhone().SleepMode = toggle;
            EventDispatcher.Send("tlg:phone:setSettings", "sleep", toggle);
        }
    }

    public class SettingsSubMenu
    {
        public string Name { get; private set; }
        public IconLabels Icon { get; private set; }
        public List<SettingsSubMenuItem> Items { get; set; }

        public SettingsSubMenu(string label, IconLabels icon, List<SettingsSubMenuItem> items = null)
        {
            Name = label;
            Icon = icon;
            Items = items;
        }
    }

    public class SettingsSubMenuItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public IconLabels Icon { get; set; }

        public SettingsSubMenuItem(string name, int id, IconLabels icon)
        {
            Name = name;
            Id = id;
            Icon = icon;
        }
    }
}
