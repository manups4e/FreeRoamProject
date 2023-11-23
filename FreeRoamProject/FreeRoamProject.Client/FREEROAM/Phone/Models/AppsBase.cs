using System.Collections.Generic;

namespace FreeRoamProject.Client.FREEROAM.Phone.Models
{
    public static class AppsBase
    {
        public static App CurrentApp { get; set; } = null;
        public static List<App> Apps { get; set; } = new List<App>();

        public static void Start(App app)
        {
            if (app.Name == "Main")
            {
                Kill();
            }
        }

        public static void Kill()
        {
            if (CurrentApp != null)
            {
                CurrentApp.Kill();
            }

            App lastApp = CurrentApp;
            CurrentApp = null;

            if (lastApp.Name == "Main")
            {
                Game.PlaySound("Hang_Up", "Phone_SoundSet_Michael");
                // kill phone
            }
            else
            {
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                //Start(new Main())
            }
        }
    }
}
