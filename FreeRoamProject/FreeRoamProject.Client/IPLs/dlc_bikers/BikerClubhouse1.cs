using CitizenFX.Core.Native;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerClubhouse1
    {
        public enum Color
        {
            Sable = 0,
            YellowGrey = 1,
            Red = 2,
            Brown = 3,
            Yellow = 4,
            LightYellow = 5,
            LightYellowGrey = 6,
            LightGrey = 7,
            Orange = 8,
            Grey = 9
        }
        private static bool _enabled = false;
        public static string ipl = "bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo";
        public static bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public class BikerWalls
        {
            public string Brick = "walls_01";
            public string Plain = "walls_02";

            public void Set(string walls, Color color, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, walls, true, refresh);
                API.SetInteriorEntitySetColor(InteriorId, walls, (int)color);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Brick, false, refresh);
                IplManager.SetIplPropState(InteriorId, Plain, false, refresh);
            }
        }

        public class BikerFurnitures
        {
            public string A = "furnishings_01";
            public string B = "furnishings_02";

            public void Set(string furn, Color color, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, furn, true, refresh);
                API.SetInteriorEntitySetColor(InteriorId, furn, (int)color);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, A, false, refresh);
                IplManager.SetIplPropState(InteriorId, B, false, refresh);
            }
        }

        public class BikerDecorations
        {
            public string A = "decorative_01";
            public string B = "decorative_02";

            public void Set(string deco, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, deco, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, A, false, refresh);
                IplManager.SetIplPropState(InteriorId, B, false, refresh);
            }
        }

        public class BikerMurals
        {
            public string None = "";
            public string RideFree = "mural_01";
            public string Mods = "mural_02";
            public string Brave = "mural_03";
            public string Fist = "mural_04";
            public string Forest = "mural_05";
            public string Mods2 = "mural_06";
            public string RideForever = "mural_07";
            public string Heart = "mural_08";
            public string Route68 = "mural_09";

            public void Set(string mural, bool refresh = true)
            {
                Clear(false);
                if (mural != None)
                    IplManager.SetIplPropState(InteriorId, mural, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }
            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, new List<string>() { "mural_01", "mural_02", "mural_03", "mural_04", "mural_05", "mural_06", "mural_07", "mural_08", "mural_09" }, false, refresh);
            }
        }
        public class BikerGunLocker
        {
            public string None = "";
            public string On = "gun_locker";
            public string Off = "no_gun_locker";

            public void Set(string locker, bool refresh = true)
            {
                Clear(false);
                if (locker != None)
                    IplManager.SetIplPropState(InteriorId, locker, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, new List<string>() { "gun_locker", "no_gun_locker" }, false, refresh);
            }
        }
        public class BikerModBooth
        {
            public string None = "";
            public string On = "mod_booth";
            public string Off = "no_mod_booth";

            public void Set(string locker, bool refresh = true)
            {
                Clear(false);
                if (locker != None)
                    IplManager.SetIplPropState(InteriorId, locker, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, new List<string>() { "mod_booth", "no_mod_booth" }, false, refresh);
            }
        }

        public class BikerMeth
        {
            public string None = "";
            public string Stage1 = "meth_stash1";
            public List<string> Stage2 = new List<string>() { "meth_stash1", "meth_stash2" };
            public List<string> Stage3 = new List<string>() { "meth_stash1", "meth_stash2", "meth_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public class BikerCash
        {
            public string None = "";
            public string Stage1 = "cash_stash1";
            public List<string> Stage2 = new List<string>() { "cash_stash1", "cash_stash2" };
            public List<string> Stage3 = new List<string>() { "cash_stash1", "cash_stash2", "cash_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public class BikerWeed
        {
            public string None = "";
            public string Stage1 = "weed_stash1";
            public List<string> Stage2 = new List<string>() { "weed_stash1", "weed_stash2" };
            public List<string> Stage3 = new List<string>() { "weed_stash1", "weed_stash2", "weed_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public class BikerCoke
        {
            public string None = "";
            public string Stage1 = "coke_stash1";
            public List<string> Stage2 = new List<string>() { "coke_stash1", "coke_stash2" };
            public List<string> Stage3 = new List<string>() { "coke_stash1", "coke_stash2", "coke_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public class BikerCounterfeit
        {
            public string None = "";
            public string Stage1 = "counterfeit_stash1";
            public List<string> Stage2 = new List<string>() { "counterfeit_stash1", "counterfeit_stash2" };
            public List<string> Stage3 = new List<string>() { "counterfeit_stash1", "counterfeit_stash2", "counterfeit_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public class BikerDocuments
        {
            public string None = "";
            public string Stage1 = "id_stash1";
            public List<string> Stage2 = new List<string>() { "id_stash1", "id_stash2" };
            public List<string> Stage3 = new List<string>() { "id_stash1", "id_stash2", "id_stash3" };

            public void Set(string stage, bool refresh = true)
            {
                Clear(false);
                if (stage != None)
                    IplManager.SetIplPropState(InteriorId, stage, true, refresh);
                else
                {
                    if (refresh) API.RefreshInterior(InteriorId);
                }
            }

            public void Set(List<string> stage, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, stage, true, refresh);
            }

            public void Clear(bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Stage1, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage2, false, refresh);
                IplManager.SetIplPropState(InteriorId, Stage3, false, refresh);
            }
        }

        public static int InteriorId = 246273;
        public static BikerWalls Walls = new BikerWalls();
        public static BikerFurnitures Fornitures = new BikerFurnitures();
        public static BikerDecorations Decorations = new BikerDecorations();
        public static BikerMurals Murals = new BikerMurals();
        public static BikerGunLocker GunLocker = new BikerGunLocker();
        public static BikerModBooth ModBooth = new BikerModBooth();
        public static BikerMeth Meth = new BikerMeth();
        public static BikerCash Cash = new BikerCash();
        public static BikerWeed Weed = new BikerWeed();
        public static BikerCoke Coke = new BikerCoke();
        public static BikerCounterfeit Counterfeit = new BikerCounterfeit();
        public static BikerDocuments Documents = new BikerDocuments();

        public static void LoadDefault()
        {
            Enabled = true;
            Walls.Set(Walls.Plain, Color.Brown);
            Fornitures.Set(Fornitures.A, Color.Brown);
            Decorations.Set(Decorations.A);
            Murals.Set(Murals.RideFree);
            ModBooth.Set(ModBooth.None);
            GunLocker.Set(GunLocker.None);
            Meth.Set(Meth.None);
            Weed.Set(Weed.None);
            Coke.Set(Coke.None);
            Cash.Set(Cash.None);
            Counterfeit.Set(Counterfeit.None);
            Documents.Set(Documents.None);
            API.RefreshInterior(InteriorId);
        }


    }
}
