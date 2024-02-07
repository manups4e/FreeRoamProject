using FreeRoamProject.Client.FREEROAM.Properties.Managers;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.ApartmentsShared;
using FreeRoamProject.Shared.Core.ApartmentsShared.Enums;
using FreeRoamProject.Shared.Core.Doors;
using FreeRoamProject.Shared.Properties.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Properties
{
    public enum CusceneType
    {
        Buzzer,
        FrontDoor
    }

    public enum SceneElements
    {
        PedA,
        Door,
        Cam
    }

    public enum MainStage
    {
        STAGE_INIT = 0,
        STAGE_CHECK_FOR_IN_LOCATE = 1,
        STAGE_SETUP_FOR_MENU = 2,
        STAGE_USING_MENU = 3,
        STAGE_SETUP_FOR_USING_PROPERTY = 4,
        STAGE_ENTER_PROPERTY = 5,
        STAGE_LEAVE_ENTRANCE_AREA = 6,
        STAGE_BUZZED_intO_PROPERTY = 7,
        STAGE_WARP_TO_ENTRANCE_AREA_THEN_LEAVE = 8,
    }
    public enum PropEnterStage
    {
        STAGE_INIT = 0,
        STAGE_FULL = 1,
        STAGE_NO_VEHICLE = 2,
        STAGE_VEHICLE = 3,
        STAGE_FAKE_CUTSCENE_HEIST = 4,
    }
    enum GARAGE_PED_ENTER_CUTSCENE_STAGE
    {
        GARAGE_PED_ENTER_CUTSCENE_INIT = 0,
        GARAGE_PED_ENTER_CUTSCENE_TRIGGER_CUT,
        GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR,
        GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_INSIDE,
        GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR,
        GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_BEAT,
        GARAGE_PED_ENTER_CUTSCENE_COMPLETE
    }
    enum GARAGE_CAR_ENTER_CUTSCENE_STAGE
    {
        GARAGE_CAR_ENTER_CUTSCENE_INIT = 0,
        GARAGE_CAR_ENTER_CUTSCENE_LOAD_CUT,
        GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT,
        GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR,
        GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_INSIDE,
        GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR,
        GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_beat,
        GARAGE_CAR_ENTER_CUTSCENE_OFFICE_GARAGE_PAUSE,
        GARAGE_CAR_ENTER_CUTSCENE_OFFICE_GARAGE_WAIT_FADE,
        GARAGE_CAR_ENTER_CUTSCENE_COMPLETE
    }
    public enum FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE
    {
        FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT = 0,
        FAKE_GARAGE_CAR_ENTER_CUTSCENE_START,
        FAKE_GARAGE_CAR_ENTER_CUTSCENE_RUNNING,
        FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE
    }

    public enum WalkInStage
    {
        WIS_INIT = 0,
        WIS_WAIT_FOR_DOOR_CONTROL = 1,
        WIS_GIVE_SEQUENCE = 2,
        WIS_WAIT_FOR_SEQUENCE_END = 3,
        WIS_WAIT_FOR_LOAD = 4,
        WIS_CLEANUP = 5,
    }

    public enum ENTRY_CUTSCENE_TYPE
    {
        ENTRY_CUTSCENE_TYPE_BUZZER,
        ENTRY_CUTSCENE_TYPE_FRONT_DOOR
    }

    public enum ENTRY_CS_STAGE
    {
        ENTRY_CS_STAGE_INIT_DATA = 0,
        ENTRY_CS_STAGE_WAIT_FOR_MODELS = 1,
        ENTRY_CS_STAGE_TRIGGER_CUT = 2,
        ENTRY_CS_STAGE_RUN_CUT = 3,
        ENTRY_CS_STAGE_RUN_SECOND_CUT = 4,
        ENTRY_CS_STAGE_HANDLE_PLAYER_PED = 5
    }

    public enum ENTRY_CS_BS
    {
        ENTRY_CS_BS_GET_DATA = 0,
        ENTRY_CS_BS_STARTED_MP_CUTSCENE = 1,
        ENTRY_CS_BS_TOOK_AWAY_CONTROL = 2,
        ENTRY_CS_BS_SECOND_CUT = 3,
        ENTRY_CS_BS_APT_DOOR_MODEL_HIDE = 4,
        ENTRY_CS_BS_STARTED_FAKE_CUT = 5
    }
    public enum SYNC_SCENE_ELEMENTS
    {
        SYNC_SCENE_PED_A,
        SYNC_SCENE_DOOR,
        SYNC_SCENE_CAM,
        SYNC_SCENE_MAX_ELEMENTS
    }

    public enum LOCAL_BS
    {
        STARTED_FADE = 0,
        SKIP_ENTER_FADE = 1,
        CLEANUP_MP_PROPERTIES = 2,
        NO_FADE = 3,
        STARTED_CUTSCENE = 4,
        SETUP_MENU = 5,
        TAKEN_AWAY_CONTROL = 6,
        WARPED_IN_GARAGE = 7,
        WANTED_HELP_TEXT = 8,
        JUST_BOUGHT_PROPERTY = 10,
        INVALID_VEHICLE_HELP = 11,
        AWAITING_BUZZER_RESPONSE = 12,
        ENTER_NO_WARP = 13,
        ENTER_INGORE_PLAYER_OK = 14,
        USING_BUZZER_MENU = 15,
        DELETED_ENTERING_VEHICLE = 16,
        ENTER_FOOT_PUT_CAR_IN_GAR = 17,
        GARAGE_COMPLETELY_FULL = 18,
        BUZZER_REQUESTED_ANIM = 19,
        BUZZER_GIVE_GOTO_TASK = 20,
        BUZZER_GIVE_RING_TASK = 21,
        BUZZER_TRIGGERED_LOAD_SCENE = 22,
        PURCHASE_MENU_REQUEST_SF = 23,
        PURCHASE_MENU_SHOWING_WARN = 24,
        STOP_CUSTOM_MENU_CHECK = 25,
        FORCE_TERMINATED_intERNET = 26,
        PURCHASED_CUSTOM_APT = 27,
        ASSOCIATE_DENIED = 28,
    }

    public enum LOCAL_BS2
    {
        bCleanupOldPersonalVehicle = 0,
        bClearedHeistPanCutscene = 1,
        bKeepWantedFlag = 2,
        bResetOnCallForTransition = 3,
        bKeepScriptCameras = 4,
        bEnteringAnotherPlayerProperty = 5,
        bFadeOutWarpIntoGarage = 6,//Bug 1615873 (this doesn't work so commenting out)
        bCarEntryAborted = 7,
        bKeepPurchaseContext = 8,
        bWalkInTriggered = 9,
        PlayerInVehicleDoingHeistDelivery = 10,
        TriggeredAcceptWarning = 12,
        bRunPropertySelectMenu = 13,
        loadedGarageWalkInAnim = 14,
        AddedEnteringDecorator = 15,
        WarpAndLeavePointsAdded = 16,
        GroupAccessAllowed = 17,
        DoNotBuzzOthers = 18,
        KeepInvalidText = 19,
        PlayerWalkingOut = 20,
        SetEntryData = 21,
        DisabledRadar = 22,
        FakeGarageReverse = 23,
        VehBelongsToOtherGarage = 24,
        VehBelongsToStorage = 25,
        LockCarOnMenu = 26,
        RemoveStickyBombs = 27,
        ShapeTestRunning = 28,
        DisabledStore = 29,
    }

    internal static class PropertiesExteriorsManager
    {
        private static bool Initialized = false;
        public static List<PropertyData> Properties = [];
        public static PropertiesEnum CurrentPropertyID { get; set; }
        public static int iEntrancePlayerIsUsing { get; set; }
        private static readonly List<MarkerEx> EntranceMarkers = [];
        private static CutsceneData entryCutData = new();
        private static readonly MPPropertyNonAxis[] EntranceArea = [new(), new(), new()];
        private static int fakeBuilding6GarageObj;
        private static GARAGE_PED_ENTER_CUTSCENE_STAGE garagePedEnterCutStage;
        private static GARAGE_CAR_ENTER_CUTSCENE_STAGE garageCarEnterCutStage;
        private static int iApartmentDoorSoundStage = 0;
        private static int iApartmentBuzzerSoundStage = 0;
        private static Vehicle vehFakeGarageEnter = null;
        private static int vehCrateGarageEnter = 0;
        private static readonly int[] pedFakeGarageEnter = new int[9];
        private static MPFakeGarageDriveStruct fakeGarageDriveData = new();
        private static bool bLeavingEntranceArea = false;
        private static int iMenuInputDelay = 0;
        public static MainStage iLocalStage;
        private static readonly MPRealityWarpIn warpInControl = new();
        private static PropForSale forSaleDetails = new();
        private static Prop forSaleSign = null;
        private static Prop entryBlockingObj = null;
        private static Prop garageBlockingObj = null;
        private static Prop revolvingDoor = null;
        private static readonly int[] mapHoleProtectors = new int[3];
        private static readonly int[] createdBuzzers = new int[3];
        private static readonly int[] iDoorSetBS = new int[3];
        private static readonly SCRIPT_TIMER[] serverDoorStateTimeout = [new(), new(), new()];
        private static readonly int[] doorPlanks = new int[2];
        private static readonly bool[] bPropertyDoorGarage = new bool[3];
        private static Position tempPropOffset;
        private static WalkInStage iWalkInStage;
        private static int propertyCam0, propertyCam1;
        private static int camGarageCutscene0, camGarageCutscene1;
        private static readonly MpDoorDetails[] propertyDoors = [new MpDoorDetails(), new MpDoorDetails(), new MpDoorDetails()];
        private static SCRIPT_TIMER iWalkInTimer = new();
        private static SCRIPT_TIMER iCameraTimer = new();
        private static readonly SCRIPT_TIMER pauseMenuDelay = new();
        private static readonly SCRIPT_TIMER menuInputDelay = new();
        private static readonly int[] officeGarageDoors = new int[2];
        private static Prop officeGarageExternalDoor = null;
        private static MPCamOffset tempCamOffset = new();
        private static readonly List<Blip> PropertiesBlips = [];
        private static readonly int warpInWithDriverID = -1;
        private static int iLocalBS;
        private static int iLocalBS2;
        private static bool bLoadedElevatorSounds;
        private static readonly bool bIsAnotherPlayerPersonalVehicle;
        private static bool bCleanupFakeGarageEnter;
        private static readonly int NUM_VEHICLE_SEATS = 9;
        private static FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE fakeGarageCarEnterCutsceneStage;
        private static FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE iRunCarEntryFadeStage;
        private static int iGarageCutTimer;
        private static int iFadeDelayTimer;
        private static int iPedsInCar = 0;
        private static int iGarageCutsceneBitset;
        private static bool bStartedGarageDoorSound = false;
        private static readonly float fDoorSlideOpenSpeed = 3f;
        private static readonly float fDoorSlideCloseSpeed = 1.5f;
        private static int iGarageDoorSound;
        private static int iGarageSound;
        private static float fFakeVehicleOffset;
        private static bool bWarpVeh;
        private static int officeGarageDoorInterior;
        private static bool bGrabbedOfficeGarageDoorInterior = false;
        private static bool bInteriorPinned = false;

        private static readonly int GARAGE_CUT_SKIP_TIME_SHORT = 5000;
        private static readonly int GARAGE_CUT_SKIP_TIME_LONG = 10000;
        private static readonly int GARAGE_CUT_SKIP_TIME_BEAT = 0666;


        public static void Init()
        {
            CutsceneHelper.CleanupMPCutscene(true, true, true);
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }
        public static void Spawned(PlayerClient client)
        {
            InitCurrentBuildingDetails();
            if (CurrentPropertyID != (PropertiesEnum)(-1))
            {
                ProcessPreGame();
                EntranceArea[0] = PropertyFunctions.GetBuildingExtEntranceArea((BuildingsEnum)CurrentPropertyID, 0);
                EntranceArea[1] = PropertyFunctions.GetBuildingExtEntranceArea((BuildingsEnum)CurrentPropertyID, 1);
                Initialized = true;
            }
            HandleBlipsEntrance();
            CutsceneHelper.CleanupMPCutscene(true, true, true);
            TickController.TickGenerics.Add(CheckerLoop);
            TickController.TickGenerics.Add(MainLoop);
        }
        public static void onPlayerLeft(PlayerClient client)
        {

        }

        private static async Task CheckerLoop()
        {
            await BaseScript.Delay(250);
            if (!Initialized)
            {
                InitCurrentBuildingDetails();
                ProcessPreGame();
                EntranceArea[0] = PropertyFunctions.GetBuildingExtEntranceArea((BuildingsEnum)CurrentPropertyID, 0);
                EntranceArea[1] = PropertyFunctions.GetBuildingExtEntranceArea((BuildingsEnum)CurrentPropertyID, 1);
                Initialized = true;
            }
        }
        private static void RequestGarageDoorOpen()
        {
            RequestToUseDoor(2, true);
        }
        private static void RequestGarageDoorClose()
        {
            RequestToUseDoor(2, false);
        }

        private static bool SlideOfficeGarageDoors(bool bOpen, float fSpeed)
        {
            bool[] bComplete = new bool[2];
            if (!bStartedGarageDoorSound)
            {
                iGarageDoorSound = GetSoundId();
                if (bOpen)
                {
                    if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3 && bLoadedElevatorSounds)
                        PlaySoundFrontend(iGarageDoorSound, "Elevator_Doors_Opening_Loop", "DLC_IE_Garage_Elevator_Sounds", true);
                    else
                        PlaySoundFrontend(iGarageDoorSound, "Garage_Door_Open_Loop", "GTAO_Script_Doors_Sounds", true);
                }
                else
                {
                    if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3 && bLoadedElevatorSounds)
                        PlaySoundFrontend(iGarageDoorSound, "Elevator_Doors_Closing_Loop", "DLC_IE_Garage_Elevator_Sounds", true);
                    else
                        PlaySoundFrontend(iGarageDoorSound, "Garage_Door_Close_Loop", "GTAO_Script_Doors_Sounds", true);
                }
                bStartedGarageDoorSound = true;
            }

            Vector3 vTargetPosition;
            if (!bOpen)
            {
                if (vehFakeGarageEnter != null && vehFakeGarageEnter.Exists())
                {
                    if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3)
                    {
                        Vector3 pos1 = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(Properties[(int)CurrentPropertyID].BuildingID, 10, false);
                        Vector3 pos2 = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(Properties[(int)CurrentPropertyID].BuildingID, 11, false);
                        vTargetPosition = (pos1 + pos2) * 0.5f;
                    }
                    else
                    {
                        vTargetPosition = PropertyFunctions.GetOfficeGarageExternalDoorPosition();
                    }
                    vehFakeGarageEnter.Model.GetDimensions(out Vector3 min, out Vector3 max);

                    Vector3 front = GetOffsetFromEntityInWorldCoords(vehFakeGarageEnter.Handle, 0, (max.Y - min.Y) * 0.5f, 0);
                    Vector3 back = GetOffsetFromEntityInWorldCoords(vehFakeGarageEnter.Handle, 0, (max.Y - min.Y) * -0.5f, 0);
                    Vector3 vFrontToFinish = vTargetPosition - front;
                    Vector3 vBackToFinish = vTargetPosition - back;
                    if (Vmag(vFrontToFinish.X, vFrontToFinish.Y, vFrontToFinish.Z) < Vmag(vBackToFinish.X, vBackToFinish.Y, vBackToFinish.Z))
                        return false;
                    else
                    {
                        if (Vector3.Dot(vFrontToFinish, vBackToFinish) <= 0f)
                            return false;
                    }
                }
            }
            Vector3 vCurrentPosition;
            Vector3 vec;
            float fDist;
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (DoesEntityExist(officeGarageDoors[i]))
                    {
                        bComplete[i] = false;
                        if (!bOpen)
                            vTargetPosition = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(Properties[(int)CurrentPropertyID].BuildingID, 8 + i, false);
                        else
                            vTargetPosition = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(Properties[(int)CurrentPropertyID].BuildingID, 10 + i, false);
                        vCurrentPosition = GetEntityCoords(officeGarageDoors[i], true);
                        vec = vTargetPosition - vCurrentPosition;
                        fDist = 0;
                        fDist += Timestep() * fSpeed;
                        if (Vmag(vec.X, vec.Y, vec.Z) < fDist)
                        {
                            SetEntityCoordsNoOffset(officeGarageDoors[i], vTargetPosition.X, vTargetPosition.Y, vTargetPosition.Z, false, false, true);
                            bComplete[i] = true;
                        }
                        else
                        {
                            vec /= Vmag(vec.X, vec.Y, vec.Z);
                            vec *= fDist;
                            SetEntityCoordsNoOffset(officeGarageDoors[i], (vCurrentPosition + vec).X, (vCurrentPosition + vec).Y, (vCurrentPosition + vec).Z, false, false, true);
                        }
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (!bComplete[i])
                        return false;
                }
            }
            else
            {
                if (officeGarageExternalDoor != null && officeGarageExternalDoor.Exists())
                {
                    vTargetPosition = PropertyFunctions.GetOfficeGarageExternalDoorPosition();
                    if (bOpen)
                        vTargetPosition += new Vector3(0, 0, 4.35f);
                    vCurrentPosition = officeGarageExternalDoor.Position;
                    vec = vTargetPosition - vCurrentPosition;
                    fDist = 0;
                    fDist += Timestep() * fSpeed;
                    if (Vmag(vec.X, vec.Y, vec.Z) < fDist)
                    {
                        SetEntityCoordsNoOffset(officeGarageExternalDoor.Handle, vTargetPosition.X, vTargetPosition.Y, vTargetPosition.Z, false, false, false);
                    }
                    else
                    {
                        vec /= Vmag(vec.X, vec.Y, vec.Z);
                        vec *= fDist;
                        SetEntityCoordsNoOffset(officeGarageExternalDoor.Handle, (vCurrentPosition + vec).X, (vCurrentPosition + vec).Y, (vCurrentPosition + vec).Z, false, false, false);
                        return false;
                    }
                }
            }
            if (bStartedGarageDoorSound)
            {
                StopSound(iGarageDoorSound);
                bStartedGarageDoorSound = false;
                if (!bOpen)
                {
                    if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3 && bLoadedElevatorSounds)
                    {
                        iGarageSound = GetSoundId();
                        PlaySoundFrontend(iGarageSound, "Speech_Going_Up", "DLC_IE_Garage_Elevator_Sounds", true);
                    }
                }
            }
            return true;
        }
        private static bool IsGarageDoorOpen()
        {
            if (PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                return SlideOfficeGarageDoors(true, fDoorSlideOpenSpeed);
            if (propertyDoors[2].iDoorHash == 0)
                return true;

            return DoorSystemGetOpenRatio((uint)propertyDoors[2].iDoorHash) >= 0.65f
                || Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_5
                && DoorSystemGetOpenRatio((uint)propertyDoors[2].iDoorHash) >= 0.5f;
        }
        private static bool IsGarageDoorClosed()
        {
            if (PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                return SlideOfficeGarageDoors(false, fDoorSlideCloseSpeed);
            if (propertyDoors[2].iDoorHash == 0)
                return true;

            return DoorSystemGetOpenRatio((uint)propertyDoors[2].iDoorHash) <= 0.1f;
        }
        private static bool ProcessPreGame()
        {
            RegisterPropertyDoors();
            CreateOfficeGarageDoors();
            return true;
        }

        private static void HandleBlipsEntrance()
        {

            for (int i = 0; i < PlayerCache.Character.Properties.Count; i++)
            {
                Shared.Core.Character.OwnedProperty saved = PlayerCache.Character.Properties[i];
                BuildingsEnum building = PropertyFunctions.GetPropertyBuilding((PropertiesEnum)saved.ID);
                PropertyData data = Properties.FirstOrDefault(x => x.Index == (PropertiesEnum)saved.ID);
                Blip blip = World.CreateBlip(data.BlipLocation[0]);
                if (PropertyFunctions.IsPropertyOffice(data.Index))
                {
                    blip.Sprite = (BlipSprite)475;
                }
                else if (PropertyFunctions.IsPropertyClubhouse(data.Index))
                {
                    blip.Sprite = (BlipSprite)492;
                }
                else
                {
                    blip.Sprite = BlipSprite.Safehouse;
                }
                //todo: handle the blip and add the right name
                blip.IsShortRange = true;
                PropertiesBlips.Add(blip);
            }

            //DEBUG
            for (int i = 0; i < 85; i++)
            {
                Vector3 tempVector = GetMpPropertyBuildingWorldPoint((BuildingsEnum)i);
                if (tempVector != Vector3.Zero)
                {
                    Blip p = World.CreateBlip(tempVector);
                    p.Sprite = BlipSprite.ChatBubble;
                    BuildingRelated buildingProperties = new();
                    PropertyFunctions.GetBuildingProperties(ref buildingProperties, (BuildingsEnum)i);
                    p.Name = GetLabelText(Properties[(int)buildingProperties.PropertiesInBuilding[0]].Label);
                }
            }
            //DEBUG
        }

        private static void CreateOfficeGarageDoors()
        {
            PropertyData property = Properties[(int)CurrentPropertyID];
            if (property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1
                || property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2
                || property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3
                || property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4)
            {
                uint ModelName;
                Vector3 vPosition;
                Vector3 vRotation;
                for (int i = 0; i < 2; i++)
                {
                    vPosition = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(property.BuildingID, 8 + i, false);
                    vRotation = DriveIntoGarageHelper.GetOfficeGarageVectorAsOffset(property.BuildingID, 8 + i, true);

                    if (i == 0)
                        ModelName = Functions.HashUint("imp_prop_impexp_liftdoor_l");
                    else
                        ModelName = Functions.HashUint("imp_prop_impexp_liftdoor_r");
                    RequestLoadModel(ModelName);
                    officeGarageDoors[i] = CreateObjectNoOffset(ModelName, vPosition.X, vPosition.Y, vPosition.Z, false, false, true);
                    FreezeEntityPosition(officeGarageDoors[i], true);
                    SetEntityProofs(officeGarageDoors[i], true, true, true, true, true, true, true, true);
                    SetEntityInvincible(officeGarageDoors[i], true);
                    SetEntityDynamic(officeGarageDoors[i], false);
                    SetEntityRotation(officeGarageDoors[i], vRotation.X, vRotation.Y, vRotation.Z, 2, false);
                }

                if (property.BuildingID != BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3)
                {
                    vPosition = PropertyFunctions.GetOfficeGarageExternalDoorPosition();
                    vRotation = PropertyFunctions.GetOfficeGarageExternalDoorRotation();
                    ModelName = PropertyFunctions.GetOfficeGarageExternalDoorModel();

                    RequestLoadModel(ModelName);
                    officeGarageExternalDoor = new Prop(CreateObjectNoOffset(ModelName, vPosition.X, vPosition.Y, vPosition.Z, false, false, true))
                    {
                        IsPositionFrozen = true,
                        Rotation = vRotation,
                        IsInvincible = true
                    };
                    SetEntityDynamic(officeGarageExternalDoor.Handle, false);
                    SetEntityProofs(officeGarageExternalDoor.Handle, true, true, true, true, true, true, true, true);
                }
            }
        }
        private static void RegisterPropertyDoors()
        {
            bool bDoorGarage;
            for (int i = 0; i < 3; i++)
            {
                bDoorGarage = false;
                propertyDoors[i].vCoords = Vector3.Zero;
                bPropertyDoorGarage[i] = false;
                propertyDoors[i].iDoorHash = 0;
                if (PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[i], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, i))
                {
                    PropertyFunctions.SetupMpDoors(propertyDoors[i]);
                }
                bPropertyDoorGarage[i] = bDoorGarage;
                if (bPropertyDoorGarage[i])
                {
                    if (propertyDoors[i].iDoorHash != 0)
                    {
                        if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_1)
                            DoorSystemSetAutomaticRate((uint)propertyDoors[i].iDoorHash, 0.4f, false, false);
                        else
                            DoorSystemSetAutomaticRate((uint)propertyDoors[i].iDoorHash, 0.6f, false, false);
                        if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_5)
                            DoorSystemSetAutomaticDistance((uint)propertyDoors[i].iDoorHash, 15, false, false);
                    }
                }
            }
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_38)
            {
                CreateModelHide(2494.2651f, 1587.5674f, 31.7398f, 0.02f, Functions.HashUint("PROP_FNCLINK_02GATE3"), true);
                CreateModelHide(2484.0889f, 1566.9988f, 31.7453f, 0.02f, Functions.HashUint("PROP_FNCLINK_02GATE3"), true);
            }
        }

        public static void SetLocalStage(MainStage stage)
        {
            if (stage == MainStage.STAGE_SETUP_FOR_USING_PROPERTY)
                SetPlayerControl(PlayerId(), false, 0);
            if (stage == MainStage.STAGE_LEAVE_ENTRANCE_AREA)
                bLeavingEntranceArea = true;
            if (stage == MainStage.STAGE_USING_MENU)
                iMenuInputDelay = 0;
            //ClientMain.Logger.Debug("Setting stage to: " + stage);
            iLocalStage = stage;
        }

        private static void InitCurrentBuildingDetails()
        {
            BuildingRelated buildingProperties = new();
            float distance = 5000;
            Position pos = PlayerCache.MyClient.Position;
            BuildingsEnum building = 0;
            for (int i = 0; i < 85; i++)
            {
                Vector3 tempVector = GetMpPropertyBuildingWorldPoint((BuildingsEnum)i);
                if (pos.AreAlmostEqual(tempVector, 150f))
                {
                    float tmpd = pos.Distance(tempVector);
                    if (tmpd < distance)
                    {
                        distance = tmpd;
                        building = (BuildingsEnum)i;
                    }
                }
            }

            PropertyFunctions.GetBuildingProperties(ref buildingProperties, building);
            CurrentPropertyID = buildingProperties.PropertiesInBuilding[0];
            GetForSaleDetails(ref forSaleDetails, building);
        }

        public static async Task MainLoop()
        {
            Ped playerPed = PlayerCache.MyClient.Ped;
            PropertyData property = Properties[(int)CurrentPropertyID];
            if (iLocalStage < MainStage.STAGE_USING_MENU && PlayerCache.MyClient.Position.Distance(GetMpPropertyBuildingWorldPoint(Properties[(int)CurrentPropertyID].BuildingID)) > 135f)
            {
                ClearAll();
                return;
            }

            if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID) || PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
            {
                UpdateOfficeGarageDoorsRoom();
                UpdateOfficeGarageAudio();
            }

            //Notifications.DrawText(0.35f, 0.625f, $"CurrentPropertyID:{CurrentPropertyID}");
            //Notifications.DrawText(0.35f, 0.65f, $"iLocalStage:{iLocalStage}");
            //Notifications.DrawText(0.35f, 0.675f, $"iWalkInStage:{iWalkInStage}");
            //Notifications.DrawText(0.35f, 0.7f, $"entryCutData.iStage:{entryCutData.iStage}");
            //Notifications.DrawText(0.35f, 0.825f, $"warpInControl.iStage:{warpInControl.iStage}");

            switch (iLocalStage)
            {
                case MainStage.STAGE_INIT:
                    if (MAINTAIN_FOR_SALE_SIGN() && CREATE_ENTRY_AREAS_MAP_HOLE_PROTECTORS() && CREATE_LOCAL_BLOCKING_OBJECTS()
                        && CREATE_BUZZER_PROPS_IF_NEEDED() && CREATE_DOOR_PLANKS() && CREATE_REVOLVING_DOOR())
                    {
                        SetLocalStage(MainStage.STAGE_CHECK_FOR_IN_LOCATE);
                    }
                    break;
                case MainStage.STAGE_CHECK_FOR_IN_LOCATE:
                    // MOVE_OFFICE_GARAGE_BLIP
                    if (PlayerCache.MyClient.Status.Instance.Instanced)
                    {
                        // they do a cleanup in here because.. well.. this script checks for the outside.. if i'm inside.. what to check? ahaha
                        return;
                    }
                    MAINTAIN_FOR_SALE_SIGN();

                    // TODO: DISABLED AS IT'S NOT COMPLETE.. INTERIORS ARE NOT YET MADE SO IF YOU WALK IN..
                    // YOU'RE SOFTLOCKED AND YOU MUST RESTART YOUR RESOURCE
                    //LoopEntrances(); 

                    if (IsThereAPropertyToBuy())
                    {
                        //HandlePurchaseLocate();
                    }
                    break;
                case MainStage.STAGE_SETUP_FOR_USING_PROPERTY:
                    RemoveAllStickyBombsFromEntity(playerPed.Handle);
                    if (playerPed.IsInVehicle())
                    {
                        if (playerPed.CurrentVehicle.Exists())
                        {
                            if (NetworkHasControlOfEntity(playerPed.CurrentVehicle.Handle))
                            {
                                playerPed.CurrentVehicle.LockStatus = VehicleLockStatus.Locked;
                                RemoveAllStickyBombsFromEntity(playerPed.CurrentVehicle.Handle);
                            }
                            SetPedCanBeKnockedOffVehicle(playerPed.Handle, 1);
                            //SetLocalStage(MainStage.STAGE_ENTER_PROPERTY);
                        }
                    }
                    if (property.Entrance[iEntrancePlayerIsUsing].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
                    {
                        if (HandleWarpIntoGarage())
                        {
                            if (!playerPed.IsInjured)
                            {
                                if (playerPed.IsInVehicle())
                                {
                                    Vehicle veh = playerPed.CurrentVehicle;
                                    if (veh.Driver != playerPed)
                                    {
                                        if (PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
                                        {
                                            RenderScriptCams(false, false, 3000, true, false);
                                            SetGameplayCamRelativeHeading(0f);
                                            SetGameplayCamRelativePitch(0f, 0f);
                                            //i'm a passenger
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SetLocalStage(MainStage.STAGE_ENTER_PROPERTY);
                    }
                    break;
                case MainStage.STAGE_ENTER_PROPERTY:
                    //DISABLE_CELLPHONE_THIS_FRAME_ONLY
                    if (IsPlayerSwitchInProgress())
                    {
                        ResetToEntranceToPropertyStage();
                    }
                    WalkIntoPropertyCutscene(false);
                    WalkInCleanup(false);
                    DisplayRadar(true);
                    break;
            }
        }

        private static void UpdateOfficeGarageAudio()
        {
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3)
            {
                // if(!IS_CURRENT_MISSION_THIS_TUNER_ROBBERY_FINALE(TR_UNION_DEPOSITORY)){}
                if (!bLoadedElevatorSounds)
                {
                    if (PlayerIsInArcadiusUndergroundCarPark())
                    {
                        if (RequestScriptAudioBank("DLC_IMPORTEXPORT/GARAGE_ELEVATOR", false))
                        {
                            bLoadedElevatorSounds = true;
                        }
                    }
                }
                else
                {
                    if (!PlayerIsInArcadiusUndergroundCarPark() && (garageCarEnterCutStage <= GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT))
                    {
                        ReleaseNamedScriptAudioBank("DLC_IMPORTEXPORT/GARAGE_ELEVATOR");
                        bLoadedElevatorSounds = false;
                    }
                }
            }
        }

        private static void UpdateOfficeGarageDoorsRoom()
        {
            if (!bGrabbedOfficeGarageDoorInterior)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (DoesEntityExist(officeGarageDoors[i]))
                    {
                        string sInteriorType = "";
                        switch (CurrentPropertyID)
                        {
                            case PropertiesEnum.PROPERTY_OFFICE_1:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3:
                                sInteriorType = "hei_sm_13_carpark";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3:
                                sInteriorType = "hei_sm_15_carpark";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_3:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3:
                                sInteriorType = "hei_dt1_02_carpark";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_4:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3:
                                sInteriorType = "hei_dt1_11_carpark";
                                break;
                        }
                        if (!string.IsNullOrWhiteSpace(sInteriorType))
                        {
                            Vector3 pos = GetEntityCoords(officeGarageDoors[i], false);
                            officeGarageDoorInterior = GetInteriorAtCoordsWithType(pos.X, pos.Y, pos.Z, sInteriorType);
                            if (IsValidInterior(officeGarageDoorInterior))
                            {
                                bGrabbedOfficeGarageDoorInterior = true;
                                PinInteriorInMemory(officeGarageDoorInterior);
                                bInteriorPinned = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (IsValidInterior(officeGarageDoorInterior))
                {
                    if (IsInteriorReady(officeGarageDoorInterior))
                    {
                        string sRoomName = "";
                        switch (CurrentPropertyID)
                        {
                            case PropertiesEnum.PROPERTY_OFFICE_1:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3:
                                sRoomName = "GtaMloRoom001";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3:
                                sRoomName = "GtaMloRoom002";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_3:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3:
                                sRoomName = "GtaMloRoom018";
                                break;
                            case PropertiesEnum.PROPERTY_OFFICE_4:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2:
                            case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3:
                                sRoomName = "GtaMloRoom001";
                                break;
                        }
                        if (!string.IsNullOrWhiteSpace(sRoomName))
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (DoesEntityExist(officeGarageDoors[i]))
                                {
                                    ForceRoomForEntity(officeGarageDoors[i], officeGarageDoorInterior, (uint)GetHashKey(sRoomName));
                                }
                            }
                        }
                    }
                }
                else
                {
                    bGrabbedOfficeGarageDoorInterior = false;
                    bInteriorPinned = false;
                }
            }
        }

        private static void SetPropertyEnterStage(PropEnterStage stage)
        {
            if (stage == PropEnterStage.STAGE_FULL)
            {
                SetPlayerControl(PlayerId(), false, 65536 | 512);
            }
            ClientMain.Logger.Debug("Setting PropertyEnterStage to: " + stage);
            warpInControl.iStage = stage;
        }

        private static bool ShouldWarpIntoGarageAbort(int vehID)
        {
            // if(!IS_VEHICLE_SUITABLE_FOR_PROPERTY()) return true;
            return false;
        }
        private static void ForceUndermapForEntry(int val)
        {
            int thisVehicle;
            int pedTemp;
            float fDistance = 200;
            if (VehicleChecker.IsInVehicle)
            {
                if (VehicleChecker.CurrentVehicle.IsDriveable)
                {
                    if (NetworkHasControlOfEntity(VehicleChecker.CurrentVehicle.Handle))
                    {
                        VehicleChecker.CurrentVehicle.IsPositionFrozen = true;
                    }
                }
            }
        }
        private static void ResetGarageCarEnterCutscene(int iReason, bool bClearTasks = false, bool bTurnOffRenderCams = true)
        {
            ResetGarageCutscene(bClearTasks, bTurnOffRenderCams);
            DeleteClonedEntitiesAndClearRequests();
            garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_INIT;
        }
        private static void ResetGaragePedEnterCutscene(bool bClearTasks = false, bool bTurnOffRenderCams = true)
        {
            RequestGarageDoorClose();
            ResetGarageCutscene(bClearTasks, bTurnOffRenderCams);
            ResetToEntranceToPropertyStage();
            garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_INIT;
        }
        private static void ResetGarageCutscene(bool bClearTasks = false, bool bTurnOffRenderScriptCams = true)
        {
            if (bTurnOffRenderScriptCams)
            {
                RenderScriptCams(false, false, 3000, true, false);
            }
            RemoveAnimDict("anim@apt_trans@garage");
            if (DoesCamExist(camGarageCutscene0))
                DestroyCam(camGarageCutscene0, false);
            if (DoesCamExist(camGarageCutscene1))
                DestroyCam(camGarageCutscene1, false);
            if (IsAudioSceneActive("DLC_IE_Garage_Elevator_Enter_Scene"))
                StopAudioScene("DLC_IE_Garage_Elevator_Enter_Scene");
            if (IsAudioSceneActive("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE"))
                StopAudioScene("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE");
            if (IsAudioSceneActive("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene"))
                StopAudioScene("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene");
            CutsceneHelper.CleanupMPCutscene(bReturnPlayerControl: true);
            RequestGarageDoorClose();
            ResetToEntranceToPropertyStage();
            SetPlayerControl(PlayerId(), true, 0);
        }
        private static void DeleteClonedEntitiesAndClearRequests()
        {
            if (DoesEntityExist(vehCrateGarageEnter))
            {
                SetModelAsNoLongerNeeded((uint)GetEntityModel(vehCrateGarageEnter));
                DeleteObject(ref vehCrateGarageEnter);
            }
            if (vehFakeGarageEnter != null && vehFakeGarageEnter.Exists())
            {
                SetModelAsNoLongerNeeded((uint)GetEntityModel(vehFakeGarageEnter.Handle));
                vehFakeGarageEnter.Delete();
            }
            for (int i = 0; i < pedFakeGarageEnter.Length; i++)
            {
                if (DoesEntityExist(pedFakeGarageEnter[i]))
                {
                    DeletePed(ref pedFakeGarageEnter[i]);
                }
            }
        }

        private static void ResetFakeGarageCarEnterCutscene(bool bClearTasks = false, bool bTurnOffRenderScriptCams = true)
        {
            ResetGarageCutscene(bClearTasks, bTurnOffRenderScriptCams);
            iPedsInCar = 0;
            iFadeDelayTimer = 0;
            fakeGarageCarEnterCutsceneStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT;
        }

        private static void PlayEnteringGarageSound()
        {
            int iSound = GetSoundId();
            if (PropertyFunctions.GetPropertySizeType(CurrentPropertyID) != PropertySizeType.PROP_SIZE_TYPE_LARGE_APT
                && !PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID) && !PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
            {
                PlaySoundFrontend(iSound, "GARAGE_DOOR_SCRIPTED_OPEN", "", true);
                SetVariableOnSound(iSound, "hold", 2.25f);
            }
        }

        private static bool DoGaragePedEnterCutscene(bool resetCoords)
        {
            STRUCT_WalkInGarage scene = new();
            if (!WalkIntoGarageHelper.Get_WalkInGarage(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID), ref scene))
            {
                return true;
            }
            if (CurrentPropertyID == PropertiesEnum.PROPERTY_LOW_APT_7)
                DisableOcclusionThisFrame();
            if (CurrentPropertyID == PropertiesEnum.PROPERTY_HIGH_APT_14
                || CurrentPropertyID == PropertiesEnum.PROPERTY_HIGH_APT_15)
            {
                createFakeBuilding6GarageObject();
            }
            if (DoGaragePedEnterThisCutscene(resetCoords, scene))
            {
                if (DoesEntityExist(fakeBuilding6GarageObj))
                {
                    DeleteObject(ref fakeBuilding6GarageObj);
                }
                return true;
            }
            return false;
        }

        private static bool DoGaragePedEnterThisCutscene(bool bResetCoords, STRUCT_WalkInGarage scene)
        {
            Ped thePed = PlayerCache.MyPed;
            thePed = new(pedFakeGarageEnter[0]);
            //ClientMain.Logger.Debug("garagePedEnterCutStage: " + garagePedEnterCutStage);
            switch (garagePedEnterCutStage)
            {
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_INIT:
                    SetPlayerControl(PlayerId(), false, 0);
                    iGarageCutTimer = GetGameTimer();
                    Position pos = PlayerCache.MyClient.Position + new Position(0, 0, -10f);
                    if (PlayerCache.Character.Skin.Sex != "Female")
                        pedFakeGarageEnter[0] = CreatePed(4, PlayerCache.Character.Skin.Model, pos.X, pos.Y, pos.Z, PlayerCache.MyPed.Heading, false, false);
                    else
                        pedFakeGarageEnter[0] = CreatePed(5, PlayerCache.Character.Skin.Model, pos.X, pos.Y, pos.Z, PlayerCache.MyPed.Heading, false, false);
                    ClonePedToTarget(PlayerPedId(), pedFakeGarageEnter[0]);
                    //UPDATE_MC_EMBLEM(GET_PLAYER_INDEX(), pedFakeGarageEnter[0])
                    FreezeEntityPosition(pedFakeGarageEnter[0], true);
                    SetEntityProofs(pedFakeGarageEnter[0], true, true, true, true, true, true, true, true);
                    fakeGarageCarEnterCutsceneStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START;
                    iGarageCutTimer = GetGameTimer();
                    garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_TRIGGER_CUT;
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_TRIGGER_CUT:
                    if (GetGameTimer() - iGarageCutTimer < 5000)
                    {
                        if (DoesEntityExist(pedFakeGarageEnter[0]))
                        {
                            if (!IsPedInjured(pedFakeGarageEnter[0]))
                            {
                                if (!HaveAllStreamingRequestsCompleted(pedFakeGarageEnter[0]))
                                    return false;
                                if (!HasPedHeadBlendFinished(pedFakeGarageEnter[0]))
                                    return false;
                            }
                        }
                    }
                    if (!IsPedInAnyVehicle(PlayerPedId(), true))
                    {
                        ClearPedTasksImmediately(PlayerPedId());
                        SetPlayerControl(PlayerId(), false, 0);
                        Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.TAKEN_AWAY_CONTROL);
                        iGarageCutsceneBitset = 0;
                        iGarageCutTimer = GetGameTimer();
                        thePed.Position = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos;
                        thePed.Heading = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot;
                        thePed.IsPositionFrozen = false;
                        if (bResetCoords)
                        {
                            PlayerCache.MyPed.Position = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos;
                            PlayerCache.MyPed.Heading = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot;
                        }
                        if (!NetworkIsInMpCutscene())
                        {
                            SetLocalPlayerVisibleInCutscene(false, true);
                            CutsceneHelper.StartMPCutscene(true);
                            Functions.FadeEntity(PlayerCache.MyPed, false, true, true);
                        }
                        Functions.SetBit(ref entryCutData.iBS, (int)ENTRY_CS_BS.ENTRY_CS_BS_STARTED_MP_CUTSCENE);
                        if (DoesEntityExist(entryCutData.objIDs[0]))
                            DeleteObject(ref entryCutData.objIDs[0]);
                        if (DoesEntityExist(entryCutData.playerClone))
                            DeletePed(ref entryCutData.playerClone);
                        StartAudioScene("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE");
                        CameraHelper.ExecuteCut(scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start], ref camGarageCutscene0);
                        garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR;
                        if (PropertyFunctions.GetPropertySizeType(Properties[(int)CurrentPropertyID].Index) != PropertySizeType.PROP_SIZE_TYPE_LARGE_APT
                            && Properties[(int)CurrentPropertyID].Index != PropertiesEnum.PROPERTY_LOW_APT_7)
                        {
                            DoScreenFadeOut(500);
                            garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE;
                        }
                    }
                    else
                    {
                        if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 1)
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 0)
                            {
                                TaskLeaveAnyVehicle(PlayerPedId(), 0, 0);
                            }
                        }
                    }
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_SHORT)
                    {
                        garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE;
                    }
                    if (!IsPedInAnyVehicle(PlayerPedId(), true))
                    {
                        RequestGarageDoorOpen();
                        // IS_GARAGE_DOOR_UNLOCKED returns true whatsoever.. is forced true
                        if (IsGarageDoorOpen())
                        {
                            if (Vector3.Distance(thePed.Position, scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos) < 30f)
                                TaskGoStraightToCoord(thePed.Handle, scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos.X,
                                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos.Y,
                                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos.Z, 1.0f, -1, 40000f, 0.5f);
                            iGarageCutTimer = GetGameTimer();
                            garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_INSIDE;
                        }
                        else
                        {
                            if (!Functions.IsTaskOngoing(thePed.Handle, "SCRIPT_TASK_GO_STRAIGHT_TO_COORD"))
                            {
                                Vector3 vPos0 = scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0;
                                Vector3 vPos1 = scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1;
                                if (vPos0.Z > vPos1.Z)
                                    vPos0.Z = vPos1.Z;
                                else
                                    vPos1.Z = vPos0.Z;
                                if (thePed.IsInAngledArea(vPos0, vPos1 + new Vector3(0, 0, scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight), scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth))
                                {
                                    TaskGoStraightToCoord(thePed.Handle, scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos.X,
                                        scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos.Y,
                                        scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos.Z, 1.0f, -1, scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot, 0.5f);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 1)
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 0)
                            {
                                TaskLeaveAnyVehicle(PlayerPedId(), 0, 0);
                            }
                        }
                    }
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_INSIDE:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_LONG)
                    {
                        garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE;
                    }
                    if (!Functions.IsBitSet(iGarageCutsceneBitset, 0))//GARAGE_CUT_BS_intERPOLATE_STARTED
                    {
                        if (GetGameTimer() - iGarageCutTimer > 500 || Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_5)
                        {
                            CameraHelper.ExecutePan(ref scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent], ref camGarageCutscene0, ref camGarageCutscene1);
                            Functions.SetBit(ref iGarageCutsceneBitset, 0);
                        }
                    }
                    if (!IsPedInAnyVehicle(PlayerPedId(), true))
                    {
                        if (Vector3.DistanceSquared(thePed.Position, scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos) < 64f)
                        {
                            TaskGoStraightToCoord(thePed.Handle, scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos.X,
                                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos.Y,
                                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos.Z, 1.0f, -1, 40000f, 0.5f);
                            iGarageCutTimer = GetGameTimer();
                            garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR;
                        }
                    }
                    else
                    {
                        if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 1)
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 0)
                            {
                                TaskLeaveAnyVehicle(PlayerPedId(), 0, 0);
                            }
                        }
                    }
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_LONG)
                    {
                        garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE;
                    }
                    if (!IsPedInAnyVehicle(PlayerPedId(), true))
                    {
                        Vector3 vPos0 = scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0;
                        Vector3 vPos1 = scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1;
                        if (vPos0.Z > vPos1.Z)
                            vPos0.Z = vPos1.Z;
                        else
                            vPos1.Z = vPos0.Z;
                        if (thePed.IsInAngledArea(vPos0, vPos1 + new Vector3(0, 0, scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight), scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth))
                        {

                        }
                        else
                        {
                            RequestGarageDoorClose();
                            if (Vector3.DistanceSquared(thePed.Position, scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos) < 64f)
                            {
                                iGarageCutTimer = GetGameTimer();
                                garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_BEAT;
                            }
                        }
                    }
                    else
                    {
                        if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 1)
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_LEAVE_ANY_VEHICLE")) != 0)
                            {
                                TaskLeaveAnyVehicle(PlayerPedId(), 0, 0);
                            }
                        }
                    }
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_BEAT:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_BEAT)
                        garagePedEnterCutStage = GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE;
                    break;
                case GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_COMPLETE:
                    if (!IsScreenFadingOut())
                    {
                        if (IsScreenFadedOut())
                        {
                            RenderScriptCams(false, false, 3000, true, false);
                            if (DoesCamExist(camGarageCutscene0))
                                DestroyCam(camGarageCutscene0, false);
                        }
                        if (IsAudioSceneActive("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE"))
                            StopAudioScene("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE");
                        return true;
                    }
                    break;

            }
            return false;
        }

        private static bool HandleWarpIntoGarage()
        {
            Ped playerPed = PlayerCache.MyPed;
            bool bPersonalVehicle = false;
            bool bAnotherPlayerPersonalVehicle = false;
            int iSlotToUse, iDisplaySlotToUse;
            bool bOtherGarage = false;
            bool bStorage = false;
            uint vehicleModel;
            tempCamOffset = new();
            int iDuration = 0;
            int iVehicleSaveOffset;
            int vehFadeOut;

            // we need to get the right parking slot for the apartment and the vehicle so that it can be parked the right position..
            // even tho.. we don't really need it here.. as in the end.. we store the vehicle and that's all.. if the vehicle knows its slot we are ok with that.

            ForceUndermapForEntry(2);

            switch (warpInControl.iStage)
            {
                case PropEnterStage.STAGE_INIT:
                    if (warpInWithDriverID != -1)
                    {
                        SetPropertyEnterStage(PropEnterStage.STAGE_VEHICLE);
                    }
                    else
                    {
                        if (playerPed.IsInVehicle())
                        {
                            warpInControl.vehID = playerPed.CurrentVehicle.Handle;
                            vehicleModel = (uint)playerPed.CurrentVehicle.Model.Hash;
                            // here the game checks if the vehicle has decor "Player_Vehicle"
                            // and if the decor_int is == NETWORK_HASH_FROM_PLAYER_HANDLE(PLAYER_ID())
                            // if TRUE the vehicle is mine, if false the vehicle is someone else's
                            if (ShouldWarpIntoGarageAbort(warpInControl.vehID))
                            {
                                ResetToEntranceToPropertyStage();
                                if (garageCarEnterCutStage != GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_INIT)
                                    ResetGarageCarEnterCutscene(6);
                                if (garagePedEnterCutStage != GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_INIT)
                                    ResetGaragePedEnterCutscene();
                                return false;
                            }
                            if (playerPed != playerPed.CurrentVehicle.Driver)
                            {
                                SetPropertyEnterStage(PropEnterStage.STAGE_NO_VEHICLE);
                            }
                            else
                            {
                                if (!Functions.HasNetTimerStarted(iWalkInTimer))
                                {
                                    Functions.StartNetTimer(ref iWalkInTimer, true);
                                }
                                else
                                {
                                    if (true) // globalPropertyEntryData.ownerID != -1.. mean if the player inside garage / property is WWWWWWWWWWWWWWWWWWWWvalid.. we always enter with vehicle for now
                                    {
                                        if (Functions.HasNetTimerExpired(ref iWalkInTimer, 10000, true))
                                        {
                                            ResetToEntranceToPropertyStage();
                                            if (garageCarEnterCutStage != GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_INIT)
                                                ResetGarageCarEnterCutscene(6);
                                            if (garagePedEnterCutStage != GARAGE_PED_ENTER_CUTSCENE_STAGE.GARAGE_PED_ENTER_CUTSCENE_INIT)
                                                ResetGaragePedEnterCutscene();
                                            return false;
                                        }
                                        SetPropertyEnterStage(PropEnterStage.STAGE_VEHICLE);
                                        break;
                                    }
                                    else
                                    {
                                        SetPropertyEnterStage(PropEnterStage.STAGE_NO_VEHICLE);
                                    }
                                }
                                if (IsAnyoneTryingToEnterCurrentVehicle())
                                {
                                    break;
                                }
                                if (bIsAnotherPlayerPersonalVehicle)
                                {
                                    SetPropertyEnterStage(PropEnterStage.STAGE_NO_VEHICLE);
                                }
                                else if (bPersonalVehicle)
                                {
                                    // need to check if current property has free space for the vehicle..
                                    //TODO: line 8727
                                    SetPropertyEnterStage(PropEnterStage.STAGE_VEHICLE);
                                }
                            }
                        }
                        else
                        {
                            if ((PropertyFunctions.GetPropertySizeType(Properties[(int)CurrentPropertyID].Index) != PropertySizeType.PROP_SIZE_TYPE_LARGE_APT
                                && Properties[(int)CurrentPropertyID].Index != PropertiesEnum.PROPERTY_LOW_APT_7)
                                || PropertyFunctions.IsPropertyStiltApartment(CurrentPropertyID))
                            {
                                if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_FADE))
                                {
                                    DoScreenFadeOut(500);
                                    Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.STARTED_FADE);
                                }
                            }
                            if (!Functions.IsPlayerGettingInOrOutOfVehicle(PlayerId())
                                && !Functions.IsLocalPlayerEnteringOrExitingAVehicle())
                            {
                                SetPropertyEnterStage(PropEnterStage.STAGE_NO_VEHICLE);
                            }
                        }
                    }
                    break;
                case PropEnterStage.STAGE_FULL:
                    if (PlayerCache.Character.Properties.FirstOrDefault(x => x.ID == (int)CurrentPropertyID).Garage.VehicleInSlot.Any(y => y == 0))
                    {
                        if (!playerPed.IsInVehicle())
                        {
                            ResetToEntranceToPropertyStage();
                            return false;
                        }
                        else
                        {
                            vehFadeOut = playerPed.CurrentVehicle.Handle;
                            if (!IsVehicleDriveable(vehFadeOut, false) || Functions.IsVehicleAttachedToAnyCargobob(new Vehicle(vehFadeOut)))
                            {
                                ResetToEntranceToPropertyStage();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Main.Warning.ShowWarningWithButtons(GetLabelText("CUST_GAR_FULL"), GetLabelText("CUST_GAR_REP"), "",
                        [
                            new InstructionalButton(Control.FrontendCancel, GetLabelText("IB_CANCEL")),
                            new InstructionalButton(Control.FrontendAccept, GetLabelText("IB_OK"))
                        ]);
                        Main.Warning.OnButtonPressed += (button) =>
                        {
                            if (button.Text == GetLabelText("IB_OK"))
                            {
                            }
                            else if (button.Text == GetLabelText("IB_CANCEL"))
                            {
                            }
                        };
                    }
                    break;
                case PropEnterStage.STAGE_NO_VEHICLE:
                    if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_FADE))
                    {
                        if (DoGaragePedEnterCutscene(false))
                        {
                            DoScreenFadeOut(500);
                            PlayEnteringGarageSound();
                            Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.STARTED_FADE);
                        }
                    }
                    else
                    {
                        if (Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_FADE) || IsScreenFadedOut() || Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE))
                        {
                            if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE))
                            {
                                Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE);
                            }
                            else
                            {
                                if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.WARPED_IN_GARAGE))
                                {
                                    Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.WARPED_IN_GARAGE);
                                }
                                else
                                {
                                    Debug.WriteLine("returned");
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (!IsScreenFadingOut() && !IsScreenFadedOut() && !IsScreenFadingIn())
                            {
                                if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.NO_FADE))
                                {
                                    if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.SKIP_ENTER_FADE))
                                    {
                                        DoScreenFadeOut(0);
                                    }
                                    else
                                    {
                                        DoScreenFadeOut(500);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case PropEnterStage.STAGE_VEHICLE:
                    if (playerPed.IsInVehicle())
                    {
                        vehFadeOut = playerPed.CurrentVehicle.Handle;
                        if (playerPed.CurrentVehicle.Driver == playerPed)
                        {
                            // they apply some decorator? bah..
                            if (playerPed.CurrentVehicle.Model.Hash == Functions.HashInt("DELUXO")
                                || playerPed.CurrentVehicle.Model.Hash == Functions.HashInt("OPPRESSOR2"))
                            {
                                SetDisableHoverModeFlight(vehFadeOut, true);
                                SetSpecialFlightModeTargetRatio(vehFadeOut, 0);
                            }
                        }
                    }
                    if (fakeGarageCarEnterCutsceneStage > FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START)
                    {
                        HideHudAndRadarThisFrame();
                    }
                    if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_FADE))
                    {
                        ClearAreaOfProjectiles(playerPed.Position.X, playerPed.Position.Y, playerPed.Position.Z, 5f, 0);
                        if (DoesEntityExist(warpInControl.vehID))
                        {
                            if (NetworkHasControlOfEntity(warpInControl.vehID))
                            {
                                SetVehicleDoorsLocked(warpInControl.vehID, 2);
                            }
                        }
                        if (DoGarageCarEnterCutscene(false))
                        {
                            DoScreenFadeOut(500);
                            PlayEnteringGarageSound();
                            if (DoesEntityExist(warpInControl.vehID))
                            {
                                if (NetworkHasControlOfEntity(warpInControl.vehID))
                                {
                                    SetVehicleDoorsLocked(warpInControl.vehID, 2);
                                }
                            }
                            Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.STARTED_FADE);
                        }
                    }
                    else
                    {
                        if (Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_FADE) || IsScreenFadedOut() || Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE))
                        {
                            if (IsScreenFadedOut())
                            {
                                if (playerPed.IsInVehicle())
                                {
                                    vehFadeOut = playerPed.CurrentVehicle.Handle;
                                    if (playerPed.CurrentVehicle.Driver == playerPed)
                                    {
                                        Functions.FadeEntity(playerPed.CurrentVehicle, false, true, true);
                                        playerPed.CurrentVehicle.IsSirenActive = false;
                                    }
                                }
                                else
                                {
                                    Functions.FadeEntity(playerPed, false, true, true);
                                }
                            }
                            if (!Functions.IsBitSet(iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE))
                            {
                                Functions.SetBit(ref iLocalBS, (int)LOCAL_BS.STARTED_CUTSCENE);
                            }
                        }
                    }
                    break;
            }
            return true;
        }

        private static bool IsAnyoneTryingToEnterCurrentVehicle()
        {

            Ped playerPed = PlayerCache.MyPed;
            if (playerPed.IsInVehicle())
            {
                if (playerPed.CurrentVehicle.IsDriveable)
                {
                    List<Player> players = Functions.GetPlayersInArea(playerPed.Position, 125f);
                    foreach (Player p in players)
                    {
                        if (GetVehiclePedIsEntering(p.Character.Handle) == playerPed.CurrentVehicle.Handle)
                            return true;
                    }
                }
            }
            return false;
        }

        private static void CleanupThisPropertyCam(int cam)
        {
            if (DoesCamExist(cam))
            {
                RenderScriptCams(false, false, 3000, true, false);
                if (IsCamActive(cam))
                    SetCamActive(cam, false);
                DestroyCam(cam, false);
            }
        }
        #region Walk into property
        private static void WalkInCleanup(bool setPlayerControlOn)
        {
            if (setPlayerControlOn)
            {
                SetPlayerControl(PlayerId(), true, 0);
            }
            CleanupThisPropertyCam(propertyCam1);
            CleanupThisPropertyCam(propertyCam0);
        }

        private static void ResetToEntranceToPropertyStage()
        {
            CurrentPropertyID = Properties[(int)CurrentPropertyID].Building.PropertiesInBuilding[0];
            CleanupEntryCS();
            if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
            {
                if (IsAudioSceneActive("EXEC1_Enter_Office_From_Ground_Scene"))
                    StopAudioScene("EXEC1_Enter_Office_From_Ground_Scene");
                if (IsAudioSceneActive("EXEC1_Enter_Office_From_Roof_Scene"))
                    StopAudioScene("EXEC1_Enter_Office_From_Roof_Scene");
            }

            if (IsScreenFadedOut() || IsScreenFadingOut())
                DoScreenFadeIn(500);
            SetLocalStage(MainStage.STAGE_CHECK_FOR_IN_LOCATE);
            if (DoesCamExist(propertyCam0))
                DestroyCam(propertyCam0, false);
            if (DoesCamExist(propertyCam1))
            {
                DestroyCam(propertyCam1, false);
                RenderScriptCams(false, false, 3000, true, false);
            }
        }
        private static void CleanupEntryCS()
        {
            if (entryCutData.iSyncedSceneID >= 0)
            {
                if (!IsPedInjured(entryCutData.playerClone))
                    ClearPedTasks(entryCutData.playerClone);
                entryCutData.iSyncedSceneID = -1;
            }
            if (DoesEntityExist(entryCutData.playerClone))
                DeletePed(ref entryCutData.playerClone);
            entryCutData.timer.bInitialisedTimer = false;
            if (DoesCamExist(entryCutData.cameras[0]))
                DestroyCam(entryCutData.cameras[0], false);
            RemoveAnimDict(entryCutData.animDictionary);
            if (DoesEntityExist(entryCutData.objIDs[0]))
                DeleteObject(ref entryCutData.objIDs[0]);
            if (DoesEntityExist(entryCutData.playerClone))
                DeletePed(ref entryCutData.playerClone);
            if (entryCutData.iSoundID >= 0)
                StopSound(entryCutData.iSoundID);

            entryCutData = new();
        }
        private static bool WalkIntoPropertyCutscene(bool resetCoords)
        {
            STRUCT_WalkIn scene = new();
            if (!WalkIntoPropertyHelper.Get_WalkIn(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID), ref scene, iEntrancePlayerIsUsing))
            {
                iWalkInStage = WalkInStage.WIS_INIT;
                return true;
            }
            if (WalkIntoThisProperty(resetCoords, ref scene))
                return true;
            return false;
        }

        private static bool WalkIntoThisProperty(bool resetCoords, ref STRUCT_WalkIn scene)
        {
            PropertyData property = Properties[(int)CurrentPropertyID];
            if (IsPlayerSwitchInProgress())
            {
                iWalkInStage = WalkInStage.WIS_CLEANUP;
            }

            if (iWalkInStage == WalkInStage.WIS_INIT
                || iWalkInStage == WalkInStage.WIS_WAIT_FOR_DOOR_CONTROL
                || iWalkInStage == WalkInStage.WIS_GIVE_SEQUENCE
                || iWalkInStage == WalkInStage.WIS_WAIT_FOR_SEQUENCE_END)
            {
                DisableRockstarEditorCameraChanges(); //REPLAY_DISABLE_CAMERA_MOVEMENT_THIS_FRAME
            }

            switch (iWalkInStage)
            {
                case WalkInStage.WIS_INIT:
                    if (RunEntryCuscene(ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR))
                        iWalkInStage = WalkInStage.WIS_WAIT_FOR_LOAD;
                    break;
                case WalkInStage.WIS_WAIT_FOR_DOOR_CONTROL:
                    RequestToUseDoor(0);
                    RequestToUseDoor(1);
                    if (RequestToUseDoor(0) && RequestToUseDoor(1))
                        iWalkInStage = WalkInStage.WIS_GIVE_SEQUENCE;
                    else if (PropertyFunctions.GetPropertySizeType(CurrentPropertyID) < PropertySizeType.PROP_SIZE_TYPE_SMALL_APT)
                        iWalkInStage = WalkInStage.WIS_GIVE_SEQUENCE;
                    HideHudAndRadarThisFrame();
                    break;
                case WalkInStage.WIS_GIVE_SEQUENCE:
                    if (resetCoords)
                    {
                        PlayerCache.MyPed.Position = scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos;
                        PlayerCache.MyPed.Heading = scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot;
                    }

                    TaskFlushRoute();

                    if (CurrentPropertyID == PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3
                    && IsEntityInAngledArea(PlayerPedId(), -105.851982f, 6528.291992f, 28.911039f, -103.993401f, 6530.095703f, 31.722012f, 2.250000f, false, false, 0))
                        TaskExtendRoute(-106.0008f, 6530.2056f, 28.8582f);
                    else
                        TaskExtendRoute(scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos.X, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos.Y, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos.Z);

                    TaskExtendRoute(scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos.X, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos.Y, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos.Z);
                    TaskExtendRoute(scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos.X, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos.Y, scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos.Z);
                    TaskFollowPointRoute(PlayerPedId(), 1.0f, 0);
                    CameraHelper.ExecutePan(ref scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing], ref propertyCam0, ref propertyCam1);
                    iCameraTimer.bInitialisedTimer = false;
                    PlayerCache.MyPed.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    PlayerCache.MyPed.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    Functions.ReinintNetTimer(ref iCameraTimer, true);
                    HideHudAndRadarThisFrame();
                    iWalkInStage = WalkInStage.WIS_WAIT_FOR_SEQUENCE_END;
                    break;
                case WalkInStage.WIS_WAIT_FOR_SEQUENCE_END:
                    PlayerCache.MyPed.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    PlayerCache.MyPed.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    HideHudAndRadarThisFrame();
                    if (Functions.HasNetTimerExpired(ref iCameraTimer, Round((scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration + scene.fExitDelay) * 1000f)))
                    {
                        if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 0 //WAITING_TO_START_TASK
                            && GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 1) //PERFORMING_TASK
                        {
                            iWalkInStage = WalkInStage.WIS_WAIT_FOR_LOAD;
                        }
                        else if (Functions.HasNetTimerExpired(ref iWalkInTimer, 10000, true))
                            iWalkInStage = WalkInStage.WIS_WAIT_FOR_LOAD;
                    }
                    break;
                case WalkInStage.WIS_WAIT_FOR_LOAD:
                    HideHudAndRadarThisFrame();
                    break;
                case WalkInStage.WIS_CLEANUP:
                    WalkInCleanup(true);
                    return true;
            }
            return false;
        }
        #endregion

        private static bool RequestToUseDoor(int iDoor, bool bRequestControl = true)
        {
            if (iDoor == 0)
                return true;
            else
            {
                if (!bRequestControl) // close
                {
                    if (!Functions.IsBitSet(iDoorSetBS[iDoor], 1))
                    {
                        if (DoorSystemGetDoorPendingState((uint)propertyDoors[iDoor].iDoorHash) == (int)DoorStateEnum.DOORSTATE_INVALID)
                        {
                            if (DoorSystemGetDoorState((uint)propertyDoors[iDoor].iDoorHash) != (int)DoorStateEnum.DOORSTATE_LOCKED)
                            {
                                DoorSystemSetHoldOpen((uint)propertyDoors[iDoor].iDoorHash, false);
                                DoorSystemSetDoorState((uint)propertyDoors[iDoor].iDoorHash, (int)DoorStateEnum.DOORSTATE_LOCKED, false, true);
                                serverDoorStateTimeout[iDoor].bInitialisedTimer = false;
                                Functions.SetBit(ref iDoorSetBS[iDoor], 1);
                                ClearBit(ref iDoorSetBS[iDoor], 0);
                            }
                        }
                        else
                        {
                            if (DoorSystemGetDoorPendingState((uint)propertyDoors[iDoor].iDoorHash) != (int)DoorStateEnum.DOORSTATE_LOCKED)
                            {
                                DoorSystemSetHoldOpen((uint)propertyDoors[iDoor].iDoorHash, false);
                                DoorSystemSetDoorState((uint)propertyDoors[iDoor].iDoorHash, (int)DoorStateEnum.DOORSTATE_LOCKED, false, true);
                                serverDoorStateTimeout[iDoor].bInitialisedTimer = false;
                                Functions.SetBit(ref iDoorSetBS[iDoor], 1);
                                ClearBit(ref iDoorSetBS[iDoor], 0);
                            }
                        }
                    }
                    else
                    {
                        if (!Functions.HasNetTimerStarted(serverDoorStateTimeout[iDoor]))
                        {
                            Functions.StartNetTimer(ref serverDoorStateTimeout[iDoor], true);
                        }
                        return true;
                    }
                }
                else // open
                {
                    if (!Functions.IsBitSet(iDoorSetBS[iDoor], 0))
                    {
                        if (DoorSystemGetDoorPendingState((uint)propertyDoors[iDoor].iDoorHash) == (int)DoorStateEnum.DOORSTATE_INVALID)
                        {
                            if (DoorSystemGetDoorState((uint)propertyDoors[iDoor].iDoorHash) != (int)DoorStateEnum.DOORSTATE_UNLOCKED)
                            {
                                DoorSystemSetDoorState((uint)propertyDoors[iDoor].iDoorHash, (int)DoorStateEnum.DOORSTATE_UNLOCKED, false, true);
                                DoorSystemSetHoldOpen((uint)propertyDoors[iDoor].iDoorHash, true);
                                serverDoorStateTimeout[iDoor].bInitialisedTimer = false;
                                ClearBit(ref iDoorSetBS[iDoor], 1);
                                Functions.SetBit(ref iDoorSetBS[iDoor], 0);
                            }
                        }
                        else
                        {
                            if (DoorSystemGetDoorPendingState((uint)propertyDoors[iDoor].iDoorHash) != (int)DoorStateEnum.DOORSTATE_UNLOCKED)
                            {
                                DoorSystemSetDoorState((uint)propertyDoors[iDoor].iDoorHash, (int)DoorStateEnum.DOORSTATE_UNLOCKED, false, true);
                                DoorSystemSetHoldOpen((uint)propertyDoors[iDoor].iDoorHash, true);
                                serverDoorStateTimeout[iDoor].bInitialisedTimer = false;
                                ClearBit(ref iDoorSetBS[iDoor], 1);
                                Functions.SetBit(ref iDoorSetBS[iDoor], 0);
                            }
                        }
                    }
                    else
                    {
                        if (!Functions.HasNetTimerStarted(serverDoorStateTimeout[iDoor]))
                        {
                            Functions.StartNetTimer(ref serverDoorStateTimeout[iDoor], true);
                        }
                        return true;
                    }
                }
                if (Functions.HasNetTimerStarted(serverDoorStateTimeout[iDoor]))
                {
                    if (Functions.HasNetTimerExpired(ref serverDoorStateTimeout[iDoor], 1000, true))
                    {
                        serverDoorStateTimeout[iDoor].bInitialisedTimer = false;
                        ClearBit(ref iDoorSetBS[iDoor], 0);
                        ClearBit(ref iDoorSetBS[iDoor], 1);
                    }
                }
            }
            return false;
        }

        private static void DoApartmentBuzzerPressSounds()
        {
            float fSoundTime = 0;
            if (PropertyFunctions.GetPropertySizeType(Properties[(int)CurrentPropertyID].Index) == PropertySizeType.PROP_SIZE_TYPE_LARGE_APT)
            {
                if (!string.IsNullOrEmpty(entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A]))
                {
                    if (entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A] == "buzz_short")
                        fSoundTime = 0.353f;
                    else if (entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A] == "buzz_reg")
                        fSoundTime = 0.320f;
                    else
                        fSoundTime = 0.373f;
                }
            }
            if (entryCutData.iSyncedSceneID >= 0)
            {
                if (IsSynchronizedSceneRunning(entryCutData.iSyncedSceneID))
                {
                    switch (iApartmentBuzzerSoundStage)
                    {
                        case 0:
                            if (GetSynchronizedScenePhase(entryCutData.iSyncedSceneID) >= fSoundTime)
                            {
                                if (!IsPedInjured(entryCutData.playerClone))
                                {
                                    if (entryCutData.iSoundID <= 0)
                                    {
                                        entryCutData.iSoundID = GetSoundId();
                                    }
                                    PlaySoundFromEntity(entryCutData.iSoundID, "DOOR_BUZZ_ONESHOT_MASTER", entryCutData.playerClone, "GTAO_APT_DOOR_DOWNSTAIRS_GLASS_SOUNDS", false, 0);
                                }
                                iApartmentBuzzerSoundStage++;
                            }
                            break;
                    }
                }
            }
        }

        private static bool RunEntryCuscene(ENTRY_CUTSCENE_TYPE type, bool skipSecondCut = false)
        {
            if (!IsGameplayCamRendering())
            {
                HideHudAndRadarThisFrame();
            }
            STRUCT_WalkIn scene = new();
            if (WalkIntoPropertyHelper.Get_WalkIn(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID), ref scene, iEntrancePlayerIsUsing)) { }
            float fStartPhase = 0f;
            bool bDoorGarage = false;
            if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR && entryCutData.iStage < ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_SECOND_CUT)
            {
                DoApartmentDoorSounds();
                fStartPhase = 0.15f;
            }
            if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR && PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
            {
                fStartPhase = 0.2f;
            }
            if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_BUZZER)
            {
                DoApartmentBuzzerPressSounds();
            }
            switch (entryCutData.iStage)
            {
                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_INIT_DATA:
                    if (GetEntryCutsceneData(type, skipSecondCut))
                    {
                        RequestAnimDict(entryCutData.animDictionary);
                        for (int i = 0; i < 500; i++)
                        {
                            if (HasAnimDictLoaded(entryCutData.animDictionary))
                                break;
                        }
                        if (HasAnimDictLoaded(entryCutData.animDictionary))
                        {
                            Functions.ReinintNetTimer(ref entryCutData.timer, true);
                            SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_WAIT_FOR_MODELS);
                        }
                    }
                    break;

                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_WAIT_FOR_MODELS:
                    if (!Functions.HasNetTimerExpired(ref entryCutData.timer, 5000, true))
                    {
                        if (DoesEntityExist(entryCutData.playerClone))
                        {
                            if (!IsPedInjured(entryCutData.playerClone))
                            {
                                if (!HaveAllStreamingRequestsCompleted(entryCutData.playerClone))
                                    return false;
                                if (!HasPedHeadBlendFinished(entryCutData.playerClone))
                                    return false;
                            }
                        }
                    }
                    SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_HANDLE_PLAYER_PED);
                    break;
                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_HANDLE_PLAYER_PED:
                    SetPlayerControl(PlayerId(), false, 16384 | 32768 | 524288 | 8192); //NSPC_NO_COLLISION | NSPC_FREEZE_POSITION | NSPC_PREVENT_VISIBILITY_CHANGES | NSPC_SET_INVISIBLE
                    Functions.FadeEntity(PlayerCache.MyPed, false, true, true);
                    SetLocalPlayerVisibleInCutscene(false, true);
                    CutsceneHelper.StartMPCutscene(true);
                    SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_TRIGGER_CUT);
                    break;
                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_TRIGGER_CUT:
                    if (DoesCamExist(entryCutData.cameras[0]))
                        DestroyCam(entryCutData.cameras[0], false);
                    if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR)
                    {
                        if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) != BuildingsEnum.MP_PROPERTY_BUILDING_5)
                        {
                            if (propertyDoors[1].vCoords == Vector3.Zero)
                            {
                                CreateModelHide(propertyDoors[1].vCoords.X, propertyDoors[1].vCoords.Y, propertyDoors[1].vCoords.Z, 1, propertyDoors[1].doorModel, true);
                            }
                            else
                            {
                                CreateModelHide(propertyDoors[0].vCoords.X, propertyDoors[0].vCoords.Y, propertyDoors[0].vCoords.Z, 1, propertyDoors[0].doorModel, true);
                            }
                        }
                        else
                        {
                            CreateModelHide(propertyDoors[0].vCoords.X, propertyDoors[0].vCoords.Y, propertyDoors[0].vCoords.Z, 1, propertyDoors[0].doorModel, true);
                        }
                        if (DoesEntityExist(entryCutData.objIDs[0]))
                        {
                            Vector3 pos = GetAnimInitialOffsetPosition(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                entryCutData.vSyncSceneLoc.X, entryCutData.vSyncSceneLoc.Y, entryCutData.vSyncSceneLoc.Z, entryCutData.vSyncSceneRot.X, entryCutData.vSyncSceneRot.Y, entryCutData.vSyncSceneRot.Z, fStartPhase, 2);
                            Vector3 rot = GetAnimInitialOffsetRotation(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                entryCutData.vSyncSceneLoc.X, entryCutData.vSyncSceneLoc.Y, entryCutData.vSyncSceneLoc.Z, entryCutData.vSyncSceneRot.X, entryCutData.vSyncSceneRot.Y, entryCutData.vSyncSceneRot.Z, fStartPhase, 2);
                            SetEntityCoordsNoOffset(entryCutData.objIDs[0], pos.X, pos.Y, pos.Z, false, false, true);
                            SetEntityRotation(entryCutData.objIDs[0], rot.X, rot.Y, rot.Z, 2, false);

                        }
                        entryCutData.cameras[0] = CreateCamera(Functions.HashUint("DEFAULT_SCRIPTED_CAMERA"), true);
                        SetCamParams(entryCutData.cameras[0],
                            entryCutData.vCamLoc[0].X, entryCutData.vCamLoc[0].Y, entryCutData.vCamLoc[0].Z,
                            entryCutData.vCamRot[0].X, entryCutData.vCamRot[0].Y, entryCutData.vCamRot[0].Z,
                            entryCutData.fCamFOV[0], 0, 1, 1, 2);
                        SetCamFarClip(entryCutData.cameras[0], 1000f);
                        ShakeCam(entryCutData.cameras[0], "HAND_SHAKE", 0.25f);
                        Functions.ReinintNetTimer(ref entryCutData.timer, true);
                        RenderScriptCams(true, false, 3000, true, false);
                        FreezeEntityPosition(entryCutData.playerClone, true);
                        entryCutData.iSyncedSceneID = CreateSynchronizedScene(entryCutData.vSyncSceneLoc.X, entryCutData.vSyncSceneLoc.Y, entryCutData.vSyncSceneLoc.Z, entryCutData.vSyncSceneRot.X, entryCutData.vSyncSceneRot.Y, entryCutData.vSyncSceneRot.Z, 2);
                        if (!IsPedInjured(entryCutData.playerClone))
                        {
                            TaskSynchronizedScene(entryCutData.playerClone, entryCutData.iSyncedSceneID, entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A],
                                                    1000f, -1000f, 4, 0, 1000f, 0); //INSTANT_BLEND_IN,INSTANT_BLEND_OUT,SYNCED_SCENE_DONT_intERRUPT,RBF_NONE,INSTANT_BLEND_IN,AIK_NONE
                        }
                        if (!PropertyFunctions.IsIndipendenceDayApartment(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID)))
                        {
                            if (DoesEntityExist(entryCutData.objIDs[0]))
                            {
                                switch (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID))
                                {
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                                        {
                                            Vector3 pos = GetAnimInitialOffsetPosition(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                               -931.625f, -385.063f, 37.763f, 0.000f, 0.000f, -64.000f, 0, 2);
                                            Vector3 rot = GetAnimInitialOffsetRotation(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                               -931.625f, -385.063f, 37.763f, 0.000f, 0.000f, -64.000f, 0, 2);
                                            SetEntityRotation(entryCutData.objIDs[0], rot.X, rot.Y, rot.Z, 2, false);
                                            SetEntityCoordsNoOffset(entryCutData.objIDs[0], pos.X, pos.Y, pos.Z, false, false, true);
                                            PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, fStartPhase, 524288);
                                        }
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 1);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], tempPropOffset.X, tempPropOffset.Y, tempPropOffset.Z, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 1);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], 0, 0, -90f, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 1);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], 0, 0, -52f, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 0);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], tempPropOffset.X, tempPropOffset.Y, tempPropOffset.Z, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 1);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], 0, 0, 230f, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 1);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], 0, 0, 50f, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.153f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                                        {
                                            Vector3 pos = GetAnimInitialOffsetPosition(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                               -1295.462f, 453.962f, 96.359f, 0.000f, 0.000f, -180, 0, 2);
                                            Vector3 rot = GetAnimInitialOffsetRotation(entryCutData.animDictionary, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR],
                                               -1295.462f, 453.962f, 96.359f, 0.000f, 0.000f, -180, 0, 2);
                                            SetEntityRotation(entryCutData.objIDs[0], rot.X, rot.Y, rot.Z, 2, false);
                                            SetEntityCoordsNoOffset(entryCutData.objIDs[0], pos.X, pos.Y, pos.Z, false, false, true);
                                            PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, fStartPhase, 524288);
                                        }
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 0);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], tempPropOffset.X, tempPropOffset.Y, tempPropOffset.Z, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, 0.70f, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                                    case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                                        PropertyFunctions.GetBuildingDoorDetails(ref tempPropOffset, ref propertyDoors[0], ref bDoorGarage, Properties[(int)CurrentPropertyID].BuildingID, 0);
                                        SetEntityRotation(entryCutData.objIDs[0], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], tempPropOffset.X, tempPropOffset.Y, tempPropOffset.Z, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, fStartPhase, 524288);
                                        break;
                                    case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                                        SetEntityRotation(entryCutData.objIDs[0], 180f, 0f, -71.5f, 2, false);
                                        SetEntityCoordsNoOffset(entryCutData.objIDs[0], -753.498f, 619.340f, 143.2394f, false, false, true);
                                        PlayEntityAnim(entryCutData.objIDs[0], entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, false, false, false, fStartPhase, 524288);
                                        break;
                                    default:
                                        PlaySynchronizedEntityAnim(entryCutData.objIDs[0], entryCutData.iSyncedSceneID, entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR], entryCutData.animDictionary, 1000f, -1000f, 0, 1000f);
                                        break;
                                }
                            }
                        }
                        SetSynchronizedScenePhase(entryCutData.iSyncedSceneID, fStartPhase);
                        SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_CUT);
                    }
                    break;
                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_CUT:
                    if (Functions.HasNetTimerExpired(ref entryCutData.timer, 5000, true))
                    {
                        Functions.ReinintNetTimer(ref iCameraTimer, true);
                        Functions.ReinintNetTimer(ref iWalkInTimer, true);
                        CameraHelper.ExecutePan(ref scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing], ref propertyCam0, ref propertyCam1);
                        if (!IsPedInjured(entryCutData.playerClone) && type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR)
                        {
                            SetEntityVisible(entryCutData.playerClone, false, false);
                        }
                        if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                        {
                            if (iEntrancePlayerIsUsing == 0)
                                StartAudioScene("EXEC1_Enter_Office_From_Ground_Scene");
                            else
                                StartAudioScene("EXEC1_Enter_Office_From_Roof_Scene");
                        }
                        SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_SECOND_CUT);
                    }
                    if (entryCutData.iSyncedSceneID >= 0)
                    {
                        if (IsSynchronizedSceneRunning(entryCutData.iSyncedSceneID))
                        {
                            if (GetSynchronizedScenePhase(entryCutData.iSyncedSceneID) > entryCutData.fSyncedSceneCompleteStage)
                            {
                                if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR)
                                {
                                    if (propertyDoors[1].vCoords != Vector3.Zero)
                                        Function.Call(Hash.REMOVE_MODEL_HIDE, propertyDoors[1].vCoords.X, propertyDoors[1].vCoords.Y, propertyDoors[1].vCoords.Z, 1f, propertyDoors[1].doorModel, false);
                                    else
                                        Function.Call(Hash.REMOVE_MODEL_HIDE, propertyDoors[0].vCoords.X, propertyDoors[0].vCoords.Y, propertyDoors[0].vCoords.Z, 1f, propertyDoors[0].doorModel, false);
                                }
                                else
                                    Function.Call(Hash.REMOVE_MODEL_HIDE, propertyDoors[0].vCoords.X, propertyDoors[0].vCoords.Y, propertyDoors[0].vCoords.Z, 1f, propertyDoors[0].doorModel, false);
                            }
                            return true;
                        }
                    }
                    else
                    {
                        Functions.ReinintNetTimer(ref iCameraTimer, true);
                        Functions.ReinintNetTimer(ref iWalkInTimer, true);
                        CameraHelper.ExecutePan(ref scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing], ref propertyCam0, ref propertyCam1);
                        if (!IsPedInjured(entryCutData.playerClone) && type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR)
                        {
                            SetEntityVisible(entryCutData.playerClone, false, false);
                        }
                        if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                        {
                            if (iEntrancePlayerIsUsing == 0)
                                StartAudioScene("EXEC1_Enter_Office_From_Ground_Scene");
                            else
                                StartAudioScene("EXEC1_Enter_Office_From_Roof_Scene");
                        }
                        SetEntryCSStage(ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_SECOND_CUT);
                    }
                    break;
                case ENTRY_CS_STAGE.ENTRY_CS_STAGE_RUN_SECOND_CUT:
                    if (Functions.HasNetTimerExpired(ref iCameraTimer, Round((scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration + scene.fExitDelay) * 1000f), true))
                    {
                        if (entryCutData.iSoundID >= 0)
                            Audio.StopSound(entryCutData.iSoundID);
                        return true;
                    }
                    else
                    {
                        if (type == ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR)
                            DoApartmentDoorSounds();
                    }
                    break;
            }
            return false;
        }

        private static bool GetEntryCutsceneData(ENTRY_CUTSCENE_TYPE type, bool bSkipSecondCut = false)
        {
            PropertyData property = Properties[(int)CurrentPropertyID];
            uint modelToLoad = 0;
            iApartmentDoorSoundStage = 0;
            switch (type)
            {
                case ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_BUZZER:
                    if (property.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_5
                        && property.Entrance[iEntrancePlayerIsUsing].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
                        entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A] = "buzz_short";
                    else
                        entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A] = "buzz_reg";

                    PropertyFunctions.GetTransitionBuzzCamDetails(property.BuildingID, ref tempCamOffset, iEntrancePlayerIsUsing);
                    entryCutData.vCamLoc[0] = tempCamOffset.vLoc;
                    entryCutData.vCamRot[0] = tempCamOffset.vRot;
                    entryCutData.fCamFOV[0] = tempCamOffset.iFov;

                    PropertyFunctions.GetTransitionBuzzSceneDetails(property.BuildingID, ref tempPropOffset, iEntrancePlayerIsUsing);
                    entryCutData.vSyncSceneLoc = tempPropOffset.ToVector3;
                    entryCutData.vSyncSceneRot = tempPropOffset.ToRotationVector;
                    if (!DoesEntityExist(entryCutData.playerClone))
                    {
                        Position pos = PlayerCache.MyClient.Position + new Position(0, 0, -10f);
                        if (PlayerCache.Character.Skin.Sex != "Female")
                            entryCutData.playerClone = CreatePed(4, PlayerCache.Character.Skin.Model, pos.X, pos.Y, pos.Z, PlayerCache.MyPed.Heading, false, false);
                        else
                            entryCutData.playerClone = CreatePed(5, PlayerCache.Character.Skin.Model, pos.X, pos.Y, pos.Z, PlayerCache.MyPed.Heading, false, false);
                        ClonePedToTarget(PlayerPedId(), entryCutData.playerClone);
                        //UPDATE_MC_EMBLEM(GET_PLAYER_INDEX(), entryCutData.playerClone)
                    }
                    FreezeEntityPosition(entryCutData.playerClone, true);
                    SetEntityProofs(entryCutData.playerClone, true, true, true, true, true, true, true, true);
                    entryCutData.fSyncedSceneCompleteStage = 0.6f;
                    break;
                case ENTRY_CUTSCENE_TYPE.ENTRY_CUTSCENE_TYPE_FRONT_DOOR:
                    entryCutData.animDictionary = "anim@apt_trans@hinge_r";
                    if (property.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_17
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_20
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_58
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A
                    || (property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2 && iEntrancePlayerIsUsing == 0)
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1
                    || (property.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4)
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11
                    || property.BuildingID == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12)
                        entryCutData.animDictionary = "anim@apt_trans@hinge_l";

                    entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_PED_A] = "ext_player";
                    entryCutData.animName[(int)SYNC_SCENE_ELEMENTS.SYNC_SCENE_DOOR] = "ext_door";

                    if (CurrentPropertyID != PropertiesEnum.PROPERTY_OFFICE_2_BASE)
                        modelToLoad = PropertyFunctions.GetSpecialPropertyDoorForAnimation(property.BuildingID, iEntrancePlayerIsUsing);
                    else if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                        modelToLoad = PropertyFunctions.GetSpecialPropertyDoorForAnimation(property.BuildingID, iEntrancePlayerIsUsing);

                    if (modelToLoad == Functions.HashUint("DUMMY_MODEL_FOR_SCRIPT"))
                    {
                        if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) != BuildingsEnum.MP_PROPERTY_BUILDING_5)
                        {
                            if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                                modelToLoad = propertyDoors[iEntrancePlayerIsUsing].doorModel;
                            else
                            {
                                if (propertyDoors[1].vCoords != Vector3.Zero)
                                    modelToLoad = propertyDoors[1].doorModel;
                                else
                                    modelToLoad = propertyDoors[0].doorModel;
                            }
                        }
                        else
                            modelToLoad = propertyDoors[0].doorModel;
                    }
                    if (!RequestLoadModel(modelToLoad))
                    {
                        return false;
                    }

                    tempCamOffset = new MPCamOffset();
                    PropertyFunctions.PropertyTransitionCamDetails(property.BuildingID, iEntrancePlayerIsUsing, true, ref tempCamOffset);
                    entryCutData.vCamLoc[0] = tempCamOffset.vLoc;
                    entryCutData.vCamRot[0] = tempCamOffset.vRot;
                    entryCutData.fCamFOV[0] = tempCamOffset.iFov;

                    PropertyFunctions.GetTransitionEnterSceneDetails(property.BuildingID, ref tempPropOffset, iEntrancePlayerIsUsing);
                    entryCutData.vSyncSceneLoc = tempPropOffset.ToVector3;
                    entryCutData.vSyncSceneRot = tempPropOffset.ToRotationVector;
                    if (!DoesEntityExist(entryCutData.objIDs[0])
                        && !PropertyFunctions.IsIndipendenceDayApartment(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID))
                        && !PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
                    {
                        if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_6)
                        {
                            Vector3 pos = PlayerCache.MyPed.Position + new Vector3(0, 0, -20f);
                            entryCutData.objIDs[0] = CreateObjectNoOffset(modelToLoad, pos.X, pos.Y, pos.Z, false, false, true);
                        }
                        else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_5)
                        {
                            if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                            {
                                Vector3 pos = propertyDoors[iEntrancePlayerIsUsing].vCoords + new Vector3(0, 0, -20);
                                entryCutData.objIDs[0] = CreateObjectNoOffset(modelToLoad, pos.X, pos.Y, pos.Z, false, false, true);
                            }
                            else
                            {

                                Vector3 pos = new();
                                if (propertyDoors[1].vCoords != Vector3.Zero)
                                    pos = propertyDoors[1].vCoords + new Vector3(0, 0, -20f);
                                else
                                    pos = propertyDoors[0].vCoords + new Vector3(0, 0, -20f);
                                entryCutData.objIDs[0] = CreateObjectNoOffset(modelToLoad, pos.X, pos.Y, pos.Z, false, false, true);
                            }
                        }
                        else
                        {
                            Vector3 pos = propertyDoors[0].vCoords + new Vector3(0, 0, -20f);
                            entryCutData.objIDs[0] = CreateObjectNoOffset(modelToLoad, pos.X, pos.Y, pos.Z, false, false, true);
                        }
                    }

                    Position _pos = PlayerCache.MyClient.Position + new Position(0, 0, -10f);
                    if (PlayerCache.Character.Skin.Sex != "Female")
                        entryCutData.playerClone = CreatePed(4, PlayerCache.Character.Skin.Model, _pos.X, _pos.Y, _pos.Z, PlayerCache.MyPed.Heading, false, false);
                    else
                        entryCutData.playerClone = CreatePed(5, PlayerCache.Character.Skin.Model, _pos.X, _pos.Y, _pos.Z, PlayerCache.MyPed.Heading, false, false);
                    ClonePedToTarget(PlayerPedId(), entryCutData.playerClone);
                    //UPDATE_MC_EMBLEM(GET_PLAYER_INDEX(), entryCutData.playerClone)
                    FreezeEntityPosition(entryCutData.playerClone, true);
                    SetEntityProofs(entryCutData.playerClone, true, true, true, true, true, true, true, true);
                    entryCutData.fSyncedSceneCompleteStage = 0.6f;
                    break;
            }
            return true;
        }

        private static void SetEntryCSStage(ENTRY_CS_STAGE iStage)
        {
            entryCutData.iStage = iStage;
        }
        private static void DoApartmentDoorSounds()
        {
            float fDoorOpen = 0, fDoorShutting = 0;
            if (!IsStringNullOrEmpty(entryCutData.animDictionary))
            {
                if (entryCutData.animDictionary == "anim@apt_trans@hinge_l")
                {
                    fDoorOpen = 0.271f;
                    fDoorShutting = 0.411f;
                }
                else
                {
                    fDoorOpen = 0.242f;
                    fDoorShutting = 0.418f;
                }
            }
            if (entryCutData.iSyncedSceneID >= 0)
            {
                if (IsSynchronizedSceneRunning(entryCutData.iSyncedSceneID))
                {
                    switch (iApartmentDoorSoundStage)
                    {
                        case 0: // doors start opening
                            if (GetSynchronizedScenePhase(entryCutData.iSyncedSceneID) >= fDoorOpen)
                            {
                                if (entryCutData.iSoundID < 0)
                                    entryCutData.iSoundID = GetSoundId();
                                if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_57
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_58
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_59
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_60
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_61
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_62
                                 || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_63)
                                {
                                    PlaySoundFrontend(entryCutData.iSoundID, "WOODEN_DOOR_OPEN_NO_HANDLE_AT", "", true);
                                }
                                else if (PropertyFunctions.IsPropertyStiltApartment(CurrentPropertyID))
                                {
                                    PlaySoundFrontend(entryCutData.iSoundID, "PUSH", "GTAO_APT_DOOR_DOWNSTAIRS_WOOD_SOUNDS", true);
                                }
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6)
                                {
                                    PlaySoundFrontend(entryCutData.iSoundID, "PUSH", "GTAO_APT_DOOR_DOWNSTAIRS_GENERIC_SOUNDS", true);
                                }
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4
                                && iEntrancePlayerIsUsing == 1)
                                {
                                    PlaySoundFrontend(entryCutData.iSoundID, "PUSH", "GTAO_APT_DOOR_ROOF_METAL_SOUNDS", true);
                                }
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12)
                                {
                                    PlaySoundFrontend(entryCutData.iSoundID, "PUSH", "GTAO_APT_DOOR_ROOF_METAL_SOUNDS", true);
                                }
                                else
                                    PlaySoundFrontend(entryCutData.iSoundID, "PUSH", "GTAO_APT_DOOR_DOWNSTAIRS_GLASS_SOUNDS", true);
                                iApartmentDoorSoundStage++;
                            }
                            break;
                        case 1: //Door begins to swing shut
                            if (GetSynchronizedScenePhase(entryCutData.iSyncedSceneID) >= fDoorShutting)
                            {
                                if (entryCutData.iSoundID < 0)
                                    entryCutData.iSoundID = GetSoundId();
                                if (PropertyFunctions.IsPropertyStiltApartment(CurrentPropertyID))
                                    PlaySoundFrontend(entryCutData.iSoundID, "LIMIT", "GTAO_APT_DOOR_DOWNSTAIRS_WOOD_SOUNDS", true);
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6)
                                    PlaySoundFrontend(entryCutData.iSoundID, "LIMIT", "GTAO_APT_DOOR_DOWNSTAIRS_GENERIC_SOUNDS", true);
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4
                                && iEntrancePlayerIsUsing == 1)
                                    PlaySoundFrontend(entryCutData.iSoundID, "LIMIT", "GTAO_APT_DOOR_ROOF_METAL_SOUNDS", true);
                                else if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11
                                || PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12)
                                    PlaySoundFrontend(entryCutData.iSoundID, "LIMIT", "GTAO_APT_DOOR_ROOF_METAL_SOUNDS", true);
                                else
                                    PlaySoundFrontend(entryCutData.iSoundID, "LIMIT", "GTAO_APT_DOOR_DOWNSTAIRS_GLASS_SOUNDS", true);
                                iApartmentDoorSoundStage++;
                            }
                            break;
                    }
                }

            }
        }
        private static bool DoesLocalRevolvingDoorExist()
        {
            return Properties[(int)CurrentPropertyID].BuildingID != BuildingsEnum.MP_PROPERTY_BUILDING_6 || (revolvingDoor != null && revolvingDoor.Exists());
        }

        private static bool CREATE_REVOLVING_DOOR()
        {
            if (!DoesLocalRevolvingDoorExist())
            {
                uint model = Functions.HashUint("PROP_QL_REVOLVING_DOOR");
                if (RequestLoadModel(model))
                {
                    CreateModelHide(-935.040f, -378.360f, 39.180f, 2, model, true);
                    revolvingDoor = new Prop(CreateObjectNoOffset(model, -935.040f, -378.360f, 39.180f, false, false, true))
                    {
                        Rotation = new Vector3(0, 0, 162),
                        IsPositionFrozen = true,
                        IsInvincible = true
                    };
                    SetEntityProofs(revolvingDoor.Handle, true, true, true, true, true, true, true, true);
                    SetEntityDynamic(revolvingDoor.Handle, false);
                    return true;
                }
                return false;
            }
            return true;
        }

        private static bool CREATE_DOOR_PLANKS()
        {
            switch (CurrentPropertyID)
            {
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                    {
                        if (!DoesEntityExist(doorPlanks[0]))
                        {
                            uint model = Functions.HashUint("Prop_Cons_plank");
                            if (RequestLoadModel(model))
                            {
                                doorPlanks[0] = CreateObject((int)model, 1340.5740f, -1578.2190f, 54.861f, false, false, true);
                                SetEntityRotation(doorPlanks[0], -90.4000f, 104.2000f, 50.8000f, 2, false);
                                FreezeEntityPosition(doorPlanks[0], true);
                                SetEntityProofs(doorPlanks[0], true, true, true, true, true, true, true, true);
                                SetEntityInvincible(doorPlanks[0], true);
                                SetEntityDynamic(doorPlanks[0], false);
                            }
                            return false;
                        }
                        if (!DoesEntityExist(doorPlanks[1]))
                        {
                            uint model = Functions.HashUint("Prop_Cons_plank");
                            if (RequestLoadModel(model))
                            {
                                doorPlanks[1] = CreateObject((int)model, 1340.6680f, -1578.1560f, 54.248f, false, false, true);
                                SetEntityRotation(doorPlanks[1], -111.6000f, -2.3000f, -55.6000f, 2, false);
                                FreezeEntityPosition(doorPlanks[1], true);
                                SetEntityProofs(doorPlanks[1], true, true, true, true, true, true, true, true);
                                SetEntityInvincible(doorPlanks[1], true);
                                SetEntityDynamic(doorPlanks[1], false);
                            }
                            return false;
                        }
                        break;
                    }
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                    if (!DoesEntityExist(doorPlanks[0]))
                    {
                        uint model = Functions.HashUint("prop_barrier_work06a");
                        if (RequestLoadModel(model))
                        {
                            switch (CurrentPropertyID)
                            {
                                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                                    doorPlanks[0] = CreateObject((int)model, 35.5731f, -1033.4091f, 28.4974f, false, false, true);
                                    SetEntityRotation(doorPlanks[0], 0.0000f, -0.0000f, 67.4000f, 2, false);
                                    break;
                                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                                    doorPlanks[0] = CreateObject((int)model, -26.0706f, -190.4464f, 51.3284f, false, false, true);
                                    SetEntityRotation(doorPlanks[0], 0.0000f, -0.0000f, -19.8000f, 2, false);
                                    break;
                                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                                    doorPlanks[0] = CreateObject((int)model, -42.1150f, 6417.3618f, 30.4484f, false, false, true);
                                    SetEntityRotation(doorPlanks[0], 0.0000f, -0.0000f, 43.0000f, 2, false);
                                    break;
                            }
                            FreezeEntityPosition(doorPlanks[0], true);
                            SetEntityProofs(doorPlanks[0], true, true, true, true, true, true, true, true);
                            SetEntityInvincible(doorPlanks[0], true);
                            SetEntityDynamic(doorPlanks[0], false);
                        }
                        return false;
                    }
                    break;
            }
            return true;
        }
        private static bool IsPropertyMissingBuzzers(PropertiesEnum property)
        {
            return property switch
            {
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4 or PropertiesEnum.PROPERTY_IND_DAY_LOW_1 or PropertiesEnum.PROPERTY_IND_DAY_LOW_2 or PropertiesEnum.PROPERTY_IND_DAY_LOW_3 or PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B or PropertiesEnum.PROPERTY_STILT_APT_2_B or PropertiesEnum.PROPERTY_STILT_APT_3_B or PropertiesEnum.PROPERTY_STILT_APT_4_B or PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A or PropertiesEnum.PROPERTY_STILT_APT_7_A or PropertiesEnum.PROPERTY_STILT_APT_8_A or PropertiesEnum.PROPERTY_STILT_APT_10_A or PropertiesEnum.PROPERTY_STILT_APT_12_A or PropertiesEnum.PROPERTY_STILT_APT_13_A or PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_4 or PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => true,
                _ => false,
            };
        }
        private static uint GetPropertyBuzzerModel(PropertiesEnum iPropertyID)
        {
            return iPropertyID switch
            {
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4 or PropertiesEnum.PROPERTY_IND_DAY_LOW_1 or PropertiesEnum.PROPERTY_IND_DAY_LOW_2 or PropertiesEnum.PROPERTY_IND_DAY_LOW_3 or PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B or PropertiesEnum.PROPERTY_STILT_APT_2_B or PropertiesEnum.PROPERTY_STILT_APT_3_B or PropertiesEnum.PROPERTY_STILT_APT_4_B or PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A or PropertiesEnum.PROPERTY_STILT_APT_7_A or PropertiesEnum.PROPERTY_STILT_APT_8_A or PropertiesEnum.PROPERTY_STILT_APT_10_A or PropertiesEnum.PROPERTY_STILT_APT_12_A or PropertiesEnum.PROPERTY_STILT_APT_13_A or PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_4 or PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => Functions.HashUint("PROP_LD_KEYPAD_01B"),
                _ => Functions.HashUint("DUMMY_MODEL_FOR_SCRIPT"),
            };
        }
        private static bool CREATE_BUZZER_PROPS_IF_NEEDED()
        {
            PropertyData property = Properties[(int)CurrentPropertyID];
            if (IsPropertyMissingBuzzers(CurrentPropertyID))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (property.Entrance[i].BuzzerProp != Vector3.Zero)
                    {
                        if (!DoesEntityExist(createdBuzzers[i]))
                        {
                            if (RequestLoadModel(GetPropertyBuzzerModel(CurrentPropertyID)))
                            {
                                createdBuzzers[i] = CreateObject((int)GetPropertyBuzzerModel(CurrentPropertyID), property.Entrance[i].BuzzerProp.X, property.Entrance[i].BuzzerProp.Y, property.Entrance[i].BuzzerProp.Z, false, false, true);
                                if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID) && i == 1)
                                    SetEntityCoordsNoOffset(createdBuzzers[i], property.Entrance[i].BuzzerProp.X, property.Entrance[i].BuzzerProp.Y, property.Entrance[i].BuzzerProp.Z, false, false, true);
                                SetEntityRotation(createdBuzzers[i], property.Entrance[i].BuzzerPropRot.X, property.Entrance[i].BuzzerPropRot.Y, property.Entrance[i].BuzzerPropRot.Z, 2, false);
                                FreezeEntityPosition(createdBuzzers[i], true);
                                SetEntityProofs(createdBuzzers[i], true, true, true, true, true, true, true, true);
                                SetEntityInvincible(createdBuzzers[i], true);
                                SetEntityDynamic(createdBuzzers[i], false);
                            }
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private static bool CREATE_LOCAL_BLOCKING_OBJECTS()
        {
            uint model = Functions.HashUint("prop_dummy_car");
            if (PropertyFunctions.GetPropertyBuilding(CurrentPropertyID) == BuildingsEnum.MP_PROPERTY_BUILDING_6)
            {
                if (entryBlockingObj == null || !entryBlockingObj.Exists())
                {
                    if (RequestLoadModel(model))
                    {
                        if (CanRegisterMissionEntities(0, 0, 1, 0))
                        {
                            ClearAreaOfObjects(-935.1886f, -378.4521f, 38.8713f, 3f, 0);
                            entryBlockingObj = new Prop(CreateObjectNoOffset(model, -935.1886f, -378.4521f, 38.8713f, false, false, true))
                            {
                                Rotation = new Vector3(0, 0, 26),
                                IsPositionFrozen = true,
                                IsVisible = false,
                                IsInvincible = true
                            };
                            SetEntityProofs(entryBlockingObj.Handle, true, true, true, true, true, true, true, true);
                            SetEntityDynamic(entryBlockingObj.Handle, false);
                            SetCanClimbOnEntity(entryBlockingObj.Handle, false);
                        }
                    }
                    return false;
                }
                if (garageBlockingObj == null || !garageBlockingObj.Exists())
                {
                    if (RequestLoadModel(model))
                    {
                        if (CanRegisterMissionEntities(0, 0, 1, 0))
                        {
                            ClearAreaOfObjects(-935.1886f, -378.4521f, 39.8713f, 3f, 0);
                            garageBlockingObj = new Prop(CreateObjectNoOffset(model, -935.1886f, -378.4521f, 39.8713f, false, false, true))
                            {
                                Rotation = new Vector3(0, 0, 26),
                                IsPositionFrozen = true,
                                IsVisible = false,
                                IsInvincible = true
                            };
                            SetEntityProofs(garageBlockingObj.Handle, true, true, true, true, true, true, true, true);
                            SetEntityDynamic(garageBlockingObj.Handle, false);
                            SetCanClimbOnEntity(garageBlockingObj.Handle, false);
                            SetModelAsNoLongerNeeded(model);
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        private static bool RequestLoadModel(uint model)
        {
            if (model == Functions.HashUint("DUMMY_MODEL_FOR_SCRIPT"))
                return true;
            RequestModel(model);
            return HasModelLoaded(model);
        }

        private static bool DoesForSaleSignExist()
        {
            if (forSaleDetails.locate.Width == 0)
                return true;
            return forSaleSign != null && forSaleSign.Exists();
        }
        private static bool MAINTAIN_FOR_SALE_SIGN()
        {
            if (IsThereAPropertyToBuy())
            {
                if (!DoesForSaleSignExist())
                {
                    if (RequestLoadModel(forSaleDetails.saleSign))
                    {
                        forSaleSign = new Prop(CreateObjectNoOffset(forSaleDetails.saleSign, forSaleDetails.vProp.X, forSaleDetails.vProp.Yaw, forSaleDetails.vProp.Z, false, false, true))
                        {
                            Rotation = forSaleDetails.vProp.ToRotationVector,
                            IsPositionFrozen = true,
                            IsInvincible = true
                        };
                        SetEntityProofs(forSaleSign.Handle, true, true, true, true, true, true, true, true);
                        SetEntityDynamic(forSaleSign.Handle, false);
                        SetDisableFragDamage(forSaleSign.Handle, true);
                        SetDisableBreaking(forSaleSign.Handle, true);
                        SetModelAsNoLongerNeeded(forSaleDetails.saleSign);
                        return true;
                    }
                    return false;
                }
            }
            else
            {
                if (forSaleSign != null && forSaleSign.Exists())
                    forSaleSign.Delete();
            }
            return true;
        }

        private static bool CREATE_ENTRY_AREAS_MAP_HOLE_PROTECTORS()
        {
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_9)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!CreateMapHolePropector(i))
                        return false;
                }
            }
            return true;
        }

        public static bool CreateMapHolePropector(int index)
        {
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_9)
            {
                if (!DoesEntityExist(mapHoleProtectors[index]))
                {
                    uint model = Functions.HashUint("prop_ss1_mpint_garage");
                    if (RequestLoadModel(model))
                    {
                        tempPropOffset = new();
                        switch (index)
                        {
                            case 0: //interior left wall
                                tempPropOffset = new(7.941f, 40.869f, 70.586f, 0f, 0f, 71.30f);
                                break;
                            case 1: //interior right wall
                                tempPropOffset = new(2.611f, 42.849f, 70.586f, 0f, 0f, 71.30f);
                                break;
                            case 2: //interior back wall
                                tempPropOffset = new(4.881f, 42.099f, 70.586f, 0f, 0f, 160f);
                                break;
                        }

                        mapHoleProtectors[index] = CreateObject((int)model, tempPropOffset.X, tempPropOffset.Y, tempPropOffset.Z, false, false, true);
                        SetEntityRotation(mapHoleProtectors[index], tempPropOffset.Roll, tempPropOffset.Pitch, tempPropOffset.Yaw, 2, false);
                        FreezeEntityPosition(mapHoleProtectors[index], true);
                        SetEntityProofs(mapHoleProtectors[index], true, true, true, true, true, true, true, true);
                        SetEntityVisible(mapHoleProtectors[index], false, false);
                        SetEntityInvincible(mapHoleProtectors[index], true);
                        SetEntityDynamic(mapHoleProtectors[index], false);
                    }
                    return false;
                }
            }
            return true;
        }

        private static bool IsThereAPropertyToBuy()
        {
            for (int i = 0; i < Properties[(int)CurrentPropertyID].Building.NumProperties; i++)
            {
                if (!PlayerCache.Character.Properties.Any(x => x.ID == (int)Properties[(int)CurrentPropertyID].Building.PropertiesInBuilding[i]) /* !IsPropertySaleBlockedByTunables*/)
                    return true;
            }
            return false;
        }

        private static void PlayEnterGarageOpeningSound()
        {
            int iSoundId = GetSoundId();
            PlaySoundFrontend(iSoundId, "GARAGE_DOOR_SCRIPTED_CLOSE", "", true);
            SetVariableOnSound(iSoundId, "hold", 2.25f);
        }

        private static void CleanupFadedOutGarageCarEnter(bool bIgnoreStageCheck)
        {
            if (bIgnoreStageCheck
                || iRunCarEntryFadeStage > FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT
                && iRunCarEntryFadeStage < FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE)
            {
                iPedsInCar = 0;
                SetPlayerControl(PlayerId(), true, 0);
                CutsceneHelper.CleanupMPCutscene(true);
                if (IsAudioSceneActive("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene"))
                    StopAudioScene("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene");
                bCleanupFakeGarageEnter = false;
                ResetFakeGarageCarEnterCutscene(true);
                ResetToEntranceToPropertyStage();
            }
        }
        private static bool RunFadedOutGarageCarEnter()
        {
            bool bRun = false;
            Vehicle vehPlayer = null;
            if (iRunCarEntryFadeStage <= FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START)
            {
                if (PlayerCache.MyPed.IsInVehicle())
                {
                    vehPlayer = PlayerCache.MyPed.CurrentVehicle;
                    if (vehPlayer.IsDriveable)
                    {
                        if (NetworkHasControlOfEntity(vehPlayer.Handle))
                        {
                            SetEntityCanBeDamaged(vehPlayer.Handle, false);
                        }
                        bRun = true;
                    }
                }
            }
            else bRun = true;

            if (bRun)
            {
                ForceUndermapForEntry(1);
                if (iRunCarEntryFadeStage > FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START)
                    HideHudAndRadarThisFrame();
                switch (iRunCarEntryFadeStage)
                {
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT:
                        iRunCarEntryFadeStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START;
                        iGarageCutTimer = GetGameTimer();
                        iFadeDelayTimer = 0;
                        DoScreenFadeOut(500);
                        SetPlayerControl(PlayerId(), false, 0);
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START:
                        if (IsScreenFadedOut())
                        {
                            // TODO: set stateBAG in garage
                            if (iFadeDelayTimer == 0)
                                iFadeDelayTimer = GetGameTimer();
                            if (!Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage))
                            {
                                if (GetGameTimer() - iFadeDelayTimer > 250)
                                {
                                    if (PlayerCache.MyPed.IsInVehicle())
                                    {
                                        int vehFadeOut = PlayerCache.MyPed.CurrentVehicle.Handle;
                                        if (GetPedInVehicleSeat(vehFadeOut, -1) == PlayerPedId())
                                        {
                                            Functions.FadeEntity(new Vehicle(vehFadeOut), false, true, true);
                                            SetVehicleSilent(vehFadeOut, false);
                                            Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage);
                                        }
                                    }
                                    else
                                    {
                                        Functions.FadeEntity(PlayerCache.MyPed, false, true, true);
                                        Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage);
                                    }
                                }
                                else return false;
                            }
                            CutsceneHelper.MakePlayerSafeForMPCutscene(false, false, true, true);

                            iGarageCutsceneBitset = 0;
                            iGarageCutTimer = GetGameTimer();
                            iRunCarEntryFadeStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_RUNNING;
                            PlayEnterGarageOpeningSound();
                        }
                        else
                        {
                            if (!IsScreenFadingOut())
                                DoScreenFadeOut(0);
                        }
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_RUNNING:
                        CutsceneHelper.MakePlayerSafeForMPCutscene(false, false, true, true);
                        iRunCarEntryFadeStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE:
                        bCleanupFakeGarageEnter = true;
                        iPedsInCar = 0;
                        return true;
                }
            }
            else
            {
                CleanupFadedOutGarageCarEnter(true);
            }
            return false;
        }

        public static bool DoGarageCarEnterCutscene(bool resetCoords = false)
        {
            Vehicle veh;
            Ped ped = PlayerCache.MyPed;
            PropertyData property = Properties[(int)CurrentPropertyID];

            if (ped.IsInVehicle())
            {
                veh = ped.CurrentVehicle;
                if (((uint)veh.Model.Hash == (uint)VehicleHash.Apc && GetVehicleMod(veh.Handle, veh.Mods[VehicleModType.Roof].Index) >= 0)
                    || (uint)veh.Model.Hash == (uint)VehicleHash.HalfTrack
                    || (uint)veh.Model.Hash == (uint)VehicleHash.Insurgent3
                    || (uint)veh.Model.Hash == Functions.HashUint("CARACARA")
                    || (uint)veh.Model.Hash == Functions.HashUint("PATRIOT2")
                    || (uint)veh.Model.Hash == Functions.HashUint("OPPRESSOR2")
                    || (uint)veh.Model.Hash == Functions.HashUint("ZHABA")
                    || (uint)veh.Model.Hash == Functions.HashUint("YOUGA3")
                    || (uint)veh.Model.Hash == Functions.HashUint("SLUMTRACK"))
                {
                    if (RunFadedOutGarageCarEnter())
                    {
                        if (PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                        {

                        }
                        return true;
                    }
                    return false;
                }
            }

            if (PropertyFunctions.GetPropertySizeType(property.Index) == PropertySizeType.PROP_SIZE_TYPE_LARGE_APT
                && !PropertyFunctions.IsPropertyStiltApartment(CurrentPropertyID)
                || CurrentPropertyID == PropertiesEnum.PROPERTY_LOW_APT_7
                || PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
            {
                if (DoRealGarageCarEnterCutscene(resetCoords))
                {
                    if (PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                    {

                    }
                    return true;
                }
            }
            else
            {
                if (DoFakeGarageCarEnterThisCutscene())
                    return true;
            }
            return false;
        }

        private static void CleanupFakeGarageCarEnterThisCutscene(bool ignoreStageCheck)
        {
            if (ignoreStageCheck || fakeGarageCarEnterCutsceneStage > FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT
                && fakeGarageCarEnterCutsceneStage < FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE)
            {
                iPedsInCar = 0;
                SetPlayerControl(PlayerId(), true, 0);
                CutsceneHelper.CleanupMPCutscene(true);
                if (IsAudioSceneActive("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene"))
                    StopAudioScene("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene");
                bCleanupFakeGarageEnter = false;
                DeleteClonedEntitiesAndClearRequests();
                ResetFakeGarageCarEnterCutscene(true);
                ResetToEntranceToPropertyStage();
            }
        }
        private static bool DoFakeGarageCarEnterThisCutscene()
        {
            Ped playerPed = PlayerCache.MyPed;
            bool bRun = false;
            Vehicle vehPlayer = null;
            if (fakeGarageCarEnterCutsceneStage <= FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START)
            {
                if (playerPed.IsInVehicle())
                {
                    vehPlayer = playerPed.CurrentVehicle;
                    if (vehPlayer.IsDriveable)
                    {
                        if (NetworkHasControlOfEntity(vehPlayer.Handle))
                        {
                            SetEntityCanBeDamaged(vehPlayer.Handle, false);
                        }

                        if (fakeGarageCarEnterCutsceneStage == FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT)
                        {
                            GetMPFakeGarageDriveData(ref fakeGarageDriveData, PropertyFunctions.GetPropertyBuilding(CurrentPropertyID));
                        }
                        bRun = true;
                    }
                }
            }
            else bRun = true;

            if (bRun)
            {
                ForceUndermapForEntry(1);
                for (int i = 0; i < 9; i++)
                {
                    if (DoesEntityExist(pedFakeGarageEnter[i]) && !IsPedInjured(pedFakeGarageEnter[i]))
                    {
                        SetPedConfigFlag(pedFakeGarageEnter[i], 380, true); // PCF_DisableAutoEquipHelmetsInBikes
                        SetPedResetFlag(pedFakeGarageEnter[i], (int)PedResetFlags.PRF_PreventGoingIntoShuntInVehicleState, true);
                    }
                }
                if (fakeGarageCarEnterCutsceneStage > FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START)
                    HideHudAndRadarThisFrame();
                switch (fakeGarageCarEnterCutsceneStage)
                {
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_INIT:
                        ClearBit(ref iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse);
                        if (Functions.IsHeadingAcceptableCorrected(vehPlayer.Heading, Properties[(int)CurrentPropertyID].Entrance[iEntrancePlayerIsUsing].locateDetails.EnterHeading - 180, 45f))
                        {
                            Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse);
                        }

                        //clones
                        CutsceneHelper.CreateCutsceneVehicleClone(ref vehFakeGarageEnter, vehPlayer, fakeGarageDriveData.vStartPoint, fakeGarageDriveData.vStartRotation.Z);
                        vehFakeGarageEnter.LockStatus = VehicleLockStatus.Unlocked;
                        SetVehicleOnGroundProperly(vehFakeGarageEnter.Handle);
                        SetEntityCollision(vehFakeGarageEnter.Handle, false, true);
                        vehFakeGarageEnter.IsPositionFrozen = true;
                        Vector3 vFakeGaragePlayerCarCoords = vehFakeGarageEnter.Position;
                        fFakeVehicleOffset = vFakeGaragePlayerCarCoords.Z - fakeGarageDriveData.vStartPoint.Z;
                        vehFakeGarageEnter.Position = fakeGarageDriveData.vStartPoint + new Vector3(0, 0, -10f);
                        int pedTemp;
                        uint modelTemp;
                        iPedsInCar = 0;
                        for (int i = -1; i < 9; i++)
                        {
                            if (i < GetVehicleModelNumberOfSeats((uint)vehPlayer.Model.Hash))
                            {
                                if (!vehPlayer.IsSeatFree((VehicleSeat)i))
                                {
                                    pedTemp = vehPlayer.GetPedOnSeat((VehicleSeat)i).Handle;
                                    if (DoesEntityExist(pedTemp))
                                    {
                                        modelTemp = (uint)GetEntityModel(pedTemp);
                                        Vector3 pos = GetEntityCoords(pedTemp, false) + new Vector3(0, 0, -10f);
                                        if (modelTemp != (uint)PedHash.FreemodeFemale01)
                                            pedFakeGarageEnter[iPedsInCar] = CreatePed(4, modelTemp, pos.X, pos.Y, pos.Z, GetEntityHeading(pedTemp), false, false);
                                        else
                                            pedFakeGarageEnter[iPedsInCar] = CreatePed(5, modelTemp, pos.X, pos.Y, pos.Z, GetEntityHeading(pedTemp), false, false);
                                        ClonePedToTarget(pedTemp, pedFakeGarageEnter[iPedsInCar]);
                                        SetPedConfigFlag(pedFakeGarageEnter[iPedsInCar], 380, true);
                                        TaskEnterVehicle(pedFakeGarageEnter[iPedsInCar], vehFakeGarageEnter.Handle, 1, i, 1.0f, 16, 0);
                                        iPedsInCar++;
                                    }
                                }
                            }
                        }
                        if (vehFakeGarageEnter != null && vehFakeGarageEnter.IsDriveable)
                        {
                            vehFakeGarageEnter.AreLightsOn = true;
                            vehFakeGarageEnter.IsSirenActive = false;
                            vehFakeGarageEnter.AreHighBeamsOn = true;
                        }
                        fakeGarageCarEnterCutsceneStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START;
                        iGarageCutTimer = GetGameTimer();
                        iFadeDelayTimer = 0;
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_START:
                        if (GetGameTimer() - iGarageCutTimer < 5000)
                        {
                            for (int i = 0; i < iPedsInCar; i++)
                            {
                                if (DoesEntityExist(pedFakeGarageEnter[i]))
                                {
                                    if (!IsPedInjured(pedFakeGarageEnter[i]))
                                    {
                                        if (!HaveAllStreamingRequestsCompleted(pedFakeGarageEnter[i]))
                                            return false;
                                        if (!HasPedHeadBlendFinished(pedFakeGarageEnter[i]))
                                            return false;
                                    }
                                }
                            }
                        }
                        //TODO: SET THAT WE ARE IN GARAGE
                        if (iFadeDelayTimer == 0)
                            iFadeDelayTimer = GetGameTimer();
                        if (!Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage))
                        {
                            if (playerPed.IsInVehicle())
                            {
                                Vehicle vehFadeOut = playerPed.CurrentVehicle;
                                if (vehFadeOut.Driver == playerPed)
                                {
                                    Functions.FadeEntity(vehFadeOut, false, true, true);
                                    vehFadeOut.IsSirenActive = true;
                                    Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage);
                                }
                            }
                            else
                            {
                                Functions.FadeEntity(playerPed, false, true, true);
                                Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage);
                            }
                        }
                        else
                            return false;

                        SetPlayerControl(PlayerId(), false, 0);
                        CutsceneHelper.MakePlayerSafeForMPCutscene(false, false, true, true);
                        CutsceneHelper.StartMPCutscene(true);
                        iGarageCutsceneBitset = 0;
                        iGarageCutTimer = GetGameTimer();
                        if (DoesCamExist(camGarageCutscene0))
                            DestroyCam(camGarageCutscene0, false);
                        camGarageCutscene0 = CreateCamera(Functions.HashUint("DEFAULT_SCRIPTED_CAMERA"), true);

                        SetCamParams(camGarageCutscene0,
                            fakeGarageDriveData.vCamCoord1.X, fakeGarageDriveData.vCamCoord1.Y, fakeGarageDriveData.vCamCoord1.Z,
                            fakeGarageDriveData.vCamRot1.X, fakeGarageDriveData.vCamRot1.Y, fakeGarageDriveData.vCamRot1.Z,
                            fakeGarageDriveData.fCamFov1, 0, 1, 1, 2);

                        if (fakeGarageDriveData.vCamCoord2 != Vector3.Zero)
                        {
                            SetCamParams(camGarageCutscene0,
                                fakeGarageDriveData.vCamCoord2.X, fakeGarageDriveData.vCamCoord2.Y, fakeGarageDriveData.vCamCoord2.Z,
                                fakeGarageDriveData.vCamRot2.X, fakeGarageDriveData.vCamRot2.Y, fakeGarageDriveData.vCamRot2.Z,
                                fakeGarageDriveData.fCamFov2, fakeGarageDriveData.iCamDuration + 2000, fakeGarageDriveData.camGraphType, fakeGarageDriveData.camGraphType, 2);
                        }
                        SetCamFarClip(camGarageCutscene0, 1000f);
                        ShakeCam(camGarageCutscene0, "HAND_SHAKE", fakeGarageDriveData.fCamShake);
                        RenderScriptCams(true, false, 3000, true, false);
                        fakeGarageCarEnterCutsceneStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_RUNNING;
                        if (vehFakeGarageEnter != null && vehFakeGarageEnter.Exists())
                        {
                            if (vehFakeGarageEnter.IsDriveable)
                            {
                                vehFakeGarageEnter.PositionNoOffset = GetInterpPointVector(fakeGarageDriveData.vStartPoint + new Vector3(0.0f, 0.0f, fFakeVehicleOffset),
                                    fakeGarageDriveData.vEndPoint + new Vector3(0.0f, 0.0f, fFakeVehicleOffset),
                                    iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                    MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                if (Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse))
                                    vehFakeGarageEnter.Rotation = GetInterpPointVector(new(0.0f - fakeGarageDriveData.vStartRotation.X, 0.0f - fakeGarageDriveData.vStartRotation.Y, (fakeGarageDriveData.vStartRotation.Z + 180.0f)),
                                        new((0.0f - fakeGarageDriveData.vEndRotation.X), 0.0f - fakeGarageDriveData.vEndRotation.Y, fakeGarageDriveData.vEndRotation.Z + 180.0f),
                                        iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                        MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                else
                                    vehFakeGarageEnter.Rotation = GetInterpPointVector(fakeGarageDriveData.vStartRotation,
                                        fakeGarageDriveData.vEndRotation,
                                        iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                        MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                SetEntityCollision(vehFakeGarageEnter.Handle, false, true);
                                vehFakeGarageEnter.IsPositionFrozen = true;
                            }
                        }
                        if (PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
                        {
                            if (!IsAudioSceneActive("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene"))
                                StartAudioScene("DLC_Biker_Clubhouse_Enter_In_Vehicle_Scene");
                        }
                        PlayEnterGarageOpeningSound();
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_RUNNING:
                        if (!IsCamRendering(camGarageCutscene0))
                        {
                            CutsceneHelper.MakePlayerSafeForMPCutscene(false, false, true, true);
                            RenderScriptCams(true, false, 3000, true, false);
                        }
                        if (vehFakeGarageEnter != null && vehFakeGarageEnter.Exists())
                        {
                            if (vehFakeGarageEnter.IsDriveable)
                            {
                                vehFakeGarageEnter.PositionNoOffset = GetInterpPointVector(fakeGarageDriveData.vStartPoint + new Vector3(0.0f, 0.0f, fFakeVehicleOffset),
                                    fakeGarageDriveData.vEndPoint + new Vector3(0.0f, 0.0f, fFakeVehicleOffset),
                                    iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                    MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                if (Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse))
                                    vehFakeGarageEnter.Rotation = GetInterpPointVector(new(0.0f - fakeGarageDriveData.vStartRotation.X, 0.0f - fakeGarageDriveData.vStartRotation.Y, (fakeGarageDriveData.vStartRotation.Z + 180.0f)),
                                        new((0.0f - fakeGarageDriveData.vEndRotation.X), 0.0f - fakeGarageDriveData.vEndRotation.Y, fakeGarageDriveData.vEndRotation.Z + 180.0f),
                                        iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                        MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                else
                                    vehFakeGarageEnter.Rotation = GetInterpPointVector(fakeGarageDriveData.vStartRotation,
                                        fakeGarageDriveData.vEndRotation,
                                        iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration,
                                        MathUtil.Clamp(GetGameTimer(), iGarageCutTimer, iGarageCutTimer + fakeGarageDriveData.fDuration));
                                SetEntityCollision(vehFakeGarageEnter.Handle, false, true);
                                vehFakeGarageEnter.IsPositionFrozen = true;
                            }
                            if (GetGameTimer() > iGarageCutTimer + fakeGarageDriveData.fDuration
                                && GetGameTimer() > iGarageCutTimer + fakeGarageDriveData.iCamDuration + 2600)
                            {
                                fakeGarageCarEnterCutsceneStage = FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                            }
                        }
                        break;
                    case FAKE_GARAGE_CAR_ENTER_CUTSCENE_STAGE.FAKE_GARAGE_CAR_ENTER_CUTSCENE_COMPLETE:
                        bCleanupFakeGarageEnter = true;
                        if (DoesEntityExist(vehCrateGarageEnter))
                            DeleteObject(ref vehCrateGarageEnter);
                        if (vehFakeGarageEnter != null && vehFakeGarageEnter.Exists())
                            vehFakeGarageEnter.Delete();
                        for (int i = 0; i < pedFakeGarageEnter.Length; i++)
                        {
                            if (DoesEntityExist(pedFakeGarageEnter[i]))
                                DeletePed(ref pedFakeGarageEnter[i]);
                        }
                        iPedsInCar = 0;
                        return true;
                }
            }
            else
            {
                CleanupFakeGarageCarEnterThisCutscene(true);
            }
            return false;
        }

        public static bool DoRealGarageCarEnterCutscene(bool bResetCoords = false)
        {
            STRUCT_DriveIn scene = new();
            if (!DriveIntoGarageHelper.Get_DriveIn(PropertyFunctions.GetPropertyBuilding(CurrentPropertyID), ref scene))
            {
                return true;
            }

            if (CurrentPropertyID == PropertiesEnum.PROPERTY_LOW_APT_7)
                DisableOcclusionThisFrame();
            if (CurrentPropertyID == PropertiesEnum.PROPERTY_HIGH_APT_14 || CurrentPropertyID == PropertiesEnum.PROPERTY_HIGH_APT_15)
            {
                createFakeBuilding6GarageObject();
            }
            if (DoGarageCarEnterThisCutscene(bResetCoords, scene))
            {
                if (DoesEntityExist(fakeBuilding6GarageObj))
                    DeleteObject(ref fakeBuilding6GarageObj);
                return true;
            }
            return false;
        }
        private static async void createFakeBuilding6GarageObject()
        {
            float fBUILDING_6_GARAGE_EXTRA_Z = 1.2f;
            uint fakeBuilding6GarageModel = Functions.HashUint("PROP_BH1_08_MP_GAR");
            RequestModel(fakeBuilding6GarageModel);
            while (!HasModelLoaded(fakeBuilding6GarageModel)) await BaseScript.Delay(0);
            if (fBUILDING_6_GARAGE_EXTRA_Z == 1.2f)
                fakeBuilding6GarageObj = CreateObject((int)fakeBuilding6GarageModel, -878.027f, -359.452f, -36.249f, false, false, true);
            else
            {
                Vector3 pos = new Vector3(-878.027f, -359.452f, 36.249f) + new Vector3(0, 0, fBUILDING_6_GARAGE_EXTRA_Z);
                fakeBuilding6GarageObj = CreateObject((int)fakeBuilding6GarageModel, -878.027f, -359.452f, 36.249f, false, false, true);
            }
            SetEntityRotation(fakeBuilding6GarageObj, 0, 0, 26.88f, 2, false);
            FreezeEntityPosition(fakeBuilding6GarageObj, true);
            SetEntityCollision(fakeBuilding6GarageObj, false, true);
            SetModelAsNoLongerNeeded(fakeBuilding6GarageModel);
        }

        private static bool DoGarageCarEnterThisCutscene(bool resetCoords, STRUCT_DriveIn scene)
        {
            PropertyData property = Properties[(int)CurrentPropertyID];
            Ped ped = PlayerCache.MyPed;
            Vehicle thisVehicle = null;
            bool bFadeWaitingForPlayers = false;
            int pedTemp, pedTemp2;
            uint modelTemp;
            int i;

            /*

             insert code check for heist here

             */
            if (garageCarEnterCutStage > GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT)
            {
                if (ped.IsInVehicle())
                {
                    thisVehicle = ped.CurrentVehicle;
                    if (thisVehicle.IsDriveable)
                    {
                        if (thisVehicle.Driver == ped)
                        {
                            for (i = -1; i <= 8; i++)
                            {
                                if (i < GetVehicleModelNumberOfSeats((uint)thisVehicle.Model.Hash))
                                {
                                    Ped pedSeat;
                                    Player playerSeat;
                                    if (!thisVehicle.IsSeatFree((VehicleSeat)i))
                                    {
                                        pedSeat = thisVehicle.GetPedOnSeat((VehicleSeat)i);
                                        if (!pedSeat.IsInjured)
                                        {
                                            if (pedSeat.IsPlayer)
                                            {
                                                playerSeat = new Player(NetworkGetPlayerIndexFromPed(pedSeat.Handle));
                                                if (playerSeat.Handle != PlayerId())
                                                {
                                                    bFadeWaitingForPlayers = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (!bFadeWaitingForPlayers)
                            {
                                Functions.FadeEntity(thisVehicle, true, true);
                                thisVehicle.IsSirenActive = false;
                            }
                        }
                    }
                }
            }
            else if (garageCarEnterCutStage > GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_INIT)
            {
                if (ped.IsInVehicle())
                {
                    thisVehicle = ped.CurrentVehicle;
                    if (thisVehicle.IsDriveable)
                    {
                        if (NetworkHasControlOfEntity(thisVehicle.Handle))
                        {
                            thisVehicle.CanBeVisiblyDamaged = false;
                        }
                    }
                }
            }
            if (garageCarEnterCutStage < GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR)
                Function.Call((Hash)0x6868e2852ae71199); // DISABLE_HDTEX_THIS_FRAME
            if (garageCarEnterCutStage > GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT)
                HideHudAndRadarThisFrame();

            for (i = 0; i < 9; i++)
            {
                if (DoesEntityExist(pedFakeGarageEnter[iPedsInCar]))
                {
                    SetPedConfigFlag(pedFakeGarageEnter[iPedsInCar], 380, true);
                }
            }

            float fDistance = 0;
            switch (garageCarEnterCutStage)
            {
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_INIT:
                    if (ped.IsInVehicle())
                    {
                        thisVehicle = ped.CurrentVehicle;
                        if (thisVehicle.IsDriveable)
                        {
                            //Heist_Veh_ID to be handled // TODO:
                            ClearBit(ref iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse);
                            if (Functions.IsHeadingAcceptableCorrected(thisVehicle.Heading, property.Entrance[iEntrancePlayerIsUsing].locateDetails.EnterHeading, 45f))
                            {
                                Functions.SetBit(ref iLocalBS2, (int)LOCAL_BS2.FakeGarageReverse);
                            }
                            CutsceneHelper.CreateCutsceneVehicleClone(ref vehFakeGarageEnter, thisVehicle, thisVehicle.Position - new Vector3(0, 0, 20f), thisVehicle.Heading);
                            vehFakeGarageEnter.LockStatus = VehicleLockStatus.Unlocked;
                            vehFakeGarageEnter.CanBeVisiblyDamaged = false;
                            int iPedsInCar = 0;
                            for (i = -1; i <= 8; i++)
                            {
                                if (i < GetVehicleModelNumberOfSeats((uint)thisVehicle.Model.Hash))
                                {
                                    if (!thisVehicle.IsSeatFree((VehicleSeat)i))
                                    {
                                        pedTemp = GetPedInVehicleSeat(thisVehicle.Handle, i);
                                        if (DoesEntityExist(pedTemp))
                                        {
                                            modelTemp = (uint)GetEntityModel(pedTemp);

                                            Vector3 pos = GetEntityCoords(pedTemp, true) + new Vector3(0, 0, -10);
                                            if (IsPedMale(pedTemp))
                                                pedFakeGarageEnter[iPedsInCar] = CreatePed(4, modelTemp, pos.X, pos.Y, pos.Z, GetEntityHeading(pedTemp), false, false);
                                            else
                                                pedFakeGarageEnter[iPedsInCar] = CreatePed(5, modelTemp, pos.X, pos.Y, pos.Z, GetEntityHeading(pedTemp), false, false);
                                            ClonePedToTarget(pedTemp, pedFakeGarageEnter[iPedsInCar]);
                                            SetPedConfigFlag(pedFakeGarageEnter[iPedsInCar], 380, true);
                                            TaskEnterVehicle(pedFakeGarageEnter[iPedsInCar], vehFakeGarageEnter.Handle, 1, i, 1.0f, 16, 0);
                                            iPedsInCar++;
                                        }
                                    }
                                }
                            }
                            if (vehFakeGarageEnter.IsDriveable)
                            {
                                vehFakeGarageEnter.AreLightsOn = true;
                                vehFakeGarageEnter.IsSirenActive = false;
                                if (thisVehicle.AreHighBeamsOn)
                                {
                                    vehFakeGarageEnter.AreHighBeamsOn = true;
                                }
                            }
                            garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_LOAD_CUT;
                            StartAudioScene("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE");
                        }
                        else
                        {
                            ResetGarageCarEnterCutscene(12, true);
                            ResetToEntranceToPropertyStage();
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_LOAD_CUT:
                    thisVehicle = ped.CurrentVehicle;
                    if (thisVehicle.IsDriveable)
                    {
                        /*
                        if (thisVehicle.State["Heist_Veh_ID"])
                        {
                            // handle heist veh
                        }
                        */
                    }
                    if (DoesEntityExist(pedFakeGarageEnter[0]))
                    {
                        if (!IsPedInjured(pedFakeGarageEnter[0]))
                        {
                            if (!HaveAllStreamingRequestsCompleted(pedFakeGarageEnter[0]) || !HasPedHeadBlendFinished(pedFakeGarageEnter[0]))
                                return false;
                        }
                    }
                    SetLocalPlayerVisibleInCutscene(false, true);
                    NetworkSetInMpCutscene(true, true);
                    garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT;
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_TRIGGER_CUT:
                    //TODO: CHECK FOR HEIST VEHICLE
                    if (ped.IsInVehicle())
                    {
                        thisVehicle = ped.CurrentVehicle;
                        if (thisVehicle.IsDriveable)
                        {
                            if (NetworkHasControlOfEntity(thisVehicle.Handle))
                            {
                                SetEntityCanBeDamaged(thisVehicle.Handle, false);
                            }
                            CutsceneHelper.StartMPCutscene(true);
                            Functions.SetBit(ref entryCutData.iBS, (int)ENTRY_CS_BS.ENTRY_CS_BS_STARTED_MP_CUTSCENE);
                            ClearBit(ref iLocalBS2, (int)LOCAL_BS2.bCarEntryAborted);
                            SetPlayerControl(PlayerId(), false, 0);
                            iGarageCutsceneBitset = 0;
                            iGarageCutTimer = GetGameTimer();
                            if (vehFakeGarageEnter.IsDriveable)
                            {
                                vehFakeGarageEnter.Position = scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos;
                                vehFakeGarageEnter.Heading = scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot;
                                vehFakeGarageEnter.PlaceOnGround();
                                if (DoesEntityExist(fakeBuilding6GarageObj))
                                {
                                    SetEntityCoords(fakeBuilding6GarageObj, -878.027f, -359.452f, 36.249f + 2.5f, false, false, false, false);
                                    SetEntityRotation(fakeBuilding6GarageObj, 0, 0, 26.88f, 2, false);
                                    FreezeEntityPosition(fakeBuilding6GarageObj, true);
                                    SetEntityCollision(fakeBuilding6GarageObj, false, true);
                                }
                                if (iFadeDelayTimer == 0)
                                    iFadeDelayTimer = GetGameTimer();
                                CameraHelper.ExecutePan(ref scene.mPans[(int)DriveInPans.DriveIn_PAN_descent], ref camGarageCutscene0, ref camGarageCutscene1);
                                SetCamFarClip(camGarageCutscene0, 1000);
                                SetCamFarClip(camGarageCutscene1, 1000);
                                garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR;
                                if (PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                                {
                                    if (!IsAudioSceneActive("DLC_IE_Garage_Elevator_Enter_Scene"))
                                        StartAudioScene("DLC_IE_Garage_Elevator_Enter_Scene");

                                }
                            }
                            else
                                ResetGarageCarEnterCutscene(1, true);
                        }
                        else
                        {
                            if (IsVehicleDriveable(warpInControl.vehID, false))
                            {
                                if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 0 //WAITING_TO_START_TASK
                                    && GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 1) //PERFORMING_TASK
                                {
                                    TaskEnterVehicle(PlayerPedId(), warpInControl.vehID, 1, -1, 1f, 16, 0);
                                }
                            }
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_OPEN_DOOR:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_SHORT)
                    {
                        garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                    }
                    if (ped.IsInVehicle())
                    {
                        if (vehFakeGarageEnter.IsDriveable)
                        {
                            RequestGarageDoorOpen();
                            if (IsGarageDoorOpen())
                            {
                                if (!IsPedInjured(pedFakeGarageEnter[0]))
                                {
                                    TaskVehicleDriveToCoord(pedFakeGarageEnter[0], vehFakeGarageEnter.Handle,
                                        scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.X, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.Y, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.Z,
                                        5f, 0, (uint)vehFakeGarageEnter.Model.Hash, 262144, 1f, 100f);
                                }
                                iGarageCutTimer = GetGameTimer();
                                Vehicle vehPlayer = PlayerCache.MyPed.CurrentVehicle;
                                if (vehPlayer != null && vehPlayer.Exists())
                                {
                                    PlaySoundFromEntity(-1, "Engine_Revs", vehPlayer.Handle, "DLC_HEISTS_GENERIC_SOUNDS", false, 0);
                                }
                                garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_INSIDE;
                            }
                            else
                            {
                                if (vehFakeGarageEnter.IsDriveable)
                                {
                                    if (!bWarpVeh)
                                    {
                                        Vector3 v1 = vehFakeGarageEnter.Position;
                                        Vector3 v2 = scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos;
                                        Vector3 vDiff = v2 - v1;
                                        float fOffHead = GetHeadingFromVector_2d(vDiff.X, vDiff.Y);
                                        if (!Functions.IsVehicleRoughlyFacingThisDirection(vehFakeGarageEnter.Handle, fOffHead))
                                        {
                                            vehFakeGarageEnter.Position = scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos;
                                            vehFakeGarageEnter.Heading = scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot;
                                            vehFakeGarageEnter.PlaceOnGround();
                                        }
                                        bWarpVeh = true;
                                    }
                                    if (IsPedInjured(pedFakeGarageEnter[0]))
                                    {
                                        if (!Functions.IsTaskOngoing(pedFakeGarageEnter[0], "SCRIPT_TASK_VEHICLE_DRIVE_TO_COORD"))
                                        {
                                            Vector3 vFrontTopLeft = new(), vFrontTopRight = new(), vBackTopLeft = new(), vBackTopRight = new();
                                            Functions.Determine4TopVectorsOfModelBoxInWorldCoords(vehFakeGarageEnter.Handle, (uint)vehFakeGarageEnter.Model.Hash, ref vFrontTopLeft, ref vFrontTopRight, ref vBackTopLeft, ref vBackTopRight);
                                            Vector3 pos0 = scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0;
                                            Vector3 pos1 = scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1;
                                            if (pos0.Z > pos1.Z)
                                                pos0.Z = pos1.Z;
                                            else
                                                pos1.Z = pos0.Z;

                                            if (IsPointInAngledArea(vFrontTopLeft.X, vFrontTopLeft.Y, vFrontTopLeft.Z, pos0.X, pos0.Y, pos0.Z,
                                                pos1.X, pos1.Y, pos1.Z + scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight,
                                                scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth, false, true)
                                                || IsPointInAngledArea(vFrontTopRight.X, vFrontTopRight.Y, vFrontTopRight.Z, pos0.X, pos0.Y, pos0.Z,
                                                pos1.X, pos1.Y, pos1.Z + scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight,
                                                scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth, false, true)
                                                || IsPointInAngledArea(vBackTopLeft.X, vBackTopLeft.Y, vBackTopLeft.Z, pos0.X, pos0.Y, pos0.Z,
                                                pos1.X, pos1.Y, pos1.Z + scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight,
                                                scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth, false, true)
                                                || IsPointInAngledArea(vBackTopRight.X, vBackTopRight.Y, vBackTopRight.Z, pos0.X, pos0.Y, pos0.Z,
                                                pos1.X, pos1.Y, pos1.Z + scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight,
                                                scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth, false, true))
                                            {
                                                TaskVehicleDriveToCoord(pedFakeGarageEnter[0], vehFakeGarageEnter.Handle,
                                                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.X, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.Y, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos.Z,
                                                    5f, 2, (uint)vehFakeGarageEnter.Model.Hash, 262144, 1f, 100f);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ResetGarageCarEnterCutscene(3, true);
                        }
                    }
                    else
                    {
                        if (IsVehicleDriveable(warpInControl.vehID, false))
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 0 //WAITING_TO_START_TASK
                                && GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 1) //PERFORMING_TASK
                            {
                                TaskEnterVehicle(PlayerPedId(), warpInControl.vehID, 1, -1, 1f, 16, 0);
                            }
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_INSIDE:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_LONG)
                    {
                        garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                    }
                    if (vehFakeGarageEnter.IsDriveable)
                    {
                        fDistance = 16;
                        if (vehFakeGarageEnter.Model.Hash == Functions.HashInt("VIGILANTE"))
                        {
                            fDistance = 24;
                        }
                        if (Vector3.DistanceSquared(vehFakeGarageEnter.Position, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos) < fDistance)
                        {
                            if (!IsPedInjured(pedFakeGarageEnter[0]))
                            {
                                TaskVehicleDriveToCoord(pedFakeGarageEnter[0], vehFakeGarageEnter.Handle,
                                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos.X, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos.Y, scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos.Z,
                                    5f, 0, (uint)vehFakeGarageEnter.Model.Hash, 262144, 1f, 100f);
                            }
                            iGarageCutTimer = GetGameTimer();
                            garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR;
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_LONG)
                    {
                        if (vehFakeGarageEnter.IsDriveable)
                        {
                            RequestGarageDoorClose();
                            if (IsGarageDoorClosed())
                            {
                                iGarageCutTimer = GetGameTimer();
                                garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_beat;
                            }
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_WAIT_FOR_CLOSE_DOOR_beat:
                    if (GetGameTimer() - iGarageCutTimer > GARAGE_CUT_SKIP_TIME_BEAT)
                    {
                        if (!PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                            garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                        else
                        {
                            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3)
                            {
                                iGarageCutTimer = GetGameTimer();
                                garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_OFFICE_GARAGE_PAUSE;
                            }
                            else
                            {
                                garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                            }
                        }
                    }
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_OFFICE_GARAGE_PAUSE:
                    if (GetGameTimer() - iGarageCutTimer > 1000)
                        garageCarEnterCutStage = GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE;
                    break;
                case GARAGE_CAR_ENTER_CUTSCENE_STAGE.GARAGE_CAR_ENTER_CUTSCENE_COMPLETE:
                    if (!PropertyFunctions.IsPropertyOfficeGarage(CurrentPropertyID))
                    {
                        DeleteClonedEntitiesAndClearRequests();
                    }
                    StopAudioScene("DLC_MPHEIST_DRIVE_INTO_GARAGE_SCENE");
                    return true;
            }
            return false;
        }

        private static bool IsDistanceToOfficeGarageOk(float fDistance)
        {
            return CurrentPropertyID switch
            {
                PropertiesEnum.PROPERTY_OFFICE_1 => fDistance <= 70f,
                PropertiesEnum.PROPERTY_OFFICE_2_BASE => fDistance <= 55f,
                PropertiesEnum.PROPERTY_OFFICE_3 => fDistance <= 100f,
                PropertiesEnum.PROPERTY_OFFICE_4 => fDistance <= 65f,
                _ => false,
            };
        }

        //SetLocalStage(Stage.STAGE_SETUP_FOR_USING_PROPERTY); for starting.. by foot only at the moment
        private static void LoopEntrances()
        {
            Ped playerPed = PlayerCache.MyPed;
            BuildingsEnum building = PropertyFunctions.GetPropertyBuilding(CurrentPropertyID);
            float fDistance;
            bool bAllowedInWithVehicle = false;
            bool bLocalPlayerOwnsPropertyInBuilding = true;//PlayerCache.Character.Properties.Any(x => PropertyFunctions.GetPropertyBuilding((PropertiesEnum)x.ID) == building); /*default false, for debug set to true*/

            PropertyData property = Properties[(int)CurrentPropertyID];
            if (!IsPlayerTeleportActive())
            {
                for (int i = 0; i < property.NumEntrances; i++)
                {
                    iEntrancePlayerIsUsing = i;
                    fDistance = Position.Distance(PlayerCache.MyClient.Position, property.Entrance[i].EntranceMarkerLoc);
                    if (fDistance <= 30f || (property.Entrance[i].Type == EntranceType.ENTRANCE_TYPE_GARAGE && IsDistanceToOfficeGarageOk(fDistance)))
                    {
                        DrawBuzzerLocate(i);
                        if (IsPlayerInBuzzerLocation(i))
                        {
                            // for now we handle only our... then we'll add code for friends/buzzer menu
                            if (bLocalPlayerOwnsPropertyInBuilding)
                            {
                                // handle buzzer?
                                // yes
                                if (Properties[(int)CurrentPropertyID].Entrance[i].Type == EntranceType.ENTRANCE_TYPE_HOUSE)
                                {
                                    CurrentPropertyID = property.Index;
                                    SetLocalStage(MainStage.STAGE_SETUP_FOR_USING_PROPERTY);
                                    break;
                                }
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            iEntrancePlayerIsUsing = i;
                            //We call the menu here
                            //if()

                        }
                    }
                    if (fDistance <= 10f
                    || (fDistance <= 30 && CurrentPropertyID == PropertiesEnum.PROPERTY_GARAGE_NEW_9)
                    || (fDistance <= 50 && CurrentPropertyID == PropertiesEnum.PROPERTY_OFFICE_1 && property.Entrance[i].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
                    || (fDistance <= 55 && CurrentPropertyID == PropertiesEnum.PROPERTY_OFFICE_2_BASE && property.Entrance[i].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
                    || (fDistance <= 100 && CurrentPropertyID == PropertiesEnum.PROPERTY_OFFICE_3 && property.Entrance[i].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
                    || (fDistance <= 65 && CurrentPropertyID == PropertiesEnum.PROPERTY_OFFICE_4 && property.Entrance[i].Type == EntranceType.ENTRANCE_TYPE_GARAGE))
                    {
                        iEntrancePlayerIsUsing = i;
                        if (bLocalPlayerOwnsPropertyInBuilding) //|| is generically allowed in
                        {
                            bAllowedInWithVehicle = bLocalPlayerOwnsPropertyInBuilding; // add checks for guests
                            bAllowedInWithVehicle = true;
                            if (playerPed.IsInVehicle())
                            {
                                /*
                                // check it's our vehicle by checking the state added to the vehicle on spawn
                                // TODO: ADD BETTER CHECKS.. MAYBE WITH STATEBAGS? OR DECORATORS?
                                if (playerPed.CurrentVehicle.GetState<int>("Owned_vehicle_owner") != PlayerCache.MyClient.Handle)
                                {
                                    // handle not allowed
                                }
                                */
                                //SetLocalStage(MainStage.STAGE_SETUP_FOR_USING_PROPERTY);
                            }
                            if (IsPlayerEnteringTheProperty(bAllowedInWithVehicle) && !IsPlayerInBuzzerLocation(iEntrancePlayerIsUsing))
                            {
                                // check we are not wanted or chased by cops or cops are near us
                                SetLocalStage(MainStage.STAGE_SETUP_FOR_USING_PROPERTY);
                                // here we do a check for the owned properties in building.. if we have more than 1 property (office..garage lv1, 2, 3) we have to choose..
                                // else is garave level 1 if we enter by car
                                // debug code below.. to be removed with the right checks about owned properties..
                                // DEBUG \\
                                if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID))
                                {
                                    if (playerPed.IsInVehicle())
                                    {
                                        CurrentPropertyID = GetPropertyIdForFirstOfficeGarageInBuilding(property.BuildingID);
                                    }
                                }
                                // DEBUG \\
                                break;
                            }
                        }
                    }
                    //Notifications.DrawText(0.35f, 0.75f + (0.025f * i), $"Distance:{fDistance}, type: {Properties[(int)CurrentPropertyID].Entrance[i].Type}");
                }
                //Notifications.DrawText(0.35f, 0.725f, $"iEntrancePlayerIsUsing:{iEntrancePlayerIsUsing}, type: {Properties[(int)CurrentPropertyID].Entrance[iEntrancePlayerIsUsing].Type}");
            }
        }

        private static PropertiesEnum GetPropertyIdForFirstOfficeGarageInBuilding(BuildingsEnum iBuilding)
        {
            BuildingRelated building = new();
            PropertyFunctions.GetBuildingProperties(ref building, iBuilding);
            for (int i = 0; i < building.NumProperties; i++)
            {
                if (PropertyFunctions.GetOfficeGarageBaseIdFromProperty(building.PropertiesInBuilding[i]) == PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1)
                    return building.PropertiesInBuilding[i];
            }
            return CurrentPropertyID;
        }

        private static void DrawBuzzerLocate(int iEntrance)
        {
            if (iLocalStage == MainStage.STAGE_ENTER_PROPERTY && PropertyFunctions.IsPropertyStiltApartment(CurrentPropertyID))
                return;
            Vector3 pos = Properties[(int)CurrentPropertyID].Entrance[iEntrance].BuzzerLoc;
            float h = 0;
            GetGroundZFor_3dCoord(pos.X, pos.Y, pos.Z + 0.5f, ref h, false);
            Vector3 scale = new(0.75f);
            pos.Z = h - 0.25f;

            switch (CurrentPropertyID)
            {
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                    if (iEntrance == 0)
                        pos.Y += 0.28f;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                    if (iEntrance == 0)
                    {
                        pos.Y -= 0.45f;
                        pos.X += 0.2f;
                        pos.Z -= 0.25f;
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                    if (iEntrance == 0)
                    {
                        pos.Y += 0.5f;
                        pos.X += 0.286f;
                        pos.Z -= 0.25f;
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    if (iEntrance == 0)
                    {
                        pos.Y += 0.07f;
                        pos.X += 0.11f;
                    }
                    else if (iEntrance == 1)
                    {
                        pos.Y -= 0.449f;
                        pos.X += 0.074f;
                        pos.Z += 0.3f;
                        scale = new(0.5f);
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                    if (iEntrance == 0)
                    {
                        pos.X -= 0.113f;
                        pos.Y += 0.1f;
                        pos.Z += 0.1f;
                        scale = new(0.65f);
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                    if (iEntrance == 0)
                    {
                        pos.X += 0.487f;
                        pos.Y -= 0.1f;
                    }
                    else if (iEntrance == 1)
                    {
                        pos.Y -= 0.562f;
                        pos.X += 0.45f;
                    }
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                    if (iEntrance == 2)
                    {
                        pos.X -= 0.1f;
                        pos.Y += 0.3f;
                    }
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3:
                    if (iEntrance == 2)
                    {
                        pos.X -= 0.3f;
                        pos.Y -= 0.5f;
                    }
                    break;
            }

            SColor markercol = SColor.HUD_Blue;
            DrawMarker(1, pos.X, pos.Y, pos.Z, 0, 0, 0, 0, 0, 0, scale.X, scale.Y, scale.Z, markercol.R, markercol.G, markercol.B, 255, false, false, 2, false, null, null, false);
        }

        static bool IsPlayerInBuzzerLocation(int iEntrance)
        {
            Vector3 vLocateSize = new(1, 1, 2);
            PropertyData apart = Properties[(int)CurrentPropertyID];
            if (apart.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_23)
            {
                vLocateSize = new(1.6f, 1.6f, 2);
            }
            if (apart.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_60 || apart.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_62)
            {
                vLocateSize = new(0.75f, 0.75f, 2);
            }
            if (apart.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_1 && apart.Entrance[iEntrance].Type == EntranceType.ENTRANCE_TYPE_HOUSE)
            {
                vLocateSize = new(1.6f, 1.6f, 2);
            }
            if (apart.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3 && apart.Entrance[iEntrance].Type == EntranceType.ENTRANCE_TYPE_HOUSE)
            {
                vLocateSize = new(1.6f, 1.6f, 2);
            }
            if ((apart.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1 || apart.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2
            || apart.BuildingID == BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3) && apart.Entrance[iEntrance].Type == EntranceType.ENTRANCE_TYPE_GARAGE)
            {
                vLocateSize = new(1.6f, 1.6f, 2);
            }

            if (!IsPlayerTeleportActive())
            {
                if ((apart.BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_3
                    && apart.Entrance[iEntrance].Type == EntranceType.ENTRANCE_TYPE_HOUSE
                    && IsEntityInAngledArea(PlayerPedId(), -1441.711182f, -543.508911f, 33.242393f, -1440.725586f, -544.946777f, 36.492393f, 1.750000f, false, false, 0))
                    || (apart.BuildingID == BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A
                    && apart.Entrance[iEntrance].Type == EntranceType.ENTRANCE_TYPE_GARAGE
                    && IsEntityInAngledArea(PlayerPedId(), -746.749756f, 601.368530f, 141.274338f, -747.467041f, 602.151794f, 143.575226f, 2.060000f, false, false, 0))
                    || ((apart.BuildingID != BuildingsEnum.MP_PROPERTY_BUILDING_3 || apart.Entrance[iEntrance].Type != EntranceType.ENTRANCE_TYPE_HOUSE)
                    && (apart.BuildingID != BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A || apart.Entrance[iEntrance].Type != EntranceType.ENTRANCE_TYPE_GARAGE)
                    && IsEntityAtCoord(PlayerPedId(), apart.Entrance[iEntrance].BuzzerLoc.X, apart.Entrance[iEntrance].BuzzerLoc.Y, apart.Entrance[iEntrance].BuzzerLoc.Z, vLocateSize.X, vLocateSize.Y, vLocateSize.Z, false, true, 1)))
                {
                    if (Functions.IsLocalPlayerEnteringOrExitingAVehicle())
                        return false;
                    if (Functions.IsPlayerGettingInOrOutOfVehicle(PlayerId()))
                        return false;
                    return true;
                }
            }
            return false;
        }


        public static bool IsPlayerDrivingIntoPropertyGarage(int theVehicle, uint theModel, ref bool reverseIn)
        {
            PropertyData apart = Properties[(int)CurrentPropertyID];
            Vector3 vFrontTopLeft = new(), vFrontTopRight = new(), vBackTopLeft = new(), vBackTopRight = new();
            Functions.Determine4TopVectorsOfModelBoxInWorldCoords(theVehicle, theModel, ref vFrontTopLeft, ref vFrontTopRight, ref vBackTopLeft, ref vBackTopRight);

            Vector3 vFrontBottomLeft = new(), vFrontBottomRight = new(), vBackBottomLeft = new(), vBackBottomRight = new();
            Functions.Determine4BottomVectorsOfModelBoxInWorldCoords(theVehicle, theModel, ref vFrontBottomLeft, ref vFrontBottomRight, ref vBackBottomLeft, ref vBackBottomRight);

            Vector3 vFrontMiddleLeft = GetInterpPointVector(vFrontBottomLeft, vFrontTopLeft, 0.0f, 1.0f, 0.5f);
            Vector3 vFrontMiddleRight = GetInterpPointVector(vFrontBottomRight, vFrontTopRight, 0.0f, 1.0f, 0.5f);
            Vector3 vBackMiddleLeft = GetInterpPointVector(vBackBottomLeft, vBackTopLeft, 0.0f, 1.0f, 0.5f);
            Vector3 vBackMiddleRight = GetInterpPointVector(vBackBottomRight, vBackTopRight, 0.0f, 1.0f, 0.5f);

            if (IsPointInAngledArea(vFrontMiddleLeft.X, vFrontMiddleLeft.Y, vFrontMiddleLeft.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Width, false, true)

            || IsPointInAngledArea(vFrontMiddleRight.X, vFrontMiddleRight.Y, vFrontMiddleRight.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Z,
                                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Width, false, true))
            {
                if (Functions.IsHeadingAcceptableCorrected(GetEntityHeading(theVehicle), apart.Entrance[iEntrancePlayerIsUsing].locateDetails.EnterHeading, 45))
                {
                    if (Functions.IsNpcInVehicle())
                    {
                        if (!IsHelpMessageBeingDisplayed())
                        {
                            if (PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("INV_VEH_GAR0_CH"));
                            else
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("INV_VEH_GAR0"));
                        }
                        return false;
                    }
                    reverseIn = false;
                    return true;
                }
            }
            else if (IsPointInAngledArea(vBackMiddleLeft.X, vBackMiddleLeft.Y, vBackMiddleLeft.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Width, false, true)
            || IsPointInAngledArea(vBackMiddleRight.X, vBackMiddleRight.Y, vBackMiddleRight.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.X, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Y, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2.Z,
                apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Width, false, true))
            {
                if (Functions.IsHeadingAcceptableCorrected(GetEntityHeading(theVehicle), apart.Entrance[iEntrancePlayerIsUsing].locateDetails.EnterHeading - 180, 45))
                {
                    if (Functions.IsNpcInVehicle())
                    {
                        if (!IsHelpMessageBeingDisplayed())
                        {
                            if (PropertyFunctions.IsPropertyClubhouse(CurrentPropertyID))
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("INV_VEH_GAR0_CH"));
                            else
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("INV_VEH_GAR0"));
                        }
                        return false;
                    }
                    reverseIn = true;
                    return true;
                }
            }
            return false;
        }

        public static bool IsPlayerEnteringTheProperty(bool bVehiclesValidForEntry)
        {
            Ped playerPed = PlayerCache.MyPed;
            int theVehicle;
            bool bReverseIn = false;
            int theDriver;
            PropertyData apart = Properties[(int)CurrentPropertyID];

            if (!IsPlayerTeleportActive() && !Functions.IsPlayerGettingInOrOutOfVehicle(PlayerId()))
            {
                if (PropertyFunctions.IsPropertyOffice(CurrentPropertyID) && apart.Entrance[iEntrancePlayerIsUsing].Type == EntranceType.ENTRANCE_TYPE_GARAGE
                    && PlayerCache.Character.Properties.Any(x => x.ID == (int)PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1))
                { return false; }
                if (playerPed.IsInVehicle() && apart.Entrance[iEntrancePlayerIsUsing].Type == EntranceType.ENTRANCE_TYPE_GARAGE && bVehiclesValidForEntry)
                {
                    theVehicle = playerPed.CurrentVehicle.Handle;
                    theDriver = playerPed.CurrentVehicle.Driver.Handle;
                    if (playerPed.Handle == theDriver)
                    {
                        uint model = (uint)GetEntityModel(theVehicle);
                        if (IsModelInCdimage(model))
                        {
                            if (IsPlayerDrivingIntoPropertyGarage(theVehicle, model, ref bReverseIn))
                            {
                                //TODO: CHECK IF THE VEHICLE IS YOURS OR ANOTHER PLAYER, YOU CANNOT ENTER WITH ANOTHER PLAYER'S VEHICLE UNLESS YOU'RE WITH HIM AS PASSENGER
                                //TODO: ALSO CHECK FOR THE VEHICLE AND THE PROPERTY.. A KHANJALI CAN'T ENTER AN APARTMENT GARAGE
                                // if both PRint_HELP("MP_CLU_PERSVO")
                                //if(notAlloed)
                                //else
                                Vector3 vVelocity = GetEntitySpeedVector(theVehicle, true);
                                if ((!bReverseIn && vVelocity.Y > 0) || bReverseIn && vVelocity.Y < 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (playerPed.IsInAngledArea(apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos1, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Pos2, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.Width))
                    {
                        // TODO: check for any reason why the player would not be allowed
                        /*
                            IF IS_LOCAL_PLAYER_IN_POSSESSION_OF_A_MISSION_CRITITCAL_ENTITY()
                            AND (mpProperties[iCurrentPropertyID].entrance[iEntrancePlayerIsUsing].iType != ENTRANCE_TYPE_HOUSE
                            OR NOT (SHOULD_BYPASS_CHECKS_FOR_ENTRY(FALSE)
                            AND mpProperties[iCurrentPropertyID].entrance[iEntrancePlayerIsUsing].iType = ENTRANCE_TYPE_HOUSE))
                            OR IS_PLAYER_BLOCKED_FROM_PROPERTY(FALSE, GET_PROPERTY_TYPE_FOR_IS_PLAYER_BLOCKED_FROM_PROPERTY(iCurrentPropertyID))
                            OR iNotAllowedReason != 0
                        {
                        }
                        else{
                        }
                        this below is in the else (player can enter)
                         */
                        if (Functions.IsHeadingAcceptableCorrected(playerPed.Heading, apart.Entrance[iEntrancePlayerIsUsing].locateDetails.EnterHeading, 30))
                        {
                            if (!Functions.IsPlayerGettingInOrOutOfVehicle(PlayerId()) && !Functions.IsLocalPlayerEnteringOrExitingAVehicle())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;

        }

        private static float GetInterpPointFloat(float fStartPos, float fEndPos, float fStartTime, float fEndTime, float fPointTime)
        {
            return (((fEndPos - fStartPos) / (fEndTime - fStartTime)) * (fPointTime - fStartTime)) + fStartPos;
        }

        private static Vector3 GetInterpPointVector(Vector3 vStartPos, Vector3 vEndPos, float fStartTime, float fEndTime, float fPointTime)
        {
            return new(GetInterpPointFloat(vStartPos.X, vEndPos.X, fStartTime, fEndTime, fPointTime), GetInterpPointFloat(vStartPos.Y, vEndPos.Y, fStartTime, fEndTime, fPointTime), GetInterpPointFloat(vStartPos.Z, vEndPos.Z, fStartTime, fEndTime, fPointTime));
        }

        private static void GetForSaleDetails(ref PropForSale forSaleDetils, BuildingsEnum iBuilding)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    forSaleDetails.locate.Pos1 = new(-787.989929f, 299.358978f, 84.383942f);
                    forSaleDetails.locate.Pos2 = new(-787.791382f, 297.495056f, 88.587593f);
                    forSaleDetails.locate.Width = 3.0f;
                    forSaleDetails.locate.EnterHeading = 4.6857f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-786.62f, 299.34f, 84.70f, 0.0f, 0.0f, 7.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    forSaleDetails.locate.Pos1 = new(-263.427032f, -977.441467f, 30.219301f);
                    forSaleDetails.locate.Pos2 = new(-262.310364f, -974.449219f, 31.219479f);
                    forSaleDetails.locate.Width = 3.0f;
                    forSaleDetails.locate.EnterHeading = 24.6447f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_02");
                    forSaleDetails.vProp = new(-262.6969f, -976.3912f, 30.2196f, 0.0f, 0.0f, -20.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    forSaleDetails.locate.Pos1 = new(-1438.366577f, -544.081909f, 33.742393f);
                    forSaleDetails.locate.Pos2 = new(-1437.262207f, -545.659973f, 36.742393f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 35.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1437.3145f, -543.6579f, 33.7424f, 0.0f, 0.0f, 35.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    forSaleDetails.locate.Pos1 = new(-923.904663f, -465.280365f, 36.111301f);
                    forSaleDetails.locate.Pos2 = new(-925.168518f, -465.960449f, 39.120045f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = -60.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-923.5200f, -466.3311f, 35.9673f, 0.0f, 0.0f, -60.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    forSaleDetails.locate.Pos1 = new(-54.195885f, -589.821838f, 35.396210f);
                    forSaleDetails.locate.Pos2 = new(-55.673012f, -589.277710f, 38.397793f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 70.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-53.9263f, -588.7011f, 35.2529f, 0.0f, 0.0f, 70.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    forSaleDetails.locate.Pos1 = new(-956.514221f, -402.813293f, 36.832603f);
                    forSaleDetails.locate.Pos2 = new(-957.761108f, -403.463776f, 39.834034f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = -62.5f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-956.1393f, -403.9353f, 36.7294f, 0.0f, 0.0f, -62.5f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    forSaleDetails.locate.Pos1 = new(-612.367493f, 25.004744f, 41.003834f);
                    forSaleDetails.locate.Pos2 = new(-612.372375f, 23.226894f, 43.964260f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = -62.5f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-611.2051f, 24.9482f, 40.8329f, 0.0f, 0.0f, 0.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    forSaleDetails.locate.Pos1 = new(270.922394f, -151.435516f, 62.396744f);
                    forSaleDetails.locate.Pos2 = new(269.256531f, -150.864319f, 65.909271f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 70.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(271.1721f, -150.2852f, 62.5341f, 0.0f, 0.0f, 70.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    forSaleDetails.locate.Pos1 = new(-1.850821f, 34.869568f, 69.674965f);
                    forSaleDetails.locate.Pos2 = new(-2.394848f, 33.385918f, 73.171623f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = -20.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-0.7718f, 34.3326f, 70.0917f, 0.0f, 0.0f, -20.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    forSaleDetails.locate.Pos1 = new(-10.847434f, 91.983421f, 76.314728f);
                    forSaleDetails.locate.Pos2 = new(-12.685419f, 92.663673f, 79.821358f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 70.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-10.6809f, 93.1954f, 76.5386f, 0.0f, 0.0f, 70.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    forSaleDetails.locate.Pos1 = new(-507.639435f, 111.952484f, 62.173340f);
                    forSaleDetails.locate.Pos2 = new(-509.113037f, 113.013084f, 65.368782f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 54.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-506.7909f, 112.7582f, 62.3125f, 0.0f, 0.0f, 54.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    forSaleDetails.locate.Pos1 = new(-201.070724f, 90.048210f, 68.051292f);
                    forSaleDetails.locate.Pos2 = new(-200.567734f, 91.867226f, 71.569321f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = -15.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-199.9104f, 89.8473f, 68.3045f, 0.0f, 0.0f, -15.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    forSaleDetails.locate.Pos1 = new(-635.007446f, 162.255402f, 57.960247f);
                    forSaleDetails.locate.Pos2 = new(-633.068542f, 162.240250f, 61.742886f);
                    forSaleDetails.locate.Width = 3.250000f;
                    forSaleDetails.locate.EnterHeading = 270.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-633.1862f, 163.2426f, 58.3901f, 0.0000f, 0.0000f, 90.0000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    forSaleDetails.locate.Pos1 = new(-985.580994f, -1444.672363f, 4.279670f);
                    forSaleDetails.locate.Pos2 = new(-987.102173f, -1444.398804f, 7.185308f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 262.0629f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-985.4065f, -1443.5095f, 3.9247f, 0.0f, 0.0f, 79.91f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    forSaleDetails.locate.Pos1 = new(-836.994019f, -849.941284f, 18.151722f);
                    forSaleDetails.locate.Pos2 = new(-838.205750f, -848.480103f, 21.372906f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 221.6453f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-836.1278f, -849.1601f, 18.2256f, 0.0f, 0.0f, 39.66f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    forSaleDetails.locate.Pos1 = new(-756.589905f, -748.934998f, 25.702108f);
                    forSaleDetails.locate.Pos2 = new(-754.743408f, -748.941223f, 28.953197f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 90.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-756.3851f, -750.0966f, 25.7957f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    forSaleDetails.locate.Pos1 = new(-50.187210f, -55.036629f, 60.272251f);
                    forSaleDetails.locate.Pos2 = new(-51.619686f, -54.628963f, 63.717583f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 252.3236f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-50.0229f, -53.8636f, 60.3119f, 0.0f, 0.0f, 74.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    forSaleDetails.locate.Pos1 = new(-213.102692f, 187.012329f, 78.035645f);
                    forSaleDetails.locate.Pos2 = new(-211.254333f, 186.907654f, 82.408676f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 263.5080f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-211.1639f, 188.0837f, 78.3851f, 0.0f, 0.0f, 86.5f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    forSaleDetails.locate.Pos1 = new(-817.563843f, -988.784607f, 12.384418f);
                    forSaleDetails.locate.Pos2 = new(-819.363892f, -989.715027f, 15.589163f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 300.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-817.0109f, -989.8439f, 12.2483f, 0.0f, 0.0f, -62.5f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    forSaleDetails.locate.Pos1 = new(-672.138855f, -855.171997f, 22.961401f);
                    forSaleDetails.locate.Pos2 = new(-672.151245f, -853.397522f, 26.194956f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 174.2108f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-671.0081f, -854.9676f, 22.8995f, 0.0f, 0.0f, 0.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    forSaleDetails.locate.Pos1 = new(-1537.805786f, -328.869080f, 46.313866f);
                    forSaleDetails.locate.Pos2 = new(-1539.257568f, -327.890259f, 49.460922f);
                    forSaleDetails.locate.Width = 3.000000f;
                    forSaleDetails.locate.EnterHeading = 235.0142f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1537.1100f, -327.7055f, 46.1506f, 0.0000f, 0.0000f, 56.0000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    forSaleDetails.locate.Pos1 = new(-1555.599121f, -413.882538f, 40.994942f);
                    forSaleDetails.locate.Pos2 = new(-1556.715576f, -415.209564f, 44.388985f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 323.7604f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1554.7875f, -414.5885f, 41.2475f, 0.0f, 0.0f, -40.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    forSaleDetails.locate.Pos1 = new(-1610.954956f, -425.218628f, 39.186172f);
                    forSaleDetails.locate.Pos2 = new(-1612.198120f, -424.292145f, 42.669319f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 234.8191f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1610.3525f, -424.2323f, 39.3451f, 0.0f, 0.0f, 52.5f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    forSaleDetails.locate.Pos1 = new(964.442139f, -1011.256592f, 39.847279f);
                    forSaleDetails.locate.Pos2 = new(964.446167f, -1013.178040f, 42.847485f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 360.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(963.2650f, -1011.4455f, 39.6999f, 0.0f, 0.0f, 180.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    forSaleDetails.locate.Pos1 = new(883.501709f, -893.872375f, 24.784945f);
                    forSaleDetails.locate.Pos2 = new(883.484680f, -891.957886f, 28.283627f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 176.5860f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(884.6694f, -893.7291f, 24.9839f, 0.0f, 0.0f, 0.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    forSaleDetails.locate.Pos1 = new(823.519043f, -924.736755f, 24.985094f);
                    forSaleDetails.locate.Pos2 = new(823.510620f, -922.458008f, 28.093512f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 180.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(824.7078f, -924.5371f, 24.7669f, 0.0f, 0.0f, 0.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    forSaleDetails.locate.Pos1 = new(758.314941f, -748.266052f, 25.967655f);
                    forSaleDetails.locate.Pos2 = new(760.379700f, -748.252747f, 29.215302f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 90.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(758.4970f, -749.5124f, 25.7709f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    forSaleDetails.locate.Pos1 = new(856.973816f, -1162.723511f, 23.942072f);
                    forSaleDetails.locate.Pos2 = new(857.032776f, -1160.941772f, 27.197281f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 180.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_02");
                    forSaleDetails.vProp = new(858.1913f, -1162.6014f, 23.7193f, 0.0f, 0.0f, 88.92f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    forSaleDetails.locate.Pos1 = new(521.815552f, -1603.118896f, 28.068350f);
                    forSaleDetails.locate.Pos2 = new(520.687012f, -1602.161743f, 31.303627f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 231.2289f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(522.4885f, -1602.1176f, 28.1483f, 0.0f, 0.0f, 50.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    forSaleDetails.locate.Pos1 = new(572.736084f, -1572.967529f, 27.125452f);
                    forSaleDetails.locate.Pos2 = new(574.337891f, -1571.034546f, 30.401808f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 140.1712f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(571.9355f, -1572.1470f, 27.1465f);//new Vector3(573.7555f, -1573.6274f, 27.1465f, 0.0f, 0.0f, 138.4000ff);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    forSaleDetails.locate.Pos1 = new(722.010864f, -1189.458984f, 23.032354f);
                    forSaleDetails.locate.Pos2 = new(722.118408f, -1191.982422f, 26.282240f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 0.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(723.1205f, -1189.5334f, 22.7849f, 0.0f, 0.0f, 0.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32:
                    forSaleDetails.locate.Pos1 = new(511.378998f, -1494.215210f, 28.038017f);
                    forSaleDetails.locate.Pos2 = new(509.179077f, -1494.248657f, 31.288240f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 282.9001f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(511.1209f, -1493.0115f, 27.8279f, 0.0f, 0.0f, 90.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    forSaleDetails.locate.Pos1 = new(470.367279f, -1543.246582f, 28.032578f);
                    forSaleDetails.locate.Pos2 = new(471.718628f, -1541.650879f, 31.280441f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 140.3705f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(471.3800f, -1543.8505f, 27.9276f, 0.0f, 0.0f, -40.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                    forSaleDetails.locate.Pos1 = new(-66.096863f, 6428.335449f, 30.187746f);
                    forSaleDetails.locate.Pos2 = new(-67.568665f, 6429.747070f, 33.438263f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 226.1709f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-65.3201f, 6429.2266f, 29.9401f, 0.0f, 0.0f, 45.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    forSaleDetails.locate.Pos1 = new(-250.968063f, 6236.711914f, 30.239182f);
                    forSaleDetails.locate.Pos2 = new(-249.531006f, 6235.281738f, 33.489334f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 47.1554f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-251.7290f, 6235.8125f, 30.3967f, 0.0f, 0.0f, -135.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    forSaleDetails.locate.Pos1 = new(2550.967285f, 4666.499023f, 32.826591f);
                    forSaleDetails.locate.Pos2 = new(2550.294189f, 4668.046387f, 36.076591f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 204.5545f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(2551.9944f, 4667.0566f, 32.7716f, 0.0f, 0.0f, 24.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    forSaleDetails.locate.Pos1 = new(2463.038818f, 1576.448120f, 31.470388f);
                    forSaleDetails.locate.Pos2 = new(2465.060303f, 1576.392090f, 34.720390f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 94.3013f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(2463.2476f, 1575.2825f, 31.1929f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    forSaleDetails.locate.Pos1 = new(-2200.421875f, 4244.493652f, 46.685417f);
                    forSaleDetails.locate.Pos2 = new(-2199.036621f, 4245.555176f, 49.882755f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 127.0623f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-2199.5706f, 4243.6704f, 46.4650f, 0.0f, 0.0f, -52.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    forSaleDetails.locate.Pos1 = new(221.367157f, 2604.778076f, 44.620392f);
                    forSaleDetails.locate.Pos2 = new(219.656570f, 2604.362793f, 47.856190f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 289.1630f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(220.9417f, 2605.9116f, 44.7401f, 0.0f, 0.0f, 105.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    forSaleDetails.locate.Pos1 = new(186.395218f, 2782.788086f, 44.402477f);
                    forSaleDetails.locate.Pos2 = new(188.007141f, 2783.044434f, 47.655220f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 102.1472f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(186.9066f, 2781.7334f, 44.6552f, 0.0f, 0.0f, -80.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    forSaleDetails.locate.Pos1 = new(634.842957f, 2772.270752f, 40.764332f);
                    forSaleDetails.locate.Pos2 = new(636.888123f, 2772.353516f, 44.017746f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 100.8663f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(635.1283f, 2771.1194f, 40.7407f, 0.0f, 0.0f, -85.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    forSaleDetails.locate.Pos1 = new(-1126.475952f, 2696.537598f, 17.542923f);
                    forSaleDetails.locate.Pos2 = new(-1127.806885f, 2695.367676f, 20.800388f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 312.5133f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1127.3835f, 2697.3264f, 17.8004f, 0.0f, 0.0f, 133.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    forSaleDetails.locate.Pos1 = new(-13.942451f, -1644.276245f, 28.080687f);
                    forSaleDetails.locate.Pos2 = new(-12.848918f, -1642.979858f, 31.330111f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 139.4987f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-12.9589f, -1644.9135f, 27.7787f, 0.0f, 0.0f, -40.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    forSaleDetails.locate.Pos1 = new(1025.266968f, -2392.445557f, 28.889736f);
                    forSaleDetails.locate.Pos2 = new(1027.172974f, -2392.607910f, 32.136665f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 87.3884f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(1025.3685f, -2393.6165f, 28.8254f, 0.0f, 0.0f, -95.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    forSaleDetails.locate.Pos1 = new(867.267273f, -2231.949219f, 29.265272f);
                    forSaleDetails.locate.Pos2 = new(867.120728f, -2233.811768f, 32.510471f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 355.1479f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(866.0789f, -2231.9785f, 29.0011f, 0.0f, 0.0f, 175.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    forSaleDetails.locate.Pos1 = new(-661.830627f, -2376.241943f, 12.694332f);
                    forSaleDetails.locate.Pos2 = new(-663.601318f, -2375.243652f, 15.902493f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 241.4825f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-661.4331f, -2375.0635f, 12.9445f, 0.0f, 0.0f, 60.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    forSaleDetails.locate.Pos1 = new(-1085.231812f, -2237.962646f, 11.969692f);
                    forSaleDetails.locate.Pos2 = new(-1084.084839f, -2236.855957f, 15.226416f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 134.1198f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1084.2795f, -2238.7375f, 12.2211f, 0.0f, 0.0f, -45.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    forSaleDetails.locate.Pos1 = new(-342.872986f, -1471.703369f, 29.496666f);
                    forSaleDetails.locate.Pos2 = new(-340.430420f, -1471.747070f, 32.619366f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 90.5248f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-342.7135f, -1472.8895f, 29.2626f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    forSaleDetails.locate.Pos1 = new(-1238.995850f, -258.817322f, 37.700485f);
                    forSaleDetails.locate.Pos2 = new(-1239.997070f, -256.966309f, 40.961609f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 208.2259f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1238.0275f, -258.1714f, 37.4894f, 0.0f, 0.0f, 28.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    forSaleDetails.locate.Pos1 = new(906.553711f, -147.747131f, 75.154121f);
                    forSaleDetails.locate.Pos2 = new(907.461914f, -146.259521f, 78.330307f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 175.1345f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(907.5774f, -148.2901f, 75.2916f, 0.0f, 0.0f, -32.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    forSaleDetails.locate.Pos1 = new(-1425.518677f, 526.261169f, 116.890656f);
                    forSaleDetails.locate.Pos2 = new(-1427.518188f, 526.182190f, 120.918182f);
                    forSaleDetails.locate.Width = 2.750000f;
                    forSaleDetails.locate.EnterHeading = 267.2128f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1425.5720f, 527.2727f, 117.3776f, 0.0000f, 0.0000f, 92.1000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    forSaleDetails.locate.Pos1 = new(1351.397827f, -1584.639282f, 51.079918f);
                    forSaleDetails.locate.Pos2 = new(1352.786377f, -1586.568726f, 55.083618f);
                    forSaleDetails.locate.Width = 3.250000f;
                    forSaleDetails.locate.EnterHeading = 32.2147f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(1352.2960f, -1584.0680f, 51.9391f, 0.0000f, 0.0000f, 36.6000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    forSaleDetails.locate.Pos1 = new(-116.970314f, 6536.277832f, 27.282572f);
                    forSaleDetails.locate.Pos2 = new(-115.775063f, 6535.058105f, 31.481049f);
                    forSaleDetails.locate.Width = 2.500000f;
                    forSaleDetails.locate.EnterHeading = 225.7066f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-115.0400f, 6535.8901f, 28.6400f, 0.0000f, 0.0000f, 45.1000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    forSaleDetails.locate.Pos1 = new(-303.866302f, 6337.519043f, 29.231432f);
                    forSaleDetails.locate.Pos2 = new(-305.289124f, 6338.888184f, 33.055397f);
                    forSaleDetails.locate.Width = 2.500000f;
                    forSaleDetails.locate.EnterHeading = 216.6495f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-303.0000f, 6338.4102f, 30.0000f, 0.0000f, 0.0000f, 44.0000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    forSaleDetails.locate.Pos1 = new(-5.353218f, 6544.288086f, 30.456274f);
                    forSaleDetails.locate.Pos2 = new(-4.242996f, 6543.283203f, 34.008408f);
                    forSaleDetails.locate.Width = 2.500000f;
                    forSaleDetails.locate.EnterHeading = 46.1972f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-4.5037f, 6545.2139f, 30.6346f, 0.0f, 0.0f, 46.8f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    forSaleDetails.locate.Pos1 = new(1895.803711f, 3762.427734f, 30.348080f);
                    forSaleDetails.locate.Pos2 = new(1896.545166f, 3760.881836f, 34.241802f);
                    forSaleDetails.locate.Width = 2.500000f;
                    forSaleDetails.locate.EnterHeading = 26.8017f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(1896.9330f, 3762.8711f, 31.1300f, 0.0f, 0.0f, 25.1000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    forSaleDetails.locate.Pos1 = new(1668.035767f, 4764.542480f, 39.693623f);
                    forSaleDetails.locate.Pos2 = new(1669.620972f, 4764.813965f, 43.627949f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 117.8755f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(1667.8400f, 4765.7402f, 40.8100f, 0.0000f, 0.0000f, 99.1000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:

                    forSaleDetails.locate.Pos1 = new(-193.835007f, 502.281403f, 132.656677f);
                    forSaleDetails.locate.Pos2 = new(-196.182022f, 501.719604f, 134.788620f);

                    forSaleDetails.locate.Width = 1.000000f;
                    forSaleDetails.locate.EnterHeading = 184.4416f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-193.7673f, 501.7835f, 131.7232f, 0.0000f, 0.0000f, 13.68f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    forSaleDetails.locate.Pos1 = new(348.604248f, 447.072021f, 145.250092f);
                    forSaleDetails.locate.Pos2 = new(346.835083f, 448.670319f, 148.001633f);
                    forSaleDetails.locate.Width = 1f;
                    forSaleDetails.locate.EnterHeading = 117.8755f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(348.2750f, 446.7000f, 145.0000f, 0.0000f, 0.0000f, -41.00f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    forSaleDetails.locate.Pos1 = new(-748.647766f, 616.273560f, 141.095444f);
                    forSaleDetails.locate.Pos2 = new(-749.458618f, 618.645630f, 143.608246f);
                    forSaleDetails.locate.Width = 1f;
                    forSaleDetails.locate.EnterHeading = 84.8639f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-749.1125f, 616.1250f, 140.9000f, 0.0000f, 0.0000f, -72.72f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    forSaleDetails.locate.Pos1 = new(-690.888367f, 598.237061f, 142.001465f);
                    forSaleDetails.locate.Pos2 = new(-692.839722f, 596.790466f, 144.338913f);
                    forSaleDetails.locate.Width = 1f;
                    forSaleDetails.locate.EnterHeading = 253.1015f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-692.5033f, 596.4478f, 141.5300f, 0.0000f, 0.0000f, -143.64f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    forSaleDetails.locate.Pos1 = new(123.538338f, 567.972046f, 182.245819f);
                    forSaleDetails.locate.Pos2 = new(120.921776f, 567.985474f, 185.180695f);
                    forSaleDetails.locate.Width = 2.25f;
                    forSaleDetails.locate.EnterHeading = 117.8755f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(123.4150f, 568.0184f, 182.1895f, 0.0000f, 0.0000f, -0.0f);
                    break;

                //		case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_6_A:
                //			forSaleDetails.locate.Pos1 = new(1668.035767f,4764.542480f,39.693623f);
                //			forSaleDetails.locate.Pos2 = new(1669.620972f,4764.813965f,43.627949f); 
                //			forSaleDetails.locate.Width = 2.5f;
                //			forSaleDetails.locate.EnterHeading = 117.8755f;
                //			forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                //			forSaleDetails.vProp = new(991.7500f, 586.4250f, 101.1875f, new Vector3(0.0000f, 0.0000f, 99.1000ff);
                //		break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    forSaleDetails.locate.Pos1 = new(-558.176819f, 669.296082f, 143.978836f);
                    forSaleDetails.locate.Pos2 = new(-560.451721f, 669.873962f, 146.525894f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 169.0783f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-558.1771f, 669.1576f, 143.5971f, 0.0000f, -0.0000f, -16.3928f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    forSaleDetails.locate.Pos1 = new(-728.791504f, 592.705444f, 140.583817f);
                    forSaleDetails.locate.Pos2 = new(-731.080933f, 593.514404f, 143.452667f);
                    forSaleDetails.locate.Width = 2.2f;
                    forSaleDetails.locate.EnterHeading = 155.4847f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-731.0388f, 593.4600f, 140.6234f, 0.0000f, 0.0000f, 160.92f);
                    break;
                //		case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_9_A		:
                //			forSaleDetails.locate.Pos1 = new(1668.035767f,4764.542480f,39.693623f);
                //			forSaleDetails.locate.Pos2 = new(1669.620972f,4764.813965f,43.627949f); 
                //			forSaleDetails.locate.Width = 2.5f;
                //			forSaleDetails.locate.EnterHeading = 117.8755f;
                //			forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                //			forSaleDetails.vProp = new(1143.9060f, 549.5625f, 99.9250f, new Vector3(0.0000f, 0.0000f, 11.68ff);
                //		break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    forSaleDetails.locate.Pos1 = new(-849.827515f, 702.697876f, 147.675751f);
                    forSaleDetails.locate.Pos2 = new(-852.166138f, 702.266968f, 150.344437f);
                    forSaleDetails.locate.Width = 1.625f;
                    forSaleDetails.locate.EnterHeading = 187.8264f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-849.8375f, 702.6500f, 147.3250f, 0.0000f, 0.0000f, 10.44f);
                    break;
                //		case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_11_A		:
                //			forSaleDetails.locate.Pos1 = new(-921.726563f,694.898682f,150.833191f);
                //			forSaleDetails.locate.Pos2 = new(-924.133667f,694.672058f,153.457336f); 
                //			forSaleDetails.locate.Width = 2.5f;
                //			forSaleDetails.locate.EnterHeading = 179.4734f;
                //			forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                //			forSaleDetails.vProp = new(921.7497f, 694.8510f, 150.4750f, new Vector3(0.0000f, 0.0000f, 6.5250ff);
                //		break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    forSaleDetails.locate.Pos1 = new(-1301.607910f, 454.463379f, 96.691994f);
                    forSaleDetails.locate.Pos2 = new(-1303.777954f, 455.434998f, 98.971428f);
                    forSaleDetails.locate.Width = 2.5f;
                    forSaleDetails.locate.EnterHeading = 129.0f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1301.6331f, 454.4250f, 96.2000f, 0.0000f, 0.0000f, -24.12f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    forSaleDetails.locate.Pos1 = new(367.498322f, 433.104065f, 143.672165f);
                    forSaleDetails.locate.Pos2 = new(370.085205f, 432.815094f, 146.316040f);
                    forSaleDetails.locate.Width = 2f;
                    forSaleDetails.locate.EnterHeading = 164.3325f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(369.9500f, 432.3125f, 143.2625f, 0.0000f, 0.0000f, -6.84f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    forSaleDetails.locate.Pos1 = new(-1589.729126f, -551.257751f, 34.068645f);
                    forSaleDetails.locate.Pos2 = new(-1591.615112f, -552.568787f, 36.489510f);
                    forSaleDetails.locate.Width = 0f;// 1.00f;

                    forSaleDetails.locate.EnterHeading = 219.8654f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1589.396f, -551.649f, 33.614f, 0.0000f, 0.0000f, 38.16f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    forSaleDetails.locate.Pos1 = new(-1364.004517f, -510.436584f, 29.907789f);
                    forSaleDetails.locate.Pos2 = new(-1363.794556f, -511.766785f, 32.989868f);
                    forSaleDetails.locate.Width = 0f;// 2.750000f;

                    forSaleDetails.locate.EnterHeading = 357.9634f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-1362.8070f, -510.2996f, 30.1451f, 0.0000f, 0.0000f, 8.8000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    forSaleDetails.locate.Pos1 = new(-92.297760f, -577.105591f, 35.288895f);
                    forSaleDetails.locate.Pos2 = new(-93.230873f, -579.454895f, 38.365421f);
                    forSaleDetails.locate.Width = 0f;//2.125000f;

                    forSaleDetails.locate.EnterHeading = 71.9247f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-92.4380f, -577.2136f, 35.0354f, 0.0000f, 0.0000f, 70.0000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    forSaleDetails.locate.Pos1 = new(-66.095551f, -774.387207f, 43.073174f);
                    forSaleDetails.locate.Pos2 = new(-64.500237f, -776.382690f, 46.074734f);
                    forSaleDetails.locate.Width = 0f;//1.0f;

                    forSaleDetails.locate.EnterHeading = 133.9114f;
                    forSaleDetails.saleSign = Functions.HashUint("PROP_FORSALE_DYN_01");
                    forSaleDetails.vProp = new(-64.8331f, -776.5843f, 43.2158f, 0.0000f, -0.0000f, -48.2400f);
                    break;
            }
        }

        public static Vector3 GetMpPropertyBuildingWorldPoint(BuildingsEnum iBuildingID)
        {
            return iBuildingID switch
            {
                BuildingsEnum.MP_PROPERTY_BUILDING_1 => new(-773.4775f, 310.6321f, 84.6981f),
                BuildingsEnum.MP_PROPERTY_BUILDING_2 => new(-252.5713f, -949.9199f, 30.2210f),
                BuildingsEnum.MP_PROPERTY_BUILDING_3 => new(-1443.0938f, -544.7684f, 33.7424f),
                BuildingsEnum.MP_PROPERTY_BUILDING_4 => new(-913.8500f, -455.1392f, 38.5999f),
                BuildingsEnum.MP_PROPERTY_BUILDING_5 => new(-47.3145f, -585.9766f, 36.9593f),
                BuildingsEnum.MP_PROPERTY_BUILDING_6 => new(-932.7474f, -383.9246f, 37.9613f),
                BuildingsEnum.MP_PROPERTY_BUILDING_7 => new(-619.1315f, 37.8841f, 42.5883f),
                BuildingsEnum.MP_PROPERTY_BUILDING_8 => new(284.9614f, -159.9891f, 63.6221f),
                BuildingsEnum.MP_PROPERTY_BUILDING_9 => new(2.8889f, 35.7762f, 70.5349f),
                BuildingsEnum.MP_PROPERTY_BUILDING_10 => new(9.7400f, 84.6906f, 77.3975f),
                BuildingsEnum.MP_PROPERTY_BUILDING_11 => new(-512.1465f, 111.2223f, 62.3510f),
                BuildingsEnum.MP_PROPERTY_BUILDING_12 => new(-197.3405f, 88.1053f, 68.7422f),
                BuildingsEnum.MP_PROPERTY_BUILDING_13 => new(-628.3212f, 165.8364f, 60.1651f),
                BuildingsEnum.MP_PROPERTY_BUILDING_14 => new(-973.3757f, -1429.4247f, 6.6791f),
                BuildingsEnum.MP_PROPERTY_BUILDING_15 => new(-829.1362f, -855.0104f, 18.6297f),
                BuildingsEnum.MP_PROPERTY_BUILDING_16 => new(-757.5739f, -755.5591f, 25.5697f),
                BuildingsEnum.MP_PROPERTY_BUILDING_17 => new(-45.1289f, -57.0925f, 62.2531f),
                BuildingsEnum.MP_PROPERTY_BUILDING_18 => new(-206.7293f, 184.1420f, 79.3279f),
                BuildingsEnum.MP_PROPERTY_BUILDING_19 => new(-811.7045f, -984.1961f, 13.1538f),
                BuildingsEnum.MP_PROPERTY_BUILDING_20 => new(-664.0032f, -853.6744f, 23.4325f),
                BuildingsEnum.MP_PROPERTY_BUILDING_21 => new(-1534.0247f, -324.5247f, 46.5237f),
                BuildingsEnum.MP_PROPERTY_BUILDING_22 => new(-1561.3810f, -412.1974f, 41.3890f),
                BuildingsEnum.MP_PROPERTY_BUILDING_23 => new(-1608.8514f, -429.1840f, 39.4390f),
                BuildingsEnum.MP_PROPERTY_BUILDING_24 => new(964.3583f, -1034.1991f, 39.8303f),
                BuildingsEnum.MP_PROPERTY_BUILDING_25 => new(894.2868f, -885.5679f, 26.1212f),
                BuildingsEnum.MP_PROPERTY_BUILDING_26 => new(821.1741f, -924.1658f, 25.1998f),
                BuildingsEnum.MP_PROPERTY_BUILDING_27 => new(759.7933f, -759.8209f, 25.7590f),
                BuildingsEnum.MP_PROPERTY_BUILDING_28 => new(844.7289f, -1164.0997f, 24.2681f),
                BuildingsEnum.MP_PROPERTY_BUILDING_29 => new(526.2521f, -1604.6130f, 28.2625f),
                BuildingsEnum.MP_PROPERTY_BUILDING_30 => new(572.0462f, -1570.7357f, 27.4904f),
                BuildingsEnum.MP_PROPERTY_BUILDING_31 => new(722.2852f, -1190.6168f, 23.2820f),
                BuildingsEnum.MP_PROPERTY_BUILDING_32 => new(497.6212f, -1494.0845f, 28.2893f),
                BuildingsEnum.MP_PROPERTY_BUILDING_33 => new(480.3127f, -1549.9368f, 28.2828f),
                BuildingsEnum.MP_PROPERTY_BUILDING_34 => new(-68.7020f, 6426.1479f, 30.4390f),
                BuildingsEnum.MP_PROPERTY_BUILDING_35 => new(-247.4374f, 6240.2939f, 30.4892f),
                BuildingsEnum.MP_PROPERTY_BUILDING_36 => new(2554.1653f, 4668.0591f, 33.0233f),
                BuildingsEnum.MP_PROPERTY_BUILDING_38 => new(2461.2202f, 1589.2552f, 32.0443f),
                BuildingsEnum.MP_PROPERTY_BUILDING_39 => new(-2203.3350f, 4244.4272f, 47.3305f),
                BuildingsEnum.MP_PROPERTY_BUILDING_40 => new(218.0665f, 2601.8171f, 44.7668f),
                BuildingsEnum.MP_PROPERTY_BUILDING_41 => new(186.1719f, 2786.3425f, 45.0144f),
                BuildingsEnum.MP_PROPERTY_BUILDING_42 => new(642.0746f, 2791.7295f, 40.9795f),
                BuildingsEnum.MP_PROPERTY_BUILDING_47 => new(-1130.9376f, 2701.1333f, 17.8004f),
                BuildingsEnum.MP_PROPERTY_BUILDING_49 => new(-10.9440f, -1646.7601f, 28.3125f),
                BuildingsEnum.MP_PROPERTY_BUILDING_50 => new(1024.2628f, -2398.4036f, 29.1261f),
                BuildingsEnum.MP_PROPERTY_BUILDING_51 => new(870.8577f, -2232.3228f, 29.5508f),
                BuildingsEnum.MP_PROPERTY_BUILDING_52 => new(-663.8541f, -2380.3889f, 12.9446f),
                BuildingsEnum.MP_PROPERTY_BUILDING_53 => new(-1088.6158f, -2235.0977f, 12.2182f),
                BuildingsEnum.MP_PROPERTY_BUILDING_54 => new(-342.5126f, -1468.6746f, 29.6107f),
                BuildingsEnum.MP_PROPERTY_BUILDING_55 => new(-1241.5399f, -259.8841f, 37.9445f),
                BuildingsEnum.MP_PROPERTY_BUILDING_56 => new(899.8448f, -147.5280f, 75.5674f),
                BuildingsEnum.MP_PROPERTY_BUILDING_57 => new(-1405.4109f, 526.8572f, 122.8361f),
                BuildingsEnum.MP_PROPERTY_BUILDING_58 => new(1341.5518f, -1578.0366f, 53.4443f),
                BuildingsEnum.MP_PROPERTY_BUILDING_59 => new(-105.7029f, 6528.5391f, 29.1719f),
                BuildingsEnum.MP_PROPERTY_BUILDING_60 => new(-302.3985f, 6327.4341f, 31.8918f),
                BuildingsEnum.MP_PROPERTY_BUILDING_61 => new(-15.2580f, 6557.3779f, 32.2454f),
                BuildingsEnum.MP_PROPERTY_BUILDING_62 => new(1899.6729f, 3773.1785f, 31.8829f),
                BuildingsEnum.MP_PROPERTY_BUILDING_63 => new(1662.1211f, 4776.3169f, 41.0075f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B => new(-178.2278f, 490.8860f, 134.0466f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B => new(339.5743f, 439.7083f, 145.5896f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B => new(-764.6163f, 618.3144f, 137.5536f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B => new(-679.5461f, 592.5162f, 139.6930f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A => new(124.4571f, 551.8877f, 181.6580f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A => new(-563.7349f, 689.099f, 151.6596f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A => new(-743.0927f, 590.0371f, 140.9221f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A => new(-861.2520f, 684.8923f, 146.2643f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A => new(-1292.4557f, 440.9454f, 93.7572f),
                BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A => new(369.5891f, 417.4813f, 136.8344f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1 => new(-1581.5015f, -558.2578f, 33.9528f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2 => new(-1379.5457f, -499.1783f, 32.1574f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3 => new(-117.5296f, -605.7157f, 35.2857f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4 => new(-67.0943f, -802.4415f, 43.2273f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1 => new(254.1892f, -1809.1831f, 26.1805f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2 => new(-1472.2778f, -920.0677f, 8.9683f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3 => new(38.9478f, -1026.6288f, 28.6354f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4 => new(46.9030f, 2789.8247f, 57.1124f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5 => new(-342.3246f, 6065.3164f, 30.4895f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6 => new(1737.8784f, 3709.0876f, 33.1348f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7 => new(939.7161f, -1459.2039f, 30.4670f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8 => new(189.7624f, 309.7488f, 104.4714f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9 => new(-21.9593f, -191.3618f, 51.5599f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10 => new(2472.2197f, 4110.4927f, 36.9629f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11 => new(-39.3286f, 6420.6025f, 30.7017f),
                BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12 => new(-1134.762f, -1568.8480f, 3.4077f),
                _ => Vector3.Zero,
            };
        }
        private static void GetMPFakeGarageDriveData(ref MPFakeGarageDriveStruct fakeGarageDriveData, BuildingsEnum iBuilding)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:  //----MED SIZE APT GARAGES----:
                    fakeGarageDriveData.vStartPoint = new Vector3(282.2381f, -147.1377f, 64.7194f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-1.1206f, 1.2502f, -107.7124f);
                    fakeGarageDriveData.vEndPoint = new Vector3(291.7622f, -150.1795f, 64.5238f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-1.1206f, 1.2502f, -107.7124f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(280.9155f, -142.1422f, 74.6172f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-63.6406f, 0.0000f, -159.4209f);
                    fakeGarageDriveData.fCamFov1 = 43.6050f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(281.1650f, -142.0818f, 74.5581f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-60.1554f, 0.0000f, -152.1888f);
                    fakeGarageDriveData.fCamFov2 = 43.6050f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    fakeGarageDriveData.vStartPoint = new Vector3(-10.0048f, 37.5644f, 71.2121f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.4104f, 2.9777f, -18.5547f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-6.8228f, 47.0444f, 71.2837f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.4104f, 2.9777f, -18.5547f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-12.1709f, 40.6827f, 79.2905f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-67.6078f, 0.0000f, -133.0747f);
                    fakeGarageDriveData.fCamFov1 = 37.4602f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-12.0966f, 40.7525f, 79.4262f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-68.4974f, 0.0000f, -117.8285f);
                    fakeGarageDriveData.fCamFov2 = 37.4602f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    fakeGarageDriveData.vStartPoint = new Vector3(27.7079f, 79.3738f, 74.4324f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-3.2650f, 1.1760f, 143.6296f);
                    fakeGarageDriveData.vEndPoint = new Vector3(21.7875f, 71.3349f, 73.8629f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-3.2650f, 1.1760f, 143.6296f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(31.7731f, 80.2026f, 82.0504f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-66.0132f, -0.0000f, 104.5604f);
                    fakeGarageDriveData.fCamFov1 = 50.0000f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(31.7731f, 80.2026f, 82.0504f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-57.3429f, -0.0000f, 116.8637f);
                    fakeGarageDriveData.fCamFov2 = 50.0000f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    fakeGarageDriveData.vStartPoint = new Vector3(-501.5964f, 84.4108f, 55.9000f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-4.5362f, 0.1290f, -90.6480f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-491.6284f, 84.2981f, 55.1091f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-4.5362f, 0.1290f, -90.6480f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-495.3444f, 74.5327f, 61.9028f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-30.7693f, 0.0518f, 19.3165f);
                    fakeGarageDriveData.fCamFov1 = 33.9968f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-495.3444f, 74.5327f, 61.9028f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-33.0911f, 0.0518f, -5.8935f);
                    fakeGarageDriveData.fCamFov2 = 33.9968f;
                    fakeGarageDriveData.iCamDuration = 1800;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    fakeGarageDriveData.vStartPoint = new Vector3(-215.6616f, 39.0101f, 59.4679f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0989f, 9.6654f, -104.2112f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-205.9677f, 36.5551f, 59.4851f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0989f, 9.6654f, -104.2112f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-219.7459f, 48.7438f, 61.4571f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-4.0536f, -0.0000f, -170.1054f);
                    fakeGarageDriveData.fCamFov1 = 37.1668f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-219.7459f, 48.7438f, 61.4571f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-3.2125f, -0.0000f, -160.8897f);
                    fakeGarageDriveData.fCamFov2 = 37.1668f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    fakeGarageDriveData.vStartPoint = new Vector3(-630.1108f, 152.2030f, 56.5563f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-7.4487f, 1.7718f, -87.7348f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-620.2029f, 152.5949f, 55.2599f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-7.4487f, 1.7718f, -87.7348f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-626.2416f, 146.1366f, 64.7731f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-52.6818f, 0.0000f, 28.3187f);
                    fakeGarageDriveData.fCamFov1 = 41.0756f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-626.1986f, 146.1378f, 64.7731f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-55.8905f, 0.0000f, 1.5091f);
                    fakeGarageDriveData.fCamFov2 = 41.0756f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    fakeGarageDriveData.vStartPoint = new Vector3(-981.8929f, -1450.3265f, 4.5459f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-3.9664f, 0.1169f, -67.7563f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-972.6593f, -1446.5502f, 3.8541f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-3.9664f, 0.1169f, -67.7563f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-984.0593f, -1448.9143f, 12.1711f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-69.5862f, -0.0000f, -100.6522f);
                    fakeGarageDriveData.fCamFov1 = 38.7775f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-984.0593f, -1448.9143f, 12.1711f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-61.1556f, 0.0000f, -95.2381f);
                    fakeGarageDriveData.fCamFov2 = 38.7775f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    fakeGarageDriveData.vStartPoint = new Vector3(-760.1356f, -870.4690f, 21.0282f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-10.2890f, -3.8836f, 80.0382f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-769.8264f, -868.7669f, 19.2421f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-10.2890f, -3.8836f, 80.0382f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-762.6753f, -853.0572f, 24.7561f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-12.8230f, 0.0064f, -169.7421f);
                    fakeGarageDriveData.fCamFov1 = 30.1796f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-762.8038f, -853.0630f, 24.7561f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-16.5765f, 0.0064f, -177.4226f);
                    fakeGarageDriveData.fCamFov2 = 30.1796f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    fakeGarageDriveData.vStartPoint = new Vector3(-785.7354f, -803.0583f, 20.2969f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.0310f, -1.9617f, 2.4109f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-786.1561f, -793.0672f, 20.2915f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.0310f, -1.9617f, 2.4109f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-803.6768f, -804.7111f, 23.1995f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-6.4933f, -0.0000f, -78.6719f);
                    fakeGarageDriveData.fCamFov1 = 27.5460f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-803.7925f, -804.1338f, 23.1995f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-6.4933f, 0.0000f, -76.3952f);
                    fakeGarageDriveData.fCamFov2 = 27.5460f;
                    fakeGarageDriveData.iCamDuration = 1800;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17: //----LOW END APT GARAGES----:
                    fakeGarageDriveData.vStartPoint = new Vector3(-32.2924f, -68.7007f, 58.9749f);
                    fakeGarageDriveData.vStartRotation = new Vector3(3.8663f, 0.3524f, -20.4979f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-28.7986f, -59.3552f, 59.6492f);
                    fakeGarageDriveData.vEndRotation = new Vector3(3.8663f, 0.3524f, -20.4979f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-32.8059f, -65.7310f, 66.7503f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-71.3294f, -0.0000f, -165.7213f);
                    fakeGarageDriveData.fCamFov1 = 36.5696f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-32.6489f, -65.6107f, 66.8067f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-80.4246f, 0.0000f, -143.2124f);
                    fakeGarageDriveData.fCamFov2 = 36.5696f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    fakeGarageDriveData.vStartPoint = new Vector3(-204.7136f, 192.6043f, 79.7539f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-8.4178f, 7.2752f, -86.9347f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-194.8355f, 193.1333f, 78.2900f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-8.4178f, 7.2752f, -86.9347f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-203.5741f, 202.1610f, 85.0254f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-23.4390f, -0.0000f, -178.1196f);
                    fakeGarageDriveData.fCamFov1 = 36.4045f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-203.5380f, 202.1691f, 85.0254f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-21.7612f, -0.0000f, -166.4292f);
                    fakeGarageDriveData.fCamFov2 = 36.4045f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    fakeGarageDriveData.vStartPoint = new Vector3(-799.5796f, -982.4630f, 13.2871f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-10.2862f, -2.8161f, 33.3460f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-804.9882f, -974.2435f, 11.5015f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-10.2862f, -2.8161f, 33.3460f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-783.8897f, -969.8353f, 20.4452f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-17.6878f, -0.0000f, 131.1822f);
                    fakeGarageDriveData.fCamFov1 = 34.3933f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-784.1321f, -969.5460f, 20.4452f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-22.3429f, 0.0000f, 124.3197f);
                    fakeGarageDriveData.fCamFov2 = 34.3933f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    fakeGarageDriveData.vStartPoint = new Vector3(-667.8899f, -853.0598f, 23.9252f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.1496f, 0.9550f, 179.9519f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-667.8983f, -863.0597f, 23.8991f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.1496f, 0.9550f, 179.9519f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-667.4206f, -850.1749f, 35.0685f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-71.6889f, 0.0000f, 178.5344f);
                    fakeGarageDriveData.fCamFov1 = 39.4288f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-667.4206f, -850.1749f, 35.0685f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-63.3388f, -0.0000f, 179.6505f);
                    fakeGarageDriveData.fCamFov2 = 39.4288f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1529.6903f, -345.1286f, 44.9759f);
                    fakeGarageDriveData.vStartRotation = new Vector3(2.0456f, 3.7798f, -43.2900f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1522.8378f, -337.8543f, 45.3329f);
                    fakeGarageDriveData.vEndRotation = new Vector3(2.0456f, 3.7798f, -43.2900f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1532.7729f, -344.6169f, 60.2138f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-78.2937f, 0.0000f, -92.5529f);
                    fakeGarageDriveData.fCamFov1 = 31.5824f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1532.5663f, -344.5278f, 59.9469f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-76.0354f, 0.0000f, -68.0600f);
                    fakeGarageDriveData.fCamFov2 = 31.5824f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1555.4988f, -401.3440f, 41.6277f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0388f, 0.0159f, 50.3554f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1563.1990f, -394.9638f, 41.6345f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0388f, 0.0159f, 50.3554f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1551.9146f, -406.2923f, 50.1552f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-55.5290f, 0.0000f, 39.4672f);
                    fakeGarageDriveData.fCamFov1 = 35.9498f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1551.9146f, -406.2923f, 50.1552f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-46.9086f, -0.0000f, 44.0199f);
                    fakeGarageDriveData.fCamFov2 = 35.9498f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24: //----EAST LOS SANTOS GARAGES----:
                    fakeGarageDriveData.vStartPoint = new Vector3(967.2626f, -1025.5471f, 40.4888f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0056f, 0.0182f, 91.0124f);
                    fakeGarageDriveData.vEndPoint = new Vector3(957.2642f, -1025.7238f, 40.4898f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0056f, 0.0182f, 91.0124f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(964.1608f, -1004.4283f, 42.8687f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-5.1752f, -0.0000f, -170.3357f);
                    fakeGarageDriveData.fCamFov1 = 39.7597f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(963.9210f, -1004.4107f, 42.8687f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-5.1752f, 0.0000f, -184.2027f);
                    fakeGarageDriveData.fCamFov2 = 39.7597f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    fakeGarageDriveData.vStartPoint = new Vector3(892.6966f, -887.0980f, 26.6401f);
                    fakeGarageDriveData.vStartRotation = new Vector3(4.4946f, -0.1024f, -88.5362f);
                    fakeGarageDriveData.vEndPoint = new Vector3(902.6626f, -886.8434f, 27.4237f);
                    fakeGarageDriveData.vEndRotation = new Vector3(4.4946f, -0.1024f, -88.5362f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(882.9940f, -884.1534f, 38.3898f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-48.1610f, -0.0000f, -106.9426f);
                    fakeGarageDriveData.fCamFov1 = 36.8885f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(883.2540f, -884.2086f, 38.2431f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-42.5923f, -0.0000f, -100.5455f);
                    fakeGarageDriveData.fCamFov2 = 36.8885f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    fakeGarageDriveData.vStartPoint = new Vector3(817.1609f, -921.3576f, 25.6636f);
                    fakeGarageDriveData.vStartRotation = new Vector3(3.7217f, -0.1810f, -178.0125f);
                    fakeGarageDriveData.vEndPoint = new Vector3(817.5070f, -931.3305f, 26.3127f);
                    fakeGarageDriveData.vEndRotation = new Vector3(3.7217f, -0.1810f, -178.0125f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(809.0961f, -923.7908f, 49.5857f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-70.3569f, 0.0000f, -63.9375f);
                    fakeGarageDriveData.fCamFov1 = 32.6499f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(809.1757f, -924.3426f, 49.5857f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-70.5596f, 0.0000f, -78.1180f);
                    fakeGarageDriveData.fCamFov2 = 32.6499f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    fakeGarageDriveData.vStartPoint = new Vector3(761.3924f, -752.7610f, 26.5738f);
                    fakeGarageDriveData.vStartRotation = new Vector3(3.2672f, -2.4877f, 91.3504f);
                    fakeGarageDriveData.vEndPoint = new Vector3(751.4114f, -752.9963f, 27.1437f);
                    fakeGarageDriveData.vEndRotation = new Vector3(3.2672f, -2.4877f, 91.3504f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(758.9533f, -762.7834f, 48.0995f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-72.3599f, 0.0000f, -13.3868f);
                    fakeGarageDriveData.fCamFov1 = 36.3885f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(758.6724f, -762.8107f, 48.1025f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-70.6849f, 0.0000f, 5.3055f);
                    fakeGarageDriveData.fCamFov2 = 36.3885f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    fakeGarageDriveData.vStartPoint = new Vector3(846.6603f, -1161.4995f, 24.9088f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0256f, 0.0044f, -177.0476f);
                    fakeGarageDriveData.vEndPoint = new Vector3(847.1754f, -1171.4862f, 24.9133f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0256f, 0.0044f, -177.0476f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(856.3569f, -1141.0571f, 40.9422f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-37.9331f, -0.0000f, 153.2809f);
                    fakeGarageDriveData.fCamFov1 = 35.3267f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(856.3569f, -1141.0571f, 40.9422f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-27.0109f, 0.0000f, 158.8086f);
                    fakeGarageDriveData.fCamFov2 = 35.3267f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    fakeGarageDriveData.vStartPoint = new Vector3(526.5894f, -1601.4061f, 28.8315f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.7490f, -0.7061f, -130.3278f);
                    fakeGarageDriveData.vEndPoint = new Vector3(534.2123f, -1607.8772f, 28.7007f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.7490f, -0.7061f, -130.3278f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(546.9518f, -1587.7031f, 34.2113f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-9.0224f, 0.0000f, 128.2028f);
                    fakeGarageDriveData.fCamFov1 = 30.3880f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(546.9518f, -1587.7031f, 34.2113f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-10.3283f, -0.0000f, 135.2253f);
                    fakeGarageDriveData.fCamFov2 = 30.3880f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    fakeGarageDriveData.vStartPoint = new Vector3(571.3971f, -1568.0491f, 28.2515f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.6149f, -2.7795f, 141.2995f);
                    fakeGarageDriveData.vEndPoint = new Vector3(565.1450f, -1575.8529f, 28.1442f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.6149f, -2.7795f, 141.2995f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(573.2791f, -1575.5587f, 46.9199f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-68.8843f, -0.0703f, 24.8515f);
                    fakeGarageDriveData.fCamFov1 = 31.2938f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(573.2791f, -1575.5587f, 46.9199f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-69.1637f, -0.0703f, 43.8487f);
                    fakeGarageDriveData.fCamFov2 = 31.2938f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    fakeGarageDriveData.vStartPoint = new Vector3(724.9709f, -1192.3809f, 23.9192f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0391f, 0.0595f, 0.0286f);
                    fakeGarageDriveData.vEndPoint = new Vector3(724.9659f, -1182.3809f, 23.9260f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0391f, 0.0595f, 0.0286f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(722.6805f, -1187.9257f, 38.2566f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-72.2394f, -0.0000f, -140.7753f);
                    fakeGarageDriveData.fCamFov1 = 29.7867f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(722.8250f, -1187.7715f, 38.2566f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-76.0456f, 0.0000f, -133.1711f);
                    fakeGarageDriveData.fCamFov2 = 29.7867f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32: //----SOUTH LOS SANTOS GARAGES----:
                    fakeGarageDriveData.vStartPoint = new Vector3(501.2068f, -1495.3925f, 28.9288f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0272f, 0.0092f, -0.4849f);
                    fakeGarageDriveData.vEndPoint = new Vector3(501.2914f, -1485.3928f, 28.9335f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0272f, 0.0092f, -0.4849f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(504.3377f, -1488.9459f, 43.7174f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-64.8908f, 0.0000f, 152.1497f);
                    fakeGarageDriveData.fCamFov1 = 35.1511f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(504.3377f, -1488.9459f, 43.7174f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-71.0987f, 0.0000f, 140.7012f);
                    fakeGarageDriveData.fCamFov2 = 35.1511f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    fakeGarageDriveData.vStartPoint = new Vector3(475.6252f, -1543.7405f, 28.9036f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.7862f, -0.0034f, 140.2885f);
                    fakeGarageDriveData.vEndPoint = new Vector3(469.2365f, -1551.4325f, 29.0408f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.7862f, -0.0034f, 140.2885f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(466.4099f, -1540.5402f, 29.3242f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(0.0930f, 0.0000f, -108.5351f);
                    fakeGarageDriveData.fCamFov1 = 37.4413f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(466.3842f, -1540.6171f, 29.3242f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(0.0930f, -0.0000f, -120.9249f);
                    fakeGarageDriveData.fCamFov2 = 37.4413f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34: //---- GARAGE NEW ----:
                    fakeGarageDriveData.vStartPoint = new Vector3(-70.1812f, 6428.0459f, 31.0790f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0308f, -0.0140f, -135.0552f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-63.1169f, 6420.9683f, 31.0844f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0308f, -0.0140f, -135.0552f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-57.6381f, 6435.8394f, 52.8205f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-64.0500f, 0.0000f, 123.9937f);
                    fakeGarageDriveData.fCamFov1 = 37.5256f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-57.6381f, 6435.8394f, 52.8205f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-62.8623f, -0.0000f, 133.6449f);
                    fakeGarageDriveData.fCamFov2 = 37.5256f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    fakeGarageDriveData.vStartPoint = new Vector3(-244.9784f, 6238.4668f, 31.1296f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0172f, 0.0223f, 45.5498f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-252.1170f, 6245.4697f, 31.1326f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0172f, 0.0223f, 45.5498f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-237.2837f, 6226.9512f, 43.7141f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-38.0273f, -0.0000f, 36.7390f);
                    fakeGarageDriveData.fCamFov1 = 36.4635f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-237.2822f, 6226.9517f, 43.7144f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-29.0807f, -0.0260f, 41.0273f);
                    fakeGarageDriveData.fCamFov2 = 36.4635f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    fakeGarageDriveData.vStartPoint = new Vector3(2553.2327f, 4670.4785f, 33.6288f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.6077f, -3.1634f, -156.4158f);
                    fakeGarageDriveData.vEndPoint = new Vector3(2557.2334f, 4661.3145f, 33.5228f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.6077f, -3.1634f, -156.4158f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(2557.8582f, 4669.9331f, 51.9641f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-78.8873f, 0.0000f, 74.0489f);
                    fakeGarageDriveData.fCamFov1 = 45.4939f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(2557.9324f, 4668.8081f, 51.9686f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-79.4619f, 0.0000f, 90.4893f);
                    fakeGarageDriveData.fCamFov2 = 45.4939f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    fakeGarageDriveData.vStartPoint = new Vector3(2463.6968f, 1589.5326f, 32.4561f);
                    fakeGarageDriveData.vStartRotation = new Vector3(4.0268f, -0.0430f, 94.4038f);
                    fakeGarageDriveData.vEndPoint = new Vector3(2458.1140f, 1589.4073f, 32.3716f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0643f, 0.0008f, 89.1684f);
                    fakeGarageDriveData.fDuration = 1000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(2457.0183f, 1572.3728f, 49.7001f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-44.1736f, 0.0000f, -20.1861f);
                    fakeGarageDriveData.fCamFov1 = 31.5402f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(2457.0183f, 1572.3728f, 49.7001f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-43.0249f, 0.0000f, -9.7775f);
                    fakeGarageDriveData.fCamFov2 = 31.5402f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    fakeGarageDriveData.vStartPoint = new Vector3(-2204.4141f, 4246.3960f, 47.5079f);
                    fakeGarageDriveData.vStartRotation = new Vector3(9.6381f, 0.1979f, -143.5093f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-2198.5510f, 4238.4697f, 49.1822f);
                    fakeGarageDriveData.vEndRotation = new Vector3(9.6381f, 0.1979f, -143.5093f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-2230.6702f, 4220.1206f, 47.5106f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-1.5007f, 0.0000f, -46.6541f);
                    fakeGarageDriveData.fCamFov1 = 26.3164f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-2230.5771f, 4220.0024f, 47.5106f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-0.4144f, 0.0000f, -50.7899f);
                    fakeGarageDriveData.fCamFov2 = 26.3164f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    fakeGarageDriveData.vStartPoint = new Vector3(217.3774f, 2604.6265f, 45.5921f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-4.5961f, 0.0049f, -168.7901f);
                    fakeGarageDriveData.vEndPoint = new Vector3(219.3152f, 2594.8489f, 44.7907f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-4.5961f, 0.0049f, -168.7901f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(231.9102f, 2602.4541f, 46.4126f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(3.4737f, 0.0000f, 79.9577f);
                    fakeGarageDriveData.fCamFov1 = 32.1111f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(231.9138f, 2602.4224f, 46.4126f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(4.4272f, -0.0000f, 97.0735f);
                    fakeGarageDriveData.fCamFov2 = 32.1111f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    fakeGarageDriveData.vStartPoint = new Vector3(188.8881f, 2787.0393f, 45.3312f);
                    fakeGarageDriveData.vStartRotation = new Vector3(3.4448f, 0.4471f, 100.6538f);
                    fakeGarageDriveData.vEndPoint = new Vector3(179.0782f, 2785.1938f, 45.9321f);
                    fakeGarageDriveData.vEndRotation = new Vector3(3.4448f, 0.4471f, 100.6538f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(180.9998f, 2807.5940f, 46.7046f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-3.0400f, 0.0000f, -155.9323f);
                    fakeGarageDriveData.fCamFov1 = 29.6816f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(180.7166f, 2807.4668f, 46.7046f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-1.4530f, 0.0000f, -161.1876f);
                    fakeGarageDriveData.fCamFov2 = 29.6816f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    fakeGarageDriveData.vStartPoint = new Vector3(638.8624f, 2774.1997f, 41.6398f);
                    fakeGarageDriveData.vStartRotation = new Vector3(1.0937f, 0.1626f, -175.0808f);
                    fakeGarageDriveData.vEndPoint = new Vector3(639.7198f, 2764.2383f, 41.8306f);
                    fakeGarageDriveData.vEndRotation = new Vector3(1.0937f, 0.1626f, -175.0808f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(633.7023f, 2771.6411f, 55.6154f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-69.7908f, 0.0000f, -55.0385f);
                    fakeGarageDriveData.fCamFov1 = 42.5851f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(633.7242f, 2771.0037f, 55.5837f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-69.7908f, 0.0000f, -67.4836f);
                    fakeGarageDriveData.fCamFov2 = 42.5851f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1131.8018f, 2697.9768f, 18.4404f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0610f, -0.0014f, -46.6650f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1124.5282f, 2704.8394f, 18.4511f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0610f, -0.0014f, -46.6650f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1130.3347f, 2706.6177f, 33.9812f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-60.9219f, 0.0000f, 179.0602f);
                    fakeGarageDriveData.fCamFov1 = 34.2989f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1129.9264f, 2706.9133f, 33.8337f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-63.7902f, -0.0000f, 191.2047f);
                    fakeGarageDriveData.fCamFov2 = 34.2989f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    fakeGarageDriveData.vStartPoint = new Vector3(-9.2410f, -1644.8750f, 28.8595f);
                    fakeGarageDriveData.vStartRotation = new Vector3(2.1373f, -0.0602f, 138.4612f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-15.8676f, -1652.3549f, 29.2324f);
                    fakeGarageDriveData.vEndRotation = new Vector3(2.1373f, -0.0602f, 138.4612f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(8.1032f, -1660.5637f, 38.5312f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-21.3429f, 0.0000f, 49.7328f);
                    fakeGarageDriveData.fCamFov1 = 26.4682f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(8.0493f, -1660.6440f, 38.5312f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-21.3429f, 0.0000f, 56.1426f);
                    fakeGarageDriveData.fCamFov2 = 26.4682f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    fakeGarageDriveData.vStartPoint = new Vector3(1026.6680f, -2398.3774f, 29.5076f);
                    fakeGarageDriveData.vStartRotation = new Vector3(2.9979f, -2.0604f, 83.5527f);
                    fakeGarageDriveData.vEndPoint = new Vector3(1016.7448f, -2397.2561f, 30.0306f);
                    fakeGarageDriveData.vEndRotation = new Vector3(2.9979f, -2.0604f, 83.5527f);
                    fakeGarageDriveData.fDuration = 1800f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(1025.9293f, -2392.9202f, 57.7325f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-83.5372f, 0.0000f, -149.2023f);
                    fakeGarageDriveData.fCamFov1 = 32.8593f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(1025.1747f, -2393.0984f, 57.7325f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-83.5372f, 0.0000f, -164.2777f);
                    fakeGarageDriveData.fCamFov2 = 32.8593f;
                    fakeGarageDriveData.iCamDuration = 2000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    fakeGarageDriveData.vStartPoint = new Vector3(870.4368f, -2234.6443f, 30.2158f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.8345f, -0.6373f, -4.1122f);
                    fakeGarageDriveData.vEndPoint = new Vector3(871.1539f, -2224.6711f, 30.0702f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.8345f, -0.6373f, -4.1122f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(861.5919f, -2231.6753f, 54.8766f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-71.9401f, -0.0000f, -108.5225f);
                    fakeGarageDriveData.fCamFov1 = 30.0426f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(861.6459f, -2231.4314f, 54.8766f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-71.3234f, -0.0000f, -98.7928f);
                    fakeGarageDriveData.fCamFov2 = 30.0426f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    fakeGarageDriveData.vStartPoint = new Vector3(-666.1675f, -2379.3271f, 13.5390f);
                    fakeGarageDriveData.vStartRotation = new Vector3(1.1993f, 0.0718f, -122.3419f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-657.7206f, -2384.6758f, 13.7483f);
                    fakeGarageDriveData.vEndRotation = new Vector3(1.1993f, 0.0718f, -122.3419f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-660.8848f, -2373.8525f, 35.8767f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-73.2999f, 0.0000f, 136.9541f);
                    fakeGarageDriveData.fCamFov1 = 37.4674f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-660.4532f, -2374.2554f, 35.8767f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-73.2999f, 0.0000f, 144.3813f);
                    fakeGarageDriveData.fCamFov2 = 37.4674f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1087.0016f, -2232.9473f, 12.8696f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.1899f, -0.0061f, 135.3795f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1094.0256f, -2240.0649f, 12.8364f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.1899f, -0.0061f, 135.3795f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1096.1954f, -2225.2153f, 38.0656f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-66.7251f, 0.0000f, -120.3547f);
                    fakeGarageDriveData.fCamFov1 = 31.6568f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1096.7744f, -2226.1318f, 38.0656f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-66.7251f, -0.0000f, -127.7912f);
                    fakeGarageDriveData.fCamFov2 = 31.6568f;
                    fakeGarageDriveData.iCamDuration = 2200;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    fakeGarageDriveData.vStartPoint = new Vector3(-340.1190f, -1468.5680f, 30.2343f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.7603f, -0.0820f, 89.5817f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-350.1179f, -1468.4950f, 30.3670f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.7603f, -0.0820f, 89.5817f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-342.3679f, -1450.2625f, 30.9518f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-0.2107f, 0.0000f, -170.5530f);
                    fakeGarageDriveData.fCamFov1 = 29.3208f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-342.9362f, -1450.3568f, 30.9518f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-0.2107f, -0.0000f, -176.7102f);
                    fakeGarageDriveData.fCamFov2 = 29.3208f;
                    fakeGarageDriveData.iCamDuration = 2500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1242.5619f, -258.1299f, 38.6231f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-1.3350f, 0.0931f, -152.1025f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1237.8843f, -266.9654f, 38.3901f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-1.3350f, 0.0931f, -152.1025f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1239.5111f, -260.8066f, 52.1922f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-74.7780f, -0.0000f, 68.5204f);
                    fakeGarageDriveData.fCamFov1 = 35.1098f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1239.0067f, -261.1324f, 52.0514f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-76.1127f, -0.0000f, 74.6274f);
                    fakeGarageDriveData.fCamFov2 = 35.1098f;
                    fakeGarageDriveData.iCamDuration = 2500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    fakeGarageDriveData.vStartPoint = new Vector3(901.1611f, -145.4026f, 76.2495f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.7765f, -2.8131f, 147.5402f);
                    fakeGarageDriveData.vEndPoint = new Vector3(895.7946f, -153.8396f, 76.1140f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.7765f, -2.8131f, 147.5402f);
                    fakeGarageDriveData.fDuration = 2200f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(905.2103f, -144.0690f, 87.2221f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-70.3870f, 0.0000f, 110.7201f);
                    fakeGarageDriveData.fCamFov1 = 50.0000f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(904.7272f, -143.8318f, 87.3027f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-62.3467f, -0.0000f, 132.8678f);
                    fakeGarageDriveData.fCamFov2 = 50.0000f;
                    fakeGarageDriveData.iCamDuration = 2500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1408.2008f, 538.2416f, 122.5593f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.3128f, 0.0125f, -87.6001f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1398.2097f, 538.6603f, 122.6139f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.3128f, 0.0125f, -87.6001f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1406.4348f, 546.4155f, 127.3461f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-34.0193f, -0.0000f, 162.6676f);
                    fakeGarageDriveData.fCamFov1 = 46.5333f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1406.4348f, 546.4155f, 127.3461f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-34.0193f, -0.0000f, 162.6676f);
                    fakeGarageDriveData.fCamFov2 = 46.5333f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    fakeGarageDriveData.vStartPoint = new Vector3(1351.3232f, -1574.6200f, 53.6865f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.2167f, -0.0377f, 32.6254f);
                    fakeGarageDriveData.vEndPoint = new Vector3(1346.4000f, -1567.7000f, 53.7243f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.2167f, -0.0377f, 32.6254f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(1344.5973f, -1573.5840f, 61.6032f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-56.1653f, -0.0000f, -87.1267f);
                    fakeGarageDriveData.fCamFov1 = 57.8171f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(1344.5973f, -1573.5840f, 61.6032f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-56.1653f, -0.0000f, -87.1267f);
                    fakeGarageDriveData.fCamFov2 = 57.8171f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    fakeGarageDriveData.vStartPoint = new Vector3(-104.4773f, 6533.8853f, 29.4492f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0286f, 0.0007f, -134.9083f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-97.3950f, 6526.8257f, 29.4542f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0286f, 0.0007f, -134.9083f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-106.5683f, 6526.1616f, 36.5415f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-43.0312f, -0.0000f, -29.0363f);
                    fakeGarageDriveData.fCamFov1 = 50.0000f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-106.5683f, 6526.1616f, 36.5415f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-43.0312f, -0.0000f, -29.0363f);
                    fakeGarageDriveData.fCamFov2 = 50.0000f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    fakeGarageDriveData.vStartPoint = new Vector3(-294.8630f, 6338.3862f, 31.9149f);
                    fakeGarageDriveData.vStartRotation = new Vector3(4.6208f, -0.1441f, -134.9575f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-287.8097f, 6331.3433f, 32.7205f);
                    fakeGarageDriveData.vEndRotation = new Vector3(4.6208f, -0.1441f, -134.9575f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-297.9726f, 6326.8555f, 39.1224f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-35.2856f, -0.0000f, -23.8657f);
                    fakeGarageDriveData.fCamFov1 = 43.3183f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-297.9726f, 6326.8555f, 39.1224f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-35.2856f, -0.0000f, -23.8657f);
                    fakeGarageDriveData.fCamFov2 = 43.3183f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    fakeGarageDriveData.vStartPoint = new Vector3(-11.5786f, 6563.2603f, 31.5991f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.4487f, 0.0096f, 43.5465f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-18.4679f, 6570.5083f, 31.5208f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.4487f, 0.0096f, 43.5465f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-20.8243f, 6563.2583f, 37.9402f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-40.7407f, 0.0000f, -88.5192f);
                    fakeGarageDriveData.fCamFov1 = 46.2911f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-20.8243f, 6563.2583f, 37.9402f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-40.7407f, 0.0000f, -88.5192f);
                    fakeGarageDriveData.fCamFov2 = 46.2911f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    fakeGarageDriveData.vStartPoint = new Vector3(1883.8129f, 3769.6204f, 32.5041f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0435f, 1.3623f, 26.9842f);
                    fakeGarageDriveData.vEndPoint = new Vector3(1879.2754f, 3778.5317f, 32.5117f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0435f, 1.3623f, 26.9842f);
                    fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(1890.1251f, 3779.8413f, 38.7186f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-30.0362f, 0.0000f, 151.4523f);
                    fakeGarageDriveData.fCamFov1 = 48.4090f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(1890.1251f, 3779.8413f, 38.7186f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-30.0362f, 0.0000f, 151.4523f);
                    fakeGarageDriveData.fCamFov2 = 48.4090f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    //			fakeGarageDriveData.vStartPoint = new Vector3(1662.8229f, 4768.1626f, 41.6475f);
                    //			fakeGarageDriveData.vStartRotation = new Vector3(0.0383f, 0.0000f, 97.9564f);
                    //			fakeGarageDriveData.vEndPoint = new Vector3(1652.9192f, 4766.7783f, 41.6542f);
                    //			fakeGarageDriveData.vEndRotation = new Vector3(0.0383f, 0.0000f, 97.9564f);
                    //			fakeGarageDriveData.fDuration = 2000f;
                    fakeGarageDriveData.vStartPoint = new Vector3(1665.0555f, 4768.7563f, 41.8482f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.9197f, 0.0146f, 99.2382f);
                    fakeGarageDriveData.vEndPoint = new Vector3(1650.0370f, 4766.3193f, 41.9365f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0783f, 0.0154f, 98.2428f);
                    fakeGarageDriveData.fDuration = 3000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(1657.9930f, 4760.9766f, 45.8312f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-24.6537f, 0.0000f, -29.8021f);
                    fakeGarageDriveData.fCamFov1 = 54.0505f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(1657.9930f, 4760.9766f, 45.8312f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-24.6537f, 0.0000f, -29.8021f);
                    fakeGarageDriveData.fCamFov2 = 54.0505f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    fakeGarageDriveData.vStartPoint = new Vector3(-189.9290f, 502.0752f, 134.0467f);
                    fakeGarageDriveData.vStartRotation = new Vector3(7.2756f, 4.3579f, -163.5091f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-187.3726f, 494.6655f, 134.4831f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.1435f, 0.7666f, -167.0400f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-188.2829f, 500.4548f, 144.2996f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-85.1251f, -0.4581f, 128.5047f);
                    fakeGarageDriveData.fCamFov1 = 31.4222f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-188.2829f, 500.4548f, 144.2996f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-85.1251f, -0.4581f, 128.5047f);
                    fakeGarageDriveData.fCamFov2 = 31.4222f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.4000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B: //drive in cam:
                    fakeGarageDriveData.vStartPoint = new Vector3(353.5861f, 437.3159f, 146.3978f);
                    fakeGarageDriveData.vStartRotation = new Vector3(18.2917f, 0.4457f, 116.5296f);
                    fakeGarageDriveData.vEndPoint = new Vector3(346.9411f, 433.8934f, 147.4128f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.1583f, 0.4457f, 116.5296f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(353.0261f, 431.7783f, 149.5573f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-8.9158f, -0.0000f, -12.4275f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(353.3477f, 431.4130f, 149.6069f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-9.6238f, -0.0697f, 8.5029f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    fakeGarageDriveData.vStartPoint = new Vector3(-753.7995f, 627.2748f, 142.2250f);
                    fakeGarageDriveData.vStartRotation = new Vector3(5.9057f, 0.7576f, 101.0971f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-759.1145f, 625.1973f, 142.4425f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.7693f, -0.1674f, 114.0971f);
                    fakeGarageDriveData.fDuration = 3500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-754.6390f, 627.8649f, 150.0208f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-83.7416f, 0.0092f, -144.6354f);
                    fakeGarageDriveData.fCamFov1 = 34f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-754.6390f, 627.8649f, 150.0208f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-83.7416f, 0.0092f, -144.6354f);
                    fakeGarageDriveData.fCamFov2 = 34f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.4000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    fakeGarageDriveData.vStartPoint = new Vector3(-684.6121f, 602.4670f, 143.3149f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.7773f, 2.4556f, -137.5184f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-679.9671f, 597.5770f, 143.3449f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.4977f, 2.4556f, -142.8434f);
                    fakeGarageDriveData.fDuration = 3500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-687.9766f, 597.0465f, 142.8633f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(8.3745f, -0.0033f, -24.2560f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-688.2665f, 597.2999f, 142.8524f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-1.1852f, -0.0123f, -39.3913f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1500;
                    fakeGarageDriveData.fCamShake = 0.4000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(131.7292f, 567.2824f, 182.3064f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-2.0400f, 0.0000f, 180.0000f);
                    fakeGarageDriveData.vEndPoint = new Vector3(131.7292f, 561.9020f, 182.3532f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-2.0400f, 0.0000f, 180.0000f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(127.2599f, 566.0569f, 188.9683f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-51.7424f, -0.0000f, -52.1745f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(127.2599f, 566.0569f, 188.9683f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-51.7424f, -0.0000f, -52.1745f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(-554.6328f, 666.1597f, 144.4448f);
                    fakeGarageDriveData.vStartRotation = new Vector3(12.1488f, -4.1148f, 161.8071f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-556.8428f, 659.8797f, 145.7748f);
                    fakeGarageDriveData.vEndRotation = new Vector3(12.1488f, -4.1148f, 161.8071f);
                    fakeGarageDriveData.fDuration = 3000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-556.2558f, 663.2256f, 149.0134f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-61.6587f, -0.0293f, -33.2598f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-556.2558f, 663.2256f, 149.0134f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-61.6587f, -0.0293f, -33.2598f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.4000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(-742.3668f, 602.2495f, 141.6722f);
                    fakeGarageDriveData.vStartRotation = new Vector3(1.5600f, 1.1055f, 138.9600f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-745.9068f, 597.5695f, 142.2622f);
                    fakeGarageDriveData.vEndRotation = new Vector3(5.5600f, 0.8055f, 144.6600f);
                    fakeGarageDriveData.fDuration = 3000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-741.5162f, 601.4786f, 147.0677f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-70.3517f, 2.6961f, -2.4030f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-741.5162f, 601.4786f, 147.0677f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-70.3517f, 2.6961f, -2.4030f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(-861.3705f, 702.3333f, 148.2944f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.1980f, -1.8465f, 143.2800f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-867.1995f, 693.5106f, 148.8968f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.1980f, -1.8465f, 143.2800f);
                    fakeGarageDriveData.fDuration = 4500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-864.9432f, 696.2421f, 151.3598f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-52.4190f, 0.0762f, -6.1500f);
                    fakeGarageDriveData.fCamFov1 = 60.1590f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-864.9432f, 696.2421f, 151.3598f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-52.4190f, 0.0762f, -6.1500f);
                    fakeGarageDriveData.fCamFov2 = 60.1590f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                //		case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_11_A:
                //			fakeGarageDriveData.vStartPoint = new Vector3(-912.3926f, 699.3450f, 151.0507f);
                //			fakeGarageDriveData.vStartRotation = new Vector3(-0.2255f, -3.4134f, 163.0253f);
                //			fakeGarageDriveData.vEndPoint = new Vector3(-914.2726f, 690.6950f, 151.0507f);
                //			fakeGarageDriveData.vEndRotation = new Vector3(-0.2255f, -3.4134f, 163.0253f);
                //			fakeGarageDriveData.fDuration = 4500f;
                //
                //			fakeGarageDriveData.vCamCoord1 = new Vector3(-911.9498f, 695.1615f, 154.1081f);
                //			fakeGarageDriveData.vCamRot1 = new Vector3(-56.0922f, 0.0000f, 57.1575f);
                //			fakeGarageDriveData.fCamFov1 = 50.0f;
                //			fakeGarageDriveData.vCamCoord2 = new Vector3(-911.9498f, 695.1615f, 154.1081f);
                //			fakeGarageDriveData.vCamRot2 = new Vector3(-56.0922f, 0.0000f, 57.1575f);
                //			fakeGarageDriveData.fCamFov2 = 50.0f;
                //			fakeGarageDriveData.iCamDuration = 1000;
                //			fakeGarageDriveData.fCamShake = 0.3000f;
                //			fakeGarageDriveData.camGraphType = 3;
                //		break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1297.2590f, 457.8409f, 97.0725f);
                    fakeGarageDriveData.vStartRotation = new Vector3(-0.9738f, -5.2755f, 180.1808f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1297.2590f, 451.0709f, 97.1425f);
                    fakeGarageDriveData.vEndRotation = new Vector3(-0.9738f, -5.2755f, 180.1808f);
                    fakeGarageDriveData.fDuration = 4500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1297.4442f, 455.3719f, 100.2617f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-89.5011f, 0.0065f, 0.1323f);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1297.4442f, 455.3719f, 100.2617f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-89.5011f, 0.0065f, 0.1323f);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    fakeGarageDriveData.vStartPoint = new Vector3(393.6284f, 431.2094f, 142.9430f);
                    fakeGarageDriveData.vStartRotation = new Vector3(13.8146f, 2.1126f, 175.169f);
                    fakeGarageDriveData.vEndPoint = new Vector3(393.6284f, 425.1094f, 144.5730f);
                    fakeGarageDriveData.vEndRotation = new Vector3(10.8146f, 2.7126f, 175.169f);
                    fakeGarageDriveData.fDuration = 4500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(393.8496f, 427.7094f, 150.9641f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-77.3182f, -0.0367f, 30.5176f);
                    fakeGarageDriveData.fCamFov1 = 37.9878f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(393.8496f, 427.7094f, 150.9641f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-77.3182f, -0.0367f, 30.5176f);
                    fakeGarageDriveData.fCamFov2 = 37.9878f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3000f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    fakeGarageDriveData.vStartPoint = new Vector3(257.6366f, -1800.4467f, 26.5774f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, -130f);
                    fakeGarageDriveData.vEndPoint = new Vector3(268.6786f, -1809.8590f, 26.5774f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, -130f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(257.6866f, -1801.5112f, 31.0237f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-75.1987f, -0.0000f, -22.5891f);
                    fakeGarageDriveData.fCamFov1 = 42.1790f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(257.6866f, -1801.5112f, 31.0237f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-75.1987f, -0.0000f, -42.2620f);
                    fakeGarageDriveData.fCamFov2 = 42.1790f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1469.1f, -928f, 10.691574f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 140.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1476.6f, -940.0f, 10.691574f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 140.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1470.0514f, -928.5242f, 16.6866f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-82.1395f, -0.0000f, -134.2994f);
                    fakeGarageDriveData.fCamFov1 = 37.1847f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1470.0514f, -928.5242f, 16.6866f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-82.1395f, -0.0000f, -149.2751f);
                    fakeGarageDriveData.fCamFov2 = 37.1847f;
                    fakeGarageDriveData.iCamDuration = 800;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    fakeGarageDriveData.vStartPoint = new Vector3(37.8f, -1021.5f, 28.4774f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 247.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(52.0f, -1026f, 28.4774f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 247.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(39.7338f, -1022.8085f, 36.9206f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-83.2489f, -0.0000f, 8.4950f);
                    fakeGarageDriveData.fCamFov1 = 30.4260f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(39.7338f, -1022.8085f, 36.9206f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-83.2490f, -0.0000f, -9.5499f);
                    fakeGarageDriveData.fCamFov2 = 30.4260f;
                    fakeGarageDriveData.iCamDuration = 800;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    fakeGarageDriveData.vStartPoint = new Vector3(52.1569f, 2786.6475f, 56.8783f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 320.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(60.0158f, 2796.0447f, 56.8783f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 320.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(53.2243f, 2786.7935f, 62.0157f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-78.0797f, 0.0000f, 78.7165f);
                    fakeGarageDriveData.fCamFov1 = 38.1005f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(53.2243f, 2786.7935f, 62.0157f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-78.0796f, -0.0000f, 63.1088f);
                    fakeGarageDriveData.fCamFov2 = 38.1005f;
                    fakeGarageDriveData.iCamDuration = 800;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    fakeGarageDriveData.vStartPoint = new Vector3(-355.0497f, 6067.2222f, 30.4985f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 225.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-346.0f, 6058.0f, 30.4984f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 225.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-354.5774f, 6065.5049f, 37.1598f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-77.1198f, -0.0000f, -3.0303f);
                    fakeGarageDriveData.fCamFov1 = 38.6331f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-354.5774f, 6065.5049f, 37.1598f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-79.2176f, -0.0000f, -20.0852f);
                    fakeGarageDriveData.fCamFov2 = 38.6331f;
                    fakeGarageDriveData.iCamDuration = 800;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    fakeGarageDriveData.vStartPoint = new Vector3(1730.8097f, 3709.5325f, 33.1846f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 198.1396f);
                    fakeGarageDriveData.vEndPoint = new Vector3(1736.2354f, 3695.5264f, 33.4914f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 198.1396f);
                    fakeGarageDriveData.fDuration = 3500f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(1729.4021f, 3707.7197f, 39.3357f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-70.1444f, 0.0000f, -66.4882f);
                    fakeGarageDriveData.fCamFov1 = 31.5493f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(1729.4021f, 3707.7197f, 39.3357f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-70.5110f, -0.0000f, -86.7802f);
                    fakeGarageDriveData.fCamFov2 = 31.5493f;
                    fakeGarageDriveData.iCamDuration = 800;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    fakeGarageDriveData.vStartPoint = new Vector3(943.6209f, -1456.3628f, 30.3297f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 180.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(943.6209f, -1471.5f, 30.3297f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 180.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(942.4880f, -1457.9991f, 36.5272f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-81.0827f, -0.0000f, -71.0876f);
                    fakeGarageDriveData.fCamFov1 = 40.8165f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(942.4880f, -1457.9991f, 36.5272f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-81.0827f, -0.0000f, -90.3366f);
                    fakeGarageDriveData.fCamFov2 = 40.8165f;
                    fakeGarageDriveData.iCamDuration = 3000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    fakeGarageDriveData.vStartPoint = new Vector3(178.2f, 306.4690f, 104.3727f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 5.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(177.0f, 319.688690f, 104.3731f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 5.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(179.8012f, 308.6315f, 108.8320f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-63.8798f, -0.0000f, 113.2677f);
                    fakeGarageDriveData.fCamFov1 = 42.3784f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(179.8012f, 308.6315f, 108.8320f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-63.8798f, -0.0000f, 93.4493f);
                    fakeGarageDriveData.fCamFov2 = 42.3784f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    fakeGarageDriveData.vStartPoint = new Vector3(-17.5f, -195.051f, 51.3705f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 337.5201f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-9.7f, -176.0f, 51.3595f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 337.5201f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-16.0176f, -194.0540f, 58.9096f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-80.4747f, -0.0000f, 101.3275f);
                    fakeGarageDriveData.fCamFov1 = 29.5301f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-16.0176f, -194.0540f, 58.9096f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-80.4747f, -0.0000f, 85.3781f);
                    fakeGarageDriveData.fCamFov2 = 29.5301f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    fakeGarageDriveData.vStartPoint = new Vector3(2466.0662f, 4101.5767f, 37.0647f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 248.0f);
                    fakeGarageDriveData.vEndPoint = new Vector3(2480.0f, 4096.1f, 37.0647f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 248.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(2467.4023f, 4100.0684f, 42.1736f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-74.8660f, -0.0000f, 6.4042f);
                    fakeGarageDriveData.fCamFov1 = 41.0943f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(2467.4023f, 4100.0684f, 42.1736f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-74.8660f, -0.0000f, -11.8805f);
                    fakeGarageDriveData.fCamFov2 = 41.0943f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    fakeGarageDriveData.vStartPoint = new Vector3(-34.3f, 6423.0f, 30.4253f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 44.1740f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-48.1f, 6436.0f, 30.4900f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 45.0f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-33.8482f, 6425.3506f, 38.4516f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-76.6605f, -0.0000f, 156.2424f);
                    fakeGarageDriveData.fCamFov1 = 28.3078f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-33.8482f, 6425.3506f, 38.4516f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-76.6605f, -0.0000f, 132.6993f);
                    fakeGarageDriveData.fCamFov2 = 28.3078f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    fakeGarageDriveData.vStartPoint = new Vector3(-1146.4874f, -1578.8573f, 3.300f);
                    fakeGarageDriveData.vStartRotation = new Vector3(0.0f, 0.0f, 31.2024f);
                    fakeGarageDriveData.vEndPoint = new Vector3(-1155.0887f, -1565.3911f, 3.4282f);
                    fakeGarageDriveData.vEndRotation = new Vector3(0.0f, 0.0f, 31.2024f);
                    fakeGarageDriveData.fDuration = 4000f;
                    fakeGarageDriveData.vCamCoord1 = new Vector3(-1146.7966f, -1577.4719f, 9.1906f);
                    fakeGarageDriveData.vCamRot1 = new Vector3(-78.1286f, -0.0000f, 162.1961f);
                    fakeGarageDriveData.fCamFov1 = 38.4125f;
                    fakeGarageDriveData.vCamCoord2 = new Vector3(-1146.7966f, -1577.4719f, 9.1906f);
                    fakeGarageDriveData.vCamRot2 = new Vector3(-78.1286f, -0.0000f, 142.8614f);
                    fakeGarageDriveData.fCamFov2 = 38.4125f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    fakeGarageDriveData.vStartPoint = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 0, false);
                    fakeGarageDriveData.vStartRotation = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 0, true);
                    fakeGarageDriveData.vEndPoint = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 1, false);
                    fakeGarageDriveData.vEndRotation = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 1, true);
                    fakeGarageDriveData.fDuration = 3000f;
                    fakeGarageDriveData.vCamCoord1 = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 2, false);
                    fakeGarageDriveData.vCamRot1 = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 2, true);
                    fakeGarageDriveData.fCamFov1 = 50.0f;
                    fakeGarageDriveData.vCamCoord2 = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 3, false);
                    fakeGarageDriveData.vCamRot2 = GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(iBuilding, 3, true);
                    fakeGarageDriveData.fCamFov2 = 50.0f;
                    fakeGarageDriveData.iCamDuration = 1000;
                    fakeGarageDriveData.fCamShake = 0.3f;
                    fakeGarageDriveData.camGraphType = 3;
                    break;
            }
        }
        private static Vector3 GET_OFFICE_GARAGE_FAKE_DRIVE_DATA_AS_OFFSET(BuildingsEnum iBuilding, int i, bool bRotation)
        {
            Position[] tempStruct = [new(), new(), new()];
            // Base for offset - OFFICE 1
            tempStruct[0] = new(-1535.10f, -581.22f, 24.71f, 0.0f, 0.0f, -146.31f);
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    tempStruct[1] = new(-1535.10f, -581.22f, 24.71f, 0.0f, 0.0f, -146.31f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    tempStruct[1] = new(-1358.03f, -471.41f, 30.61f, 0.0f, 0.0f, -81.19f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    tempStruct[1] = new(-142.62f, -572.42f, 31.42f, 0.0f, 0.0f, -19.8f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    tempStruct[1] = new(-84.87f, -825.55f, 35.05f, 0.0f, 0.0f, 170.0f);
                    break;
            }
            switch (i)
            {
                case 0: // Vehicle starting position for OFFICE 1
                    tempStruct[2] = new(-1542.3057f, -570.4739f, 24.7079f, 0.0f, 0.0f, 214.3476f);
                    break;
                case 1: // Vehicle ending position for OFFICE 1
                    tempStruct[2] = new(-1537.7513f, -577.1400f, 24.7078f, 0.0f, 0.0f, 214.3470f);
                    break;
                case 2: // Camera position 1 for OFFICE 1
                    tempStruct[2] = new(-1543.532593f, -575.844360f, 26.087002f, 13.052541f, -0.000000f, -48.858231f);
                    break;
                case 3: // Camera position 2 for OFFICE 1
                    tempStruct[2] = new(-1543.532593f, -575.844360f, 26.087002f, 13.052541f, -0.000000f, -48.858231f);
                    break;
            }
            Vector3 vOffset = (tempStruct[2] - tempStruct[0]).ToVector3;
            vOffset = PropertyFunctions.RotateVectorAboutZ(vOffset, -tempStruct[0].Yaw);
            vOffset = PropertyFunctions.RotateVectorAboutZ(vOffset, tempStruct[1].Yaw);
            tempStruct[2] = new Position(GetObjectOffsetFromCoords(tempStruct[1].X, tempStruct[1].Y, tempStruct[1].Z, 0.0f, vOffset.X, vOffset.Y, vOffset.Z), tempStruct[2].ToRotationVector);
            if (tempStruct[0].Yaw > 180.0f)
                tempStruct[0].Yaw -= 360.0f;
            if (tempStruct[0].Yaw < -180.0f)
                tempStruct[0].Yaw += 360.0f;
            if (tempStruct[1].Yaw > 180.0f)
                tempStruct[1].Yaw -= 360.0f;
            if (tempStruct[1].Yaw < -180.0f)
                tempStruct[1].Yaw += 360.0f;
            tempStruct[2].Yaw = tempStruct[2].Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
            if (tempStruct[2].Yaw > 180.0f)
                tempStruct[2].Yaw -= 360.0f;
            if (tempStruct[2].Yaw < -180.0f)
                tempStruct[2].Yaw += 360.0f;
            if (bRotation)
                return tempStruct[2].ToRotationVector;
            else
                return tempStruct[2].ToVector3;
        }

        private static bool PlayerIsInArcadiusUndergroundCarPark()
        {
            return IsEntityInAngledArea(PlayerPedId(), -181.591f, -663.244f, 24.799f, -146.266f, -566.319f, 39.349f, 88.375f, false, false, 0);
        }

        private static void ClearAll()
        {
            if (bInteriorPinned)
            {
                if (IsValidInterior(officeGarageDoorInterior) && IsInteriorReady(officeGarageDoorInterior))
                {
                    UnpinInterior(officeGarageDoorInterior);
                }
                bInteriorPinned = false;
            }
            if (bLoadedElevatorSounds)
            {
                ReleaseNamedScriptAudioBank("DLC_IMPORTEXPORT/GARAGE_ELEVATOR");
            }
            for (int i = 0; i < 2; i++)
            {
                if (DoesEntityExist(officeGarageDoors[i]))
                    DeleteObject(ref officeGarageDoors[i]);
            }
            if (officeGarageExternalDoor != null && officeGarageExternalDoor.Exists())
                officeGarageExternalDoor.Delete();

            if (Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.SetEntryData))
                ClearBit(ref iLocalBS2, (int)LOCAL_BS2.SetEntryData);
            ResetToEntranceToPropertyStage();
            DeleteClonedEntitiesAndClearRequests();
            bool bDriver = false;
            if (bCleanupFakeGarageEnter)
            {
                if (PlayerCache.MyPed.IsInVehicle())
                {
                    Vehicle tempVeh = PlayerCache.MyPed.CurrentVehicle;
                    if (tempVeh.Driver == PlayerCache.MyPed)
                        bDriver = true;
                }
                if (!bDriver)
                {
                    CutsceneHelper.CleanupMPCutscene(true, false);
                }
                if (!PlayerCache.MyPed.IsInVehicle())
                    SetEntityCollision(PlayerPedId(), true, true);
                bCleanupFakeGarageEnter = false;
            }
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_6)
                Function.Call(Hash.REMOVE_MODEL_HIDE, -935.040f, -378.360f, 39.180f, 2f, Functions.HashInt("PROP_QL_REVOLVING_DOOR"), true);
            if (Properties[(int)CurrentPropertyID].BuildingID == BuildingsEnum.MP_PROPERTY_BUILDING_38)
            {
                Function.Call(Hash.REMOVE_MODEL_HIDE, 2494.2651, 1587.5674, 31.7398, 0.02f, Functions.HashInt("PROP_FNCLINK_02GATE3"), false);
                Function.Call(Hash.REMOVE_MODEL_HIDE, 2484.0889, 1566.9988, 31.7453, 0.02f, Functions.HashInt("PROP_FNCLINK_02GATE3"), false);
            }

            if (Functions.IsBitSet(iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage))
            {
                if (PlayerCache.MyPed.IsInVehicle())
                {
                    Vehicle vehFadeOut = PlayerCache.MyPed.CurrentVehicle;
                    if (vehFadeOut.Driver == PlayerCache.MyPed)
                    {
                        vehFadeOut.IsVisible = true;
                        PlayerCache.MyPed.IsVisible = true;
                    }
                }
                else
                {
                    PlayerCache.MyPed.IsVisible = true;
                    NetworkSetLocalPlayerInvincibleTime(0);
                }
                ClearBit(ref iLocalBS2, (int)LOCAL_BS2.bFadeOutWarpIntoGarage);
            }
            forSaleSign?.Delete();
            Initialized = false;
        }
    }

    public class MPFakeGarageDriveStruct
    {
        //Vehicle
        public Vector3 vStartPoint { get; set; }
        public Vector3 vStartRotation { get; set; }
        public Vector3 vEndPoint { get; set; }
        public Vector3 vEndRotation { get; set; }
        public float fDuration { get; set; }

        //Camera
        public Vector3 vCamCoord1 { get; set; }
        public Vector3 vCamRot1 { get; set; }
        public float fCamFov1 { get; set; }

        public Vector3 vCamCoord2 { get; set; }
        public Vector3 vCamRot2 { get; set; }
        public float fCamFov2 { get; set; }

        public int iCamDuration { get; set; }
        public float fCamShake { get; set; }
        public int camGraphType { get; set; }
    }
}