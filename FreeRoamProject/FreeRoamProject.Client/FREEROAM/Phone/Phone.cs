using FreeRoamProject.Client.FREEROAM.Phone.Apps;
using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone
{
    public class Phone
    {
        public Scaleform Scaleform = new Scaleform("CELLPHONE_IFRUIT");
        public bool Visible = false;
        public bool SleepMode = false;
        public List<PhoneData> phone_data = new List<PhoneData>();
        public List<App> apps;
        public App mainApp;
        public App currentApp = null;
        public int VisibleAnimProgress;
        public bool IsBackOverriddenByApp;
        public bool InCall = false;
        public float Scale = 0;
        internal Vector3 Position1 = Vector3.Zero;
        internal Vector3 Position2 = Vector3.Zero;
        private bool firstOpen = true;
        internal int iLocal18;

        Vector3 Global_20226 = new(-90, 0, 0);
        public Phone()
        {
            phone_data.Add(new PhoneData());
            apps = new List<App>()
            {
                new Contacts(this), new Messages(this), new QuickSave(this), new Apps.Settings(this)
            };
            mainApp = new MainMenu(this, apps);
            if (GetIsHidef())
            {
                Position1 = new Vector3(GetSafeZoneSize() * 117.2f, GetSafeZoneSize() * -158.8f, -113f);
                Position2 = new Vector3(GetSafeZoneSize() * 117.2f, GetSafeZoneSize() * -53.3f, -113f);
            }
            else
            {
                Position1 = new Vector3(GetSafeZoneSize() * 85.7f, GetSafeZoneSize() * -121.8f, -91.5f);
                Position2 = new Vector3(GetSafeZoneSize() * 85.7f, GetSafeZoneSize() * -35.3f, -91.5f);
            }
            Scaleform = new Scaleform("CELLPHONE_IFRUIT");
        }

        public async void OpenPhone()
        {
            Scaleform = new Scaleform("CELLPHONE_IFRUIT");
            Game.PlaySound("Pull_Out", "Phone_SoundSet_Default");
            CreateMobilePhone((int)ModelPhone.Micheal);
            PhoneMainClient.StartApp("Main");
            PlayerCache.MyPed.SetConfigFlag(242, false);
            PlayerCache.MyPed.SetConfigFlag(243, false);
            PlayerCache.MyPed.SetConfigFlag(244, true);
            VisibleAnimProgress = 21;
            N_0x83a169eabcdb10a2(PlayerPedId(), 0); // TODO: here we load the saved theme
            if (GetFollowPedCamViewMode() == 4)
                Scale = 0f;
            else
                Scale = 500f;
            SetMobilePhoneScale(Scale);
            Visible = true;
            SetMobilePhoneRotation(-90f, 0f, 0f, 0);
            SetMobilePhonePosition(Position1.X, Position1.Y, Position1.Z);
            SetMobilePhoneScale(Scale);
            SetMobilePhoneUnk(true);
            ClientMain.Instance.AddTick(Screen);
            await RotateAnimation(Position1, Position2, new Vector3(-90f, 0f, 0f), new Vector3(-90f, 0f, 0f), 350f, false);
        }

        public async void ClosePhone()
        {
            await RotateAnimation(Position2, Position1, new Vector3(-90f, 0f, 0f), new Vector3(-90f, 0f, 0f), 350f, false);
            Scaleform.CallFunction("SHUTDOWN_MOVIE");
            Scaleform.Dispose();
            DestroyMobilePhone();
            Visible = false;
            PlayerCache.MyPed.SetConfigFlag(242, true);
            PlayerCache.MyPed.SetConfigFlag(243, true);
            PlayerCache.MyPed.SetConfigFlag(244, false);
            ClientMain.Instance.RemoveTick(Screen);
        }

        public PhoneData getCurrentCharPhone()
        {
            if (PlayerCache.Character.PhoneData == null)
                PlayerCache.Character.PhoneData = new PhoneData();
            return PlayerCache.Character.PhoneData;
            /*
			for (int i = 0; i < phone_data.Count; i++)
			{
				if (Cache.MyPlayer.User.char_current - 1 == phone_data[i].id - 1)
					return phone_data[i];
			}
			*/
            return null;
        }

        public void SetSoftKeys(int index, int icon)
        {
            Scaleform.CallFunction("SET_SOFT_KEYS", index, true, icon);
        }

        private async Task Screen()
        {
            Game.DisableControlThisFrame(0, Control.Sprint);

            Scaleform.CallFunction("SET_TITLEBAR_TIME", World.CurrentDayTime.Hours, World.CurrentDayTime.Minutes);

            Scaleform.CallFunction("SET_SLEEP_MODE", SleepMode);
            Scaleform.CallFunction("SET_THEME", 1); // TODO: USE SAVED DATA
            N_0x83a169eabcdb10a2(PlayerPedId(), 0); // theme -1
            Scaleform.CallFunction("SET_BACKGROUND_IMAGE", 0); // TODO: USE SAVED DATA
            SetSoftKeys(2, 19);
            Vector3 playerPos = PlayerCache.MyClient.Position.ToVector3;
            Scaleform.CallFunction("SET_SIGNAL_STRENGTH", GetZoneScumminess(GetZoneAtCoords(playerPos.X, playerPos.Y, playerPos.Z)));

            if (GetFollowPedCamViewMode() == 4)
                Scale = 0f;
            else
                Scale = 350f;
            if (currentApp != null)
            {
                Scaleform.CallFunction("SET_HEADER", currentApp.Name);
                if (currentApp.OverrideBack)
                    IsBackOverriddenByApp = true;
                else
                    IsBackOverriddenByApp = false;
            }
            int renderId = 0;
            GetMobilePhoneRenderId(ref renderId);
            SetTextRenderId(renderId);
            DrawScaleformMovie(Scaleform.Handle, 0.0998f, 0.1775f, 0.1983f, 0.364f, 255, 255, 255, 255, 0);
            SetTextRenderId(1);

        }

        public async Task RotateAnimation(Vector3 Param0, Vector3 Param1, Vector3 Param2, Vector3 Param3, float fParam4, bool bParam5)
        {
            iLocal18 = GetGameTimer();
            while (RotatePhone(Param0, Param1, Param2, Param3, fParam4, bParam5) < 1f)
                await BaseScript.Delay(0);
        }

        private float RotatePhone(Vector3 Param0, Vector3 Param1, Vector3 Param2, Vector3 Param3, float fParam4, bool bParam5)
        {
            float fVar1;
            float fVar2;
            float fVar3;
            // if something then 25f
            // if something then new rotation Vector3 = -45f, 45f, 25f
            Vector3 Var0 = Vector3.Zero;
            Vector3 pos = Vector3.Zero;
            Vector3 rot = Vector3.Zero;
            GetMobilePhonePosition(ref Var0);
            fVar1 = func_17(((GetGameTimer() - iLocal18) / fParam4), 0f, 1f); // or / 25f
            if (fVar1 < 1f)
            {
                fVar2 = fVar1;
                if (bParam5)
                {
                    fVar2 = (fVar2 - 1f);
                    fVar3 = 0.670158f;
                    fVar2 = (((fVar2 * fVar2) * (((fVar3 + 1f) * fVar2) + fVar3)) + 1f);
                }
                else
                {
                    fVar2 = Sin((fVar1 * 90f));
                }
                pos = func_16(Param0, Param1, fVar2);
                rot = func_16(Param2, Param3, fVar2);
            }
            else
            {
                pos = Param1;
                rot = Param3;
            }
            SetMobilePhonePosition(pos.X, pos.Y, pos.Z);
            SetMobilePhoneRotation(rot.X, rot.Y, rot.Z, 0);
            return fVar1;
        }

        private Vector3 func_16(Vector3 Param0, Vector3 Param1, float fParam2)//Position - 0x288D
        {
            return Param0 + Param1 - Param0 * new Vector3(fParam2, fParam2, fParam2);
        }


        private float func_17(float fParam0, float fParam1, float fParam2)//Position - 0x28A7
        {
            if (fParam0 > fParam2)
                return fParam2;
            else if (fParam0 < fParam1)
                return fParam1;
            return fParam0;
        }



    }
}
