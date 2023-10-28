namespace FreeRoamProject.Client.IPLs.dlc_finance
{
    public class FinanceOffice1 : FinanceOffice
    {
        public override OfficeFinanceStyle Style { get => base.Style; set => base.Style = value; }
        public override OfficeCassaForte Safe { get => base.Safe; set => base.Safe = value; }
        public FinanceOffice1() : base()
        {
            Style = new()
            {
                Warm = new(236289, "ex_dt1_02_office_01a", "ex_prop_safedoor_office1a"),
                Classical = new(236545, "ex_dt1_02_office_01b", "ex_prop_safedoor_office1b"),
                Vintage = new(236801, "ex_dt1_02_office_01c", "ex_prop_safedoor_office1c"),
                Contrast = new(237057, "ex_dt1_02_office_02a", "ex_prop_safedoor_office2a"),
                Rich = new(237313, "ex_dt1_02_office_02b", "ex_prop_safedoor_office2a"),
                Cool = new(237569, "ex_dt1_02_office_02c", "ex_prop_safedoor_office2a"),
                Ice = new(237825, "ex_dt1_02_office_03a", "ex_prop_safedoor_office3a"),
                Conservative = new(238081, "ex_dt1_02_office_03b", "ex_prop_safedoor_office3a"),
                Polished = new(238337, "ex_dt1_02_office_03c", "ex_prop_safedoor_office3c"),
            };
            Safe = new()
            {
                DoorHeadingL = 96f,
                Position = new Vector3(-124.25f, -641.30f, 168.870f),
            };
        }
    }
}
