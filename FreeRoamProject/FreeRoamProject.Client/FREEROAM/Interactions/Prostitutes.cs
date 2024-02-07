using FreeRoamProject.Client.Handlers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Interactions
{
    public static class Prostitutes
    {
        private static Ped _hooker;
        private static readonly float ProstDistance = 10f;
        private static bool prosOnVeh = false;
        private static readonly List<string> Scenarios = [];
        private static bool havingSex = false;
        private static int currentSexType = -1;
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += AccessingEvents_OnFreeRoamSpawn;
            AccessingEvents.OnFreeRoamLeave += AccessingEvents_OnFreeRoamLeave;
        }

        private static void AccessingEvents_OnFreeRoamLeave(PlayerClient client)
        {
            TickController.TickOnVehicle.Remove(CheckProstitutes);
            TickController.TickOnVehicle.Remove(LoopProstitutes);
        }

        private static void AccessingEvents_OnFreeRoamSpawn(PlayerClient client)
        {
            TickController.TickOnVehicle.Add(CheckProstitutes);
            TickController.TickOnVehicle.Add(LoopProstitutes);
        }

        public static async Task CheckProstitutes()
        {
            _hooker = World.GetAllPeds().Select(o => new Ped(o.Handle)).Where(o => IsPedUsingScenario(o.Handle, "WORLD_HUMAN_PROSTITUTE_LOW_CLASS") || IsPedUsingScenario(o.Handle, "WORLD_HUMAN_PROSTITUTE_HIGH_CLASS")).FirstOrDefault(o => Vector3.Distance(Cache.PlayerCache.MyClient.Position.ToVector3, o.Position) < ProstDistance);
            await BaseScript.Delay(200);
        }

        public static async Task LoopProstitutes()
        {
            Ped playerPed = Cache.PlayerCache.MyClient.Ped;
            Vehicle currentVeh = playerPed.CurrentVehicle;

            if (_hooker != null)
            {
                if (_hooker.IsPlayer) return;

                if (Cache.PlayerCache.MyClient.Status.PlayerStates.InVehicle && currentVeh.GetPedOnSeat(VehicleSeat.Passenger) != _hooker && currentVeh.IsStopped)
                {
                    Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_ACCEPT"));

                    if (Input.IsControlJustPressed(Control.VehicleHorn) || Input.IsControlJustPressed(Control.Context))
                    {
                        if (Cache.PlayerCache.MyClient.User.Money > 50f)
                        {
                            if (currentVeh.ClassType != VehicleClass.Boats && currentVeh.ClassType != VehicleClass.Cycles && currentVeh.ClassType != VehicleClass.Motorcycles && currentVeh.ClassType != VehicleClass.Helicopters && currentVeh.ClassType != VehicleClass.Military && currentVeh.ClassType != VehicleClass.Motorcycles && currentVeh.ClassType != VehicleClass.Planes && currentVeh.ClassType != VehicleClass.Trains)
                            {
                                if (currentVeh.IsStopped)
                                {
                                    if (currentVeh.IsSeatFree(VehicleSeat.Passenger))
                                    {
                                        _hooker.IsPersistent = true;
                                        _hooker.Task.EnterVehicle(currentVeh, VehicleSeat.Passenger);
                                        while (!_hooker.IsInVehicle(currentVeh)) await BaseScript.Delay(0);
                                        SetPedInVehicleContext(_hooker.Handle, Functions.HashUint("MINI_PROSTITUTE_LOW_PASSENGER"));
                                        _hooker.BlockPermanentEvents = true;
                                        prosOnVeh = true;
                                        RequestAnimDict("mini@prostitutes@sexlow_veh");
                                        RequestAnimDict("mini@prostitutes@sexnorm_veh");
                                        RequestAnimDict("mini@prostitutes@sexlow_veh_first_person");
                                        RequestAnimDict("mini@prostitutes@sexnorm_veh_first_person");
                                        RequestAnimDict("anim@mini@prostitutes@sex@veh_vstr@");
                                    }
                                }
                                if (prosOnVeh)
                                {
                                    if (!playerPed.IsSittingInVehicle())
                                    {
                                        _hooker.Task.ClearAll();
                                        ResetPedInVehicleContext(_hooker.Handle);
                                        _hooker.Task.LeaveVehicle();
                                        TaskWanderStandard(_hooker.Handle, 400000f, 0);
                                        _hooker.MarkAsNoLongerNeeded();
                                        await BaseScript.Delay(3000);
                                        if (playerPed.Weapons.Current.Hash != WeaponHash.Unarmed)
                                        {
                                            _hooker.Task.ReactAndFlee(playerPed);
                                            _hooker.MarkAsNoLongerNeeded();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (playerPed.IsDoingDriveBy || playerPed.IsInjured)
                                        {
                                            _hooker.Task.ClearAll();
                                            ResetPedInVehicleContext(_hooker.Handle);
                                            _hooker.Task.ReactAndFlee(playerPed);
                                            _hooker.MarkAsNoLongerNeeded();
                                            return;
                                        }
                                    }
                                    if (currentVeh.IsStopped)
                                    {
                                        if (havingSex)
                                        {
                                            DisableControlAction(0, 0, true);
                                            if (HasAnimEventFired(_hooker.Handle, 876132797))
                                                CarHump(playerPed.CurrentVehicle, currentSexType);
                                        }
                                        else
                                        {
                                            if (currentVeh.IsOnAllWheels && currentVeh.IsDriveable && !currentVeh.IsInWater)
                                            {
                                                if (!playerPed.IsDead)
                                                {
                                                    Vector3 coords = playerPed.Position;
                                                    Vector3 coordsPlus = coords + new Vector3(15);
                                                    Vector3 coordsMinus = coords - new Vector3(15);
                                                    if (!(IsCopPedInArea_3d(coordsMinus.X, coordsMinus.Y, coordsMinus.Z, coordsPlus.X, coordsPlus.Y, coordsPlus.Z) || IsCopVehicleInArea_3d(coordsMinus.X, coordsMinus.Y, coordsMinus.Z, coordsPlus.X, coordsPlus.Y, coordsPlus.Z)))
                                                    {
                                                        SetScenarioPedsToBeReturnedByNextCommand(true);
                                                        int ped = -1;
                                                        GetClosestPed(coords.X, coords.Y, coords.Z, 20f, true, true, ref ped, false, true, -1);
                                                        if (DoesEntityExist(ped))
                                                        {
                                                            if (!IsEntityDead(ped))
                                                            {
                                                                if (HasEntityClearLosToEntity(ped, currentVeh.Handle, 17))
                                                                {
                                                                    Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_SPOT"));
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_COPS"));
                                                        return;
                                                    }

                                                    if (NetworkGetEntityIsNetworked(currentVeh.Handle))
                                                    {
                                                        if (NetworkHasControlOfEntity(currentVeh.Handle))
                                                        {
                                                            SetVehicleDoorsLockedForAllPlayers(currentVeh.Handle, true);
                                                            SetVehicleDoorsLocked(currentVeh.Handle, 4);
                                                            //VEHICLE::SET_VEHICLE_RESPECTS_LOCKS_WHEN_HAS_DRIVER(currentVeh.Handle, true);
                                                        }
                                                    }
                                                    uint prosHash = 0;
                                                    AddRelationshipGroup("ProstituteInPlay", ref prosHash);
                                                    SetRelationshipBetweenGroups(1, prosHash, Functions.HashUint("player"));
                                                    SetPedRelationshipGroupHash(playerPed.Handle, prosHash);
                                                    UIMenu pronsMenu = new("", Game.GetGXTEntry("PROS_OPTS"), new PointF(0, 0), "", "");
                                                    pronsMenu.EnableAnimation = false;
                                                    pronsMenu.BuildingAnimation = MenuBuildingAnimation.NONE;
                                                    UIMenuItem firstopt = new(Game.GetGXTEntry("PROS_DOLLAR").Replace("~1~", "50"));
                                                    UIMenuItem secondopt = new(Game.GetGXTEntry("PROS_DOLLAR").Replace("~1~", "70"));
                                                    UIMenuItem thirdopt = new(Game.GetGXTEntry("PROS_DOLLAR").Replace("~1~", "100"));
                                                    UIMenuItem fourthopt = new(Game.GetGXTEntry("PROS_QUIT"));
                                                    if (Cache.PlayerCache.MyClient.User.Money < 70)
                                                    {
                                                        secondopt.Enabled = false;
                                                        thirdopt.Enabled = false;
                                                    }
                                                    if (Cache.PlayerCache.MyClient.User.Money > 70 && Cache.PlayerCache.MyClient.User.Money < 100)
                                                    {
                                                        thirdopt.Enabled = false;
                                                    }

                                                    pronsMenu.AddItem(firstopt);
                                                    pronsMenu.AddItem(secondopt);
                                                    pronsMenu.AddItem(thirdopt);
                                                    pronsMenu.AddItem(fourthopt);
                                                    pronsMenu.OnItemSelect += (a, b, c) =>
                                                    {
                                                        switch (c)
                                                        {
                                                            case 0:
                                                                prosBJ(_hooker);
                                                                break;
                                                            case 1:
                                                                prosSex(_hooker, "low");
                                                                break;
                                                            case 2:
                                                                prosSex(_hooker, "high");
                                                                break;
                                                            default:
                                                                Decline();
                                                                break;
                                                        }
                                                        MenuHandler.CloseAndClearHistory();
                                                    };
                                                    pronsMenu.Visible = true;
                                                }
                                            }
                                            else
                                            {
                                                Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_SPOT"));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_CAR"));
                            }
                        }
                        else
                        {
                            Notifications.ShowHelpNotification(Game.GetGXTEntry("PROS_NO_MONEY"));
                        }
                    }
                }
            }
        }

        private static string func_45() { return "mini@prostitutes@sexnorm_veh_first_person"; }

        private static string func_46() { return "mini@prostitutes@sexnorm_veh"; }

        private static string func_47() { return "mini@prostitutes@sexlow_veh_first_person"; }

        private static string func_48() { return "mini@prostitutes@sexlow_veh"; }

        private static async void prosBJ(Ped hooker)
        {
            DoSex(hooker, 0, 50);
        }

        private static async void prosSex(Ped hooker, string type)
        {
            if (type == "low")
            {
                DoSex(hooker, 1, 70);
            }
            else
            {
                DoSex(hooker, 2, 100);
            }
        }



        private static async void DoSex(Ped hooker, int type, int price)
        {
            EventDispatcher.Send("tlg:removeCharMoney", 0, price);
            if (!PlayerCache.MyClient.Ped.IsDead && !hooker.IsDead)
            {
                currentSexType = type;
                havingSex = true;
                SetScriptedAnimSeatOffset(hooker.Handle, 0.916f);

                if (type == 0)
                    PlayPedAmbientSpeechNative(hooker.Handle, "SEX_ORAL", "SPEECH_PARAMS_FORCE_SHOUTED_CLEAR");
                else
                    PlayPedAmbientSpeechNative(hooker.Handle, "SEX_GENERIC", "SPEECH_PARAMS_FORCE_SHOUTED_CLEAR");

                SexAnimation(hooker, type, true);
                SexAnimation(PlayerCache.MyClient.Ped, type, false);

                await BaseScript.Delay(2000);
                while (GetSequenceProgress(hooker.Handle) != -1) await BaseScript.Delay(0);
                havingSex = false;
            }
        }

        private static void SexAnimation(Ped ped, int tipo, bool hooker)
        {
            string dict = getDictMain(ped, false, 0, tipo);
            Vehicle veh = VehicleChecker.CurrentVehicle;
            bool bVar1 = CheckVehLayout(veh.Handle);

            int prosHandle = 0;
            OpenSequenceTask(ref prosHandle);
            TaskPlayAnim(0, dict, SexAnimationscoordinator(0, hooker, tipo != 0, bVar1), 8f, -8f, -1, 0, 0f, false, false, false);
            TaskPlayAnim(0, dict, SexAnimationscoordinator(1, hooker, tipo != 0, bVar1), 8f, -4f, -1, 0, 0f, false, false, false);
            TaskPlayAnim(0, dict, SexAnimationscoordinator(2, hooker, tipo != 0, bVar1), 8f, -4f, Floor(15000f * (1f + (3f / 2f))), 1, 0f, false, false, false);
            TaskPlayAnim(0, dict, SexAnimationscoordinator(3, hooker, tipo != 0, bVar1), 8f, -4f, -1, 0, 0f, false, false, false);
            TaskPlayAnim(0, dict, SexAnimationscoordinator(4, hooker, tipo != 0, bVar1), 4f, -2f, -1, 0, 0f, false, false, false);
            CloseSequenceTask(prosHandle);
            TaskPerformSequence(ped.Handle, prosHandle);
        }
        private static bool CheckVehLayout(int iParam0)
        {
            if (IsVehicleDriveable(iParam0, false))
            {
                switch (GetVehicleLayoutHash(iParam0))
                {
                    case -2066252141:
                    case -38413156:
                    case -782720499:
                    case 542797648:
                    case 68566729:
                    case -1887744178:
                    case -463340997:
                    case 2033852426:
                    case -1820894825:
                    case 1697345049:
                    case -635697407:
                    case -1453479140:
                    case 1837596901:
                    case 2013836096:
                    case 2071837743:
                    case 2130662788:
                    case -1546132012:
                    case 1192783831:
                    case -317944664:
                    case 570040040:
                    case 1212243433:
                    case -193022774:
                    case 510359473:
                    case -988377294:
                    case 1240573865:
                    case -627376728:
                    case 986556497:
                        return true;
                }
            }

            return false;
        }

        private static void Decline()
        {
            ResetPedInVehicleContext(_hooker.Handle);
            int seq = 0;
            TaskSequence exit = new(seq);
            exit.AddTask.LeaveVehicle(LeaveVehicleFlags.None);
            exit.AddTask.WanderAround();
            exit.Close();
            _hooker.Task.PerformSequence(exit);
            _hooker.MarkAsNoLongerNeeded();
            RemoveAnimDict("mini@prostitutes@sexlow_veh");
            RemoveAnimDict("mini@prostitutes@sexnorm_veh");
            RemoveAnimDict("mini@prostitutes@sexlow_veh_first_person");
            RemoveAnimDict("mini@prostitutes@sexnorm_veh_first_person");
            RemoveAnimDict("anim@mini@prostitutes@sex@veh_vstr@");
            SetCinematicButtonActive(true);
        }

        private static bool getCamIsFirstPerson(bool onFoot, bool inVeh)
        {
            bool res = false;
            if (onFoot) res = GetCamViewModeForContext(0) == 4;
            if (inVeh && !res)
                res = GetCamViewModeForContext(1) == 4;
            return res;
        }

        private static void CarHump(Vehicle veh, int type)
        {
            if (type == 0)
            {
                SetPadShake(0, 200, 84);
                ApplyForceToEntity(veh.Handle, 1, 0f, 0f, -0.05f, 0f, 0f, 0f, 0, true, true, true, true, false);
            }
            else
            {
                SetPadShake(0, 200, 252);
                ApplyForceToEntity(veh.Handle, 1, 0f, 0f, -0.1f, 0f, 0f, 0f, 0, true, true, true, true, false);
            }
        }

        private static string getAnim(int type)
        {
            switch (type)
            {
                case 0:
                    return "into_proposition_male";
                case 1:
                    return "into_proposition_prostitute";
                case 2:
                    return "proposition_loop_male";
                case 3:
                    return "proposition_loop_prostitute";
                case 4:
                    return "proposition_to_exit_male";
                case 5:
                    return "prop_to_sit_alt_prostitute";
                case 6:
                    return "prop_to_sit_male";
                case 7:
                    return "prop_to_sit_prostitute";
                case 8:
                    return "proposition_to_sex_p1_prostitute";
                case 9:
                    return "proposition_to_sex_p2_prostitute";
                case 10:
                    return "sex_loop_prostitute";
                case 11:
                    return "sex_to_proposition_p1_prostitute";
                case 12:
                    return "sex_to_proposition_p2_prostitute";
                case 13:
                    return "proposition_to_sex_p1_male";
                case 14:
                    return "proposition_to_sex_p2_male";
                case 15:
                    return "sex_loop_male";
                case 16:
                    return "sex_to_proposition_p1_male";
                case 17:
                    return "sex_to_proposition_p2_male";
                case 18:
                    return "proposition_to_BJ_p1_prostitute";
                case 19:
                    return "proposition_to_BJ_p2_prostitute";
                case 20:
                    return "BJ_loop_prostitute";
                case 21:
                    return "BJ_to_proposition_p1_prostitute";
                case 22:
                    return "BJ_to_proposition_p2_prostitute";
                case 23:
                    return "proposition_to_BJ_p1_male";
                case 24:
                    return "proposition_to_BJ_p2_male";
                case 25:
                    return "BJ_loop_male";
                case 26:
                    return "BJ_to_proposition_p1_male";
                case 27:
                    return "BJ_to_proposition_p2_male";
                default:
                    return "";
            }
        }

        private static string getAnim2(int type)
        {
            switch (type)
            {
                case 0:
                    return "low_car_sit_to_prop_player";
                case 1:
                    return "low_car_sit_to_prop_female";
                case 2:
                    return "low_car_prop_loop_player";
                case 3:
                    return "low_car_prop_loop_female";
                case 4:
                    return "low_car_prop_to_leave_player";
                case 5:
                    return "low_car_prop_to_sit_alt_female";
                case 6:
                    return "low_car_prop_to_sit_player";
                case 7:
                    return "low_car_prop_to_sit_female";
                case 8:
                    return "low_car_prop_to_sex_p1_female";
                case 9:
                    return "low_car_prop_to_sex_p2_female";
                case 10:
                    return "low_car_sex_loop_female";
                case 11:
                    return "low_car_sex_to_prop_p1_female";
                case 12:
                    return "low_car_sex_to_prop_p2_female";
                case 13:
                    return "low_car_prop_to_sex_p1_player";
                case 14:
                    return "low_car_prop_to_sex_p2_player";
                case 15:
                    return "low_car_sex_loop_player";
                case 16:
                    return "low_car_sex_to_prop_p1_player";
                case 17:
                    return "low_car_sex_to_prop_p2_player";
                case 18:
                    return "low_car_prop_to_bj_p1_female";
                case 19:
                    return "low_car_prop_to_bj_p2_female";
                case 20:
                    return "low_car_bj_loop_female";
                case 21:
                    return "low_car_bj_to_prop_p1_female";
                case 22:
                    return "low_car_bj_to_prop_p2_female";
                case 23:
                    return "low_car_prop_to_bj_p1_player";
                case 24:
                    return "low_car_prop_to_bj_p2_player";
                case 25:
                    return "low_car_bj_loop_player";
                case 26:
                    return "low_car_bj_to_prop_p1_player";
                case 27:
                    return "low_car_bj_to_prop_p2_player";
                default:
                    return "";
            }
        }
        private static string getDictMain(Ped prost, bool param1, int param2, int tipo)
        {
            if (!prost.IsDead)
            {
                Vehicle vv = prost.CurrentVehicle;
                if (vv.IsDriveable)
                {
                    if (CheckVehLayout(vv.Handle))
                    {
                        if (tipo == 0 || tipo == 1)
                        {
                            if ((!getCamIsFirstPerson(false, true) || param2 != 0) && !param1)
                            {
                                return "mini@prostitutes@sexlow_veh";
                            }
                            else
                            {
                                return "mini@prostitutes@sexlow_veh_first_person";
                            }
                        }
                        else
                        {
                            if ((!getCamIsFirstPerson(false, true) || param2 != 0) && !param1)
                            {
                                return "mini@prostitutes@sexnorm_veh";
                            }
                            else
                            {
                                return "mini@prostitutes@sexnorm_veh_first_person";
                            }
                        }
                    }
                    else if (vv.Model.Hash == GetHashKey("vstr"))
                    {
                        return "anim@mini@prostitutes@sex@veh_vstr@";
                    }
                }
            }
            return "mini@prostitutes@sexlow_veh";
        }
        private static string SexAnimationscoordinator(int phase, bool isHooker, bool isBj, bool isLayoutright)
        {
            string animation = "";
            switch (phase)
            {
                case 0:
                    if (isLayoutright)
                    {
                        if (isBj)
                        {
                            if (isHooker)
                                animation = getAnim2(18);
                            else
                                animation = getAnim2(23);
                        }
                        else if (isHooker)
                            animation = getAnim2(8);
                        else
                            animation = getAnim2(13);
                    }
                    else if (isBj)
                    {
                        if (isHooker)
                            animation = getAnim(18);
                        else
                            animation = getAnim(23);
                    }
                    else if (isHooker)
                        animation = getAnim(8);
                    else
                        animation = getAnim(13);
                    break;

                case 1:
                    if (isLayoutright)
                    {
                        if (isBj)
                        {
                            if (isHooker)
                                animation = getAnim2(19);
                            else
                                animation = getAnim2(24);
                        }
                        else if (isHooker)
                            animation = getAnim2(9);
                        else
                            animation = getAnim2(14);
                    }
                    else if (isBj)
                    {
                        if (isHooker)
                            animation = getAnim(19);
                        else
                            animation = getAnim(24);
                    }
                    else if (isHooker)
                        animation = getAnim(9);
                    else
                        animation = getAnim(14);
                    break;

                case 2:
                    if (isLayoutright)
                    {
                        if (isBj)
                        {
                            if (isHooker)
                                animation = getAnim2(20);
                            else
                                animation = getAnim2(25);
                        }
                        else if (isHooker)
                            animation = getAnim2(10);
                        else
                            animation = getAnim2(15);
                    }
                    else if (isBj)
                    {
                        if (isHooker)
                            animation = getAnim(20);
                        else
                            animation = getAnim(25);
                    }
                    else if (isHooker)
                        animation = getAnim(10);
                    else
                        animation = getAnim(15);
                    break;

                case 3:
                    if (isLayoutright)
                    {
                        if (isBj)
                        {
                            if (isHooker)
                                animation = getAnim2(21);
                            else
                                animation = getAnim2(26);
                        }
                        else if (isHooker)
                            animation = getAnim2(11);
                        else
                            animation = getAnim2(16);
                    }
                    else if (isBj)
                    {
                        if (isHooker)
                            animation = getAnim(21);
                        else
                            animation = getAnim(26);
                    }
                    else if (isHooker)
                        animation = getAnim(11);
                    else
                        animation = getAnim(16);
                    break;

                case 4:
                    if (isLayoutright)
                    {
                        if (isBj)
                        {
                            if (isHooker)
                                animation = getAnim2(22);
                            else
                                animation = getAnim2(27);
                        }
                        else if (isHooker)
                            animation = getAnim2(12);
                        else
                            animation = getAnim2(17);
                    }
                    else if (isBj)
                    {
                        if (isHooker)
                            animation = getAnim(22);
                        else
                            animation = getAnim(27);
                    }
                    else if (isHooker)
                        animation = getAnim(12);
                    else
                        animation = getAnim(17);
                    break;

                case 5:
                    if (isLayoutright)
                    {
                        if (isHooker)
                            animation = getAnim2(3);
                        else
                            animation = getAnim2(2);
                    }
                    else if (isHooker)
                        animation = getAnim(3);
                    else
                        animation = getAnim(2);
                    break;

                case 6:
                    break;
            }
            return animation;
        }



    }
}