using System;
using System.Threading.Tasks;

namespace Client.Scripts.Minigiochi.Tron
{
    static class Deadline
    {
        public static void Init()
        {

        }
        static Vector4[] posList = new Vector4[99];

        public static async Task OnTick()
        {
            if (Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, "Deadline"))
            {
                if (PlayerCache.MyPlayer.Ped.IsSittingInVehicle())
                {
                    if (!Function.Call<bool>(Hash._GET_SCREEN_EFFECT_IS_ACTIVE, "DeadlineNeon"))
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "DeadlineNeon", 0, 1);
                    }
                    Vehicle v = PlayerCache.MyPlayer.Ped.CurrentVehicle;
                    int index = Function.Call<int>(Hash.GET_ENTITY_BONE_INDEX_BY_NAME, v.Handle, "wheel_lr");
                    Vector3 poz = Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, v.Handle, index);
                    //World.DrawMarker(MarkerType.DebugSphere, poz, Vector3.Zero, Vector3.Zero, Vector3.One * 0.4f, Color.FromArgb(255, 0, 0));


                    Vector3 currentpos = PlayerCache.MyPlayer.Ped.CurrentVehicle.Position;
                    Vector4[] oldArray = posList;
                    Array.Copy(oldArray, 0, posList, 1, 99);
                    posList[0] = new Vector4(currentpos, PlayerCache.MyPlayer.Ped.CurrentVehicle.Rotation.Y);
                    for (int i = 0; i < 99; i++)
                    {
                        //Debug.WriteLine(i.ToString());
                        Vector3 pos = new Vector3(posList[i].X, posList[i].Y, posList[i].Z);
                        float rot = MathUtil.DegreesToRadians(posList[i].W);
                        Vector3 pos2 = new Vector3(posList[i + 1].X, posList[i + 1].Y, posList[i + 1].Z);
                        float rot2 = MathUtil.DegreesToRadians(posList[i + 1].W);

                        Vector3 ul = pos + new Vector3(0f, 0f, 0.4f);
                        Vector3 ur = pos2 + new Vector3(0f, 0f, 0.4f);
                        Vector3 bl = pos + new Vector3(0f, 0f, -0.2f);
                        Vector3 br = pos2 + new Vector3(0f, 0f, -0.2f);
                        int alpha = 175;
                        Function.Call((Hash)0x736D7AA1B750856B, ur, bl, br, 24, 202, 230, alpha, "Deadline", "Deadline_Trail_01", 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 1f);
                        Function.Call((Hash)0x736D7AA1B750856B, br, bl, ur, 24, 202, 230, alpha, "Deadline", "Deadline_Trail_01", 0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f, 1f);
                        Function.Call((Hash)0x736D7AA1B750856B, ur, ul, bl, 24, 202, 230, alpha, "Deadline", "Deadline_Trail_01", 0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f, 1f);
                        Function.Call((Hash)0x736D7AA1B750856B, ul, ur, bl, 24, 202, 230, alpha, "Deadline", "Deadline_Trail_01", 0f, 0f, 1f, 1f, 0f, 1f, 1f, 1f, 1f);

                    }
                }
                else
                {
                    if (Function.Call<bool>(Hash._GET_SCREEN_EFFECT_IS_ACTIVE, "DeadlineNeon"))
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "DeadlineNeon");
                }
            }
            else
                Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "Deadline", true);

            await Task.FromResult(0);
        }
    }
}
