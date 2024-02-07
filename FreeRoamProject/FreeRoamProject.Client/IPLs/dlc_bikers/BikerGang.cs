using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.IPLs.dlc_bikers
{
    public class BikerGang
    {
        public BikerName Name = new();
        public BikerEmblem Emblem = new();
        public static BikerClubHouse ClubHouse = new();

        public BikerGang()
        {
            ClubHouse.Members.President.Init();
            ClubHouse.Members.VicePresident.Init();
            ClubHouse.Members.RoadCaptain.Init();
            ClubHouse.Members.Enforcer.Init();
            ClubHouse.Members.SergeantAtArms.Init();
            ClubHouse.ClubName.Init();
            ClubHouse.Emblem.Init();
            ClubHouse.MissionWall.Init();
            ClientMain.Instance.AddTick(BikerGangTick);
        }

        public async Task BikerGangTick()
        {
            if (ClubHouse.ClubName.NeedToLoad ||
                ClubHouse.Emblem.NeedToLoad ||
                ClubHouse.MissionWall.NeedToLoad ||
                ClubHouse.Members.President.NeedToLoad ||
                ClubHouse.Members.VicePresident.NeedToLoad ||
                ClubHouse.Members.RoadCaptain.NeedToLoad ||
                ClubHouse.Members.Enforcer.NeedToLoad ||
                ClubHouse.Members.SergeantAtArms.NeedToLoad)
            {
                if (IplManager.Global.Biker.isInsideClubhouse1 || IplManager.Global.Biker.isInsideClubhouse2)
                {
                    if (ClubHouse.ClubName.NeedToLoad)
                    {
                        DrawClubName(Name.Name, Name.Color, Name.Font);
                        ClubHouse.ClubName.Loaded = true;
                    }
                    else if (ClubHouse.ClubName.Loaded)
                    {
                        ClubHouse.ClubName.Clear();
                        ClubHouse.ClubName.Loaded = false;
                    }

                    if (ClubHouse.Emblem.NeedToLoad)
                    {
                        DrawEmblem(Emblem.Emblem, Emblem.Rot);
                        ClubHouse.Emblem.Loaded = true;
                    }
                    else if (ClubHouse.Emblem.Loaded)
                    {
                        ClubHouse.Emblem.Clear();
                        ClubHouse.Emblem.Loaded = false;
                    }

                    if (ClubHouse.MissionWall.NeedToLoad)
                    {
                        DrawMissions();
                        ClubHouse.MissionWall.Loaded = true;
                    }
                    else if (ClubHouse.MissionWall.Loaded)
                    {
                        ClubHouse.MissionWall.Clear();
                        ClubHouse.MissionWall.Loaded = false;
                    }

                    if (ClubHouse.Members.President.NeedToLoad)
                    {
                        DrawMember(ClubHouse.Members.President);
                        ClubHouse.Members.President.Loaded = true;
                    }
                    else if (ClubHouse.Members.President.Loaded)
                    {
                        ClubHouse.Members.President.Clear();
                        ClubHouse.Members.President.Loaded = false;
                    }

                    if (ClubHouse.Members.VicePresident.NeedToLoad)
                    {
                        DrawMember(ClubHouse.Members.VicePresident);
                        ClubHouse.Members.VicePresident.Loaded = true;
                    }
                    else if (ClubHouse.Members.President.Loaded)
                    {
                        ClubHouse.Members.VicePresident.Clear();
                        ClubHouse.Members.VicePresident.Loaded = false;
                    }

                    if (ClubHouse.Members.RoadCaptain.NeedToLoad)
                    {
                        DrawMember(ClubHouse.Members.RoadCaptain);
                        ClubHouse.Members.RoadCaptain.Loaded = true;
                    }
                    else if (ClubHouse.Members.RoadCaptain.Loaded)
                    {
                        ClubHouse.Members.RoadCaptain.Clear();
                        ClubHouse.Members.RoadCaptain.Loaded = false;
                    }

                    if (ClubHouse.Members.Enforcer.NeedToLoad)
                    {
                        DrawMember(ClubHouse.Members.Enforcer);
                        ClubHouse.Members.Enforcer.Loaded = true;
                    }
                    else if (ClubHouse.Members.Enforcer.Loaded)
                    {
                        ClubHouse.Members.Enforcer.Clear();
                        ClubHouse.Members.Enforcer.Loaded = false;
                    }

                    if (ClubHouse.Members.SergeantAtArms.NeedToLoad)
                    {
                        DrawMember(ClubHouse.Members.SergeantAtArms);
                        ClubHouse.Members.SergeantAtArms.Loaded = true;
                    }
                    else if (ClubHouse.Members.SergeantAtArms.Loaded)
                    {
                        ClubHouse.Members.SergeantAtArms.Clear();
                        ClubHouse.Members.SergeantAtArms.Loaded = false;
                    }
                }
                else await BaseScript.Delay(1000);
            }
            else await BaseScript.Delay(1000);
        }

        public static void DrawClubName(string name, int color, int font)
        {
            if (ClubHouse.ClubName.Stage == 0)
            {
                if (ClubHouse.ClubName.RenderId == -1)
                    ClubHouse.ClubName.RenderId = RenderTargets.CreateNamedRenderTargetForModel(ClubHouse.ClubName.Target, Functions.HashUint(ClubHouse.ClubName.Prop));
                if (ClubHouse.ClubName.MovieId == -1)
                    ClubHouse.ClubName.MovieId = API.RequestScaleformMovie("CLUBHOUSE_NAME");
                ClubHouse.ClubName.Stage = 1;
            }
            else if (ClubHouse.ClubName.Stage == 1)
            {
                if (API.HasScaleformMovieLoaded(ClubHouse.ClubName.MovieId))
                {
                    API.BeginScaleformMovieMethod(ClubHouse.ClubName.MovieId, "SET_CLUBHOUSE_NAME");
                    API.ScaleformMovieMethodAddParamTextureNameString(name);
                    API.ScaleformMovieMethodAddParamInt(color);
                    API.ScaleformMovieMethodAddParamInt(font);
                    API.EndScaleformMovieMethod();
                    ClubHouse.ClubName.Stage = 2;
                }
                else
                    ClubHouse.ClubName.MovieId = API.RequestScaleformMovie("CLUBHOUSE_NAME");
            }
            else if (ClubHouse.ClubName.Stage == 2)
            {
                API.SetTextRenderId(ClubHouse.ClubName.RenderId);
                API.SetUiLayer(4);
                API.N_0xc6372ecd45d73bcd(true);
                API.ScreenDrawPositionBegin(73, 73);
                API.DrawScaleformMovie(ClubHouse.ClubName.MovieId, 0.0975f, 0.105f, 0.235f, 0.35f, 255, 255, 255, 255, 0);
                API.SetTextRenderId(API.GetDefaultScriptRendertargetRenderId());
                API.ScreenDrawPositionEnd();
            }
        }

        public static async void DrawEmblem(string texturesDict, float rotation)
        {
            if (ClubHouse.Emblem.Stage == 0)
            {
                if (ClubHouse.Emblem.RenderId == -1)
                    ClubHouse.Emblem.RenderId = RenderTargets.CreateNamedRenderTargetForModel(ClubHouse.Emblem.Target, Functions.HashUint(ClubHouse.Emblem.Prop));
                bool IsTextureDictLoaded = await IplManager.LoadStreamedTextureDict(texturesDict);
                if (!IsTextureDictLoaded) ClientMain.Logger.Error("Impossibile caricare texture riga 506 bikerGang.cs");
                ClubHouse.Emblem.Stage = 1;
            }
            else if (ClubHouse.Emblem.Stage == 1)
            {
                ClubHouse.Emblem.RenderId = RenderTargets.CreateNamedRenderTargetForModel(ClubHouse.Emblem.Target, Functions.HashUint(ClubHouse.Emblem.Prop));
                ClubHouse.Emblem.Stage = 2;
            }
            else if (ClubHouse.Emblem.Stage == 2)
            {
                API.SetTextRenderId(ClubHouse.Emblem.RenderId);
                API.ScreenDrawPositionBegin(73, 73);
                API.SetUiLayer(4);
                API.N_0xc6372ecd45d73bcd(true);
                API.N_0x2bc54a8188768488(texturesDict, texturesDict, 0.5f, 0.5f, 1.0f, 1.0f, rotation, 255, 255, 255, 255); ;
                API.ScreenDrawPositionEnd();
                API.SetTextRenderId(API.GetDefaultScriptRendertargetRenderId());
            }
        }

        public static void DrawMissions()
        {
            if (ClubHouse.MissionWall.Stage == 0)
            {
                if (ClubHouse.MissionWall.RenderId == -1)
                    ClubHouse.MissionWall.RenderId = RenderTargets.CreateNamedRenderTargetForModel(ClubHouse.MissionWall.Target, Functions.HashUint(ClubHouse.MissionWall.Prop));
                ClubHouse.MissionWall.Stage = 1;
            }
            else if (ClubHouse.MissionWall.Stage == 1)
            {
                if (API.HasScaleformMovieLoaded(ClubHouse.MissionWall.MovieId))
                    ClubHouse.MissionWall.Stage = 2;
                else
                    ClubHouse.MissionWall.MovieId = API.RequestScaleformMovie("BIKER_MISSION_WALL");
            }
            else if (ClubHouse.MissionWall.Stage == 2)
            {
                API.SetTextRenderId(ClubHouse.MissionWall.RenderId);
                API.SetUiLayer(4);
                API.N_0xc6372ecd45d73bcd(false);
                API.DrawScaleformMovie(ClubHouse.MissionWall.MovieId, 0.5f, 0.5f, 1.0f, 1.0f, 255, 255, 255, 255, 0);
                API.SetTextRenderId(API.GetDefaultScriptRendertargetRenderId());
                API.N_0xe6a9f00d4240b519(ClubHouse.MissionWall.MovieId, true);
            }
        }

        public static void DrawMember(Member member)
        {
            if (member.Stage == 0)
                member.Stage = 1;
            else if (member.Stage == 1)
            {
                member.RenderId = RenderTargets.CreateNamedRenderTargetForModel(member.Target, Functions.HashUint(member.Prop));
                member.Stage = 2;
            }
            else if (member.Stage == 2)
            {
                if (API.HasStreamedTextureDictLoaded(member.TextureDict))
                {
                    API.SetTextRenderId(member.RenderId);
                    API.ScreenDrawPositionBegin(73, 73);
                    API.N_0x2bc54a8188768488(member.TextureDict, member.TextureDict, 0.5f, 0.5f, 1.0f, 1.0f, 0.0f, 255, 255, 255, 255);
                    API.ScreenDrawPositionEnd();
                    API.SetTextRenderId(API.GetDefaultScriptRendertargetRenderId());
                }
            }
        }
    }
    public class BikerName
    {
        public enum Colors { Black = 0, Grey = 1, White = 2, Orange = 3, Red = 4, Green = 5, Yellow = 6, Blue = 7 }
        public enum Fonts { Font1 = 0, Font2 = 1, Font3 = 2, Font4 = 3, Font5 = 4, Font6 = 5, Font7 = 6, Font = 7, Font9 = 8, Font10 = 9, Font11 = 10, Fon12 = 11, Font13 = 12 }

        public string Name = "";
        public int Color = 0;
        public int Font = 0;
        public void Set(string name, Colors color, Fonts font)
        {
            Name = name;
            Color = (int)color;
            Font = (int)font;
        }
    }

    public class BikerEmblem
    {
        public string Eagle = "MPClubPreset1";
        public string Skull = "MPClubPreset2";
        public string Ace = "MPClubPreset3";
        public string BrassKnuckles = "MPClubPreset4";
        public string UR = "MPClubPreset5";
        public string Fox = "MPClubPreset6";
        public string City = "MPClubPreset7";
        public string Dices = "MPClubPreset8";
        public string Target = "MPClubPreset9";

        public string Emblem = "MPClubPreset1";
        public float Rot = 90f;
        public void Set(string logo, float rotation)
        {
            Emblem = logo;
            Rot = rotation;
            BikerGang.ClubHouse.Emblem.Stage = 0;
        }
    }

    public class BikerClubHouse
    {
        public int InteriorId1 = 246273;
        public int InteriorId2 = 246529;
        public BEmblem Emblem = new();
        public BMembers Members = new();
        public BClubName ClubName = new();
        public BMissionWalls MissionWall = new();
        public void ClearAll()
        {
            ClubName.Clear();
            ClubName.Loaded = false;
            Emblem.Clear();
            Emblem.Loaded = false;
            MissionWall.Clear();
            MissionWall.Loaded = false;

            Members.President.Clear();
            Members.VicePresident.Clear();
            Members.RoadCaptain.Clear();
            Members.Enforcer.Clear();
            Members.SergeantAtArms.Clear();
            Members.President.Loaded = false;
            Members.VicePresident.Loaded = false;
            Members.RoadCaptain.Loaded = false;
            Members.Enforcer.Loaded = false;
            Members.SergeantAtArms.Loaded = false;

        }
    }
    public class BMembers
    {
        public Member President = new("memorial_wall_president", "bkr_prop_rt_memorial_president");
        public Member VicePresident = new("memorial_wall_vice_president", "bkr_prop_rt_memorial_vice_pres");
        public Member RoadCaptain = new("memorial_wall_active_01", "bkr_prop_rt_memorial_active_01");
        public Member Enforcer = new("memorial_wall_active_02", "bkr_prop_rt_memorial_active_02");
        public Member SergeantAtArms = new("memorial_wall_active_03", "bkr_prop_rt_memorial_active_03");

        public async void Set(Member member, Ped ped)
        {
            member.Clear();
            Tuple<int, string> mugshot = await Core.Utility.Functions.GetPedMugshotAsync(ped);
            member.PedHeadshot = mugshot.Item1;
            member.TextureDict = mugshot.Item2;
            bool IsTextureDictLoaded = await IplManager.LoadStreamedTextureDict(member.TextureDict);
            if (!IsTextureDictLoaded) ClientMain.Logger.Error("Errore a caricare la texture del biker");
        }
        public void Clear(Member member)
        {
            if (API.IsNamedRendertargetRegistered(member.Target))
                API.ReleaseNamedRendertarget(member.Target);
            if (member.PedHeadshot != -1)
                API.UnregisterPedheadshot(member.PedHeadshot);
            if (member.TextureDict != "")
                API.SetStreamedTextureDictAsNoLongerNeeded(member.TextureDict);
        }
    }
    public class Member
    {
        public bool NeedToLoad = false;
        public bool Loaded = false;
        public int RenderId = -1;
        public string TextureDict;
        public int PedHeadshot = -1;
        public string Target;
        public string Prop;
        public int Stage = 0;
        public Member(string target, string prop)
        {
            Target = target;
            Prop = prop;
        }
        public void Init()
        {
            IplManager.DrawEmptyRect(Target, Core.Utility.Functions.HashUint(Prop));
        }
        public void Enable(bool state)
        {
            NeedToLoad = state;
        }
        public void Set(Ped ped)
        {
            BikerGang.ClubHouse.Members.Set(this, ped);
        }
        public void Clear()
        {
            BikerGang.ClubHouse.Members.Clear(this);
        }
    }

    public class BClubName
    {
        public bool NeedToLoad = false;
        public bool Loaded = false;
        public string Target = "clubname_blackboard_01a";
        public string Prop = "bkr_prop_clubhouse_blackboard_01a";
        public int RenderId = -1;
        public int MovieId = -1;
        public int Stage = 0;
        public void Init()
        {
            IplManager.DrawEmptyRect(Target, Functions.HashUint(Prop));
        }
        public void Enable(bool state)
        {
            NeedToLoad = state;
        }
        public void Clear()
        {
            if (API.IsNamedRendertargetRegistered(Target))
                API.ReleaseNamedRendertarget(Target);
            if (API.HasScaleformMovieLoaded(MovieId))
                API.SetScaleformMovieAsNoLongerNeeded(ref MovieId);
            RenderId = -1;
            MovieId = -1;
            Stage = 0;
        }
    }
    public class BEmblem
    {
        public bool NeedToLoad = false;
        public bool Loaded = false;
        public string Target = "clubhouse_table";
        public string Prop = "bkr_prop_rt_clubhouse_table";
        public int RenderId = -1;
        public string MovieName;
        public int MovieId = -1;
        public int Stage = 0;
        public void Init()
        {
            IplManager.DrawEmptyRect(Target, Core.Utility.Functions.HashUint(Prop));
        }
        public void Enable(bool state)
        {
            NeedToLoad = state;
        }
        public void Clear()
        {
            if (API.IsNamedRendertargetRegistered(Target))
                API.ReleaseNamedRendertarget(Target);
            RenderId = -1;
            Stage = 0;
        }
    }
    public class BMissionWalls
    {
        public bool NeedToLoad = false;
        public bool Loaded = false;
        public string Target = "clubhouse_Plan_01a";
        public string Prop = "bkr_prop_rt_clubhouse_plan_01a";
        public int RenderId = -1;
        public string MovieName;
        public int MovieId = -1;
        public int Stage = 0;
        public enum BPosition
        {
            none = -1,
            left = 0,
            center = 1,
            right = 2
        }
        public void Init()
        {
            IplManager.DrawEmptyRect(Target, Core.Utility.Functions.HashUint(Prop));
        }
        public void Enable(bool state)
        {
            NeedToLoad = state;
        }
        public void SelectMission(BPosition position)
        {
            API.BeginScaleformMovieMethod(MovieId, "SET_SELECTED_MISSION");
            API.PushScaleformMovieMethodParameterInt((int)position); // Mission index 0 to 2(-1 = no mission)
            API.EndScaleformMovieMethod();
        }
        public async void SetMission(BPosition position, string name = null, string desc = null, string textdict = null, float x = 0, float y = 0)
        {
            if (NeedToLoad)
            {
                if (!API.HasScaleformMovieLoaded(MovieId))
                {
                    MovieId = API.RequestScaleformMovie("BIKER_MISSION_WALL");
                    while (!API.HasScaleformMovieLoaded(MovieId)) await BaseScript.Delay(0);
                    if (MovieId != -1)
                    {
                        if ((int)position > -1)
                        {
                            API.BeginScaleformMovieMethod(MovieId, "SET_MISSION");
                            API.PushScaleformMovieMethodParameterInt((int)position);        // Mission index 0 to 2(-1 = no mission);
                            API.PushScaleformMovieMethodParameterString(name);
                            API.PushScaleformMovieMethodParameterString(desc);
                            API.PushScaleformMovieMethodParameterButtonName(textdict);
                            API.PushScaleformMovieMethodParameterFloat(x);      // Mission 0: world coordinates X
                            API.PushScaleformMovieMethodParameterFloat(y);      // Mission 0: world coordinates Y
                            API.EndScaleformMovieMethod();
                        }
                        else
                        {
                            RemoveMission(BPosition.none);
                            RemoveMission(BPosition.left);
                            RemoveMission(BPosition.center);
                            RemoveMission(BPosition.right);
                            SelectMission(BPosition.none);
                        }
                    }
                }
            }
        }
        public void RemoveMission(BPosition pos)
        {
            API.BeginScaleformMovieMethod(MovieId, "HIDE_MISSION");
            API.PushScaleformMovieMethodParameterInt((int)pos);
            API.EndScaleformMovieMethod();
        }
        public void Clear()
        {
            SelectMission(BPosition.none);
            SetMission(BPosition.none);
            if (API.IsNamedRendertargetRegistered(Prop))
                API.ReleaseNamedRendertarget(Prop);
            if (API.HasScaleformMovieLoaded(MovieId))
                API.SetScaleformMovieAsNoLongerNeeded(ref MovieId);
            // Resetting
            RenderId = -1;
            MovieId = -1;
            Stage = 0;

        }
    }
    public class Missions
    {
        public BTitles Titles = new();
        public BPictures Pictures = new();
        public BDescriptions Descriptions = new();
    }
    public class BTitles
    {
        public string byThePoundUpper = "BDEAL_DEALN";
        public string byThePound = "DEAL_DEALN";
        public string prisonerOfWarUpper = "BIGM_RESCN";
        public string prisonerOfWar = "CELL_BIKER_RESC";
        public string gunsForHire = "LR_INTRO_ST";
        public string weaponOfChoice = "CELL_BIKER_CK";
        public string gunrunningUpper = "GB_BIGUNLOAD_U";
        public string gunrunning = "GB_BIGUNLOAD_T";
        public string nineTenthsOfTheLawUpper = "SB_INTRO_TITLE";
        public string nineTenthsOfTheLaw = "SB_MENU_TITLE";
        public string jailbreakUpper = "FP_INTRO_TITLE";
        public string jailbreak = "FP_MENU_TITLE";
        public string crackedUpper = "SC_INTRO_TITLE";
        public string cracked = "SC_MENU_TITLE";
        public string fragileGoodsUpper = "DV_SH_BIG";
        public string fragileGoods = "DV_SH_TITLE";
        public string torchedUpper = "BA_SH_BIG";
        public string torched = "BA_SH_TITLE";
        public string outriderUpper = "SHU_SH_BIG";
        public string outrider = "SHU_SH_TITLE";
    }
    public class BDescriptions
    {
        public string byThePound = "DEAL_DEALND";
        public string prisonerOfWar = "CELL_BIKER_RESD";
        public string gunsForHire = "GFH_MENU_DESC";
        public string weaponOfChoice = "CELL_BIKER_CKD";
        public string gunrunning = "GB_BIGUNLOAD_D";
        public string nineTenthsOfTheLaw = "SB_MENU_DESC";
        public string jailbreak = "FP_MENU_DESC";
        public string cracked = "SC_MENU_DESC";
        public string fragileGoods = "DV_MENU_DESC";
        public string torched = "BA_MENU_DESC";
        public string outrider = "SHU_MENU_DESC";
    }
    public class BPictures
    {
        public string byThePound = "CHM_IMG0";          // Pickup car parked
        public string prisonerOfWar = "CHM_IMG8";           // Police with man down
        public string gunsForHire = "CHM_IMG4";             // Limo
        public string weaponOfChoice = "CHM_IMG10";         // Prisoner being beaten
        public string gunrunning = "CHM_IMG3";              // Shipment
        public string nineTenthsOfTheLaw = "CHM_IMG6";      // Wheeling
        public string jailbreak = "CHM_IMG5";                   // Prison bus
        public string cracked = "CHM_IMG1";                 // Safe
        public string fragileGoods = "CHM_IMG2";                // Lost Van
        public string torched = "CHM_IMG9";                 // Explosive crate
        public string outrider = "CHM_IMG7";                // Sport ride
    }

}
