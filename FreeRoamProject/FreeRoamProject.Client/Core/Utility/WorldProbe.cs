using FreeRoamProject.Client.Handlers;
using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Core.Utility
{
    internal static class WorldProbe
    {
        public static RaycastResult CrossairRaycastResult;
        public static RaycastResult CrossairRenderingRaycastResult;

        static WorldProbe()
        {
            ClientMain.Instance.AddTick(new Func<Task>(async () =>
            {
                CrossairRaycastResult = await GamePlayCamCrosshairRaycast();
                CrossairRenderingRaycastResult = await CrosshairRaycast();
                await Task.FromResult(0);
            }));
        }

        public static Vector3 GetGamePlayCameraForwardVector()
        {
            Vector3 rot = GameplayCamera.Rotation;
            double rotX = rot.X / 57.295779513082320876798154814105;
            double rotZ = rot.Z / 57.295779513082320876798154814105;
            double multXY = Math.Abs(Math.Cos(rotX));
            return new Vector3((float)(-Math.Sin(rotZ) * multXY), (float)(Math.Cos(rotZ) * multXY), (float)System.Math.Sin(rotX));
        }

        public static Vehicle GetVehicleInFrontOfPlayer(float distance = 5f)
        {
            try
            {
                Entity source = Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVehicle ? VehicleChecker.CurrentVehicle : Cache.PlayerCache.MyPlayer.Ped;

                return GetVehicleInFrontOfPlayer(source, source, distance);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"[WorldProbe] GetVehicleInFrontOfPlayer Error: {ex.Message}");
            }

            return default;
        }

        public static Vehicle GetVehicleInFrontOfPlayer(Entity source, Entity ignore, float distance = 5f)
        {
            try
            {
                RaycastResult raycast = World.Raycast(source.Position + new Vector3(0f, 0f, -0.4f), source.GetOffsetPosition(new Vector3(0f, distance, 0f)) + new Vector3(0f, 0f, -0.4f), (IntersectOptions)71, ignore);

                if (raycast.DitHitEntity && raycast.HitEntity.Model.IsVehicle) return (Vehicle)raycast.HitEntity;
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"[WorldProbe] GetVehicleInFrontOfPlayer Error: {ex.Message}");
            }

            return default;
        }

        public static Vector3 CalculateClosestPointOnLine(Vector3 start, Vector3 end, Vector3 point)
        {
            try
            {
                float dotProduct = Vector3.Dot(start - end, point - start);
                float percent = dotProduct / (start - end).LengthSquared();

                if (percent < 0.0f)
                    return start;
                if (percent > 1.0f) return end;

                return start + percent * (end - start);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe CalculateClosestPointOnLine Error: {ex.Message}");
            }

            return default;
        }

        public static Vector3 GameplayCamForwardVector()
        {
            try
            {
                Vector3 rotation = (float)(Math.PI / 180.0) * GameplayCamera.Rotation;

                return Vector3.Normalize(new Vector3((float)-Math.Sin(rotation.Z) * (float)Math.Abs(Math.Cos(rotation.X)), (float)Math.Cos(rotation.Z) * (float)Math.Abs(Math.Cos(rotation.X)), (float)Math.Sin(rotation.X)));
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe GameplayCamForwardVector Error: {ex.Message}");
            }

            return default;
        }

        public static Vector3 CamForwardVector(this Camera cam)
        {
            try
            {
                Vector3 rotation = (float)(Math.PI / 180.0) * cam.Rotation;

                return Vector3.Normalize(new Vector3((float)-Math.Sin(rotation.Z) * (float)Math.Abs(Math.Cos(rotation.X)), (float)Math.Cos(rotation.Z) * (float)Math.Abs(Math.Cos(rotation.X)), (float)Math.Sin(rotation.X)));
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe GameplayCamForwardVector Error: {ex.Message}");
            }

            return default;
        }

        public static async Task<RaycastResult> GamePlayCamCrosshairRaycast(float distance = 1000, Entity ignoredEntity = null)
        {
            try
            {
                Vector3 position = GameplayCamera.Position;
                Vector3 direction = distance * GameplayCamForwardVector();

                return await Raycast(position, direction, distance, IntersectOptions.Everything, ignoredEntity);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe _CrosshairRaycast Error: {ex.Message}");
            }

            return default;
        }

        public static async Task<RaycastResult> CrosshairRaycast(this Camera cam, float distance = 1000, Entity ignoredEntity = null)
        {
            try
            {
                Vector3 position = cam.Position;
                Vector3 direction = position + distance * cam.CamForwardVector();

                return await Raycast(position, direction, distance, IntersectOptions.Everything, ignoredEntity);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe _CrosshairRaycast Error: {ex.Message}");
            }

            return default;
        }

        public static async Task<RaycastResult> CrosshairRaycast(this Camera cam, IntersectOptions options = IntersectOptions.Everything, float distance = 1000, Entity ignoredEntity = null)
        {
            try
            {
                Vector3 position = cam.Position;
                Vector3 direction = position + distance * cam.CamForwardVector();

                return await Raycast(position, direction, distance, options, ignoredEntity);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe _CrosshairRaycast Error: {ex.Message}");
            }

            return default;
        }

        public static async Task<RaycastResult> CrosshairRaycast(IntersectOptions options = IntersectOptions.Everything, float distance = 1000, Entity ignoredEntity = null)
        {
            try
            {
                Camera cam = new(GetRenderingCam());
                Vector3 position = cam.Position;
                Vector3 direction = position + distance * cam.CamForwardVector();

                return await Raycast(position, direction, distance, options, ignoredEntity);
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe _CrosshairRaycast Error: {ex.Message}");
            }

            return default;
        }

        public static async Task<Entity> GetEntityInFrontOfPed(this Ped ped, float maxDistance = 5.0f)
        {
            try
            {
                RaycastResult raycast = await Raycast(ped.Position, ped.ForwardVector * maxDistance, IntersectOptions.Everything);

                if (raycast.DitHitEntity) return raycast.HitEntity;
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"{ex.Message}");
            }

            return null;
        }

        public static async Task<Entity> GetEntityInFrontOfPlayer(this Player player, float distance = 5f)
        {
            try
            {
                RaycastResult raycast = await Raycast(player.Character.Position, player.Character.ForwardVector * distance, IntersectOptions.Everything);

                if (raycast.DitHitEntity) return raycast.HitEntity;
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"{ex.Message}");
            }

            return null;
        }

        public static async Task<RaycastResult> Raycast(Vector3 source, Vector3 target, IntersectOptions options, Entity ignoredEntity = null)
        {
            int RayShape = StartShapeTestLosProbe(source.X, source.Y, source.Z, target.X, target.Y, target.Z, (int)options, ignoredEntity == null ? 0 : ignoredEntity.Handle, 7);
            RaycastResult result = new(0);

            while (result.Result != 2)
            {
                await BaseScript.Delay(0);
                result = new(RayShape);
            }
            return result;
        }

        public static async Task<RaycastResult> Raycast(Vector3 source, Vector3 direction, float maxDistance, IntersectOptions options, Entity ignoredEntity = null)
        {
            Vector3 target = source + direction * maxDistance;
            int RayShape = StartShapeTestLosProbe(source.X, source.Y, source.Z, target.X, target.Y, target.Z, (int)options, ignoredEntity == null ? 0 : ignoredEntity.Handle, 7);
            RaycastResult result = new(0);

            while (result.Result != 2)
            {
                await BaseScript.Delay(0);
                result = new(RayShape);
            }
            return result;
        }

        public static RaycastResult SynchronousCrosshairRaycast(this Camera cam, IntersectOptions options = IntersectOptions.Everything, float distance = 1000, Entity ignoredEntity = null)
        {
            Vector3 position = cam.Position;
            Vector3 direction = position + distance * cam.CamForwardVector();
            return new(StartExpensiveSynchronousShapeTestLosProbe(position.X, position.Y, position.Z, direction.X, direction.Y, direction.Z, (int)options, ignoredEntity == null ? 0 : ignoredEntity.Handle, 0));
        }
    }
}