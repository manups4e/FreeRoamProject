using FreeRoamProject.Shared.Core.ApartmentsShared;
using FreeRoamProject.Shared.Core.ApartmentsShared.Enums;
using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    enum WalkOutPans
    {
        WalkOut_PAN_walkOut,
        WalkOut_PAN_MAX
    }

    enum WalkOutCuts
    {
        WalkOut_CUT_catchup = 0,
        WalkOut_CUT_MAX
    }

    enum WalkOutMarkers
    {
        WalkOut_MARKER_walkTo,
        WalkOut_MARKER_MAX
    }

    enum WalkOutPlacers
    {
        WalkOut_PLACER_resetCoords,
        WalkOut_PLACER_occupiedSphere,
        WalkOut_PLACER_MAX
    }

    enum WOS
    {
        WOS_INIT = 0,
        WOS_WAIT_FOR_DOOR_CONTROL = 1,
        WOS_GIVE_SEQUENCE = 2,
        WOS_WAIT_FOR_SEQUENCE_END = 3,
        WOS_RETURN_CONTROL_GRACEFULLY = 4,
        WOS_WARP_TO_UNOCCUPIED_AREA = 5,
        WOS_SET_IN_UNOCCUPIED_AREA = 6,
        WOS_CLEANUP = 7
    }

    public class STRUCT_WalkOut
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)WalkOutPans.WalkOut_PAN_MAX];
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)WalkOutCuts.WalkOut_CUT_MAX];
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)WalkOutMarkers.WalkOut_MARKER_MAX];
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)WalkOutPlacers.WalkOut_PLACER_MAX];
        public bool[] bEnablePans = new bool[(int)WalkOutPans.WalkOut_PAN_MAX];
        public float fExitDelay { get; set; }
    }

    internal class WalkOutOfPropertyHelper
    {
        public static bool Fake_WalkOut(ref STRUCT_WalkOut scene)
        {
            scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos;
            scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0f;
            return true;
        }

        public static bool Get_WalkOut(BuildingsEnum BuildingId, ref STRUCT_WalkOut scene)
        {
            switch (BuildingId)
            {
                case 0:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-779.846680f, 307.215790f, 86.100006f, 2.534921f, 0.000000f, -22.975626f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-778.645813f, 306.863953f, 86.106171f, 1.323177f, -0.000000f, -20.878082f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 40.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 5.000f - 0.6f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos.ToRotationVector);
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-777.0378f, 311.5292f, 84.6992f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-777.4117f, 317.9462f, 84.6690f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 180.9339f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-255.3428f, -975.6434f, 33.2047f, -9.2821f, -0.0000f, 48.3619f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-257.4192f, -976.5851f, 32.2040f, -6.9527f, -0.0000f, 46.9130f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f - 0.4f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-260.9806f, -972.6545f, 30.2196f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-264.7780f, -964.3018f, 30.2236f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 206.2500f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-206.1010f, 188.4548f, 96.4279f, -76.4265f, 0.0000f, -136.0800f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-205.8278f, 188.1450f, 94.7147f, -76.4265f, -0.0000f, -144.4217f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 28.0785f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.2000f - 0.6f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-204.7485f, 184.3757f, 79.3274f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-200.6764f, 186.3481f, 79.5104f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 91.4400f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-206.1342f, 184.3563f, 79.3274f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-816.6025f, -991.1185f, 17.0888f, 17.6505f, -0.0000f, -41.4345f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-815.9750f, -990.4141f, 14.3000f, 2.2736f, 0.0000f, -23.4331f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f - 0.8f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-814.5579f, -983.6636f, 13.0743f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-809.5139f, -978.3112f, 13.2278f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 123.4800f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-665.1188f, -847.3347f, 26.1009f, 56.3143f, 0.0000f, -149.4329f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-665.1449f, -847.2905f, 25.4584f, -6.1796f, -0.0000f, -145.2366f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 5.5000f - 0.4f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-662.7435f, -851.4297f, 23.4288f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-662.3965f, -858.1040f, 23.5232f);
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-1540.0833f, -321.7534f, 48.0299f, -3.4209f, -0.0000f, -123.1820f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-1540.5493f, -323.2066f, 48.0117f, -8.0173f, 0.0000f, -104.9244f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 37.5853f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.9400f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-1536.5195f, -324.0229f, 46.4567f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-1532.1157f, -327.7559f, 46.9200f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 48.9600f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-1535.4785f, -324.9415f, 46.4819f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-1554.0779f, -411.0318f, 44.6944f, 43.0312f, 0.0000f, 83.3163f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-1553.9454f, -411.0573f, 43.3586f, -5.7502f, -0.0000f, 79.0932f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 44.5739f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f - 0.4f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-1561.3427f, -408.4821f, 41.3890f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-1567.6069f, -403.7278f, 41.3882f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 231.8400f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-1614.6853f, -422.4536f, 49.5392f, 16.4600f, -0.0000f, -147.0865f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-1614.9767f, -422.9563f, 47.7871f, -33.5123f, 0.0000f, -144.5396f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 43.8106f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 5.5000f - 0.66f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-1608.4954f, -430.5093f, 39.4370f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-1602.3040f, -435.7079f, 39.4220f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 48.9600f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-1611.7537f, -427.8397f, 39.5634f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(276.8639f, -161.5447f, 65.0431f, -1.6793f, 0.0000f, -79.3308f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(277.2520f, -162.8801f, 65.0431f, -1.6793f, 0.0000f, -69.0721f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 37.5362f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.8000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(284.5421f, -159.6689f, 63.6221f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(289.5417f, -162.3463f, 64.3987f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 63.8973f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(284.5421f, -159.6689f, 63.6221f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(4.5824f, 23.2871f, 86.0296f, -53.7934f, 0.0000f, 8.2595f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(4.1416f, 25.9133f, 81.5619f, -47.7373f, 0.0000f, 9.5287f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 37.7091f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.1000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(3.0264f, 35.6280f, 70.5353f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(4.6261f, 39.9890f, 70.5326f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 157.3200f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(2.8828f, 35.4128f, 70.5353f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(20.6232f, 87.0676f, 80.5134f, -9.3961f, -0.0000f, 112.3034f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(19.0930f, 89.4920f, 80.5134f, -12.1385f, -0.0000f, 123.8808f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 33.5446f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.5000f - 0.66f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(10.9772f, 83.9295f, 77.3977f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(8.6638f, 79.0654f, 77.4448f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 340.9200f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(10.9806f, 83.8818f, 77.3977f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-524.0706f, 119.4098f, 74.7327f, -36.6703f, 0.0000f, -121.0795f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-522.6709f, 118.2410f, 73.3864f, -36.6703f, -0.0000f, -123.2925f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 35.9940f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.0000f - 0.66f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-511.6992f, 109.2992f, 62.8006f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-510.8555f, 104.0593f, 62.8006f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 8.6400f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-511.6992f, 109.2992f, 62.8006f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-199.7267f, 95.2666f, 70.8220f, -2.9825f, -0.0000f, -146.0882f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-199.3750f, 93.9299f, 70.7064f, -8.5711f, -0.0000f, -156.9829f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 41.2497f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.8400f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-197.5728f, 89.4184f, 68.6857f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-198.2581f, 83.3431f, 68.7591f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 349.5600f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-197.4908f, 89.8990f, 68.6668f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-632.8743f, 165.0295f, 61.7998f, -4.4891f, -0.0000f, -50.0760f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-632.8743f, 165.0295f, 61.7998f, -6.2407f, 0.0000f, -33.6965f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 40.8737f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.6400f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-630.4570f, 169.5246f, 60.2563f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-626.3204f, 169.9248f, 60.1623f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 88.2000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-630.4570f, 169.5246f, 60.2563f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-988.0358f, -1438.1102f, 12.7701f, -13.3248f, 0.0000f, -69.8776f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-987.1445f, -1437.7834f, 12.5081f, -21.6723f, 0.0000f, -69.8776f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 47.2249f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.2000f - 0.66f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-973.1356f, -1432.4341f, 6.6791f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-967.3808f, -1430.2212f, 6.7684f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 111.6000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-972.9456f, -1432.4485f, 6.6791f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-834.7097f, -856.9741f, 21.4362f, -4.3502f, -0.0000f, -148.7740f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-834.0713f, -856.9313f, 21.4116f, -9.4005f, 0.0000f, -148.1172f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 43.7555f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.6400f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-831.6066f, -859.9925f, 19.6946f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-831.3633f, -863.9606f, 19.7126f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-831.8629f, -859.9764f, 19.6946f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-751.8182f, -758.0746f, 29.8423f, -11.6783f, -0.0589f, 67.2833f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-751.3698f, -756.5670f, 29.8342f, -11.0220f, -0.0589f, 74.6871f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 33.5567f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.6400f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0.0000f, 0.0000f, 0.0000f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-760.9564f, -753.8917f, 26.8736f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-764.8309f, -754.4858f, 26.8752f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 270.3600f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-760.9564f, -753.8917f, 26.8736f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-936.6873f, -393.2527f, 39.9279f, -5.4851f, -0.0000f, -20.4644f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-938.1174f, -391.9020f, 39.8544f, -7.9852f, 0.0000f, -18.0689f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 41.2177f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-936.3890f, -386.1136f, 37.9613f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-932.6791f, -383.5796f, 37.9613f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 115.9200f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-630.8286f, 21.9468f, 49.2013f, -14.3535f, 0.0000f, -49.1429f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-628.7056f, 19.8417f, 49.2013f, -15.9722f, 0.0000f, -39.9208f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 33.6203f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 5.7000f - 0.5f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-615.5634f, 33.2746f, 42.5307f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-614.7665f, 40.6905f, 42.5906f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 180.7200f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-615.7649f, 31.3210f, 42.5301f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-52.1442f, -583.0818f, 37.8780f, -0.6010f, 0.0000f, -146.6836f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-53.0051f, -583.8224f, 36.6284f, -1.2727f, 0.0000f, -140.0944f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-51.6116f, -586.7893f, 35.6002f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-46.3888f, -588.5487f, 37.1670f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 0.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-1440.4741f, -574.1239f, 46.5883f, -26.4383f, -0.0000f, -0.7259f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-1440.4498f, -572.2144f, 45.6387f, -23.8785f, 0.0000f, 2.6070f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 31.8038f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-12.9633f, 0.0000f, 166.7685f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-1441.8468f, -547.4501f, 33.7424f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-1445.2860f, -541.5842f, 33.7415f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 218.5200f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-914.7648f, -481.3169f, 39.6928f, -5.0805f, 0.0000f, 3.7868f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-915.7421f, -480.7480f, 39.8551f, -5.0805f, 0.0000f, 0.9599f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 31.0261f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.2550f - 1.0f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-917.0003f, -458.0423f, 38.5999f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-914.9155f, -452.8455f, 38.5999f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 169.5600f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    Fake_WalkOut(ref scene);
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-49.8329f, -47.6051f, 64.3165f, 6.6436f, -0.0000f, -173.8716f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-48.1860f, -47.6119f, 64.3158f, -4.3669f, 0.0000f, -152.5805f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 35.7644f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.2500f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.6000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(0f, 0f, 0f), new Vector3(-9.4999f, 0.0000f, 94.2595f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-42.8798f, -57.8034f, 62.4512f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-37.7157f, -59.7536f, 63.0682f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 68.7600f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-43.6420f, -57.4815f, 62.3966f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-1406.8398f, 526.6141f, 124.5208f, -5.1604f, 0.0000f, -14.7551f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-1406.2139f, 526.5825f, 124.5119f, -4.8760f, 0.0256f, 1.7898f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 2.7500f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(-1406.2139f, 526.5825f, 124.5119f), new Vector3(-4.8760f, 0.0256f, 1.7898f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0000f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-1406.3076f, 529.7269f, 122.8361f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-1405.4445f, 526.5302f, 122.8361f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 22.5000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-1499.6051f, 523.1385f, 117.2722f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(1340.2795f, -1578.7097f, 54.8223f, -5.4591f, 0.0000f, -125.5653f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(1341.6482f, -1578.9459f, 54.7106f, -2.6626f, 0.0000f, -132.5410f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.6750f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(1341.6482f, -1578.9459f, 54.7106f), new Vector3(-2.6626f, 0.0000f, -132.5410f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(1344.1912f, -1580.7418f, 53.0549f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(1341.4930f, -1577.8148f, 53.4443f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 221.2500f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(1342.5518f, -1578.0366f, 53.4443f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-103.8299f, 6528.9521f, 30.5451f, -4.7791f, -0.0000f, 50.8526f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-105.1552f, 6528.6353f, 30.5075f, -4.9733f, 0.0000f, 23.5478f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(-105.1552f, 6528.6353f, 30.5075f), new Vector3(-4.9733f, 0.0000f, 23.5478f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-106.5943f, 6532.0054f, 28.8582f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-105.8078f, 6528.3330f, 29.3718f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 0.0000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-14.2580f, 6000.0000f, 32.2454f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-300.4659f, 6328.5054f, 33.2355f, -5.0230f, 0.0000f, 64.9785f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-302.0653f, 6328.3496f, 33.1190f, -4.5385f, -0.0000f, 51.7653f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.7750f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(-302.0653f, 6328.3496f, 33.1190f), new Vector3(-4.5385f, -0.0000f, 51.7653f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-304.5024f, 6330.1440f, 31.4893f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-301.7189f, 6327.2710f, 31.8926f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 45.0000f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-301.3985f, 6000.0000f, 31.8918f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(-16.0685f, 6558.2686f, 33.6771f, -8.6469f, -0.0000f, -81.0994f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(-14.5951f, 6558.5684f, 33.4494f, -20.5931f, -0.0000f, -59.6802f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(-14.5951f, 6558.5684f, 33.4494f), new Vector3(-20.5931f, -0.0000f, -59.6802f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(-12.4015f, 6560.2305f, 30.9710f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(-15.6693f, 6557.3003f, 32.2455f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 311.2500f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(-14.2580f, 6000.0000f, 32.2454f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(1899.5564f, 3780.1938f, 33.2782f, -2.2800f, 0.0000f, -30.6051f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(1899.1544f, 3781.1560f, 33.2566f, -2.2800f, 0.0000f, -43.9225f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 3.5000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(1899.1544f, 3781.1560f, 33.2566f), new Vector3(-2.2800f, 0.0000f, -43.9225f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(1901.0154f, 3783.2876f, 31.7961f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(1898.5573f, 3781.5977f, 31.9072f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 303.7500f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(1900.6729f, 3773.1785f, 31.8829f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(1663.3756f, 4777.4126f, 43.0227f, -10.7709f, 0.0000f, -165.2197f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(1662.7836f, 4775.8545f, 42.7935f, -7.8945f, -0.0000f, -145.3202f);
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = 50.0000f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.0f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 4.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = new(new Vector3(1662.7836f, 4775.8545f, 42.7935f), new Vector3(-7.8945f, -0.0000f, -145.3202f));
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = 50.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = 0.0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = new(1664.7622f, 4772.8311f, 40.9904f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = new(1661.9733f, 4776.7261f, 41.0075f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 213.7500f;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos = new(1663.1211f, 4776.3169f, 41.0075f);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot = 4.0000f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.6600f;
                    return true;
                default:
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mStart.Pos = new(PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId) + new Vector3(0.0f, 0.0f, 5.0f), new Vector3(89.4999f, -0.0000f, 94.2595f));
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos = new(PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId) + new Vector3(0.0f, 0.0f, 7.5f), new Vector3(-9.4999f, -0.0000f, 94.2595f));
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov = GetGameplayCamFov();
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake = 0.25f;
                    scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration = 6.500f;
                    scene.bEnablePans[(int)WalkOutPans.WalkOut_PAN_walkOut] = false;
                    scene.fExitDelay = 0.66f + 0.0000f;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].mEnd.Pos;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fFov = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fFov;
                    scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].fShake = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fShake;
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId);
                    scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot = 0f;
                    scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos + new Vector3(1.0f, 0.0f, 0.0f);
                    Fake_WalkOut(ref scene);
                    return false;
            }
        }


        public static bool WalkOutOfThisProperty(ref STRUCT_WalkOut scene, int iCurrentProperty, ref WOS iWalkOutStage, int WalkOutCam0, int WalkOutCam1,
                ref SCRIPT_TIMER iWalkOutTimer, ref SCRIPT_TIMER iWalkOutCamInterpDelayTimer, ref SCRIPT_TIMER iWalkOutCamEndTimer, bool bAllExit)
        {
            Ped ped = PlayerCache.MyPed;
            int WALK_OUT_TIMEOUT = 10000;
            Vector3 vWalkToOffset = new();
            if (IsPlayerSwitchInProgress())
                iWalkOutStage = WOS.WOS_CLEANUP;
            bool bWarpWhenBlocked = false;
            int[] iPositionIndex = new int[2];
            float fDistance = 0.3f;
            MPPropertyNonAxis entranceArea = new MPPropertyNonAxis();
            PropertyData apart = PropertiesExteriorsManager.Properties[iCurrentProperty];
            switch (iWalkOutStage)
            {
                case WOS.WOS_INIT:
                    if (IsPositionOccupied(scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos.X,
                                          scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos.Y,
                                          scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].Pos.Z,
                            scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_occupiedSphere].fRot, false, true, false, false, false, 0, false)
                        || (PropertyFunctions.GetPropertySizeType(apart.Index) != PropertySizeType.PROP_SIZE_TYPE_LARGE_APT && bAllExit))
                    {
                        PlayerCache.MyClient.Status.Instance.RemoveInstance();
                        //ApartmentsExteriorsManager.SetPlayerInProperty(false, false, false);
                        // teleporting to
                        //ApartmentsExteriorsManager.SetupSpecificSpawnLocation(apart.House.Exits[0].OutPlayerLoc, apart.House.Exits[0].OutPlayerHeading, 10, false);
                        if (IsNewLoadSceneActive())
                            iWalkOutStage = WOS.WOS_SET_IN_UNOCCUPIED_AREA;
                        else
                            iWalkOutStage = WOS.WOS_WARP_TO_UNOCCUPIED_AREA;
                        return false;
                    }
                    CameraHelper.ExecutePan(ref scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut], ref WalkOutCam0, ref WalkOutCam1);
                    ped.Heading = scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].fRot;
                    ped.Position = scene.mPlacers[(int)WalkOutPlacers.WalkOut_PLACER_resetCoords].Pos;
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_AllowOpenDoorIkBeforeFullMovement);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_IgnoreNavigationForDoorArmIK);
                    HideHudAndRadarThisFrame();
                    Functions.ReinintNetTimer(ref iWalkOutCamInterpDelayTimer);
                    Functions.ReinintNetTimer(ref iWalkOutCamEndTimer);
                    if (!IsScreenFadedIn() && !IsScreenFadingIn())
                        DoScreenFadeIn(500);
                    iWalkOutStage = WOS.WOS_WAIT_FOR_DOOR_CONTROL;
                    break;
                case WOS.WOS_WAIT_FOR_DOOR_CONTROL:
                    HideHudAndRadarThisFrame();
                    iWalkOutStage = WOS.WOS_GIVE_SEQUENCE;
                    break;
                case WOS.WOS_GIVE_SEQUENCE:
                    SetPlayerControl(PlayerId(), false, 65536 | 512); // NSPC_CAN_BE_TARGETTED | NSPC_ALLOW_PLAYER_DAMAGE
                    TaskGoStraightToCoord(PlayerPedId(), scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.X, scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.Y, scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.Z, 1.0f, -1, 40000.0f, 0.5f);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_AllowOpenDoorIkBeforeFullMovement);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_IgnoreNavigationForDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_DontWalkRoundObjects);
                    Functions.ReinintNetTimer(ref iWalkOutTimer);
                    HideHudAndRadarThisFrame();
                    iWalkOutStage = WOS.WOS_WAIT_FOR_SEQUENCE_END;
                    break;
                case WOS.WOS_WAIT_FOR_SEQUENCE_END:
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_AllowOpenDoorIkBeforeFullMovement);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_IgnoreNavigationForDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_DontWalkRoundObjects);
                    HideHudAndRadarThisFrame();
                    entranceArea = PropertyFunctions.GetBuildingExtEntranceArea(PropertyFunctions.GetPropertyBuilding((PropertiesEnum)iCurrentProperty), 0);
                    if (!ped.IsInAngledArea(entranceArea.Pos1, entranceArea.Pos2, entranceArea.Width) && !PropertyFunctions.IsPropertyMissingOpeningDoors((PropertiesEnum)iCurrentProperty))
                    {
                        iWalkOutStage = WOS.WOS_RETURN_CONTROL_GRACEFULLY;
                        Functions.ReinintNetTimer(ref iWalkOutTimer);
                        Functions.ReinintNetTimer(ref iWalkOutCamEndTimer);
                    }
                    else
                    {
                        float fWALK_OUT_duration;
                        fWALK_OUT_duration = scene.mPans[(int)WalkOutPans.WalkOut_PAN_walkOut].fDuration;
                        fWALK_OUT_duration += scene.fExitDelay;
                        if (Functions.HasNetTimerExpired(ref iWalkOutCamEndTimer, Round(fWALK_OUT_duration * 1000.0f)))
                        {
                            if (GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 0//WAITING_TO_START_TASK
                                && GetScriptTaskStatus(PlayerPedId(), Functions.HashUint("SCRIPT_TASK_PERFORM_SEQUENCE")) != 1)//PERFORMING_TASK
                            {
                                if (scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos != Position.Zero)
                                {
                                    CameraHelper.ExecuteCut(scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup], ref WalkOutCam0);
                                }
                                else
                                {
                                    WalkOutCam0 = CreateCam("DEFAULT_SCRIPTED_CAMERA", false);
                                    AttachCamToEntity(WalkOutCam0, PlayerPedId(), 0.2624f, -0.8617f, 0.5789f, true);
                                    PointCamAtEntity(WalkOutCam0, PlayerPedId(), 0.1000f, 2.1250f, 0.3471f, true);
                                    SetCamFov(WalkOutCam0, 50.0000f);
                                    SetCamActive(WalkOutCam0, true);
                                    RenderScriptCams(true, false, 3000, true, false);
                                }
                                if (DoesCamExist(WalkOutCam1))
                                {
                                    if (IsCamActive(WalkOutCam1))
                                        SetCamActive(WalkOutCam1, false);
                                    DestroyCam(WalkOutCam1, false);
                                }
                                iWalkOutStage = WOS.WOS_CLEANUP;
                            }
                            else if (Functions.HasNetTimerExpired(ref iWalkOutTimer, WALK_OUT_TIMEOUT, true))
                            {
                                ClearPedTasks(PlayerPedId());
                                if (scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup].mCam.Pos != Position.Zero)
                                    CameraHelper.ExecuteCut(scene.mCuts[(int)WalkOutCuts.WalkOut_CUT_catchup], ref WalkOutCam0);
                                else
                                    WalkOutCam0 = CreateCam("DEFAULT_SCRIPTED_CAMERA", false);
                                AttachCamToEntity(WalkOutCam0, PlayerPedId(), 0.2624f, -0.8617f, 0.5789f, false);
                                PointCamAtEntity(WalkOutCam0, PlayerPedId(), 0.1000f, 2.1250f, 0.3471f, false);
                                SetCamFov(WalkOutCam0, 50.0000f);
                                SetCamActive(WalkOutCam0, true);
                                RenderScriptCams(true, false, 3000, true, false);
                                if (DoesCamExist(WalkOutCam1))
                                {
                                    if (IsCamActive(WalkOutCam1))
                                        SetCamActive(WalkOutCam1, false);
                                    DestroyCam(WalkOutCam1, false);
                                }
                                iWalkOutStage = WOS.WOS_CLEANUP;
                            }
                        }
                    }
                    break;
                case WOS.WOS_RETURN_CONTROL_GRACEFULLY:
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_SearchForClosestDoor);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_OpenDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_AllowOpenDoorIkBeforeFullMovement);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_IgnoreNavigationForDoorArmIK);
                    ped.ResetConfigFlag((int)PedResetFlags.PRF_DontWalkRoundObjects);
                    HideHudAndRadarThisFrame();
                    entranceArea = PropertyFunctions.GetBuildingExtEntranceArea(PropertyFunctions.GetPropertyBuilding((PropertiesEnum)iCurrentProperty), 0);
                    if (!iWalkOutCamEndTimer.bInitialisedTimer)
                    {
                        if (Functions.HasNetTimerExpired(ref iWalkOutTimer, 200, true))
                        {
                            vWalkToOffset = new Vector3(0, 0, 0f);
                            if (bAllExit)
                            {
                                iPositionIndex[0] = ParticipantIdToInt();
                                if (iPositionIndex[0] > 0)
                                {
                                    if (iPositionIndex[0] % 2 == 0)
                                    {
                                        iPositionIndex[1] = Ceil((iPositionIndex[0]) / 4f);
                                        vWalkToOffset.X = iPositionIndex[1] * fDistance;
                                        if (iPositionIndex[0] % 4 == 0)
                                            vWalkToOffset.Y = fDistance;
                                        else
                                            vWalkToOffset.Y = -fDistance;
                                    }
                                    else
                                    {
                                        iPositionIndex[1] = Ceil((iPositionIndex[0]) / 4f);
                                        vWalkToOffset.X = iPositionIndex[1] * -fDistance;
                                        if (iPositionIndex[0] % 4 == 3)
                                            vWalkToOffset.Y = fDistance;
                                        else
                                            vWalkToOffset.Y = -fDistance;
                                    }
                                }
                                Functions.ReinintNetTimer(ref iWalkOutCamEndTimer, true); ;
                                scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos = scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos + vWalkToOffset;
                                TaskGoStraightToCoord(PlayerPedId(), scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.X, scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.Y, scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.Z, 1.0f, -1, 40000.0f, 0.5f);
                            }
                        }
                        else
                        {
                            if (Functions.HasNetTimerExpired(ref iWalkOutTimer, 500, true))
                            {
                                ClearPedTasks(PlayerPedId());
                                SimulatePlayerInputGait(PlayerId(), 1.0f, 2000, GetHeadingFromVector_2d(ped.Position.X - scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.X, ped.Position.Y - scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos.Y), false, false);
                                iWalkOutStage = WOS.WOS_CLEANUP;
                            }
                        }
                    }
                    break;
                case WOS.WOS_WARP_TO_UNOCCUPIED_AREA:
                case WOS.WOS_SET_IN_UNOCCUPIED_AREA:
                    if (iWalkOutStage == WOS.WOS_SET_IN_UNOCCUPIED_AREA)
                    {
                        bWarpWhenBlocked = true;
                        if (!IsNewLoadSceneActive() || IsNewLoadSceneLoaded())
                        {
                        }
                        else
                            return false;
                        /*
                        if (ApartmentsExteriorsManager.WarpToSpawnLocation(13, false, false, false, bWarpWhenBlocked))
                        {
                            if (!IsScreenFadedIn() && !IsScreenFadingIn())
                                DoScreenFadeIn(500);
                            iWalkOutStage = WOS.WOS_CLEANUP;
                        }
                        */
                    }
                    break;
                case WOS.WOS_CLEANUP:
                    if (ped.IsInAngledArea(entranceArea.Pos1, entranceArea.Pos2, entranceArea.Width))
                    {
                        ped.Position = scene.mMarkers[(int)WalkOutMarkers.WalkOut_MARKER_walkTo].Pos;
                        SetPlayerControl(PlayerId(), true, 0);
                    }
                    else
                        SetPlayerControl(PlayerId(), true, 0);
                    iWalkOutStage = WOS.WOS_INIT;
                    if (DoesCamExist(WalkOutCam0) && !DoesCamExist(WalkOutCam1))
                    {
                        StopRenderingScriptCamsUsingCatchUp(false, 0, 3);
                        if (DoesCamExist(WalkOutCam0))
                        {
                            if (IsCamActive(WalkOutCam0))
                                SetCamActive(WalkOutCam0, false);
                            DestroyCam(WalkOutCam0, false);
                        }
                        if (DoesCamExist(WalkOutCam1))
                        {
                            if (IsCamActive(WalkOutCam1))
                                SetCamActive(WalkOutCam1, false);
                            DestroyCam(WalkOutCam1, false);
                        }
                    }
                    else
                    {
                        if (DoesCamExist(WalkOutCam0))
                            RenderScriptCams(true, false, 3000, true, false);
                        if (IsCamActive(WalkOutCam0))
                            SetCamActive(WalkOutCam0, false);
                        DestroyCam(WalkOutCam0, false);
                        if (DoesCamExist(WalkOutCam1))
                            RenderScriptCams(true, false, 3000, true, false);
                        if (IsCamActive(WalkOutCam1))
                            SetCamActive(WalkOutCam1, false);
                        DestroyCam(WalkOutCam1, false);
                    }
                    return true;
            }
            return false;
        }
    }
}