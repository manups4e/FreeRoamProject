namespace FreeRoamProject.Shared.Core.Doors
{
    public enum DoorStateEnum
    {
        DOORSTATE_INVALID = -1,
        DOORSTATE_UNLOCKED,
        DOORSTATE_LOCKED,
        DOORSTATE_FORCE_LOCKED_UNTIL_OUT_OF_AREA,
        DOORSTATE_FORCE_UNLOCKED_THIS_FRAME,
        DOORSTATE_FORCE_LOCKED_THIS_FRAME,
        DOORSTATE_FORCE_OPEN_THIS_FRAME,
        DOORSTATE_FORCE_CLOSED_THIS_FRAME
    }
    public class MpDoorDetails
    {
        public int iDoorHash { get; set; }
        public int iGameMode { get; set; }
        public uint doorModel { get; set; }
        public Vector3 vCoords { get; set; }
        public bool bJustAdd { get; set; }
        public bool bUseStateSystem { get; set; }
        public DoorStateEnum theDoorDefaultState { get; set; } //only used if using state system
        public bool bHoldOpen { get; set; }
        public bool bRaceDoor { get; set; }
        public bool bPermanentState { get; set; }
        public float fRatio { get; set; }
        public float fAutoOpenRange { get; set; }
        public float fAutoOpenRate { get; set; }
    }
}
