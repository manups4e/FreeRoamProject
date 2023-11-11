﻿using System.Collections.Generic;
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

    public class InteractionAnimation
    {
        public string dictBase { get; set; }
        public string dictAdvanced { get; set; }
    }
}