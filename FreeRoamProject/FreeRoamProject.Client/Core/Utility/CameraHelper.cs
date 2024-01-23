namespace FreeRoamProject.Client.Core.Utility
{
    internal class CameraHelper
    {
        public static bool ExecutePan(ref SceneTool_Pan pan, ref int hCam0, ref int hCam1)
        {
            if (DoesCamExist(hCam0))
                DestroyCam(hCam0, false);
            if (DoesCamExist(hCam1))
                DestroyCam(hCam1, false);
            hCam0 = CreateCam("DEFAULT_SCRIPTED_CAMERA", false);
            hCam1 = CreateCam("DEFAULT_SCRIPTED_CAMERA", false);
            if (DoesCamExist(hCam0) && DoesCamExist(hCam1))
            {
                SetCamCoord(hCam0, pan.mStart.Pos.X, pan.mStart.Pos.Y, pan.mStart.Pos.Z);
                SetCamRot(hCam0, pan.mStart.Pos.Pitch, pan.mStart.Pos.Roll, pan.mStart.Pos.Yaw, 2);
                SetCamFov(hCam0, pan.fFov);

                SetCamCoord(hCam1, pan.mEnd.Pos.X, pan.mEnd.Pos.Y, pan.mEnd.Pos.Z);
                SetCamRot(hCam1, pan.mEnd.Pos.Pitch, pan.mEnd.Pos.Roll, pan.mEnd.Pos.Yaw, 2);
                SetCamFov(hCam1, pan.fFov);

                ShakeCam(hCam0, "HAND_SHAKE", pan.fShake);
                ShakeCam(hCam1, "HAND_SHAKE", pan.fShake);

                if (pan.fDuration > 0.1f)
                    SetCamActiveWithInterp(hCam1, hCam0, Round(pan.fDuration * 1000), 1, 1);
                else
                    SetCamActive(hCam0, true);
                RenderScriptCams(true, false, 3000, false, false);
                return true;
            }
            return false;
        }

        public static bool ExecuteCut(SceneTool_Cut cut, ref int hCam0)
        {
            if (DoesCamExist(hCam0))
                DestroyCam(hCam0, false);
            hCam0 = CreateCam("DEFAULT_SCRIPTED_CAMERA", false);
            if (DoesCamExist(hCam0))
            {
                SetCamCoord(hCam0, cut.mCam.Pos.X, cut.mCam.Pos.Y, cut.mCam.Pos.Z);
                SetCamRot(hCam0, cut.mCam.Pos.Pitch, cut.mCam.Pos.Roll, cut.mCam.Pos.Yaw, 2);
                SetCamFov(hCam0, cut.fFov);

                ShakeCam(hCam0, "HAND_SHAKE", cut.fShake);

                SetCamActive(hCam0, true);
                RenderScriptCams(true, false, 3000, false, false);
                return true;
            }
            return false;
        }
    }


    public class SceneTool_Cam
    {
        public Position Pos { get; set; }
    }

    public class SceneTool_Pan
    {
        public SceneTool_Cam mStart = new();
        public SceneTool_Cam mEnd = new();
        public float fFov { get; set; }
        public float fShake { get; set; }
        public float fDuration { get; set; }
    }

    public class SceneTool_Cut
    {
        public SceneTool_Cam mCam = new();
        public float fFov { get; set; }
        public float fShake { get; set; }
    }

    public class SceneTool_Marker
    {
        public Vector3 Pos { get; set; }
    }

    public class SceneTool_Placer
    {
        public Vector3 Pos { get; set; }
        public float fRot { get; set; }
    }
    public class SceneTool_AngArea
    {
        public Vector3 Pos0 { get; set; }
        public Vector3 Pos1 { get; set; }
        public float fWidth { get; set; }
        public float fHeight { get; set; }
    }
    public class SceneTool_Point
    {
        public Position Pos { get; set; }
    }
}
