using Newtonsoft.Json;
using System;
using System.IO;

namespace FreeRoamProject.Shared
{
    public class Position
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Heading { get => Roll; set => Roll = value; }
        public float Roll { get; set; }
        public float Pitch { get; set; }
        public float Yaw { get; set; }

        public static readonly Position Zero = new();


        public Position() { }

        public Position(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Position(float x, float y, float z, float heading)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = heading;
        }


        public Position(float x, float y, float z, float roll, float pitch, float yaw)
        {
            X = x;
            Y = y;
            Z = z;
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public Position(Vector3 value)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
        }

        public Position(Vector3 pos, Vector3 rot)
        {
            X = pos.X;
            Y = pos.Y;
            Z = pos.Z;
            Roll = rot.X;
            Pitch = rot.Y;
            Yaw = rot.Z;
        }

        public Position(Vector3 value, float heading)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            Yaw = heading;
        }

        public Position(Vector3 pos, float roll, float pitch, float yaw)
        {
            X = pos.X;
            Y = pos.Y;
            Z = pos.Z;
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
        }

        public Position(BinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
            Roll = reader.ReadSingle();
            Pitch = reader.ReadSingle();
            Yaw = reader.ReadSingle();
        }

        public void PackSerializedBytes(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Z);
            writer.Write(Roll);
            writer.Write(Pitch);
            writer.Write(Yaw);
        }

        public Position Subtract(Position position)
        {
            X -= position.X;
            Y -= position.Y;
            Z -= position.Z;
            Yaw -= position.Yaw;
            Pitch -= position.Pitch;
            Roll -= position.Roll;

            return this;
        }

        public static Position Subtract(Position pos, Position position)
        {
            return new(
            pos.X - position.X,
            pos.Y - position.Y,
            pos.Z - position.Z,
            pos.Yaw - position.Yaw,
            pos.Pitch - position.Pitch,
            pos.Roll - position.Roll);
        }

        public Position Add(Position position)
        {
            X += position.X;
            Y += position.Y;
            Z += position.Z;
            Yaw += position.Yaw;
            Pitch += position.Pitch;
            Roll += position.Roll;

            return this;
        }

        public bool AreAlmostEqual(Vector3 v1, float fTolerance = 0.5f, bool bDisregardZ = false)
        {
            if (fTolerance < 0)
                fTolerance = 0;
            if (!bDisregardZ)
            {
                if (Math.Abs(X - v1.X) <= fTolerance && Math.Abs(Y - v1.Y) <= fTolerance && Math.Abs(Z - v1.Z) <= fTolerance)
                    return true;
            }
            else
            {
                if (Math.Abs(X - v1.X) <= fTolerance && Math.Abs(Y - v1.Y) <= fTolerance)
                    return true;
            }
            return false;
        }


        public Position Clone() => new(X, Y, Z, Yaw, Pitch, Roll);

        public override string ToString() => $"X:{X}, Y:{Y}, Z:{Z} [Yaw(X):{Yaw}, Pitch(Y):{Pitch}, Roll(Z):{Roll}]";


        [JsonIgnore]
        public bool IsZero => X == 0 && Y == 0 && Z == 0 && Yaw == 0 && Pitch == 0 && Roll == 0;

        public float[] ToArray() => new[] { X, Y, Z, Yaw, Pitch, Roll };


        [JsonIgnore]
        public Vector2 ToVector2 => new(X, Y);
        [JsonIgnore]
        public Vector3 ToVector3 => new(X, Y, Z);
        [JsonIgnore]
        public Vector4 ToVector4 => new(X, Y, Z, Yaw);


        [JsonIgnore]
        public Vector3 ToRotationVector => new(Roll, Pitch, Yaw);

        public float Distance(Vector3 value)
        {
            float x = X - value.X;
            float y = Y - value.Y;
            float z = Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static float Distance(Position pos, Vector3 value)
        {
            float x = pos.X - value.X;
            float y = pos.Y - value.Y;
            float z = pos.Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }


        public float Distance(Vector4 value)
        {
            float x = X - value.X;
            float y = Y - value.Y;
            float z = Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static float Distance(Position pos, Vector4 value)
        {
            float x = pos.X - value.X;
            float y = pos.Y - value.Y;
            float z = pos.Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public float Distance(Position value)
        {
            float x = X - value.X;
            float y = Y - value.Y;
            float z = Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static float Distance(Position pos, Position value)
        {
            float x = pos.X - value.X;
            float y = pos.Y - value.Y;
            float z = pos.Z - value.Z;
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static bool AreAlmostEqual(Position pos, Vector3 v1, float fTolerance = 0.5f, bool bDisregardZ = false)
        {
            if (fTolerance < 0)
                fTolerance = 0;
            if (!bDisregardZ)
            {
                if (Math.Abs(pos.X - v1.X) <= fTolerance && Math.Abs(pos.Y - v1.Y) <= fTolerance && Math.Abs(pos.Z - v1.Z) <= fTolerance)
                    return true;
            }
            else
            {
                if (Math.Abs(pos.X - v1.X) <= fTolerance && Math.Abs(pos.Y - v1.Y) <= fTolerance)
                    return true;
            }
            return false;
        }
        public float LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z);
        }

        public bool IsInRangeOf(Vector3 value, float radius) => Distance(value) <= radius;
        public bool IsInRangeOf(Position value, float radius) => Distance(value) <= radius;

        public static Position operator +(Position left, Position right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.Yaw + right.Yaw, left.Pitch + right.Pitch, left.Roll + right.Roll);
        public static Position operator +(Position value) => value;
        public static Position operator +(Position value, float scalar) => new(value.X + scalar, value.Y + scalar, value.Z + scalar, value.Yaw + scalar, value.Pitch + scalar, value.Roll + scalar);
        public static Position operator +(float scalar, Position value) => new(scalar + value.X, scalar + value.Y, scalar + value.Z, value.Yaw + scalar, value.Pitch + scalar, value.Roll + scalar);
        public static Position operator -(Position left, Position right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.Yaw - right.Yaw, left.Pitch - right.Pitch, left.Roll - right.Roll);
        public static Position operator -(Position value) => new(-value.X, -value.Y, -value.Z, -value.Yaw, -value.Pitch, -value.Roll);
        public static Position operator -(Position value, float scalar) => new(value.X - scalar, value.Y - scalar, value.Z - scalar, value.Yaw - scalar, value.Pitch - scalar, value.Roll - scalar);
        public static Position operator -(float scalar, Position value) => new(scalar - value.X, scalar - value.Y, scalar - value.Z, scalar - value.Yaw, scalar - value.Pitch, scalar - value.Roll);
        public static Position operator *(float scale, Position value) => new(value.X * scale, value.Y * scale, value.Z * scale, value.Pitch * scale, value.Yaw * scale, value.Roll * scale);
        public static Position operator *(Position value, float scale) => new(value.X * scale, value.Y * scale, value.Z * scale, value.Pitch * scale, value.Yaw * scale, value.Roll * scale);
        public static Position operator *(Position left, Position right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.Yaw * right.Yaw, left.Pitch * right.Pitch, left.Roll * right.Roll);
        public static Position operator /(Position value, float scale) => new(value.X / scale, value.Y / scale, value.Z / scale, value.Yaw / scale, value.Pitch / scale, value.Roll / scale);
        public static Position operator /(float scale, Position value) => new(scale / value.X, scale / value.Y, scale / value.Z, scale / value.Yaw, scale / value.Pitch, scale / value.Roll);
        public static Position operator /(Position value, Position scale) => new(value.X / scale.X, value.Y / scale.Y, value.Z / scale.Z, value.Yaw / scale.Yaw, value.Pitch / scale.Pitch, value.Roll / scale.Roll);

        public static bool operator ==(Position left, Position right) => left?.Equals(right) ?? false;
        public static bool operator !=(Position left, Position right) => !(left == right);

        public static bool operator >(Position left, Position right) => left.X > right.X || left.Y > right.Y || left.Z > right.Z || left.Yaw > right.Yaw || left.Pitch > right.Pitch || left.Roll > right.Roll;
        public static bool operator <(Position left, Position right) => left.X < right.X || left.Y < right.Y || left.Z < right.Z || left.Yaw < right.Yaw || left.Pitch < right.Pitch || left.Roll < right.Roll;

        public static bool operator >=(Position left, Position right) => left.X >= right.X || left.Y >= right.Y || left.Z >= right.Z || left.Yaw >= right.Yaw || left.Pitch >= right.Pitch || left.Roll >= right.Roll;
        public static bool operator <=(Position left, Position right) => left.X <= right.X || left.Y <= right.Y || left.Z <= right.Z || left.Yaw <= right.Yaw || left.Pitch <= right.Pitch || left.Roll <= right.Roll;

        public static bool operator >=(float left, Position right) => left >= right.X || left >= right.Y || left >= right.Z || left >= right.Yaw || left >= right.Pitch || left >= right.Roll;
        public static bool operator <=(float left, Position right) => left <= right.X || left <= right.Y || left <= right.Z || left <= right.Yaw || left <= right.Pitch || left <= right.Roll;

        public bool Equals(ref Position other) => other is not null && MathUtil.NearEqual(other.X, X) && MathUtil.NearEqual(other.Y, Y) && MathUtil.NearEqual(other.Z, Z)
            && MathUtil.NearEqual(other.Yaw, Yaw) && MathUtil.NearEqual(other.Pitch, Pitch) && MathUtil.NearEqual(other.Roll, Roll);

        public bool Equals(Position other) => Equals(ref other);

        public override bool Equals(object value)
        {
            if ((value is not Position || value is null))
                return false;

            Position strongValue = (Position)value;
            return Equals(ref strongValue);
        }

        public override int GetHashCode()
        {
            int hashCode = -297745992;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            hashCode = hashCode * -1521134295 + Heading.GetHashCode();
            hashCode = hashCode * -1521134295 + Yaw.GetHashCode();
            hashCode = hashCode * -1521134295 + Pitch.GetHashCode();
            hashCode = hashCode * -1521134295 + Roll.GetHashCode();
            hashCode = hashCode * -1521134295 + IsZero.GetHashCode();
            hashCode = hashCode * -1521134295 + ToVector2.GetHashCode();
            hashCode = hashCode * -1521134295 + ToVector3.GetHashCode();
            hashCode = hashCode * -1521134295 + ToVector4.GetHashCode();
            hashCode = hashCode * -1521134295 + ToRotationVector.GetHashCode();
            return hashCode;
        }
    }
}
