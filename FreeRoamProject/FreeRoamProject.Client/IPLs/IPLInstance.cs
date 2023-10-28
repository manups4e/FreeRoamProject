using FreeRoamProject.Client.IPLs.dlc_afterhours;
using FreeRoamProject.Client.IPLs.dlc_bikers;
using FreeRoamProject.Client.IPLs.dlc_casino;
using FreeRoamProject.Client.IPLs.dlc_cayo_perico;
using FreeRoamProject.Client.IPLs.dlc_doomsday;
using FreeRoamProject.Client.IPLs.dlc_executive;
using FreeRoamProject.Client.IPLs.dlc_finance;
using FreeRoamProject.Client.IPLs.dlc_gunrunning;
using FreeRoamProject.Client.IPLs.dlc_heists;
using FreeRoamProject.Client.IPLs.dlc_import_export;
using FreeRoamProject.Client.IPLs.dlc_smuggler;
using FreeRoamProject.Client.IPLs.gta_online;
using FreeRoamProject.Client.IPLs.gtav;
using System.Collections.Generic;


namespace FreeRoamProject.Client.IPLs
{
    public static class IPLInstance
    {
        // TODO: figure out a more dynamic way to handle ipls.
        public static Michael Michael = new();
        public static Simeon Simeon = new();
        public static FranklinAunt FranklinAunt = new();
        public static Franklin Franklin = new();
        public static Floyd Floyd = new();
        public static TrevorsTrailer TrevorsTrailer = new();
        public static BahamaMamas BahamaMamas = new();
        public static PillboxHospital PillboxHospital = new();
        public static ZancudoGates ZancudoGates = new();
        public static Ammunations Ammunations = new();
        public static LesterFactory LesterFactory = new();
        public static StripClub StripClub = new();
        public static Graffitis Graffitis = new();
        public static UFO UFO = new();
        public static RedCarpet RedCarpet = new();
        public static NorthYankton NorthYankton = new();
        public static GTAOApartmentHi1 GTAOApartmentHi1 = new();
        public static GTAOApartmentHi2 GTAOApartmentHi2 = new();
        public static GTAOHouseHi1 GTAOHouseHi1 = new();
        public static GTAOHouseHi2 GTAOHouseHi2 = new();
        public static GTAOHouseHi3 GTAOHouseHi3 = new();
        public static GTAOHouseHi4 GTAOHouseHi4 = new();
        public static GTAOHouseHi5 GTAOHouseHi5 = new();
        public static GTAOHouseHi6 GTAOHouseHi6 = new();
        public static GTAOHouseHi7 GTAOHouseHi7 = new();
        public static GTAOHouseHi8 GTAOHouseHi8 = new();
        public static GTAOHouseMid1 GTAOHouseMid1 = new();
        public static GTAOHouseLow1 GTAOHouseLow1 = new();
        public static HLApartment1 HLApartment1 = new();
        public static HLApartment2 HLApartment2 = new();
        public static HLApartment3 HLApartment3 = new();
        public static HLApartment4 HLApartment4 = new();
        public static HLApartment5 HLApartment5 = new();
        public static HLApartment6 HLApartment6 = new();
        public static ImportCEOGarage1 ImportCEOGarage1 = new();
        public static ImportCEOGarage2 ImportCEOGarage2 = new();
        public static ImportCEOGarage3 ImportCEOGarage3 = new();
        public static ImportCEOGarage4 ImportCEOGarage4 = new();
        public static ImportVehicleWarehouse ImportVehicleWarehouse = new();
        public static SmugglerHangar SmugglerHangar = new();
        public static HeistCarrier HeistCarrier = new();
        public static HeistYacht HeistYacht = new();
        public static ExecApartment1 ExecApartment1 = new();
        public static ExecApartment2 ExecApartment2 = new();
        public static ExecApartment3 ExecApartment3 = new();
        public static FinanceOffice1 FinanceOffice1 = new();
        public static FinanceOffice2 FinanceOffice2 = new();
        public static FinanceOffice3 FinanceOffice3 = new();
        public static FinanceOffice4 FinanceOffice4 = new();
        public static BikerCocaine BikerCocaine = new();
        public static BikerCounterfeit BikerCounterfeit = new();
        public static BikerDocumentForgery BikerDocumentForgery = new();
        public static BikerMethLab BikerMethLab = new();
        public static BikerWeedFarm BikerWeedFarm = new();
        public static BikerClubhouse1 BikerClubhouse1 = new();
        public static BikerClubhouse2 BikerClubhouse2 = new();
        public static GunrunningBunker GunrunningBunker = new();
        public static GunrunningYacht GunrunningYacht = new();
        public static FinanceOrganization FinanceOrganization = new();
        public static AfterHoursNightclubs NightClub = new();
        public static Casino DiamondCasino = new();
        public static Penthouse DiamondPenthouse = new();
        // 4840.571 -5174.425 2.0
        public static Island CayoPericoIsland = new();

