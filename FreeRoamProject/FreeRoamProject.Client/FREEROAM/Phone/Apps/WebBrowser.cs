using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData.Model.Diamond;
using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData.Model.MazeBank;
using FreeRoamProject.Client.FREEROAM.Phone.Models;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty;
using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.ForClosures;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.FREEROAM.Banking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Apps
{
    public enum BrowserSkin
    {
        IFRUIT,
        IFRUIT2,
        BADGER,
        FACADE,
        IFRUIT3,
    }
    public class WebBrowser : App
    {
        private readonly int CELEBRATION_SCREEN = 10;
        private readonly int YACHT = 11;
        private readonly int OFFICE = 12;
        private readonly int CLUBHOUSE = 13;
        private readonly int GARAGE_1 = 14;
        private readonly int GARAGE_2 = 15;
        private readonly int VEHICLE_SALE = 16;
        private readonly int TRUCK = 17;
        private readonly int CHOPPER = 18;
        private readonly int ARENA_GARAGE = 19;
        private int FrameCount = 0;
        private bool ShowingVideo = false;
        private float browserrollDistance = 0;
        private int iLocal_248 = 0;
        private int iLocal_249 = 0;
        private int iLocal_250 = 0;
        private int iLocal_251 = 0;
        private int iLocal_252;
        private int iLocal_253;
        private int iLocal_254;
        private int iLocal_255;
        private readonly bool bLocal_1016 = false;
        private float fLocal_256 = 0;
        private float fLocal_257 = 0;
        private float fLocal_258 = 0;
        private float fLocal_259 = 0;
        private int iLocal_235;
        private int iLocal_236;
        private int iLocal_237;
        private int iLocal_238;
        private int iLocal_239;
        private int iLocal_240;
        private int iLocal_241;
        private int iLocal_242;
        private int iLocal_243;
        private int iLocal_247;

        private readonly float posXLast = 0;
        private readonly float posYLast = 0;
        private readonly bool isWatchingVideo = false;
        private ScaleformWideScreen fontLib;
        internal ScaleformWideScreen browser;
        private bool _isDynamic = false;
        private readonly bool _showingBrowser = false;
        private readonly Random random = new(GetGameTimer());

        private int _currentSiteId = -1;
        private int _currentPageId = 1;
        private int _currentSelection = 0;
        public bool ShowBrowser = false;

        public int CurrentSiteId => _currentSiteId;
        public int CurrentPageId => _currentPageId;
        public int CurrentSelection => _currentSelection;

        bool KeyboardOpen = false;

        public WebBrowser(Phone phone) : base("CELL_2", IconLabels.EYEFIND, phone, 0)
        {

        }

        public async Task VisualTick()
        {
            if (!ShowBrowser) return;
            BrowserLogic();
            SetScriptGfxDrawOrder(1);
            browser.Render2D();
        }

        private async void BrowserLogic()
        {
            if (!ShowBrowser) return;

            int currentSiteId = await GetSiteId();
            int currentPageId = await GetPageId();

            if (currentSiteId == -1 && currentPageId == -1) return;


            if (_currentSiteId != currentSiteId || _currentPageId != currentPageId)
            {
                _currentSiteId = currentSiteId;
                _currentPageId = currentPageId;

                if (CurrentSiteId != -1 && (currentPageId == 1 || currentPageId == 2))
                {
                    InitaliseWebsite();
                    IsDynamic();
                    switch (currentSiteId)
                    {
                        case (int)eWebsiteDynamic.WWW_EYEFIND_INFO:
                            if (currentPageId != 7 && currentPageId != 8)
                            {
                                SetDataSlotEmpty();
                                EyeFind.SetupWebBrowserHeader(this, currentPageId);
                                UpdateText();
                            }
                            break;
                        case (int)eWebsiteDynamic.WWW_DYNASTY8REALESTATE_COM:
                            {
                                SetDataSlotEmpty();
                                Dynasty8RealEstateHandler.LoadApartments(this);
                                UpdateText();
                            }
                            break;
                        case (int)eWebsiteDynamic.WWW_DYNASTY8EXECUTIVEREALTY_COM:
                            {
                                SetDataSlotEmpty();
                                Dynasty8ExecutiveHandler.LoadOffices(this);
                                UpdateText();
                            }
                            break;
                        case (int)eWebsiteDynamic.WWW_MAZE_D_BANK_COM:
                            {
                                SetDataSlotEmpty();
                                MazeBankHandler.LoadBank(this);
                                UpdateText();
                            }
                            break;
                        case (int)eWebsiteDynamic.FORECLOSURES_MAZE_D_BANK_COM: // func_7280
                            {
                                SetDataSlotEmpty();
                                ForClosuresHandler.LoadProperties(this);
                                UpdateText();
                                break;
                            }

                        case (int)eWebsiteDynamic.WWW_LEGENDARYMOTORSPORT_NET:
                        case (int)eWebsiteDynamic.WWW_ELITASTRAVEL_COM:
                        case (int)eWebsiteDynamic.WWW_WARSTOCK_D_CACHE_D_AND_D_CARRY_COM:
                        case (int)eWebsiteDynamic.WWW_DOCKTEASE_COM:
                        case (int)eWebsiteDynamic.WWW_PANDMCYCLES_COM:
                        case (int)eWebsiteDynamic.WWW_SOUTHERNSANANDREASSUPERAUTOS_COM:
                        case (int)eWebsiteDynamic.WWW_BENNYSORIGINALMOTORWORKS_COM:
                        case (int)eWebsiteDynamic.WWW_ARENAWAR_TV:
                            {
                                SetDataSlotEmpty();
                                VehicleSitesHandler.InitVehs((eWebsiteDynamic)currentSiteId, this);
                                UpdateText();
                            }
                            //TODO: currentPageId IS THE ID OF THE VEHICLE
                            // currentSelection for the color selection..
                            // currentSelection can be also used for vehicle selection... ummmm
                            break;
                        case (int)eWebsiteDynamic.WWW_THEDIAMONDCASINOANDRESORT_COM:
                            {
                                SetDataSlotEmpty();
                                DiamondCasinoHandler.LoadCasino(this);
                                UpdateText();
                            }
                            break;
                        case (int)eWebsiteDynamic.WWW_IWILLSURVIVEITALL_COM:
                            {

                            }
                            break;
                    }
                }
                else if (CurrentSiteId == -1 && CurrentPageId == 1)
                {
                    await BaseScript.Delay(250);
                    if (CurrentSiteId == -1 && CurrentPageId == 1)
                    {
                        InitaliseWebsite();
                        IsDynamic();
                    }
                }
            }

            Notifications.DrawText(0.35f, 0.675f, $"currentSite: " + await GetCurrentWebside(), color: SColor.HUD_Orange);
            Notifications.DrawText(0.35f, 0.7f, $"currentSiteID: " + currentSiteId, color: SColor.HUD_Orange);
            Notifications.DrawText(0.35f, 0.725f, $"currentPageID: " + currentPageId, color: SColor.HUD_Orange);
            Notifications.DrawText(0.35f, 0.75f, $"currentSelection: " + _currentSelection, color: SColor.HUD_Orange);

            for (int i = 0; i < 20; i++)
            {
                Notifications.DrawText(0.8f, 0.4f + (0.025f * i), $"GetGlobalActionscriptFlag({i}): {GetGlobalActionscriptFlag(i)}", color: SColor.HUD_Orange);
            }
        }

        public override async Task TickControls()
        {
            DisableControls();
            GetControlValues(ref iLocal_248, ref iLocal_249, ref iLocal_250, ref iLocal_251, true, false);
            if (iLocal_248 < 10 && iLocal_248 > -10)
            {
                iLocal_248 = 0;
            }
            if (iLocal_249 < 10 && iLocal_249 > -10)
            {
                iLocal_249 = 0;
            }
            if (iLocal_250 < 10 && iLocal_250 > -10)
            {
                iLocal_250 = 0;
            }
            if (iLocal_251 < 10 && iLocal_251 > -10)
            {
                iLocal_251 = 0;
            }
            float fVar1 = 1f + (10f * Timestep());

            if (!isWatchingVideo)
            {
                if (IsUsingKeyboard_2(2))
                {
                    fLocal_256 = Game.GetDisabledControlNormal(2, Control.CursorX);
                    fLocal_257 = Game.GetDisabledControlNormal(2, Control.CursorY);
                    if (fLocal_256 != fLocal_258 || fLocal_257 != fLocal_259)
                    {
                        browser.CallFunction("SET_MOUSE_INPUT", fLocal_256, fLocal_257);
                        fLocal_258 = fLocal_256;
                        fLocal_259 = fLocal_257;
                    }
                }
                if (IsUsingKeyboard(2))
                {
                    if (Game.IsControlPressed(2, Control.FrontendDown) || Game.IsControlPressed(2, Control.FrontendLt) || Game.IsDisabledControlJustPressed(2, Control.FrontendLt) || Game.IsDisabledControlJustPressed(2, Control.FrontendDown))
                    {
                        browserrollDistance = 200f;
                    }
                    else if (Game.IsControlPressed(2, Control.FrontendUp) || Game.IsControlPressed(2, Control.FrontendRt) || Game.IsDisabledControlJustPressed(2, Control.FrontendRt) || Game.IsDisabledControlJustPressed(2, Control.FrontendUp))
                    {
                        browserrollDistance = -200f;
                    }
                    else if (Game.IsControlPressed(2, Control.CursorScrollDown) || Game.IsDisabledControlPressed(2, Control.CursorScrollDown))
                    {
                        if (browserrollDistance <= 0f)
                        {
                            browserrollDistance = 200f;
                        }
                        else
                        {
                            browserrollDistance += 200f;
                            if (browserrollDistance >= 1000f)
                            {
                                browserrollDistance = 1000f;
                            }
                        }
                    }
                    else if (Game.IsControlPressed(2, Control.CursorScrollUp) || Game.IsDisabledControlPressed(2, Control.CursorScrollUp))
                    {
                        if (browserrollDistance >= 0f)
                        {
                            browserrollDistance = -200f;
                        }
                        else
                        {
                            browserrollDistance -= 200f;
                            if (browserrollDistance <= -1000f)
                            {
                                browserrollDistance = -1000f;
                            }
                        }
                    }
                }
                else
                {
                    if (iLocal_252 != iLocal_248 || iLocal_253 != iLocal_249)
                    {

                        browser.CallFunction("SET_ANALOG_STICK_INPUT", 1, iLocal_248 * fVar1, iLocal_249 * fVar1);
                        iLocal_252 = iLocal_248;
                        iLocal_253 = iLocal_249;
                    }
                    if (iLocal_254 != iLocal_250 || iLocal_255 != iLocal_251)
                    {
                        browser.CallFunction("SET_ANALOG_STICK_INPUT", 0, iLocal_250 * fVar1, iLocal_251 * fVar1);
                        iLocal_254 = iLocal_250;
                        iLocal_255 = iLocal_251;
                        browserrollDistance = 0f;
                    }
                }
                if (browserrollDistance != 0f)
                {
                    browserrollDistance *= 0.9f;
                    if (browserrollDistance < 5f && browserrollDistance > -5f)
                    {
                        browserrollDistance = 0f;
                    }
                    browser.CallFunction("SET_ANALOG_STICK_INPUT", 0, 0f, browserrollDistance, true);
                }
                if (Game.IsControlPressed(2, Control.FrontendLb) || Game.IsDisabledControlJustPressed(2, Control.FrontendLb))
                {
                    if (!bLocal_1016)
                    {
                        if (iLocal_235 == 0)
                        {
                            iLocal_235 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 4);
                        }
                    }
                }
                else
                {
                    iLocal_235 = 0;
                }
                if (Game.IsControlPressed(2, Control.FrontendLt) || Game.IsDisabledControlJustPressed(2, Control.FrontendLt))
                {
                    if (iLocal_236 == 0)
                    {
                        iLocal_236 = 1;
                        browser.CallFunction("SET_INPUT_EVENT", 5);
                    }
                }
                else
                {
                    iLocal_236 = 0;
                }
                if (Game.IsControlPressed(2, Control.FrontendLb) || Game.IsDisabledControlJustPressed(2, Control.FrontendLb))
                {
                    if (!bLocal_1016)
                    {
                        if (iLocal_237 == 0)
                        {
                            iLocal_237 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 6);
                        }
                    }
                }
                else
                {
                    iLocal_237 = 0;
                }
                if (Game.IsControlPressed(2, Control.FrontendRt) || Game.IsDisabledControlJustPressed(2, Control.FrontendRt))
                {
                    if (iLocal_238 == 0)
                    {
                        iLocal_238 = 1;
                        browser.CallFunction("SET_INPUT_EVENT", 7);
                    }
                }
                else
                {
                    iLocal_238 = 0;
                }
                if (Game.IsControlJustReleased(2, Control.FrontendRt) || Game.IsDisabledControlJustPressed(2, Control.FrontendRt))
                {
                    iLocal_238 = 0;
                    browser.CallFunction("SET_INPUT_RELEASE_EVENT", 7);
                }
                if (Game.IsControlJustReleased(2, Control.FrontendLt) || Game.IsDisabledControlJustPressed(2, Control.FrontendLt))
                {
                    iLocal_236 = 0;
                    browser.CallFunction("SET_INPUT_RELEASE_EVENT", 5);
                }
                if (!IsUsingKeyboard(2))
                {
                    if (Game.IsControlPressed(2, Control.FrontendUp) || Game.IsDisabledControlPressed(2, Control.FrontendUp))
                    {
                        if (iLocal_239 == 0)
                        {
                            iLocal_239 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 8);
                        }
                    }
                    else
                    {
                        iLocal_239 = 0;
                    }
                    if (Game.IsControlPressed(2, Control.FrontendDown) || Game.IsDisabledControlPressed(2, Control.FrontendDown))
                    {
                        if (iLocal_240 == 0)
                        {
                            iLocal_240 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 9);
                        }
                    }
                    else
                    {
                        iLocal_240 = 0;
                    }
                    if (Game.IsControlPressed(2, Control.FrontendLeft) || Game.IsDisabledControlPressed(2, Control.FrontendLeft))
                    {
                        if (iLocal_241 == 0)
                        {
                            iLocal_241 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 10);
                        }
                    }
                    else
                    {
                        iLocal_241 = 0;
                    }
                    if (Game.IsControlPressed(2, Control.FrontendRight) || Game.IsDisabledControlPressed(2, Control.FrontendRight))
                    {
                        if (iLocal_242 == 0)
                        {
                            iLocal_242 = 1;
                            browser.CallFunction("SET_INPUT_EVENT", 11);
                        }
                    }
                    else
                    {
                        iLocal_242 = 0;
                    }
                }
                else if (IsControlReleased(2, (int)Control.CursorAccept) || IsDisabledControlReleased(2, (int)Control.CursorAccept))
                {
                    if (iLocal_247 == 1)
                    {
                        iLocal_247 = 0;
                        browser.CallFunction("SET_INPUT_RELEASE_EVENT", 237);
                    }
                }
                else
                {
                    iLocal_247 = 1;
                }
                if (Game.IsControlPressed(2, Control.FrontendSelect) || Game.IsDisabledControlJustPressed(2, Control.FrontendSelect))
                {
                    if (iLocal_243 == 0)
                    {
                        iLocal_243 = 1;
                        browser.CallFunction("SET_INPUT_RELEASE_EVENT", 13);
                    }
                }
                else
                {
                    iLocal_243 = 0;
                }
            }


            if (Game.IsControlJustPressed(0, Control.CursorAccept) || Game.IsControlJustPressed(2, Control.FrontendAccept))
            {
                if (!KeyboardOpen)
                {
                    KeyboardOpen = true;
                    if (IsKeyboardOpen())
                    {
                        if (IsUsingKeyboard(2))
                        {
                            if (Game.IsControlPressed(2, Control.FrontendAccept) || Game.IsDisabledControlJustPressed(2, Control.FrontendAccept))
                            {
                                return;
                            }
                        }
                    }
                    BeginScaleformMovieMethod(browser.Handle, "SET_INPUT_EVENT");
                    if (Game.IsControlPressed(2, Control.FrontendAccept) || Game.IsDisabledControlJustPressed(2, Control.FrontendAccept))
                    {
                        ScaleformMovieMethodAddParamInt(16);
                    }
                    else
                    {
                        ScaleformMovieMethodAddParamInt(1001);
                    }
                    EndScaleformMovieMethod();
                    if (IsUsingKeyboard_2(2))
                    {
                        browser.CallFunction("SET_MOUSE_INPUT", Game.GetDisabledControlNormal(2, Control.CursorX), Game.GetDisabledControlNormal(2, Control.CursorY));
                    }
                    else
                    {
                        browser.CallFunction("SET_ANALOG_STICK_INPUT", 0f, 0f, 0f);
                        browserrollDistance = 0f;
                    }
                    _currentSelection = await browser.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
                    int currentSiteId = await GetSiteId();
                    int currentPageId = await GetPageId();

                    if (_currentPageId != currentPageId)
                        _currentPageId = currentPageId;
                    if (CurrentSiteId != currentSiteId)
                        _currentSiteId = currentSiteId;

                    Debug.WriteLine($"currentSite: " + CurrentSiteId);
                    Debug.WriteLine($"currentPage: " + CurrentPageId);
                    Debug.WriteLine($"currentSelection: " + CurrentSelection);

                    if (CurrentSiteId != -1)
                    {
                        switch (CurrentSiteId)
                        {
                            case 2:
                                if (CurrentSelection == 1)
                                {
                                    int i = 10;
                                    while (i != 0)
                                    {
                                        await BaseScript.Delay(0);
                                        if (IsUsingKeyboard_2(2))
                                        {
                                            browser.CallFunction("SET_MOUSE_INPUT", Game.GetDisabledControlNormal(2, Control.CursorX), Game.GetDisabledControlNormal(2, Control.CursorY));
                                        }
                                        else
                                        {
                                            browser.CallFunction("SET_ANALOG_STICK_INPUT", 0f, 0f, 0f);
                                            browserrollDistance = 0f;
                                        }
                                        i--;
                                    }
                                }
                                break;
                            case 21:
                                MazeBankHandler.HandleClick(this);
                                break;
                            case 18:
                                Dynasty8RealEstateHandler.HandleClick(this);
                                break;
                            case 28: // FORECLOSURES_MAZE_D_BANK_COM
                                {
                                    if (CurrentPageId == 9)
                                    {
                                        if (CurrentSelection == 7)
                                        {
                                            int bitwise = GetGlobalActionscriptFlag(13);
                                            int idx = 0;
                                            int wall = 0;
                                            int hanging = 0;
                                            int furniture = 0;
                                            int mural = 0;
                                            int font = 0;
                                            int fontColour = 0;
                                            int emblem = 0;
                                            bool hideSignage = false;
                                            string signage = "";
                                            bool gunLocker = false;
                                            bool bikeShop = false;

                                            ForClosuresHandler.GetPurchasedClubhouseData(bitwise, ref idx, ref wall, ref hanging, ref furniture, ref mural, ref font, ref fontColour, ref emblem, ref hideSignage, ref signage, ref gunLocker, ref bikeShop);
                                        }
                                    }
                                    if (CurrentPageId == 36 && !ShowingVideo)
                                    {
                                        switch (CurrentSelection)
                                        {
                                            case 12:
                                                DrawVideo("PL_WEB_LR1");
                                                FrameCount = GetFrameCount() + 644;
                                                break;

                                            case 13:
                                                DrawVideo("PL_WEB_LR2");
                                                FrameCount = GetFrameCount() + 443;
                                                break;

                                            case 14:
                                                DrawVideo("PL_WEB_LR3");
                                                FrameCount = GetFrameCount() + 522;
                                                break;

                                            case 15:
                                                DrawVideo("PL_WEB_LR4");
                                                FrameCount = GetFrameCount() + 528;
                                                break;
                                        }
                                    }

                                    break;
                                }

                            case 30 when !ShowingVideo:
                                if (CurrentPageId == 1 && CurrentSelection == 0)
                                {
                                    DrawVideo("PL_WEB_CAS");
                                    FrameCount = GetFrameCount() + 2467 + 500;
                                }
                                break;
                        }
                    }
                    else
                    {
                        string website = await GetCurrentWebside();
                        switch (website.ToLower())
                        {
                            case "www_fameorshame_net":
                                if (!ShowingVideo)
                                {
                                    if (currentPageId == 2 && CurrentSelection == 6)
                                    {
                                        DrawVideo("PL_WEB_FOS");
                                    }
                                    else if (currentPageId == 1 && CurrentSelection == 8)
                                    {
                                        DrawVideo("PL_WEB_FOS");
                                    }
                                    else if (currentPageId == 4 && CurrentSelection == 8)
                                    {
                                        DrawVideo("PL_WEB_FOS");
                                    }
                                    else if (currentPageId == 4 && CurrentSelection == 8)
                                    {
                                        DrawVideo("PL_WEB_FOS");
                                    }
                                }
                                break;
                            case "www_jackhowitzer_com":
                                if (!ShowingVideo)
                                {
                                    if (CurrentSelection == 7)
                                    {
                                        DrawVideo("PL_WEB_HOWITZER");
                                    }
                                }
                                break;
                            case "www_kungfurainbowlazerforce_com":
                                if (!ShowingVideo)
                                {
                                    if (CurrentSelection == 6)
                                    {
                                        DrawVideo("PL_WEB_KFLF");
                                    }
                                }
                                break;
                            case "www_princessrobotbubblegum_com":
                                if (IsDlcPresent(Functions.HashUint("patchday3ng")))
                                {
                                    if (!ShowingVideo)
                                    {
                                        if (CurrentSelection == 6)
                                        {
                                            DrawVideo("PL_WEB_PRB2");
                                        }
                                    }
                                }
                                break;
                            case "www_republicanspacerangers_com":
                                if (!ShowingVideo)
                                {
                                    if (CurrentSelection == 8)
                                    {
                                        DrawVideo("PL_WEB_RANGERS");
                                    }
                                }
                                break;
                            case "www_righteousslaughter7_com":
                                if (!ShowingVideo)
                                {
                                    if (CurrentSelection == 3)
                                    {
                                        DrawVideo("PL_WEB_RS");
                                    }
                                }
                                break;
                            case "www_taco_d_bomb_com":
                                if (currentPageId == 2)
                                {
                                    switch (CurrentSelection)
                                    {
                                        case 0:
                                            StartScriptedConversation(0);
                                            break;
                                        case 1:
                                            StartScriptedConversation(1);
                                            break;
                                        case 2:
                                            StartScriptedConversation(2);
                                            break;
                                        case 3:
                                            StartScriptedConversation(3);
                                            break;
                                        case 4:
                                            StartScriptedConversation(4);
                                            break;
                                        case 5:
                                            StartScriptedConversation(5);
                                            break;
                                        case 6:
                                            StartScriptedConversation(6);
                                            break;
                                    }
                                }
                                break;

                        }
                    }
                }
            }
            if (KeyboardOpen)
            {
                KeyboardOpen = false;
                browser.CallFunction("SET_CURSOR_STATE", "ARROW");
            }
            if (IsKeyboardOpen())
            {
                browser.CallFunction("SHOW_CURSOR", true);
                if (IsUsingKeyboard(2 /*FRONTEND_CONTROL*/))
                {
                    DisableControlAction(2 /*FRONTEND_CONTROL*/, 202 /*INPUT_FRONTEND_CANCEL*/, true);
                }
            }

            if (ShowingVideo)
            {
                if (IsPauseMenuActive())
                {
                    browser.CallFunction("SUPRESS_HISTORY", false);
                    SetTvChannel(-1);
                    StopAudioScene("INTERNET_BROWSER_VIDEO_SCENE");
                    FrameCount = -1;
                    ShowingVideo = false;
                }
                else
                {
                    SetTextRenderId(GetDefaultScriptRendertargetRenderId());
                    SetScriptGfxDrawOrder(4);
                    SetScriptGfxDrawBehindPausemenu(true);
                    DrawTvChannel(0.5f, 0.5f, 0.5f, 0.5f, 0f, 255, 255, 255, 255);
                }
                if (FrameCount != -1)
                {
                    int frame = GetFrameCount();
                    if (frame >= FrameCount)
                    {
                        browser.CallFunction("SUPRESS_HISTORY", false);
                        SetTvChannel(-1);
                        StopAudioScene("INTERNET_BROWSER_VIDEO_SCENE");
                        FrameCount = -1;
                        ShowingVideo = false;
                    }
                }
            }
            bool isBrowserOpen = GetGlobalActionscriptFlag(1) == 1;
            if ((Game.IsControlJustPressed(0, Control.CursorCancel) || Game.IsControlJustPressed(2, Control.FrontendCancel)))
            {
                if (ShowingVideo)
                {
                    browser.CallFunction("SUPRESS_HISTORY", false);
                    SetTvChannel(-1);
                    StopAudioScene("INTERNET_BROWSER_VIDEO_SCENE");
                    FrameCount = -1;
                    ShowingVideo = false;
                }
                else if (isBrowserOpen)
                {
                    browser.CallFunction("SET_INPUT_EVENT", 15);
                    browser.CallFunction("GO_BACK");
                    PlaySoundFrontend(-1, "CLICK_BACK", "WEB_NAVIGATION_SOUNDS_PHONE", true);
                }
                else
                {
                    ShowBrowser = false;
                    Phone.StartApp("MAINMENU");
                }
            }
        }

        private void GetControlValues(ref int iParam0, ref int iParam1, ref int iParam2, ref int iParam3, bool checkDisabled, bool checkInverted)//Position - 0x13E924
        {
            iParam0 = Floor((GetControlUnboundNormal(2, 218) * 127f));
            iParam1 = Floor((GetControlUnboundNormal(2, 219) * 127f));
            iParam2 = Floor((GetControlUnboundNormal(2, 220) * 127f));
            iParam3 = Floor((GetControlUnboundNormal(2, 221) * 127f));
            if (checkDisabled)
            {
                if (!IsControlEnabled(2, 218))
                {
                    iParam0 = Floor(GetDisabledControlUnboundNormal(2, 218) * 127f);
                }
                if (!IsControlEnabled(2, 219))
                {
                    iParam1 = Floor(GetDisabledControlUnboundNormal(2, 219) * 127f);
                }
                if (!IsControlEnabled(2, 220))
                {
                    iParam2 = Floor(GetDisabledControlUnboundNormal(2, 220) * 127f);
                }
                if (!IsControlEnabled(2, 221))
                {
                    iParam3 = Floor(GetDisabledControlUnboundNormal(2, 221) * 127f);
                }
            }
            if (IsUsingKeyboard(2))
            {
                if (checkInverted)
                {
                    if (IsLookInverted())
                    {
                        iParam3 *= -1;
                    }
                    if (N_0xe1615ec03b3bb4fd())
                    {
                        iParam3 *= -1;
                    }
                }
            }
        }

        public override async void Initialize(Phone phone)
        {
            Phone = phone;
            fontLib = new ScaleformWideScreen("font_lib_web");
            while (!fontLib.IsLoaded) await BaseScript.Delay(0);
            browser = new ScaleformWideScreen("web_browser");
            while (!browser.IsLoaded) await BaseScript.Delay(0);
            MinimapHandler.MinimapEnabled = false;
            ClientMain.Instance.AddTick(VisualTick);
            ClientMain.Instance.AddTick(TickControls);
            browser.CallFunction("SET_WIDESCREEN", GetIsWidescreen());
            PlayerCache.MyPed.SetConfigFlag(185, true);
            BankingClient.ShowMoney(-1);
            SetMobilePhonePosition(Phone.PositionHidden.X, Phone.PositionHidden.Y, Phone.PositionHidden.Z);
            SetMultiplayer(true);
            SetSkin(BrowserSkin.IFRUIT3);//4 = multiplayer
            int currentSiteId = await GetSiteId();
            while (currentSiteId == -1 && _currentSiteId == -1)
            {
                await BaseScript.Delay(0);
                currentSiteId = await GetSiteId();
                GoToWebPage(2, 1);
            }
            ShowBrowser = true;
        }

        public override void Kill()
        {
            ShowBrowser = false;
            MinimapHandler.MinimapEnabled = true;
            BankingClient.HideMoney();
            PlayerCache.MyPed.SetConfigFlag(185, false);
            ClientMain.Instance.RemoveTick(VisualTick);
            ClientMain.Instance.RemoveTick(TickControls);
            SetMobilePhonePosition(Phone.PositionOpen.X, Phone.PositionOpen.Y, Phone.PositionOpen.Z);
        }

        private void DisableControls()
        {
            // TODO: Add death check
            Game.DisableAllControlsThisFrame(0);
            Game.DisableAllControlsThisFrame(2);

            Game.EnableControlThisFrame(2, Control.FrontendAccept /*Control.FrontendAccept INPUT_FRONTEND_ACCEPT*/);
            Game.EnableControlThisFrame(2, Control.FrontendCancel /*202 INPUT_FRONTEND_CANCEL*/);
            Game.EnableControlThisFrame(2, Control.FrontendDown /*Control.FrontendDown INPUT_FRONTEND_DOWN*/);
            Game.EnableControlThisFrame(2, Control.FrontendLb /*Control.FrontendLb INPUT_FRONTEND_LB*/);
            Game.EnableControlThisFrame(2, Control.FrontendLeft /*Control.FrontendLeft INPUT_FRONTEND_LEFT*/);
            Game.EnableControlThisFrame(2, Control.FrontendLt /*207 INPUT_FRONTEND_LT*/);
            Game.EnableControlThisFrame(2, Control.FrontendRb /*206 INPUT_FRONTEND_RB*/);
            Game.EnableControlThisFrame(2, Control.FrontendRight /*Control.FrontendRight INPUT_FRONTEND_RIGHT*/);
            Game.EnableControlThisFrame(2, Control.FrontendRt /*Control.FrontendRt INPUT_FRONTEND_RT*/);
            Game.EnableControlThisFrame(2, Control.FrontendSelect /*217 INPUT_FRONTEND_SELECT*/);
            Game.EnableControlThisFrame(2, Control.FrontendUp /*Control.FrontendUp INPUT_FRONTEND_UP*/);
            Game.EnableControlThisFrame(2, Control.FrontendX /*203 INPUT_FRONTEND_X*/);
            Game.EnableControlThisFrame(2, Control.FrontendY /*204 INPUT_FRONTEND_Y*/);
            Game.EnableControlThisFrame(2, Control.FrontendAxisX /*195 INPUT_FRONTEND_AXIS_X*/);
            Game.EnableControlThisFrame(2, Control.FrontendAxisY /*196 INPUT_FRONTEND_AXIS_Y*/);
            Game.EnableControlThisFrame(2, Control.FrontendRightAxisX /*197 INPUT_FRONTEND_RIGHT_AXIS_X*/);
            Game.EnableControlThisFrame(2, Control.FrontendRightAxisY /*198 INPUT_FRONTEND_RIGHT_AXIS_Y*/);
            Game.EnableControlThisFrame(2, Control.CursorAccept /*237 INPUT_CURSOR_ACCEPT*/);
            Game.EnableControlThisFrame(2, Control.CursorCancel /*238 INPUT_CURSOR_CANCEL*/);
            Game.EnableControlThisFrame(2, Control.CursorX /*239 INPUT_CURSOR_X*/);
            Game.EnableControlThisFrame(2, Control.CursorY /*240 INPUT_CURSOR_Y*/);
            Game.EnableControlThisFrame(2, Control.CursorScrollUp /*241 INPUT_CURSOR_SCROLL_UP*/);
            Game.EnableControlThisFrame(2, Control.CursorScrollDown /*242 INPUT_CURSOR_SCROLL_DOWN*/);
            SetInputExclusive(2, (int)Control.FrontendRight /*INPUT_FRONTEND_RIGHT*/);
            SetInputExclusive(2, (int)Control.FrontendLeft /*INPUT_FRONTEND_LEFT*/);
            SetInputExclusive(2, (int)Control.FrontendDown /*INPUT_FRONTEND_DOWN*/);
            SetInputExclusive(2, (int)Control.FrontendUp /*INPUT_FRONTEND_UP*/);
            Game.EnableControlThisFrame(0, Control.NextCamera /*0 INPUT_NEXT_CAMERA*/);
            if (GetCamViewModeForContext(GetCamActiveViewModeContext()) == 4)
            {
                Game.EnableControlThisFrame(0, Control.LookLeftRight /*1 INPUT_LOOK_LR*/);
                Game.EnableControlThisFrame(0, Control.LookUpDown /*2 INPUT_LOOK_UD*/);
                Game.EnableControlThisFrame(0, Control.LookUpOnly /*3 INPUT_LOOK_UP_ONLY*/);
                Game.EnableControlThisFrame(0, Control.LookDownOnly /*4 INPUT_LOOK_DOWN_ONLY*/);
                Game.EnableControlThisFrame(0, Control.LookLeftOnly /*5 INPUT_LOOK_LEFT_ONLY*/);
                Game.EnableControlThisFrame(0, Control.LookRightOnly /*6 INPUT_LOOK_RIGHT_ONLY*/);
            }
            Game.EnableControlThisFrame(0, Control.VehicleCinematicUpDown /*95 INPUT_VEH_CINEMATIC_UD*/);
            Game.EnableControlThisFrame(0, Control.VehicleCinematicLeftRight /*98 INPUT_VEH_CINEMATIC_LR*/);
            Game.EnableControlThisFrame(0, Control.FrontendLs /*209 INPUT_FRONTEND_LS*/);
            Game.EnableControlThisFrame(0, Control.FrontendRs /*210 INPUT_FRONTEND_RS*/);
            Game.EnableControlThisFrame(0, Control.ScriptLT /*228 INPUT_SCRIPT_LT*/);
            Game.EnableControlThisFrame(0, Control.ScriptRT /*229 INPUT_SCRIPT_RT*/);
            Game.EnableControlThisFrame(0, Control.ScriptLS /*230 INPUT_SCRIPT_LS*/);
            Game.EnableControlThisFrame(0, Control.ScriptRS /*231 INPUT_SCRIPT_RS*/);
            Game.EnableControlThisFrame(0, Control.ScriptLeftAxisX /*218 INPUT_SCRIPT_LEFT_AXIS_X*/);
            Game.EnableControlThisFrame(0, Control.ScriptLeftAxisY /*219 INPUT_SCRIPT_LEFT_AXIS_Y*/);
            Game.EnableControlThisFrame(0, Control.ScriptRightAxisX /*220 INPUT_SCRIPT_RIGHT_AXIS_X*/);
            Game.EnableControlThisFrame(0, Control.ScriptRightAxisY /*221 INPUT_SCRIPT_RIGHT_AXIS_Y*/);
            SetInputExclusive(2, (int)Control.CursorAccept /*INPUT_CURSOR_ACCEPT*/);
            SetInputExclusive(2, (int)Control.CursorCancel /*INPUT_CURSOR_CANCEL*/);
            SetInputExclusive(2, (int)Control.CursorX /*INPUT_CURSOR_X*/);
            SetInputExclusive(2, (int)Control.CursorY /*INPUT_CURSOR_Y*/);
            SetInputExclusive(2, (int)Control.CursorScrollUp /*INPUT_CURSOR_SCROLL_UP*/);
            SetInputExclusive(2, (int)Control.CursorScrollDown /*INPUT_CURSOR_SCROLL_DOWN*/);
            Game.EnableControlThisFrame(2, Control.CursorScrollUp /*241 INPUT_CURSOR_SCROLL_UP*/);
            if (!IsUsingKeyboard(2 /*FRONTEND_CONTROL*/))
            {
                Game.EnableControlThisFrame(2, Control.FrontendPause /*199 INPUT_FRONTEND_PAUSE*/);
            }
            StopRecordingThisFrame();
        }
        int _lastCursorState = 0;

        public void SetCursorState(string cursor)
        {
            int hash = GetHashKey(cursor);

            if (hash == _lastCursorState) return;

            _lastCursorState = hash;

            BeginScaleformMovieMethod(browser.Handle, "SET_CURSOR_STATE");
            Tools.SetScaleformString(cursor);
            EndScaleformMovieMethod();
        }

        public bool IsHelpMessageBeingDisplayed(string helpMessage)
        {
            BeginTextCommandIsThisHelpMessageBeingDisplayed(helpMessage);
            return EndTextCommandIsThisHelpMessageBeingDisplayed(0);
        }

        public void DisplayHelpMessage(int message)
        {
            string messageToDisplay = string.Empty;
            switch (message)
            {
                case 1:
                    messageToDisplay = IsUsingKeyboard(2) ? "BROWTUT1_KM" : "BROWTUT1";
                    break;
            }

        }

        public void DrawVideo(string sParam0)//Position - 0x28464D
        {
            SetTvChannelPlaylist(0, sParam0, true);
            SetTvAudioFrontend(true);
            SetTvVolume(-5f);
            EnableMovieSubtitles(true);
            SetTvChannel(0);
            SetTextRenderId(GetDefaultScriptRendertargetRenderId());
            SetScriptGfxDrawOrder(4);
            SetScriptGfxDrawBehindPausemenu(true);
            DrawTvChannel(0.5f, 0.5f, 0.5f, 0.5f, 0f, 255, 255, 255, 255);
            browser.CallFunction("SUPRESS_HISTORY", true);
            StartAudioScene("INTERNET_BROWSER_VIDEO_SCENE");
            browser.CallFunction("SET_ANALOG_STICK_INPUT", 1, 0f, 0f);
            ShowingVideo = true;
        }

        public async void StartScriptedConversation(int id)
        {
            switch (id)
            {
                case 0:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_TASTY");
                    break;
                case 1:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_COLON");
                    break;
                case 2:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_CSEC");
                    break;
                case 3:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_DOG");
                    break;
                case 4:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_VOMIT");
                    break;
                case 5:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_PAIN");
                    break;
                case 6:
                    await DialogueControllerClient.RunDialogue("PACOWAU", new Dictionary<int, string> { [1] = "PACO" }, "PACOW_MELT");
                    break;
            }
        }
        public void SetWidescreen(bool isWidescreen)
        {
            browser.CallFunction("SET_WIDESCREEN", isWidescreen);
        }

        public void SetSkin(BrowserSkin skin)
        {
            browser.CallFunction("SET_BROWSER_SKIN", (int)skin);
        }

        public void InitaliseWebsite()
        {
            browser.CallFunction("INITIALISE_WEBSITE");
        }

        public async void IsDynamic()
        {
            _isDynamic = await browser.CallFunctionReturnValueBool("IS_SITE_DYNAMIC");
        }

        public async Task<int> GetCurrentRollover()
        {
            return await browser.CallFunctionReturnValueInt("GET_CURRENT_ROLLOVER");
        }

        public void GoToWebPage(int siteId, int pageId)
        {
            browser.CallFunction("GO_TO_WEBPAGE_ID", siteId, pageId);
        }
        public void GoToWebPage(string webSiteString)
        {
            BeginScaleformMovieMethod(browser.Handle, "GO_TO_WEBPAGE");
            BeginTextCommandScaleformString("STRING");
            AddTextComponentSubstringWebsite(webSiteString);
            EndTextCommandScaleformString();
            EndScaleformMovieMethod();
        }

        public async Task<int> GetSiteId()
        {
            return await browser.CallFunctionReturnValueInt("GET_SITE_ID");
        }

        public async Task<int> GetPageId()
        {
            return await browser.CallFunctionReturnValueInt("GET_PAGE_ID");
        }

        public async Task<string> GetCurrentWebside()
        {
            return await browser.CallFunctionReturnValueString("GET_CURRENT_WEBSITE");
        }

        public async Task<int> GetCurrentSelection()
        {
            return await browser.CallFunctionReturnValueInt("GET_CURRENT_SELECTION");
        }

        public void ProxyFunction(params object[] args)
        {
            browser.CallFunction("PROXY_FUNCTION", args);
        }

        public void SuppressHistory(bool suppressBackButton = false)
        {
            browser.CallFunction("SUPPRESS_HISTORY", suppressBackButton);
        }

        public void UpdateText(string text = "")
        {
            if (text.Length > 0)
                browser.CallFunction("UPDATE_TEXT", text);
            else
                browser.CallFunction("UPDATE_TEXT");
        }

        public void SetTitlebarText(string text, string hexColor = "6710886")
        {
            browser.CallFunction("SET_TITLEBAR_TEXT", text, hexColor);
        }

        public void SetTickerTape(float speed, string message)
        {
            browser.CallFunction("SET_TICKER_TAPE", speed, message);
        }

        public void SetCursorSpeedModifier(float speed)
        {
            browser.CallFunction("SET_CURSOR_SPEED_MODIFIER", speed);
        }

        public void SetJapanese(bool isJapanese)
        {
            browser.CallFunction("IS_JAPANESE", isJapanese);
        }

        /// <summary>
        /// Enables or disables multipler options
        /// EyeFinder (false): Enables news items and hides email options
        /// EyeFinder (true): Enables email options and hides news items
        /// </summary>
        /// <param name="isMultiplayer"></param>
        public void SetMultiplayer(bool isMultiplayer)
        {
            browser.CallFunction("SET_MULTIPLAYER", isMultiplayer);
        }

        public void SetPrices(int slotId, int price)
        {
            browser.CallFunction("SET_PRICES", slotId, price);
        }

        public void DisableVideo(bool disableVideo = true)
        {
            browser.CallFunction("DISABLE_VIDEO", disableVideo);
        }

        public void SetDataSlotEmpty()
        {
            browser.CallFunction("SET_DATA_SLOT_EMPTY");
        }

        public bool IsKeyboardOpen()
        {
            return GetGlobalActionscriptFlag(0) == 1;
        }

        public int GetNumberOfClickedLinks()
        {
            return GetGlobalActionscriptFlag(2);
        }

        public bool GetCursorSelection(ref int eventType, ref int context, ref int item, ref int unused)
        {
            return GetScaleformMovieCursorSelection(browser.Handle, ref eventType, ref context, ref item, ref unused);
        }
    }
}
