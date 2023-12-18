using System.Drawing;
using System.Threading.Tasks;
using MarkerEx = FreeRoamProject.Client.Core.Utility.HUD.MarkerEx;

namespace FreeRoamProject.Client
{
    // REMOVED IN PRODUCTION :D THIS IS JUST A TEST CLASS
    internal static class TestClass
    {
        //static ClientList list = new ClientList();
        public static async void Init()
        {
            ClientMain.Instance.AddTick(TestTick);
        }
        static bool pp = false;
        static MarkerEx dummyMarker = new(MarkerType.VerticalCylinder, WorldProbe.CrossairRaycastResult.HitPosition.ToPosition(), SColor.Blue);
        private static async Task TestTick()
        {
            //ClientMain.Logger.Debug(IplManager.Global.ToJson());
            if (Input.IsControlJustPressed(Control.Detonate, PadCheck.Keyboard, ControlModifier.Shift) && !MenuHandler.IsAnyMenuOpen)
            {
                //await PlayerCache.InitPlayer();

                //PlayerCache.MyPlayer.Ped.Weapons.Give(WeaponHash.Pistol, 100, true, true);
                //TestMenu();
                //AttivaMenu();
                /*
                list.RequestPlayerList();
                await list.WaitRequested();
                foreach (var pl in list) 
                {
                    ClientMain.Logger.Debug($"giocatori: {pl.Player.Name}, {pl.Handle}");
                    ClientMain.Logger.Debug(pl.ToJson());
                }
                */
            }
            if (Input.IsControlJustPressed(Control.Context, PadCheck.Keyboard, ControlModifier.Shift))
            {
                menu.MenuItems[0].Enabled = !menu.MenuItems[0].Enabled;
            }
        }

        public static void Stop()
        {
            ClientMain.Instance.RemoveTick(TestTick);
        }

        static UIMenu menu = new("Menu Test", "Test");

        private static void TestMenu()
        {
            UIMenu menu = new UIMenu("🐌", "test", new PointF(50, 50), "thelastgalaxy", "bannerbackground", false, true);
            UIMenuItem item = new("😐", "~BLIP_INFO_ICON~ Potrai in ogni mento riaprire questo menu di pausa premendo i tasti ~INPUT_SPRINT~ + ~INPUT_DROP_WEAPON~ oppure con il comando /help.");
            menu.AddItem(item);
            menu.Visible = true;
        }
    }
}