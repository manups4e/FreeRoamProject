namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public class FinanceOffice3 : FinanceOffice
    {
        public override OfficeFinanceStyle Style { get => base.Style; set => base.Style = value; }
        public override OfficeCassaForte Safe { get => base.Safe; set => base.Safe = value; }
        public FinanceOffice3() : base()
        {
            Style = new()
            {
                Warm = new(240897, "ex_sm_13_office_01a", "ex_prop_safedoor_office1a"),
                Classical = new(241153, "ex_sm_13_office_01b", "ex_prop_safedoor_office1b"),
                Vintage = new(241409, "ex_sm_13_office_01c", "ex_prop_safedoor_office1c"),
                Contrast = new(241665, "ex_sm_13_office_02a", "ex_prop_safedoor_office2a"),
                Rich = new(241921, "ex_sm_13_office_02b", "ex_prop_safedoor_office2a"),
                Cool = new(242177, "ex_sm_13_office_02c", "ex_prop_safedoor_office2a"),
                Ice = new(242433, "ex_sm_13_office_03a", "ex_prop_safedoor_office3a"),
                Conservative = new(242689, "ex_sm_13_office_03b", "ex_prop_safedoor_office3a"),
                Polished = new(242945, "ex_sm_13_office_03c", "ex_prop_safedoor_office3c"),
            };
            Safe = new()
            {
                DoorHeadingL = 126f,
                Position = new Vector3(-1554.08f, -573.7122f, 108.5272f),
            };
        }
    }
}
