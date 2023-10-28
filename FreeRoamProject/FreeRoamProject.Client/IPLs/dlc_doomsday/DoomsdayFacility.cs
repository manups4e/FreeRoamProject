using System.Collections.Generic;

namespace FreeRoamProject.Client.IPLs.dlc_doomsday
{
    public class DoomsdayFacility
    {
        public static int InteriorId = 269313;

        public static DInterior Interior = new();
        public static DExterior Exterior = new();
        public static DWalls Walls = new();
        public static DDecals Decals = new();
        public static DLounge Lounge = new();
        public static DSleeping Sleeping = new();
        public static DSecurity Security = new();
        public static DCannon Cannon = new();
        public static DPrivacyGlass PrivacyGlass = new();
        public static DDetailsFacility Details = new();
        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                IplManager.EnableInterior(InteriorId, value);
                Exterior.Enabled = value;
                Interior.Enabled = value;
            }
        }

        public static void LoadDefault()
        {
            Exterior.Enabled = true;
            Interior.Enabled = true;

            Walls.SetColor(AvengerColors.Utility);
            Decals.Set(Decals.style01);
            Lounge.Set(Lounge.Presser, AvengerColors.Utility);
            Sleeping.Set(Sleeping.Presser, AvengerColors.Utility);
            Security.Set(Security.On, AvengerColors.Utility);
            Cannon.Set(Cannon.On, AvengerColors.Utility);

            // Privacy glass remote
            PrivacyGlass.BedRoom.Control.Enable(true);
            PrivacyGlass.Lounge.Control.Enable(true);

            Details.Enable(Details.CrewEmblem, false);

            Details.Enable(Details.AvengerParts, true);

            Details.Enable(Details.Outfits.Foundry, true);
            Details.Enable(Details.Outfits.Iaa, true);
            Details.Enable(Details.Outfits.Khanjali, true);
            Details.Enable(Details.Outfits.Morgue, true);
            Details.Enable(Details.Outfits.Paramedic, true);
            Details.Enable(Details.Outfits.Predator, true);
            Details.Enable(Details.Outfits.Riot, true);
            Details.Enable(Details.Outfits.ServerFarm, true);
            Details.Enable(Details.Outfits.StealAvenger, true);
            Details.Enable(Details.Outfits.Stromberg, true);
            Details.Enable(Details.Outfits.Submarine, true);
            Details.Enable(Details.Outfits.Volatol, true);

            Details.Enable(Details.Trophies.Eagle, true);
            Details.Enable(Details.Trophies.Iaa, true);
            Details.Enable(Details.Trophies.Submarine, true);

            Details.Trophies.SetColor(AvengerColors.Utility);

            Details.Enable(new List<string>() { Details.Clutter.A, Details.Clutter.B }, true);

            API.RefreshInterior(InteriorId);
        }
    }

    public class DInterior
    {
        private bool _enabled = false;
        public string ipl = "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_";
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
                IplManager.SetIplPropState(DoomsdayFacility.InteriorId, "set_int_02_shell", true, true);
            }
        }
    }
    public class DExterior
    {
        private bool _enabled = false;
        public List<string> ipl = new List<string>()
            {
                "xm_hatch_01_cutscene",         // 1286.924 2846.06 49.39426
				"xm_hatch_02_cutscene",         // 18.633 2610.834 86.0
				"xm_hatch_03_cutscene",         // 2768.574 3919.924 45.82
				"xm_hatch_04_cutscene",         // 3406.90 5504.77 26.28
				"xm_hatch_06_cutscene",         // 1.90 6832.18 15.82
				"xm_hatch_07_cutscene",         // -2231.53 2418.42 12.18
				"xm_hatch_08_cutscene",         // -6.92 3327.0 41.63
				"xm_hatch_09_cutscene",         // 2073.62 1748.77 104.51
				"xm_hatch_10_cutscene",         // 1874.35 284.34 164.31
				"xm_hatch_closed",              // Closed hatches (all)
				"xm_siloentranceclosed_x17",    // Closed silo: 598.4869 5556.846 716.7615
				"xm_bunkerentrance_door",       // Bunker entrance closed door: 2050.85 2950.0 47.75
				"xm_hatches_terrain",           // Terrain adjustments for facilities (all) + silo
				"xm_hatches_terrain_lod",
            };
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }
    }
    public class DDecals
    {
        public string None = "";
        public string style01 = "set_int_02_decal_01"; public string style02 = "set_int_02_decal_02"; public string style03 = "set_int_02_decal_03";
        public string style04 = "set_int_02_decal_04"; public string style05 = "set_int_02_decal_05"; public string style06 = "set_int_02_decal_06";
        public string style07 = "set_int_02_decal_07"; public string style08 = "set_int_02_decal_08"; public string style09 = "set_int_02_decal_09";

        public void Set(string decal, bool refresh = true)
        {
            Clear(false);
            if (decal != None)
                IplManager.SetIplPropState(DoomsdayFacility.InteriorId, decal, true, refresh);
            else
            {
                if (refresh) API.RefreshInterior(DoomsdayFacility.InteriorId);
            }
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_decal_01", "set_int_02_decal_02", "set_int_02_decal_03", "set_int_02_decal_04", "set_int_02_decal_05", "set_int_02_decal_06", "set_int_02_decal_07", "set_int_02_decal_08", "set_int_02_decal_09" }, false, refresh);
        }
    }

    public class DLounge
    {
        public string Utility = "set_int_02_lounge1"; public string Prestige = "set_int_02_lounge2"; public string Presser = "set_int_02_lounge3";
        public void Set(string lounge, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, lounge, true, refresh);
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, lounge, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_lounge1", "set_int_02_lounge2", "set_int_02_lounge3" }, false, refresh);
        }
    }

    public class DSleeping
    {
        public string None = "set_int_02_no_sleep";
        public string Utility = "set_int_02_sleep"; public string Prestige = "set_int_02_sleep2"; public string Presser = "set_int_02_sleep3";
        public void Set(string sleep, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, sleep, true, refresh);
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, sleep, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_sleep", "set_int_02_sleep2", "set_int_02_sleep3" }, false, refresh);
        }
    }

    public class DSecurity
    {
        public string Off = "set_int_02_no_security";
        public string On = "set_int_02_security";
        public void Set(string security, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, security, true, refresh);
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, security, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_no_security", "set_int_02_security" }, false, refresh);
        }
    }
    public class DCannon
    {
        public string Off = "set_int_02_no_cannon";
        public string On = "set_int_02_cannon";
        public void Set(string security, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, security, true, refresh);
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, security, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_no_cannon", "set_int_02_cannon" }, false, refresh);
        }
    }

    public class DPrivacyGlass
    {
        public static int ControlModelHash = Functions.HashInt("xm_prop_x17_tem_control_01");

        public PGBedRoom BedRoom = new PGBedRoom();
        public PGLounge Lounge = new PGLounge();
    }

    public class PGBedRoom
    {
        public async void Enable(bool state)
        {
            int handle = API.GetClosestObjectOfType(367.99f, 4827.745f, -59.0f, 1.0f, Functions.HashUint("xm_prop_x17_l_glass_03"), false, false, false);

            if (state)
            {
                if (handle == 0)
                {
                    int model = Functions.HashInt("xm_prop_x17_l_glass_03");
                    API.RequestModel((uint)model);
                    while (!API.HasModelLoaded((uint)model)) await BaseScript.Delay(0);

                    int PrivacyGlass = API.CreateObject(model, 367.99f, 4827.745f, -59.0f, false, false, false);
                    API.SetEntityAsMissionEntity(PrivacyGlass, true, false);
                    API.SetEntityCollision_2(PrivacyGlass, false, false);
                    API.SetEntityInvincible(PrivacyGlass, true);
                    API.SetEntityAlpha(PrivacyGlass, 254, 0);
                }
            }
            else
            {
                if (handle != 0)
                {
                    API.SetEntityAsMissionEntity(handle, false, false);
                    API.DeleteEntity(ref handle);
                }
            }
        }
        public class Controls
        {
            Vector3 Position = new Vector3(372.115f, 4827.504f, -58.47f);
            Vector3 Rotation = new Vector3(0);

            public async void Enable(bool state)
            {
                int handle = API.GetClosestObjectOfType(Position.X, Position.Y, Position.Z, 1.0f, (uint)DPrivacyGlass.ControlModelHash, false, false, false);

                if (state)
                {
                    if (handle == 0)
                    {
                        API.RequestModel((uint)DPrivacyGlass.ControlModelHash);
                        while (!API.HasModelLoaded((uint)DPrivacyGlass.ControlModelHash)) await BaseScript.Delay(0);

                        int PrivacyGlass = API.CreateObjectNoOffset((uint)DPrivacyGlass.ControlModelHash, Position.X, Position.Y, Position.Z, true, true, false);
                        API.SetEntityRotation(PrivacyGlass, Rotation.X, Rotation.Y, Rotation.Z, 2, true);
                        API.FreezeEntityPosition(PrivacyGlass, true);
                        API.SetEntityAsMissionEntity(PrivacyGlass, false, false);
                    }
                }
                else
                {
                    if (handle != 0)
                    {
                        API.SetEntityAsMissionEntity(handle, false, false);
                        API.DeleteEntity(ref handle);
                    }
                }
            }
        }
        public Controls Control = new Controls();
    }

    public class PGLounge
    {

        public List<Glass> Glasses = new List<Glass>()
                {
                    new Glass(Functions.HashInt("xm_prop_x17_l_door_glass_01"), Functions.HashInt("xm_prop_x17_l_door_frame_01"), new Vector3(359.22f, 4846.043f, -58.85f)),
                    new Glass(Functions.HashInt("xm_prop_x17_l_door_glass_01"), Functions.HashInt("xm_prop_x17_l_door_frame_01"), new Vector3(369.066f, 4846.273f, -58.85f)),
                    new Glass(Functions.HashInt("xm_prop_x17_l_glass_01"), Functions.HashInt("xm_prop_x17_l_frame_01"), new Vector3(358.843f, 4845.103f, -60.0f)),
                    new Glass(Functions.HashInt("xm_prop_x17_l_glass_02"), Functions.HashInt("xm_prop_x17_l_frame_02"), new Vector3(366.309f, 4847.281f, -60.0f)),
                    new Glass(Functions.HashInt("xm_prop_x17_l_glass_03"), Functions.HashInt("xm_prop_x17_l_frame_03"), new Vector3(371.194f, 4841.27f, -60.0f)),
                };

        public async void Enable(bool state)
        {
            foreach (Glass glass in Glasses)
            {
                int handle = API.GetClosestObjectOfType(glass.EntityPos.X, glass.EntityPos.Y, glass.EntityPos.Z, 1.0f, (uint)glass.ModelHash, false, false, false);

                if (state)
                {
                    if (handle == 0)
                    {
                        int entityToAttach = API.GetClosestObjectOfType(glass.EntityPos.X, glass.EntityPos.Y, glass.EntityPos.Z, 1.0f, (uint)glass.EntityHash, false, false, false);
                        if (entityToAttach != 0)
                        {
                            API.RequestModel((uint)glass.ModelHash);
                            while (!API.HasModelLoaded((uint)glass.ModelHash)) await BaseScript.Delay(0);

                            int PrivacyGlass = API.CreateObject(glass.ModelHash, glass.EntityPos.X, glass.EntityPos.Y, glass.EntityPos.Z, false, false, false);
                            API.SetEntityAsMissionEntity(PrivacyGlass, true, false);
                            API.SetEntityCollision_2(PrivacyGlass, false, false);
                            API.SetEntityInvincible(PrivacyGlass, true);
                            API.SetEntityAlpha(PrivacyGlass, 254, 0);
                            API.AttachEntityToEntity(PrivacyGlass, entityToAttach, -1, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false, false, false, false, 2, true);
                        }

                    }
                }
                else
                {
                    if (handle != 0)
                    {
                        API.SetEntityAsMissionEntity(handle, false, false);
                        API.DeleteEntity(ref handle);
                    }
                }
            }
        }

        public Controls Control = new Controls();
    }
    public class Glass
    {
        public int ModelHash;
        public int EntityHash;
        public Vector3 EntityPos;
        public Glass(int model, int entity, Vector3 pos)
        {
            ModelHash = model;
            EntityHash = entity;
            EntityPos = pos;
        }
    }

    public class Controls
    {
        Vector3 Position = new Vector3(367.317f, 4846.729f, -58.448f);
        Vector3 Rotation = new Vector3(0, 0, -16f);

        public async void Enable(bool state)
        {
            int handle = API.GetClosestObjectOfType(Position.X, Position.Y, Position.Z, 1.0f, (uint)DPrivacyGlass.ControlModelHash, false, false, false);

            if (state)
            {
                if (handle == 0)
                {
                    API.RequestModel((uint)DPrivacyGlass.ControlModelHash);
                    while (!API.HasModelLoaded((uint)DPrivacyGlass.ControlModelHash)) await BaseScript.Delay(0);

                    int PrivacyGlass = API.CreateObjectNoOffset((uint)DPrivacyGlass.ControlModelHash, Position.X, Position.Y, Position.Z, true, true, false);
                    API.SetEntityRotation(PrivacyGlass, Rotation.X, Rotation.Y, Rotation.Z, 2, true);
                    API.FreezeEntityPosition(PrivacyGlass, true);
                    API.SetEntityAsMissionEntity(PrivacyGlass, false, false);
                }
            }
            else
            {
                if (handle != 0)
                {
                    API.SetEntityAsMissionEntity(handle, false, false);
                    API.DeleteEntity(ref handle);
                }
            }
        }
    }

    public class DDetailsFacility
    {
        public List<string> KhanjaliParts = new List<string>() { "Set_Int_02_Parts_Panther1", "Set_Int_02_Parts_Panther2", "Set_Int_02_Parts_Panther3" };
        public List<string> RiotParts = new List<string>() { "Set_Int_02_Parts_Riot1", "Set_Int_02_Parts_Riot2", "Set_Int_02_Parts_Riot3" };
        public List<string> ChenoParts = new List<string>() { "Set_Int_02_Parts_Cheno1", "Set_Int_02_Parts_Cheno2", "Set_Int_02_Parts_Cheno3" };
        public List<string> ThrusterParts = new List<string>() { "Set_Int_02_Parts_Thruster1", "Set_Int_02_Parts_Thruster2", "Set_Int_02_Parts_Thruster3" };
        public List<string> AvengerParts = new List<string>() { "Set_Int_02_Parts_Avenger1", "Set_Int_02_Parts_Avenger2", "Set_Int_02_Parts_Avenger3" };
        public Outfit Outfits = new Outfit();
        public Trophiess Trophies = new Trophiess();

        public Clutters Clutter = new Clutters();
        public string CrewEmblem = "set_int_02_crewemblem";

        public void Enable(List<string> detail, bool state = true, bool refresh = true)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, detail, state, refresh);
        }
        public void Enable(string detail, bool state = true, bool refresh = true)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, detail, state, refresh);
        }
    }
    public class Outfit
    {
        public string Paramedic = "Set_Int_02_outfit_paramedic"; public string Morgue = "Set_Int_02_outfit_morgue"; public string ServerFarm = "Set_Int_02_outfit_serverfarm";
        public string Iaa = "Set_Int_02_outfit_iaa"; public string StealAvenger = "Set_Int_02_outfit_steal_avenger"; public string Foundry = "Set_Int_02_outfit_foundry";
        public string Riot = "Set_Int_02_outfit_riot_van"; public string Stromberg = "Set_Int_02_outfit_stromberg"; public string Submarine = "Set_Int_02_outfit_sub_finale";
        public string Predator = "Set_Int_02_outfit_predator"; public string Khanjali = "Set_Int_02_outfit_khanjali"; public string Volatol = "Set_Int_02_outfit_volatol";
    }
    public class Trophiess
    {
        public string Eagle = "set_int_02_trophy1"; public string Iaa = "set_int_02_trophy_iaa"; public string Submarine = "set_int_02_trophy_sub";

        public void Set(string trofeo, AvengerColors color, bool refresh = true)
        {
            Clear(false);
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, trofeo, true, refresh);
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, trofeo, (int)color);
        }
        public void Clear(bool refresh)
        {
            IplManager.SetIplPropState(DoomsdayFacility.InteriorId, new List<string>() { "set_int_02_trophy1", "set_int_02_trophy_iaa", "set_int_02_trophy_sub" }, false, refresh);
        }
        public void SetColor(AvengerColors color, bool refresh = true)
        {
            API.SetInteriorEntitySetColor(DoomsdayFacility.InteriorId, "set_int_02_trophy_sub", (int)color);
            if (refresh) API.RefreshInterior(DoomsdayFacility.InteriorId);
        }
    }
    public class Clutters
    {
        public string A = "set_int_02_clutter1"; public string B = "set_int_02_clutter2"; public string C = "set_int_02_clutter3"; public string D = "set_int_02_clutter4"; public string E = "set_int_02_clutter5";
    }

}
