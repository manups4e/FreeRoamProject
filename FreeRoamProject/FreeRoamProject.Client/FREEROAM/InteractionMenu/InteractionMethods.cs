using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheLastPlanet.Client.GameMode.ROLEPLAY.Personale
{
    // TODO: THIS CLASS IS GONNA BE USED FOR HANDLE THE EFFECTS OF WHAT IS CHANGED IN THE MENU..
    // SO THAT THE MENU REMAINS SHORT CODED AND READABLE
    internal static class InteractionMethods
    {
        public static bool WindowsDown = false;
        public static bool ShowStatus = true;
        public static bool ShowMoney = true;
        public static Vehicle saveVehicle = null;
        public static float CinematicHeight = 0;
        internal static Camera MoodCam;
        /*				if (value)
                      Client.Instance.AddTick(CinematicMode);
                  else
                      Client.Instance.RemoveTick(CinematicMode);
  */
        private static List<HudComponent> hideComponents = new List<HudComponent>()
        {
            HudComponent.WantedStars,
            HudComponent.WeaponIcon,
            HudComponent.Cash,
            HudComponent.MpCash,
            HudComponent.MpMessage,
            HudComponent.VehicleName,
            HudComponent.AreaName,
            HudComponent.Unused,
            HudComponent.StreetName,
            HudComponent.HelpText,
            HudComponent.FloatingHelpText1,
            HudComponent.FloatingHelpText2,
            HudComponent.CashChange,
            HudComponent.Reticle,
            HudComponent.SubtitleText,
            HudComponent.RadioStationsWheel,
            HudComponent.Saving,
            HudComponent.GamingStreamUnusde,
			//HudComponent.WeaponWheel, // forse per questo non potevo cambiare arma???
			HudComponent.WeaponWheelStats
        };
        /*
        public static async Task CinematicMode()
        {
            hideComponents.ForEach(c => Screen.Hud.HideComponentThisFrame(c));

            if (Main.ClientConfig.LetterBox > 0f)
            {
                DrawRect(0.5f, Main.ClientConfig.LetterBox / 1000 / 2, 1f, Main.ClientConfig.LetterBox / 1000, 0, 0, 0, 255);
                DrawRect(0.5f, 1 - Main.ClientConfig.LetterBox / 1000 / 2, 1f, Main.ClientConfig.LetterBox / 1000, 0, 0, 0, 255);
            }

            await Task.FromResult(0);
        }
        */

        internal static async void SetWalkingStyle(int selection)//Position - 0x4FE05F
        {
            string sex = PlayerCache.MyPlayer.User.Character.Skin.Sex;
            switch (selection)
            {
                case 0:
                    RemoveClipSets(0);
                    ResetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, 0.25f);
                    break;
                case 1:
                    RequestClipSet(sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@", 0.25f);
                    RemoveClipSets(1);
                    break;

                case 2:
                    RequestClipSet(sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG", 0.25f);
                    RemoveClipSets(2);
                    break;

                case 3:
                    RequestClipSet(sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@", 0.25f);
                    RemoveClipSets(3);
                    break;

                case 4:
                    RequestClipSet(sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@", 0.25f);
                    RemoveClipSets(4);
                    break;

                case 5:
                    RequestClipSet(sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@");
                    while (!HasClipSetLoaded(sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyPlayer.Ped.Handle, sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@", 0.25f);
                    RemoveClipSets(5);
                    break;
            }
        }

        internal static void RemoveClipSets(int iParam0)//Position - 0x4FE31E
        {
            string sex = PlayerCache.MyPlayer.User.Character.Skin.Sex;
            if (iParam0 != 1)
            {
                RemoveClipSet(sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@");
            }
            if (iParam0 != 2)
            {
                RemoveClipSet(sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG");
            }
            if (iParam0 != 3)
            {
                RemoveClipSet(sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@");
            }
            if (iParam0 != 4)
            {
                RemoveClipSet(sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@");
            }
            if (iParam0 != 5)
            {
                RemoveClipSet(sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@");
            }
        }

        internal static void SetFacialAnim(int selection)
        {
            string mood = GetMoodDict(selection);
            Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyPlayer.Ped.Handle, mood, 0);
        }

        internal static string GetMoodDict(int selection)
        {
            return selection switch
            {
                0 => "mood_Aiming_1",
                1 => "mood_Angry_1",
                2 => "mood_Happy_1",
                3 => "mood_Injured_1",
                4 => "mood_Normal_1",
                5 => "mood_stressed_1",
                6 => "mood_smug_1",
                7 => "mood_sulk_1",
                _ => "mood_Normal_1",
            };
        }

        public static void VehDorrs(string door)
        {
            int port = 0;

            switch (door)
            {
                case "Anteriore Sinistra":
                    port = 0;

                    break;
                case "Anteriore Right":
                    port = 1;

                    break;
                case "Rear Left":
                    port = 2;

                    break;
                case "Rear Right":
                    port = 3;

                    break;
                case "Hood":
                    port = 4;

                    break;
                case "Trunk":
                    port = 5;

                    break;
            }

            Vehicle vehicle = saveVehicle;

            if (PlayerCache.MyPlayer.Status.PlayerStates.InVehicle)
            {
                Vehicle veh = PlayerCache.MyPlayer.Ped.CurrentVehicle;

                if (veh.Doors.HasDoor((VehicleDoorIndex)port))
                {
                    if (veh.Doors[(VehicleDoorIndex)port].IsOpen)
                    {
                        veh.Doors[(VehicleDoorIndex)port].Close();
                        Notifications.ShowNotification("You closed the ~y~ " + door + "~w~.", NotificationColor.Cyan);
                    }
                    else
                    {
                        veh.Doors[(VehicleDoorIndex)port].Open();
                        Notifications.ShowNotification("You opened the ~y~ " + door + "~w~.", NotificationColor.Cyan);
                    }
                }
                else
                {
                    Notifications.ShowNotification("This vehicle doens't have a ~b~ " + door + "~w~!", NotificationColor.Red, true);
                }
            }
            else
            {
                if (vehicle == null || !vehicle.Exists()) return;
                float distanceToVeh = Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, vehicle.Position);

                if (distanceToVeh <= 20f)
                {
                    if (vehicle.Doors.HasDoor((VehicleDoorIndex)port))
                    {
                        if (vehicle.Doors[(VehicleDoorIndex)port].IsOpen)
                        {
                            vehicle.Doors[(VehicleDoorIndex)port].Close();
                            if (door == "Hood" || door == "Trunk")
                                Notifications.ShowNotification("You closed the ~y~" + door + "~w~ door.", NotificationColor.Cyan);
                        }
                        else
                        {
                            vehicle.Doors[(VehicleDoorIndex)port].Open();
                            Notifications.ShowNotification("You opened~y~" + door + "~w~ door.", NotificationColor.Cyan);
                        }
                    }
                    else
                    {
                        if (door == "Hood" || door == "Trunk")
                            Notifications.ShowNotification("this vehicles doesn't have a ~b~ " + door + "~w~!", NotificationColor.Red, true);
                        else
                            Notifications.ShowNotification("this vehicle doesn't have a ~b~ " + door + "~w~ door!", NotificationColor.Red, true);
                    }
                }
                else
                {
                    Notifications.ShowNotification("You're too far from your vehicle!", NotificationColor.Red, true);
                }
            }
        }

        private static bool window0up = true;
        private static bool window1up = true;
        private static bool window2up = true;
        private static bool window3up = true;

        public static void Windows(string finestrini)
        {
            if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle) return;
            if (PlayerCache.MyPlayer.Ped.CurrentVehicle.Driver != PlayerCache.MyPlayer.Ped) return;

            switch (finestrini)
            {
                case "Front Left" when window1up:
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].RollDown();
                    window1up = false;
                    WindowsDown = true;

                    break;
                case "Front Left":
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].RollUp();
                    window1up = true;
                    WindowsDown = false;

                    break;
                case "Front Right" when window0up:
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontRightWindow].RollDown();
                    window0up = false;
                    WindowsDown = true;

                    break;
                case "Front Right":
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontRightWindow].RollUp();
                    window0up = true;
                    WindowsDown = false;

                    break;
                case "Rear Left" when window3up:
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.BackLeftWindow].RollDown();
                    window3up = false;
                    WindowsDown = true;

                    break;
                case "Rear Left":
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.BackLeftWindow].RollUp();
                    window3up = true;
                    WindowsDown = false;

                    break;
                case "Right Rear" when window2up:
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.BackRightWindow].RollDown();
                    window2up = false;
                    WindowsDown = true;

                    break;
                case "Right Rear":
                    PlayerCache.MyPlayer.Ped.CurrentVehicle.Windows[VehicleWindowIndex.BackRightWindow].RollUp();
                    window2up = true;
                    WindowsDown = false;

                    break;
            }
        }

        public static void Save(bool saved)
        {
            if (!PlayerCache.MyPlayer.Ped.IsSittingInVehicle() || PlayerCache.MyPlayer.Ped.CurrentVehicle.Driver != PlayerCache.MyPlayer.Ped) return;

            if (!saved)
            {
                saveVehicle.AttachedBlip.Delete();
                saveVehicle = null;
                Notifications.ShowNotification("Saved vehicle ~r~removed~w~ be careful if you get too far it will be towed.", NotificationColor.Blue);
                InteractionMenu.saved = true;
            }
            else
            {
                saveVehicle = PlayerCache.MyPlayer.Ped.CurrentVehicle;
                saveVehicle.AttachBlip();
                saveVehicle.AttachedBlip.Sprite = BlipSprite.PersonalVehicleCar;
                saveVehicle.AttachedBlip.Color = BlipColor.Green;
                Notifications.ShowNotification("This ~y~" + saveVehicle.LocalizedName + "~w~ has been ~g~daved~w~ and won't be deleted if you get too far from it.", NotificationColor.GreenDark);
                InteractionMenu.saved = true;
            }
        }

        public static async void engine(bool toggle)
        {
            Vehicle vehicle = saveVehicle;
            vehicle.IsEngineRunning = toggle;
            vehicle.IsDriveable = toggle;
        }

        public static async void Lock(bool toggle)
        {
            try
            {
                Vehicle vehicle = saveVehicle;
                VehicleLockStatus islocked = vehicle.LockStatus;
                float distanceToVeh = Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, vehicle.Position);

                if (toggle)
                {
                    if (vehicle.Exists())
                    {
                        if (vehicle.Driver == PlayerCache.MyPlayer.Ped)
                        {
                            vehicle.LockStatus = VehicleLockStatus.Locked;
                            SetVehicleDoorsLockedForAllPlayers(vehicle.Handle, true);
                            Notifications.ShowNotification("You locked your ~y~" + vehicle.LocalizedName + "~w~.", NotificationColor.Cyan, true);
                            PlayVehicleDoorCloseSound(vehicle.Handle, 1);
                            InteractionMenu.closed = true;
                        }
                        else if (distanceToVeh <= 20f)
                        {
                            if (islocked == VehicleLockStatus.Unlocked)
                            {
                                vehicle.LockStatus = VehicleLockStatus.Locked;
                                SetVehicleDoorsLockedForAllPlayers(vehicle.Handle, true);
                                Notifications.ShowNotification("You locked your ~y~" + vehicle.LocalizedName + "~w~.", NotificationColor.Cyan, true);
                                await LockLightsAsync(vehicle);
                                PlayVehicleDoorCloseSound(vehicle.Handle, 1);
                                InteractionMenu.closed = true;
                            }
                            else
                            {
                                Notifications.ShowNotification("Already locked.", NotificationColor.Red);
                            }
                        }
                        else
                        {
                            Notifications.ShowNotification("You must be near your vehicle to lock it.", NotificationColor.Red);
                        }
                    }
                    else
                    {
                        Notifications.ShowNotification("No saved vehicle!", NotificationColor.Red);
                    }
                }
                else
                {
                    if (vehicle.Exists())
                    {
                        if (vehicle.Driver == PlayerCache.MyPlayer.Ped)
                        {
                            vehicle.LockStatus = VehicleLockStatus.Unlocked;
                            SetVehicleDoorsLockedForAllPlayers(vehicle.Handle, false);
                            Notifications.ShowNotification("You unlocked ~y~" + vehicle.LocalizedName + "~w~.", NotificationColor.Cyan, true);
                            PlayVehicleDoorOpenSound(vehicle.Handle, 0);
                            InteractionMenu.closed = false;
                        }
                        else if (distanceToVeh <= 20f)
                        {
                            if (islocked == VehicleLockStatus.Locked)
                            {
                                vehicle.LockStatus = VehicleLockStatus.Unlocked;
                                SetVehicleDoorsLockedForAllPlayers(vehicle.Handle, false);
                                Notifications.ShowNotification("You unlocked ~y~" + vehicle.LocalizedName + "~w~.", NotificationColor.Cyan, true);
                                await LockLightsAsync(vehicle);
                                PlayVehicleDoorOpenSound(vehicle.Handle, 0);
                                InteractionMenu.closed = false;
                            }
                            else
                            {
                                Notifications.ShowNotification("Already unlocked.", NotificationColor.Red);
                            }
                        }
                        else
                        {
                            Notifications.ShowNotification("You must be near your vehicle to unlock it.", NotificationColor.Red);
                        }
                    }
                    else
                    {
                        Notifications.ShowNotification("No saved vehicle!", NotificationColor.Red);
                    }
                }
            }
            catch
            {
                Notifications.ShowNotification("Devi prima salvare un veicolo!!");
            }
        }

        public static async Task LockLightsAsync(Vehicle vehicle)
        {
            //vehicle.SoundHorn(200);
            vehicle.IsLeftIndicatorLightOn = true;
            vehicle.IsRightIndicatorLightOn = true;
            await BaseScript.Delay(500);
            //vehicle.SoundHorn(200);
            vehicle.IsLeftIndicatorLightOn = false;
            vehicle.IsRightIndicatorLightOn = false;
            await BaseScript.Delay(500);
            vehicle.IsLeftIndicatorLightOn = true;
            vehicle.IsRightIndicatorLightOn = true;
            await BaseScript.Delay(400);
            vehicle.IsLeftIndicatorLightOn = false;
            vehicle.IsRightIndicatorLightOn = false;
        }
    }


    static void func_13801(int iParam0, int iParam1, int iParam3, int iParam4)//Position - 0x48257E
    {
        List<dynamic> uParam2 = new List<dynamic>();
        switch (iParam0)
        {
            case 0:
                switch (iParam1)
                {
                    case 0:
                        break;

                    case 1:
                        StringCopy(uParam2[1 /*16*/], "amb@code_human_in_car_mp_actions@smoke@low@ps@base", 64);
                        StringCopy(uParam2[4 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@rds@base", 64);
                        StringCopy(uParam2[5 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@rps@base", 64);
                        StringCopy(uParam2[3 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@ps@base", 64);
                        StringCopy(uParam2[8 /*16*/], "amb@code_human_in_car_mp_actions@smoke@bodhi@rps@base", 64);
                        StringCopy(uParam2[9 /*16*/], "amb@code_human_in_car_mp_actions@smoke@bodhi@rps@base", 64);
                        StringCopy(uParam2[6 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@ds@base", 64);
                        StringCopy(uParam2[7 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@ps@base", 64);
                        StringCopy(uParam2[2 /*16*/], "amb@code_human_in_car_mp_actions@smoke@std@ds@base", 64);
                        StringCopy(uParam2[0 /*16*/], "amb@code_human_in_car_mp_actions@smoke@low@ds@base", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke_car", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth_car", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse_car", 64);
                        uParam2->f_430 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        break;

                    case 2:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarfingerlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarfingerstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarfingerstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarfingerstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarfingerbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarfingerbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarfingerbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarfingerbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarfingerstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarfingerlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 3:
                        StringCopy(uParam2[1 /*16*/], "amb@code_human_in_car_mp_actions@dance@low@ps@base", 64);
                        StringCopy(uParam2[4 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@rds@base", 64);
                        StringCopy(uParam2[5 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@rps@base", 64);
                        StringCopy(uParam2[3 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@ps@base", 64);
                        StringCopy(uParam2[8 /*16*/], "amb@code_human_in_car_mp_actions@dance@bodhi@rds@base", 64);
                        StringCopy(uParam2[9 /*16*/], "amb@code_human_in_car_mp_actions@dance@bodhi@rds@base", 64);
                        StringCopy(uParam2[6 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@ps@base", 64);
                        StringCopy(uParam2[7 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@ds@base", 64);
                        StringCopy(uParam2[2 /*16*/], "amb@code_human_in_car_mp_actions@dance@std@ds@base", 64);
                        StringCopy(uParam2[0 /*16*/], "amb@code_human_in_car_mp_actions@dance@low@ds@base", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        break;

                    case 4:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarrocklow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarrockstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarrockstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarrockstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarrockbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarrockbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarrockbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarrockbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarrockstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarrocklow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 5:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarwanklow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarwankstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarwankstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarwankstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarwankbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarwankbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarwankbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarwankbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarwankstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarwanklow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 7:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarair_shagginglow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarair_shaggingstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarair_shaggingstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarair_shaggingstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarair_shaggingbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarair_shaggingbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarair_shaggingbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarair_shaggingbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarair_shaggingstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarair_shagginglow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        break;

                    case 8:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincardocklow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincardockstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincardockstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincardockstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincardockbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincardockbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincardockbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincardockbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincardockstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincardocklow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 9:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarknuckle_crunchlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarknuckle_crunchstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarknuckle_crunchstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarknuckle_crunchstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarknuckle_crunchbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarknuckle_crunchbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarknuckle_crunchbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarknuckle_crunchbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarknuckle_crunchstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarknuckle_crunchlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_490 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 10:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarsalutelow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarsalutestd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarsalutestd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarsalutestd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarsalutebodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarsalutebodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarsalutebodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarsalutebodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarsalutestd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarsalutelow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 6:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarblow_kisslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarblow_kissstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarblow_kissstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarblow_kissstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarblow_kissbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarblow_kissbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarblow_kissbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarblow_kissbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarblow_kissstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarblow_kisslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        break;

                    case 11:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarslow_claplow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarslow_clapstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarslow_clapstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarslow_clapstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarslow_clapbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarslow_clapbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarslow_clapbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarslow_clapbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarslow_clapstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarslow_claplow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 12:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarface_palmlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarface_palmstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarface_palmstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarface_palmstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarface_palmbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarface_palmbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarface_palmbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarface_palmbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarface_palmstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarface_palmlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 13:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarthumbs_uplow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarthumbs_upstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarthumbs_upstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarthumbs_upstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarthumbs_upbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarthumbs_upbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarthumbs_upbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarthumbs_upbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarthumbs_upstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarthumbs_uplow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 14:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarjazz_handslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarjazz_handsstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarjazz_handsstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarjazz_handsstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarjazz_handsbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarjazz_handsbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarjazz_handsbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarjazz_handsbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarjazz_handsstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarjazz_handslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 15:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarnose_picklow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarnose_pickstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarnose_pickstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarnose_pickstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarnose_pickbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarnose_pickbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarnose_pickbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarnose_pickbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarnose_pickstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarnose_picklow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 17:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarwavelow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarwavestd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarwavestd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarwavestd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarwavebodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarwavebodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarwavebodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarwavebodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarwavestd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarwavelow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 16:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarair_guitarlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarair_guitarstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarair_guitarstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarair_guitarstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarair_guitarbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarair_guitarbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarair_guitarbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarair_guitarbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarair_guitarstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarair_guitarlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 18:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarsurrenderlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarsurrenderstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarsurrenderstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarsurrenderstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarsurrenderbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarsurrenderbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarsurrenderbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarsurrenderbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarsurrenderstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarsurrenderlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 19:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarshushlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarshushstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarshushstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarshushstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarshushbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarshushbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarshushbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarshushbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarshushstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarshushlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 20:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarphotographylow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarphotographystd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarphotographystd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarphotographystd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarphotographybodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarphotographybodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarphotographybodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarphotographybodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarphotographystd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarphotographylow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 21:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincardjlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincardjstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincardjstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincardjstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincardjbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincardjbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincardjbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincardjbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincardjstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincardjlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 22:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarair_synthlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarair_synthstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarair_synthstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarair_synthstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarair_synthbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarair_synthbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarair_synthbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarair_synthbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarair_synthstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarair_synthlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 23:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarno_waylow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarno_waystd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarno_waystd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarno_waystd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarno_waybodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarno_waybodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarno_waybodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarno_waybodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarno_waystd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarno_waylow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 25:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarchin_brushlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarchin_brushstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarchin_brushstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarchin_brushstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarchin_brushbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarchin_brushbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarchin_brushbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarchin_brushbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarchin_brushstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarchin_brushlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 24:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarchicken_tauntlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarchicken_tauntstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarchicken_tauntstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarchicken_tauntstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarchicken_tauntbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarchicken_tauntbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarchicken_tauntbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarchicken_tauntbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarchicken_tauntstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarchicken_tauntlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 26:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarfinger_kisslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarfinger_kissstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarfinger_kissstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarfinger_kissstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarfinger_kissbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarfinger_kissbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarfinger_kissbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarfinger_kissbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarfinger_kissstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarfinger_kisslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 27:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarpeacelow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarpeacestd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarpeacestd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarpeacestd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarpeacebodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarpeacebodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarpeacebodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarpeacebodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarpeacestd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarpeacelow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 28:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincaryou_locolow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincaryou_locostd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincaryou_locostd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincaryou_locostd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincaryou_locobodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincaryou_locobodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincaryou_locobodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincaryou_locobodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincaryou_locostd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincaryou_locolow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 29:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarfreakoutlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarfreakoutstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarfreakoutstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarfreakoutstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarfreakoutbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarfreakoutbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarfreakoutbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarfreakoutbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarfreakoutstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarfreakoutlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 30:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarthumb_on_earslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarthumb_on_earsstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarthumb_on_earsstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarthumb_on_earsstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarthumb_on_earsbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarthumb_on_earsbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarthumb_on_earsbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarthumb_on_earsbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarthumb_on_earsstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarthumb_on_earslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 31:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carcry_babylow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carcry_babystd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carcry_babystd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carcry_babystd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carcry_babybodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carcry_babybodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carcry_babybodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carcry_babybodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carcry_babystd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carcry_babylow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 32:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carcut_throatlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carcut_throatstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carcut_throatstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carcut_throatstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carcut_throatbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carcut_throatbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carcut_throatbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carcut_throatbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carcut_throatstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carcut_throatlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 33:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carkarate_chopslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carkarate_chopsstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carkarate_chopsstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carkarate_chopsstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carkarate_chopsbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carkarate_chopsbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carkarate_chopsbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carkarate_chopsbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carkarate_chopsstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carkarate_chopslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 34:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carshadow_boxinglow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carshadow_boxingstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carshadow_boxingstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carshadow_boxingstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carshadow_boxingbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carshadow_boxingbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carshadow_boxingbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carshadow_boxingbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carshadow_boxingstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carshadow_boxinglow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 35:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carthe_woogielow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carthe_woogiestd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carthe_woogiestd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carthe_woogiestd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carthe_woogiebodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carthe_woogiebodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carthe_woogiebodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carthe_woogiebodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carthe_woogiestd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carthe_woogielow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 36:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intin_carstinkerlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intin_carstinkerstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intin_carstinkerstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intin_carstinkerstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intin_carstinkerbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intin_carstinkerbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intin_carstinkerbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intin_carstinkerbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intin_carstinkerstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intin_carstinkerlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 37:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarair_drumslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarair_drumsstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarair_drumsstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarair_drumsstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarair_drumsbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarair_drumsbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarair_drumsbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarair_drumsbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarair_drumsstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarair_drumslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 38:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarcall_melow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarcall_mestd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarcall_mestd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarcall_mestd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarcall_mebodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarcall_mebodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarcall_mebodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarcall_mebodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarcall_mestd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarcall_melow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 39:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarcoin_roll_and_tosslow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarcoin_roll_and_tossstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarcoin_roll_and_tosslow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_419 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_429 = joaat("vw_prop_vw_coin_01a");
                        uParam2->f_424 = 1;
                        break;

                    case 40:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarbang_banglow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarbang_bangstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarbang_bangstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarbang_bangstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarbang_bangbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarbang_bangbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarbang_bangbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarbang_bangbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarbang_bangstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarbang_banglow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 41:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarrespectlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarrespectstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarrespectstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarrespectstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarrespectbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarrespectbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarrespectbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarrespectbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarrespectstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarrespectlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 42:
                        StringCopy(uParam2[1 /*16*/], "anim@mp_player_intincarmind_blownlow@ps@", 64);
                        StringCopy(uParam2[4 /*16*/], "anim@mp_player_intincarmind_blownstd@rds@", 64);
                        StringCopy(uParam2[5 /*16*/], "anim@mp_player_intincarmind_blownstd@rps@", 64);
                        StringCopy(uParam2[3 /*16*/], "anim@mp_player_intincarmind_blownstd@ps@", 64);
                        StringCopy(uParam2[8 /*16*/], "anim@mp_player_intincarmind_blownbodhi@rds@", 64);
                        StringCopy(uParam2[9 /*16*/], "anim@mp_player_intincarmind_blownbodhi@rps@", 64);
                        StringCopy(uParam2[6 /*16*/], "anim@mp_player_intincarmind_blownbodhi@ds@", 64);
                        StringCopy(uParam2[7 /*16*/], "anim@mp_player_intincarmind_blownbodhi@ps@", 64);
                        StringCopy(uParam2[2 /*16*/], "anim@mp_player_intincarmind_blownstd@ds@", 64);
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intincarmind_blownlow@ds@", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_209), "ENTER", 64);
                        StringCopy(&(uParam2->f_225), "IDLE_A", 64);
                        StringCopy(&(uParam2->f_241), "EXIT", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;
                }
                break;

            case 1:
                switch (iParam1)
                {
                    case 0:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_upperbro_love", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_bro_love_ENTER", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_bro_love", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_bro_love_EXIT", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@bro_love", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@bro_love", 64);
                        StringCopy(&(uParam2->f_257), "bro_love", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_489 = 2;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        StringCopy(uParam2[12 /*16*/], "mp_player_int_upperbro_love", 64);
                        break;

                    case 1:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_upperfinger", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_finger_02_ENTER", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_finger_02", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_finger_02_EXIT", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@finger", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@finger", 64);
                        StringCopy(&(uParam2->f_257), "finger", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 2:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_upperwank", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_wank_02_ENTER", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_wank_02", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_wank_02_EXIT", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@wank", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@wank", 64);
                        StringCopy(&(uParam2->f_257), "wank", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        break;

                    case 3:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_upperup_yours", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_up_yours_ENTER", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_up_yours", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_up_yours_EXIT", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@up_yours", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@up_yours", 64);
                        StringCopy(&(uParam2->f_257), "up_yours", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;
                }
                break;

            case 2:
                switch (iParam1)
                {
                    case 0:
                        break;

                    case 1:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperfinger", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@finger", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@finger", 64);
                        StringCopy(&(uParam2->f_257), "finger", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intselfiethe_bird", 64);
                        break;

                    case 2:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperrock", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperrock", 64);
                        break;

                    case 3:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppersalute", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@salute", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@salute", 64);
                        StringCopy(&(uParam2->f_257), "salute", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppersalute", 64);
                        break;

                    case 4:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperwank", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@wank", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@wank", 64);
                        StringCopy(&(uParam2->f_257), "wank", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intselfiewank", 64);
                        break;

                    case 59:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_uppersmoke", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_smoke_ENTER", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_smoke", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_smoke_EXIT", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@smoke_flick", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@smoke_flick", 64);
                        StringCopy(&(uParam2->f_257), "smoke_flick", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        uParam2->f_430 = 1;
                        break;

                    case 60:
                        StringCopy(uParam2[0 /*16*/], "mp_player_intdrink", 64);
                        StringCopy(&(uParam2->f_209), "Intro", 64);
                        StringCopy(&(uParam2->f_225), "Loop", 64);
                        StringCopy(&(uParam2->f_241), "Outro", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_ecola_can");
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 61:
                        StringCopy(uParam2[0 /*16*/], "mp_player_intdrink", 64);
                        StringCopy(&(uParam2->f_209), "Intro_bottle", 64);
                        StringCopy(&(uParam2->f_225), "Loop_bottle", 64);
                        StringCopy(&(uParam2->f_241), "Outro_bottle", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_amb_beer_bottle");
                        uParam2->f_488 = 3;
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 62:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperspray_champagne", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@spray_champagne", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@spray_champagne", 64);
                        StringCopy(&(uParam2->f_257), "spray_champagne", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_420 = 1;
                        uParam2->f_429 = joaat("xs_prop_arena_champ_closed");
                        uParam2->f_428 = 1;
                        uParam2->f_424 = 1;
                        uParam2->f_488 = 3;
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        uParam2->f_422 = 1;
                        break;

                    case 63:
                        StringCopy(uParam2[0 /*16*/], "mp_player_intdrink", 64);
                        StringCopy(&(uParam2->f_209), "Intro", 64);
                        StringCopy(&(uParam2->f_225), "Loop", 64);
                        StringCopy(&(uParam2->f_241), "Outro", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_ld_can_01b");
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 39:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperraining_cash", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@raining_cash", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@raining_cash", 64);
                        StringCopy(&(uParam2->f_257), "raining_cash", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_420 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_423 = 1;
                        uParam2->f_429 = joaat("xs_prop_arena_cash_pile_l");
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperraining_cash", 64);
                        uParam2->f_422 = 1;
                        break;

                    case 58:
                        StringCopy(&(uParam2->f_369), "HLWN_22", 64);
                        StringCopy(&(uParam2->f_385), "Mask_SFX", 64);
                        StringCopy(&(uParam2->f_401), "SPEECH_PARAMS_FORCE_NORMAL", 64);
                        uParam2->f_417 = 1;
                        break;

                    case 64:
                        StringCopy(uParam2[0 /*16*/], "mp_player_inteat@pnq", 64);
                        StringCopy(&(uParam2->f_209), "intro", 64);
                        StringCopy(&(uParam2->f_225), "loop", 64);
                        StringCopy(&(uParam2->f_241), "outro", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_choc_pq");
                        uParam2->f_489 = 2;
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 65:
                        StringCopy(uParam2[0 /*16*/], "mp_player_inteat@burger", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_eat_burger_enter", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_eat_burger", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_eat_exit_burger", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_choc_ego");
                        uParam2->f_489 = 2;
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 66:
                        StringCopy(uParam2[0 /*16*/], "mp_player_inteat@burger", 64);
                        StringCopy(&(uParam2->f_209), "mp_player_int_eat_burger_enter", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_eat_burger", 64);
                        StringCopy(&(uParam2->f_241), "mp_player_int_eat_exit_burger", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationmale@rock", 64);
                        StringCopy(&(uParam2->f_257), "rock", 64);
                        uParam2->f_418 = 1;
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 0;
                        uParam2->f_427 = 0;
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_choc_meto");
                        uParam2->f_489 = 2;
                        uParam2->f_430 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 6:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperair_shagging", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@air_shagging", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@air_shagging", 64);
                        StringCopy(&(uParam2->f_257), "air_shagging", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 7:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperdock", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@dock", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@dock", 64);
                        StringCopy(&(uParam2->f_257), "dock", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intselfiedock", 64);
                        break;

                    case 8:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperknuckle_crunch", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@knuckle_crunch", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@knuckle_crunch", 64);
                        StringCopy(&(uParam2->f_257), "knuckle_crunch", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 5:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperblow_kiss", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@blow_kiss", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@blow_kiss", 64);
                        StringCopy(&(uParam2->f_257), "blow_kiss", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intselfieblow_kiss", 64);
                        break;

                    case 9:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperslow_clap", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@slow_clap", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@slow_clap", 64);
                        StringCopy(&(uParam2->f_257), "slow_clap", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_490 = 1;
                        break;

                    case 10:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperface_palm", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@face_palm", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@face_palm", 64);
                        StringCopy(&(uParam2->f_257), "face_palm", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperface_palm", 64);
                        break;

                    case 11:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperthumbs_up", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@thumbs_up", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@thumbs_up", 64);
                        StringCopy(&(uParam2->f_257), "thumbs_up", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intselfiethumbs_up", 64);
                        break;

                    case 12:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperjazz_hands", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@jazz_hands", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@jazz_hands", 64);
                        StringCopy(&(uParam2->f_257), "jazz_hands", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperjazz_hands", 64);
                        break;

                    case 13:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppernose_pick", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@nose_pick", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@nose_pick", 64);
                        StringCopy(&(uParam2->f_257), "nose_pick", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppernose_pick", 64);
                        break;

                    case 15:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperwave", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@wave", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@wave", 64);
                        StringCopy(&(uParam2->f_257), "wave", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperwave", 64);
                        break;

                    case 14:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperair_guitar", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@air_guitar", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@air_guitar", 64);
                        StringCopy(&(uParam2->f_257), "air_guitar", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperair_guitar", 64);
                        break;

                    case 16:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppersurrender", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@surrender", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@surrender", 64);
                        StringCopy(&(uParam2->f_257), "surrender", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppersurrender", 64);
                        break;

                    case 17:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppershush", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@shush", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@shush", 64);
                        StringCopy(&(uParam2->f_257), "shush", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_418 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppershush", 64);
                        break;

                    case 18:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperphotography", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@photography", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@photography", 64);
                        StringCopy(&(uParam2->f_257), "photography", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperphotography", 64);
                        break;

                    case 19:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperdj", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@dj", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@dj", 64);
                        StringCopy(&(uParam2->f_257), "dj", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperdj", 64);
                        break;

                    case 20:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperair_synth", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@air_synth", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@air_synth", 64);
                        StringCopy(&(uParam2->f_257), "air_synth", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperair_synth", 64);
                        break;

                    case 21:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperno_way", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@no_way", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@no_way", 64);
                        StringCopy(&(uParam2->f_257), "no_way", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperno_way", 64);
                        break;

                    case 23:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperchin_brush", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@chin_brush", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@chin_brush", 64);
                        StringCopy(&(uParam2->f_257), "chin_brush", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperchin_brush", 64);
                        break;

                    case 22:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperchicken_taunt", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@chicken_taunt", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@chicken_taunt", 64);
                        StringCopy(&(uParam2->f_257), "chicken_taunt", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperchicken_taunt", 64);
                        break;

                    case 25:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperpeace", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@peace", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@peace", 64);
                        StringCopy(&(uParam2->f_257), "peace", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperpeace", 64);
                        break;

                    case 24:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperfinger_kiss", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@finger_kiss", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@finger_kiss", 64);
                        StringCopy(&(uParam2->f_257), "finger_kiss", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperfinger_kiss", 64);
                        break;

                    case 26:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperyou_loco", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@you_loco", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@you_loco", 64);
                        StringCopy(&(uParam2->f_257), "you_loco", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperyou_loco", 64);
                        break;

                    case 27:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperfreakout", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@freakout", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@freakout", 64);
                        StringCopy(&(uParam2->f_257), "freakout", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        break;

                    case 28:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperthumb_on_ears", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@thumb_on_ears", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@thumb_on_ears", 64);
                        StringCopy(&(uParam2->f_257), "thumb_on_ears", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 1;
                        break;

                    case 30:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperbanging_tunes", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@banging_tunes", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@banging_tunes", 64);
                        StringCopy(&(uParam2->f_257), "banging_tunes", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 29:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperbanging_tunes_left", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@banging_tunes_left", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@banging_tunes_left", 64);
                        StringCopy(&(uParam2->f_257), "banging_tunes", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 31:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperbanging_tunes_right", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@banging_tunes_right", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@banging_tunes_right", 64);
                        StringCopy(&(uParam2->f_257), "banging_tunes", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 32:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperoh_snap", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@oh_snap", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@oh_snap", 64);
                        StringCopy(&(uParam2->f_257), "oh_snap", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 33:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercats_cradle", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@cats_cradle", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@cats_cradle", 64);
                        StringCopy(&(uParam2->f_257), "cats_cradle", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 34:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperraise_the_roof", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@raise_the_roof", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@raise_the_roof", 64);
                        StringCopy(&(uParam2->f_257), "raise_the_roof", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 35:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperfind_the_fish", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@find_the_fish", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@find_the_fish", 64);
                        StringCopy(&(uParam2->f_257), "find_the_fish", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 36:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppersalsa_roll", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@salsa_roll", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@salsa_roll", 64);
                        StringCopy(&(uParam2->f_257), "salsa_roll", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 37:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperheart_pumping", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@heart_pumping", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@heart_pumping", 64);
                        StringCopy(&(uParam2->f_257), "heart_pumping", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 38:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperuncle_disco", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@uncle_disco", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@uncle_disco", 64);
                        StringCopy(&(uParam2->f_257), "uncle_disco", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        *(uParam2[12 /*16*/]) = { *(uParam2[0 /*16*/]) };
                        break;

                    case 40:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercry_baby", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@cry_baby", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@cry_baby", 64);
                        StringCopy(&(uParam2->f_257), "cry_baby", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppercry_baby", 64);
                        break;

                    case 41:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercut_throat", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@cut_throat", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@cut_throat", 64);
                        StringCopy(&(uParam2->f_257), "cut_throat", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppercut_throat", 64);
                        break;

                    case 42:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperkarate_chops", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@karate_chops", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@karate_chops", 64);
                        StringCopy(&(uParam2->f_257), "karate_chops", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperkarate_chops", 64);
                        break;

                    case 43:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppershadow_boxing", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@shadow_boxing", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@shadow_boxing", 64);
                        StringCopy(&(uParam2->f_257), "shadow_boxing", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppershadow_boxing", 64);
                        break;

                    case 44:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperthe_woogie", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@the_woogie", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@the_woogie", 64);
                        StringCopy(&(uParam2->f_257), "the_woogie", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperthe_woogie", 64);
                        break;

                    case 45:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperstinker", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@stinker", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@stinker", 64);
                        StringCopy(&(uParam2->f_257), "stinker", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperstinker", 64);
                        break;

                    case 46:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperair_drums", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@air_drums", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@air_drums", 64);
                        StringCopy(&(uParam2->f_257), "air_drums", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperair_drums", 64);
                        break;

                    case 47:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercall_me", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@call_me", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@call_me", 64);
                        StringCopy(&(uParam2->f_257), "call_me", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppercall_me", 64);
                        break;

                    case 48:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercoin_roll_and_toss", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@coin_roll_and_toss", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@coin_roll_and_toss", 64);
                        StringCopy(&(uParam2->f_257), "coin_roll_and_toss", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppercoin_roll_and_toss", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_429 = joaat("vw_prop_vw_coin_01a");
                        uParam2->f_424 = 1;
                        break;

                    case 49:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperbang_bang", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@bang_bang", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@bang_bang", 64);
                        StringCopy(&(uParam2->f_257), "bang_bang", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperbang_bang", 64);
                        break;

                    case 50:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperrespect", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@respect", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@respect", 64);
                        StringCopy(&(uParam2->f_257), "respect", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intupperrespect", 64);
                        break;

                    case 51:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppermind_blown", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@mind_blown", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@mind_blown", 64);
                        StringCopy(&(uParam2->f_257), "mind_blown", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_489 = -3;
                        StringCopy(uParam2[12 /*16*/], "anim@mp_player_intuppermind_blown", 64);
                        break;

                    case 52:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppercrowd_invitation", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@crowd_invitation", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@crowd_invitation", 64);
                        StringCopy(&(uParam2->f_257), "crowd_invitation", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 53:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperdriver", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@driver", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@driver", 64);
                        StringCopy(&(uParam2->f_257), "driver", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 54:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intupperrunner", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@runner", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@runner", 64);
                        StringCopy(&(uParam2->f_257), "runner", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 55:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppershooting", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@shooting", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@shooting", 64);
                        StringCopy(&(uParam2->f_257), "shooting", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 56:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppersuck_it", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@suck_it", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@suck_it", 64);
                        StringCopy(&(uParam2->f_257), "suck_it", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_426 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_489 = -3;
                        break;

                    case 57:
                        StringCopy(uParam2[0 /*16*/], "anim@mp_player_intuppertake_selfie", 64);
                        StringCopy(&(uParam2->f_209), "enter", 64);
                        StringCopy(&(uParam2->f_225), "idle_a", 64);
                        StringCopy(&(uParam2->f_241), "exit", 64);
                        StringCopy(uParam2[10 /*16*/], "anim@mp_player_intcelebrationmale@take_selfie", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_player_intcelebrationfemale@take_selfie", 64);
                        StringCopy(&(uParam2->f_257), "take_selfie", 64);
                        uParam2->f_425 = 1;
                        uParam2->f_427 = 0;
                        uParam2->f_426 = 0;
                        uParam2->f_489 = -1;
                        uParam2->f_419 = 1;
                        uParam2->f_420 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_424 = 0;
                        uParam2->f_423 = 1;
                        uParam2->f_429 = joaat("prop_phone_ing_02");
                        break;
                }
                break;

            case 3:
                switch (iParam1)
                {
                    case 0:
                        StringCopy(uParam2[0 /*16*/], "mp_player_int_upper_nod", 64);
                        StringCopy(&(uParam2->f_225), "mp_player_int_nod_no", 64);
                        uParam2->f_425 = 0;
                        uParam2->f_418 = 0;
                        uParam2->f_489 = 2;
                        StringCopy(uParam2[12 /*16*/], "mp_player_int_upper_nod", 64);
                        break;

                    case 1:
                        StringCopy(uParam2[0 /*16*/], "amb@code_human_in_car_mp_actions@nod@low@ds@base", 64);
                        StringCopy(&(uParam2->f_225), "nod_no", 64);
                        uParam2->f_425 = 0;
                        uParam2->f_418 = 0;
                        uParam2->f_489 = 1;
                        break;

                    case 2:
                        StringCopy(uParam2[0 /*16*/], "amb@code_human_in_car_mp_actions@nod@low@ds@base", 64);
                        StringCopy(&(uParam2->f_225), "nod_no", 64);
                        uParam2->f_425 = 0;
                        uParam2->f_418 = 0;
                        uParam2->f_489 = 0;
                        break;

                    case 3:
                        StringCopy(uParam2[0 /*16*/], "amb@code_human_in_car_mp_actions@nod@std@ds@base", 64);
                        StringCopy(&(uParam2->f_225), "nod_no", 64);
                        uParam2->f_425 = 0;
                        uParam2->f_418 = 0;
                        uParam2->f_489 = 1;
                        break;

                    case 4:
                        StringCopy(uParam2[10 /*16*/], "anim@mp_freemode_return@m@idle", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_freemode_return@f@idle", 64);
                        StringCopy(&(uParam2->f_257), "idle_a", 64);
                        break;

                    case 5:
                        StringCopy(uParam2[10 /*16*/], "anim@mp_freemode_return@m@idle", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_freemode_return@f@idle", 64);
                        StringCopy(&(uParam2->f_257), "idle_b", 64);
                        break;

                    case 6:
                        StringCopy(uParam2[10 /*16*/], "anim@mp_freemode_return@m@idle", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_freemode_return@f@idle", 64);
                        StringCopy(&(uParam2->f_257), "idle_c", 64);
                        if (iParam3 && iParam4)
                        {
                        }
                        else
                        {
                            uParam2->f_419 = 1;
                            uParam2->f_421 = 1;
                            uParam2->f_429 = joaat("prop_npc_phone");
                        }
                        break;

                    case 7:
                        StringCopy(uParam2[10 /*16*/], "anim@mp_freemode_return@m@fail", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@mp_freemode_return@f@fail", 64);
                        StringCopy(&(uParam2->f_257), "fail_a", 64);
                        break;

                    case 8:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(&(uParam2->f_257), "respawn_a_ped_a", 64);
                        break;

                    case 9:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(&(uParam2->f_257), "respawn_a_ped_b_smoke", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 10:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(&(uParam2->f_257), "respawn_a_ped_c", 64);
                        break;

                    case 11:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_a", 64);
                        StringCopy(&(uParam2->f_257), "respawn_a_ped_d_smoke", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 12:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(&(uParam2->f_257), "respawn_b_ped_a", 64);
                        break;

                    case 13:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(&(uParam2->f_257), "respawn_b_ped_b_smoke", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 14:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(&(uParam2->f_257), "respawn_b_ped_c", 64);
                        break;

                    case 15:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_b", 64);
                        StringCopy(&(uParam2->f_257), "respawn_b_ped_d_smoke", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 16:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(&(uParam2->f_257), "respawn_c_ped_a", 64);
                        break;

                    case 17:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(&(uParam2->f_257), "respawn_c_ped_b", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_429 = joaat("prop_npc_phone");
                        break;

                    case 18:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(&(uParam2->f_257), "respawn_c_ped_c", 64);
                        break;

                    case 19:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_c", 64);
                        StringCopy(&(uParam2->f_257), "respawn_c_ped_d", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 20:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(&(uParam2->f_257), "respawn_d_ped_a", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 21:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(&(uParam2->f_257), "respawn_d_ped_b", 64);
                        break;

                    case 22:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(&(uParam2->f_257), "respawn_d_ped_c", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 23:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_d", 64);
                        StringCopy(&(uParam2->f_257), "respawn_d_ped_d", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 24:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(&(uParam2->f_257), "respawn_e_ped_a", 64);
                        break;

                    case 25:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(&(uParam2->f_257), "respawn_e_ped_b", 64);
                        break;

                    case 26:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(&(uParam2->f_257), "respawn_e_ped_c", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 27:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_e", 64);
                        StringCopy(&(uParam2->f_257), "respawn_e_ped_d", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_429 = joaat("prop_npc_phone");
                        break;

                    case 28:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(&(uParam2->f_257), "respawn_f_ped_a", 64);
                        break;

                    case 29:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(&(uParam2->f_257), "respawn_f_ped_b", 64);
                        break;

                    case 30:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(&(uParam2->f_257), "respawn_f_ped_c", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 31:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_f", 64);
                        StringCopy(&(uParam2->f_257), "respawn_f_ped_d", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_421 = 1;
                        uParam2->f_429 = joaat("prop_npc_phone");
                        break;

                    case 32:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(&(uParam2->f_257), "respawn_g_ped_a", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_429 = joaat("prop_ecola_can");
                        break;

                    case 33:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(&(uParam2->f_257), "respawn_g_ped_b", 64);
                        break;

                    case 34:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(&(uParam2->f_257), "respawn_g_ped_c", 64);
                        uParam2->f_419 = 1;
                        uParam2->f_422 = 1;
                        uParam2->f_429 = joaat("prop_cs_ciggy_01");
                        uParam2->f_431 = 1;
                        StringCopy(&(uParam2->f_432), "ent_anim_cig_smoke", 64);
                        uParam2->f_448 = { -0.08f, 0f, 0f };
                        uParam2->f_451 = { 0f, 0f, 0f };
                        uParam2->f_454 = 1;
                        StringCopy(&(uParam2->f_455), "ent_anim_cig_exhale_mth", 64);
                        uParam2->f_471 = 1;
                        StringCopy(&(uParam2->f_472), "ent_anim_cig_exhale_nse", 64);
                        break;

                    case 35:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@variations@variation_g", 64);
                        StringCopy(&(uParam2->f_257), "respawn_g_ped_d", 64);
                        break;

                    case 36:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(&(uParam2->f_257), "post_pacific_finale_respawn_ped_a", 64);
                        break;

                    case 37:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(&(uParam2->f_257), "post_pacific_finale_respawn_ped_b", 64);
                        break;

                    case 38:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(&(uParam2->f_257), "post_pacific_finale_respawn_ped_c", 64);
                        break;

                    case 39:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@pacific", 64);
                        StringCopy(&(uParam2->f_257), "post_pacific_finale_respawn_ped_d", 64);
                        break;

                    case 40:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@fleeca", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@fleeca", 64);
                        StringCopy(&(uParam2->f_257), "post_fleeca_finale_respawn_ped_a", 64);
                        break;

                    case 41:
                        StringCopy(uParam2[10 /*16*/], "anim@heists@team_respawn@fleeca", 64);
                        StringCopy(uParam2[11 /*16*/], "anim@heists@team_respawn@fleeca", 64);
                        StringCopy(&(uParam2->f_257), "post_fleeca_finale_respawn_ped_b", 64);
                        break;
                }
                break;
        }
    }

    public class InteractionAnimation
    {
        public string dictBase { get; set; }
        public string dictAdvanced { get; set; }
    }
}