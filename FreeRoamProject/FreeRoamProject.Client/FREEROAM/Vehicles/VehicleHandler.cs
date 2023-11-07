using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Vehicles
{
    public static class VehicleHandler
    {
        public static async Task<VehProp> GetVehicleProperties(this Vehicle veh)
        {
            bool[] extras = new bool[13];
            for (int i = 0; i < 13; i++) extras[i] = veh.IsExtraOn(i);
            List<VehMod> mods = veh.Mods.GetAllMods().Select(mod => new VehMod((int)mod.ModType, mod.Index, mod.LocalizedModName, mod.LocalizedModTypeName)).ToList();
            VehProp vehi = new VehProp(veh.Model, veh.LocalizedName, veh.Mods.LicensePlate, (int)veh.Mods.LicensePlateStyle, veh.BodyHealth, veh.EngineHealth, veh.FuelLevel, veh.DirtLevel, (int)veh.Mods.PrimaryColor, (int)veh.Mods.SecondaryColor, veh.Mods.CustomPrimaryColor, veh.Mods.CustomSecondaryColor, veh.Mods.IsPrimaryColorCustom, veh.Mods.IsSecondaryColorCustom, (int)veh.Mods.PearlescentColor, (int)veh.Mods.RimColor, (int)veh.Mods.WheelType, (int)veh.Mods.WindowTint, new bool[4] { veh.Mods.HasNeonLight(VehicleNeonLight.Left), veh.Mods.HasNeonLight(VehicleNeonLight.Right), veh.Mods.HasNeonLight(VehicleNeonLight.Front), veh.Mods.HasNeonLight(VehicleNeonLight.Back) }, extras, veh.Mods.NeonLightsColor, veh.Mods.TireSmokeColor, !(GetVehicleModKit(veh.Handle) == 65535), mods, veh.Mods.Livery);
            return vehi;
        }

        public static async void SetVehicleProperties(this Vehicle veh, VehProp props)
        {
            veh.Mods.LicensePlate = props.Plate;
            if (props.ModKitInstalled) veh.Mods.InstallModKit();
            veh.Mods.LicensePlateStyle = (LicensePlateStyle)props.PlateIndex;
            veh.DirtLevel = props.DirtLevel;
            veh.Mods.PrimaryColor = (VehicleColor)props.PrimaryColor;
            veh.Mods.SecondaryColor = (VehicleColor)props.SecondaryColor;
            veh.Mods.CustomPrimaryColor = props.CustomPrimaryColor;
            veh.Mods.CustomSecondaryColor = props.CustomSecondaryColor;
            //veh.Mods.IsPrimaryColorCustom = props.HasCustomPrimaryColor;
            //veh.Mods.IsSecondaryColorCustom = props.HasCustomSecondaryColor;
            veh.Mods.PearlescentColor = (VehicleColor)props.PearlescentColor;
            veh.Mods.RimColor = (VehicleColor)props.WheelColor;
            veh.Mods.WheelType = (VehicleWheelType)props.Wheels;
            veh.Mods.WindowTint = (VehicleWindowTint)props.WindowTint;
            for (int i = 0; i < props.NeonEnabled.Length; i++) veh.Mods.SetNeonLightsOn((VehicleNeonLight)i, props.NeonEnabled[i]);
            for (int i = 0; i < 13; i++) veh.ToggleExtra(i, props.Extras[i]);
            veh.Mods.NeonLightsColor = props.NeonColor;
            veh.Mods.TireSmokeColor = props.TireSmokeColor;
            VehicleMod[] mods = veh.Mods.GetAllMods();
            foreach (VehMod mod in props.Mods) SetVehicleMod(veh.Handle, mod.ModIndex, mod.Value, mods.ToList().FirstOrDefault(x => (int)x.ModType == mod.ModIndex).Variation);
            veh.Mods.Livery = props.ModLivery;
        }
    }
}
