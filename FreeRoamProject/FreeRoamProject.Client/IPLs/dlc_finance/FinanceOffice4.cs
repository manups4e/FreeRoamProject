namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public class FinanceOffice4 : FinanceOffice
    {
        public override OfficeFinanceStyle Style { get => base.Style; set => base.Style = value; }
        public override OfficeCassaForte Safe { get => base.Safe; set => base.Safe = value; }
        public FinanceOffice4() : base()
        {
            Style = new()
            {
                Warm = new(243201, "ex_sm_15_office_01a", "ex_prop_safedoor_office1a"),
                Classical = new(243457, "ex_sm_15_office_01b", "ex_prop_safedoor_office1b"),
                Vintage = new(243713, "ex_sm_15_office_01c", "ex_prop_safedoor_office1c"),
                Contrast = new(243969, "ex_sm_15_office_02a", "ex_prop_safedoor_office2a"),
                Rich = new(244225, "ex_sm_15_office_02b", "ex_prop_safedoor_office2a"),
                Cool = new(244481, "ex_sm_15_office_02c", "ex_prop_safedoor_office2a"),
                Ice = new(244737, "ex_sm_15_office_03a", "ex_prop_safedoor_office3a"),
                Conservative = new(244993, "ex_sm_15_office_03b", "ex_prop_safedoor_office3a"),
                Polished = new(245249, "ex_sm_15_office_03c", "ex_prop_safedoor_office3c"),
            };
            Safe = new()
            {
                DoorHeadingL = 188f,
                Position = new Vector3(-1372.905f, -462.08f, 72.05f),
            };
        }
    }
}