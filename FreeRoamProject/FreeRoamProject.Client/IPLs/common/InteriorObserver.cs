using System.Threading.Tasks;
using FreeRoamProject.Client.IPLs.dlc_bikers;
using FreeRoamProject.Client.IPLs.dlc_finance;

namespace FreeRoamProject.Client.IPLs
{
    static class InteriorObserver
    {
        public static async Task Observer()
        {
            await PlayerCache.Loaded();
            IplManager.Global.CurrentInteriorId = GetInteriorFromEntity(PlayerPedId());
            if (IplManager.Global.CurrentInteriorId == 0)
            {
                IplManager.Global.ResetInteriorVariables();
                foreach (var ipl in IPLInstance.Ammunations.AmmunationsList)
                {
                    float x = 0, y = 0, z = 0;
                    GetInteriorPosition(ipl.InteriorId, ref x, ref y, ref z);

                    if (PlayerCache.MyPlayer.Position.IsInRangeOf(new Vector3(x, y, z), 300))
                    {
                        if (!ipl.Enabled) ipl.Enabled = true;
                    }
                    else
                    {
                        if (ipl.Enabled) ipl.Enabled = false;
                    }
                }
            }
            else
            {
                // eseguiamolo una volta sola
                if (IplManager.Global.IsAnyInteriorActive)
                {
                    HideMinimapExteriorMapThisFrame();
                    return;
                }

                switch (IplManager.Global.CurrentInteriorId)
                {
                    case int a when a == IPLInstance.GTAOApartmentHi1.InteriorId:
                        IplManager.Global.Online.isInsideApartmentHi1 = true;
                        break;
                    case int a when a == IPLInstance.GTAOApartmentHi2.InteriorId:
                        IplManager.Global.Online.isInsideApartmentHi2 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi1.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi1 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi2.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi2 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi3.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi3 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi4.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi4 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi5.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi5 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi6.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi6 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi7.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi7 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseHi8.InteriorId:
                        IplManager.Global.Online.isInsideHouseHi8 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseLow1.InteriorId:
                        IplManager.Global.Online.isInsideHouseLow1 = true;
                        break;
                    case int a when a == IPLInstance.GTAOHouseMid1.InteriorId:
                        IplManager.Global.Online.isInsideHouseMid1 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment1.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment1 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment2.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment2 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment3.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment3 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment4.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment4 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment5.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment5 = true;
                        break;
                    case int a when a == IPLInstance.HLApartment6.InteriorId:
                        IplManager.Global.HighLife.isInsideApartment6 = true;
                        break;
                    case int a when a == BikerClubhouse1.InteriorId:
                        IplManager.Global.Biker.isInsideClubhouse1 = true;
                        break;
                    case int a when a == BikerClubhouse2.InteriorId:
                        IplManager.Global.Biker.isInsideClubhouse2 = true;
                        break;
                    case int a when a == IPLInstance.FinanceOffice1.CurrentInteriorId:
                        IplManager.Global.FinanceOffices.isInsideOffice1 = true;
                        break;
                    case int a when a == IPLInstance.FinanceOffice2.CurrentInteriorId:
                        IplManager.Global.FinanceOffices.isInsideOffice2 = true;
                        break;
                    case int a when a == IPLInstance.FinanceOffice3.CurrentInteriorId:
                        IplManager.Global.FinanceOffices.isInsideOffice3 = true;
                        break;
                    case int a when a == IPLInstance.FinanceOffice4.CurrentInteriorId:
                        IplManager.Global.FinanceOffices.isInsideOffice4 = true;
                        break;
                    case int a when a == IPLInstance.DiamondCasino.InteriorId:
                        IplManager.Global.DiamondDlc.IsInCasino = true;
                        if (IPLInstance.DiamondCasino.ExpositionVeh is null)
                        {
                            string model = await EventDispatcher.Get<string>("tlg:casino:getVehModel");
                            IPLInstance.DiamondCasino.CreateVehicleForDisplay(model);
                        }
                        IPLInstance.DiamondCasino.RenderWalls(true);
                        break;
                }
            }

            await BaseScript.Delay(500);
        }

        public static async Task OfficeSafeDoorHandler()
        {
            int doorhandle = 0;
            FinanceOffice office = null;

            if (IplManager.Global.FinanceOffices.isInsideOffice1) office = IPLInstance.FinanceOffice1;
            else if (IplManager.Global.FinanceOffices.isInsideOffice2) office = IPLInstance.FinanceOffice2;
            else if (IplManager.Global.FinanceOffices.isInsideOffice3) office = IPLInstance.FinanceOffice3;
            else if (IplManager.Global.FinanceOffices.isInsideOffice4) office = IPLInstance.FinanceOffice4;

            if (office != null)
            {
                doorhandle = await office.Safe.GetDoorHandle(OfficeCassaForte.CurrentSafeDoors.HashL);

                //sinsitra
                if (doorhandle != 0)
                {
                    if (office.Safe.IsLeftDoorOpen) office.Safe.SetDoorState("left", true);
                    else office.Safe.SetDoorState("left", false);
                }

                doorhandle = await office.Safe.GetDoorHandle(OfficeCassaForte.CurrentSafeDoors.HashR);

                //destra
                if (doorhandle != 0)
                {
                    if (office.Safe.IsRightDoorOpen) office.Safe.SetDoorState("right", true);
                    else office.Safe.SetDoorState("right", false);
                }
            }
            await BaseScript.Delay(500);
        }

        public static async Task OrganizationWatchers()
        {
            if (IPLInstance.FinanceOrganization.Office.NeedToLoad)
            {
                if (IplManager.Global.FinanceOffices.isInsideOffice1 || IplManager.Global.FinanceOffices.isInsideOffice2 ||
                    IplManager.Global.FinanceOffices.isInsideOffice3 || IplManager.Global.FinanceOffices.isInsideOffice4)
                {
                    IplManager.DrawOrganizationName(IPLInstance.FinanceOrganization.Name.Name, IPLInstance.FinanceOrganization.Name.Style, IPLInstance.FinanceOrganization.Name.Color, IPLInstance.FinanceOrganization.Name.Font);
                    IPLInstance.FinanceOrganization.Office.Loaded = true;
                }
            }
            else if (IPLInstance.FinanceOrganization.Office.Loaded)
            {
                IPLInstance.FinanceOrganization.Office.Clear();
                IPLInstance.FinanceOrganization.Office.Loaded = false;
            }
            else await BaseScript.Delay(1000);
        }

    }
}