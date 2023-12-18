using FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Data;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    public class PropertyBase
    {
        public const string SET_DATA_SLOT = "SET_DATA_SLOT";
        public const string APPEND_OFFICE_DATA_SLOT = "APPEND_OFFICE_DATA_SLOT";

        public const int OWNED_CLUBHOUSE_DATA_INDEX = 0;
        public const int OWNED_BUNKER_DATA_INDEX = 15;
        public const int OWNED_HANGAR_DATA_INDEX = 47;
        public const int OWNED_BASE_DATA_INDEX = 60;
        public const int OWNED_NIGHTCLUB_DATA_INDEX = 70;
        public const int OWNED_ARCADE_DATA_INDEX = 90;

        public int Slot;
        public int Id;
        public string Name;
        public eOfficePropertyType OfficeType;
        public Vector3 Position = Vector3.Zero;
        public string Texture;
        public string Description;
        public string Address;
        public int BaseCost = -1;
        public int BaseSaleCost = -1;

        public PropertyBase(int slot, int id)
        {
            Slot = slot;
            Id = id;
        }
    }
}
