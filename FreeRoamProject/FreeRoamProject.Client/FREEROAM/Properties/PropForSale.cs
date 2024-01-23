using FreeRoamProject.Shared.Core.ApartmentsShared;

namespace FreeRoamProject.Client.FREEROAM.Properties
{
    public class PropForSale()
    {
        public MPPropertyNonAxis locate = new();
        public Position vProp { get; set; }
        public uint saleSign { get; set; }

    }
}