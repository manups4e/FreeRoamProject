using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FreeRoamProject.Client.Handlers
{
    //YEAH.. THIS HANDLES ALL THE TICKS IN CLIENT.. DISABLING/RE-ENABLING THEM WHEN ENTERING A VEHICLE OR EXITING IT.. THINGS LIKE THIS..
    //we need this 😭 
    internal static class TickController
    {
        public static List<Func<Task>> TickOnFoot = new();
        public static List<Func<Task>> TickOnVehicle = new();
        public static List<Func<Task>> TickApartments = new();
        public static List<Func<Task>> TickHUD = new();
        public static List<Func<Task>> TickGenerics = new();

        private static bool _inAVehicle;
        private static bool _hideHud;
        private static bool _inApartment;
        private static int _timer;
        /*
        public static void Init()
        {
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
        }
        */

        private static void Spawned(PlayerClient client)
        {
            TickGenerics.ForEach(x => ClientMain.Instance.AddTick(x));
            TickOnFoot.ForEach(x => ClientMain.Instance.AddTick(x));
            TickHUD.ForEach(x => ClientMain.Instance.AddTick(x));
            //ClientMain.Instance.AddTick(TickHandler);
        }
        private static void Disconnected(PlayerClient client)
        {

            TickHUD.ForEach(x => ClientMain.Instance.RemoveTick(x));
            TickGenerics.ForEach(x => ClientMain.Instance.RemoveTick(x));
            TickOnFoot.ForEach(x => ClientMain.Instance.RemoveTick(x));
            TickOnVehicle.ForEach(x => ClientMain.Instance.RemoveTick(x));
            TickApartments.ForEach(x => ClientMain.Instance.RemoveTick(x));
            TickHUD.Clear();
            TickGenerics.Clear();
            TickOnFoot.Clear();
            TickOnVehicle.Clear();
            TickApartments.Clear();
        }

        /*
        private static async Task TickHandler()
        {
            if (Cache.PlayerCache.MyPlayer.Status.PlayerStates.InVehicle)
            {
                if (!_inAVehicle)
                {
                    TickOnFoot.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    TickOnVehicle.ForEach(x => ClientMain.Instance.AddTick(x));
                    _inAVehicle = true;
                }
            }
            else
            {
                if (_inAVehicle)
                {
                    TickOnVehicle.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    TickOnFoot.ForEach(x => ClientMain.Instance.AddTick(x));
                    VehHud.NUIBuckled(false);
                    _inAVehicle = false;
                }
            }

            if (Main.ClientConfig.CinemaMode)
            {
                if (!_hideHud)
                {
                    TickHUD.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    ClientMain.Instance.AddTick(EventsPersonalMenu.CinematicMode);
                    _hideHud = true;
                }
            }
            else
            {
                if (_hideHud)
                {
                    TickHUD.ForEach(x => ClientMain.Instance.AddTick(x));
                    ClientMain.Instance.RemoveTick(EventsPersonalMenu.CinematicMode);
                    _hideHud = false;
                }
            }

            if (Cache.PlayerCache.MyPlayer.Status.Instance.Instanced)
            {
                if (!_inApartment)
                {
                    TickOnFoot.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    // TODO: HANDLE GARAGES 
                    TickApartments.ForEach(x => ClientMain.Instance.AddTick(x));
                    _inApartment = true;
                }
            }
            else
            {
                if (_inApartment)
                {
                    TickApartments.ForEach(x => ClientMain.Instance.RemoveTick(x));
                    // TODO: HANDLE GARAGES 
                    TickOnFoot.ForEach(x => ClientMain.Instance.AddTick(x));
                    _inApartment = false;
                }
            }

            if (Cache.PlayerCache.MyPlayer.User.CurrentChar.Job.Name.ToLower() == "polizia")
            {
                if (_medics)
                {
                    ClientMain.Instance.RemoveTick(MedicsMainClient.MarkersMedics);
                    foreach (KeyValuePair<Ped, Blip> morto in MedicsMainClient.Dead) morto.Value.Delete();

                    if (MedicsMainClient.Dead.Count > 0)
                    {
                        MedicsMainClient.Dead.Clear();
                        ClientMain.Instance.RemoveTick(MedicsMainClient.DeadBlips);
                    }

                    _medics = false;
                }

                if (!_police)
                {
                    ClientMain.Instance.AddTick(PoliceMainClient.MarkersPolice);
                    ClientMain.Instance.AddTick(PoliceMainClient.MainTickPolice);
                    if (Client.Settings.RolePlay.Jobs.Police.Config.EnableBlipsPolice) ClientMain.Instance.AddTick(PoliceMainClient.EnableBlipPolice);
                    _police = true;
                }
            }
            else if (Cache.PlayerCache.MyPlayer.User.CurrentChar.Job.Name.ToLower() == "medico")
            {
                if (_police)
                {
                    ClientMain.Instance.RemoveTick(PoliceMainClient.MarkersPolice);
                    ClientMain.Instance.RemoveTick(PoliceMainClient.MainTickPolice);
                    if (Client.Settings.RolePlay.Jobs.Police.Config.EnableBlipsPolice) ClientMain.Instance.RemoveTick(PoliceMainClient.EnableBlipPolice);
                    _police = false;
                }

                if (!_medics)
                {
                    ClientMain.Instance.AddTick(MedicsMainClient.MarkersMedics);
                    ClientMain.Instance.AddTick(MedicsMainClient.DeadBlips);
                    _medics = true;
                }
            }
            else if (Cache.PlayerCache.MyPlayer.User.CurrentChar.Job.Name.ToLower() != "medico" && Cache.PlayerCache.MyPlayer.User.CurrentChar.Job.Name.ToLower() != "polizia")
            {
                if (_police)
                {
                    ClientMain.Instance.RemoveTick(PoliceMainClient.MarkersPolice);
                    ClientMain.Instance.RemoveTick(PoliceMainClient.MainTickPolice);
                    if (Client.Settings.RolePlay.Jobs.Police.Config.EnableBlipsPolice) ClientMain.Instance.RemoveTick(PoliceMainClient.EnableBlipPolice);
                    _police = false;
                }

                if (_medics)
                {
                    ClientMain.Instance.RemoveTick(MedicsMainClient.MarkersMedics);
                    foreach (KeyValuePair<Ped, Blip> morto in MedicsMainClient.Dead) morto.Value.Delete();

                    if (MedicsMainClient.Dead.Count > 0)
                    {
                        MedicsMainClient.Dead.Clear();
                        ClientMain.Instance.RemoveTick(MedicsMainClient.DeadBlips);
                    }

                    _medics = false;
                }
            }
            await BaseScript.Delay(250);
            // 4 time per second is enough.. it's not necessary to be "immediate" switching
        }
        */

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