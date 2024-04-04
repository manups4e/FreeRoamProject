using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    public enum DriveOutPans
    {
        DriveOut_PAN_null,
        DriveOut_PAN_MAX
    }

    public enum DriveOutCuts
    {
        DriveOut_CUT_shot = 0,
        DriveOut_CUT_MAX
    }

    public enum DriveOutMarkers
    {
        DriveOut_MARKER_null,
        DriveOut_MARKER_MAX
    }

    public enum DriveOutPlacers
    {
        DriveOut_PLACER_startCoords,
        DriveOut_PLACER_driveTo,
        DriveOut_PLACER_MAX
    }

    public class STRUCT_DriveOut
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)DriveOutPans.DriveOut_PAN_MAX];
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)DriveOutCuts.DriveOut_CUT_MAX];
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)DriveOutMarkers.DriveOut_MARKER_MAX];
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)DriveOutPlacers.DriveOut_PLACER_MAX];
        public bool[] bEnablePans = new bool[(int)DriveOutPans.DriveOut_PAN_MAX];
        public Vector3 vDoorPos1 { get; set; }
        public Vector3 vDoorPos2 { get; set; }
        public Vector3 vDoorPos3 { get; set; }
        public float fExitDelay { get; set; }
        public bool bSetCarLockedInvulnerable { get; set; }
    }

    public class DRIVE_OUT_GARAGE_CS_STRUCT
    {
        public int vehClone { get; set; }
        public int[] PedIndex = new int[4];
        public int iPedsInCar { get; set; }
        public int iBS { get; set; }
    }

    internal class DriveOutOfGarageHelper
    {

        static readonly int DRIVE_OUT_FAKE_PEDS = 4;
        static readonly int FAKE_CAR_EXIT_GARAGE_WARP_POSSIBLE = 0;
        static readonly int FAKE_CAR_EXIT_GARAGE_WARP_DONE = 1;
        static readonly int FAKE_CAR_EXIT_GARAGE_ADDED_CUST_SPAWN = 2;

        public static bool Get_DriveOutGarage(BuildingsEnum iBuildingID, ref STRUCT_DriveOut scene)
        {
            switch (iBuildingID)
            {
                case 0:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f, 0.0000f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 0.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 0.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-793.3801f, 321.0642f, 85.8677f, 2.3849f, -0.0000f, 164.3360f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-795.8162f, 322.7209f, 84.7015f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 179.8355f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-795.6993f, 301.1959f, 84.7075f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 179.8355f;
                    scene.vDoorPos1 = new(-798.967651f, 313.991486f, 84.705750f);
                    scene.vDoorPos2 = new(-795.849182f, 314.308655f, 84.701675f);
                    scene.vDoorPos3 = new(-792.878845f, 314.504852f, 84.699097f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-1452.4291f, -495.9077f, 38.5501f, -22.7824f, 0.0000f, -9.0439f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-1452.4291f, -495.9077f, 38.5501f, -22.7824f, 0.0000f, -9.0439f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-1454.0414f, -510.0159f, 31.4477f, 3.9470f, -0.0000f, 19.6017f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-1450.5439f, -511.1783f, 30.8522f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 35.0000f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-1458.9189f, -496.1591f, 31.9241f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 322.5000f;
                    scene.vDoorPos1 = new(-282.026947f, -993.643066f, 23.303766f);
                    scene.vDoorPos2 = new(-283.157166f, -996.661743f, 23.483461f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-810.3313f, -418.4649f, 35.9807f, -25.1259f, 0.0000f, 112.0883f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-810.3313f, -418.4649f, 35.9807f, -25.1259f, 0.0000f, 112.0883f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-810.4244f, -428.7455f, 36.2140f, 4.3253f, 0.0000f, 128.9352f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-812.6725f, -423.6420f, 33.5552f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 153.7500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-828.6069f, -448.3151f, 35.6399f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 75.0000f;
                    scene.vDoorPos1 = new(-819.302307f, -438.809143f, 35.626488f);
                    scene.vDoorPos2 = new(-821.377380f, -435.120636f, 35.794361f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-884.4767f, -350.0993f, 35.9389f, -1.6140f, 0.0000f, -148.2025f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-884.4767f, -350.0993f, 35.9389f, -1.6140f, 0.0000f, -148.2025f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-879.5704f, -351.3455f, 34.9938f, 5.7711f, -0.0000f, -169.6314f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0047f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-882.8714f, -350.0053f, 33.6581f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 207.3600f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-871.5641f, -372.2396f, 37.9079f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 207.0000f;
                    scene.vDoorPos1 = new(-876.418823f, -358.469299f, 34.920353f);
                    scene.vDoorPos2 = new(-879.781738f, -360.224945f, 34.828461f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-624.2532f, 53.5243f, 44.6045f, -2.7979f, 0.0000f, -114.5529f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-624.2532f, 53.5243f, 44.6045f, -2.7979f, 0.0000f, -114.5529f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-622.4495f, 55.0172f, 44.2430f, 0.0871f, 0.0000f, 78.4050f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-620.2952f, 58.3260f, 42.7365f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 100.3200f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-645.2898f, 57.5593f, 43.0006f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 89.8800f;
                    scene.vDoorPos1 = new(-629.773926f, 59.266457f, 42.724987f);
                    scene.vDoorPos2 = new(-629.822937f, 55.832752f, 42.724960f);
                    scene.vDoorPos3 = new(-629.732056f, 52.372917f, 42.725010f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-41.7185f, -620.0758f, 35.5620f, 0.5557f, 0.0000f, -101.1061f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-41.7185f, -620.0758f, 35.5620f, 0.5557f, 0.0000f, -101.1061f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-36.1208f, -618.8893f, 35.3674f, -3.3754f, 0.0307f, -135.9231f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-38.2102f, -620.6124f, 34.0848f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 251.6400f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-23.1606f, -625.4481f, 34.7032f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 251.6400f;
                    scene.vDoorPos1 = new(-33.880001f, -621.538513f, 34.038071f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-242.7861f, -1004.2469f, 30.7049f, -14.4323f, 0.0000f, 66.8627f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-242.7861f, -1004.2469f, 30.7049f, -14.4323f, 0.0000f, 66.8627f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-288.3694f, -991.2920f, 24.4412f, 0.2085f, -0.0000f, -121.1736f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0430f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-290.5520f, -994.1109f, 23.1368f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 250.0000f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-265.1293f, -1003.4581f, 26.1927f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 248.7600f;
                    scene.vDoorPos1 = new(-282.026947f, -993.643066f, 23.303766f);
                    scene.vDoorPos2 = new(-283.157166f, -996.661743f, 23.483461f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(-1612.9268f, -457.2170f, 42.0234f, -28.5862f, 0.0000f, -33.6129f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(-1612.9268f, -457.2170f, 42.0234f, -28.5862f, 0.0000f, -33.6129f);
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = 50.0000f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.2500f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.5000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = new(-1598.1476f, -442.8423f, 38.1364f, 1.2301f, 0.0000f, 124.0840f);
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = 50.0010f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = 0.2500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = new(-1599.0793f, -439.5631f, 37.2166f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 138.7500f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = new(-1613.1024f, -456.1613f, 37.0932f);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 139.5000f;
                    scene.vDoorPos1 = new(-1606.561279f, -445.916870f, 37.216648f);
                    scene.vDoorPos2 = new(-1603.390503f, -448.632263f, 37.216648f);
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    return false;
                default:
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mStart.Pos = new(GetGameplayCamCoord(), GetGameplayCamRot(2));
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos = new(GetGameplayCamCoord(), GetGameplayCamRot(2));
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov = GetGameplayCamFov();
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake = 0.25f;
                    scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fDuration = 6.500f;
                    scene.bEnablePans[(int)DriveOutPans.DriveOut_PAN_null] = false;
                    scene.fExitDelay = 0.0000f;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].mCam.Pos = scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].mEnd.Pos;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fFov = scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fFov;
                    scene.mCuts[(int)DriveOutCuts.DriveOut_CUT_shot].fShake = scene.mPans[(int)DriveOutPans.DriveOut_PAN_null].fShake;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].fRot = 0f;
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(iBuildingID);
                    scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_driveTo].fRot = 0f;
                    scene.mMarkers[(int)DriveOutPans.DriveOut_PAN_null].Pos = scene.mPlacers[(int)DriveOutPlacers.DriveOut_PLACER_startCoords].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    return false;
            }
        }

        public enum GARAGE_CAR_LEAVE_CUTSCENE_STAGE
        {
            GARAGE_CAR_LEAVE_CUTSCENE_INIT = 0,
            GARAGE_CAR_LEAVE_CUTSCENE_TRIGGER_CUT,
            GARAGE_CAR_LEAVE_CUTSCENE_WAIT_FOR_OPEN_DOOR,
            GARAGE_CAR_LEAVE_CUTSCENE_RE_TASK,
            GARAGE_CAR_LEAVE_CUTSCENE_WAIT_FOR_EXIT,
            GARAGE_CAR_WARP_TO_UNOCCUPIED_AREA,
            GARAGE_CAR_SET_IN_UNOCCUPIED_AREA,
            GARAGE_CAR_LEAVE_CUTSCENE_COMPLETE
        }

        static bool IsDoorBlocked(ref STRUCT_DriveOut scene)
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
    }
}
