using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Interactions
{
    public enum TVChannel
    {
        Off = 0,
        TV = 1,
        Rest = 2
    }

    internal static class Televisions
    {
        private static Prop FakeTV;
        private static readonly Prop Remote;
        public static Television TV = new();
        private static int RenderTarget;
        private static readonly TvCoord actualTV = new();
        private static bool Scaleform = false;
        private static readonly List<ObjectHash> TVHashes =
        [
            ObjectHash.prop_tv_flat_01,
            ObjectHash.prop_tv_flat_02,
            ObjectHash.prop_tv_flat_02b,
            ObjectHash.prop_tv_flat_03,
            ObjectHash.prop_tv_flat_03b,
            ObjectHash.prop_tv_03,
            ObjectHash.apa_mp_h_str_avunits_01,
            ObjectHash.apa_mp_h_str_avunitm_01,
            ObjectHash.apa_mp_h_str_avunitm_03,
            ObjectHash.apa_mp_h_str_avunitl_01_b,
            ObjectHash.apa_mp_h_str_avunitl_04,
            ObjectHash.apa_mp_h_str_avunits_04,
            (ObjectHash)(-1223496606),
            (ObjectHash)608950395,
            (ObjectHash)1340914825,
            (ObjectHash)1020451759,
            (ObjectHash)60046420,
            (ObjectHash)1020451759,
            (ObjectHash)(-1949621260),
            (ObjectHash)(-240931727),
            (ObjectHash)(-897601557),
            (ObjectHash)777010715
        ];

        private static readonly List<TvCoord> localTVs =
        [
            new TvCoord(new Vector3(1120.1711f, -3144.5613f, -35.8581f), new Vector3(0.0000f, 0.0000f, 90.0000f)),
            new TvCoord(new Vector3(1010.6960f, -3164.1321f, -34.1590f), new Vector3(0.0000f, 0.0000f, -63.9800f)),
            new TvCoord(new Vector3(364.0089f, 4838.958f, -58.8157f), new Vector3(0f, 0f, 163f)),
            new TvCoord(new Vector3(228.8359f, -974.6591f, -98.3713f), new Vector3(0))
        ];

        private static readonly List<string> TVChannels =
        [
            "PL_STD_CNT",
            "PL_STD_WZL",
            "PL_LO_CNT",
            "PL_LO_WZL",
            "PL_SP_WORKOUT",
            "PL_SP_INV",
            "PL_SP_INV_EXP",
            "PL_LO_RS",
            "PL_LO_RS_CUTSCENE",
            "PL_SP_PLSH1_INTRO",
            "PL_LES1_FAME_OR_SHAME",
            "PL_STD_WZL_FOS_EP2",
            "PL_MP_WEAZEL",
            "PL_MP_CCTV",
            "PL_CINEMA_ACTION",
            "PL_CINEMA_ARTHOUSE",
            "PL_CINEMA_MULTIPLAYER",
            "PL_WEB_HOWITZER",
            "PL_WEB_RANGERS"
        ];

        private static readonly List<string> internetChannels =
        [
            "PL_CINEMA_ACTION",
            "PL_CINEMA_ARTHOUSE",
            "PL_CINEMA_MULTIPLAYER",
            "PL_WEB_HOWITZER",
            "PL_WEB_RANGERS",
            "PL_WEB_PRB2",
            "PL_WEB_KFLF",
            "PL_WEB_RS"
        ];

        public static async void TurnOnTV()
        {
            if (TV.Channel == 0 && !TV.On)
            {
                TV.On = true;
                Tuple<Vector3, Vector3> coords = GetCoords(GetInteriorFromGameplayCam());
                FakeTV = await Functions.CreateProp(GetInteriorFromGameplayCam() == 149761 ? "prop_tv_03_overlay" : "prop_tv_flat_01_screen", coords.Item1, coords.Item2, false);
                //FakeTV = await World.CreateProp(new Model(GetInteriorFromGameplayCam() == 149761 ? "prop_tv_03_overlay" : "prop_tv_flat_01_screen"), coords.Item1, coords.Item2, true, false);
                RenderTarget = RenderTargets.CreateNamedRenderTargetForModel("tvscreen", (uint)FakeTV.Model.Hash);
                RegisterScriptWithAudio(0);
                SetTvAudioFrontend(false);
                AttachTvAudioToEntity(FakeTV.Handle);
                SetTvChannel(-1);
                SetTvChannelPlaylist(1, TVChannels[0], false);
                TV.Channel = 1;
                SetTvChannel((int)TVChannel.TV);
                SetTvVolume(-4f);
                EnableMovieSubtitles(true);
                Scaleform = false;
                ClientMain.Instance.AddTick(DrawTV);
            }
        }

        private static Tuple<Vector3, Vector3> GetCoords(int iParam1)
        {
            Prop tv = new(GetClosestObjectOfType(Cache.PlayerCache.MyClient.Position.ToVector3.X, Cache.PlayerCache.MyClient.Position.ToVector3.Y, Cache.PlayerCache.MyClient.Position.ToVector3.Z, 10f, (uint)World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => TVHashes.Contains((ObjectHash)(uint)o.Model.Hash)).First(o => Vector3.Distance(Cache.PlayerCache.MyClient.Position.ToVector3, o.Position) < 5f).Model.Hash, false, false, true));

            switch (iParam1)
            {
                case 227329:
                    return new Tuple<Vector3, Vector3>(new Vector3(-780.6508f, 338.4844f, 216.8965f), new Vector3(0.0000f, 0.0000f, -90f));
                case 227585:
                    return new Tuple<Vector3, Vector3>(new Vector3(-780.3577f, 319.2637f, 195.9517f), new Vector3(0.0000f, 0.0000f, 89.99998f));
                case 206337:
                    return new Tuple<Vector3, Vector3>(new Vector3(377.2207f, 404.794f, 145.5749f), new Vector3(0.0000f, 0.0000f, -104f));
                case 208385:
                    return new Tuple<Vector3, Vector3>(new Vector3(-1281.774f, 432.1868f, 97.56892f), new Vector3(0.0000f, 0.0000f, -90f));
                case 207361:
                    return new Tuple<Vector3, Vector3>(new Vector3(-850.4965f, 674.4608f, 152.53f), new Vector3(0.0000f, 0.0000f, -85.40627f));
                case 207873:
                    return new Tuple<Vector3, Vector3>(new Vector3(-568.4861f, 642.998f, 145.5069f), new Vector3(0.0000f, 0.0000f, -104.5563f));
                case 208129:
                    return new Tuple<Vector3, Vector3>(new Vector3(-664.2865f, 585.6975f, 144.9159f), new Vector3(0.0000f, 0.0000f, -49.71875f));
                case 207617:
                    return new Tuple<Vector3, Vector3>(new Vector3(-771.523f, 604.845f, 143.6769f), new Vector3(0.0000f, 0.0000f, -161.5625f));
                case 206081:
                    return new Tuple<Vector3, Vector3>(new Vector3(330.9883f, 421.8975f, 148.917f), new Vector3(0.0000f, 0.0000f, -153.5f));
                case 146689:
                    return new Tuple<Vector3, Vector3>(new Vector3(-606.229f, 40.56918f, 97.39062f), new Vector3(0.0000f, 0.0000f, 180.0000f));
                case 147201:
                    return new Tuple<Vector3, Vector3>(new Vector3(-22.07481f, -578.9377f, 79.22162f), new Vector3(0.0000f, 0.0000f, -20.46875f));
                case 146177:
                    return new Tuple<Vector3, Vector3>(new Vector3(-907.0548f, -382.8968f, 113.4625f), new Vector3(0.0000f, 0.0000f, 153.0f));
                case 227841:
                    return new Tuple<Vector3, Vector3>(new Vector3(-780.6545f, 338.4835f, 187.1751f), new Vector3(0.0000f, 0.0000f, -90f));
                case 206593:
                    return new Tuple<Vector3, Vector3>(new Vector3(127.057f, 543.3829f, 183.9688f), new Vector3(0.0000f, 0.0000f, -84.0000f));
                case 207105:
                    return new Tuple<Vector3, Vector3>(new Vector3(-161.9239f, 482.8065f, 137.1923f), new Vector3(0.0000f, 0.0000f, -78.99996f));
                case 146945:
                    return new Tuple<Vector3, Vector3>(new Vector3(-781.8525f, 342.0280f, 211.183f), new Vector3(0));
                case 145921:
                    return new Tuple<Vector3, Vector3>(new Vector3(-1469.128f, -548.506f, 73.114f), new Vector3(0f, 0f, -235));
                case 143873:
                case 243201:
                case 148225:
                case 144641:
                case 144129:
                case 144385:
                case 141825:
                case 141569:
                case 145409:
                case 145665:
                case 143617:
                case 143105:
                case 142593:
                case 141313:
                case 147969:
                case 142849:
                case 143361:
                case 144897:
                case 145153:
                    tv = new Prop(GetClosestObjectOfType(Cache.PlayerCache.MyClient.Position.ToVector3.X, Cache.PlayerCache.MyClient.Position.ToVector3.Y, Cache.PlayerCache.MyClient.Position.ToVector3.Z, 5f, (uint)World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => TVHashes.Contains((ObjectHash)(uint)o.Model.Hash)).First(o => Vector3.Distance(Cache.PlayerCache.MyClient.Position.ToVector3, o.Position) < 5f).Model.Hash, false, false, true));

                    return new Tuple<Vector3, Vector3>(tv.Position + new Vector3(0, 0, -0.13f), tv.Rotation);
                case 149761:
                    tv = new Prop(GetClosestObjectOfType(Cache.PlayerCache.MyClient.Position.ToVector3.X, Cache.PlayerCache.MyClient.Position.ToVector3.Y, Cache.PlayerCache.MyClient.Position.ToVector3.Z, 5f, (uint)World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => TVHashes.Contains((ObjectHash)(uint)o.Model.Hash)).First(o => Vector3.Distance(Cache.PlayerCache.MyClient.Position.ToVector3, o.Position) < 5f).Model.Hash, false, false, true));

                    return new Tuple<Vector3, Vector3>(tv.Position + new Vector3(0, 0, -0.21f), tv.Rotation);
            }

            return new Tuple<Vector3, Vector3>(new Vector3(), new Vector3());
        }

        public static async Task DrawTV()
        {
            float fVar0 = 1f;
            MathAspectRatioRenderTarget(ref fVar0);
            SetTextRenderId(RenderTarget);
            Set_2dLayer(4);
            SetScriptGfxDrawBehindPausemenu(true);
            DrawTvChannel(0.5f, 0.5f, fVar0, 1.0f, 0.0f, 255, 255, 255, 255);
            SetTextRenderId(GetDefaultScriptRendertargetRenderId());
            SetScriptGfxDrawBehindPausemenu(false);
        }

        public static async Task TVControls()
        {
            List<InstructionalButton> buttons =
            [
                new InstructionalButton((Control)202, (Control)177, GetLabelText("HUD_INPUT3")),
                new InstructionalButton((Control)222, (Control)51, TV.On? GetLabelText("HUD_INPUT82") : GetLabelText("HUD_INPUT81")),
                new InstructionalButton((Control)218, GetLabelText("HUD_INPUT75")),
                new InstructionalButton((Control)219, GetLabelText("HUD_INPUT77")),
                new InstructionalButton((Control)236, GetLabelText("HUD_INPUT87")),
            ];
            ScaleformUI.Main.InstructionalButtons.SetInstructionalButtons(buttons);
            Game.DisableControlThisFrame(0, Control.MoveLeftOnly);
            Game.DisableControlThisFrame(0, Control.MoveRightOnly);
            Game.DisableControlThisFrame(0, Control.MoveUpOnly);
            Game.DisableControlThisFrame(0, Control.MultiplayerInfo);
            Game.DisableControlThisFrame(0, Control.MoveDownOnly);
            Game.DisableControlThisFrame(0, Control.ScriptRUp);
            Game.DisableControlThisFrame(0, Control.Context);

            if (!TV.On && SittingAnimations.sitting)
            {
                if (IsDisabledControlJustPressed(0, IsInputDisabled(2) ? 51 : 222))
                {
                    TurnOnTV();
                    Scaleform = false;
                }
            }
            else if (TV.On && SittingAnimations.sitting)
            {
                //				HUD.ShowHelp("~INPUTGROUP_FRONTEND_DPAD_LR~ per cambiare ~y~canale~w~.\n~INPUTGROUP_FRONTEND_DPAD_UD~ per cambiare il ~b~volume~w~.\n~INPUT_VEH_EXIT~ per spegnere la TV");
                if (Input.IsDisabledControlJustPressed(Control.MoveLeftOnly)) // channel-
                {
                    --TV.Channel;
                    if (TV.Channel < 0) TV.Channel = TVChannels.Count - 1;
                    SetTvChannelPlaylist(1, TVChannels[TV.Channel], false);
                    SetTvChannel((int)TVChannel.TV);
                    Game.PlaySound("SAFEHOUSE_MICHAEL_SIT_SOFA", "MICHAEL_SOFA_TV_CHANGE_CHANNEL_MASTER");
                }

                if (Input.IsDisabledControlJustPressed(Control.MoveRightOnly)) // channel+ 
                {
                    ++TV.Channel;
                    if (TV.Channel > 18) TV.Channel = 0;
                    SetTvChannelPlaylist(1, TVChannels[TV.Channel], false);
                    SetTvChannel((int)TVChannel.TV);
                    Game.PlaySound("SAFEHOUSE_MICHAEL_SIT_SOFA", "MICHAEL_SOFA_TV_CHANGE_CHANNEL_MASTER");
                }

                if (Input.IsDisabledControlPressed(Control.MoveUpOnly)) // volume up
                {
                    TV.Volume += 0.5f;
                    if (TV.Volume > 0) TV.Volume = 0;
                    SetTvVolume(TV.Volume);
                    if (TV.Volume > -36 && TV.Volume < 0) Game.PlaySound("SAFEHOUSE_MICHAEL_SIT_SOFA", "MICHAEL_SOFA_REMOTE_CLICK_VOLUME_MASTER");
                }

                if (Input.IsDisabledControlPressed(Control.MoveDownOnly)) // volume down
                {
                    TV.Volume -= 0.5f;
                    if (TV.Volume < -36) TV.Volume = -36;
                    SetTvVolume(TV.Volume);
                    if (TV.Volume > -36 && TV.Volume < 0) Game.PlaySound("SAFEHOUSE_MICHAEL_SIT_SOFA", "MICHAEL_SOFA_REMOTE_CLICK_VOLUME_MASTER");
                }

                if (IsDisabledControlJustPressed(0, IsInputDisabled(2) ? 51 : 222))
                {
                    ClearTvChannelPlaylist(1);
                    SetTvChannel(-1);
                    if (IsNamedRendertargetRegistered("tvscreen"))
                        ReleaseNamedRendertarget("tvscreen");
                    else if (IsNamedRendertargetRegistered("ex_tvscreen")) ReleaseNamedRendertarget("ex_tvscreen");
                    RenderTarget = -1;
                    SetTextRenderId(GetDefaultScriptRendertargetRenderId());
                    TV.On = false;
                    TV.Channel = 0;
                    Scaleform = false;
                    EnableMovieSubtitles(false);
                    FakeTV.Delete();
                    int intnum = -1;
                    uint something = (uint)intnum;
                    ClientMain.Instance.RemoveTick(DrawTV);
                }
            }
        }

        private static void MathAspectRatioRenderTarget(ref float fParam0)
        {
            float fVar0;
            float fVar1;
            float fVar2;
            fVar0 = GetAspectRatio(false);

            if (fVar0 <= 16f / 9f)
            {
                fVar1 = fVar0 / (16f / 9f);
                fVar2 = fParam0;
                fParam0 = fVar2 * fVar1;
            }
        }
    }

    public class Television
    {
        public int Channel = 0;
        public Prop Entity;
        public bool On = false;
        public float Volume = 0.5f;
    }

    internal class TvCoord
    {
        public Vector3 Coord = new();
        public Vector3 Rot = new();

        public TvCoord() { }

        public TvCoord(Vector3 coord, Vector3 rot)
        {
            Coord = coord;
            Rot = rot;
        }
    }
}