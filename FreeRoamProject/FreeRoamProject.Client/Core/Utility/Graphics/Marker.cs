using System;

namespace FreeRoamProject.Client.Core.Utility.HUD
{
    // WE EXTEND SCALEFORMUI'S MARKER WITH THIS TO ADD SUPPORT TO POSITION CLASS
    public class MarkerEx : Marker
    {
        private float _height;
        public new Position Position { get; set; }
        public new bool IsInMarker { get; set; }

        public MarkerEx(MarkerType type, Position position, float distance, SColor color, bool placeOnGround = false, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
            : base(type, position.ToVector3, distance, color, placeOnGround, bobUpDown, rotate, faceCamera)
        {
            Position = position;
        }

        public MarkerEx(MarkerType type, Position position, Vector3 scale, float distance, SColor color, bool placeOnGround = false, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
            : base(type, position.ToVector3, scale, distance, color, placeOnGround, bobUpDown, rotate, faceCamera)
        {
            Position = position;
        }

        public MarkerEx(MarkerType type, Position position, SColor color, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
            : base(type, position.ToVector3, 50f, color, bobUpDown, rotate, faceCamera)
        {
            Position = position;
        }

        public MarkerEx(MarkerType type, Position position, Vector3 scale, SColor color, bool placeOnGround = false, bool bobUpDown = false, bool rotate = false, bool faceCamera = false)
            : base(type, position.ToVector3, scale, 50f, color, placeOnGround, bobUpDown, rotate, faceCamera)
        {
            Position = position;
        }


        public new void Draw()
        {
            if (IsInRange && PlaceOnGround && Position.Z != _height + 0.1f && API.GetGroundZFor_3dCoord(Position.X, Position.Y, Position.Z, ref _height, ignoreWater: false))
            {
                Position = new Position(Position.X, Position.Y, _height + 0.03f);
            }

            World.DrawMarker(MarkerType, Position.ToVector3, Direction, Rotation, Scale, Color.ToColor(), BobUpDown, FaceCamera, Rotate);
            if (CheckZ)
            {
                float num = Position.ToVector3.DistanceToSquared(PlayerCache.MyPlayer.Position.ToVector3);
                IsInMarker = (double)num < Math.Pow(Scale.X / 2f, 2.0) || (double)num < Math.Pow(Scale.Y / 2f, 2.0) || (double)num < Math.Pow(Scale.Z / 2f, 2.0);
            }
            else
            {
                float num2 = Position.ToVector3.DistanceToSquared2D(PlayerCache.MyPlayer.Position.ToVector3);
                IsInMarker = (double)num2 <= Math.Pow(Scale.X / 2f, 2.0) || (double)num2 <= Math.Pow(Scale.Y / 2f, 2.0);
            }
        }

    }
}