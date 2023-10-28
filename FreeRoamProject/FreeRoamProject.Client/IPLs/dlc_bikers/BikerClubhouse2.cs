using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerClubhouse2
    {
        private static bool _enabled = false;
        public static string ipl = "bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milo";
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
            public enum Color
            {
                GreenGrey = 1,
                Multicolor = 2,
                OrangeGrey = 3,
                Blue = 4,
                LightBlueSable = 5,
                GreenRed = 6,
                YellowGrey = 7,
                Red = 8,
                FuchsiaGrey = 9
            }

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

        public class BikerLowerWalls
        {
            public enum Color
            {
                GreenGrey = 1,
                Multicolor = 2,
                OrangeGrey = 3,
                Blue = 4,
                LightBlueSable = 5,
                GreenRed = 6,
                YellowGrey = 7,
                Red = 8,
                FuchsiaGrey = 9
            }

            public string Default = "lower_walls_default";
            public void SetColor(Color color, bool refresh)
            {
                IplManager.SetIplPropState(InteriorId, Default, true, refresh);
                API.SetInteriorEntitySetColor(InteriorId, Default, (int)color);
            }
        }

        public class BikerFurnitures
        {
            public string A = "furnishings_01";
            public string B = "furnishings_02";
            public enum Color
            {
                Turquoise = 0,
                DarkBrown = 1,
                Brown = 2,
                Brown2 = 4,
                Grey = 5,
                Red = 6,
                DarkGrey = 7,
                Black = 8,
                Red2 = 9
            }

            public void Set(string furn, Color color, bool refresh = true)
            {
                Clear(false);
                IplManager.SetIplPropState(InteriorId, furn, true, refresh);
                if (furn == A)
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
            public string Stage1 = "meth_small";
            public List<string> Stage2 = new List<string>() { "meth_small", "meth_medium" };
            public List<string> Stage3 = new List<string>() { "meth_small", "meth_medium", "meth_large" };

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
            public string Stage1 = "cash_small";
            public List<string> Stage2 = new List<string>() { "cash_small", "cash_medium" };
            public List<string> Stage3 = new List<string>() { "cash_small", "cash_medium", "cash_large" };

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
            public string Stage1 = "weed_small";
            public List<string> Stage2 = new List<string>() { "weed_small", "weed_medium" };
            public List<string> Stage3 = new List<string>() { "weed_small", "weed_medium", "weed_large" };

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
            public string Stage1 = "coke_small";
            public List<string> Stage2 = new List<string>() { "coke_small", "coke_medium" };
            public List<string> Stage3 = new List<string>() { "coke_small", "coke_medium", "coke_large" };

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
            public string Stage1 = "counterfeit_small";
            public List<string> Stage2 = new List<string>() { "counterfeit_small", "counterfeit_medium" };
            public List<string> Stage3 = new List<string>() { "counterfeit_small", "counterfeit_medium", "counterfeit_large" };

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
            public string Stage1 = "id_small";
            public List<string> Stage2 = new List<string>() { "id_small", "id_medium" };
            public List<string> Stage3 = new List<string>() { "id_small", "id_medium", "id_large" };

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

        public static int InteriorId = 246529;
        public static BikerWalls Walls = new BikerWalls();
        public static BikerLowerWalls LowerWalls = new BikerLowerWalls();
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
            Walls.Set(Walls.Plain, BikerWalls.Color.Red);
            LowerWalls.SetColor(BikerLowerWalls.Color.Red, false);
            Fornitures.Set(Fornitures.A, BikerFurnitures.Color.Brown);
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
