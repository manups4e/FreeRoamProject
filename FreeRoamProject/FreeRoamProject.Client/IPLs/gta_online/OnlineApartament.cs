using CitizenFX.Core.Native;

namespace FreeRoamProject.Client.IPLs.gta_online
{
    public class OnlineApartament
    {
        public int InteriorId;
        public Style Strip { get; set; }
        public Style Booze { get; set; }
        public Style Smoke { get; set; }

        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                IplManager.EnableInterior(InteriorId, value);
            }
        }


        public virtual void LoadDefault()
        {
            Strip.Enable(Strip.Stage1, false);
            Strip.Enable(Strip.Stage2, false);
            Strip.Enable(Strip.Stage3, false);
            Booze.Enable(Booze.Stage1, false);
            Booze.Enable(Booze.Stage2, false);
            Booze.Enable(Booze.Stage3, false);
            Smoke.Enable(Smoke.Stage1, false);
            Smoke.Enable(Smoke.Stage2, false);
            Smoke.Enable(Smoke.Stage3, false);
            API.RefreshInterior(InteriorId);
        }
    }
}
