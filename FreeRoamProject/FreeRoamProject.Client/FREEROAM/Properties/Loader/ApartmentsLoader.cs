using FreeRoamProject.Shared.Core.ApartmentsShared;
using FreeRoamProject.Shared.Properties.Enums;
using System.Threading.Tasks;
namespace FreeRoamProject.Client.FREEROAM.Properties.Loader
{
    internal static class ApartmentsLoader
    {
        public static Global_4280768[] g_PrivateYachtDetails = new Global_4280768[43];
        public static async Task LoadApartments()
        {
            int i = 0;
            while (i < 42)
            {
                await BaseScript.Delay(0);
                Position Var1 = func_9970(i);
                g_PrivateYachtDetails[i] = new Global_4280768();
                g_PrivateYachtDetails[i /*45*/].f_0 = Var1.ToVector3;
                g_PrivateYachtDetails[i /*45*/].f_3 = Var1.ToRotationVector.Z;
                func_18463(i, ref g_PrivateYachtDetails[i /*45*/].f_8, ref g_PrivateYachtDetails[i /*45*/].f_11);
                g_PrivateYachtDetails[i /*45*/].f_4 = g_PrivateYachtDetails[i /*45*/].f_0 + func_39_1(i);
                g_PrivateYachtDetails[i /*45*/].f_7 = g_PrivateYachtDetails[i /*45*/].f_3 + 90.005f;
                g_PrivateYachtDetails[i /*45*/].f_12 = func_37_1(i, new(-0.1665f, -38.7851f, -5.5231f));
                i++;
            }

            //string binary = API.LoadResourceFile(GetCurrentResourceName(), "files/apartments.bin");
            //Properties = binary.StringToBytes().FromBytes<List<PropertyData>>();

            i = 0;
            while (i < 131)
            {
                await BaseScript.Delay(10);
                PropertyData property = new();
                GetPropertyData(ref property, (PropertiesEnum)i);
                ClientMain.Logger.Debug($"index: {i}, {property.ToJson()}");
                PropertiesExteriorsManager.Properties.Add(property);
                i++;
            }
        }
        private static void GetPropertyData(ref PropertyData propertyDetails, PropertiesEnum iIndex)
        {
            int i;
            for (i = 0; i < 5; i++)
            {
                propertyDetails.Garage.CarExitWeight[i] = 1.0f;
            }
            for (i = 0; i < 4; i++)
            {
                propertyDetails.Building.PropertiesInBuilding[i] = 0;
            }
            GetMpPropertyClubhouseDetailsFull(ref propertyDetails, iIndex);
            GetMpPropertyOfficeGarageDetailsFull(ref propertyDetails, iIndex);
            switch (iIndex)
            {
                case PropertiesEnum.PROPERTY_HIGH_APT_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_BUS_HIGH_APT_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_BASE:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_2_BASE;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_BASE);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_5;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_6:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_6;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_7:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_7;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_8:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_8;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_BUS_HIGH_APT_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_9:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_9;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_10:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_10;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_11:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_11;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_12:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_5;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_12;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_13:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_5;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_13;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_5;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_BUS_HIGH_APT_5;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_14:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_6;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_14;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_15:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_6;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_15;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_6;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_BUS_HIGH_APT_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_16:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_7;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_16;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_HIGH_APT_17:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_7;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_HIGH_APT_17;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_BUS_HIGH_APT_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_7;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_BUS_HIGH_APT_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_1_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_2_B:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_2_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_3_B:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_3_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_4_B:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_4_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_5_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_7_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_7_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_8_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_8_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_10_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_10_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_12_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_12_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_STILT_APT_13_A:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_STILT_APT_13_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CUSTOM_APT_1_BASE;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_2:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CUSTOM_APT_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CUSTOM_APT_3:
                    propertyDetails.BuildingID = PropertyFunctions.GetPropertyBuilding(iIndex);
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CUSTOM_APT_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_8;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_9;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_10;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_11;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_12;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_5;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_6:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_13;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_6;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_7:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_14;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_7;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_8:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_15;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_8;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MEDIUM_APT_9:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_16;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MEDIUM_APT_9;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_17;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_18;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_19;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_20;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_21;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_5;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_6:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_22;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_6;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_LOW_APT_7:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_23;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_LOW_APT_7;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_24;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_1;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_25;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_2;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_26;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_3;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_27;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_4;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_28;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_5;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_6:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_29;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_6;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_7:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_30;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_7;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_8:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_31;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_EAST_LOS_SANTOS_8;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_32;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_33;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_34;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_1;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_35;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_2;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_36;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_3;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_5:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_38;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_5;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_6:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_39;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_6;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_7:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_40;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_7;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_8:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_41;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_8;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_9:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_42;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_9;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_14:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_47;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_14;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_16:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_49;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_16;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_17:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_50;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_17;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_18:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_51;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_18;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_19:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_52;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_19;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_20:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_53;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_20;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_10);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_21:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_54;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_21;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_22:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_55;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_22;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_GARAGE_NEW_23:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_56;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_GARAGE_NEW_23;
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_57;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_58;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_59;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_60;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_6);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_MEDIUM_4;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_61;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_LOW_1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_62;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_LOW_2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_IND_DAY_LOW_3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_BUILDING_63;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetGarageDetailsForSize(ref propertyDetails, (int)GarageSize.PROP_GARAGE_SIZE_2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_IND_DAY_LOW_3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, propertyDetails.Index);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
                case PropertiesEnum.PROPERTY_MULTISTOREY_GARAGE:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_MULTISTOREY_GARAGE_BUILDING;
                    propertyDetails.BlipLocation[0] = new(-286.2379f, 281.7274f, 88.8872f);
                    propertyDetails.PurchaseLocation = new(-286.2379f, 281.7274f, 88.8872f);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_MULTISTOREY_GARAGE;
                    propertyDetails.GarageSize = (int)GarageSize.PROP_GARAGE_SIZE_50;
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_GARAGE_HOUSE;
                    break;
            }
        }

        #region Get Methods
        static void GetMpPropertyClubhouseDetailsFull(ref PropertyData propertyDetails, PropertiesEnum iParam1)
        {
            propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1;
            switch (iParam1)
            {
                case PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_5;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_6;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_7;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_8;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_9;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_10;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_11;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
                case PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_CLUBHOUSE_BUILDING_12;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetClubhouseGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_CLUBHOUSE;
                    break;
            }
        }
        static void GetMpPropertyOfficeGarageDetailsFull(ref PropertyData propertyDetails, PropertiesEnum iIndex)
        {
            switch (iIndex)
            {
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_1;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_2;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_3;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
                case PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3:
                    propertyDetails.BuildingID = BuildingsEnum.MP_PROPERTY_OFFICE_BUILDING_4;
                    PropertyFunctions.GetBuildingExteriorDetailsFull(ref propertyDetails, propertyDetails.BuildingID);
                    PropertyFunctions.GetOfficeGarageDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3);
                    propertyDetails.Index = PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3;
                    PropertyFunctions.GetHouseInteriorDetails(ref propertyDetails, PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3);
                    propertyDetails.Type = (int)PropertyType.PROPERTY_TYPE_OFFICE_GARAGE;
                    break;
            }
        }
        #endregion

        #region Global unknown (yacht related)
        static Position func_9970(int iParam0)
        {
            Position Var0 = iParam0 switch
            {
                0 => new(-3555.1155f, 1473.0128f, 9.7027f, 0f, 0f, 57f),
                1 => new(-3147.0488f, 2827.088f, 9.7027f, 0f, 0f, -88f),
                2 => new(-3277.473f, 2159.8499f, 9.7027f, 0f, 0f, -93f),
                3 => new(-2822.4194f, 4054.8396f, 9.7027f, 0f, 0f, 72f),
                4 => new(-3249.849f, 3704.6814f, 9.7027f, 0f, 0f, -98f),
                5 => new(-2383.1934f, 4685.0034f, 9.7027f, 0f, 0f, 47f),
                6 => new(-3224.6863f, -215.9825f, 9.7027f, 0f, 0f, -3f),
                7 => new(-3447.8765f, 291.9275f, 9.7027f, 0f, 0f, 97f),
                8 => new(-2713.098f, -528.3185f, 9.7027f, 0f, 0f, -33f),
                9 => new(-1981.6182f, -1537.2692f, 9.7027f, 0f, 0f, 142f),
                10 => new(-2100.817f, -2533.2332f, 9.7027f, 0f, 0f, -143f),
                11 => new(-1599.6425f, -1891.2773f, 9.7027f, 0f, 0f, 112f),
                12 => new(-733.6151f, -3916.9846f, 9.7027f, 0f, 0f, -168f),
                13 => new(-363.3534f, -3568.56f, 9.7027f, 0f, 0f, 57f),
                14 => new(-1478.436f, -3753.5378f, 9.7027f, 0f, 0f, -18f),
                15 => new(1535.974f, -3061.8774f, 9.7027f, 0f, 0f, 62f),
                16 => new(2471.4185f, -2430.9297f, 9.7027f, 0f, 0f, 12f),
                17 => new(2067.3708f, -2813.0103f, 9.7027f, 0f, 0f, -148f),
                18 => new(3021.0881f, -1513.6022f, 9.7027f, 0f, 0f, 72f),
                19 => new(3025.9556f, -704.3854f, 9.7027f, 0f, 0f, -98f),
                20 => new(2961.8628f, -2007.6315f, 9.7027f, 0f, 0f, 47f),
                21 => new(3398.1694f, 1958.5214f, 9.7027f, 0f, 0f, 77f),
                22 => new(3428.6812f, 1202.0597f, 9.7027f, 0f, 0f, -148f),
                23 => new(3787.8298f, 2567.8838f, 9.7027f, 0f, 0f, -93f),
                24 => new(4235.9463f, 4004.2522f, 9.7027f, 0f, 0f, -118f),
                25 => new(4245.1514f, 4595.375f, 9.7027f, 0f, 0f, -68f),
                26 => new(4209.057f, 3392.7053f, 9.7027f, 0f, 0f, -98f),
                27 => new(3738.8098f, 5768.2524f, 9.7027f, 0f, 0f, -43f),
                28 => new(3472.9656f, 6315.245f, 9.7027f, 0f, 0f, -23f),
                29 => new(3693.4683f, 5194.6587f, 9.7027f, 0f, 0f, 122f),
                30 => new(572.9806f, 7142.138f, 9.7027f, 0f, 0f, -58f),
                31 => new(2024.036f, 6907.536f, 9.7027f, 0f, 0f, -173f),
                32 => new(1377.2958f, 6863.2305f, 9.7027f, 0f, 0f, -3f),
                33 => new(-1169.3605f, 6000.214f, 9.7027f, 0f, 0f, -88f),
                34 => new(-759.2205f, 6573.955f, 9.7027f, 0f, 0f, -153f),
                35 => new(-373.8432f, 6964.86f, 9.7027f, 0f, 0f, -108f),
                36 => new(3634.999f, -4781.017f, 9.7065f, 0f, 0f, -179.95f),
                37 => new(50.6219f, -3312.5625f, 9.7065f, 0f, 0f, 90.05f),
                38 => new(-3556.677f, 738.4581f, 9.7065f, 0f, 0f, 0.05f),
                39 => new(-1766.8353f, 5334.0933f, 9.7065f, 0f, 0f, -9.95f),
                40 => new(-3280.7068f, -1580.8092f, 9.7065f, 0f, 0f, -12.45f),
                41 => new(-833.0568f, -4809.8076f, 9.7065f, 0f, 0f, -147.45f),
                _ => new(-1478.436f, -3753.5378f, 9.7027f, 0f, 0f, -18f),
            };
            return Var0;
        }
        static void func_18463(int iParam0, ref Vector3 uParam1, ref float uParam2)
        {
            switch (iParam0)
            {
                case 0:
                    uParam1 = new(-3542.82f, 1488.25f, 5.42995f);
                    uParam2 = -123.045f;
                    break;
                case 1:
                    uParam1 = new(-3148.38f, 2807.55f, 5.42995f);
                    uParam2 = 91.955f;
                    break;
                case 2:
                    uParam1 = new(-3280.5f, 2140.51f, 5.42995f);
                    uParam2 = 86.955f;
                    break;
                case 3:
                    uParam1 = new(-2814.49f, 4072.74f, 5.42995f);
                    uParam2 = -108.045f;
                    break;
                case 4:
                    uParam1 = new(-3254.55f, 3685.68f, 5.42995f);
                    uParam2 = 81.955f;
                    break;
                case 5:
                    uParam1 = new(-2368.44f, 4697.87f, 5.42995f);
                    uParam2 = -133.045f;
                    break;
                case 6:
                    uParam1 = new(-3205.34f, -219.01f, 5.42995f);
                    uParam2 = 176.955f;
                    break;
                case 7:
                    uParam1 = new(-3448.25f, 311.502f, 5.42995f);
                    uParam2 = -83.045f;
                    break;
                case 8:
                    uParam1 = new(-2697.86f, -540.612f, 5.42995f);
                    uParam2 = 146.955f;
                    break;
                case 9:
                    uParam1 = new(-1995.73f, -1523.69f, 5.42997f);
                    uParam2 = -38.045f;
                    break;
                case 10:
                    uParam1 = new(-2117.58f, -2543.35f, 5.42995f);
                    uParam2 = 36.955f;
                    break;
                case 11:
                    uParam1 = new(-1605.07f, -1872.47f, 5.42995f);
                    uParam2 = -68.045f;
                    break;
                case 12:
                    uParam1 = new(-753.082f, -3919.07f, 5.42995f);
                    uParam2 = 11.955f;
                    break;
                case 13:
                    uParam1 = new(-351.061f, -3553.32f, 5.42995f);
                    uParam2 = -123.045f;
                    break;
                case 14:
                    uParam1 = new(-1460.54f, -3761.47f, 5.42995f);
                    uParam2 = 161.955f;
                    break;
                case 15:
                    uParam1 = new(1546.89f, -3045.63f, 5.42995f);
                    uParam2 = -118.045f;
                    break;
                case 16:
                    uParam1 = new(2490.89f, -2428.85f, 5.42995f);
                    uParam2 = -168.045f;
                    break;
                case 17:
                    uParam1 = new(2049.79f, -2821.62f, 5.42995f);
                    uParam2 = 31.955f;
                    break;
                case 18:
                    uParam1 = new(3029.02f, -1495.7f, 5.42995f);
                    uParam2 = -108.045f;
                    break;
                case 19:
                    uParam1 = new(3021.25f, -723.39f, 5.42995f);
                    uParam2 = 81.955f;
                    break;
                case 20:
                    uParam1 = new(2976.62f, -1994.76f, 5.42995f);
                    uParam2 = -133.045f;
                    break;
                case 21:
                    uParam1 = new(3404.51f, 1977.04f, 5.42995f);
                    uParam2 = -103.045f;
                    break;
                case 22:
                    uParam1 = new(3411.1f, 1193.44f, 5.42995f);
                    uParam2 = 31.955f;
                    break;
                case 23:
                    uParam1 = new(3784.8f, 2548.54f, 5.42995f);
                    uParam2 = 86.955f;
                    break;
                case 24:
                    uParam1 = new(4225.03f, 3988f, 5.42995f);
                    uParam2 = 61.955f;
                    break;
                case 25:
                    uParam1 = new(4250.58f, 4576.57f, 5.42995f);
                    uParam2 = 111.955f;
                    break;
                case 26:
                    uParam1 = new(4204.36f, 3373.7f, 5.42995f);
                    uParam2 = 81.955f;
                    break;
                case 27:
                    uParam1 = new(3751.68f, 5753.5f, 5.42995f);
                    uParam2 = 136.955f;
                    break;
                case 28:
                    uParam1 = new(3490.11f, 6305.79f, 5.42995f);
                    uParam2 = 156.955f;
                    break;
                case 29:
                    uParam1 = new(3684.85f, 5212.24f, 5.42995f);
                    uParam2 = -58.045f;
                    break;
                case 30:
                    uParam1 = new(581.595f, 7124.56f, 5.42995f);
                    uParam2 = 121.955f;
                    break;
                case 31:
                    uParam1 = new(2004.46f, 6907.16f, 5.42997f);
                    uParam2 = 6.955f;
                    break;
                case 32:
                    uParam1 = new(1396.64f, 6860.2f, 5.42995f);
                    uParam2 = 176.955f;
                    break;
                case 33:
                    uParam1 = new(-1170.69f, 5980.68f, 5.42995f);
                    uParam2 = 91.955f;
                    break;
                case 34:
                    uParam1 = new(-777.487f, 6566.91f, 5.42995f);
                    uParam2 = 26.955f;
                    break;
                case 35:
                    uParam1 = new(-381.774f, 6946.96f, 5.42995f);
                    uParam2 = 71.955f;
                    break;
                case 36:
                    uParam1 = new(3615.5232f, -4779.021f, 5.4337f);
                    uParam2 = 0f;
                    break;
                case 37:
                    uParam1 = new(52.6177f, -3293.0867f, 5.4337f);
                    uParam2 = -90f;
                    break;
                case 38:
                    uParam1 = new(-3537.2012f, 736.4623f, 5.4337f);
                    uParam2 = 180f;
                    break;
                case 39:
                    uParam1 = new(-1748.0023f, 5328.746f, 5.4337f);
                    uParam2 = 170f;
                    break;
                case 40:
                    uParam1 = new(-3262.125f, -1586.9724f, 5.4337f);
                    uParam2 = 167.5f;
                    break;
                case 41:
                    uParam1 = new(-850.5552f, -4818.589f, 5.4337f);
                    uParam2 = 32.5f;
                    break;
            }
        }
        static Vector3 func_37_1(int iParam0, Vector3 Param1)
        {
            Vector3 p1 = g_PrivateYachtDetails[iParam0].f_4;
            return GetObjectOffsetFromCoords(p1.X, p1.Y, p1.Z, g_PrivateYachtDetails[iParam0].f_7, Param1.X, Param1.Y, Param1.Z);
        }
        static Vector3 func_39_1(int iParam0)
        {
            Vector3 Var0 = new(0.08f, -17.998f, 0.701f);
            func_40_1(ref Var0, new Vector3(0f, 0f, g_PrivateYachtDetails[iParam0 /*45*/].f_3 + 90.005f));
            return Var0;
        }
        static void func_40_1(ref Vector3 uParam0, Vector3 Param1)
        {
            float fVar0;
            float fVar1;
            Vector3 Var2;
            fVar0 = Cos(Param1.X);
            fVar1 = Sin(Param1.X);
            Var2 = new Vector3(uParam0.X, fVar0 * uParam0.Y - fVar1 * uParam0.Z, fVar1 * uParam0.Y + fVar0 * uParam0.Z);
            uParam0 = Var2;
            fVar0 = Cos(Param1.Y);
            fVar1 = Sin(Param1.Y);
            Var2 = new Vector3(fVar0 * uParam0.X + fVar1 * uParam0.Z, uParam0.Y, fVar0 * uParam0.Z - fVar1 * uParam0.X);
            uParam0 = Var2;
            fVar0 = Cos(Param1.Z);
            fVar1 = Sin(Param1.Z);
            Var2 = new Vector3(fVar0 * uParam0.X - fVar1 * uParam0.Y, fVar1 * uParam0.X + fVar0 * uParam0.Y, uParam0.Z);
            uParam0 = Var2;
        }
        #endregion
    }
}