namespace FreeRoamProject.Client.IPLs.dlc_import_export
{
    public class ImportCEOGarage1 : ImportCEOGarage
    {
        public ImportCEOGarage1() : base()
        {
            Part = new GaragePart()
            {
                Garage1 = new Garage(253441, "imp_dt1_02_cargarage_a"),
                Garage2 = new Garage(253697, "imp_dt1_02_cargarage_b"),
                Garage3 = new Garage(253953, "imp_dt1_02_cargarage_c"),
                ModShop = new GarageModShop(254209, "imp_dt1_02_modgarage")
            };
            Style = new GarageStyle();
            Numbering = new GarageNumbering();
            Lighting = new GarageLighting();
        }
    }
}
