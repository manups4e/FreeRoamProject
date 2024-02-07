using FreeRoamProject.Client.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Core.Debug
{
    internal class DeveloperFunctions
    {
        private static readonly InputController noclip = new(Control.ReplayStartStopRecordingSecondary, PadCheck.Keyboard, action: new Action<Ped, object[]>(_NoClip));
        private static readonly InputController teleport = new(Control.SaveReplayClip, PadCheck.Keyboard, action: new Action<Ped, object[]>(Teleport));
        private static readonly InputController camera = new(Control.ReplayStartStopRecording, PadCheck.Keyboard, action: new Action<Ped, object[]>(Camera));
        private static Camera noClipCamera;
        private static Vector3 cameraPosition;
        private static float zoom = 75f;
        private static float Height = 0;
        public static void Init()
        {
            InputHandler.AddInput(noclip);
            InputHandler.AddInput(teleport);
            InputHandler.AddInput(camera);
        }

        private static void Teleport(Ped p, object[] args)
        {
            if (Cache.PlayerCache.MyClient.User != null && (int)Cache.PlayerCache.MyClient.User.group_level > 1) TeleportToMarker();
        }

        private static async void _NoClip(Ped p, object[] args)
        {
            if (Cache.PlayerCache.MyClient.User == null || (int)Cache.PlayerCache.MyClient.User.group_level < 4) return;

            if (!NoClip)
            {
                if (!Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle)
                {
                    RequestAnimDict(noclip_ANIM_A);
                    while (!HasAnimDictLoaded(noclip_ANIM_A)) await BaseScript.Delay(0);
                    curLocation = Cache.PlayerCache.MyClient.Position.ToVector3;
                    curRotation = p.Rotation;
                    curHeading = Cache.PlayerCache.MyClient.Position.Heading;
                    TaskPlayAnim(PlayerPedId(), noclip_ANIM_A, noclip_ANIM_B, 8.0f, 0.0f, -1, 9, 0, false, false, false);
                }
                else
                {
                    curLocation = p.CurrentVehicle.Position;
                    curRotation = p.CurrentVehicle.Rotation;
                    curHeading = p.CurrentVehicle.Heading;
                }

                p.Rotation = new Vector3(0);
                ClientMain.Instance.AddTick(noClip);
                NoClip = true;
                List<InstructionalButton> istr =
                [
                    new InstructionalButton(Control.FrontendLt, Control.Cover, "Up"),
                    new InstructionalButton(Control.FrontendRt, Control.HUDSpecial, "Down"),
                    new InstructionalButton(Control.MoveLeftRight, "Rotate L/R"),
                    new InstructionalButton(Control.MoveUpDown, "Move Fw/Bw"),
                    new InstructionalButton(Control.FrontendX, "Change speed")
                ];
                ScaleformUI.Main.InstructionalButtons.SetInstructionalButtons(istr);
            }
            else
            {
                ClientMain.Instance.RemoveTick(noClip);

                while (p.IsInvincible)
                {
                    p.IsInvincible = false;
                    await BaseScript.Delay(0);
                }

                if (!Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle)
                {
                    ClearPedTasksImmediately(PlayerPedId());
                    SetUserRadioControlEnabled(true);
                    p.IsInvincible = false;
                }
                else
                {
                    SetUserRadioControlEnabled(true);
                    p.IsInvincible = false;
                    Vehicle veh = p.CurrentVehicle;
                    veh.IsInvincible = false;
                }

                ClearAllHelpMessages();
                NoClip = false;
                ScaleformUI.Main.InstructionalButtons.ClearButtonList();
            }
        }
        public static bool NoClip = false;
        private static readonly string noclip_ANIM_A = "amb@world_human_stand_impatient@male@no_sign@base";
        private static readonly string noclip_ANIM_B = "base";
        private static int travelSpeed = 0;
        private static Vector3 curLocation;
        private static Vector3 curRotation;
        private static float curHeading;
        private static string travelSpeedStr = "Media";

        private static async Task noClip()
        {
            Ped p = Cache.PlayerCache.MyPed;
            Game.DisableAllControlsThisFrame(0);
            Game.EnableControlThisFrame(0, Control.LookLeftRight);
            Game.EnableControlThisFrame(0, Control.LookUpDown);
            Game.EnableControlThisFrame(0, Control.LookDown);
            Game.EnableControlThisFrame(0, Control.LookUp);
            Game.EnableControlThisFrame(0, Control.LookLeft);
            Game.EnableControlThisFrame(0, Control.LookRight);
            Game.EnableControlThisFrame(0, Control.LookDownOnly);
            Game.EnableControlThisFrame(0, Control.LookUpOnly);
            Game.EnableControlThisFrame(0, Control.LookLeftOnly);
            Game.EnableControlThisFrame(0, Control.LookRightOnly);
            Notifications.ShowHelpNotification("Speed: ~y~" + travelSpeedStr + "~w~.");
            const float rotationSpeed = 2.5f;
            float forwardPush = 0.8f;

            switch (travelSpeed)
            {
                case 0:
                    forwardPush = 0.8f; //medium
                    travelSpeedStr = "Everage";

                    break;
                case 1:
                    forwardPush = 1.8f; //fast
                    travelSpeedStr = "Fast";

                    break;
                case 2:
                    forwardPush = 3.6f; //very fast
                    travelSpeedStr = "Very fast";

                    break;
                case 3:
                    forwardPush = 5.4f; //extremely fast
                    travelSpeedStr = "Extremely fast";

                    break;
                case 4:
                    forwardPush = 0.025f; //very slow
                    travelSpeedStr = "Extremely slow";

                    break;
                case 5:
                    forwardPush = 0.05f; //very slow
                    travelSpeedStr = "Very slow";

                    break;
                case 6:
                    forwardPush = 0.2f; //slow
                    travelSpeedStr = "Slow";

                    break;
            }

            Vector2 vect = new(forwardPush * (float)Math.Sin(Functions.Deg2rad(curHeading)) * -1.0f, forwardPush * (float)Math.Cos(Functions.Deg2rad(curHeading)));
            Entity target = p;
            if (Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle) target = p.CurrentVehicle;
            p.Velocity = new Vector3(0);

            if (!Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle)
            {
                SetUserRadioControlEnabled(false);
                p.IsInvincible = true;
            }
            else
            {
                SetUserRadioControlEnabled(false);
                p.IsInvincible = true;
                Vehicle veh = p.CurrentVehicle;
                veh.IsInvincible = true;
            }

            if (Input.IsDisabledControlJustPressed(Control.FrontendX))
            {
                travelSpeed++;
                if (travelSpeed > 6) travelSpeed = 0;
            }

            if (Input.IsDisabledControlPressed(Control.Cover, PadCheck.Keyboard) || Input.IsDisabledControlPressed(Control.FrontendLt, PadCheck.Controller)) curLocation.Z += forwardPush / 2;
            if (Input.IsDisabledControlPressed(Control.HUDSpecial, PadCheck.Keyboard) || Input.IsDisabledControlPressed(Control.FrontendRt, PadCheck.Controller)) curLocation.Z -= forwardPush / 2;
            if (Input.IsDisabledControlPressed(Control.MoveUpOnly)) curLocation = target is Vehicle ? Vector3.Add(curLocation, new Vector3(vect, 0)) : Vector3.Subtract(curLocation, new Vector3(vect, 0));
            if (Input.IsDisabledControlPressed(Control.MoveDownOnly)) curLocation = target is Vehicle ? Vector3.Subtract(curLocation, new Vector3(vect, 0)) : Vector3.Add(curLocation, new Vector3(vect, 0));
            if (Input.IsDisabledControlPressed(Control.MoveLeftOnly)) curHeading += rotationSpeed;
            if (Input.IsControlPressed(Control.MoveRightOnly)) curHeading -= rotationSpeed;
            target.Position = curLocation;
            target.Heading = curHeading - rotationSpeed;
        }

        private static async void Camera(Ped p, object[] args)
        {
            if (Cache.PlayerCache.MyClient.User == null || (int)Cache.PlayerCache.MyClient.User.group_level < 4) return;

            if (!NoClip)
            {
                noClipCamera = World.CreateCamera(PlayerCache.MyPed.Bones[Bone.SKEL_Head].Position, PlayerCache.MyPed.Rotation, GameplayCamera.FieldOfView);
                curLocation = PlayerCache.MyClient.Position.ToVector3;
                cameraPosition = curLocation;
                curRotation = p.Rotation;
                curHeading = PlayerCache.MyClient.Position.Heading;
                zoom = GameplayCamera.FieldOfView;
                p.Rotation = new Vector3(0);
                ClientMain.Instance.AddTick(NoClipCamera);
                NoClip = true;
                List<InstructionalButton> istr =
                [
                    new InstructionalButton(Control.FrontendLt, "Up"),
                    new InstructionalButton(Control.FrontendRt, "Down"),
                    new InstructionalButton(Control.FrontendLb, "Zoom+"),
                    new InstructionalButton(Control.FrontendRb, "Zoom-"),
                    new InstructionalButton(Control.MoveLeftRight, "Rotate L/R"),
                    new InstructionalButton(Control.MoveUpDown, "Move Fw/Bw"),
                    new InstructionalButton(Control.FrontendX, "Change speed"),
                    new InstructionalButton(Control.NextCamera, "Save camera")
                ];
                ScaleformUI.Main.InstructionalButtons.SetInstructionalButtons(istr);
                RenderScriptCams(true, true, 2000, true, false);
            }
            else
            {
                ClientMain.Instance.RemoveTick(NoClipCamera);
                RenderScriptCams(false, true, 2000, true, false);
                noClipCamera = null;

                while (p.IsInvincible)
                {
                    p.IsInvincible = false;
                    await BaseScript.Delay(0);
                }

                if (!PlayerCache.MyClient.Status.PlayerStates.InVehicle)
                {
                    ClearPedTasksImmediately(PlayerPedId());
                    SetUserRadioControlEnabled(true);
                    p.IsInvincible = false;
                }
                else
                {
                    SetUserRadioControlEnabled(true);
                    p.IsInvincible = false;
                    Vehicle veh = p.CurrentVehicle;
                    veh.IsInvincible = false;
                }

                ClearAllHelpMessages();
                NoClip = false;
                ScaleformUI.Main.InstructionalButtons.ClearButtonList();
            }
        }

        static float forwardPush = 0.8f;

        private static async Task NoClipCamera()
        {
            Game.DisableAllControlsThisFrame(0);
            Game.DisableAllControlsThisFrame(1);
            Game.DisableAllControlsThisFrame(2);
            Notifications.ShowHelpNotification("Actual speed: ~y~" + travelSpeedStr + "~w~.");
            const float rotationSpeed = 2.5f;
            float fVar0 = GetDisabledControlNormal(2, 218) * forwardPush;
            float fVar1 = GetDisabledControlNormal(2, 219) * forwardPush;
            float fVar2 = GetDisabledControlNormal(2, 220);
            float fVar3 = GetDisabledControlNormal(2, 221);
            float ltNorm = GetDisabledControlNormal(2, 252);
            float rtNorm = GetDisabledControlNormal(2, 253);
            float zoomingWheel = 0f;
            if (!IsLookInverted())
            {
                fVar1 = -fVar1;
                fVar3 = -fVar3;
            }
            if (!IsInputDisabled(2))
            {
                N_0xc8b5c4a79cc18b94(noClipCamera.Handle);
            }
            else if (Input.IsDisabledControlPressed(Control.CreatorLT) || Input.IsDisabledControlPressed(Control.CreatorRT))
            {
                N_0xc8b5c4a79cc18b94(noClipCamera.Handle);
            }
            if (IsInputDisabled(2))
            {
                fVar2 = GetDisabledControlUnboundNormal(2, 1) * 2;
                fVar3 = GetDisabledControlUnboundNormal(2, 2) * -1 * 2;
                if (GetDisabledControlNormal(2, 241) > 0.25f)
                    zoomingWheel = 3f;
                if (GetDisabledControlNormal(2, 242) > 0.25f)
                    zoomingWheel = -3f;
            }

            float xVectFwd = -fVar1 * (float)Math.Sin(Functions.Deg2rad(curRotation.Z));
            float yVectFwd = fVar1 * (float)Math.Cos(Functions.Deg2rad(curRotation.Z));
            float xVectLat = fVar0 * (float)Math.Cos(Functions.Deg2rad(curRotation.Z));
            float yVectLat = fVar0 * (float)Math.Sin(Functions.Deg2rad(curRotation.Z));


            cameraPosition.X += xVectFwd + xVectLat;
            cameraPosition.Y += yVectFwd + yVectLat;
            curRotation = new(fVar3 + noClipCamera.Rotation.X, 0, -fVar2 + noClipCamera.Rotation.Z);

            curLocation = new((cameraPosition + zoom * noClipCamera.CamForwardVector()).X, (cameraPosition + zoom * noClipCamera.CamForwardVector()).Y, Height);

            if (ltNorm > 0 || rtNorm > 0 || zoomingWheel != 0)
            {
                zoom += rtNorm;
                zoom -= ltNorm;
                zoom += zoomingWheel;
                if (zoom >= 130f)
                    zoom = 130f;
                if (zoom <= 16f)
                    zoom = 16f;
                noClipCamera.FieldOfView = zoom;
            }

            if (IsDisabledControlPressed(2, func_7450()))
            {
                cameraPosition.Z += 1f * forwardPush;
                Height += 1f * forwardPush;
            }
            if (IsDisabledControlPressed(2, func_7449()))
            {
                cameraPosition.Z -= 1f * forwardPush;
                Height -= 1f * forwardPush;
            }


            switch (travelSpeed)
            {
                case 0:
                    forwardPush = 0.1f; //medium
                    travelSpeedStr = "Everage";

                    break;
                case 1:
                    forwardPush = 0.2f; //fast
                    travelSpeedStr = "Fast";

                    break;
                case 2:
                    forwardPush = 0.4f; //very fast
                    travelSpeedStr = "Very fast";

                    break;
                case 3:
                    forwardPush = 0.8f; //extremely fast
                    travelSpeedStr = "Extremely fast";

                    break;
                case 6:
                    forwardPush = 0.02f; //very slow
                    travelSpeedStr = "Extremely slow";

                    break;
                case 5:
                    forwardPush = 0.05f; //very slow
                    travelSpeedStr = "Very slow";

                    break;
                case 4:
                    forwardPush = 0.08f; //slow
                    travelSpeedStr = "Slow";

                    break;
            }

            if (Input.IsControlJustPressed(Control.FrontendX))
            {
                travelSpeed++;
                if (travelSpeed > 6) travelSpeed = 0;
            }

            if (Input.IsDisabledControlPressed(Control.FrontendLt)) zoom -= 1f;
            if (Input.IsDisabledControlPressed(Control.FrontendRt)) zoom += 1f;
            if (Input.IsControlJustPressed(Control.NextCamera)) ClientMain.Logger.Debug(noClipCamera.ToJson());


            float z = 0;
            GetGroundZFor_3dCoord(curLocation.X, curLocation.Y, Height + 300, ref z, false);
            if (Height <= z + 0.3f)
                Height = z + 0.3f;

            noClipCamera.Position = cameraPosition;
            noClipCamera.Rotation = curRotation;
            noClipCamera.FieldOfView = zoom;

            Notifications.DrawText(0.4f, 0.825f, $"~o~Position~w~: {cameraPosition}");
            Notifications.DrawText(0.4f, 0.85f, $"Rotation: {curRotation}");
            Notifications.DrawText(0.4f, 0.80f, $"Field of View = {zoom}");
        }

        private static int func_7449()
        {
            if (IsInputDisabled(2))
                return 251;
            return 206;
        }

        private static int func_7450()
        {
            if (IsInputDisabled(2))
                return 250;
            return 205;
        }

        private static async void TeleportToMarker()
        {
            Position coords = Cache.PlayerCache.MyClient.Position;
            bool blipFound = false;
            // search for marker blip
            int blipIterator = GetBlipInfoIdIterator();

            for (Blip i = new(GetFirstBlipInfoId(blipIterator)); i.Exists(); i = new Blip(GetNextBlipInfoId(blipIterator)))
                if (i.Type == 4)
                {
                    coords = i.Position.ToPosition();
                    blipFound = true;

                    break;
                }

            if (blipFound)
            {
                // get entity to teleport
                Entity ent = Cache.PlayerCache.MyPed;
                if (Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle) ent = Cache.PlayerCache.MyPed.CurrentVehicle;

                // load needed map region and check height levels for ground existence
                bool groundFound = false;
                float[] groundCheckHeight = [100.0f, 150.0f, 50.0f, 0.0f, 200.0f, 250.0f, 300.0f, 350.0f, 400.0f, 450.0f, 500.0f, 550.0f, 600.0f, 650.0f, 700.0f, 750.0f, 800.0f];
                float ground = 0;

                for (int i = 0; i < groundCheckHeight.Length; i++)
                {
                    ent.PositionNoOffset = new Vector3(coords.X, coords.Y, groundCheckHeight[i]);
                    await BaseScript.Delay(100);

                    if (GetGroundZFor_3dCoord(coords.X, coords.Y, groundCheckHeight[i], ref ground, false))
                    {
                        groundFound = true;
                        ground += 3.0f;

                        break;
                    }
                }

                // if ground not found then set Z in air and give player a parachute
                if (!groundFound)
                {
                    ground = 1000.0f;
                    GiveDelayedWeaponToPed(PlayerPedId(), 0xFBAB5776, 1, false);
                }

                //do it
                ent.PositionNoOffset = new Vector3(coords.X, coords.Y, ground);
                Notifications.ShowNotification("Teleported!", NotificationColor.Blue, true);
            }
            else
            {
                Notifications.ShowNotification("Map POI not found, add a POI on the map to teleport!", NotificationColor.Red, true);
            }
        }
    }
}
