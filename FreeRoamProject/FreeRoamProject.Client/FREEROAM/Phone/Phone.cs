using FreeRoamProject.Client.FREEROAM.Phone.Apps;
using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone
{
    public enum MessageStyle
    {
        MESSAGE_TYPE_HEIST = 1,
        MESSAGE_TYPE_ADVERSARY = 2,
        LOW_FLOW = 3,
        STYLE_G1 = 4,
        STYLE_G2 = 5,
        STYLE_G3 = 6,
        STYLE_G4 = 7,
        STYLE_G5 = 8,
        STYLE_G6 = 9,
        STYLE_G7 = 10,
        STYLE_G8 = 11,
        STYLE_G9 = 12,
        STYLE_G10 = 13,
        STYLE_G11 = 14,
        STYLE_G12 = 15,
        STYLE_G13 = 16,
        STYLE_G14 = 17,
        STYLE_G15 = 18,
        STYLE_TECH_GREEN = 19
    }

    public enum ModelPhone : int
    {
        Micheal = 0,
        Franklin = 1,
        Trevor = 2,
        Prologue = 4
    }
    public enum PhoneAnimation
    {
        CLOSE,
        OPEN,
        OPEN_ROTATION,
        SET_HORIZONTAL,
        SET_VERTICAL,
        OPEN_CAMERA,
        CLOSE_CAMERA
    }

    public enum SoftKeys
    {
        BLANK = 1,
        SELECT,
        PAGES,
        BACK,
        CALL,
        HANGUP,
        HANGUP_HUMAN,
        WEEK,
        KEYPAD,
        OPEN,
        REPLY,
        DELETE,
        YES,
        NO,
        SORT,
        WEBSITE,
        POLICE,
        AMBULANCE,
        FIRE,
        PAGES2
    }

    public enum IconLabels
    {
        CAMERA = 1,
        TEXT_MESSAGE = 2,
        CALENDAR = 3,
        EMAIL = 4,
        CALL = 5,
        EYEFIND = 6,
        MAP = 7,
        APPS = 8,
        MEDIA = 9,
        ATTACHMENT = 10,
        NEW_CONTACT = 11,
        SIDE_TASKS = 12,
        BAWSAQ = 13,
        MULTIPLAYER = 14,
        MUSIC = 15,
        GPS = 16,
        SPARE = 17,
        RINGTONE = 18,
        TEXT_TONE = 19,
        VIBRATE_ON = 20,
        VIBRATE_OFF = 21,
        VOLUME = 22,
        SETTINGS_1 = 23,
        SETTINGS_2 = 24,
        PROFILE = 25,
        SLEEP_MODE = 26,
        MISSED_CALL = 27,
        UNREAD_EMAIL = 28,
        READ_EMAIL = 29,
        REPLY_EMAIL = 30,
        REPLAYMISSION = 31,
        SHITSKIP = 32,
        UNREAD_SMS = 33,
        READ_SMS = 34,
        PLAYER_LIST = 35,
        COP_BACKUP = 36,
        GANG_TAXI = 37,
        REPEAT_PLAY = 38,
        CHECKLIST = 39,
        SNIPER = 40,
        ZIT_IT = 41,
        TRACKIFY = 42,
        SAVE = 43,
        ADD_TAG = 44,
        REMOVE_TAG = 45,
        LOCATION = 46,
        PARTY = 47,
        TICKED = 48,
        BROADCAST = 49,
        GAMEPAD = 50,
        SILENT = 51,
        INVITES_PENDING = 52,
        ON_CALL = 53,
        H_LOCK = 54,
        PUSH_TO_TALK = 55,
        BENNYS = 56,
        GANG = 57,
        TRACKER = 58,
        SIGHT_SEER = 59,
        BEACON = 60,
    }

    public enum PhoneView
    {
        SHUTDOWN_MOVIE = 0,
        HOMEMENU,
        CONTACTLIST,
        unk_3,
        CALLSCREEN,
        unk_5,
        TEXT_MESSAGE_LIST,
        TEXT_MESSAGE_VIEW,
        EMAIL_LIST,
        EMAIL_VIEW,
        unk_10,
        APP_NUMBERPAD,
        unk_12,
        SETTINGS,
        APP_TODO_LIST,
        APP_TODO_VIEW,
        SHUTTER,
        APP_TODO_VIEW_2,
        MISSION_REPEAT_LIST,
        APP_MISSION_STATS_VIEW,
        JOB_LIST,
        EMAIL_RESPONSE,
        SETTINGS_2,
        APP_TRACKIFY,
        XYZ,
        BOSS_JOB_LIST,
        BOSS_JOB_LIST_VIEW,
        APP_SECUROSERV_HACKING
    }

    public class Phone
    {
        public ScaleformWideScreen Scaleform = new("CELLPHONE_IFRUIT");
        public bool Visible = false;
        public bool SleepMode = false;
        public List<App> apps;
        public App MainMenu;
        public App Callscreen;
        public App CurrentApp = null;
        public int VisibleAnimProgress;
        public bool IsBackOverriddenByApp;
        public bool InCall = false;
        public float Scale = 0;
        private float currentScale = 0;

        internal Vector3 RotationHidden = Vector3.Zero;
        internal Vector3 PositionHidden = Vector3.Zero;
        internal Vector3 PositionOpen = Vector3.Zero;
        internal Vector3 PositionLean = Vector3.Zero;
        internal Vector3 RotationHorizontal = Vector3.Zero;
        internal Vector3 RotationVertical = Vector3.Zero;
        private readonly bool firstOpen = true;
        internal int iLocal18;
        public Phone()
        {
            /*
            email, messages, contacts, 
            quickjoin, jobList, settings,
            snapmatic, web, securoserv,
            */

            apps =
            [
                new Emails(this), new Messages(this), new Contacts(this),
                new QuickJoin(this), new JobList(this), new Apps.Settings(this),
                new Snapmatic(this), new Apps.WebBrowser(this), new Securoserv(this)
        ];
            MainMenu = new MainMenu(this, apps);
            Callscreen = new CallScreen(this);
            RotationHidden = new Vector3(-90f, -130f, 0f);
            if (GetIsHidef())
            {
                PositionHidden = new Vector3(GetSafeZoneSize() * 117.2f, GetSafeZoneSize() * -158.8f, -113f);
                PositionOpen = new Vector3(GetSafeZoneSize() * 117.2f, GetSafeZoneSize() * -53.3f, -113f);
            }
            else
            {
                PositionHidden = new Vector3(GetSafeZoneSize() * 85.7f, GetSafeZoneSize() * -121.8f, -91.5f);
                PositionOpen = new Vector3(GetSafeZoneSize() * 85.7f, GetSafeZoneSize() * -35.3f, -91.5f);
            }
            PositionLean = Vector3.Add(PositionOpen, new Vector3(-10, 20, 0));
            RotationVertical = new Vector3(-90, 0, 0);
            RotationHorizontal = new Vector3(-90, 0, 90);
            currentScale = 500f;
        }

        public async void OpenPhone()
        {
            ScriptIsMovingMobilePhoneOffscreen(false);
            Scaleform = new ScaleformWideScreen("CELLPHONE_IFRUIT");
            while (!Scaleform.IsLoaded) await BaseScript.Delay(0);
            Game.PlaySound("Pull_Out", "Phone_SoundSet_Default");
            CreateMobilePhone((int)ModelPhone.Micheal);
            ClientMain.Instance.AddTick(Screen);
            StartApp("MAINMENU");
            PlayerCache.MyPed.SetConfigFlag(242, false);
            PlayerCache.MyPed.SetConfigFlag(243, false);
            PlayerCache.MyPed.SetConfigFlag(244, true);
            Visible = true;
            SetMobilePhonePosition(PositionHidden.X, PositionHidden.Y, PositionHidden.Z);
            SetMobilePhoneRotation(RotationHidden.X, RotationHidden.Y, RotationHidden.Z, 0);
            SetMobilePhoneScale(currentScale);
            await RotateAnimation(PhoneAnimation.OPEN);
        }

        public async void OpenPhoneIncominCall(Contact contact)
        {
            ScriptIsMovingMobilePhoneOffscreen(false);
            Scaleform = new ScaleformWideScreen("CELLPHONE_IFRUIT");
            while (!Scaleform.IsLoaded) await BaseScript.Delay(0);
            Game.PlaySound("Pull_Out", "Phone_SoundSet_Default");
            CreateMobilePhone((int)ModelPhone.Micheal);
            ClientMain.Instance.AddTick(Screen);
            ((CallScreen)Callscreen).SetContact(contact);
            StartApp("callscreen", true);
            string ringtone = getCurrentCharPhone().GetPlayerRingtoneString();
            PlayPedRingtone(ringtone, PlayerPedId(), true);
            ((CallScreen)Callscreen).CallStatus = CallState.INCOMING_CALL;
            PlayerCache.MyPed.SetConfigFlag(242, false);
            PlayerCache.MyPed.SetConfigFlag(243, false);
            PlayerCache.MyPed.SetConfigFlag(244, true);
            Visible = true;
            SetMobilePhonePosition(PositionHidden.X, PositionHidden.Y, PositionHidden.Z);
            SetMobilePhoneRotation(RotationHidden.X, RotationHidden.Y, RotationHidden.Z, 0);
            SetMobilePhoneScale(currentScale);
            await RotateAnimation(PhoneAnimation.OPEN);
        }

        public async void ClosePhone()
        {
            if (!PhoneMainClient.PhoneActive) return;
            Game.PlaySound("Put_Away", "Phone_SoundSet_Default");
            await RotateAnimation(PhoneAnimation.CLOSE);
            Scaleform.CallFunction("SHUTDOWN_MOVIE");
            ClientMain.Instance.RemoveTick(Screen);
            CurrentApp?.Kill();
            apps.ForEach(app => app.Kill());
            Scaleform.Dispose();
            DestroyMobilePhone();
            Visible = false;
            PlayerCache.MyPed.SetConfigFlag(242, true);
            PlayerCache.MyPed.SetConfigFlag(243, true);
            PlayerCache.MyPed.SetConfigFlag(244, false);
            ScriptIsMovingMobilePhoneOffscreen(true);
        }

        public PhoneData getCurrentCharPhone()
        {
            if (PlayerCache.Character.PhoneData == null)
                PlayerCache.Character.PhoneData = new PhoneData();
            return PlayerCache.Character.PhoneData;
        }

        public void SetSoftKeys(int index, SoftKeys icon, bool enabled, SColor color)
        {
            Scaleform.CallFunction("SET_SOFT_KEYS", index, enabled, (int)icon);
            Scaleform.CallFunction("SET_SOFT_KEYS_COLOUR", index, (int)color.R, (int)color.G, (int)color.B);
        }

        private async Task Screen()
        {
            HideHudComponentThisFrame(6);
            HideHudComponentThisFrame(7);
            HideHudComponentThisFrame(8);
            HideHudComponentThisFrame(9);
            Game.DisableControlThisFrame(0, Control.Sprint);

            Scaleform.CallFunction("SET_TITLEBAR_TIME", World.CurrentDayTime.Hours, World.CurrentDayTime.Minutes, getDay(World.CurrentDayTime.Days));
            Scaleform.CallFunction("SET_SLEEP_MODE", getCurrentCharPhone().SleepMode);
            Scaleform.CallFunction("SET_THEME", getCurrentCharPhone().Theme); // TODO: USE SAVED DATA
            N_0x83a169eabcdb10a2(PlayerPedId(), getCurrentCharPhone().Theme - 1); // theme -1
            Scaleform.CallFunction("SET_BACKGROUND_IMAGE", getCurrentCharPhone().Wallpaper); // TODO: USE SAVED DATA
            Vector3 playerPos = PlayerCache.MyClient.Position.ToVector3;
            Scaleform.CallFunction("SET_SIGNAL_STRENGTH", GetZoneScumminess(GetZoneAtCoords(playerPos.X, playerPos.Y, playerPos.Z)));

            if (GetFollowPedCamViewMode() == 4 || UpdateOnscreenKeyboard() == 0)
            {
                SetMobilePhoneScale(0);
            }
            else
            {
                if (iLocal18 == 0)
                {
                    SetMobilePhoneScale(currentScale);
                }
            }

            if (CurrentApp != null)
            {
                if (CurrentApp.OverrideBack)
                    IsBackOverriddenByApp = true;
                else
                    IsBackOverriddenByApp = false;
            }
            int renderId = 0;
            GetMobilePhoneRenderId(ref renderId);
            SetTextRenderId(renderId);
            SetScriptGfxDrawOrder(4);
            DrawScaleformMovie(Scaleform.Handle, 0.1f, 0.179f, 0.2f, 0.356f, 255, 255, 255, 255, 0);
            SetTextRenderId(1);
        }

        public void StartApp(string app, bool callscreen = false)
        {
            CurrentApp?.Kill();
            if (!callscreen)
            {
                if (app == "MAINMENU")
                {
                    CurrentApp = MainMenu;
                }
                else if (apps.Exists(x => x.Name == app))
                {
                    CurrentApp = apps.FirstOrDefault(x => x.Name == app);
                }
            }
            else
            {
                CurrentApp = Callscreen;
            }

            CurrentApp.Initialize(this);
        }

        public async Task RotateAnimation(PhoneAnimation animation)
        {
            if (GetFollowPedCamViewMode() == 4)
            {
                return;
            }
            switch (animation)
            {
                case PhoneAnimation.CLOSE:
                    {
                        while (RotatePhone(PositionOpen, PositionHidden, RotationVertical, RotationVertical, 350f, false) < 1f)
                        {
                            await BaseScript.Delay(0);
                        }
                        iLocal18 = 0;
                    }
                    break;
                case PhoneAnimation.OPEN:
                    {
                        while (RotatePhone(PositionHidden, PositionOpen, RotationVertical, RotationVertical, 350f, false) < 1f)
                        {
                            await BaseScript.Delay(0);
                        }
                        iLocal18 = 0;
                    }
                    break;
                case PhoneAnimation.OPEN_ROTATION:
                    {
                        while (RotatePhone(PositionHidden, PositionOpen, RotationHidden, RotationVertical, 450f, false) < 1f)
                        {
                            await BaseScript.Delay(0);
                            SetMobilePhoneScale(500f);
                            currentScale = 500f;
                        }
                        iLocal18 = 0;
                    }
                    break;
                case PhoneAnimation.SET_HORIZONTAL:
                    {
                        float val = 0;
                        while (val < 1f)
                        {
                            await BaseScript.Delay(0);
                            val = RotatePhone(PositionOpen, PositionLean, RotationVertical, RotationHorizontal, 350f, false);
                            SetMobilePhoneScale(500f + (75f * val));
                            currentScale = 500f + (75f * val);
                        }
                        iLocal18 = 0;
                    }
                    break;
                case PhoneAnimation.SET_VERTICAL:
                    {
                        float val = 0;
                        while (val < 1f)
                        {
                            await BaseScript.Delay(0);
                            val = RotatePhone(PositionLean, PositionOpen, RotationHorizontal, RotationVertical, 350f, false);
                            SetMobilePhoneScale(500f + (75f * (1f - val)));
                            currentScale = 500f + (75f * (1f - val));
                        }
                        iLocal18 = 0;
                    }
                    break;
                case PhoneAnimation.OPEN_CAMERA:
                    {
                        while (RotatePhone(PositionOpen, new Vector3(1.5f, 0f, -17f), RotationVertical, new Vector3(-90.3f, 0f, 90f), 450f, false) < 1f)
                        {
                            await BaseScript.Delay(0);
                        }
                    }
                    break;
                case PhoneAnimation.CLOSE_CAMERA:
                    {
                        while (RotatePhone(new Vector3(1.5f, 0f, -17f), PositionOpen, new Vector3(-90.3f, 0f, 90f), RotationVertical, 450f, false) < 1f)
                        {
                            await BaseScript.Delay(0);
                        }
                    }
                    break;
            }
        }

        // taken from cellphone_flashhand.c and appemail.c
        private float RotatePhone(Vector3 startPosition, Vector3 endPosition, Vector3 startRotation, Vector3 endRotation, float step, bool someBool)
        {
            float fVar1;
            float fVar2;
            if (iLocal18 == 0)
            {
                iLocal18 = GetGameTimer();
            }
            fVar1 = GetValueInRange(ToFloat(GetGameTimer() - iLocal18) / step, 0f, 1f);
            Vector3 pos;
            Vector3 rot;
            if (fVar1 < 1f)
            {
                fVar2 = fVar1;
                if (someBool)
                {
                    fVar2--;
                    float fVar3 = 0.670158f;
                    fVar2 = (fVar2 * fVar2 * (((fVar3 + 1f) * fVar2) + fVar3)) + 1f;
                }
                else
                {
                    fVar2 = Sin(fVar1 * 90f);
                }
                pos = func_16(startPosition, endPosition, fVar2);
                rot = func_16(startRotation, endRotation, fVar2);
            }
            else
            {
                pos = endPosition;
                rot = endRotation;
            }
            SetMobilePhonePosition(pos.X, pos.Y, pos.Z);
            SetMobilePhoneRotation(rot.X, rot.Y, rot.Z, 0);
            return fVar1;
        }

        private Vector3 func_16(Vector3 Param0, Vector3 Param1, float fParam2)
        {
            return Param0 + ((Param1 - Param0) * new Vector3(fParam2));
        }


        internal float GetValueInRange(float fParam0, float fParam1, float fParam2)
        {
            return fParam0 > fParam2 ? fParam2 : fParam0 < fParam1 ? fParam1 : fParam0;
        }

        private string getDay(int day)
        {
            return day switch
            {
                0 => GetLabelText("CELL_920"),
                1 => GetLabelText("CELL_921"),
                2 => GetLabelText("CELL_922"),
                3 => GetLabelText("CELL_923"),
                4 => GetLabelText("CELL_924"),
                5 => GetLabelText("CELL_925"),
                6 => GetLabelText("CELL_926"),
                _ => GetLabelText("CELL_206"),
            };
        }

    }
}
