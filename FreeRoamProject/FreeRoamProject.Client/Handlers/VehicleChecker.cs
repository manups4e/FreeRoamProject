using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    public delegate void PedEnteredVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex);
    public delegate void PedLeftVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex);
    public delegate void PedEnteringVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex);
    public delegate void PedEnteringVehicleAborted(Ped ped, Vehicle vehicle);
    public static class VehicleChecker
    {
        private static bool isInVehicle = false;
        private static bool isEnteringVehicle = false;
        private static Vehicle currentVehicle;
        private static VehicleSeat currentSeat;
        public static event PedEnteredVehicle OnPedEnteredVehicle;
        public static event PedLeftVehicle OnPedLeftVehicle;
        public static event PedEnteringVehicle OnPedEnteringVehicle;
        public static event PedEnteringVehicleAborted OnPedEnteringVehicleAborted;
        public static bool IsInVehicle => isInVehicle;
        public static bool IsEnteringVehicle => isEnteringVehicle;
        public static Vehicle CurrentVehicle => currentVehicle;
        public static VehicleSeat CurrentSeat => currentSeat;

        public static async void Init()
        {
            await PlayerCache.Loaded();
            ClientMain.Instance.AddTick(VehicleCheck);
            OnPedEnteredVehicle += OnPedEnteredVehicleCheck;
            OnPedLeftVehicle += OnPedLeftVehicleCheck;
        }
        private static void OnPedLeftVehicleCheck(Ped ped, Vehicle vehicle, VehicleSeat seatIndex)
        {
            if (ped.Handle == PlayerCache.MyPlayer.Ped.Handle)
            {
                PlayerCache.MyPlayer.Status.PlayerStates.InVehicle = false;
            }
        }

        private static void OnPedEnteredVehicleCheck(Ped ped, Vehicle vehicle, VehicleSeat seat)
        {
            if (ped.Handle == PlayerCache.MyPlayer.Ped.Handle)
            {
                PlayerCache.MyPlayer.Status.PlayerStates.InVehicle = true;
            }
        }

        private static async Task VehicleCheck()
        {
            Ped me = PlayerCache.MyPlayer.Ped;
            int meHandle = me.Handle;
            if (!(isInVehicle || me.IsDead))
            {
                if (DoesEntityExist(GetVehiclePedIsTryingToEnter(meHandle)) && !isEnteringVehicle)
                {
                    int veh = GetVehiclePedIsTryingToEnter(meHandle);
                    if (NetworkGetEntityIsNetworked(veh))
                    {
                        int netId = VehToNet(veh);
                        VehicleSeat seat = (VehicleSeat)GetSeatPedIsTryingToEnter(meHandle);
                        isEnteringVehicle = true;
                        OnPedEnteringVehicle?.Invoke(me, currentVehicle, seat);
                        EventDispatcher.Send("baseevents:enteringVehicle", veh, seat, netId);
                    }
                }
                else if (!DoesEntityExist(GetVehiclePedIsTryingToEnter(meHandle)) && !me.IsInVehicle() && isEnteringVehicle)
                {
                    if (NetworkGetEntityIsNetworked(GetVehiclePedIsTryingToEnter(meHandle)))
                    {
                        OnPedEnteringVehicleAborted?.Invoke(me, currentVehicle);
                        EventDispatcher.Send("baseevents:enteringAborted");
                        isEnteringVehicle = false;
                    }
                }
                else if (me.IsInVehicle())
                {
                    if (NetworkGetEntityIsNetworked(me.CurrentVehicle.Handle))
                    {
                        isEnteringVehicle = false;
                        isInVehicle = true;
                        currentVehicle = me.CurrentVehicle;
                        currentSeat = me.SeatIndex;

                        OnPedEnteredVehicle?.Invoke(me, currentVehicle, currentSeat);
                        EventDispatcher.Send("baseevents:enteredVehicle", currentVehicle.Handle, currentSeat, currentVehicle.NetworkId);
                    }
                }
            }
            else if (isInVehicle)
            {
                if (!me.IsInVehicle() || me.IsDead)
                {
                    OnPedLeftVehicle?.Invoke(me, currentVehicle, currentSeat);
                    EventDispatcher.Send("baseevents:leftVehicle", currentVehicle.Handle, currentSeat);
                    isInVehicle = false;
                    currentVehicle = null;
                    currentSeat = 0;
                }
            }
            await BaseScript.Delay(50);
        }
    }
}
