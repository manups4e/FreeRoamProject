using FreeRoamProject.FREEROAM.Banking;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone
{
    //prop_phone_proto
    //npcphone

    static class PhoneMainClient
    {
        public static Phone Phone;
        public static bool PhoneActive = false;
        public static void Init()
        {
            Phone = new Phone();
            // TODO: USE TICKCONTROLLER
            ClientMain.Instance.AddTick(ControlloApertura);
        }

        public static async Task ControlloApertura()
        {
            Ped ped = PlayerCache.MyPed;

            if (!MenuHandler.IsAnyMenuOpen && !Game.IsPaused && !BankingClient.InterfaceOpen && !ped.IsAiming && !ped.IsAimingFromCover && !ped.IsInCover() && !ped.IsShooting)
            {
                if (Input.IsControlJustPressed(Control.Phone) && !IsPedRunningMobilePhoneTask(ped.Handle))
                {
                    Phone.OpenPhone();
                    PhoneActive = true;
                }
            }
        }
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
