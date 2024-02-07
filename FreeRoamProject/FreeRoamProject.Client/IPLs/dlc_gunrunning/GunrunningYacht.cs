using System.Collections.Generic;
using FreeRoamProject.Client.IPLs.dlc_heists;

namespace FreeRoamProject.Client.IPLs.dlc_gunrunning
{
    public class GunrunningYacht
    {
        private bool _enabled = false;
        public List<string> ipl =
        [
            "gr_heist_yacht2",
            "gr_heist_yacht2_bar",
            "gr_heist_yacht2_bar_lod",
            "gr_heist_yacht2_bedrm",
            "gr_heist_yacht2_bedrm_lod",
            "gr_heist_yacht2_bridge",
            "gr_heist_yacht2_bridge_lod",
            "gr_heist_yacht2_enginrm",
            "gr_heist_yacht2_enginrm_lod",
            "gr_heist_yacht2_lod",
            "gr_heist_yacht2_lounge",
            "gr_heist_yacht2_lounge_lod",
            "gr_heist_yacht2_slod",
        ];
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                IplManager.EnableIpl(ipl, _enabled);
            }
        }
        public YacthWater Water = new(new Vector4(-1369.0f, 6736.0f, 5.40f, 5.0f));

        public void LoadDefault()
        {
            Enabled = true;
        }
    }
}
