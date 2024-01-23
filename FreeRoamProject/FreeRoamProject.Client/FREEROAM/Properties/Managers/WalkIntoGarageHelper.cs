using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    enum WalkInGaragePans
    {
        WalkInGarage_PAN_descent,
        WalkInGarage_PAN_MAX
    }

    enum WalkInGarageCuts
    {
        WalkInGarage_CUT_start = 0,
        WalkInGarage_CUT_MAX
    }

    enum WalkInGarageMarkers
    {
        WalkInGarage_MARKER_gotoA = 0,
        WalkInGarage_MARKER_findCoord,
        WalkInGarage_MARKER_gotoB,
        WalkInGarage_MARKER_MAX
    }

    enum WalkInGaragePlacers
    {
        WalkInGarage_PLACER_resetCoords = 0,
        WalkInGarage_PLACER_gotoA,
        WalkInGarage_PLACER_MAX
    }

    enum WalkInGarageAngArea
    {
        WalkInGarage_ANGAREA_area0 = 0,
        WalkInGarage_ANGAREA_MAX
    }

    public class STRUCT_WalkInGarage
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)WalkInGaragePans.WalkInGarage_PAN_MAX] { new() };
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)WalkInGarageCuts.WalkInGarage_CUT_MAX] { new() };
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)WalkInGarageMarkers.WalkInGarage_MARKER_MAX] { new(), new(), new() };
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)WalkInGaragePlacers.WalkInGarage_PLACER_MAX] { new(), new() };
        public SceneTool_AngArea[] mAngAreas = new SceneTool_AngArea[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_MAX] { new() };

        public bool[] bEnablePans = new bool[(int)WalkInGaragePans.WalkInGarage_PAN_MAX];
        public float fExitDelay { get; set; }
    }

    internal class WalkIntoGarageHelper
    {
        public static bool Get_WalkInGarage(BuildingsEnum BuildingId, ref STRUCT_WalkInGarage scene)
        {
            switch (BuildingId)
            {
                case 0:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-799.0720f, 320.6587f, 86.3632f, -0.0375f, 0.0000f, -158.5483f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 38.0701f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-799.0720f, 320.6587f, 86.3632f, -0.0375f, 0.0000f, -158.5483f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-798.6212f, 321.0813f, 86.3633f, -1.1295f, 0.0000f, -156.4889f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 38.0701f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 5.0000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-796.1236f, 312.4341f, 84.7060f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-795.8869f, 317.6662f, 84.6711f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-795.2998f, 334.9379f, 84.7015f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-796.0367f, 310.9356f, 84.7103f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 8.0000f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-795.9910f, 310.7705f, 84.7107f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 8.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-801.0840f, 311.6861f, 84.9301f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-789.5790f, 311.8261f, 84.7084f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 4.7500f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 4.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-28.4072f, -70.9489f, 61.1346f, -14.7019f, -0.0000f, 30.9941f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-28.4072f, -70.9489f, 61.1346f, -14.7019f, -0.0000f, 30.9941f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-27.9463f, -71.7163f, 61.3694f, -14.7019f, -0.0000f, 30.9941f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-30.7467f, -65.8139f, 58.5436f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-31.4669f, -65.4419f, 58.5525f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-31.8227f, -64.9260f, 58.5754f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-29.2472f, -66.5444f, 58.5276f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-32.0059f, -65.5429f, 58.5382f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 0.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-32.8878f, -64.7022f, 58.5703f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-36.1431f, -63.7190f, 58.5692f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(973.3799f, -1017.0472f, 44.9454f, -20.8093f, -0.0000f, 118.7105f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(973.3799f, -1017.0472f, 44.9454f, -20.8093f, -0.0000f, 118.7105f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(972.7641f, -1017.3845f, 44.6786f, -20.8093f, -0.0000f, 118.7105f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(0.0000f, 0.0000f, 0.0000f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(964.5840f, -1024.7875f, 39.8475f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(964.5313f, -1027.4164f, 39.8475f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(963.9338f, -1022.5884f, 39.8475f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 90.0000f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(965.1632f, -1026.4447f, 39.8475f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 135.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(963.0906f, -1027.9738f, 39.9060f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(962.9706f, -1023.0401f, 39.8475f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 2.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(873.3696f, -2235.5352f, 32.9233f, -5.3132f, -0.0000f, 26.6492f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(873.3696f, -2235.5352f, 32.9233f, -16.2593f, 0.0000f, 26.6492f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(870.9843f, -2229.7058f, 29.5195f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(871.2320f, -2227.6548f, 29.5195f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(870.5704f, -2232.8079f, 29.5401f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(868.8420f, -2231.7966f, 30.0477f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(872.7557f, -2232.1396f, 29.8316f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 1.1250f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 1.1250f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-879.3593f, -352.8495f, 35.5138f, 10.7143f, -0.0000f, -171.2698f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-879.3593f, -352.8495f, 35.5138f, 10.7143f, -0.0000f, -171.2698f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-879.3593f, -352.8495f, 35.5138f, 2.8042f, 0.0000f, -178.5876f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-883.6517f, -348.2842f, 33.5340f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-883.7838f, -347.9753f, 33.5340f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-894.7950f, -340.3699f, 33.5340f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-876.0183f, -361.2808f, 35.0158f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 24.4800f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-876.0363f, -361.2022f, 35.0044f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 32.0400f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-880.0811f, -360.5822f, 34.8559f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-875.8514f, -358.5576f, 34.8860f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.3000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-624.4329f, 59.0079f, 44.3892f, -1.4600f, 0.0000f, 107.5935f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 41.3305f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-624.4329f, 59.0079f, 44.3892f, -1.4600f, 0.0000f, 107.5935f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-624.1620f, 58.7679f, 44.3938f, -1.4600f, 0.0000f, 113.4649f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 41.3305f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2540f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.0000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-622.7378f, 55.6352f, 42.7313f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-622.7034f, 55.6411f, 42.7314f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-618.7881f, 64.6789f, 42.7423f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-631.6893f, 54.7157f, 42.7250f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 272.8800f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-631.8889f, 54.6938f, 42.7250f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 272.8200f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-629.9460f, 60.9404f, 42.7918f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-629.8743f, 52.2069f, 42.7250f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.5000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 4.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-20.3428f, -626.4957f, 38.5043f, 18.2283f, -0.0000f, 69.3122f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-20.3428f, -626.4957f, 38.5043f, 18.2283f, -0.0000f, 69.3122f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-19.2934f, -626.8920f, 38.2333f, -11.1781f, 0.0000f, 69.3122f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 50.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-41.4098f, -621.9307f, 34.0381f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-41.4407f, -622.0095f, 34.0486f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-37.8465f, -616.8147f, 34.0956f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-28.9981f, -622.2560f, 34.3170f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 69.1200f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-29.3961f, -622.1253f, 34.2924f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 69.1200f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-34.1868f, -625.8323f, 34.2464f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-31.3887f, -618.1778f, 34.3354f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 2.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 5.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-275.5190f, -994.7433f, 25.9268f, 14.8533f, -0.0000f, 95.4414f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 39.8202f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-275.5190f, -994.7433f, 25.9268f, 14.8533f, -0.0000f, 95.4414f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-275.5190f, -994.7433f, 25.9268f, -11.3264f, -0.0000f, 89.9160f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 39.8202f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-293.1742f, -991.1610f, 23.1368f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-293.1823f, -991.2120f, 23.1368f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-294.4002f, -985.1016f, 23.1368f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-280.0096f, -995.3130f, 23.4494f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 75.0000f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-279.4986f, -995.4564f, 23.5404f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 71.6400f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-283.6542f, -998.4232f, 23.1964f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-281.3947f, -992.0045f, 23.2172f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 4.2500f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-1449.8301f, -509.4476f, 31.8831f, -0.6590f, 0.0000f, 49.2517f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 41.4552f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-1449.8301f, -509.4476f, 31.8831f, -0.6590f, 0.0000f, 49.2517f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-1449.6281f, -509.9228f, 31.8883f, -0.6590f, 0.0000f, 58.0153f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 41.4552f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 10.3000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-1449.4760f, -515.0535f, 30.8522f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-1449.4485f, -515.1066f, 30.8522f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-1444.2711f, -525.8814f, 30.8522f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-1459.2285f, -501.3297f, 31.5081f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 222.8400f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-1459.7349f, -500.6072f, 31.5980f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 222.8400f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-1453.2833f, -502.1619f, 31.1400f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-1458.3475f, -505.6930f, 31.1630f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-813.5735f, -435.9550f, 36.4917f, 5.1927f, 0.0000f, 102.2532f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 42.5856f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.0000f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-813.5735f, -435.9550f, 36.4917f, 5.1927f, 0.0000f, 102.2532f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-813.5735f, -435.9550f, 36.4917f, 5.1927f, 0.0000f, 84.4315f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 42.5856f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-814.0803f, -427.8784f, 34.2289f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-814.0607f, -427.8223f, 34.2197f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-814.9882f, -415.9547f, 32.2944f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-821.7708f, -439.5038f, 35.6399f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 306.0000f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-821.9498f, -439.5983f, 35.6399f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 302.4000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-822.5115f, -433.3241f, 35.6609f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-818.7810f, -440.3744f, 35.6770f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 4.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = new(-1602.1926f, -440.6148f, 38.3428f, -0.4196f, 0.0000f, 154.5195f);
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = 42.8873f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(-1602.1926f, -440.6148f, 38.3428f, -0.4196f, 0.0000f, 154.5195f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(-1601.6389f, -440.3610f, 38.3462f, -0.8137f, 0.0000f, 159.8575f);
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = 42.8873f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.2500f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.5000f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = new(-1597.7802f, -441.2629f, 37.2166f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(-1595.5609f, -435.8115f, 37.2166f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = new(-1589.0699f, -442.9493f, 36.2118f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = new(-1606.2397f, -448.3238f, 37.1934f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 318.7500f;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = new(-1606.3799f, -448.4681f, 37.1887f);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 318.7500f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = new(-1607.5896f, -445.3750f, 37.2258f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = new(-1603.0813f, -449.2010f, 37.2257f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 3.0000f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 3.5000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.0000f;
                    return true;
                default:
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mStart.Pos = new(GetGameplayCamCoords(), GetGameplayCamRot(2));
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos = new(GetGameplayCamCoords(), GetGameplayCamRot(2));
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov = GetGameplayCamFov();
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake = 0.25f;
                    scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fDuration = 6.500f;
                    scene.bEnablePans[(int)WalkInGaragePans.WalkInGarage_PAN_descent] = false;
                    scene.fExitDelay = 0.0000f;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].mCam.Pos = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].mEnd.Pos;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fFov = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fFov;
                    scene.mCuts[(int)WalkInGarageCuts.WalkInGarage_CUT_start].fShake = scene.mPans[(int)WalkInGaragePans.WalkInGarage_PAN_descent].fShake;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId);
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].fRot = 0f;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos;
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_findCoord].Pos = new(0, 0, 0f);
                    scene.mMarkers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoB].Pos = scene.mPlacers[(int)WalkInGarageMarkers.WalkInGarage_MARKER_gotoA].Pos;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].Pos = scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_resetCoords].Pos;
                    scene.mPlacers[(int)WalkInGaragePlacers.WalkInGarage_PLACER_gotoA].fRot = 0f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos0 = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId) - new Vector3(5, 5, 0f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fWidth = 5.0f;
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].Pos1 = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId) + new Vector3(5, 5, 0f);
                    scene.mAngAreas[(int)WalkInGarageAngArea.WalkInGarage_ANGAREA_area0].fHeight = 5.0f;
                    return false;
            }
        }
    }
}
