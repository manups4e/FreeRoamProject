namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public class FinanceOffice2 : FinanceOffice
    {
        public override OfficeFinanceStyle Style { get => base.Style; set => base.Style = value; }
        public override OfficeCassaForte Safe { get => base.Safe; set => base.Safe = value; }
        public FinanceOffice2() : base()
        {
            Style = new()
            {
                Warm = new(238593, "ex_dt1_11_office_01a", "ex_prop_safedoor_office1a"),
                Classical = new(238849, "ex_dt1_11_office_01b", "ex_prop_safedoor_office1b"),
                Vintage = new(239105, "ex_dt1_11_office_01c", "ex_prop_safedoor_office1c"),
                Contrast = new(239361, "ex_dt1_11_office_02a", "ex_prop_safedoor_office2a"),
                Rich = new(239617, "ex_dt1_11_office_02b", "ex_prop_safedoor_office2a"),
                Cool = new(239873, "ex_dt1_11_office_02c", "ex_prop_safedoor_office2a"),
                Ice = new(240129, "ex_dt1_11_office_03a", "ex_prop_safedoor_office3a"),
                Conservative = new(240385, "ex_dt1_11_office_03b", "ex_prop_safedoor_office3a"),
                Polished = new(240641, "ex_dt1_11_office_03c", "ex_prop_safedoor_office3c"),
            };
            Safe = new()
            {
                DoorHeadingL = 250f,
                Position = new Vector3(-82.593f, -801.0f, 243.385f),
            };
        }
    }
}
