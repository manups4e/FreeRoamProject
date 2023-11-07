using FreeRoamProject.Client.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Interactions
{
    internal static class Showers
    {
        private static string sLocal_436;
        private static string sLocal_437;
        private static string sLocal_438;
        private static string sLocal_439;
        private static string sLocal_440;
        private static string sLocal_441;
        private static string sLocal_442;
        private static string sLocal_443;
        private static string sLocal_444;
        private static string sLocal_445;
        private static float Global_2499242_f_20 = 0;
        private static int Global_2499242_f_25 = 0;
        private static float Global_2499242_f_21 = 0;
        private static float Global_2499242_f_22 = 0;
        private static float Global_2499242_f_23 = 0;
        private static float Global_2499242_f_15 = 0;
        private static float Global_2499242_f_16 = 0;
        private static float Global_2499242_f_17 = 0;
        private static float Global_2499242_f_18 = 0;
        private static bool NearShower = false;
        private static Prop ShowerDoor;
        private static bool InShower = false;
        private static string sLocal_448 = "dlc_EXEC1/MP_APARTMENT_SHOWER_01";
        private static int Scene1;
        private static int uLocal_433;
        private static int uLocal_434;

        private static ShowerCoords actual = new ShowerCoords(new Vector3(0), new Vector3(0), new Vector3(0), new Vector3(0), new Vector3(0), new Vector3(0));

        private static List<ShowerCoords> Coords = new List<ShowerCoords>()
        {
            new ShowerCoords(new Vector3(254.847f, -1000.64f, -99.768f), new Vector3(0f, 0f, -180f), new Vector3(254.5308f, -1000.291f, -97.67236f), new Vector3(-45f, 0f, 0f), new Vector3(254.5308f, -1000.291f, -97.67236f), new Vector3(-45f, 0f, 0f)),
            new ShowerCoords(new Vector3(347.3f, -994.85f, -99.966f), new Vector3(0f, 0f, -90f), new Vector3(346.9f, -995.1795f, -97.85f), new Vector3(-45f, 0f, 0f), new Vector3(346.9f, -995.1795f, -97.85f), new Vector3(-45f, 0f, 0f)),
            new ShowerCoords(new Vector3(-788.3300f, 330.6500f, 200.6120f), new Vector3(0.0000f, 0.0000f, -90.0000f), new Vector3(-788.7310f, 330.0000f, 202.7750f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(-787.9000f, 329.6000f, 202.5000f), new Vector3(315.0000f, 0.0000f, 270.0000f)),
            new ShowerCoords(new Vector3(-796.8000f, 332.8490f, 209.9510f), new Vector3(0.0000f, 0.0000f, 90.0000f), new Vector3(-796.4452f, 333.5307f, 212.1467f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(-796.3611f, 333.2506f, 210.7966f), new Vector3(315.0000f, 0.0000f, 264.6319f)),
            new ShowerCoords(new Vector3(-168.4210f, 490.7790f, 133.0250f), new Vector3(0.0000f, 0.0000f, -78.7500f), new Vector3(-167.8510f, 490.0606f, 135.7694f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(-167.5152f, 490.5291f, 134.8193f), new Vector3(-8.5698f, 0.0000f, 118.8549f)),
            new ShowerCoords(new Vector3(121.3710f, 551.8600f, 179.6770f), new Vector3(0.0000f, 0.0000f, -84.2400f), new Vector3(121.9528f, 551.1089f, 182.4490f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(121.6896f, 551.3428f, 181.2820f), new Vector3(-12.7072f, 0.0000f, 106.2162f)),
            new ShowerCoords(new Vector3(-804.2160f, 335.0650f, 189.9520f), new Vector3(0.0000f, 0.0000f, 90.0000f), new Vector3(-803.8332f, 335.6036f, 192.1505f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(-803.7757f, 335.7051f, 192.0836f), new Vector3(-64.3203f, 0.0000f, 90.0509f)),
            new ShowerCoords(new Vector3(-1385.4200f, -470.7970f, 71.2030f), new Vector3(0.0000f, 0.0000f, -82.1600f), new Vector3(-1385.7200f, -471.5600f, 73.3700f), new Vector3(-45.0000f, 0.0000f, 0.0000f), new Vector3(-1385.4200f, -470.7970f, 72.3000f), new Vector3(0.0000f, 0.0000f, -82.1600f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-767.6866f, 326.602478f, 169.7948f), new Vector3(0.0f, 0.0f, 90.0f), new Vector3(-767.2856f, 327.252472f, 171.9578f), new Vector3(-45.0f, 0.0f, -180.0f), new Vector3(-768.1166f, 327.652466f, 171.6828f), new Vector3(315.0f, 0.0f, 90.0f)),
            new ShowerCoords(new Vector3(-767.777161f, 326.606079f, 216.2488f), new Vector3(0.0f, 0.0f, 90.0f), new Vector3(-767.37616f, 327.256073f, 218.411789f), new Vector3(-45.0f, 0.0f, -180.0f), new Vector3(-768.207153f, 327.656067f, 218.1368f), new Vector3(315.0f, 0.0f, 90.0f)),
            new ShowerCoords(new Vector3(-788.797241f, 331.0422f, 152.9926f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-789.198242f, 330.3922f, 155.1556f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-788.367249f, 329.992218f, 154.8806f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-268.8693f, -953.806152f, 70.2224045f), new Vector3(0.0f, 0.0f, 160.0f), new Vector3(-269.342926f, -953.207031f, 72.3854f), new Vector3(-45.0f, 0.0f, -110.0f), new Vector3(-270.003021f, -953.851135f, 72.110405f), new Vector3(315.0f, 0.0f, 160.0f)),
            new ShowerCoords(new Vector3(-274.3165f, -954.534363f, 85.502f), new Vector3(0.0f, 0.0f, -20.0f), new Vector3(-273.842865f, -955.1335f, 87.66499f), new Vector3(-45.0f, 0.0f, 70.0f), new Vector3(-273.18277f, -954.4894f, 87.39f), new Vector3(315.0f, 0.0f, -20.0f)),
            new ShowerCoords(new Vector3(-1461.3363f, -534.3227f, 62.54768f), new Vector3(0.0f, 0.0f, -55.0f), new Vector3(-1461.292f, -535.085144f, 64.71068f), new Vector3(-45.0f, 0.0f, 35.0f), new Vector3(-1460.38184f, -534.936157f, 64.4356842f), new Vector3(315.0f, 0.0f, -55.0f)),
            new ShowerCoords(new Vector3(-1461.3363f, -534.3227f, 49.920063f), new Vector3(0.0f, 0.0f, -55.0f), new Vector3(-1461.292f, -535.085144f, 52.0830574f), new Vector3(-45.0f, 0.0f, 35.0f), new Vector3(-1460.38184f, -534.936157f, 51.8080635f), new Vector3(315.0f, 0.0f, -55.0f)),
            new ShowerCoords(new Vector3(-895.3639f, -446.567139f, 119.525505f), new Vector3(0.0f, 0.0f, 117.556168f), new Vector3(-895.3091f, -445.805359f, 121.6885f), new Vector3(-45.0f, 0.0f, -152.443832f), new Vector3(-896.230835f, -445.835175f, 121.413506f), new Vector3(315.0f, 0.0f, 117.556168f)),
            new ShowerCoords(new Vector3(-903.1201f, -443.489166f, 114.5982f), new Vector3(0.0f, 0.0f, -63.3092957f), new Vector3(-903.1864f, -444.250031f, 116.761192f), new Vector3(-45.0f, 0.0f, 26.6907043f), new Vector3(-902.2643f, -444.234131f, 116.4862f), new Vector3(315.0f, 0.0f, -63.3092957f)),
            new ShowerCoords(new Vector3(-897.571045f, -440.417419f, 88.45218f), new Vector3(0.0f, 0.0f, -153.0807f), new Vector3(-898.332153f, -440.354156f, 90.61517f), new Vector3(-45.0f, 0.0f, -63.0807037f), new Vector3(-898.3126f, -441.276184f, 90.34018f), new Vector3(315.0f, 0.0f, -153.0807f)),
            new ShowerCoords(new Vector3(-31.9253273f, -587.0056f, 83.10589f), new Vector3(0.0f, 0.0f, -110.0f), new Vector3(-32.524456f, -587.479248f, 85.26888f), new Vector3(-45.0f, 0.0f, -20.0f), new Vector3(-31.8803825f, -588.139343f, 84.99389f), new Vector3(315.0f, 0.0f, -110.0f)),
            new ShowerCoords(new Vector3(-21.0673981f, -593.863953f, 93.22392f), new Vector3(0.0f, 0.0f, 160.0f), new Vector3(-21.5410423f, -593.264832f, 95.38692f), new Vector3(-45.0f, 0.0f, -110.0f), new Vector3(-22.20113f, -593.908936f, 95.11192f), new Vector3(315.0f, 0.0f, 160.0f)),
            new ShowerCoords(new Vector3(-910.5702f, -371.726227f, 78.4715652f), new Vector3(0.0f, 0.0f, 116.926117f), new Vector3(-910.507f, -370.9651f, 80.63456f), new Vector3(-45.0f, 0.0f, -153.073883f), new Vector3(-911.4291f, -370.984772f, 80.3595657f), new Vector3(315.0f, 0.0f, 116.926117f)),
            new ShowerCoords(new Vector3(-919.498657f, -379.439819f, 102.431404f), new Vector3(0.0f, 0.0f, -62.5531f), new Vector3(-919.554932f, -380.201477f, 104.5944f), new Vector3(-45.0f, 0.0f, 27.4469f), new Vector3(-918.633057f, -380.173431f, 104.319405f), new Vector3(315.0f, 0.0f, -62.5531f)),
            new ShowerCoords(new Vector3(-610.5763f, 55.62761f, 101.018105f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-610.9773f, 54.9776154f, 103.1811f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-610.1463f, 54.57762f, 102.906105f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-590.789856f, 51.68989f, 86.6172f), new Vector3(0.0f, 0.0f, 90.0f), new Vector3(-590.388855f, 52.3398857f, 88.7802f), new Vector3(-45.0f, 0.0f, -180.0f), new Vector3(-591.219849f, 52.73988f, 88.5052f), new Vector3(315.0f, 0.0f, 90.0f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-1456.09961f, -547.293457f, 62.6591034f), new Vector3(0.0f, 0.0f, 35.0f), new Vector3(-1455.33716f, -547.249146f, 64.8221f), new Vector3(-45.0f, 0.0f, 125.0f), new Vector3(-1455.48608f, -546.339f, 64.5471039f), new Vector3(315.0f, 0.0f, 35.0f)),
            new ShowerCoords(new Vector3(-906.45105f, -369.819153f, 102.8895f), new Vector3(0.0f, 0.0f, 117.0f), new Vector3(-906.388855f, -369.057953f, 105.0525f), new Vector3(-45.0f, 0.0f, -153.0f), new Vector3(-907.3109f, -369.078827f, 104.777504f), new Vector3(315.0f, 0.0f, 117.0f)),
            new ShowerCoords(new Vector3(-599.7421f, 51.948204f, 86.81501f), new Vector3(0.0f, 0.0f, 90.0f), new Vector3(-599.3411f, 52.5981979f, 88.9780045f), new Vector3(-45.0f, 0.0f, -180.0f), new Vector3(-600.1721f, 52.99819f, 88.70301f), new Vector3(315.0f, 0.0f, 90.0f)),
            new ShowerCoords(new Vector3(-32.0679359f, -587.3891f, 68.6457062f), new Vector3(0.0f, 0.0f, -110.12f), new Vector3(-32.6680565f, -587.8615f, 70.8087f), new Vector3(-45.0f, 0.0f, -20.1200027f), new Vector3(-32.0253677f, -588.522949f, 70.53371f), new Vector3(315.0f, 0.0f, -110.119995f)),
            new ShowerCoords(new Vector3(-788.329956f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(16.963623f, 984.8595f, 212.3391f), new Vector3(0.0f, 0.0f, -164.5f), new Vector3(16.2301025f, 985.072144f, 214.50209f), new Vector3(-45.0f, 0.0f, -74.5f), new Vector3(16.0667114f, 984.164551f, 214.2271f), new Vector3(315.0f, 0.0f, -164.5f)),
            new ShowerCoords(new Vector3(-1004.13171f, 1206.0321f, 207.099f), new Vector3(0.0f, 0.0f, -172.5f), new Vector3(-1004.82849f, 1206.34485f, 209.262f), new Vector3(-45.0f, 0.0f, -82.5f), new Vector3(-1005.11658f, 1205.46875f, 208.987f), new Vector3(315.0f, 0.0f, -172.5f)),
            new ShowerCoords(new Vector3(-1134.5575f, 144.810211f, 208.3381f), new Vector3(0.0f, 0.0f, -60.5f), new Vector3(-1134.58643f, 144.047f, 210.5011f), new Vector3(-45.0f, 0.0f, 29.5f), new Vector3(-1133.66626f, 144.108032f, 210.2261f), new Vector3(315.0f, 0.0f, -60.5f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.7311f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9001f, 329.6f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-1500.40833f, 764.311768f, 162.147f), new Vector3(0.0f, 0.0f, -110.5f), new Vector3(-1501.0116f, 763.8434f, 164.31f), new Vector3(-45.0f, 0.0f, -20.5f), new Vector3(-1500.37329f, 763.1777f, 164.035f), new Vector3(315.0f, 0.0f, -110.5f)),
            new ShowerCoords(new Vector3(-1614.35083f, 925.894348f, 162.5754f), new Vector3(0.0f, 0.0f, -125.0f), new Vector3(-1615.05212f, 925.5919f, 164.738388f), new Vector3(-45.0f, 0.0f, -35.0f), new Vector3(-1614.60083f, 924.7876f, 164.4634f), new Vector3(315.0f, 0.0f, -125.0f)),
            new ShowerCoords(new Vector3(-1771.13623f, 485.763184f, 169.167908f), new Vector3(0.0f, 0.0f, -91.5f), new Vector3(-1771.5542f, 485.1239f, 171.3309f), new Vector3(-45.0f, 0.0f, -1.5f), new Vector3(-1770.73389f, 484.702271f, 171.055908f), new Vector3(315.0f, 0.0f, -91.5f)),
            new ShowerCoords(new Vector3(-2214.38281f, 316.302063f, 114.2096f), new Vector3(0.0f, 0.0f, -96.0f), new Vector3(-2214.84961f, 315.6975f, 116.3726f), new Vector3(-45.0f, 0.0f, -6.0f), new Vector3(-2214.065f, 315.21286f, 116.0976f), new Vector3(315.0f, 0.0f, -96.0f)),
            new ShowerCoords(new Vector3(-555.7201f, 517.9686f, 162.2154f), new Vector3(0.0f, 0.0f, -110.0f), new Vector3(-556.3192f, 517.495f, 164.378387f), new Vector3(-45.0f, 0.0f, -20.0f), new Vector3(-555.675049f, 516.834839f, 164.1034f), new Vector3(315.0f, 0.0f, -110.0f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 230.33699f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 232.499985f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6f, 232.224991f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-772.676331f, 327.0984f, 209.3848f), new Vector3(0.0f, 0.0f, 90.0f), new Vector3(-772.2753f, 327.748383f, 211.547791f), new Vector3(-45.0f, 0.0f, -180.0f), new Vector3(-773.1063f, 328.148376f, 211.2728f), new Vector3(315.0f, 0.0f, 90.0f)),
            new ShowerCoords(new Vector3(-579.7008f, -717.703064f, 237.0929f), new Vector3(0.0f, 0.0f, -152.0f), new Vector3(-580.463f, -717.654236f, 239.25589f), new Vector3(-45.0f, 0.0f, -62.0f), new Vector3(-580.4261f, -718.5757f, 238.9809f), new Vector3(315.0f, 0.0f, -152.0f)),
            new ShowerCoords(new Vector3(-788.33f, 330.65f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.730957f, 329.9999f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.599945f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(648.079468f, -1253.17676f, 297.390381f), new Vector3(0.0f, 0.0f, 178.0f), new Vector3(647.443848f, -1252.7533f, 299.5534f), new Vector3(-45.0f, 0.0f, -92.0f), new Vector3(647.015137f, -1253.56982f, 299.278381f), new Vector3(315.0f, 0.0f, 178.0f)),
            new ShowerCoords(new Vector3(-508.118622f, 87.24957f, 371.9558f), new Vector3(0.0f, 0.0f, -28.0f), new Vector3(-507.732819f, 86.59033f, 374.118774f), new Vector3(-45.0f, 0.0f, 62.0f), new Vector3(-506.9896f, 87.13629f, 373.8438f), new Vector3(315.0f, 0.0f, -28.0f)),
            new ShowerCoords(new Vector3(-788.329956f, 330.6499f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.7311f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.9f, 329.6001f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-1090.84912f, 404.4295f, 151.112f), new Vector3(0.0f, 0.0f, -150.06f), new Vector3(-1091.61255f, 404.4525f, 153.275f), new Vector3(-45.0f, 0.0f, -60.0600052f), new Vector3(-1091.54431f, 403.5327f, 153.0f), new Vector3(315.0f, 0.0f, -150.06f)),
            new ShowerCoords(new Vector3(-597.065f, -1052.30847f, 151.112f), new Vector3(0.0f, 0.0f, 119.94f), new Vector3(-597.042f, -1051.545f, 153.275f), new Vector3(-45.0f, 0.0f, -150.06f), new Vector3(-597.9618f, -1051.61316f, 153.0f), new Vector3(315.0f, 0.0f, 119.94f)),
            new ShowerCoords(new Vector3(-2053.81982f, -1546.1062f, 151.112f), new Vector3(0.0f, 0.0f, 29.9400024f), new Vector3(-2053.0564f, -1546.12915f, 153.275f), new Vector3(-45.0f, 0.0f, 119.94f), new Vector3(-2053.12451f, -1545.20947f, 153.0f), new Vector3(315.0f, 0.0f, 29.9400024f)),
            new ShowerCoords(new Vector3(-2025.88879f, 403.6874f, 121.712f), new Vector3(0.0f, 0.0f, -87.46001f), new Vector3(-2026.26062f, 403.020172f, 123.874992f), new Vector3(-45.0f, 0.0f, 2.53999329f), new Vector3(-2025.4126f, 402.65744f, 123.6f), new Vector3(315.0f, 0.0f, -87.46002f)),
            new ShowerCoords(new Vector3(-2025.90881f, 403.6702f, 113.712f), new Vector3(0.0f, 0.0f, -87.46001f), new Vector3(-2026.28064f, 403.00296f, 115.874992f), new Vector3(-45.0f, 0.0f, 2.53999329f), new Vector3(-2025.43262f, 402.640228f, 115.6f), new Vector3(315.0f, 0.0f, -87.46002f)),
            new ShowerCoords(new Vector3(-734.5568f, -1354.55688f, 121.712f), new Vector3(0.0f, 0.0f, 92.73999f), new Vector3(-734.1874f, -1353.88843f, 123.874992f), new Vector3(-45.0f, 0.0f, -177.26001f), new Vector3(-735.03656f, -1353.52856f, 123.6f), new Vector3(315.0f, 0.0f, 92.73999f)),
            new ShowerCoords(new Vector3(-788.33f, 330.649963f, 200.612f), new Vector3(0.0f, 0.0f, -90.0f), new Vector3(-788.731f, 330.0f, 202.775f), new Vector3(-45.0f, 0.0f, 0.0f), new Vector3(-787.899963f, 329.599976f, 202.5f), new Vector3(315.0f, 0.0f, -90.0f)),
            new ShowerCoords(new Vector3(-927.401245f, 158.913879f, 200.612f), new Vector3(0.0f, 0.0f, -75.2000046f), new Vector3(-927.6229f, 158.182922f, 202.775f), new Vector3(-45.0f, 0.0f, 14.7999954f), new Vector3(-926.7173f, 158.008484f, 202.5f), new Vector3(315.0f, 0.0f, -75.20001f)),
            new ShowerCoords(new Vector3(898.497f, -292.3025f, 200.612f), new Vector3(0.0f, 0.0f, 164.799988f), new Vector3(897.9749f, -291.7451f, 202.775f), new Vector3(-45.0f, 0.0f, -105.200005f), new Vector3(897.3709f, -292.442169f, 202.5f), new Vector3(315.0f, 0.0f, 164.799988f)),
            new ShowerCoords(new Vector3(-219.241867f, 256.858643f, 286.612f), new Vector3(0.0f, 0.0f, -116.16f), new Vector3(-219.888382f, 256.452026f, 288.775f), new Vector3(-45.0f, 0.0f, -26.1600037f), new Vector3(-219.3188f, 255.726563f, 288.5f), new Vector3(315.0f, 0.0f, -116.16f)),
            new ShowerCoords(new Vector3(-1149.80664f, -959.772339f, 286.612f), new Vector3(0.0f, 0.0f, -26.1600037f), new Vector3(-1149.3999f, -960.4188f, 288.775f), new Vector3(-45.0f, 0.0f, 63.8399963f), new Vector3(-1148.67444f, -959.8493f, 288.5f), new Vector3(315.0f, 0.0f, -26.1600037f)),
            new ShowerCoords(new Vector3(999.511841f, -678.230957f, 286.612f), new Vector3(0.0f, 0.0f, 153.84f), new Vector3(999.1052f, -677.5845f, 288.775f), new Vector3(-45.0f, 0.0f, -116.16f), new Vector3(998.379761f, -678.154053f, 288.5f), new Vector3(315.0f, 0.0f, 153.84f))
        };

        private static List<int> ShowerList = new List<int>() { 1924030334, 1358716892, 879181614, -553740697 };

        public static void Init()
        {
            //TODO: ADD EVENTS FOR WHEN PED ENTERED APARTMENT, AND PASS PARAMETER IF IT'S OWNER OR NOT
            // maybe we can use the PlayerStateBag or FreeRoamStateBag handlers events and check them..

            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }

        // TODO: ON PLAYER LEFT WHAT? BUCKET? APARTMENT I'D SAY
        public static void onPlayerLeft(PlayerClient client)
        {
            RemoveAnimDict(sLocal_436);
            ReleaseAmbientAudioBank();
            RemoveNamedPtfxAsset("scr_fm_mp_missioncreator");
            TickController.TickApartments.Remove(CheckShowersNear);
        }

        private static async void Spawned(PlayerClient client)
        {
            if (Cache.PlayerCache.MyPlayer.User.Character.Skin.Sex == "Male")
            {
                sLocal_436 = "mp_safehouseshower@male@";
                sLocal_437 = "male_shower_undress_&_turn_on_water";
                sLocal_438 = "male_shower_enter_into_idle";
                sLocal_439 = "male_shower_idle_a";
                sLocal_440 = "male_shower_idle_b";
                sLocal_441 = "male_shower_idle_c";
                sLocal_442 = "male_shower_idle_d";
                sLocal_443 = "Male_Shower_Exit_To_Idle";
                sLocal_444 = "male_shower_undress_&_turn_on_water_door";
                sLocal_445 = "Male_Shower_Exit_To_Idle_Door";
                Global_2499242_f_20 = 0.5f;
                Global_2499242_f_21 = 0.55f;
                Global_2499242_f_22 = 0.833f;
                Global_2499242_f_23 = 0.25f;
                Global_2499242_f_15 = 0.26f;
                Global_2499242_f_16 = 0.9f;
                Global_2499242_f_17 = 0.3f;
                Global_2499242_f_18 = 0.79f;
            }
            else
            {
                sLocal_436 = "mp_safehouseshower@female@";
                sLocal_437 = "shower_undress_&_turn_on_water";
                sLocal_438 = "shower_enter_into_idle";
                sLocal_439 = "shower_idle_a";
                sLocal_440 = "shower_idle_b";
                sLocal_441 = "shower_idle_b";
                sLocal_442 = "shower_idle_a";
                sLocal_443 = "shower_Exit_To_Idle";
                sLocal_444 = "shower_undress_&_turn_on_water_door";
                sLocal_445 = "shower_Exit_To_Idle_Door";
                Global_2499242_f_20 = 0.5f;
                Global_2499242_f_21 = 0.5f;
                Global_2499242_f_22 = 0.384f;
                Global_2499242_f_23 = 0.166f;
                Global_2499242_f_15 = 0.26f;
                Global_2499242_f_16 = 0.9f;
                Global_2499242_f_17 = 0.3f;
                Global_2499242_f_18 = 0.75f;
            }

            RequestAnimDict(sLocal_436);
            while (!HasAnimDictLoaded(sLocal_436)) await BaseScript.Delay(0);
            RequestAmbientAudioBank(sLocal_448, false);
            Global_2499242_f_25 = GetSoundId();
            RequestNamedPtfxAsset("scr_fm_mp_missioncreator");
            while (!HasNamedPtfxAssetLoaded("scr_fm_mp_missioncreator")) await BaseScript.Delay(0);

            TickController.TickApartments.Add(CheckShowersNear);
        }

        public static async Task CheckShowersNear()
        {
            if (!InShower)
            {
                NearShower = World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => ShowerList.Contains(o.Model.Hash)).Any(o => Vector3.Distance(Cache.PlayerCache.MyPlayer.Position.ToVector3, o.Position) < 1.375f);

                if (NearShower)
                {
                    ShowerDoor = World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => ShowerList.Contains(o.Model.Hash)).First(o => Vector3.Distance(Cache.PlayerCache.MyPlayer.Position.ToVector3, o.Position) < 1.375f);
                    if (!ShowerDoor.IsAttached()) ShowerDoor.IsPositionFrozen = true;
                    actual = Coords.First(o => Vector3.Distance(o.anim, ShowerDoor.Position) < 2f);
                }
                await BaseScript.Delay(850);
            }
            else if (NearShower)
            {
                if (!InShower)
                {
                    int val = -1750863300;
                    DoorSystemSetDoorState((uint)val, 0, false, true);
                    Notifications.ShowHelpNotification(GetLabelText("SA_SHWR_IN"));
                    if (Input.IsControlJustPressed(Control.Context))
                    {
                        await Shower();
                    }
                }
            }

        }

        public static async Task Shower()
        {
            if (NearShower)
            {
                if (!InShower)
                {
                    int ped = PlayerCache.MyPlayer.Ped.Handle;
                    InShower = true;

                    //CreaCam(CameraCoords(GetInteriorFromGameplayCam()));
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_437, 1000f, -8f, 1, 0, 1000f, 4);
                    if (DoesEntityHaveDrawable(ShowerDoor.Handle)) PlaySynchronizedEntityAnim(ShowerDoor.Handle, Scene1, sLocal_444, sLocal_436, 2f, -8f, 1, 1148846080);
                    while (GetSynchronizedScenePhase(Scene1) < Global_2499242_f_20) await BaseScript.Delay(0);
                    func_314();
                    Cache.PlayerCache.MyPlayer.Ped.ClearBloodDamage();
                    Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "MP_APARTMENT_SHOWER_GET_UNDRESSED_MASTER", ped, 0, 0, 0);
                    while (GetSynchronizedScenePhase(Scene1) < Global_2499242_f_22) await BaseScript.Delay(0);
                    Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, Global_2499242_f_25, "MP_APARTMENT_SHOWER_MASTER", ped, 0, 0, 0);
                    UseParticleFxAsset("scr_fm_mp_missioncreator");
                    uLocal_433 = StartParticleFxLoopedAtCoord("ent_amb_shower", actual.FxShowerCoord.X, actual.FxShowerCoord.Y, actual.FxShowerCoord.Z, actual.FxShowerRot.X, actual.FxShowerRot.Y, actual.FxShowerRot.Z, 1f, false, false, false, true);
                    UseParticleFxAsset("scr_fm_mp_missioncreator");
                    uLocal_434 = StartParticleFxLoopedAtCoord("ent_amb_shower_steam", actual.FxSteamCoord.X, actual.FxSteamCoord.Y, actual.FxSteamCoord.Z, actual.FxSteamRot.X, actual.FxSteamRot.Y, actual.FxSteamRot.Z, 1f, false, false, false, true);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_438, 8f, -8f, 1, 0, 1148846080, 0);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_439, 8f, -8f, 1, 0, 1148846080, 0);
                    N_0x2208438012482a1a(ped, false, false);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_440, 8f, -8f, 1, 0, 1148846080, 0);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_441, 8f, -8f, 1, 0, 1148846080, 0);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_442, 8f, -8f, 1, 0, 1148846080, 0);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(1);
                    Scene1 = CreateSynchronizedScene(actual.anim.X, actual.anim.Y, actual.anim.Z, actual.rot.X, actual.rot.Y, actual.rot.Z, 0);
                    TaskSynchronizedScene(ped, Scene1, sLocal_436, sLocal_443, 1000f, -8f, 1, 0, 1148846080, 0);
                    if (DoesEntityHaveDrawable(ShowerDoor.Handle)) PlaySynchronizedEntityAnim(ShowerDoor.Handle, Scene1, sLocal_445, sLocal_436, 1000f, -8f, 1, 1148846080);
                    while (GetSynchronizedScenePhase(Scene1) < Global_2499242_f_23) await BaseScript.Delay(0);
                    if (DoesParticleFxLoopedExist(uLocal_433)) StopParticleFxLooped(uLocal_433, false);
                    if (DoesParticleFxLoopedExist(uLocal_434)) StopParticleFxLooped(uLocal_434, false);
                    StopSound(Global_2499242_f_25);
                    ReleaseAmbientAudioBank();
                    if (Global_2499242_f_25 != -1) ReleaseSoundId(Global_2499242_f_25);

                    if (Cache.PlayerCache.MyPlayer.User.Character.Skin.Sex == "Female")
                    {
                        while (GetSynchronizedScenePhase(Scene1) < 0.76f) await BaseScript.Delay(0);
                        Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "MP_APARTMENT_SHOWER_DOOR_OPEN_MASTER", ped, 0, 0, 0);
                    }
                    else
                    {
                        while (GetSynchronizedScenePhase(Scene1) < 0.8f) await BaseScript.Delay(0);
                        Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "MP_APARTMENT_SHOWER_DOOR_OPEN_MASTER", ped, 0, 0, 0);
                    }

                    while (GetSynchronizedScenePhase(Scene1) < Global_2499242_f_21) await BaseScript.Delay(0);
                    Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, -1, "MP_APARTMENT_SHOWER_GET_DRESSED_MASTER", ped, 0, 0, 0);
                    Functions.UpdateDress(ped, PlayerCache.MyPlayer.User.Character.Dressing);
                    while (GetSynchronizedScenePhase(Scene1) < 0.99f) await BaseScript.Delay(0);
                    ClearPedTasks(ped);
                    InShower = false;
                    RemoveAnimDict(sLocal_436);
                }
            }
        }

        private static void func_314()
        {
            int ped = PlayerCache.MyPlayer.Ped.Handle;
            //			func_315(ped , 4, -1, -1);
            SetPedComponentVariation(ped, 11, 15, 0, 0);
            if (GetPedDrawableVariation(ped, 3) != 15) SetPedComponentVariation(ped, 3, 15, 0, 0);
            SetPedComponentVariation(ped, 8, 15, 0, 0);
            SetPedComponentVariation(ped, 9, 0, 0, 0);
            SetPedComponentVariation(ped, 7, 0, 0, 0);
            SetPedComponentVariation(ped, 5, 0, 0, 0);
            SetPedComponentVariation(ped, 1, 0, 0, 0);
            SetPedComponentVariation(ped, 10, 0, 0, 0);
            if (GetPedDrawableVariation(ped, 6) != 5) SetPedComponentVariation(ped, 6, 5, 0, 0);
            ClearAllPedProps(ped);

            if (GetEntityModel(ped) == GetHashKey("mp_m_freemode_01"))
            {
                if (GetPedDrawableVariation(ped, 4) != 14)
                    SetPedComponentVariation(ped, 4, 14, 0, 0);
            }
            else
            {
                if (GetPedDrawableVariation(ped, 4) != 15)
                    SetPedComponentVariation(ped, 4, 15, 0, 0);
            }

            if (HasPedHeadBlendFinished(ped) && HasStreamedPedAssetsLoaded(ped))
                N_0x4668d80430d6c299(ped);
        }
    }

    internal class ShowerCoords
    {
        public Vector3 anim = new Vector3(0);
        public Vector3 rot = new Vector3(0);
        public Vector3 FxShowerCoord = new Vector3(0);
        public Vector3 FxShowerRot = new Vector3(0);
        public Vector3 FxSteamCoord = new Vector3(0);
        public Vector3 FxSteamRot = new Vector3(0);
        public ShowerCoords() { }

        public ShowerCoords(Vector3 anima, Vector3 rotaz, Vector3 fxshower, Vector3 fxshowerrot, Vector3 fxvapore, Vector3 fxvaporerot)
        {
            anim = anima;
            rot = rotaz;
            FxShowerCoord = fxshower;
            FxShowerRot = fxshowerrot;
            FxSteamCoord = fxvapore;
            FxSteamRot = fxvaporerot;
        }
    }
}