        public static void Init()
        {
            /*
            AccessingEvents.OnRoleplaySpawn += Spawned;
            AccessingEvents.OnRoleplayLeave += onPlayerLeft;
            */
        }

        public static void Spawned(PlayerClient client)
        {

            /*
			// ====================================================================
			// =--------------------- [GTA V: Single player] ---------------------=
			// ====================================================================

			// Michael: -802.311, 175.056, 72.8446
			Michael.LoadDefault();

			// Simeon: -47.16170 -1115.3327 26.5
			Simeon.LoadDefault();

			// Franklin's aunt: -9.96562, -1438.54, 31.1015
			FranklinAunt.LoadDefault();

			// Franklin
			Franklin.LoadDefault();

			// Floyd: -1150.703, -1520.713, 10.633
			Floyd.LoadDefault();

			// Trevor: 1985.48132, 3828.76757, 32.5
			TrevorsTrailer.LoadDefault();

			// Zancudo Gates (GTAO like): -1600.30100000, 2806.73100000, 18.79683000
			ZancudoGates.LoadDefault();

			// Other
			LesterFactory.LoadDefault();
			StripClub.LoadDefault();

			// ====================================================================
			// =-------------------------- [GTA Online] --------------------------=
			// ====================================================================

			GTAOApartmentHi1.LoadDefault();      // -35.31277 -580.4199 88.71221 (4 Integrity Way, Apt 30)
			GTAOApartmentHi2.LoadDefault();      // -1477.14 -538.7499 55.5264 (Dell Perro Heights, Apt 7)
			GTAOHouseHi1.LoadDefault();          // -169.286 486.4938 137.4436 (3655 Wild Oats Drive)
			GTAOHouseHi2.LoadDefault();          // 340.9412 437.1798 149.3925 (2044 North Conker Avenue)
			GTAOHouseHi3.LoadDefault();          // 373.023 416.105 145.7006 (2045 North Conker Avenue)
			GTAOHouseHi4.LoadDefault();          // -676.127 588.612 145.1698 (2862 Hillcrest Avenue)
			GTAOHouseHi5.LoadDefault();          // -763.107 615.906 144.1401 (2868 Hillcrest Avenue)
			GTAOHouseHi6.LoadDefault();          // -857.798 682.563 152.6529 (2874 Hillcrest Avenue)
			GTAOHouseHi7.LoadDefault();          // 120.5 549.952 184.097 (2677 Whispymound Drive) 
			GTAOHouseHi8.LoadDefault();          // -1288 440.748 97.69459 (2133 Mad Wayne Thunder)
			GTAOHouseMid1.LoadDefault();         // 347.2686 -999.2955 -99.19622
			GTAOHouseLow1.LoadDefault();         // 261.4586 -998.8196 -99.00863

			// ====================================================================
			// =------------------------ [DLC: High life] ------------------------=
			// ====================================================================
			HLApartment1.LoadDefault();          // -1468.14 -541.815 73.4442 (Dell Perro Heights, Apt 4)
			HLApartment2.LoadDefault();          // -915.811 -379.432 113.6748 (Richard Majestic, Apt 2)
			HLApartment3.LoadDefault();          // -614.86 40.6783 97.60007 (Tinsel Towers, Apt 42)
			HLApartment4.LoadDefault();          // -773.407 341.766 211.397 (EclipseTowers, Apt 3)	--------
			HLApartment5.LoadDefault();          // -18.07856 -583.6725 79.46569 (4 Integrity Way, Apt 28)
			HLApartment6.LoadDefault();          // -609.56690000 51.28212000 -183.98080

			// ====================================================================
			// =-------------------------- [DLC: Heists] -------------------------=
			// ====================================================================
			HeistCarrier.Enabled = true;       // 3082.3117, -4717.1191, 15.2622
			HeistYacht.Enabled = true;        // -2043.974,-1031.582, 11.981

			// ====================================================================
			// =--------------- [DLC: Executives & Other Criminals] --------------=
			// ====================================================================
			ExecApartment1.LoadDefault();    // -787.7805 334.9232 215.8384 (EclipseTowers, Penthouse Suite 1)
			ExecApartment2.LoadDefault();    // -773.2258 322.8252 194.8862 (EclipseTowers, Penthouse Suite 2)
			ExecApartment3.LoadDefault();    // -787.7805 334.9232 186.1134 (EclipseTowers, Penthouse Suite 3)

			// ====================================================================
			// =-------------------- [DLC: Finance  & Felony] --------------------=
			// ====================================================================
			FinanceOffice1.LoadDefault();    // -141.1987, -620.913, 168.8205 (Arcadius Business Centre)
			FinanceOffice2.LoadDefault();    // -75.8466, -826.9893, 243.3859 (Maze Bank Building)
			FinanceOffice3.LoadDefault();    // -1579.756, -565.0661, 108.523 (Lom Bank)
			FinanceOffice4.LoadDefault();    // -1392.667, -480.4736, 72.04217 (Maze Bank West)

			
			// ====================================================================
			// =-------------------------- [DLC: Bikers] -------------------------=
			// ====================================================================
			BikerCocaine.LoadDefault();          // Cocaine lockup: 1093.6, -3196.6, -38.99841
			BikerCounterfeit.LoadDefault();      // Counterfeit cash factory: 1121.897, -3195.338, -40.4025
			BikerDocumentForgery.LoadDefault();  // Document forgery: 1165, -3196.6, -39.01306
			BikerMethLab.LoadDefault();          // Meth lab: 1009.5, -3196.6, -38.99682
			BikerWeedFarm.LoadDefault();         // Weed farm: 1051.491, -3196.536, -39.14842
			BikerClubhouse1.LoadDefault();       // 1107.04, -3157.399, -37.51859
			BikerClubhouse2.LoadDefault();       // 998.4809, -3164.711, -38.90733

			// ====================================================================
			// =------------------------ [DLC: Gunrunning] -----------------------=
			// ====================================================================
			GunrunningBunker.LoadDefault();  // 892.6384, -3245.8664, -98.2645
			GunrunningYacht.LoadDefault();   // -1363.724, 6734.108, 2.44598

			// ====================================================================
			// =---------------------- [DLC: Import/Export] ----------------------=
			// ====================================================================
			ImportCEOGarage1.LoadDefault();         // Arcadius Business Centre
			ImportCEOGarage2.LoadDefault();         // Maze Bank Building /!\ Do not load parts Garage1, Garage2 and Garage3 at the same time (overlaping issues)
			ImportCEOGarage3.LoadDefault();         // Lom Bank           /!\ Do not load parts Garage1, Garage2 and Garage3 at the same time (overlaping issues)
			ImportCEOGarage4.LoadDefault();         // Maze Bank West     /!\ Do not load parts Garage1, Garage2 and Garage3 at the same time (overlaping issues)
			ImportVehicleWarehouse.LoadDefault();   // Vehicle warehouse: 994.5925, -3002.594, -39.64699


			// ====================================================================
			// =---------------------- [DLC: Smuggler's Run] ---------------------=
			// ====================================================================
			SmugglerHangar.LoadDefault();    // -1267.0 -3013.135 -49.5

			// ====================================================================
			// =-------------------- [DLC: The Doomsday Heist] -------------------=
			// ====================================================================
			DoomsdayFacility.LoadDefault();

			// ====================================================================
			// =----------------------- [DLC: After Hours] -----------------------=
			// ====================================================================
			AfterHoursNightclubs.LoadDefault();  // -1604.664, -3012.583, -78.000
			*/

            // ====================================================================
            // =------------------------ SEMPRE ATTIVI ---------------------------=
            // ====================================================================

            // Heist Jewel: -637.20159 - 239.16250 38.1
            IplManager.EnableIpl("post_hiest_unload", true);

            // Max Renda: -585.8247, -282.72, 35.45475
            IplManager.EnableIpl("refit_unload", true);

            // Heist Union Depository: 2.69689322, -667.0166, 16.1306286
            IplManager.EnableIpl("FINBANK", true);

            // Morgue: 239.75195, -1360.64965, 39.53437
            IplManager.EnableIpl(new List<string> { "Coroner_Int_on", "coronertrash" }, true);

            // Cluckin Bell: -146.3837, 6161.5, 30.2062
            IplManager.EnableIpl(new List<string> { "CS1_02_cf_onmission1", "CS1_02_cf_onmission2", "CS1_02_cf_onmission3", "CS1_02_cf_onmission4" }, true);

            // Grapeseed's farm: 2447.9, 4973.4, 47.7
            IplManager.EnableIpl(new List<string> { "farm", "farmint", "farm_lod", "farm_props", "des_farmhouse" }, true);

            // FIB lobby: 105.4557, -745.4835, 44.7548
            IplManager.EnableIpl("FIBlobby", true);

            // Billboard: iFruit
            IplManager.EnableIpl(new List<string> { "FruitBB", "sc1_01_newbill", "hw1_02_newbill", "hw1_emissive_newbill", "sc1_14_newbill", "dt1_17_newbill" }, true);

            // Lester's factory: 716.84, -962.05, 31.59
            IplManager.EnableIpl(new List<string> { "id2_14_during_door", "id2_14_during1" }, true);

            // Life Invader lobby: -1047.9, -233.0, 39.0
            IplManager.EnableIpl("facelobby", true);

            // Tunnels
            IplManager.EnableIpl("v_tunnel_hole", true);

            // Carwash: 55.7, -1391.3, 30.5
            IplManager.EnableIpl("Carwash_with_spinners", true);

            // Stadium "Fame or Shame": -248.49159240722656, -2010.509033203125, 34.57429885864258
            IplManager.EnableIpl(new List<string> { "sp1_10_real_interior", "sp1_10_real_interior_lod" }, true);

            // House in Banham Canyon: -3086.428, 339.2523, 6.3717
            IplManager.EnableIpl("ch1_02_open", true);

            // Hill Valley church - Grave: -282.46380000, 2835.84500000, 55.91446000
            IplManager.EnableIpl("lr_cs6_08_grave_closed", true);

            // Lost's trailer park: 49.49379000, 3744.47200000, 46.38629000
            IplManager.EnableIpl("methtrailer_grp1", true);

            // Garage in La Mesa(autoshop): 970.27453, -1826.56982, 31.11477
            IplManager.EnableIpl("bkr_bi_id1_23_door", true);

            // Lost safehouse: 984.1552, -95.3662, 74.50
            IplManager.EnableIpl("bkr_bi_hw1_13_int", true);

            // Raton Canyon river: -1652.83, 4445.28, 2.52
            IplManager.EnableIpl("CanyonRvrShallow", true);

            // Pillbox hospital: 307.1680, -590.807, 43.280
            IplManager.EnableIpl("rc12b_default", true);

            // Josh's house: -1117.1632080078, 303.090698, 66.52217
            IplManager.EnableIpl(new List<string> { "bh1_47_joshhse_unburnt", "bh1_47_joshhse_unburnt_lod" }, true);

            // Bahama Mamas: -1388.0013, -618.41967, 30.819599
            IplManager.EnableIpl("hei_sm_16_interior_v_bahama_milo_", true);

            // Zancudo River(need streamed content): 86.815, 3191.649, 30.463
            IplManager.EnableIpl(new List<string> { "cs3_05_water_grp1", "cs3_05_water_grp1_lod", "trv1_trail_start" }, true);

            // Cassidy Creek(need streamed content): -425.677, 4433.404, 27.3253
            IplManager.EnableIpl(new List<string> { "canyonriver01", "canyonriver01_lod" }, true);

            // Ferris wheel
            IplManager.EnableIpl("ferris_finale_anim", true);

            // Bahama Mamas: -1388.0013, -618.41967, 30.819599
            BahamaMamas.Enabled = true;
            // Pillbox hospital: 307.1680, -590.807, 43.280
            PillboxHospital.Enabled = true;

            // Graffitis
            Graffitis.Enabled = true;

            // UFO
            UFO.Hippie.Enabled = false;    // 2490.47729, 3774.84351, 2414.035
            UFO.Chiliad.Enabled = false;   // 501.52880000, 5593.86500000, 796.23250000
            UFO.Zancudo.Enabled = false;   // -2051.99463, 3237.05835, 1456.97021

            // Red Carpet: 300.5927, 199.7589, 104.3776
            RedCarpet.Enabled = true;

            // North Yankton: 3217.697, -4834.826, 111.8152
            NorthYankton.Enabled = false;
            /*
			 2 Car Garage	173.2903 -1003.600 -99.65707
	 		 6 Car Garage	197.8153 -1002.293 -99.65749
			 10 Car Garage	229.9559 -981.7928 -99.66071
		   */

            FinanceOrganization.Office.Init();
            GunrunningBunker.Exterior.Enabled = true;

            if (API.GetGameBuildNumber() >= 2060)
            {
                // casino 1100.000 220.000 -50.000
                // penthouse 976.636 70.295 115.164
                DiamondCasino.Enabled = true;
                DiamondPenthouse.Enabled = true;
            }

            // si può migliorare per rimuovere il tick fisso sempre.. 🤔
            ClientMain.Instance.AddTick(InteriorObserver.Observer);
            ClientMain.Instance.AddTick(InteriorObserver.OfficeSafeDoorHandler);
            ClientMain.Instance.AddTick(InteriorObserver.OrganizationWatchers);
        }

