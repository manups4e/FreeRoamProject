using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_afterhours
{
    public class AfterHoursNightclubs
    {
        public static int InteriorId = 271617;

        private bool _enabled = false;
        public string ipl = "ba_int_placement_ba_interior_0_dlc_int_01_ba_milo_";

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }

        public class NightInterior
        {
            public class Names
            {
                public string Galaxy = "Int01_ba_clubname_01"; public string Studio = "Int01_ba_clubname_02"; public string Omega = "Int01_ba_clubname_03";
                public string Technologie = "Int01_ba_clubname_04"; public string Gefangnis = "Int01_ba_clubname_05"; public string Maisonette = "Int01_ba_clubname_06";
                public string Tony = "Int01_ba_clubname_07"; public string Palace = "Int01_ba_clubname_08"; public string Paradise = "Int01_ba_clubname_09";

                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    IplManager.SetIplPropState(InteriorId, style, true, refresh);
                }

                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_clubname_01", "Int01_ba_clubname_02", "Int01_ba_clubname_03", "Int01_ba_clubname_04", "Int01_ba_clubname_05", "Int01_ba_clubname_06", "Int01_ba_clubname_07", "Int01_ba_clubname_08", "Int01_ba_clubname_09" }, false, refresh);
                }
            }

            public class Styles
            {
                public string Trad = "Int01_ba_Style01"; public string Edgy = "Int01_ba_Style02"; public string Glam = "Int01_ba_Style03";
                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    IplManager.SetIplPropState(InteriorId, style, true, refresh);
                }
                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_Style01", "Int01_ba_Style02", "Int01_ba_Style03" }, false, refresh);
                }
            }

            public class Podiums
            {
                public string None = ""; public string Trad = "Int01_ba_Style01_podium"; public string Edgy = "Int01_ba_Style02_podium"; public string Glam = "Int01_ba_Style03_podium";
                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    IplManager.SetIplPropState(InteriorId, style, true, refresh);
                }
                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_Style01_podium", "Int01_ba_Style02_podium", "Int01_ba_Style03_podium" }, false, refresh);
                }
            }

            public class Speaker
            {
                public string None = ""; public string Basic = "Int01_ba_equipment_setup"; public string Upgrade = "Int01_ba_equipment_upgrade";
                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    if (style == Upgrade)
                        IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_equipment_setup", "Int01_ba_equipment_upgrade" }, true, refresh);
                    else
                        IplManager.SetIplPropState(InteriorId, style, true, refresh);
                }
                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, "Int01_ba_equipment_setup", false, refresh);
                    IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_equipment_setup", "Int01_ba_equipment_upgrade" }, false, refresh);
                }
            }

            public class Securitys
            {
                public string Off = ""; public string On = "Int01_ba_security_upgrade";
                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    IplManager.SetIplPropState(InteriorId, style, true, refresh);
                }
                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, "Int01_ba_security_upgrade", false, refresh);
                }
            }

            public class TurnTable
            {
                public string None = "";
                public string style01 = "Int01_ba_dj01"; public string style02 = "Int01_ba_dj02";
                public string style03 = "Int01_ba_dj03"; public string style04 = "Int01_ba_dj04";
                public void Set(string style, bool refresh = true)
                {
                    Clear(false);
                    if (style != None)
                        IplManager.SetIplPropState(InteriorId, style, true, refresh);
                    else
                    {
                        if (refresh) API.RefreshInterior(InteriorId);
                    }
                }
                public void Clear(bool refresh)
                {
                    IplManager.SetIplPropState(InteriorId, new List<string>() { "Int01_ba_dj01", "Int01_ba_dj02", "Int01_ba_dj03", "Int01_ba_dj04" }, false, refresh);
                }
            }

            public class Light
            {
                public class Luce
                {
                    public string Colore1; public string Colore2; public string Colore3; public string Colore4;
                    public Luce(string a, string b, string c, string d) { Colore1 = a; Colore2 = b; Colore3 = c; Colore4 = d; }
                    public void Set(string style, bool refresh = true)
                    {
                        Clear(false);
                        IplManager.SetIplPropState(InteriorId, style, true, refresh);
                    }
                    public void Clear(bool refresh)
                    {
                        List<string> list = [Colore1, Colore2, Colore3, Colore4];
                        IplManager.SetIplPropState(InteriorId, list, false, refresh);
                    }
                }
                public Luce Droplets = new("DJ_01_Lights_01", "DJ_02_Lights_01", "DJ_03_Lights_01", "DJ_04_Lights_01");
                public Luce Neons = new("DJ_01_Lights_02", "DJ_02_Lights_02", "DJ_03_Lights_02", "DJ_04_Lights_02");
                public Luce Bands = new("DJ_01_Lights_03", "DJ_02_Lights_03", "DJ_03_Lights_03", "DJ_04_Lights_03");
                public Luce Lasers = new("DJ_01_Lights_04", "DJ_02_Lights_04", "DJ_03_Lights_04", "DJ_04_Lights_04");

                public void Clear()
                {
                    Droplets.Clear(true);
                    Neons.Clear(true);
                    Bands.Clear(true);
                    Lasers.Clear(true);
                }
            }

            public class Bars
            {
                public void Enable(bool state = true, bool refresh = true)
                {
                    IplManager.SetIplPropState(InteriorId, "Int01_ba_bar_content", state, refresh);
                }
            }

            public class Boozes
            {
                public string A = "Int01_ba_booze_01"; public string B = "Int01_ba_booze_02"; public string C = "Int01_ba_booze_03";
                public void Enable(string booze, bool state = true, bool refresh = true)
                {
                    IplManager.SetIplPropState(InteriorId, booze, state, refresh);
                }
            }
            public class Trofei
            {
                public enum Colors
                {
                    Bronze = 0,
                    Silver = 1,
                    Gold = 2
                }
                public string Number1 = "Int01_ba_trophy01";
                public string Battler = "Int01_ba_trophy02";
                public string Dancer = "Int01_ba_trophy03";
                public void Enable(string trophy, bool state, Colors color, bool refresh = true)
                {
                    IplManager.SetIplPropState(InteriorId, trophy, state, refresh);
                    API.SetInteriorEntitySetColor(InteriorId, trophy, (int)color);
                }
            }

            public class GhiaccioSecco
            {
                public float Scale = 5.0f;
                readonly List<Tuple<Vector3, Vector3>> Emitters =
                [
                    new Tuple<Vector3, Vector3>(new Vector3(-1602.932f, -3019.1f, -79.99f), new Vector3(0.0f, -10.0f, 66.0f)),
                    new Tuple<Vector3, Vector3>(new Vector3(-1593.238f, -3017.05f, -79.99f), new Vector3(0.0f, -10.0f, 110.0f)),
                    new Tuple<Vector3, Vector3>(new Vector3(-1597.134f, -3008.2f, -79.99f), new Vector3(0.0f, -10.0f, -122.53f)),
                    new Tuple<Vector3, Vector3>(new Vector3(-1589.966f, -3008.518f, -79.99f), new Vector3(0.0f, -10.0f, -166.97f)),
                ];

                public async void Enable(bool state)
                {
                    if (state)
                    {
                        API.RequestNamedPtfxAsset("scr_ba_club");
                        while (!API.HasNamedPtfxAssetLoaded("scr_ba_club")) await BaseScript.Delay(0);
                        foreach (Tuple<Vector3, Vector3> emitter in Emitters)
                        {
                            API.UseParticleFxAsset("scr_ba_club");
                            API.StartParticleFxLoopedAtCoord("scr_ba_club_smoke_machine", emitter.Item1.X, emitter.Item1.Y, emitter.Item1.Z, emitter.Item2.X, emitter.Item2.Y, emitter.Item2.Z, Scale, false, false, false, true);
                        }
                    }
                    else
                    {
                        foreach (Tuple<Vector3, Vector3> emitter in Emitters)
                            API.RemoveParticleFxInRange(emitter.Item1.X, emitter.Item1.Y, emitter.Item1.Z, 1f);
                    }
                }
            }

            public class AHDetails
            {
                public string clutter = "Int01_ba_Clutter";               // Clutter and graffitis
                public string worklamps = "Int01_ba_Worklamps";           // Work lamps + trash
                public string truck = "Int01_ba_deliverytruck";           // Truck parked in the garage

                public string dryIce = "Int01_ba_dry_ice";                // Dry ice machines(no effects)

                public string lightRigsOff = "light_rigs_off";            // All light rigs at once but turned off

                public string roofLightsOff = "Int01_ba_lightgrid_01";    // Fake lights

                public string floorTradLights = "Int01_ba_trad_lights";   // Floor lights meant to go with the trad style
                public string chest = "Int01_ba_trophy04";                // Chest on the VIP desk
                public string vaultAmmunations = "Int01_ba_trophy05";     // (inside vault) Ammunations

                public string vaultMeth = "Int01_ba_trophy07";            // (inside vault) Meth bag
                public string vaultFakeID = "Int01_ba_trophy08";          // (inside vault) Fake ID
                public string vaultWeed = "Int01_ba_trophy09";            // (inside vault) Opened weed bag

                public string vaultCoke = "Int01_ba_trophy10";            // (inside vault) Coke doll
                public string vaultCash = "Int01_ba_trophy11";            // (inside vault) Scrunched fake money

                public void Enable(string det, bool state = true, bool refresh = true)
                {
                    IplManager.SetIplPropState(InteriorId, det, state, refresh);
                }
            }

            public Names Name = new();
            public Styles Style = new();
            public Podiums Podium = new();
            public Speaker Speakers = new();
            public Securitys Security = new();
            public TurnTable TurnTables = new();
            public Light Lights = new();
            public Bars Bar = new();
            public Boozes Booze = new();
            public Trofei Trophy = new();
            public GhiaccioSecco DryIce = new();
            public AHDetails Details = new();
        }

        public class AHInfo
        {
            public static int Id;
            public AHInfo(int id) { Id = id; }
            public class Barriera
            {
                public void Enable(bool state = true)
                {
                    Barrier.Enable(Id, state);
                }
            }
            public class aPoster
            {
                public void Enable(string poster, bool state = true)
                {
                    Posters.Enable(Id, poster, state);
                }
                public void Clear()
                {
                    Posters.Clear(Id);
                }
            }
            public Barriera Barriere = new();
            public aPoster Poster = new();
        }

        public class AHBarrier
        {
            public string Barrier = "ba_barriers_caseX";
            public void Enable(int id, bool state)
            {
                string value = Barrier.Replace("caseX", $"case{id}");
                IplManager.EnableIpl(value, state);
            }
        }

        public class AHPosters
        {
            public string ForSale = "ba_caseX_forsale";
            public string Dixon = "ba_caseX_dixon";
            public string Madonna = "ba_caseX_madonna";
            public string Solomun = "ba_caseX_solomun";
            public string TaleOfUs = "ba_caseX_taleofus";

            public void Enable(int id, string poster, bool state)
            {
                IplManager.EnableIpl(poster.Replace("caseX", $"case{id}"), state);
            }
            public void Clear(int id)
            {
                IplManager.EnableIpl(ForSale.Replace("caseX", $"case{id}"), false);
                IplManager.EnableIpl(Dixon.Replace("caseX", $"case{id}"), false);
                IplManager.EnableIpl(Madonna.Replace("caseX", $"case{id}"), false);
                IplManager.EnableIpl(Solomun.Replace("caseX", $"case{id}"), false);
                IplManager.EnableIpl(TaleOfUs.Replace("caseX", $"case{id}"), false);
            }
        }

        public static NightInterior Interior = new();
        public static AHBarrier Barrier = new();
        public static AHPosters Posters = new();
        public static AHInfo Mesa = new(0);
        public static AHInfo MissionRow = new(1);
        public static AHInfo Strawberry = new(2);
        public static AHInfo VinewoodWest = new(3);
        public static AHInfo Cypress = new(4);
        public static AHInfo DelPerro = new(5);
        public static AHInfo Airport = new(6);
        public static AHInfo Elysian = new(7);
        public static AHInfo Vinewood = new(8);
        public static AHInfo Vespucci = new(9);

        public void LoadDefault()
        {

            Enabled = true;

            Interior.Name.Set(Interior.Name.Galaxy);

            Interior.Style.Set(Interior.Style.Edgy);


            Interior.Podium.Set(Interior.Podium.Edgy);

            Interior.Speakers.Set(Interior.Speakers.Upgrade);


            Interior.Security.Set(Interior.Security.On);


            Interior.TurnTables.Set(Interior.TurnTables.style01);

            Interior.Lights.Bands.Set(Interior.Lights.Bands.Colore4);


            Interior.Bar.Enable(true);


            Interior.Booze.Enable(Interior.Booze.A, true);
            Interior.Booze.Enable(Interior.Booze.B, true);
            Interior.Booze.Enable(Interior.Booze.C, true);

            Interior.Trophy.Enable(Interior.Trophy.Number1, true, NightInterior.Trofei.Colors.Gold);

            API.RefreshInterior(InteriorId);


            // Exterior IPL

            Mesa.Barriere.Enable(true);

            Mesa.Poster.Enable(Posters.Dixon, true);
            Mesa.Poster.Enable(Posters.Madonna, true);
            Mesa.Poster.Enable(Posters.Solomun, true);
            Mesa.Poster.Enable(Posters.TaleOfUs, true);
            Mesa.Poster.Enable(Posters.ForSale, false);


            MissionRow.Barriere.Enable(true);

            MissionRow.Poster.Enable(Posters.Dixon, true);
            MissionRow.Poster.Enable(Posters.Madonna, true);
            MissionRow.Poster.Enable(Posters.Solomun, true);
            MissionRow.Poster.Enable(Posters.TaleOfUs, true);
            MissionRow.Poster.Enable(Posters.ForSale, false);


            Strawberry.Barriere.Enable(true);

            Strawberry.Poster.Enable(Posters.Dixon, true);
            Strawberry.Poster.Enable(Posters.Madonna, true);
            Strawberry.Poster.Enable(Posters.Solomun, true);
            Strawberry.Poster.Enable(Posters.TaleOfUs, true);
            Strawberry.Poster.Enable(Posters.ForSale, false);


            VinewoodWest.Barriere.Enable(true);

            VinewoodWest.Poster.Enable(Posters.Dixon, true);
            VinewoodWest.Poster.Enable(Posters.Madonna, true);
            VinewoodWest.Poster.Enable(Posters.Solomun, true);
            VinewoodWest.Poster.Enable(Posters.TaleOfUs, true);
            VinewoodWest.Poster.Enable(Posters.ForSale, false);


            Cypress.Barriere.Enable(true);

            Cypress.Poster.Enable(Posters.Dixon, true);
            Cypress.Poster.Enable(Posters.Madonna, true);
            Cypress.Poster.Enable(Posters.Solomun, true);
            Cypress.Poster.Enable(Posters.TaleOfUs, true);
            Cypress.Poster.Enable(Posters.ForSale, false);


            DelPerro.Barriere.Enable(true);

            DelPerro.Poster.Enable(Posters.Dixon, true);
            DelPerro.Poster.Enable(Posters.Madonna, true);
            DelPerro.Poster.Enable(Posters.Solomun, true);
            DelPerro.Poster.Enable(Posters.TaleOfUs, true);
            DelPerro.Poster.Enable(Posters.ForSale, false);


            Airport.Barriere.Enable(true);

            Airport.Poster.Enable(Posters.Dixon, true);
            Airport.Poster.Enable(Posters.Madonna, true);
            Airport.Poster.Enable(Posters.Solomun, true);
            Airport.Poster.Enable(Posters.TaleOfUs, true);
            Airport.Poster.Enable(Posters.ForSale, false);


            Elysian.Barriere.Enable(true);

            Elysian.Poster.Enable(Posters.Dixon, true);
            Elysian.Poster.Enable(Posters.Madonna, true);
            Elysian.Poster.Enable(Posters.Solomun, true);
            Elysian.Poster.Enable(Posters.TaleOfUs, true);
            Elysian.Poster.Enable(Posters.ForSale, false);


            Vinewood.Barriere.Enable(true);

            Vinewood.Poster.Enable(Posters.Dixon, true);
            Vinewood.Poster.Enable(Posters.Madonna, true);
            Vinewood.Poster.Enable(Posters.Solomun, true);
            Vinewood.Poster.Enable(Posters.TaleOfUs, true);
            Vinewood.Poster.Enable(Posters.ForSale, false);


            Vespucci.Barriere.Enable(true);

            Vespucci.Poster.Enable(Posters.Dixon, true);
            Vespucci.Poster.Enable(Posters.Madonna, true);
            Vespucci.Poster.Enable(Posters.Solomun, true);
            Vespucci.Poster.Enable(Posters.TaleOfUs, true);
            Vespucci.Poster.Enable(Posters.ForSale, false);
        }
    }
}
