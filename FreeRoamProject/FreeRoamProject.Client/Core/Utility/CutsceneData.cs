using FreeRoamProject.Client.FREEROAM.Properties;

namespace FreeRoamProject.Client.Core.Utility
{
    internal class CutsceneData
    {
        public int playerClone;
        public int[] objIDs = new int[2];
        public int[] cameras = new int[2];
        public SCRIPT_TIMER timer = new();

        public ENTRY_CS_STAGE iStage;
        public int iSyncedSceneID = -1;
        public int iBS;

        public string animDictionary;
        public string[] animName = new string[3];

        public Vector3[] vCamLoc = [new(), new()];
        public Vector3[] vCamRot = [new(), new()];
        public float[] fCamFOV = new float[2];

        public Vector3 vSyncSceneLoc;
        public Vector3 vSyncSceneRot;

        public float fSyncedSceneCompleteStage;
        public int iSoundID;

    }

    public class SCRIPT_TIMER
    {
        public int Timer { get; set; }
        public bool bInitialisedTimer { get; set; }
    }
}
