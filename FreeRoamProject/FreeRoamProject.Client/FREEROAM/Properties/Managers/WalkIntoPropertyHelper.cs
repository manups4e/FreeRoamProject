using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Client.FREEROAM.Properties.Managers
{
    public enum WalkInPans
    {
        WalkIn_PAN_establishing,
        WalkIn_PAN_MAX
    }

    public enum WalkInCuts
    {
        WalkIn_CUT_null = 0,
        WalkIn_CUT_MAX
    }

    public enum WalkInMarkers
    {
        WalkIn_MARKER_playerWalk0 = 0,
        WalkIn_MARKER_playerWalk1,
        WalkIn_MARKER_playerWalk2,
        WalkIn_MARKER_MAX
    }

    public enum WalkInPlacers
    {
        WalkIn_PLACER_playerPos = 0,
        WalkIn_PLACER_MAX
    }

    public class STRUCT_WalkIn
    {
        public SceneTool_Pan[] mPans = new SceneTool_Pan[(int)WalkInPans.WalkIn_PAN_MAX] { new() };
        public SceneTool_Cut[] mCuts = new SceneTool_Cut[(int)WalkInCuts.WalkIn_CUT_MAX] { new() };
        public SceneTool_Marker[] mMarkers = new SceneTool_Marker[(int)WalkInMarkers.WalkIn_MARKER_MAX] { new(), new(), new() };
        public SceneTool_Placer[] mPlacers = new SceneTool_Placer[(int)WalkInPlacers.WalkIn_PLACER_MAX] { new() };
        public bool[] bEnablePans = new bool[(int)WalkInPans.WalkIn_PAN_MAX];
        public float fExitDelay { get; set; }
    }

    internal class WalkIntoPropertyHelper
    {
        public static bool Get_WalkIn(BuildingsEnum BuildingId, ref STRUCT_WalkIn scene, int Entrance)
        {
            switch (BuildingId)
            {
                case 0:
                    return false;
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-764.146790f, 287.016663f, 88.399513f, 2.117963f, -0.000593f, 31.722597f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-764.115967f, 286.966858f, 89.982582f, 67.312279f, -0.000594f, 30.308628f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 38.958f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.500f;
                    scene.bEnablePans[(int)WalkInCuts.WalkIn_CUT_null] = false;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(0f, 0f, 0f, 0f, 0f, 0f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 0.0f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.0f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-777.1078f, 312.9173f, 84.6992f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-777.1355f, 318.5040f, 84.6690f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-781.8685f, 317.8841f, 84.6690f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 0f;

                    scene.fExitDelay = 0.5f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(16.4329f, 6.8270f, 80.5267f, -7.5722f, 0.0000f, 21.8734f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(5.9640f, 9.5679f, 80.5267f, -5.0091f, 0.0000f, -1.2863f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(9.7400f, 84.6906f, 84.8975f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(3.7647f, 37.9219f, 70.5326f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(4.4901f, 40.2624f, 70.5325f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(4.7016f, 41.4096f, 70.5324f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(3.1573f, 35.8189f, 70.5353f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 2.8800f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(5.9445f, 97.0624f, 85.2171f, -28.0555f, 0.0000f, -161.6681f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(5.9445f, 97.0624f, 85.2171f, 22.9757f, -0.0000f, -165.5721f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 35.9431f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-12.3328f, 90.4359f, 78.9943f, -3.1404f, 0.0000f, 0.0000f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(9.3664f, 80.3693f, 77.4446f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(8.9422f, 77.8170f, 77.4445f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(7.5691f, 76.7449f, 77.4450f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(10.2835f, 81.9529f, 77.4349f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 142.2000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-209.0646f, 182.8417f, 83.5620f, -8.7027f, -0.0000f, -57.9412f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-209.5238f, 182.5246f, 85.3932f, 18.0955f, 0.0000f, -55.3760f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 45.4706f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 3.2000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-212.4597f, 186.8262f, 81.7795f, -8.9058f, 0.0000f, 2.0662f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-200.9720f, 185.8880f, 79.3274f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-191.8559f, 187.7168f, 79.6304f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-201.5801f, 186.2485f, 79.3274f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-200.9754f, 185.1715f, 79.3133f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 360.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-818.4136f, -995.9948f, 15.8156f, -0.2251f, 0.0000f, -13.4816f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-818.0875f, -994.8571f, 16.1372f, 17.7022f, -0.0000f, -22.7164f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 42.4130f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-814.1236f, -984.7809f, 14.7478f, -8.0001f, 0.0000f, 0.0000f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-812.1517f, -980.2053f, 13.2756f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-811.2305f, -979.7562f, 13.2278f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-809.3616f, -978.3578f, 13.2278f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-813.2254f, -979.8819f, 13.1845f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 293.7600f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-668.7176f, -847.0402f, 26.7036f, -8.1205f, 0.0000f, -126.9468f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-672.0388f, -844.1733f, 33.1015f, 37.1171f, -0.0000f, -139.4427f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-665.9950f, -848.7388f, 26.3021f, -24.2122f, -0.0000f, -154.1999f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-662.4749f, -854.2733f, 23.4632f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-662.4390f, -855.0770f, 23.5232f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-662.4626f, -858.1933f, 23.5232f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-663.7423f, -853.7128f, 23.4364f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 246.9600f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1544.1926f, -325.6087f, 48.7006f, 0.9878f, 0.0000f, -93.1602f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1544.1074f, -325.2982f, 52.6245f, 14.1037f, 0.0000f, -87.8281f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 46.9647f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1539.0712f, -323.6113f, 49.1943f, -15.6880f, 0.0000f, -117.8159f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-1533.1915f, -326.5664f, 46.9112f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-1531.5039f, -328.6764f, 46.9200f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-1528.2477f, -326.8056f, 46.9200f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-1532.7437f, -325.4603f, 46.9112f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 190.8000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1550.9618f, -411.5307f, 43.5845f, -4.1345f, -0.0000f, 81.7934f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1550.7887f, -411.5194f, 46.7358f, 36.4638f, 0.0000f, 87.4149f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 45.7458f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1558.9783f, -414.2136f, 43.6826f, -13.7780f, 0.0000f, 42.6711f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-1564.4786f, -406.3255f, 41.3890f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-1565.5349f, -405.6029f, 41.3882f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-1567.6156f, -403.6811f, 41.3882f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-1562.1353f, -404.7448f, 41.3890f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 117.7200f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1615.7172f, -427.2462f, 43.8714f, -24.2332f, -0.0608f, -111.2071f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1615.7172f, -427.2462f, 43.8714f, 39.3052f, -0.0608f, -109.2756f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1612.4561f, -427.1014f, 42.2432f, -17.0852f, 0.0000f, -125.5306f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-1606.4282f, -433.1473f, 39.4353f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-1603.5750f, -435.2336f, 39.4220f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-1602.1851f, -436.2353f, 39.4220f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-1608.5460f, -433.6591f, 39.4307f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 302.7600f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-952.8615f, -373.9132f, 41.3722f, -1.4572f, -0.0000f, -109.5390f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-953.1790f, -373.8005f, 44.2973f, 66.6251f, -0.0000f, -109.5086f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 40.1924f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-934.6458f, -384.7574f, 40.1453f, -18.1743f, 0.0000f, -11.0527f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-933.2696f, -384.0754f, 37.9613f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-932.9f, -383.7f, 37.9613f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-932.9f, -383.7f, 37.9613f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-935.9081f, -380.9029f, 37.9613f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 207.3600f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-606.7625f, 5.8908f, 46.1434f, -3.9545f, -0.0000f, 17.6827f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-606.7625f, 5.8908f, 46.1434f, 55.9204f, 0.0000f, 7.3095f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-619.4422f, 27.8255f, 44.8775f, -10.8012f, 0.0000f, -19.0543f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-614.8010f, 37.9139f, 42.5897f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-617.2769f, 44.2665f, 42.5806f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-616.1315f, 40.8841f, 42.5883f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-615.9416f, 36.8541f, 42.5735f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 35.2800f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-63.2719f, -554.3776f, 42.5900f, -1.5637f, 0.0773f, -157.8888f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-63.5758f, -553.6505f, 48.4018f, 40.1273f, 0.0773f, -157.8888f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 37.4999f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-52.0226f, -586.4724f, 38.4119f, -17.3572f, -0.0000f, -136.2297f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-47.6852f, -587.6509f, 36.9580f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-45.3853f, -588.2827f, 37.1663f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-44.0858f, -582.7677f, 37.1674f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-48.8711f, -589.5564f, 36.9580f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 0.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-262.4320f, -984.2408f, 34.1312f, -4.8896f, 0.0000f, 3.6011f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-262.4470f, -985.7540f, 34.6655f, 63.9671f, 0.0000f, 8.5645f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.9600f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-252.5713f, -949.9199f, 37.7210f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-260.8901f, -970.2086f, 30.2196f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-264.0789f, -963.5338f, 30.2235f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-268.8266f, -955.2571f, 30.2234f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-259.1245f, -968.8276f, 30.2196f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 135.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1427.9330f, -556.7278f, 36.0702f, -6.2601f, -0.0000f, 54.5506f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1428.3942f, -556.3994f, 36.0081f, 54.5161f, 0.0000f, 54.5506f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 43.3970f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1443.0938f, -544.7684f, 41.2424f, -89.4999f, 0.0000f, 94.2595f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-1442.4517f, -544.0094f, 33.7424f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-1444.6846f, -541.8195f, 33.7417f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-1446.4171f, -538.6528f, 33.7410f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-1441.3108f, -545.0703f, 33.7424f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 66.2400f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-930.8760f, -486.5101f, 39.8948f, -4.6055f, -0.0000f, -30.7434f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-930.8760f, -486.5101f, 39.8948f, 59.5121f, -0.0000f, -27.2118f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 38.9142f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-917.3011f, -461.1729f, 40.8489f, -26.9735f, 0.0000f, -33.8730f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-912.8500f, -454.1392f, 38.5999f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-911.8500f, -453.1392f, 38.5999f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-910.8500f, -452.1392f, 38.5999f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-913.6371f, -456.8211f, 38.5999f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 0.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-198.8816f, 97.0476f, 70.6552f, 0.8232f, 0.0000f, -170.7582f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-199.0013f, 97.7828f, 76.3453f, 6.7146f, 0.0000f, -170.7582f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-194.2464f, 94.1687f, 71.6105f, -19.6197f, -0.0000f, 128.6171f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-198.0717f, 83.7918f, 68.7585f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-198.0717f, 83.7918f, 68.7585f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-198.2247f, 82.5191f, 68.7601f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-198.3362f, 87.4109f, 68.7477f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 189.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-48.5784f, -38.9737f, 66.0594f, -6.9087f, -0.0000f, -157.8717f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-48.5784f, -38.9737f, 66.0594f, 37.2662f, 0.0000f, -152.1534f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 48.0867f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(18.0530f, -5.4515f, 71.5144f, -7.4857f, 0.0000f, 32.7084f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-38.7890f, -59.3940f, 63.0680f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-38.1290f, -59.6640f, 63.0680f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-37.5590f, -59.9040f, 63.0680f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-42.2142f, -59.2807f, 62.4963f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 274.3200f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(275.4461f, -162.8499f, 66.2759f, -4.9207f, 0.0000f, -78.5758f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(275.4461f, -162.8499f, 66.2759f, 38.4836f, -0.0000f, -58.1826f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 49.3615f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(282.3360f, -159.6951f, 63.3730f, 33.6005f, -0.0000f, -105.0994f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(285.8218f, -160.2860f, 63.6221f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(286.4932f, -160.2142f, 63.6743f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(291.0940f, -163.7814f, 61.3492f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(284.6325f, -162.2803f, 63.6221f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 332.6400f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-526.1783f, 121.8094f, 65.2405f, -0.0565f, 0.0000f, -134.5127f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-523.8516f, 119.5216f, 66.0724f, 16.3573f, -0.0000f, -134.5127f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 46.8403f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 7.4050f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-511.4594f, 108.6869f, 64.6722f, -5.9833f, -0.0000f, 14.1879f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-511.7757f, 105.7855f, 62.8006f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-511.4152f, 101.6653f, 62.8006f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-513.4710f, 100.7747f, 62.8006f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-510.7062f, 108.8691f, 62.8006f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 142.2000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-653.9388f, 172.6451f, 68.3956f, -14.5896f, 0.0000f, -112.5694f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-651.1877f, 171.5017f, 68.5470f, 11.5287f, 0.0000f, -112.5694f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 43.8951f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-629.6102f, 167.6119f, 61.8764f, -3.0000f, 0.0000f, 0.0000f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-626.4092f, 169.4724f, 60.1626f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-624.9139f, 171.3835f, 61.9539f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-625.3212f, 168.8364f, 60.1651f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-628.9289f, 168.8015f, 60.1413f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 285.1200f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-981.1505f, -1437.6874f, 9.1368f, -9.2981f, 0.0000f, -52.3394f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-979.6581f, -1437.6234f, 9.1775f, 15.9431f, 0.0000f, -15.7977f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 42.5590f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-980.7847f, -1437.7778f, 8.6966f, -6.3937f, 0.0000f, -67.4498f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-970.3165f, -1431.2484f, 6.6791f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-967.7848f, -1430.0485f, 6.7684f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-968.8149f, -1426.9413f, 6.7684f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-970.1749f, -1432.2048f, 6.6791f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 299.8800f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-832.9249f, -835.3940f, 22.9385f, -5.8753f, -0.0000f, -173.0395f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-824.9551f, -833.4756f, 26.3226f, 12.8298f, -0.0000f, -170.1190f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 35.0493f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-831.3647f, -860.8909f, 21.0378f, -11.5852f, 0.0000f, 6.5266f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-831.4977f, -863.8859f, 19.7126f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-830.8679f, -865.4865f, 19.7126f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-831.1386f, -865.9618f, 19.7126f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-832.0834f, -861.9040f, 19.6946f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 193.3200f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-751.3406f, -750.4796f, 29.9035f, -12.5433f, 0.0000f, 121.1872f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-751.3406f, -750.4796f, 29.9035f, 56.5823f, -0.0000f, 123.7904f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 61.8447f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-759.8932f, -758.0070f, 28.5537f, -1.9886f, -0.0000f, 5.3909f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-765.9852f, -754.1449f, 26.8752f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-766.9714f, -755.4404f, 26.8752f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-766.6912f, -758.4532f, 26.8752f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-762.8427f, -753.8799f, 26.8736f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 105.8400f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1404.5686f, 505.8876f, 124.2054f, 0.2675f, -0.0000f, -10.9241f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1403.1555f, 505.5369f, 124.2054f, 0.2675f, -0.0000f, -23.8402f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1496.0000f, 512.0843f, 118.6189f, -3.0001f, 0.0000f, 0.0000f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-1404.9149f, 526.9042f, 122.8440f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-1404.9150f, 526.9040f, 122.8440f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-1404.9150f, 526.9040f, 122.8440f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-1406.1467f, 526.8649f, 122.8361f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 273.7500f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(1327.9758f, -1580.9358f, 54.7918f, -1.6230f, 0.0000f, -73.0287f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(1327.7219f, -1580.2666f, 54.7918f, -1.6230f, 0.0000f, -54.7927f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 4.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-1501.4905f, 522.9186f, 119.0109f, -2.6974f, 0.0000f, -144.7947f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(1336.6704f, -1578.5664f, 53.5760f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(1336.6700f, -1578.5660f, 53.5760f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(1336.6700f, -1578.5660f, 53.5760f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(1337.1830f, -1579.1577f, 53.2443f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 41.2500f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-117.4990f, 6533.6177f, 30.8231f, -0.9024f, -0.0000f, -119.5713f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-117.7792f, 6532.7847f, 30.8262f, -1.5503f, -0.0000f, -125.3187f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 45.2616f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-15.4012f, 6609.5630f, 34.0445f, -42.3207f, -0.0000f, 9.8353f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-105.8921f, 6528.1489f, 29.4110f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-105.8920f, 6000.0000f, 29.4110f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-105.8920f, 6000.0000f, 29.4110f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-105.4947f, 6528.7666f, 29.1719f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 135.0000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-314.3491f, 6329.5425f, 33.1484f, 4.3643f, -0.0000f, -110.6641f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-314.4063f, 6328.8486f, 33.1631f, 2.7551f, -0.0000f, -117.1005f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-309.1423f, 6342.8843f, 32.0011f, -4.7469f, -0.0000f, -157.6043f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-302.4787f, 6326.3696f, 31.8928f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-302.4790f, 6000.0000f, 31.8930f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-302.4790f, 6000.0000f, 31.8930f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-302.7712f, 6327.0127f, 31.8919f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 217.5000f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-4.6936f, 6544.4785f, 34.3108f, -0.8994f, 0.1541f, 41.0393f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-5.2879f, 6543.8721f, 34.3131f, 0.6296f, 0.1541f, 61.8894f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 45.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-105.1235f, 6527.9424f, 30.9723f, -7.6816f, 0.0000f, 14.5907f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(-15.6618f, 6557.0786f, 32.2676f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(-15.7333f, 6557.1499f, 32.2559f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(-15.7876f, 6557.2124f, 32.2455f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(-14.7801f, 6557.9116f, 32.2455f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 138.7500f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(1904.7861f, 3770.0391f, 33.7531f, -5.7096f, -0.0000f, 35.7448f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(1903.9667f, 3769.2939f, 33.7531f, -5.7096f, -0.0000f, 49.9815f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0000f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5.5000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(-15.3187f, 6557.1484f, 33.4866f, -13.0784f, -0.0000f, -48.8424f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(1898.5499f, 3781.5476f, 31.9342f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(1898.5500f, 3781.5481f, 31.9340f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(1898.5500f, 3781.5481f, 31.9340f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(1899.1631f, 3781.8655f, 31.8834f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 116.2500f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(1668.0369f, 4758.7124f, 43.3325f, -1.9164f, -0.1183f, 35.1509f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(1667.5472f, 4758.5771f, 43.3257f, -1.9164f, -0.1183f, 43.3979f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 36.4464f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.2500f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = new(1899.1578f, 3780.7351f, 33.6846f, -4.6976f, 0.0000f, -41.3041f);
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fFov = 50.0000f;
                    scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = 0.2500f;
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = new(1661.8740f, 4776.1196f, 41.3705f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = new(1661.8740f, 4776.1201f, 41.3710f);
                    scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = new(1661.8740f, 4776.1201f, 41.3710f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = new(1663.1089f, 4776.2847f, 41.0075f);
                    scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 101.2500f;
                    scene.bEnablePans[0] = false;
                    scene.fExitDelay = 0.5000f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(133.2934f, 584.3945f, 190.0845f, -10.8508f, -0.0000f, 160.7334f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(132.8789f, 583.0829f, 188.2512f, -8.9635f, 0.0000f, 160.7334f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 36.9913f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-208.0829f, 518.3535f, 140.3316f, -7.3226f, 0.1861f, -130.1492f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-206.5799f, 517.0856f, 140.0791f, -6.6921f, 0.1861f, -130.1492f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 30.7081f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(353.9353f, 462.4018f, 150.4586f, -2.5531f, -0.0000f, 153.1456f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(353.2027f, 460.9551f, 150.3837f, -2.9072f, -0.0000f, 153.1456f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 35.8575f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.500f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-741.6832f, 641.0106f, 154.7754f, -23.8965f, 0.0035f, 138.6701f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-740.3902f, 642.4799f, 149.1488f, -9.0033f, 0.0035f, 138.6701f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 35.6885f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-711.5103f, 600.7102f, 146.8317f, -3.8913f, -0.0000f, -96.5459f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-707.7958f, 600.6136f, 146.5823f, -2.9451f, -0.0000f, -106.0029f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 41.1816f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-566.6136f, 682.6280f, 153.9417f, -13.2295f, -0.0000f, -176.9261f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-566.4597f, 679.9078f, 152.9502f, -21.0684f, -0.0000f, -176.9261f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 44.4597f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-714.3430f, 600.4932f, 145.6452f, -5.1117f, -0.0000f, 93.0870f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-716.1815f, 600.2896f, 145.4803f, -5.1117f, -0.0000f, 93.5199f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 40.9374f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-871.8802f, 714.9831f, 157.9014f, -12.9560f, 0.0000f, -153.2849f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-871.4766f, 714.3058f, 153.0697f, -5.1549f, -0.0000f, -152.8134f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 40.7390f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;

                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1308.7963f, 466.9584f, 101.2854f, -6.2008f, -0.0000f, -137.3542f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1302.7015f, 470.1645f, 101.1989f, -6.9115f, -0.0000f, -151.9336f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 33.0663f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(360.6288f, 447.7085f, 152.3981f, -14.2309f, -0.0000f, -150.1516f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(364.2911f, 449.7356f, 149.9966f, -9.9722f, -0.0000f, -156.8911f);
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 38.3855f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                    scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1604.4607f, -524.7966f, 41.0270f, 3.8238f, -0.0000f, -145.4550f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1604.4607f, -524.7966f, 41.0270f, 39.3718f, 0.0000f, -144.2074f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 4f;
                        return true;
                    }
                    else if (Entrance == 1)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1562.7817f, -535.1185f, 119.8220f, -11.5371f, -0.0000f, 162.9484f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1560.7837f, -528.6019f, 112.0111f, -17.6105f, 0.0000f, 162.9484f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 4f;
                        return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1361.4659f, -530.5521f, 37.4391f, 3.6438f, -0.0000f, 9.0420f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1361.4659f, -530.5521f, 37.4391f, 26.3500f, 0.0000f, 9.0420f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                        return true;
                    }
                    else if (Entrance == 1)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1340.9651f, -485.9737f, 91.8395f, -17.3985f, -0.0000f, 66.7450f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1341.0265f, -485.9550f, 84.4150f, -12.1969f, -0.0000f, 70.2023f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                        return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-68.4012f, -642.7999f, 49.4706f, 5.8340f, -1.2990f, 50.6573f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-68.4012f, -642.7999f, 49.4706f, 44.8900f, -1.2990f, 55.8225f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 47.2556f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5f;
                    }
                    else if (Entrance == 1)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-80.4670f, -671.7493f, 156.2275f, 13.4637f, 0.1570f, 36.1166f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-79.5971f, -673.3090f, 150.2293f, -17.6748f, 0.1570f, 31.9479f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 34.8060f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.5f;
                    }
                    return true;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(97.5429f, -742.6163f, 119.7490f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(95.9027f, -743.2773f, 121.1036f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 30f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.6f;
                    }
                    else if (Entrance == 1)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-96.4946f, -872.8673f, 331.5534f, -22.4994f, -0.0000f, -21.6700f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-93.9497f, -870.1461f, 238.8003f, 33.8407f, -0.0000f, -18.3067f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 4f;
                    }
                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(276.3126f, -1830.5745f, 27.4641f, 10.3317f, -0.0000f, 29.4192f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(75.9980f, -1830.0762f, 28.3617f, 13.6228f, -0.0000f, 29.1940f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 62.8023f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.6f;
                    }
                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1476.5219f, -959.1437f, 9.9776f, 7.0914f, 0.0000f, 9.3966f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1476.8148f, -957.3717f, 10.2890f, 12.0257f, -0.0000f, 9.3966f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(25.4904f, -1034.8164f, 29.4169f, 0.2223f, 0.0000f, -75.4860f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(27.5923f, -1034.2714f, 29.7021f, 13.0847f, -0.0000f, -75.4860f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(38.5308f, 2782.2214f, 57.8536f, 0.8513f, -0.0000f, -52.9510f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(39.6345f, 2783.0642f, 57.9778f, 8.4851f, -0.0000f, -52.9510f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-341.4055f, 6090.9282f, 39.1533f, -15.2138f, 0.0000f, 167.3142f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-342.4233f, 6086.4106f, 37.8931f, -15.2138f, 0.0000f, 167.3142f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(1743.4716f, 3723.8005f, 34.5536f, 0.7364f, -0.0000f, 163.9551f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(1742.2789f, 3721.3467f, 34.6222f, 5.5424f, -0.0000f, 163.9551f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(915.3560f, -1434.9849f, 31.1141f, 2.4655f, -0.0000f, -135.6969f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(917.1609f, -1436.8337f, 31.3592f, 6.0013f, -0.0000f, -135.6969f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 36.6601f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.6f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(197.7034f, 294.2755f, 109.8201f, -11.2896f, -0.0000f, 36.2861f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(195.6434f, 297.0814f, 109.1805f, -7.6567f, 0.0000f, 36.2861f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-39.5358f, -202.4035f, 54.0587f, 5.7660f, 0.0000f, -55.5984f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-38.6302f, -201.9416f, 54.1626f, 8.3564f, -0.0000f, -55.5984f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 44.2655f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(2509.3657f, 4109.6470f, 37.9957f, 2.7399f, 0.0000f, 107.1840f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(2508.2510f, 4109.2876f, 38.0515f, 5.9493f, -0.0000f, 107.1839f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 34.4001f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-36.2847f, 6405.1216f, 31.9714f, -1.4549f, -0.0000f, 15.0229f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-36.9731f, 6407.6880f, 32.2795f, 9.6539f, 0.0000f, 15.0229f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 50.0f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    if (Entrance == 0)
                    {
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(-1149.9884f, -1598.9075f, 4.3410f, 2.4955f, -0.0000f, -6.7014f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(-1149.8022f, -1597.3248f, 4.4105f, 4.8661f, -0.0000f, -6.7014f);
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = 32.3628f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
                        scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 5f;
                    }

                    return true;
            }
            scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mStart.Pos = new(GetGameplayCamCoords(), GetGameplayCamRot(2));
            scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos = new(GetGameplayCamCoords(), GetGameplayCamRot(2));
            scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fFov = GetGameplayCamFov();
            scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake = 0.25f;
            scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fDuration = 6.500f;
            scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].mCam.Pos = scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].mEnd.Pos;
            scene.mCuts[(int)WalkInCuts.WalkIn_CUT_null].fShake = scene.mPans[(int)WalkInPans.WalkIn_PAN_establishing].fShake;
            scene.bEnablePans[(int)WalkInCuts.WalkIn_CUT_null] = false;

            scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos = PropertiesExteriorsManager.GetMpPropertyBuildingWorldPoint(BuildingId);
            scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].fRot = 0f;

            scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos = scene.mPlacers[(int)WalkInPlacers.WalkIn_PLACER_playerPos].Pos + new Vector3(1.0f, 1.0f, 0.0f);
            scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos = scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk0].Pos + new Vector3(1.0f, 1.0f, 0.0f);
            scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk2].Pos = scene.mMarkers[(int)WalkInMarkers.WalkIn_MARKER_playerWalk1].Pos + new Vector3(1.0f, 1.0f, 0.0f);
            scene.fExitDelay = 0.5f;
            return false;
        }
    }
}