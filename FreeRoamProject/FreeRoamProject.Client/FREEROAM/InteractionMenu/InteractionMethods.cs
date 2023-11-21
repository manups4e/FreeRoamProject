using FreeRoamProject.Client;
using FreeRoamProject.Client.Handlers;
using System;
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
        internal static int CurrentAnimMode;
        internal static int CurrentAnimSelection;
        internal static bool switchingVisor = false;
        internal static bool canPerform;
        internal static int[] playersArray = new int[64];

        #region TO BE LOADED BY PLAYER LOGIN AND SAVED
        public static InteractionAnimation Anim = new InteractionAnimation();
        #endregion

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += AccessingEvents_OnFreeRoamSpawn;
            AccessingEvents.OnFreeRoamLeave += AccessingEvents_OnFreeRoamLeave;
        }

        private static void AccessingEvents_OnFreeRoamLeave(PlayerClient client)
        {
            TickController.TickHUD.Remove(InteractionMenu.Enable);
            TickController.TickHUD.Remove(InteractionMenuTick);
            TickController.TickGenerics.Remove(LightingClothingsTick);
        }

        private static void AccessingEvents_OnFreeRoamSpawn(PlayerClient client)
        {
            TickController.TickHUD.Add(InteractionMenu.Enable);
            TickController.TickHUD.Add(InteractionMenuTick);
            TickController.TickGenerics.Add(LightingClothingsTick);
        }

        internal static async Task LightingClothingsTick()
        {
            int iVar3 = GetGameTimer();
            foreach (PlayerClient client in ClientMain.Instance.Clients)
            {
                //ClientMain.Logger.Debug(client.User.Character.Stats.ToJson());
                int iVar8 = client.Handle;
                Ped ped = client.Ped;
                if (!ped.IsInjured && DoesEntityHaveDrawable(ped.Handle) && DoesEntityHavePhysics(ped.Handle) && HaveAllStreamingRequestsCompleted(ped.Handle) && IsPedShaderEffectValid(ped.Handle))
                {
                    float fVar4 = GetPedEmissiveIntensity(ped.Handle);
                    float fVar5 = -1f;
                    float fVar6 = 0f;
                    float fVar7 = 0f;
                    switch (client.Status.FreeRoamStates.IlluminatedClothing)
                    {
                        case 0:
                            if (fVar4 != 1f)
                            {
                                fVar5 = 1f;
                                playersArray[iVar8] = iVar3;
                            }
                            break;
                        case 1:
                            if (playersArray[iVar8] == -1)
                            {
                                playersArray[iVar8] = iVar3;
                            }
                            fVar6 = fVar4;
                            if (fVar6 < 0.5f)
                            {
                                fVar6 = 0f;
                            }
                            else
                            {
                                fVar6 = 1f;
                            }
                            if (iVar3 >= playersArray[iVar8] + 1000)
                            {
                                if (fVar6 < 0.5f)
                                {
                                    fVar6 = 1f;
                                }
                                else
                                {
                                    fVar6 = 0f;
                                }
                            }
                            if (fVar4 != fVar6)
                            {
                                fVar5 = fVar6;
                                playersArray[iVar8] = iVar3;
                            }
                            break;
                        case 2:
                            if (playersArray[iVar8] == -1)
                            {
                                playersArray[iVar8] = iVar3;
                            }
                            fVar7 = Sin((iVar3 - playersArray[iVar8]) * 0.2f);
                            fVar7 = (fVar7 + 1f) * 0.5f;
                            if (fVar4 != fVar7)
                            {
                                fVar5 = fVar7;
                            }
                            break;
                        case 3:
                            if (fVar4 != 0f)
                            {
                                fVar5 = 0f;
                                playersArray[iVar8] = iVar3;
                            }
                            break;
                        default:
                            fVar5 = 1f;
                            playersArray[iVar8] = iVar3;
                            break;
                    }
                    if (fVar5 != -1f)
                    {
                        if (fVar5 < 0f)
                        {
                            fVar5 = 0f;
                        }
                        if (fVar5 > 1f)
                        {
                            fVar5 = 1f;
                        }
                        if (fVar4 != fVar5)
                        {
                            SetPedEmissiveIntensity(ped.Handle, fVar5);
                        }
                    }
                }
            }
        }

        internal static async Task InteractionMenuTick()
        {
            if (!MenuHandler.IsAnyMenuOpen)
            {
                Tuple<bool, int> kbDouble = await Input.HasControlBeenPressedMultipleTimes(Control.SpecialAbilityPC, FreeRoamProject.Client.PadCheck.Keyboard, frameTime: 500);
                Tuple<bool, int> GamePadDouble = await Input.HasControlBeenPressedMultipleTimes(Control.SpecialAbility, Control.SpecialAbilitySecondary, FreeRoamProject.Client.PadCheck.Controller, frameTime: 500);

                // do we need it in another tick?
                if (await Input.IsControlStillPressedAsync(Control.SpecialAbilityPC, FreeRoamProject.Client.PadCheck.Keyboard, timeout: 500) ||
                    (await Input.IsControlStillPressedAsync(Control.SpecialAbility, FreeRoamProject.Client.PadCheck.Controller, timeout: 500) &&
                    await Input.IsControlStillPressedAsync(Control.SpecialAbilitySecondary, FreeRoamProject.Client.PadCheck.Controller, timeout: 500)) ||
                    kbDouble.Item1 || GamePadDouble.Item1)
                {
                    if (CurrentAnimSelection == 0) return;
                    await PerformCurrentAction(true);
                }
                else if (kbDouble.Item2 == 1 || (GamePadDouble.Item2 == 1))
                {
                    if (CurrentAnimSelection == 0) return;
                    await PerformCurrentAction(false);
                }
            }
            else
            {
                // DO WE NEED IT?...
                Ped playerPed = PlayerCache.MyClient.Ped;
                UIMenu curMenu = (UIMenu)MenuHandler.CurrentMenu;
                if (curMenu == InteractionMenu.MainMenu ||
                    curMenu == InteractionMenu.GangsMenu ||
                    curMenu == InteractionMenu.ObjectivesMenu ||
                    curMenu == InteractionMenu.StyleMenu ||
                    curMenu == InteractionMenu.VehContr ||
                    curMenu == InteractionMenu.ServicesMenu ||
                    curMenu == InteractionMenu.MapBlipOptMenu ||
                    curMenu == InteractionMenu.ImpromptuRaceMenu ||
                    curMenu == InteractionMenu.HighlightPlayerMenu)
                {
                    if (curMenu == InteractionMenu.StyleMenu)
                    {
                        if (curMenu.CurrentSelection == 9)
                        {
                            Tuple<bool, int> doubleTap = await Input.HasControlBeenPressedMultipleTimes(Control.FrontendAccept);
                            if (doubleTap.Item1)
                            {
                                if (PlayerCache.MyClient.Ped.IsOnFoot)
                                {
                                    if (CurrentAnimSelection == 0) return;
                                    await PerformCurrentAction(true);
                                }
                            }
                            else if (doubleTap.Item2 == 1)
                            {
                                if (CurrentAnimSelection == 0) return;
                                await PerformCurrentAction(false);
                            }
                        }
                    }
                }
            }
        }

        public static async Task PerformCurrentAction(bool @double)
        {
            int ped = PlayerCache.MyClient.Ped.Handle;
            #region loadAnim
            Anim = func_13801(CurrentAnimMode, CurrentAnimSelection, true, true); // param2 is the anim index.. 0 == none

            /* TODO: perform this control for these animations
                    CurrentAnimSelection == 39 when PlayerCache.MyPlayer.Ped.IsOnFoot => Game.GetGXTEntry("PIM_HANIM3"), : take $~1~ from your wallet with each use
                    CurrentAnimSelection == 62 when PlayerCache.MyPlayer.Ped.IsOnFoot => Game.GetGXTEntry("PIM_HANIM4"), : requires Blêuter'd Champagne purchased from the Arena War Spectator Box
                    CurrentAnimSelection == 58 => Game.GetGXTEntry("PIM_HANIM5"), : requires a Horror Pumpkin Mask to be equipped
             */


            if (@double && !VehicleChecker.IsInVehicle)
            {

                string animDict = PlayerCache.Character.Skin.Sex == "Male" ? Anim.uParam2[10] : Anim.uParam2[11];
                Anim.AnimIndex = CurrentAnimSelection;
                Anim.SelectedDict = animDict;
                RequestAnimDict(animDict);
                while (!HasAnimDictLoaded(animDict)) await BaseScript.Delay(0);
                PlayFacialAnim(ped, animDict, Anim.f_257 + "_facial");
                int seqTask = 0;
                OpenSequenceTask(ref seqTask);
                TaskPlayAnim(0, animDict, Anim.f_257, -8.0f, 8.0f, -1, 0, 0, false, false, false);
                CloseSequenceTask(seqTask);
                TaskPerformSequence(ped, seqTask);
                ClearSequenceTask(ref seqTask);
                RemoveAnimDict(animDict);
                canPerform = true;
                if (MenuHandler.IsAnyMenuOpen)
                    ((UIMenu)MenuHandler.CurrentMenu).MenuItems[9].Enabled = false;
                SetPlayerControl(ped, false, 1 << 8);
            }
            else
            {
                string animDict = Anim.uParam2[0];
                Anim.AnimIndex = CurrentAnimSelection;
                Anim.SelectedDict = animDict;
                RequestAnimDict(animDict);
                while (!HasAnimDictLoaded(animDict)) await BaseScript.Delay(0);
                if (Anim.f_417 == 1)
                {
                    if (!IsAmbientSpeechPlaying(ped))
                    {
                        PlayPedAmbientSpeechWithVoiceNative(ped, Anim.f_369, Anim.f_385, Anim.f_401, true);
                        return;
                    }
                }
                if (CurrentAnimMode == 0)
                {
                    int seat = (int)Anim.SeatIndex;
                    RemoveAnimDict(animDict);
                    animDict = Anim.uParam2[seat + 1];
                    Anim.SelectedDict = animDict;
                    RequestAnimDict(animDict);
                    while (!HasAnimDictLoaded(animDict)) await BaseScript.Delay(0);
                }
                int seqTask = 0;
                OpenSequenceTask(ref seqTask);
                TaskPlayAnim(0, animDict, Anim.f_209, -8.0f, 8.0f, -1, 0, 0, false, false, false);
                TaskPlayAnim(0, animDict, Anim.f_225, -8.0f, 8.0f, -1, 0, 0, false, false, false);
                TaskPlayAnim(0, animDict, Anim.f_241, -8.0f, 8.0f, -1, 0, 0, false, false, false);
                CloseSequenceTask(seqTask);
                TaskPerformSequence(ped, seqTask);
                ClearSequenceTask(ref seqTask);
                RemoveAnimDict(animDict);
                SetPlayerControl(ped, false, 1 << 8);
                if (MenuHandler.IsAnyMenuOpen)
                    ((UIMenu)MenuHandler.CurrentMenu).MenuItems[9].Enabled = false;
                canPerform = true;
            }
            #endregion

            #region AnimUpdate
            while (canPerform)
            {
                await BaseScript.Delay(0);
                DisableAllControlActions(0);
                DisableAllControlActions(1);
                DisableAllControlActions(2);
                if (HasAnimEventFired(ped, Functions.HashUint("CREATE")) || HasAnimEventFired(ped, Functions.HashUint("GripCash_L")) || HasAnimEventFired(ped, Functions.HashUint("GripBottle")) || HasAnimEventFired(ped, Functions.HashUint("Create_whiskey_bottle")))
                {
                    if (Anim.animProp == 0)
                    {
                        SetLocalPlayerCanUsePickupsWithThisModel(Anim.f_429, true);
                        Vector3 coords = GetPedBoneCoords(ped, 28422, 0, 0, 0);
                        Anim.animProp = (await Functions.CreateProp((int)Anim.f_429, coords + new Vector3(0, 0, -5f), new Vector3(), false, false)).Handle;
                        DetachEntity(Anim.animProp, false, true);
                        if (VehicleChecker.IsInVehicle || Anim.f_424 == 1)
                            AttachEntityToEntity(Anim.animProp, ped, GetPedBoneIndex(ped, 28422), 0, 0, 0, 0, 0, 0, true, true, false, false, 2, true);
                        else
                            AttachEntityToEntity(Anim.animProp, ped, GetPedBoneIndex(ped, 60309), 0, 0, 0, 0, 0, 0, true, true, false, false, 2, true);
                        DisableCamCollisionForObject(Anim.animProp);
                        SetEntityNoCollisionEntity(Anim.animProp, ped, false);
                    }
                    if (Anim.animProp != 0)
                    {
                        if (Anim.f_431 == 1)
                        {
                            RequestNamedPtfxAsset("scr_mp_cig");
                            while (!HasNamedPtfxAssetLoaded("scr_mp_cig")) await BaseScript.Delay(0);
                            UseParticleFxAsset("scr_mp_cig");
                            Anim.particle = StartParticleFxLoopedOnEntity(Anim.f_432, Anim.animProp, Anim.f_448.X, Anim.f_448.Y, Anim.f_448.Z, Anim.f_451.X, Anim.f_451.Y, Anim.f_451.Z, 1f, false, false, false);
                        }
                    }
                }
                if (HasAnimEventFired(ped, Functions.HashUint("EXHALE")) || HasAnimEventFired(ped, Functions.HashUint("LOOP_EVENT")))
                {
                    RequestNamedPtfxAsset("scr_mp_cig");
                    while (!HasNamedPtfxAssetLoaded("scr_mp_cig")) await BaseScript.Delay(0);
                    UseParticleFxAsset("scr_mp_cig");
                    if (Anim.f_454 == 1)
                        StartParticleFxNonLoopedOnPedBone(Anim.f_455, ped, -0.02f, 0.13f, 0f, 0f, 0f, 0f, 31086, 1f, false, false, false);
                    if (Anim.f_471 == 1)
                        StartParticleFxNonLoopedOnPedBone(Anim.f_472, ped, 0.02f, 0.16f, 0f, 0f, 0f, 0f, 31086, 1f, false, false, false);
                }
                if (Anim.AnimIndex == 62)
                {
                    if (HasAnimEventFired(ped, Functions.HashUint("OpenBottle")))
                    {
                        if (IsEntityAttachedToAnyPed(Anim.animProp) && DoesEntityHaveDrawable(Anim.animProp))
                        {
                            Vector3 coords = GetEntityCoords(Anim.animProp, false);
                            int prop = (await Functions.CreateProp(Functions.HashInt("xs_Prop_Arena_Champ_Open"), coords + new Vector3(0, 0, -5f), new Vector3(), false, false)).Handle;
                            DetachEntity(Anim.animProp, false, true);
                            DeleteObject(ref Anim.animProp);
                            Anim.animProp = prop;
                            AttachEntityToEntity(Anim.animProp, ped, GetPedBoneIndex(ped, 28422), 0, 0, 0, 0, 0, 0, true, true, false, false, 2, true);
                            RequestNamedPtfxAsset("scr_ba_club");
                            while (!HasNamedPtfxAssetLoaded("scr_ba_club"))
                                await BaseScript.Delay(0);
                            UseParticleFxAsset("scr_ba_club");
                            Anim.particle = StartParticleFxLoopedOnEntityBone("scr_ba_club_champagne_spray", Anim.animProp, 0, 0, 0, 0, 0, 0, GetEntityBoneIndexByName(Anim.animProp, "VFX"), 1f, false, false, false);
                            DisableCamCollisionForObject(Anim.animProp);
                            SetEntityNoCollisionEntity(Anim.animProp, ped, false);
                        }
                    }
                    if ((!@double && GetEntityAnimCurrentTime(ped, Anim.SelectedDict, Anim.f_225) > 0.5f) || (@double && GetEntityAnimCurrentTime(ped, Anim.SelectedDict, Anim.f_257) > 0.5f))
                    {
                        if (DoesParticleFxLoopedExist(Anim.particle))
                        {
                            StopParticleFxLooped(Anim.particle, false);
                        }
                    }
                }
                if (Anim.AnimIndex == 39)
                {
                    if (HasAnimEventFired(ped, Functions.HashUint("GripCash_M")))
                    {
                        Vector3 coords = GetEntityCoords(Anim.animProp, false);
                        int prop = (await Functions.CreateProp(Functions.HashInt("xs_Prop_Arena_Cash_Pile_M"), coords + new Vector3(0, 0, -5f), new Vector3(), false, false)).Handle;
                        DetachEntity(Anim.animProp, false, true);
                        DeleteObject(ref Anim.animProp);
                        Anim.animProp = prop;
                        AttachEntityToEntity(Anim.animProp, ped, GetPedBoneIndex(ped, 60309), 0, 0, 0, 0, 0, 0, true, true, false, false, 2, true);
                    }
                    if (HasAnimEventFired(ped, Functions.HashUint("GripCash_S")))
                    {
                        Vector3 coords = GetEntityCoords(Anim.animProp, false);
                        int prop = (await Functions.CreateProp(Functions.HashInt("xs_Prop_Arena_Cash_Pile_S"), coords + new Vector3(0, 0, -5f), new Vector3(), false, false)).Handle;
                        DetachEntity(Anim.animProp, false, true);
                        DeleteObject(ref Anim.animProp);
                        Anim.animProp = prop;
                        AttachEntityToEntity(Anim.animProp, ped, GetPedBoneIndex(ped, 60309), 0, 0, 0, 0, 0, 0, true, true, false, false, 2, true);
                    }
                    if (HasAnimEventFired(ped, Functions.HashUint("vfx_xs_raining_cash_start")))
                    {
                        if (IsEntityAttachedToAnyPed(Anim.animProp) && DoesEntityHaveDrawable(Anim.animProp))
                        {
                            RequestNamedPtfxAsset("scr_xs_celebration");
                            while (!HasNamedPtfxAssetLoaded("scr_xs_celebration")) await BaseScript.Delay(0);
                            UseParticleFxAsset("scr_xs_celebration");
                            Anim.particle = StartParticleFxLoopedOnEntityBone("scr_xs_money_rain", ped, 0, 0, 0, 0, 90f, 0, GetPedBoneIndex(ped, 60309), 1f, false, false, false);
                        }
                    }
                    if (HasAnimEventFired(ped, Functions.HashUint("vfx_xs_raining_cash_stop")))
                    {
                        if (DoesParticleFxLoopedExist(Anim.particle))
                        {
                            StopParticleFxLooped(Anim.particle, false);
                        }
                    }
                }

                if (HasAnimEventFired(ped, Functions.HashUint("DELETE")) || HasAnimEventFired(ped, Functions.HashUint("RELEASE")) || HasAnimEventFired(ped, Functions.HashUint("ReleaseCash")) || HasAnimEventFired(ped, Functions.HashUint("ReleaseBottle")))
                {
                    if (DoesEntityExist(Anim.animProp))
                    {
                        if (DoesParticleFxLoopedExist(Anim.particle))
                            StopParticleFxLooped(Anim.particle, false);
                        if (DoesEntityExist(Anim.animProp))
                            DeleteObject(ref Anim.animProp);
                    }
                }
                if (GetEntityAlpha(ped) < 255)
                {
                    SetEntityAlpha(Anim.animProp, 0, 0);
                    if (Anim.particle != -1 && DoesParticleFxLoopedExist(Anim.particle))
                    {
                        StopParticleFxLooped(Anim.particle, false);
                    }
                }
                else if (GetEntityAlpha(Anim.animProp) == 0)
                {
                    if (Anim.f_431 == 1)
                    {
                        Anim.particle = StartParticleFxLoopedOnEntity(Anim.f_432, Anim.animProp, Anim.f_448.X, Anim.f_448.Y, Anim.f_448.Z, Anim.f_451.X, Anim.f_451.Y, Anim.f_451.Z, 1f, false, false, false);
                    }
                }
                if (GetSequenceProgress(ped) == -1)
                {
                    RemoveNamedPtfxAsset(Anim.f_432);
                    SetLocalPlayerCanUsePickupsWithThisModel(Anim.f_429, false);
                    RemoveAnimDict(Anim.SelectedDict);
                    canPerform = false;
                    SetPlayerControl(ped, true, 0);
                    if (MenuHandler.IsAnyMenuOpen)
                        ((UIMenu)MenuHandler.CurrentMenu).MenuItems[9].Enabled = true;
                    return;
                }
            }
            #endregion
        }

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
            string sex = PlayerCache.Character.Skin.Sex;
            switch (selection)
            {
                case 0:
                    RemoveClipSets(0);
                    ResetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, 0.25f);
                    break;
                case 1:
                    RequestClipSet(sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, sex == "Male" ? "MOVE_M@FEMME@" : "MOVE_F@FEMME@", 0.25f);
                    RemoveClipSets(1);
                    break;

                case 2:
                    RequestClipSet(sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, sex == "Male" ? "MOVE_M@GANGSTER@NG" : "MOVE_F@GANGSTER@NG", 0.25f);
                    RemoveClipSets(2);
                    break;

                case 3:
                    RequestClipSet(sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, sex == "Male" ? "MOVE_M@POSH@" : "MOVE_F@POSH@", 0.25f);
                    RemoveClipSets(3);
                    break;

                case 4:
                    RequestClipSet(sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@");
                    while (!HasClipSetLoaded(sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, sex == "Male" ? "MOVE_M@TOUGH_GUY@" : "MOVE_F@TOUGH_GUY@", 0.25f);
                    RemoveClipSets(4);
                    break;

                case 5:
                    RequestClipSet(sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@");
                    while (!HasClipSetLoaded(sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@")) await BaseScript.Delay(0);
                    SetPedMovementClipset(PlayerCache.MyClient.Ped.Handle, sex == "Male" ? "ANIM@MOVE_M@GROOVING@" : "ANIM@MOVE_F@GROOVING@", 0.25f);
                    RemoveClipSets(5);
                    break;
            }
        }

        internal static void RemoveClipSets(int iParam0)//Position - 0x4FE31E
        {
            string sex = PlayerCache.Character.Skin.Sex;
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
            Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, mood, 0);
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

            if (PlayerCache.MyClient.Status.PlayerStates.InVehicle)
            {
                Vehicle veh = VehicleChecker.CurrentVehicle;

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
                float distanceToVeh = Vector3.Distance(PlayerCache.MyClient.Position.ToVector3, vehicle.Position);

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
            if (!PlayerCache.MyClient.Status.PlayerStates.InVehicle) return;
            if (VehicleChecker.CurrentVehicle.Driver != PlayerCache.MyClient.Ped) return;

            switch (finestrini)
            {
                case "Front Left" when window1up:
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].RollDown();
                    window1up = false;
                    WindowsDown = true;

                    break;
                case "Front Left":
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].RollUp();
                    window1up = true;
                    WindowsDown = false;

                    break;
                case "Front Right" when window0up:
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.FrontRightWindow].RollDown();
                    window0up = false;
                    WindowsDown = true;

                    break;
                case "Front Right":
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.FrontRightWindow].RollUp();
                    window0up = true;
                    WindowsDown = false;

                    break;
                case "Rear Left" when window3up:
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.BackLeftWindow].RollDown();
                    window3up = false;
                    WindowsDown = true;

                    break;
                case "Rear Left":
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.BackLeftWindow].RollUp();
                    window3up = true;
                    WindowsDown = false;

                    break;
                case "Right Rear" when window2up:
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.BackRightWindow].RollDown();
                    window2up = false;
                    WindowsDown = true;

                    break;
                case "Right Rear":
                    VehicleChecker.CurrentVehicle.Windows[VehicleWindowIndex.BackRightWindow].RollUp();
                    window2up = true;
                    WindowsDown = false;

                    break;
            }
        }

        public static void Save(bool saved)
        {
            if (!PlayerCache.MyClient.Ped.IsSittingInVehicle() || VehicleChecker.CurrentVehicle.Driver != PlayerCache.MyClient.Ped) return;

            if (!saved)
            {
                saveVehicle.AttachedBlip.Delete();
                saveVehicle = null;
                Notifications.ShowNotification("Saved vehicle ~r~removed~w~ be careful if you get too far it will be towed.", NotificationColor.Blue);
                InteractionMenu.saved = true;
            }
            else
            {
                saveVehicle = VehicleChecker.CurrentVehicle;
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
                float distanceToVeh = Vector3.Distance(PlayerCache.MyClient.Position.ToVector3, vehicle.Position);

                if (toggle)
                {
                    if (vehicle.Exists())
                    {
                        if (vehicle.Driver == PlayerCache.MyClient.Ped)
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
                        if (vehicle.Driver == PlayerCache.MyClient.Ped)
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

        public static async Task SwitchComponent(bool glasses, int animDir)
        {
            switchingVisor = true;
            if (InteractionMenu.MainMenu != null && ((UIMenu)MenuHandler.CurrentMenu).Subtitle == Game.GetGXTEntry("PIM_TITLESTYL"))
            {
                ((UIMenu)MenuHandler.CurrentMenu).MenuItems[6].Enabled = false;
            }
            Ped playerPed = PlayerCache.MyClient.Ped;
            int pedHandle = playerPed.Handle;
            int component = GetPedPropIndex(pedHandle, 0);
            int texture = GetPedPropTextureIndex(pedHandle, 0);
            int newHelmet = component;
            int newHelmetTexture = texture;
            AltPropVariationData[] newHelmetData = Game.GetAltPropVariationData(pedHandle, 0);
            if (newHelmetData != null && newHelmetData.Length > 0)
            {
                newHelmet = newHelmetData[0].altPropVariationIndex;
                newHelmetTexture = newHelmetData[0].altPropVariationTexture;
            }

            string animName = animDir == 1 ? "visor_up" : "visor_down";

            if (glasses)
                animName.Replace("visor", "goggles");

            string animDict = "anim@mp_helmets@on_foot";

            if (GetFollowPedCamViewMode() == 4)
            {
                animName = "pov_" + animName;
            }
            if (playerPed.IsInVehicle())
            {
                // why tho?
                if (glasses)
                {
                    return;
                }
                Vehicle veh = playerPed.CurrentVehicle;
                if (veh != null && veh.Exists() && !veh.IsDead && (veh.Model.IsBicycle || veh.Model.IsBike || veh.Model.IsQuadbike))
                {
                    if (veh.Model.IsQuadbike)
                    {
                        animDict = "anim@mp_helmets@on_bike@quad";
                    }
                    else if (veh.Model.IsBike)
                    {
                        List<uint> sportBikes = new List<uint>()
                        {
                            (uint)GetHashKey("AKUMA"),
                            (uint)GetHashKey("BATI"),
                            (uint)GetHashKey("BATI2"),
                            (uint)GetHashKey("CARBONRS"),
                            (uint)GetHashKey("DEFILER"),
                            (uint)GetHashKey("DIABLOUS2"),
                            (uint)GetHashKey("DOUBLE"),
                            (uint)GetHashKey("FCR"),
                            (uint)GetHashKey("FCR2"),
                            (uint)GetHashKey("HAKUCHOU"),
                            (uint)GetHashKey("HAKUCHOU2"),
                            (uint)GetHashKey("LECTRO"),
                            (uint)GetHashKey("NEMESIS"),
                            (uint)GetHashKey("OPPRESSOR"),
                            (uint)GetHashKey("OPPRESSOR2"),
                            (uint)GetHashKey("PCJ"),
                            (uint)GetHashKey("RUFFIAN"),
                            (uint)GetHashKey("SHOTARO"),
                            (uint)GetHashKey("VADER"),
                            (uint)GetHashKey("VORTEX"),
                        };
                        List<uint> chopperBikes = new List<uint>()
                        {
                            (uint)GetHashKey("SANCTUS"),
                            (uint)GetHashKey("ZOMBIEA"),
                            (uint)GetHashKey("ZOMBIEB"),
                        };
                        List<uint> dirtBikes = new List<uint>()
                        {
                            (uint)GetHashKey("BF400"),
                            (uint)GetHashKey("ENDURO"),
                            (uint)GetHashKey("MANCHEZ"),
                            (uint)GetHashKey("SANCHEZ"),
                            (uint)GetHashKey("SANCHEZ2"),
                            (uint)GetHashKey("ESSKEY"),
                        };
                        List<uint> scooters = new List<uint>()
                        {
                            (uint)GetHashKey("FAGGIO"),
                            (uint)GetHashKey("FAGGIO2"),
                            (uint)GetHashKey("FAGGIO3"),
                            (uint)GetHashKey("CLIFFHANGER"),
                            (uint)GetHashKey("BAGGER"),
                        };
                        List<uint> policeb = new List<uint>()
                        {
                            (uint)GetHashKey("AVARUS"),
                            (uint)GetHashKey("CHIMERA"),
                            (uint)GetHashKey("POLICEB"),
                            (uint)GetHashKey("SOVEREIGN"),
                            (uint)GetHashKey("HEXER"),
                            (uint)GetHashKey("INNOVATION"),
                            (uint)GetHashKey("NIGHTBLADE"),
                            (uint)GetHashKey("RATBIKE"),
                            (uint)GetHashKey("DAEMON"),
                            (uint)GetHashKey("DAEMON2"),
                            (uint)GetHashKey("DIABLOUS"),
                            (uint)GetHashKey("GARGOYLE"),
                            (uint)GetHashKey("THRUST"),
                            (uint)GetHashKey("VINDICATOR"),
                            (uint)GetHashKey("WOLFSBANE"),
                        };

                        if (policeb.Contains((uint)veh.Model.Hash))
                        {
                            animDict = "anim@mp_helmets@on_bike@policeb";
                        }
                        else if (sportBikes.Contains((uint)veh.Model.Hash))
                        {
                            animDict = "anim@mp_helmets@on_bike@sports";
                        }
                        else if (chopperBikes.Contains((uint)veh.Model.Hash))
                        {
                            animDict = "anim@mp_helmets@on_bike@chopper";
                        }
                        else if (dirtBikes.Contains((uint)veh.Model.Hash))
                        {
                            animDict = "anim@mp_helmets@on_bike@dirt";
                        }
                        else if (scooters.Contains((uint)veh.Model.Hash))
                        {
                            animDict = "anim@mp_helmets@on_bike@scooter";
                        }
                        else
                        {
                            animDict = "anim@mp_helmets@on_bike@sports";
                        }
                    }
                    else if (veh.Model.IsBicycle)
                    {
                        animDict = "anim@mp_helmets@on_bike@scooter";
                    }
                }
            }
            if (!HasAnimDictLoaded(animDict))
            {
                RequestAnimDict(animDict);
                while (!HasAnimDictLoaded(animDict))
                {
                    await BaseScript.Delay(0);
                }
            }
            if (animName.StartsWith("pov_") && animDict != "anim@mp_helmets@on_foot")
            {
                animName = animName.Substring(4);
            }
            ClearPedTasks(pedHandle);
            ClientMain.Logger.Debug("Animsection");
            TaskPlayAnim(pedHandle, animDict, animName, 8.0f, 1.0f, -1, 48, 0.0f, false, false, false);
            int timeoutTimer = GetGameTimer();
            while (GetEntityAnimCurrentTime(Game.PlayerPed.Handle, animDict, animName) <= 0.0f)
            {
                if (GetGameTimer() - timeoutTimer > 1000)
                {
                    ClearPedTasks(Game.PlayerPed.Handle);
                    Debug.WriteLine("[vMenu] [WARNING] Waiting for animation to start took too long. Preventing hanging of function. Dbg: fault in location 1.");
                    return;
                }
                await BaseScript.Delay(0);
            }
            timeoutTimer = GetGameTimer();
            while (GetEntityAnimCurrentTime(pedHandle, animDict, animName) > 0.0f)
            {
                await BaseScript.Delay(0);

                if (GetGameTimer() - timeoutTimer > 3000)
                {
                    ClearPedTasks(pedHandle);
                    Debug.WriteLine("Waiting for animation duration took too long.");
                    return;
                }
                if (GetEntityAnimCurrentTime(pedHandle, animDict, animName) > 0.39f)
                {
                    SetPedPropIndex(pedHandle, 0, newHelmet, newHelmetTexture, false);
                }
            }
            ClearPedTasks(pedHandle);
            RemoveAnimDict(animDict);
            if (InteractionMenu.MainMenu != null && ((UIMenu)MenuHandler.CurrentMenu).Subtitle == Game.GetGXTEntry("PIM_TITLESTYL"))
            {
                ((UIMenu)MenuHandler.CurrentMenu).MenuItems[6].Enabled = true;
            }
            switchingVisor = false;
        }


        internal static InteractionAnimation func_13801(int iParam0, int iParam1, bool iParam3, bool iParam4)//Position - 0x48257E
        {
            /*
                @ds = driver seat
                @ps = passenger seat
                @rds = rear driver seat
                @rps = rear passenger seat
             */
            InteractionAnimation anim = new InteractionAnimation();
            switch (iParam0)
            {
                case 0:
                    switch (iParam1)
                    {
                        case 0:
                            break;

                        case 1:
                            anim.uParam2[0] = "amb@code_human_in_car_mp_actions@smoke@low@ds@base";
                            anim.uParam2[1] = "amb@code_human_in_car_mp_actions@smoke@low@ps@base";
                            anim.uParam2[2] = "amb@code_human_in_car_mp_actions@smoke@std@ds@base";
                            anim.uParam2[3] = "amb@code_human_in_car_mp_actions@smoke@std@ps@base";
                            anim.uParam2[4] = "amb@code_human_in_car_mp_actions@smoke@std@rds@base";
                            anim.uParam2[5] = "amb@code_human_in_car_mp_actions@smoke@std@rps@base";
                            anim.uParam2[6] = "amb@code_human_in_car_mp_actions@smoke@std@ds@base";
                            anim.uParam2[7] = "amb@code_human_in_car_mp_actions@smoke@std@ps@base";
                            anim.uParam2[8] = "amb@code_human_in_car_mp_actions@smoke@bodhi@rps@base";
                            anim.uParam2[9] = "amb@code_human_in_car_mp_actions@smoke@bodhi@rps@base";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke_car";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth_car";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse_car";
                            anim.f_430 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            break;

                        case 2:
                            anim.uParam2[1] = "anim@mp_player_intincarfingerlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarfingerstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarfingerstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarfingerstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarfingerbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarfingerbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarfingerbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarfingerbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarfingerstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarfingerlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 3:
                            anim.uParam2[1] = "amb@code_human_in_car_mp_actions@dance@low@ps@base";
                            anim.uParam2[4] = "amb@code_human_in_car_mp_actions@dance@std@rds@base";
                            anim.uParam2[5] = "amb@code_human_in_car_mp_actions@dance@std@rps@base";
                            anim.uParam2[3] = "amb@code_human_in_car_mp_actions@dance@std@ps@base";
                            anim.uParam2[8] = "amb@code_human_in_car_mp_actions@dance@bodhi@rds@base";
                            anim.uParam2[9] = "amb@code_human_in_car_mp_actions@dance@bodhi@rds@base";
                            anim.uParam2[6] = "amb@code_human_in_car_mp_actions@dance@std@ps@base";
                            anim.uParam2[7] = "amb@code_human_in_car_mp_actions@dance@std@ds@base";
                            anim.uParam2[2] = "amb@code_human_in_car_mp_actions@dance@std@ds@base";
                            anim.uParam2[0] = "amb@code_human_in_car_mp_actions@dance@low@ds@base";
                            anim.f_225 = "idle_a";
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            break;

                        case 4:
                            anim.uParam2[1] = "anim@mp_player_intincarrocklow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarrockstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarrockstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarrockstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarrockbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarrockbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarrockbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarrockbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarrockstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarrocklow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 5:
                            anim.uParam2[1] = "anim@mp_player_intincarwanklow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarwankstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarwankstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarwankstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarwankbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarwankbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarwankbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarwankbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarwankstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarwanklow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 7:
                            anim.uParam2[1] = "anim@mp_player_intincarair_shagginglow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarair_shaggingstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarair_shaggingstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarair_shaggingstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarair_shaggingbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarair_shaggingbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarair_shaggingbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarair_shaggingbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarair_shaggingstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarair_shagginglow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            break;

                        case 8:
                            anim.uParam2[1] = "anim@mp_player_intincardocklow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincardockstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincardockstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincardockstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincardockbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincardockbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincardockbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincardockbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincardockstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincardocklow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 9:
                            anim.uParam2[1] = "anim@mp_player_intincarknuckle_crunchlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarknuckle_crunchstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarknuckle_crunchstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarknuckle_crunchstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarknuckle_crunchbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarknuckle_crunchbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarknuckle_crunchbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarknuckle_crunchbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarknuckle_crunchstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarknuckle_crunchlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_490 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 10:
                            anim.uParam2[1] = "anim@mp_player_intincarsalutelow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarsalutestd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarsalutestd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarsalutestd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarsalutebodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarsalutebodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarsalutebodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarsalutebodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarsalutestd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarsalutelow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 6:
                            anim.uParam2[1] = "anim@mp_player_intincarblow_kisslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarblow_kissstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarblow_kissstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarblow_kissstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarblow_kissbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarblow_kissbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarblow_kissbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarblow_kissbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarblow_kissstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarblow_kisslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            break;

                        case 11:
                            anim.uParam2[1] = "anim@mp_player_intincarslow_claplow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarslow_clapstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarslow_clapstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarslow_clapstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarslow_clapbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarslow_clapbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarslow_clapbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarslow_clapbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarslow_clapstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarslow_claplow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_490 = 1;
                            break;

                        case 12:
                            anim.uParam2[1] = "anim@mp_player_intincarface_palmlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarface_palmstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarface_palmstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarface_palmstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarface_palmbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarface_palmbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarface_palmbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarface_palmbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarface_palmstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarface_palmlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 13:
                            anim.uParam2[1] = "anim@mp_player_intincarthumbs_uplow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarthumbs_upstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarthumbs_upstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarthumbs_upstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarthumbs_upbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarthumbs_upbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarthumbs_upbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarthumbs_upbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarthumbs_upstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarthumbs_uplow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 14:
                            anim.uParam2[1] = "anim@mp_player_intincarjazz_handslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarjazz_handsstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarjazz_handsstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarjazz_handsstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarjazz_handsbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarjazz_handsbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarjazz_handsbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarjazz_handsbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarjazz_handsstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarjazz_handslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 15:
                            anim.uParam2[1] = "anim@mp_player_intincarnose_picklow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarnose_pickstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarnose_pickstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarnose_pickstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarnose_pickbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarnose_pickbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarnose_pickbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarnose_pickbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarnose_pickstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarnose_picklow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 17:
                            anim.uParam2[1] = "anim@mp_player_intincarwavelow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarwavestd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarwavestd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarwavestd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarwavebodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarwavebodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarwavebodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarwavebodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarwavestd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarwavelow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 16:
                            anim.uParam2[1] = "anim@mp_player_intincarair_guitarlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarair_guitarstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarair_guitarstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarair_guitarstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarair_guitarbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarair_guitarbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarair_guitarbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarair_guitarbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarair_guitarstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarair_guitarlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 18:
                            anim.uParam2[1] = "anim@mp_player_intincarsurrenderlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarsurrenderstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarsurrenderstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarsurrenderstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarsurrenderbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarsurrenderbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarsurrenderbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarsurrenderbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarsurrenderstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarsurrenderlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 19:
                            anim.uParam2[1] = "anim@mp_player_intincarshushlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarshushstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarshushstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarshushstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarshushbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarshushbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarshushbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarshushbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarshushstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarshushlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 20:
                            anim.uParam2[1] = "anim@mp_player_intincarphotographylow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarphotographystd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarphotographystd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarphotographystd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarphotographybodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarphotographybodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarphotographybodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarphotographybodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarphotographystd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarphotographylow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 21:
                            anim.uParam2[1] = "anim@mp_player_intincardjlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincardjstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincardjstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincardjstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincardjbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincardjbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincardjbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincardjbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincardjstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincardjlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 22:
                            anim.uParam2[1] = "anim@mp_player_intincarair_synthlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarair_synthstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarair_synthstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarair_synthstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarair_synthbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarair_synthbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarair_synthbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarair_synthbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarair_synthstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarair_synthlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 23:
                            anim.uParam2[1] = "anim@mp_player_intincarno_waylow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarno_waystd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarno_waystd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarno_waystd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarno_waybodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarno_waybodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarno_waybodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarno_waybodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarno_waystd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarno_waylow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 25:
                            anim.uParam2[1] = "anim@mp_player_intincarchin_brushlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarchin_brushstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarchin_brushstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarchin_brushstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarchin_brushbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarchin_brushbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarchin_brushbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarchin_brushbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarchin_brushstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarchin_brushlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 24:
                            anim.uParam2[1] = "anim@mp_player_intincarchicken_tauntlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarchicken_tauntstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarchicken_tauntstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarchicken_tauntstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarchicken_tauntbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarchicken_tauntbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarchicken_tauntbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarchicken_tauntbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarchicken_tauntstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarchicken_tauntlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 26:
                            anim.uParam2[1] = "anim@mp_player_intincarfinger_kisslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarfinger_kissstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarfinger_kissstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarfinger_kissstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarfinger_kissbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarfinger_kissbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarfinger_kissbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarfinger_kissbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarfinger_kissstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarfinger_kisslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 27:
                            anim.uParam2[1] = "anim@mp_player_intincarpeacelow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarpeacestd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarpeacestd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarpeacestd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarpeacebodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarpeacebodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarpeacebodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarpeacebodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarpeacestd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarpeacelow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 28:
                            anim.uParam2[1] = "anim@mp_player_intincaryou_locolow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincaryou_locostd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincaryou_locostd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincaryou_locostd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincaryou_locobodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincaryou_locobodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincaryou_locobodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincaryou_locobodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincaryou_locostd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincaryou_locolow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 29:
                            anim.uParam2[1] = "anim@mp_player_intincarfreakoutlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarfreakoutstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarfreakoutstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarfreakoutstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarfreakoutbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarfreakoutbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarfreakoutbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarfreakoutbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarfreakoutstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarfreakoutlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 30:
                            anim.uParam2[1] = "anim@mp_player_intincarthumb_on_earslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarthumb_on_earsstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarthumb_on_earsstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarthumb_on_earsstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarthumb_on_earsbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarthumb_on_earsbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarthumb_on_earsbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarthumb_on_earsbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarthumb_on_earsstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarthumb_on_earslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 31:
                            anim.uParam2[1] = "anim@mp_player_intin_carcry_babylow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carcry_babystd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carcry_babystd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carcry_babystd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carcry_babybodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carcry_babybodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carcry_babybodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carcry_babybodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carcry_babystd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carcry_babylow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 32:
                            anim.uParam2[1] = "anim@mp_player_intin_carcut_throatlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carcut_throatstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carcut_throatstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carcut_throatstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carcut_throatbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carcut_throatbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carcut_throatbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carcut_throatbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carcut_throatstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carcut_throatlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 33:
                            anim.uParam2[1] = "anim@mp_player_intin_carkarate_chopslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carkarate_chopsstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carkarate_chopsstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carkarate_chopsstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carkarate_chopsbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carkarate_chopsbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carkarate_chopsbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carkarate_chopsbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carkarate_chopsstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carkarate_chopslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 34:
                            anim.uParam2[1] = "anim@mp_player_intin_carshadow_boxinglow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carshadow_boxingstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carshadow_boxingstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carshadow_boxingstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carshadow_boxingbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carshadow_boxingbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carshadow_boxingbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carshadow_boxingbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carshadow_boxingstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carshadow_boxinglow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 35:
                            anim.uParam2[1] = "anim@mp_player_intin_carthe_woogielow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carthe_woogiestd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carthe_woogiestd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carthe_woogiestd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carthe_woogiebodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carthe_woogiebodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carthe_woogiebodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carthe_woogiebodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carthe_woogiestd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carthe_woogielow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 36:
                            anim.uParam2[1] = "anim@mp_player_intin_carstinkerlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intin_carstinkerstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intin_carstinkerstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intin_carstinkerstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intin_carstinkerbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intin_carstinkerbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intin_carstinkerbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intin_carstinkerbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intin_carstinkerstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intin_carstinkerlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 37:
                            anim.uParam2[1] = "anim@mp_player_intincarair_drumslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarair_drumsstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarair_drumsstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarair_drumsstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarair_drumsbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarair_drumsbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarair_drumsbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarair_drumsbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarair_drumsstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarair_drumslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 38:
                            anim.uParam2[1] = "anim@mp_player_intincarcall_melow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarcall_mestd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarcall_mestd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarcall_mestd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarcall_mebodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarcall_mebodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarcall_mebodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarcall_mebodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarcall_mestd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarcall_melow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 39:
                            anim.uParam2[1] = "anim@mp_player_intincarcoin_roll_and_tosslow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarcoin_roll_and_tossstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarcoin_roll_and_tossstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarcoin_roll_and_tossstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarcoin_roll_and_tossbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarcoin_roll_and_tossbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarcoin_roll_and_tossbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarcoin_roll_and_tossbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarcoin_roll_and_tossstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarcoin_roll_and_tosslow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_419 = 1;
                            anim.f_421 = 1;
                            anim.f_429 = Functions.HashUint("vw_prop_vw_coin_01a");
                            anim.f_424 = 1;
                            break;

                        case 40:
                            anim.uParam2[1] = "anim@mp_player_intincarbang_banglow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarbang_bangstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarbang_bangstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarbang_bangstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarbang_bangbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarbang_bangbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarbang_bangbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarbang_bangbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarbang_bangstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarbang_banglow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 41:
                            anim.uParam2[1] = "anim@mp_player_intincarrespectlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarrespectstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarrespectstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarrespectstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarrespectbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarrespectbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarrespectbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarrespectbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarrespectstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarrespectlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 42:
                            anim.uParam2[1] = "anim@mp_player_intincarmind_blownlow@ps@";
                            anim.uParam2[4] = "anim@mp_player_intincarmind_blownstd@rds@";
                            anim.uParam2[5] = "anim@mp_player_intincarmind_blownstd@rps@";
                            anim.uParam2[3] = "anim@mp_player_intincarmind_blownstd@ps@";
                            anim.uParam2[8] = "anim@mp_player_intincarmind_blownbodhi@rds@";
                            anim.uParam2[9] = "anim@mp_player_intincarmind_blownbodhi@rps@";
                            anim.uParam2[6] = "anim@mp_player_intincarmind_blownbodhi@ds@";
                            anim.uParam2[7] = "anim@mp_player_intincarmind_blownbodhi@ps@";
                            anim.uParam2[2] = "anim@mp_player_intincarmind_blownstd@ds@";
                            anim.uParam2[0] = "anim@mp_player_intincarmind_blownlow@ds@";
                            anim.f_225 = "idle_a";
                            anim.f_209 = "ENTER";
                            anim.f_225 = "IDLE_A";
                            anim.f_241 = "EXIT";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;
                    }
                    break;

                case 1:
                    switch (iParam1)
                    {
                        case 0:
                            anim.uParam2[0] = "mp_player_int_upperbro_love";
                            anim.f_209 = "mp_player_int_bro_love_ENTER";
                            anim.f_225 = "mp_player_int_bro_love";
                            anim.f_241 = "mp_player_int_bro_love_EXIT";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@bro_love";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@bro_love";
                            anim.f_257 = "bro_love";
                            anim.f_418 = 1;
                            anim.f_489 = 2;
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.uParam2[1] = "mp_player_int_upperbro_love";
                            break;

                        case 1:
                            anim.uParam2[0] = "mp_player_int_upperfinger";
                            anim.f_209 = "mp_player_int_finger_02_ENTER";
                            anim.f_225 = "mp_player_int_finger_02";
                            anim.f_241 = "mp_player_int_finger_02_EXIT";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@finger";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@finger";
                            anim.f_257 = "finger";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 2:
                            anim.uParam2[0] = "mp_player_int_upperwank";
                            anim.f_209 = "mp_player_int_wank_02_ENTER";
                            anim.f_225 = "mp_player_int_wank_02";
                            anim.f_241 = "mp_player_int_wank_02_EXIT";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@wank";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@wank";
                            anim.f_257 = "wank";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            break;

                        case 3:
                            anim.uParam2[0] = "mp_player_int_upperup_yours";
                            anim.f_209 = "mp_player_int_up_yours_ENTER";
                            anim.f_225 = "mp_player_int_up_yours";
                            anim.f_241 = "mp_player_int_up_yours_EXIT";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@up_yours";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@up_yours";
                            anim.f_257 = "up_yours";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;
                    }
                    break;

                case 2:
                    switch (iParam1)
                    {
                        case 0:
                            break;

                        case 1:
                            anim.uParam2[0] = "anim@mp_player_intupperfinger";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@finger";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@finger";
                            anim.f_257 = "finger";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.uParam2[12] = "anim@mp_player_intselfiethe_bird";
                            break;

                        case 2:
                            anim.uParam2[0] = "anim@mp_player_intupperrock";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperrock";
                            break;

                        case 3:
                            anim.uParam2[0] = "anim@mp_player_intuppersalute";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@salute";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@salute";
                            anim.f_257 = "salute";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intuppersalute";
                            break;

                        case 4:
                            anim.uParam2[0] = "anim@mp_player_intupperwank";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@wank";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@wank";
                            anim.f_257 = "wank";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.uParam2[12] = "anim@mp_player_intselfiewank";
                            break;

                        case 59:
                            anim.uParam2[0] = "mp_player_int_uppersmoke";
                            anim.f_209 = "mp_player_int_smoke_ENTER";
                            anim.f_225 = "mp_player_int_smoke";
                            anim.f_241 = "mp_player_int_smoke_EXIT";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@smoke_flick";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@smoke_flick";
                            anim.f_257 = "smoke_flick";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            anim.f_430 = 1;
                            break;

                        case 60:
                            anim.uParam2[0] = "mp_player_intdrink";
                            anim.f_209 = "Intro";
                            anim.f_225 = "Loop";
                            anim.f_241 = "Outro";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_ecola_can");
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 61:
                            anim.uParam2[0] = "mp_player_intdrink";
                            anim.f_209 = "Intro_bottle";
                            anim.f_225 = "Loop_bottle";
                            anim.f_241 = "Outro_bottle";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_amb_beer_bottle");
                            anim.f_488 = 3;
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 62:
                            anim.uParam2[0] = "anim@mp_player_intupperspray_champagne";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@spray_champagne";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@spray_champagne";
                            anim.f_257 = "spray_champagne";
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_420 = 1;
                            anim.f_429 = Functions.HashUint("xs_prop_arena_champ_closed");
                            anim.f_428 = 1;
                            anim.f_424 = 1;
                            anim.f_488 = 3;
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            anim.f_422 = 1;
                            break;

                        case 63:
                            anim.uParam2[0] = "mp_player_intdrink";
                            anim.f_209 = "Intro";
                            anim.f_225 = "Loop";
                            anim.f_241 = "Outro";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_ld_can_01b");
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 39:
                            anim.uParam2[0] = "anim@mp_player_intupperraining_cash";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@raining_cash";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@raining_cash";
                            anim.f_257 = "raining_cash";
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_420 = 1;
                            anim.f_421 = 1;
                            anim.f_423 = 1;
                            anim.f_429 = Functions.HashUint("xs_prop_arena_cash_pile_l");
                            anim.uParam2[12] = "anim@mp_player_intupperraining_cash";
                            anim.f_422 = 1;
                            break;

                        case 58:
                            anim.f_369 = "HLWN_22";
                            anim.f_385 = "Mask_SFX";
                            anim.f_401 = "SPEECH_PARAMS_FORCE_NORMAL";
                            anim.f_417 = 1;
                            break;

                        case 64:
                            anim.uParam2[0] = "mp_player_inteat@pnq";
                            anim.f_209 = "intro";
                            anim.f_225 = "loop";
                            anim.f_241 = "outro";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_choc_pq");
                            anim.f_489 = 2;
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 65:
                            anim.uParam2[0] = "mp_player_inteat@burger";
                            anim.f_209 = "mp_player_int_eat_burger_enter";
                            anim.f_225 = "mp_player_int_eat_burger";
                            anim.f_241 = "mp_player_int_eat_exit_burger";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_choc_ego");
                            anim.f_489 = 2;
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 66:
                            anim.uParam2[0] = "mp_player_inteat@burger";
                            anim.f_209 = "mp_player_int_eat_burger_enter";
                            anim.f_225 = "mp_player_int_eat_burger";
                            anim.f_241 = "mp_player_int_eat_exit_burger";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@rock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationmale@rock";
                            anim.f_257 = "rock";
                            anim.f_418 = 1;
                            anim.f_425 = 1;
                            anim.f_426 = 0;
                            anim.f_427 = 0;
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_choc_meto");
                            anim.f_489 = 2;
                            anim.f_430 = 1;
                            anim.f_490 = 1;
                            break;

                        case 6:
                            anim.uParam2[0] = "anim@mp_player_intupperair_shagging";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@air_shagging";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@air_shagging";
                            anim.f_257 = "air_shagging";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 7:
                            anim.uParam2[0] = "anim@mp_player_intupperdock";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@dock";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@dock";
                            anim.f_257 = "dock";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.uParam2[12] = "anim@mp_player_intselfiedock";
                            break;

                        case 8:
                            anim.uParam2[0] = "anim@mp_player_intupperknuckle_crunch";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@knuckle_crunch";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@knuckle_crunch";
                            anim.f_257 = "knuckle_crunch";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_490 = 1;
                            break;

                        case 5:
                            anim.uParam2[0] = "anim@mp_player_intupperblow_kiss";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@blow_kiss";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@blow_kiss";
                            anim.f_257 = "blow_kiss";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intselfieblow_kiss";
                            break;

                        case 9:
                            anim.uParam2[0] = "anim@mp_player_intupperslow_clap";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@slow_clap";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@slow_clap";
                            anim.f_257 = "slow_clap";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_490 = 1;
                            break;

                        case 10:
                            anim.uParam2[0] = "anim@mp_player_intupperface_palm";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@face_palm";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@face_palm";
                            anim.f_257 = "face_palm";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperface_palm";
                            break;

                        case 11:
                            anim.uParam2[0] = "anim@mp_player_intupperthumbs_up";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@thumbs_up";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@thumbs_up";
                            anim.f_257 = "thumbs_up";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.uParam2[12] = "anim@mp_player_intselfiethumbs_up";
                            break;

                        case 12:
                            anim.uParam2[0] = "anim@mp_player_intupperjazz_hands";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@jazz_hands";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@jazz_hands";
                            anim.f_257 = "jazz_hands";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperjazz_hands";
                            break;

                        case 13:
                            anim.uParam2[0] = "anim@mp_player_intuppernose_pick";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@nose_pick";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@nose_pick";
                            anim.f_257 = "nose_pick";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intuppernose_pick";
                            break;

                        case 15:
                            anim.uParam2[0] = "anim@mp_player_intupperwave";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@wave";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@wave";
                            anim.f_257 = "wave";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperwave";
                            break;

                        case 14:
                            anim.uParam2[0] = "anim@mp_player_intupperair_guitar";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@air_guitar";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@air_guitar";
                            anim.f_257 = "air_guitar";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperair_guitar";
                            break;

                        case 16:
                            anim.uParam2[0] = "anim@mp_player_intuppersurrender";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@surrender";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@surrender";
                            anim.f_257 = "surrender";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intuppersurrender";
                            break;

                        case 17:
                            anim.uParam2[0] = "anim@mp_player_intuppershush";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@shush";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@shush";
                            anim.f_257 = "shush";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_418 = 1;
                            anim.uParam2[12] = "anim@mp_player_intuppershush";
                            break;

                        case 18:
                            anim.uParam2[0] = "anim@mp_player_intupperphotography";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@photography";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@photography";
                            anim.f_257 = "photography";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperphotography";
                            break;

                        case 19:
                            anim.uParam2[0] = "anim@mp_player_intupperdj";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@dj";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@dj";
                            anim.f_257 = "dj";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperdj";
                            break;

                        case 20:
                            anim.uParam2[0] = "anim@mp_player_intupperair_synth";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@air_synth";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@air_synth";
                            anim.f_257 = "air_synth";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperair_synth";
                            break;

                        case 21:
                            anim.uParam2[0] = "anim@mp_player_intupperno_way";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@no_way";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@no_way";
                            anim.f_257 = "no_way";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperno_way";
                            break;

                        case 23:
                            anim.uParam2[0] = "anim@mp_player_intupperchin_brush";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@chin_brush";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@chin_brush";
                            anim.f_257 = "chin_brush";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperchin_brush";
                            break;

                        case 22:
                            anim.uParam2[0] = "anim@mp_player_intupperchicken_taunt";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@chicken_taunt";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@chicken_taunt";
                            anim.f_257 = "chicken_taunt";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperchicken_taunt";
                            break;

                        case 25:
                            anim.uParam2[0] = "anim@mp_player_intupperpeace";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@peace";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@peace";
                            anim.f_257 = "peace";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperpeace";
                            break;

                        case 24:
                            anim.uParam2[0] = "anim@mp_player_intupperfinger_kiss";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@finger_kiss";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@finger_kiss";
                            anim.f_257 = "finger_kiss";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperfinger_kiss";
                            break;

                        case 26:
                            anim.uParam2[0] = "anim@mp_player_intupperyou_loco";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@you_loco";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@you_loco";
                            anim.f_257 = "you_loco";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.uParam2[12] = "anim@mp_player_intupperyou_loco";
                            break;

                        case 27:
                            anim.uParam2[0] = "anim@mp_player_intupperfreakout";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@freakout";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@freakout";
                            anim.f_257 = "freakout";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            break;

                        case 28:
                            anim.uParam2[0] = "anim@mp_player_intupperthumb_on_ears";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@thumb_on_ears";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@thumb_on_ears";
                            anim.f_257 = "thumb_on_ears";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 1;
                            break;

                        case 30:
                            anim.uParam2[0] = "anim@mp_player_intupperbanging_tunes";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@banging_tunes";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@banging_tunes";
                            anim.f_257 = "banging_tunes";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 29:
                            anim.uParam2[0] = "anim@mp_player_intupperbanging_tunes_left";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@banging_tunes_left";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@banging_tunes_left";
                            anim.f_257 = "banging_tunes";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 31:
                            anim.uParam2[0] = "anim@mp_player_intupperbanging_tunes_right";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@banging_tunes_right";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@banging_tunes_right";
                            anim.f_257 = "banging_tunes";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 32:
                            anim.uParam2[0] = "anim@mp_player_intupperoh_snap";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@oh_snap";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@oh_snap";
                            anim.f_257 = "oh_snap";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 33:
                            anim.uParam2[0] = "anim@mp_player_intuppercats_cradle";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@cats_cradle";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@cats_cradle";
                            anim.f_257 = "cats_cradle";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 34:
                            anim.uParam2[0] = "anim@mp_player_intupperraise_the_roof";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@raise_the_roof";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@raise_the_roof";
                            anim.f_257 = "raise_the_roof";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 35:
                            anim.uParam2[0] = "anim@mp_player_intupperfind_the_fish";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@find_the_fish";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@find_the_fish";
                            anim.f_257 = "find_the_fish";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 36:
                            anim.uParam2[0] = "anim@mp_player_intuppersalsa_roll";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@salsa_roll";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@salsa_roll";
                            anim.f_257 = "salsa_roll";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 37:
                            anim.uParam2[0] = "anim@mp_player_intupperheart_pumping";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@heart_pumping";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@heart_pumping";
                            anim.f_257 = "heart_pumping";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 38:
                            anim.uParam2[0] = "anim@mp_player_intupperuncle_disco";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@uncle_disco";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@uncle_disco";
                            anim.f_257 = "uncle_disco";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            //*(uParam2[12]) = new Vector3(*(uParam2[0]));
                            break;

                        case 40:
                            anim.uParam2[0] = "anim@mp_player_intuppercry_baby";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@cry_baby";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@cry_baby";
                            anim.f_257 = "cry_baby";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppercry_baby";
                            break;

                        case 41:
                            anim.uParam2[0] = "anim@mp_player_intuppercut_throat";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@cut_throat";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@cut_throat";
                            anim.f_257 = "cut_throat";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppercut_throat";
                            break;

                        case 42:
                            anim.uParam2[0] = "anim@mp_player_intupperkarate_chops";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@karate_chops";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@karate_chops";
                            anim.f_257 = "karate_chops";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperkarate_chops";
                            break;

                        case 43:
                            anim.uParam2[0] = "anim@mp_player_intuppershadow_boxing";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@shadow_boxing";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@shadow_boxing";
                            anim.f_257 = "shadow_boxing";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppershadow_boxing";
                            break;

                        case 44:
                            anim.uParam2[0] = "anim@mp_player_intupperthe_woogie";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@the_woogie";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@the_woogie";
                            anim.f_257 = "the_woogie";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperthe_woogie";
                            break;

                        case 45:
                            anim.uParam2[0] = "anim@mp_player_intupperstinker";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@stinker";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@stinker";
                            anim.f_257 = "stinker";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperstinker";
                            break;

                        case 46:
                            anim.uParam2[0] = "anim@mp_player_intupperair_drums";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@air_drums";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@air_drums";
                            anim.f_257 = "air_drums";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperair_drums";
                            break;

                        case 47:
                            anim.uParam2[0] = "anim@mp_player_intuppercall_me";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@call_me";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@call_me";
                            anim.f_257 = "call_me";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppercall_me";
                            break;

                        case 48:
                            anim.uParam2[0] = "anim@mp_player_intuppercoin_roll_and_toss";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@coin_roll_and_toss";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@coin_roll_and_toss";
                            anim.f_257 = "coin_roll_and_toss";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppercoin_roll_and_toss";
                            anim.f_419 = 1;
                            anim.f_421 = 1;
                            anim.f_429 = Functions.HashUint("vw_prop_vw_coin_01a");
                            anim.f_424 = 1;
                            break;

                        case 49:
                            anim.uParam2[0] = "anim@mp_player_intupperbang_bang";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@bang_bang";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@bang_bang";
                            anim.f_257 = "bang_bang";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperbang_bang";
                            break;

                        case 50:
                            anim.uParam2[0] = "anim@mp_player_intupperrespect";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@respect";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@respect";
                            anim.f_257 = "respect";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intupperrespect";
                            break;

                        case 51:
                            anim.uParam2[0] = "anim@mp_player_intuppermind_blown";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@mind_blown";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@mind_blown";
                            anim.f_257 = "mind_blown";
                            anim.f_425 = 1;
                            anim.f_427 = 1;
                            anim.f_426 = 1;
                            anim.f_489 = -3;
                            anim.uParam2[12] = "anim@mp_player_intuppermind_blown";
                            break;

                        case 52:
                            anim.uParam2[0] = "anim@mp_player_intuppercrowd_invitation";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@crowd_invitation";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@crowd_invitation";
                            anim.f_257 = "crowd_invitation";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 53:
                            anim.uParam2[0] = "anim@mp_player_intupperdriver";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@driver";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@driver";
                            anim.f_257 = "driver";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 54:
                            anim.uParam2[0] = "anim@mp_player_intupperrunner";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@runner";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@runner";
                            anim.f_257 = "runner";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 55:
                            anim.uParam2[0] = "anim@mp_player_intuppershooting";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@shooting";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@shooting";
                            anim.f_257 = "shooting";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 56:
                            anim.uParam2[0] = "anim@mp_player_intuppersuck_it";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@suck_it";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@suck_it";
                            anim.f_257 = "suck_it";
                            anim.f_425 = 1;
                            anim.f_426 = 1;
                            anim.f_427 = 0;
                            anim.f_489 = -3;
                            break;

                        case 57:
                            anim.uParam2[0] = "anim@mp_player_intuppertake_selfie";
                            anim.f_209 = "enter";
                            anim.f_225 = "idle_a";
                            anim.f_241 = "exit";
                            anim.uParam2[10] = "anim@mp_player_intcelebrationmale@take_selfie";
                            anim.uParam2[11] = "anim@mp_player_intcelebrationfemale@take_selfie";
                            anim.f_257 = "take_selfie";
                            anim.f_425 = 1;
                            anim.f_427 = 0;
                            anim.f_426 = 0;
                            anim.f_489 = -1;
                            anim.f_419 = 1;
                            anim.f_420 = 1;
                            anim.f_421 = 1;
                            anim.f_424 = 0;
                            anim.f_423 = 1;
                            anim.f_429 = Functions.HashUint("prop_phone_ing_02");
                            break;
                    }
                    break;

                case 3:
                    switch (iParam1)
                    {
                        case 0:
                            anim.uParam2[0] = "mp_player_int_upper_nod";
                            anim.f_225 = "mp_player_int_nod_no";
                            anim.f_425 = 0;
                            anim.f_418 = 0;
                            anim.f_489 = 2;
                            anim.uParam2[10] = "mp_player_int_upper_nod";
                            break;

                        case 1:
                            anim.uParam2[0] = "amb@code_human_in_car_mp_actions@nod@low@ds@base";
                            anim.f_225 = "nod_no";
                            anim.f_425 = 0;
                            anim.f_418 = 0;
                            anim.f_489 = 1;
                            break;

                        case 2:
                            anim.uParam2[0] = "amb@code_human_in_car_mp_actions@nod@low@ds@base";
                            anim.f_225 = "nod_no";
                            anim.f_425 = 0;
                            anim.f_418 = 0;
                            anim.f_489 = 0;
                            break;

                        case 3:
                            anim.uParam2[0] = "amb@code_human_in_car_mp_actions@nod@std@ds@base";
                            anim.f_225 = "nod_no";
                            anim.f_425 = 0;
                            anim.f_418 = 0;
                            anim.f_489 = 1;
                            break;

                        case 4:
                            anim.uParam2[10] = "anim@mp_freemode_return@m@idle";
                            anim.uParam2[11] = "anim@mp_freemode_return@f@idle";
                            anim.f_257 = "idle_a";
                            break;

                        case 5:
                            anim.uParam2[10] = "anim@mp_freemode_return@m@idle";
                            anim.uParam2[11] = "anim@mp_freemode_return@f@idle";
                            anim.f_257 = "idle_b";
                            break;

                        case 6:
                            anim.uParam2[10] = "anim@mp_freemode_return@m@idle";
                            anim.uParam2[11] = "anim@mp_freemode_return@f@idle";
                            anim.f_257 = "idle_c";
                            if (iParam3 && iParam4)
                            {
                            }
                            else
                            {
                                anim.f_419 = 1;
                                anim.f_421 = 1;
                                anim.f_429 = Functions.HashUint("prop_npc_phone");
                            }
                            break;

                        case 7:
                            anim.uParam2[10] = "anim@mp_freemode_return@m@fail";
                            anim.uParam2[11] = "anim@mp_freemode_return@f@fail";
                            anim.f_257 = "fail_a";
                            break;

                        case 8:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_a";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_a";
                            anim.f_257 = "respawn_a_ped_a";
                            break;

                        case 9:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_a";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_a";
                            anim.f_257 = "respawn_a_ped_b_smoke";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 10:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_a";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_a";
                            anim.f_257 = "respawn_a_ped_c";
                            break;

                        case 11:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_a";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_a";
                            anim.f_257 = "respawn_a_ped_d_smoke";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 12:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_b";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_b";
                            anim.f_257 = "respawn_b_ped_a";
                            break;

                        case 13:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_b";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_b";
                            anim.f_257 = "respawn_b_ped_b_smoke";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 14:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_b";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_b";
                            anim.f_257 = "respawn_b_ped_c";
                            break;

                        case 15:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_b";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_b";
                            anim.f_257 = "respawn_b_ped_d_smoke";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 16:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_c";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_c";
                            anim.f_257 = "respawn_c_ped_a";
                            break;

                        case 17:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_c";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_c";
                            anim.f_257 = "respawn_c_ped_b";
                            anim.f_419 = 1;
                            anim.f_421 = 1;
                            anim.f_429 = Functions.HashUint("prop_npc_phone");
                            break;

                        case 18:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_c";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_c";
                            anim.f_257 = "respawn_c_ped_c";
                            break;

                        case 19:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_c";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_c";
                            anim.f_257 = "respawn_c_ped_d";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 20:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_d";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_d";
                            anim.f_257 = "respawn_d_ped_a";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 21:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_d";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_d";
                            anim.f_257 = "respawn_d_ped_b";
                            break;

                        case 22:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_d";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_d";
                            anim.f_257 = "respawn_d_ped_c";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 23:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_d";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_d";
                            anim.f_257 = "respawn_d_ped_d";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 24:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_e";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_e";
                            anim.f_257 = "respawn_e_ped_a";
                            break;

                        case 25:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_e";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_e";
                            anim.f_257 = "respawn_e_ped_b";
                            break;

                        case 26:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_e";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_e";
                            anim.f_257 = "respawn_e_ped_c";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 27:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_e";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_e";
                            anim.f_257 = "respawn_e_ped_d";
                            anim.f_419 = 1;
                            anim.f_421 = 1;
                            anim.f_429 = Functions.HashUint("prop_npc_phone");
                            break;

                        case 28:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_f";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_f";
                            anim.f_257 = "respawn_f_ped_a";
                            break;

                        case 29:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_f";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_f";
                            anim.f_257 = "respawn_f_ped_b";
                            break;

                        case 30:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_f";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_f";
                            anim.f_257 = "respawn_f_ped_c";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 31:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_f";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_f";
                            anim.f_257 = "respawn_f_ped_d";
                            anim.f_419 = 1;
                            anim.f_421 = 1;
                            anim.f_429 = Functions.HashUint("prop_npc_phone");
                            break;

                        case 32:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_g";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_g";
                            anim.f_257 = "respawn_g_ped_a";
                            anim.f_419 = 1;
                            anim.f_429 = Functions.HashUint("prop_ecola_can");
                            break;

                        case 33:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_g";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_g";
                            anim.f_257 = "respawn_g_ped_b";
                            break;

                        case 34:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_g";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_g";
                            anim.f_257 = "respawn_g_ped_c";
                            anim.f_419 = 1;
                            anim.f_422 = 1;
                            anim.f_429 = Functions.HashUint("prop_cs_ciggy_01");
                            anim.f_431 = 1;
                            anim.f_432 = "ent_anim_cig_smoke";
                            anim.f_448 = new Vector3(-0.08f, 0f, 0f);
                            anim.f_451 = new Vector3(0f, 0f, 0f);
                            anim.f_454 = 1;
                            anim.f_455 = "ent_anim_cig_exhale_mth";
                            anim.f_471 = 1;
                            anim.f_472 = "ent_anim_cig_exhale_nse";
                            break;

                        case 35:
                            anim.uParam2[10] = "anim@heists@team_respawn@variations@variation_g";
                            anim.uParam2[11] = "anim@heists@team_respawn@variations@variation_g";
                            anim.f_257 = "respawn_g_ped_d";
                            break;

                        case 36:
                            anim.uParam2[10] = "anim@heists@team_respawn@pacific";
                            anim.uParam2[11] = "anim@heists@team_respawn@pacific";
                            anim.f_257 = "post_pacific_finale_respawn_ped_a";
                            break;

                        case 37:
                            anim.uParam2[10] = "anim@heists@team_respawn@pacific";
                            anim.uParam2[11] = "anim@heists@team_respawn@pacific";
                            anim.f_257 = "post_pacific_finale_respawn_ped_b";
                            break;

                        case 38:
                            anim.uParam2[10] = "anim@heists@team_respawn@pacific";
                            anim.uParam2[11] = "anim@heists@team_respawn@pacific";
                            anim.f_257 = "post_pacific_finale_respawn_ped_c";
                            break;

                        case 39:
                            anim.uParam2[10] = "anim@heists@team_respawn@pacific";
                            anim.uParam2[11] = "anim@heists@team_respawn@pacific";
                            anim.f_257 = "post_pacific_finale_respawn_ped_d";
                            break;

                        case 40:
                            anim.uParam2[10] = "anim@heists@team_respawn@fleeca";
                            anim.uParam2[11] = "anim@heists@team_respawn@fleeca";
                            anim.f_257 = "post_fleeca_finale_respawn_ped_a";
                            break;

                        case 41:
                            anim.uParam2[10] = "anim@heists@team_respawn@fleeca";
                            anim.uParam2[11] = "anim@heists@team_respawn@fleeca";
                            anim.f_257 = "post_fleeca_finale_respawn_ped_b";
                            break;
                    }
                    break;
            }
            return anim;
        }



    }


    public class InteractionAnimation
    {
        public string[] uParam2 = new string[15];
        public string f_209;
        public string f_225;
        public string f_241;

        public int f_419;
        public int f_421;
        public int f_424;
        public int f_422;
        public uint f_429;
        public int f_431;
        public string f_432;
        public Vector3 f_448;
        public Vector3 f_451;
        public int f_454;
        public string f_455;
        public int f_471;
        public string f_472;
        public int f_430;
        public int f_425;
        public int f_426;
        public int f_427;
        public int f_490;
        public string f_257;
        public int f_418;
        public int f_489;
        public int f_420;
        public int f_428;
        public int f_488;
        public int f_423;
        public string f_369;
        public string f_385;
        public string f_401;
        public int f_417;
        public int animProp = 0;
        public int particle = 0;
        public int AnimIndex = 0;
        public string SelectedDict = "";

        public VehicleSeat SeatIndex
        {
            get
            {
                int iVar2 = 0;
                if (PlayerCache.MyClient.Ped.IsSittingInVehicle())
                {
                    Vehicle iVar0 = VehicleChecker.CurrentVehicle;
                    int iVar1 = 0;
                    while (iVar1 < iVar0.PassengerCapacity + 1)
                    {
                        iVar2 = (iVar1 - 1);
                        if (!iVar0.IsSeatFree((VehicleSeat)iVar2))
                        {
                            if (iVar0.GetPedOnSeat((VehicleSeat)iVar2) == PlayerCache.MyClient.Ped)
                            {
                                return (VehicleSeat)iVar2;
                            }
                        }
                        iVar1++;
                    }
                }
                return (VehicleSeat)iVar2;
            }
        }


        public string dictBase { get; set; }
        public string dictAdvanced { get; set; }
    }
}