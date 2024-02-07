using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
#if CLIENT
using ScaleformUI.Menu;
using ScaleformUI;
using static CitizenFX.Core.Native.API;
#endif

namespace FreeRoamProject.Shared
{
    public static class Extensions
    {
        private static readonly Log Logger = new();

        public static async Task ForEachAsync<T>(this List<T> list, Func<T, Task> Funzioni)
        {
            foreach (T value in list)
            {
                await Funzioni(value);
            }
        }

        public static T GetVal<T>(this IDictionary<string, object> dict, string key, T defaultVal)
        {
            if (dict.ContainsKey(key))
                if (dict[key] is T t)
                    return t;
            return defaultVal;
        }

#if CLIENT
        public static void BindItemToMenu(this UIMenuItem item, UIMenu newmenu)
        {
            item.Activated += async (a, b) => await a.SwitchTo(newmenu, 0, true);
        }

        public static async Task<float> FindGroundZ(this Vector3 position)
        {
            float z = 0;
            try
            {
                float h = position.Z;
                int time = GetNetworkTime();
                while (z == 0)
                {
                    if (GetNetworkTime() - time > 5000)
                    {
                        Logger.Debug($"Vector3 FindGroundZ: Troppo tempo a caricare la coordinata Z, esco dall'attesa..");
                        return -199.99f;
                    }
                    await BaseScript.Delay(50);
                    bool pippo = GetGroundZFor_3dCoord(position.X, position.Y, h, ref z, false);
                    h += 10;
                }
                return z;
            }
            catch (Exception ex)
            {
                Logger.Error($"Vector3 FindGroundZ Error: {ex.Message}");
                return -199f;
            }
        }