        public static void onPlayerLeft(PlayerClient client)
        {
            Michael.LoadDefault();
            Simeon.LoadDefault();
            FranklinAunt.LoadDefault();
            Franklin.LoadDefault();
            Floyd.LoadDefault();
            TrevorsTrailer.LoadDefault();
            BahamaMamas.Enabled = true;
            PillboxHospital.Enabled = true;
            ZancudoGates.LoadDefault();
            LesterFactory.LoadDefault();
            StripClub.LoadDefault();
            Graffitis.Enabled = false;
            UFO.Hippie.Enabled = false;
            UFO.Chiliad.Enabled = false;
            UFO.Zancudo.Enabled = false;
            RedCarpet.Enabled = false;
            NorthYankton.Enabled = false;
            GTAOApartmentHi1.LoadDefault();
            GTAOApartmentHi2.LoadDefault();
            GTAOHouseHi1.LoadDefault();
            GTAOHouseHi2.LoadDefault();
            GTAOHouseHi3.LoadDefault();
            GTAOHouseHi4.LoadDefault();
            GTAOHouseHi5.LoadDefault();
            GTAOHouseHi6.LoadDefault();
            GTAOHouseHi7.LoadDefault();
            GTAOHouseHi8.LoadDefault();
            GTAOHouseMid1.LoadDefault();
            GTAOHouseLow1.LoadDefault();
            HLApartment1.LoadDefault();
            HLApartment2.LoadDefault();
            HLApartment3.LoadDefault();
            HLApartment4.LoadDefault();
            HLApartment5.LoadDefault();
            HLApartment6.LoadDefault();
            HeistCarrier.Enabled = false;
            HeistYacht.Enabled = false;
            ExecApartment1.LoadDefault();
            ExecApartment2.LoadDefault();
            ExecApartment3.LoadDefault();
            FinanceOffice1.LoadDefault();
            FinanceOffice2.LoadDefault();
            FinanceOffice3.LoadDefault();
            FinanceOffice4.LoadDefault();
            BikerCocaine.LoadDefault();
            BikerCounterfeit.LoadDefault();
            BikerDocumentForgery.LoadDefault();
            BikerMethLab.LoadDefault();
            BikerWeedFarm.LoadDefault();
            BikerClubhouse1.LoadDefault();
            BikerClubhouse2.LoadDefault();
            ImportCEOGarage1.LoadDefault();
            ImportCEOGarage2.LoadDefault();
            ImportCEOGarage3.LoadDefault();
            ImportCEOGarage4.LoadDefault();
            ImportVehicleWarehouse.LoadDefault();
            GunrunningBunker.LoadDefault();
            GunrunningYacht.LoadDefault();
            SmugglerHangar.LoadDefault();
            DoomsdayFacility.LoadDefault();
            NightClub.LoadDefault();
            IplManager.EnableIpl("post_hiest_unload", false);
            IplManager.EnableIpl("refit_unload", false);
            IplManager.EnableIpl("FINBANK", false);
            IplManager.EnableIpl(new List<string> { "Coroner_Int_on", "coronertrash" }, false);
            IplManager.EnableIpl(new List<string> { "CS1_02_cf_onmission1", "CS1_02_cf_onmission2", "CS1_02_cf_onmission3", "CS1_02_cf_onmission4" }, false);
            IplManager.EnableIpl(new List<string> { "farm", "farmint", "farm_lod", "farm_props", "des_farmhouse" }, false);
            IplManager.EnableIpl("FIBlobby", false);
            IplManager.EnableIpl(new List<string> { "FruitBB", "sc1_01_newbill", "hw1_02_newbill", "hw1_emissive_newbill", "sc1_14_newbill", "dt1_17_newbill" }, false);
            IplManager.EnableIpl(new List<string> { "id2_14_during_door", "id2_14_during1" }, false);
            IplManager.EnableIpl("facelobby", false);
            IplManager.EnableIpl("v_tunnel_hole", false);
            IplManager.EnableIpl("Carwash_with_spinners", false);
            IplManager.EnableIpl(new List<string> { "sp1_10_real_interior", "sp1_10_real_interior_lod" }, false);
            IplManager.EnableIpl("ch1_02_open", false);
            IplManager.EnableIpl("lr_cs6_08_grave_closed", false);
            IplManager.EnableIpl("methtrailer_grp1", false);
            IplManager.EnableIpl("bkr_bi_id1_23_door", false);
            IplManager.EnableIpl("bkr_bi_hw1_13_int", false);
            IplManager.EnableIpl("CanyonRvrShallow", false);
            IplManager.EnableIpl("rc12b_default", false);
            IplManager.EnableIpl(new List<string> { "bh1_47_joshhse_unburnt", "bh1_47_joshhse_unburnt_lod" }, false);
            IplManager.EnableIpl("hei_sm_16_interior_v_bahama_milo_", false);
            IplManager.EnableIpl(new List<string> { "cs3_05_water_grp1", "cs3_05_water_grp1_lod", "trv1_trail_start" }, false);
            IplManager.EnableIpl(new List<string> { "canyonriver01", "canyonriver01_lod" }, false);
            IplManager.EnableIpl("ferris_finale_anim", false);
            ClientMain.Instance.RemoveTick(InteriorObserver.Observer);
            ClientMain.Instance.RemoveTick(InteriorObserver.OfficeSafeDoorHandler);
            ClientMain.Instance.RemoveTick(InteriorObserver.OrganizationWatchers);
        }
    }
}
