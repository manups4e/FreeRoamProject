using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Client.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLastPlanet.Client.GameMode.ROLEPLAY.Personale;


namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    class Snapmatic : App
    {
        ScaleformWideScreen camera = new ScaleformWideScreen("CAMERA_GALLERY");
        private int iLocal_60;
        private int iLocal_61;

        private float fLocal_107 = 0.5f;
        private float fLocal_108 = 0.85f;
        private float fLocal_109 = 0.5f;
        private float fLocal_110 = -0.25f;
        private float fLocal_111 = 0.25f;
        private float fLocal_112 = 0.3f;
        private float fLocal_113 = 0.3f;
        private float fLocal_36;
        private float fLocal_37;
        private bool grid = false;
        private int currentGesture = 0;
        private bool doingGesture = false;
        private int sequenceId = 0;
        private bool focusLocked = false;
        private bool playAction = false;
        private List<string> gestureDicts = [
            "None",
            "anim@mp_player_intselfieblow_kiss",
            "anim@mp_player_intselfiedock",
            "anim@mp_player_intselfiejazz_hands",
            "anim@mp_player_intselfiethe_bird",
            "anim@mp_player_intselfiethumbs_up",
            "anim@mp_player_intselfiewank"
        ];
        InteractionAnimation currentAnimation = null;
        string[] moods = ["No_Expression", "mood_Aiming_1", "mood_Happy_1", "mood_smug_1", "mood_Injured_1", "mood_sulk_1", "mood_Angry_1"];
        string[] borders = ["No_Border", "frame1", "frame2", "frame3", "frame4", "frame5", "frame6", "frame7", "frame8", "frame9", "frame10", "frame11", "frame12"];
        string[] filters = ["No_Filter", "phone_cam1", "phone_cam2", "phone_cam3", "phone_cam4", "phone_cam5", "phone_cam6", "phone_cam7", "phone_cam8", "phone_cam9", "phone_cam10", "phone_cam11", "phone_cam12"];
        private bool frontCam = false;
        private int DofModeEnabled = 0;
        private int currentMood = 0;
        private int currentFrame = 0;
        private int currentFilter = 0;
        private int iLocal_63 = 0; // camera zoom sound
        private string gestureDir = "anim@mp_player_intselfieblow_kiss";
        private List<InstructionalButton> IB_FrontCam = [
            new InstructionalButton(Control.PhoneCancel, Game.GetGXTEntry("CELL_281")),
            new InstructionalButton(Control.PhoneSelect, Game.GetGXTEntry("CELL_280")),
            new InstructionalButton(Control.PhoneRight, Game.GetGXTEntry("CELL_ACCYC")),
            new InstructionalButton(Control.PhoneLeft, Game.GetGXTEntry("CELL_ACTION")),
            new InstructionalButton(Control.PhoneCameraSelfie, Game.GetGXTEntry("CELL_SP_2NP_XB")),
            new InstructionalButton(Control.PhoneCameraGrid, Game.GetGXTEntry("CELL_GRID")),
            new InstructionalButton(Control.PhoneCameraDOF, Game.GetGXTEntry("CELL_DEPTH")),
            new InstructionalButton(InputGroup.INPUTGROUP_LOOK, Game.GetGXTEntry("CELL_285")),
            new InstructionalButton(Control.PhoneDown, Game.GetGXTEntry("CELL_FILTER")),
            new InstructionalButton(Control.PhoneUp, Game.GetGXTEntry("CELL_BORDER")),
        ];

        private List<InstructionalButton> IB_RearCam = [
            new InstructionalButton(Control.PhoneCancel, Game.GetGXTEntry("CELL_281")),
            new InstructionalButton(Control.PhoneSelect, Game.GetGXTEntry("CELL_280")),
            new InstructionalButton(Control.PhoneCameraSelfie, Game.GetGXTEntry("CELL_SP_1NP_XB")),
            new InstructionalButton(Control.PhoneCameraGrid, Game.GetGXTEntry("CELL_GRID")),
            new InstructionalButton(Control.PhoneCameraDOF, Game.GetGXTEntry("CELL_DEPTH")),
            new InstructionalButton(InputGroup.INPUTGROUP_LOOK, Game.GetGXTEntry("CELL_285")),
            new InstructionalButton(Control.PhoneDown, Game.GetGXTEntry("CELL_FILTER")),
            new InstructionalButton(Control.PhoneUp, Game.GetGXTEntry("CELL_BORDER")),
            new InstructionalButton(Control.PhoneCameraFocusLock, Game.GetGXTEntry("CELL_FOCUS")),
        ];

        private List<InstructionalButton> IB_PhotoSaving = [
            new InstructionalButton(Control.PhoneSelect, Game.GetGXTEntry("CELL_GALSAVE")),
            new InstructionalButton(Control.PhoneCancel, Game.GetGXTEntry("CELL_277")),
        ];
        private bool iLocal_64 = false;

        public Snapmatic(Phone phone) : base("CELL_3", IconLabels.CAMERA, phone, 0)
        {
            OpenCamera(false);
            DestroyMobilePhone();
        }

        public async Task CameraTick()
        {
            if (Main.Warning.IsShowing || Main.Warning.IsShowingWithButtons) return;
            HideHudAndRadarThisFrame();
            DisableControlAction(0, 25, true);
            DisableControlAction(0, 44, true);
            DisableControlAction(0, 3, true);
            DisableControlAction(0, 4, true);
            DisableControlAction(0, 5, true);
            DisableControlAction(0, 6, true);
            DisableControlAction(0, 47, true);
            DisableControlAction(0, 56, true);
            Phone.Scaleform.CallFunction("DISPLAY_VIEW", 16, 0);
            iLocal_60 = GetCurrentNumberOfCloudPhotos();
            iLocal_61 = GetMaximumNumberOfCloudPhotos();
            if (!IsPauseMenuActive())
            {
                camera.CallFunction("SET_REMAINING_PHOTOS", iLocal_60, iLocal_61);
                DrawScaleformMovie(camera.Handle, 0.5f, 0.5f, 1f, 1f, 255, 255, 255, 255, 0);
            }
        }

        public override async Task TickControls()
        {
            if (Main.Warning.IsShowing || Main.Warning.IsShowingWithButtons) return;
            if (Input.IsControlJustPressed(Control.PhoneUp))
            {
                currentFrame++;
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                if (currentFrame == 13)
                {
                    if (N_0xbcedb009461da156() == 1)
                    {
                        N_0x7ac24eab6d74118d(false);
                        SetStreamedTextureDictAsNoLongerNeeded(borders[currentFrame - 1]);
                        currentFrame = 0;
                        camera.CallFunction("SHOW_REMAINING_PHOTOS", 1);
                        camera.CallFunction("SHOW_PHOTO_FRAME", 1);
                    }
                }
                if (currentFrame > 0 && currentFrame < 13)
                {
                    RequestStreamedTextureDict(borders[currentFrame], false);
                    while (!HasStreamedTextureDictLoaded(borders[currentFrame])) await BaseScript.Delay(0);
                    if (N_0xbcedb009461da156() == 0)
                    {
                        N_0x7ac24eab6d74118d(true);
                        if (currentFrame > 0 && currentFrame < 99)
                        {
                            N_0x27feb5254759cde3(borders[currentFrame], false);
                            CellCamSetHorizontalOffset(0.25f);
                        }
                    }
                    camera.CallFunction("SHOW_PHOTO_FRAME", 0);
                    CellCamSetHorizontalOffset(0.25f);
                    N_0x27feb5254759cde3(borders[currentFrame], false);
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneDown))
            {
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                ClearTimecycleModifier();
                currentFilter++;
                if (currentFilter == 13)
                    currentFilter = 0;
                if (currentFilter == 0)
                {
                    ClearTimecycleModifier();
                }
                else
                    SetTimecycleModifier(filters[currentFilter]);
            }
            else if (Input.IsControlJustPressed(Control.PhoneRight))
            {
                // CYCLE ACTION
                // CELL_ACCYC
                currentGesture++;
                if (currentGesture == 67)
                    currentGesture = 0;
                currentAnimation = InteractionMethods.func_13801(2, currentGesture, false, false);
                while (currentGesture != 0 && (currentGesture == 20 || currentGesture == 39 || currentGesture == 41 || currentGesture == 46 || currentGesture == 47 || currentGesture == 48 || currentGesture == 49 || currentGesture == 50 || string.IsNullOrEmpty(currentAnimation.uParam2[12])))
                {
                    await BaseScript.Delay(0);
                    currentGesture++;
                    currentAnimation = InteractionMethods.func_13801(2, currentGesture, false, false);
                    if (currentGesture == 67)
                        currentGesture = 0;
                }

                string name = InteractionMenu.GetAnimName(2, currentGesture);
                BeginScaleformMovieMethod(camera.Handle, "SET_FOCUS_LOCK");
                ScaleformMovieMethodAddParamBool(currentGesture != 0);
                BeginTextCommandScaleformString("CELL_ACTTL");
                AddTextComponentSubstringPlayerName(Game.GetGXTEntry(name));
                EndTextCommandScaleformString();
                ScaleformMovieMethodAddParamBool(false);
                EndScaleformMovieMethod();

                if (playAction)
                {
                    if (currentGesture != 0)
                    {
                        RequestAnimDict(currentAnimation.uParam2[12]);
                        while (!HasAnimDictLoaded(currentAnimation.uParam2[12])) await BaseScript.Delay(0);
                        TaskPlayPhoneGestureAnimation(PlayerPedId(), currentAnimation.uParam2[12], "idle_a", "BONEMASK_HEAD_NECK_AND_L_ARM", 0.5f, 0.5f, true, true);
                    }
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneLeft))
            {
                // PLAY ACTION
                // CELL_ACTION
                playAction = !playAction;
                if (IsPlayingPhoneGestureAnim(PlayerPedId()) || currentGesture == 0)
                {
                    TaskStopPhoneGestureAnimation(PlayerPedId());
                    while (IsPlayingPhoneGestureAnim(PlayerPedId())) await BaseScript.Delay(0);
                }
                if (playAction)
                {
                    if (currentGesture != 0)
                    {
                        RequestAnimDict(currentAnimation.uParam2[12]);
                        while (!HasAnimDictLoaded(currentAnimation.uParam2[12])) await BaseScript.Delay(0);
                        TaskPlayPhoneGestureAnimation(PlayerPedId(), currentAnimation.uParam2[12], "idle_a", "BONEMASK_HEAD_NECK_AND_L_ARM", 0.5f, 0.5f, true, true);
                    }
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneSelect))
            {
                if (!(UpdateOnscreenKeyboard() == 0) && !NetworkIsTextChatActive() && !IsPauseMenuActive() && !IsWarningMessageActive() && !Main.Warning.IsShowing && !MenuHandler.IsAnyMenuOpen)
                {
                    if (iLocal_60 >= iLocal_61)
                    {
                        Main.Warning.ShowWarningWithButtons(Game.GetGXTEntry("CELL_CAM_ALERT"), Game.GetGXTEntry("CELL_CAM_FW_1"), Game.GetGXTEntry("CELL_CAM_FW_2"), new List<InstructionalButton>() { new(Control.FrontendAccept, "OK") });
                        Main.Warning.OnButtonPressed += (button) =>
                        {
                            if (button.Text == "OK")
                            {
                                if (!frontCam)
                                {
                                    Main.InstructionalButtons.SetInstructionalButtons(IB_RearCam);
                                }
                                else
                                {
                                    Main.InstructionalButtons.SetInstructionalButtons(IB_FrontCam);
                                }
                            }
                        };
                        return;
                    }

                    Main.InstructionalButtons.ClearButtonList();
                    float fLocal_38 = GetGameplayCamRelativePitch();
                    float fLocal_39 = GetGameplayCamRelativeHeading();
                    DrawLowQualityPhotoToPhone(false, false);
                    Audio.StopSound(iLocal_63);
                    camera.CallFunction("SHOW_PHOTO_FRAME", 0);
                    camera.CallFunction("SHOW_REMAINING_PHOTOS", 0f);
                    Game.PlaySound("Camera_Shoot", "Phone_SoundSet_Default");
                    camera.CallFunction("CLOSE_SHUTTER");
                    ClearTimecycleModifier();
                    float iLocal_86 = GetGameTimer();
                    while (GetGameTimer() - iLocal_86 < 1200)
                    {
                        StopRecordingThisFrame();
                        HideHudAndRadarThisFrame();
                        DisableControlAction(0, 25, true);
                        DisableControlAction(0, 44, true);
                        DisableControlAction(0, 3, true);
                        DisableControlAction(0, 4, true);
                        DisableControlAction(0, 5, true);
                        DisableControlAction(0, 6, true);
                        DisableControlAction(0, 1, true);
                        DisableControlAction(0, 2, true);
                        DisableControlAction(0, 39, true);
                        DisableControlAction(0, 47, true);
                        DisableControlAction(0, 56, true);
                        await BaseScript.Delay(0);
                    }
                    camera.CallFunction("OPEN_SHUTTER");
                    if (!frontCam)
                    {
                        Main.InstructionalButtons.SetInstructionalButtons(IB_RearCam);
                    }
                    else
                    {
                        Main.InstructionalButtons.SetInstructionalButtons(IB_FrontCam);
                    }
                    FreeMemoryForHighQualityPhoto();
                    FreeMemoryForLowQualityPhoto();
                    BeginTakeHighQualityPhoto();
                    int iLocal_50 = 0;
                    while (GetStatusOfTakeHighQualityPhoto() != (0))
                    {
                        ClientMain.Logger.Debug("GetStatusOfTakeHighQualityPhoto(): " + GetStatusOfTakeHighQualityPhoto());
                        await BaseScript.Delay(0);
                    }
                    if (SaveHighQualityPhoto(-1))
                    {
                        Main.InstructionalButtons.AddSavingText(LoadingSpinnerType.Clockwise1, Game.GetGXTEntry("CELL_278"));
                    }
                    if (GetStatusOfTakeHighQualityPhoto() == 0)
                    {
                        iLocal_50 = GetNetworkTime();
                        while (GetNetworkTime() - iLocal_50 < 3000) await BaseScript.Delay(0);
                        Main.InstructionalButtons.HideSavingText();
                    }
                    DrawLowQualityPhotoToPhone(true, true);
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneCancel))
            {
                if (IsPlayingPhoneGestureAnim(PlayerPedId()) || currentGesture == 0)
                    TaskStopPhoneGestureAnimation(PlayerPedId());
                OpenCamera(false);
                await Phone.RotateAnimation(PhoneAnimation.CLOSE_CAMERA);
                Phone.StartApp("MAINMENU");
            }
            else if (focusLocked)
            {
                if (!Input.IsControlPressed(Control.PhoneCameraFocusLock))
                {
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    BeginScaleformMovieMethod(camera.Handle, "SET_FOCUS_LOCK");
                    ScaleformMovieMethodAddParamBool(false);
                    BeginTextCommandScaleformString("CELL_FOCUS");
                    EndTextCommandScaleformString();
                    ScaleformMovieMethodAddParamBool(true);
                    EndScaleformMovieMethod();
                    focusLocked = false;
                }
            }
            else if (Input.IsControlPressed(Control.PhoneCameraFocusLock) && !frontCam)
            {
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                focusLocked = true;
                BeginScaleformMovieMethod(camera.Handle, "SET_FOCUS_LOCK");
                ScaleformMovieMethodAddParamBool(true);
                BeginTextCommandScaleformString("CELL_FOCUS");
                EndTextCommandScaleformString();
                ScaleformMovieMethodAddParamBool(true);
                EndScaleformMovieMethod();
            }
            else if (Input.IsControlJustPressed(Control.PhoneCameraGrid))
            {
                grid = !grid;
                Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                camera.CallFunction("SHOW_PHOTO_FRAME", grid);
            }
            else if (Input.IsControlJustPressed(Control.PhoneCameraSelfie))
            {
                TaskStopPhoneGestureAnimation(PlayerPedId());
                if (!IsPedInAnyVehicle(PlayerPedId(), false) && !(GetPedParachuteState(PlayerPedId()) == 2))
                {
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    Main.InstructionalButtons.ClearButtonList();
                    camera.CallFunction("SHOW_PHOTO_FRAME", 0);
                    camera.CallFunction("CLOSE_SHUTTER");
                    int iLocal_86 = GetGameTimer();
                    while (GetGameTimer() - iLocal_86 < 166)
                    {
                        StopRecordingThisFrame();
                        HideHudAndRadarThisFrame();
                        DisableControlAction(0, 25, true);
                        DisableControlAction(0, 44, true);
                        DisableControlAction(0, 3, true);
                        DisableControlAction(0, 4, true);
                        DisableControlAction(0, 5, true);
                        DisableControlAction(0, 6, true);
                        DisableControlAction(0, 1, true);
                        DisableControlAction(0, 2, true);
                        DisableControlAction(0, 39, true);
                        DisableControlAction(0, 47, true);
                        DisableControlAction(0, 56, true);
                        await BaseScript.Delay(0);
                    }
                    if (!frontCam)
                    {
                        fLocal_36 = GetGameplayCamRelativePitch();
                        fLocal_37 = GetGameplayCamRelativeHeading();
                        StopSound(iLocal_63);
                        frontCam = true;
                        Function.Call((Hash)0x2491A93618B7D838, true);
                        SetGameplayCamRelativePitch(0, 1f);
                        SetGameplayCamRelativeHeading(172f);
                    }
                    else
                    {
                        Function.Call((Hash)0x2491A93618B7D838, false);
                        SetGameplayCamRelativePitch(fLocal_36, 1f);
                        SetGameplayCamRelativeHeading(fLocal_37);
                        frontCam = false;
                    }
                    iLocal_86 = GetGameTimer();
                    while (GetGameTimer() - iLocal_86 < 1200)
                    {
                        StopRecordingThisFrame();
                        HideHudAndRadarThisFrame();
                        DisableControlAction(0, 25, true);
                        DisableControlAction(0, 44, true);
                        DisableControlAction(0, 3, true);
                        DisableControlAction(0, 4, true);
                        DisableControlAction(0, 5, true);
                        DisableControlAction(0, 6, true);
                        DisableControlAction(0, 1, true);
                        DisableControlAction(0, 2, true);
                        DisableControlAction(0, 39, true);
                        DisableControlAction(0, 47, true);
                        DisableControlAction(0, 56, true);
                        await BaseScript.Delay(0);
                    }
                    camera.CallFunction("OPEN_SHUTTER");
                    camera.CallFunction("SHOW_PHOTO_FRAME", grid);
                    if (!frontCam)
                    {
                        Main.InstructionalButtons.SetInstructionalButtons(IB_RearCam);
                    }
                    else
                    {
                        Main.InstructionalButtons.SetInstructionalButtons(IB_FrontCam);
                    }
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneCameraDOF))
            {
                if (DofModeEnabled == 0)
                {
                    Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                    DofModeEnabled = 1;
                    Function.Call((Hash)0xA2CCBE62CD4C91A4, true);//MOBILE::CELL_CAM_ACTIVATE_SHALLOW_DOF_MODE
                    SetMobilePhoneUnk(true);
                }
                else
                {
                    DofModeEnabled = 0;
                    Function.Call((Hash)0xA2CCBE62CD4C91A4, false);//MOBILE::CELL_CAM_ACTIVATE_SHALLOW_DOF_MODE
                    SetMobilePhoneUnk(false);
                }
            }
            else if (Input.IsControlJustPressed(Control.PhoneCameraExpression))
            {
                if (frontCam)
                {
                    currentMood++;
                    if (currentMood > 0 && currentMood < 7)
                    {
                        Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                        Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, "mood_normal_1", 0);
                        ClearFacialIdleAnimOverride(PlayerPedId());
                        int iVar4 = 0;
                        int iVar2 = GetPedPropIndex(PlayerPedId(), 0);
                        if (iVar2 == 20 || iVar2 == 14)
                        {
                            iVar4 = 1;
                        }
                        int iVar3 = GetPedPropIndex(PlayerPedId(), 1);
                        if (iVar3 != -1)
                        {
                            iVar4 = 1;
                        }
                        if (iVar4 == 1)
                        {
                            if ((((currentMood == 2 || currentMood == 3) || currentMood == 4) || currentMood == 8) || currentMood == 9)
                            {
                                if (iVar2 == -1 && iVar3 > -1)
                                {
                                    if (currentMood == 3)
                                    {
                                        Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, moods[currentMood], 0);
                                    }
                                }
                            }
                            else
                            {
                                Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, moods[currentMood], 0);
                            }
                        }
                        else
                        {
                            Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, moods[currentMood], 0);
                        }
                    }
                    if (currentMood == 7 || currentMood > 7)
                    {
                        currentMood = 0;
                    }
                    if (currentMood == 0)
                    {
                        if (!IsEntityDead(PlayerPedId()))
                        {
                            Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, moods[currentMood], 0);
                            ClearFacialIdleAnimOverride(PlayerPedId());
                            Game.PlaySound("Menu_Navigate", "Phone_SoundSet_Default");
                        }
                    }
                }
            }
            if (!frontCam)
            {
                if (IsControlJustPressed(0, 40) || IsControlJustPressed(0, 41))
                {
                    float fLocal_65 = GetFirstPersonAimCamZoomFactor();
                    if (fLocal_65 > 1f && fLocal_65 < 4.5f)
                    {
                        if (HasSoundFinished(iLocal_63))
                        {
                            iLocal_63 = Audio.PlaySoundFrontend("Camera_Zoom", "Phone_SoundSet_Default");
                        }
                    }
                    else
                    {
                        Audio.StopSound(iLocal_63);
                    }
                    iLocal_64 = true;
                }
                else if (IsControlPressed(0, 40) || IsControlPressed(0, 41))
                {
                    float fLocal_65 = GetFirstPersonAimCamZoomFactor();
                    if (fLocal_65 > 1f && fLocal_65 < 4.5f)
                    {
                        if (HasSoundFinished(iLocal_63))
                        {
                            iLocal_63 = Audio.PlaySoundFrontend("Camera_Zoom", "Phone_SoundSet_Default");
                        }
                    }
                    else
                    {
                        Audio.StopSound(iLocal_63);
                    }
                }
                else
                {
                    Audio.StopSound(iLocal_63);
                }
            }
            if (frontCam)
            {
                func_80();
                func_84();
            }
        }

        private void OpenCamera(bool enable)
        {
            if (enable)
            {
                camera.CallFunction("OPEN_SHUTTER");
                camera.CallFunction("SHOW_PHOTO_FRAME", grid);
                camera.CallFunction("SHOW_REMAINING_PHOTOS", 1);
            }
            else
            {
                camera.CallFunction("CLOSE_SHUTTER");
                camera.CallFunction("SHOW_PHOTO_FRAME", 0);
                camera.CallFunction("SHOW_REMAINING_PHOTOS", 0);
            }
            SetPedConfigFlag(PlayerPedId(), 242, enable);
            SetPedConfigFlag(PlayerPedId(), 243, enable);
            SetPedConfigFlag(PlayerPedId(), 244, !enable);
            CellCamActivate(enable, enable);
            // frontcam
            Function.Call((Hash)0x2491A93618B7D838, false);
        }



        private void func_80()//Position - 0xC809
        {
            int iVar0;
            int iVar1;
            int iVar2;
            int iVar3;
            float fVar4 = 0;
            float fVar5 = 0;
            float fVar6 = 0;
            float fVar7 = 0;
            float fVar8 = 0;
            int iVar9;
            int iVar10;

            if (IsUsingKeyboard(2))
            {
                iVar9 = 179;
                iVar10 = 21;
            }
            else
            {
                iVar9 = 228;
                iVar10 = 229;
            }
            if (IsControlPressed(2, iVar10) && !IsControlPressed(2, iVar9))
            {
                DisableControlAction(0, 2, true);
                DisableControlAction(0, 1, true);
                iVar0 = Floor(GetDisabledControlUnboundNormal(0, 30)) * 127;
                iVar1 = Floor(GetDisabledControlUnboundNormal(0, 31)) * 127;
                iVar2 = Floor(GetDisabledControlUnboundNormal(0, 1)) * 127;
                iVar3 = Floor(GetDisabledControlUnboundNormal(0, 2)) * 127;
                if (IsUsingKeyboard(2))
                {
                    if (Absi(iVar0) > 28 || Absi(iVar1) > 28)
                    {
                        fVar6 = (((iVar0) / 128f) * 0.075f);
                    }
                }
                else if (Absi(iVar2) > 28 || Absi(iVar3) > 28)
                {
                    fVar6 = (((iVar2) / 128f) * 0.075f);
                }
                if (IsUsingKeyboard(2))
                {
                    fVar7 = GetDisabledControlUnboundNormal(0, 290);
                    fVar8 = GetDisabledControlUnboundNormal(0, 291);
                    if (N_0xe1615ec03b3bb4fd())
                    {
                        fVar8 = (fVar8 * -1f);
                    }
                    fVar4 += fVar7;
                    fVar5 -= fVar8;
                }
                else if (Absi(iVar0) > 28 || Absi(iVar1) > 28)
                {
                    fVar4 = (((iVar0) / 128f) * 0.075f);
                    fVar5 = (((-iVar1) / 128f) * 0.075f);
                }
                func_83(fVar5);
                func_82(fVar6);
                func_81(fVar4);
            }
            else if (!IsControlPressed(2, iVar9))
            {
                EnableControlAction(0, 2, true);
                EnableControlAction(0, 1, true);
            }
        }

        private void func_81(float fParam0)//Position - 0xC988
        {
            fLocal_111 = (fLocal_111 + fParam0);
            if (fLocal_111 > 1f)
                fLocal_111 = 1f;
            else if (fLocal_111 < -1f)
                fLocal_111 = -1f;
            CellCamSetHeadPitch(fLocal_111);
        }

        private void func_82(float fParam0)//Position - 0xC9B4
        {
            fLocal_112 = (fLocal_112 + fParam0);
            if (fLocal_112 > 1f)
                fLocal_112 = 1f;
            else if (fLocal_112 < -1f)
                fLocal_112 = -1f;
            CellCamSetHeadRoll(fLocal_112);
        }

        private void func_83(float fParam0)//Position - 0xC9E0
        {
            fLocal_113 = (fLocal_113 + fParam0);
            if (fLocal_113 > 1f)
                fLocal_113 = 1f;
            else if (fLocal_113 < -1f)
                fLocal_113 = -1f;
            CellCamSetHeadHeight(fLocal_113);
        }
        private void func_84()
        {
            int iVar0;
            int iVar1;
            int iVar2;
            int iVar3;
            float fVar4 = 0;
            float fVar5 = 0;
            float fVar6 = 0;
            float fVar7 = 0;
            float fVar8;
            float fVar9;
            int iVar10;
            int iVar11;
            if (IsUsingKeyboard(2))
            {
                iVar10 = 179;
                iVar11 = 178;
                if (IsControlPressed(2, iVar10))
                {
                    if (IsControlJustPressed(2, 178))
                    {
                        CellCamSetDistance(0.5f);
                        CellCamSetVerticalOffset(0.85f);
                        N_0xac2890471901861c(0.5f);
                        CellCamSetRoll(-0.25f);
                        fLocal_107 = 0.5f;
                        fLocal_108 = 0.85f;
                        fLocal_109 = 0.5f;
                        fLocal_110 = -0.25f;
                    }
                }
            }
            else
            {
                iVar10 = 228;
                iVar11 = 229;
            }
            if (IsControlPressed(2, iVar10) && IsControlPressed(2, iVar11))
            {
                if (Input.IsControlJustPressed(Control.PhoneOption))
                {
                    CellCamSetDistance(0.5f);
                    CellCamSetVerticalOffset(0.85f);
                    N_0xac2890471901861c(0.5f);
                    CellCamSetRoll(-0.25f);
                    fLocal_107 = 0.5f;
                    fLocal_108 = 0.85f;
                    fLocal_109 = 0.5f;
                    fLocal_110 = -0.25f;
                }
                DisableControlAction(0, 2, true);
                DisableControlAction(0, 1, true);
                iVar0 = Floor(GetDisabledControlUnboundNormal(0, 30)) * 127;
                iVar1 = Floor(GetDisabledControlUnboundNormal(0, 31)) * 127;
                iVar2 = Floor(GetDisabledControlUnboundNormal(0, 1)) * 127;
                iVar3 = Floor(GetDisabledControlUnboundNormal(0, 2)) * 127;
                if (IsUsingKeyboard(2))
                {
                    iVar1 = Floor(GetDisabledControlUnboundNormal(0, 39)) * 127;
                    fVar8 = Floor(GetDisabledControlUnboundNormal(0, 290));
                    fVar9 = Floor(GetDisabledControlUnboundNormal(0, 291));
                    if (N_0xe1615ec03b3bb4fd())
                    {
                        fVar9 *= -1f;
                    }
                    fVar6 += fVar8;
                    fVar7 -= fVar9;
                }
                else if (Absi(iVar2) > 15 || Absi(iVar3) > 15)
                {
                    fVar6 = iVar2 / 128f * 0.075f;
                    fVar7 = (-iVar3) / 128f * 0.075f;
                }
                if (Absi(iVar0) > 28 || Absi(iVar1) > 28)
                {
                    fVar4 = iVar0 / 128f * 0.075f;
                    fVar5 = iVar1 / 128f * 0.075f;
                }
                func_88(fVar6);
                func_87(fVar7);
                func_86(fVar4);
                func_85(fVar5);
            }
            else if (!IsDisabledControlPressed(2, iVar11))
            {
                EnableControlAction(0, 2, true);
                EnableControlAction(0, 1, true);
            }
            if (!IsDisabledControlPressed(2, iVar10) && !IsDisabledControlPressed(2, iVar11))
            {
                iVar0 = Floor(GetDisabledControlUnboundNormal(0, 30)) * 127;
                iVar1 = Floor(GetDisabledControlUnboundNormal(0, 31)) * 127;
                iVar2 = Floor(GetDisabledControlUnboundNormal(0, 290)) * 127;
                iVar3 = Floor(GetDisabledControlUnboundNormal(0, 291)) * 127;
                iVar2 = Floor(GetDisabledControlUnboundNormal(0, 294)) * 127;
                iVar2 = Floor(GetDisabledControlUnboundNormal(0, 295)) * 127;
                iVar3 = Floor(GetDisabledControlUnboundNormal(0, 292)) * 127;
                iVar3 = Floor(GetDisabledControlUnboundNormal(0, 293)) * 127;
                if (Absi(iVar2) > 28 || Absi(iVar3) > 28)
                {
                    fVar6 = (((iVar2) / 128f) * 0.075f);
                    fVar7 = (((-iVar3) / 128f) * 0.075f);
                }
                if (Absi(iVar0) > 28 || Absi(iVar1) > 28)
                {
                    fVar4 = (((iVar0) / 128f) * 0.075f);
                    fVar5 = (((iVar1) / 128f) * 0.075f);
                }
                func_85(fVar5);
            }
        }

        private void func_85(float fParam0)//Position - 0xCD4B
        {
            fLocal_109 += fParam0;
            if (fLocal_109 > 1f)
                fLocal_109 = 1f;
            else if (fLocal_109 < 0f)
                fLocal_109 = 0f;
            N_0xac2890471901861c(fLocal_109);
        }

        private void func_86(float fParam0)//Position - 0xCD77
        {
            fLocal_110 += fParam0;
            if (fLocal_110 > 1f)
                fLocal_110 = 1f;
            else if (fLocal_110 < -1f)
                fLocal_110 = -1f;
            CellCamSetRoll(fLocal_110);
        }

        private void func_87(float fParam0)//Position - 0xCDA3
        {
            fLocal_108 += fParam0;
            if (fLocal_108 > 1.5f)
                fLocal_108 = 1.5f;
            else if (fLocal_108 < 0.5f)
                fLocal_108 = 0.5f;
            CellCamSetVerticalOffset(fLocal_108);
        }
        private void func_88(float fParam0)//Position - 0xCDDF
        {
            fLocal_107 += fParam0;
            if (fLocal_107 > 2f)
                fLocal_107 = 2f;
            else if (fLocal_107 < -1.7f)
                fLocal_107 = -1.7f;
            CellCamSetDistance(fLocal_107);
        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            RequestAnimDict("anim@mp_player_intselfieblow_kiss");
            RequestAnimDict("anim@mp_player_intselfiedock");
            RequestAnimDict("anim@mp_player_intselfiejazz_hands");
            RequestAnimDict("anim@mp_player_intselfiethe_bird");
            RequestAnimDict("anim@mp_player_intselfiethumbs_up");
            RequestAnimDict("anim@mp_player_intselfiewank");
            await Phone.RotateAnimation(PhoneAnimation.OPEN_CAMERA);
            ClientMain.Instance.AddTick(CameraTick);
            OpenCamera(true);
            ClientMain.Instance.AddTick(TickControls);
            Main.InstructionalButtons.SetInstructionalButtons(IB_RearCam);
            MinimapHandler.MinimapEnabled = false;
        }

        public override async void Kill()
        {
            MinimapHandler.MinimapEnabled = true;
            currentFilter = 0;
            currentFrame = 0;
            TaskStopPhoneGestureAnimation(PlayerPedId());
            Function.Call(Hash.SET_FACIAL_IDLE_ANIM_OVERRIDE, PlayerCache.MyClient.Ped.Handle, "mood_normal_1", 0);
            ClearFacialIdleAnimOverride(PlayerCache.MyClient.Ped.Handle);
            Function.Call((Hash)0xA2CCBE62CD4C91A4, false);//MOBILE::CELL_CAM_ACTIVATE_SHALLOW_DOF_MODE
            SetMobilePhoneUnk(false);
            CellCamSetHorizontalOffset(1f);
            ClearTimecycleModifier();
            RemoveAnimDict("anim@mp_player_intselfieblow_kiss");
            RemoveAnimDict("anim@mp_player_intselfiedock");
            RemoveAnimDict("anim@mp_player_intselfiejazz_hands");
            RemoveAnimDict("anim@mp_player_intselfiethe_bird");
            RemoveAnimDict("anim@mp_player_intselfiethumbs_up");
            RemoveAnimDict("anim@mp_player_intselfiewank");
            ClientMain.Instance.RemoveTick(CameraTick);
            ClientMain.Instance.RemoveTick(TickControls);
            Main.InstructionalButtons.ClearButtonList();
            SetMobilePhoneRotation(Phone.RotationVertical.X, Phone.RotationVertical.Y, Phone.RotationVertical.Z, 2);
            await Phone.RotateAnimation(PhoneAnimation.CLOSE_CAMERA);
        }
    }
}