        public static async Task<float> FindGroundZ(this Vector4 position)
        {
            float result = -199f;
            try
            {
                float[] groundCheckHeight = [-100.0f, -50.0f, 0.0f, 50.0f, 100.0f, 150.0f, 200.0f, 250.0f, 300.0f, 350.0f, 400.0f, 450.0f, 500.0f, 550.0f, 600.0f, 650.0f, 700.0f, 750.0f, 800.0f];

                foreach (float h in groundCheckHeight)
                {
                    await BaseScript.Delay(1);
                    float z = 0;
                    if (GetGroundZFor_3dCoord(position.X, position.Y, h, ref z, false))
                    {
                        result = z;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Vector4 FindGroundZ Error: {ex.Message}");
            }
            await Task.FromResult(0);
            return result;
        }

        public static async Task<float> FindGroundZ(this Position position)
        {
            float z = 0;
            try
            {
                float h = position.Z;
                int time = GetNetworkTime();
                while (z == 0)
                {
                    if (GetNetworkTime() - time > 5000)
                    {
                        Logger.Debug($"Position FindGroundZ: Taking too much to load Z, exiting from await..");
                        return -199.99f;
                    }
                    await BaseScript.Delay(50);
                    bool pippo = GetGroundZFor_3dCoord(position.X, position.Y, h, ref z, false);
                    h += 10;
                }
                return z;
            }
            catch (Exception ex)
            {
                Logger.Error($"Vector3 FindGroundZ Error: {ex.Message}");
                return -199f;
            }
        }

        public static async Task<Vector3> GetVector3WithGroundZ(this Vector3 position)
        {
            try
            {
                float Z = await position.FindGroundZ();
                return new Vector3(position.X, position.Y, Z);
            }
            catch (Exception ex)
            {
                Logger.Error($"Vector3 GetVector3WithGroundZ Error: {ex.Message}");
                return new Vector3(position.X, position.Y, -199.99f);
            }
        }
        public static async Task<Vector4> GetVector4WithGroundZ(this Vector4 position)
        {
            try
            {
                float Z = await position.FindGroundZ();
                return new Vector4(position.X, position.Y, Z, position.W);
            }
            catch (Exception ex)
            {
                Logger.Error($"Vector4 GetVector4WithGroundZ Error: {ex.Message}");
                return new Vector4(position.X, position.Y, -199.99f, position.W);
            }
        }

        public static async Task<Position> GetPositionWithGroundZ(this Position position)
        {
            try
            {
                float Z = await position.FindGroundZ();
                return new Position(position.X, position.Y, Z, position.Heading);
            }
            catch (Exception ex)
            {
                Logger.Error($"Position GetVector3WithGroundZ Error: {ex.Message}");
                return new Position(position.X, position.Y, -199.99f, position.Heading);
            }
        }

        /// <summary>
        /// Loads the area where the camera was created (even if the ped is far away). It is reset with ClearFocus().
        /// </summary>
        /// <param name="pos"></param>
        public static void SetFocus(this Vector3 pos)
        {
            SetFocusPosAndVel(pos.X, pos.Y, pos.Z, 0, 0, 0);
        }

        /// <summary>
        /// Loads the area where the camera was created (even if the ped is far away). It is reset with ClearFocus().
        /// </summary>
        /// <param name="pos"></param>
        public static void SetFocus(this Vector4 pos)
        {
            SetFocusPosAndVel(pos.X, pos.Y, pos.Z, 0, 0, 0);
        }

        /// <summary>
        /// Loads the area where the camera was created (even if the ped is far away). It is reset with ClearFocus().
        /// </summary>
        /// <param name="pos"></param>
        public static void SetFocus(this Position pos)
        {
            SetFocusPosAndVel(pos.X, pos.Y, pos.Z, 0, 0, 0);
        }
#endif

        public static PointF Add(this PointF c1, PointF c2)
        {
            return new PointF(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static PointF Subtract(this PointF c1, PointF c2)
        {
            return new PointF(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static List<T> Slice<T>(this List<T> list, int start, int end)
        {
            return list.Skip(start).Take(end - start + 1).ToList();
        }

        public static bool IsBetween<T>(this T value, T start, T end) where T : IComparable
        {
            return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
        }

        // WIP
        public static Color ToColor(this string color)
        {
            try
            {
                return Color.FromArgb(int.Parse(color.Replace("#", ""),
                             System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            catch (Exception ex)
            {
                Logger.Error($"ToColor exception: {ex.Data}");
            }
            return Color.FromArgb(255, 255, 255, 255);
        }

        public static Vector2 ToVector2(this float[] xyArray)
        {
            try
            {
                return new Vector2(xyArray[0], xyArray[1]);
            }
            catch (Exception ex)
            {
                Logger.Debug($"ToVector2 exception: {ex.Data}");
            }
            return Vector2.Zero;
        }

        public static Vector3 ToVector3(this float[] xyzArray)
        {
            try
            {
                return new Vector3(xyzArray[0], xyzArray[1], xyzArray[2]);
            }
            catch (Exception ex)
            {
                Logger.Debug($"ToVector3 exception: {ex.Data}");
            }
            return Vector3.Zero;
        }

        public static Vector3 ToVector3(this Vector4 vector)
        {
            try
            {
                return new Vector3(vector.X, vector.Y, vector.Z);
            }
            catch (Exception ex)
            {
                Logger.Debug($"ToVector3 exception: {ex.Data}");
            }
            return Vector3.Zero;
        }

        public static Vector4 ToVector4(this float[] xyzwArray)
        {
            try
            {
                return new Vector4(xyzwArray[0], xyzwArray[1], xyzwArray[2], xyzwArray[3]);
            }
            catch (Exception ex)
            {
                Logger.Debug($"ToVector4 exception: {ex.Data}");
            }
            return Vector4.Zero;
        }


        public static Position ToPosition(this Vector3 vec) => new(vec);
        public static Position ToPosition(this Vector4 vec) => new(vec.ToVector3(), vec.W);

        public static bool IsInMarker(Position markerPos, Position pos, Vector3 Scale)
        {
            Vector3 center = markerPos.ToVector3;

            float _xRadius = Scale.X / 2;
            float _yRadius = Scale.Y / 2;
            float _wRadius = Scale.Z / 2;

            if (_xRadius <= 0f || _yRadius <= 0f || _wRadius <= 0f)
                return false;

            Vector3 normalized = new(pos.X - center.X, pos.Y - center.Y, center.Z - pos.Z);
            return (Math.Pow(normalized.X, 2) / Math.Pow(_xRadius, 2) + Math.Pow(normalized.Y, 2) / Math.Pow(_yRadius, 2) + Math.Pow(normalized.Z, 2) / Math.Pow(_wRadius, 2)) <= 1f;
        }

#if SERVER
        public static void TriggerSubsystemEvent(this Player player, string endpoint, params object[] args)
        {
            EventDispatcher.Send(player, endpoint, args);
        }

        public static void TriggerSubsystemEvent(this PlayerClient client, string endpoint, params object[] args)
        {
            EventDispatcher.Send(client, endpoint, args);
        }

#endif
    }

    internal class IgnoreJsonAttributesResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in props)
            {
                prop.Ignored = false;   // Ignore [JsonIgnore]
                                        //prop.Converter = null;  // Ignore [JsonConverter]
                                        //prop.PropertyName = prop.UnderlyingName;  // Use original property name instead of [JsonProperty] name
            }
            return props;
        }
    }

    public class MinMaggioreDiMax : Exception { }
}