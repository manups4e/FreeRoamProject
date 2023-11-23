using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.FREEROAM.Banking;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone
{
    public enum ModelPhone : int
    {
        Micheal = 0,
        Franklin = 1,
        Trevor = 2,
        Prologue = 4
    }

    //prop_phone_proto
    //npcphone

    static class PhoneMainClient
    {
        public static Phone Phone;
        public static void Init()
        {
            Phone = new Phone();
            // TODO: USE TICKCONTROLLER
            ClientMain.Instance.AddTick(ControlloApertura);
        }

        public static async Task ControlloApertura()
        {
            Ped ped = PlayerCache.MyPed;

            if (!(MenuHandler.IsAnyMenuOpen || Game.IsPaused || BankingClient.InterfaceOpen || ped.IsAiming || ped.IsAimingFromCover || ped.IsInCover() || ped.IsShooting))
            {
                if (Input.IsControlJustPressed(Control.Phone) && !IsPedRunningMobilePhoneTask(ped.Handle))
                {
                    Phone.OpenPhone();
                    Phone.currentApp = Phone.mainApp;
                }
                else if (IsPedRunningMobilePhoneTask(ped.Handle) && Input.IsControlJustPressed(Control.PhoneCancel))
                {
                    if (Phone.IsBackOverriddenByApp)
                        Phone.IsBackOverriddenByApp = false;
                    else
                        KillApp();
                }
            }
        }

        /*
         email, messages, contacts, 
         quickjoin, jobList, settings,
         snapmatic, web, securoserv,
         */

        public static void StartApp(string app)
        {
            if (app == "Main")
            {
                KillApp();
                if (Phone.currentApp != null)
                {
                    Phone.currentApp.Kill();
                    ClientMain.Instance.RemoveTick(Phone.currentApp.Tick);
                }
                Phone.currentApp = Phone.mainApp;
            }
            else if (Phone.apps.Exists(x => x.Name == app))
            {
                ClientMain.Instance.RemoveTick(Phone.mainApp.Tick);
                Phone.currentApp = Phone.apps.FirstOrDefault(x => x.Name == app);
            }

            Phone.currentApp.Initialize(Phone);
            ClientMain.Instance.AddTick(Phone.currentApp.Tick);

            ClientMain.Logger.Debug($"CurrentApp = {Phone.currentApp.Name}");
        }

        public static void KillApp()
        {
            if (Phone.currentApp != null)
            {
                ClientMain.Logger.Debug($"Killing App {Phone.currentApp.Name}");
                ClientMain.Instance.RemoveTick(Phone.currentApp.Tick);
                Phone.currentApp.Kill();

                App lastApp = Phone.currentApp;
                Phone.currentApp = null;

                if (lastApp.Icon == 0)
                {
                    foreach (App app in Phone.apps)
                    {
                        app.Kill();
                        ClientMain.Instance.RemoveTick(app.Tick);
                    }
                    Phone.ClosePhone();
                }
                else
                {
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    StartApp("Main");
                }
            }
        }

    }

    public enum SoftKeyIcon
    {
        Blank = 1,
        Select = 2,
        Pages = 3,
        Back = 4,
        Call = 5,
        Hangup = 6,
        HangupHuman = 7,
        Week = 8,
        Keypad = 9,
        Open = 10,
        Reply = 11,
        Delete = 12,
        Yes = 13,
        No = 14,
        Sort = 15,
        Website = 16,
        Police = 17,
        Ambulance = 18,
        Fire = 19,
        Pages2 = 20
    }

    public sealed class Wallpapers
    {
        public static readonly string iFruitDefault = "Phone_Wallpaper_ifruitdefault";
        public static readonly string BadgerDefault = "Phone_Wallpaper_badgerdefault";
        public static readonly string Bittersweet = "Phone_Wallpaper_bittersweet_b";
        public static readonly string PurpleGlow = "Phone_Wallpaper_purpleglow";
        public static readonly string GreenSquares = "Phone_Wallpaper_greensquares";
        public static readonly string OrangeHerringBone = "Phone_Wallpaper_orangeherringbone";
        public static readonly string OrangeHalftone = "Phone_Wallpaper_orangehalftone";
        public static readonly string GreenTriangles = "Phone_Wallpaper_greentriangles";
        public static readonly string GreenShards = "Phone_Wallpaper_greenshards";
        public static readonly string BlueAngles = "Phone_Wallpaper_blueangles";
        public static readonly string BlueShards = "Phone_Wallpaper_blueshards";
        public static readonly string BlueTriangles = "Phone_Wallpaper_bluetriangles";
        public static readonly string BlueCircles = "Phone_Wallpaper_bluecircles";
        public static readonly string Diamonds = "Phone_Wallpaper_diamonds";
        public static readonly string GreenGlow = "Phone_Wallpaper_greenglow";
        public static readonly string Orange8Bit = "Phone_Wallpaper_orange8bit";
        public static readonly string OrangeTriangles = "Phone_Wallpaper_orangetriangles";
        public static readonly string PurpleTartan = "Phone_Wallpaper_purpletartan";
    }

}
