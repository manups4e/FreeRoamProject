using FreeRoamProject.Shared.Core.ApartmentsShared;
using FreeRoamProject.Shared.Core.Doors;
using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    public enum WalkOutGaragePans
    {
        WalkOutGarage_PAN_null,
        WalkOutGarage_PAN_MAX
    }

    public enum WalkOutGarageCuts
    {
        WalkOutGarage_CUT_shot = 0,
        WalkOutGarage_CUT_MAX
    }

    public enum WalkOutGarageMarkers
    {
        WalkOutGarage_MARKER_walkTo,
        WalkOutGarage_MARKER_MAX
    }

    public enum WalkOutGaragePlacers
    {
        WalkOutGarage_PLACER_startCoords_0,
        WalkOutGarage_PLACER_startCoords_1,
        WalkOutGarage_PLACER_MAX
    }

    enum GARAGE_PED_LEAVE_CUTSCENE_STAGE
    {
        GARAGE_PED_LEAVE_CUTSCENE_INIT = 0,
        GARAGE_PED_LEAVE_CUTSCENE_TRIGGER_CUT,
        GARAGE_PED_LEAVE_CUTSCENE_WAIT_FOR_LOAD,
        GARAGE_PED_LEAVE_CUTSCENE_WAIT_FOR_OPEN_DOOR,
        GARAGE_PED_LEAVE_CUTSCENE_WAIT_FOR_EXIT,
        GARAGE_PED_WARP_TO_UNOCCUPIED_AREA,
        GARAGE_PED_SET_IN_UNOCCUPIED_AREA,
        GARAGE_PED_LEAVE_CUTSCENE_COMPLETE
    }
    public class STRUCT_WalkOutGarage
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)WalkOutGaragePans.WalkOutGarage_PAN_MAX];
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)WalkOutGarageCuts.WalkOutGarage_CUT_MAX];
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_MAX];
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_MAX];
        public bool[] bEnablePans = new bool[(int)WalkOutGaragePans.WalkOutGarage_PAN_MAX];
        public Vector3 vDoorPos1 { get; set; }
        public Vector3 vDoorPos2 { get; set; }
        public Vector3 vDoorPos3 { get; set; }
        public float fExitDelay { get; set; }
    }

    public struct FAKE_PED_EXIT_GARAGE_DATA
    {
        public int fakeExitPed { get; set; }
        public MpDoorDetails garageDoor = new();
        public int iBS { get; set; }
        public FAKE_PED_EXIT_GARAGE_DATA() { }
    }

    internal class WalkOutOfGarageHelper
    {
        public static int FAKE_PED_EXIT_GARAGE_WARP_POSSIBLE = 0;
        public static int FAKE_PED_EXIT_GARAGE_WARP_DONE = 1;
        public static int FAKE_PED_EXIT_GARAGE_ADDED_CUST_SPAWN = 2;


        public static bool Get_WalkOutGarage(BuildingsEnum iBuildingID, ref STRUCT_WalkOutGarage scene)
        {
            switch (iBuildingID)
            {
                case 0:
                    return false;

                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(0.0000f, 0.0000f, 0.000f, 0.0000f, 0.0000f, 0.0000f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 0.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 0.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-797.2457f, 320.9005f, 86.5710f, -1.4479f, 0.0000f, -173.3266f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(0.0000f, 0.0000f, 0.0000f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-795.9908f, 320.5264f, 84.6913f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 180.9339f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-796.4648f, 308.5788f, 84.7048f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 180.0000f;
                    scene.vDoorPos1 = new(-798.967651f, 313.991486f, 84.705750f);
                    scene.vDoorPos2 = new(-795.849182f, 314.308655f, 84.701675f);
                    scene.vDoorPos3 = new(-792.878845f, 314.504852f, 84.699097f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-932.7474f, -383.9246f, 42.9613f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-932.7474f, -383.9246f, 45.461f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-878.9250f, -355.4584f, 35.7946f, 6.6901f, -0.0000f, -167.9745f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-876.2924f, -364.0820f, 35.5610f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-881.0963f, -354.6912f, 34.2618f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 204.4800f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-876.3240f, -364.1094f, 35.5636f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 207.3600f;
                    scene.vDoorPos1 = new(-876.418823f, -358.469299f, 34.920353f);
                    scene.vDoorPos2 = new(-879.781738f, -360.224945f, 34.828461f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-619.1315f, 37.8841f, 47.5883f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-619.1315f, 37.8841f, 50.088f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-626.4656f, 59.2381f, 44.0759f, 1.5216f, 0.0000f, 107.2253f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-635.0194f, 56.9403f, 42.7605f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-623.6274f, 57.5262f, 42.7295f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 99.0000f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-634.6904f, 57.2514f, 42.7774f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 0.0000f;
                    scene.vDoorPos1 = new(-629.773926f, 59.266457f, 42.724987f);
                    scene.vDoorPos2 = new(-629.822937f, 55.832752f, 42.724960f);
                    scene.vDoorPos3 = new(-629.732056f, 52.372917f, 42.725010f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-47.3145f, -585.9766f, 41.9593f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-47.3145f, -585.9766f, 44.459f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-37.4006f, -619.0651f, 35.6844f, 0.1928f, 0.0000f, -127.8392f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-27.0036f, -623.9375f, 34.4608f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-37.4249f, -620.4834f, 34.0698f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 253.8000f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-32.5265f, -622.1819f, 34.1244f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 253.8000f;
                    scene.vDoorPos1 = new(-33.880001f, -621.538513f, 34.038071f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-252.5713f, -949.9199f, 35.2210f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-252.5713f, -949.9199f, 37.721f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-286.3485f, -991.8517f, 24.5451f, -0.5902f, -0.0000f, -124.2111f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-276.9672f, -997.3885f, 24.0628f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-287.2802f, -993.2685f, 23.1368f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 251.2500f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-276.7173f, -997.4412f, 24.1063f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 247.5000f;
                    scene.vDoorPos1 = new(-282.026947f, -993.643066f, 23.303766f);
                    scene.vDoorPos2 = new(-283.157166f, -996.661743f, 23.483461f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-1443.0938f, -544.7684f, 38.7424f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-1443.0938f, -544.7684f, 41.242f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-1454.1522f, -509.1251f, 32.2253f, -2.2188f, 0.0000f, 19.8287f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-1457.6260f, -500.9148f, 31.4627f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-1452.4513f, -508.5775f, 30.9113f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 29.1600f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-1452.4985f, -508.4085f, 30.9163f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 30.6000f;
                    scene.vDoorPos1 = new(-1456.828247f, -505.130096f, 31.242815f);
                    scene.vDoorPos2 = new(-1454.213867f, -503.342804f, 30.570770f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-913.8500f, -455.1392f, 43.5999f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-913.8500f, -455.1392f, 46.099f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-815.3887f, -433.1594f, 36.5962f, 6.3730f, 0.0000f, 123.6414f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-824.7270f, -438.2999f, 35.6399f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-818.2505f, -431.6903f, 35.0843f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 136.8000f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-824.8032f, -438.3822f, 35.6399f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 133.9200f;
                    scene.vDoorPos1 = new(-819.302307f, -438.809143f, 35.626488f);
                    scene.vDoorPos2 = new(-821.377380f, -435.120636f, 35.794361f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(-1608.8514f, -429.1840f, 44.4390f, 89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(-1608.8514f, -429.1840f, 46.939f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = new(-1601.8047f, -442.4136f, 39.4131f, -6.7813f, -0.0000f, 142.8609f);
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutGarageMarkers.WalkOutGarage_MARKER_walkTo].Pos = new(-1609.8853f, -452.7733f, 37.1659f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = new(-1601.3816f, -442.5541f, 37.2166f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 142.5000f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = new(-1610.0961f, -453.1568f, 37.1576f);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 142.5000f;
                    scene.vDoorPos1 = new(-1606.561279f, -445.916870f, 37.216648f);
                    scene.vDoorPos2 = new(-1603.390503f, -448.632263f, 37.216648f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                default:
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mStart.Pos = new(PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID) + new Vector3(0.0f, 0.0f, 5.0f), new Vector3(89.4999f, -0.0000f, 94.2595f));
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos = new(PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID) + new Vector3(0.0f, 0.0f, 7.5f), new Vector3(-89.4999f, -0.0000f, 94.2595f));
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov = GetGameplayCamFov();
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake = 0.25f;
                    scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fDuration = 6.500f;
                    scene.bEnablePans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null] = false;
                    scene.fExitDelay = 0.0000f;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].mCam.Pos = scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].mEnd.Pos;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fFov = scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fFov;
                    scene.mCuts[(int)WalkOutGarageCuts.WalkOutGarage_CUT_shot].fShake = scene.mPans[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].fShake;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].fRot = 0f;
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID);
                    scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_1].fRot = 0f;
                    scene.mMarkers[(int)WalkOutGaragePans.WalkOutGarage_PAN_null].Pos = scene.mPlacers[(int)WalkOutGaragePlacers.WalkOutGarage_PLACER_startCoords_0].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    return false;
            }
        }

        public static bool IsDoorBlocked(ref STRUCT_WalkOutGarage scene)
        {
            float fRadius = 2.0f;
            if (scene.vDoorPos1 != Vector3.Zero)
            {
                if (IsPositionOccupied(scene.vDoorPos1.X, scene.vDoorPos1.Y, scene.vDoorPos1.Z, fRadius, false, true, false, false, false, 0, false))
                    return true;
            }
            if (scene.vDoorPos2 != Vector3.Zero)
            {
                if (IsPositionOccupied(scene.vDoorPos2.X, scene.vDoorPos2.Y, scene.vDoorPos2.Z, fRadius, false, true, false, false, false, 0, false))
                    return true;
            }
            if (scene.vDoorPos1 != Vector3.Zero)
            {
                if (IsPositionOccupied(scene.vDoorPos3.X, scene.vDoorPos3.Y, scene.vDoorPos3.Z, fRadius, false, true, false, false, false, 0, false))
                    return true;
            }
            return false;
        }

        public static void GetPedExitGarageCoords(ref Position mpOffset, int iCurrentProperty, int iIndex)
        {
            PropertyData apart = PropertiesExteriorsManager.Properties[iCurrentProperty];
            mpOffset = new Position(apart.Garage.ExitPlayerPos, new Vector3(0, 0, apart.Garage.FromHousePlayerHeading));
        }
    }
}
