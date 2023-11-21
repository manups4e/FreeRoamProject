using FreeRoamProject.Client.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.FREEROAM.Interactions
{
    internal static class VendingMachines
    {
        private static string anim = "MINI@SPRUNK@FIRST_PERSON";
        private static string AudioBank = "VENDING_MACHINE";
        private static float MachineRange = 1.375f;
        private static Prop VendingMachineClosest;
        private static Prop Can = new Prop((int)ObjectHash.prop_ld_can_01b);
        private static List<ObjectHash> VendingHashes = new List<ObjectHash>()
        {
            ObjectHash.prop_vend_coffe_01,
            ObjectHash.prop_vend_soda_01,
            ObjectHash.prop_vend_soda_02,
            ObjectHash.prop_vend_condom_01,
            ObjectHash.prop_vend_fags_01,
            ObjectHash.prop_vend_snak_01,
            ObjectHash.prop_vend_water_01
        };

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            AccessingEvents.OnFreeRoamLeave += onPlayerLeft;
        }

        public static void Spawned(PlayerClient client)
        {
            TickController.TickOnFoot.Add(ControlMachines);
        }
        public static void onPlayerLeft(PlayerClient client)
        {
            TickController.TickOnFoot.Remove(ControlMachines);
        }

        public static async Task ControlMachines()
        {
            if (VendingMachineClosest == null)
            {
                VendingMachineClosest = World.GetAllProps().Select(o => new Prop(o.Handle)).Where(o => VendingHashes.Contains((ObjectHash)(uint)o.Model.Hash)).FirstOrDefault(o => Cache.PlayerCache.MyClient.Position.Distance(o.Position) < MachineRange);
                await BaseScript.Delay(250);
            }
            else
            {
                if (!PlayerCache.MyClient.Ped.IsDead && !MenuHandler.IsAnyMenuOpen)
                {
                    if (VendingMachineClosest.Model.Hash == (int)ObjectHash.prop_vend_soda_01 || VendingMachineClosest.Model.Hash == (int)ObjectHash.prop_vend_soda_02)
                    {
                        Notifications.ShowHelpNotification(Game.GetGXTEntry("VENDHLP"));
                        if (Input.IsControlJustPressed(Control.Context))
                        {
                            await VendingMachinesAnim();
                        }
                    }
                }
            }
        }

        public static async Task VendingMachinesAnim()
        {
            if (Cache.PlayerCache.MyClient.User.Money > 5)
            {
                Ped playerPed = PlayerCache.MyClient.Ped;
                RequestAmbientAudioBank(AudioBank, false);
                RequestAnimDict(anim);
                while (!HasAnimDictLoaded(anim)) await BaseScript.Delay(0);
                //BaseScript.TriggerServerEvent("lprp:removemoney", 5);
                Vector3 offset = GetOffsetFromEntityInWorldCoords(VendingMachineClosest.Handle, 0f, -0.97f, 0.05f);
                playerPed.Task.LookAt(VendingMachineClosest);
                TaskGoStraightToCoord(PlayerPedId(), offset.X, offset.Y, offset.Z, 1f, 20000, VendingMachineClosest.Heading, 0.1f);
                await BaseScript.Delay(1000);
                await playerPed.Task.PlayAnimation(anim, "PLYR_BUY_DRINK_PT1", 2f, -4f, -1, (AnimationFlags)1048576, 0);
                await BaseScript.Delay(1000);
                RequestModel((uint)ObjectHash.prop_ld_can_01b);
                while (!HasModelLoaded((uint)ObjectHash.prop_ld_can_01b)) await BaseScript.Delay(0);
                if (VendingMachineClosest.Model.Hash == (int)ObjectHash.prop_vend_soda_01)
                    Can = new Prop(CreateObjectNoOffset((uint)ObjectHash.prop_ecola_can, offset.X, offset.Y, offset.Z, true, false, false));
                else if (VendingMachineClosest.Model.Hash == (int)ObjectHash.prop_vend_soda_02) Can = new Prop(CreateObjectNoOffset((uint)ObjectHash.prop_ld_can_01b, offset.X, offset.Y, offset.Z, true, false, false));
                AttachEntityToEntity(Can.Handle, PlayerPedId(), GetPedBoneIndex(PlayerPedId(), 28422), 0f, 0f, 0f, 0f, 0f, 0f, true, true, false, false, 2, true);
                SetModelAsNoLongerNeeded((uint)ObjectHash.prop_ld_can_01b);
                while (GetEntityAnimCurrentTime(PlayerPedId(), anim, "PLYR_BUY_DRINK_PT1") < 0.95f) await BaseScript.Delay(0);
                await playerPed.Task.PlayAnimation(anim, "PLYR_BUY_DRINK_PT2", 4f, -1000f, -1, (AnimationFlags)1048576, 0);
                ForcePedAiAndAnimationUpdate(PlayerPedId(), false, false);
                while (GetEntityAnimCurrentTime(PlayerPedId(), anim, "PLYR_BUY_DRINK_PT2") < 0.95f) await BaseScript.Delay(0);
                await playerPed.Task.PlayAnimation(anim, "PLYR_BUY_DRINK_PT3", 1000f, -4f, -1, (AnimationFlags)1048624, 0);
                while (GetEntityAnimCurrentTime(PlayerPedId(), anim, "PLYR_BUY_DRINK_PT3") < 0.35f) await BaseScript.Delay(0);
                Function.Call(Hash.HINT_AMBIENT_AUDIO_BANK, "VENDING_MACHINE", 0, -1);
                Can.Detach();
                Can.ApplyForce(new Vector3(6f, 10f, 2f), new Vector3(0), ForceType.MaxForceRot);
                Can.MarkAsNoLongerNeeded();
                RemoveAnimDict(anim);
                ReleaseAmbientAudioBank();
            }
            else
            {
                Notifications.ShowNotification("Not enough cash!!");
            }
        }
    }
}
