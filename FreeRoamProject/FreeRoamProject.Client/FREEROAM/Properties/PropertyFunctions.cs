using FreeRoamProject.Client.FREEROAM.Properties.Loader;
using FreeRoamProject.Shared.Core.ApartmentsShared;
using FreeRoamProject.Shared.Core.ApartmentsShared.Enums;
using FreeRoamProject.Shared.Core.Doors;
using FreeRoamProject.Shared.Properties.Enums;
namespace FreeRoamProject.Client.FREEROAM.Properties
{
    public class MPCamOffset
    {
        public Vector3 vLoc { get; set; }
        public Vector3 vRot { get; set; }
        public int iFov { get; set; }
    }
    internal class PropertyFunctions
    {
        public static bool GetBuildingDoorDetails(ref Position LocationData, ref MpDoorDetails PropertyDoors, ref bool bGarageDoor, BuildingsEnum iBuildingID, int iDoorId)
        {
            string doorName = $"PROP_BUILDING_{(int)iBuildingID}_DOOR_{iDoorId}";
            bGarageDoor = false;
            switch (iBuildingID)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_PROP_SS1_MPINT_DOOR_L");
                            PropertyDoors.vCoords = new(-778.3578f, 313.5395f, 86.1433f);
                            LocationData = new(-778.3578f, 313.5395f, 86.1433f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_PROP_SS1_MPINT_DOOR_R");
                            PropertyDoors.vCoords = new(-776.1967f, 313.5395f, 86.1433f);
                            LocationData = new(-776.1967f, 313.5395f, 86.1433f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_prop_ss1_mpint_garage2");
                            PropertyDoors.vCoords = new(-796.0818f, 313.7807f, 86.6735f);
                            LocationData = new(-796.0818f, 313.7807f, 86.6735f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("hei_prop_dt1_20_mph_door_l");
                            PropertyDoors.vCoords = new(263.46f, -970.52f, 31.6f);
                            LocationData = new(-263.46f, -970.52f, 31.61f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_PROP_DT1_20_MPH_DOOR_R");
                            PropertyDoors.vCoords = new(260.66f, -969.21f, 31.6f);
                            LocationData = new(-260.66f, -969.21f, 31.61f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("hei_prop_dt1_20_mp_gar2");
                            PropertyDoors.vCoords = new(282.55f, -995.16f, 24.6f);
                            LocationData = new(-282.55f, -995.16f, 24.67f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_PROP_SM_14_MPH_DOOR_L");
                            PropertyDoors.vCoords = new(1444.28f, -545.01f, 34.9f);
                            LocationData = new(-1444.28f, -545.01f, 34.98f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_PROP_SM_14_MPH_DOOR_R");
                            PropertyDoors.vCoords = new(1442.30f, -543.63f, 34.9f);
                            LocationData = new(-1442.30f, -543.63f, 34.98f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("hei_PROP_SM_14_MP_GAR2");
                            PropertyDoors.vCoords = new(1455.81f, -503.98f, 32.2f);
                            LocationData = new(-1455.81f, -503.98f, 32.29f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_prop_bh1_09_mph_l");
                            PropertyDoors.vCoords = new(914.06f, -453.65f, 39.8f);
                            LocationData = new(-914.06f, -453.65f, 39.81f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_prop_bh1_09_mph_r");
                            PropertyDoors.vCoords = new(912.91f, -455.89f, 39.8f);
                            LocationData = new(-912.91f, -455.89f, 39.81f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_Prop_BH1_09_MP_Gar2");
                            PropertyDoors.vCoords = new(820.57f, -436.81f, 37.4f);
                            LocationData = new(-820.57f, -436.81f, 37.44f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_DT1_03_MPH_DOOR_01");
                            PropertyDoors.vCoords = new(47.84f, -588.77f, 38.3f);
                            LocationData = new(-47.84f, -588.77f, 38.36f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_Prop_Com_MP_Gar2");
                            PropertyDoors.vCoords = new(33.79f, -621.62f, 36.1f);
                            LocationData = new(-33.79f, -621.62f, 36.11f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("hei_prop_bh1_08_hdoor");
                            PropertyDoors.vCoords = new(933.0500f, -382.2390f, 39.151f);
                            LocationData = new(-933.0500f, -382.2390f, 39.1510f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("hei_prop_bh1_08_hdoor");
                            PropertyDoors.vCoords = new(933.500f, -382.2390f, 39.151f);
                            LocationData = new(-933.0500f, -382.2390f, 39.1510f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_prop_bh1_08_mp_gar2");
                            PropertyDoors.vCoords = new(878.02f, -359.46f, 36.2f);
                            LocationData = new(-878.02f, -359.46f, 36.27f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_prop_ss1_mpint_door_l");
                            PropertyDoors.vCoords = new(615.80f, 38.37f, 44.0f);
                            LocationData = new(-615.80f, 38.37f, 44.04f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_prop_ss1_mpint_door_r");
                            PropertyDoors.vCoords = new(613.64f, 38.37f, 44.0f);
                            LocationData = new(-613.64f, 38.37f, 44.04f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_prop_SS1_MPINT_GARAGE2");
                            PropertyDoors.vCoords = new(629.91f, 56.57f, 44.7f);
                            LocationData = new(-629.91f, 56.57f, 44.72f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_bh1_44_door_01l");
                            PropertyDoors.vCoords = new(86.91f, -159.22f, 64.8f);
                            LocationData = new(286.91f, -159.22f, 64.84f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_bh1_44_door_01r");
                            PropertyDoors.vCoords = new(85.94f, -161.88f, 64.8f);
                            LocationData = new(285.94f, -161.88f, 64.84f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_bh1_44_door_01r");
                            PropertyDoors.vCoords = new(.40f, 37.32f, 71.7f);
                            LocationData = new(4.40f, 37.32f, 71.75f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_bh1_44_door_01r");
                            PropertyDoors.vCoords = new(.74f, 81.31f, 78.6f);
                            LocationData = new(8.74f, 81.31f, 78.65f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm1_11_doorl");
                            PropertyDoors.vCoords = new(510.42f, 108.00f, 64.0f);
                            LocationData = new(-510.42f, 108.00f, 64.02f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm1_11_doorr");
                            PropertyDoors.vCoords = new(512.84f, 107.66f, 64.0f);
                            LocationData = new(-512.84f, 107.66f, 64.02f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_ss1_05_mp_door");
                            PropertyDoors.vCoords = new(197.23f, 85.16f, 69.9f);
                            LocationData = new(-197.23f, 85.16f, 69.90f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_ss1_08_mp_door_l");
                            PropertyDoors.vCoords = new(627.34f, 170.87f, 61.2f);
                            LocationData = new(-627.34f, 170.87f, 61.29f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_ss1_08_mp_door_r");
                            PropertyDoors.vCoords = new(627.34f, 168.53f, 61.2f);
                            LocationData = new(-627.34f, 168.53f, 61.29f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("vb_43_door_l_mp");
                            PropertyDoors.vCoords = new(969.36f, -1429.98f, 7.9f);
                            LocationData = new(-969.36f, -1429.98f, 7.97f, 0f, 0f, -70f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("vb_43_door_r_mp");
                            PropertyDoors.vCoords = new(968.60f, -1432.04f, 6.7f);
                            LocationData = new(-968.60f, -1432.04f, 6.77f, 0f, 0f, -70f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_10_mpdoor_r");
                            PropertyDoors.vCoords = new(830.05f, -862.99f, 21.0f);
                            LocationData = new(-830.05f, -862.99f, 21.09f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_10_mpdoor_l");
                            PropertyDoors.vCoords = new(832.81f, -862.99f, 21.0f);
                            LocationData = new(-832.81f, -862.99f, 21.09f, 0f, 0f, 125f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_06_door_l");
                            PropertyDoors.vCoords = new(763.90f, -755.08f, 28.1f);
                            LocationData = new(-763.90f, -755.08f, 28.19f, 0f, 0f, -270f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_06_door_r");
                            PropertyDoors.vCoords = new(763.90f, -752.49f, 28.1f);
                            LocationData = new(-763.90f, -752.49f, 28.19f, 0f, 0f, -270f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("p_cut_door_01");
                            PropertyDoors.vCoords = new(40.19f, -58.21f, 64.2f);
                            LocationData = new(-40.19f, -58.21f, 64.21f, 0f, 0f, -107f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("p_cut_door_03");
                            PropertyDoors.vCoords = new(200.29f, 185.5980f, 80.661f);
                            LocationData = new(-200.29f, 185.5980f, 80.6614f, 0f, 0f, -90f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_10_mpdoor_l");
                            PropertyDoors.vCoords = new(812.83f, -979.01f, 14.6f);
                            LocationData = new(-812.83f, -979.01f, 14.60f, 0f, 0f, 124.88f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_kt1_10_mpdoor_r");
                            PropertyDoors.vCoords = new(811.25f, -981.27f, 14.6f);
                            LocationData = new(-811.25f, -981.27f, 14.61f, 0f, 0f, 124.88f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("kt1_11_mp_door");
                            PropertyDoors.vCoords = new(661.87f, -854.63f, 24.6f);
                            LocationData = new(-661.87f, -854.63f, 24.69f, 0f, 0f, -180f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm_10_mp_door");
                            PropertyDoors.vCoords = new(1533.554f, -327.6279f, 48.079f);
                            LocationData = new(-1533.554f, -327.6279f, 48.0796f, 0f, 0f, 45f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm1_11_doorr");
                            PropertyDoors.vCoords = new(1565.58f, -406.92f, 42.6f);
                            LocationData = new(-1565.58f, -406.92f, 42.61f, 0f, 0f, 50f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm1_11_doorl");
                            PropertyDoors.vCoords = new(1564.01f, -405.04f, 42.6f);
                            LocationData = new(-1564.01f, -405.04f, 42.61f, 0f, 0f, 50f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("PROP_SM1_11_DOORR");
                            PropertyDoors.vCoords = new(1605.0138f, -431.9617f, 40.638f);
                            LocationData = new(-1605.0138f, -431.9617f, 40.6384f, 0f, 0f, -130f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("PROP_SM1_11_DOORL");
                            PropertyDoors.vCoords = new(1606.5881f, -433.8380f, 40.638f);
                            LocationData = new(-1606.5881f, -433.8380f, 40.6384f, 0f, 0f, -130f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 2:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("prop_sm1_11_garaged");
                            PropertyDoors.vCoords = new(1605.26f, -447.18f, 38.5f);
                            LocationData = new(-1605.26f, -447.18f, 38.58f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            bGarageDoor = true;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("HEI_Prop_sync_door_06");
                            PropertyDoors.vCoords = new(1605.0138f, -431.9617f, 40.638f);
                            LocationData = new(-1605.0138f, -431.9617f, 40.6384f, 0f, 0f, 0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_04");
                            PropertyDoors.vCoords = new(174.2531f, 503.1949f, 137.522f);
                            LocationData = new(-174.2531f, 503.1949f, 137.5228f, 0f, 0f, -79.20f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_01");
                            PropertyDoors.vCoords = new(45.5790f, 440.7786f, 148.253f);
                            LocationData = new(345.5790f, 440.7786f, 148.2533f, 0.0000f, 0.0000f, -62.95f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_05l");
                            PropertyDoors.vCoords = new(754.1140f, 621.1347f, 143.239f);
                            LocationData = new(-754.1140f, 621.1347f, 143.2394f, 0f, 0f, -71.5f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_05r");
                            PropertyDoors.vCoords = new(753.5129f, 619.3302f, 143.2f);
                            LocationData = new(-753.5129f, 619.3302f, 143.23f, 0f, 0f, -71.5f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_01");
                            PropertyDoors.vCoords = new(686.0629f, 595.3705f, 144.204f);
                            LocationData = new(-686.0629f, 595.3705f, 144.2043f, 0.0000f, 0.0000f, 40.76f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_02");
                            PropertyDoors.vCoords = new(20.0174f, 563.6835f, 184.149f);
                            LocationData = new(120.0174f, 563.6835f, 184.1492f, 0f, 0f, 7f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_03");
                            PropertyDoors.vCoords = new(559.1312f, 663.2863f, 145.6409f);
                            LocationData = new(-559.1312f, 663.2863f, 145.6409f, 0.0000f, -0.0000f, 164.3200f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_02");
                            PropertyDoors.vCoords = new(733.8267f, 593.6790f, 142.6572f);
                            LocationData = new(-733.8267f, 593.6790f, 142.6572f, 0f, 0f, 152f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_02");
                            PropertyDoors.vCoords = new(-853.550f, 694.739f, 149.2f);
                            LocationData = new(-853.550f, 694.739f, 149.2f, 0.0000f, -0.0000f, 184.0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_03");
                            PropertyDoors.vCoords = new(1294.8663f, 453.9819f, 97.805f);
                            LocationData = new(-1294.8663f, 453.9819f, 97.8050f, 0f, 0f, 0.37f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("apa_p_mp_door_04");
                            PropertyDoors.vCoords = new(74.6819f, 428.2515f, 145.785f);
                            LocationData = new(374.6819f, 428.2515f, 145.7855f, 0.0000f, -0.0000f, -103.29f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_prop_door_lowbank_ent_r");
                            PropertyDoors.vCoords = new(1370.6086f, -501.8980f, 33.613f);
                            LocationData = new(-1370.6086f, -501.8980f, 33.6133f, 0.0000f, 0.0000f, -54.76f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_prop_door_lowbank_roof");
                            PropertyDoors.vCoords = new(1560.996f, -570.000f, 113.14f);
                            LocationData = new(-1560.996f, -570.000f, 113.149f, 0.0000f, 0.0000f, 36.0f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_Prop_Door_Maze2_ent_r");
                            PropertyDoors.vCoords = new(1370.6086f, -501.8980f, 33.613f);
                            LocationData = new(-1370.6086f, -501.8980f, 33.6133f, 0.0000f, 0.0000f, -54.76f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_prop_door_maze2_rf_l");
                            PropertyDoors.vCoords = new(1370.2104f, -471.8008f, 84.900f);
                            LocationData = new(-1370.2104f, -471.8008f, 84.9007f, 0.0000f, -0.0000f, 124.00f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_Prop_Door_arcad_Ent_L");
                            PropertyDoors.vCoords = new(-117.950f, -604.900f, 35.304f);
                            LocationData = new(-117.950f, -604.900f, 35.304f, 0.000f, -0.000f, -109.500f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_Prop_Door_Arcad_Roof_R");
                            PropertyDoors.vCoords = new(-135.279f, -584.869f, 201.746f);
                            LocationData = new(-135.279f, -584.869f, 201.746f, 0.000f, 0.000f, -50.250f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    switch (iDoorId)
                    {
                        case 0:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_Prop_Door_Maze2_Ent_R");
                            PropertyDoors.vCoords = new(71.4163f, -839.6919f, 41.030f);
                            LocationData = new(-71.4163f, -839.6919f, 41.0300f, 0.0000f, -0.0000f, -5.2000f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                        case 1:
                            PropertyDoors.iDoorHash = Functions.HashInt(doorName);
                            PropertyDoors.doorModel = Functions.HashUint("ex_Prop_Door_Maze2_Roof");
                            PropertyDoors.vCoords = new(68.5001f, -822.6728f, 321.505f);
                            LocationData = new(-68.5001f, -822.6728f, 321.5059f, 0.0000f, -0.0000f, 70.5600f);
                            PropertyDoors.bUseStateSystem = true;
                            PropertyDoors.theDoorDefaultState = DoorStateEnum.DOORSTATE_LOCKED;
                            return true;
                    }
                    break;
            }
            return false;
        }
        public static void SetupMpDoors(MpDoorDetails doorDetails, bool bNetwork = false)
        {
            if (doorDetails.iDoorHash != 0)
            {
                AddDoorToSystem((uint)doorDetails.iDoorHash, doorDetails.doorModel, doorDetails.vCoords.X, doorDetails.vCoords.Y, doorDetails.vCoords.Z, false, bNetwork, doorDetails.bPermanentState);
                if (doorDetails.bHoldOpen)
                    DoorSystemSetHoldOpen((uint)doorDetails.iDoorHash, true);
                if (doorDetails.fRatio != 0)
                    DoorSystemSetOpenRatio((uint)doorDetails.iDoorHash, doorDetails.fRatio, false, bNetwork);
                if (!doorDetails.bJustAdd && doorDetails.bUseStateSystem)
                    DoorSystemSetDoorState((uint)doorDetails.iDoorHash, (int)doorDetails.theDoorDefaultState, bNetwork, false);
                if (doorDetails.bRaceDoor)
                    Function.Call((Hash)0xA85A21582451E951, doorDetails.iDoorHash, true);
                if (doorDetails.fAutoOpenRate != 0)
                    DoorSystemSetAutomaticRate((uint)doorDetails.iDoorHash, doorDetails.fAutoOpenRate, bNetwork, false);
                if (doorDetails.fAutoOpenRange != 0)
                    DoorSystemSetAutomaticDistance((uint)doorDetails.iDoorHash, doorDetails.fAutoOpenRange, bNetwork, false);
            }
        }
        public static Vector3 GetOfficeGarageExternalDoorPosition()
        {
            return PropertiesExteriorsManager.Properties[(int)PropertiesExteriorsManager.CurrentPropertyID].BuildingID switch
            {
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1 => new Vector3(-1550.147f, -559.428f, 24.755f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2 => new Vector3(-1414.345f, -477.138f, 32.413f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4 => new Vector3(-79.488f, -786.100f, 37.338f),
                _ => Vector3.Zero,
            };
        }
        public static Vector3 GetOfficeGarageExternalDoorRotation()
        {
            return PropertiesExteriorsManager.Properties[(int)PropertiesExteriorsManager.CurrentPropertyID].BuildingID switch
            {
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1 => new Vector3(0.0f, 0.0f, 34.0f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2 => new Vector3(0.0f, 0.0f, -56.5f),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4 => new Vector3(0.0f, 0.0f, 14.750f),
                _ => Vector3.Zero,
            };
        }
        public static uint GetOfficeGarageExternalDoorModel()
        {
            return PropertiesExteriorsManager.Properties[(int)PropertiesExteriorsManager.CurrentPropertyID].BuildingID switch
            {
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1 => Functions.HashUint("imp_Prop_ImpEx_Gate_sm_13"),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2 => Functions.HashUint("imp_Prop_ImpEx_Gate_sm_15"),
                BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4 => Functions.HashUint("imp_Prop_ImpEx_Gate_01"),
                _ => Functions.HashUint("DUMMY_MODEL_FOR_SCRIPT")
            };
        }
        public static void GetTransitionBuzzCamDetails(BuildingsEnum iBuilding, ref MPCamOffset mpOffset, int iEntrance)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-779.8222f, 312.4101f, 86.2709f);
                            mpOffset.vRot = new(-9.3334f, 0.0000f, -44.5438f);
                            mpOffset.iFov = 35;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-789.4091f, 307.7998f, 86.2120f);
                            mpOffset.vRot = new(-4.8871f, 0.0000f, 35.8326f);
                            mpOffset.iFov = 46;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-260.6f, -969.8f, 31.8f);
                            mpOffset.vRot = new(-5.1f, 0.0f, -13.8f);
                            mpOffset.iFov = 58;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-279.9714f, -992.7164f, 25.0111f);
                            mpOffset.vRot = new(-8.5828f, -0.0000f, 30.3828f);
                            mpOffset.iFov = 51;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1442.4f, -544.4f, 35.4f);
                            mpOffset.vRot = new(-7.6f, 0.0f, -35.2f);
                            mpOffset.iFov = 30;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1454.5521f, -500.1300f, 32.6765f);
                            mpOffset.vRot = new(-8.7803f, -0.0000f, -93.2592f);
                            mpOffset.iFov = 49;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-913.5f, -455.6f, 40.3f);
                            mpOffset.vRot = new(-6.9f, -0.0f, -134.8f);
                            mpOffset.iFov = 37;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-820.4738f, -441.0721f, 37.3119f);
                            mpOffset.vRot = new(-7.2462f, 0.0000f, -99.9315f);
                            mpOffset.iFov = 48;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-49.6f, -589.7f, 38.4f);
                            mpOffset.vRot = new(0.5f, 0.0f, -128.2f);
                            mpOffset.iFov = 36;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-31.9128f, -618.3400f, 35.3104f);
                            mpOffset.vRot = new(-5.0098f, -0.0000f, 113.7626f);
                            mpOffset.iFov = 57;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-934.4f, -380.9f, 39.7f);
                            mpOffset.vRot = new(-9.5f, 0.0f, 3.3f);
                            mpOffset.iFov = 41;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-875.1f, -360.1f, 36.6f);
                            mpOffset.vRot = new(-8.8f, 0.0f, -11.6f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-613.9f, 36.1f, 44.3f);
                            mpOffset.vRot = new(-5.9f, -0.0f, -9.9f);
                            mpOffset.iFov = 38;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-632.0f, 52.5f, 44.4f);
                            mpOffset.vRot = new(-9.1f, 0.0f, -119.8f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(285.4668f, -161.1250f, 65.2602f);
                            mpOffset.vRot = new(-6.4571f, 0.0000f, -164.4728f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(285.5949f, -145.3242f, 65.7009f);
                            mpOffset.vRot = new(-7.7904f, 0.0000f, -55.5110f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(5.2649f, 35.2547f, 72.2539f);
                            mpOffset.vRot = new(-10.4412f, -0.0000f, -53.7611f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-6.0041f, 39.0034f, 71.9630f);
                            mpOffset.vRot = new(-9.6880f, -0.0000f, -51.8642f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(12.1362f, 81.8963f, 79.1336f);
                            mpOffset.vRot = new(-8.9777f, 0.0000f, -166.6546f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(22.7339f, 79.1615f, 75.2801f);
                            mpOffset.vRot = new(-7.3074f, 0.0000f, -150.1745f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-509.4645f, 108.8472f, 64.3629f);
                            mpOffset.vRot = new(-9.8990f, -0.0000f, 131.8686f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-497.1247f, 79.1840f, 56.5678f);
                            mpOffset.vRot = new(-8.2948f, -0.0000f, -142.6047f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-198.2783f, 86.1405f, 70.4677f);
                            mpOffset.vRot = new(-9.2761f, 0.0000f, 115.5424f);
                            mpOffset.iFov = 52;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-213.0514f, 32.5272f, 60.5488f);
                            mpOffset.vRot = new(-8.2222f, -0.0000f, -131.4560f);
                            mpOffset.iFov = 52;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-628.1761f, 168.9902f, 61.8914f);
                            mpOffset.vRot = new(-4.4950f, 0.0000f, -141.2589f);
                            mpOffset.iFov = 48;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-627.3095f, 149.4444f, 57.2343f);
                            mpOffset.vRot = new(-10.2520f, -0.0000f, -127.7655f);
                            mpOffset.iFov = 49;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-969.3254f, -1432.4276f, 8.3229f);
                            mpOffset.vRot = new(-6.3998f, 0.0000f, -119.2131f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-981.0207f, -1448.2601f, 5.3947f);
                            mpOffset.vRot = new(-8.7371f, 0.0000f, -29.0958f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-833.3187f, -861.9778f, 21.3686f);
                            mpOffset.vRot = new(-6.6930f, 0.0000f, 138.5805f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-762.9166f, -867.1293f, 21.4671f);
                            mpOffset.vRot = new(-4.9357f, -0.0000f, 29.5602f);
                            mpOffset.iFov = 52;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-763.1182f, -751.6816f, 28.5075f);
                            mpOffset.vRot = new(-1.8853f, -0.0000f, 42.6966f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-782.6591f, -800.6797f, 21.4422f);
                            mpOffset.vRot = new(-5.5632f, 0.0000f, -39.9767f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-41.4389f, -58.8451f, 64.3271f);
                            mpOffset.vRot = new(-3.0713f, 0.0000f, -154.3893f);
                            mpOffset.iFov = 39;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-29.7067f, -67.1028f, 60.3260f);
                            mpOffset.vRot = new(-8.4087f, -0.0000f, -54.9184f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-201.1683f, 186.0728f, 81.0095f);
                            mpOffset.vRot = new(-4.5407f, 0.0000f, -146.1329f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-201.0988f, 195.9190f, 80.0388f);
                            mpOffset.vRot = new(-3.8081f, 0.0000f, -35.7488f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-814.3718f, -980.4719f, 14.8034f);
                            mpOffset.vRot = new(-1.1897f, 0.0000f, -24.3240f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-802.0981f, -983.4576f, 13.9184f);
                            mpOffset.vRot = new(-6.1095f, 0.0000f, 66.4167f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-662.3193f, -853.7542f, 25.1988f);
                            mpOffset.vRot = new(-7.4463f, -0.0000f, 124.8045f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-665.6224f, -854.9120f, 25.0359f);
                            mpOffset.vRot = new(-2.9676f, 0.0000f, -143.5872f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1533.5221f, -325.1373f, 48.5180f);
                            mpOffset.vRot = new(-4.0529f, 0.0000f, -101.1638f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1526.6040f, -346.1278f, 45.8928f);
                            mpOffset.vRot = new(-2.5993f, -0.0000f, -76.3419f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1562.7728f, -404.9621f, 43.0871f);
                            mpOffset.vRot = new(-5.4640f, 0.0000f, 0.6323f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1556.5867f, -397.3818f, 42.6921f);
                            mpOffset.vRot = new(-6.8539f, -0.0000f, -1.2556f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1606.8475f, -433.0265f, 41.1098f);
                            mpOffset.vRot = new(-5.1466f, -0.0000f, 170.9712f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1604.5302f, -449.8414f, 38.8454f);
                            mpOffset.vRot = new(-9.7372f, -0.0000f, -82.1673f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(963.7385f, -1023.4319f, 41.6100f);
                            mpOffset.vRot = new(-4.4804f, -0.0000f, 31.9752f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(895.0206f, -888.5084f, 27.8658f);
                            mpOffset.vRot = new(-7.4969f, 0.0000f, -145.8136f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(813.0861f, -924.0255f, 26.8470f);
                            mpOffset.vRot = new(-4.8828f, -0.0000f, 125.4508f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(759.5690f, -750.8026f, 27.8671f);
                            mpOffset.vRot = new(-12.0700f, -0.0000f, 36.2770f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(845.4525f, -1164.0549f, 26.0404f);
                            mpOffset.vRot = new(-5.1125f, 0.0000f, 128.3197f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(527.1507f, -1604.1677f, 30.0043f);
                            mpOffset.vRot = new(-8.7829f, 0.0000f, 179.0896f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(568.9454f, -1568.7795f, 29.3756f);
                            mpOffset.vRot = new(-8.8411f, 0.0000f, 88.5419f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(725.9837f, -1190.0828f, 24.7622f);
                            mpOffset.vRot = new(-5.7563f, 0.0000f, -52.9913f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(503.8840f, -1493.3114f, 29.9838f);
                            mpOffset.vRot = new(-7.4584f, -0.0000f, -49.7693f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(472.6767f, -1544.2998f, 29.9581f);
                            mpOffset.vRot = new(-7.1085f, -0.0000f, 88.7617f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-69.6453f, 6425.6719f, 32.0933f);
                            mpOffset.vRot = new(-7.5796f, 0.0000f, 171.2266f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-249.6360f, 6236.9258f, 32.1614f);
                            mpOffset.vRot = new(-7.9593f, 0.0000f, -3.2575f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(2556.9614f, 4669.8813f, 34.7015f);
                            mpOffset.vRot = new(-6.8502f, 0.0000f, 150.3864f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(2461.5303f, 1591.3009f, 33.6156f);
                            mpOffset.vRot = new(-9.9709f, -0.0000f, 34.8646f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-2201.2710f, 4246.4478f, 49.0632f);
                            mpOffset.vRot = new(-9.3812f, -0.0000f, 162.4918f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(215.7870f, 2601.8115f, 46.4296f);
                            mpOffset.vRot = new(-9.7269f, -0.0000f, 141.6687f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(186.1695f, 2788.5823f, 46.2773f);
                            mpOffset.vRot = new(-10.4301f, 0.0000f, 47.6613f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(637.7636f, 2771.8210f, 42.7397f);
                            mpOffset.vRot = new(-8.5790f, 0.0000f, 130.5458f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1128.7236f, 2698.0581f, 19.4849f);
                            mpOffset.vRot = new(-7.8616f, 0.0000f, -99.0872f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-7.7169f, -1648.5443f, 30.0391f);
                            mpOffset.vRot = new(-7.4420f, -0.0000f, 87.9721f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1025.9585f, -2393.5747f, 30.8460f);
                            mpOffset.vRot = new(-11.4425f, 0.0000f, 144.4801f);
                            mpOffset.iFov = 48;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(872.4777f, -2233.0913f, 31.0957f);
                            mpOffset.vRot = new(-7.7465f, 0.0000f, -58.0003f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-666.3512f, -2382.8408f, 14.6285f);
                            mpOffset.vRot = new(-5.4658f, -0.0000f, -177.1331f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1090.2739f, -2231.9016f, 13.9317f);
                            mpOffset.vRot = new(-8.2135f, 0.0000f, 84.4760f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-342.1407f, -1467.4602f, 31.3066f);
                            mpOffset.vRot = new(-4.0818f, -0.0000f, 37.5008f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1242.8226f, -260.0704f, 39.6309f);
                            mpOffset.vRot = new(-6.6752f, 0.0000f, 160.0690f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(898.4088f, -145.9213f, 77.3075f);
                            mpOffset.vRot = new(-5.8786f, 0.0000f, 94.1609f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1406.1196f, 529.0493f, 124.6023f);
                            mpOffset.vRot = new(-6.8212f, 0.0000f, -146.1539f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1406.0845f, 534.9131f, 123.5716f);
                            mpOffset.vRot = new(-1.7131f, -0.0000f, -29.5293f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1335.5577f, -1580.5234f, 54.7103f);
                            mpOffset.vRot = new(-4.3105f, -0.0000f, -8.9232f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(1347.8134f, -1573.3794f, 54.6940f);
                            mpOffset.vRot = new(-2.6367f, -0.0000f, 84.1322f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-106.6919f, 6530.0532f, 30.5213f);
                            mpOffset.vRot = new(-4.0991f, 0.0000f, 174.2741f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-99.8316f, 6534.0361f, 30.4947f);
                            mpOffset.vRot = new(-5.5428f, -0.0000f, -179.8944f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-301.0318f, 6328.6123f, 33.5878f);
                            mpOffset.vRot = new(-3.8726f, 0.0000f, 175.6090f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-295.0799f, 6333.0522f, 33.2058f);
                            mpOffset.vRot = new(-4.4204f, -0.0000f, -88.6178f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-13.5813f, 6556.1704f, 34.0232f);
                            mpOffset.vRot = new(-7.0358f, -0.0000f, 88.1934f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-16.9580f, 6564.1592f, 32.6155f);
                            mpOffset.vRot = new(-7.9109f, 0.0000f, 0.2209f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1900.1654f, 3780.2783f, 33.5484f);
                            mpOffset.vRot = new(-4.2523f, 0.0000f, 75.7018f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(1879.8076f, 3771.3669f, 33.5671f);
                            mpOffset.vRot = new(-8.8235f, 0.0000f, -14.1092f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1662.8319f, 4774.0508f, 42.7264f);
                            mpOffset.vRot = new(-4.5231f, -0.0000f, 49.5092f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(1658.7134f, 4764.9829f, 42.6845f);
                            mpOffset.vRot = new(-4.9649f, 0.0000f, 52.0654f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-174.2346f, 501.1949f, 137.9935f);
                            mpOffset.vRot = new(-3.0108f, 0.1808f, -3.6855f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-191.3622f, 499.5826f, 135.3534f);
                            mpOffset.vRot = new(-6.7478f, -0.0000f, 107.7213f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(346.1495f, 440.9070f, 148.2978f);
                            mpOffset.vRot = new(-1.3061f, -0.0000f, 5.8705f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(352.4345f, 434.0689f, 148.1152f);
                            mpOffset.vRot = new(-8.0827f, -0.0000f, -160.3445f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-753.1660f, 620.7542f, 143.0819f);
                            mpOffset.vRot = new(-2.9823f, 0.0564f, 13.6013f);
                            mpOffset.iFov = 40;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-756.2818f, 630.7937f, 143.2509f);
                            mpOffset.vRot = new(-0.9135f, -0.0000f, 34.0667f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-688.5220f, 595.4149f, 144.2805f);
                            mpOffset.vRot = new(-5.1276f, -0.0000f, -107.7303f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-679.2871f, 605.6187f, 144.3488f);
                            mpOffset.vRot = new(-4.1557f, -0.0000f, 163.6818f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(116.8450f, 564.7203f, 185.1113f);
                            mpOffset.vRot = new(-26.9607f, 0.0000f, -125.1322f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(127.8118f, 566.9700f, 185.2009f);
                            mpOffset.vRot = new(-24.5905f, -0.0000f, -124.9627f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-557.4619f, 663.5363f, 146.1900f);
                            mpOffset.vRot = new(-2.7893f, -0.0000f, 72.3185f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-553.9622f, 664.7136f, 145.5907f);
                            mpOffset.vRot = new(1.5786f, -0.0174f, -156.8600f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-734.6143f, 594.6970f, 142.7924f);
                            mpOffset.vRot = new(-2.7459f, -0.0000f, -136.1363f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-745.9420f, 602.2723f, 143.1472f);
                            mpOffset.vRot = new(-6.9421f, 0.0000f, 91.0443f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-854.4550f, 695.9321f, 149.3805f);
                            mpOffset.vRot = new(-1.8270f, -0.0000f, -146.2099f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-860.4291f, 695.2629f, 149.8496f);
                            mpOffset.vRot = new(-7.5003f, -0.0000f, 66.0756f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1295.9320f, 454.9302f, 97.9414f);
                            mpOffset.vRot = new(8.3431f, 3.2192f, -124.4324f);
                            mpOffset.iFov = 61;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1299.6975f, 454.6570f, 98.3056f);
                            mpOffset.vRot = new(-10.6364f, -0.0000f, 127.4379f);
                            mpOffset.iFov = 48;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(372.1357f, 429.6533f, 146.8284f);
                            mpOffset.vRot = new(-23.2066f, -0.0000f, -158.6161f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(386.1300f, 430.1164f, 145.3114f);
                            mpOffset.vRot = new(-16.4084f, 0.0000f, -141.0797f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1581.6547f, -557.7567f, 35.5710f);
                            mpOffset.vRot = new(-3.8568f, 0.0013f, 153.5884f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1561.4110f, -569.1495f, 114.8875f);
                            mpOffset.vRot = new(-7.6241f, -0.0000f, 148.5089f);
                            mpOffset.iFov = 46;
                            break;
                        case 2:
                            mpOffset.vLoc = new(-1554.214966f, -560.700195f, 26.531332f);
                            mpOffset.vRot = new(-8.309215f, -0.000000f, -170.644196f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1368.7903f, -506.0562f, 33.8591f);
                            mpOffset.vRot = new(-10.1108f, 0.0000f, 15.0077f);
                            mpOffset.iFov = 44;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1369.0529f, -472.1344f, 85.1331f);
                            mpOffset.vRot = new(-7.7322f, -0.0000f, 56.5926f);
                            mpOffset.iFov = 50;
                            break;
                        case 2:
                            mpOffset.vLoc = new(-1414.233398f, -481.263428f, 34.351917f);
                            mpOffset.vRot = new(-17.313862f, 0.000000f, -95.088608f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-118.0230f, -608.6168f, 36.8739f);
                            mpOffset.vRot = new(1.1795f, -0.0000f, 139.2717f);
                            mpOffset.iFov = 50;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-134.4682f, -584.0303f, 202.3415f);
                            mpOffset.vRot = new(-8.8012f, -0.0000f, 61.2406f);
                            mpOffset.iFov = 57;
                            break;
                        case 2:
                            mpOffset.vLoc = new(-143.687881f, -582.120850f, 33.123844f);
                            mpOffset.vRot = new(-12.536664f, -0.000000f, -59.125427f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-82.5742f, -796.5438f, 44.7419f);
                            mpOffset.vRot = new(-4.2586f, 0.0000f, -170.8396f);
                            mpOffset.iFov = 47;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-66.7362f, -821.1367f, 322.0084f);
                            mpOffset.vRot = new(-9.7959f, 0.0000f, 26.2285f);
                            mpOffset.iFov = 58;
                            break;
                        case 2:
                            mpOffset.vLoc = new(-83.925270f, -785.817200f, 39.018078f);
                            mpOffset.vRot = new(-13.762782f, 0.011307f, 161.143478f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(253.029724f, -1808.568848f, 27.762878f);
                            mpOffset.vRot = new(-7.506186f, 0.000000f, -170.139160f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1472.722778f, -921.915527f, 10.744691f);
                            mpOffset.vRot = new(-11.720086f, -0.000000f, -3.190560f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(36.753845f, -1029.493042f, 30.219028f);
                            mpOffset.vRot = new(-17.187565f, -0.000000f, -150.430313f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(44.810307f, 2789.567627f, 58.631462f);
                            mpOffset.vRot = new(-18.836893f, -0.000000f, -77.778770f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-342.098602f, 6066.375488f, 32.185349f);
                            mpOffset.vRot = new(-9.564704f, -0.000000f, 90.726303f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1737.418579f, 3709.417725f, 34.816765f);
                            mpOffset.vRot = new(-11.651431f, 0.000000f, 163.782608f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(939.175964f, -1457.899780f, 32.006920f);
                            mpOffset.vRot = new(-6.133397f, -0.006570f, 143.585876f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(187.974518f, 308.639313f, 106.091232f);
                            mpOffset.vRot = new(-11.210886f, -0.000000f, -39.121571f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-24.222765f, -191.784744f, 52.986099f);
                            mpOffset.vRot = new(-7.573972f, 0.000000f, -60.875786f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(2471.192139f, 4110.565430f, 38.838745f);
                            mpOffset.vRot = new(-9.600769f, -0.000000f, -157.882141f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-38.316467f, 6420.124023f, 32.193729f);
                            mpOffset.vRot = new(-10.774587f, -0.000000f, 2.229327f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1134.481689f, -1569.199219f, 5.096465f);
                            mpOffset.vRot = new(-12.477842f, -0.000000f, -2.606249f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
            }
        }
        public static void GetTransitionBuzzSceneDetails(BuildingsEnum iBuilding, ref Position mpOffset, int iEntrance)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-778.860f, 313.505f, 84.708f, 0.000f, 0.000f, -0.720f);
                            break;
                        case 1:
                            mpOffset = new(-790.315f, 308.720f, 84.710f, 0.000f, 0.000f, -0.720f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-260.583f, -969.092f, 30.340f, 0.000f, 0.000f, 61.200f);
                            break;
                        case 1:
                            mpOffset = new(-280.575f, -991.538f, 23.422f, 0.000f, 0.000f, 66.600f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1441.876f, -543.441f, 33.825f, 0.000f, 0.000f, 34.560f);
                            break;
                        case 1:
                            mpOffset = new(-1453.493f, -500.210f, 31.635f, 0.000f, 0.000f, -144.360f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-912.864f, -456.052f, 38.768f, 0.000f, 0.000f, -63.000f);
                            break;
                        case 1:
                            mpOffset = new(-819.315f, -441.321f, 35.794f, 0.000f, 0.000f, -153.360f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-49.069f, -590.428f, 37.037f, 0.000f, 0.000f, 158.760f);
                            break;
                        case 1:
                            mpOffset = new(-32.770f, -618.915f, 34.005f, 0.000f, 0.000f, 70.200f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-934.373f, -380.042f, 38.190f, 0.000f, 0.000f, -63.000f);
                            break;
                        case 1:
                            mpOffset = new(-875.060f, -359.235f, 34.979f, 0.000f, 0.000f, -63.000f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-613.546f, 36.995f, 42.799f, 0.000f, 0.000f, -89.640f);
                            break;
                        case 1:
                            mpOffset = new(-631.275f, 51.995f, 42.946f, 0.000f, 0.000f, 180.000f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(285.850f, -162.196f, 63.708f, 0.000f, 0.000f, -123.120f);
                            break;
                        case 1:
                            mpOffset = new(286.537f, -144.748f, 64.141f, 0.000f, 0.000f, -118.080f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(6.212f, 35.838f, 70.663f, 0.000f, 0.000f, -113.040f);
                            break;
                        case 1:
                            mpOffset = new(-5.117f, 39.705f, 70.435f, 0.000f, 0.000f, -113.040f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(12.512f, 80.891f, 77.539f, 0.000f, 0.000f, -110.880f);
                            break;
                        case 1:
                            mpOffset = new(23.380f, 78.140f, 73.747f, 0.000f, 0.000f, 158.760f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-510.110f, 108.054f, 62.790f, 0.000f, 0.000f, -172.800f);
                            break;
                        case 1:
                            mpOffset = new(-496.396f, 78.392f, 54.955f, 0.000f, 0.000f, -87.840f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-199.099f, 85.587f, 68.884f, 0.000f, 0.000f, 164.160f);
                            break;
                        case 1:
                            mpOffset = new(-212.390f, 31.740f, 58.950f, 0.000f, 0.000f, 164.160f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-627.387f, 168.158f, 60.361f, 0.000f, 0.000f, -89.640f);
                            break;
                        case 1:
                            mpOffset = new(-626.418f, 148.743f, 55.622f, 0.000f, 0.000f, 180.000f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-968.312f, -1432.835f, 6.802f, 0.000f, 0.000f, -68.400f);
                            break;
                        case 1:
                            mpOffset = new(-980.675f, -1447.305f, 3.847f, 0.000f, 0.000f, 24.120f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-834.032f, -862.810f, 19.822f, 0.000f, 0.000f, 107.280f);
                            break;
                        case 1:
                            mpOffset = new(-763.499f, -866.322f, 19.969f, 0.000f, 0.000f, 89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-763.908f, -750.905f, 27.003f, 0.000f, 0.000f, 87.840f);
                            break;
                        case 1:
                            mpOffset = new(-781.935f, -799.920f, 19.899f, 0.000f, 0.000f, -89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-40.785f, -59.991f, 62.786f, 0.000f, 0.000f, -107.280f);
                            break;
                        case 1:
                            mpOffset = new(-28.825f, -66.555f, 58.700f, 0.000f, 0.000f, -107.280f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-200.445f, 185.240f, 79.430f, 0.000f, 0.000f, -89.640f);
                            break;
                        case 1:
                            mpOffset = new(-200.450f, 196.680f, 78.460f, 0.000f, 0.000f, -89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-814.070f, -979.435f, 13.330f, 0.000f, 0.000f, 32.760f);
                            break;
                        case 1:
                            mpOffset = new(-803.008f, -983.228f, 12.395f, 0.000f, 0.000f, 126.720f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-663.153f, -854.500f, 23.625f, 0.000f, 0.000f, 176.400f);
                            break;
                        case 1:
                            mpOffset = new(-664.845f, -855.715f, 23.480f, 0.000f, 0.000f, -93.240f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1532.390f, -325.215f, 46.970f, 0.000f, 0.000f, -48.600f);
                            break;
                        case 1:
                            mpOffset = new(-1525.625f, -346.010f, 44.354f, 0.000f, 0.000f, -135.720f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1562.933f, -403.870f, 41.462f, 0.000f, 0.000f, 52.200f);
                            break;
                        case 1:
                            mpOffset = new(-1556.635f, -396.370f, 41.102f, 0.000f, 0.000f, 52.200f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1606.920f, -434.125f, 39.535f, 0.000f, 0.000f, -126.720f);
                            break;
                        case 1:
                            mpOffset = new(-1603.537f, -449.763f, 37.301f, 0.000f, 0.000f, -126.720f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(963.137f, -1022.760f, 40.080f, 0.000f, 0.000f, 89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(895.667f, -889.268f, 26.338f, -0.000f, -0.000f, -83.754f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(812.400f, -924.721f, 25.327f, 0.000f, 0.000f, 164.160f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(758.920f, -750.150f, 26.265f, 0.000f, 0.000f, 89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(844.695f, -1164.752f, 24.515f, 0.000f, 0.000f, -176.760f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(527.236f, -1605.145f, 28.440f, 0.000f, 0.000f, -127.800f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(568.009f, -1568.872f, 27.815f, 0.000f, 0.000f, 142.920f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(726.732f, -1189.434f, 23.180f, 0.000f, 0.000f, -3.240f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(504.575f, -1492.614f, 28.413f, 0.000f, 0.000f, -1.800f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(471.728f, -1544.385f, 28.410f, 0.000f, 0.000f, 141.480f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-69.685f, 6424.698f, 30.560f, 0.000f, 0.000f, -132.840f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-249.652f, 6237.979f, 30.618f, 0.000f, 0.000f, 45.360f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(2556.598f, 4669.000f, 33.165f, 0.000f, 0.000f, -158.040f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(2460.905f, 1592.035f, 31.968f, 0.000f, -0.300f, 89.280f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-2201.405f, 4245.515f, 47.470f, 0.000f, -0.300f, -141.480f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(215.200f, 2600.950f, 44.873f, -0.000f, -0.300f, -168.120f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(185.370f, 2789.204f, 44.667f, 0.000f, -0.300f, 99.360f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(637.058f, 2771.099f, 41.166f, -0.000f, -0.300f, -178.200f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1127.692f, 2697.950f, 17.914f, 0.000f, -0.300f, -47.160f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-8.790f, -1648.565f, 28.436f, 0.000f, -0.300f, 139.680f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1025.392f, -2394.257f, 29.210f, 0.000f, 0.000f, 82.440f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(873.255f, -2232.497f, 29.485f, 0.000f, 0.000f, -6.120f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-666.195f, -2383.775f, 13.064f, 0.000f, 0.000f, -118.080f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1091.300f, -2231.885f, 12.353f, 0.000f, 0.000f, 139.320f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-342.836f, -1466.688f, 29.740f, 0.000f, 0.000f, 89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1243.128f, -261.075f, 38.075f, 0.000f, 0.000f, -153.360f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(897.375f, -146.065f, 75.765f, 0.000f, 0.000f, 147.960f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1405.408f, 528.250f, 123.042f, 0.000f, 0.000f, -89.640f);
                            break;
                        case 1:
                            mpOffset = new(-1405.475f, 535.675f, 122.068f, 0.000f, 0.000f, -89.640f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1335.650f, -1579.352f, 53.190f, 0.000f, 0.000f, 34.560f);
                            break;
                        case 1:
                            mpOffset = new(1346.860f, -1573.206f, 53.188f, 0.000f, 0.000f, 34.560f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-106.670f, 6528.895f, 29.000f, 0.000f, 0.000f, -137.520f);
                            break;
                        case 1:
                            mpOffset = new(-99.780f, 6533.024f, 28.962f, 0.000f, 0.000f, -137.520f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-301.052f, 6327.556f, 32.060f, 0.000f, 0.000f, -137.520f);
                            break;
                        case 1:
                            mpOffset = new(-294.012f, 6333.058f, 31.678f, 0.000f, 0.000f, -133.920f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-14.642f, 6556.123f, 32.450f, 0.000f, 0.000f, 135.720f);
                            break;
                        case 1:
                            mpOffset = new(-17.011f, 6565.195f, 31.040f, 0.000f, 0.000f, 43.560f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1899.145f, 3780.497f, 32.010f, 0.000f, 0.000f, 121.320f);
                            break;
                        case 1:
                            mpOffset = new(1879.988f, 3772.333f, 31.981f, 0.000f, 0.000f, 32.760f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1662.005f, 4774.645f, 41.170f, 0.000f, 0.000f, 100.080f);
                            break;
                        case 1:
                            mpOffset = new(1657.865f, 4765.595f, 41.150f, 0.000f, 0.000f, 7.920f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-173.976f, 501.860f, 136.464f, 0.000f, -0.000f, -110.000f);
                            break;
                        case 1:
                            mpOffset = new(-192.284f, 498.754f, 133.614f, -0.000f, -0.000f, 178.338f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(345.261f, 441.950f, 146.750f, 0.000f, 0.000f, 77.000f);
                            break;
                        case 1:
                            mpOffset = new(352.488f, 432.724f, 146.529f, 0.000f, -0.000f, 120.500f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-753.894f, 621.781f, 141.511f, 0.000f, -0.000f, 104.565f);
                            break;
                        case 1:
                            mpOffset = new(-757.200f, 631.612f, 141.712f, 0.000f, -0.000f, 120.500f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-687.152f, 594.762f, 142.710f, 0.000f, -0.000f, -180.000f);
                            break;
                        case 1:
                            mpOffset = new(-679.688f, 604.138f, 142.763f, 0.000f, -0.000f, -147.750f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(118.280f, 563.638f, 183.008f, 0.000f, -0.000f, -179.340f);
                            break;
                        case 1:
                            mpOffset = new(129.230f, 565.888f, 183.008f, 0.000f, -0.000f, -179.340f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-558.722f, 663.216f, 144.404f, 0.000f, -0.000f, 156.000f);
                            break;
                        case 1:
                            mpOffset = new(-553.175f, 663.625f, 144.211f, 0.000f, -0.000f, -99.250f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-734.125f, 593.760f, 141.239f, 0.000f, -0.000f, 120.000f);
                            break;
                        case 1:
                            mpOffset = new(-747.402f, 602.115f, 141.523f, -0.000f, -0.000f, 146.014f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-853.810f, 694.600f, 147.800f, 0.000f, -0.000f, 147.600f);
                            break;
                        case 1:
                            mpOffset = new(-861.735f, 695.088f, 148.055f, 0.000f, -0.000f, 147.600f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1295.052f, 454.016f, 96.640f, 0.000f, 0.000f, 175.442f);
                            break;
                        case 1:
                            mpOffset = new(-1300.509f, 454.024f, 96.721f, 0.000f, 0.000f, 169.767f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(372.736f, 427.031f, 144.747f, -0.000f, -0.000f, 160.521f);
                            break;
                        case 1:
                            mpOffset = new(387.286f, 428.181f, 143.133f, -0.000f, -0.000f, 160.521f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1582.009f, -559.573f, 33.941f, 0.000f, -0.000f, -150.480f);
                            break;
                        case 1:
                            mpOffset = new(-1561.870f, -570.280f, 113.432f, 0.000f, -0.000f, -148.000f);
                            break;
                        case 2:
                            mpOffset = new(-1554.315f, -561.610f, 24.906f, 0.000f, -0.000f, 124.500f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1369.110f, -504.830f, 32.178f, 0.000f, 0.000f, -44.000f);
                            break;
                        case 1:
                            mpOffset = new(-1370.207f, -471.512f, 83.443f, 0.000f, -0.000f, 120.000f);
                            break;
                        case 2:
                            mpOffset = new(-1413.410f, -481.631f, 32.606f, 0.000f, -0.000f, -157.750f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-119.812f, -609.795f, 35.279f, 0.000f, 0.000f, 61.100f);
                            break;
                        case 1:
                            mpOffset = new(-135.302f, -583.755f, 200.762f, 0.000f, -0.000f, 120.000f);
                            break;
                        case 2:
                            mpOffset = new(-142.894f, -581.447f, 31.425f, 0.000f, -0.000f, -19.803f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-82.468f, -797.692f, 43.216f, 0.000f, -0.000f, 115.000f);
                            break;
                        case 1:
                            mpOffset = new(-67.255f, -819.950f, 320.313f, 0.000f, 0.000f, 85.000f);
                            break;
                        case 2:
                            mpOffset = new(-84.443f, -786.525f, 37.348f, 0.000f, -0.000f, 94.500f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(253.31f, -1809.59f, 26.113f, 0.0f, 0.0f, -130.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1472.840f, -920.940f, 9.053f, 0.0f, 0.0f, 50.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(37.287f, -1030.246f, 28.458f, 0.0f, 0.0f, 247.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(45.790f, 2789.82f, 56.878f, 0.0f, 0.0f, 322.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-343.11f, 6066.146f, 30.509f, 0.0f, 0.0f, 135.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1737.198f, 3708.397f, 33.136f, 0.0f, 0.0f, -159.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(938.65f, -1458.78f, 30.4f, 0.0f, 0.0f, 180.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(188.413f, 309.453f, 104.39f, 0.0f, 0.0f, 5.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-23.4f, -191.15f, 51.35f, 0.0f, 0.0f, -20.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(2471.68f, 4109.53f, 37.065f, 0.0f, 0.0f, -112.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-38.485f, 6421.165f, 30.483f, 0.0f, 0.0f, 45.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1134.440f, -1568.120f, 3.408f, 0.0f, 0.0f, 35.0f);
                            break;
                    }
                    break;
            }
        }
        // IVariation is used for offices to handle enter and exit, enter = 0, exit = 1
        public static uint GetSpecialPropertyDoorForAnimation(BuildingsEnum iBuilding, int iEntrance, int iVariation = 0)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    if (iEntrance == 1)
                        if (iVariation == 0)
                            return Functions.HashUint("Prop_bh1_44_door_01l");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    if (iEntrance == 1)
                        return Functions.HashUint("Prop_bh1_44_door_01l");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    if (iEntrance == 1)
                        return Functions.HashUint("Prop_sm1_11_doorl");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    if (iEntrance == 0)
                        return Functions.HashUint("PROP_SS1_05_MP_DOOR");
                    else if (iEntrance == 1)
                        return Functions.HashUint("Prop_ss1_05_mp_door");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    if (iEntrance == 1)
                        return Functions.HashUint("Prop_ss1_08_mp_door_l");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    if (iEntrance == 0)
                        return Functions.HashUint("VB_43_DOOR_R_MP");
                    else if (iEntrance == 1)
                        return Functions.HashUint("VB_43_DOOR_L_MP");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    if (iEntrance == 1)
                        return Functions.HashUint("Prop_kt1_10_mpdoor_r");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    if (iEntrance == 0)
                        return Functions.HashUint("Prop_kt1_06_door_r");
                    else if (iEntrance == 1)
                        return Functions.HashUint("Prop_kt1_06_door_r");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    if (iEntrance == 0)
                        return Functions.HashUint("prop_kt1_10_mpdoor_l");
                    else if (iEntrance == 1)
                        return Functions.HashUint("Prop_kt1_10_mpdoor_r");
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    return Functions.HashUint("HEI_Prop_sync_door_06");
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR03");
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR04");
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR02B");
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR07");
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR05B");
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    return Functions.HashUint("HEI_PROP_SYNC_DOOR01A");
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    if (iEntrance == 0)
                        return Functions.HashUint("hei_prop_BH1_08_HDoor");
                    else if (iEntrance == 1)
                        return Functions.HashUint("hei_prop_BH1_08_HDoor");
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    if (iEntrance == 0)
                        return Functions.HashUint("ex_prop_door_lowbank_ent_r");
                    else if (iEntrance == 1)
                        return Functions.HashUint("ex_prop_door_lowbank_roof");
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    if (iEntrance == 1)
                        if (iVariation == 0)
                            return Functions.HashUint("ex_Prop_Door_Maze2_Rf_L");
                        else if (iVariation == 1)
                            return Functions.HashUint("ex_Prop_Door_Maze2_Rf_R");
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    if (iEntrance == 0)
                        return Functions.HashUint("ex_Prop_Door_arcad_Ent_L");
                    else if (iEntrance == 1)
                        if (iVariation == 0)
                            return Functions.HashUint("ex_Prop_Door_Arcad_Roof_L");
                        else if (iVariation == 1)
                            return Functions.HashUint("ex_Prop_Door_Arcad_Roof_R");
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    if (iEntrance == 0)
                        return Functions.HashUint("ex_Prop_Door_Maze2_Ent_R");
                    else if (iEntrance == 1)
                        return Functions.HashUint("ex_Prop_Door_Maze2_Roof");
                    break;
            }
            return Functions.HashUint("DUMMY_MODEL_FOR_SCRIPT");
        }
        public static void PropertyTransitionCamDetails(BuildingsEnum iBuilding, int iEntrance, bool bWalkIn, ref MPCamOffset mpOffset)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-778.8375f, 312.4263f, 86.2157f);
                            mpOffset.vRot = new(-3.6467f, -0.0242f, -61.4538f);
                            mpOffset.iFov = 26;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-262.3743f, -971.1577f, 31.7935f);
                            mpOffset.vRot = new(-7.6574f, -0.0501f, -31.6205f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1443.9298f, -545.9659f, 35.1923f);
                            mpOffset.vRot = new(-5.5697f, -0.0008f, -32.2035f);
                            mpOffset.iFov = 30;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-915.1278f, -453.6297f, 40.0744f);
                            mpOffset.vRot = new(-6.0811f, -0.0118f, -134.2025f);
                            mpOffset.iFov = 28;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-48.9890f, -584.7633f, 38.6f);
                            mpOffset.vRot = new(-1.2894f, -0.0270f, -165.4495f);
                            mpOffset.iFov = 22;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-931.6423f, -390.9495f, 39.0325f);
                            mpOffset.vRot = new(-0.3785f, 0.5770f, 5.7074f);
                            mpOffset.iFov = 20;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-616.0326f, 37.8265f, 44.3494f);
                            mpOffset.vRot = new(-8.1049f, -0.1644f, -72.0749f);
                            mpOffset.iFov = 30;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(285.9142f, -159.6398f, 65.0086f);
                            mpOffset.vRot = new(-5.1911f, -0.0457f, -171.3981f);
                            mpOffset.iFov = 36;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1.9757f, 37.2375f, 71.8745f);
                            mpOffset.vRot = new(-3.8733f, -0.0381f, -79.9425f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(11.0097f, 81.2408f, 78.7658f);
                            mpOffset.vRot = new(-4.0039f, -0.0606f, 99.0836f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-510.8780f, 108.4017f, 64.1737f);
                            mpOffset.vRot = new(-4.7927f, -0.0578f, 115.5957f);
                            mpOffset.iFov = 36;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-196.3497f, 85.7192f, 70.0537f);
                            mpOffset.vRot = new(-4.1878f, -0.0707f, 100.6295f);
                            mpOffset.iFov = 32;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-628.1861f, 170.5892f, 61.5412f);
                            mpOffset.vRot = new(-7.1596f, 0.0340f, -151.0119f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-969.9488f, -1430.5129f, 8.2810f);
                            mpOffset.vRot = new(-0.9523f, -0.0007f, -128.5640f);
                            mpOffset.iFov = 36;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-830.5533f, -862.1614f, 21.2626f);
                            mpOffset.vRot = new(-5.7446f, 0.0702f, 113.1385f);
                            mpOffset.iFov = 34;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-830.9413f, -862.3662f, 21.1341f);
                            mpOffset.vRot = new(-6.4051f, 0.0000f, 120.4844f);
                            mpOffset.iFov = 50;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-763.1959f, -754.4324f, 28.0761f);
                            mpOffset.vRot = new(-0.1307f, 0.0611f, 32.2352f);
                            mpOffset.iFov = 35;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-41.8778f, -59.9533f, 64.3708f);
                            mpOffset.vRot = new(-2.5317f, 0.0466f, -47.9009f);
                            mpOffset.iFov = 35;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-201.1149f, 187.7645f, 80.8444f);
                            mpOffset.vRot = new(-4.7470f, 0.0559f, -149.2041f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-813.5362f, -979.8682f, 14.8561f);
                            mpOffset.vRot = new(-5.6169f, 0.0575f, -116.8919f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-663.8629f, -853.4365f, 24.8634f);
                            mpOffset.vRot = new(-5.2770f, -0.0469f, -124.8955f);
                            mpOffset.iFov = 33;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1532.8925f, -325.5346f, 48.4096f);
                            mpOffset.vRot = new(-2.7735f, 0.0108f, 169.1348f);
                            mpOffset.iFov = 41;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1564.6744f, -406.9030f, 42.7314f);
                            mpOffset.vRot = new(-2.3305f, -0.0179f, -11.8820f);
                            mpOffset.iFov = 35;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1605.9042f, -431.7684f, 40.8291f);
                            mpOffset.vRot = new(-4.0988f, 0.0591f, 169.9062f);
                            mpOffset.iFov = 32;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1405.6022f, 528.2314f, 124.3656f);
                            mpOffset.vRot = new(-4.3219f, -0.0000f, -170.2689f);
                            mpOffset.iFov = 40;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1334.5752f, -1580.3108f, 54.9153f);
                            mpOffset.vRot = new(0.9696f, -0.0301f, -50.8474f);
                            mpOffset.iFov = 31;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-107.8012f, 6530.5430f, 30.6087f);
                            mpOffset.vRot = new(1.7051f, -0.0310f, -139.5824f);
                            mpOffset.iFov = 31;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-297.7531f, 6331.1738f, 32.7564f);
                            mpOffset.vRot = new(2.2478f, 0.0379f, 136.6248f);
                            mpOffset.iFov = 23;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-12.5197f, 6554.6187f, 33.5394f);
                            mpOffset.vRot = new(-1.3467f, 0.0000f, 46.8774f);
                            mpOffset.iFov = 27;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1903.2606f, 3774.3770f, 33.0854f);
                            mpOffset.vRot = new(-0.5878f, 0.0308f, 32.3490f);
                            mpOffset.iFov = 18;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1662.2240f, 4772.8242f, 42.8465f);
                            mpOffset.vRot = new(-3.1724f, 0.0000f, 0.7520f);
                            mpOffset.iFov = 17;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-174.2884f, 501.3120f, 137.950f);
                            mpOffset.vRot = new(-1.2027f, 0.0156f, 7.0754f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(117.6510f, 563.5542f, 184.9347f);
                            mpOffset.vRot = new(-17.7276f, 0.0362f, -77.4043f);
                            mpOffset.iFov = 30;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(345.9495f, 441.9537f, 148.1468f);
                            mpOffset.vRot = new(-4.1549f, -0.0894f, -172.1909f);
                            mpOffset.iFov = 46;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-753.3809f, 622.2144f, 142.9006f);
                            mpOffset.vRot = new(3.1702f, 0.0623f, 167.7499f);
                            mpOffset.iFov = 40;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-687.0825f, 595.0414f, 144.1755f);
                            mpOffset.vRot = new(0.5655f, -0.0023f, -61.8951f);
                            mpOffset.iFov = 52;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-556.8793f, 664.4926f, 145.5217f);
                            mpOffset.vRot = new(0.7323f, -0.1035f, 109.3282f);
                            mpOffset.iFov = 33;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-731.8242f, 593.0071f, 143.0652f);
                            mpOffset.vRot = new(-12.4002f, 0.0292f, 68.9178f);
                            mpOffset.iFov = 37;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-851.2979f, 695.7601f, 149.4358f);
                            mpOffset.vRot = new(-5.2567f, -0.0731f, 115.5629f);
                            mpOffset.iFov = 39;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1292.7130f, 454.9815f, 97.8919f);
                            mpOffset.vRot = new(3.2630f, 0.0350f, 130.6120f);
                            mpOffset.iFov = 36;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(371.7109f, 430.7896f, 146.0474f);
                            mpOffset.vRot = new(-0.2850f, -0.0000f, -136.6176f);
                            mpOffset.iFov = 24;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            if (bWalkIn)
                            {
                                mpOffset.vLoc = new(-1579.5897f, -556.4324f, 35.5136f);
                                mpOffset.vRot = new(-0.6030f, -0.0228f, 127.9377f);
                                mpOffset.iFov = 20;
                            }
                            else
                            {
                                mpOffset.vLoc = new(-1580.4760f, -557.3078f, 35.5376f);
                                mpOffset.vRot = new(-4.3653f, -0.0815f, 129.6542f);
                                mpOffset.iFov = 24;
                            }
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1558.7742f, -567.9628f, 114.6745f);
                            mpOffset.vRot = new(0.1791f, 0.0687f, 126.7500f);
                            mpOffset.iFov = 27;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1372.0757f, -500.8174f, 33.6383f);
                            mpOffset.vRot = new(-1.2811f, -0.0249f, -126.7845f);
                            mpOffset.iFov = 43;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-1368.5631f, -473.6149f, 85.2461f);
                            mpOffset.vRot = new(-13.9712f, 0.0000f, 37.0980f);
                            mpOffset.iFov = 42;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-119.2171f, -609.3939f, 36.8558f);
                            mpOffset.vRot = new(-3.0867f, 0.0696f, -19.2852f);
                            mpOffset.iFov = 16;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-130.8887f, -587.8684f, 202.2298f);
                            mpOffset.vRot = new(-0.0352f, -0.0257f, 53.5323f);
                            mpOffset.iFov = 18;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-73.2211f, -842.1545f, 41.2237f);
                            mpOffset.vRot = new(-5.6972f, 1.3887f, -48.4721f);
                            mpOffset.iFov = 22;
                            break;
                        case 1:
                            mpOffset.vLoc = new(-69.0923f, -825.2212f, 322.6436f);
                            mpOffset.vRot = new(-12.4604f, 0.1103f, -23.9435f);
                            mpOffset.iFov = 20;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(254.943878f, -1807.320557f, 27.628801f);
                            mpOffset.vRot = new(-0.252823f, -0.200463f, 145.110504f);
                            mpOffset.iFov = 24;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1473.231689f, -921.663879f, 10.423450f);
                            mpOffset.vRot = new(-2.428516f, -0.032469f, -22.644066f);
                            mpOffset.iFov = 43;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(36.916344f, -1030.839111f, 30.251883f);
                            mpOffset.vRot = new(-4.955771f, -0.072793f, -23.517040f);
                            mpOffset.iFov = 34;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(47.483208f, 2788.058105f, 58.452034f);
                            mpOffset.vRot = new(-1.609905f, -0.050702f, 26.164320f);
                            mpOffset.iFov = 38;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-343.997772f, 6067.128418f, 32.256989f);
                            mpOffset.vRot = new(-6.119500f, 0.116859f, -129.049713f);
                            mpOffset.iFov = 18;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(1734.820190f, 3709.049072f, 34.539253f);
                            mpOffset.vRot = new(1.492825f, -0.085494f, -94.461479f);
                            mpOffset.iFov = 21;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(941.205811f, -1458.384888f, 31.990330f);
                            mpOffset.vRot = new(-2.881305f, 0.069815f, 111.231911f);
                            mpOffset.iFov = 39;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(187.246552f, 309.167206f, 106.126678f);
                            mpOffset.vRot = new(-4.899244f, 0.092152f, -80.156792f);
                            mpOffset.iFov = 21;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-24.885988f, -190.964523f, 53.101295f);
                            mpOffset.vRot = new(-10.212523f, 0.071275f, -93.717575f);
                            mpOffset.iFov = 31;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(2472.763184f, 4112.579102f, 38.881607f);
                            mpOffset.vRot = new(-7.489403f, 0.048921f, 161.973495f);
                            mpOffset.iFov = 25;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-40.147297f, 6419.259277f, 32.262348f);
                            mpOffset.vRot = new(-1.430565f, 0.008784f, -37.568604f);
                            mpOffset.iFov = 31;
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset.vLoc = new(-1133.160278f, -1567.434326f, 5.008084f);
                            mpOffset.vRot = new(-0.669292f, -0.082458f, 127.098763f);
                            mpOffset.iFov = 27;
                            break;
                    }
                    break;
            }
        }
        public static void GetTransitionEnterSceneDetails(BuildingsEnum iBuilding, ref Position mpOffset, int iEntrance = -1)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    mpOffset = new(-776.765f, 313.492f, 84.701f, 0.000f, 0.000f, 180.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    mpOffset = new(-261.150f, -969.550f, 30.163f, 0.000f, 0.000f, -142.280f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    mpOffset = new(-1442.754f, -543.987f, 33.538f, 0.000f, 0.000f, -145.200f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    mpOffset = new(-913.188f, -455.375f, 38.363f, 0.000f, 0.000f, 117.640f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    mpOffset = new(-47.663f, -588.20f, 36.925f, 0.000f, 0.000f, 69.840f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    mpOffset = new(-932.225f, -384.075f, 37.9612f, 0.000f, 0.000f, 116.640f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    mpOffset = new(-614.235f, 38.350f, 42.595f, 0.000f, 0.000f, 180f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    mpOffset = new(286.125f, -161.313f, 63.401f, 0.000f, 0.000f, 70.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    mpOffset = new(3.833f, 37.504f, 70.310f, 0.000f, 0.000f, 160.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    mpOffset = new(9.311f, 81.125f, 77.209f, 0.000f, 0.000f, -20.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    mpOffset = new(-512.254f, 107.765f, 62.574f, 0.000f, 0.000f, 7.995f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    mpOffset = new(-197.815f, 85.312f, 68.453f, 0.000f, 0.000f, -12.200f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    mpOffset = new(-627.344f, 169.129f, 59.847f, -0.300f, 0.000f, 90.700f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    mpOffset = new(-968.813f, -1431.475f, 6.787f, 0.100f, 0.000f, 110.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    mpOffset = new(-832.213f, -862.966f, 19.645f, 0.080f, 0.000f, 0.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    mpOffset = new(-763.900f, -753.162f, 26.612f, 0.000f, 0.000f, -89.900f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    mpOffset = new(-40.513f, -58.813f, 62.862f, -0.400f, -0.000f, -106.350f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    mpOffset = new(-200.312f, 186.200f, 79.217f, 0.000f, 0.000f, 90.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    mpOffset = new(-811.737f, -980.688f, 13.288f, 0.000f, 0.000f, 125.300f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    mpOffset = new(-662.480f, -854.513f, 23.248f, -0.300f, -0.000f, -179.250f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    mpOffset = new(-1533.110f, -327.123f, 46.921f, 0.100f, -0.000f, 45.360f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    mpOffset = new(-1564.363f, -405.504f, 41.165f, 0.000f, 0.000f, -129.900f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    mpOffset = new(-1606.232f, -433.376f, 39.195f, 0.000f, 0.000f, 50.000f);
                    break;
                //DLC Independence Day
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    mpOffset = new(-1404.915f, 526.914f, 122.857f, 0.000f, 0.000f, 90.500f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    mpOffset = new(1336.639f, -1578.502f, 53.500f, -0.300f, 0.000f, 37.700f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    mpOffset = new(-105.935f, 6528.175f, 29.465f, 0.000f, 0.000f, -45.100f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    mpOffset = new(-302.313f, 6326.367f, 31.847f, 0.000f, 0.000f, 42.500f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    mpOffset = new(-15.637f, 6557.038f, 32.225f, 0.000f, 0.000f, -45.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    mpOffset = new(1898.564f, 3781.471f, 31.862f, 0.000f, 0.000f, -60.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    mpOffset = new(1661.691f, 4776.062f, 41.275f, -0.200f, 0.000f, -82.200f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    mpOffset = new(119.346f, 563.179f, 182.979f, 0.000f, -0.000f, -180.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    mpOffset = new(-174.255f, 502.569f, 136.425f, 0.000f, 0.000f, -78.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    mpOffset = new(345.894f, 440.306f, 146.759f, 0.000f, 0.000f, 117.5f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    mpOffset = new(-753.600f, 619.931f, 141.845f, 0.000f, 0.000f, -71.0f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    mpOffset = new(-685.647f, 595.773f, 143.065f, 0.000f, 0.000f, 220.520f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    mpOffset = new(-559.697f, 663.578f, 144.217f, 0.000f, -0.000f, 165.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    mpOffset = new(-733.287f, 593.431f, 141.256f, 0.000f, 0.000f, -29.75f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    mpOffset = new(-852.969f, 694.765f, 147.930f, 0.000f, 0.000f, 4.250f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    mpOffset = new(-1294.267f, 453.888f, 96.559f, 0.000f, -0.000f, 0.000f);
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    mpOffset = new(374.368f, 427.691f, 144.733f, 0.000f, -0.000f, -102.720f);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1580.421f, -558.301f, 33.973f, 0.000f, -0.000f, -143.640f);
                            break;
                        case 1:
                            mpOffset = new(-1561.088f, -569.806f, 113.449f, 0.000f, -0.000f, -145.800f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1370.342f, -502.459f, 32.170f, 0.000f, 0.000f, -54.000f);
                            break;
                        case 1:
                            mpOffset = new(-1369.856f, -472.284f, 83.457f, 0.000f, 0.000f, -56.000f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-117.950f, -604.900f, 35.504f, 0.000f, -0.000f, -109.500f);
                            break;
                        case 1:
                            mpOffset = new(-135.279f, -584.869f, 200.746f, 0.000f, 0.000f, -50.250f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-70.945f, -839.588f, 39.602f, 0.000f, -0.000f, -3.6f);
                            break;
                        case 1:
                            mpOffset = new(-67.850f, -821.000f, 320.300f, 0.000f, -0.000f, 71.5773f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(253.86f, -1809.132f, 26.154f, 0.0f, 0.0f, -132.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1472.1595f, -919.8719f, 9.0250f, 0.0f, 0.0f, 230.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(38.108315f, -1029.571411f, 28.5669f, 0.0f, 0.0f, 67.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(46.8286f, 2789.5867f, 56.8783f, 0.0f, 0.0f, 322.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-342.360f, 6065.496f, 30.509f, 0.0f, 0.0f, 135.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(1738.004f, 3708.644f, 33.136f, 0.0f, 0.0f, -159.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(939.6199f, -1458.8795f, 30.4678f, 0.0f, 0.0f, 180.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(189.78f, 309.55f, 104.39f, 0.0f, 0.0f, 5.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-22.05f, -191.6f, 51.35f, 0.0f, 0.0f, -20.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(2472.108f, 4110.74f, 37.065f, 0.0f, 0.0f, -112.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-39.385f, 6420.715f, 30.683f, 0.0f, 0.0f, 45.0f);
                            break;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    switch (iEntrance)
                    {
                        case 0:
                            mpOffset = new(-1135.159f, -1568.442f, 3.408f, 0.0f, 0.0f, 35.0f);
                            break;
                    }
                    break;
            }
        }
        internal static void GetGarageDetailsForSize(ref PropertyData propertyDetails, int iGarageSize)
        {
            switch ((GarageSize)iGarageSize)
            {
                case GarageSize.PROP_GARAGE_SIZE_2:
                    propertyDetails.GarageSize = iGarageSize;
                    propertyDetails.Garage.InPlayerLoc = new(173.1406f, -1008.0995f, -99.9999f);
                    propertyDetails.Garage.InPlayerHeading = 343.2760f;
                    propertyDetails.Garage.FromHousePlayerLoc = new(178.4598f, -1006.1571f, -99.9999f);
                    propertyDetails.Garage.FromHousePlayerHeading = 98.8495f;
                    propertyDetails.Garage.CarLoc[0] = new(171.4693f, -1003.6766f, -99.9999f);
                    propertyDetails.Garage.CarHeading[0] = 178.4085f;
                    propertyDetails.Garage.CarLoc[1] = new(175.2003f, -1003.8159f, -99.9999f);
                    propertyDetails.Garage.CarHeading[1] = 178.4085f;
                    propertyDetails.Garage.CarLoc[10] = new(170.7203f, -1007.5126f, -99.9999f);
                    propertyDetails.Garage.CarHeading[10] = 255.2687f;
                    propertyDetails.Garage.AutoExitLoc.Pos1 = new(172.860016f, -1007.823486f, -100.249924f);
                    propertyDetails.Garage.AutoExitLoc.Pos2 = new(172.851334f, -1008.995361f, -96.249924f);
                    propertyDetails.Garage.AutoExitLoc.Width = 6.250000f;
                    propertyDetails.Garage.AutoExitLoc.EnterHeading = 188.1891f;
                    propertyDetails.Garage.cctv.Pos = new(177.9457f, -1008.6973f, -97.2447f);
                    propertyDetails.Garage.cctv.Rot = new(-25.3590f, 2.3332f, 44.1740f);
                    propertyDetails.Garage.cctv.FOV = 50.0f;
                    propertyDetails.Garage.MidPoint = new(172.7787f, -1003.2102f, -99.9999f);
                    GetMpGarageInteriorBounds(ref propertyDetails.Garage.Bounds, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Garage.BuzzerLoc = new(177.9406f, -1008.5942f, -97.7757f);
                    propertyDetails.Garage.AutoExitToApart.Pos1 = new(179.066132f, -1003.423950f, -100.062248f);
                    propertyDetails.Garage.AutoExitToApart.Pos2 = new(179.08899f, -1006.22290f, -97.249947f);
                    propertyDetails.Garage.AutoExitToApart.Width = 1.750000f;
                    propertyDetails.Garage.AutoExitToApart.EnterHeading = 354.2478f;
                    propertyDetails.Garage.NumBikeSlots = 1;
                    propertyDetails.Garage.DoorBlockerLoc = new(179.130f, -1003.859f, -98.766f);
                    propertyDetails.Garage.DoorBlockerRot = new(90f, 0f, 0);
                    propertyDetails.Garage.SafeCoronaLoc = new(173.2590f, -1006.0999f, -99.9999f);
                    break;
                case GarageSize.PROP_GARAGE_SIZE_6:
                    propertyDetails.GarageSize = iGarageSize;
                    propertyDetails.Garage.InPlayerLoc = new(206.1946f, -1006.4241f, -99.999f);
                    propertyDetails.Garage.InPlayerHeading = 11.2220f;
                    propertyDetails.Garage.FromHousePlayerLoc = new(206.7599f, -999.1566f, -100.0000f);
                    propertyDetails.Garage.FromHousePlayerHeading = 84.8064f;
                    propertyDetails.Garage.CarLoc[0] = new(193.1573f, -1003.3317f, -99.9999f);
                    propertyDetails.Garage.CarHeading[0] = 0.0168f;
                    propertyDetails.Garage.CarLoc[1] = new(196.6948f, -1003.3317f, -99.9999f);
                    propertyDetails.Garage.CarHeading[1] = 0.0168f;
                    propertyDetails.Garage.CarLoc[2] = new(200.1865f, -1003.3317f, -99.9999f);
                    propertyDetails.Garage.CarHeading[2] = 0.0168f;
                    propertyDetails.Garage.CarLoc[3] = new(203.8078f, -1003.3317f, -99.9999f);
                    propertyDetails.Garage.CarHeading[3] = 0.0168f;
                    propertyDetails.Garage.CarLoc[4] = new(193.5414f, -997.6031f, -99.9999f);
                    propertyDetails.Garage.CarHeading[4] = 211.0307f;
                    propertyDetails.Garage.CarLoc[5] = new(198.0267f, -997.2191f, -99.9999f);
                    propertyDetails.Garage.CarHeading[5] = 206.5741f;
                    propertyDetails.Garage.CarLoc[10] = new(201.0628f, -995.7986f, -99.9999f);
                    propertyDetails.Garage.CarHeading[10] = 191.8480f;
                    propertyDetails.Garage.AutoExitLoc.Pos1 = new(198.391479f, -1007.090637f, -100.249962f);
                    propertyDetails.Garage.AutoExitLoc.Pos2 = new(198.405197f, -1008.852234f, -96.250183f);
                    propertyDetails.Garage.AutoExitLoc.Width = 13.750000f;
                    propertyDetails.Garage.AutoExitLoc.EnterHeading = 186.5288f;
                    propertyDetails.Garage.cctv.Pos = new(190.7409f, -1007.6721f, -97.4883f);
                    propertyDetails.Garage.cctv.Rot = new(-21.4541f, -6.6235f, -45.6924f);
                    propertyDetails.Garage.cctv.FOV = 50.0f;
                    propertyDetails.Garage.MidPoint = new(198.6071f, -1000.5364f, -100.0000f);
                    GetMpGarageInteriorBounds(ref propertyDetails.Garage.Bounds, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Garage.BuzzerLoc = new(207.1707f, -1007.9170f, -97.6376f);
                    propertyDetails.Garage.AutoExitToApart.Pos1 = new(207.886658f, -999.074951f, -100.249962f);
                    propertyDetails.Garage.AutoExitToApart.Pos2 = new(207.093582f, -999.093872f, -97.499962f);
                    propertyDetails.Garage.AutoExitToApart.Width = 1.750000f;
                    propertyDetails.Garage.AutoExitToApart.EnterHeading = 272.9543f;
                    propertyDetails.Garage.NumBikeSlots = 2;
                    propertyDetails.Garage.DoorBlockerLoc = new(208.690f, -99.051f, -99.00f);
                    propertyDetails.Garage.DoorBlockerRot = new(90f, 0f, 0f);
                    propertyDetails.Garage.SafeCoronaLoc = new(203.2500f, -997.1685f, -99.999f);
                    break;
                case GarageSize.PROP_GARAGE_SIZE_10:
                    propertyDetails.GarageSize = iGarageSize;
                    propertyDetails.Garage.InPlayerLoc = new(229.2159f, -1005.1038f, -99.9999f);
                    propertyDetails.Garage.InPlayerHeading = 352.7715f;
                    propertyDetails.Garage.FromHousePlayerLoc = new(237.6044f, -1004.7485f, -99.9999f);
                    propertyDetails.Garage.FromHousePlayerHeading = 80.2776f;
                    propertyDetails.Garage.CarLoc[0] = new(224.3354f, -980.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[0] = 241.3985f;
                    propertyDetails.Garage.CarLoc[1] = new(224.3354f, -986.3477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[1] = 241.3985f;
                    propertyDetails.Garage.CarLoc[2] = new(224.3354f, -991.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[2] = 241.3985f;
                    propertyDetails.Garage.CarLoc[3] = new(224.3354f, -997.3477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[3] = 241.3985f;
                    propertyDetails.Garage.CarLoc[4] = new(224.3354f, -1002.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[4] = 241.3985f;
                    propertyDetails.Garage.CarLoc[5] = new(232.6471f, -980.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[5] = 116.3088f;
                    propertyDetails.Garage.CarLoc[6] = new(232.6471f, -986.3477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[6] = 116.3088f;
                    propertyDetails.Garage.CarLoc[7] = new(232.6471f, -991.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[7] = 116.3088f;
                    propertyDetails.Garage.CarLoc[8] = new(232.6471f, -997.3477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[8] = 116.3088f;
                    propertyDetails.Garage.CarLoc[9] = new(232.6471f, -1002.8477f, -99.9999f);
                    propertyDetails.Garage.CarHeading[9] = 116.3088f;
                    propertyDetails.Garage.CarLoc[10] = new(223.4140f, -977.0094f, -99.9999f);
                    propertyDetails.Garage.CarHeading[10] = 259.4501f;
                    propertyDetails.Garage.AutoExitLoc.Pos1 = new(228.408340f, -1006.032471f, -100.249924f);
                    propertyDetails.Garage.AutoExitLoc.Pos2 = new(228.339630f, -1011.415283f, -95.777344f);
                    propertyDetails.Garage.AutoExitLoc.Width = 13.750000f;
                    propertyDetails.Garage.AutoExitLoc.EnterHeading = 177.8521f;
                    propertyDetails.Garage.cctv.Pos = new(228.2770f, -1007.0140f, -96.7812f);
                    propertyDetails.Garage.cctv.Rot = new(-22.3788f, -1.5101f, -0.1088f);
                    propertyDetails.Garage.cctv.FOV = 50.0f;
                    propertyDetails.Garage.MidPoint = new(227.8602f, -991.1093f, -99.9999f);
                    GetMpGarageInteriorBounds(ref propertyDetails.Garage.Bounds, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Garage.BuzzerLoc = new(237.4485f, -1006.8026f, -98.3606f);
                    propertyDetails.Garage.AutoExitToApart.Pos1 = new(237.951736f, -1004.842102f, -100.249924f);
                    propertyDetails.Garage.AutoExitToApart.Pos2 = new(239.128143f, -1004.827759f, -97.264351f);
                    propertyDetails.Garage.AutoExitToApart.Width = 2.000000f;
                    propertyDetails.Garage.AutoExitToApart.EnterHeading = 260.1318f;
                    propertyDetails.Garage.NumBikeSlots = 3;
                    propertyDetails.Garage.DoorBlockerLoc = new(239.778f, -1004.827f, -98.560f);
                    propertyDetails.Garage.DoorBlockerRot = new(90f, 0f, 0f);
                    propertyDetails.Garage.SafeCoronaLoc = new(228.8723f, -978.2864f, -99.9999f);
                    break;
            }
        }
        internal static MPPropertyNonAxis GetMpGarageInteriorBounds(ref MPPropertyNonAxis Bounds, int iGarageSize)
        {
            switch ((GarageSize)iGarageSize)
            {
                case GarageSize.PROP_GARAGE_SIZE_2:
                    Bounds.Pos1 = new(175.043396f, -998.796509f, -100.225586f);
                    Bounds.Pos2 = new(175.087845f, -1009.003601f, -95.999924f);
                    Bounds.Width = 14.000000f;
                    break;
                case GarageSize.PROP_GARAGE_SIZE_6:
                    Bounds.Pos1 = new(212.908401f, -999.677551f, -99.999962f);
                    Bounds.Pos2 = new(189.684357f, -1000.067993f, -95.250702f);
                    Bounds.Width = 16.750000f;
                    break;
                case GarageSize.PROP_GARAGE_SIZE_10:
                    Bounds.Pos1 = new(230.009445f, -1009.123535f, -100.653893f);
                    Bounds.Pos2 = new(230.593887f, -964.021973f, -94.536179f);
                    Bounds.Width = 23.500000f;
                    break;
            }
            return Bounds;
        }
        internal static void GetHouseInteriorDetails(ref PropertyData propertyDetails, PropertiesEnum iProperty)
        {
            Position tempStruct = new Position();
            PropertiesEnum iBaseProperty = (PropertiesEnum)(-1);
            switch (iProperty)
            {
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_HIGH_APT_5:
                case PropertiesEnum.PROPERTY_HIGH_APT_6:
                case PropertiesEnum.PROPERTY_HIGH_APT_7:
                case PropertiesEnum.PROPERTY_HIGH_APT_8:
                case PropertiesEnum.PROPERTY_HIGH_APT_9:
                case PropertiesEnum.PROPERTY_HIGH_APT_10:
                case PropertiesEnum.PROPERTY_HIGH_APT_11:
                case PropertiesEnum.PROPERTY_HIGH_APT_12:
                case PropertiesEnum.PROPERTY_HIGH_APT_13:
                case PropertiesEnum.PROPERTY_HIGH_APT_14:
                case PropertiesEnum.PROPERTY_HIGH_APT_15:
                case PropertiesEnum.PROPERTY_HIGH_APT_16:
                case PropertiesEnum.PROPERTY_HIGH_APT_17:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_5:
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                case PropertiesEnum.PROPERTY_OFFICE_3:
                case PropertiesEnum.PROPERTY_OFFICE_4:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1:
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2:
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3:
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1:
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2:
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3:
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2:
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3:
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1:
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2:
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3:
                    iBaseProperty = GetBasePropertyFromProperty(iProperty);
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW1_A, ref tempStruct, iBaseProperty);
                    propertyDetails.window[0].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW1_B, ref tempStruct, iBaseProperty);
                    propertyDetails.window[0].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW1_SPAWN, ref tempStruct, iBaseProperty);
                    propertyDetails.window[0].SpawnPoint = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW2_A, ref tempStruct, iBaseProperty);
                    propertyDetails.window[1].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW2_B, ref tempStruct, iBaseProperty);
                    propertyDetails.window[1].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW1_SPAWN, ref tempStruct, iBaseProperty);
                    propertyDetails.window[0].SpawnPoint = tempStruct.ToVector3;
                    propertyDetails.window[0].PedRadius = tempStruct.ToRotationVector.X;
                    propertyDetails.window[0].VehRadius = tempStruct.ToRotationVector.Y;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_WINDOW2_SPAWN, ref tempStruct, iBaseProperty);
                    propertyDetails.window[1].SpawnPoint = tempStruct.ToVector3;
                    propertyDetails.window[1].PedRadius = tempStruct.ToRotationVector.X;
                    propertyDetails.window[1].VehRadius = tempStruct.ToRotationVector.Y;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_ENTRY_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.Entrance[0].InPlayerLoc = tempStruct.ToVector3;
                    propertyDetails.Entrance[0].InPlayerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR1, ref tempStruct, iBaseProperty);
                    propertyDetails.House.Exits[0].autoExitLoc.Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.Exits[0].autoExitLoc.Pos2 = tempStruct.ToVector3;
                    if (IsPropertyCustomApartment(iProperty) || IsPropertyStiltApartment(iProperty))
                        propertyDetails.House.Exits[0].autoExitLoc.Width = 1.000000f;
                    else if (IsPropertyClubhouse(iProperty, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A))
                        propertyDetails.House.Exits[0].autoExitLoc.Width = 2.0f;
                    else if (IsPropertyClubhouse(iProperty, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B))
                        propertyDetails.House.Exits[0].autoExitLoc.Width = 2.25f;
                    else
                        propertyDetails.House.Exits[0].autoExitLoc.Width = 3.500000f;
                    propertyDetails.House.Exits[0].autoExitLoc.EnterHeading = tempStruct.Yaw;
                    if (IsPropertyOffice(iProperty))
                    {
                        GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT2_DOOR1, ref tempStruct, iBaseProperty);
                        propertyDetails.House.Exits[1].autoExitLoc.Pos1 = tempStruct.ToVector3;
                        GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT2_DOOR2, ref tempStruct, iBaseProperty);
                        propertyDetails.House.Exits[1].autoExitLoc.Pos2 = tempStruct.ToVector3;
                        propertyDetails.House.Exits[1].autoExitLoc.Width = 3.500000f;
                        propertyDetails.House.Exits[1].autoExitLoc.EnterHeading = tempStruct.Yaw;
                    }
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLAN_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.HeistPlanningLocate = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.HeistCameraPos = tempStruct.ToVector3;
                    propertyDetails.House.HeistCameraRot = tempStruct.ToRotationVector;
                    propertyDetails.House.HeistFOV = 62.8385f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_MIDPOINT, ref tempStruct, iBaseProperty);
                    propertyDetails.House.MidPoint = tempStruct.ToVector3;
                    GetMpHouseInteriorBounds(ref propertyDetails.House.Bounds, iProperty);
                    if (GetBasePropertyFromProperty(iProperty) == PropertiesEnum.PROPERTY_YACHT_APT_1_BASE)
                    {
                        GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_CIRCLE_BOUNDS_YACHT_BAR, ref tempStruct, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
                        propertyDetails.House.CircleBoundRadius = tempStruct.Yaw;
                        propertyDetails.House.CircleBoundPosition = tempStruct.ToVector3;
                    }
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BUZZER, ref tempStruct, iBaseProperty);
                    propertyDetails.House.BuzzerLoc = tempStruct.ToVector3;
                    GetPropertyWardrobeLocation(iProperty, ref propertyDetails.House.WardrobeLoc, ref propertyDetails.House.WardrobeHeading, -1);
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerRot = tempStruct.Yaw;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].FranklinBong = true;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].Cam2Vec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].Cam2Rot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_TRIGGER_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BONG_TRIGGER_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerRot = tempStruct.Yaw;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerSizeVec = new(1.0f);
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_FRAME_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaAVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathAreaWidth = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerPos = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathroomDoorArea = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BATHROOM_DOOR, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorRot = tempStruct.ToRotationVector;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].TriggerSizeVec = new(1.0f);
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].LookCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].LookCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].AboveCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].AboveCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].TurnOffCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].TurnOffCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ShowerHeadVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ShowerHeadRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].SteamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].SteamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].AreaAVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].BathAreaWidth = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_2, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ExitShowerPos = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].ExitShowerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].BathroomDoorArea = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BATHROOM_DOOR, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].DoorVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_2].DoorRot = tempStruct.ToRotationVector;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].TriggerSizeVec = new(1.0f);
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].LookCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].LookCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].AboveCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].AboveCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].TurnOffCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].TurnOffCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ShowerHeadVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ShowerHeadRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].SteamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].SteamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].AreaAVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].BathAreaWidth = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_3, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ExitShowerPos = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].ExitShowerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].BathroomDoorArea = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BATHROOM_DOOR, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].DoorVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER_3].DoorRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA0, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].ShowerHeadVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA1, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].SteamVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHDEST, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].DoorVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_IDLE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].AreaAVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PDANCE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].LookCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].LookCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SDANCE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].AboveCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_STRIP].AboveCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_GLASS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].GlassLoc = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_GLASS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].GlassLoc = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_GLASS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].GlassLoc = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKY_NEW].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHEATGRS].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].TriggerVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].TriggerRot = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].CamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].CamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_EXIT_CAM, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].ExitCamVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].ExitCamRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_SCENE, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].SceneVec = tempStruct.ToVector3;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].SceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_AREA_A, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].AreaAVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WINE_AREA_B, ref tempStruct, iBaseProperty);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WINE].AreaBVec = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_START_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerPos = tempStruct.ToVector3;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_INSIDE_END_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDPos = tempStruct.ToVector3;
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_END_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDPos = tempStruct.ToVector3;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.ExitScene.SyncedSceneLoc = tempStruct.ToVector3;
                    propertyDetails.House.ExitScene.SyncedSceneRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_PLAYER_START_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.ExitScene.PlayerPos = tempStruct.ToVector3;
                    propertyDetails.House.ExitScene.PlayerHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_DOOR_BLOCKER, ref tempStruct, iBaseProperty);
                    propertyDetails.House.DoorBlockerLoc = tempStruct.ToVector3;
                    propertyDetails.House.DoorBlockerRot = tempStruct.ToRotationVector;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_STRIPPER_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.BuzzerEnter.OutsideStripperPos = tempStruct.ToVector3;
                    propertyDetails.House.BuzzerEnter.OutsideStripperHeading = tempStruct.Yaw;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SAFE_CORONA_COORDS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.SafeCoronaLoc = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_BOARD_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.BoardPosition = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_MAP_LOC, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.MapPosition = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_BOARD, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Board = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_DESCRIPTION, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Desc = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_MAP, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Map = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_MAP_TUTORIAL, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Map = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_OVERVIEW, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Overview = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_STATS, ref tempStruct, iBaseProperty);
                    propertyDetails.House.heistPlanning.CamPos_Stat = tempStruct.ToVector3;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_1:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_2:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_3:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_4:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_5:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_6:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_7:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_8:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_9:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4:
                    propertyDetails.Entrance[0].InPlayerLoc = new(347.3975f, -1001.4458f, -100.1982f);
                    propertyDetails.Entrance[0].InPlayerHeading = 4.8810f;
                    propertyDetails.House.Exits[0].autoExitLoc.Pos1 = new(347.089661f, -1002.553955f, -96.946182f);
                    propertyDetails.House.Exits[0].autoExitLoc.Pos2 = new(347.086090f, -1003.800354f, -100.886047f);
                    propertyDetails.House.Exits[0].autoExitLoc.Width = 2.500000f;
                    propertyDetails.House.Exits[0].autoExitLoc.EnterHeading = 176.3655f;
                    propertyDetails.House.HeistPlanningLocate = new(338.7102f, -1002.2359f, -100.2119f);
                    propertyDetails.House.HeistCameraPos = new(342.9461f, -999.7300f, -98.0236f);
                    propertyDetails.House.HeistCameraRot = new(0f, 0f, 37.7289f);
                    propertyDetails.House.HeistFOV = 50f;
                    propertyDetails.House.MidPoint = new(348.1320f, -997.2031f, -100.1741f);
                    GetMpHouseInteriorBounds(ref propertyDetails.House.Bounds, iProperty); propertyDetails.House.BuzzerLoc = new(346.4337f, -1002.8267f, -97.7941f);
                    GetPropertyWardrobeLocation(iProperty, ref propertyDetails.House.WardrobeLoc, ref propertyDetails.House.WardrobeHeading, -1);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerVec = new(349.9853f, -997.8344f, -99.1952f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerRot = 285.4278f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].TriggerVec = new(343.8862f, -1002.2512f, -100.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].TriggerRot = 277.1949f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].CamVec = new(344.6448f, -1003.7554f, -98.7875f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].CamRot = new(-2.7747f, -1.6005f, 17.2117f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].Cam2Vec = new(344.6427f, -1003.9994f, -98.7826f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].Cam2Rot = new(-0.1925f, -1.5516f, 18.2611f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].ExitCamVec = new(342.3470f, -1003.1187f, -97.9876f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].ExitCamRot = new(-27.0125f, -1.6193f, -66.8063f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].SceneVec = new Vector3(344.482f, -1002.380f, -99.095f) + new Vector3(0.0651f, 0.066f, 0.0058f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].SceneRot = new(0.0f, 0.0f, -129.960f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].AreaAVec = new(344.6000f, -1002.3000f, -100.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].AreaBVec = new(343.5000f, -1002.3000f, -98.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].GlassLoc = new(341.9066f, -1001.6698f, -99.2330f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerVec = new(339.6112f, -996.2951f, -99.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerRot = 10.80f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneVec = new(339.435f, -995.849f, -100.196f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneRot = new(0.000f, 0.000f, -169.200f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamVec = new(348.8181f, -993.7432f, -99.2265f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamRot = new(-9.5524f, 0.0000f, -143.8996f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaAVec = new(339.388062f, -996.723328f, -100.196220f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaBVec = new(340.258545f, -996.263855f, -98.196220f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].FranklinBong = false;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerVec = new(347.2369f, -995.4249f, -99.1069f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerRot = 91.0909f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerSizeVec = new(0.6f, 0.6f, 0.6f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneVec = new(347.3f, -994.85f, -99.966f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamVec = new(348.0795f, -995.1061f, -98.5370f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamRot = new(-3.7658f, 0.0129f, 117.3778f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamVec = new(347.3852f, -995.6655f, -98.3721f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamRot = new(28.8622f, 0.0506f, 37.7639f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamVec = new(348.0655f, -995.4604f, -98.5769f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamRot = new(-3.3764f, 0.0015f, 90.1577f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamVec = new(347.4615f, -995.3900f, -97.7124f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamRot = new(-42.5076f, 0.0833f, 89.4140f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamVec = new(347.4615f, -995.3900f, -97.7124f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamRot = new(-42.5076f, 0.0833f, 89.4140f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamVec = new(346.4644f, -992.7673f, -98.5189f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamRot = new(-19.2697f, -0.0001f, -146.3524f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadVec = new(346.9f, -995.1795f, -97.85f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadRot = new(-45.0f, 0.0f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamVec = new(346.9f, -995.1795f, -97.85f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamRot = new(-45.0f, 0.0f, 90.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaAVec = new(346.2500f, -994.4f, -100.200f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaBVec = new(348.2500f, -994.4f, -97.5000f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathAreaWidth = 5.5f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorVec = new(348.2157f, -993.1122f, -99.0430f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorRot = new(0.0f, 0.0f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerPos = new(347.7391f, -994.5944f, -100.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerHeading = 9.7212f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathroomDoorArea = new(348.161530f, -993.473450f, -100.696220f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerVec = new(342.6041f, -1001.5839f, -100.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerRot = 88.0775f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneVec = new Vector3(341.900f, -1001.646f, -99.250f) + new Vector3(0.0066f, -0.0238f, -0.0027f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamVec = new(341.3749f, -1002.8832f, -98.9319f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamRot = new(-2.0018f, -0.0676f, -25.1089f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].ExitCamVec = new(341.3749f, -1002.8832f, -98.9319f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].ExitCamRot = new(-2.0018f, -0.0676f, -25.1089f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].AreaAVec = new(342.0000f, -1001.5486f, -100.1962f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].AreaBVec = new(343.0000f, -1001.5486f, -98.1962f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(346.7972f, -1004.4448f, -100.1919f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.0f, 0.0f, 180.0f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerPos = new(346.7960f, -1002.2325f, -99.1900f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerHeading = 178.66f;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerPos = new(346.5500f, -1006.2598f, -100.1962f);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerHeading = 359.8999f;
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDPos = new(346.2292f, -1000.9788f, -99.1900f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDHeading = -132.94f;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDPos = new(347.2401f, -1001.8555f, -99.1900f);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDHeading = 51.24f;
                    propertyDetails.House.DoorBlockerLoc = new(346.480f, -1004.03f, -98.810f);
                    propertyDetails.House.DoorBlockerRot = new(90f, 0f, 0f);
                    propertyDetails.House.SafeCoronaLoc = new(340.6887f, -998.2258f, -100.1962f);
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_1:
                case PropertiesEnum.PROPERTY_LOW_APT_2:
                case PropertiesEnum.PROPERTY_LOW_APT_3:
                case PropertiesEnum.PROPERTY_LOW_APT_4:
                case PropertiesEnum.PROPERTY_LOW_APT_5:
                case PropertiesEnum.PROPERTY_LOW_APT_6:
                case PropertiesEnum.PROPERTY_LOW_APT_7:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_1:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_2:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_3:
                    propertyDetails.Entrance[0].InPlayerLoc = new(264.5677f, -1000.6248f, -100.0086f);
                    propertyDetails.Entrance[0].InPlayerHeading = 38.4697f;
                    propertyDetails.House.Exits[0].autoExitLoc.Pos1 = new(265.081970f, -1000.700928f, -100.008621f);
                    propertyDetails.House.Exits[0].autoExitLoc.Pos2 = new(265.066620f, -1002.634583f, -97.258621f);
                    propertyDetails.House.Exits[0].autoExitLoc.Width = 1.750000f;
                    propertyDetails.House.Exits[0].autoExitLoc.EnterHeading = 182.9622f;
                    propertyDetails.House.HeistPlanningLocate = new(264.4842f, -997.0889f, -100.0086f);
                    propertyDetails.House.HeistCameraPos = new(262.9771f, -999.9382f, -97.7223f);
                    propertyDetails.House.HeistCameraRot = new(0f, 0f, 46.9484f);
                    propertyDetails.House.HeistFOV = 50f;
                    propertyDetails.House.MidPoint = new(262.6717f, -1000.4250f, -100.0087f);
                    GetMpHouseInteriorBounds(ref propertyDetails.House.Bounds, iProperty); propertyDetails.House.BuzzerLoc = new(265.9362f, -1001.3053f, -97.6834f);
                    GetPropertyWardrobeLocation(iProperty, ref propertyDetails.House.WardrobeLoc, ref propertyDetails.House.WardrobeHeading, -1);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerVec = new(261.2055f, -1003.9203f, -100.0086f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BED].TriggerRot = 280.6086f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].TriggerVec = new(265.6066f, -996.4553f, -99.0039f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].TriggerRot = 264.6031f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].SceneVec = new Vector3(266.20f, -996.940f, -98.900f) - new Vector3(-0.0237f, -0.2399f, 0.0016f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].SceneRot = new(0.00000f, 0.0000f, -146.160f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].CamVec = new(266.5220f, -995.2286f, -98.7813f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].CamRot = new(1.4963f, 0.0565f, 169.5309f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].Cam2Vec = new(266.5220f, -995.2286f, -98.7813f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].Cam2Rot = new(1.4963f, 0.0565f, 169.5309f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].ExitCamVec = new(265.3000f, -996.2000f, -98.2000f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].ExitCamRot = new(-26.5f, -0.0000f, -126.9383f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].AreaAVec = new(266.4885f, -996.7000f, -98.50000f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BEER].AreaBVec = new(265.0000f, -996.7000f, -100.0086f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerVec = new(259.4345f, -996.0923f, -100.0086f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].TriggerRot = 74.0f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneVec = new(259.221f, -994.878f, -99.536f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].SceneRot = new(0.0f, 0.0000f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamVec = new(259.5696f, -997.0326f, -99.3819f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].CamRot = new(3.6829f, -0.0466f, 50.1658f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].Cam2Vec = new(259.1824f, -996.4972f, -99.2152f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].Cam2Rot = new(13.6201f, -0.0466f, 1.4220f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].ExitCamVec = new(257.0249f, -995.7932f, -98.5627f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].ExitCamRot = new(-8.5766f, -0.0466f, -102.1123f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaAVec = new(258.650269f, -995.929932f, -100.008621f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].AreaBVec = new(259.760986f, -996.100403f, -98.008621f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_BONG].FranklinBong = true;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_GAS].TriggerVec = new(262.4687f, -999.5469f, -100.0086f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_GAS].TriggerRot = 187.4952f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerVec = new(254.3181f, -1000.8063f, -98.9226f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerRot = 357.3586f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TriggerSizeVec = new(0.6f, 0.6f, 0.6f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneVec = new(254.847f, -1000.640f, -99.768f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SceneRot = new(0.0f, 0.0f, -180.000f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamVec = new(254.5649f, -1001.6345f, -98.2143f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].CamRot = new(-13.1864f, -0.0000f, 14.3302f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamVec = new(254.0852f, -1001.0563f, -97.9779f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].LookCamRot = new(8.8526f, -0.0221f, -37.4062f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamVec = new(254.2074f, -1001.6578f, -98.3661f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AboveCamRot = new(-2.5954f, -0.0719f, -0.3961f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamVec = new(254.2738f, -1001.0099f, -97.7600f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].TurnOffCamRot = new(-32.3906f, -0.0172f, 0.3708f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamVec = new(254.2738f, -1001.0099f, -97.7600f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitFrameCamRot = new(-32.3906f, -0.0172f, 0.3708f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamVec = new(256.8365f, -1001.0202f, -98.7670f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitCamRot = new(-3.3968f, -0.0144f, 88.4273f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadVec = new(254.53081f, -1000.29114f, -97.67236f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ShowerHeadRot = new(-45.0f, 0.0f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamVec = new(254.53081f, -1000.29114f, -97.67236f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].SteamRot = new(-45.0f, 0.0f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaAVec = new(253.843277f, -1000.755066f, -100.00f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].AreaBVec = new(257.273926f, -1000.765259f, -97.00f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathAreaWidth = 2.0f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorVec = new(257.2896f, -1001.2546f, -98.8587f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].DoorRot = new(0.0f, 0.0f, 0.0f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerPos = new(255.2676f, -1000.9778f, -100.0099f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].ExitShowerHeading = 274.0441f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_SHOWER].BathroomDoorArea = new(257.236145f, -1000.591980f, -99.509918f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerVec = new(263.6821f, -996.9714f, -100.0087f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].TriggerRot = 90.1681f;
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneVec = new(264.2415f, -994.803f, -99.071f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneRot = new(0.0f, 0.0f, -2.520f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamVec = new(265.4949f, -994.6922f, -98.7894f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].CamRot = new(2.6773f, -0.0000f, 115.8733f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneVec = new(264.2415f, -994.803f, -99.071f);
                    propertyDetails.House.activity[(int)SafeActs.SAFEACT_WHISKEY].SceneRot = new(0.0f, 0.0f, -2.520f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(265.4131f, -1002.989f, -99.9457f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.0f, 0.0f, 180.0f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerPos = new(265.4250f, -1000.7535f, -100.0086f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerHeading = 178.66f;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerPos = new(265.1576f, -1002.9908f, -100.0086f);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerHeading = 0.8739f;
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDPos = new(264.8582f, -999.4998f, -100.0086f);
                    propertyDetails.House.BuzzerEnter.InsidePlayerENDHeading = -132.94f;
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDPos = new(265.8691f, -1000.3765f, -100.0086f);
                    propertyDetails.House.BuzzerEnter.OutsidePlayerENDHeading = 51.24f;
                    propertyDetails.House.DoorBlockerLoc = new(265.130f, -1002.489f, -98.816f);
                    propertyDetails.House.DoorBlockerRot = new(90f, 0f, 0f);
                    propertyDetails.House.SafeCoronaLoc = new(260.9818f, -999.0168f, -100.0086f);
                    break;
            }
        }
        internal static void GetMpHouseInteriorBounds(ref MPPropertyNonAxis[] bounds, PropertiesEnum iProperty)
        {
            Position tempStruct = new Position();
            switch (iProperty)
            {
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_HIGH_APT_5:
                case PropertiesEnum.PROPERTY_HIGH_APT_6:
                case PropertiesEnum.PROPERTY_HIGH_APT_7:
                case PropertiesEnum.PROPERTY_HIGH_APT_8:
                case PropertiesEnum.PROPERTY_HIGH_APT_9:
                case PropertiesEnum.PROPERTY_HIGH_APT_10:
                case PropertiesEnum.PROPERTY_HIGH_APT_11:
                case PropertiesEnum.PROPERTY_HIGH_APT_12:
                case PropertiesEnum.PROPERTY_HIGH_APT_13:
                case PropertiesEnum.PROPERTY_HIGH_APT_14:
                case PropertiesEnum.PROPERTY_HIGH_APT_15:
                case PropertiesEnum.PROPERTY_HIGH_APT_16:
                case PropertiesEnum.PROPERTY_HIGH_APT_17:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 19f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 14.500000f;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_1:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_2:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_3:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_4:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_5:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_6:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_7:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_8:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_9:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4:
                    bounds[0].Pos1 = new(355.076630f, -998.967651f, -96.519341f);
                    bounds[0].Pos2 = new(336.403687f, -998.408447f, -100.923859f);
                    bounds[0].Width = 15.750000f;
                    bounds[1].Pos1 = new(347.143219f, -1013.496460f, -100.446175f);
                    bounds[1].Pos2 = new(347.162628f, -1003.188477f, -96.912247f);
                    bounds[1].Width = 8.250000f;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_1:
                case PropertiesEnum.PROPERTY_LOW_APT_2:
                case PropertiesEnum.PROPERTY_LOW_APT_3:
                case PropertiesEnum.PROPERTY_LOW_APT_4:
                case PropertiesEnum.PROPERTY_LOW_APT_5:
                case PropertiesEnum.PROPERTY_LOW_APT_6:
                case PropertiesEnum.PROPERTY_LOW_APT_7:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_1:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_2:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_3:
                    bounds[0].Pos1 = new(270.248199f, -1000.775696f, -95.954659f);
                    bounds[0].Pos2 = new(251.783051f, -1001.063721f, -102.247849f);
                    bounds[0].Width = 15.000000f;
                    bounds[1].Width = 0f;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_5:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_BUS_HIGH_APT_1);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_BUS_HIGH_APT_1);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 21.000000f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_BUS_HIGH_APT_1);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_BUS_HIGH_APT_1);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 14.500000f;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 9.75f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 10.2500f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_THIRD_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[2].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_THIRD_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    bounds[2].Pos2 = tempStruct.ToVector3;
                    bounds[2].Width = 6.75f;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 9.75f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 5.0f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_THIRD_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    bounds[2].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_THIRD_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    bounds[2].Pos2 = tempStruct.ToVector3;
                    bounds[2].Width = 9.5f;
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 26.75f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 18.250000f;
                    break;
                case PropertiesEnum.PROPERTY_YACHT_APT_1_BASE:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 14.750000f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 11.750000f;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1:
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                case PropertiesEnum.PROPERTY_OFFICE_3:
                case PropertiesEnum.PROPERTY_OFFICE_4:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 27.250000f;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    bounds[1].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SECOND_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    bounds[1].Pos2 = tempStruct.ToVector3;
                    bounds[1].Width = 7.500000f;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 29.7500f;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    bounds[0].Pos1 = tempStruct.ToVector3;
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    bounds[0].Pos2 = tempStruct.ToVector3;
                    bounds[0].Width = 22.00f;
                    break;
            }
        }
        internal static void GetPropertyWardrobeLocation(PropertiesEnum iProperty, ref Vector3 ToVector3, ref float fHeading, int iYacht)
        {
            Position tempStruct = new();
            switch (iProperty)
            {
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_HIGH_APT_5:
                case PropertiesEnum.PROPERTY_HIGH_APT_6:
                case PropertiesEnum.PROPERTY_HIGH_APT_7:
                case PropertiesEnum.PROPERTY_HIGH_APT_8:
                case PropertiesEnum.PROPERTY_HIGH_APT_9:
                case PropertiesEnum.PROPERTY_HIGH_APT_10:
                case PropertiesEnum.PROPERTY_HIGH_APT_11:
                case PropertiesEnum.PROPERTY_HIGH_APT_12:
                case PropertiesEnum.PROPERTY_HIGH_APT_13:
                case PropertiesEnum.PROPERTY_HIGH_APT_14:
                case PropertiesEnum.PROPERTY_HIGH_APT_15:
                case PropertiesEnum.PROPERTY_HIGH_APT_16:
                case PropertiesEnum.PROPERTY_HIGH_APT_17:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct);
                    ToVector3 = tempStruct.ToVector3;
                    if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_1)
                        ToVector3.Z = 200.4294f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_2)
                        ToVector3.Z = 169.6122f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_3)
                        ToVector3.Z = 216.0662f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_4)
                        ToVector3.Z = 152.8101f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_5)
                        ToVector3.Z = 70.0399f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_6)
                        ToVector3.Z = 85.3194f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_7)
                        ToVector3.Z = 62.3652f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_8)
                        ToVector3.Z = 49.7375f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_9)
                        ToVector3.Z = 119.3430f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_10)
                        ToVector3.Z = 114.4156f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_11)
                        ToVector3.Z = 88.2696f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_12)
                        ToVector3.Z = 82.9234f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_13)
                        ToVector3.Z = 93.0414f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_14)
                        ToVector3.Z = 78.2890f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_15)
                        ToVector3.Z = 102.2488f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_16)
                        ToVector3.Z = 100.8356f;
                    else if (iProperty == PropertiesEnum.PROPERTY_HIGH_APT_17)
                        ToVector3.Z = 86.4347f;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_1:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_2:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_3:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_4:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_5:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_6:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_7:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_8:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_9:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4:
                    ToVector3 = new(350.7414f, -993.6222f, -100.2020f);
                    fHeading = 179.6123f;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_1:
                case PropertiesEnum.PROPERTY_LOW_APT_2:
                case PropertiesEnum.PROPERTY_LOW_APT_3:
                case PropertiesEnum.PROPERTY_LOW_APT_4:
                case PropertiesEnum.PROPERTY_LOW_APT_5:
                case PropertiesEnum.PROPERTY_LOW_APT_6:
                case PropertiesEnum.PROPERTY_LOW_APT_7:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_1:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_2:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_3:
                    ToVector3 = new(259.8177f, -1003.7940f, -100.0086f);
                    fHeading = 307.1585f;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_2:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_3:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_4:
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_5:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_BUS_HIGH_APT_1);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                case PropertiesEnum.PROPERTY_STILT_APT_10_A:
                case PropertiesEnum.PROPERTY_STILT_APT_12_A:
                case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_YACHT_APT_1_BASE:
                    GetPositionAsOffsetForYacht(iYacht, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1:
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                case PropertiesEnum.PROPERTY_OFFICE_3:
                case PropertiesEnum.PROPERTY_OFFICE_4:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                    GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_WARDROBE, ref tempStruct, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    ToVector3 = tempStruct.ToVector3;
                    fHeading = tempStruct.Yaw;
                    break;
            }
        }
        internal static Position GetBaseYachtInteriorLocation(int iYachtID = -1)
        {
            Position tempStruct = new Position();
            tempStruct = iYachtID switch
            {
                0 => new(-3555.1155f, 1473.0128f, 9.7027f, 0f, 0f, 57.0f),
                1 => new(-3147.0488f, 2827.0879f, 9.7027f, 0f, 0f, -88.0f),
                2 => new(-3277.4729f, 2159.8499f, 9.7027f, 0f, 0f, -93.0f),
                3 => new(-2822.4194f, 4054.8396f, 9.7027f, 0f, 0f, 72.0f),
                4 => new(-3249.8491f, 3704.6814f, 9.7027f, 0f, 0f, -98.0f),
                5 => new(-2383.1934f, 4685.0034f, 9.7027f, 0f, 0f, 47.0f),
                6 => new(-3224.6863f, -215.9825f, 9.7027f, 0f, 0f, -3.0f),
                7 => new(-3447.8765f, 291.9275f, 9.7027f, 0f, 0f, 97.0f),
                8 => new(-2713.0979f, -528.3185f, 9.7027f, 0f, 0f, -33.0f),
                9 => new(-1981.6182f, -1537.2692f, 9.7027f, 0f, 0f, 142.0f),
                10 => new(-2100.8169f, -2533.2332f, 9.7027f, 0f, 0f, -143.0f),
                11 => new(-1599.6425f, -1891.2773f, 9.7027f, 0f, 0f, 112.0f),
                12 => new(-733.6151f, -3916.9846f, 9.7027f, 0f, 0f, -168.0f),
                13 => new(-363.3534f, -3568.5601f, 9.7027f, 0f, 0f, 57.0f),
                14 => new(-1478.4360f, -3753.5378f, 9.7027f, 0f, 0f, -18f),
                15 => new(1535.9740f, -3061.8774f, 9.7027f, 0f, 0f, 62.0f),
                16 => new(2471.4185f, -2430.9297f, 9.7027f, 0f, 0f, 12.0f),
                17 => new(2067.3708f, -2813.0103f, 9.7027f, 0f, 0f, -148.0f),
                18 => new(3021.0881f, -1513.6022f, 9.7027f, 0f, 0f, 72.0f),
                19 => new(3025.9556f, -704.3854f, 9.7027f, 0f, 0f, -98.0f),
                20 => new(2961.8629f, -2007.6315f, 9.7027f, 0f, 0f, 47.0f),
                21 => new(3398.1694f, 1958.5214f, 9.7027f, 0f, 0f, 77.0f),
                22 => new(3428.6812f, 1202.0597f, 9.7027f, 0f, 0f, -148.0f),
                23 => new(3787.8298f, 2567.8838f, 9.7027f, 0f, 0f, -93.0f),
                24 => new(4235.9463f, 4004.2522f, 9.7027f, 0f, 0f, -118.0f),
                25 => new(4245.1514f, 4595.3750f, 9.7027f, 0f, 0f, -68.0f),
                26 => new(4209.0571f, 3392.7053f, 9.7027f, 0f, 0f, -98.0f),
                27 => new(3738.8098f, 5768.2524f, 9.7027f, 0f, 0f, -43.0f),
                28 => new(3472.9656f, 6315.2451f, 9.7027f, 0f, 0f, -23.0f),
                29 => new(3693.4683f, 5194.6587f, 9.7027f, 0f, 0f, 122.0f),
                30 => new(572.9806f, 7142.1382f, 9.7027f, 0f, 0f, -58.0f),
                31 => new(2024.0360f, 6907.5361f, 9.7027f, 0f, 0f, -173.0f),
                32 => new(1377.2958f, 6863.2305f, 9.7027f, 0f, 0f, -3.0f),
                33 => new(-1169.3605f, 6000.2139f, 9.7027f, 0f, 0f, -88.0f),
                34 => new(-759.2205f, 6573.9551f, 9.7027f, 0f, 0f, -153.0f),
                35 => new(-373.8432f, 6964.8599f, 9.7027f, 0f, 0f, -108.0f),
                36 => new(3634.9990f, -4781.0171f, 9.7065f, 0.0f, 0.0f, -179.95f),
                37 => new(50.6219f, -3312.5625f, 9.7065f, 0.0f, 0.0f, 90.05f),
                38 => new(-3556.6770f, 738.4581f, 9.7065f, 0.0f, 0.0f, 0.05f),
                39 => new(-1766.8353f, 5334.0933f, 9.7065f, 0.0f, 0.0f, -9.95f),
                40 => new(-3280.7068f, -1580.8092f, 9.7065f, 0.0f, 0.0f, -12.45f),
                41 => new(-833.0568f, -4809.8076f, 9.7065f, 0.0f, 0.0f, -147.45f),
                _ => new(-1478.4360f, -3753.5378f, 9.7027f, 0f, 0f, -18f),
            };
            return tempStruct;
        }
        internal static void GetPositionAsOffsetForYacht(int iYachtID, int iElement, ref Position offsetStruct, bool bExteriorOffset = false)
        {
            Position[] tempStruct = new Position[2];
            if (!bExteriorOffset)
                tempStruct[0] = GetBaseYachtInteriorLocation();
            else
                tempStruct[0] = new(ApartmentsLoader.g_PrivateYachtDetails[iYachtID].f_4, 0, 0, ApartmentsLoader.g_PrivateYachtDetails[iYachtID].f_7);
            if (!bExteriorOffset)
                tempStruct[1] = GetBaseYachtInteriorLocation(iYachtID);
            else
                tempStruct[1] = new(ApartmentsLoader.g_PrivateYachtDetails[iYachtID].f_4, 0, 0, ApartmentsLoader.g_PrivateYachtDetails[iYachtID].f_7);
            offsetStruct = GetBaseElementLocation(iElement, PropertiesEnum.PROPERTY_YACHT_APT_1_BASE);
            Vector3 vOffset = (offsetStruct - tempStruct[0]).ToVector3;
            vOffset = RotateVectorAboutZ(vOffset, -tempStruct[0].Yaw);
            vOffset = RotateVectorAboutZ(vOffset, tempStruct[1].Yaw);
            offsetStruct = new(GetObjectOffsetFromCoords(tempStruct[1].X, tempStruct[1].Y, tempStruct[1].Z, 0.0f, vOffset.X, vOffset.Y, vOffset.Z), offsetStruct.ToRotationVector);
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_ELEMENT_ENTRY_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR2:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC1:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC2:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC3:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC4:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC5:
                case PropertyPropElements.MP_PROP_ELEMENT_TV:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_3:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM1:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM2:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM3:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM4:
                case PropertyPropElements.MP_PROP_ELEMENT_MONITOR_BLOCKER:
                case PropertyPropElements.MP_PROP_ELEMENT_WARDROBE:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BED:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_FRAME_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA:
                case PropertyPropElements.MP_PROP_ELEMENT_BATHROOM_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA0:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA1:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHDEST:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PDANCE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SDANCE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_INSIDE_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_INSIDE_END_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_END_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APART_ENTRANCE_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_PLAYER_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_CAMERA0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_CAMERA1:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_DOOR_BLOCKER:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_STRIPPER_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_0:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_1:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_2:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_BACK_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_CASINO_POKER_TABLE:
                case PropertyPropElements.MP_PROP_ELEMENT_CASINO_BJACK_TABLE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW:
                case PropertyPropElements.MP_PROP_ELEMENT_ENTRY_DOOR_FIXED_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM1_START:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM1_END:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM2_START:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM2_END:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_0:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_1:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_2:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_3:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_4:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_5:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_6:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_7:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_8:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_9:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_10:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_11:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_12:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_14:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_15:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO1_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO2_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_REAL_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_NO_TEAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_CHRISTMAS_TREE_LOCATION:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_MODEL:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BUZZER_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BUZZER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_ENTER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_PAN_START:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_PAN_END:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_0:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_1:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_2:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_3:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_4:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_5:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_6:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_7:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_8:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_9:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_10:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_11:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_12:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_13:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_14:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXIT_SPAWN_15:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_PLAYER_OUT_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_EXIT_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BUZZER_PROP:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXTERIOR_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXTERIOR_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXTERIOR_DOOR_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BAR_BOTTLE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BAR_SHOT_GLASS:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BARTENDER:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BAR_LOCATE_A:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BAR_LOCATE_B:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_BAR_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_OBJECT:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_OBJECT_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_OBJECT_3:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_CAPTAIN:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BOAT_STAFF_1:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BOAT_STAFF_2:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_NAME_PORT:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_NAME_STARB:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_NAME_STERN:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_HORN:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_NAME_OVERHEAD:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA_2_B:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA_3_B:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_3:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_4:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_5:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_LEAN_ANIM_ROOT_6:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_LEAN_ANIM_ROOT_7:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPYACHT_LEAN_LOCATE1_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPYACHT_LEAN_LOCATE0_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPYACHT_LEAN_ANIM_ROOT_0:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_ENTRY_1_A:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_ENTRY_1_B:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_ENTRY_2_A:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_ENTRY_2_B:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_EXIT_A:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR_EXIT_B:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_ENTRY_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_EXIT_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_ENTRY_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_ENTRY_ANIM_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_EXIT_ANIM_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_BRIDGE_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_JACUZZI_CENTRE:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_FRONT_STATIC_EMITTER:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_TOP_DECK_STATIC_EMITTER:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_ENTRANCE_STATIC_EMITTER:
                case PropertyPropElements.MP_PROP_ELEMENT_YACHT_EXT_JACUZZI_STATIC_EMITTER:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_1_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_0_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO1_1_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO1_0_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO2_1_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO2_0_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_ANIMS_EXT:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_1:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_1:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_PROP2:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_PROP1:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_PROP0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_0_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_1_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_2_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_3_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_4_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_5_V1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_0_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_1_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_2_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_3_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_4_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_ANIM_ROOT_5_V2:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_R:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_2_R:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_3_R:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
        }
        internal static Position GetBaseInteriorLocation(PropertiesEnum iProperty, bool bIsModGarage = false)
        {
            Position tempStruct = new();
            switch (iProperty)
            {
                case (PropertiesEnum)(-1):
                    tempStruct = new(-794.9184f, 339.6266f, 200.4135f, 0f, 0f, 180.0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                    tempStruct = new(-794.9184f, 339.6266f, 200.4135f, 0f, 0f, 180.0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_2:
                    tempStruct = new(-761.0982f, 317.6259f, 169.59628f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_3:
                    tempStruct = new(-761.1888f, 317.6295f, 216.0503f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_4:
                    tempStruct = new(-795.3856f, 340.0188f, 152.7941f, 0f, 0f, 179.99997f);
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                    tempStruct = new(-778.5056f, 332.3779f, 212.1968f, 0f, 0f, 90f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_5:
                    tempStruct = new(-258.1807f, -950.6853f, 70.0239f, 0f, 0f, 70f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_6:
                    tempStruct = new(-285.0051f, -957.6552f, 85.3035f, 0f, 0f, -109.99999f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_7:
                    tempStruct = new(-1471.8821f, -530.7484f, 62.34918f, 0f, 0f, -145.0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_8:
                    tempStruct = new(-1471.8821f, -530.7484f, 49.72156f, 0f, 0f, -145.0f);
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_2:
                    tempStruct = new(-1463.1500f, -540.2369f, 74.2439f, 0f, 0f, -145f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_9:
                    tempStruct = new(-885.3702f, -451.4775f, 119.327f, 0f, 0f, 27.55617f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_10:
                    tempStruct = new(-913.0385f, -438.4284f, 114.39966f, 0f, 0f, -153.30931f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_11:
                    tempStruct = new(-892.5499f, -430.4789f, 88.25368f, 0f, 0f, 116.9193f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_12:
                    tempStruct = new(-35.0462f, -576.3170f, 82.90739f, 0f, 0f, 160.0f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_13:
                    tempStruct = new(-10.3788f, -590.7431f, 93.02542f, 0f, 0f, 70f);
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_5:
                    tempStruct = new(-22.2487f, -589.1461f, 80.2305f, 0f, 0f, 69.88f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_14:
                    tempStruct = new(-900.6311f, -376.7462f, 78.27306f, 0f, 0f, 26.92611f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_15:
                    tempStruct = new(-929.4830f, -374.5104f, 102.23286f, 0f, 0f, -152.55307f);
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_3:
                    tempStruct = new(-914.4202f, -375.8189f, 114.4743f, 0f, 0f, -63f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_16:
                    tempStruct = new(-617.1647f, 64.6042f, 100.8196f, 0f, 0f, 180f);
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_17:
                    tempStruct = new(-584.2015f, 42.7133f, 86.4187f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_4:
                    tempStruct = new(-609.5665f, 50.2203f, 98.3998f, 0f, 0f, -90f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                    tempStruct = new(-171.3969f, 494.2671f, 134.4935f, 0f, 0f, 11.0f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                    tempStruct = new(339.4982f, 434.0887f, 146.2206f, 0f, 0f, -63.50f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                    tempStruct = new(-761.3884f, 615.7333f, 140.9805f, 0f, 0f, -71.50f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                    tempStruct = new(-678.1752f, 591.0076f, 142.2196f, 0f, 0f, 40.50f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    tempStruct = new(120.0541f, 553.7930f, 181.0943f, 0f, 0f, 6.00f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                    tempStruct = new(-571.4039f, 655.2008f, 142.6293f, 0f, 0f, -14.50f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                    tempStruct = new(-742.2565f, 587.6547f, 143.0577f, 0f, 0f, -29.00f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_10_A:
                    tempStruct = new(-857.2222f, 685.0510f, 149.6502f, 0f, 0f, 4.50f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_12_A:
                    tempStruct = new(-1287.6498f, 443.2707f, 94.6919f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                    tempStruct = new(374.2012f, 416.9688f, 142.6977f, 0f, 0f, -14.00f);
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                    tempStruct = new(-787.7805f, 334.9232f, 186.1134f, 0f, 0f, 90f);
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                    tempStruct = new(-787.7805f, 334.9232f, 215.8384f, 0f, 0f, 90f);
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                    tempStruct = new(-773.2258f, 322.8252f, 194.8862f, 0f, 0f, -90f);
                    break;
                case PropertiesEnum.PROPERTY_YACHT_APT_1_BASE:
                    tempStruct = new(-1573.0981f, -4085.8059f, 9.7851f, 0f, 0f, 162.00f);
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_1:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_2:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_3:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_4:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_5:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_6:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_7:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_8:
                case PropertiesEnum.PROPERTY_MEDIUM_APT_9:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3:
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4:
                    tempStruct = new(342.8157f, -997.4288f, -100.0000f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_1:
                case PropertiesEnum.PROPERTY_LOW_APT_2:
                case PropertiesEnum.PROPERTY_LOW_APT_3:
                case PropertiesEnum.PROPERTY_LOW_APT_4:
                case PropertiesEnum.PROPERTY_LOW_APT_5:
                case PropertiesEnum.PROPERTY_LOW_APT_6:
                case PropertiesEnum.PROPERTY_LOW_APT_7:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_1:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_2:
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_3:
                    tempStruct = new(260.3297f, -997.4288f, -100.0000f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1:
                    tempStruct = new(-1572.1869f, -570.8315f, 109.9879f, 0f, 0f, -54.00f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                    tempStruct = new(-1383.9543f, -476.7112f, 73.5070f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3:
                    tempStruct = new(-138.0029f, -629.7390f, 170.2854f, 0f, 0f, -84f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4:
                    tempStruct = new(-74.8895f, -817.6883f, 244.8508f, 0f, 0f, 70f);
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                    tempStruct = new(1100.7644f, -3159.3840f, -34.9342f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                    tempStruct = new(1005.8060f, -3157.6702f, -36.0897f, 0f, 0f, 0f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1:
                    if (!bIsModGarage)
                        tempStruct = new(-1576.5712f, -569.7595f, 85.500000f, 0f, 0f, 36.10f);
                    else
                        tempStruct = new(-1578.0225f, -576.4251f, 104.2000f, 0.0f, 0.0f, -144.04f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2:
                    if (!bIsModGarage)
                        tempStruct = new(-1571.2538f, -566.5865f, 85.5f, 0f, 0f, -53.90f);
                    else
                        tempStruct = new(-1578.0225f, -576.4251f, 104.2000f, 0.0f, 0.0f, -144.04f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3:
                    if (!bIsModGarage)
                        tempStruct = new(-1568.0984f, -571.9171f, 85.500000f, 0f, 0f, -143.90f);
                    else
                        tempStruct = new(-1578.0225f, -576.4251f, 104.2000f, 0.0f, 0.0f, -144.04f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1:
                    if (!bIsModGarage)
                        tempStruct = new(-1384.5178f, -475.8657f, 56.1000f, 0f, 0f, 98.70f);
                    else
                        tempStruct = new(-1391.2450f, -473.9638f, 77.200f, 0.0f, 0.0f, 98.86f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2:
                    if (!bIsModGarage)
                        tempStruct = new(-1384.53829f, -475.8829f, 48.100f, 0f, 0f, 98.70f);
                    else
                        tempStruct = new(-1391.2450f, -473.9638f, 77.200f, 0.0f, 0.0f, 98.86f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3:
                    if (!bIsModGarage)
                        tempStruct = new(-1378.9939f, -477.2481f, 56.100f, 0f, 0f, -81.10f);
                    else
                        tempStruct = new(-1391.2450f, -473.9638f, 77.200f, 0.0f, 0.0f, 98.86f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                    if (!bIsModGarage)
                        tempStruct = new(-186.5683f, -576.4624f, 135.000f, 0.0f, 0.0f, 96.16f);
                    else
                        tempStruct = new(-146.6167f, -596.6301f, 166.0000f, 0.0f, 0.0f, -140.0f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2:
                    if (!bIsModGarage)
                        tempStruct = new(-113.8860f, -564.3862f, 135.000f);
                    else
                        tempStruct = new(-146.6167f, -596.6301f, 166.0000f, 0.0f, 0.0f, -140.0f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3:
                    if (!bIsModGarage)
                        tempStruct = new(-134.6568f, -635.1774f, 135.000000f, 0f, 0f, -9.04f);
                    else
                        tempStruct = new(-146.6167f, -596.6301f, 166.0000f, 0.0f, 0.0f, -140.0f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1:
                    if (!bIsModGarage)
                        tempStruct = new(-79.0479f, -822.6393f, 221.0f, 0f, 0f, 70);
                    else
                        tempStruct = new(-73.9040f, -821.6204f, 284.0000f, 0.0f, 0.0f, -110.00f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2:
                    if (!bIsModGarage)
                        tempStruct = new(-70.3086f, -819.5784f, 221.00f, 0f, 0f, 160);
                    else
                        tempStruct = new(-73.9040f, -821.6204f, 284.0000f, 0.0f, 0.0f, -110.00f);
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3:
                    if (!bIsModGarage)
                        tempStruct = new(-79.9861f, -818.4250f, 221.00f, 0f, 0f, -20);
                    else
                        tempStruct = new(-73.9040f, -821.6204f, 284.0000f, 0.0f, 0.0f, -110.00f);
                    break;
            }
            return tempStruct;
        }
        internal static Position GetBaseElementLocation(int iElement, PropertiesEnum iBaseProperty = (PropertiesEnum)(-1))
        {
            Position sBaseElementReturn = new Position();
            ElementLockBlock sPropMetadataInfo = 0;
            bool bMetadataBlockValid = false;
            if (GetMetadataBlockForApartment(iBaseProperty, ref sPropMetadataInfo))
                bMetadataBlockValid = true;
            OutputArgument vec1 = new(sBaseElementReturn.ToVector3);
            OutputArgument vec2 = new(sBaseElementReturn.ToRotationVector);
            if (bMetadataBlockValid && Function.Call<bool>((Hash)0xB335F761606DB47C, vec1, vec2, iElement, (int)sPropMetadataInfo))
            {
                sBaseElementReturn = new(vec1.GetResult<Vector3>(), vec2.GetResult<Vector3>());
                return sBaseElementReturn;
            }
            return sBaseElementReturn;
        }
        internal static bool GetMetadataBlockForApartment(PropertiesEnum iPropertyID, ref ElementLockBlock sInfoOut)
        {
            switch (iPropertyID)
            {
                case (PropertiesEnum)(-1):
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_BASE;
                    return true;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_HI_APT;
                    return true;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_1;
                    return true;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_2;
                    return true;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_3;
                    return true;
                case PropertiesEnum.PROPERTY_YACHT_APT_1_BASE:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_4;
                    return true;
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_5;
                    return true;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_6;
                    return true;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_7;
                    return true;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                    sInfoOut = ElementLockBlock.ELEMENT_LOC_BLOCK_EXTRA_8;
                    return true;
            }
            return false;
        }
        internal static void GetPositionAsOffsetForProperty(PropertiesEnum iProperty, int iElement, ref Position offsetStruct, PropertiesEnum iBaseProperty = (PropertiesEnum)(-1), bool bIsOfficeModGarage = false)
        {
            Position[] tempStruct =
            [
                GetBaseInteriorLocation(iBaseProperty, bIsOfficeModGarage),
                GetBaseInteriorLocation(iProperty, bIsOfficeModGarage),
            ];
            offsetStruct = GetBaseElementLocation(iElement, iBaseProperty);
            Vector3 vOffset = offsetStruct.ToVector3 - tempStruct[0].ToVector3;
            vOffset = RotateVectorAboutZ(vOffset, -tempStruct[0].Yaw);
            vOffset = RotateVectorAboutZ(vOffset, tempStruct[1].Yaw);
            offsetStruct = new(GetObjectOffsetFromCoords(tempStruct[1].X, tempStruct[1].Y, tempStruct[1].Z, 0.0f, vOffset.X, vOffset.Y, vOffset.Z), offsetStruct.ToRotationVector);
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_ELEMENT_ENTRY_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR2:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC1:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC2:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC3:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC4:
                case PropertyPropElements.MP_PROP_ELEMENT_SPAWN_LOC5:
                case PropertyPropElements.MP_PROP_ELEMENT_TV:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_2:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM1:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM2:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM3:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM4:
                case PropertyPropElements.MP_PROP_ELEMENT_MONITOR_BLOCKER:
                case PropertyPropElements.MP_PROP_ELEMENT_WARDROBE:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BONG_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BED:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BEER_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_HEAD:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_STEAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ENTER_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_LOOK_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_ABOVE_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TURN_OFF_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_FRAME_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_TRIGGER_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_SHOWER_DOOR_AREA:
                case PropertyPropElements.MP_PROP_ELEMENT_BATHROOM_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA0:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHAREA1:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PATHDEST:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_PDANCE:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_SDANCE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_A:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKEY_AREA_B:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WINE_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_WHEATGRASS_EXIT_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_INSIDE_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_INSIDE_END_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_END_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APART_ENTRANCE_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_LEAVE_SYNC_SCENE_PLAYER_START_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_CAMERA0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO_CAMERA1:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_DOOR_BLOCKER:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_ENTER_SYNC_SCENE_OUTSIDE_STRIPPER_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_0:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_1:
                case PropertyPropElements.MP_PROP_ELEMENT_WARP_IN_LOCATION_2:
                case PropertyPropElements.MP_PROP_ELEMENT_STRIPPER_BACK_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_CASINO_POKER_TABLE:
                case PropertyPropElements.MP_PROP_ELEMENT_CASINO_BJACK_TABLE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_SCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PROP_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_BOARD_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_MAP_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_OVERVIEW:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_MAP_TUTORIAL:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_BOARD:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_DESCRIPTION:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_STATS:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_BOARD_CENTRE_LOC:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_PIE_CHART:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_TODO_LIST:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_STORAGE_LOCKER:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CAM_POS_BOARD_CLOSE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_START_POINT_0:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_START_POINT_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_START_POINT_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_START_POINT_3:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_END_POINT:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_CAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_CAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTS_CAM_EST:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLANNING_POST_MISSION_APT_POS_0:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLANNING_POST_MISSION_APT_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLANNING_POST_MISSION_APT_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLANNING_POST_MISSION_APT_POS_3:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ROOM_PROP_PIVOT:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ROOM_EXIT:
                case PropertyPropElements.MP_PROP_ELEMENT_ENTRY_DOOR_FIXED_CAM:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM1_START:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM1_END:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM2_START:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM2_END:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM3_START:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_CAM3_END:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_ENTRANCE_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_PLANNING_ROOM_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_WALK_TO1:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_WALK_TO2:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_WALK_TO3:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_POS_PLANNING_ROOM:
                case PropertyPropElements.MP_PROP_ELEMENT_PLANNING_BOARD_CUT_POS_PLANNING_BOARD:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM1_START:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM1_END:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM2_START:
                case PropertyPropElements.MP_PROP_ELEMENT_APT_REFURB_CUT_CAM2_END:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_0:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_1:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_2:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_3:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_4:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_5:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_6:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_7:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_8:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_9:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_10:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_11:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_12:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_14:
                case PropertyPropElements.MP_PROP_ELEMENT_APARTMENT_ENTRY_SPAWN_15:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO1_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO2_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_REAL_DOOR:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_NO_TEAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_NO_TEAM:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_0_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_1_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_2_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_PLACEMENT_TEAM_3_3:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CAMERA_PLACEMENT_TEAM_3:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_PHONE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_PICKUP:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WHISKY_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WHISKY_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINE_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINE_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_COUCH_M_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_COUCH_M_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_COUCH_F_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_COUCH_F_2:
                case PropertyPropElements.MP_END_HEIST_WINNER_SCENE_PED_0_COORDS:
                case PropertyPropElements.MP_END_HEIST_WINNER_SCENE_PED_1_COORDS:
                case PropertyPropElements.MP_END_HEIST_WINNER_SCENE_PED_2_COORDS:
                case PropertyPropElements.MP_END_HEIST_WINNER_SCENE_PED_3_COORDS:
                case PropertyPropElements.MP_END_HEIST_WINNER_SCENE_CAMERA_COORDS:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_WINDOW1_A:
                case PropertyPropElements.MP_PROP_WINDOW1_B:
                case PropertyPropElements.MP_PROP_WINDOW2_A:
                case PropertyPropElements.MP_PROP_WINDOW2_B:
                case PropertyPropElements.MP_PROP_WINDOW1_SPAWN:
                case PropertyPropElements.MP_PROP_WINDOW2_SPAWN:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUT_AFTER_POS0:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUT_AFTER_POS1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUT_AFTER_POS2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUT_AFTER_POS3:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_PLANNING_CUTSCENE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CELEBRATION_DLC_MPH_FIN_CEL_APT1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_INTRO_ANIM:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_BESPOKE_ANIM_INTRO_LEADER:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_BESPOKE_ANIM_INTRO_GUEST:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_M_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_M_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_M_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_F_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_F_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_TV_F_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_M_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_M_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_M_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_F_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_F_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_WINDOW_F_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_M_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_M_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_M_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_F_1:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_F_2:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_ANIM_KITCHEN_F_IDLE:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CORONA_LIGHT_RIG_FINALE:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CORONA_LIGHT_RIG_TEAM_0:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CORONA_LIGHT_RIG_TEAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CORONA_LIGHT_RIG_TEAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_BESPOKE_CORONA_LIGHT_RIG_TEAM_3:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION_1:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION_2:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION_END:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION_1_END:
                case PropertyPropElements.MP_PROP_HEIST_CELEBRATION_CAMERA_LOCATION_2_END:
                case PropertyPropElements.MP_PROP_ELEMENT_CHRISTMAS_TREE_LOCATION:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_MODEL:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_0:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_1:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_2:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_3:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_4:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_6:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_7:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_8:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_9:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_10:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_11:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_12:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_13:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_14:
                case PropertyPropElements.MP_PROP_ELEMENT_SAFE_LOCATION_15:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_0_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_0_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_1_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_1_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_2_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_2_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_3_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_3_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_4_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_4_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_6_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_6_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_7_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_7_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_8_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_8_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_9_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_9_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_10_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_10_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_11_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_11_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_12_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_12_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_13_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_13_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_14_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_14_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_15_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_UNSAFE_LOC_15_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_SCENE_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_AREA_A_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_WHISKY_NEW_AREA_B_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_3:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_4:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE0_5:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_0:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_1:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_2:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_3:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_4:
                case PropertyPropElements.MP_PROP_ELEMENT_MPJACUZZI_SEAT_LOCATE1_5:
                case PropertyPropElements.MP_PROP_ELEMENT_MPTV_ROOM_CAMERA_3:
                case PropertyPropElements.MP_PROP_ELEMENT_HEIST_CUTSCENE_CONCAT_BESPOKE:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_1:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO3_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_1:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_0:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO4_ANIMS:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_0_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_1_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_RADIO0_ANIMS_VAR2:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_B_R:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_TRIGGER_AREA_A_R:
                case PropertyPropElements.MP_PROP_ELEMENT_BED_SCENE_R:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_ASSISTANT:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_WEAPON_CRATE_TRIGGER_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_VAULT_SAFE_TRIGGER_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_L_OPEN:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_L_CLOSED:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_R_OPEN:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_R_CLOSED:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_L_OPEN:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_L_CLOSED:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_R_OPEN:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_R_CLOSED:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_CAM1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_CAM2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_SCENE_LOC:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_INSIDE_LOC_0:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_WALKTO_LOC:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_PED_INSIDE_LOC:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_PED_WALKTO_LOC:
                case PropertyPropElements.MP_PROP_OFFICE_GUN_VAULT_DOOR:
                case PropertyPropElements.MP_PROP_OFFICE_SAFE_VAULT_DOOR:
                case PropertyPropElements.MP_PROP_OFFICE_GUN_VAULT_DOOR_SCENE:
                case PropertyPropElements.MP_PROP_OFFICE_SAFE_VAULT_DOOR_SCENE:
                case PropertyPropElements.MP_PROP_OFFICE_SAFE_VAULT_DOOR_CAMERA:
                case PropertyPropElements.MP_PROP_OFFICE_SAFE_VAULT_DOOR_PLAYER_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_EXIT2_DOOR2:
                case PropertyPropElements.MP_PROP_OFFICE_GUN_VAULT_DOOR_OPEN_POS:
                case PropertyPropElements.MP_PROP_OFFICE_GUN_VAULT_DOOR_CAMERA:
                case PropertyPropElements.MP_PROP_OFFICE_GUN_VAULT_DOOR_PLAYER_POS:
                case PropertyPropElements.MP_PROP_OFFICE_SAFE_VAULT_DOOR_OPEN_POS:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_1_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_1_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_2_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_2_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_3_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_3_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_4_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_4_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_5_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_5_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_5:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_6_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_6_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_6:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_7_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_7_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_7:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_8_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_8_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_8:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_9_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_9_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_10_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_10_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_10:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_11_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_11_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_11:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_12_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_12_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_12:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_5:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_6:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_7:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_8:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_9:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_10:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_11:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_12:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_13:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_14:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_15:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_16:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_17:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_18:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_19:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_20:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_21:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_22:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_23:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_CASH_PILE_POS_24:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_AMMO_BOX_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_AMMO_BOX_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_RIFLE_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SHOTGUN_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR_1_L1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR_2_L1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR_1_L2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR_2_L2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR_COORD:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_QUATERS_DOOR2_COORD:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_AMMO_BOX_3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_AMMO_BOX_4:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM5:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM6:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM7:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM8:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM9:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM10:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM11:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM12:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM13:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM14:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_1_SPAWN:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_2_SPAWN:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_3_SPAWN:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_4_SPAWN:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_ENTRY_CAM_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_ENTRY_CAM_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_ENTRY_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_ENTRY_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_ENTRY_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_ENTRY_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_WALK_TO_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_WALK_TO_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_WALK_TO_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_2_WALK_TO_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_IDLE_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_IDLE_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_IDLE_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_IDLE_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_POS_CHAIR_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SCENE_POS_CHAIR_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_DANCE_SCENE_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_DANCE_SCENE_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_DANCE_SCENE_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_DANCE_SCENE_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_C1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_SIT_DOWN_SCENE_POS_C2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_CHAIR_1_LOCATE:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_CHAIR_2_LOCATE:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_CHAIR_1_SINGLE_DANCE:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_ENTRY_1_WALK_TO_COORD:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_13_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_13_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_13:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_14_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_14_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_14:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_MACHINEGUN_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_0:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_5:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_6:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_ANIM_ROOT_7:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_AWARD:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_EXIT_SCENE_POS_S1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_EXIT_SCENE_POS_S2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_EXIT_SCENE_POS_S3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_EXIT_SCENE_POS_S4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_EXIT_SCENE_GO_TO_COORD:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_VAULT_SAFE_TRIGGER_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_WEAPON_CRATE_TRIGGER_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_COMPUTER_BOXB:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_COMPUTER_BOXA:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_COMPUTER_TRIGGER_LOCATION:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SEAT_BOX_BLOCKER:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_INSIDE_LOC_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_INSIDE_LOC_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_INSIDE_LOC_3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_WALKTO_LOC_2:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
            switch ((PropertyPropElements)iElement)
            {
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_W1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_W2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_W3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_UNSAFE_AREA_4_W4:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_PERSONAL_ASSISTANT_CHAIR:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_4TH_TV_STAND_BOUND_1A:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_4TH_TV_STAND_BOUND_1B:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_4TH_TV_STAND_BOUND_2A:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_4TH_TV_STAND_BOUND_2B:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_ELE_EXIT_P2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_STRIPPER_ELE_EXIT_P3:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM15:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM16:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM17:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM18:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM19:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM20:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM21:
                case PropertyPropElements.MP_PROP_ELEMENT_INTRO_APT_CAM22:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_16_POS_1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_UNSAFE_LOC_16_POS_2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFFICE_SAFE_LOCATION_16:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_OUT_START1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_OUT_START2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_PED_OUT_START3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_OUT_CAM:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_PED_OUT_START1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_PED_OUT_START2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_PED_OUT_START3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_LDOOR_OUT_CAM:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM1_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM2_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM1_3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM2_3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM1_4:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM2_4:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM1_5:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_ELEV_RDOOR_CAM2_5:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_PLATFORM_L0:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_PLATFORM_L1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_PLATFORM_L2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_PLATFORM_L3:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_CAM_L0:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_CAM_L1:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_CAM_L2:
                case PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_CAM_L3:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_GAR_ELEV_BUTTON_SCENE:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MOD_ELEV_BUTTON_SCENE:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_GARAGE_INTRO_CAM_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_GARAGE_INTRO_CAM_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_GARAGE_OUTRO_CAM_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_GARAGE_OUTRO_CAM_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MOD_GARAGE_LIFT_COORD_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MOD_GARAGE_LIFT_COORD_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MODE_GARAGE_VEH_BROWSING_LOC_1:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MODE_GARAGE_VEH_BROWSING_LOC_2:
                case PropertyPropElements.MP_PROP_ELEM_OFFICE_MODE_GARAGE_VEH_BROWSING_SAFE_LOC:
                    if (tempStruct[0].Yaw > 180.0f)
                        tempStruct[0].Yaw -= 360.0f;
                    if (tempStruct[0].Yaw < -180.0f)
                        tempStruct[0].Yaw += 360.0f;
                    if (tempStruct[1].Yaw > 180.0f)
                        tempStruct[1].Yaw -= 360.0f;
                    if (tempStruct[1].Yaw < -180.0f)
                        tempStruct[1].Yaw += 360.0f;
                    offsetStruct.Yaw = offsetStruct.Yaw + (tempStruct[1].Yaw - tempStruct[0].Yaw);
                    if (offsetStruct.Yaw > 180.0f)
                        offsetStruct.Yaw -= 360.0f;
                    if (offsetStruct.Yaw < -180.0f)
                        offsetStruct.Yaw += 360.0f;
                    break;
            }
        }
        internal static Vector3 RotateVectorAboutZ(Vector3 vToRotate, float fZRot)
        {
            float fSin = Sin(fZRot);
            float fCos = Cos(fZRot);
            Vector3 vNew = new Vector3(vToRotate.X * fCos - vToRotate.Y * fSin, vToRotate.X * fSin + vToRotate.Y * fCos, vToRotate.Z);
            return vNew;
        }
        internal static PropertiesEnum GetBasePropertyFromProperty(PropertiesEnum iProperty)
        {
            return iProperty switch
            {
                PropertiesEnum.PROPERTY_HIGH_APT_1 or PropertiesEnum.PROPERTY_HIGH_APT_2 or PropertiesEnum.PROPERTY_HIGH_APT_3 or PropertiesEnum.PROPERTY_HIGH_APT_4 or PropertiesEnum.PROPERTY_HIGH_APT_5 or PropertiesEnum.PROPERTY_HIGH_APT_6 or PropertiesEnum.PROPERTY_HIGH_APT_7 => PropertiesEnum.PROPERTY_HIGH_APT_1,
                PropertiesEnum.PROPERTY_MEDIUM_APT_1 or PropertiesEnum.PROPERTY_MEDIUM_APT_2 or PropertiesEnum.PROPERTY_MEDIUM_APT_3 or PropertiesEnum.PROPERTY_MEDIUM_APT_4 or PropertiesEnum.PROPERTY_MEDIUM_APT_5 or PropertiesEnum.PROPERTY_MEDIUM_APT_6 or PropertiesEnum.PROPERTY_MEDIUM_APT_7 or PropertiesEnum.PROPERTY_MEDIUM_APT_8 or PropertiesEnum.PROPERTY_MEDIUM_APT_9 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2 => PropertiesEnum.PROPERTY_MEDIUM_APT_1,
                PropertiesEnum.PROPERTY_LOW_APT_1 or PropertiesEnum.PROPERTY_LOW_APT_2 or PropertiesEnum.PROPERTY_LOW_APT_3 or PropertiesEnum.PROPERTY_LOW_APT_4 or PropertiesEnum.PROPERTY_LOW_APT_5 or PropertiesEnum.PROPERTY_LOW_APT_6 or PropertiesEnum.PROPERTY_LOW_APT_7 or PropertiesEnum.PROPERTY_IND_DAY_LOW_1 or PropertiesEnum.PROPERTY_IND_DAY_LOW_2 or PropertiesEnum.PROPERTY_IND_DAY_LOW_3 => PropertiesEnum.PROPERTY_LOW_APT_1,
                PropertiesEnum.PROPERTY_BUS_HIGH_APT_1 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_2 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_3 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_4 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_5 => PropertiesEnum.PROPERTY_BUS_HIGH_APT_1,
                PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B or PropertiesEnum.PROPERTY_STILT_APT_2_B or PropertiesEnum.PROPERTY_STILT_APT_3_B or PropertiesEnum.PROPERTY_STILT_APT_4_B => PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B,
                PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A or PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE or PropertiesEnum.PROPERTY_CUSTOM_APT_2 or PropertiesEnum.PROPERTY_CUSTOM_APT_3 or PropertiesEnum.PROPERTY_YACHT_APT_1_BASE => PropertiesEnum.PROPERTY_YACHT_APT_1_BASE,
                PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_4 => PropertiesEnum.PROPERTY_OFFICE_2_BASE,
                PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A => PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A,
                PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B,
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1,
                _ => (PropertiesEnum)(-1),
            };
        }
        internal static bool IsPropertyClubhouse(PropertiesEnum iPropertyID, PropertiesEnum iBaseLayout = (PropertiesEnum)(-1))
        {
            if (iBaseLayout == (PropertiesEnum)(-1))
            {
                switch (iPropertyID)
                {
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                        return true;
                }
            }
            else if (iBaseLayout == PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A)
            {
                switch (iPropertyID)
                {
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                        return true;
                }
            }
            else if (iBaseLayout == PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B)
            {
                switch (iPropertyID)
                {
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                    case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                        return true;
                }
            }
            return false;
        }
        internal static bool IsPropertyCustomApartment(PropertiesEnum iPropertyID)
        {
            switch (iPropertyID)
            {
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                    return true;
            }
            return false;
        }
        internal static bool IsPropertyOffice(PropertiesEnum iPropertyID)
        {
            return iPropertyID switch
            {
                PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_4 => true,
                _ => false,
            };
        }
        internal static bool IsPropertyStiltApartment(PropertiesEnum iPropertyID, PropertiesEnum iBaseLayout = (PropertiesEnum)(-1))
        {
            switch (iBaseLayout)
            {
                case (PropertiesEnum)(-1):
                    switch (iPropertyID)
                    {
                        case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_10_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_12_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                            return true;
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    switch (iPropertyID)
                    {
                        case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_10_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_12_A:
                        case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                            return true;
                    }
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                    switch (iPropertyID)
                    {
                        case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                        case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                            return true;
                    }
                    break;
            }
            return false;
        }
        internal static void GetBuildingExteriorDetailsFull(ref PropertyData propertyDetails, BuildingsEnum iBuilding)
        {
            Position buzzerOffset = new();
            propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    propertyDetails.PurchaseLocation = new(-773.4775f, 310.6321f, 84.6981f);
                    propertyDetails.BlipLocation[0] = new(-773.6766f, 310.0611f, 84.6981f);
                    propertyDetails.BlipLocation[1] = new(-795.8660f, 307.7965f, 84.7028f);
                    propertyDetails.CamData.Pos = new(-885.9518f, 223.3702f, 88.5406f);
                    propertyDetails.CamData.Rot = new(26.6167f, 0.0000f, -45.2182f);
                    propertyDetails.CamData.FOV = 49.3611f;
                    propertyDetails.HouseHeistExitLocation = new(-774.1072f, 303.6408f, 84.7069f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-778.326843f, 313.488342f, 84.230034f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-769.400269f, 313.488617f, 87.729683f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 6.2405f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-778.78247f, 312.69183f, 84.69943f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-778.8333f, 313.5024f, 86.1362f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 0.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-774.1633f, 301.6800f, 84.7287f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 179.6133f;
                    propertyDetails.cctv[0].Pos = new(-760.2628f, 308.7320f, 88.8700f);
                    propertyDetails.cctv[0].Rot = new(-15.5240f, -0.0000f, 96.4358f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-796.180420f, 307.5f, 84.209877f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-796.152527f, 314.767395f, 89.192497f);
                    propertyDetails.Entrance[1].locateDetails.Width = 9.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 359.8296f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-790.31415f, 308.08603f, 84.70361f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-790.2910f, 308.7186f, 86.1399f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -0.46f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-801.4907f, 309.0866f, 90.1835f);
                    propertyDetails.cctv[1].Rot = new(-22.1431f, 6.4677f, -147.0698f);
                    propertyDetails.cctv[1].FOV = 52.8642f;
                    propertyDetails.Garage.ExitPlayerPos = new(-789.7264f, 306.3527f, 84.7041f);
                    propertyDetails.Garage.ExitPlayerHeading = 138.5170f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-797.8920f, 309.0646f, 84.7099f);
                    propertyDetails.Garage.CarExitHeading[0] = 178.3762f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-794.1440f, 308.9016f, 84.7101f);
                    propertyDetails.Garage.CarExitHeading[1] = 182.3833f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-795.4863f, 301.8851f, 84.7067f);
                    propertyDetails.Garage.CarExitHeading[2] = 180.8176f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-791.7180f, 302.1822f, 84.7114f);
                    propertyDetails.Garage.CarExitHeading[3] = 179.7487f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-799.1396f, 301.9907f, 84.7020f);
                    propertyDetails.Garage.CarExitHeading[4] = 180.1214f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    propertyDetails.PurchaseLocation = new(-250.8403f, -946.8867f, 30.2210f);
                    propertyDetails.BlipLocation[0] = new(-261.9f, -970.1f, 30.4f);
                    propertyDetails.BlipLocation[1] = new(-281.5628f, -995.2958f, 23.1968f);
                    propertyDetails.CamData.Pos = new(-213.5606f, -1073.0078f, 32.9946f);
                    propertyDetails.CamData.Rot = new(22.7554f, 0.0000f, 28.5746f);
                    propertyDetails.CamData.FOV = 50.0029f;
                    propertyDetails.HouseHeistExitLocation = new(-258.6570f, -979.0373f, 30.2196f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-263.624054f, -971.435181f, 30.219469f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-259.746216f, -969.732910f, 33.219643f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 45.6118f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-260.03949f, -969.30920f, 30.21964f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-260.5696f, -969.0703f, 31.7697f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 62.19f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-250.4661f, -948.8276f, 30.2210f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 280.3501f;
                    propertyDetails.cctv[0].Pos = new(-267.5294f, -972.4159f, 33.8078f);
                    propertyDetails.cctv[0].Rot = new(-29.1007f, -0.0000f, -87.3852f);
                    propertyDetails.cctv[0].FOV = 63.7505f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-283.662781f, -994.513123f, 22.886221f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-278.313446f, -996.504456f, 26.923477f);
                    propertyDetails.Entrance[1].locateDetails.Width = 9.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 72.7851f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-280.02359f, -991.71930f, 23.23886f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-280.5642f, -991.5149f, 24.8514f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 70.39f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-272.2346f, -994.4540f, 29.0453f);
                    propertyDetails.cctv[1].Rot = new(-27.4266f, 0.0000f, 97.1765f);
                    propertyDetails.cctv[1].FOV = 50.0000f;
                    propertyDetails.Garage.ExitPlayerPos = new(-246.8039f, -1002.9652f, 28.0879f);
                    propertyDetails.Garage.ExitPlayerHeading = 317.9801f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-275.3677f, -999.8269f, 24.4617f);
                    propertyDetails.Garage.CarExitHeading[0] = 250.0199f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-267.1935f, -1002.8241f, 25.8638f);
                    propertyDetails.Garage.CarExitHeading[1] = 250.0199f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-259.9177f, -1005.3362f, 27.0322f);
                    propertyDetails.Garage.CarExitHeading[2] = 250.0199f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-253.0097f, -1007.8217f, 28.0031f);
                    propertyDetails.Garage.CarExitHeading[3] = 250.0199f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-250.7050f, -998.8266f, 28.3060f);
                    propertyDetails.Garage.CarExitHeading[4] = 252.2370f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    propertyDetails.PurchaseLocation = new(-1438.1409f, -546.4819f, 33.7424f);
                    propertyDetails.BlipLocation[0] = new(-1443.0938f, -544.7684f, 33.7424f);
                    propertyDetails.BlipLocation[1] = new(-1456.1455f, -503.6975f, 31.1250f);
                    propertyDetails.CamData.Pos = new(-1392.0742f, -570.8373f, 31.4774f);
                    propertyDetails.CamData.Rot = new(30.5301f, -0.0000f, 64.2307f);
                    propertyDetails.CamData.FOV = 35.9982f;
                    propertyDetails.HouseHeistExitLocation = new(-1437.5380f, -548.4748f, 33.7424f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1443.327148f, -544.265381f, 33.242393f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1442.531982f, -545.398010f, 36.742393f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 33.6492f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1441.43677f, -543.96490f, 33.74239f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1441.8552f, -543.4296f, 35.2561f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 34.30f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1441.4111f, -546.8956f, 33.7424f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 228.9348f;
                    propertyDetails.cctv[0].Pos = new(-1440.3973f, -543.9622f, 38.4101f);
                    propertyDetails.cctv[0].Rot = new(-50.8306f, -0.0000f, 146.0578f);
                    propertyDetails.cctv[0].FOV = 66.6860f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1454.586548f, -504.594635f, 30.909817f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1456.920288f, -501.004547f, 34.775024f);
                    propertyDetails.Entrance[1].locateDetails.Width = 7.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 215.8951f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1453.77197f, -499.83475f, 31.65348f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1453.5149f, -500.2265f, 33.0628f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -145.70f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1461.3362f, -504.5396f, 34.1800f);
                    propertyDetails.cctv[1].Rot = new(-33.3185f, -0.0000f, -101.1299f);
                    propertyDetails.cctv[1].FOV = 79.7441f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1461.4781f, -502.4903f, 31.9616f);
                    propertyDetails.Garage.ExitPlayerHeading = 344.4053f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1457.9415f, -500.4242f, 31.5223f);
                    propertyDetails.Garage.CarExitHeading[0] = 34.5619f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1456.4272f, -494.6811f, 32.0311f);
                    propertyDetails.Garage.CarExitHeading[1] = 327.6367f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1451.8315f, -489.7961f, 33.1993f);
                    propertyDetails.Garage.CarExitHeading[2] = 303.4561f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1460.2089f, -490.6057f, 32.3611f);
                    propertyDetails.Garage.CarExitHeading[3] = 305.0743f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1454.5066f, -486.7246f, 33.3460f);
                    propertyDetails.Garage.CarExitHeading[4] = 304.9227f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    propertyDetails.PurchaseLocation = new(-916.2685f, -457.9519f, 38.5999f);
                    propertyDetails.BlipLocation[0] = new(-913.8500f, -455.1392f, 38.5999f);
                    propertyDetails.BlipLocation[1] = new(-820.8674f, -436.8401f, 35.6417f);
                    propertyDetails.CamData.Pos = new(-961.9043f, -550.0120f, 32.5747f);
                    propertyDetails.CamData.Rot = new(28.8097f, 0.0000f, -26.8876f);
                    propertyDetails.CamData.FOV = 50f;
                    propertyDetails.HouseHeistExitLocation = new(-926.9868f, -458.9109f, 36.2744f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-916.711792f, -448.500092f, 38.835438f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-912.639038f, -456.802185f, 41.344563f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 283.8998f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-913.59485f, -456.44321f, 38.59986f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-912.8546f, -456.0751f, 40.1971f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -63.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-916.9406f, -458.2739f, 38.5999f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 118.3416f;
                    propertyDetails.cctv[0].Pos = new(-918.8735f, -446.8497f, 43.3190f);
                    propertyDetails.cctv[0].Rot = new(-27.7029f, -0.0000f, 171.7493f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-820.249573f, -436.822754f, 35.229187f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-824.775940f, -439.070343f, 39.390945f);
                    propertyDetails.Entrance[1].locateDetails.Width = 8.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 303.8392f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-819.69104f, -440.63336f, 35.63988f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-819.3383f, -441.3292f, 37.2220f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -153.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-819.8430f, -441.3822f, 40.5771f);
                    propertyDetails.cctv[1].Rot = new(-45.4656f, 0.0000f, 22.1899f);
                    propertyDetails.cctv[1].FOV = 62.5824f;
                    propertyDetails.Garage.ExitPlayerPos = new(-831.2813f, -421.1668f, 35.7651f);
                    propertyDetails.Garage.ExitPlayerHeading = 115.6516f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-825.1858f, -437.1445f, 35.6399f);
                    propertyDetails.Garage.CarExitHeading[0] = 116.8246f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-823.4354f, -440.7882f, 35.6399f);
                    propertyDetails.Garage.CarExitHeading[1] = 120.1966f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-828.4323f, -430.9531f, 35.6402f);
                    propertyDetails.Garage.CarExitHeading[2] = 122.4224f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-830.1832f, -427.4356f, 35.6402f);
                    propertyDetails.Garage.CarExitHeading[3] = 117.4938f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-831.9682f, -437.3509f, 35.6399f);
                    propertyDetails.Garage.CarExitHeading[4] = 1f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    propertyDetails.PurchaseLocation = new(-49.5410f, -581.6407f, 36.1681f);
                    propertyDetails.BlipLocation[0] = new(-47.3145f, -585.9766f, 36.9593f);
                    propertyDetails.BlipLocation[1] = new(-33.4055f, -621.6096f, 34.0626f);
                    propertyDetails.CamData.Pos = new(-67.3495f, -513.4921f, 42.6787f);
                    propertyDetails.CamData.Rot = new(23.7233f, 0.0000f, -151.7019f);
                    propertyDetails.CamData.FOV = 55.5648f;
                    propertyDetails.HouseHeistExitLocation = new(-54.8035f, -583.1857f, 35.8327f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-47.951832f, -585.801147f, 36.459324f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-46.808289f, -586.207764f, 40.023293f);
                    propertyDetails.Entrance[0].locateDetails.Width = 5.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 257.7099f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-48.91060f, -589.79462f, 36.95801f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-49.0912f, -590.4172f, 38.4656f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 160.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-50.2013f, -584.2267f, 35.8979f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 73.2695f;
                    propertyDetails.cctv[0].Pos = new(-49.4323f, -589.8673f, 40.3768f);
                    propertyDetails.cctv[0].Rot = new(-33.5740f, 0.0000f, -12.6715f);
                    propertyDetails.cctv[0].FOV = 64.1407f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-29.237755f, -623.199158f, 33.632519f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-34.747360f, -621.288330f, 38.789433f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.250000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 73.2531f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-32.09113f, -619.14569f, 34.22395f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-32.7921f, -618.8801f, 35.2212f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 70.13f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-34.8441f, -625.3490f, 38.6518f);
                    propertyDetails.cctv[1].Rot = new(-31.8634f, -0.0000f, -53.0187f);
                    propertyDetails.cctv[1].FOV = 58.2563f;
                    propertyDetails.Garage.ExitPlayerPos = new(-32.8449f, -625.3205f, 34.2937f);
                    propertyDetails.Garage.ExitPlayerHeading = 244.5756f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-28.0896f, -623.9330f, 34.4009f);
                    propertyDetails.Garage.CarExitHeading[0] = 253.5360f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-20.8009f, -626.0856f, 34.7246f);
                    propertyDetails.Garage.CarExitHeading[1] = 253.5255f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-13.5114f, -635.1727f, 34.7246f);
                    propertyDetails.Garage.CarExitHeading[2] = 342.8254f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-10.9497f, -627.4315f, 34.7246f);
                    propertyDetails.Garage.CarExitHeading[3] = 339.6547f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-8.0308f, -619.5068f, 35.0813f);
                    propertyDetails.Garage.CarExitHeading[4] = 338.0451f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    propertyDetails.PurchaseLocation = new(-938.8708f, -378.8302f, 37.9613f);
                    propertyDetails.BlipLocation[0] = new(-932.8344f, -383.6555f, 37.9613f);
                    propertyDetails.BlipLocation[1] = new(-877.7446f, -359.9399f, 34.8356f);
                    propertyDetails.CamData.Pos = new(-960.2891f, -472.7867f, 39.0439f);
                    propertyDetails.CamData.Rot = new(24.7986f, 0.0409f, -21.4827f);
                    propertyDetails.CamData.FOV = 52.0185f;
                    propertyDetails.HouseHeistExitLocation = new(-933.3674f, -395.4044f, 37.9613f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-932.029907f, -383.208466f, 37.461254f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-933.481567f, -383.947510f, 40.961254f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 294.3158f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-934.88226f, -380.37585f, 37.96125f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-934.3623f, -380.0636f, 39.6193f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -62.99f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-935.1856f, -384.7494f, 37.9613f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 124.6926f;
                    propertyDetails.cctv[0].Pos = new(-937.7342f, -382.6371f, 41.9208f);
                    propertyDetails.cctv[0].Rot = new(-27.8942f, 0.0000f, -96.6988f);
                    propertyDetails.cctv[0].FOV = 57.8662f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-878.411438f, -358.720154f, 34.315826f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-875.646484f, -363.797394f, 38.616428f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 25.4424f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-875.52026f, -359.54578f, 34.85448f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-875.1261f, -359.3368f, 36.5067f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -63.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-880.0004f, -360.9817f, 37.9450f);
                    propertyDetails.cctv[1].Rot = new(-40.5587f, 0.0000f, -86.9507f);
                    propertyDetails.cctv[1].FOV = 70.6367f;
                    propertyDetails.Garage.ExitPlayerPos = new(-866.4783f, -374.2520f, 38.5193f);
                    propertyDetails.Garage.ExitPlayerHeading = 207.0932f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-876.1686f, -362.7803f, 35.2834f);
                    propertyDetails.Garage.CarExitHeading[0] = 210.3103f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-872.5136f, -370.2674f, 37.3645f);
                    propertyDetails.Garage.CarExitHeading[1] = 208.8528f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-868.9897f, -377.3745f, 38.3081f);
                    propertyDetails.Garage.CarExitHeading[2] = 205.0445f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-858.4080f, -377.1530f, 38.3760f);
                    propertyDetails.Garage.CarExitHeading[3] = 117.6478f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-879.7519f, -385.9676f, 38.0070f);
                    propertyDetails.Garage.CarExitHeading[4] = 111.2521f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    propertyDetails.PurchaseLocation = new(-618.4424f, 32.5811f, 42.5305f);
                    propertyDetails.BlipLocation[0] = new(-619.1315f, 37.8841f, 42.5883f);
                    propertyDetails.BlipLocation[1] = new(-630.5854f, 56.6084f, 42.7250f);
                    propertyDetails.CamData.Pos = new(-667.2404f, -25.1369f, 43.1678f);
                    propertyDetails.CamData.Rot = new(21.8261f, -0.0000f, -39.9922f);
                    propertyDetails.CamData.FOV = 48.3545f;
                    propertyDetails.HouseHeistExitLocation = new(-618.4301f, 31.9811f, 42.5303f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-622.613953f, 38.369530f, 42.706711f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-613.729797f, 38.366718f, 45.550163f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.75f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 356.9405f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-614.03992f, 36.98944f, 42.56974f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-613.5477f, 36.9706f, 44.2302f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-614.7665f, 40.6905f, 42.5906f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 173.3715f;
                    propertyDetails.cctv[0].Pos = new(-613.7437f, 34.6647f, 46.9721f);
                    propertyDetails.cctv[0].Rot = new(-35.5307f, -0.0000f, 68.8590f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-629.871582f, 56.232082f, 42.224960f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-634.594727f, 56.239681f, 47.224960f);
                    propertyDetails.Entrance[1].locateDetails.Width = 10.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 272.9018f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-631.31433f, 52.52833f, 42.72496f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-631.3015f, 51.9951f, 44.3777f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 180.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-638.8582f, 62.4140f, 46.2529f);
                    propertyDetails.cctv[1].Rot = new(-14.5847f, 0.0000f, -138.3022f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-637.4379f, 59.9699f, 43.4399f);
                    propertyDetails.Garage.ExitPlayerHeading = 110.4011f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-636.2328f, 53.4510f, 42.4178f);
                    propertyDetails.Garage.CarExitHeading[0] = 93.8782f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-636.4083f, 56.4379f, 42.7701f);
                    propertyDetails.Garage.CarExitHeading[1] = 92.4188f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-636.2635f, 59.5577f, 43.2135f);
                    propertyDetails.Garage.CarExitHeading[2] = 90.1560f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-642.7320f, 60.1266f, 43.7986f);
                    propertyDetails.Garage.CarExitHeading[3] = 86.9803f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-642.8851f, 55.8529f, 42.6135f);
                    propertyDetails.Garage.CarExitHeading[4] = 89.2534f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    propertyDetails.PurchaseLocation = new(282.0378f, -158.5011f, 62.6221f);
                    propertyDetails.BlipLocation[0] = new(284.6026f, -160.2201f, 63.6221f);
                    propertyDetails.BlipLocation[1] = new(280.2899f, -146.4596f, 64.1177f);
                    propertyDetails.CamData.Pos = new(263.1562f, -117.1081f, 76.7280f);
                    propertyDetails.CamData.Rot = new(-8.1170f, -0.0000f, -147.0301f);
                    propertyDetails.CamData.FOV = 37.9554f;
                    propertyDetails.HouseHeistExitLocation = new(272.6708f, -156.0256f, 62.3682f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(286.772583f, -159.575562f, 63.181328f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(286.066681f, -161.513718f, 66.677803f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 250.5252f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(285.21463f, -162.04276f, 63.62207f);
                    propertyDetails.Entrance[0].BuzzerProp = new(285.8317f, -162.2050f, 65.1628f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -110.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(282.6784f, -158.9562f, 62.6221f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 71.7708f;
                    propertyDetails.cctv[0].Pos = new(284.4029f, -164.5213f, 68.2954f);
                    propertyDetails.cctv[0].Rot = new(-36.4588f, -0.0000f, 18.4559f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(286.919922f, -145.680756f, 63.564697f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(284.928833f, -151.150833f, 67.925255f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.250000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 250.4756f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(285.92123f, -144.60461f, 64.08031f);
                    propertyDetails.Entrance[1].BuzzerProp = new(286.4148f, -144.7555f, 65.6753f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -110.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(286.9442f, -142.8617f, 68.4190f);
                    propertyDetails.cctv[1].Rot = new(-28.8168f, 3.9695f, 133.9510f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(274.3903f, -137.1274f, 65.7109f);
                    propertyDetails.Garage.ExitPlayerHeading = 89.7489f;
                    propertyDetails.Garage.CarExitLoc[0] = new(278.6978f, -145.3078f, 64.2479f);
                    propertyDetails.Garage.CarExitHeading[0] = 66.6052f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(269.8685f, -133.7206f, 65.8865f);
                    propertyDetails.Garage.CarExitHeading[1] = 342.0529f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(283.8793f, -135.1920f, 66.3761f);
                    propertyDetails.Garage.CarExitHeading[2] = 68.5635f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(270.2002f, -163.5318f, 59.9760f);
                    propertyDetails.Garage.CarExitHeading[3] = 69.4681f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(265.3670f, -150.3620f, 62.7343f);
                    propertyDetails.Garage.CarExitHeading[4] = 338.2748f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    propertyDetails.PurchaseLocation = new(2.8889f, 35.7762f, 70.5349f);
                    propertyDetails.BlipLocation[0] = new(2.8400f, 35.2876f, 70.5349f);
                    propertyDetails.BlipLocation[1] = new(-11.7956f, 36.4751f, 70.6604f);
                    propertyDetails.CamData.Pos = new(-19.3488f, -9.4322f, 89.2875f);
                    propertyDetails.CamData.Rot = new(-5.8716f, -0.0000f, -21.2911f);
                    propertyDetails.CamData.FOV = 40.1614f;
                    propertyDetails.HouseHeistExitLocation = new(0.7433f, 30.9570f, 70.0813f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(2.701670f, 37.918968f, 69.364952f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(4.666537f, 37.202835f, 73.375526f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 336.3539f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(5.72587f, 36.02024f, 70.53527f);
                    propertyDetails.Entrance[0].BuzzerProp = new(6.1991f, 35.8211f, 72.1210f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -110.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(1.7704f, 32.7973f, 70.0909f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 149.8567f;
                    propertyDetails.cctv[0].Pos = new(5.6274f, 36.3837f, 73.3125f);
                    propertyDetails.cctv[0].Rot = new(-32.9240f, -0.0000f, 101.9878f);
                    propertyDetails.cctv[0].FOV = 50.5336f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-15.476118f, 44.577019f, 69.848953f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-4.834036f, 40.702763f, 73.876465f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 345.9296f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-10.3984f, 41.7438f, 70.4113f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-5.2392f, 39.6933f, 71.7436f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -110.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-3.7128f, 38.3486f, 74.8271f);
                    propertyDetails.cctv[1].Rot = new(-30.1420f, 4.8180f, 92.9892f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-4.8106f, 34.7009f, 70.3499f);
                    propertyDetails.Garage.ExitPlayerHeading = 165.3343f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-14.0049f, 39.8929f, 70.7672f);
                    propertyDetails.Garage.CarExitHeading[0] = 161.0269f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-8.7064f, 37.7788f, 70.5283f);
                    propertyDetails.Garage.CarExitHeading[1] = 161.1748f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-13.4518f, 32.8482f, 70.5989f);
                    propertyDetails.Garage.CarExitHeading[2] = 160.3379f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-19.8498f, 34.1721f, 70.7425f);
                    propertyDetails.Garage.CarExitHeading[3] = 111.2427f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-9.1111f, 30.4793f, 70.2918f);
                    propertyDetails.Garage.CarExitHeading[4] = 206.6557f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    propertyDetails.PurchaseLocation = new(9.7400f, 84.6906f, 77.3975f);
                    propertyDetails.BlipLocation[0] = new(10.4433f, 83.3155f, 77.3975f);
                    propertyDetails.BlipLocation[1] = new(26.8874f, 82.7536f, 73.7902f);
                    propertyDetails.CamData.Pos = new(-42.7037f, 92.9252f, 89.2578f);
                    propertyDetails.CamData.Rot = new(-6.9786f, -0.0000f, -109.8209f);
                    propertyDetails.CamData.FOV = 42.5562f;
                    propertyDetails.HouseHeistExitLocation = new(-11.8278f, 96.4341f, 77.5908f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(10.325045f, 80.742813f, 77.242455f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(8.381888f, 81.452484f, 80.495377f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 161.0883f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(11.84303f, 81.16698f, 77.43491f);
                    propertyDetails.Entrance[0].BuzzerProp = new(12.5023f, 80.8683f, 78.9946f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -110.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-12.7328f, 94.7645f, 77.2155f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 140.6907f;
                    propertyDetails.cctv[0].Pos = new(14.4919f, 82.5583f, 80.6919f);
                    propertyDetails.cctv[0].Rot = new(-19.3660f, 0.0000f, 70.3056f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(28.161423f, 75.670265f, 73.520164f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(22.641685f, 77.677490f, 77.291046f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 159.8871f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(23.60801f, 78.95453f, 73.63702f);
                    propertyDetails.Entrance[1].BuzzerProp = new(23.3697f, 78.2563f, 75.2878f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 160.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(21.0105f, 79.3261f, 76.9841f);
                    propertyDetails.cctv[1].Rot = new(-23.5919f, 2.1002f, -88.4588f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(30.0462f, 77.2835f, 73.7957f);
                    propertyDetails.Garage.ExitPlayerHeading = 280.8853f;
                    propertyDetails.Garage.CarExitLoc[0] = new(23.1398f, 81.3826f, 73.6617f);
                    propertyDetails.Garage.CarExitHeading[0] = 282.8950f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(30.0217f, 79.9709f, 73.9552f);
                    propertyDetails.Garage.CarExitHeading[1] = 279.5829f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(38.0929f, 77.4687f, 74.4692f);
                    propertyDetails.Garage.CarExitHeading[2] = 247.9818f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(47.0701f, 79.3809f, 75.4097f);
                    propertyDetails.Garage.CarExitHeading[3] = 340.0299f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(43.1922f, 69.5084f, 73.3978f);
                    propertyDetails.Garage.CarExitHeading[4] = 159.0439f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    propertyDetails.PurchaseLocation = new(-512.1465f, 111.2223f, 62.3510f);
                    propertyDetails.BlipLocation[0] = new(-512.0948f, 110.6228f, 62.5925f);
                    propertyDetails.BlipLocation[1] = new(-496.6235f, 84.2570f, 54.8619f);
                    propertyDetails.CamData.Pos = new(-534.6452f, 137.1912f, 75.7177f);
                    propertyDetails.CamData.Rot = new(-4.1062f, -0.0000f, -142.8033f);
                    propertyDetails.CamData.FOV = 36.7108f;
                    propertyDetails.HouseHeistExitLocation = new(-512.1901f, 115.9776f, 62.3180f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-510.475555f, 107.988213f, 60.590782f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-512.752014f, 107.668503f, 65.344360f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 194.6077f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-510.23291f, 108.61990f, 62.80056f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-510.1327f, 108.0511f, 64.2438f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -172.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-512.5056f, 111.1181f, 62.3456f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 19.9820f;
                    propertyDetails.cctv[0].Pos = new(-508.4918f, 109.1324f, 65.8247f);
                    propertyDetails.cctv[0].Rot = new(-19.4084f, 0.0000f, 61.2413f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-495.923798f, 87.288429f, 54.637875f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-496.089264f, 81.490707f, 58.332943f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 272.1017f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-497.05954f, 78.38213f, 54.88129f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-496.4968f, 78.3370f, 56.4797f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -91.5f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-496.7119f, 77.6624f, 59.1793f);
                    propertyDetails.cctv[1].Rot = new(-28.4671f, 4.9064f, 26.2850f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-498.7155f, 79.4350f, 55.0144f);
                    propertyDetails.Garage.ExitPlayerHeading = 88.8337f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-499.8006f, 84.5234f, 55.1152f);
                    propertyDetails.Garage.CarExitHeading[0] = 88.4420f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-508.5442f, 84.7626f, 55.8091f);
                    propertyDetails.Garage.CarExitHeading[1] = 88.4254f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-517.9949f, 85.0214f, 56.5581f);
                    propertyDetails.Garage.CarExitHeading[2] = 88.4314f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-529.6277f, 84.8542f, 57.3585f);
                    propertyDetails.Garage.CarExitHeading[3] = 91.5164f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-538.8803f, 84.3561f, 57.4109f);
                    propertyDetails.Garage.CarExitHeading[4] = 84.0946f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    propertyDetails.PurchaseLocation = new(-197.3405f, 88.1053f, 68.7422f);
                    propertyDetails.BlipLocation[0] = new(-197.5160f, 87.9089f, 68.7457f);
                    propertyDetails.BlipLocation[1] = new(-213.6f, 38.0f, 60.5f);
                    propertyDetails.CamData.Pos = new(-198.4187f, 129.4615f, 77.2345f);
                    propertyDetails.CamData.Rot = new(-1.6958f, -0.0000f, -165.7142f);
                    propertyDetails.CamData.FOV = 39.1733f;
                    propertyDetails.HouseHeistExitLocation = new(-202.4989f, 98.5772f, 68.4945f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-197.095963f, 85.238091f, 67.555412f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-198.594254f, 85.553360f, 71.305954f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 171.9653f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-198.96335f, 86.33958f, 68.75433f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-199.1217f, 85.5957f, 70.3121f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 169.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-199.7983f, 94.9680f, 68.5241f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 33.5049f;
                    propertyDetails.cctv[0].Pos = new(-195.7844f, 86.3135f, 72.2746f);
                    propertyDetails.cctv[0].Rot = new(-20.9847f, -0.0000f, 31.3591f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-211.768188f, 31.646317f, 58.199608f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-209.551559f, 43.916500f, 62.879993f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 267.3955f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-212.29578f, 32.53296f, 58.82444f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-212.4217f, 31.8592f, 60.4929f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 171.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-209.6682f, 68.0340f, 69.8104f);
                    propertyDetails.cctv[1].Rot = new(-21.8220f, -0.0000f, -10.4246f);
                    propertyDetails.cctv[1].FOV = 62.2409f;
                    propertyDetails.Garage.ExitPlayerPos = new(-208.6779f, 79.2142f, 66.6934f);
                    propertyDetails.Garage.ExitPlayerHeading = 70.3424f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-215.2726f, 36.7172f, 58.5308f);
                    propertyDetails.Garage.CarExitHeading[0] = 83.0326f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-214.0385f, 40.5861f, 59.1211f);
                    propertyDetails.Garage.CarExitHeading[1] = 80.4651f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-222.0280f, 39.8632f, 58.6695f);
                    propertyDetails.Garage.CarExitHeading[2] = 78.6603f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-220.3056f, 43.9508f, 59.7136f);
                    propertyDetails.Garage.CarExitHeading[3] = 80.1687f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-222.5635f, 35.5804f, 57.6641f);
                    propertyDetails.Garage.CarExitHeading[4] = 82.3515f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    propertyDetails.PurchaseLocation = new(-631.8065f, 170.2451f, 60.3941f);
                    propertyDetails.BlipLocation[0] = new(-628.8236f, 169.5813f, 60.1437f);
                    propertyDetails.BlipLocation[1] = new(-628.5014f, 152.7422f, 55.7063f);
                    propertyDetails.CamData.Pos = new(-696.6976f, 83.2761f, 71.5015f);
                    propertyDetails.CamData.Rot = new(1.1701f, 0.0000f, -49.3976f);
                    propertyDetails.CamData.FOV = 23.6246f;
                    propertyDetails.HouseHeistExitLocation = new(-637.3282f, 169.9458f, 60.4572f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-627.389526f, 171.053070f, 62.466927f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-627.391663f, 168.346619f, 59.978931f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 277.9590f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-628.05597f, 168.08670f, 60.15696f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-627.3870f, 168.1326f, 61.8173f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-630.0102f, 169.6864f, 60.2309f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 92.4426f;
                    propertyDetails.cctv[0].Pos = new(-628.4830f, 163.9228f, 64.2357f);
                    propertyDetails.cctv[0].Rot = new(-30.7736f, -0.0000f, 7.6243f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-625.982178f, 155.987778f, 59.131115f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-625.976318f, 148.717606f, 55.129967f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 274.2654f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-626.45874f, 149.28088f, 55.50729f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-626.4755f, 148.8474f, 57.1539f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 179.5f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-626.3999f, 148.4401f, 59.2913f);
                    propertyDetails.cctv[1].Rot = new(-30.5292f, 2.6808f, 39.3670f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-637.4221f, 158.0952f, 57.6976f);
                    propertyDetails.Garage.ExitPlayerHeading = 98.4512f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-630.2997f, 152.3060f, 55.9224f);
                    propertyDetails.Garage.CarExitHeading[0] = 88.1313f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-638.1433f, 150.1428f, 56.6599f);
                    propertyDetails.Garage.CarExitHeading[1] = 105.7233f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-638.8364f, 154.3290f, 57.0811f);
                    propertyDetails.Garage.CarExitHeading[2] = 76.4708f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-642.5622f, 144.1441f, 56.0075f);
                    propertyDetails.Garage.CarExitHeading[3] = 178.5606f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-643.6265f, 161.9029f, 58.4242f);
                    propertyDetails.Garage.CarExitHeading[4] = 2.3175f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    propertyDetails.PurchaseLocation = new(-973.3757f, -1429.4247f, 6.6791f);
                    propertyDetails.BlipLocation[0] = new(-970.4616f, -1431.5524f, 6.6791f);
                    propertyDetails.BlipLocation[1] = new(-979.8791f, -1449.7249f, 3.7352f);
                    propertyDetails.CamData.Pos = new(-1005.5947f, -1485.3966f, 16.3224f);
                    propertyDetails.CamData.Rot = new(-0.7255f, -0.0000f, -31.8818f);
                    propertyDetails.CamData.FOV = 38.7981f;
                    propertyDetails.HouseHeistExitLocation = new(-990.0446f, -1438.6542f, 4.0512f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-969.659302f, -1429.291748f, 9.274211f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-968.322571f, -1432.799561f, 5.267247f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 288.7475f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-968.99982f, -1433.18250f, 6.67908f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-968.2812f, -1432.9247f, 8.1858f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 70.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-975.5323f, -1435.4574f, 6.6791f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 114.4599f;
                    propertyDetails.cctv[0].Pos = new(-974.1971f, -1427.8442f, 9.1311f);
                    propertyDetails.cctv[0].Rot = new(-10.8710f, -0.0000f, -136.9180f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-979.599548f, -1446.877319f, 6.075722f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-977.940308f, -1451.485474f, 3.582479f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.250000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 290.9057f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-980.51587f, -1447.77209f, 3.72778f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-980.7506f, -1447.0208f, 4.5223f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -70.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-977.2012f, -1452.5908f, 6.1940f);
                    propertyDetails.cctv[1].Rot = new(-22.1332f, 1.2127f, 61.7078f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-988.2418f, -1447.7733f, 4.1853f);
                    propertyDetails.Garage.ExitPlayerHeading = 119.0613f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-992.6162f, -1425.0612f, 4.0163f);
                    propertyDetails.Garage.CarExitHeading[0] = 108.4024f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-998.9100f, -1427.1215f, 4.0575f);
                    propertyDetails.Garage.CarExitHeading[1] = 109.1714f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1003.8618f, -1434.2129f, 4.0621f);
                    propertyDetails.Garage.CarExitHeading[2] = 145.2133f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1003.1061f, -1424.0535f, 4.0372f);
                    propertyDetails.Garage.CarExitHeading[3] = 109.7396f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1010.4411f, -1426.6680f, 4.0384f);
                    propertyDetails.Garage.CarExitHeading[4] = 109.6394f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    propertyDetails.PurchaseLocation = new(-829.1362f, -855.0104f, 18.6297f);
                    propertyDetails.BlipLocation[0] = new(-831.4647f, -861.3573f, 19.6944f);
                    propertyDetails.BlipLocation[1] = new(-761.7806f, -870.2498f, 20.0595f);
                    propertyDetails.CamData.Pos = new(-793.9170f, -794.2643f, 43.4654f);
                    propertyDetails.CamData.Rot = new(-9.0463f, 0.0000f, 177.2242f);
                    propertyDetails.CamData.FOV = 44.2989f;
                    propertyDetails.HouseHeistExitLocation = new(-831.3257f, -850.3224f, 18.5661f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-828.797302f, -862.990417f, 21.958952f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-833.896240f, -862.956848f, 19.441055f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 185.1126f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-833.61047f, -862.56372f, 19.69465f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-833.9494f, -862.6305f + 0.1f, 21.2407f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-831.7097f, -860.6437f, 19.6944f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 358.8877f;
                    propertyDetails.cctv[0].Pos = new(-828.6544f, -862.7701f, 23.5690f);
                    propertyDetails.cctv[0].Rot = new(-41.3573f, -0.0000f, 58.9153f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-763.505798f, -874.873962f, 23.628805f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-763.521240f, -866.558899f, 19.643551f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 91.3542f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-762.89838f, -866.16376f, 19.91171f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-763.3941f, -866.1509f, 21.3894f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-763.5423f, -875.5127f, 23.5228f);
                    propertyDetails.cctv[1].Rot = new(-21.7641f, 5.0336f, -41.0061f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-761.8991f, -865.2859f, 20.1452f);
                    propertyDetails.Garage.ExitPlayerHeading = 258.7110f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-759.5589f, -868.3928f, 20.5444f);
                    propertyDetails.Garage.CarExitHeading[0] = 268.3556f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-760.1168f, -872.2332f, 20.2893f);
                    propertyDetails.Garage.CarExitHeading[1] = 268.0820f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-754.1190f, -874.6438f, 20.7304f);
                    propertyDetails.Garage.CarExitHeading[2] = 229.9483f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-753.7412f, -869.8978f, 20.9882f);
                    propertyDetails.Garage.CarExitHeading[3] = 268.8166f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-754.4808f, -863.8301f, 21.2895f);
                    propertyDetails.Garage.CarExitHeading[4] = 311.0490f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    propertyDetails.PurchaseLocation = new(-757.5739f, -755.5591f, 25.5697f);
                    propertyDetails.BlipLocation[0] = new(-762.0167f, -753.7158f, 26.8736f);
                    propertyDetails.BlipLocation[1] = new(-786.6761f, -800.9836f, 19.6249f);
                    propertyDetails.CamData.Pos = new(-840.3021f, -913.9555f, 62.5480f);
                    propertyDetails.CamData.Rot = new(-1.9782f, -0.0000f, -29.9785f);
                    propertyDetails.CamData.FOV = 33.9137f;
                    propertyDetails.HouseHeistExitLocation = new(-753.0964f, -753.3385f, 25.6773f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-763.904480f, -756.618225f, 29.509310f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-763.893921f, -750.960815f, 25.513952f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 90.1550f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-763.18298f, -750.92767f, 26.87358f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-763.9045f, -750.8787f - 0.1f, 28.4594f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-761.0186f, -753.8593f, 26.8736f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 270.2364f;
                    propertyDetails.cctv[0].Pos = new(-763.5029f, -757.6476f, 30.9677f);
                    propertyDetails.cctv[0].Rot = new(-38.1858f, 0.0000f, -14.2267f);
                    propertyDetails.cctv[0].FOV = 50.0297f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-791.646301f, -798.515442f, 23.021124f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-781.889526f, -798.543823f, 19.494862f);
                    propertyDetails.Entrance[1].locateDetails.Width = 4.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 332.1913f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-782.69604f, -799.98175f, 19.75900f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-782.0396f, -799.9789f, 21.4256f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-792.3658f, -802.0107f, 23.5808f);
                    propertyDetails.cctv[1].Rot = new(-33.4177f, 1.7446f, -129.4547f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-790.1055f, -803.9869f, 19.6203f);
                    propertyDetails.Garage.ExitPlayerHeading = 185.4586f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-788.9369f, -802.5391f, 19.6203f);
                    propertyDetails.Garage.CarExitHeading[0] = 178.9109f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-784.7282f, -802.6130f, 19.6905f);
                    propertyDetails.Garage.CarExitHeading[1] = 178.8607f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-788.4198f, -810.0004f, 19.6203f);
                    propertyDetails.Garage.CarExitHeading[2] = 177.8878f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-788.6883f, -816.7969f, 19.8097f);
                    propertyDetails.Garage.CarExitHeading[3] = 177.8166f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-784.2047f, -821.8116f, 20.0773f);
                    propertyDetails.Garage.CarExitHeading[4] = 181.9788f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    propertyDetails.PurchaseLocation = new(-45.1289f, -57.0925f, 62.2531f);
                    propertyDetails.BlipLocation[0] = new(-41.6451f, -58.4377f, 62.5090f);
                    propertyDetails.BlipLocation[1] = new(-38.6172f, -64.4738f, 58.4488f);
                    propertyDetails.CamData.Pos = new(-83.9575f, -39.5983f, 72.6015f);
                    propertyDetails.CamData.Rot = new(-5.5826f, -0.0000f, -106.7397f);
                    propertyDetails.CamData.FOV = 24.6610f;
                    propertyDetails.HouseHeistExitLocation = new(-53.1021f, -61.7120f, 59.0581f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-40.170601f, -58.139736f, 65.369408f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-40.629402f, -59.639935f, 62.382698f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 251.3745f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-41.5895f, -58.7089f, 63.6596f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-40.9042f, -60.0130f, 64.3240f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -107.5f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-43.5543f, -61.1891f, 62.5837f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 83.4021f;
                    propertyDetails.cctv[0].Pos = new(-39.8800f, -55.6415f, 66.3075f);
                    propertyDetails.cctv[0].Rot = new(-38.5367f, 0.0000f, 135.6675f);
                    propertyDetails.cctv[0].FOV = 50.0297f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-44.137451f, -61.396339f, 61.975510f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-28.903469f, -65.975243f, 58.491375f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 349.0972f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-29.33882f, -66.43806f, 58.53217f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-28.9430f, -66.5774f, 60.2440f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -107.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-28.5985f, -67.3177f, 62.0343f);
                    propertyDetails.cctv[1].Rot = new(-16.5682f, 0.0000f, 79.5990f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-45.2779f, -63.3981f, 58.4721f);
                    propertyDetails.Garage.ExitPlayerHeading = 110.5964f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-30.9354f, -68.7573f, 58.3542f);
                    propertyDetails.Garage.CarExitHeading[0] = 196.1560f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-37.6065f, -66.7263f, 58.2968f);
                    propertyDetails.Garage.CarExitHeading[1] = 114.2586f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-43.3868f, -65.4183f, 58.2721f);
                    propertyDetails.Garage.CarExitHeading[2] = 99.3293f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-50.3881f, -64.1393f, 58.5953f);
                    propertyDetails.Garage.CarExitHeading[3] = 76.2414f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-57.0713f, -62.5026f, 58.7976f);
                    propertyDetails.Garage.CarExitHeading[4] = 77.0011f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    propertyDetails.PurchaseLocation = new(-206.7293f, 184.1420f, 79.3279f);
                    propertyDetails.BlipLocation[0] = new(-201.9074f, 186.2365f, 79.3279f);
                    propertyDetails.BlipLocation[1] = new(-204.1669f, 192.5419f, 79.0583f);
                    propertyDetails.CamData.Pos = new(-228.8237f, 215.2885f, 91.0992f);
                    propertyDetails.CamData.Rot = new(-8.9858f, -0.0000f, -135.2404f);
                    propertyDetails.CamData.FOV = 30.8687f;
                    propertyDetails.HouseHeistExitLocation = new(-213.5534f, 184.6969f, 77.9346f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-200.398987f, 186.916016f, 81.718521f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-200.398987f, 185.535553f, 75.235382f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 271.6089f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-200.92720f, 185.13937f, 79.31755f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-200.5526f, 185.1893f, 80.9715f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-205.1874f, 184.6205f, 79.3279f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 91.1398f;
                    propertyDetails.cctv[0].Pos = new(-200.7608f, 184.2875f, 82.3418f);
                    propertyDetails.cctv[0].Rot = new(-40.6867f, 0.0000f, 14.5767f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-200.468048f, 196.422760f, 82.006607f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-200.399048f, 189.026184f, 77.975861f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 261.7313f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-201.2675f, 192.7632f, 78.4640f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-200.5526f, 196.6260f, 80.0050f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-200.8381f, 197.3646f, 82.3480f);
                    propertyDetails.cctv[1].Rot = new(-21.7228f, 0.0000f, 142.5736f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-212.6341f, 187.5834f, 78.6904f);
                    propertyDetails.Garage.ExitPlayerHeading = 95.5658f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-204.3918f, 193.0630f, 79.1536f);
                    propertyDetails.Garage.CarExitHeading[0] = 87.3067f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-211.8205f, 193.6091f, 80.2532f);
                    propertyDetails.Garage.CarExitHeading[1] = 83.0203f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-216.5322f, 189.6087f, 79.1441f);
                    propertyDetails.Garage.CarExitHeading[2] = 119.5884f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-216.1513f, 197.3657f, 81.0638f);
                    propertyDetails.Garage.CarExitHeading[3] = 59.2407f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-216.4448f, 204.4023f, 82.9056f);
                    propertyDetails.Garage.CarExitHeading[4] = 353.2901f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    propertyDetails.PurchaseLocation = new(-811.7045f, -984.1961f, 13.1538f);
                    propertyDetails.BlipLocation[0] = new(-813.1431f, -981.0231f, 13.1452f);
                    propertyDetails.BlipLocation[1] = new(-800.3237f, -981.8350f, 12.4718f);
                    propertyDetails.CamData.Pos = new(-813.5714f, -1050.2361f, 23.4961f);
                    propertyDetails.CamData.Rot = new(-2.8056f, -0.0000f, -3.2598f);
                    propertyDetails.CamData.FOV = 18.4201f;
                    propertyDetails.HouseHeistExitLocation = new(-816.0616f, -992.5058f, 12.4806f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-812.958801f, -978.910461f, 16.246567f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-811.209961f, -981.407654f, 12.698908f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 306.7349f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-813.54626f, -979.87274f, 13.18758f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-813.8711f, -979.4198f, 14.7474f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 35.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-814.5236f, -983.1685f, 13.0938f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 175.3115f;
                    propertyDetails.cctv[0].Pos = new(-808.9595f, -985.3073f, 16.4923f);
                    propertyDetails.cctv[0].Rot = new(-23.3080f, -0.0000f, 54.3617f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-800.386719f, -981.656494f, 12.040546f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-802.477173f, -978.615723f, 15.516710f);
                    propertyDetails.Entrance[1].locateDetails.Width = 6.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 44.5014f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-802.67029f, -982.95984f, 12.21205f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-803.2634f, -983.3758f, 13.0737f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 34.20f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_01;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-803.7123f, -982.5094f, 14.1644f);
                    propertyDetails.cctv[1].Rot = new(-13.7254f, 2.7563f, -86.2615f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-801.9234f, -987.0692f, 12.7538f);
                    propertyDetails.Garage.ExitPlayerHeading = 221.5954f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-799.9266f, -984.2426f, 12.8616f);
                    propertyDetails.Garage.CarExitHeading[0] = 216.4714f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-797.6566f, -982.7219f, 12.9562f);
                    propertyDetails.Garage.CarExitHeading[1] = 215.8357f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-792.1985f, -981.5099f, 13.2024f);
                    propertyDetails.Garage.CarExitHeading[2] = 278.4626f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-801.3300f, -989.4982f, 12.6938f);
                    propertyDetails.Garage.CarExitHeading[3] = 164.9299f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-794.9520f, -987.8015f, 12.7256f);
                    propertyDetails.Garage.CarExitHeading[4] = 219.2995f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    propertyDetails.PurchaseLocation = new(-664.0032f, -853.6744f, 23.4325f);
                    propertyDetails.BlipLocation[0] = new(-662.4317f, -853.6143f, 23.4561f);
                    propertyDetails.BlipLocation[1] = new(-668.6993f, -854.7399f, 23.2635f);
                    propertyDetails.CamData.Pos = new(-631.6448f, -807.6888f, 43.8212f);
                    propertyDetails.CamData.Rot = new(-6.3784f, -0.0000f, 142.6094f);
                    propertyDetails.CamData.FOV = 32.7941f;
                    propertyDetails.HouseHeistExitLocation = new(-668.6069f, -848.1468f, 23.2887f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-662.426575f, -854.635681f, 25.989618f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-662.423218f, -853.754333f, 23.208197f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 193.8726f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-662.3884f, -853.9021f, 23.4638f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-663.2095f, -854.3929f, 25.1573f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -177.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-662.5104f, -852.2342f, 23.4378f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 13.9347f;
                    propertyDetails.cctv[0].Pos = new(-659.7298f, -854.2432f, 28.5561f);
                    propertyDetails.cctv[0].Rot = new(-48.9010f, -0.0000f, 63.8518f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-664.960266f, -856.675110f, 26.886330f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-670.859375f, -856.622498f, 22.886330f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 188.2017f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-665.41968f, -855.76440f, 23.35765f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-664.9559f, -855.7695f, 25.0188f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-672.7541f, -854.4485f, 26.9547f);
                    propertyDetails.cctv[1].Rot = new(-31.7934f, 2.9750f, -69.0846f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-664.1664f, -853.1893f, 23.4233f);
                    propertyDetails.Garage.ExitPlayerHeading = 356.0786f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-667.9470f, -852.0844f, 23.2814f);
                    propertyDetails.Garage.CarExitHeading[0] = 359.9586f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-661.9177f, -848.2018f, 23.4100f);
                    propertyDetails.Garage.CarExitHeading[1] = 320.3188f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-676.1816f, -846.8066f, 23.0190f);
                    propertyDetails.Garage.CarExitHeading[2] = 92.6230f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-670.7328f, -847.1837f, 23.1038f);
                    propertyDetails.Garage.CarExitHeading[3] = 30.6874f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-657.1520f, -846.9487f, 23.3693f);
                    propertyDetails.Garage.CarExitHeading[4] = 269.8845f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    propertyDetails.PurchaseLocation = new(-1534.0247f, -324.5247f, 46.5237f);
                    propertyDetails.BlipLocation[0] = new(-1533.9158f, -326.4442f, 46.9108f);
                    propertyDetails.BlipLocation[1] = new(-1529.0159f, -344.6623f, 44.3427f);
                    propertyDetails.CamData.Pos = new(-1548.3856f, -299.5765f, 56.3053f);
                    propertyDetails.CamData.Rot = new(-6.1519f, 0.0000f, -133.5596f);
                    propertyDetails.CamData.FOV = 41.7577f;
                    propertyDetails.HouseHeistExitLocation = new(-1540.2974f, -322.4765f, 46.3136f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1532.287720f, -326.305176f, 49.229465f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1534.089478f, -328.075653f, 46.221008f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 237.6246f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1532.79187f, -325.73761f, 46.91117f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1532.4303f, -325.3266f, 48.5029f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -45.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1535.1931f, -325.2051f, 46.4857f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 51.5003f;
                    propertyDetails.cctv[0].Pos = new(-1536.0469f, -328.8640f, 50.8195f);
                    propertyDetails.cctv[0].Rot = new(-41.4352f, 0.0000f, -18.8051f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1530.622925f, -341.287964f, 47.990681f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1525.618530f, -346.065918f, 43.999084f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 324.1467f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1526.11914f, -345.66339f, 44.32087f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1525.8250f, -346.0658f, 45.7772f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -135.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1532.0775f, -340.9420f, 47.9153f);
                    propertyDetails.cctv[1].Rot = new(-26.7709f, 0.8689f, -155.4644f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1533.7347f, -342.6815f, 44.6768f);
                    propertyDetails.Garage.ExitPlayerHeading = 131.1871f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1531.9689f, -344.8956f, 44.4344f);
                    propertyDetails.Garage.CarExitHeading[0] = 123.1062f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1538.7380f, -348.5782f, 44.6988f);
                    propertyDetails.Garage.CarExitHeading[1] = 119.3949f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1528.7245f, -347.6192f, 44.0972f);
                    propertyDetails.Garage.CarExitHeading[2] = 145.9691f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1533.3853f, -355.9714f, 43.7891f);
                    propertyDetails.Garage.CarExitHeading[3] = 152.8662f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1536.2656f, -352.6110f, 44.1812f);
                    propertyDetails.Garage.CarExitHeading[4] = 135.3279f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    propertyDetails.PurchaseLocation = new(-1561.3810f, -412.1974f, 41.3890f);
                    propertyDetails.BlipLocation[0] = new(-1562.9495f, -406.2817f, 41.3890f);
                    propertyDetails.BlipLocation[1] = new(-1557.4014f, -400.0025f, 40.9881f);
                    propertyDetails.CamData.Pos = new(-1549.5356f, -453.3481f, 56.7394f);
                    propertyDetails.CamData.Rot = new(-6.3982f, 0.0000f, 10.7246f);
                    propertyDetails.CamData.FOV = 34.3497f;
                    propertyDetails.HouseHeistExitLocation = new(-1556.6167f, -417.2538f, 41.1883f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1564.902954f, -406.185333f, 43.810246f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1563.756958f, -404.787872f, 41.284882f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 53.1375f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1562.45435f, -404.26755f, 41.38898f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1562.8165f, -403.8937f, 43.0028f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 50.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1560.3230f, -409.2578f, 41.3890f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 216.3644f;
                    propertyDetails.cctv[0].Pos = new(-1566.9603f, -415.1502f, 46.0548f);
                    propertyDetails.cctv[0].Rot = new(-29.7021f, -0.0000f, -70.8796f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1560.774902f, -401.227295f, 44.124756f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1556.794556f, -396.483276f, 40.579990f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 48.7978f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1556.07239f, -396.76691f, 40.98813f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1556.4463f, -396.3038f, 42.5343f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 50.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1552.6870f, -398.0967f, 44.8597f);
                    propertyDetails.cctv[1].Rot = new(-30.5051f, 2.4603f, 165.9363f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1551.2654f, -399.6432f, 40.9881f);
                    propertyDetails.Garage.ExitPlayerHeading = 221.7628f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1555.4916f, -401.5921f, 40.9881f);
                    propertyDetails.Garage.CarExitHeading[0] = 229.0269f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1550.0897f, -406.2810f, 40.9881f);
                    propertyDetails.Garage.CarExitHeading[1] = 229.0350f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1548.6974f, -401.6271f, 40.9881f);
                    propertyDetails.Garage.CarExitHeading[2] = 257.9825f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1542.3252f, -399.0072f, 40.9881f);
                    propertyDetails.Garage.CarExitHeading[3] = 292.4030f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1543.9772f, -405.3359f, 40.9890f);
                    propertyDetails.Garage.CarExitHeading[4] = 291.6289f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    propertyDetails.PurchaseLocation = new(-1608.8514f, -429.1840f, 39.4390f);
                    propertyDetails.BlipLocation[0] = new(-1606.7810f, -431.8483f, 39.4372f);
                    propertyDetails.BlipLocation[1] = new(-1606.7291f, -448.6675f, 37.1799f);
                    propertyDetails.CamData.Pos = new(-1616.9534f, -505.0326f, 53.6363f);
                    propertyDetails.CamData.Rot = new(-6.7901f, -0.0000f, -19.8142f);
                    propertyDetails.CamData.FOV = 34.4399f;
                    propertyDetails.HouseHeistExitLocation = new(-1614.8463f, -425.6327f, 39.3947f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1604.959717f, -431.834961f, 41.957710f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1606.787598f, -434.011841f, 38.442875f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 232.2676f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1607.47900f, -433.72363f, 39.43241f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1607.0397f, -434.1056f, 41.0649f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -130.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1609.2124f, -429.7664f, 39.4372f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 55.7531f;
                    propertyDetails.cctv[0].Pos = new(-1604.8062f, -429.8766f, 44.8098f);
                    propertyDetails.cctv[0].Rot = new(-48.1096f, 0.0000f, 102.1529f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1608.378540f, -446.164581f, 36.555408f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1603.769287f, -450.092438f, 40.716335f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 314.7102f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1604.14709f, -449.44098f, 37.20527f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1603.7241f, -449.8294f, 38.7276f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -130.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1603.8298f, -449.2337f, 40.2590f);
                    propertyDetails.cctv[1].Rot = new(-35.7033f, -0.9669f, 99.5657f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1607.4504f, -456.7893f, 36.8592f);
                    propertyDetails.Garage.ExitPlayerHeading = 148.0527f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1607.8218f, -450.3613f, 37.1359f);
                    propertyDetails.Garage.CarExitHeading[0] = 139.9644f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1609.7788f, -458.7872f, 36.8884f);
                    propertyDetails.Garage.CarExitHeading[1] = 168.1596f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1613.2382f, -456.8185f, 37.0621f);
                    propertyDetails.Garage.CarExitHeading[2] = 140.1804f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1617.0525f, -454.5710f, 37.3955f);
                    propertyDetails.Garage.CarExitHeading[3] = 112.6241f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1621.2996f, -453.1793f, 37.4966f);
                    propertyDetails.Garage.CarExitHeading[4] = 48.5007f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    propertyDetails.BlipLocation[0] = new(963.4199f, -1022.1301f, 39.8475f);
                    propertyDetails.CamData.Pos = new(1002.1281f, -1023.4307f, 49.5466f);
                    propertyDetails.CamData.Rot = new(-2.4589f, -0.0000f, 88.9038f);
                    propertyDetails.CamData.FOV = 36.2121f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(961.867615f, -1022.555054f, 39.347485f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(965.055725f, -1022.581604f, 44.097485f);
                    propertyDetails.Entrance[0].locateDetails.Width = 22.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 80.8479f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(964.24481f, -1022.68311f, 39.84748f);
                    propertyDetails.Entrance[0].BuzzerProp = new(963.2421f, -1022.5897f, 41.5091f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.PurchaseLocation = new(965.1798f, -1031.3204f, 39.8384f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(966.2585f, -1010.0174f, 40.0476f);
                    propertyDetails.Garage.ExitPlayerHeading = 263.2577f;
                    propertyDetails.Garage.CarExitLoc[0] = new(966.3380f, -1031.1354f, 39.8390f);
                    propertyDetails.Garage.CarExitHeading[0] = 266.5586f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(967.1743f, -1025.6099f, 39.8475f);
                    propertyDetails.Garage.CarExitHeading[1] = 270.8348f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(967.6329f, -1020.0041f, 39.8475f);
                    propertyDetails.Garage.CarExitHeading[2] = 270.4741f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(966.9617f, -1013.7098f, 39.8475f);
                    propertyDetails.Garage.CarExitHeading[3] = 271.1738f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(965.6980f, -1037.5924f, 39.8303f);
                    propertyDetails.Garage.CarExitHeading[4] = 263.0311f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(896.339478f, -889.294006f, 26.003153f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(894.240417f, -889.275940f, 30.367142f);
                    propertyDetails.Entrance[0].locateDetails.Width = 9.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 268.5209f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(895.20142f, -889.31818f, 26.19163f);
                    propertyDetails.Entrance[0].BuzzerProp = new(895.5656f, -889.3296f, 27.6491f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(895.9359f, -888.7846f, 26.2485f);
                    propertyDetails.CamData.Pos = new(840.2737f, -935.0451f, 42.8762f);
                    propertyDetails.CamData.Rot = new(-2.9799f, -0.0000f, -53.3725f);
                    propertyDetails.CamData.FOV = 32.5988f;
                    propertyDetails.PurchaseLocation = new(893.8858f, -887.0587f, 26.0899f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(894.3965f, -892.7888f, 26.1293f);
                    propertyDetails.Garage.ExitPlayerHeading = 84.3930f;
                    propertyDetails.Garage.CarExitLoc[0] = new(892.3411f, -886.9641f, 25.9702f);
                    propertyDetails.Garage.CarExitHeading[0] = 87.7599f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(892.4629f, -891.6348f, 25.9794f);
                    propertyDetails.Garage.CarExitHeading[1] = 91.7013f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(883.6350f, -891.8969f, 25.2952f);
                    propertyDetails.Garage.CarExitHeading[2] = 91.7290f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(882.4849f, -886.9933f, 25.2061f);
                    propertyDetails.Garage.CarExitHeading[3] = 91.5397f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(872.6458f, -887.7606f, 24.9248f);
                    propertyDetails.Garage.CarExitHeading[4] = 177.6021f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(817.637024f, -926.171143f, 25.397013f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(817.672241f, -923.801208f, 29.427319f);
                    propertyDetails.Entrance[0].locateDetails.Width = 9.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 186.4707f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(812.29810f, -924.25171f, 25.20545f);
                    propertyDetails.Entrance[0].BuzzerProp = new(812.2344f, -924.6008f, 26.7609f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -180.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(817.4532f, -924.8551f, 25.2430f);
                    propertyDetails.CamData.Pos = new(846.5938f, -912.0248f, 29.8333f);
                    propertyDetails.CamData.Rot = new(1.8843f, -0.0000f, 116.7035f);
                    propertyDetails.CamData.FOV = 32.0039f;
                    propertyDetails.PurchaseLocation = new(817.4396f, -923.2914f, 25.1455f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(811.3528f, -922.7236f, 25.1103f);
                    propertyDetails.Garage.ExitPlayerHeading = 25.2843f;
                    propertyDetails.Garage.CarExitLoc[0] = new(818.6449f, -922.2507f, 25.0809f);
                    propertyDetails.Garage.CarExitHeading[0] = 28.7207f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(813.7722f, -922.1363f, 25.0738f);
                    propertyDetails.Garage.CarExitHeading[1] = 33.4430f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(830.8185f, -913.9405f, 24.6657f);
                    propertyDetails.Garage.CarExitHeading[2] = 91.3280f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(820.7473f, -913.1084f, 24.5875f);
                    propertyDetails.Garage.CarExitHeading[3] = 92.9782f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(810.5826f, -913.3151f, 24.6075f);
                    propertyDetails.Garage.CarExitHeading[4] = 93.4120f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(758.157104f, -755.466736f, 25.430733f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(759.623901f, -755.476379f, 30.154293f);
                    propertyDetails.Entrance[0].locateDetails.Width = 10.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 86.9705f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(759.48035f, -749.99609f, 26.13875f);
                    propertyDetails.Entrance[0].BuzzerProp = new(759.0246f, -749.9797f, 27.6906f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(759.2387f, -755.3151f, 25.9151f);
                    propertyDetails.CamData.Pos = new(792.6638f, -754.6710f, 34.6688f);
                    propertyDetails.CamData.Rot = new(0.7646f, -0.0000f, 90.0749f);
                    propertyDetails.CamData.FOV = 42.4321f;
                    propertyDetails.PurchaseLocation = new(760.4014f, -758.0060f, 25.8063f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(759.4371f, -760.0032f, 25.7598f);
                    propertyDetails.Garage.ExitPlayerHeading = 277.8507f;
                    propertyDetails.Garage.CarExitLoc[0] = new(761.8399f, -750.8654f, 25.9419f);
                    propertyDetails.Garage.CarExitHeading[0] = 306.6377f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(761.6503f, -756.5213f, 25.7067f);
                    propertyDetails.Garage.CarExitHeading[1] = 294.2219f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(762.6526f, -746.4432f, 26.1404f);
                    propertyDetails.Garage.CarExitHeading[2] = 358.0908f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(762.9658f, -738.5776f, 26.5185f);
                    propertyDetails.Garage.CarExitHeading[3] = 358.3590f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(763.2261f, -769.1245f, 25.3579f);
                    propertyDetails.Garage.CarExitHeading[4] = 180.7413f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(842.029968f, -1167.653809f, 23.768063f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(841.885071f, -1163.101563f, 28.518063f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 187.1127f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(844.56061f, -1164.14612f, 24.26806f);
                    propertyDetails.Entrance[0].BuzzerProp = new(844.5184f, -1164.6573f, 25.9390f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -176.5f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(842.1298f, -1165.0754f, 24.3046f);
                    propertyDetails.CamData.Pos = new(873.2134f, -1114.6626f, 48.9161f);
                    propertyDetails.CamData.Rot = new(-13.8258f, -0.0000f, 144.1864f);
                    propertyDetails.CamData.FOV = 37.2109f;
                    propertyDetails.PurchaseLocation = new(842.0649f, -1162.5195f, 24.2681f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(841.5887f, -1163.3604f, 24.2681f);
                    propertyDetails.Garage.ExitPlayerHeading = 7.7576f;
                    propertyDetails.Garage.CarExitLoc[0] = new(841.6375f, -1160.7850f, 24.2678f);
                    propertyDetails.Garage.CarExitHeading[0] = 2.6753f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(834.4910f, -1153.0087f, 24.2281f);
                    propertyDetails.Garage.CarExitHeading[1] = 272.6176f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(835.1475f, -1156.9692f, 24.2681f);
                    propertyDetails.Garage.CarExitHeading[2] = 273.0558f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(844.0175f, -1156.4968f, 24.2681f);
                    propertyDetails.Garage.CarExitHeading[3] = 273.0678f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(846.6666f, -1151.5957f, 24.1599f);
                    propertyDetails.Garage.CarExitHeading[4] = 269.9492f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(529.376038f, -1604.027222f, 27.831518f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(527.910461f, -1602.797485f, 32.474586f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 216.8423f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(526.62036f, -1604.66467f, 28.27846f);
                    propertyDetails.Entrance[0].BuzzerProp = new(527.0496f, -1605.2067f, 29.8629f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -130.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(528.8805f, -1603.0293f, 28.3225f);
                    propertyDetails.CamData.Pos = new(511.6405f, -1541.9185f, 41.1761f);
                    propertyDetails.CamData.Rot = new(-4.7034f, -0.0000f, -169.1090f);
                    propertyDetails.CamData.FOV = 20.2458f;
                    propertyDetails.PurchaseLocation = new(527.3356f, -1602.1427f, 28.1478f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(525.8525f, -1604.5986f, 28.2550f);
                    propertyDetails.Garage.ExitPlayerHeading = 45.4901f;
                    propertyDetails.Garage.CarExitLoc[0] = new(525.7641f, -1601.4014f, 28.1769f);
                    propertyDetails.Garage.CarExitHeading[0] = 50.8529f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(517.8649f, -1601.5873f, 28.2864f);
                    propertyDetails.Garage.CarExitHeading[1] = 73.5817f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(515.6566f, -1605.2291f, 28.3055f);
                    propertyDetails.Garage.CarExitHeading[2] = 78.3556f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(526.7875f, -1592.3201f, 28.2797f);
                    propertyDetails.Garage.CarExitHeading[3] = 8.7291f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(512.2185f, -1609.1097f, 28.3116f);
                    propertyDetails.Garage.CarExitHeading[4] = 80.5639f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(569.652466f, -1570.558838f, 27.327698f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(570.508911f, -1569.585205f, 31.840675f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 135.5236f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(568.28577f, -1568.31775f, 27.70387f);
                    propertyDetails.Entrance[0].BuzzerProp = new(567.9484f, -1568.6820f, 29.2407f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 140.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(569.9441f, -1570.2930f, 27.5777f);
                    propertyDetails.CamData.Pos = new(595.9171f, -1540.1836f, 32.4308f);
                    propertyDetails.CamData.Rot = new(0.5723f, -0.0000f, 138.7878f);
                    propertyDetails.CamData.FOV = 24.2761f;
                    propertyDetails.PurchaseLocation = new(571.3317f, -1569.2113f, 27.5769f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(571.9505f, -1570.7150f, 27.4944f);
                    propertyDetails.Garage.ExitPlayerHeading = 316.8053f;
                    propertyDetails.Garage.CarExitLoc[0] = new(572.6698f, -1566.7014f, 27.6227f);
                    propertyDetails.Garage.CarExitHeading[0] = 318.9168f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(567.3885f, -1564.2723f, 27.8734f);
                    propertyDetails.Garage.CarExitHeading[1] = 11.3999f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(576.4351f, -1571.6967f, 27.3460f);
                    propertyDetails.Garage.CarExitHeading[2] = 284.5693f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(579.3066f, -1574.5211f, 27.1020f);
                    propertyDetails.Garage.CarExitHeading[3] = 316.8582f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(563.3011f, -1560.7766f, 28.0953f);
                    propertyDetails.Garage.CarExitHeading[4] = 319.6255f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(724.897583f, -1188.176636f, 23.181055f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(724.775879f, -1191.175781f, 27.529465f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.50000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 8.0958f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(726.76019f, -1189.99512f, 23.27746f);
                    propertyDetails.Entrance[0].BuzzerProp = new(726.7885f, -1189.5450f, 24.7175f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 0.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(727.7570f, -1189.8367f, 23.2765f);
                    propertyDetails.CamData.Pos = new(751.2015f, -1201.4775f, 25.9253f);
                    propertyDetails.CamData.Rot = new(0.2972f, -0.0000f, 68.1021f);
                    propertyDetails.CamData.FOV = 28.0400f;
                    propertyDetails.PurchaseLocation = new(724.9683f, -1191.5889f, 23.2793f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(722.4882f, -1190.6957f, 23.2818f);
                    propertyDetails.Garage.ExitPlayerHeading = 226.8115f;
                    propertyDetails.Garage.CarExitLoc[0] = new(727.2533f, -1192.6544f, 23.2769f);
                    propertyDetails.Garage.CarExitHeading[0] = 225.7019f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(734.2759f, -1194.8922f, 23.2741f);
                    propertyDetails.Garage.CarExitHeading[1] = 270.6564f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(742.4778f, -1194.8030f, 23.2677f);
                    propertyDetails.Garage.CarExitHeading[2] = 270.6550f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(743.9144f, -1198.5862f, 23.2600f);
                    propertyDetails.Garage.CarExitHeading[3] = 268.5719f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(721.1934f, -1193.5802f, 23.2832f);
                    propertyDetails.Garage.CarExitHeading[4] = 223.0747f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(504.441528f, -1492.073486f, 27.901068f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(504.435089f, -1493.984497f, 32.538689f);
                    propertyDetails.Entrance[0].locateDetails.Width = 13.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 6.0979f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(504.65533f, -1493.16235f, 28.28859f);
                    propertyDetails.Entrance[0].BuzzerProp = new(504.7454f, -1492.7229f, 29.8382f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 0.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(504.6782f, -1492.8872f, 28.2886f);
                    propertyDetails.CamData.Pos = new(489.3747f, -1518.9008f, 31.5557f);
                    propertyDetails.CamData.Rot = new(-1.8290f, -0.0000f, -32.9606f);
                    propertyDetails.CamData.FOV = 22.1333f;
                    propertyDetails.PurchaseLocation = new(501.0715f, -1494.1602f, 28.2890f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(497.3470f, -1493.9241f, 28.2893f);
                    propertyDetails.Garage.ExitPlayerHeading = 211.2587f;
                    propertyDetails.Garage.CarExitLoc[0] = new(501.0577f, -1496.1643f, 28.2891f);
                    propertyDetails.Garage.CarExitHeading[0] = 178.7652f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(501.4612f, -1502.6527f, 28.2889f);
                    propertyDetails.Garage.CarExitHeading[1] = 189.8566f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(507.9253f, -1496.2356f, 28.2885f);
                    propertyDetails.Garage.CarExitHeading[2] = 179.6585f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(507.9807f, -1502.4520f, 28.2883f);
                    propertyDetails.Garage.CarExitHeading[3] = 182.1230f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(504.4424f, -1506.7959f, 28.2716f);
                    propertyDetails.Garage.CarExitHeading[4] = 268.4133f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(474.989655f, -1547.674683f, 27.782791f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(475.860992f, -1546.609985f, 32.532791f);
                    propertyDetails.Entrance[0].locateDetails.Width = 9.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 137.9010f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(472.27435f, -1543.77087f, 28.28258f);
                    propertyDetails.Entrance[0].BuzzerProp = new(471.8385f, -1544.3411f, 29.8348f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 140.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(475.7058f, -1547.1232f, 28.2828f);
                    propertyDetails.CamData.Pos = new(474.4796f, -1526.7422f, 32.3941f);
                    propertyDetails.CamData.Rot = new(-1.0343f, -0.0000f, -175.9226f);
                    propertyDetails.CamData.FOV = 31.8160f;
                    propertyDetails.PurchaseLocation = new(478.0967f, -1547.7393f, 28.2826f);
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(481.4461f, -1551.5210f, 28.2828f);
                    propertyDetails.Garage.ExitPlayerHeading = 319.4575f;
                    propertyDetails.Garage.CarExitLoc[0] = new(476.7013f, -1543.2727f, 28.2688f);
                    propertyDetails.Garage.CarExitHeading[0] = 317.4218f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(478.8961f, -1546.5181f, 28.2828f);
                    propertyDetails.Garage.CarExitHeading[1] = 321.1352f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(487.6636f, -1543.0957f, 28.2618f);
                    propertyDetails.Garage.CarExitHeading[2] = 230.0298f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(481.2663f, -1537.8181f, 28.2474f);
                    propertyDetails.Garage.CarExitHeading[3] = 230.3941f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(471.9972f, -1530.9518f, 28.2219f);
                    propertyDetails.Garage.CarExitHeading[4] = 232.9607f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    GetBuildingExteriorDetailsFullPart2(ref propertyDetails, iBuilding);
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    GetBuildingExteriorDetailsFullPart3(ref propertyDetails, iBuilding);
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    GetClubhouseBuildingExteriorDetailsFull(ref propertyDetails, iBuilding);
                    break;
            }
            propertyDetails.BuildingID = iBuilding;
            GetBuildingProperties(ref propertyDetails.Building, propertyDetails.BuildingID);
        }
        internal static void GetBuzzerPlayerOffset(Vector3 vCurrentLoc, Vector3 vCurrentRot, ref Position offset, int buzzerType)
        {
            Position BaseLoc = new();
            Position BaseOffset = new();
            Position NewLoc = new();
            offset = new Position(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
            switch ((BuzzerType)buzzerType)
            {
                case BuzzerType.BUZZER_TYPE_KEYPAD_01:
                    BaseLoc = new Position(285.8317f, -162.2050f, 65.1628f, 0.0f, 0.0f, -110.0f);
                    BaseOffset = new Position(285.138f, -162.024f, 63.614f, 0.0f, 0.0f, 160.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_KEYPAD_01_FLIPPED:
                    BaseLoc = new Position(-968.2812f, -1432.9247f, 8.1858f, 0.0f, 0.0f, 70.0f);
                    BaseOffset = new Position(-968.944f, -1433.234f, 6.673f, 0.0f, 0.0f, -160.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_KEYPAD_01B:
                    BaseLoc = new Position(-778.8333f, 313.5024f, 86.1362f, 0.0f, 0.0f, 0.0f);
                    BaseOffset = new Position(-778.727f, 312.728f, 84.693f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_GATECOM_01:
                    BaseLoc = new Position(-980.7506f, -1447.0208f, 4.5223f, 0.0f, 0.0f, -70.0f);
                    BaseOffset = new Position(-980.290f, -1447.934f, 3.723f, 0.0f, 0.0f, -70.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_GATECOM_02:
                    BaseLoc = new Position(895.5656f, -889.3296f, 27.6491f, 0.0f, 0.0f, -90.0f);
                    BaseOffset = new Position(894.954f, -889.428f, 26.158f, 0.0f, 0.0f, 180.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED:
                    BaseLoc = new Position(726.7885f, -1189.5450f, 24.7175f, 0.0f, 0.0f, 0.0f);
                    BaseOffset = new Position(726.857f, -1190.163f, 23.270f, 0.0f, 0.0f, -90.0f);
                    break;
                case BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE:
                    BaseLoc = new Position(-833.9494f, -862.6305f, 21.2407f, 0.0f, 0.0f, 90.0f);
                    BaseOffset = new Position(-833.335f, -862.650f, 19.682f, 0.0f, 0.0f, 0.0f);
                    break;
            }
            NewLoc = new Position(vCurrentLoc, vCurrentRot);
            GetOffsetForPositionFromBaseOffset(BaseLoc, BaseOffset, NewLoc, ref offset);
        }
        internal static void GetClubhouseBuildingExteriorDetailsFull(ref PropertyData propertyDetails, BuildingsEnum iBuilding)
        {
            Position buzzerOffset = new();
            propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    propertyDetails.PurchaseLocation = new(252.3021f, -1813.1484f, 26.1691f);
                    propertyDetails.BlipLocation[0] = new(254.0506f, -1809.1121f, 26.2643f);
                    propertyDetails.BlipLocation[1] = new(259.5366f, -1802.3033f, 26.2152f);
                    propertyDetails.CamData.Pos = new(239.7418f, -1811.5352f, 32.0606f);
                    propertyDetails.CamData.Rot = new(-11.7578f, -0.0000f, -67.7135f);
                    propertyDetails.CamData.FOV = 44.6712f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(253.311478f, -1808.407715f, 25.863140f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(254.294601f, -1809.260010f, 28.863140f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 219.9318f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(254.0506f, -1809.1121f, 26.2643f);
                    propertyDetails.Entrance[0].BuzzerProp = new(253.254f, -1809.654f, 27.417f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 230.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(253.3365f, -1799.6703f, 26.1131f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 57.3276f;
                    propertyDetails.cctv[0].Pos = new(252.8545f, -1809.9440f, 29.2059f);
                    propertyDetails.cctv[0].Rot = new(-48.2796f, -0.0000f, -25.9045f);
                    propertyDetails.cctv[0].FOV = 69.8427f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(259.520630f, -1802.301392f, 26.071270f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(258.070801f, -1801.065796f, 29.363140f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 232.4453f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(259.5366f, -1802.3033f, 26.2152f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(257.5821f, -1800.8406f, 26.1131f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 56.3008f;
                    propertyDetails.cctv[1].Pos = new(257.8029f, -1803.0870f, 28.5437f);
                    propertyDetails.cctv[1].Rot = new(-37.1543f, -0.0000f, -31.4609f);
                    propertyDetails.cctv[1].FOV = 83.2505f;
                    propertyDetails.Garage.ExitPlayerPos = new(257.5821f, -1800.8406f, 26.1131f);
                    propertyDetails.Garage.ExitPlayerHeading = 56.3008f;
                    propertyDetails.Garage.CarExitLoc[0] = new(256.5020f, -1801.2483f, 26.1131f);
                    propertyDetails.Garage.CarExitHeading[0] = 90.9405f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(254.0294f, -1803.6024f, 26.1131f);
                    propertyDetails.Garage.CarExitHeading[1] = 116.4148f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(251.8847f, -1800.8208f, 26.1131f);
                    propertyDetails.Garage.CarExitHeading[2] = 141.4167f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(255.4657f, -1796.4010f, 26.1131f);
                    propertyDetails.Garage.CarExitHeading[3] = 140.9190f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(248.3528f, -1806.4415f, 26.1131f);
                    propertyDetails.Garage.CarExitHeading[4] = 124.5272f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    propertyDetails.PurchaseLocation = new(-1485.756836f, -923.317566f, 19.595057f);
                    propertyDetails.BlipLocation[0] = new(-1471.8319f, -920.1343f, 9.0249f);
                    propertyDetails.BlipLocation[1] = new(-1469.6271f, -929.1902f, 9.1865f);
                    propertyDetails.CamData.Pos = new(-1455.513062f, -921.607178f, 16.841164f);
                    propertyDetails.CamData.Rot = new(-20.002123f, 0.0f, 100.733139f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1471.1069f, -919.8443f, 9.0237f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1472.0938f, -920.9706f, 12.0346f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.5f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 50.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1471.8319f, -920.1343f, 9.0249f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1472.809f, -920.902f, 10.376f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 50.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1469.0375f, -922.3520f, 9.0291f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 230.0f;
                    propertyDetails.cctv[0].Pos = new(-1469.620728f, -917.429199f, 12.425049f);
                    propertyDetails.cctv[0].Rot = new(-33.262169f, 0.0f, 156.687332f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1473.4039f, -926.0901f, 9.1849f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1466.2554f, -932.0925f, 13.1885f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 140.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1469.6271f, -929.1902f, 9.1865f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-1466.5770f, -925.1134f, 9.0269f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 320.0f;
                    propertyDetails.cctv[1].Pos = new(-1465.914063f, -932.212158f, 12.603905f);
                    propertyDetails.cctv[1].Rot = new(-23.171425f, 0.0f, 42.555431f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1465.4921f, -923.8866f, 9.0338f);
                    propertyDetails.Garage.ExitPlayerHeading = 320.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1465.4921f, -923.8866f, 9.0338f);
                    propertyDetails.Garage.CarExitHeading[0] = 320.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1458.8389f, -922.0121f, 9.0580f);
                    propertyDetails.Garage.CarExitHeading[1] = 230.6614f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1449.9634f, -930.0195f, 8.8814f);
                    propertyDetails.Garage.CarExitHeading[2] = 227.8659f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1444.9832f, -936.6174f, 7.8077f);
                    propertyDetails.Garage.CarExitHeading[3] = 227.1320f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1464.8540f, -918.0606f, 9.0349f);
                    propertyDetails.Garage.CarExitHeading[4] = 231.8444f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    propertyDetails.PurchaseLocation = new(48.134914f, -1031.286621f, 35.662636f);
                    propertyDetails.BlipLocation[0] = new(37.2720f, -1029.3018f, 28.5669f);
                    propertyDetails.BlipLocation[1] = new(40.1411f, -1022.5889f, 28.5317f);
                    propertyDetails.CamData.Pos = new(22.920012f, -1039.357788f, 37.236332f);
                    propertyDetails.CamData.Rot = new(-18.077564f, 0.0f, -71.813332f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(37.4920f, -1028.7545f, 28.5675f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(37.1163f, -1029.8750f, 31.5689f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.5f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 247.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(37.3588f, -1029.3250f, 28.5711f);
                    propertyDetails.Entrance[0].BuzzerProp = new(37.272518f, -1030.289f, 29.8f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 247.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(34.6624f, -1028.1530f, 28.52f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 67.0f;
                    propertyDetails.cctv[0].Pos = new(34.735939f, -1034.842773f, 32.468525f);
                    propertyDetails.cctv[0].Rot = new(-32.013218f, 0.0f, -11.85664f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(40.9591f, -1020.4954f, 28.5168f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(39.2666f, -1024.6724f, 32.5593f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 247.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(40.0932f, -1022.6314f, 28.5310f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(37.0577f, -1021.2496f, 28.4798f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 67.0f;
                    propertyDetails.cctv[1].Pos = new(41.921799f, -1018.611694f, 33.166576f);
                    propertyDetails.cctv[1].Rot = new(-43.817642f, 0.0f, 135.396042f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(33.2270f, -1016.9539f, 28.4567f);
                    propertyDetails.Garage.ExitPlayerHeading = 340.9914f;
                    propertyDetails.Garage.CarExitLoc[0] = new(33.2270f, -1016.9539f, 28.4567f);
                    propertyDetails.Garage.CarExitHeading[0] = 340.9914f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(36.3108f, -1007.7845f, 28.4626f);
                    propertyDetails.Garage.CarExitHeading[1] = 340.1653f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(39.3771f, -999.3572f, 28.4154f);
                    propertyDetails.Garage.CarExitHeading[2] = 339.8190f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(29.4222f, -1029.5435f, 28.4506f);
                    propertyDetails.Garage.CarExitHeading[3] = 157.1595f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(31.7689f, -1033.4246f, 28.4128f);
                    propertyDetails.Garage.CarExitHeading[4] = 158.5681f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    propertyDetails.PurchaseLocation = new(53.039482f, 2791.662354f, 65.012314f);
                    propertyDetails.BlipLocation[0] = new(46.7547f, 2789.6455f, 57.1054f);
                    propertyDetails.BlipLocation[1] = new(56.1234f, 2785.7100f, 56.8783f);
                    propertyDetails.CamData.Pos = new(32.843651f, 2787.492920f, 64.489822f);
                    propertyDetails.CamData.Rot = new(-19.861828f, -0.000000f, -72.681763f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(45.7077f, 2789.3469f, 56.8783f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(46.9525f, 2788.6184f, 59.8783f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.5f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 322.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(46.8107f, 2789.6008f, 57.1054f);
                    propertyDetails.Entrance[0].BuzzerProp = new(45.861257f, 2789.767266f, 58.2f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 322.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(44.7758f, 2786.8245f, 56.8781f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 142.0f;
                    propertyDetails.cctv[0].Pos = new(42.798809f, 2791.530762f, 61.485840f);
                    propertyDetails.cctv[0].Rot = new(-39.604027f, 0.000001f, -137.500702f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(52.0210f, 2788.5676f, 56.8783f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(57.2193f, 2784.6777f, 60.8783f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 322.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(56.2014f, 2785.7693f, 56.8783f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(53.9654f, 2782.9033f, 56.8783f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 142.0f;
                    propertyDetails.cctv[1].Pos = new(50.610519f, 2788.690918f, 60.975185f);
                    propertyDetails.cctv[1].Rot = new(-21.141226f, -0.000001f, -131.595856f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(49.9789f, 2783.6082f, 56.8840f);
                    propertyDetails.Garage.ExitPlayerHeading = 79.0340f;
                    propertyDetails.Garage.CarExitLoc[0] = new(49.9789f, 2783.6082f, 56.8840f);
                    propertyDetails.Garage.CarExitHeading[0] = 79.0340f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(57.3569f, 2777.6204f, 56.8783f);
                    propertyDetails.Garage.CarExitHeading[1] = 189.5871f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(47.4214f, 2776.2715f, 56.8840f);
                    propertyDetails.Garage.CarExitHeading[2] = 58.7704f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(35.2752f, 2782.3770f, 56.8781f);
                    propertyDetails.Garage.CarExitHeading[3] = 132.5531f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(59.3515f, 2768.5923f, 56.8783f);
                    propertyDetails.Garage.CarExitHeading[4] = 185.7522f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    propertyDetails.PurchaseLocation = new(-349.025177f, 6061.300781f, 46.643566f);
                    propertyDetails.BlipLocation[0] = new(-342.0963f, 6065.6294f, 30.5093f);
                    propertyDetails.BlipLocation[1] = new(-353.9768f, 6066.2563f, 30.4985f);
                    propertyDetails.CamData.Pos = new(-345.506134f, 6083.811035f, 39.056438f);
                    propertyDetails.CamData.Rot = new(-21.427885f, -0.000000f, 171.869644f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-341.6371f, 6065.1592f, 30.5111f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-342.6248f, 6066.1318f, 33.5077f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.5f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 135.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-342.0963f, 6065.6294f, 30.5093f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-343.174f, 6066.212f, 31.82f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 135.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-339.2251f, 6068.4688f, 30.3603f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 315.0f;
                    propertyDetails.cctv[0].Pos = new(-339.342041f, 6063.224609f, 34.012508f);
                    propertyDetails.cctv[0].Rot = new(-32.057144f, -0.000000f, 43.118244f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-352.3805f, 6067.9160f, 30.4979f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-355.7214f, 6064.5557f, 34.4992f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 225.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-353.9768f, 6066.2563f, 30.4985f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-357.9002f, 6069.9585f, 30.4985f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 45.0f;
                    propertyDetails.cctv[1].Pos = new(-349.034332f, 6071.203125f, 35.386097f);
                    propertyDetails.cctv[1].Rot = new(-32.464748f, -0.000001f, 121.312172f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-359.7650f, 6071.8052f, 30.4983f);
                    propertyDetails.Garage.ExitPlayerHeading = 45.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-359.7650f, 6071.8052f, 30.4983f);
                    propertyDetails.Garage.CarExitHeading[0] = 45.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-355.8349f, 6076.7598f, 30.5016f);
                    propertyDetails.Garage.CarExitHeading[1] = 314.8498f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-359.3047f, 6079.3672f, 30.4973f);
                    propertyDetails.Garage.CarExitHeading[2] = 316.1204f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-344.8482f, 6075.5439f, 30.4072f);
                    propertyDetails.Garage.CarExitHeading[3] = 225.4279f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-366.4851f, 6069.5430f, 30.5001f);
                    propertyDetails.Garage.CarExitHeading[4] = 88.9391f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    propertyDetails.PurchaseLocation = new(1733.579834f, 3702.428955f, 42.480869f);
                    propertyDetails.BlipLocation[0] = new(1737.9225f, 3709.1099f, 33.1355f);
                    propertyDetails.BlipLocation[1] = new(1729.3052f, 3706.8066f, 33.1207f);
                    propertyDetails.CamData.Pos = new(1745.778809f, 3725.659180f, 39.644505f);
                    propertyDetails.CamData.Rot = new(-17.609089f, -0.000000f, 158.541458f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(1738.5031f, 3709.2212f, 33.1450f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(1737.3252f, 3708.8433f, 36.1273f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.5f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 201.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(1737.9225f, 3709.1099f, 33.1355f);
                    propertyDetails.Entrance[0].BuzzerProp = new(1737.132f, 3708.370f, 34.44f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 201.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(1736.7023f, 3712.4556f, 33.1196f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 21.0f;
                    propertyDetails.cctv[0].Pos = new(1741.285767f, 3711.000000f, 36.026985f);
                    propertyDetails.cctv[0].Rot = new(-20.295559f, 0.000001f, 115.602615f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(1733.8457f, 3708.5010f, 33.1237f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(1724.7946f, 3705.2273f, 37.1555f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 201.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(1729.3052f, 3706.8066f, 33.1207f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(1726.3298f, 3714.0073f, 33.1908f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 21.0f;
                    propertyDetails.cctv[1].Pos = new(1735.764648f, 3710.416992f, 37.936584f);
                    propertyDetails.cctv[1].Rot = new(-28.018818f, -0.000000f, 110.972122f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(1724.0144f, 3712.9819f, 33.2183f);
                    propertyDetails.Garage.ExitPlayerHeading = 21.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(1724.0144f, 3712.9819f, 33.2183f);
                    propertyDetails.Garage.CarExitHeading[0] = 21.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(1729.0753f, 3714.9749f, 33.1545f);
                    propertyDetails.Garage.CarExitHeading[1] = 21.0f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(1728.6119f, 3721.6101f, 33.0577f);
                    propertyDetails.Garage.CarExitHeading[2] = 355.1809f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(1723.2264f, 3721.5029f, 33.0942f);
                    propertyDetails.Garage.CarExitHeading[3] = 3.5273f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(1733.5560f, 3723.3313f, 33.0045f);
                    propertyDetails.Garage.CarExitHeading[4] = 357.9914f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    propertyDetails.PurchaseLocation = new(948.707336f, -1462.662354f, 42.384762f);
                    propertyDetails.BlipLocation[0] = new(939.6351f, -1458.9806f, 30.47f);
                    propertyDetails.BlipLocation[1] = new(943.48f, -1458.6298f, 30.4708f);
                    propertyDetails.CamData.Pos = new(928.795959f, -1445.592407f, 37.127846f);
                    propertyDetails.CamData.Rot = new(-16.382874f, 0.0f, -147.701706f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(940.2686f, -1458.9457f, 32.73f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(939.0130f, -1458.9457f, 30.0f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 180.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(939.6578f, -1458.9774f, 30.4699f);
                    propertyDetails.Entrance[0].BuzzerProp = new(938.6f, -1458.778f, 31.68f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 180.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(939.6075f, -1456.7239f, 30.3631f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 0.0f;
                    propertyDetails.cctv[0].Pos = new(935.281372f, -1458.617554f, 34.208694f);
                    propertyDetails.cctv[0].Rot = new(-33.669399f, 0.0f, -80.533501f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(941.4440f, -1458.3840f, 30.0f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(945.3676f, -1458.3840f, 34.0f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 180.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(943.4398f, -1458.7019f, 30.474f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(943.4383f, -1453.2849f, 30.14f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 0.0f;
                    propertyDetails.cctv[1].Pos = new(974.553589f, -1476.000244f, 46.417789f);
                    propertyDetails.cctv[1].Rot = new(-23.050289f, 0.0f, 88.102196f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(943.4383f, -1453.2849f, 30.14f);
                    propertyDetails.Garage.ExitPlayerHeading = 0.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(943.4010f, -1454.0593f, 30.6370f);
                    propertyDetails.Garage.CarExitHeading[0] = -5.77f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(947.8489f, -1454.6787f, 30.6761f);
                    propertyDetails.Garage.CarExitHeading[1] = -17.76f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(932.9202f, -1454.8738f, 30.2099f);
                    propertyDetails.Garage.CarExitHeading[2] = 319.7290f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(935.9636f, -1455.2886f, 30.2326f);
                    propertyDetails.Garage.CarExitHeading[3] = -16.32f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(950.9557f, -1454.9889f, 30.2025f);
                    propertyDetails.Garage.CarExitHeading[4] = 337.6744f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    propertyDetails.PurchaseLocation = new(177.884232f, 318.728546f, 122.267441f);
                    propertyDetails.BlipLocation[0] = new(189.8949f, 309.2079f, 104.3896f);
                    propertyDetails.BlipLocation[1] = new(177.9027f, 308.8062f, 104.3697f);
                    propertyDetails.CamData.Pos = new(196.295349f, 298.588287f, 113.404694f);
                    propertyDetails.CamData.Rot = new(-20.067480f, -0.000000f, 38.442162f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(189.1762f, 309.1273f, 104.3897f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(190.5779f, 309.2284f, 107.3897f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 5.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(189.8949f, 309.2079f, 104.3896f);
                    propertyDetails.Entrance[0].BuzzerProp = new(188.480f, 309.460f, 105.716f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 5.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(190.0721f, 305.5183f, 104.3977f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 185.0f;
                    propertyDetails.cctv[0].Pos = new(185.694229f, 308.831482f, 107.888496f);
                    propertyDetails.cctv[0].Rot = new(-28.510675f, -0.000000f, -98.607025f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(176.0313f, 308.3507f, 104.3710f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(180.1147f, 308.6703f, 108.3695f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 5.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(177.9027f, 308.8062f, 104.3697f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(178.2772f, 305.5948f, 104.3732f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 185.0f;
                    propertyDetails.cctv[1].Pos = new(183.740616f, 308.499939f, 108.037811f);
                    propertyDetails.cctv[1].Rot = new(-25.271816f, -0.000000f, 99.132088f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(177.1230f, 300.9604f, 104.3748f);
                    propertyDetails.Garage.ExitPlayerHeading = 91.7932f;
                    propertyDetails.Garage.CarExitLoc[0] = new(177.1230f, 300.9604f, 104.3748f);
                    propertyDetails.Garage.CarExitHeading[0] = 91.7932f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(167.2899f, 300.1632f, 105.6391f);
                    propertyDetails.Garage.CarExitHeading[1] = 93.2529f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(185.7480f, 298.2313f, 104.4235f);
                    propertyDetails.Garage.CarExitHeading[2] = 251.0825f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(186.2933f, 303.3362f, 104.4264f);
                    propertyDetails.Garage.CarExitHeading[3] = 236.4414f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(197.8231f, 293.2612f, 104.6384f);
                    propertyDetails.Garage.CarExitHeading[4] = 248.9478f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    propertyDetails.PurchaseLocation = new(-19.170744f, -185.037933f, 68.971001f);
                    propertyDetails.BlipLocation[0] = new(-22.0633f, -192.0560f, 51.3638f);
                    propertyDetails.BlipLocation[1] = new(-16.539602f, -191.605515f, 53.949978f);
                    propertyDetails.CamData.Pos = new(-40.058464f, -199.465637f, 60.365749f);
                    propertyDetails.CamData.Rot = new(-14.128690f, 0.000001f, -55.927200f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-22.8026f, -191.6848f, 51.3627f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-21.3126f, -192.2275f, 54.3646f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 340.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-22.0633f, -192.0560f, 51.3638f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-23.336f, -191.170f, 52.654f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 340.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-23.1747f, -195.7159f, 51.3659f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 160.0f;
                    propertyDetails.cctv[0].Pos = new(-25.039228f, -190.771530f, 54.128937f);
                    propertyDetails.cctv[0].Rot = new(-26.308592f, -0.000001f, -125.974228f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-19.0774f, -193.0987f, 51.3675f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-15.1719f, -194.4668f, 56.3675f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 340.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-16.539602f, -191.605515f, 53.949978f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-27.2982f, -193.4763f, 51.3583f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 160.0f;
                    propertyDetails.cctv[1].Pos = new(-30.745188f, -189.147202f, 56.232029f);
                    propertyDetails.cctv[1].Rot = new(-31.822266f, -0.000001f, -116.968323f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-28.1203f, -196.1983f, 51.3639f);
                    propertyDetails.Garage.ExitPlayerHeading = 160.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-28.1203f, -196.1983f, 51.3639f);
                    propertyDetails.Garage.CarExitHeading[0] = 160.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-35.4665f, -197.4720f, 51.3557f);
                    propertyDetails.Garage.CarExitHeading[1] = 71.8790f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-34.7617f, -193.9737f, 51.3590f);
                    propertyDetails.Garage.CarExitHeading[2] = 72.8786f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-21.2296f, -202.8143f, 51.3551f);
                    propertyDetails.Garage.CarExitHeading[3] = 251.3569f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-12.0377f, -206.4577f, 51.5363f);
                    propertyDetails.Garage.CarExitHeading[4] = 249.2681f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    propertyDetails.PurchaseLocation = new(2473.098633f, 4096.519043f, 52.162071f);
                    propertyDetails.BlipLocation[0] = new(2471.9436f, 4110.6621f, 37.0647f);
                    propertyDetails.BlipLocation[1] = new(2467.9373f, 4100.7451f, 37.0647f);
                    propertyDetails.CamData.Pos = new(2462.311279f, 4123.168945f, 47.586555f);
                    propertyDetails.CamData.Rot = new(-17.713013f, -0.000000f, -152.809662f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(2472.1135f, 4111.4971f, 37.0647f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(2471.5339f, 4109.9839f, 40.0647f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 248.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(2471.9436f, 4110.6621f, 37.0647f);
                    propertyDetails.Entrance[0].BuzzerProp = new(2471.648f, 4109.449f, 38.409f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 248.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(2469.9907f, 4111.6045f, 37.0647f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 68.0f;
                    propertyDetails.cctv[0].Pos = new(2470.287354f, 4107.251953f, 40.907482f);
                    propertyDetails.cctv[0].Rot = new(-35.728081f, -0.000001f, -15.280706f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(2468.2771f, 4102.2031f, 37.0647f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(2467.2498f, 4099.5366f, 41.0647f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 248.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(2467.9373f, 4100.7451f, 37.0647f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(2465.3677f, 4101.8813f, 37.0647f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 68.0f;
                    propertyDetails.cctv[1].Pos = new(2466.077637f, 4097.306641f, 40.994057f);
                    propertyDetails.cctv[1].Rot = new(-29.995745f, -0.000000f, -11.943918f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(2465.3677f, 4101.8813f, 37.0647f);
                    propertyDetails.Garage.ExitPlayerHeading = 68.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(2465.4043f, 4102.0166f, 37.0647f);
                    propertyDetails.Garage.CarExitHeading[0] = 353.9050f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(2467.2139f, 4107.9287f, 37.0647f);
                    propertyDetails.Garage.CarExitHeading[1] = 340.5299f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(2470.3066f, 4113.5820f, 37.0647f);
                    propertyDetails.Garage.CarExitHeading[2] = 329.2530f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(2473.9504f, 4116.2158f, 37.0647f);
                    propertyDetails.Garage.CarExitHeading[3] = 291.3084f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(2481.9893f, 4118.2891f, 37.0647f);
                    propertyDetails.Garage.CarExitHeading[4] = 264.1184f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    propertyDetails.PurchaseLocation = new(-45.748684f, 6429.790527f, 56.775539f);
                    propertyDetails.BlipLocation[0] = new(-39.1115f, 6420.4746f, 30.6905f);
                    propertyDetails.BlipLocation[1] = new(-35.3235f, 6424.1157f, 30.4333f);
                    propertyDetails.CamData.Pos = new(-38.014118f, 6407.127441f, 40.712585f);
                    propertyDetails.CamData.Rot = new(-21.779882f, 0.000000f, 16.051352f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-39.4762f, 6419.8228f, 30.4904f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-38.4606f, 6420.8408f, 33.4904f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 45.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-39.1115f, 6420.4746f, 30.6905f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-38.420f, 6421.227f, 31.826f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 45.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-37.1880f, 6418.5347f, 30.4904f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 225.0f;
                    propertyDetails.cctv[0].Pos = new(-37.065594f, 6422.330566f, 33.243950f);
                    propertyDetails.cctv[0].Rot = new(-25.039474f, -0.000000f, 150.094208f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-36.7141f, 6422.5762f, 30.4632f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-33.7452f, 6425.5171f, 34.4328f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 45.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-35.3235f, 6424.1157f, 30.4333f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-32.4131f, 6421.9355f, 30.4598f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 225.0f;
                    propertyDetails.cctv[1].Pos = new(-32.621376f, 6426.550293f, 34.628048f);
                    propertyDetails.cctv[1].Rot = new(-34.962963f, -0.000001f, 146.770294f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-32.5090f, 6421.4312f, 30.4661f);
                    propertyDetails.Garage.ExitPlayerHeading = 225.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-32.5090f, 6421.4312f, 30.4661f);
                    propertyDetails.Garage.CarExitHeading[0] = 225.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-29.1462f, 6417.2378f, 30.4904f);
                    propertyDetails.Garage.CarExitHeading[1] = 225.0f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-24.2641f, 6411.9321f, 30.4904f);
                    propertyDetails.Garage.CarExitHeading[2] = 225.0f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-32.4584f, 6412.8135f, 30.4904f);
                    propertyDetails.Garage.CarExitHeading[3] = 225.0f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-27.9055f, 6408.1694f, 30.4904f);
                    propertyDetails.Garage.CarExitHeading[4] = 225.0f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    propertyDetails.PurchaseLocation = new(-1136.590454f, -1564.308838f, 12.937270f);
                    propertyDetails.BlipLocation[0] = new(-1134.7958f, -1568.8192f, 3.4081f);
                    propertyDetails.BlipLocation[1] = new(-1147.4380f, -1577.5774f, 3.5701f);
                    propertyDetails.CamData.Pos = new(-1117.042603f, -1574.494019f, 13.515028f);
                    propertyDetails.CamData.Rot = new(-17.010227f, -0.000000f, 75.327484f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1135.5327f, -1569.2538f, 3.4117f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1134.2228f, -1568.3727f, 6.4057f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 35.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1134.7958f, -1568.8192f, 3.4081f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1134.403f, -1568.090f, 4.715f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 35.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1133.7134f, -1570.1848f, 3.2607f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 215.0f;
                    propertyDetails.cctv[0].Pos = new(-1137.457031f, -1570.620239f, 7.014599f);
                    propertyDetails.cctv[0].Rot = new(-33.610840f, 0.000001f, -69.272675f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1149.1505f, -1578.8999f, 3.4373f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1145.5365f, -1576.3844f, 7.4348f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.0f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 35.0f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1147.4380f, -1577.5774f, 3.5701f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-1146.2540f, -1579.1456f, 3.2626f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 215.0f;
                    propertyDetails.cctv[1].Pos = new(-1150.860229f, -1580.058716f, 6.993506f);
                    propertyDetails.cctv[1].Rot = new(-35.346024f, 0.000001f, -71.947403f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1146.2540f, -1579.1456f, 3.2626f);
                    propertyDetails.Garage.ExitPlayerHeading = 215.0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1146.2540f, -1579.1456f, 3.2626f);
                    propertyDetails.Garage.CarExitHeading[0] = 215.0f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1125.6335f, -1577.4982f, 3.2418f);
                    propertyDetails.Garage.CarExitHeading[1] = 305.4502f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1144.9355f, -1590.7456f, 3.2428f);
                    propertyDetails.Garage.CarExitHeading[2] = 304.4731f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1139.7471f, -1575.1775f, 3.2834f);
                    propertyDetails.Garage.CarExitHeading[3] = 126.4407f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1157.1512f, -1587.0713f, 3.2301f);
                    propertyDetails.Garage.CarExitHeading[4] = 126.0571f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
            }
        }
        internal static void GetBuildingExteriorDetailsFullPart2(ref PropertyData propertyDetails, BuildingsEnum iBuilding)
        {
            Position buzzerOffset = new();
            propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-66.966522f, 6427.382324f, 34.264103f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-69.531319f, 6424.847656f, 29.282707f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 238.4392f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-70.23156f, 6425.21436f, 30.43954f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-69.8040f, 6424.7310f, 31.8753f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -135.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-68.7020f, 6426.1479f, 30.4390f);
                    propertyDetails.CamData.Pos = new(-83.3466f, 6436.8037f, 35.1359f);
                    propertyDetails.CamData.Rot = new(9.9582f, 0.0000f, -134.7812f);
                    propertyDetails.CamData.FOV = 58.8827f;
                    propertyDetails.PurchaseLocation = new(-67.0695f, 6429.7285f, 30.4383f);
                    propertyDetails.cctv[0].Pos = new(-66.4177f, 6428.4902f, 35.0323f);
                    propertyDetails.cctv[0].Rot = new(-39.6313f, 0.0000f, 112.9385f);
                    propertyDetails.cctv[0].FOV = 57.0534f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(-71.5713f, 6434.2534f, 30.4396f);
                    propertyDetails.Garage.ExitPlayerHeading = 70.9241f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-71.1927f, 6428.8911f, 30.4394f);
                    propertyDetails.Garage.CarExitHeading[0] = 45.2484f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-73.2770f, 6435.9297f, 30.4402f);
                    propertyDetails.Garage.CarExitHeading[1] = 45.8937f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-78.9433f, 6441.6904f, 30.4971f);
                    propertyDetails.Garage.CarExitHeading[2] = 44.1069f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-81.1158f, 6436.3413f, 30.4943f);
                    propertyDetails.Garage.CarExitHeading[3] = 45.7366f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-75.5796f, 6424.6890f, 30.4904f);
                    propertyDetails.Garage.CarExitHeading[4] = 44.5217f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-249.038712f, 6239.044922f, 33.512451f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-245.787231f, 6242.423340f, 30.083305f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 46.1642f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-249.05867f, 6237.58740f, 30.48934f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-249.5378f, 6237.9453f, 31.9300f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 45.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-245.5158f, 6239.0479f, 30.4892f);
                    propertyDetails.CamData.Pos = new(-223.8007f, 6241.2402f, 34.9939f);
                    propertyDetails.CamData.Rot = new(-0.6584f, -0.0000f, 98.1777f);
                    propertyDetails.CamData.FOV = 33.1860f;
                    propertyDetails.PurchaseLocation = new(-249.6617f, 6235.9966f, 30.4891f);
                    propertyDetails.cctv[0].Pos = new(-244.8033f, 6242.5776f, 34.2428f);
                    propertyDetails.cctv[0].Rot = new(-40.6708f, 0.0000f, 145.1215f);
                    propertyDetails.cctv[0].FOV = 64.1840f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(-251.6962f, 6234.6865f, 30.4891f);
                    propertyDetails.Garage.ExitPlayerHeading = 243.0621f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-244.7509f, 6238.0239f, 30.4896f);
                    propertyDetails.Garage.CarExitHeading[0] = 225.1490f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-246.2962f, 6231.4146f, 30.4894f);
                    propertyDetails.Garage.CarExitHeading[1] = 134.7321f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-244.3101f, 6228.8745f, 30.5019f);
                    propertyDetails.Garage.CarExitHeading[2] = 134.7857f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-235.0201f, 6237.3994f, 30.4898f);
                    propertyDetails.Garage.CarExitHeading[3] = 134.9227f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-237.9496f, 6240.6665f, 30.4907f);
                    propertyDetails.Garage.CarExitHeading[4] = 132.8805f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(2556.064697f, 4668.817871f, 37.055973f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(2552.244873f, 4667.131836f, 32.031837f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 208.9861f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(2556.19360f, 4669.48242f, 33.05043f);
                    propertyDetails.Entrance[0].BuzzerProp = new(2556.3943f, 4669.0293f, 34.5895f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -154.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(2554.1653f, 4668.0591f, 33.0233f);
                    propertyDetails.CamData.Pos = new(2524.1899f, 4696.8462f, 35.3387f);
                    propertyDetails.CamData.Rot = new(6.4304f, -0.0000f, -121.3408f);
                    propertyDetails.CamData.FOV = 32.2333f;
                    propertyDetails.PurchaseLocation = new(2556.8303f, 4671.3696f, 32.9989f);
                    propertyDetails.cctv[0].Pos = new(2551.0940f, 4666.8643f, 37.0818f);
                    propertyDetails.cctv[0].Rot = new(-36.8487f, 0.0000f, -50.5276f);
                    propertyDetails.cctv[0].FOV = 57.5607f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(2549.0161f, 4668.9961f, 33.0767f);
                    propertyDetails.Garage.ExitPlayerHeading = 359.9875f;
                    propertyDetails.Garage.CarExitLoc[0] = new(2552.8066f, 4671.2065f, 32.9544f);
                    propertyDetails.Garage.CarExitHeading[0] = 23.4604f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(2549.9641f, 4678.3066f, 32.9764f);
                    propertyDetails.Garage.CarExitHeading[1] = 21.7014f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(2545.6274f, 4688.4160f, 32.5933f);
                    propertyDetails.Garage.CarExitHeading[2] = 23.9501f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(2552.9734f, 4681.7524f, 32.9039f);
                    propertyDetails.Garage.CarExitHeading[3] = 16.9448f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(2549.8342f, 4690.1953f, 32.6529f);
                    propertyDetails.Garage.CarExitHeading[4] = 19.1831f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(2460.892578f, 1587.033691f, 36.205948f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(2460.912842f, 1591.731689f, 29.727119f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 90.6692f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(2461.74316f, 1592.12817f, 31.72039f);
                    propertyDetails.Entrance[0].BuzzerProp = new(2461.0132f, 1592.0822f, 33.5060f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(2461.2202f, 1589.2552f, 32.0443f);
                    propertyDetails.CamData.Pos = new(2554.2195f, 1605.9854f, 39.4534f);
                    propertyDetails.CamData.Rot = new(2.9221f, -0.0000f, 108.0557f);
                    propertyDetails.CamData.FOV = 32.0143f;
                    propertyDetails.PurchaseLocation = new(2463.3840f, 1585.3732f, 31.7201f);
                    propertyDetails.cctv[0].Pos = new(2461.3259f, 1592.2249f, 36.2419f);
                    propertyDetails.cctv[0].Rot = new(-48.7504f, -0.0000f, -174.4014f);
                    propertyDetails.cctv[0].FOV = 60.2443f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(2462.8696f, 1593.2992f, 31.7201f);
                    propertyDetails.Garage.ExitPlayerHeading = 232.3503f;
                    propertyDetails.Garage.CarExitLoc[0] = new(2464.1997f, 1589.4071f, 31.7204f);
                    propertyDetails.Garage.CarExitHeading[0] = 270.5459f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(2472.1218f, 1589.4701f, 31.7204f);
                    propertyDetails.Garage.CarExitHeading[1] = 270.4538f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(2481.7297f, 1589.5356f, 31.7204f);
                    propertyDetails.Garage.CarExitHeading[2] = 270.3932f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(2472.5432f, 1582.7057f, 31.7204f);
                    propertyDetails.Garage.CarExitHeading[3] = 236.2670f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(2482.1946f, 1578.4744f, 31.7204f);
                    propertyDetails.Garage.CarExitHeading[4] = 249.5383f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-2204.263184f, 4241.036133f, 47.070641f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-2206.512451f, 4244.067383f, 50.317635f);
                    propertyDetails.Entrance[0].locateDetails.Width = 9.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 215.8775f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-2201.77759f, 4245.77295f, 47.29582f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-2201.5972f, 4245.4985f, 48.8956f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -143.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-2203.3350f, 4244.4272f, 47.3305f);
                    propertyDetails.CamData.Pos = new(-2203.1672f, 4289.1372f, 57.1272f);
                    propertyDetails.CamData.Rot = new(-14.5968f, -0.0000f, 165.7235f);
                    propertyDetails.CamData.FOV = 26.2662f;
                    propertyDetails.PurchaseLocation = new(-2203.8342f, 4245.8105f, 46.9031f);
                    propertyDetails.cctv[0].Pos = new(-2201.4858f, 4245.6455f, 50.0007f);
                    propertyDetails.cctv[0].Rot = new(-39.3492f, -0.0000f, 97.0326f);
                    propertyDetails.cctv[0].FOV = 63.7082f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(-2210.0066f, 4257.9272f, 46.3102f);
                    propertyDetails.Garage.ExitPlayerHeading = 0f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-2204.8350f, 4247.0928f, 46.6831f);
                    propertyDetails.Garage.CarExitHeading[0] = 37.0444f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-2211.0085f, 4253.1733f, 46.3205f);
                    propertyDetails.Garage.CarExitHeading[1] = 65.1199f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-2220.8774f, 4256.5923f, 45.5691f);
                    propertyDetails.Garage.CarExitHeading[2] = 67.5084f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-2209.1931f, 4246.2075f, 46.5722f);
                    propertyDetails.Garage.CarExitHeading[3] = 57.1749f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-2219.0522f, 4250.2964f, 45.6889f);
                    propertyDetails.Garage.CarExitHeading[4] = 67.5023f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(220.727264f, 2601.928223f, 48.241409f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(215.375458f, 2600.983154f, 43.255169f);
                    propertyDetails.Entrance[0].locateDetails.Width = 5.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 194.0507f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(215.05670f, 2601.51221f, 44.75016f);
                    propertyDetails.Entrance[0].BuzzerProp = new(215.0199f, 2601.0264f, 46.2970f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -170.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(218.0665f, 2601.8171f, 44.7668f);
                    propertyDetails.CamData.Pos = new(203.8715f, 2620.3718f, 47.9511f);
                    propertyDetails.CamData.Rot = new(0.9185f, -0.0000f, -139.0046f);
                    propertyDetails.CamData.FOV = 25.1587f;
                    propertyDetails.PurchaseLocation = new(211.8593f, 2605.9016f, 44.9672f);
                    propertyDetails.cctv[0].Pos = new(214.6859f, 2601.0364f, 47.9360f);
                    propertyDetails.cctv[0].Rot = new(-35.1379f, 0.0000f, -59.8548f);
                    propertyDetails.cctv[0].FOV = 62.3358f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(221.5349f, 2608.2761f, 45.2190f);
                    propertyDetails.Garage.ExitPlayerHeading = 2.3625f;
                    propertyDetails.Garage.CarExitLoc[0] = new(217.5363f, 2604.5447f, 44.9176f);
                    propertyDetails.Garage.CarExitHeading[0] = 10.8359f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(215.5460f, 2615.0037f, 46.0539f);
                    propertyDetails.Garage.CarExitHeading[1] = 10.3759f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(208.0219f, 2618.4043f, 46.4394f);
                    propertyDetails.Garage.CarExitHeading[2] = 38.3398f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(225.5106f, 2608.1196f, 45.1560f);
                    propertyDetails.Garage.CarExitHeading[3] = 34.4217f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(221.6936f, 2616.8738f, 45.8940f);
                    propertyDetails.Garage.CarExitHeading[4] = 14.1856f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(186.231995f, 2784.172607f, 49.265640f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(185.478439f, 2788.868896f, 42.746250f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 96.4365f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(185.98155f, 2789.38696f, 44.52750f);
                    propertyDetails.Entrance[0].BuzzerProp = new(185.4518f, 2789.3843f, 46.0915f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 99.5f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(186.1719f, 2786.3425f, 45.0144f);
                    propertyDetails.CamData.Pos = new(204.1797f, 2781.6101f, 46.8041f);
                    propertyDetails.CamData.Rot = new(2.1959f, -0.0000f, 70.7072f);
                    propertyDetails.CamData.FOV = 30.0687f;
                    propertyDetails.PurchaseLocation = new(187.7611f, 2782.9468f, 44.6553f);
                    propertyDetails.cctv[0].Pos = new(186.8019f, 2782.5754f, 49.2501f);
                    propertyDetails.cctv[0].Rot = new(-40.3641f, -0.0000f, -20.6897f);
                    propertyDetails.cctv[0].FOV = 61.8127f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(188.1871f, 2790.8137f, 44.5641f);
                    propertyDetails.Garage.ExitPlayerHeading = 263.0688f;
                    propertyDetails.Garage.CarExitLoc[0] = new(190.1576f, 2787.2988f, 44.6088f);
                    propertyDetails.Garage.CarExitHeading[0] = 282.2347f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(188.9260f, 2794.5137f, 44.6552f);
                    propertyDetails.Garage.CarExitHeading[1] = 6.4226f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(193.6776f, 2794.9871f, 44.6552f);
                    propertyDetails.Garage.CarExitHeading[2] = 8.4438f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(188.1367f, 2802.6470f, 44.6552f);
                    propertyDetails.Garage.CarExitHeading[3] = 4.8248f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(192.7628f, 2803.0625f, 44.6552f);
                    propertyDetails.Garage.CarExitHeading[4] = 8.5929f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(641.295959f, 2771.369873f, 40.687790f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(637.174194f, 2771.076172f, 44.582718f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 184.4578f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(636.96204f, 2772.02246f, 41.02439f);
                    propertyDetails.Entrance[0].BuzzerProp = new(636.8882f, 2771.1980f, 42.5919f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -176.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(639.45f, 2771.2f, 41.2f);
                    propertyDetails.CamData.Pos = new(680.7204f, 2782.6965f, 45.1229f);
                    propertyDetails.CamData.Rot = new(0.1065f, -0.0000f, 80.5649f);
                    propertyDetails.CamData.FOV = 34.4741f;
                    propertyDetails.PurchaseLocation = new(643.8202f, 2787.8726f, 40.9563f);
                    propertyDetails.cctv[0].Pos = new(641.8820f, 2794.9102f, 44.6330f);
                    propertyDetails.cctv[0].Rot = new(-39.3967f, 0.0000f, -161.2362f);
                    propertyDetails.cctv[0].FOV = 55.4012f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(637.2254f, 2784.6633f, 41.0101f);
                    propertyDetails.Garage.ExitPlayerHeading = 227.5745f;
                    propertyDetails.Garage.CarExitLoc[0] = new(638.8456f, 2776.4204f, 40.9690f);
                    propertyDetails.Garage.CarExitHeading[0] = 4.5972f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(644.3888f, 2779.1707f, 40.9367f);
                    propertyDetails.Garage.CarExitHeading[1] = 275.5146f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(647.0148f, 2770.9834f, 40.9766f);
                    propertyDetails.Garage.CarExitHeading[2] = 183.5678f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(649.6042f, 2757.4421f, 40.9613f);
                    propertyDetails.Garage.CarExitHeading[3] = 202.3017f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(653.1031f, 2764.2092f, 40.9388f);
                    propertyDetails.Garage.CarExitHeading[4] = 228.5975f;
                    propertyDetails.Garage.CarExitWeight[0] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1131.622314f, 2702.444824f, 20.784332f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1129.753784f, 2700.222168f, 17.566471f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 308.0592f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1128.03064f, 2697.54102f, 17.80039f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1127.6660f, 2697.7524f, 19.3395f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -48.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-1130.9376f, 2701.1333f, 17.8004f);
                    propertyDetails.CamData.Pos = new(-1154.7216f, 2665.7944f, 20.9318f);
                    propertyDetails.CamData.Rot = new(2.0466f, -0.0000f, -47.8797f);
                    propertyDetails.CamData.FOV = 26.9081f;
                    propertyDetails.PurchaseLocation = new(-1129.3767f, 2697.9443f, 17.8005f);
                    propertyDetails.cctv[0].Pos = new(-1128.8252f, 2698.8555f, 21.1368f);
                    propertyDetails.cctv[0].Rot = new(-34.5325f, -0.0000f, 54.3263f);
                    propertyDetails.cctv[0].FOV = 59.8904f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(-1129.4147f, 2697.9575f, 17.8003f);
                    propertyDetails.Garage.ExitPlayerHeading = 148.8793f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1131.8142f, 2697.0757f, 17.8004f);
                    propertyDetails.Garage.CarExitHeading[0] = 153.0315f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1135.4033f, 2690.0298f, 17.8004f);
                    propertyDetails.Garage.CarExitHeading[1] = 152.9890f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1138.8588f, 2682.2061f, 17.1049f);
                    propertyDetails.Garage.CarExitHeading[2] = 174.7645f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1135.5634f, 2672.6858f, 17.0939f);
                    propertyDetails.Garage.CarExitHeading[3] = 219.4992f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1138.6471f, 2667.3992f, 17.0928f);
                    propertyDetails.Garage.CarExitHeading[4] = 178.4860f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-9.274190f, -1648.472412f, 33.096531f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-13.008923f, -1645.338379f, 27.815578f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 153.8012f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-8.29621f, -1648.11963f, 28.32089f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-8.7565f, -1648.4497f, 29.9717f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 140.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-10.9440f, -1646.7601f, 28.3125f);
                    propertyDetails.CamData.Pos = new(30.3715f, -1607.5082f, 36.8431f);
                    propertyDetails.CamData.Rot = new(-3.1524f, -0.0000f, 139.9197f);
                    propertyDetails.CamData.FOV = 21.3688f;
                    propertyDetails.PurchaseLocation = new(-7.1931f, -1648.7003f, 28.3206f);
                    propertyDetails.cctv[0].Pos = new(-7.8353f, -1649.1998f, 32.7190f);
                    propertyDetails.cctv[0].Rot = new(-35.0705f, -0.0000f, 28.4357f);
                    propertyDetails.cctv[0].FOV = 56.1118f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(-1.0175f, -1653.2354f, 28.3206f);
                    propertyDetails.Garage.ExitPlayerHeading = 308.6224f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-8.7616f, -1643.9999f, 28.1685f);
                    propertyDetails.Garage.CarExitHeading[0] = 319.3071f;
                    propertyDetails.Garage.CarExitWeight[0] = 50.0901f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-13.2855f, -1639.2626f, 28.1651f);
                    propertyDetails.Garage.CarExitHeading[1] = 320.2909f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-4.2297f, -1646.7322f, 28.1645f);
                    propertyDetails.Garage.CarExitHeading[2] = 231.2027f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(0.6959f, -1650.6791f, 28.1606f);
                    propertyDetails.Garage.CarExitHeading[3] = 231.2781f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(6.6154f, -1654.3099f, 28.1579f);
                    propertyDetails.Garage.CarExitHeading[4] = 264.0044f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(1023.649719f, -2401.359131f, 34.944851f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(1024.319702f, -2395.397705f, 28.735165f);
                    propertyDetails.Entrance[0].locateDetails.Width = 5.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 92.2894f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(1026.16577f, -2394.39233f, 29.07515f);
                    propertyDetails.Entrance[0].BuzzerProp = new(1025.5039f, -2394.2144f, 30.7512f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 85.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(1024.2628f, -2398.4036f, 29.1261f);
                    propertyDetails.CamData.Pos = new(1056.3915f, -2400.2139f, 36.3721f);
                    propertyDetails.CamData.Rot = new(1.2159f, 0.0000f, 86.3154f);
                    propertyDetails.CamData.FOV = 41.0913f;
                    propertyDetails.PurchaseLocation = new(1026.0168f, -2404.0728f, 28.7200f);
                    propertyDetails.cctv[0].Pos = new(1025.4635f, -2394.4709f, 35.4670f);
                    propertyDetails.cctv[0].Rot = new(-52.0974f, -0.0000f, 175.3725f);
                    propertyDetails.cctv[0].FOV = 63.3140f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(1026.8683f, -2383.1951f, 29.3707f);
                    propertyDetails.Garage.ExitPlayerHeading = 278.7988f;
                    propertyDetails.Garage.CarExitLoc[0] = new(1028.0582f, -2398.6733f, 28.7850f);
                    propertyDetails.Garage.CarExitHeading[0] = 263.1474f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(1028.7896f, -2403.6509f, 28.5859f);
                    propertyDetails.Garage.CarExitHeading[1] = 211.1604f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(1030.3021f, -2394.4202f, 28.9265f);
                    propertyDetails.Garage.CarExitHeading[2] = 323.9013f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(1030.8512f, -2388.2048f, 29.1169f);
                    propertyDetails.Garage.CarExitHeading[3] = 354.9865f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(1028.4369f, -2409.6482f, 28.3444f);
                    propertyDetails.Garage.CarExitHeading[4] = 176.4828f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(870.894958f, -2230.893311f, 29.019482f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(870.617798f, -2233.976074f, 34.832703f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 355.1031f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(873.18457f, -2233.25317f, 29.54528f);
                    propertyDetails.Entrance[0].BuzzerProp = new(873.3047f, -2232.6067f, 31.0195f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -5.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(870.8577f, -2232.3228f, 29.5508f);
                    propertyDetails.CamData.Pos = new(839.1729f, -2251.3359f, 36.3461f);
                    propertyDetails.CamData.Rot = new(-2.4285f, -0.0000f, -61.0109f);
                    propertyDetails.CamData.FOV = 27.8913f;
                    propertyDetails.PurchaseLocation = new(867.3748f, -2233.0640f, 29.5120f);
                    propertyDetails.cctv[0].Pos = new(865.7656f, -2231.9331f, 35.2020f);
                    propertyDetails.cctv[0].Rot = new(-41.4886f, 0.0000f, -115.6493f);
                    propertyDetails.cctv[0].FOV = 52.8804f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Garage.ExitPlayerPos = new(857.1803f, -2231.2981f, 29.4231f);
                    propertyDetails.Garage.ExitPlayerHeading = 198.7231f;
                    propertyDetails.Garage.CarExitLoc[0] = new(870.4635f, -2235.9758f, 29.6135f);
                    propertyDetails.Garage.CarExitHeading[0] = 175.5827f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(865.8381f, -2235.6646f, 29.5193f);
                    propertyDetails.Garage.CarExitHeading[1] = 126.7770f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(875.8398f, -2239.8640f, 29.4001f);
                    propertyDetails.Garage.CarExitHeading[2] = 264.6278f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(864.8415f, -2239.6333f, 29.3801f);
                    propertyDetails.Garage.CarExitHeading[3] = 85.2316f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(857.4260f, -2236.4231f, 29.3134f);
                    propertyDetails.Garage.CarExitHeading[4] = 105.4882f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-662.181946f, -2377.943359f, 17.998512f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-665.329773f, -2383.396240f, 12.702133f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 246.1582f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-667.04858f, -2383.26904f, 12.92401f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-666.3141f, -2383.7715f, 14.6044f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -120.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-663.8541f, -2380.3889f, 12.9446f);
                    propertyDetails.CamData.Pos = new(-719.5740f, -2366.9417f, 20.1524f);
                    propertyDetails.CamData.Rot = new(1.5858f, 0.0000f, -92.4432f);
                    propertyDetails.CamData.FOV = 25.2947f;
                    propertyDetails.PurchaseLocation = new(-662.9977f, -2375.8777f, 12.9198f);
                    propertyDetails.cctv[0].Pos = new(-666.2004f, -2383.6599f, 17.4456f);
                    propertyDetails.cctv[0].Rot = new(-41.4322f, -0.0000f, -22.9677f);
                    propertyDetails.cctv[0].FOV = 64.8067f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(-659.9097f, -2368.9719f, 12.9446f);
                    propertyDetails.Garage.ExitPlayerHeading = 49.4983f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-667.7959f, -2378.3474f, 12.8602f);
                    propertyDetails.Garage.CarExitHeading[0] = 59.5981f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-668.5652f, -2372.9788f, 12.8107f);
                    propertyDetails.Garage.CarExitHeading[1] = 27.3385f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-674.8391f, -2379.8542f, 12.8041f);
                    propertyDetails.Garage.CarExitHeading[2] = 100.3572f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-670.3742f, -2383.3569f, 12.8684f);
                    propertyDetails.Garage.CarExitHeading[3] = 121.2465f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-679.6597f, -2387.9653f, 12.8113f);
                    propertyDetails.Garage.CarExitHeading[4] = 113.4791f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1086.132080f, -2237.117920f, 18.677397f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1091.123413f, -2232.125732f, 11.673464f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 132.9527f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1090.98694f, -2231.39160f, 12.22213f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1091.3480f, -2231.6953f, 13.7872f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -135.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-1088.6158f, -2235.0977f, 12.2182f);
                    propertyDetails.CamData.Pos = new(-1089.1172f, -2209.6890f, 16.8480f);
                    propertyDetails.CamData.Rot = new(1.8425f, -0.0000f, -162.2026f);
                    propertyDetails.CamData.FOV = 38.6580f;
                    propertyDetails.PurchaseLocation = new(-1084.3058f, -2237.9534f, 12.2685f);
                    propertyDetails.cctv[0].Pos = new(-1092.0020f, -2230.7087f, 18.7219f);
                    propertyDetails.cctv[0].Rot = new(-41.9243f, -0.0000f, -135.0189f);
                    propertyDetails.cctv[0].FOV = 57.1276f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.ExitPlayerPos = new(-1078.7614f, -2242.1765f, 12.2722f);
                    propertyDetails.Garage.ExitPlayerHeading = 307.3823f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1086.2666f, -2232.2776f, 12.2336f);
                    propertyDetails.Garage.CarExitHeading[0] = 314.6230f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1082.5579f, -2234.5615f, 12.2378f);
                    propertyDetails.Garage.CarExitHeading[1] = 282.1199f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1089.8103f, -2228.2419f, 12.2350f);
                    propertyDetails.Garage.CarExitHeading[2] = 1.3510f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1094.4353f, -2223.4783f, 12.2355f);
                    propertyDetails.Garage.CarExitHeading[3] = 23.0358f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1077.5790f, -2238.8528f, 12.2399f);
                    propertyDetails.Garage.CarExitHeading[4] = 248.6185f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-341.682800f, -1466.340576f, 28.861671f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-346.650208f, -1466.225342f, 32.950165f);
                    propertyDetails.Entrance[0].locateDetails.Width = 8.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 96.3665f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-342.01886f, -1466.66724f, 29.61167f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-342.7317f, -1466.6293f, 31.2761f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 90.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-342.5126f, -1468.6746f, 29.6107f);
                    propertyDetails.CamData.Pos = new(-310.1259f, -1433.7842f, 36.4266f);
                    propertyDetails.CamData.Rot = new(-2.5852f, -0.0000f, 142.0256f);
                    propertyDetails.CamData.FOV = 23.0369f;
                    propertyDetails.PurchaseLocation = new(-341.5999f, -1471.6276f, 29.7515f);
                    propertyDetails.cctv[0].Pos = new(-342.7205f, -1471.8623f, 33.2148f);
                    propertyDetails.cctv[0].Rot = new(-32.0401f, 0.0000f, -23.2693f);
                    propertyDetails.cctv[0].FOV = 56.3666f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(-356.7247f, -1463.1417f, 28.6324f);
                    propertyDetails.Garage.ExitPlayerHeading = 5.3571f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-339.0020f, -1467.7991f, 29.5844f);
                    propertyDetails.Garage.CarExitHeading[0] = 281.1683f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-339.1405f, -1462.8916f, 29.5900f);
                    propertyDetails.Garage.CarExitHeading[1] = 293.1545f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-332.1327f, -1458.4500f, 29.4955f);
                    propertyDetails.Garage.CarExitHeading[2] = 306.6605f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-330.6393f, -1464.0457f, 29.5099f);
                    propertyDetails.Garage.CarExitHeading[3] = 298.5376f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-336.3814f, -1474.6881f, 29.5482f);
                    propertyDetails.Garage.CarExitHeading[4] = 212.1829f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1240.189087f, -259.505829f, 41.044113f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1242.813721f, -260.929413f, 37.777046f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 211.7432f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1243.63611f, -260.30231f, 37.94491f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1243.3290f, -261.0626f, 39.5057f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, -151.5f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_SIDE;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(-1241.5399f, -259.8841f, 37.9445f);
                    propertyDetails.CamData.Pos = new(-1238.6152f, -237.7320f, 41.2694f);
                    propertyDetails.CamData.Rot = new(-0.1405f, -0.0000f, 174.5821f);
                    propertyDetails.CamData.FOV = 29.2463f;
                    propertyDetails.PurchaseLocation = new(-1239.2970f, -257.4720f, 37.9577f);
                    propertyDetails.cctv[0].Pos = new(-1243.7146f, -261.1733f, 41.0460f);
                    propertyDetails.cctv[0].Rot = new(-41.9739f, -0.0000f, -52.1773f);
                    propertyDetails.cctv[0].FOV = 64.1421f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(-1231.7517f, -261.1873f, 37.7356f);
                    propertyDetails.Garage.ExitPlayerHeading = 309.7137f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1243.3073f, -256.9916f, 38.0127f);
                    propertyDetails.Garage.CarExitHeading[0] = 28.1569f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1239.4128f, -252.4819f, 38.1356f);
                    propertyDetails.Garage.CarExitHeading[1] = 345.0404f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1247.6144f, -259.2161f, 38.0121f);
                    propertyDetails.Garage.CarExitHeading[2] = 83.7995f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1254.6190f, -261.4668f, 38.0736f);
                    propertyDetails.Garage.CarExitHeading[3] = 117.0801f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1234.7942f, -253.1250f, 38.1299f);
                    propertyDetails.Garage.CarExitHeading[4] = 250.1010f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(901.995605f, -148.902100f, 79.349731f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(897.741821f, -146.494080f, 75.320961f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 150.9974f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(897.51843f, -145.34059f, 75.70785f);
                    propertyDetails.Entrance[0].BuzzerProp = new(897.3796f, -145.9439f, 77.0859f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 150.0f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.BlipLocation[0] = new(899.8448f, -147.5280f, 75.5674f);
                    propertyDetails.CamData.Pos = new(897.9404f, -97.0383f, 81.3473f);
                    propertyDetails.CamData.Rot = new(-0.5489f, -0.0000f, -176.1915f);
                    propertyDetails.CamData.FOV = 18.6505f;
                    propertyDetails.PurchaseLocation = new(895.2067f, -142.3797f, 75.9438f);
                    propertyDetails.cctv[0].Pos = new(903.5604f, -148.9383f, 79.4718f);
                    propertyDetails.cctv[0].Rot = new(-33.5031f, 0.0000f, 47.9397f);
                    propertyDetails.cctv[0].FOV = 61.3316f;
                    propertyDetails.NumEntrances = 1;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Garage.ExitPlayerPos = new(896.6425f, -143.7906f, 75.8284f);
                    propertyDetails.Garage.ExitPlayerHeading = 331.8638f;
                    propertyDetails.Garage.CarExitLoc[0] = new(902.2581f, -143.8422f, 75.6196f);
                    propertyDetails.Garage.CarExitHeading[0] = 327.9151f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(908.1265f, -141.9543f, 75.4090f);
                    propertyDetails.Garage.CarExitHeading[1] = 291.4932f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(901.1325f, -137.1122f, 75.7044f);
                    propertyDetails.Garage.CarExitHeading[2] = 16.3723f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(895.2284f, -133.0699f, 76.0953f);
                    propertyDetails.Garage.CarExitHeading[3] = 56.9496f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(914.0188f, -145.0915f, 74.9349f);
                    propertyDetails.Garage.CarExitHeading[4] = 237.7844f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    propertyDetails.PurchaseLocation = new(-1405.4109f, 526.8572f, 122.8361f);
                    propertyDetails.BlipLocation[0] = new(-1405.4109f, 526.8572f, 122.8361f);
                    propertyDetails.BlipLocation[1] = new(-1405.0873f, 540.0269f, 121.9285f);
                    propertyDetails.CamData.Pos = new(-1426.9503f, 560.2891f, 134.0229f);
                    propertyDetails.CamData.Rot = new(-12.2373f, -0.0000f, -138.4202f);
                    propertyDetails.CamData.FOV = 30.8201f;
                    propertyDetails.HouseHeistExitLocation = new(-1409.1404f, 534.6944f, 121.9111f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1404.915039f, 526.850647f, 121.867462f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1406.636963f, 526.843445f, 126.586113f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 262.0459f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1405.4109f, 526.8572f, 122.8361f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1405.4066f, 528.2228f, 124.3400f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, -88.8000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1406.1443f, 529.9474f, 122.8361f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 11.333f;
                    propertyDetails.cctv[0].Pos = new(-1405.9202f, 525.1206f, 126.2389f);
                    propertyDetails.cctv[0].Rot = new(-45.9372f, -0.0000f, 12.5680f);
                    propertyDetails.cctv[0].FOV = 56.7555f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1404.632690f, 540.320862f, 120.969200f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1406.549683f, 540.324707f, 125.677330f);
                    propertyDetails.Entrance[1].locateDetails.Width = 8.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 265.3779f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1405.0873f, 540.0269f, 121.9285f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1405.4771f, 535.6528f, 123.3700f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, 0.0000f, -88.8000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1405.8713f, 543.8805f, 125.0912f);
                    propertyDetails.cctv[1].Rot = new(-41.1469f, 0.0000f, 159.0998f);
                    propertyDetails.cctv[1].FOV = 68.4407f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1409.2903f, 538.0002f, 121.9135f);
                    propertyDetails.Garage.ExitPlayerHeading = 93.7343f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1409.0726f, 537.7550f, 121.9144f);
                    propertyDetails.Garage.CarExitHeading[0] = 98.0524f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1409.0262f, 541.6954f, 121.9180f);
                    propertyDetails.Garage.CarExitHeading[1] = 104.4953f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1417.0787f, 539.0190f, 120.7941f);
                    propertyDetails.Garage.CarExitHeading[2] = 114.0971f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1416.7280f, 535.2925f, 120.5692f);
                    propertyDetails.Garage.CarExitHeading[3] = 107.5656f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1423.5465f, 534.5643f, 119.4372f);
                    propertyDetails.Garage.CarExitHeading[4] = 106.4241f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    propertyDetails.PurchaseLocation = new(1336.8986f, -1578.7438f, 53.4443f);
                    propertyDetails.BlipLocation[0] = new(1336.8986f, -1578.7438f, 53.4443f);
                    propertyDetails.BlipLocation[1] = new(1351.9443f, -1575.2987f, 53.0439f);
                    propertyDetails.CamData.Pos = new(1369.5925f, -1586.2245f, 56.3956f);
                    propertyDetails.CamData.Rot = new(-2.2156f, -0.0000f, 66.1587f);
                    propertyDetails.CamData.FOV = 26.8035f;
                    propertyDetails.HouseHeistExitLocation = new(1338.1633f, -1580.7217f, 53.0517f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(1337.235352f, -1579.397827f, 52.801712f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(1336.622681f, -1578.602417f, 55.910572f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 44.4010f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(1336.8986f, -1578.7438f, 53.4443f);
                    propertyDetails.Entrance[0].BuzzerProp = new(1335.6700f, -1579.3400f, 54.4900f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, 36.7500f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(1338.1633f, -1580.7217f, 53.0517f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 233.6165f;
                    propertyDetails.cctv[0].Pos = new(1344.8154f, -1579.6471f, 55.9164f);
                    propertyDetails.cctv[0].Rot = new(-20.7335f, 0.0000f, 83.8051f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(1347.030884f, -1573.104126f, 52.919212f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(1352.191406f, -1570.003296f, 55.655323f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 31.0130f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(1351.9443f, -1575.2987f, 53.0439f);
                    propertyDetails.Entrance[1].BuzzerProp = new(1346.8800f, -1573.1899f, 54.4900f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, 0.0000f, 30.6500f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(1347.8281f, -1577.4059f, 55.9645f);
                    propertyDetails.cctv[1].Rot = new(-20.5771f, 0.0000f, -12.7006f);
                    propertyDetails.cctv[1].FOV = 50f;
                    propertyDetails.Garage.ExitPlayerPos = new(1350.6079f, -1573.0576f, 53.0515f);
                    propertyDetails.Garage.ExitPlayerHeading = 214.7269f;
                    propertyDetails.Garage.CarExitLoc[0] = new(1354.6522f, -1578.6346f, 52.7106f);
                    propertyDetails.Garage.CarExitHeading[0] = 215.0819f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(1372.8141f, -1582.1458f, 52.6000f);
                    propertyDetails.Garage.CarExitHeading[1] = 305.4971f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(1386.5300f, -1572.2173f, 53.9185f);
                    propertyDetails.Garage.CarExitHeading[2] = 305.6955f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(1353.2223f, -1589.8846f, 51.5701f);
                    propertyDetails.Garage.CarExitHeading[3] = 128.0031f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(1344.0901f, -1596.9325f, 51.0919f);
                    propertyDetails.Garage.CarExitHeading[4] = 127.4157f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    propertyDetails.PurchaseLocation = new(-104.9801f, 6529.1636f, 29.1719f);
                    propertyDetails.BlipLocation[0] = new(-104.9801f, 6529.1636f, 29.1719f);
                    propertyDetails.BlipLocation[1] = new(-105.0318f, 6534.6777f, 28.8092f);
                    propertyDetails.CamData.Pos = new(-110.1730f, 6576.2578f, 32.1717f);
                    propertyDetails.CamData.Rot = new(0.0198f, -0.0000f, -177.4159f);
                    propertyDetails.CamData.FOV = 18.7421f;
                    propertyDetails.HouseHeistExitLocation = new(-108.2526f, 6531.6304f, 28.8092f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-105.373589f, 6527.764648f, 28.952587f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-106.473595f, 6528.864258f, 31.613363f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 134.6413f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-104.9801f, 6529.1636f, 29.1719f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-106.6888f, 6528.8799f, 30.3018f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, -137.2000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-108.2526f, 6531.6304f, 28.8092f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 49.2311f;
                    propertyDetails.cctv[0].Pos = new(-100.0377f, 6532.9863f, 31.7713f);
                    propertyDetails.cctv[0].Rot = new(-15.7838f, -0.0000f, 102.1657f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-99.839272f, 6532.972168f, 28.765419f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-103.050629f, 6529.760254f, 31.867950f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 225.2950f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-105.0318f, 6534.6777f, 28.8092f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-99.7988f, 6533.0098f, 30.2618f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, 0.0000f, -134.5000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-110.8133f, 6530.8481f, 31.8120f);
                    propertyDetails.cctv[1].Rot = new(-16.9222f, -0.0000f, -80.7392f);
                    propertyDetails.cctv[1].FOV = 52.8642f;
                    propertyDetails.Garage.ExitPlayerPos = new(-103.1034f, 6532.6592f, 28.8092f);
                    propertyDetails.Garage.ExitPlayerHeading = 43.8528f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-104.5972f, 6534.2437f, 28.8092f);
                    propertyDetails.Garage.CarExitHeading[0] = 46.1190f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-110.2358f, 6539.6636f, 28.7473f);
                    propertyDetails.Garage.CarExitHeading[1] = 46.1600f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-110.7653f, 6550.7910f, 28.5617f);
                    propertyDetails.Garage.CarExitHeading[2] = 312.715f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-101.0747f, 6560.0410f, 28.5630f);
                    propertyDetails.Garage.CarExitHeading[3] = 312.1525f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-129.3656f, 6539.9092f, 28.5080f);
                    propertyDetails.Garage.CarExitHeading[4] = 136.4030f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    propertyDetails.PurchaseLocation = new(-302.6793f, 6327.5308f, 31.8915f);
                    propertyDetails.BlipLocation[0] = new(-302.6793f, 6327.5308f, 31.8915f);
                    propertyDetails.BlipLocation[1] = new(-294.5604f, 6338.5225f, 31.2827f);
                    propertyDetails.CamData.Pos = new(-338.4015f, 6342.9194f, 33.9788f);
                    propertyDetails.CamData.Rot = new(-0.5933f, 0.0000f, -109.2485f);
                    propertyDetails.CamData.FOV = 26.0857f;
                    propertyDetails.HouseHeistExitLocation = new(-774.1072f, 303.6408f, 84.7069f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-301.291138f, 6327.553711f, 31.742939f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-302.727905f, 6326.001465f, 34.444378f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 220.6790f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-302.6793f, 6327.5308f, 31.8915f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-301.0700f, 6327.5400f, 33.3600f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, -136.7000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-305.3481f, 6331.0146f, 31.4893f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 48.1647f;
                    propertyDetails.cctv[0].Pos = new(-306.7626f, 6327.7148f, 34.1136f);
                    propertyDetails.cctv[0].Rot = new(-23.3308f, -0.0000f, -79.0093f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-289.391266f, 6337.942383f, 29.084129f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-293.809296f, 6333.271973f, 34.088074f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 225.6549f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-294.5604f, 6338.5225f, 31.2827f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-294.0300f, 6333.0400f, 32.9800f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, -133.0000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-300.2161f, 6330.6045f, 33.8086f);
                    propertyDetails.cctv[1].Rot = new(-10.9035f, -0.0000f, -49.6255f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-293.1363f, 6337.6538f, 31.4098f);
                    propertyDetails.Garage.ExitPlayerHeading = 38.2211f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-295.2674f, 6339.1025f, 31.2112f);
                    propertyDetails.Garage.CarExitHeading[0] = 45.0538f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-303.0802f, 6346.8691f, 29.8847f);
                    propertyDetails.Garage.CarExitHeading[1] = 45.1332f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-301.9123f, 6360.8232f, 29.5040f);
                    propertyDetails.Garage.CarExitHeading[2] = 312.3356f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-320.7206f, 6350.6987f, 29.3934f);
                    propertyDetails.Garage.CarExitHeading[3] = 133.3218f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-329.3412f, 6342.1123f, 29.2682f);
                    propertyDetails.Garage.CarExitHeading[4] = 134.0955f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_6;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    propertyDetails.PurchaseLocation = new(-14.8944f, 6557.8179f, 32.2454f);
                    propertyDetails.BlipLocation[0] = new(-14.8944f, 6557.8179f, 32.2454f);
                    propertyDetails.BlipLocation[1] = new(-12.2099f, 6563.8950f, 30.9552f);
                    propertyDetails.CamData.Pos = new(13.1554f, 6522.4551f, 33.9638f);
                    propertyDetails.CamData.Rot = new(2.0923f, -0.0000f, 45.5912f);
                    propertyDetails.CamData.FOV = 22.9656f;
                    propertyDetails.HouseHeistExitLocation = new(-12.7249f, 6559.9575f, 30.9710f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-15.009585f, 6556.497070f, 32.010277f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-16.197723f, 6557.742188f, 34.745510f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 136.3973f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-14.8944f, 6557.8179f, 32.2454f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-14.6600f, 6556.1401f, 33.7500f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 135.0000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-12.7249f, 6559.9575f, 30.9710f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 315.8066f;
                    propertyDetails.cctv[0].Pos = new(-18.3390f, 6560.1191f, 34.7698f);
                    propertyDetails.cctv[0].Rot = new(-16.6529f, 0.0000f, -109.5559f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-16.852196f, 6565.348633f, 30.658970f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-13.642389f, 6568.558105f, 33.626915f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 44.0470f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-12.2099f, 6563.8950f, 30.9552f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-16.9900f, 6565.2100f, 32.3400f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 45.1000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-9.7957f, 6554.7085f, 35.1352f);
                    propertyDetails.cctv[1].Rot = new(-19.8197f, 0.0000f, 18.0251f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(-13.5522f, 6565.2529f, 30.9267f);
                    propertyDetails.Garage.ExitPlayerHeading = 221.1647f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-7.4587f, 6559.0771f, 30.9709f);
                    propertyDetails.Garage.CarExitHeading[0] = 224.9500f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-3.6101f, 6555.2183f, 30.9340f);
                    propertyDetails.Garage.CarExitHeading[1] = 225.1458f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(2.3391f, 6549.3008f, 30.3709f);
                    propertyDetails.Garage.CarExitHeading[2] = 225.4122f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(0.4904f, 6539.5239f, 30.3861f);
                    propertyDetails.Garage.CarExitHeading[3] = 135.0325f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(18.4567f, 6550.5386f, 30.3861f);
                    propertyDetails.Garage.CarExitHeading[4] = 314.7267f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    propertyDetails.PurchaseLocation = new(1900.4055f, 3772.1484f, 31.8860f);
                    propertyDetails.BlipLocation[0] = new(1898.9148f, 3781.8203f, 31.8819f);
                    propertyDetails.BlipLocation[1] = new(1883.8983f, 3774.3259f, 31.7873f);
                    propertyDetails.CamData.Pos = new(1925.6063f, 3757.1411f, 34.3505f);
                    propertyDetails.CamData.Rot = new(0.5929f, -0.0000f, 63.7656f);
                    propertyDetails.CamData.FOV = 21.8329f;
                    propertyDetails.HouseHeistExitLocation = new(1901.7582f, 3770.1428f, 31.7519f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(1898.432739f, 3781.732422f, 31.735981f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(1899.448364f, 3782.283203f, 35.303207f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 123.4840f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(1898.9148f, 3781.8203f, 31.8819f);
                    propertyDetails.Entrance[0].BuzzerProp = new(1899.1300f, 3780.5200f, 33.3100f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 119.1000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(1901.7582f, 3770.1428f, 31.7519f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 210.6425f;
                    propertyDetails.cctv[0].Pos = new(1893.7781f, 3770.2517f, 35.0531f);
                    propertyDetails.cctv[0].Rot = new(-20.2686f, -0.0000f, -84.6772f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(1880.156250f, 3772.427490f, 34.535461f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(1886.477539f, 3776.082520f, 31.583681f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 39.8771f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(1883.8983f, 3774.3259f, 31.7873f);
                    propertyDetails.Entrance[1].BuzzerProp = new(1880.0100f, 3772.3501f, 33.2800f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 31.6000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(1893.4165f, 3770.2671f, 35.0829f);
                    propertyDetails.cctv[1].Rot = new(-17.6513f, 0.0000f, 69.9366f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(1885.5829f, 3772.4214f, 31.8156f);
                    propertyDetails.Garage.ExitPlayerHeading = 203.6179f;
                    propertyDetails.Garage.CarExitLoc[0] = new(1884.5725f, 3767.7659f, 31.8607f);
                    propertyDetails.Garage.CarExitHeading[0] = 208.1913f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(1891.3075f, 3759.0137f, 31.6070f);
                    propertyDetails.Garage.CarExitHeading[1] = 210.2192f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(1887.6563f, 3768.9651f, 31.7966f);
                    propertyDetails.Garage.CarExitHeading[2] = 200.6109f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(1886.5502f, 3748.0466f, 31.6557f);
                    propertyDetails.Garage.CarExitHeading[3] = 121.3845f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(1905.5642f, 3753.2893f, 31.4482f);
                    propertyDetails.Garage.CarExitHeading[4] = 299.7900f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    propertyDetails.PurchaseLocation = new(1663.0311f, 4776.3042f, 41.0075f);
                    propertyDetails.BlipLocation[0] = new(1663.0311f, 4776.3042f, 41.0075f);
                    propertyDetails.BlipLocation[1] = new(1661.8176f, 4768.2480f, 41.0075f);
                    propertyDetails.CamData.Pos = new(1696.0996f, 4776.8491f, 43.6956f);
                    propertyDetails.CamData.Rot = new(6.4054f, -0.0000f, 94.3951f);
                    propertyDetails.CamData.FOV = 28.4081f;
                    propertyDetails.HouseHeistExitLocation = new(1664.5260f, 4776.4639f, 40.9783f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(1661.922119f, 4775.278320f, 44.094707f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(1661.730957f, 4776.941406f, 40.896439f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.500000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 101.1850f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(1663.0311f, 4776.3042f, 41.0075f);
                    propertyDetails.Entrance[0].BuzzerProp = new(1662.0000f, 4774.6699f, 42.4700f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0f, 0.0f, 97.4000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(1664.5260f, 4776.4639f, 40.9783f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 270.1331f;
                    propertyDetails.cctv[0].Pos = new(1662.7144f, 4770.4775f, 44.8333f);
                    propertyDetails.cctv[0].Rot = new(-26.9123f, -0.0000f, -12.3788f);
                    propertyDetails.cctv[0].FOV = 50.0000f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(1656.875244f, 4767.401367f, 40.507427f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(1664.101318f, 4768.458008f, 44.290939f);
                    propertyDetails.Entrance[1].locateDetails.Width = 4.250000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 98.8964f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(1661.8176f, 4768.2480f, 41.0075f);
                    propertyDetails.Entrance[1].BuzzerProp = new(1657.8900f, 4765.6001f, 42.4500f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0f, 0.0f, 7.6000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(1663.7917f, 4770.2515f, 43.9323f);
                    propertyDetails.cctv[1].Rot = new(-21.1548f, 0.0000f, 134.3140f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.Garage.ExitPlayerPos = new(1661.5612f, 4768.1411f, 41.0075f);
                    propertyDetails.Garage.ExitPlayerHeading = 281.5633f;
                    propertyDetails.Garage.CarExitLoc[0] = new(1667.2184f, 4768.9038f, 40.9318f);
                    propertyDetails.Garage.CarExitHeading[0] = 278.8245f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(1675.2478f, 4762.7920f, 40.9741f);
                    propertyDetails.Garage.CarExitHeading[1] = 196.0204f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(1678.1053f, 4753.6108f, 40.9893f);
                    propertyDetails.Garage.CarExitHeading[2] = 198.7690f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(1679.1998f, 4778.5845f, 40.9837f);
                    propertyDetails.Garage.CarExitHeading[3] = 1.7503f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(1678.7386f, 4790.4360f, 40.9947f);
                    propertyDetails.Garage.CarExitHeading[4] = 3.3935f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_2;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.PurchaseLocation = new(-194.9809f, 501.7973f, 132.4774f);
                    propertyDetails.BlipLocation[0] = new(-177.2919f, 504.2896f, 135.8602f);
                    propertyDetails.BlipLocation[1] = new(-191.7057f, 500.0735f, 133.4895f);
                    propertyDetails.CamData.Pos = new(-197.7389f, 510.5206f, 136.3903f);
                    propertyDetails.CamData.Rot = new(4.4541f, -0.0000f, -130.5121f);
                    propertyDetails.CamData.FOV = 50.4296f;
                    propertyDetails.cctv[0].Pos = new(-177.0029f, 501.2041f, 138.6498f);
                    propertyDetails.cctv[0].Rot = new(-23.7879f, -0.0000f, -52.9233f);
                    propertyDetails.cctv[0].FOV = 61.2835f;
                    propertyDetails.cctv[1].Pos = new(-184.3932f, 503.7115f, 136.3540f);
                    propertyDetails.cctv[1].Rot = new(-19.4473f, -0.0000f, 134.8015f);
                    propertyDetails.cctv[1].FOV = 50.3357f;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-174.796982f, 503.203461f, 136.653610f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-174.487625f, 501.887115f, 138.653610f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-176.7676f, 503.9538f, 135.8529f);
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 282.6224f;
                    propertyDetails.Entrance[0].BuzzerProp = new(-173.9970f, 501.8261f, 137.7961f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, -78.8000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-176.7676f, 503.9538f, 135.8529f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 29.1450f;
                    propertyDetails.HouseHeistExitLocation = new(-176.7676f, 503.9538f, 135.8529f);
                    propertyDetails.Garage.ExitPlayerPos = new(-188.9353f, 502.4905f, 133.4325f);
                    propertyDetails.Garage.ExitPlayerHeading = 34.1741f;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-173.976f, 501.860f, 136.464f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, -0.000f, -110.000f);
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-188.8384f, 499.6424f, 133.7361f);
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-185.527618f, 501.637207f, 133.877914f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-192.118073f, 500.236206f, 136.093857f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.81f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 193.6283f;
                    propertyDetails.Entrance[1].BuzzerProp = new(-192.375f, 498.750f, 134.886f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.000f, 0.000f, 189.5f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-187.3407f, 503.5363f, 133.6252f);
                    propertyDetails.Garage.CarExitHeading[0] = 17.8818f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-190.5919f, 503.5130f, 133.1963f);
                    propertyDetails.Garage.CarExitHeading[1] = 19.9412f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-197.0257f, 502.7821f, 132.2657f);
                    propertyDetails.Garage.CarExitHeading[2] = 104.2812f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-172.2021f, 509.0025f, 136.0632f);
                    propertyDetails.Garage.CarExitHeading[3] = 136.7116f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-206.8378f, 500.7487f, 130.7149f);
                    propertyDetails.Garage.CarExitHeading[4] = 100.8708f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(346.964722f, 440.796417f, 146.707184f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(345.879639f, 440.297150f, 149.990845f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 112.2264f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(346.6832f, 440.3893f, 146.7075f);
                    propertyDetails.Entrance[0].BuzzerProp = new(345.2750f, 442.0000f, 148.053f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, 116.8000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(345.261f, 441.950f, 146.750f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, 0.000f, 77.000f);
                    propertyDetails.PurchaseLocation = new(348.2750f, 446.7000f, 145.0000f);
                    propertyDetails.BlipLocation[0] = new(347.2768f, 442.0909f, 146.7065f);
                    propertyDetails.BlipLocation[1] = new(353.3849f, 435.0725f, 146.1240f);
                    propertyDetails.CamData.Pos = new(349.7426f, 463.4214f, 150.5502f);
                    propertyDetails.CamData.Rot = new(-2.7041f, 0.0000f, 161.0581f);
                    propertyDetails.CamData.FOV = 35.5099f;
                    propertyDetails.cctv[0].Pos = new(347.4289f, 439.4345f, 149.7005f);
                    propertyDetails.cctv[0].Rot = new(-32.3614f, -0.0000f, 3.6285f);
                    propertyDetails.cctv[0].FOV = 91.4098f;
                    propertyDetails.cctv[1].Pos = new(349.4540f, 439.5841f, 150.1733f);
                    propertyDetails.cctv[1].Rot = new(-48.7754f, -0.0000f, -127.4111f);
                    propertyDetails.cctv[1].FOV = 92.1135f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(350.0362f, 443.1544f, 146.9524f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 306.6064f;
                    propertyDetails.HouseHeistExitLocation = new(350.0362f, 443.1544f, 146.9524f);
                    propertyDetails.Garage.ExitPlayerPos = new(353.7372f, 437.4555f, 145.6733f);
                    propertyDetails.Garage.ExitPlayerHeading = 301.9638f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(352.630646f, 432.435059f, 146.145996f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(349.058289f, 439.559692f, 150.027496f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.500000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 114.2784f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(352.1213f, 436.8011f, 146.2290f);
                    propertyDetails.Entrance[1].BuzzerProp = new(352.4493f, 432.7883f, 147.83f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 115.7750f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(356.4036f, 436.1895f, 145.1594f);
                    propertyDetails.Garage.CarExitHeading[0] = 295.2705f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(354.2893f, 440.1214f, 145.0805f);
                    propertyDetails.Garage.CarExitHeading[1] = 300.6924f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(349.0107f, 448.4448f, 145.3680f);
                    propertyDetails.Garage.CarExitHeading[2] = 228.5837f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(363.8029f, 438.9819f, 143.8032f);
                    propertyDetails.Garage.CarExitHeading[3] = 251.7819f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(364.4465f, 447.8789f, 144.3506f);
                    propertyDetails.Garage.CarExitHeading[4] = 66.8917f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-754.082092f, 621.350220f, 140.775330f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-753.386841f, 619.296875f, 144.673660f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.562500f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 110.3481f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-754.082092f, 621.350220f, 140.775330f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-753.909f, 621.845f, 142.832f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, 108.9000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-753.860f, 621.628f, 142.025f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, 0.000f, 77.000f);
                    propertyDetails.PurchaseLocation = new(-749.1125f, 616.1250f, 140.9000f);
                    propertyDetails.BlipLocation[0] = new(-753.4206f, 620.2255f, 141.8517f);
                    propertyDetails.BlipLocation[1] = new(-756.5550f, 628.7863f, 141.8053f);
                    propertyDetails.CamData.Pos = new(-736.2330f, 620.3261f, 147.0935f);
                    propertyDetails.CamData.Rot = new(-11.7133f, -0.0000f, 89.1236f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.cctv[0].Pos = new(-753.6261f, 621.4352f, 145.5712f);
                    propertyDetails.cctv[0].Rot = new(-61.2992f, -0.0000f, -144.1396f);
                    propertyDetails.cctv[0].FOV = 60.5044f;
                    propertyDetails.cctv[1].Pos = new(-753.8900f, 622.1678f, 145.1428f);
                    propertyDetails.cctv[1].Rot = new(-28.3326f, -0.0000f, 2.8184f);
                    propertyDetails.cctv[1].FOV = 50.7379f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-751.3826f, 621.3622f, 141.2540f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 286.1973f;
                    propertyDetails.HouseHeistExitLocation = new(-751.3826f, 621.3622f, 141.2540f);
                    propertyDetails.Garage.ExitPlayerPos = new(-753.0756f, 627.3389f, 141.5332f);
                    propertyDetails.Garage.ExitPlayerHeading = 142.5343f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-754.109558f, 622.506775f, 140.298920f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-757.110596f, 631.373291f, 145.005157f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.187500f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 110.3481f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-754.109558f, 622.506775f, 140.298920f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-757.2359f, 631.6739f, 143.0083f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 108.9300f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-752.8541f, 626.0184f, 141.5241f);
                    propertyDetails.Garage.CarExitHeading[0] = 337.0182f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-754.2813f, 631.2744f, 141.5919f);
                    propertyDetails.Garage.CarExitHeading[1] = 327.5519f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-747.2169f, 615.7965f, 141.1734f);
                    propertyDetails.Garage.CarExitHeading[2] = 15.4398f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-752.8635f, 640.1825f, 141.6789f);
                    propertyDetails.Garage.CarExitHeading[3] = 10.0842f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-753.9585f, 646.4396f, 141.8233f);
                    propertyDetails.Garage.CarExitHeading[4] = 9.8840f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-685.153198f, 596.213562f, 142.683563f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-686.126648f, 595.388000f, 145.511200f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.562500f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 222.3235f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-686.7532f, 596.7286f, 142.6471f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-687.195f, 594.773f, 143.990f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, -139.2000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-687.152f, 594.762f, 142.710f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, -0.000f, -180.000f);
                    propertyDetails.PurchaseLocation = new(-692.5033f, 596.4478f, 141.5300f);
                    propertyDetails.BlipLocation[0] = new(-685.5753f, 595.7667f, 143.0528f);
                    propertyDetails.BlipLocation[1] = new(-682.1959f, 601.0403f, 142.7455f);
                    propertyDetails.CamData.Pos = new(-717.0034f, 600.6978f, 147.8930f);
                    propertyDetails.CamData.Rot = new(-4.9085f, -0.0000f, -98.5860f);
                    propertyDetails.CamData.FOV = 32f;
                    propertyDetails.cctv[0].Pos = new(-685.3674f, 597.9558f, 147.0950f);
                    propertyDetails.cctv[0].Rot = new(-57.9486f, -0.0000f, 123.0923f);
                    propertyDetails.cctv[0].FOV = 49.2029f;
                    propertyDetails.cctv[1].Pos = new(-679.6271f, 609.7404f, 146.4369f);
                    propertyDetails.cctv[1].Rot = new(-19.6156f, -0.0000f, 148.6934f);
                    propertyDetails.cctv[1].FOV = 41.7163f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-687.2443f, 597.7927f, 142.6471f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 39.4563f;
                    propertyDetails.HouseHeistExitLocation = new(-687.2443f, 597.7927f, 142.6471f);
                    propertyDetails.Garage.ExitPlayerPos = new(-682.7540f, 601.2996f, 141.8721f);
                    propertyDetails.Garage.ExitPlayerHeading = 39.7500f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-685.332764f, 599.232544f, 142.694519f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-679.980286f, 603.750732f, 146.012543f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.625f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 204.6117f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-682.4546f, 601.7089f, 142.6945f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-679.7475f, 604.0975f, 144.0625f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, -139.2000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-682.9122f, 605.3720f, 142.8277f);
                    propertyDetails.Garage.CarExitHeading[0] = 348.6960f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-694.9319f, 597.1962f, 141.8161f);
                    propertyDetails.Garage.CarExitHeading[1] = 308.7104f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-679.9867f, 615.1488f, 143.8798f);
                    propertyDetails.Garage.CarExitHeading[2] = 338.6013f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-677.8329f, 622.5870f, 144.7422f);
                    propertyDetails.Garage.CarExitHeading[3] = 347.6829f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-676.5367f, 633.3019f, 146.0182f);
                    propertyDetails.Garage.CarExitHeading[4] = 355.3295f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    propertyDetails.PurchaseLocation = new(122.4f, 568.4f, 183.1f);
                    propertyDetails.BlipLocation[0] = new(118.1757f, 563.7846f, 182.9644f);
                    propertyDetails.BlipLocation[1] = new(128.9398f, 566.3500f, 182.9644f);
                    propertyDetails.HouseHeistExitLocation = new(118.3690f, 569.6913f, 183.3575f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(120.2f, 573.1f, 184.1f);
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(120.227692f, 564.239990f, 182.964401f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(118.600868f, 564.124084f, 185.546616f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 182.9470f;
                    propertyDetails.CamData.Pos = new(112.0956f, 573.5894f, 189.6378f);
                    propertyDetails.CamData.Rot = new(-20.3798f, 0.0000f, -141.0139f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.Entrance[0].BuzzerProp = new(118.3342f, 563.5432f, 184.299f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, -173.8800f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(118.3690f, 569.6913f, 183.3575f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 4.6f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(133.2049f, 565.3521f, 182.9341f);
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(134.199646f, 566.065125f, 182.870514f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(129.528793f, 565.535828f, 185.121063f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 180.7678f;
                    propertyDetails.Entrance[1].BuzzerProp = new(129.1583f, 565.8832f, 184.3003f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 180.0f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.ExitPlayerPos = new(131.9220f, 567.1509f, 182.6452f);
                    propertyDetails.Garage.ExitPlayerHeading = 15.8382f;
                    propertyDetails.Garage.CarExitLoc[0] = new(131.6537f, 568.9899f, 182.3411f);
                    propertyDetails.Garage.CarExitHeading[0] = 4.0689f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(133.8850f, 577.6986f, 182.5053f);
                    propertyDetails.Garage.CarExitHeading[1] = 92.9431f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(128.1558f, 577.4041f, 182.2566f);
                    propertyDetails.Garage.CarExitHeading[2] = 93.0176f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(121.7724f, 577.1444f, 182.1052f);
                    propertyDetails.Garage.CarExitHeading[3] = 97.5507f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(130.4890f, 581.2024f, 182.6389f);
                    propertyDetails.Garage.CarExitHeading[4] = 113.4962f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-559.078125f, 663.323181f, 144.539658f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-560.320190f, 663.638245f, 146.825974f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.437500f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 156.1758f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-559.4445f, 663.9685f, 144.4570f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-558.77f, 663.24f, 145.67f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, 160.3586f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-687.152f, 594.762f, 142.710f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, -0.000f, -180.000f);
                    propertyDetails.PurchaseLocation = new(-558.1771f, 669.1576f, 143.5971f);
                    propertyDetails.BlipLocation[0] = new(-559.6165f, 663.6034f, 144.5187f);
                    propertyDetails.BlipLocation[1] = new(-556.4049f, 662.4710f, 144.6138f);
                    propertyDetails.CamData.Pos = new(-543.6597f, 674.5140f, 147.0296f);
                    propertyDetails.CamData.Rot = new(-2.4999f, -0.0000f, 129.3025f);
                    propertyDetails.CamData.FOV = 33f;
                    propertyDetails.cctv[0].Pos = new(-558.7669f, 663.3293f, 147.2130f);
                    propertyDetails.cctv[0].Rot = new(-58.1066f, -0.0000f, 31.9443f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.cctv[1].Pos = new(-553.6230f, 662.0633f, 147.1800f);
                    propertyDetails.cctv[1].Rot = new(-54.5653f, -0.0000f, 43.0157f);
                    propertyDetails.cctv[1].FOV = 61.4621f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-558.2228f, 664.6216f, 144.4907f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 310.6559f;
                    propertyDetails.HouseHeistExitLocation = new(-558.2228f, 664.6216f, 144.4907f);
                    propertyDetails.Garage.ExitPlayerPos = new(-555.3579f, 664.1602f, 144.2354f);
                    propertyDetails.Garage.ExitPlayerHeading = 343.7260f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-553.830688f, 661.794617f, 144.239822f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-558.375122f, 662.931396f, 146.921051f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.625000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 167.8321f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-555.9142f, 662.6932f, 144.4900f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-553.19f, 663.55f, 145.497f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 249.4970f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-554.8588f, 666.1501f, 143.8092f);
                    propertyDetails.Garage.CarExitHeading[0] = 342.3456f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-560.1591f, 671.6970f, 144.2621f);
                    propertyDetails.Garage.CarExitHeading[1] = 253.1444f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-567.9676f, 673.9246f, 145.0193f);
                    propertyDetails.Garage.CarExitHeading[2] = 256.4467f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-577.1042f, 675.9783f, 145.7941f);
                    propertyDetails.Garage.CarExitHeading[3] = 257.1249f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-546.3216f, 666.6395f, 142.6902f);
                    propertyDetails.Garage.CarExitHeading[4] = 247.2661f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-732.653137f, 593.139709f, 141.061874f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-733.853271f, 593.803711f, 144.015060f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.75f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 147.7891f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-733.2375f, 593.7828f, 141.4827f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-734.1544f, 593.8073f, 142.5726f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, 151.0000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-733.287f, 593.431f, 141.456f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, 0.000f, -29.250f);
                    propertyDetails.PurchaseLocation = new(-731.0388f, 593.4600f, 140.6234f);
                    propertyDetails.BlipLocation[0] = new(-733.4767f, 593.2111f, 141.5178f);
                    propertyDetails.BlipLocation[1] = new(-744.3030f, 599.5864f, 141.5458f);
                    propertyDetails.CamData.Pos = new(-728.4564f, 610.9077f, 148.0444f);
                    propertyDetails.CamData.Rot = new(-11.9555f, 0.0000f, 138.3181f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.cctv[0].Pos = new(-731.7910f, 592.6054f, 144.7493f);
                    propertyDetails.cctv[0].Rot = new(-44.7805f, -0.0000f, 41.0826f);
                    propertyDetails.cctv[0].FOV = 50.0f;
                    propertyDetails.cctv[1].Pos = new(-746.4487f, 604.9315f, 143.8863f);
                    propertyDetails.cctv[1].Rot = new(-13.5851f, -0.0000f, -153.1004f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-732.5507f, 594.9288f, 141.0640f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 332.0094f;
                    propertyDetails.HouseHeistExitLocation = new(-732.5507f, 594.9288f, 141.0640f);
                    propertyDetails.Garage.ExitPlayerPos = new(-746.3018f, 601.5711f, 141.0995f);
                    propertyDetails.Garage.ExitPlayerHeading = 327.7594f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-741.255066f, 597.921692f, 141.092407f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-747.456787f, 601.402710f, 144.525101f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 142.3104f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-744.2535f, 600.0396f, 141.5243f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-747.4618f, 602.1413f, 142.8174f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 151.0000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-740.8754f, 602.3074f, 140.9152f);
                    propertyDetails.Garage.CarExitHeading[0] = 278.0610f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-744.7444f, 610.6098f, 141.1045f);
                    propertyDetails.Garage.CarExitHeading[1] = 207.2077f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-733.4897f, 597.4697f, 140.8929f);
                    propertyDetails.Garage.CarExitHeading[2] = 235.7999f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-725.7398f, 594.1789f, 140.8683f);
                    propertyDetails.Garage.CarExitHeading[3] = 252.9259f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-715.8591f, 592.7691f, 140.9360f);
                    propertyDetails.Garage.CarExitHeading[4] = 269.4550f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-852.307068f, 694.887573f, 147.865967f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-853.631775f, 694.784912f, 150.550323f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.06f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 181.5430f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-853.0189f, 695.2390f, 147.7879f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-853.8400f, 694.6200f, 149.1100f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, -176.0000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.BuzzerEnter.SyncedSceneLoc = new(-853.810f, 694.600f, 147.800f);
                    propertyDetails.House.BuzzerEnter.SyncedSceneRot = new(0.000f, -0.000f, 156.000f);
                    propertyDetails.PurchaseLocation = new(-849.8375f, 702.6500f, 147.3250f);
                    propertyDetails.BlipLocation[0] = new(-852.9005f, 694.7808f, 148.0741f);
                    propertyDetails.BlipLocation[1] = new(-865.7102f, 695.9731f, 148.1733f);
                    propertyDetails.CamData.Pos = new(-863.8798f, 714.2239f, 152.3501f);
                    propertyDetails.CamData.Rot = new(-6.6228f, -0.0000f, -167.1610f);
                    propertyDetails.CamData.FOV = 50.0f;
                    propertyDetails.cctv[0].Pos = new(-851.5412f, 695.0746f, 151.4110f);
                    propertyDetails.cctv[0].Rot = new(-49.9033f, 0.0000f, 77.4696f);
                    propertyDetails.cctv[0].FOV = 46.8069f;
                    propertyDetails.cctv[1].Pos = new(-869.0064f, 698.2000f, 151.6408f);
                    propertyDetails.cctv[1].Rot = new(-42.0295f, -0.0000f, -83.6115f);
                    propertyDetails.cctv[1].FOV = 50.0f;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-853.3578f, 697.1407f, 147.8176f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 4.3200f;
                    propertyDetails.HouseHeistExitLocation = new(-853.3578f, 697.1407f, 147.8176f);
                    propertyDetails.Garage.ExitPlayerPos = new(-863.2893f, 695.5299f, 148.0291f);
                    propertyDetails.Garage.ExitPlayerHeading = 336.7931f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-862.279602f, 694.627258f, 148.022903f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-868.915894f, 697.309692f, 151.360825f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.43f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 155.3475f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-865.5343f, 696.2910f, 147.9989f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-861.7898f, 695.1250f, 149.3596f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 157.6050f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.CarExitLoc[0] = new(-863.5904f, 699.6087f, 148.0632f);
                    propertyDetails.Garage.CarExitHeading[0] = 326.1612f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-856.5907f, 699.4403f, 147.8406f);
                    propertyDetails.Garage.CarExitHeading[1] = 350.5732f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-849.4887f, 705.9847f, 147.6541f);
                    propertyDetails.Garage.CarExitHeading[2] = 287.6365f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-841.0287f, 708.6886f, 147.3639f);
                    propertyDetails.Garage.CarExitHeading[3] = 252.9259f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-871.8189f, 699.3496f, 148.4745f);
                    propertyDetails.Garage.CarExitHeading[4] = 326.4510f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    propertyDetails.PurchaseLocation = new(-1302.4485f, 455.2224f, 96.7710f);
                    propertyDetails.BlipLocation[0] = new(-1294.2745f, 454.0578f, 96.7013f);
                    propertyDetails.BlipLocation[1] = new(-1297.9100f, 453.6508f, 96.7213f);
                    propertyDetails.CamData.Pos = new(-1306.6085f, 466.3748f, 101.9808f);
                    propertyDetails.CamData.Rot = new(-14.3811f, 0.0000f, -141.5052f);
                    propertyDetails.CamData.FOV = 47.8726f;
                    propertyDetails.HouseHeistExitLocation = new(-1295.0082f, 456.3158f, 96.1681f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1294.373169f, 454.630798f, 96.274605f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1294.326294f, 453.504028f, 99.189705f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.75000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 179.7048f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1294.3888f, 454.4630f, 96.5513f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1295.1180f, 454.0250f, 97.915f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, 180.0000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1294.3090f, 455.4050f, 96.3444f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 0.7367f;
                    propertyDetails.cctv[0].Pos = new(-1292.5781f, 454.2545f, 99.3409f);
                    propertyDetails.cctv[0].Rot = new(-39.6077f, -0.0000f, 69.4682f);
                    propertyDetails.cctv[0].FOV = 46.1469f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1298.060181f, 455.011139f, 96.280434f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1298.077637f, 451.717010f, 99.546967f);
                    propertyDetails.Entrance[1].locateDetails.Width = 5.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 176.5304f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1297.9030f, 454.2289f, 96.6315f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1300.5630f, 454.0388f, 98.0586f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(-0.4682f, -0.0000f, 180.0000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.cctv[1].Pos = new(-1300.9814f, 454.1239f, 99.3252f);
                    propertyDetails.cctv[1].Rot = new(-31.7665f, -0.0000f, -72.5331f);
                    propertyDetails.cctv[1].FOV = 42.2252f;
                    propertyDetails.Garage.ExitPlayerPos = new(-1298.4021f, 455.4963f, 96.4856f);
                    propertyDetails.Garage.ExitPlayerHeading = 356.4123f;
                    propertyDetails.Garage.CarExitLoc[0] = new(-1295.8458f, 457.1532f, 96.2299f);
                    propertyDetails.Garage.CarExitHeading[0] = 297.2790f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1283.4493f, 459.2665f, 95.2123f);
                    propertyDetails.Garage.CarExitHeading[1] = 277.3313f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1307.9097f, 457.9644f, 97.3667f);
                    propertyDetails.Garage.CarExitHeading[2] = 270.7701f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1282.9124f, 466.1473f, 95.0291f);
                    propertyDetails.Garage.CarExitHeading[3] = 95.758f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1298.7336f, 464.2884f, 96.4425f);
                    propertyDetails.Garage.CarExitHeading[4] = 92.1621f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    propertyDetails.PurchaseLocation = new(368.8f, 432.8f, 144.6f);
                    propertyDetails.BlipLocation[0] = new(373.8f, 428.4f, 145.7f);
                    propertyDetails.BlipLocation[1] = new(391.3558f, 427.1763f, 143.2039f);
                    propertyDetails.CamData.Pos = new(366.2502f, 450.5897f, 151.1863f);
                    propertyDetails.CamData.Rot = new(-14.3367f, -1.2993f, -158.6361f);
                    propertyDetails.CamData.FOV = 40.2194f;
                    propertyDetails.HouseHeistExitLocation = new(372.4530f, 431.8328f, 143.7681f);
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(374.615234f, 428.334351f, 146.906754f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(374.339966f, 427.175140f, 144.896027f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 263.0232f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(373.4f, 430.6f, 145.1f);
                    propertyDetails.Entrance[0].BuzzerProp = new(372.6857f, 426.9829f, 146.0747f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, 170.0000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(372.4530f, 431.8328f, 143.7681f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 340.1881f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(394.899841f, 427.130371f, 146.292908f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(387.697205f, 427.809326f, 143.249573f);
                    propertyDetails.Entrance[1].locateDetails.Width = 3.5f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 172.5183f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(391.1181f, 427.7463f, 143.2038f);
                    propertyDetails.Entrance[1].BuzzerProp = new(387.2895f, 428.0783f, 144.3926f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 170.0000f);
                    propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[1].BuzzerProp, propertyDetails.Entrance[1].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[1].BuzzerType);
                    propertyDetails.Entrance[1].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[1].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.Garage.ExitPlayerPos = new(390.8834f, 429.9290f, 142.7315f);
                    propertyDetails.Garage.ExitPlayerHeading = 359.9581f;
                    propertyDetails.Garage.CarExitLoc[0] = new(394.5217f, 433.2644f, 142.0235f);
                    propertyDetails.Garage.CarExitHeading[0] = 325.5933f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(384.9257f, 434.2468f, 142.5070f);
                    propertyDetails.Garage.CarExitHeading[1] = 81.9996f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(373.5152f, 436.3026f, 143.1639f);
                    propertyDetails.Garage.CarExitHeading[2] = 77.5761f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(389.9466f, 441.0051f, 142.2565f);
                    propertyDetails.Garage.CarExitHeading[3] = 263.4446f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(399.8194f, 432.3830f, 141.7439f);
                    propertyDetails.Garage.CarExitHeading[4] = 264.9702f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.NumEntrances = 2;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
            }
        }
        internal static void GetBuildingExteriorDetailsFullPart3(ref PropertyData propertyDetails, BuildingsEnum iBuilding)
        {
            Position buzzerOffset = new();
            propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[1].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_GATECOM_02_FLIPPED;
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    propertyDetails.PurchaseLocation = new(-1581.5f, -558.3f, 35.0f);
                    propertyDetails.BlipLocation[0] = new(-1581.5f, -558.3f, 35.0f);
                    propertyDetails.BlipLocation[1] = new(-1560.7710f, -569.1514f, 113.7914f);
                    propertyDetails.CamData.Pos = new(-1566.3601f, -485.2462f, 40.5030f);
                    propertyDetails.CamData.Rot = new(23.8802f, 0.0288f, 173.8406f);
                    propertyDetails.CamData.FOV = 55.7454f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1580.198364f, -557.681763f, 33.952816f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1582.202148f, -559.187256f, 36.452858f);
                    propertyDetails.Entrance[0].locateDetails.Width = 1.000000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 216.2582f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1583.5200f, -558.4530f, 33.9535f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1582.046f, -559.602f, 35.2500f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0f, 0f, -142.20f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1584.0527f, -554.6662f, 33.9762f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 39.6483f;
                    propertyDetails.cctv[0].Pos = new(-1577.8252f, -557.2221f, 41.1317f);
                    propertyDetails.cctv[0].Rot = new(-44.1509f, 0.0000f, 89.9985f);
                    propertyDetails.cctv[0].FOV = 77.4526f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1559.691650f, -568.117737f, 113.449318f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1562.035645f, -569.738037f, 115.699318f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.000000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 209.3411f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1563.5151f, -568.7156f, 113.4493f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1561.8950f, -570.2933f, 114.859f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0f, 0f, -142.300f);
                    propertyDetails.Entrance[1].BuzzerLoc = new(-1562.3384f, -569.6094f, 114.4321f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-1561.9615f, -567.2552f, 113.4493f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 24.2550f;
                    propertyDetails.cctv[1].Pos = new(-1556.4696f, -566.1495f, 119.3585f);
                    propertyDetails.cctv[1].Rot = new(-31.7605f, -0.0000f, 104.6976f);
                    propertyDetails.cctv[1].FOV = 59.2455f;
                    propertyDetails.Garage.cctv.Pos = new(-1554.8196f, -561.2455f, 30.5729f);
                    propertyDetails.Garage.cctv.Rot = new(-52.3398f, 0.0000f, -28.4273f);
                    propertyDetails.Garage.cctv.FOV = 67.3726f;
                    propertyDetails.Entrance[2].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[2].locateDetails.Pos1 = new(-1545.798f, -557.460f, 24.360f);
                    propertyDetails.Entrance[2].locateDetails.Pos2 = new(-1553.650f, -562.815f, 28.910f);
                    propertyDetails.Entrance[2].locateDetails.Width = 6.450f;
                    propertyDetails.Entrance[2].locateDetails.EnterHeading = 217.4663f;
                    propertyDetails.Entrance[2].EntranceMarkerLoc = new(-1565.6465f, -537.8900f, 33.8479f);
                    propertyDetails.Garage.CarExitLoc[0] = new(-1566.8820f, -531.6985f, 34.5696f);
                    propertyDetails.Garage.CarExitHeading[0] = 35.4988f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1568.7050f, -529.1504f, 34.5097f);
                    propertyDetails.Garage.CarExitHeading[1] = 35.6329f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1550.6097f, -534.6669f, 34.0739f);
                    propertyDetails.Garage.CarExitHeading[2] = 37.4680f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1546.0995f, -540.9735f, 33.5649f);
                    propertyDetails.Garage.CarExitHeading[3] = 39.0033f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1540.0524f, -549.1758f, 32.9157f);
                    propertyDetails.Garage.CarExitHeading[4] = 38.6120f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Entrance[2].BuzzerProp = new(-1554.339f, -561.571f, 26.2058f);
                    propertyDetails.Entrance[2].BuzzerPropRot = new(0.0f, 0.0f, 125.125f);
                    propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[2].BuzzerProp, propertyDetails.Entrance[2].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[2].BuzzerType);
                    propertyDetails.Entrance[2].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[2].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[2].OutPlayerLoc = new(-1569.7242f, -531.7974f, 34.4859f);
                    propertyDetails.House.Exits[2].OutPlayerHeading = 47.1292f;
                    propertyDetails.BlipLocation[2] = new(-1565.6465f, -537.8900f, 33.8479f);
                    propertyDetails.NumEntrances = 3;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    propertyDetails.PurchaseLocation = new(-1363.7557f, -510.9757f, 30.2801f);
                    propertyDetails.BlipLocation[0] = new(-1370.3484f, -503.0963f, 32.1574f);
                    propertyDetails.BlipLocation[1] = new(-1369.7494f, -472.0480f, 83.7585f);
                    propertyDetails.CamData.Pos = new(-1382.8022f, -576.5264f, 33.7159f);
                    propertyDetails.CamData.Rot = new(14.0594f, 0.0160f, -6.0004f);
                    propertyDetails.CamData.FOV = 48.6496f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-1369.998169f, -502.798279f, 31.940834f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-1370.934448f, -503.472412f, 35.407406f);
                    propertyDetails.Entrance[0].locateDetails.Width = 3.250000f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 307.1366f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-1370.3484f, -503.0963f, 32.1574f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-1369.0811f, -504.8530f, 33.4758f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, -0.0000f, -54.9000f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-1371.6980f, -504.2646f, 32.1574f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 136.3790f;
                    propertyDetails.cctv[0].Pos = new(-1373.5930f, -499.2561f, 37.2086f);
                    propertyDetails.cctv[0].Rot = new(-29.2442f, -0.0000f, -174.7204f);
                    propertyDetails.cctv[0].FOV = 64.1320f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-1369.870850f, -472.244446f, 83.336838f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-1369.223999f, -471.785278f, 86.696938f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.750000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 124.2775f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-1369.5686f, -471.9889f, 83.4469f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-1370.1970f, -471.4860f, 84.8834f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 122.7400f);
                    propertyDetails.Entrance[1].BuzzerLoc = new(-1369.6176f, -471.1026f, 84.4431f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-1367.4072f, -471.2750f, 83.4469f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 192.5905f;
                    propertyDetails.cctv[1].Pos = new(-1364.5750f, -486.9128f, 89.3676f);
                    propertyDetails.cctv[1].Rot = new(-16.1979f, -0.0000f, 47.8232f);
                    propertyDetails.cctv[1].FOV = 71.8136f;
                    propertyDetails.Garage.cctv.Pos = new(-1416.9712f, -473.9347f, 37.9568f);
                    propertyDetails.Garage.cctv.Rot = new(-48.1546f, -0.0000f, -177.9143f);
                    propertyDetails.Garage.cctv.FOV = 57.6609f;
                    propertyDetails.Entrance[2].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[2].locateDetails.Pos1 = new(-1411.050f, -480.325f, 37.675f);
                    propertyDetails.Entrance[2].locateDetails.Pos2 = new(-1416.075f, -472.925f, 32.175f);
                    propertyDetails.Entrance[2].locateDetails.Width = 9.350f;
                    propertyDetails.Entrance[2].locateDetails.EnterHeading = 303.7230f;
                    propertyDetails.Entrance[2].EntranceMarkerLoc = new(-1415.3624f, -477.7129f, 32.5229f);
                    propertyDetails.Garage.CarExitLoc[0] = new(-1420.7272f, -479.2959f, 32.8519f);
                    propertyDetails.Garage.CarExitHeading[0] = 125.1182f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-1428.9260f, -473.8968f, 33.1141f);
                    propertyDetails.Garage.CarExitHeading[1] = 34.1439f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-1418.6899f, -489.0421f, 32.2947f);
                    propertyDetails.Garage.CarExitHeading[2] = 33.2319f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-1413.8832f, -496.0346f, 31.8743f);
                    propertyDetails.Garage.CarExitHeading[3] = 33.3650f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-1408.1458f, -504.3559f, 31.3764f);
                    propertyDetails.Garage.CarExitHeading[4] = 33.8830f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Entrance[2].BuzzerProp = new(-1413.486f, -481.671f, 33.8948f);
                    propertyDetails.Entrance[2].BuzzerPropRot = new(0.0f, 0.0f, -146.595f);
                    propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[2].BuzzerProp, propertyDetails.Entrance[2].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[2].BuzzerType);
                    propertyDetails.Entrance[2].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[2].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[2].OutPlayerLoc = new(-1418.9496f, -479.0730f, 32.8152f);
                    propertyDetails.House.Exits[2].OutPlayerHeading = 124.8494f;
                    propertyDetails.BlipLocation[2] = new(-1415.3624f, -477.7129f, 32.5229f);
                    propertyDetails.NumEntrances = 3;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    propertyDetails.PurchaseLocation = new(-92.6372f, -578.6620f, 35.3123f);
                    propertyDetails.BlipLocation[0] = new(-117.5296f, -605.7157f, 35.2857f);
                    propertyDetails.BlipLocation[1] = new(-134.3277f, -584.6831f, 200.8647f);
                    propertyDetails.CamData.Pos = new(-74.0762f, -701.7039f, 49.4868f);
                    propertyDetails.CamData.Rot = new(33.3480f, 0.0253f, 37.4705f);
                    propertyDetails.CamData.FOV = 55.3993f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-119.685837f, -609.642334f, 35.258965f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-115.888458f, -599.150391f, 38.391968f);
                    propertyDetails.Entrance[0].locateDetails.Width = 4.1875f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 64.6717f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-118.5747f, -610.1472f, 35.5043f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-119.7680f, -609.7531f, 36.6249f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(-0.0000f, -0.0000f, 70.1550f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-110.9626f, -605.3646f, 35.2857f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 255.3759f;
                    propertyDetails.cctv[0].Pos = new(-117.2984f, -588.0927f, 39.4723f);
                    propertyDetails.cctv[0].Rot = new(-13.4276f, -0.0000f, -137.6638f);
                    propertyDetails.cctv[0].FOV = 61.2735f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-133.541306f, -585.788086f, 200.680161f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-135.239731f, -583.780823f, 203.378555f);
                    propertyDetails.Entrance[1].locateDetails.Width = 2.687500f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 134.4353f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-134.9465f, -583.0051f, 201.1521f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-135.2997f, -583.7286f, 202.1938f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, -0.0000f, 140.4400f);
                    propertyDetails.Entrance[1].BuzzerLoc = new(-134.7125f, -583.3456f, 201.7620f);
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-131.9133f, -585.8597f, 200.7354f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 212.5333f;
                    propertyDetails.cctv[1].Pos = new(-165.6158f, -590.6523f, 216.2003f);
                    propertyDetails.cctv[1].Rot = new(-8.8826f, -0.0000f, -95.9212f);
                    propertyDetails.cctv[1].FOV = 56.7626f;
                    propertyDetails.Garage.cctv.Pos = new(-142.9038f, -581.8480f, 34.5346f);
                    propertyDetails.Garage.cctv.Rot = new(-22.8984f, 0.0000f, 133.7528f);
                    propertyDetails.Garage.cctv.FOV = 63.1373f;
                    propertyDetails.Entrance[2].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[2].locateDetails.Pos1 = new(-146.409f, -575.904f, 31.597f);
                    propertyDetails.Entrance[2].locateDetails.Pos2 = new(-141.982f, -577.559f, 34.597f);
                    propertyDetails.Entrance[2].locateDetails.Width = 12.875f;
                    propertyDetails.Entrance[2].locateDetails.EnterHeading = 328.7051f;
                    propertyDetails.Entrance[2].EntranceMarkerLoc = new(-125.7799f, -659.3828f, 34.3782f);
                    propertyDetails.Garage.CarExitLoc[0] = new(-148.9469f, -589.2340f, 31.4245f);
                    propertyDetails.Garage.CarExitHeading[0] = 159.9474f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-151.4621f, -596.1295f, 31.4245f);
                    propertyDetails.Garage.CarExitHeading[1] = 159.9607f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-154.2729f, -603.8367f, 31.4245f);
                    propertyDetails.Garage.CarExitHeading[2] = 159.9593f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-157.7088f, -655.0534f, 31.2126f);
                    propertyDetails.Garage.CarExitHeading[3] = 250.7447f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-139.9135f, -661.3720f, 32.6781f);
                    propertyDetails.Garage.CarExitHeading[4] = 249.0975f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Entrance[2].BuzzerProp = new(-142.810f, -581.477f, 32.7278f);
                    propertyDetails.Entrance[2].BuzzerPropRot = new(0.0f, 0.0f, -19.803f);
                    propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[2].BuzzerProp, propertyDetails.Entrance[2].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[2].BuzzerType);
                    propertyDetails.Entrance[2].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[2].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[2].OutPlayerLoc = new(-146.9829f, -585.0058f, 31.4245f);
                    propertyDetails.House.Exits[2].OutPlayerHeading = 158.7409f;
                    propertyDetails.BlipLocation[2] = new(-125.7799f, -659.3828f, 34.3782f);
                    propertyDetails.NumEntrances = 3;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    propertyDetails.PurchaseLocation = new(-56.6f, -783.3f, 44.1f);
                    propertyDetails.BlipLocation[0] = new(-81.3f, -797.5f, 44.2f);
                    propertyDetails.BlipLocation[1] = new(-67.8f, -821.6f, 320.4f);
                    propertyDetails.CamData.Pos = new(-50.6769f, -1013.9424f, 183.2113f);
                    propertyDetails.CamData.Rot = new(18.7747f, -0.0159f, 7.6518f);
                    propertyDetails.CamData.FOV = 44.5136f;
                    propertyDetails.Entrance[0].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[0].locateDetails.Pos1 = new(-82.050285f, -797.791687f, 43.227314f);
                    propertyDetails.Entrance[0].locateDetails.Pos2 = new(-78.213669f, -796.743164f, 45.727314f);
                    propertyDetails.Entrance[0].locateDetails.Width = 2.0f;
                    propertyDetails.Entrance[0].locateDetails.EnterHeading = 205.4841f;
                    propertyDetails.Entrance[0].EntranceMarkerLoc = new(-78.3f, -799.7f, 44.2f);
                    propertyDetails.Entrance[0].BuzzerProp = new(-82.5033f, -797.6400f, 44.5225f);
                    propertyDetails.Entrance[0].BuzzerPropRot = new(0.0000f, 0.0000f, 136.4400f);
                    propertyDetails.Entrance[0].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[0].BuzzerProp, propertyDetails.Entrance[0].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[0].BuzzerType);
                    propertyDetails.Entrance[0].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[0].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[0].OutPlayerLoc = new(-83.3513f, -794.3069f, 43.2273f);
                    propertyDetails.House.Exits[0].OutPlayerHeading = 19.2204f;
                    propertyDetails.cctv[0].Pos = new(-80.0721f, -805.2011f, 50.2228f);
                    propertyDetails.cctv[0].Rot = new(-23.2990f, -0.0000f, -23.5398f);
                    propertyDetails.cctv[0].FOV = 63.0745f;
                    propertyDetails.Entrance[1].Type = EntranceType.ENTRANCE_TYPE_HOUSE;
                    propertyDetails.Entrance[1].locateDetails.Pos1 = new(-68.306038f, -822.966431f, 320.297516f);
                    propertyDetails.Entrance[1].locateDetails.Pos2 = new(-67.012535f, -819.417664f, 322.789612f);
                    propertyDetails.Entrance[1].locateDetails.Width = 1.250000f;
                    propertyDetails.Entrance[1].locateDetails.EnterHeading = 75.5765f;
                    propertyDetails.Entrance[1].EntranceMarkerLoc = new(-67.7f, -821.6f, 321.3f);
                    propertyDetails.Entrance[1].BuzzerProp = new(-67.2490f, -819.9236f, 321.7416f);
                    propertyDetails.Entrance[1].BuzzerPropRot = new(0.0000f, 0.0000f, 79.8400f);
                    propertyDetails.Entrance[1].BuzzerLoc = new(-66.3545f, -819.9989f, 321.3130f);
                    propertyDetails.cctv[1].Pos = new(-66.9822f, -819.1842f, 323.0544f);
                    propertyDetails.cctv[1].Rot = new(-27.1470f, -0.0000f, -173.3470f);
                    propertyDetails.cctv[1].FOV = 57.4756f;
                    propertyDetails.House.Exits[1].OutPlayerLoc = new(-65.9803f, -818.9702f, 320.2896f);
                    propertyDetails.House.Exits[1].OutPlayerHeading = 356.4971f;
                    propertyDetails.Garage.cctv.Pos = new(-84.8048f, -784.2784f, 41.7591f);
                    propertyDetails.Garage.cctv.Rot = new(-28.6275f, -0.0000f, -17.8843f);
                    propertyDetails.Garage.cctv.FOV = 66.9887f;
                    propertyDetails.Entrance[2].Type = EntranceType.ENTRANCE_TYPE_GARAGE;
                    propertyDetails.Entrance[2].locateDetails.Pos1 = new(-83.950f, -790.000f, 35.987f);
                    propertyDetails.Entrance[2].locateDetails.Pos2 = new(-72.300f, -786.750f, 41.787f);
                    propertyDetails.Entrance[2].locateDetails.Width = 10.200f;
                    propertyDetails.Entrance[2].locateDetails.EnterHeading = 195.0365f;
                    propertyDetails.Entrance[2].EntranceMarkerLoc = new(-82.4907f, -772.7483f, 38.8316f);
                    propertyDetails.Garage.CarExitLoc[0] = new(-79.1206f, -774.7828f, 38.3078f);
                    propertyDetails.Garage.CarExitHeading[0] = 16.0370f;
                    propertyDetails.Garage.CarExitWeight[0] = 1.0f;
                    propertyDetails.Garage.CarExitLoc[1] = new(-82.4993f, -763.0030f, 40.8070f);
                    propertyDetails.Garage.CarExitHeading[1] = 19.1010f;
                    propertyDetails.Garage.CarExitWeight[1] = 0.9f;
                    propertyDetails.Garage.CarExitLoc[2] = new(-87.4891f, -747.4923f, 43.0785f);
                    propertyDetails.Garage.CarExitHeading[2] = 17.8727f;
                    propertyDetails.Garage.CarExitWeight[2] = 0.8f;
                    propertyDetails.Garage.CarExitLoc[3] = new(-76.5863f, -755.1157f, 43.1195f);
                    propertyDetails.Garage.CarExitHeading[3] = 208.6326f;
                    propertyDetails.Garage.CarExitWeight[3] = 0.7f;
                    propertyDetails.Garage.CarExitLoc[4] = new(-70.0160f, -765.9581f, 43.1511f);
                    propertyDetails.Garage.CarExitHeading[4] = 220.2367f;
                    propertyDetails.Garage.CarExitWeight[4] = 0.6f;
                    propertyDetails.Entrance[2].BuzzerProp = new(-84.454f, -786.462f, 38.6688f);
                    propertyDetails.Entrance[2].BuzzerPropRot = new(0.0f, 0.0f, 104.760f);
                    propertyDetails.Entrance[2].BuzzerType = (int)BuzzerType.BUZZER_TYPE_KEYPAD_01B;
                    GetBuzzerPlayerOffset(propertyDetails.Entrance[2].BuzzerProp, propertyDetails.Entrance[2].BuzzerPropRot, ref buzzerOffset, propertyDetails.Entrance[2].BuzzerType);
                    propertyDetails.Entrance[2].BuzzerLoc = buzzerOffset.ToVector3;
                    propertyDetails.Entrance[2].BuzzerHeading = buzzerOffset.Yaw;
                    propertyDetails.House.Exits[2].OutPlayerLoc = new(-81.5764f, -776.6653f, 38.1687f);
                    propertyDetails.House.Exits[2].OutPlayerHeading = 354.5269f;
                    propertyDetails.BlipLocation[2] = new(-82.4907f, -772.7483f, 38.8316f);
                    propertyDetails.NumEntrances = 3;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
            }
        }
        internal static void GetBuildingProperties(ref BuildingRelated building, BuildingsEnum iBuilding)
        {
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_1;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_2;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_HIGH_APT_3;
                    building.PropertiesInBuilding[3] = PropertiesEnum.PROPERTY_HIGH_APT_4;
                    building.PropertiesInBuilding[4] = PropertiesEnum.PROPERTY_BUS_HIGH_APT_1;
                    building.PropertiesInBuilding[5] = PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE;
                    building.PropertiesInBuilding[6] = PropertiesEnum.PROPERTY_CUSTOM_APT_2;
                    building.PropertiesInBuilding[7] = PropertiesEnum.PROPERTY_CUSTOM_APT_3;
                    building.NumProperties = 8;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_5;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_6;
                    building.NumProperties = 2;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_7;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_8;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_BUS_HIGH_APT_2;
                    building.NumProperties = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_9;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_10;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_HIGH_APT_11;
                    building.NumProperties = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_12;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_13;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_BUS_HIGH_APT_5;
                    building.NumProperties = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_14;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_15;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_BUS_HIGH_APT_3;
                    building.NumProperties = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_HIGH_APT_16;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_HIGH_APT_17;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_BUS_HIGH_APT_4;
                    building.NumProperties = 3;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_4;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_5;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_6;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_7;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_8;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_MEDIUM_APT_9;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_4;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_5;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_6;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_LOW_APT_7;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_24:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_25:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_26:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_27:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_4;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_28:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_5;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_29:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_6;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_30:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_7;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_31:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_8;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_32:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_33:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_34:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_35:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_36:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_38:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_5;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_39:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_6;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_40:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_7;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_41:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_8;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_42:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_9;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_47:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_14;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_49:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_16;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_50:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_17;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_51:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_18;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_52:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_19;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_53:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_20;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_54:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_21;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_55:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_22;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_56:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_GARAGE_NEW_23;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_57:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_58:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_59:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_60:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_61:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_LOW_1;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_62:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_LOW_2;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_63:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_IND_DAY_LOW_3;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_2_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_3_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_4_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_7_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_8_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_10_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_12_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_STILT_APT_13_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_OFFICE_1;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2;
                    building.PropertiesInBuilding[3] = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3;
                    building.NumProperties = 4;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_OFFICE_2_BASE;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2;
                    building.PropertiesInBuilding[3] = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3;
                    building.NumProperties = 4;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_OFFICE_3;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2;
                    building.PropertiesInBuilding[3] = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3;
                    building.NumProperties = 4;
                    break;
                case BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_OFFICE_4;
                    building.PropertiesInBuilding[1] = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1;
                    building.PropertiesInBuilding[2] = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2;
                    building.PropertiesInBuilding[3] = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3;
                    building.NumProperties = 4;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B;
                    building.NumProperties = 1;
                    break;
                case BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12:
                    building.PropertiesInBuilding[0] = PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B;
                    building.NumProperties = 1;
                    break;
            }
        }
        internal static void GetOffsetForPositionFromBaseOffset(Position BaseLoc, Position BaseOffset, Position NewLoc, ref Position FinalOffset)
        {
            FinalOffset = BaseOffset;
            Vector3 vOffset = (FinalOffset - BaseLoc).ToVector3;
            vOffset = RotateVectorAboutZ(vOffset, -BaseLoc.Yaw);
            vOffset = RotateVectorAboutZ(vOffset, NewLoc.Yaw);
            FinalOffset = new(GetObjectOffsetFromCoords(NewLoc.ToVector3.X, NewLoc.ToVector3.Y, NewLoc.ToVector3.Z, 0.0f, vOffset.X, vOffset.Y, vOffset.Z), FinalOffset.ToRotationVector);
            if (NewLoc.ToRotationVector != BaseLoc.ToRotationVector)
            {
                if (BaseLoc.Yaw > 180.0f)
                    BaseLoc.Yaw -= 360.0f;
                if (BaseLoc.Yaw < -180.0f)
                    BaseLoc.Yaw += 360.0f;
                if (NewLoc.Yaw > 180.0f)
                    NewLoc.Yaw -= 360.0f;
                if (NewLoc.Yaw < -180.0f)
                    NewLoc.Yaw += 360.0f;
                FinalOffset.Yaw += NewLoc.Yaw - BaseLoc.Yaw;
                if (FinalOffset.Yaw > 180.0f)
                    FinalOffset.Yaw -= 360.0f;
                if (FinalOffset.Yaw < -180.0f)
                    FinalOffset.Yaw += 360.0f;
            }
        }
        public static PropertySizeType GetPropertySizeType(PropertiesEnum iProperty)
        {
            return iProperty switch
            {
                PropertiesEnum.PROPERTY_YACHT_APT_1_BASE => PropertySizeType.PROP_SIZE_TYPE_YACHT,
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => PropertySizeType.PROP_SIZE_TYPE_OFFICE_GARAGE,
                PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_4 => PropertySizeType.PROP_SIZE_TYPE_OFFICE,
                PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A or PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B or PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => PropertySizeType.PROP_SIZE_TYPE_CLUBHOUSE,
                PropertiesEnum.PROPERTY_HIGH_APT_1 or PropertiesEnum.PROPERTY_HIGH_APT_2 or PropertiesEnum.PROPERTY_HIGH_APT_3 or PropertiesEnum.PROPERTY_HIGH_APT_4 or PropertiesEnum.PROPERTY_HIGH_APT_5 or PropertiesEnum.PROPERTY_HIGH_APT_6 or PropertiesEnum.PROPERTY_HIGH_APT_7 or PropertiesEnum.PROPERTY_HIGH_APT_8 or PropertiesEnum.PROPERTY_HIGH_APT_9 or PropertiesEnum.PROPERTY_HIGH_APT_10 or PropertiesEnum.PROPERTY_HIGH_APT_11 or PropertiesEnum.PROPERTY_HIGH_APT_12 or PropertiesEnum.PROPERTY_HIGH_APT_13 or PropertiesEnum.PROPERTY_HIGH_APT_14 or PropertiesEnum.PROPERTY_HIGH_APT_15 or PropertiesEnum.PROPERTY_HIGH_APT_16 or PropertiesEnum.PROPERTY_HIGH_APT_17 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_1 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_2 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_3 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_4 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_5 or PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B or PropertiesEnum.PROPERTY_STILT_APT_2_B or PropertiesEnum.PROPERTY_STILT_APT_3_B or PropertiesEnum.PROPERTY_STILT_APT_4_B or PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A or PropertiesEnum.PROPERTY_STILT_APT_7_A or PropertiesEnum.PROPERTY_STILT_APT_8_A or PropertiesEnum.PROPERTY_STILT_APT_10_A or PropertiesEnum.PROPERTY_STILT_APT_12_A or PropertiesEnum.PROPERTY_STILT_APT_13_A or PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE or PropertiesEnum.PROPERTY_CUSTOM_APT_2 or PropertiesEnum.PROPERTY_CUSTOM_APT_3 => PropertySizeType.PROP_SIZE_TYPE_LARGE_APT,
                PropertiesEnum.PROPERTY_MEDIUM_APT_1 or PropertiesEnum.PROPERTY_MEDIUM_APT_2 or PropertiesEnum.PROPERTY_MEDIUM_APT_3 or PropertiesEnum.PROPERTY_MEDIUM_APT_4 or PropertiesEnum.PROPERTY_MEDIUM_APT_5 or PropertiesEnum.PROPERTY_MEDIUM_APT_6 or PropertiesEnum.PROPERTY_MEDIUM_APT_7 or PropertiesEnum.PROPERTY_MEDIUM_APT_8 or PropertiesEnum.PROPERTY_MEDIUM_APT_9 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3 or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4 => PropertySizeType.PROP_SIZE_TYPE_MED_APT,
                PropertiesEnum.PROPERTY_LOW_APT_1 or PropertiesEnum.PROPERTY_LOW_APT_2 or PropertiesEnum.PROPERTY_LOW_APT_3 or PropertiesEnum.PROPERTY_LOW_APT_4 or PropertiesEnum.PROPERTY_LOW_APT_5 or PropertiesEnum.PROPERTY_LOW_APT_6 or PropertiesEnum.PROPERTY_LOW_APT_7 or PropertiesEnum.PROPERTY_IND_DAY_LOW_1 or PropertiesEnum.PROPERTY_IND_DAY_LOW_2 or PropertiesEnum.PROPERTY_IND_DAY_LOW_3 => PropertySizeType.PROP_SIZE_TYPE_SMALL_APT,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_1 or PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_3 or PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_4 or PropertiesEnum.PROPERTY_GARAGE_NEW_17 or PropertiesEnum.PROPERTY_GARAGE_NEW_19 or PropertiesEnum.PROPERTY_GARAGE_NEW_20 => PropertySizeType.PROP_SIZE_TYPE_10_GAR,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_2 or PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_5 or PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1 or PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2 or PropertiesEnum.PROPERTY_GARAGE_NEW_8 or PropertiesEnum.PROPERTY_GARAGE_NEW_14 or PropertiesEnum.PROPERTY_GARAGE_NEW_16 or PropertiesEnum.PROPERTY_GARAGE_NEW_18 => PropertySizeType.PROP_SIZE_TYPE_6_GAR,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_6 or PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_7 or PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_8 or PropertiesEnum.PROPERTY_GARAGE_NEW_1 or PropertiesEnum.PROPERTY_GARAGE_NEW_2 or PropertiesEnum.PROPERTY_GARAGE_NEW_3 or PropertiesEnum.PROPERTY_GARAGE_NEW_5 or PropertiesEnum.PROPERTY_GARAGE_NEW_6 or PropertiesEnum.PROPERTY_GARAGE_NEW_7 or PropertiesEnum.PROPERTY_GARAGE_NEW_9 or PropertiesEnum.PROPERTY_GARAGE_NEW_21 or PropertiesEnum.PROPERTY_GARAGE_NEW_22 or PropertiesEnum.PROPERTY_GARAGE_NEW_23 => PropertySizeType.PROP_SIZE_TYPE_2_GAR,
                PropertiesEnum.PROPERTY_MULTISTOREY_GARAGE => PropertySizeType.PROP_SIZE_TYPE_50_GAR,
                _ => 0,
            };
        }

        public static bool IsPropertyMissingOpeningDoors(PropertiesEnum iPropertyID)
        {
            return iPropertyID switch
            {
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1
                or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2
                or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3
                or PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4
                or PropertiesEnum.PROPERTY_IND_DAY_LOW_1
                or PropertiesEnum.PROPERTY_IND_DAY_LOW_2
                or PropertiesEnum.PROPERTY_IND_DAY_LOW_3 => true,
                _ => false,
            };
        }

        public static MPPropertyNonAxis GetBuildingExtEntranceArea(BuildingsEnum iBuilding, int iEntrance)
        {
            MPPropertyNonAxis entranceArea = new();
            switch (iBuilding)
            {
                case BuildingsEnum.MP_PROPERTY_BUILDING_1:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-786.130554f, 318.197113f, 84.169502f);
                        entranceArea.Pos2 = new(-766.984192f, 318.141052f, 89.419502f);
                        entranceArea.Width = 9.0f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-796.385925f, 313.829193f, 84.202469f);
                        entranceArea.Pos2 = new(-796.436096f, 337.334961f, 88.986679f);
                        entranceArea.Width = 19.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_2:
                    if (iEntrance == 0)
                    {

                        entranceArea.Pos1 = new(-262.001251f, -970.002808f, 30.220259f);
                        entranceArea.Pos2 = new(-269.685425f, -953.742249f, 33.473366f);
                        entranceArea.Width = 3.25f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-281.416504f, -991.950378f, 23.136797f);
                        entranceArea.Pos2 = new(-296.168701f, -986.645447f, 26.636797f);
                        entranceArea.Width = 14.50f;
                    }
                    break;

                case BuildingsEnum.MP_PROPERTY_BUILDING_3:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-1443.355957f, -544.244690f, 33.742229f);
                        entranceArea.Pos2 = new(-1448.188721f, -537.335571f, 36.740612f);
                        entranceArea.Width = 12.75f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-1445.260132f, -514.471680f, 30.602194f);
                        entranceArea.Pos2 = new(-1458.753784f, -523.784912f, 33.352196f);
                        entranceArea.Width = 29.25f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_4:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-915.175171f, -442.150421f, 38.610317f);
                        entranceArea.Pos2 = new(-906.608521f, -459.023376f, 45.860317f);
                        entranceArea.Width = 8.25f;
                    }
                    else if (iEntrance == 1)
                    {

                        entranceArea.Pos1 = new(-814.859924f, -438.802612f, 34.243286f);
                        entranceArea.Pos2 = new(-819.548401f, -429.749908f, 39.627193f);
                        entranceArea.Width = 8.25f;
                    }
                    break;

                case BuildingsEnum.MP_PROPERTY_BUILDING_5:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-43.568470f, -582.312134f, 37.167168f);
                        entranceArea.Pos2 = new(-46.803577f, -591.238342f, 41.916233f);
                        entranceArea.Width = 3.5f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-35.122864f, -612.464355f, 34.075790f);
                        entranceArea.Pos2 = new(-39.206161f, -622.972717f, 38.359833f);
                        entranceArea.Width = 9.0f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_6:
                    if (iEntrance == 0)
                    {

                        entranceArea.Pos1 = new(-934.896118f, -378.434052f, 37.711254f);
                        entranceArea.Pos2 = new(-929.826843f, -375.814117f, 41.961254f);
                        entranceArea.Width = 9.0f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-878.080505f, -359.382446f, 34.578461f);
                        entranceArea.Pos2 = new(-883.797302f, -348.115051f, 37.784054f);
                        entranceArea.Width = 7.0f;
                    }
                    break;

                case BuildingsEnum.MP_PROPERTY_BUILDING_7:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-618.387024f, 38.452286f, 42.607441f);
                        entranceArea.Pos2 = new(-618.253052f, 47.625286f, 46.995808f);
                        entranceArea.Width = 17.5f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-629.805908f, 56.867207f, 42.724968f);
                        entranceArea.Pos2 = new(-615.785339f, 56.872269f, 46.745895f);
                        entranceArea.Width = 18.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_8:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(286.476898f, -160.576492f, 63.622066f);
                        entranceArea.Pos2 = new(293.095032f, -162.990997f, 66.447395f);
                        entranceArea.Width = 4.75f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_9:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(3.715090f, 37.615387f, 70.535271f);
                        entranceArea.Pos2 = new(5.459632f, 42.267979f, 73.782608f);
                        entranceArea.Width = 6.25f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_10:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(9.232037f, 81.063820f, 77.444725f);
                        entranceArea.Pos2 = new(7.523234f, 76.363998f, 80.444946f);
                        entranceArea.Width = 6.25f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_11:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-511.627289f, 107.804184f, 62.800556f);
                        entranceArea.Pos2 = new(-510.499329f, 99.924927f, 65.800552f);
                        entranceArea.Width = 8.75f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_12:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-197.877335f, 85.269745f, 68.756531f);
                        entranceArea.Pos2 = new(-198.496063f, 82.336723f, 72.510452f);
                        entranceArea.Width = 3.75f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_13:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-627.293091f, 169.680206f, 60.162457f);
                        entranceArea.Pos2 = new(-624.252197f, 169.688370f, 63.412453f);
                        entranceArea.Width = 3.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_14:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-968.930786f, -1430.989136f, 6.768438f);
                        entranceArea.Pos2 = new(-965.249817f, -1429.650024f, 9.268437f);
                        entranceArea.Width = 8.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_15:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-831.436340f, -863.068237f, 19.712624f);
                        entranceArea.Pos2 = new(-831.429565f, -865.973083f, 22.962624f);
                        entranceArea.Width = 2.75f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_16:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-763.954468f, -753.807617f, 26.875198f);
                        entranceArea.Pos2 = new(-768.002319f, -753.814575f, 30.125198f);
                        entranceArea.Width = 13.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_17:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-40.380810f, -58.762543f, 63.067940f);
                        entranceArea.Pos2 = new(-37.415157f, -59.783459f, 65.318085f);
                        entranceArea.Width = 2.25f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_18:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-200.249756f, 186.889267f, 79.516670f);
                        entranceArea.Pos2 = new(-190.492050f, 186.964844f, 87.249451f);
                        entranceArea.Width = 5.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_19:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-812.007874f, -980.214233f, 13.025441f);
                        entranceArea.Pos2 = new(-809.171326f, -978.269592f, 16.227818f);
                        entranceArea.Width = 3.25f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_20:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-662.457214f, -854.631470f, 23.273163f);
                        entranceArea.Pos2 = new(-662.519409f, -858.444397f, 26.273163f);
                        entranceArea.Width = 1.75f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_21:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-1531.660889f, -325.886383f, 46.920044f);
                        entranceArea.Pos2 = new(-1528.763306f, -328.811401f, 50.670044f);
                        entranceArea.Width = 9.5f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_22:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-1564.808472f, -405.962555f, 41.388157f);
                        entranceArea.Pos2 = new(-1567.752808f, -403.511047f, 44.388157f);
                        entranceArea.Width = 5.0f;
                    }
                    break;
                case BuildingsEnum.MP_PROPERTY_BUILDING_23:
                    if (iEntrance == 0)
                    {
                        entranceArea.Pos1 = new(-1605.794312f, -432.945831f, 39.422031f);
                        entranceArea.Pos2 = new(-1601.657837f, -436.419647f, 41.922031f);
                        entranceArea.Width = 8.75f;
                    }
                    else if (iEntrance == 1)
                    {
                        entranceArea.Pos1 = new(-1579.334229f, -458.934601f, 36.212383f);
                        entranceArea.Pos2 = new(-1603.423096f, -438.750092f, 40.466648f);
                        entranceArea.Width = 14.5f;
                    }
                    break;
            }
            return entranceArea;
        }

        public static bool IsIndipendenceDayApartment(BuildingsEnum iBuildingID)
        {
            return iBuildingID switch
            {
                BuildingsEnum.MP_PROPERTY_BUILDING_57 or BuildingsEnum.MP_PROPERTY_BUILDING_58 or BuildingsEnum.MP_PROPERTY_BUILDING_59 or BuildingsEnum.MP_PROPERTY_BUILDING_60 or BuildingsEnum.MP_PROPERTY_BUILDING_61 or BuildingsEnum.MP_PROPERTY_BUILDING_62 or BuildingsEnum.MP_PROPERTY_BUILDING_63 => true,
                _ => false,
            };
        }
        internal static BuildingsEnum GetPropertyBuilding(PropertiesEnum iProperty)
        {
            return iProperty switch
            {
                PropertiesEnum.PROPERTY_HIGH_APT_1 or PropertiesEnum.PROPERTY_HIGH_APT_2 or PropertiesEnum.PROPERTY_HIGH_APT_3 or PropertiesEnum.PROPERTY_HIGH_APT_4 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_1 or PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE or PropertiesEnum.PROPERTY_CUSTOM_APT_2 or PropertiesEnum.PROPERTY_CUSTOM_APT_3 => BuildingsEnum.MP_PROPERTY_BUILDING_1,
                PropertiesEnum.PROPERTY_HIGH_APT_5 or PropertiesEnum.PROPERTY_HIGH_APT_6 => BuildingsEnum.MP_PROPERTY_BUILDING_2,
                PropertiesEnum.PROPERTY_HIGH_APT_7 or PropertiesEnum.PROPERTY_HIGH_APT_8 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_2 => BuildingsEnum.MP_PROPERTY_BUILDING_3,
                PropertiesEnum.PROPERTY_HIGH_APT_9 or PropertiesEnum.PROPERTY_HIGH_APT_10 or PropertiesEnum.PROPERTY_HIGH_APT_11 => BuildingsEnum.MP_PROPERTY_BUILDING_4,
                PropertiesEnum.PROPERTY_HIGH_APT_12 or PropertiesEnum.PROPERTY_HIGH_APT_13 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_5 => BuildingsEnum.MP_PROPERTY_BUILDING_5,
                PropertiesEnum.PROPERTY_HIGH_APT_14 or PropertiesEnum.PROPERTY_HIGH_APT_15 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_3 => BuildingsEnum.MP_PROPERTY_BUILDING_6,
                PropertiesEnum.PROPERTY_HIGH_APT_16 or PropertiesEnum.PROPERTY_HIGH_APT_17 or PropertiesEnum.PROPERTY_BUS_HIGH_APT_4 => BuildingsEnum.MP_PROPERTY_BUILDING_7,
                PropertiesEnum.PROPERTY_MEDIUM_APT_1 => BuildingsEnum.MP_PROPERTY_BUILDING_8,
                PropertiesEnum.PROPERTY_MEDIUM_APT_2 => BuildingsEnum.MP_PROPERTY_BUILDING_9,
                PropertiesEnum.PROPERTY_MEDIUM_APT_3 => BuildingsEnum.MP_PROPERTY_BUILDING_10,
                PropertiesEnum.PROPERTY_MEDIUM_APT_4 => BuildingsEnum.MP_PROPERTY_BUILDING_11,
                PropertiesEnum.PROPERTY_MEDIUM_APT_5 => BuildingsEnum.MP_PROPERTY_BUILDING_12,
                PropertiesEnum.PROPERTY_MEDIUM_APT_6 => BuildingsEnum.MP_PROPERTY_BUILDING_13,
                PropertiesEnum.PROPERTY_MEDIUM_APT_7 => BuildingsEnum.MP_PROPERTY_BUILDING_14,
                PropertiesEnum.PROPERTY_MEDIUM_APT_8 => BuildingsEnum.MP_PROPERTY_BUILDING_15,
                PropertiesEnum.PROPERTY_MEDIUM_APT_9 => BuildingsEnum.MP_PROPERTY_BUILDING_16,
                PropertiesEnum.PROPERTY_LOW_APT_1 => BuildingsEnum.MP_PROPERTY_BUILDING_17,
                PropertiesEnum.PROPERTY_LOW_APT_2 => BuildingsEnum.MP_PROPERTY_BUILDING_18,
                PropertiesEnum.PROPERTY_LOW_APT_3 => BuildingsEnum.MP_PROPERTY_BUILDING_19,
                PropertiesEnum.PROPERTY_LOW_APT_4 => BuildingsEnum.MP_PROPERTY_BUILDING_20,
                PropertiesEnum.PROPERTY_LOW_APT_5 => BuildingsEnum.MP_PROPERTY_BUILDING_21,
                PropertiesEnum.PROPERTY_LOW_APT_6 => BuildingsEnum.MP_PROPERTY_BUILDING_22,
                PropertiesEnum.PROPERTY_LOW_APT_7 => BuildingsEnum.MP_PROPERTY_BUILDING_23,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_1 => BuildingsEnum.MP_PROPERTY_BUILDING_24,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_2 => BuildingsEnum.MP_PROPERTY_BUILDING_25,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_3 => BuildingsEnum.MP_PROPERTY_BUILDING_26,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_4 => BuildingsEnum.MP_PROPERTY_BUILDING_27,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_5 => BuildingsEnum.MP_PROPERTY_BUILDING_28,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_6 => BuildingsEnum.MP_PROPERTY_BUILDING_29,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_7 => BuildingsEnum.MP_PROPERTY_BUILDING_30,
                PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_8 => BuildingsEnum.MP_PROPERTY_BUILDING_31,
                PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1 => BuildingsEnum.MP_PROPERTY_BUILDING_32,
                PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2 => BuildingsEnum.MP_PROPERTY_BUILDING_33,
                PropertiesEnum.PROPERTY_GARAGE_NEW_1 => BuildingsEnum.MP_PROPERTY_BUILDING_34,
                PropertiesEnum.PROPERTY_GARAGE_NEW_2 => BuildingsEnum.MP_PROPERTY_BUILDING_35,
                PropertiesEnum.PROPERTY_GARAGE_NEW_3 => BuildingsEnum.MP_PROPERTY_BUILDING_36,
                PropertiesEnum.PROPERTY_GARAGE_NEW_5 => BuildingsEnum.MP_PROPERTY_BUILDING_38,
                PropertiesEnum.PROPERTY_GARAGE_NEW_6 => BuildingsEnum.MP_PROPERTY_BUILDING_39,
                PropertiesEnum.PROPERTY_GARAGE_NEW_7 => BuildingsEnum.MP_PROPERTY_BUILDING_40,
                PropertiesEnum.PROPERTY_GARAGE_NEW_8 => BuildingsEnum.MP_PROPERTY_BUILDING_41,
                PropertiesEnum.PROPERTY_GARAGE_NEW_9 => BuildingsEnum.MP_PROPERTY_BUILDING_42,
                PropertiesEnum.PROPERTY_GARAGE_NEW_14 => BuildingsEnum.MP_PROPERTY_BUILDING_47,
                PropertiesEnum.PROPERTY_GARAGE_NEW_16 => BuildingsEnum.MP_PROPERTY_BUILDING_49,
                PropertiesEnum.PROPERTY_GARAGE_NEW_17 => BuildingsEnum.MP_PROPERTY_BUILDING_50,
                PropertiesEnum.PROPERTY_GARAGE_NEW_18 => BuildingsEnum.MP_PROPERTY_BUILDING_51,
                PropertiesEnum.PROPERTY_GARAGE_NEW_19 => BuildingsEnum.MP_PROPERTY_BUILDING_52,
                PropertiesEnum.PROPERTY_GARAGE_NEW_20 => BuildingsEnum.MP_PROPERTY_BUILDING_53,
                PropertiesEnum.PROPERTY_GARAGE_NEW_21 => BuildingsEnum.MP_PROPERTY_BUILDING_54,
                PropertiesEnum.PROPERTY_GARAGE_NEW_22 => BuildingsEnum.MP_PROPERTY_BUILDING_55,
                PropertiesEnum.PROPERTY_GARAGE_NEW_23 => BuildingsEnum.MP_PROPERTY_BUILDING_56,
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1 => BuildingsEnum.MP_PROPERTY_BUILDING_57,
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2 => BuildingsEnum.MP_PROPERTY_BUILDING_58,
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3 => BuildingsEnum.MP_PROPERTY_BUILDING_59,
                PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4 => BuildingsEnum.MP_PROPERTY_BUILDING_60,
                PropertiesEnum.PROPERTY_IND_DAY_LOW_1 => BuildingsEnum.MP_PROPERTY_BUILDING_61,
                PropertiesEnum.PROPERTY_IND_DAY_LOW_2 => BuildingsEnum.MP_PROPERTY_BUILDING_62,
                PropertiesEnum.PROPERTY_IND_DAY_LOW_3 => BuildingsEnum.MP_PROPERTY_BUILDING_63,
                PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_1_BASE_B,
                PropertiesEnum.PROPERTY_STILT_APT_2_B => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_2_B,
                PropertiesEnum.PROPERTY_STILT_APT_3_B => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_3_B,
                PropertiesEnum.PROPERTY_STILT_APT_4_B => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_4_B,
                PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_5_BASE_A,
                PropertiesEnum.PROPERTY_STILT_APT_7_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_7_A,
                PropertiesEnum.PROPERTY_STILT_APT_8_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_8_A,
                PropertiesEnum.PROPERTY_STILT_APT_10_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_10_A,
                PropertiesEnum.PROPERTY_STILT_APT_12_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_12_A,
                PropertiesEnum.PROPERTY_STILT_APT_13_A => BuildingsEnum.MP_PROPERTY_STILT_BUILDING_13_A,
                PropertiesEnum.PROPERTY_OFFICE_1 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3 => BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1,
                PropertiesEnum.PROPERTY_OFFICE_2_BASE or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3 => BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2,
                PropertiesEnum.PROPERTY_OFFICE_3 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3 => BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3,
                PropertiesEnum.PROPERTY_OFFICE_4 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4,
                PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1,
                PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2,
                PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3,
                PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4,
                PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5,
                PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6,
                PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7,
                PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8,
                PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9,
                PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10,
                PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11,
                PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12,
                _ => 0,
            };
        }
        public static void GetOfficeGarageDetails(ref PropertyData propertyDetails, PropertiesEnum iProperty)
        {
            Position tempOffset = new();
            propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_20;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_ENTRY_LOC, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.InPlayerLoc = tempOffset.ToVector3;
            propertyDetails.Garage.InPlayerHeading = tempOffset.Yaw;
            for (int i = 0; i < 10; i++)
            {
                GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_SPACE_0 + i, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
                propertyDetails.Garage.CarLoc[i] = tempOffset.ToVector3;
                propertyDetails.Garage.CarHeading[i] = tempOffset.Yaw;
                GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_OFF_GAR_SAFE_LOC_0 + i, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
                propertyDetails.Garage.CarSpawnSafeLoc[i] = tempOffset.ToVector3;
            }
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR1, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.AutoExitLoc.Pos1 = tempOffset.ToVector3;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_EXIT_DOOR2, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.AutoExitLoc.Pos2 = tempOffset.ToVector3;
            propertyDetails.Garage.AutoExitLoc.Width = 2.0f;
            propertyDetails.Garage.AutoExitLoc.EnterHeading = tempOffset.Yaw;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BUZZER, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.BuzzerLoc = tempOffset.ToVector3;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_MIDPOINT, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.MidPoint = tempOffset.ToVector3;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS1, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.Bounds.Pos1 = tempOffset.ToVector3;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_BOUNDS2, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.Bounds.Pos2 = tempOffset.ToVector3;
            propertyDetails.Garage.Bounds.Width = 22.750000f;
            propertyDetails.Garage.NumBikeSlots = 0;
            GetPositionAsOffsetForProperty(iProperty, (int)PropertyPropElements.MP_PROP_ELEMENT_SAFE_CORONA_COORDS, ref tempOffset, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
            propertyDetails.Garage.SafeCoronaLoc = tempOffset.ToVector3;
        }
        public static void GetClubhouseGarageDetails(ref PropertyData propertyDetails, PropertiesEnum iBaseProperty)
        {
            switch (iBaseProperty)
            {
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.InPlayerLoc = new(1105.6198f, -3163.5789f, -38.5186f);
                    propertyDetails.Garage.InPlayerHeading = 347.4298f;
                    propertyDetails.Garage.CarLoc[0] = new(1099.5090f, -3153.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[0] = -120.0f;
                    propertyDetails.Garage.CarLoc[1] = new(1099.5090f, -3150.5747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[1] = -120.0f;
                    propertyDetails.Garage.CarLoc[2] = new(1099.5090f, -3148.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[2] = -120.0f;
                    propertyDetails.Garage.CarLoc[3] = new(1099.5090f, -3145.5747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[3] = -120.0f;
                    propertyDetails.Garage.CarLoc[4] = new(1099.5090f, -3143.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[4] = -120.0f;
                    propertyDetails.Garage.CarLoc[5] = new(1103.2490f, -3143.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[5] = 120.0f;
                    propertyDetails.Garage.CarLoc[6] = new(1103.2490f, -3145.5747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[6] = 120.0f;
                    propertyDetails.Garage.CarLoc[7] = new(1103.2490f, -3148.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[7] = 120.0f;
                    propertyDetails.Garage.CarLoc[8] = new(1103.2490f, -3150.5747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[8] = 120.0f;
                    propertyDetails.Garage.CarLoc[9] = new(1103.2490f, -3153.0747f, -38.0166f);
                    propertyDetails.Garage.CarHeading[9] = 120.0f;
                    propertyDetails.Garage.AutoExitLoc.Pos1 = new(1109.873413f, -3166.230225f, -38.476124f);
                    propertyDetails.Garage.AutoExitLoc.Pos2 = new(1109.856445f, -3167.783936f, -34.367371f);
                    propertyDetails.Garage.AutoExitLoc.Width = 5.0f;
                    propertyDetails.Garage.AutoExitLoc.EnterHeading = 181.7343f;
                    propertyDetails.Garage.BuzzerLoc = new(1120.3073f, -3152.9365f, -35.6192f);
                    propertyDetails.Garage.NumBikeSlots = 0;
                    propertyDetails.Garage.SafeCoronaLoc = new(1111.6139f, -3158.7023f, -37.5608f);
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_10;
                    propertyDetails.Garage.InPlayerLoc = new(998.9226f, -3158.1750f, -39.9075f);
                    propertyDetails.Garage.InPlayerHeading = 265.1815f;
                    propertyDetails.Garage.CarLoc[0] = new(1004.000f, -3167.3149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[0] = 70f;
                    propertyDetails.Garage.CarLoc[1] = new(1004.000f, -3169.5649f, -39.4068f);
                    propertyDetails.Garage.CarHeading[1] = 70f;
                    propertyDetails.Garage.CarLoc[2] = new(1004.000f, -3171.8149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[2] = 70f;
                    propertyDetails.Garage.CarLoc[3] = new(1004.000f, -3174.0649f, -39.4068f);
                    propertyDetails.Garage.CarHeading[3] = 70f;
                    propertyDetails.Garage.CarLoc[4] = new(1004.0000f, -3176.3149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[4] = 70f;
                    propertyDetails.Garage.CarLoc[5] = new(999.7000f, -3176.3149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[5] = -70f;
                    propertyDetails.Garage.CarLoc[6] = new(999.7000f, -3174.0649f, -39.4068f);
                    propertyDetails.Garage.CarHeading[6] = -70f;
                    propertyDetails.Garage.CarLoc[7] = new(999.7000f, -3171.8149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[7] = -70f;
                    propertyDetails.Garage.CarLoc[8] = new(999.7000f, -3169.5649f, -39.4068f);
                    propertyDetails.Garage.CarHeading[8] = -70f;
                    propertyDetails.Garage.CarLoc[9] = new(999.7000f, -3167.3149f, -39.4068f);
                    propertyDetails.Garage.CarHeading[9] = -70f;
                    propertyDetails.Garage.AutoExitLoc.Pos1 = new(996.562134f, -3164.368164f, -40.407059f);
                    propertyDetails.Garage.AutoExitLoc.Pos2 = new(997.244507f, -3164.318848f, -35.907146f);
                    propertyDetails.Garage.AutoExitLoc.Width = 4.50000f;
                    propertyDetails.Garage.AutoExitLoc.EnterHeading = 111.1633f;
                    propertyDetails.Garage.BuzzerLoc = new(996.6504f, -3157.1436f, -37.4737f);
                    propertyDetails.Garage.NumBikeSlots = 0;
                    propertyDetails.Garage.SafeCoronaLoc = new(1009.0786f, -3163.9946f, -39.9090f);
                    break;
            }
        }

        public static bool IsPropertyOfficeGarage(PropertiesEnum iPropertyID, bool bIsOffGarageOnly = false, bool bIsModGarageOnly = false)
        {
            /*
            if (bIsModGarageOnly)
                return IsPlayerInOfficeModInterior(PlayerId());
            if (bIsOffGarageOnly)
            {
                if (IsPlayerInOfficeModInterior(PlayerId()))
                    return false;
            }
            */
            return iPropertyID switch
            {
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 or PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3 or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => true,
                _ => false,
            };
        }

        public static PropertiesEnum GetOfficeGarageBaseIdFromProperty(PropertiesEnum iProperty)
        {
            return iProperty switch
            {
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1
                or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1
                or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1
                or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 => PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1,
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2
                or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2
                or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2
                or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 => PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2,
                PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3
                or PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3
                or PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3
                or PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3,
                _ => (PropertiesEnum)(-1)
            };

        }
    }
}
