using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    enum DriveInPans
    {
        DriveIn_PAN_descent,
        DriveIn_PAN_MAX
    }

    enum DriveInCuts
    {
        DriveIn_CUT_null = 0,
        DriveIn_CUT_MAX
    }

    enum DriveInMarkers
    {
        DriveIn_MARKER_gotoA = 0,
        DriveIn_MARKER_gotoREVERSE,
        DriveIn_MARKER_gotoB,
        DriveIn_MARKER_MAX
    }

    enum DriveInPlacers
    {
        DriveIn_PLACER_resetCoords = 0,
        DriveIn_PLACER_MAX
    }

    enum DriveInAngArea
    {
        DriveIn_ANGAREA_area0 = 0,
        DriveIn_ANGAREA_MAX
    }

    public class STRUCT_DriveIn
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)DriveInPans.DriveIn_PAN_MAX] { new() };
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)DriveInCuts.DriveIn_CUT_MAX] { new() };
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)DriveInMarkers.DriveIn_MARKER_MAX] { new(), new(), new() };
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)DriveInPlacers.DriveIn_PLACER_MAX] { new() };
        public SceneTool_AngArea[] mAngAreas = new SceneTool_AngArea[(int)DriveInAngArea.DriveIn_ANGAREA_MAX] { new() };
        public bool[] bEnablePans = new bool[(int)DriveInPans.DriveIn_PAN_MAX] { new() };
        public float fExitDelay { get; set; }
    }

    internal class DriveIntoGarageHelper
    {
        public static Vector3 GetOfficeGarageVectorAsOffset(BuildingsEnum Building, int i, bool rotation)
        {
            Position[] tempStruct = [new Position(), new Position(), new Position()];
            tempStruct[0] = new Position(-1358.03f, -471.41f, 30.61f, 0.0f, 0.0f, -81.19f);
            switch (Building)
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

            int VehicleID;
            Vector3 vMin = new();
            Vector3 vMax = new();
            float fHeight;
            bool bIsBike = false;
            bool bIsBig = false;
            if (IsPedInAnyVehicle(PlayerPedId(), false))
            {
                VehicleID = GetVehiclePedIsIn(PlayerPedId(), false);
                if (DoesEntityExist(VehicleID) && !IsEntityDead(VehicleID))
                {
                    if (IsThisModelABike((uint)GetEntityModel(VehicleID)) || IsThisModelAQuadbike((uint)GetEntityModel(VehicleID)))
                    {
                        bIsBike = true;
                    }
                    else
                    {
                        GetModelDimensions((uint)GetEntityModel(VehicleID), ref vMin, ref vMax);
                        fHeight = vMax.Z - vMin.Z;
                        if (fHeight > 2.0f)
                        {
                            bIsBig = true;
                        }
                    }
                }
            }

            switch (i)
            {
                case 0: // Camera start position for OFFICE 2

                    if (bIsBike)
                        tempStruct[2] = new(-1358.6030f, -473.2463f, 32.1693f, -3.3136f, -0.0000f, 82.6857f);
                    else if (bIsBig)
                        tempStruct[2] = new(-1358.1569f, -473.4932f, 33.3569f, -15.8994f, -0.0000f, 69.3715f);
                    else
                        tempStruct[2] = new(-1358.2449f, -473.1768f, 32.2119f, -5.5905f, 0.0000f, 74.1722f);
                    break;
                case 1: // Camera end position for OFFICE 2
                    if (bIsBike)
                        tempStruct[2] = new(-1358.6030f, -473.2463f, 32.1693f, -3.3136f, -0.0000f, 82.6857f);
                    else if (bIsBig)
                        tempStruct[2] = new(-1358.1569f, -473.4932f, 33.3569f, -15.8994f, -0.0000f, 69.3715f);
                    else
                        tempStruct[2] = new(-1358.2449f, -473.1768f, 32.2119f, -5.5905f, 0.0000f, 74.1722f);
                    break;
                case 2: // Camera null position for OFFICE 2 (Possibly not used)
                    tempStruct[2] = new(-1358.2461f, -473.1762f, 32.0766f, -16.2814f, 0.0000f, 64.1577f);
                    break;
                case 3: // Go To A position for OFFICE
                    tempStruct[2] = new(-1359.0f, -471.6f, 30.5957f);
                    break;
                case 4: // Go To Reverse position for OFFICE 2
                    tempStruct[2] = new(-1362.241f, -472.036f, 30.5957f);
                    break;
                case 5: // Go To B position for OFFICE
                    tempStruct[2] = new(-1359.0f, -471.6f, 30.5957f);
                    break;
                case 6: // Vehicle starting position for OFFICE 2
                    tempStruct[2] = new(-1371.0309f, -473.4054f, 30.5939f, 0.0f, 0.0f, 278.8534f);
                    break;
                case 7: // Angled Area in elevator for OFFICE 2
                    tempStruct[2] = new(-1358.031860f, -471.419067f, 30.607216f, -1366.101685f, -472.662262f, 35.016788f);
                    break;
                case 8: // Left elevator door
                    tempStruct[2] = new(-1365.925f, -474.760f, 30.600f, 0.0f, 0.0f, 99.250f);
                    break;
                case 9: // Right elevator door
                    tempStruct[2] = new(-1366.572f, -470.598f, 30.600f, 0.0f, 0.0f, 99.250f);
                    break;
                case 10: // Left elevator door - open
                    tempStruct[2] = new(-1365.592f, -476.897f, 30.600f, 0.0f, 0.0f, 99.250f);
                    break;
                case 11: // Right elevator door - open 
                    tempStruct[2] = new(-1366.929f, -468.485f, 30.600f, 0.0f, 0.0f, 99.250f);
                    break;
            }

            Vector3 vOffset = tempStruct[2].ToVector3 - tempStruct[0].ToVector3;
            vOffset = PropertyFunctions.RotateVectorAboutZ(vOffset, -tempStruct[0].Yaw);
            vOffset = PropertyFunctions.RotateVectorAboutZ(vOffset, tempStruct[1].Yaw);

            tempStruct[2] = new(GetObjectOffsetFromCoords(tempStruct[1].X, tempStruct[1].Y, tempStruct[1].Z, 0.0f, vOffset.X, vOffset.Y, vOffset.Z), tempStruct[2].ToRotationVector);

            if (tempStruct[0].Yaw > 180.0f)
                tempStruct[0].Yaw -= 360.0f;
            if (tempStruct[0].Yaw < -180.0f)
                tempStruct[0].Yaw += 360.0f;
            if (tempStruct[1].Yaw > 180.0f)
                tempStruct[1].Yaw -= 360.0f;
            if (tempStruct[1].Yaw < -180.0f)
                tempStruct[1].Yaw += 360.0f;
            tempStruct[2].Yaw += tempStruct[1].Yaw - tempStruct[0].Yaw;
            if (tempStruct[2].Yaw > 180.0f)
                tempStruct[2].Yaw -= 360.0f;
            if (tempStruct[2].Yaw < -180.0f)
                tempStruct[2].Yaw += 360.0f;
            if (rotation)
                return tempStruct[2].ToRotationVector;
            else
                return tempStruct[2].ToVector3;
        }
        public static bool IsPlayerOnBikeOrQuad()
        {
            int vehId;
            if (IsPedInAnyVehicle(PlayerPedId(), false))
            {
                vehId = GetVehiclePedIsIn(PlayerPedId(), false);
                if (DoesEntityExist(vehId) && !IsEntityDead(vehId))
                {
                    uint model = (uint)GetEntityModel(vehId);
                    return IsThisModelABike(model) || IsThisModelAQuadbike(model);
                }
            }
            return false;
        }
        public static bool Get_DriveIn(BuildingsEnum BuildingId, ref STRUCT_DriveIn scene)
        {
            switch (BuildingId)
            {
                case 0:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_1: //High apt 1,2,3,4
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-801.0135f, 332.7260f, 85.4419f, 4.8393f, -0.0098f, -162.9744f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-798.7095f, 333.4185f, 85.4418f, 4.8393f, -0.0098f, -162.1292f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 30.0228f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-801.0135f, 332.7260f, 85.4419f, 4.8393f, -0.0098f, -162.9744f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 30.0228f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-796.1608f, 323.2557f, 84.7015f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-796.0895f, 306.9656f, 84.7015f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-787.4305f, 336.9863f, 84.7015f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-796.1099f, 307.6792f, 84.7022f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-800.4028f, 313.7549f, 84.7211f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-791.6549f, 313.3977f, 84.7060f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.6250f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51: //garage new 18
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(873.3696f, -2235.5352f, 32.9233f, -5.3132f, -0.0000f, 26.6492f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(873.3696f, -2235.5352f, 32.9233f, -16.2593f, 0.0000f, 26.6492f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(864.1264f, -2235.6619f, 32.3054f, -16.9066f, -0.0000f, -56.8647f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(870.9843f, -2229.7058f, 29.5195f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(870.5140f, -2235.2815f, 29.6163f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(871.2320f, -2227.6548f, 29.5195f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(870.5704f, -2232.8079f, 29.5401f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(868.8420f, -2231.7966f, 30.0477f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(872.7557f, -2232.1396f, 29.8316f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 1.1250f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 1.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:  //High apt 14f,15
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-883.0992f, -345.9912f, 34.6601f, 6.3632f, 0.0000f, -160.3029f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-883.4265f, -345.3335f, 34.5787f, 6.3632f, 0.0000f, -161.1172f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 36.2740f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-935.5062f, -393.9272f, 40.0824f, -8.3063f, 0.0000f, -116.5835f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-884.9076f, -346.0437f, 33.5340f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-875.0308f, -365.1419f, 35.9402f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-899.6184f, -340.5005f, 33.5340f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-875.3135f, -364.5881f, 36.6168f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 27.3600f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-880.0560f, -360.5660f, 34.8627f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-875.9731f, -358.4306f, 34.8581f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 1.5000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 3.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:  //High apt 16f,17
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-618.2849f, 59.2275f, 44.2642f, 1.6448f, 0.0000f, 104.6055f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-617.4031f, 59.1322f, 44.2404f, 1.6448f, -0.0000f, 108.1057f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 37.2008f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-634.5964f, 55.6069f, 44.4266f, -5.5060f, 0.0000f, 87.8762f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-622.2662f, 56.7073f, 42.7323f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-638.7336f, 56.6194f, 42.9082f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-616.5451f, 48.1717f, 42.7443f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-637.3478f, 56.6297f, 42.8559f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 271.8300f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-630.1014f, 60.9404f, 42.7312f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-630.0441f, 52.2495f, 42.7250f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 4.6250f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:  //High apt 12f,13
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-38.8625f, -621.3514f, 35.3381f, 0.1933f, 0.0000f, -95.2019f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-39.0986f, -621.3379f, 35.3421f, -0.9550f, 0.0000f, -93.2745f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 39.6494f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-58.6693f, -582.4872f, 37.4534f, -0.6088f, 0.0000f, -104.2720f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-37.2861f, -620.4693f, 34.0684f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-27.8079f, -623.9610f, 34.4169f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-36.3041f, -612.9705f, 34.0841f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-28.1169f, -623.8500f, 34.3976f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 70.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-34.9953f, -625.4520f, 34.1735f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-32.2612f, -617.8603f, 34.2148f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.1250f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:  //High apt 5f,6
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-292.2810f, -993.2393f, 24.2923f, 0.2725f, 0.0000f, -97.9788f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-294.4084f, -992.5660f, 24.2819f, 0.2725f, 0.0000f, -95.7095f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 37.9699f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-267.4284f, -956.8759f, 31.9557f, -8.2883f, 0.0000f, 30.0385f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-290.0483f, -992.5299f, 23.1368f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-276.0764f, -997.3793f, 24.2061f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-293.3160f, -982.4184f, 24.1999f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-276.4688f, -997.2326f, 24.1341f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 69.1800f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-283.6024f, -998.5330f, 23.1368f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-281.3513f, -991.9869f, 23.1368f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.3000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 6.9000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:  //High apt 9f,10f,11
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-810.3807f, -425.9025f, 35.8310f, 4.4490f, 0.0000f, 139.9636f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-810.2816f, -425.4070f, 35.7966f, 3.2217f, 0.0000f, 139.1450f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 36.5979f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 7.0300f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-831.3160f, -448.3651f, 37.5418f, -6.2719f, 0.0000f, -44.8760f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-812.2617f, -429.5818f, 34.3929f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-825.9319f, -440.7628f, 35.6399f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-814.4553f, -418.6729f, 32.7103f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-825.6384f, -440.5773f, 35.6399f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 299.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-822.4520f, -433.3539f, 35.6609f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-818.7817f, -440.3885f, 35.6609f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 4.6000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23: //Low apt 7
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-1602.8921f, -440.3293f, 38.6895f, -1.0184f, -0.0019f, 157.3578f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-1602.2571f, -439.3541f, 38.7099f, -1.0184f, -0.0019f, 163.0943f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 40.9081f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-1594.6119f, -443.0864f, 38.5771f, -12.3558f, 0.0000f, -89.3312f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-1600.2324f, -438.9460f, 37.2166f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-1609.2898f, -451.8584f, 37.1881f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-1586.0852f, -447.5367f, 36.2120f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-1609.1001f, -451.6195f, 37.1823f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 325.3000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-1607.5859f, -445.3638f, 37.2258f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-1603.1171f, -449.1536f, 37.2260f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 4.5000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:  //High apt 7f,8
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-1450.2659f, -509.8492f, 32.0504f, -0.4615f, 0.0000f, 45.9398f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-1449.8395f, -510.3843f, 32.0558f, -0.4615f, 0.0000f, 47.4915f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 39.0991f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.3000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(-1447.6608f, -513.3250f, 31.9311f, -0.6590f, 0.0000f, 49.2517f);
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 41.4552f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.0000f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-1449.3281f, -514.3160f, 30.8522f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-1459.0117f, -498.6699f, 31.7324f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-1444.2711f, -525.8814f, 30.8522f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-1458.6981f, -499.1344f, 31.6752f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 212.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-1453.2833f, -502.1619f, 31.1400f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-1458.3475f, -505.6930f, 31.1630f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.0000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(GetOfficeGarageVectorAsOffset(BuildingId, 0, false), GetOfficeGarageVectorAsOffset(BuildingId, 0, true));
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(GetOfficeGarageVectorAsOffset(BuildingId, 1, false), GetOfficeGarageVectorAsOffset(BuildingId, 1, true));
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 37.0000f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = new(GetOfficeGarageVectorAsOffset(BuildingId, 2, false), GetOfficeGarageVectorAsOffset(BuildingId, 2, true));
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 37.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.0000f;
                    if (IsPlayerOnBikeOrQuad())
                        scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-143.4f, -575.0f, 31.9f);
                    else
                        scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = GetOfficeGarageVectorAsOffset(BuildingId, 3, false);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = GetOfficeGarageVectorAsOffset(BuildingId, 4, false);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos;
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = GetOfficeGarageVectorAsOffset(BuildingId, 6, false);
                    Vector3 vTemp = GetOfficeGarageVectorAsOffset(BuildingId, 6, true);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = vTemp.Z;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = GetOfficeGarageVectorAsOffset(BuildingId, 7, false);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = GetOfficeGarageVectorAsOffset(BuildingId, 7, true);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 4.687500f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.409572f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 1.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-1541.9135f, -571.6335f, 25.6177f, 2.9268f, -0.8030f, 39.3203f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-1541.1565f, -571.0165f, 25.6313f, 2.9268f, -0.8030f, 39.3203f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 23.6123f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = scene.mPans[(int)DriveInCuts.DriveIn_CUT_null].fFov;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-1547.0789f, -566.9713f, 24.7078f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-1556.4376f, -554.6019f, 27.2087f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-1541.8f, -574.4f, 24.7079f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-1554.2053f, -557.1197f, 26.0365f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 217.4663f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-1536.000f, -564.000f, 24.475f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-1548.700f, -573.300f, 27.575f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 5.0f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-1398.7780f, -476.1264f, 32.2348f, 7.7275f, -0.0000f, 96.9099f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-1396.5002f, -474.7093f, 31.9051f, 7.7275f, -0.0000f, 96.9099f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 22.05f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-1410.2128f, -476.8650f, 32.2377f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-1419.4785f, -481.8223f, 32.7237f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-1385.7f, -479.0f, 30.7364f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-1416.8383f, -480.1383f, 32.7208f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 303.7230f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-1394.800f, -472.400f, 31.000f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-1393.800f, -480.900f, 34.000f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 5.0f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(-82.8416f, -810.1617f, 36.0567f, 4.9621f, 0.0174f, -7.4456f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(-81.7104f, -810.3091f, 36.0567f, 4.9621f, 0.0174f, -7.4456f);
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = 20.0f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 10.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = 37.0000f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = 0.0000f;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = new(-80.5756f, -793.8742f, 36.4201f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = new(-84.7520f, -773.4540f, 38.7651f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = new(-84.7f, -815.5f, 35.4947f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = new(-81.6358f, -782.3251f, 37.4860f);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 195.0365f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = new(-73.3f, -809.3f, 39.6f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = new(-89.4f, -808.5f, 34.3f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 5.3f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 5.0f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                default:
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos = new(GetGameplayCamCoord(), GetGameplayCamRot(2));
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mEnd.Pos = new(GetGameplayCamCoord(), GetGameplayCamRot(2));
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov = GetGameplayCamFov();
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake = 0.25f;
                    scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fDuration = 6.500f;
                    scene.bEnablePans[(int)DriveInPans.DriveIn_PAN_descent] = false;
                    scene.fExitDelay = 0.0000f;
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId);
                    scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].fRot = 0f;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].mCam.Pos = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fFov = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fFov;
                    scene.mCuts[(int)DriveInCuts.DriveIn_CUT_null].fShake = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].fShake;
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos = scene.mPlacers[(int)DriveInPlacers.DriveIn_PLACER_resetCoords].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos = scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoA].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoB].Pos = scene.mMarkers[(int)DriveInMarkers.DriveIn_MARKER_gotoREVERSE].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos0 = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos.ToVector3 - new Vector3(5, 5, 0);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].Pos1 = scene.mPans[(int)DriveInPans.DriveIn_PAN_descent].mStart.Pos.ToVector3 + new Vector3(5, 5, 0);
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fWidth = 4.125000f;
                    scene.mAngAreas[(int)DriveInAngArea.DriveIn_ANGAREA_area0].fHeight = 4.125000f;
                    return false;
            }
        }
    }
}
