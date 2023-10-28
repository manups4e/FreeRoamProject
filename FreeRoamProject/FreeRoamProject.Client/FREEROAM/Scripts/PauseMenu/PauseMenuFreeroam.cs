using FreeRoamProject.Client.Handlers;
using System;


namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.PauseMenu
{
    static class PauseMenuFreeroam
    {
        private static readonly InputController pauseMenu = new(Control.DropWeapon, PadCheck.Keyboard, ControlModifier.Shift, new Action<Ped, object[]>(FreeRoamMenu));

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += (client) => InputHandler.AddInput(pauseMenu);
            AccessingEvents.OnFreeRoamLeave += (client) => InputHandler.RemoveInput(pauseMenu);
        }

        public static async void FreeRoamMenu(Ped me, object[] _unused)
        {
            if (MenuHandler.IsAnyPauseMenuOpen) return;
            PlayerClient client = Cache.PlayerCache.MyPlayer;

            int day = GetClockDayOfWeek();
            string giorno = "Monday";
            switch (day)
            {
                case 0:
                    giorno = "Sunday";
                    break;
                case 1:
                    giorno = "Monday";
                    break;
                case 2:
                    giorno = "Tuesday";
                    break;
                case 3:
                    giorno = "Wednesday";
                    break;
                case 4:
                    giorno = "Thursday";
                    break;
                case 5:
                    giorno = "Friday";
                    break;
                case 6:
                    giorno = "Saturday";
                    break;
            }

            TabView MainMenu = new("The Last Galaxy", "FreeRoam")
            {
                SideStringTop = Cache.PlayerCache.MyPlayer.Player.Name,
                SideStringMiddle = $"{giorno.ToUpper()} {GetClockHours()}:{GetClockMinutes()}",
                SideStringBottom = "CASH: $" + client.User.Money + " BANK: $" + client.User.Bank,
                DisplayHeader = true
            };
            Tuple<int, string> mugshot = await Functions.GetPedMugshotAsync(me);
            MainMenu.HeaderPicture = new(mugshot.Item2, mugshot.Item2);
            MainMenu.CrewPicture = new("thelastgalaxy", "serverlogo");

            SubmenuTab online = new("FREEROAM", SColor.HUD_Freemode);
            TabLeftItem disc = new("Go back to lobby", LeftItemType.Info)
            {
                Label = "WARNING"
            };
            BasicTabItem _discinfo = new("⚠ You'll go back to lobby and all progress data will be lost!");
            disc.AddItem(_discinfo);
            online.AddLeftItem(disc);

            MainMenu.AddTab(online);

            disc.OnActivated += async (item, index) =>
            {
                Screen.Fading.FadeOut(1000);
                await BaseScript.Delay(1500);
                MainMenu.Visible = false;
                await Initializer.Stop();
            };

            MainMenu.Visible = true;
        }
    }
}
