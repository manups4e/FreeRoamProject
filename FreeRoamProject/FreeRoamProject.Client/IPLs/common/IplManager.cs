using FreeRoamProject.Client.IPLs.dlc_finance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.IPLs
{
    public static class IplManager
    {
        public static GlobalIPLEnablers Global = new();

        public static void EnableInterior(int interior, bool enabled)
        {
            if (enabled)
            {
                if (IsInteriorDisabled(interior))
                {
                    PinInteriorInMemory(interior);
                    SetInteriorActive(interior, true);
                }
            }
            else
            {
                if (!IsInteriorDisabled(interior))
                {
                    API.UnpinInterior(interior);
                    SetInteriorActive(interior, false);
                }
            }
        }

        public static void EnableIpl(List<string> ipls, bool activate)
        {
            foreach (string s in ipls)
                _enableIPL(s, activate);
        }

        public static void EnableIpl(string ipls, bool activate)
        {
            _enableIPL(ipls, activate);
        }

        public static void SetIplPropState(List<int> interiorId, List<string> props, bool state, bool refresh = true)
        {
            foreach (int value in interiorId)
                foreach (string s in props)
                    _setIplPropState(value, s, state, refresh);
        }

        public static void SetIplPropState(int interiorId, List<string> props, bool state, bool refresh = true)
        {
            foreach (string s in props)
                _setIplPropState(interiorId, s, state, refresh);
        }

        public static void SetIplPropState(int interiorId, string props, bool state, bool refresh = true)
        {
            _setIplPropState(interiorId, props, state, refresh);
        }

        private static void _setIplPropState(int interior, string prop, bool state, bool refresh)
        {
            if (state)
            {
                if (!IsInteriorEntitySetActive(interior, prop))
                    ActivateInteriorEntitySet(interior, prop);
            }
            else
            {
                if (IsInteriorEntitySetActive(interior, prop))
                    DeactivateInteriorEntitySet(interior, prop);
            }
            if (refresh) RefreshInterior(interior);
        }

        private static void _enableIPL(string s, bool activate)
        {
            if (activate)
            {
                if (!IsIplActive(s))
                    RequestIpl(s);
            }
            else
            {
                if (IsIplActive(s))
                    RemoveIpl(s);
            }
        }

        public static async Task<bool> LoadStreamedTextureDict(string texture)
        {
            int time = 0;
            RequestStreamedTextureDict(texture, false);
            while (!HasStreamedTextureDictLoaded(texture))
            {
                await BaseScript.Delay(1000);
                time++;
                if (time > 5)
                    return false;
            }
            return true;
        }

        public static async void DrawEmptyRect(string name, uint model)
        {
            int currentTime = 0;
            int renderId = RenderTargets.CreateNamedRenderTargetForModel(name, model);
            while (!IsNamedRendertargetRegistered(name))
            {
                await BaseScript.Delay(250);
                currentTime += 250;
                if (currentTime >= 5000) return;
            }
            if (IsNamedRendertargetRegistered(name))
            {
                SetTextRenderId(renderId);
                SetUiLayer(4);
                DrawRect(0.5f, 0.5f, 1.0f, 1.0f, 0, 0, 0, 255);
                SetTextRenderId(GetDefaultScriptRendertargetRenderId());
                ReleaseNamedRendertarget(name);
            }
        }

        public static void DrawOrganizationName(string name, OrganizationStyle style, OrganizationColors color, OrganizationFonts font)
        {
            switch (IPLInstance.FinanceOrganization.Office.Stage)
            {
                case 0:
                    if (IPLInstance.FinanceOrganization.Office.RenderId == -1)
                        IPLInstance.FinanceOrganization.Office.RenderId = RenderTargets.CreateNamedRenderTargetForModel(IPLInstance.FinanceOrganization.Office.Target, Functions.HashUint(IPLInstance.FinanceOrganization.Office.Prop));
                    if (IPLInstance.FinanceOrganization.Office.Movie is null)
                        IPLInstance.FinanceOrganization.Office.Movie = new("ORGANISATION_NAME");
                    IPLInstance.FinanceOrganization.Office.Stage = 1;
                    break;
                case 1:
                    if (IPLInstance.FinanceOrganization.Office.Movie.IsLoaded)
                    {
                        BeginScaleformMovieMethod(IPLInstance.FinanceOrganization.Office.Movie.Handle, "SET_ORGANISATION_NAME");
                        ScaleformMovieMethodAddParamTextureNameString_2(name);
                        ScaleformMovieMethodAddParamInt((int)style);
                        ScaleformMovieMethodAddParamInt((int)color);
                        ScaleformMovieMethodAddParamInt((int)font);
                        EndScaleformMovieMethod();
                        N_0x32f34ff7f617643b(IPLInstance.FinanceOrganization.Office.Movie.Handle, 1);
                        IPLInstance.FinanceOrganization.Office.Stage = 2;
                    }
                    else IPLInstance.FinanceOrganization.Office.Movie = new("ORGANISATION_NAME");
                    break;
                case 2:
                    SetTextRenderId(IPLInstance.FinanceOrganization.Office.RenderId);
                    SetScriptGfxDrawOrder(4);
                    SetScriptGfxDrawBehindPausemenu(true);
                    SetScriptGfxAlign(73, 73);
                    //IPLInstance.FinanceOrganization.Office.Movie.Render2D();
                    DrawScaleformMovie(IPLInstance.FinanceOrganization.Office.Movie.Handle, 0.196f, 0.245f, 0.46f, 0.66f, 255, 255, 255, 255, 0);
                    SetTextRenderId(1);
                    ScreenDrawPositionEnd();
                    break;
            }
        }
    }

    public class GlobalIPLEnablers
    {
        public int CurrentInteriorId = 0;
        public GTAOnline Online = new();
        public HighLife HighLife = new();
        public BikersClubHouse Biker = new();
        public FinanceOffices FinanceOffices = new();
        public Diamond DiamondDlc = new();
        public void ResetInteriorVariables()
        {
            Online.isInsideApartmentHi1 = false;
            Online.isInsideApartmentHi2 = false;
            Online.isInsideHouseHi1 = false;
            Online.isInsideHouseHi2 = false;
            Online.isInsideHouseHi3 = false;
            Online.isInsideHouseHi4 = false;
            Online.isInsideHouseHi5 = false;
            Online.isInsideHouseHi6 = false;
            Online.isInsideHouseHi7 = false;
            Online.isInsideHouseHi8 = false;
            Online.isInsideHouseLow1 = false;
            Online.isInsideHouseMid1 = false;
            Biker.isInsideClubhouse1 = false;
            Biker.isInsideClubhouse2 = false;
            FinanceOffices.isInsideOffice1 = false;
            FinanceOffices.isInsideOffice2 = false;
            FinanceOffices.isInsideOffice3 = false;
            FinanceOffices.isInsideOffice4 = false;
            HighLife.isInsideApartment1 = false;
            HighLife.isInsideApartment2 = false;
            HighLife.isInsideApartment3 = false;
            HighLife.isInsideApartment4 = false;
            HighLife.isInsideApartment5 = false;
            HighLife.isInsideApartment6 = false;
            DiamondDlc.IsInCasino = false;
            DiamondDlc.IsInPenthouse = false;
            if (IPLInstance.DiamondCasino.ExpositionVeh is not null) IPLInstance.DiamondCasino.DeleteVehicle();
            IPLInstance.DiamondCasino.RenderWalls(false);

        }
        public bool IsAnyInteriorActive =>
            Online.isInsideApartmentHi1 ||
            Online.isInsideApartmentHi2 ||
            Online.isInsideHouseHi1 ||
            Online.isInsideHouseHi2 ||
            Online.isInsideHouseHi3 ||
            Online.isInsideHouseHi4 ||
            Online.isInsideHouseHi5 ||
            Online.isInsideHouseHi6 ||
            Online.isInsideHouseHi7 ||
            Online.isInsideHouseHi8 ||
            Online.isInsideHouseLow1 ||
            Online.isInsideHouseMid1 ||
            Biker.isInsideClubhouse1 ||
            Biker.isInsideClubhouse2 ||
            FinanceOffices.isInsideOffice1 ||
            FinanceOffices.isInsideOffice2 ||
            FinanceOffices.isInsideOffice3 ||
            FinanceOffices.isInsideOffice4 ||
            HighLife.isInsideApartment1 ||
            HighLife.isInsideApartment2 ||
            HighLife.isInsideApartment3 ||
            HighLife.isInsideApartment4 ||
            HighLife.isInsideApartment5 ||
            HighLife.isInsideApartment6 ||
            DiamondDlc.IsInCasino ||
            DiamondDlc.IsInPenthouse;
    }

    public class GTAOnline
    {
        public bool isInsideApartmentHi1 { get; set; }
        public bool isInsideApartmentHi2 { get; set; }
        public bool isInsideHouseHi1 { get; set; }
        public bool isInsideHouseHi2 { get; set; }
        public bool isInsideHouseHi3 { get; set; }
        public bool isInsideHouseHi4 { get; set; }
        public bool isInsideHouseHi5 { get; set; }
        public bool isInsideHouseHi6 { get; set; }
        public bool isInsideHouseHi7 { get; set; }
        public bool isInsideHouseHi8 { get; set; }
        public bool isInsideHouseLow1 { get; set; }
        public bool isInsideHouseMid1 { get; set; }
    }
    public class HighLife
    {
        public bool isInsideApartment1 { get; set; }
        public bool isInsideApartment2 { get; set; }
        public bool isInsideApartment3 { get; set; }
        public bool isInsideApartment4 { get; set; }
        public bool isInsideApartment5 { get; set; }
        public bool isInsideApartment6 { get; set; }
    }
    public class BikersClubHouse
    {
        public bool isInsideClubhouse1 { get; set; }
        public bool isInsideClubhouse2 { get; set; }
    }
    public class FinanceOffices
    {
        public bool isInsideOffice1 { get; set; }
        public bool isInsideOffice2 { get; set; }
        public bool isInsideOffice3 { get; set; }
        public bool isInsideOffice4 { get; set; }
    }
    public class Diamond
    {
        public bool IsInCasino { get; set; }
        public bool IsInPenthouse { get; set; }
    }
}