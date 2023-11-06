using FreeRoamProject.Client.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Interactions
{
    static class Beds
    {
        private static BedMid BedMid = new BedMid();
        private static BedLow BedLow = new BedLow();
        private static BedHigh BedHigh = new BedHigh();

        private static Vector3 coord = new Vector3();
        private static Vector3 rot = new Vector3();

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += AccessingEvents_OnFreeRoamSpawn;
            AccessingEvents.OnFreeRoamLeave += AccessingEvents_OnFreeRoamLeave;
        }

        private static void AccessingEvents_OnFreeRoamLeave(PlayerClient client)
        {
            TickController.TickApartments.Remove(CheckBeds);
        }

        private static void AccessingEvents_OnFreeRoamSpawn(PlayerClient client)
        {
            TickController.TickApartments.Add(CheckBeds);
        }

        public static async Task CheckBeds()
        {
            Ped playerPed = Cache.PlayerCache.MyPlayer.Ped;
            if (!IsEntityPlayingAnim(playerPed.Handle, "mp_bedmid", "f_getin_l_bighouse", 2) &&
                !IsEntityPlayingAnim(playerPed.Handle, "mp_bedmid", "f_getin_r_bighouse", 2) &&
                !IsEntityPlayingAnim(playerPed.Handle, "mp_bedmid", "f_getout_l_bighouse", 2) &&
                !IsEntityPlayingAnim(playerPed.Handle, "mp_bedmid", "f_getout_r_bighouse", 2))
            {
                if (playerPed.IsInRangeOf(BedMid.vLocal_338, 1.3f))
                {
                    if (!BedMid.ABed)
                    {
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_IN"));
                        if (Input.IsControlJustPressed(Control.Context))
                            BedMid.LayDown();
                    }
                    else
                    {
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_OUT"));
                    }
                }
                if (playerPed.IsInRangeOf(BedLow.vLocal_343, 1.3f))
                {
                    if (!BedLow.ABed)
                    {
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_IN"));
                        if (Input.IsControlJustPressed(Control.Context))
                            BedLow.LayDown();
                    }
                    else
                    {
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_OUT"));
                    }
                }

                for (int i = 0; i < BedHigh.Lista.Count; i++)
                {
                    if (playerPed.IsInRangeOf(BedHigh.Lista[i].Right1, 2f) && !BedHigh.ABedDestra && !BedHigh.ABedSinistra)
                    {
                        BedHigh.Lista[i].RotAnim = BedHigh.Lista[i].RotAnimStaticRight;
                        BedHigh.Lista[i].CoordAnim = BedHigh.Lista[i].CoordsAnimStaticRight;
                        coord = BedHigh.Lista[i].CoordAnim;
                        rot = BedHigh.Lista[i].RotAnim;
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_IN"));
                        if (Input.IsControlJustPressed(Control.Context))
                            BedHigh.Sdraiati(BedHigh.Lista[i], true);
                    }
                    else if (playerPed.IsInRangeOf(BedHigh.Lista[i].Left1, 2f) && !BedHigh.ABedDestra && !BedHigh.ABedSinistra)
                    {
                        BedHigh.Lista[i].RotAnim = BedHigh.Lista[i].RotAnimStaticLeft;
                        BedHigh.Lista[i].CoordAnim = BedHigh.Lista[i].CoordsAnimStaticLeft;
                        coord = BedHigh.Lista[i].CoordAnim;
                        rot = BedHigh.Lista[i].RotAnim;
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_IN"));
                        if (Input.IsControlJustPressed(Control.Context))
                            BedHigh.Sdraiati(BedHigh.Lista[i], false);
                    }
                    else if (BedHigh.ABedDestra || BedHigh.ABedSinistra)
                    {
                        Notifications.ShowHelpNotification(GetLabelText("SA_BED_OUT"));
                    }
                }
            }
        }
    }

    internal class BedBase
    {
        public virtual async void LayDown()
        {

        }
        public virtual async void GetOffBed()
        {

        }

        protected bool NoPedsNear(Vector3 n1, Vector3 n2)
        {
            Ped[] peds = World.GetAllPeds();
            if (peds.Length > 0)
            {
                int i;
                for (i = 0; i <= 7; i++)
                    if (!peds[i].IsInjured)
                        if (IsEntityInAngledArea(peds[i].Handle, n1.X, n1.Y, n1.Z, n2.X, n2.Y, n2.Z, 2f, false, true, 0) && peds[i].Handle != PlayerCache.MyPlayer.Ped.Handle)
                            return false;
            }
            return true;
        }

        protected bool Controllo1(Vector3 vParam0, float fParam3)
        {
            if (IsPlayerPlaying(PlayerId()))
                if (!IsPedInAnyVehicle(PlayerCache.MyPlayer.Ped.Handle, false) && !IsEntityOnFire(PlayerCache.MyPlayer.Ped.Handle) && IsPlayerControlOn(PlayerId()))
                    if (!IsExplosionInSphere(-1, vParam0.X, vParam0.Y, vParam0.Z, 2f))
                        if (IsGameplayCamRendering() && !IsCinematicCamRendering())
                            if (Controllo2(Cache.PlayerCache.MyPlayer.Ped.Position, vParam0, fParam3, false))
                                return true;
            return false;
        }

        protected bool Controllo2(Vector3 vParam0, Vector3 vParam3, float fParam6, bool bParam7)
        {
            if (fParam6 < 0f)
                fParam6 = 0f;
            if (!bParam7)
            {
                if (Math.Abs(vParam0.X - vParam3.X) <= fParam6)
                    if (Math.Abs(vParam0.Y - vParam3.Y) <= fParam6)
                        if (Math.Abs(vParam0.Z - vParam3.Z) <= fParam6)
                            return true;
            }
            else if (Math.Abs(vParam0.X - vParam3.X) <= fParam6)
            {
                if (Math.Abs(vParam0.Y - vParam3.Y) <= fParam6)
                    return true;
            }
            return false;
        }
    }

    internal class BedMid : BedBase
    {
        public string sLocal_334 = "mp_bedmid";
        public string sLocal_335 = "f_getin_l_bighouse";
        public string sLocal_336 = "f_sleep_l_loop_bighouse";
        public string sLocal_337 = "f_getout_l_bighouse";
        public Vector3 vLocal_338 = new Vector3(349.9853f, -997.8344f, -99.1952f);
        public Vector3 vLocal_342 = new Vector3(349f, -997.3587f, -100.5f);
        public Vector3 vLocal_345 = new Vector3(351.74f, -997.3587f, -97f);
        public Vector3 vLocal_348 = new Vector3(349.66f, -996.183f, -99.764f);
        public Vector3 vLocal_351 = new Vector3(0f, 0f, -3.96f);
        public int uLocal_331 = 0;
        public int uLocal_332 = 0;
        public float fLocal_341 = 43.8287f;
        public bool ABed = false;

        public override async void LayDown()
        {
            Ped playerPed = Cache.PlayerCache.MyPlayer.Ped;
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            Vector3 vVar0 = new Vector3(1.5f);
            Vector3 vVar3;
            if (GetFollowPedCamViewMode() == 4)
                SetFollowPedCamViewMode(1);


            if (Controllo1(vLocal_338, vVar0.X) && IsEntityInAngledArea(playerPed.Handle, vLocal_342.X, vLocal_342.Y, vLocal_342.Z, vLocal_345.X, vLocal_345.Y, vLocal_345.Z, 2f, false, true, 0) && NoPedsNear(vLocal_342, vLocal_345))
            {
                playerPed.Weapons.Select(WeaponHash.Unarmed);
                vLocal_338 = GetAnimInitialOffsetPosition(sLocal_334, sLocal_335, vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 0, 2);
                vVar3 = GetAnimInitialOffsetRotation(sLocal_334, sLocal_335, vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 0, 2);
                fLocal_341 = vVar3.Z;
                TaskGoStraightToCoord(playerPed.Handle, vLocal_338.X, vLocal_338.Y, vLocal_338.Z, 1f, 5000, fLocal_341, 0.05f);

                await BaseScript.Delay(2000);

                if (GetFollowPedCamViewMode() == 4)
                    SetFollowPedCamViewMode(1);

                uLocal_331 = NetworkCreateSynchronisedScene(vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 2, false, false, 1065353216, 0, 1065353216);
                NetworkAddPedToSynchronisedScene(playerPed.Handle, uLocal_331, sLocal_334, sLocal_335, 4f, -2f, 261, 0, 1148846080, 0);
                NetworkStartSynchronisedScene(uLocal_331);

                await BaseScript.Delay(1000);

                uLocal_332 = NetworkConvertSynchronisedSceneToSynchronizedScene(uLocal_331);

                while (GetSynchronizedScenePhase(uLocal_332) < 0.9f) await BaseScript.Delay(1);

                uLocal_331 = NetworkCreateSynchronisedScene(vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 2, false, true, 1065353216, 0, 1065353216);
                NetworkAddPedToSynchronisedScene(playerPed.Handle, uLocal_331, sLocal_334, sLocal_336, 8f, -2f, 261, 0, 1148846080, 0);
                NetworkStartSynchronisedScene(uLocal_331);

                uLocal_332 = NetworkConvertSynchronisedSceneToSynchronizedScene(uLocal_331);
                SetSynchronizedSceneLooped(uLocal_332, true);
                ABed = true;
                RemoveAnimDict("mp_bedmid");
            }
            else
            {
                Notifications.ShowNotification("You can't perform this action");
            }
        }

        public override async void GetOffBed()
        {
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            uLocal_331 = NetworkCreateSynchronisedScene(vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 2, false, true, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_331, sLocal_334, sLocal_336, 8f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_331);

            uLocal_331 = NetworkCreateSynchronisedScene(vLocal_348.X, vLocal_348.Y, vLocal_348.Z, vLocal_351.X, vLocal_351.Y, vLocal_351.Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_331, sLocal_334, sLocal_337, 1000f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_331);

            ABed = false;
            RemoveAnimDict("mp_bedmid");
        }
    }

    internal class BedLow : BedBase
    {
        public string sLocal_333 = "mp_bedmid";
        public string sLocal_334 = "f_getin_l_bighouse";
        public string sLocal_335 = "f_sleep_l_loop_bighouse";
        public string sLocal_336 = "f_getout_l_bighouse";
        public Vector3 vLocal_337 = new Vector3(262.9207f, -1002.98f, -100.0086f);
        public Vector3 vLocal_340 = new Vector3(261.0173f, -1002.98f, -98.0086f);
        public Vector3 vLocal_343 = new Vector3(261.8297f, -1002.928f, -99.0062f);
        public float fLocal_346 = 230.5943f;
        public Vector3 vLocal_347 = new Vector3(262.74f, -1004.344f, -99.575f);
        public Vector3 vLocal_350 = new Vector3(0f, 0f, -162.36f);
        public int uLocal_330 = 0;
        public int uLocal_331 = 0;
        public bool ABed = false;

        public async override void LayDown()
        {
            Ped playerPed = Cache.PlayerCache.MyPlayer.Ped;
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            playerPed.Weapons.Select(WeaponHash.Unarmed);
            Vector3 vVar0 = new Vector3(1.5f);
            Vector3 vVar3;
            if (GetFollowPedCamViewMode() == 4)
                SetFollowPedCamViewMode(1);

            if (Controllo1(vLocal_343, vVar0.X) && IsEntityInAngledArea(playerPed.Handle, vLocal_337.X, vLocal_337.Y, vLocal_337.Z, vLocal_340.X, vLocal_340.Y, vLocal_340.Z, 2f, false, true, 0) && NoPedsNear(vLocal_337, vLocal_340))
            {
                vLocal_343 = GetAnimInitialOffsetPosition(sLocal_333, sLocal_334, vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 0, 2);
                vVar3 = GetAnimInitialOffsetRotation(sLocal_333, sLocal_334, vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 0, 2);
                fLocal_346 = vVar3.Z;
                TaskGoStraightToCoord(playerPed.Handle, vLocal_343.X, vLocal_343.Y, vLocal_343.Z, 1f, 5000, fLocal_346, 0.05f);
                await BaseScript.Delay(2000);

                uLocal_330 = NetworkCreateSynchronisedScene(vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 2, false, false, 1065353216, 0, 1065353216);
                NetworkAddPedToSynchronisedScene(playerPed.Handle, uLocal_330, sLocal_333, sLocal_334, 4f, -2f, 261, 0, 1148846080, 0);
                NetworkStartSynchronisedScene(uLocal_330);

                await BaseScript.Delay(1000);

                uLocal_331 = NetworkConvertSynchronisedSceneToSynchronizedScene(uLocal_330);

                while (GetSynchronizedScenePhase(uLocal_331) < 0.9f) await BaseScript.Delay(1);

                uLocal_330 = NetworkCreateSynchronisedScene(vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 2, false, true, 1065353216, 0, 1065353216);
                NetworkAddPedToSynchronisedScene(playerPed.Handle, uLocal_330, sLocal_333, sLocal_335, 8f, -2f, 261, 0, 1148846080, 0);
                NetworkStartSynchronisedScene(uLocal_330);

                uLocal_331 = NetworkConvertSynchronisedSceneToSynchronizedScene(uLocal_330);
                SetSynchronizedSceneLooped(uLocal_331, true);
                ABed = true;
                RemoveAnimDict("mp_bedmid");
            }
            else
                Notifications.ShowNotification("You can't perform this action");
        }

        public async override void GetOffBed()
        {
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            uLocal_330 = NetworkCreateSynchronisedScene(vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_330, sLocal_333, sLocal_336, 2f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_330);

            uLocal_330 = NetworkCreateSynchronisedScene(vLocal_347.X, vLocal_347.Y, vLocal_347.Z, vLocal_350.X, vLocal_350.Y, vLocal_350.Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_330, sLocal_333, sLocal_336, 1000f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_330);

            ABed = false;
            RemoveAnimDict("mp_bedmid");
        }
    }

    internal class BedHigh : BedBase
    {
        public string sLocal_413 = "mp_bedmid";
        public bool ABedDestra = false;
        public bool ABedSinistra = false;

        private string func_234(bool iParam0) => !iParam0 ? "f_getin_l_bighouse" : "f_getin_r_bighouse";
        private string func_9(bool iParam0) => !iParam0 ? "f_getout_l_bighouse" : "f_getout_r_bighouse";
        private string func_272(bool iParam0) => !iParam0 ? "f_sleep_l_loop_bighouse" : "f_sleep_r_loop_bighouse";

        public class BedsCoordsAnim
        {
            public Vector3 Left1 = new Vector3(0);
            public Vector3 Left2 = new Vector3(0);
            public Vector3 CoordsAnimStaticRight = new Vector3(0);
            public Vector3 RotAnimStaticRight = new Vector3(0);
            public Vector3 CoordsAnimStaticLeft = new Vector3(0);
            public Vector3 RotAnimStaticLeft = new Vector3(0);
            public Vector3 Right1 = new Vector3(0);
            public Vector3 Right2 = new Vector3(0);
            public Vector3 CoordAnim = new Vector3(0);
            public Vector3 RotAnim = new Vector3(0);
            public Vector3 vLocal_438 = new Vector3(0);

            public float fLocal_402;

            public int uLocal_409;
            public int uLocal_410;
        }

        public List<BedsCoordsAnim> Lista = new List<BedsCoordsAnim>()
        {
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
            new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(), new BedsCoordsAnim(),
        };

        public BedHigh()
        {
            #region bed 1
            Lista[0].Left1 = new Vector3(-796.3056f, 337.3367f, 202.4136f);
            Lista[0].Left2 = new Vector3(-793.9697f, 337.3367f, 200.4136f);

            Lista[0].CoordsAnimStaticLeft = new Vector3(-795.8910f, 338.6630f, 200.8270f);
            Lista[0].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -5.7600f);

            //////////////////////////////////////////////////////////////////

            Lista[0].Right1 = new Vector3(-794.1949f, 339.9690f, 200.4136f);
            Lista[0].Right2 = new Vector3(-796.4470f, 339.9556f, 202.4136f);

            Lista[0].CoordsAnimStaticRight = new Vector3(-794.9370f, 340.6300f, 201.4280f);
            Lista[0].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 129.2400f);
            #endregion

            #region bed 2
            Lista[1].Left1 = new Vector3(126.4232f, 545.7162f, 179.5227f);
            Lista[1].Left2 = new Vector3(125.1505f, 546.0822f, 180.5208f);

            Lista[1].CoordsAnimStaticLeft = new Vector3(125.6500f, 544.4750f, 179.9700f);
            Lista[1].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -177.8400f);

            //////////////////////////////////////////////////////////////////

            Lista[1].Right1 = new Vector3(126.7189f, 542.8882f, 179.5227f);
            Lista[1].Right2 = new Vector3(124.6794f, 542.6829f, 181.5227f);

            Lista[1].CoordsAnimStaticRight = new Vector3(124.8870f, 541.9250f, 180.5120f);
            Lista[1].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -41.7600f);
            #endregion

            #region bed 3
            Lista[2].Left1 = new Vector3(-796.3056f, 337.3367f, 202.4136f);
            Lista[2].Left2 = new Vector3(-793.9697f, 337.3367f, 200.4136f);

            Lista[2].CoordsAnimStaticLeft = new Vector3(-795.8910f, 338.6630f, 200.8270f);
            Lista[2].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -5.7600f);

            //////////////////////////////////////////////////////////////////

            Lista[2].Right1 = new Vector3(-794.1949f, 339.9690f, 200.4136f);
            Lista[2].Right2 = new Vector3(-796.4470f, 339.9556f, 202.4136f);

            Lista[2].CoordsAnimStaticRight = new Vector3(-794.9370f, 340.6300f, 201.4280f);
            Lista[2].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 129.2400f);
            #endregion

            #region bed 4

            Lista[3].Left1 = new Vector3(-792.4382f, 332.6826f, 209.7966f);
            Lista[3].Left2 = new Vector3(-794.6772f, 332.6597f, 211.7966f);

            Lista[3].CoordsAnimStaticLeft = new Vector3(-793.5940f, 333.7590f, 210.2250f);
            Lista[3].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -1.0000f);

            //////////////////////////////////////////////////////////////////

            Lista[3].Right1 = new Vector3(-794.6525f, 335.1653f, 209.7966f);
            Lista[3].Right2 = new Vector3(-792.5333f, 335.1687f, 211.7966f);

            Lista[3].CoordsAnimStaticRight = new Vector3(-792.6250f, 335.8620f, 210.8130f);
            Lista[3].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 133.2000f);
            #endregion

            #region bed 5
            Lista[4].Left1 = new Vector3(-162.6263f, 484.8703f, 132.8697f);
            Lista[4].Left2 = new Vector3(-164.7478f, 484.4771f, 134.8697f);

            Lista[4].CoordsAnimStaticLeft = new Vector3(-163.4570f, 483.4740f, 133.2820f);
            Lista[4].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -166.6800f);

            //////////////////////////////////////////////////////////////////

            Lista[4].Right1 = new Vector3(-162.3055f, 482.5231f, 132.8697f);
            Lista[4].Right2 = new Vector3(-164.4513f, 482.0749f, 134.8697f);

            Lista[4].CoordsAnimStaticRight = new Vector3(-163.9880f, 481.3370f, 133.8630f);
            Lista[4].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -31.6800f);
            #endregion

            #region bed 6 
            Lista[5].Left1 = new Vector3(-796.5303f, 334.3555f, 189.7135f);
            Lista[5].Left2 = new Vector3(-796.5093f, 336.8433f, 191.7135f);

            Lista[5].CoordsAnimStaticLeft = new Vector3(-797.6820f, 335.6830f, 190.1550f);
            Lista[5].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 90f);

            //////////////////////////////////////////////////////////////////

            Lista[5].Right1 = new Vector3(-799.1369f, 334.6384f, 189.7135f);
            Lista[5].Right2 = new Vector3(-799.1272f, 336.8023f, 191.7135f);

            Lista[5].CoordsAnimStaticRight = new Vector3(-799.7870f, 336.5630f, 190.7500f);
            Lista[5].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -133.2000f);
            #endregion

            #region bed 7 
            Lista[6].Left1 = new Vector3(-1486.2543f, -3750.0811f, 4.9114f);
            Lista[6].Left2 = new Vector3(-1484.0914f, -3750.7080f, 6.9114f);

            Lista[6].CoordsAnimStaticLeft = new Vector3(-1485.1100f, -3749.3369f, 5.3490f);
            Lista[6].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -20.1600f);

            //////////////////////////////////////////////////////////////////

            Lista[6].Right1 = new Vector3(-1485.3296f, -3747.1462f, 4.9114f);
            Lista[6].Right2 = new Vector3(-1483.2997f, -3747.8845f, 6.9114f);

            Lista[6].CoordsAnimStaticRight = new Vector3(-1483.2990f, -3747.2151f, 5.9150f);
            Lista[6].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 110.5200f);
            #endregion

            #region bed 8
            Lista[7].Left1 = new Vector3(-37.348f, -577.829f, 83.908f);
            Lista[7].Left2 = new Vector3(0);

            Lista[7].CoordsAnimStaticLeft = new Vector3(-36.505f, -576.744f, 83.325f);
            Lista[7].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -5.7600f);

            //////////////////////////////////////////////////////////////////

            Lista[7].Right1 = new Vector3(-36.378f, -575.181f, 83.908f);
            Lista[7].Right2 = new Vector3(0);

            Lista[7].CoordsAnimStaticRight = new Vector3(-35.212f, -574.873f, 83.908f);
            Lista[7].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 129.2400f);
            #endregion

            #region bed 9
            Lista[8].Left1 = new Vector3(-1471.651f, -533.368f, 50.722f);
            Lista[8].Left2 = new Vector3();

            Lista[8].CoordsAnimStaticLeft = new Vector3(-1472.191f, -532.086f, 50.180f);
            Lista[8].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 25.108f);

            //////////////////////////////////////////////////////////////////

            Lista[8].Right1 = new Vector3(-1473.288f, -530.835f, 50.722f);
            Lista[8].Right2 = new Vector3();

            Lista[8].CoordsAnimStaticRight = new Vector3(-1472.49f, -530.079f, 50.722f);
            Lista[8].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 160.108f);
            #endregion

            #region bed 10
            Lista[9].Left1 = new Vector3(332.739f, 423.586f, 145.597f);
            Lista[9].Left2 = new Vector3();

            Lista[9].CoordsAnimStaticLeft = new Vector3(331.201f, 423.663f, 145.027f);
            Lista[9].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 110.858f);

            //////////////////////////////////////////////////////////////////

            Lista[9].Right1 = new Vector3(330.177f, 422.396f, 145.597f);
            Lista[9].Right2 = new Vector3();

            Lista[9].CoordsAnimStaticRight = new Vector3(329.052f, 423.713f, 145.597f);
            Lista[9].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 245.858f);
            #endregion

            #region bed 11
            Lista[10].Left1 = new Vector3(-666.368f, 586.985f, 141.596f);
            Lista[10].Left2 = new Vector3();

            Lista[10].CoordsAnimStaticLeft = new Vector3(-666.108f, 585.521f, 140.980f);
            Lista[10].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -148.091f);

            //////////////////////////////////////////////////////////////////

            Lista[10].Right1 = new Vector3(-664.561f, 584.795f, 141.596f);
            Lista[10].Right2 = new Vector3();

            Lista[10].CoordsAnimStaticRight = new Vector3(-665.775f, 583.444f, 141.596f);
            Lista[10].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -13.091f);
            #endregion

            #region bed 12
            Lista[11].Left1 = new Vector3(-769.533f, 606.518f, 140.357f);
            Lista[11].Left2 = new Vector3();

            Lista[11].CoordsAnimStaticLeft = new Vector3(-771.068f, 606.61f, 139.7f);
            Lista[11].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 100.65f);

            //////////////////////////////////////////////////////////////////

            Lista[11].Right1 = new Vector3(-772.254f, 605.558f, 140.357f);
            Lista[11].Right2 = new Vector3();

            Lista[11].CoordsAnimStaticRight = new Vector3(-773.032f, 607.057f, 140.357f);
            Lista[11].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 235.7f);
            #endregion

            #region bed 13
            Lista[12].Left1 = new Vector3(377.11f, 407.497f, 142.126f);
            Lista[12].Left2 = new Vector3();

            Lista[12].CoordsAnimStaticLeft = new Vector3(376.15f, 406.189f, 141.55f);
            Lista[12].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 158.254f);

            //////////////////////////////////////////////////////////////////

            Lista[12].Right1 = new Vector3(376.384f, 404.328f, 142.126f);
            Lista[12].Right2 = new Vector3();

            Lista[12].CoordsAnimStaticRight = new Vector3(374.698f, 404.407f, 142.126f);
            Lista[12].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 293.254f);
            #endregion

            #region bed 14
            Lista[13].Left1 = new Vector3(-851.342f, 677.081f, 149.078f);
            Lista[13].Left2 = new Vector3();

            Lista[13].CoordsAnimStaticLeft = new Vector3(-851.938f, 675.505f, 148.48f);
            Lista[13].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 175.652f);

            //////////////////////////////////////////////////////////////////

            Lista[13].Right1 = new Vector3(-851.172f, 673.765f, 149.078f);
            Lista[13].Right2 = new Vector3();

            Lista[13].CoordsAnimStaticRight = new Vector3(-852.672f, 673.127f, 149.078f);
            Lista[13].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 310.652f);
            #endregion

            #region bed 15
            Lista[14].Left1 = new Vector3(-1282.379f, 434.784f, 94.12f);
            Lista[14].Left2 = new Vector3();

            Lista[14].CoordsAnimStaticLeft = new Vector3(-1283.074f, 433.368f, 93.55f);
            Lista[14].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 173.296f);

            //////////////////////////////////////////////////////////////////

            Lista[14].Right1 = new Vector3(-1282.58f, 431.521f, 94.12f);
            Lista[14].Right2 = new Vector3();

            Lista[14].CoordsAnimStaticRight = new Vector3(-1283.985f, 431.201f, 94.12f);
            Lista[14].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 308.296f);
            #endregion

            #region bed 16
            Lista[15].Left1 = new Vector3(-1454.105f, -553.051f, 72.844f);
            Lista[15].Left2 = new Vector3();

            Lista[15].CoordsAnimStaticLeft = new Vector3(-1455.779f, -553.443f, 72.244f);
            Lista[15].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 116.586f);

            //////////////////////////////////////////////////////////////////

            Lista[15].Right1 = new Vector3(-1456.505f, -554.852f, 72.844f);
            Lista[15].Right2 = new Vector3();

            Lista[15].CoordsAnimStaticRight = new Vector3(-1457.986f, -553.75f, 72.844f);
            Lista[15].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 251.586f);
            #endregion

            #region bed 17
            Lista[16].Left1 = new Vector3(-900.271f, -368.65f, 113.074f);
            Lista[16].Left2 = new Vector3();

            Lista[16].CoordsAnimStaticLeft = new Vector3(-900.311f, -370.319f, 112.41f);
            Lista[16].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -161.872f);

            //////////////////////////////////////////////////////////////////

            Lista[16].Right1 = new Vector3(-898.859f, -371.413f, 113.074f);
            Lista[16].Right2 = new Vector3();

            Lista[16].CoordsAnimStaticRight = new Vector3(-900.623f, -372.368f, 113.074f);
            Lista[16].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -26.872f);
            #endregion

            #region bed 18
            Lista[17].Left1 = new Vector3(-593.632f, 50.102f, 97.000f);
            Lista[17].Left2 = new Vector3();

            Lista[17].CoordsAnimStaticLeft = new Vector3(-594.598f, 48.648f, 96.42f);
            Lista[17].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 173.93f);

            //////////////////////////////////////////////////////////////////

            Lista[17].Right1 = new Vector3(-593.862f, 47.186f, 97.000f);
            Lista[17].Right2 = new Vector3();

            Lista[17].CoordsAnimStaticRight = new Vector3(-595.587f, 47.005f, 97.000f);
            Lista[17].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 308.93f);
            #endregion

            #region bed 19
            Lista[18].Left1 = new Vector3(-794.366f, 332.413f, 210.797f);
            Lista[18].Left2 = new Vector3();

            Lista[18].CoordsAnimStaticLeft = new Vector3(-793.489f, 333.92f, 210.15f);
            Lista[18].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -5.7600f);

            //////////////////////////////////////////////////////////////////

            Lista[18].Right1 = new Vector3(-794.36f, 333.798f, 210.796f);
            Lista[18].Right2 = new Vector3();

            Lista[18].CoordsAnimStaticRight = new Vector3(-792.535f, 335.515f, 210.796f);
            Lista[18].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 129.2400f);
            #endregion

            #region bed 20
            Lista[19].Left1 = new Vector3(-37.216f, -583.865f, 78.83f);
            Lista[19].Left2 = new Vector3();

            Lista[19].CoordsAnimStaticLeft = new Vector3(-35.778f, -582.484f, 78.19f);
            Lista[19].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -26.482f);

            //////////////////////////////////////////////////////////////////

            Lista[19].Right1 = new Vector3(-36.00f, -580.439f, 78.83f);
            Lista[19].Right2 = new Vector3();

            Lista[19].CoordsAnimStaticRight = new Vector3(-34.211f, -581.406f, 78.83f);
            Lista[19].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 109.482f); // 173.482f
            #endregion

            #region bed 21
            Lista[20].Left1 = new Vector3(-593.862f, 50.457f, -183.581f);
            Lista[20].Left2 = new Vector3();

            Lista[20].CoordsAnimStaticLeft = new Vector3(-594.556f, 48.673f, -184.24f);
            Lista[20].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 176.435f);

            //////////////////////////////////////////////////////////////////

            Lista[20].Right1 = new Vector3(-593.975f, 46.781f, -183.582f);
            Lista[20].Right2 = new Vector3();

            Lista[20].CoordsAnimStaticRight = new Vector3(-595.67f, 46.941f, -183.582f);
            Lista[20].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 311.435f);
            #endregion

            #region bed 22
            Lista[21].Left1 = new Vector3(-796.183f, 334.538f, 220.438f);
            Lista[21].Left2 = new Vector3();

            Lista[21].CoordsAnimStaticLeft = new Vector3(-797.814f, 335.773f, 219.860f);
            Lista[21].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 90f);

            //////////////////////////////////////////////////////////////////

            Lista[21].Right1 = new Vector3(-799.276f, 334.683f, 220.438f);
            Lista[21].Right2 = new Vector3();

            Lista[21].CoordsAnimStaticRight = new Vector3(-799.754f, 336.443f, 220.438f);
            Lista[21].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, -133.2000f);
            #endregion

            #region bed 23
            Lista[22].Left1 = new Vector3(-764.761f, 323.155f, 199.487f);
            Lista[22].Left2 = new Vector3();

            Lista[22].CoordsAnimStaticLeft = new Vector3(-763.37f, 322.115f, 198.887f);
            Lista[22].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, -90f);

            //////////////////////////////////////////////////////////////////

            Lista[22].Right1 = new Vector3(-761.745f, 322.758f, 199.486f);
            Lista[22].Right2 = new Vector3();

            Lista[22].CoordsAnimStaticRight = new Vector3(-761.27f, 321.345f, 199.486f);
            Lista[22].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 45f);
            #endregion

            #region bed 24
            Lista[23].Left1 = new Vector3(-759.477f, 319.868f, 170.596f);
            Lista[23].Left2 = new Vector3();

            Lista[23].CoordsAnimStaticLeft = new Vector3(-759.983f, 318.388f, 169.956f);
            Lista[23].RotAnimStaticLeft = new Vector3(0.0000f, 0.0000f, 175.966f);

            //////////////////////////////////////////////////////////////////

            Lista[23].Right1 = new Vector3(-759.535f, 317.094f, 170.596f);
            Lista[23].Right2 = new Vector3();

            Lista[23].CoordsAnimStaticRight = new Vector3(-761.023f, 316.715f, 170.596f);
            Lista[23].RotAnimStaticRight = new Vector3(0.0000f, 0.0000f, 310.966f);
            #endregion

            /*
				#region bed 
				Lista[].Sinistra1 = new Vector3();
				Lista[].Sinistra2 = new Vector3();

				Lista[].CoordsAnimStaticSinistra = new Vector3();
				Lista[].RotAnimStaticSinistra = new Vector3(0.0000f, 0.0000f, );

				//////////////////////////////////////////////////////////////////

				Lista[].Destra1 = new Vector3();
				Lista[].Destra2 = new Vector3();

				Lista[].CoordsAnimStaticDestra = new Vector3();
				Lista[].RotAnimStaticDestra = new Vector3(0.0000f, 0.0000f, );
				#endregion
			*/



        }

        public async override void LayDown() { }
        public async void Sdraiati(BedsCoordsAnim lato, bool destra)
        {
            Ped playerPed = PlayerCache.MyPlayer.Ped;
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            Vector3 var0 = lato.CoordAnim;
            Vector3 var1 = lato.RotAnim;

            Cache.PlayerCache.MyPlayer.Ped.Weapons.Select(WeaponHash.Unarmed);
            Vector3 vVar3;
            if (GetFollowPedCamViewMode() == 4)
                SetFollowPedCamViewMode(1);

            lato.vLocal_438 = GetAnimInitialOffsetPosition(sLocal_413, func_234(destra), var0.X, var0.Y, var0.Z, var1.X, var1.Y, var1.Z, 0, 2);
            vVar3 = GetAnimInitialOffsetRotation(sLocal_413, func_234(destra), var0.X, var0.Y, var0.Z, var1.X, var1.Y, var1.Z, 0, 2);
            lato.fLocal_402 = vVar3.Z;
            TaskGoStraightToCoord(playerPed.Handle, var0.X, var0.Y, var0.Z, 1f, 5000, lato.fLocal_402, 0.05f);
            await BaseScript.Delay(2000);

            lato.uLocal_410 = NetworkCreateSynchronisedScene(var0.X, var0.Y, var0.Z, var1.X, var1.Y, var1.Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(playerPed.Handle, lato.uLocal_410, sLocal_413, func_234(destra), 4f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(lato.uLocal_410);

            await BaseScript.Delay(1000);

            lato.uLocal_409 = NetworkConvertSynchronisedSceneToSynchronizedScene(lato.uLocal_410);

            while (GetSynchronizedScenePhase(lato.uLocal_409) < 0.9f) await BaseScript.Delay(1);

            lato.uLocal_410 = NetworkCreateSynchronisedScene(var0.X, var0.Y, var0.Z, var1.X, var1.Y, var1.Z, 2, false, true, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(playerPed.Handle, lato.uLocal_410, sLocal_413, func_272(destra), 8f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(lato.uLocal_410);

            lato.uLocal_409 = NetworkConvertSynchronisedSceneToSynchronizedScene(lato.uLocal_410);
            SetSynchronizedSceneLooped(lato.uLocal_409, true);
            ABedDestra = destra;
            ABedSinistra = !destra;
            RemoveAnimDict("mp_bedmid");
        }

        public async override void GetOffBed() { }
        public async void ScendiDalBed(Vector3[] coords, bool destra)
        {
            RequestAnimDict("mp_bedmid");
            while (!HasAnimDictLoaded("mp_bedmid")) await BaseScript.Delay(0);
            int uLocal_410 = NetworkCreateSynchronisedScene(coords[0].X, coords[0].Y, coords[0].Z, coords[1].X, coords[1].Y, coords[1].Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_410, sLocal_413, func_9(destra), 2f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_410);

            uLocal_410 = NetworkCreateSynchronisedScene(coords[0].X, coords[0].Y, coords[0].Z, coords[1].X, coords[1].Y, coords[1].Z, 2, false, false, 1065353216, 0, 1065353216);
            NetworkAddPedToSynchronisedScene(PlayerCache.MyPlayer.Ped.Handle, uLocal_410, sLocal_413, func_9(destra), 1000f, -2f, 261, 0, 1148846080, 0);
            NetworkStartSynchronisedScene(uLocal_410);

            ABedDestra = false;
            ABedSinistra = false;
            RemoveAnimDict("mp_bedmid");
        }
    }
}
