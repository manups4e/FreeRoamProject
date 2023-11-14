using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    //YEAH.. THIS HANDLES ALL THE TICKS IN CLIENT.. DISABLING/RE-ENABLING THEM WHEN ENTERING A VEHICLE OR EXITING IT.. THINGS LIKE THIS..
    //we need this 😭 
    internal static class TickController
    {
        /// <summary>
        /// Ticks that are activated only when ped is on foot
        /// </summary>
        public static List<Func<Task>> TickOnFoot = new();
        /// <summary>
        /// Ticks that are activated only when ped is in a vehicle (wether it's a driver or a passenger)
        /// </summary>
        public static List<Func<Task>> TickOnVehicle = new();
        /// <summary>
        /// Ticks that are activated only when ped is instanced (when GetInteriorFromEntity(ped) != 0)
        /// </summary>
        public static List<Func<Task>> TickApartments = new();
        /// <summary>
        /// Ticks relative to HUD and OnScreen elements, (usually always active)
        /// </summary>
        public static List<Func<Task>> TickHUD = new();
        /// <summary>
        /// Ticks for all purposes, always active
        /// </summary>
        public static List<Func<Task>> TickGenerics = new();
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += Spawned;
            /*
                // TICK HUD \\
                TickHUD.Add(EventsPersonalMenu.ShowMeStatus);

                // TICK GENERICI \\ ATTIVI SEMPRE
                TickGenerics.Add(StatsNeeds.StatsSkillHandler);
                //TickGenerici.Add(StatsNeeds.Agg);
                TickGenerics.Add(Main.MainTick);
                TickGenerics.Add(PersonalMenu.Enable);
                TickGenerics.Add(FuelClient.FuelCount);
                TickGenerics.Add(FuelClient.FuelTruck);
                TickGenerics.Add(GasStationsClient.BusinessesPumps);
                TickGenerics.Add(ProximityChat.Proximity);

                // TICK A PIEDI \\
                TickOnFoot.Add(BankingClient.CheckATM);
                //TickAPiedi.Add(BankingClient.Markers);
                TickOnFoot.Add(Death.Injuried);
                //TickAPiedi.Add(NegozioAbitiClient.OnTick);
                //TickAPiedi.Add(NegoziClient.OnTick);
                TickOnFoot.Add(BarberClient.Chairs);
                //TickAPiedi.Add(VeicoliClient.MostraMenuAffitto);
                TickOnFoot.Add(MedicsMainClient.MarkersNotMedics);
                TickOnFoot.Add(TowingClient.StartJob);
                TickOnFoot.Add(VendingMachines.VendingMachinesTick);
                TickOnFoot.Add(VendingMachines.ControlMachines);
                TickOnFoot.Add(PickupsClient.PickupsMain);
                TickOnFoot.Add(TrashBins.TrashBinsTick);
                TickOnFoot.Add(TrashBins.CheckTrash);
                TickOnFoot.Add(HunterClient.HuntCheck);
                //TickAPiedi.Add(PescatoreClient.ControlloPesca);
                //TickAPiedi.Add(Hotels.ControlloHotel);
                TickOnFoot.Add(GameMode.ROLEPLAY.Properties.Manager.MarkerOutside);
                TickOnFoot.Add(SittingAnimations.CheckChair);
                TickOnFoot.Add(SittingAnimations.ChairsSit);
                TickOnFoot.Add(CarDealer.Markers);
                TickOnFoot.Add(LootingDead.Looting);

                // TICK NEL VEICOLO \\
                TickOnVehicle.Add(VehicleDamage.OnTick);
                if (VehicleDamage.torqueMultiplierEnabled || VehicleDamage.preventVehicleFlip || VehicleDamage.limpMode) TickOnVehicle.Add(VehicleDamage.IfNeeded);
                TickOnVehicle.Add(VehiclesClient.Lux);
                TickOnVehicle.Add(VehiclesClient.vehHandle);
                TickOnVehicle.Add(Prostitutes.LoopProstitutes);
                TickOnVehicle.Add(Prostitutes.CheckProstitutes);
                TickOnVehicle.Add(WheelsEffects.WheelCheck);
                TickOnVehicle.Add(WheelsEffects.WheelGlow);

                // TICK APPARTAMENTO \\
                TickApartments.Add(SittingAnimations.HouseCouches);
                TickApartments.Add(Showers.CheckShowersNear);
                TickApartments.Add(Showers.Shower);
                TickApartments.Add(Beds.CheckBeds);
                TickApartments.Add(Manager.MarkerInside);
            */
        }

        private static void Spawned(PlayerClient client)
        {
            TickGenerics.ForEach(ClientMain.Instance.AddTick);
            TickOnFoot.ForEach(ClientMain.Instance.AddTick);
            TickHUD.ForEach(ClientMain.Instance.AddTick);

            VehicleChecker.OnPedEnteredVehicle += VehicleChecker_OnPedEnteredVehicle;
            VehicleChecker.OnPedLeftVehicle += VehicleChecker_OnPedLeftVehicle;
            ClientMain.Instance.StateBagsHandler.OnInstanceBagChange += StateBagsHandler_OnInstanceBagChange;
            //ClientMain.Instance.AddTick(TickHandler);
        }

        private static void StateBagsHandler_OnInstanceBagChange(int userId, InstanceBag value)
        {
            if (value.Instanced)
            {
                TickOnFoot.ForEach(ClientMain.Instance.RemoveTick);
                // TODO: HANDLE GARAGES 
                TickApartments.ForEach(ClientMain.Instance.AddTick);
            }
            else
            {
                TickApartments.ForEach(ClientMain.Instance.RemoveTick);
                // TODO: HANDLE GARAGES 
                TickOnFoot.ForEach(ClientMain.Instance.AddTick);
            }
        }

        private static void VehicleChecker_OnPedLeftVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex)
        {
            TickOnVehicle.ForEach(ClientMain.Instance.RemoveTick);
            TickOnFoot.ForEach(ClientMain.Instance.AddTick);
        }

        private static void VehicleChecker_OnPedEnteredVehicle(Ped ped, Vehicle vehicle, VehicleSeat seatIndex)
        {
            TickOnFoot.ForEach(ClientMain.Instance.RemoveTick);
            TickOnVehicle.ForEach(ClientMain.Instance.AddTick);
        }

        private static async Task TickHandler()
        {
            // Taken from my MultiMode gamemode, do we enable a cinematic mode? (with blackbars and everything)
            /*
            if (CinemaMode)
            {
                if (!_hideHud)
                {
                    TickHUD.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    //ClientMain.Instance.AddTick(EventsPersonalMenu.CinematicMode);
                    _hideHud = true;
                }
            }
            else
            {
                if (_hideHud)
                {
                    TickHUD.ForEach(x => ClientMain.Instance.AddTick(x));
                    //ClientMain.Instance.RemoveTick(EventsPersonalMenu.CinematicMode);
                    _hideHud = false;
                }
            }
            */
            await BaseScript.Delay(250);
            // 4 time per second is enough.. it's not necessary to be "immediate" switching
        }

        // TODO: MOVE THIS ON ITS RIGHT PATH
        // NOT COMPLETE, WE NEED ALL THE INTERIORS TO BE CHECKED
        // AND ALSO TO CHECK IF THE CURRENT INTERIOR IS VISIBLE ON STREETS OR LIKE A BUNKER
        // TO CONCEAL OR NOT PLAYERS
        private static bool CheckApartment(int iParam1)
        {
            return iParam1 switch
            {
                227329 or 227585 or 206337 or 208385 or 207361 or 207873 or
                208129 or 207617 or 206081 or 146689 or 147201 or 146177 or
                227841 or 206593 or 207105 or 146945 or 145921 or 143873 or
                243201 or 148225 or 144641 or 144129 or 144385 or 141825 or
                141569 or 145409 or 145665 or 143617 or 143105 or 142593 or
                141313 or 147969 or 142849 or 143361 or 144897 or 145153 or 149761 => true,
                _ => false,
            };
        }
    }
}