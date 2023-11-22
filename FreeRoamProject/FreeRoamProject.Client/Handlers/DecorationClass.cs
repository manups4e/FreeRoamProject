using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client
{
    [Obsolete("not needed anymore since statebags (yeah this class was made in 2018 when statebags were not even being imagined)")]
    internal static class DecorationClass
    {
        public static async void DeclareDecors()
        {
            /* DECOR GENERICI */
            EntityDecoration.RegisterProperty("NuovaGM2019fighissimo!yeah!", DecorationType.Int);
            EntityDecoration.RegisterProperty("Testdecor", DecorationType.Int);
            /* DECOR VEICOLI */
            EntityDecoration.RegisterProperty("tlg_fuel", DecorationType.Float);
            EntityDecoration.RegisterProperty("VehiclePolice", DecorationType.Int);
            EntityDecoration.RegisterProperty("MedicsVehicle", DecorationType.Int);
            EntityDecoration.RegisterProperty("VeicoloRimozione", DecorationType.Int);
            EntityDecoration.RegisterProperty("VeicoloPersonale", DecorationType.Int);
            /* DECOR PICKUP */
            EntityDecoration.RegisterProperty("PickupOggetto", DecorationType.Int);
            EntityDecoration.RegisterProperty("PickupAccount", DecorationType.Int);
            EntityDecoration.RegisterProperty("PickupArma", DecorationType.Int);
            /* DECOR LOCK */
            EntityDecoration.LockProperties();

            await Cache.PlayerCache.Loaded();
            await Task.FromResult(0);
        }

        public static void Stop()
        {
        }
    }
}