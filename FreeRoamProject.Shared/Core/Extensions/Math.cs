using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeRoamProject.Shared
{
    public static class SharedMath
    {
        private static Log Logger = new();
        private static Random random = new Random();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A double-precision floating point number that is greater than or equal to minValue, and less than maxValue.</returns>
        public static double NextDouble(this Random rand, double minValue, double maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (maxValue - minValue) * rand.NextDouble() + minValue;
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0f, and less than 1.0f.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A single-precision floating point number that is greater than or equal to 0.0f, and less than 1.0f.</returns>
        public static float NextFloat(this Random rand)
        {
            if (rand is null)
                rand = new Random();
            return (float)rand.NextDouble();
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0f, and less than 1.0f.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A single-precision floating point number that is greater than or equal to 0.0f, and less than 1.0f.</returns>
        public static float NextFloat(this Random rand, float maxValue)
        {
            return NextFloat(rand, 0, maxValue);
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A single-precision floating point number that is greater than or equal to minValue, and less than maxValue.</returns>
        public static float NextFloat(this Random rand, float minValue, float maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (float)rand.NextDouble(minValue, maxValue);
        }

        /// <summary>
        /// Picks a random char of the string passed
        /// </summary>
        /// <param name="chars">the string containing all the chars</param>
        /// <param name="rnd"> the Random() instance</param>
        /// <returns></returns>
        public static char PickOneChar(this string chars, Random rnd)
        {
            rnd ??= new Random();

            return chars[rnd.Next(chars.Length)];
        }

        /// <summary>
        /// Picks a random char of the string passed
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static char PickOneChar(this string chars)
        {
            return chars.PickOneChar(new Random(DateTime.Now.Millisecond));
        }


        /// <summary>
        /// Returns a random decimal number that is greater than or equal to 0.0m, and less than 1.0m.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A decimal number that is greater than or equal to 0.0m, and less than 1.0m.</returns>
        public static decimal NextDecimal(this Random rand)
        {
            rand ??= new Random();
            IEnumerable<string> d = Enumerable.Range(0, 29).Select(x => rand.Next(10).ToString());
            decimal result = decimal.Parse($"0.{string.Join(string.Empty, d)}");
            return result / 1.000000000000000000000000000000000m;
        }

        /// <summary>
        /// Returns a random decimal number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A decimal number that is greater than or equal to minValue, and less than maxValue.</returns>
        public static decimal NextDecimal(this Random rand, decimal minValue, decimal maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (maxValue - minValue) * rand.NextDecimal() + minValue;
        }

        /// <summary>
        /// Returns a random byte.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 8-bit unsigned integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static byte NextByte(this Random rand)
        {
            rand ??= new Random();

            return (byte)rand.Next(byte.MaxValue);
        }

        /// <summary>
        /// Returns a random byte that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 8-bit unsigned integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static byte NextByte(this Random rand, byte maxValue)
        {
            rand ??= new Random();

            return (byte)rand.Next(maxValue);
        }

        /// <summary>
        /// Returns a random byte that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 8-bit unsigned integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static byte NextByte(this Random rand, byte minValue, byte maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (byte)rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a non-negative random sbyte.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 8-bit signed integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static sbyte NextSByte(this Random rand)
        {
            rand ??= new Random();

            return (sbyte)rand.Next(sbyte.MaxValue);
        }

        /// <summary>
        /// Returns a non-negative random sbyte that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 8-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static sbyte NextSByte(this Random rand, sbyte maxValue)
        {
            rand ??= new Random();

            return maxValue < 0 ? throw new MinMaggioreDiMax() : (sbyte)rand.Next(maxValue);
        }

        /// <summary>
        /// Returns a random sbyte that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 8-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static sbyte NextSByte(this Random rand, sbyte minValue, sbyte maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (sbyte)rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a non-negative random short.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 16-bit signed integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static short NextShort(this Random rand)
        {
            rand ??= new Random();

            return (short)rand.Next(short.MaxValue);
        }

        /// <summary>
        /// Returns a non-negative random short that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 16-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static short NextShort(this Random rand, short maxValue)
        {
            rand ??= new Random();

            return maxValue < 0 ? throw new MinMaggioreDiMax() : (short)rand.Next(maxValue);
        }

        /// <summary>
        /// Returns a random short that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 16-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static short NextShort(this Random rand, short minValue, short maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (short)rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random ushort.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 16-bit unsigned integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static ushort NextUShort(this Random rand)
        {
            rand ??= new Random();

            return (ushort)rand.Next(ushort.MaxValue);
        }

        /// <summary>
        /// Returns a random ushort that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 16-bit unsigned integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static ushort NextUShort(this Random rand, ushort maxValue)
        {
            rand ??= new Random();

            return (ushort)rand.Next(maxValue);
        }

        /// <summary>
        /// Returns a random ushort that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 16-bit unsigned integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static ushort NextUShort(this Random rand, ushort minValue, ushort maxValue)
        {
            rand ??= new Random();

            return minValue > maxValue ? throw new MinMaggioreDiMax() : (ushort)rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random uint.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static uint NextUInt(this Random rand)
        {
            rand ??= new Random();
            byte[] buffer = new byte[4];
            rand.NextBytes(buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }

        /// <summary>
        /// Returns a random uint that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static uint NextUInt(this Random rand, uint maxValue)
        {
            return rand.NextUInt(uint.MinValue, maxValue);
        }

        /// <summary>
        /// Returns a random uint that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit unsigned integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static uint NextUInt(this Random rand, uint minValue, uint maxValue)
        {
            rand ??= new Random();
            if (minValue > maxValue)
                throw new MinMaggioreDiMax();
            else if (minValue == maxValue)
                return minValue;
            uint range = maxValue - minValue;
            uint bias = uint.MaxValue - uint.MaxValue % range;
            byte[] buffer = new byte[4];
            uint result;
            do
            {
                result = rand.NextUInt();
            } while (result >= bias);
            return result % range + minValue;
        }

        /// <summary>
        /// Returns a non-negative random long.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static long NextLong(this Random rand)
        {
            return (long)rand.NextULong(long.MaxValue);
        }

        /// <summary>
        /// Returns a non-negative random long that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static long NextLong(this Random rand, long maxValue)
        {
            return maxValue < 0 ? throw new MinMaggioreDiMax() : (long)rand.NextULong((ulong)maxValue);
        }

        /// <summary>
        /// Returns a random long that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 64-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static long NextLong(this Random rand, long minValue, long maxValue)
        {
            rand ??= new Random();
            if (minValue > maxValue)
                throw new MinMaggioreDiMax();
            else if (minValue == maxValue)
                return minValue;
            ulong umin = minValue < 0 ?
                (ulong)(minValue - long.MinValue) :
                (ulong)minValue + long.MaxValue + 1;
            ulong umax = maxValue < 0 ?
                (ulong)(maxValue - long.MinValue) :
                (ulong)maxValue + long.MaxValue + 1;
            ulong result = rand.NextULong(umin, umax);
            return result >= (ulong)long.MaxValue + 1 ?
                (long)(result - long.MaxValue) - 1 :
                long.MaxValue + (long)result;
        }

        /// <summary>
        /// Returns a random ulong.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>A 64-bit unsigned integer that is greater than or equal to 0 and less than MaxValue.</returns>
        public static ulong NextULong(this Random rand)
        {
            rand ??= new Random();
            byte[] buffer = new byte[8];
            rand.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Returns a random ulong that is less than the specified maximum.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 64-bit unsigned integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static ulong NextULong(this Random rand, ulong maxValue)
        {
            return rand.NextULong(ulong.MinValue, maxValue);
        }

        /// <summary>
        /// Returns a random ulong that is within a specified range.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <param name="minValue">The incFreeRoamProject lower bound of the random number returned.</param>
        /// <param name="maxValue">The excFreeRoamProject upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 64-bit unsigned integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public static ulong NextULong(this Random rand, ulong minValue, ulong maxValue)
        {
            rand ??= new Random();
            if (minValue > maxValue)
                throw new MinMaggioreDiMax();
            /*else*/
            if (minValue == maxValue)
                return minValue;
            ulong range = maxValue - minValue;
            ulong bias = ulong.MaxValue - ulong.MaxValue % range;
            ulong result;
            do
            {
                result = rand.NextULong();
            } while (result >= bias);
            return result % range + minValue;
        }

        public static T Clamp<T>(T value, T min, T max) where T : System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;

            if (value.CompareTo(min) < 0)
                result = min;

            return result;
        }

        public static bool NextBool(this Random r, int truePercentage = 50)
        {
            return r.NextDouble() < truePercentage / 100.0;
        }

        public static bool Intersects(float[] A, float[] B, float[] P)
        {
            if (A[1] > B[1])
                return Intersects(B, A, P);

            if (P[1] == A[1] || P[1] == B[1])
                P[1] += 0.0001f;

            if (P[1] > B[1] || P[1] < A[1] || P[0] > Math.Max(A[0], B[00]))
                return false;

            if (P[0] < Math.Min(A[0], B[0]))
                return true;

            double red = (P[1] - A[1]) / (double)(P[0] - A[0]);
            double blue = (B[1] - A[1]) / (double)(B[0] - A[0]);
            return red >= blue;
        }

        public static bool Contains(float[][] shape, float[] pnt)
        {
            bool inside = false;
            int len = shape.Length;
            for (int i = 0; i < len; i++)
            {
                if (Intersects(shape[i], shape[(1 + i) % len], pnt))
                    inside = !inside;
            }
            return inside;
        }

        public static bool PointIsWithinCircle(float circleRadius, float circleCenterPointX, float circleCenterPointY, float pointToCheckX, float pointToCheckY)
        {
            return (Math.Pow(pointToCheckX - circleCenterPointX, 2) + Math.Pow(pointToCheckY - circleCenterPointY, 2)) < (Math.Pow(circleRadius, 2));
        }

        public static bool PointIsWithinSphere(float sphereRadius, Vector3 SphereCenter, Vector3 PointToCheck)
        {
            return (Math.Pow(SphereCenter.X - PointToCheck.X, 2) + Math.Pow(SphereCenter.Y - PointToCheck.Y, 2) + Math.Pow(SphereCenter.Z - PointToCheck.Z, 2)) < Math.Pow(sphereRadius, 2);
        }

        public static int GetRandomInt(int end) { return random.Next(end); }

        public static int GetRandomInt(int start, int end) { return random.Next(start, end); }

        public static long GetRandomLong(long end)
        {
            return random.NextLong(end);
        }

        public static long GetRandomLong(long start, long end)
        {
            return random.NextLong(start, end);
        }

        public static float GetRandomFloat() { return (float)Math.Round(random.NextFloat()); }
        public static float GetRandomFloat(float end) { return GetRandomFloat(0, end); }

        public static float GetRandomFloat(float start, float end)
        {
            return (float)Math.Round(random.NextFloat(start, end), 3);
        }

        public static string GetRandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder(size);
            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65�90 / 97�122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (int i = 0; i < size; i++)
            {
                char @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static Tuple<int, int> secondsToClock(int Seconds)
        {
            int seconds = Seconds;
            int hours;
            int mins;
            int secs;

            if (seconds <= 0) return new Tuple<int, int>(mins = 0, secs = 0);
            hours = (int)Math.Floor((float)(seconds / 3600));
            mins = (int)Math.Floor((float)(seconds / 60 - hours * 60));
            secs = (int)Math.Floor((float)(seconds - hours * 3600 - mins * 60));

            return new Tuple<int, int>(mins, secs);
        }

    }
}
