using FreeRoamProject.Client.FREEROAM.Vehicles;
using FreeRoamProject.Shared.Core.Character;
using System.Linq;

namespace FreeRoamProject.Client.Core.Utility
{
    internal class CutsceneHelper
    {
        public static bool CreateCutsceneVehicleClone(ref Vehicle newVeh, Vehicle vehToClone, Vector3 pos, float heading)
        {
            VehProp properties = null;
            if (vehToClone.IsDriveable)
            {
                properties = VehicleHandler.GetVehicleProperties(vehToClone);
            }

            if (newVeh == null || !newVeh.IsDriveable)
            {
                newVeh = new Vehicle(CreateVehicle((uint)vehToClone.Model.Hash, pos.X, pos.Y, pos.Z, heading, false, false));
                VehicleHandler.SetVehicleProperties(newVeh, properties);
                if (!newVeh.Model.IsBike)
                {
                    foreach (VehicleDoor door in vehToClone.Doors.GetAll())
                    {
                        if (door.IsBroken)
                            newVeh.Doors[(VehicleDoorIndex)vehToClone.Doors.GetAll().ToList().IndexOf(door)].Break(true);
                    }
                }
                for (int i = 0; i < vehToClone.Wheels.Count; i++)
                {
                    if (IsVehicleTyreBurst(vehToClone.Handle, i, true))
                        SetVehicleTyreBurst(newVeh.Handle, i, true, 1000f);
                    else if (IsVehicleTyreBurst(vehToClone.Handle, i, false))
                        SetVehicleTyreBurst(newVeh.Handle, i, false, 1000f);
                }
                if (!vehToClone.Model.IsBike)
                {
                    foreach (VehicleWindow wind in vehToClone.Windows.GetAllWindows())
                    {
                        if (wind.IsIntact)
                        {
                            newVeh.Windows[(VehicleWindowIndex)vehToClone.Windows.GetAllWindows().ToList().IndexOf(wind)].Remove();
                        }
                    }
                }
                CopyVehicleDamages(vehToClone.Handle, newVeh.Handle);
                if (vehToClone.Model.Hash == Functions.HashInt("dominator4") || vehToClone.Model.Hash == Functions.HashInt("dominator5") || vehToClone.Model.Hash == Functions.HashInt("dominator6"))
                {
                    if (!GetDoesVehicleHaveTombstone(vehToClone.Handle))
                    {
                        HideVehicleTombstone(newVeh.Handle, true);
                    }
                }
            }

            return newVeh.IsDriveable;
        }

        public static void MakePlayerSafeForMPCutscene(bool bLeavePedCopyBehind = true, bool bPlayerInvisible = true, bool bPlayerHasCollision = true, bool bPlayerFrozen = false, bool bClearTasks = true, bool bStopDucking = true, bool bKeepPortableObjects = false)
        {
            // disable phonecall (Disable_MP_Comms())
            Function.Call((Hash)0xBF22E0F32968E967, PlayerId(), bKeepPortableObjects);
            int eflags = 0;
            if (bPlayerInvisible)
                eflags |= 8192;
            if (bClearTasks)
                eflags |= 4;
            if (bPlayerHasCollision)
                eflags |= 16384;
            if (bPlayerFrozen)
                eflags |= 32768;
            SetPlayerControl(PlayerId(), false, eflags);
            if (bStopDucking)
                SetPedDucking(PlayerPedId(), false);
        }

        public static void StartMPCutscene(bool setInMpCutscene = true, bool makePlayerInvincible = true, bool allowCallsOverScene = false)
        {
            ClearHelp(true);
            SetWidescreenBorders(true, -1);
            DisplayRadar(false);
            DisplayHud(false);
            if (setInMpCutscene)    //This is sometimes set to false for tutorials so that the ambient population will exist
                if (!NetworkIsInMpCutscene()) // Wrapped in check to prevent John gurney's assert that fires if NETWORK_SET_IN_MP_CUTSCENE with the same value for it's agrument more than once.
                    NetworkSetInMpCutscene(true, makePlayerInvincible);
        }
        public static void CleanupMPCutscene(bool bClearHelp = true, bool bReturnPlayerControl = true, bool bPreventInvincibilityChanges = false, bool bCleanupNetworkCutscene = true)
        {
            if (bClearHelp)
            {
                ClearHelp(true);
            }
            SetParticleFxCamInsideVehicle(true);
            SetWidescreenBorders(false, -1);
            DisplayRadar(true);
            DisplayHud(true);
            if (bCleanupNetworkCutscene)
            {
                if (NetworkIsInMpCutscene())
                {
                    NetworkSetInMpCutscene(false, false);
                }
            }
            if (bReturnPlayerControl)
                SetPlayerControl(PlayerId(), true, 0);
            FreezeEntityPosition(PlayerPedId(), false);
        }
    }
}
