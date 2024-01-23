namespace FreeRoamProject.Client.FREEROAM.Properties
{
    public class MPRealityWarpIn
    {
        public PropEnterStage iStage { get; set; }
        public int iVehicleSlot { get; set; }
        public int iOldVehicleSlot { get; set; }//used for cars moving between garages
        public int vehID { get; set; }
        public FE_WARNING_FLAGS iWarningScreenButtonBS { get; set; }
        public int iButtonBS { get; set; }
        public int iBS { get; set; }
        public int iMenuType { get; set; }
        public int iEntryBS { get; set; }
        public int iInstance { get; set; }
        public int iPropertySlot { get; set; }
        public int propertyOwner { get; set; }
        public int propertyOwnerHandle { get; set; }
        public SCRIPT_TIMER vehicleWarpTimer { get; set; }//used to combat issue of garage sessioning not working correctly.
    }
}