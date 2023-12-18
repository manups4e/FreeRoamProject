using System;

namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal static class VehicleLoader
    {
        private static int Global_75777 = GetHashKey("apa_mp_apa_yacht");
        private static int Global_75778 = -994826917;
        private static int Global_75779 = 886151985;
        private static int Global_75780 = -1242692076;
        private static int Global_75781 = -451225720;

        internal static bool func_7071(ref VehiclePriceData iParam0, int vehicleModel, bool bParam2, int iParam3)//Position - 0x23A5A6
        {
            bool bVar0;
            int iVar1;
            int iVar2;
            bool bVar3;

            bVar0 = true;
            if (iParam3 == 0)
            {
                bVar0 = true;
            }
            else if (iParam3 == 1)
            {
                bVar0 = false;
            }
            iVar1 = -1;
            iVar2 = -1;
            if (!IsModelAVehicle((uint)vehicleModel))
            {
                bVar3 = false;
                if (vehicleModel == Global_75779)
                {
                    iVar1 = 500000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_21751") /* Tunable: 982031447 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_21751") /* Tunable: 982031447 */;
                        }
                    }
                    bVar3 = true;
                }
                if (vehicleModel == GetHashKey("inductor") || vehicleModel == GetHashKey("inductor2"))
                {
                    bVar3 = true;
                }
                if (!bVar3)
                {
                    return false;
                }
            }
            switch ((VehicleHash)vehicleModel)
            {
                case VehicleHash.Adder:
                    iVar1 = 1000000;
                    break;

                case VehicleHash.Akuma:
                    iVar1 = 9000;
                    break;

                case VehicleHash.Asea:
                    iVar1 = 12000;
                    break;

                case VehicleHash.Asterope:
                    iVar1 = 26000;
                    break;

                case VehicleHash.Bagger:
                    iVar1 = 16000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_18100") /* Tunable: -841706086 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_18100") /* Tunable: -841706086 */;
                        }
                    }
                    break;

                case VehicleHash.Baller:
                    iVar1 = 90000;
                    break;

                case VehicleHash.Baller2:
                    iVar1 = 90000;
                    break;

                case VehicleHash.Banshee:
                    iVar1 = 90000;
                    break;

                case VehicleHash.Bati:
                    iVar1 = 10000;
                    break;

                case VehicleHash.Bati2:
                    iVar1 = 10000;
                    break;

                case VehicleHash.BfInjection:
                    iVar1 = 16000;
                    break;

                case VehicleHash.Bison:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Bison2:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Bison3:
                    iVar1 = 30000;
                    break;

                case VehicleHash.BJXL:
                    iVar1 = 27000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24974") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BEEJAY_XL */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24974") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BEEJAY_XL */;
                        }
                    }
                    break;

                case VehicleHash.Blazer:
                    iVar1 = 8000;
                    break;

                case VehicleHash.Blazer2:
                    iVar1 = 62000;
                    if (bVar0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_28794") /* Tunable: CH_SALE_PRICE_BLAZER2 */;
                    }
                    break;

                case VehicleHash.Blista:
                    iVar1 = 16000;
                    break;

                case VehicleHash.BobcatXL:
                    iVar1 = 23000;
                    break;

                case VehicleHash.Bodhi2:
                    iVar1 = 12000;
                    break;

                case VehicleHash.Boxville:
                    if (!bParam2)
                    {
                        iVar1 = 298500;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28720") /* Tunable: CH_TRADE_PRICE_BOXVILLE */;
                        }
                    }
                    else
                    {
                        iVar1 = 398000;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28719") /* Tunable: CH_BIN_PRICE_BOXVILLE */;
                        }
                        iVar2 = 298500;
                        if (bVar0)
                        {
                            iVar2 = Tunables.Global_262145.Value<int>("f_28720") /* Tunable: CH_TRADE_PRICE_BOXVILLE */;
                        }
                    }
                    break;

                case VehicleHash.Stockade:
                    if (!bParam2)
                    {
                        iVar1 = 1680000;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28722") /* Tunable: CH_TRADE_PRICE_STOCKADE */;
                        }
                    }
                    else
                    {
                        iVar1 = 2240000;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28721") /* Tunable: CH_BIN_PRICE_STOCKADE */;
                        }
                        iVar2 = 1680000;
                        if (bVar0)
                        {
                            iVar2 = Tunables.Global_262145.Value<int>("f_28722") /* Tunable: CH_TRADE_PRICE_STOCKADE */;
                        }
                    }
                    break;

                case VehicleHash.Boxville2:
                    iVar1 = 25000;
                    break;

                case VehicleHash.Boxville3:
                    iVar1 = 25000;
                    break;

                case VehicleHash.Buccaneer:
                    iVar1 = 28000;
                    break;

                case VehicleHash.Buffalo:
                    iVar1 = 35000;
                    break;

                case VehicleHash.Buffalo2:
                    iVar1 = 96000;
                    break;

                case VehicleHash.Bullet:
                    iVar1 = 150000;
                    break;

                case VehicleHash.Burrito:
                    iVar1 = 13000;
                    break;

                case VehicleHash.Burrito2:
                    if (bParam2)
                    {
                        iVar1 = 450000;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28718") /* Tunable: CH_TRADE_PRICE_BURRITO2 */;
                        }
                    }
                    else
                    {
                        iVar1 = 598500;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28717") /* Tunable: CH_BIN_PRICE_BURRITO2 */;
                        }
                        iVar2 = 450000;
                        if (bVar0)
                        {
                            iVar2 = Tunables.Global_262145.Value<int>("f_28718") /* Tunable: CH_TRADE_PRICE_BURRITO2 */;
                        }
                    }
                    break;

                case VehicleHash.Burrito3:
                    iVar1 = 13000;
                    break;

                case VehicleHash.Burrito4:
                    iVar1 = 13000;
                    break;

                case VehicleHash.Carbonizzare:
                    iVar1 = 195000;
                    break;

                case VehicleHash.CarbonRS:
                    iVar1 = 40000;
                    break;

                case VehicleHash.Cavalcade:
                    iVar1 = 60000;
                    break;

                case VehicleHash.Cavalcade2:
                    iVar1 = 70000;
                    break;

                case VehicleHash.Cheetah:
                    iVar1 = 650000;
                    break;

                case VehicleHash.CogCabrio:
                    iVar1 = 185000;
                    break;

                case VehicleHash.Comet2:
                    iVar1 = 85000;
                    break;

                case VehicleHash.Coquette:
                    iVar1 = 55000;
                    break;

                case VehicleHash.Daemon:
                    iVar1 = 20000;
                    break;

                case VehicleHash.Dilettante:
                    iVar1 = 25000;
                    break;

                case VehicleHash.Dominator:
                    iVar1 = 35000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_7805") /* Tunable: DLC_VEHICLE_VAPID_DOMINATOR */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_7805") /* Tunable: DLC_VEHICLE_VAPID_DOMINATOR */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = Round((35000) * 0.75f);
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26128") /* Tunable: AW_TRADE_PRICE_DOMINATOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26128") /* Tunable: AW_TRADE_PRICE_DOMINATOR */;
                        }
                    }
                    break;

                case VehicleHash.Double:
                    iVar1 = 12000;
                    break;

                case VehicleHash.Dubsta:
                    iVar1 = 120000;
                    break;

                case VehicleHash.Dubsta2:
                    iVar1 = 120000;
                    break;

                case VehicleHash.Elegy2:
                    if (!bParam2)
                    {
                        iVar1 = 95000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19828") /* Tunable: IMPEXP_ELEGY_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19828") /* Tunable: IMPEXP_ELEGY_BASE_PRICE */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 0;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_8780") /* Tunable: ELEGY2_WEB_PRICE_MODIFIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_8780") /* Tunable: ELEGY2_WEB_PRICE_MODIFIER */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Emperor:
                    iVar1 = 8000;
                    break;

                case VehicleHash.Emperor2:
                    iVar1 = 5000;
                    break;

                case VehicleHash.Emperor3:
                    iVar1 = 5000;
                    break;

                case VehicleHash.EntityXF:
                    iVar1 = 795000;
                    break;

                case VehicleHash.Exemplar:
                    iVar1 = 205000;
                    break;

                case VehicleHash.F620:
                    iVar1 = 80000;
                    break;

                case VehicleHash.Faggio2:
                    iVar1 = 5000;
                    break;

                case VehicleHash.Felon:
                    iVar1 = 100000;
                    break;

                case VehicleHash.Felon2:
                    iVar1 = 95000;
                    break;

                case VehicleHash.Feltzer2:
                    iVar1 = 145000;
                    break;

                case VehicleHash.FQ2:
                    iVar1 = 50000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24975") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_FATHOM_FQ_2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24975") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_FATHOM_FQ_2 */;
                        }
                    }
                    break;

                case VehicleHash.Fugitive:
                    iVar1 = 24000;
                    break;

                case VehicleHash.Fusilade:
                    iVar1 = 36000;
                    break;

                case VehicleHash.Futo:
                    iVar1 = 9000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24968") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_KARIN_FUTO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24968") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_KARIN_FUTO */;
                        }
                    }
                    break;

                case VehicleHash.Gauntlet:
                    iVar1 = 32000;
                    break;

                case VehicleHash.GBurrito:
                    iVar1 = 16000;
                    break;

                case VehicleHash.Granger:
                    iVar1 = 35000;
                    break;

                case VehicleHash.Gresley:
                    iVar1 = 29000;
                    break;

                case VehicleHash.Habanero:
                    iVar1 = 42000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24976") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_EMPEROR_HABANERO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24976") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_EMPEROR_HABANERO */;
                        }
                    }
                    break;

                case VehicleHash.Hexer:
                    iVar1 = 15000;
                    break;

                case VehicleHash.Hotknife:
                    iVar1 = 90000;
                    break;

                case VehicleHash.Infernus:
                    iVar1 = 440000;
                    break;

                case VehicleHash.Ingot:
                    iVar1 = 9000;
                    break;

                case VehicleHash.Intruder:
                    iVar1 = 16000;
                    break;

                case VehicleHash.Issi2:
                    iVar1 = 18000;
                    break;

                case VehicleHash.Jackal:
                    iVar1 = 60000;
                    break;

                case VehicleHash.JB700:
                    iVar1 = 475000;
                    break;

                case VehicleHash.Khamelion:
                    iVar1 = 100000;
                    break;

                case VehicleHash.Landstalker:
                    iVar1 = 58000;
                    break;

                case VehicleHash.Lguard:
                    iVar1 = 865000;
                    if (bVar0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_28793") /* Tunable: CH_SALE_PRICE_LGUARD */;
                    }
                    break;

                case VehicleHash.FireTruk:
                    if (!bParam2)
                    {
                        iVar1 = 2471250;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28716") /* Tunable: CH_TRADE_PRICE_FIRETRUCK */;
                        }
                    }
                    else
                    {
                        iVar1 = 3295000;
                        if (bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_28715") /* Tunable: CH_BIN_PRICE_FIRETRUCK */;
                        }
                        iVar2 = 2471250;
                        if (bVar0)
                        {
                            iVar2 = Tunables.Global_262145.Value<int>("f_28716") /* Tunable: CH_TRADE_PRICE_FIRETRUCK */;
                        }
                    }
                    break;

                case VehicleHash.Manana:
                    iVar1 = 10000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_29584") /* Tunable: SUM_SALE_PRICE_MANANA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_29584") /* Tunable: SUM_SALE_PRICE_MANANA */;
                        }
                    }
                    break;

                case VehicleHash.Mesa:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Minivan:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Monroe:
                    iVar1 = 490000;
                    break;

                case VehicleHash.Nemesis:
                    iVar1 = 12000;
                    break;

                case VehicleHash.Ninef:
                    iVar1 = 120000;
                    break;

                case VehicleHash.Ninef2:
                    iVar1 = 130000;
                    break;

                case VehicleHash.Oracle:
                    iVar1 = 82000;
                    break;

                case VehicleHash.Oracle2:
                    iVar1 = 80000;
                    break;

                case VehicleHash.Patriot:
                    iVar1 = 50000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24972") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_MAMMOTH_PATRIOT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24972") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_MAMMOTH_PATRIOT */;
                        }
                    }
                    break;

                case VehicleHash.PCJ:
                    iVar1 = 9000;
                    break;

                case VehicleHash.Penumbra:
                    iVar1 = 24000;
                    break;

                case VehicleHash.Peyote:
                    iVar1 = 12000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_29585") /* Tunable: SUM_SALE_PRICE_PEYOTE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_29585") /* Tunable: SUM_SALE_PRICE_PEYOTE */;
                        }
                    }
                    break;

                case VehicleHash.Phoenix:
                    iVar1 = 20000;
                    break;

                case VehicleHash.Prairie:
                    iVar1 = 25000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24971") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BOLLOKAN_PRAIRIE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24971") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BOLLOKAN_PRAIRIE */;
                        }
                    }
                    break;

                case VehicleHash.Pranger:
                    iVar1 = 35000;
                    break;

                case VehicleHash.Premier:
                    iVar1 = 10000;
                    break;

                case VehicleHash.Primo:
                    iVar1 = 9000;
                    break;

                case VehicleHash.Radi:
                    iVar1 = 32000;
                    break;

                case VehicleHash.RancherXL:
                    iVar1 = 9000;
                    break;

                case VehicleHash.RancherXL2:
                    iVar1 = 9000;
                    break;

                case VehicleHash.RapidGT:
                    iVar1 = 118000;
                    break;

                case VehicleHash.RapidGT2:
                    iVar1 = 136000;
                    break;

                case VehicleHash.RatLoader:
                    iVar1 = 6000;
                    break;

                case VehicleHash.Rebel:
                    iVar1 = 7000;
                    break;

                case VehicleHash.Rebel2:
                    iVar1 = 22000;
                    break;

                case VehicleHash.Regina:
                    iVar1 = 8000;
                    break;

                case VehicleHash.Rocoto:
                    iVar1 = 85000;
                    break;

                case VehicleHash.Ruffian:
                    iVar1 = 10000;
                    break;

                case VehicleHash.Ruiner:
                    iVar1 = 10000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24969") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_IMPONTE_RUINER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24969") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_IMPONTE_RUINER */;
                        }
                    }
                    break;

                case VehicleHash.Rumpo:
                    iVar1 = 13000;
                    break;

                case VehicleHash.SabreGT:
                    iVar1 = 15000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_15204") /* Tunable: WEBSITE_BENNYS_DECLASSE_SABRE_TURBO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_15204") /* Tunable: WEBSITE_BENNYS_DECLASSE_SABRE_TURBO */;
                        }
                    }
                    break;

                case VehicleHash.Sadler:
                    iVar1 = 35000;
                    break;

                case VehicleHash.Sanchez:
                    iVar1 = 7000;
                    break;

                case VehicleHash.Sandking:
                    iVar1 = 45000;
                    break;

                case VehicleHash.Sandking2:
                    iVar1 = 45000;
                    break;

                case VehicleHash.Schafter2:
                    iVar1 = 65000;
                    break;

                case VehicleHash.Schwarzer:
                    iVar1 = 80000;
                    break;

                case VehicleHash.Seashark:
                    iVar1 = 16899;
                    break;

                case VehicleHash.Seminole:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Sentinel:
                    iVar1 = 60000;
                    break;

                case VehicleHash.Sentinel2:
                    iVar1 = 60000;
                    break;

                case VehicleHash.Serrano:
                    iVar1 = 60000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_24973") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BENEFACTOR_SERRANO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24973") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_BENEFACTOR_SERRANO */;
                        }
                    }
                    break;

                case VehicleHash.Speedo:
                    iVar1 = 15000;
                    break;

                case VehicleHash.Speedo2:
                    iVar1 = 15000;
                    break;

                case VehicleHash.Stanier:
                    iVar1 = 10000;
                    break;

                case VehicleHash.Stinger:
                    iVar1 = 1000000;
                    break;

                case VehicleHash.StingerGT:
                    iVar1 = 1000000;
                    break;

                case VehicleHash.Stratum:
                    iVar1 = 10000;
                    break;

                case VehicleHash.Stretch:
                    iVar1 = 30000;
                    break;

                case VehicleHash.Sultan:
                    iVar1 = 12000;
                    break;

                case VehicleHash.Superd:
                    iVar1 = 250000;
                    break;

                case VehicleHash.Surano:
                    iVar1 = 99000;
                    break;

                case VehicleHash.Surge:
                    iVar1 = 38000;
                    break;

                case VehicleHash.Tailgater:
                    iVar1 = 55000;
                    break;

                case VehicleHash.Taxi:
                    iVar1 = 13000;
                    iVar1 = 650000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_34187") /* Tunable: XM22_BIN_PRICE_TAXI */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_34187") /* Tunable: XM22_BIN_PRICE_TAXI */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = 487500;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34192") /* Tunable: XM22_TRADE_PRICE_TAXI */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34192") /* Tunable: XM22_TRADE_PRICE_TAXI */;
                        }
                    }
                    break;

                case VehicleHash.Tornado:
                    iVar1 = 30000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */;
                        }
                    }
                    break;

                case VehicleHash.Tornado2:
                    iVar1 = 30000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */;
                        }
                    }
                    break;

                case VehicleHash.Tornado3:
                    iVar1 = 30000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */;
                        }
                    }
                    break;

                case VehicleHash.Tornado4:
                    iVar1 = 30000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */;
                        }
                    }
                    break;

                case VehicleHash.Vacca:
                    iVar1 = 240000;
                    break;

                case VehicleHash.Vader:
                    iVar1 = 9000;
                    break;

                case VehicleHash.Vigero:
                    iVar1 = 21000;
                    break;

                case VehicleHash.Voltic:
                    iVar1 = 80000;
                    break;

                case VehicleHash.Voodoo2:
                    iVar1 = 5000;
                    break;

                case VehicleHash.Washington:
                    iVar1 = 15000;
                    break;

                case VehicleHash.Youga:
                    iVar1 = 16000;
                    break;

                case VehicleHash.Zion:
                    iVar1 = 50000;
                    break;

                case VehicleHash.Zion2:
                    iVar1 = 65000;
                    break;

                case VehicleHash.Bmx:
                    iVar1 = 500;
                    break;

                case VehicleHash.Scorcher:
                    iVar1 = 1000;
                    break;

                case VehicleHash.TriBike:
                    iVar1 = 2500;
                    break;

                case VehicleHash.TriBike2:
                    iVar1 = 2500;
                    break;

                case VehicleHash.TriBike3:
                    iVar1 = 2500;
                    break;

                case VehicleHash.Cruiser:
                    iVar1 = 3000;
                    break;

                case VehicleHash.ZType:
                    if (bVar0)
                    {
                        iVar1 = 1000000;
                    }
                    else
                    {
                        iVar1 = 10000000;
                    }
                    break;
            }
            if (bVar0 || iParam3 == 1)
            {
                switch ((VehicleHash)vehicleModel)
                {
                    case VehicleHash.Adder:
                        iVar1 = 1000000;
                        break;

                    case VehicleHash.Airbus:
                        iVar1 = 550000;
                        break;

                    case VehicleHash.Akuma:
                        iVar1 = 9000;
                        break;

                    case VehicleHash.Annihilator:
                        iVar1 = 4000000;
                        break;

                    case VehicleHash.Baller2:
                        iVar1 = 90000;
                        break;

                    case VehicleHash.Banshee:
                        iVar1 = 105000;
                        break;

                    case VehicleHash.Barracks:
                        iVar1 = 450000;
                        break;

                    case VehicleHash.Bati:
                        iVar1 = 15000;
                        break;

                    case VehicleHash.Bati2:
                        iVar1 = 15000;
                        break;

                    case VehicleHash.BfInjection:
                        iVar1 = 16000;
                        break;

                    case VehicleHash.Bison:
                        iVar1 = 30000;
                        break;

                    case VehicleHash.Blazer:
                        iVar1 = 8000;
                        break;

                    case VehicleHash.Bmx:
                        iVar1 = 800;
                        break;

                    case VehicleHash.Bullet:
                        iVar1 = 155000;
                        break;

                    case VehicleHash.Bus:
                        iVar1 = 500000;
                        break;

                    case VehicleHash.Buzzard:
                        iVar1 = 2000000;
                        break;

                    case VehicleHash.Carbonizzare:
                        iVar1 = 195000;
                        break;

                    case VehicleHash.CarbonRS:
                        iVar1 = 40000;
                        break;

                    case VehicleHash.Cargobob:
                        iVar1 = 185000;
                        break;

                    case VehicleHash.Cheetah:
                        iVar1 = 650000;
                        break;

                    case VehicleHash.Coach:
                        iVar1 = 525000;
                        break;

                    case VehicleHash.CogCabrio:
                        iVar1 = 185000;
                        break;

                    case VehicleHash.Comet2:
                        iVar1 = 100000;
                        break;

                    case VehicleHash.Coquette:
                        iVar1 = 138000;
                        break;

                    case VehicleHash.Cruiser:
                        iVar1 = 800;
                        break;

                    case VehicleHash.Crusader:
                        iVar1 = 225000;
                        break;

                    case VehicleHash.Cuban800:
                        iVar1 = 240000;
                        break;

                    case VehicleHash.Dilettante:
                        iVar1 = 25000;
                        break;

                    case VehicleHash.Double:
                        iVar1 = 12000;
                        break;

                    case VehicleHash.Dubsta:
                        iVar1 = 70000;
                        break;

                    case VehicleHash.Dubsta2:
                        iVar1 = 70000;
                        break;

                    case VehicleHash.Dump:
                        iVar1 = 1000000;
                        break;

                    case VehicleHash.Duster:
                        iVar1 = 275000;
                        break;

                    case VehicleHash.Elegy2:
                        if (!bParam2)
                        {
                            iVar1 = 95000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19828") /* Tunable: IMPEXP_ELEGY_BASE_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19828") /* Tunable: IMPEXP_ELEGY_BASE_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_8780") /* Tunable: ELEGY2_WEB_PRICE_MODIFIER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_8780") /* Tunable: ELEGY2_WEB_PRICE_MODIFIER */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.EntityXF:
                        iVar1 = 795000;
                        break;

                    case VehicleHash.Exemplar:
                        iVar1 = 205000;
                        break;

                    case VehicleHash.Faggio2:
                        iVar1 = 5000;
                        break;

                    case VehicleHash.Felon:
                        iVar1 = 90000;
                        break;

                    case VehicleHash.Felon2:
                        iVar1 = 95000;
                        break;

                    case VehicleHash.Feltzer2:
                        iVar1 = 145000;
                        break;

                    case VehicleHash.Frogger:
                        iVar1 = 1300000;
                        break;

                    case VehicleHash.Fugitive:
                        iVar1 = 24000;
                        break;

                    case VehicleHash.Gauntlet:
                        iVar1 = 32000;
                        break;

                    case VehicleHash.Hexer:
                        iVar1 = 15000;
                        break;

                    case VehicleHash.Hotknife:
                        iVar1 = 90000;
                        break;

                    case VehicleHash.Infernus:
                        iVar1 = 440000;
                        break;

                    case VehicleHash.Issi2:
                        iVar1 = 18000;
                        break;

                    case VehicleHash.JB700:
                        iVar1 = 350000;
                        break;

                    case VehicleHash.Jetmax:
                        iVar1 = 299000;
                        break;

                    case VehicleHash.Journey:
                        iVar1 = 15000;
                        break;

                    case VehicleHash.Khamelion:
                        iVar1 = 100000;
                        break;

                    case VehicleHash.Luxor:
                        iVar1 = 1500000;
                        break;

                    case VehicleHash.Mammatus:
                        iVar1 = 300000;
                        break;

                    case VehicleHash.Marquis:
                        iVar1 = 413990;
                        break;

                    case VehicleHash.Maverick:
                        iVar1 = 780000;
                        break;

                    case VehicleHash.Monroe:
                        iVar1 = 490000;
                        break;

                    case VehicleHash.Mule:
                        iVar1 = 27000;
                        break;

                    case VehicleHash.Ninef:
                        iVar1 = 120000;
                        break;

                    case VehicleHash.Ninef2:
                        iVar1 = 130000;
                        break;

                    case VehicleHash.Oracle2:
                        iVar1 = 80000;
                        break;

                    case VehicleHash.PCJ:
                        iVar1 = 9000;
                        break;

                    case VehicleHash.Picador:
                        iVar1 = 9000;
                        break;

                    case VehicleHash.RapidGT:
                        iVar1 = 132000;
                        break;

                    case VehicleHash.RapidGT2:
                        iVar1 = 140000;
                        break;

                    case VehicleHash.RentalBus:
                        iVar1 = 30000;
                        break;

                    case VehicleHash.Rocoto:
                        iVar1 = 85000;
                        break;

                    case VehicleHash.Ruffian:
                        iVar1 = 10000;
                        break;

                    case VehicleHash.Sanchez:
                        iVar1 = 7000;
                        break;

                    case VehicleHash.Sandking:
                        iVar1 = 45000;
                        break;

                    case VehicleHash.Schwarzer:
                        iVar1 = 80000;
                        break;

                    case VehicleHash.Scorcher:
                        iVar1 = 2000;
                        break;

                    case VehicleHash.Shamal:
                        iVar1 = 1150000;
                        break;

                    case VehicleHash.Squalo:
                        iVar1 = 196621;
                        break;

                    case VehicleHash.Stinger:
                        iVar1 = 850000;
                        break;

                    case VehicleHash.StingerGT:
                        iVar1 = 875000;
                        break;

                    case VehicleHash.Stretch:
                        iVar1 = 30000;
                        break;

                    case VehicleHash.Stunt:
                        iVar1 = 250000;
                        break;

                    case VehicleHash.Suntrap:
                        iVar1 = 25160;
                        break;

                    case VehicleHash.Superd:
                        iVar1 = 250000;
                        break;

                    case VehicleHash.Surano:
                        iVar1 = 110000;
                        break;

                    case VehicleHash.Titan:
                        iVar1 = 5000000;
                        break;

                    case VehicleHash.TriBike:
                        iVar1 = 10000;
                        break;

                    case VehicleHash.TriBike2:
                        iVar1 = 10000;
                        break;

                    case VehicleHash.TriBike3:
                        iVar1 = 10000;
                        break;

                    case VehicleHash.Tropic:
                        iVar1 = 22000;
                        break;

                    case VehicleHash.Vacca:
                        iVar1 = 240000;
                        break;

                    case VehicleHash.Vader:
                        iVar1 = 9000;
                        break;

                    case VehicleHash.Velum:
                        iVar1 = 450000;
                        break;

                    case VehicleHash.Vigero:
                        iVar1 = 21000;
                        break;

                    case VehicleHash.Voltic:
                        iVar1 = 150000;
                        break;

                    case VehicleHash.Zion:
                        iVar1 = 60000;
                        break;

                    case VehicleHash.Zion2:
                        iVar1 = 65000;
                        break;

                    case VehicleHash.ZType:
                        iVar1 = 950000;
                        break;
                }
                switch ((VehicleHash)vehicleModel)
                {
                    case VehicleHash.Annihilator:
                        iVar1 = 1825000;
                        break;

                    case VehicleHash.Blazer3:
                        iVar1 = 69000;
                        break;

                    case VehicleHash.Bodhi2:
                        iVar1 = 25000;
                        break;

                    case VehicleHash.Buzzard:
                        iVar1 = 1750000;
                        break;

                    case VehicleHash.Dilettante2:
                        iVar1 = 25000;
                        break;

                    case VehicleHash.DLoader:
                        iVar1 = 15000;
                        break;

                    case VehicleHash.Dune2:
                        iVar1 = 1000000;
                        break;

                    case VehicleHash.Frogger:
                        iVar1 = 1300000;
                        break;

                    case VehicleHash.Luxor:
                        iVar1 = 1625000;
                        break;

                    case VehicleHash.Mesa3:
                        iVar1 = 87000;
                        break;

                    case VehicleHash.Peyote:
                        iVar1 = 38000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29585") /* Tunable: SUM_SALE_PRICE_PEYOTE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29585") /* Tunable: SUM_SALE_PRICE_PEYOTE */;
                            }
                        }
                        break;

                    case VehicleHash.Rhino:
                        iVar1 = 1500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_4080") /* Tunable: RHINO_EXPENDITURE_MODIFIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4080") /* Tunable: RHINO_EXPENDITURE_MODIFIER */;
                            }
                        }
                        break;

                    case VehicleHash.Romero:
                        iVar1 = 45000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24970") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_CHARIOT_ROMERO_HEARSE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24970") /* Tunable: BB_TRADE_PRICE_EXISTING_VEHICLES_CHARIOT_ROMERO_HEARSE */;
                            }
                        }
                        break;

                    case VehicleHash.Sentinel2:
                        iVar1 = 95000;
                        break;

                    case VehicleHash.Shamal:
                        iVar1 = 1150000;
                        break;

                    case VehicleHash.Surfer:
                        iVar1 = 11000;
                        break;

                    case VehicleHash.Surfer2:
                        iVar1 = 5000;
                        break;

                    case VehicleHash.Titan:
                        iVar1 = 2000000;
                        break;

                    case VehicleHash.TowTruck2:
                        iVar1 = 32000;
                        break;
                }
                switch ((VehicleHash)vehicleModel)
                {
                    case VehicleHash.Bodhi2:
                        iVar1 = 25000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_4741") /* Tunable: BODHI2_EXPENDITURE_MODIFIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4741") /* Tunable: BODHI2_EXPENDITURE_MODIFIER */;
                            }
                        }
                        break;

                    case VehicleHash.Dune:
                        iVar1 = 20000;
                        if (bVar0 || iParam3 == 1)
                        {
                            iVar1 = 20000;
                            if (Tunables.Global_262145.Value<int>("f_4742") /* Tunable: DUNE_EXPENDITURE_MODIFIER */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4742") /* Tunable: DUNE_EXPENDITURE_MODIFIER */;
                            }
                        }
                        break;

                    case VehicleHash.Rebel:
                        iVar1 = 3000;
                        break;

                    case VehicleHash.Sadler:
                        iVar1 = 35000;
                        break;

                    case VehicleHash.Sanchez2:
                        iVar1 = 8000;
                        break;

                    case VehicleHash.Sandking2:
                        iVar1 = 38000;
                        break;
                }
                switch ((VehicleHash)vehicleModel)
                {
                    case VehicleHash.Asea:
                        iVar1 = 12000;
                        break;

                    case VehicleHash.Asterope:
                        iVar1 = 26000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7114") /* Tunable: BUSINESS_VEHICLES_ASTEROPE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7114") /* Tunable: BUSINESS_VEHICLES_ASTEROPE */;
                            }
                        }
                        break;

                    case VehicleHash.BobcatXL:
                        iVar1 = 23000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7115") /* Tunable: BUSINESS_VEHICLES_BOBCATXL */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7115") /* Tunable: BUSINESS_VEHICLES_BOBCATXL */;
                            }
                        }
                        break;

                    case VehicleHash.Cavalcade:
                        iVar1 = 60000;
                        if (bVar0 || iParam3 == 1)
                        {
                            iVar1 = 60000;
                            if (Tunables.Global_262145.Value<int>("f_4037") /* Tunable: CAVALCADE_EXPENDITURE_MODIFIER */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4037") /* Tunable: CAVALCADE_EXPENDITURE_MODIFIER */;
                            }
                        }
                        break;

                    case VehicleHash.Cavalcade2:
                        iVar1 = 60000;
                        if (bVar0 || iParam3 == 1)
                        {
                            iVar1 = 70000;
                            if (Tunables.Global_262145.Value<int>("f_7116") /* Tunable: BUSINESS_VEHICLES_CAVALCADE2 */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7116") /* Tunable: BUSINESS_VEHICLES_CAVALCADE2 */;
                            }
                        }
                        break;

                    case VehicleHash.Granger:
                        iVar1 = 35000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7117") /* Tunable: BUSINESS_VEHICLES_GRANGER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7117") /* Tunable: BUSINESS_VEHICLES_GRANGER */;
                            }
                        }
                        break;

                    case VehicleHash.Ingot:
                        iVar1 = 9000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7118") /* Tunable: BUSINESS_VEHICLES_INGOT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7118") /* Tunable: BUSINESS_VEHICLES_INGOT */;
                            }
                        }
                        break;

                    case VehicleHash.Intruder:
                        iVar1 = 16000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7119") /* Tunable: BUSINESS_VEHICLES_INTRUDER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7119") /* Tunable: BUSINESS_VEHICLES_INTRUDER */;
                            }
                        }
                        break;

                    case VehicleHash.Minivan:
                        iVar1 = 30000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7120") /* Tunable: BUSINESS_VEHICLES_MINIVAN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7120") /* Tunable: BUSINESS_VEHICLES_MINIVAN */;
                            }
                        }
                        break;

                    case VehicleHash.Premier:
                        iVar1 = 10000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7121") /* Tunable: BUSINESS_VEHICLES_PREMIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7121") /* Tunable: BUSINESS_VEHICLES_PREMIER */;
                            }
                        }
                        break;

                    case VehicleHash.Radi:
                        iVar1 = 32000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7122") /* Tunable: BUSINESS_VEHICLES_RADI */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7122") /* Tunable: BUSINESS_VEHICLES_RADI */;
                            }
                        }
                        break;

                    case VehicleHash.RancherXL:
                        iVar1 = 9000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7123") /* Tunable: BUSINESS_VEHICLES_RANCHERXL */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7123") /* Tunable: BUSINESS_VEHICLES_RANCHERXL */;
                            }
                        }
                        break;

                    case VehicleHash.RatLoader:
                        iVar1 = 6000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7143") /* Tunable: VALENTINE_MODIFIER_VEHICLE_RATLOADER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7143") /* Tunable: VALENTINE_MODIFIER_VEHICLE_RATLOADER */;
                            }
                        }
                        break;

                    case VehicleHash.Stanier:
                        iVar1 = 10000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7124") /* Tunable: BUSINESS_VEHICLES_STANIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7124") /* Tunable: BUSINESS_VEHICLES_STANIER */;
                            }
                        }
                        break;

                    case VehicleHash.Stratum:
                        iVar1 = 10000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7125") /* Tunable: BUSINESS_VEHICLES_STRATUM */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7125") /* Tunable: BUSINESS_VEHICLES_STRATUM */;
                            }
                        }
                        break;

                    case VehicleHash.Washington:
                        iVar1 = 15000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7126") /* Tunable: BUSINESS_VEHICLES_WASHINGTON */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7126") /* Tunable: BUSINESS_VEHICLES_WASHINGTON */;
                            }
                        }
                        break;

                    case VehicleHash.Cargobob:
                        iVar1 = 1790000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16746") /* Tunable: EXEC1_CARGOBOB */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16746") /* Tunable: EXEC1_CARGOBOB */;
                            }
                        }
                        break;

                    case VehicleHash.Cargobob2:
                        iVar1 = 1995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16747") /* Tunable: EXEC1_CARGOBOB2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16747") /* Tunable: EXEC1_CARGOBOB2 */;
                            }
                        }
                        break;

                    case VehicleHash.Tug:
                        iVar1 = 1250000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16753") /* Tunable: EXEC1_TUG */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16753") /* Tunable: EXEC1_TUG */;
                            }
                        }
                        break;

                    case VehicleHash.Nimbus:
                        iVar1 = 1900000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16751") /* Tunable: EXEC1_BUCKINGHAM_NIMBUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16751") /* Tunable: EXEC1_BUCKINGHAM_NIMBUS */;
                            }
                        }
                        break;

                    case VehicleHash.Brickade:
                        iVar1 = 555000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16749") /* Tunable: EXEC1_HVY_BRICKADE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16749") /* Tunable: EXEC1_HVY_BRICKADE */;
                            }
                        }
                        break;

                    case VehicleHash.Windsor2:
                        iVar1 = 900000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16755") /* Tunable: EXEC1_ENUS_WINDSOR_DROP */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16755") /* Tunable: EXEC1_ENUS_WINDSOR_DROP */;
                            }
                        }
                        break;

                    case VehicleHash.Prototipo:
                        iVar1 = 2700000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16760") /* Tunable: EXEC1_PROGEN_X80_PROTO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16760") /* Tunable: EXEC1_PROGEN_X80_PROTO */;
                            }
                        }
                        break;

                    case VehicleHash.FMJ:
                        iVar1 = 1750000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16750") /* Tunable: EXEC1_VAPID_FMJ */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16750") /* Tunable: EXEC1_VAPID_FMJ */;
                            }
                        }
                        break;

                    case VehicleHash.BestiaGTS:
                        iVar1 = 610000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16748") /* Tunable: EXEC1_GROTTI_BESTIA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16748") /* Tunable: EXEC1_GROTTI_BESTIA */;
                            }
                        }
                        break;

                    case VehicleHash.XLS:
                        iVar1 = 253000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16756") /* Tunable: EXEC1_BENEFACTOR_XLS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16756") /* Tunable: EXEC1_BENEFACTOR_XLS */;
                            }
                        }
                        break;

                    case VehicleHash.XLS2:
                        iVar1 = 522000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16757") /* Tunable: EXEC1_BENEFACTOR_XLS_ARMORED */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16757") /* Tunable: EXEC1_BENEFACTOR_XLS_ARMORED */;
                            }
                        }
                        break;

                    case VehicleHash.Seven70:
                        iVar1 = 695000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16758") /* Tunable: EXEC1_DEWBAUCHEE_SEVEN70 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16758") /* Tunable: EXEC1_DEWBAUCHEE_SEVEN70 */;
                            }
                        }
                        break;

                    case VehicleHash.Pfister811:
                        iVar1 = 1135000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16759") /* Tunable: EXEC1_PFISTER_811 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16759") /* Tunable: EXEC1_PFISTER_811 */;
                            }
                        }
                        break;

                    case VehicleHash.Reaper:
                        iVar1 = 1595000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16223") /* Tunable: EXEC_VEH_PEGASUS_REAPER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16223") /* Tunable: EXEC_VEH_PEGASUS_REAPER */;
                            }
                        }
                        break;

                    case VehicleHash.Rumpo3:
                        iVar1 = 130000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16752") /* Tunable: EXEC1_BRAVADO_RUMPO_CUSTOM */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16752") /* Tunable: EXEC1_BRAVADO_RUMPO_CUSTOM */;
                            }
                        }
                        break;

                    case VehicleHash.Volatus:
                        iVar1 = 2295000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_16754") /* Tunable: EXEC1_BUCKINGHAM_VOLATUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_16754") /* Tunable: EXEC1_BUCKINGHAM_VOLATUS */;
                            }
                        }
                        break;

                    case VehicleHash.LE7B:
                        iVar1 = 2475000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17527") /* Tunable: STUNT_ANNIS_RE7B */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17527") /* Tunable: STUNT_ANNIS_RE7B */;
                            }
                        }
                        break;

                    case VehicleHash.Omnis:
                        if (!bParam2)
                        {
                            iVar1 = 701000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_17528") /* Tunable: STUNT_OBEY_OMNIS */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_17528") /* Tunable: STUNT_OBEY_OMNIS */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case VehicleHash.Tropos:
                        iVar1 = 816000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17529") /* Tunable: STUNT_LAMPADATI_TROPOS_RALLYE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17529") /* Tunable: STUNT_LAMPADATI_TROPOS_RALLYE */;
                            }
                        }
                        break;

                    case VehicleHash.Brioso:
                        iVar1 = 155000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17530") /* Tunable: STUNT_GROTTI_BRIOSO_RA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17530") /* Tunable: STUNT_GROTTI_BRIOSO_RA */;
                            }
                        }
                        break;

                    case VehicleHash.TrophyTruck:
                        iVar1 = 550000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17531") /* Tunable: STUNT_VAPID_TROPHY_TRUCK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17531") /* Tunable: STUNT_VAPID_TROPHY_TRUCK */;
                            }
                        }
                        break;

                    case VehicleHash.TrophyTruck2:
                        iVar1 = 695000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17532") /* Tunable: STUNT_VAPID_DESERT_RAID */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17532") /* Tunable: STUNT_VAPID_DESERT_RAID */;
                            }
                        }
                        break;

                    case VehicleHash.Contender:
                        iVar1 = 250000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17533") /* Tunable: STUNT_BRAVADO_CONTENDER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17533") /* Tunable: STUNT_BRAVADO_CONTENDER */;
                            }
                        }
                        break;

                    case VehicleHash.Cliffhanger:
                        iVar1 = 225000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17534") /* Tunable: STUNT_WESTERN_CLIFFHANGER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17534") /* Tunable: STUNT_WESTERN_CLIFFHANGER */;
                            }
                        }
                        break;

                    case VehicleHash.BF400:
                        iVar1 = 95000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17535") /* Tunable: STUNT_NAGASAKI_BF400 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17535") /* Tunable: STUNT_NAGASAKI_BF400 */;
                            }
                        }
                        break;

                    case VehicleHash.Tyrus:
                        iVar1 = 2550000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17525") /* Tunable: STUNT_PROGEN_TYRUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17525") /* Tunable: STUNT_PROGEN_TYRUS */;
                            }
                        }
                        break;

                    case VehicleHash.Lynx:
                        iVar1 = 1735000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17536") /* Tunable: STUNT_OCELOT_LYNX */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17536") /* Tunable: STUNT_OCELOT_LYNX */;
                            }
                        }
                        break;

                    case VehicleHash.Sheava:
                        iVar1 = 1995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17524") /* Tunable: STUNT_EMPEROR_SHEAVA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17524") /* Tunable: STUNT_EMPEROR_SHEAVA */;
                            }
                        }
                        break;

                    case VehicleHash.RallyTruck:
                        if (!bParam2)
                        {
                            iVar1 = 1300000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_17538") /* Tunable: STUNT_MTL_DUNE_LIVERY_1 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_17538") /* Tunable: STUNT_MTL_DUNE_LIVERY_1 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1385000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_17539") /* Tunable: STUNT_MTL_DUNE_LIVERY_2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_17539") /* Tunable: STUNT_MTL_DUNE_LIVERY_2 */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Tampa2:
                        iVar1 = 995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_17526") /* Tunable: STUNT_DECALSSE_DRIFT_TAMPA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_17526") /* Tunable: STUNT_DECALSSE_DRIFT_TAMPA */;
                            }
                        }
                        break;

                    case VehicleHash.Gargoyle:
                        iVar1 = 120000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_17537") /* Tunable: STUNT_WESTERN_GARGOYLE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_17537") /* Tunable: STUNT_WESTERN_GARGOYLE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = Round((120000) * 0.75f);
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26131") /* Tunable: AW_TRADE_PRICE_GARGOYLE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26131") /* Tunable: AW_TRADE_PRICE_GARGOYLE */;
                            }
                        }
                        break;

                    case VehicleHash.Esskey:
                        iVar1 = 264000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18105") /* Tunable: BIKER_WEBSITE_PEGASSI_ESSKEY */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18105") /* Tunable: BIKER_WEBSITE_PEGASSI_ESSKEY */;
                            }
                        }
                        break;

                    case VehicleHash.Nightblade:
                        iVar1 = 100000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18108") /* Tunable: BIKER_WEBSITE_WESTERN_NIGHTBLADE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18108") /* Tunable: BIKER_WEBSITE_WESTERN_NIGHTBLADE */;
                            }
                        }
                        break;

                    case VehicleHash.Defiler:
                        if (bParam2)
                        {
                            iVar1 = 309000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28727") /* Tunable: CH_TRADE_PRICE_DEFILER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28727") /* Tunable: CH_TRADE_PRICE_DEFILER */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 412000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_18104") /* Tunable: BIKER_WEBSITE_SHITZU_DEFILER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_18104") /* Tunable: BIKER_WEBSITE_SHITZU_DEFILER */;
                                }
                            }
                            iVar2 = 309000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28727") /* Tunable: CH_TRADE_PRICE_DEFILER */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28727") /* Tunable: CH_TRADE_PRICE_DEFILER */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Avarus:
                        iVar1 = 116000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18099") /* Tunable: BIKER_WEBSITE_LCC_AVARUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18099") /* Tunable: BIKER_WEBSITE_LCC_AVARUS */;
                            }
                        }
                        break;

                    case VehicleHash.ZombieA:
                        iVar1 = 99000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18115") /* Tunable: BIKER_WEBSITE_WESTERN_ZOMBIE_BOBBER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18115") /* Tunable: BIKER_WEBSITE_WESTERN_ZOMBIE_BOBBER */;
                            }
                        }
                        break;

                    case VehicleHash.ZombieB:
                        if (!bParam2)
                        {
                            iVar1 = 122000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_18116") /* Tunable: BIKER_WEBSITE_WESTERN_ZOMBIE_CHOPPER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_18116") /* Tunable: BIKER_WEBSITE_WESTERN_ZOMBIE_CHOPPER */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case VehicleHash.Chimera:
                        iVar1 = 210000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18102") /* Tunable: BIKER_WEBSITE_NAGASAKI_CHIMERA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18102") /* Tunable: BIKER_WEBSITE_NAGASAKI_CHIMERA */;
                            }
                        }
                        break;

                    case VehicleHash.Daemon2:
                        iVar1 = 145000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18103") /* Tunable: BIKER_WEBSITE_WESTERN_DAEMON_CUSTOM */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18103") /* Tunable: BIKER_WEBSITE_WESTERN_DAEMON_CUSTOM */;
                            }
                        }
                        break;

                    case VehicleHash.RatBike:
                        iVar1 = 48000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18110") /* Tunable: BIKER_WEBSITE_WESTERN_RAT_BIKE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18110") /* Tunable: BIKER_WEBSITE_WESTERN_RAT_BIKE */;
                            }
                        }
                        break;

                    case VehicleHash.Shotaro:
                        iVar1 = 2225000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18112") /* Tunable: BIKER_WEBSITE_NAGASAKI_SHOTARO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18112") /* Tunable: BIKER_WEBSITE_NAGASAKI_SHOTARO */;
                            }
                        }
                        break;

                    case VehicleHash.Raptor:
                        iVar1 = 648000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18109") /* Tunable: BIKER_WEBSITE_BF_RAPTOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18109") /* Tunable: BIKER_WEBSITE_BF_RAPTOR */;
                            }
                        }
                        break;

                    case VehicleHash.Hakuchou2:
                        iVar1 = 976000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18106") /* Tunable: BIKER_WEBSITE_SHITZU_HAKUCHOU_DRAG */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18106") /* Tunable: BIKER_WEBSITE_SHITZU_HAKUCHOU_DRAG */;
                            }
                        }
                        break;

                    case VehicleHash.Blazer4:
                        iVar1 = 81000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18101") /* Tunable: BIKER_WEBSITE_NAGASAKI_STREET_BLAZER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18101") /* Tunable: BIKER_WEBSITE_NAGASAKI_STREET_BLAZER */;
                            }
                        }
                        break;

                    case VehicleHash.Sanctus:
                        iVar1 = 1995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_18111") /* Tunable: BIKER_WEBSITE_LCC_SANCTUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_18111") /* Tunable: BIKER_WEBSITE_LCC_SANCTUS */;
                            }
                        }
                        break;

                    case VehicleHash.Vortex:
                        if (!bParam2)
                        {
                            iVar1 = 356000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_18113") /* Tunable: BIKER_WEBSITE_PEGASSI_VORTEX */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_18113") /* Tunable: BIKER_WEBSITE_PEGASSI_VORTEX */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case VehicleHash.Manchez:
                        if (bParam2)
                        {
                            iVar1 = 50250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28728") /* Tunable: CH_TRADE_PRICE_MANCHEZ */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28728") /* Tunable: CH_TRADE_PRICE_MANCHEZ */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 67000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_18107") /* Tunable: BIKER_WEBSITE_MAIBATSU_MANCHEZ */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_18107") /* Tunable: BIKER_WEBSITE_MAIBATSU_MANCHEZ */;
                                }
                            }
                            iVar2 = 50250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28728") /* Tunable: CH_TRADE_PRICE_MANCHEZ */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28728") /* Tunable: CH_TRADE_PRICE_MANCHEZ */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Tornado6:
                        iVar1 = 378000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19177") /* Tunable: WEBSITE_DECLASSE_TORNADO_RAT_ROD */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19177") /* Tunable: WEBSITE_DECLASSE_TORNADO_RAT_ROD */;
                            }
                        }
                        break;

                    case VehicleHash.Youga2:
                        iVar1 = 195000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19180") /* Tunable: WEBSITE_VAPID_YOUGA_CLASSIC */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19180") /* Tunable: WEBSITE_VAPID_YOUGA_CLASSIC */;
                            }
                        }
                        break;

                    case VehicleHash.Wolfsbane:
                        if (bParam2)
                        {
                            iVar1 = 71250;
                            if (bVar0)
                            {
                            }
                        }
                        else
                        {
                            iVar1 = 95000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_18114") /* Tunable: BIKER_WEBSITE_WESTERN_WOLFSBANE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_18114") /* Tunable: BIKER_WEBSITE_WESTERN_WOLFSBANE */;
                                }
                            }
                            iVar2 = 71250;
                            if (bVar0)
                            {
                            }
                        }
                        break;

                    case VehicleHash.Faggio3:
                        iVar1 = 55000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19178") /* Tunable: WEBSITE_PEGASSI_FAGGIO_MOD */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19178") /* Tunable: WEBSITE_PEGASSI_FAGGIO_MOD */;
                            }
                        }
                        break;

                    case VehicleHash.Faggio:
                        iVar1 = 47500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19179") /* Tunable: WEBSITE_PEGASSI_FAGGIO_SPORT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19179") /* Tunable: WEBSITE_PEGASSI_FAGGIO_SPORT */;
                            }
                        }
                        break;

                    case VehicleHash.Dune5:
                        if (!bParam2)
                        {
                            iVar1 = 3192000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19798") /* Tunable: IMPEXP_DUNE5_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19798") /* Tunable: IMPEXP_DUNE5_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2400000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19799") /* Tunable: IMPEXP_DUNE5_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19799") /* Tunable: IMPEXP_DUNE5_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Phantom2:
                        if (!bParam2)
                        {
                            iVar1 = 2553600;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19800") /* Tunable: IMPEXP_PHANTOM2_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19800") /* Tunable: IMPEXP_PHANTOM2_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1920000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19801") /* Tunable: IMPEXP_PHANTOM2_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19801") /* Tunable: IMPEXP_PHANTOM2_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Technical2:
                        if (!bParam2)
                        {
                            iVar1 = 1489600;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19802") /* Tunable: IMPEXP_TECHNICAL2_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19802") /* Tunable: IMPEXP_TECHNICAL2_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1120000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19803") /* Tunable: IMPEXP_TECHNICAL2_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19803") /* Tunable: IMPEXP_TECHNICAL2_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Blazer5:
                        if (!bParam2)
                        {
                            iVar1 = 1755600;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19804") /* Tunable: IMPEXP_BLAZER5_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19804") /* Tunable: IMPEXP_BLAZER5_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1320000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19805") /* Tunable: IMPEXP_BLAZER5_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19805") /* Tunable: IMPEXP_BLAZER5_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Boxville5:
                        if (!bParam2)
                        {
                            iVar1 = 1300000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19806") /* Tunable: IMPEXP_BOXVILLE5_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19806") /* Tunable: IMPEXP_BOXVILLE5_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 975000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19807") /* Tunable: IMPEXP_BOXVILLE5_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19807") /* Tunable: IMPEXP_BOXVILLE5_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Wastelander:
                        if (!bParam2)
                        {
                            iVar1 = 658350;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19808") /* Tunable: IMPEXP_WASTELANDER_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19808") /* Tunable: IMPEXP_WASTELANDER_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 495000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19809") /* Tunable: IMPEXP_WASTELANDER_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19809") /* Tunable: IMPEXP_WASTELANDER_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Ruiner2:
                        if (!bParam2)
                        {
                            iVar1 = 3750000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19810") /* Tunable: IMPEXP_RUINER2_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19810") /* Tunable: IMPEXP_RUINER2_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2812500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19811") /* Tunable: IMPEXP_RUINER2_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19811") /* Tunable: IMPEXP_RUINER2_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Voltic2:
                        if (!bParam2)
                        {
                            iVar1 = 3830400;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19812") /* Tunable: IMPEXP_VOLTIC2_BIN_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19812") /* Tunable: IMPEXP_VOLTIC2_BIN_PRICE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2880000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_19813") /* Tunable: IMPEXP_VOLTIC2_SECUROSERV_PRICE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_19813") /* Tunable: IMPEXP_VOLTIC2_SECUROSERV_PRICE */;
                                }
                            }
                        }
                        break;

                    case VehicleHash.Penetrator:
                        iVar1 = 880000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19826") /* Tunable: IMPEXP_PENETRATOR_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19826") /* Tunable: IMPEXP_PENETRATOR_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.Tempesta:
                        iVar1 = 1329000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_19827") /* Tunable: IMPEXP_TEMPESTA_PRICE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_19827") /* Tunable: IMPEXP_TEMPESTA_PRICE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = Round((1329000) * 0.75f);
                        }
                        break;

                    case VehicleHash.ItaliGTB:
                        iVar1 = 1189000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19814") /* Tunable: IMPEXP_ITALIGTB_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19814") /* Tunable: IMPEXP_ITALIGTB_BASE_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.ItaliGTB2:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19814") /* Tunable: IMPEXP_ITALIGTB_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Nero:
                        iVar1 = 1440000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19818") /* Tunable: IMPEXP_NERO_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19818") /* Tunable: IMPEXP_NERO_BASE_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.Nero2:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19818") /* Tunable: IMPEXP_NERO_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Diablous:
                        iVar1 = 169000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19824") /* Tunable: IMPEXP_DIABLOUS_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19824") /* Tunable: IMPEXP_DIABLOUS_BASE_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.Diablous2:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19824") /* Tunable: IMPEXP_DIABLOUS_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.FCR:
                        iVar1 = 135000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19822") /* Tunable: IMPEXP_FCR_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19822") /* Tunable: IMPEXP_FCR_BASE_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.FCR2:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19822") /* Tunable: IMPEXP_FCR_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Specter:
                        iVar1 = 599000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_19816") /* Tunable: IMPEXP_SPECTER_BASE_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_19816") /* Tunable: IMPEXP_SPECTER_BASE_PRICE */;
                            }
                        }
                        break;

                    case VehicleHash.Specter2:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19816") /* Tunable: IMPEXP_SPECTER_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Comet3:
                        iVar1 = (85000 + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Elegy:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_19828") /* Tunable: IMPEXP_ELEGY_BASE_PRICE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case VehicleHash.Infernus2:
                        iVar1 = 915000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20462") /* Tunable: SR_PEGASSI_INFERNUS2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20462") /* Tunable: SR_PEGASSI_INFERNUS2 */;
                            }
                        }
                        break;

                    case VehicleHash.GP1:
                        iVar1 = 1260000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20461") /* Tunable: SR_PROGEN_GP1 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20461") /* Tunable: SR_PROGEN_GP1 */;
                            }
                        }
                        break;

                    case VehicleHash.Ruston:
                        iVar1 = 430000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20463") /* Tunable: SR_HIJAK_RUSTON */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20463") /* Tunable: SR_HIJAK_RUSTON */;
                            }
                        }
                        break;

                    case VehicleHash.Turismo2:
                        iVar1 = 705000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20464") /* Tunable: SR_GROTTI_TURISMO2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20464") /* Tunable: SR_GROTTI_TURISMO2 */;
                            }
                        }
                        break;

                    case VehicleHash.Ardent:
                        iVar1 = 1150000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21552") /* Tunable: GR_BASIC_WEAPONIZED_VEHICLES_OCELOT_ARDENT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21552") /* Tunable: GR_BASIC_WEAPONIZED_VEHICLES_OCELOT_ARDENT */;
                            }
                        }
                        break;

                    case VehicleHash.Cheetah2:
                        iVar1 = 865000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21555") /* Tunable: GR_NEW_SPORTS_CARS_GROTTI_CHEETAH_CLASSIC */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21555") /* Tunable: GR_NEW_SPORTS_CARS_GROTTI_CHEETAH_CLASSIC */;
                            }
                        }
                        break;

                    case VehicleHash.NightShark:
                        iVar1 = 1245000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21553") /* Tunable: GR_BASIC_WEAPONIZED_VEHICLES_HVY_NIGHTSHARK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21553") /* Tunable: GR_BASIC_WEAPONIZED_VEHICLES_HVY_NIGHTSHARK */;
                            }
                        }
                        break;

                    case VehicleHash.Torero:
                        iVar1 = 998000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21554") /* Tunable: GR_NEW_SPORTS_CARS_PEGASSI_TORERO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21554") /* Tunable: GR_NEW_SPORTS_CARS_PEGASSI_TORERO */;
                            }
                        }
                        break;

                    case VehicleHash.Vagner:
                        iVar1 = 1535000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21556") /* Tunable: GR_NEW_SPORTS_CARS_DEWBAUCHEE_VAGNER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21556") /* Tunable: GR_NEW_SPORTS_CARS_DEWBAUCHEE_VAGNER */;
                            }
                        }
                        break;

                    case VehicleHash.XA21:
                        iVar1 = 2375000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21557") /* Tunable: GR_NEW_SPORTS_CARS_OCELOT_XA_21 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21557") /* Tunable: GR_NEW_SPORTS_CARS_OCELOT_XA_21 */;
                            }
                        }
                        break;

                    case VehicleHash.Apc:
                        iVar1 = 2325000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21544") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_HVY_APC */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21544") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_HVY_APC */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.Dune3:
                        iVar1 = 850000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21545") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_BF_DUNE_FAV */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21545") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_BF_DUNE_FAV */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.HalfTrack:
                        iVar1 = 1695000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21546") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_BRAVADO_HALF_TRACK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21546") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_BRAVADO_HALF_TRACK */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.Oppressor:
                        iVar1 = 2067669;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21547") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21547") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.Tampa3:
                        iVar1 = 1585000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21548") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_DECLASSE_WEAPONIZED_TAMPA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21548") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_DECLASSE_WEAPONIZED_TAMPA */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.TrailerSmall2:
                        iVar1 = 1400000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_21549") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_TURRETED_TRAILER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_21549") /* Tunable: GR_NEW_FULLY_WEAPONIZED_VEHICLES_TURRETED_TRAILER */;
                            }
                        }
                        iVar2 = iVar1;
                        if (!bParam2)
                        {
                            iVar1 = Round(Round((iVar1) * ((100f + (Tunables.Global_262145.Value<int>("f_21543") /* Tunable: -1237354304 */)) / 100f)));
                        }
                        break;

                    case VehicleHash.Phantom3:
                        if (!bParam2)
                        {
                            iVar1 = 1225000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_21621") /* Tunable: GR_TRUCK_PROPERTY_JOBUILT_PHANTOM_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_21621") /* Tunable: GR_TRUCK_PROPERTY_JOBUILT_PHANTOM_CUSTOM */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case VehicleHash.Hauler2:
                        if (!bParam2)
                        {
                            iVar1 = 1400000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_21622") /* Tunable: GR_TRUCK_PROPERTY_JOBUILT_HAULER_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_21622") /* Tunable: GR_TRUCK_PROPERTY_JOBUILT_HAULER_CUSTOM */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case VehicleHash.Lazer:
                        iVar1 = 6500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22739") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_P996_LAZER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22739") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_P996_LAZER */;
                            }
                        }
                        break;

                    case /*MicroLight*/ (VehicleHash)2531412055:
                        if (bParam2)
                        {
                            iVar1 = 500000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22738") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_PEGASSI_ULTRALIGHT */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22738") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_PEGASSI_ULTRALIGHT */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((500000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22758") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_PEGASSI_ULTRALIGHT */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22758") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_PEGASSI_ULTRALIGHT */;
                                }
                            }
                        }
                        break;

                    case /*Mogul*/ (VehicleHash)3545667823:
                        if (bParam2)
                        {
                            iVar1 = 2350000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22731") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_MOGUL */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22731") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_MOGUL */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((2350000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22751") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_MOGUL */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22751") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_MOGUL */;
                                }
                            }
                        }
                        break;

                    case /*Rogue*/ (VehicleHash)3319621991:
                        if (bParam2)
                        {
                            iVar1 = 1200000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22735") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_ROGUE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22735") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_ROGUE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((1200000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22755") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_ROGUE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22755") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_ROGUE */;
                                }
                            }
                        }
                        break;

                    case /*Starling*/ (VehicleHash)2594093022:
                        if (bParam2)
                        {
                            iVar1 = 2750000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22730") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_STARLING */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22730") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_STARLING */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((2750000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22750") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_STARLING */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22750") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_STARLING */;
                                }
                            }
                        }
                        break;

                    case /*Seabreeze*/ (VehicleHash)3902291871:
                        if (bParam2)
                        {
                            iVar1 = 850000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22737") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_WESTERN_SEABREEZE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22737") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_WESTERN_SEABREEZE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((850000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22757") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_WESTERN_SEABREEZE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22757") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_WESTERN_SEABREEZE */;
                                }
                            }
                        }
                        break;

                    case /*Tula*/ (VehicleHash)1043222410:
                        if (bParam2)
                        {
                            iVar1 = 3075000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22726") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_TULA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22726") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_TULA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 4100000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22746") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_TULA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22746") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_TULA */;
                                }
                            }
                        }
                        break;

                    case /*Pyro*/ (VehicleHash)2908775872:
                        if (bParam2)
                        {
                            iVar1 = 3350000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22728") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_PYRO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22728") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_PYRO */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((3350000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22748") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_PYRO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22748") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_PYRO */;
                                }
                            }
                        }
                        break;

                    case /*Molotok*/ (VehicleHash)1565978651:
                        if (bParam2)
                        {
                            iVar1 = 3600000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22727") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_V65_MOLOTOK */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22727") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_V65_MOLOTOK */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((3600000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22747") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_V65_MOLOTOK */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22747") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_V65_MOLOTOK */;
                                }
                            }
                        }
                        break;

                    case /*Nokota*/ (VehicleHash)1036591958:
                        if (bParam2)
                        {
                            iVar1 = 1995000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22732") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_P45_NOKOTA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22732") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_P45_NOKOTA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((1995000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22752") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_P45_NOKOTA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22752") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_P45_NOKOTA */;
                                }
                            }
                        }
                        break;

                    case /*Bombushka*/ (VehicleHash)4262088844:
                        if (bParam2)
                        {
                            iVar1 = 3562500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22725") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_BOMBUSHKA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22725") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_BOMBUSHKA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 4750000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22745") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_BOMBUSHKA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22745") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_BOMBUSHKA */;
                                }
                            }
                        }
                        break;

                    case /*Hunter*/ (VehicleHash)4252008158:
                        if (bParam2)
                        {
                            iVar1 = 3100000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22729") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_HUNTER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22729") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_HUNTER */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((3100000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22749") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_HUNTER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22749") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_HUNTER */;
                                }
                            }
                        }
                        break;

                    case /*Havok*/ (VehicleHash)2310691317:
                        if (bParam2)
                        {
                            iVar1 = 1730000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22733") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_NAGASAKI_HAVOK */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22733") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_NAGASAKI_HAVOK */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((1730000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22753") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_NAGASAKI_HAVOK */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22753") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_NAGASAKI_HAVOK */;
                                }
                            }
                        }
                        break;

                    case /*Howard*/ (VehicleHash)3287439187:
                        if (bParam2)
                        {
                            iVar1 = 975000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22736") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_HOWARD_NX25 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22736") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_HOWARD_NX25 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((975000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22756") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_HOWARD_NX25 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22756") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_HOWARD_NX25 */;
                                }
                            }
                        }
                        break;

                    case /*Alphaz1*/ (VehicleHash)2771347558:
                        if (bParam2)
                        {
                            iVar1 = 1595000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22734") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_ALPHAZ1 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22734") /* Tunable: SMUG_VEHICLES_TRADE_PRICE_ALPHAZ1 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = Round((1595000) * ((100f + (33)) / 100f));
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_22754") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_ALPHAZ1 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_22754") /* Tunable: SMUG_VEHICLES_BUY_IT_NOW_PRICE_ALPHAZ1 */;
                                }
                            }
                        }
                        break;

                    case /*Cyclone*/ (VehicleHash)1392481335:
                        iVar1 = 1890000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22740") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_COIL_CYCLONE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22740") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_COIL_CYCLONE */;
                            }
                        }
                        break;

                    case /*Visione*/ (VehicleHash)3296789504:
                        iVar1 = 2250000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22741") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_GROTTI_VISIONE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22741") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_GROTTI_VISIONE */;
                            }
                        }
                        break;

                    case /*Vigilante*/ (VehicleHash)3052358707:
                        iVar1 = 3750000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22744") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_GROTTI_VIGILANTE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22744") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_GROTTI_VIGILANTE */;
                            }
                        }
                        break;

                    case /*Retinue*/ (VehicleHash)1841130506:
                        iVar1 = 615000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22742") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_VAPID_RETINUE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22742") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_VAPID_RETINUE */;
                            }
                        }
                        break;

                    case /*RapidGT3*/ (VehicleHash)2049897956:
                        iVar1 = 885000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_22743") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_DEWBAUCHEE_RAPIDGT_CLASSIC */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_22743") /* Tunable: SMUG_VEHICLES_CARS_TRADE_PRICE_DEWBAUCHEE_RAPIDGT_CLASSIC */;
                            }
                        }
                        break;
                }
                switch ((VehicleHash)vehicleModel)
                {
                    case /*Deluxo*/ (VehicleHash)1483171323:
                        if (bParam2)
                        {
                            iVar1 = 4312500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24074") /* Tunable: H2_VEHICLES_TRADE_PRICE_DELUXO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24074") /* Tunable: H2_VEHICLES_TRADE_PRICE_DELUXO */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 5750000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24065") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_DELUXO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24065") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_DELUXO */;
                                }
                            }
                            iVar2 = 4312500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24074") /* Tunable: H2_VEHICLES_TRADE_PRICE_DELUXO */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24074") /* Tunable: H2_VEHICLES_TRADE_PRICE_DELUXO */;
                                }
                            }
                        }
                        break;

                    case /*Stromberg*/ (VehicleHash)886810209:
                        if (bParam2)
                        {
                            iVar1 = 1875000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24075") /* Tunable: H2_VEHICLES_TRADE_PRICE_STROMBERG */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24075") /* Tunable: H2_VEHICLES_TRADE_PRICE_STROMBERG */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2500000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24066") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_STROMBERG */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24066") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_STROMBERG */;
                                }
                            }
                            iVar2 = 1875000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24075") /* Tunable: H2_VEHICLES_TRADE_PRICE_STROMBERG */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24075") /* Tunable: H2_VEHICLES_TRADE_PRICE_STROMBERG */;
                                }
                            }
                        }
                        break;

                    case /*Riot2*/ (VehicleHash)2601952180:
                        if (bParam2)
                        {
                            iVar1 = 2350000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24076") /* Tunable: H2_VEHICLES_TRADE_PRICE_RCV */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24076") /* Tunable: H2_VEHICLES_TRADE_PRICE_RCV */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 3125500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24067") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_RCV */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24067") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_RCV */;
                                }
                            }
                            iVar2 = 2350000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24076") /* Tunable: H2_VEHICLES_TRADE_PRICE_RCV */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24076") /* Tunable: H2_VEHICLES_TRADE_PRICE_RCV */;
                                }
                            }
                        }
                        break;

                    case /*Chernobog*/ (VehicleHash)3602674979:
                        if (bParam2)
                        {
                            iVar1 = 1125000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24077") /* Tunable: H2_VEHICLES_TRADE_PRICE_CHERNOBOG */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24077") /* Tunable: H2_VEHICLES_TRADE_PRICE_CHERNOBOG */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1500000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24068") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_CHERNOBOG */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24068") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_CHERNOBOG */;
                                }
                            }
                            iVar2 = 1125000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24077") /* Tunable: H2_VEHICLES_TRADE_PRICE_CHERNOBOG */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24077") /* Tunable: H2_VEHICLES_TRADE_PRICE_CHERNOBOG */;
                                }
                            }
                        }
                        break;

                    case /*Khanjali*/ (VehicleHash)2859440138:
                        if (bParam2)
                        {
                            iVar1 = 2895000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24079") /* Tunable: H2_VEHICLES_TRADE_PRICE_KHANJALI */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24079") /* Tunable: H2_VEHICLES_TRADE_PRICE_KHANJALI */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 3850350;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24070") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_KHANJALI */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24070") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_KHANJALI */;
                                }
                            }
                            iVar2 = 2895000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24079") /* Tunable: H2_VEHICLES_TRADE_PRICE_KHANJALI */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24079") /* Tunable: H2_VEHICLES_TRADE_PRICE_KHANJALI */;
                                }
                            }
                        }
                        break;

                    case /*Akula*/ (VehicleHash)1181327175:
                        if (bParam2)
                        {
                            iVar1 = 3375000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24080") /* Tunable: H2_VEHICLES_TRADE_PRICE_AKULA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24080") /* Tunable: H2_VEHICLES_TRADE_PRICE_AKULA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 4500000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24071") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_AKULA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24071") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_AKULA */;
                                }
                            }
                            iVar2 = 3375000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24080") /* Tunable: H2_VEHICLES_TRADE_PRICE_AKULA */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24080") /* Tunable: H2_VEHICLES_TRADE_PRICE_AKULA */;
                                }
                            }
                        }
                        break;

                    case /*Thruster*/ (VehicleHash)1489874736:
                        if (bParam2)
                        {
                            iVar1 = 1875000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24073") /* Tunable: H2_VEHICLES_TRADE_PRICE_THRUSTER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24073") /* Tunable: H2_VEHICLES_TRADE_PRICE_THRUSTER */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2500000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24064") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_THRUSTER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24064") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_THRUSTER */;
                                }
                            }
                            iVar2 = 1875000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24073") /* Tunable: H2_VEHICLES_TRADE_PRICE_THRUSTER */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24073") /* Tunable: H2_VEHICLES_TRADE_PRICE_THRUSTER */;
                                }
                            }
                        }
                        break;

                    case /*Barrage*/ (VehicleHash)4081974053:
                        if (bParam2)
                        {
                            iVar1 = 1595000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24078") /* Tunable: H2_VEHICLES_TRADE_PRICE_BARRAGE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24078") /* Tunable: H2_VEHICLES_TRADE_PRICE_BARRAGE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2121350;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24069") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_BARRAGE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24069") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_BARRAGE */;
                                }
                            }
                            iVar2 = 1595000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24078") /* Tunable: H2_VEHICLES_TRADE_PRICE_BARRAGE */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24078") /* Tunable: H2_VEHICLES_TRADE_PRICE_BARRAGE */;
                                }
                            }
                        }
                        break;

                    case /*Volatol*/ (VehicleHash)447548909:
                        if (bParam2)
                        {
                            iVar1 = 2800000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24081") /* Tunable: H2_VEHICLES_TRADE_PRICE_VOLATOL */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24081") /* Tunable: H2_VEHICLES_TRADE_PRICE_VOLATOL */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 3724000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24072") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_VOLATOL */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24072") /* Tunable: H2_VEHICLES_BUY_IT_NOW_PRICE_VOLATOL */;
                                }
                            }
                            iVar2 = 2800000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24081") /* Tunable: H2_VEHICLES_TRADE_PRICE_VOLATOL */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24081") /* Tunable: H2_VEHICLES_TRADE_PRICE_VOLATOL */;
                                }
                            }
                        }
                        break;

                    case /*Comet4*/ (VehicleHash)1561920505:
                        iVar1 = 710000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24082") /* Tunable: H2_VEHICLES_PRICE_COMET_SAFARI */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24082") /* Tunable: H2_VEHICLES_PRICE_COMET_SAFARI */;
                            }
                        }
                        break;

                    case /*Neon*/ (VehicleHash)2445973230:
                        iVar1 = 1500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24094") /* Tunable: H2_VEHICLES_PRICE_NEON */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24094") /* Tunable: H2_VEHICLES_PRICE_NEON */;
                            }
                        }
                        break;

                    case /*Streiter*/ (VehicleHash)1741861769:
                        iVar1 = 500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24087") /* Tunable: H2_VEHICLES_PRICE_STREITER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24087") /* Tunable: H2_VEHICLES_PRICE_STREITER */;
                            }
                        }
                        break;

                    case /*Sentinel3*/ (VehicleHash)1104234922:
                        if (bParam2)
                        {
                            iVar1 = 487500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28724") /* Tunable: CH_TRADE_PRICE_SENTINAL3 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28724") /* Tunable: CH_TRADE_PRICE_SENTINAL3 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 650000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24097") /* Tunable: H2_VEHICLES_PRICE_SENTINEL_CLASSIC */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24097") /* Tunable: H2_VEHICLES_PRICE_SENTINEL_CLASSIC */;
                                }
                            }
                            iVar2 = 487500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28724") /* Tunable: CH_TRADE_PRICE_SENTINAL3 */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28724") /* Tunable: CH_TRADE_PRICE_SENTINAL3 */;
                                }
                            }
                        }
                        break;

                    case /*Yosemite*/ (VehicleHash)1871995513:
                        iVar1 = 485000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24096") /* Tunable: H2_VEHICLES_PRICE_YOSEMITE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24096") /* Tunable: H2_VEHICLES_PRICE_YOSEMITE */;
                            }
                        }
                        break;

                    case /*Sc1*/ (VehicleHash)1352136073:
                        iVar1 = 1603000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24086") /* Tunable: H2_VEHICLES_PRICE_SC1 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24086") /* Tunable: H2_VEHICLES_PRICE_SC1 */;
                            }
                        }
                        break;

                    case /*Autarch*/ (VehicleHash)3981782132:
                        iVar1 = 1955000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24091") /* Tunable: H2_VEHICLES_PRICE_AUTARCH */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24091") /* Tunable: H2_VEHICLES_PRICE_AUTARCH */;
                            }
                        }
                        break;

                    case /*Gt500*/ (VehicleHash)2215179066:
                        iVar1 = 785000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24100") /* Tunable: H2_VEHICLES_PRICE_GT500 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24100") /* Tunable: H2_VEHICLES_PRICE_GT500 */;
                            }
                        }
                        break;

                    case /*Hustler*/ (VehicleHash)600450546:
                        iVar1 = 625000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24088") /* Tunable: H2_VEHICLES_PRICE_HUSTLER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24088") /* Tunable: H2_VEHICLES_PRICE_HUSTLER */;
                            }
                        }
                        break;

                    case /*Revolter*/ (VehicleHash)3884762073:
                        iVar1 = 1610000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24084") /* Tunable: H2_VEHICLES_PRICE_REVOLTER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24084") /* Tunable: H2_VEHICLES_PRICE_REVOLTER */;
                            }
                        }
                        break;

                    case /*Pariah*/ (VehicleHash)867799010:
                        iVar1 = 1420000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24095") /* Tunable: H2_VEHICLES_PRICE_PARIAH */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24095") /* Tunable: H2_VEHICLES_PRICE_PARIAH */;
                            }
                        }
                        break;

                    case /*Raiden*/ (VehicleHash)2765724541:
                        iVar1 = 1375000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24098") /* Tunable: H2_VEHICLES_PRICE_RAIDEN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24098") /* Tunable: H2_VEHICLES_PRICE_RAIDEN */;
                            }
                        }
                        break;

                    case /*Savestra*/ (VehicleHash)903794909:
                        iVar1 = 990000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24083") /* Tunable: H2_VEHICLES_PRICE_SAVESTRA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24083") /* Tunable: H2_VEHICLES_PRICE_SAVESTRA */;
                            }
                        }
                        break;

                    case /*Riata*/ (VehicleHash)2762269779:
                        iVar1 = 380000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24093") /* Tunable: H2_VEHICLES_PRICE_RIATA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24093") /* Tunable: H2_VEHICLES_PRICE_RIATA */;
                            }
                        }
                        break;

                    case /*Hermes*/ (VehicleHash)15219735:
                        iVar1 = 535000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24089") /* Tunable: H2_VEHICLES_PRICE_HERMES */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24089") /* Tunable: H2_VEHICLES_PRICE_HERMES */;
                            }
                        }
                        break;

                    case /*Comet5*/ (VehicleHash)661493923:
                        iVar1 = 1145000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24092") /* Tunable: H2_VEHICLES_PRICE_COMET_GT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24092") /* Tunable: H2_VEHICLES_PRICE_COMET_GT */;
                            }
                        }
                        break;

                    case /*Z190*/ (VehicleHash)838982985:
                        iVar1 = 900000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24090") /* Tunable: H2_VEHICLES_PRICE_190Z */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24090") /* Tunable: H2_VEHICLES_PRICE_190Z */;
                            }
                        }
                        break;

                    case /*Viseris*/ (VehicleHash)3903371924:
                        iVar1 = 875000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24085") /* Tunable: H2_VEHICLES_PRICE_VISERIS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24085") /* Tunable: H2_VEHICLES_PRICE_VISERIS */;
                            }
                        }
                        break;

                    case /*Kamacho*/ (VehicleHash)4173521127:
                        iVar1 = 345000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24099") /* Tunable: H2_VEHICLES_PRICE_KAMACHO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24099") /* Tunable: H2_VEHICLES_PRICE_KAMACHO */;
                            }
                        }
                        break;

                    case /*Gb200*/ (VehicleHash)1909189272:
                        iVar1 = 940000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24300") /* Tunable: ASSAULT_VEHICLES_VAPID_GB200 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24300") /* Tunable: ASSAULT_VEHICLES_VAPID_GB200 */;
                            }
                        }
                        break;

                    case /*Fagaloa*/ (VehicleHash)1617472902:
                        iVar1 = 335000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24306") /* Tunable: ASSAULT_VEHICLES_VULCAR_FAGALOA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24306") /* Tunable: ASSAULT_VEHICLES_VULCAR_FAGALOA */;
                            }
                        }
                        break;

                    case /*Ellie*/ (VehicleHash)3027423925:
                        if (bParam2)
                        {
                            iVar1 = 423750;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28726") /* Tunable: CH_TRADE_PRICE_ELLIE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28726") /* Tunable: CH_TRADE_PRICE_ELLIE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 565000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24304") /* Tunable: ASSAULT_VEHICLES_VAPID_ELLIE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24304") /* Tunable: ASSAULT_VEHICLES_VAPID_ELLIE */;
                                }
                            }
                            iVar2 = 423750;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28726") /* Tunable: CH_TRADE_PRICE_ELLIE */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28726") /* Tunable: CH_TRADE_PRICE_ELLIE */;
                                }
                            }
                        }
                        break;

                    case /*Issi3*/ (VehicleHash)931280609:
                        iVar1 = 360000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_24305") /* Tunable: ASSAULT_VEHICLES_WEENY_ISSI_CLASSIC */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24305") /* Tunable: ASSAULT_VEHICLES_WEENY_ISSI_CLASSIC */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = Round((360000) * 0.75f);
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26130") /* Tunable: AW_TRADE_PRICE_ISSI */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26130") /* Tunable: AW_TRADE_PRICE_ISSI */;
                            }
                        }
                        break;

                    case /*Michelli*/ (VehicleHash)1046206681:
                        iVar1 = 1225000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24299") /* Tunable: ASSAULT_VEHICLES_LAMPADATI_MICHELLI_GT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24299") /* Tunable: ASSAULT_VEHICLES_LAMPADATI_MICHELLI_GT */;
                            }
                        }
                        break;

                    case /*FlashGT*/ (VehicleHash)3035832600:
                        iVar1 = 1675000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24298") /* Tunable: ASSAULT_VEHICLES_VAPID_FLASH_GT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24298") /* Tunable: ASSAULT_VEHICLES_VAPID_FLASH_GT */;
                            }
                        }
                        break;

                    case /*Hotring*/ (VehicleHash)1115909093:
                        iVar1 = 830000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24301") /* Tunable: ASSAULT_VEHICLES_DECLASSE_HOTRING_SABRE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24301") /* Tunable: ASSAULT_VEHICLES_DECLASSE_HOTRING_SABRE */;
                            }
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 622500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_34193") /* Tunable: XM22_TRADE_PRICE_HOTRING */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_34193") /* Tunable: XM22_TRADE_PRICE_HOTRING */;
                            }
                        }
                        break;

                    case /*Tezeract*/ (VehicleHash)1031562256:
                        iVar1 = 2825000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24294") /* Tunable: ASSAULT_VEHICLES_PEGASSI_TEZERACT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24294") /* Tunable: ASSAULT_VEHICLES_PEGASSI_TEZERACT */;
                            }
                        }
                        break;

                    case /*Tyrant*/ (VehicleHash)3918533058:
                        iVar1 = 2515000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24295") /* Tunable: ASSAULT_VEHICLES_OVERFLOD_TYRANT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24295") /* Tunable: ASSAULT_VEHICLES_OVERFLOD_TYRANT */;
                            }
                        }
                        break;

                    case /*Dominator3*/ (VehicleHash)3308022675:
                        iVar1 = 725000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_24303") /* Tunable: ASSAULT_VEHICLES_VAPID_DOMINATOR_GTX */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_24303") /* Tunable: ASSAULT_VEHICLES_VAPID_DOMINATOR_GTX */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = Round((725000) * 0.75f);
                        }
                        break;

                    case /*Taipan*/ (VehicleHash)3160260734:
                        iVar1 = 1980000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24297") /* Tunable: ASSAULT_VEHICLES_CHEVAL_TAIPAN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24297") /* Tunable: ASSAULT_VEHICLES_CHEVAL_TAIPAN */;
                            }
                        }
                        break;

                    case /*Entity2*/ (VehicleHash)2174267100:
                        iVar1 = 2305000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24296") /* Tunable: ASSAULT_VEHICLES_OVERFLOD_ENTITY_XXR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24296") /* Tunable: ASSAULT_VEHICLES_OVERFLOD_ENTITY_XXR */;
                            }
                        }
                        break;

                    case /*Jester3*/ (VehicleHash)4080061290:
                        iVar1 = 790000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24302") /* Tunable: ASSAULT_VEHICLES_DINKA_JESTER_CLASSIC */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24302") /* Tunable: ASSAULT_VEHICLES_DINKA_JESTER_CLASSIC */;
                            }
                        }
                        break;

                    case /*Cheburek*/ (VehicleHash)3306466016:
                        iVar1 = 145000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24307") /* Tunable: ASSAULT_VEHICLES_VULCAR_CHEBUREK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24307") /* Tunable: ASSAULT_VEHICLES_VULCAR_CHEBUREK */;
                            }
                        }
                        break;

                    case /*Caracara*/ (VehicleHash)1254014755:
                        iVar1 = 1775000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24308") /* Tunable: ASSAULT_VEHICLES_VAPID_CARACARA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24308") /* Tunable: ASSAULT_VEHICLES_VAPID_CARACARA */;
                            }
                        }
                        break;

                    case /*Seasparrow*/ (VehicleHash)3568198617:
                        iVar1 = 1815000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24309") /* Tunable: ASSAULT_VEHICLES_SEA_SPARROW */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24309") /* Tunable: ASSAULT_VEHICLES_SEA_SPARROW */;
                            }
                        }
                        break;

                    case /*Terbyte*/ (VehicleHash)2306538597:
                        if (!bParam2)
                        {
                            iVar1 = 1375000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_25061") /* Tunable: BB_BENEFACTOR_TERRORBYTE */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_25061") /* Tunable: BB_BENEFACTOR_TERRORBYTE */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 0;
                        }
                        break;

                    case /*Mule4*/ (VehicleHash)1945374990:
                        if (bParam2)
                        {
                            iVar1 = 72000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24978") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24978") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 95760;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24983") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24983") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */;
                                }
                            }
                            iVar2 = 72000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24978") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24978") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MAIBATSU_MULE_CUSTOM */;
                                }
                            }
                        }
                        break;

                    case /*Pounder2*/ (VehicleHash)1653666139:
                        if (bParam2)
                        {
                            iVar1 = 241000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24977") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24977") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 320530;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24982") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24982") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */;
                                }
                            }
                            iVar2 = 241000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24977") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24977") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_MTL_POUNDER_CUSTOM */;
                                }
                            }
                        }
                        break;

                    case /*Swinger*/ (VehicleHash)500482303:
                        iVar1 = 909000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24949") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_OCELOT_SWINGER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24949") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_OCELOT_SWINGER */;
                            }
                        }
                        break;

                    case /*Menacer*/ (VehicleHash)2044532910:
                        iVar1 = 1775000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24980") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_HVY_MENACER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24980") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_HVY_MENACER */;
                            }
                        }
                        break;

                    case /*Scramjet*/ (VehicleHash)3656405053:
                        iVar1 = 4000000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24985") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_DECLASSE_SCRAMJET */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24985") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_DECLASSE_SCRAMJET */;
                            }
                        }
                        break;

                    case /*Strikeforce*/ (VehicleHash)1692272545:
                        iVar1 = 3800000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24981") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_B_11_STRIKEFORCE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24981") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_B_11_STRIKEFORCE */;
                            }
                        }
                        break;

                    case /*Oppressor2*/ (VehicleHash)2069146067:
                        if (bParam2)
                        {
                            iVar1 = 6000000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24979") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24979") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 8000000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24984") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24984") /* Tunable: BB_BUY_IT_NOW_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */;
                                }
                            }
                            iVar2 = 6000000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24979") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24979") /* Tunable: BB_TRADE_PRICE_WEAPONIZED_VEHICLES_PEGASSI_OPPRESSOR_MK_II */;
                                }
                            }
                        }
                        break;

                    case /*Patriot2*/ (VehicleHash)3874056184:
                        if (bParam2)
                        {
                            iVar1 = 460000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24946") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24946") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 611800;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24986") /* Tunable: BB_BUY_IT_NOW_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24986") /* Tunable: BB_BUY_IT_NOW_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */;
                                }
                            }
                            iVar2 = 460000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24946") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24946") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_MAMMOTH_PATRIOT_STRETCH */;
                                }
                            }
                        }
                        break;

                    case /*Stafford*/ (VehicleHash)321186144:
                        iVar1 = 1272000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24947") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_ENUS_STAFFORD */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24947") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_ENUS_STAFFORD */;
                            }
                        }
                        break;

                    case /*Freecrawler*/ (VehicleHash)4240635011:
                        iVar1 = 597000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_24948") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_CANIS_FREECRAWLER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_24948") /* Tunable: BB_TRADE_PRICE_HIGH_END_VEHICLES_CANIS_FREECRAWLER */;
                            }
                        }
                        break;

                    case /*Blimp3*/ (VehicleHash)3987008919:
                        if (bParam2)
                        {
                            iVar1 = 895000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24951") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_BLIMP */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24951") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_BLIMP */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1190350;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24988") /* Tunable: BB_BUY_IT_NOW_PRICE_MISC_VEHICLES_BLIMP */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24988") /* Tunable: BB_BUY_IT_NOW_PRICE_MISC_VEHICLES_BLIMP */;
                                }
                            }
                            iVar2 = 895000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24951") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_BLIMP */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24951") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_BLIMP */;
                                }
                            }
                        }
                        break;

                    case /*Pbus2*/ (VehicleHash)345756458:
                        if (bParam2)
                        {
                            iVar1 = 1385000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24950") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_FESTIVAL_BUS */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24950") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_FESTIVAL_BUS */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1842050;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24987") /* Tunable: BB_BUY_IT_NOW_PRICE_MISC_VEHICLES_FESTIVAL_BUS */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_24987") /* Tunable: BB_BUY_IT_NOW_PRICE_MISC_VEHICLES_FESTIVAL_BUS */;
                                }
                            }
                            iVar2 = 1385000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_24950") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_FESTIVAL_BUS */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_24950") /* Tunable: BB_TRADE_PRICE_MISC_VEHICLES_FESTIVAL_BUS */;
                                }
                            }
                        }
                        break;

                    case /*Cerberus*/ (VehicleHash)3493417227:
                        iVar1 = 3870300;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26196") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_CERBERUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26196") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_CERBERUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2910000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26211") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_CERBERUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26211") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_CERBERUS */;
                            }
                        }
                        break;

                    case /*Cerberus2*/ (VehicleHash)679453769:
                        iVar1 = 3870300;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26201") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_CERBERUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26201") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_CERBERUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2910000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26216") /* Tunable: AW_TRADE_PRICE_SCIFI_CERBERUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26216") /* Tunable: AW_TRADE_PRICE_SCIFI_CERBERUS */;
                            }
                        }
                        break;

                    case /*Cerberus3*/ (VehicleHash)1909700336:
                        iVar1 = 3870300;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26206") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_CERBERUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26206") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_CERBERUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2910000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26221") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_CERBERUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26221") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_CERBERUS */;
                            }
                        }
                        break;

                    case /*Brutus*/ (VehicleHash)2139203625:
                        iVar1 = 2666650;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26197") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_BRUTUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26197") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_BRUTUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2005000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26212") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_BRUTUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26212") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_BRUTUS */;
                            }
                        }
                        break;

                    case /*Brutus2*/ (VehicleHash)2403970600:
                        iVar1 = 2666650;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26202") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_BRUTUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26202") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_BRUTUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2005000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26217") /* Tunable: AW_TRADE_PRICE_SCIFI_BRUTUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26217") /* Tunable: AW_TRADE_PRICE_SCIFI_BRUTUS */;
                            }
                        }
                        break;

                    case /*Brutus3*/ (VehicleHash)2038858402:
                        iVar1 = 2666650;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26207") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_BRUTUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26207") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_BRUTUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2005000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26222") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_BRUTUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26222") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_BRUTUS */;
                            }
                        }
                        break;

                    case /*Scarab*/ (VehicleHash)3147997943:
                        iVar1 = 3076290;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26198") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_SCARAB */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26198") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_SCARAB */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2313000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26213") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_SCARAB */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26213") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_SCARAB */;
                            }
                        }
                        break;

                    case /*Scarab2*/ (VehicleHash)1542143200:
                        iVar1 = 3076290;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26203") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_SCARAB */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26203") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_SCARAB */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2313000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26218") /* Tunable: AW_TRADE_PRICE_SCIFI_SCARAB */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26218") /* Tunable: AW_TRADE_PRICE_SCIFI_SCARAB */;
                            }
                        }
                        break;

                    case /*Scarab3*/ (VehicleHash)3715219435:
                        iVar1 = 3076290;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26208") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_SCARAB */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26208") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_SCARAB */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2313000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26223") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_SCARAB */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26223") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_SCARAB */;
                            }
                        }
                        break;

                    case /*Imperator*/ (VehicleHash)444994115:
                        iVar1 = 2284940;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26199") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_IMPERATOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26199") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_IMPERATOR */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1718000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26214") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_IMPERATOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26214") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_IMPERATOR */;
                            }
                        }
                        break;

                    case /*Imperator2*/ (VehicleHash)1637620610:
                        iVar1 = 2284940;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26204") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_IMPERATOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26204") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_IMPERATOR */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1718000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26219") /* Tunable: AW_TRADE_PRICE_SCIFI_IMPERATOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26219") /* Tunable: AW_TRADE_PRICE_SCIFI_IMPERATOR */;
                            }
                        }
                        break;

                    case /*Imperator3*/ (VehicleHash)3539435063:
                        iVar1 = 2284940;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26209") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_IMPERATOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26209") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_IMPERATOR */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1718000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26224") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_IMPERATOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26224") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_IMPERATOR */;
                            }
                        }
                        break;

                    case /*Zr380*/ (VehicleHash)540101442:
                        iVar1 = 2138640;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26200") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_ZR380 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26200") /* Tunable: AW_BUY_IT_NOW_PRICE_APOCALYPSE_ZR380 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1608000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26215") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_ZR380 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26215") /* Tunable: AW_TRADE_PRICE_APOCALYPSE_ZR380 */;
                            }
                        }
                        break;

                    case /*Zr3802*/ (VehicleHash)3188846534:
                        iVar1 = 2138640;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26205") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_ZR380 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26205") /* Tunable: AW_BUY_IT_NOW_PRICE_SCIFI_ZR380 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1608000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26220") /* Tunable: AW_TRADE_PRICE_SCIFI_ZR380 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26220") /* Tunable: AW_TRADE_PRICE_SCIFI_ZR380 */;
                            }
                        }
                        break;

                    case /*Zr3803*/ (VehicleHash)2816263004:
                        iVar1 = 2138640;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26210") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_ZR380 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26210") /* Tunable: AW_BUY_IT_NOW_PRICE_CONSUMERISM_ZR380 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1608000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26225") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_ZR380 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26225") /* Tunable: AW_TRADE_PRICE_CONSUMERISM_ZR380 */;
                            }
                        }
                        break;

                    case /*Impaler*/ (VehicleHash)2198276962:
                        iVar1 = 331835;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26124") /* Tunable: AW_BUY_IT_NOW_PRICE_IMPALER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26124") /* Tunable: AW_BUY_IT_NOW_PRICE_IMPALER */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 249500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_26129") /* Tunable: AW_TRADE_PRICE_IMPALER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_26129") /* Tunable: AW_TRADE_PRICE_IMPALER */;
                            }
                        }
                        break;

                    case /*Vamos*/ (VehicleHash)4245851645:
                        iVar1 = 596000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26231") /* Tunable: AW_SALE_PRICE_VAMOS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26231") /* Tunable: AW_SALE_PRICE_VAMOS */;
                        }
                        break;

                    case /*Tulip*/ (VehicleHash)1456744817:
                        iVar1 = 718000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26233") /* Tunable: AW_SALE_PRICE_TULIP */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26233") /* Tunable: AW_SALE_PRICE_TULIP */;
                        }
                        break;

                    case /*Deveste*/ (VehicleHash)1591739866:
                        iVar1 = 1795000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26226") /* Tunable: AW_SALE_PRICE_DEVESTE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26226") /* Tunable: AW_SALE_PRICE_DEVESTE */;
                        }
                        break;

                    case /*Schlagen*/ (VehicleHash)3787471536:
                        iVar1 = 1300000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26227") /* Tunable: AW_SALE_PRICE_SCHLAGEN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26227") /* Tunable: AW_SALE_PRICE_SCHLAGEN */;
                        }
                        break;

                    case /*Toros*/ (VehicleHash)3126015148:
                        iVar1 = 498000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26228") /* Tunable: AW_SALE_PRICE_TOROS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26228") /* Tunable: AW_SALE_PRICE_TOROS */;
                        }
                        break;

                    case /*Deviant*/ (VehicleHash)1279262537:
                        iVar1 = 512000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26229") /* Tunable: AW_SALE_PRICE_DEVIANT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26229") /* Tunable: AW_SALE_PRICE_DEVIANT */;
                        }
                        break;

                    case /*Clique*/ (VehicleHash)2728360112:
                        iVar1 = 909000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26230") /* Tunable: AW_SALE_PRICE_CLIQUE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26230") /* Tunable: AW_SALE_PRICE_CLIQUE */;
                        }
                        break;

                    case /*ItaliGTo*/ (VehicleHash)3963499524:
                        iVar1 = 1965000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26232") /* Tunable: AW_SALE_PRICE_GTO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26232") /* Tunable: AW_SALE_PRICE_GTO */;
                        }
                        break;

                    case /*Rcbandito*/ (VehicleHash)4008920556:
                        iVar1 = 1590000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26234") /* Tunable: AW_SALE_PRICE_BANDITO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26234") /* Tunable: AW_SALE_PRICE_BANDITO */;
                        }
                        break;

                    case /*Blista3*/ (VehicleHash)3703315515:
                        iVar1 = 0;
                        break;

                    case /*Slamvan4*/ (VehicleHash)2233918197:
                        iVar1 = 0;
                        break;

                    case /*Slamvan5*/ (VehicleHash)373261600:
                        iVar1 = 100000;
                        break;

                    case /*Thrax*/ (VehicleHash)1044193113:
                        iVar1 = 2325000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27079") /* Tunable: VC_SALE_PRICE_THRAX */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27079") /* Tunable: VC_SALE_PRICE_THRAX */;
                        }
                        break;

                    case /*Drafter*/ (VehicleHash)686471183:
                        iVar1 = 718000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27080") /* Tunable: VC_SALE_PRICE_DRAFTER_8F */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27080") /* Tunable: VC_SALE_PRICE_DRAFTER_8F */;
                        }
                        break;

                    case /*Locust*/ (VehicleHash)3353694737:
                        iVar1 = 1625000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27076") /* Tunable: VC_SALE_PRICE_LOCUST */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27076") /* Tunable: VC_SALE_PRICE_LOCUST */;
                        }
                        break;

                    case /*Novak*/ (VehicleHash)2465530446:
                        iVar1 = 608000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27082") /* Tunable: VC_SALE_PRICE_NOVAK */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27082") /* Tunable: VC_SALE_PRICE_NOVAK */;
                        }
                        break;

                    case /*Zorrusso*/ (VehicleHash)3612858749:
                        iVar1 = 1925000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27081") /* Tunable: VC_SALE_PRICE_ZORRUSSO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27081") /* Tunable: VC_SALE_PRICE_ZORRUSSO */;
                        }
                        break;

                    case /*Gauntlet3*/ (VehicleHash)722226637:
                        if (bParam2)
                        {
                            iVar1 = 461250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28725") /* Tunable: CH_TRADE_PRICE_GAUNTLET3 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28725") /* Tunable: CH_TRADE_PRICE_GAUNTLET3 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 615000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_27077") /* Tunable: VC_SALE_PRICE_GAUNTLET_CLASSIC */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_27077") /* Tunable: VC_SALE_PRICE_GAUNTLET_CLASSIC */;
                                }
                            }
                            iVar2 = 461250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28725") /* Tunable: CH_TRADE_PRICE_GAUNTLET3 */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28725") /* Tunable: CH_TRADE_PRICE_GAUNTLET3 */;
                                }
                            }
                        }
                        break;

                    case /*Issi7*/ (VehicleHash)1854776567:
                        iVar1 = 897000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27083") /* Tunable: 1101391290 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27083") /* Tunable: 1101391290 */;
                        }
                        break;

                    case /*Zion3*/ (VehicleHash)1862507111:
                        iVar1 = 812000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27078") /* Tunable: VC_SALE_PRICE_ZION_CLASSIC */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27078") /* Tunable: VC_SALE_PRICE_ZION_CLASSIC */;
                        }
                        break;

                    case /*Nebula*/ (VehicleHash)3412338231:
                        iVar1 = 797000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27085") /* Tunable: VC_SALE_PRICE_NEBULA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27085") /* Tunable: VC_SALE_PRICE_NEBULA */;
                        }
                        break;

                    case /*Hellion*/ (VehicleHash)3932816511:
                        iVar1 = 835000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27084") /* Tunable: VC_SALE_PRICE_HELLION */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27084") /* Tunable: VC_SALE_PRICE_HELLION */;
                        }
                        break;

                    case /*Dynasty*/ (VehicleHash)310284501:
                        iVar1 = 450000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27086") /* Tunable: VC_SALE_PRICE_DYNASTY */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27086") /* Tunable: VC_SALE_PRICE_DYNASTY */;
                        }
                        break;

                    case /*Rrocket*/ (VehicleHash)916547552:
                        iVar1 = 925000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27094") /* Tunable: VC_SALE_PRICE_RAMPANT_ROCKET */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27094") /* Tunable: VC_SALE_PRICE_RAMPANT_ROCKET */;
                        }
                        break;

                    case /*Peyote2*/ (VehicleHash)2490551588:
                        iVar1 = 805000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27093") /* Tunable: VC_SALE_PRICE_GASSER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27093") /* Tunable: VC_SALE_PRICE_GASSER */;
                        }
                        break;

                    case /*Gauntlet4*/ (VehicleHash)1934384720:
                        iVar1 = 745000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27092") /* Tunable: VC_SALE_PRICE_GAUNTLET */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27092") /* Tunable: VC_SALE_PRICE_GAUNTLET */;
                        }
                        break;

                    case /*Caracara2*/ (VehicleHash)2945871676:
                        iVar1 = 875000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27091") /* Tunable: VC_SALE_PRICE_CARACARA_4X4 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27091") /* Tunable: VC_SALE_PRICE_CARACARA_4X4 */;
                        }
                        break;

                    case /*Jugular*/ (VehicleHash)4086055493:
                        if (bParam2)
                        {
                            iVar1 = 918750;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28723") /* Tunable: CH_TRADE_PRICE_JUGULAR */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28723") /* Tunable: CH_TRADE_PRICE_JUGULAR */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1225000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_27404") /* Tunable: VC_SALE_PRICE_JUGULAR */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_27404") /* Tunable: VC_SALE_PRICE_JUGULAR */;
                                }
                            }
                            iVar2 = 918750;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28723") /* Tunable: CH_TRADE_PRICE_JUGULAR */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28723") /* Tunable: CH_TRADE_PRICE_JUGULAR */;
                                }
                            }
                        }
                        break;

                    case /*S80*/ (VehicleHash)3970348707:
                        iVar1 = 2575000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27090") /* Tunable: VC_SALE_PRICE_S80RR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27090") /* Tunable: VC_SALE_PRICE_S80RR */;
                        }
                        break;

                    case /*Krieger*/ (VehicleHash)3630826055:
                        iVar1 = 2875000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27089") /* Tunable: VC_SALE_PRICE_KRIEGER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27089") /* Tunable: VC_SALE_PRICE_KRIEGER */;
                        }
                        break;

                    case /*Emerus*/ (VehicleHash)1323778901:
                        iVar1 = 2750000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27088") /* Tunable: VC_SALE_PRICE_EMERUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27088") /* Tunable: VC_SALE_PRICE_EMERUS */;
                        }
                        break;

                    case /*Neo*/ (VehicleHash)2674840994:
                        iVar1 = 1875000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27087") /* Tunable: VC_SALE_PRICE_NEO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27087") /* Tunable: VC_SALE_PRICE_NEO */;
                        }
                        break;

                    case /*Paragon*/ (VehicleHash)3847255899:
                        iVar1 = 905000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_27469") /* Tunable: VC_SALE_PRICE_PARAGON */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_27469") /* Tunable: VC_SALE_PRICE_PARAGON */;
                        }
                        break;
                }
                switch ((VehicleHash)vehicleModel)
                {
                    case /*Asbo*/ (VehicleHash)1118611807:
                        if (bParam2)
                        {
                            iVar1 = 306000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28690") /* Tunable: CH_TRADE_PRICE_ASBO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28690") /* Tunable: CH_TRADE_PRICE_ASBO */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 408000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28689") /* Tunable: CH_BIN_PRICE_ASBO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28689") /* Tunable: CH_BIN_PRICE_ASBO */;
                                }
                            }
                            iVar2 = 306000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28690") /* Tunable: CH_TRADE_PRICE_ASBO */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28690") /* Tunable: CH_TRADE_PRICE_ASBO */;
                                }
                            }
                        }
                        break;

                    case /*Kanjo*/ (VehicleHash)409049982:
                        if (bParam2)
                        {
                            iVar1 = 435000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28692") /* Tunable: CH_TRADE_PRICE_KANJO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28692") /* Tunable: CH_TRADE_PRICE_KANJO */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 580000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28691") /* Tunable: CH_BIN_PRICE_KANJO */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28691") /* Tunable: CH_BIN_PRICE_KANJO */;
                                }
                            }
                            iVar2 = 435000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28692") /* Tunable: CH_TRADE_PRICE_KANJO */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28692") /* Tunable: CH_TRADE_PRICE_KANJO */;
                                }
                            }
                        }
                        break;

                    case /*Everon*/ (VehicleHash)2538945576:
                        if (bParam2)
                        {
                            iVar1 = 1106250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28694") /* Tunable: CH_TRADE_PRICE_EVERON */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28694") /* Tunable: CH_TRADE_PRICE_EVERON */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1475000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28693") /* Tunable: CH_BIN_PRICE_EVERON */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28693") /* Tunable: CH_BIN_PRICE_EVERON */;
                                }
                            }
                            iVar2 = 1106250;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28694") /* Tunable: CH_TRADE_PRICE_EVERON */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28694") /* Tunable: CH_TRADE_PRICE_EVERON */;
                                }
                            }
                        }
                        break;

                    case /*Retinue2*/ (VehicleHash)2031587082:
                        if (bParam2)
                        {
                            iVar1 = 1215000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28696") /* Tunable: CH_TRADE_PRICE_RETINUE2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28696") /* Tunable: CH_TRADE_PRICE_RETINUE2 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1620000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28695") /* Tunable: CH_BIN_PRICE_RETINUE2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28695") /* Tunable: CH_BIN_PRICE_RETINUE2 */;
                                }
                            }
                            iVar2 = 1215000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28696") /* Tunable: CH_TRADE_PRICE_RETINUE2 */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28696") /* Tunable: CH_TRADE_PRICE_RETINUE2 */;
                                }
                            }
                        }
                        break;

                    case /*Yosemite2*/ (VehicleHash)1693751655:
                        if (bParam2)
                        {
                            iVar1 = 981000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28698") /* Tunable: CH_TRADE_PRICE_YOSEMITE2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28698") /* Tunable: CH_TRADE_PRICE_YOSEMITE2 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1308000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28697") /* Tunable: CH_BIN_PRICE_YOSEMITE2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28697") /* Tunable: CH_BIN_PRICE_YOSEMITE2 */;
                                }
                            }
                            iVar2 = 981000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28698") /* Tunable: CH_TRADE_PRICE_YOSEMITE2 */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28698") /* Tunable: CH_TRADE_PRICE_YOSEMITE2 */;
                                }
                            }
                        }
                        break;

                    case /*Sugoi*/ (VehicleHash)987469656:
                        if (bParam2)
                        {
                            iVar1 = 918000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28700") /* Tunable: CH_TRADE_PRICE_SUGOI */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28700") /* Tunable: CH_TRADE_PRICE_SUGOI */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1224000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28699") /* Tunable: CH_BIN_PRICE_SUGOI */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28699") /* Tunable: CH_BIN_PRICE_SUGOI */;
                                }
                            }
                            iVar2 = 918000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28700") /* Tunable: CH_TRADE_PRICE_SUGOI */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28700") /* Tunable: CH_TRADE_PRICE_SUGOI */;
                                }
                            }
                        }
                        break;

                    case /*Sultan2*/ (VehicleHash)872704284:
                        if (bParam2)
                        {
                            iVar1 = 1288500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28702") /* Tunable: CH_TRADE_PRICE_SULTAN2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28702") /* Tunable: CH_TRADE_PRICE_SULTAN2 */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1718000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28701") /* Tunable: CH_BIN_PRICE_SULTAN2 */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28701") /* Tunable: CH_BIN_PRICE_SULTAN2 */;
                                }
                            }
                            iVar2 = 1288500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28702") /* Tunable: CH_TRADE_PRICE_SULTAN2 */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28702") /* Tunable: CH_TRADE_PRICE_SULTAN2 */;
                                }
                            }
                        }
                        break;

                    case /*Outlaw*/ (VehicleHash)408825843:
                        if (bParam2)
                        {
                            iVar1 = 951000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28704") /* Tunable: CH_TRADE_PRICE_OUTLAW */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28704") /* Tunable: CH_TRADE_PRICE_OUTLAW */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1268000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28703") /* Tunable: CH_BIN_PRICE_OUTLAW */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28703") /* Tunable: CH_BIN_PRICE_OUTLAW */;
                                }
                            }
                            iVar2 = 951000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28704") /* Tunable: CH_TRADE_PRICE_OUTLAW */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28704") /* Tunable: CH_TRADE_PRICE_OUTLAW */;
                                }
                            }
                        }
                        break;

                    case /*Vagrant*/ (VehicleHash)740289177:
                        if (bParam2)
                        {
                            iVar1 = 1660500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28706") /* Tunable: CH_TRADE_PRICE_VAGRANT */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28706") /* Tunable: CH_TRADE_PRICE_VAGRANT */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2214000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28705") /* Tunable: CH_BIN_PRICE_VAGRANT */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28705") /* Tunable: CH_BIN_PRICE_VAGRANT */;
                                }
                            }
                            iVar2 = 1660500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28706") /* Tunable: CH_TRADE_PRICE_VAGRANT */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28706") /* Tunable: CH_TRADE_PRICE_VAGRANT */;
                                }
                            }
                        }
                        break;

                    case /*Komoda*/ (VehicleHash)3460613305:
                        if (bParam2)
                        {
                            iVar1 = 1275000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28708") /* Tunable: CH_TRADE_PRICE_KOMODA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28708") /* Tunable: CH_TRADE_PRICE_KOMODA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 1700000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28707") /* Tunable: CH_BIN_PRICE_KOMODA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28707") /* Tunable: CH_BIN_PRICE_KOMODA */;
                                }
                            }
                            iVar2 = 1275000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28708") /* Tunable: CH_TRADE_PRICE_KOMODA */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28708") /* Tunable: CH_TRADE_PRICE_KOMODA */;
                                }
                            }
                        }
                        break;

                    case /*Stryder*/ (VehicleHash)301304410:
                        if (bParam2)
                        {
                            iVar1 = 502500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28710") /* Tunable: CH_TRADE_PRICE_STRYDER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28710") /* Tunable: CH_TRADE_PRICE_STRYDER */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 670000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28709") /* Tunable: CH_BIN_PRICE_STRYDER */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28709") /* Tunable: CH_BIN_PRICE_STRYDER */;
                                }
                            }
                            iVar2 = 502500;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28710") /* Tunable: CH_TRADE_PRICE_STRYDER */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28710") /* Tunable: CH_TRADE_PRICE_STRYDER */;
                                }
                            }
                        }
                        break;

                    case /*Furia*/ (VehicleHash)960812448:
                        if (bParam2)
                        {
                            iVar1 = 2055000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28712") /* Tunable: CH_TRADE_PRICE_FURIA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28712") /* Tunable: CH_TRADE_PRICE_FURIA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2740000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28711") /* Tunable: CH_BIN_PRICE_FURIA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28711") /* Tunable: CH_BIN_PRICE_FURIA */;
                                }
                            }
                            iVar2 = 2055000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28712") /* Tunable: CH_TRADE_PRICE_FURIA */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28712") /* Tunable: CH_TRADE_PRICE_FURIA */;
                                }
                            }
                        }
                        break;

                    case /*Zhaba*/ (VehicleHash)1284356689:
                        if (bParam2)
                        {
                            iVar1 = 1800000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28714") /* Tunable: CH_TRADE_PRICE_ZHABA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28714") /* Tunable: CH_TRADE_PRICE_ZHABA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2400000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28713") /* Tunable: CH_BIN_PRICE_ZHABA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_28713") /* Tunable: CH_BIN_PRICE_ZHABA */;
                                }
                            }
                            iVar2 = 1800000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_28714") /* Tunable: CH_TRADE_PRICE_ZHABA */ >= 0)
                                {
                                    iVar2 = Tunables.Global_262145.Value<int>("f_28714") /* Tunable: CH_TRADE_PRICE_ZHABA */;
                                }
                            }
                        }
                        break;

                    case /*JB7002*/ (VehicleHash)394110044:
                        iVar1 = 1470000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28792") /* Tunable: CH_TRADE_PRICE_JB7002 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28792") /* Tunable: CH_TRADE_PRICE_JB7002 */;
                            }
                        }
                        break;

                    case /*Minitank*/ (VehicleHash)3040635986:
                        iVar1 = 2275000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28783") /* Tunable: CH_SALE_PRICE_MINITANK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28783") /* Tunable: CH_SALE_PRICE_MINITANK */;
                            }
                        }
                        break;

                    case /*Formula*/ (VehicleHash)340154634:
                        iVar1 = 3515000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28862") /* Tunable: CH_TRADE_PRICE_FORMULA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28862") /* Tunable: CH_TRADE_PRICE_FORMULA */;
                            }
                        }
                        break;

                    case /*Formula2*/ (VehicleHash)2334210311:
                        iVar1 = 3115000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28865") /* Tunable: CH_TRADE_PRICE_FORMULA2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28865") /* Tunable: CH_TRADE_PRICE_FORMULA2 */;
                            }
                        }
                        break;

                    case /*Imorgon*/ (VehicleHash)3162245632:
                        iVar1 = 2165000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28868") /* Tunable: CH_SALE_PRICE_IMORGEN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28868") /* Tunable: CH_SALE_PRICE_IMORGEN */;
                            }
                        }
                        break;

                    case /*Rebla*/ (VehicleHash)83136452:
                        iVar1 = 1175000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28869") /* Tunable: CH_SALE_PRICE_REBLA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28869") /* Tunable: CH_SALE_PRICE_REBLA */;
                            }
                        }
                        break;

                    case /*Vstr*/ (VehicleHash)1456336509:
                        iVar1 = 1285000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_28870") /* Tunable: CH_SALE_PRICE_VSTR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_28870") /* Tunable: CH_SALE_PRICE_VSTR */;
                            }
                        }
                        break;

                    case /*Tigon*/ (VehicleHash)2936769864:
                        iVar1 = 2310000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29571") /* Tunable: SUM_SALE_PRICE_TIGON */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29571") /* Tunable: SUM_SALE_PRICE_TIGON */;
                            }
                        }
                        break;

                    case /*Openwheel1*/ (VehicleHash)1492612435:
                        iVar1 = 3400000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29575") /* Tunable: SUM_SALE_PRICE_OPENWHEEL1 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29575") /* Tunable: SUM_SALE_PRICE_OPENWHEEL1 */;
                            }
                        }
                        break;

                    case /*Openwheel2*/ (VehicleHash)1181339704:
                        iVar1 = 2997000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29576") /* Tunable: SUM_SALE_PRICE_OPENWHEEL2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29576") /* Tunable: SUM_SALE_PRICE_OPENWHEEL2 */;
                            }
                        }
                        break;

                    case /*Coquette4*/ (VehicleHash)2566281822:
                        iVar1 = 1510000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29577") /* Tunable: SUM_SALE_PRICE_COQUETTE4 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29577") /* Tunable: SUM_SALE_PRICE_COQUETTE4 */;
                            }
                        }
                        break;

                    case /*Peyote3*/ (VehicleHash)1107404867:
                        iVar1 = 620000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_29585") /* Tunable: SUM_SALE_PRICE_PEYOTE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Yosemite3*/ (VehicleHash)67753863:
                        iVar1 = 700000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_24096") /* Tunable: H2_VEHICLES_PRICE_YOSEMITE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Gauntlet5*/ (VehicleHash)2172320429:
                        iVar1 = 815000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_27077") /* Tunable: VC_SALE_PRICE_GAUNTLET_CLASSIC */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Landstalker2*/ (VehicleHash)3456868130:
                        iVar1 = 1220000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29567") /* Tunable: SUM_SALE_PRICE_LANDSTALKER2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29567") /* Tunable: SUM_SALE_PRICE_LANDSTALKER2 */;
                            }
                        }
                        break;

                    case /*Glendale2*/ (VehicleHash)3381377750:
                        iVar1 = 520000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_8277") /* Tunable: DLC_HIPSTER_CAR_MOD_BENEFACTOR_GLENDA */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Club*/ (VehicleHash)2196012677:
                        iVar1 = 1280000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29569") /* Tunable: SUM_SALE_PRICE_CLUB */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29569") /* Tunable: SUM_SALE_PRICE_CLUB */;
                            }
                        }
                        break;

                    case /*Dukes3*/ (VehicleHash)2134119907:
                        iVar1 = 378000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29563") /* Tunable: SUM_SALE_PRICE_DUKES3 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29563") /* Tunable: SUM_SALE_PRICE_DUKES3 */;
                            }
                        }
                        break;

                    case /*Youga3*/ (VehicleHash)1802742206:
                        iVar1 = 1288000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_19180") /* Tunable: WEBSITE_VAPID_YOUGA_CLASSIC */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Manana2*/ (VehicleHash)1717532765:
                        iVar1 = 925000;
                        if (bVar0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_29584") /* Tunable: SUM_SALE_PRICE_MANANA */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                        break;

                    case /*Penumbra2*/ (VehicleHash)3663644634:
                        iVar1 = 1380000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29570") /* Tunable: SUM_SALE_PRICE_PENUMBRA2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29570") /* Tunable: SUM_SALE_PRICE_PENUMBRA2 */;
                            }
                        }
                        break;

                    case /*Seminole2*/ (VehicleHash)2484160806:
                        iVar1 = 678000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_29565") /* Tunable: SUM_SALE_PRICE_SEMINOLE2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_29565") /* Tunable: SUM_SALE_PRICE_SEMINOLE2 */;
                            }
                        }
                        break;

                    case /*Manchez2*/ (VehicleHash)1086534307:
                        iVar1 = 225000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31009") /* Tunable: IH_BIN_PRICE_MANCHEZ2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31009") /* Tunable: IH_BIN_PRICE_MANCHEZ2 */;
                            }
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 168750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_35793") /* Tunable: SU23_TRADE_PRICE_MANCHEZ2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_35793") /* Tunable: SU23_TRADE_PRICE_MANCHEZ2 */;
                            }
                        }
                        break;

                    case /*Verus*/ (VehicleHash)298565713:
                        iVar1 = 192000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31010") /* Tunable: IH_BIN_PRICE_VERUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31010") /* Tunable: IH_BIN_PRICE_VERUS */;
                            }
                        }
                        break;

                    case /*Veto*/ (VehicleHash)3437611258:
                        iVar1 = 895000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31015") /* Tunable: IH_BIN_PRICE_VETO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31015") /* Tunable: IH_BIN_PRICE_VETO */;
                            }
                        }
                        break;

                    case /*Veto2*/ (VehicleHash)2802050217:
                        iVar1 = 995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31016") /* Tunable: IH_BIN_PRICE_VETO2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31016") /* Tunable: IH_BIN_PRICE_VETO2 */;
                            }
                        }
                        break;

                    case /*SlamTruck*/ (VehicleHash)3249056020:
                        iVar1 = 1310000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31014") /* Tunable: IH_BIN_PRICE_SLAMTRUCK */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31014") /* Tunable: IH_BIN_PRICE_SLAMTRUCK */;
                            }
                        }
                        break;

                    case /*Toreador*/ (VehicleHash)1455990255:
                        iVar1 = 4250000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31000") /* Tunable: IH_BIN_PRICE_TOREADOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31000") /* Tunable: IH_BIN_PRICE_TOREADOR */;
                            }
                        }
                        break;

                    case /*Dinghy5*/ (VehicleHash)3314393930:
                        iVar1 = 1850000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31005") /* Tunable: IH_BIN_PRICE_DINGHY5 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31005") /* Tunable: IH_BIN_PRICE_DINGHY5 */;
                            }
                        }
                        break;

                    case /*Squaddie*/ (VehicleHash)4192631813:
                        iVar1 = 1130000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_31008") /* Tunable: IH_BIN_PRICE_SQUADDIE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31008") /* Tunable: IH_BIN_PRICE_SQUADDIE */;
                            }
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 847500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_35792") /* Tunable: SU23_TRADE_PRICE_SQUADDIE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_35792") /* Tunable: SU23_TRADE_PRICE_SQUADDIE */;
                            }
                        }
                        break;

                    case /*Winky*/ (VehicleHash)4084658662:
                        iVar1 = 1100000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31006") /* Tunable: IH_BIN_PRICE_WINKY */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31006") /* Tunable: IH_BIN_PRICE_WINKY */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 825000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31021") /* Tunable: IH_TRADE_PRICE_WINKY */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31021") /* Tunable: IH_TRADE_PRICE_WINKY */;
                            }
                        }
                        break;

                    case /*Annihilator2*/ (VehicleHash)295054921:
                        iVar1 = 3870000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31001") /* Tunable: IH_BIN_PRICE_ANNIHILATOR2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31001") /* Tunable: IH_BIN_PRICE_ANNIHILATOR2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2902500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31017") /* Tunable: IH_TRADE_PRICE_ANNIHILATOR2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31017") /* Tunable: IH_TRADE_PRICE_ANNIHILATOR2 */;
                            }
                        }
                        break;

                    case /*Alkonost*/ (VehicleHash)3929093893:
                        iVar1 = 4350000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31002") /* Tunable: IH_BIN_PRICE_ALKONOST */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31002") /* Tunable: IH_BIN_PRICE_ALKONOST */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 3262500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31018") /* Tunable: IH_TRADE_PRICE_ALKONOST */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31018") /* Tunable: IH_TRADE_PRICE_ALKONOST */;
                            }
                        }
                        break;

                    case /*Brioso2*/ (VehicleHash)1429622905:
                        iVar1 = 610000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31012") /* Tunable: IH_BIN_PRICE_BRIOSO2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31012") /* Tunable: IH_BIN_PRICE_BRIOSO2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 457500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31024") /* Tunable: IH_TRADE_PRICE_BRIOSO2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31024") /* Tunable: IH_TRADE_PRICE_BRIOSO2 */;
                            }
                        }
                        break;

                    case /*Weevil*/ (VehicleHash)1644055914:
                        iVar1 = 870000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31011") /* Tunable: IH_BIN_PRICE_WEEVIL */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31011") /* Tunable: IH_BIN_PRICE_WEEVIL */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 652500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31023") /* Tunable: IH_TRADE_PRICE_WEEVIL */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31023") /* Tunable: IH_TRADE_PRICE_WEEVIL */;
                            }
                        }
                        break;

                    case /*ItaliRSx*/ (VehicleHash)3145241962:
                        iVar1 = 3465000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31013") /* Tunable: IH_BIN_PRICE_ITALIRSX */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31013") /* Tunable: IH_BIN_PRICE_ITALIRSX */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2598750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31025") /* Tunable: IH_TRADE_PRICE_ITALIRSX */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31025") /* Tunable: IH_TRADE_PRICE_ITALIRSX */;
                            }
                        }
                        break;

                    case /*Longfin*/ (VehicleHash)1861786828:
                        iVar1 = 2125000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31004") /* Tunable: IH_BIN_PRICE_LONGFIN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31004") /* Tunable: IH_BIN_PRICE_LONGFIN */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1593750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31020") /* Tunable: IH_TRADE_PRICE_LONGFIN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31020") /* Tunable: IH_TRADE_PRICE_LONGFIN */;
                            }
                        }
                        break;

                    case /*Vetir*/ (VehicleHash)2014313426:
                        iVar1 = 1630000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31007") /* Tunable: IH_BIN_PRICE_VETIR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31007") /* Tunable: IH_BIN_PRICE_VETIR */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1222500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31022") /* Tunable: IH_TRADE_PRICE_VETIR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31022") /* Tunable: IH_TRADE_PRICE_VETIR */;
                            }
                        }
                        break;

                    case /*Patrolboat*/ (VehicleHash)4018222598:
                        iVar1 = 2955000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31003") /* Tunable: IH_BIN_PRICE_PATROLBOAT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31003") /* Tunable: IH_BIN_PRICE_PATROLBOAT */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2216250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31019") /* Tunable: IH_TRADE_PRICE_PATROLBOAT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31019") /* Tunable: IH_TRADE_PRICE_PATROLBOAT */;
                            }
                        }
                        break;

                    case /*Kosatka*/ (VehicleHash)1336872304:
                        if (!bParam2)
                        {
                            iVar1 = 2200000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_30828") /* Tunable: IH_SUB_SALE_KOSATKA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_30828") /* Tunable: IH_SUB_SALE_KOSATKA */;
                                }
                            }
                        }
                        else
                        {
                            iVar1 = 2200000;
                            if (bVar0)
                            {
                                if (Tunables.Global_262145.Value<int>("f_30698") /* Tunable: IH_SUB_BASE_KOSATKA */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_30698") /* Tunable: IH_SUB_BASE_KOSATKA */;
                                }
                            }
                        }
                        break;

                    case /*Calico*/ (VehicleHash)3101054893:
                        iVar1 = 1995000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31420") /* Tunable: TUNER_BIN_PRICE_CALICO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31420") /* Tunable: TUNER_BIN_PRICE_CALICO */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1496250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31437") /* Tunable: TUNER_TRADE_PRICE_CALICO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31437") /* Tunable: TUNER_TRADE_PRICE_CALICO */;
                            }
                        }
                        break;

                    case /*Comet6*/ (VehicleHash)2568944644:
                        iVar1 = 1878000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31422") /* Tunable: TUNER_BIN_PRICE_COMET6 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31422") /* Tunable: TUNER_BIN_PRICE_COMET6 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1408500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31439") /* Tunable: TUNER_TRADE_PRICE_COMET6 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31439") /* Tunable: TUNER_TRADE_PRICE_COMET6 */;
                            }
                        }
                        break;

                    case /*Cypher*/ (VehicleHash)1755697647:
                        iVar1 = 1550000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31433") /* Tunable: TUNER_BIN_PRICE_CYPHER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31433") /* Tunable: TUNER_BIN_PRICE_CYPHER */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1162500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31450") /* Tunable: TUNER_TRADE_PRICE_CYPHER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31450") /* Tunable: TUNER_TRADE_PRICE_CYPHER */;
                            }
                        }
                        break;

                    case /*Dominator7*/ (VehicleHash)426742808:
                        iVar1 = 1775000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31435") /* Tunable: TUNER_BIN_PRICE_DOMINATOR7 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31435") /* Tunable: TUNER_BIN_PRICE_DOMINATOR7 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1331250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31452") /* Tunable: TUNER_TRADE_PRICE_DOMINATOR7 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31452") /* Tunable: TUNER_TRADE_PRICE_DOMINATOR7 */;
                            }
                        }
                        break;

                    case /*Jester4*/ (VehicleHash)2712905841:
                        iVar1 = 1970000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31424") /* Tunable: TUNER_BIN_PRICE_JESTER4 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31424") /* Tunable: TUNER_BIN_PRICE_JESTER4 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1477500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31441") /* Tunable: TUNER_TRADE_PRICE_JESTER4 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31441") /* Tunable: TUNER_TRADE_PRICE_JESTER4 */;
                            }
                        }
                        break;

                    case /*Remus*/ (VehicleHash)1377217886:
                        iVar1 = 1370000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31421") /* Tunable: TUNER_BIN_PRICE_REMUS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31421") /* Tunable: TUNER_BIN_PRICE_REMUS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1027500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31438") /* Tunable: TUNER_TRADE_PRICE_REMUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31438") /* Tunable: TUNER_TRADE_PRICE_REMUS */;
                            }
                        }
                        break;

                    case /*Vectre*/ (VehicleHash)2754593701:
                        iVar1 = 1785000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31426") /* Tunable: TUNER_BIN_PRICE_VECTRE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31426") /* Tunable: TUNER_BIN_PRICE_VECTRE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1338750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31443") /* Tunable: TUNER_TRADE_PRICE_VECTRE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31443") /* Tunable: TUNER_TRADE_PRICE_VECTRE */;
                            }
                        }
                        break;

                    case /*Zr350*/ (VehicleHash)2436313176:
                        iVar1 = 1615000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31419") /* Tunable: TUNER_BIN_PRICE_ZR350 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31419") /* Tunable: TUNER_BIN_PRICE_ZR350 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1211250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31436") /* Tunable: TUNER_TRADE_PRICE_ZR350 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31436") /* Tunable: TUNER_TRADE_PRICE_ZR350 */;
                            }
                        }
                        break;

                    case /*Warrener2*/ (VehicleHash)579912970:
                        iVar1 = 1260000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31427") /* Tunable: TUNER_BIN_PRICE_WARRENER2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31427") /* Tunable: TUNER_BIN_PRICE_WARRENER2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 945000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31444") /* Tunable: TUNER_TRADE_PRICE_WARRENER2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31444") /* Tunable: TUNER_TRADE_PRICE_WARRENER2 */;
                            }
                        }
                        break;

                    case /*Rt3000*/ (VehicleHash)3842363289:
                        iVar1 = 1715000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31429") /* Tunable: TUNER_BIN_PRICE_RT3000 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31429") /* Tunable: TUNER_BIN_PRICE_RT3000 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1286250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31446") /* Tunable: TUNER_TRADE_PRICE_RT3000 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31446") /* Tunable: TUNER_TRADE_PRICE_RT3000 */;
                            }
                        }
                        break;

                    case /*Futo2*/ (VehicleHash)2787736776:
                        iVar1 = 1590000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31430") /* Tunable: TUNER_BIN_PRICE_FUTO2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31430") /* Tunable: TUNER_BIN_PRICE_FUTO2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1192500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31447") /* Tunable: TUNER_TRADE_PRICE_FUTO2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31447") /* Tunable: TUNER_TRADE_PRICE_FUTO2 */;
                            }
                        }
                        break;

                    case /*Tailgater2*/ (VehicleHash)3050505892:
                        iVar1 = 1495000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31432") /* Tunable: TUNER_BIN_PRICE_TAILGATER2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31432") /* Tunable: TUNER_BIN_PRICE_TAILGATER2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1121250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31449") /* Tunable: TUNER_TRADE_PRICE_TAILGATER2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31449") /* Tunable: TUNER_TRADE_PRICE_TAILGATER2 */;
                            }
                        }
                        break;

                    case /*Sultan3*/ (VehicleHash)4003946083:
                        iVar1 = 1789000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31428") /* Tunable: TUNER_BIN_PRICE_SULTAN3 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31428") /* Tunable: TUNER_BIN_PRICE_SULTAN3 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1341750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31445") /* Tunable: TUNER_TRADE_PRICE_SULTAN3 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31445") /* Tunable: TUNER_TRADE_PRICE_SULTAN3 */;
                            }
                        }
                        break;

                    case /*Dominator8*/ (VehicleHash)736672010:
                        iVar1 = 1220000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31434") /* Tunable: TUNER_BIN_PRICE_DOMINATOR8 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31434") /* Tunable: TUNER_BIN_PRICE_DOMINATOR8 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 915000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31451") /* Tunable: TUNER_TRADE_PRICE_DOMINATOR8 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31451") /* Tunable: TUNER_TRADE_PRICE_DOMINATOR8 */;
                            }
                        }
                        break;

                    case /*Euros*/ (VehicleHash)2038480341:
                        iVar1 = 1800000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31423") /* Tunable: TUNER_BIN_PRICE_EUROS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31423") /* Tunable: TUNER_BIN_PRICE_EUROS */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1350000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31440") /* Tunable: TUNER_TRADE_PRICE_EUROS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31440") /* Tunable: TUNER_TRADE_PRICE_EUROS */;
                            }
                        }
                        break;

                    case /*Growler*/ (VehicleHash)1304459735:
                        iVar1 = 1627000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31431") /* Tunable: TUNER_BIN_PRICE_GROWLER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31431") /* Tunable: TUNER_BIN_PRICE_GROWLER */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1220250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31448") /* Tunable: TUNER_TRADE_PRICE_GROWLER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31448") /* Tunable: TUNER_TRADE_PRICE_GROWLER */;
                            }
                        }
                        break;

                    case /*Previon*/ (VehicleHash)1416471345:
                        iVar1 = 1490000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_31425") /* Tunable: TUNER_BIN_PRICE_PREVION */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_31425") /* Tunable: TUNER_BIN_PRICE_PREVION */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1117500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_31442") /* Tunable: TUNER_TRADE_PRICE_PREVION */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_31442") /* Tunable: TUNER_TRADE_PRICE_PREVION */;
                            }
                        }
                        break;

                    case /*Astron*/ (VehicleHash)629969764:
                        iVar1 = 1580000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32718") /* Tunable: FIXER_BIN_PRICE_ASTRON */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32718") /* Tunable: FIXER_BIN_PRICE_ASTRON */;
                            }
                        }
                        break;

                    case /*Baller7*/ (VehicleHash)359875117:
                        iVar1 = 890000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32723") /* Tunable: FIXER_BIN_PRICE_BALLER7 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32723") /* Tunable: FIXER_BIN_PRICE_BALLER7 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 667500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32734") /* Tunable: FIXER_TRADE_PRICE_BALLER7 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32734") /* Tunable: FIXER_TRADE_PRICE_BALLER7 */;
                            }
                        }
                        break;

                    case /*Buffalo4*/ (VehicleHash)3675036420:
                        iVar1 = 2150000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32716") /* Tunable: FIXER_BIN_PRICE_BUFFALO4 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32716") /* Tunable: FIXER_BIN_PRICE_BUFFALO4 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1612500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32731") /* Tunable: FIXER_TRADE_PRICE_BUFFALO4 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32731") /* Tunable: FIXER_TRADE_PRICE_BUFFALO4 */;
                            }
                        }
                        break;

                    case /*Comet7*/ (VehicleHash)1141395928:
                        iVar1 = 1797000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32725") /* Tunable: FIXER_BIN_PRICE_COMET7 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32725") /* Tunable: FIXER_BIN_PRICE_COMET7 */;
                            }
                        }
                        break;

                    case /*Cinquemila*/ (VehicleHash)2767531027:
                        iVar1 = 1740000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32724") /* Tunable: FIXER_BIN_PRICE_CINQUEMILA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32724") /* Tunable: FIXER_BIN_PRICE_CINQUEMILA */;
                            }
                        }
                        break;

                    case /*Deity*/ (VehicleHash)1532171089:
                        iVar1 = 1845000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32717") /* Tunable: FIXER_BIN_PRICE_DEITY */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32717") /* Tunable: FIXER_BIN_PRICE_DEITY */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1383750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32732") /* Tunable: FIXER_TRADE_PRICE_DEITY */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32732") /* Tunable: FIXER_TRADE_PRICE_DEITY */;
                            }
                        }
                        break;

                    case /*Granger2*/ (VehicleHash)4033620423:
                        iVar1 = 2000000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32720") /* Tunable: FIXER_BIN_PRICE_GRANGER2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32720") /* Tunable: FIXER_BIN_PRICE_GRANGER2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1500000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32735") /* Tunable: FIXER_TRADE_PRICE_GRANGER2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32735") /* Tunable: FIXER_TRADE_PRICE_GRANGER2 */;
                            }
                        }
                        break;

                    case /*Ignus*/ (VehicleHash)2850852987:
                        iVar1 = 2765000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32719") /* Tunable: FIXER_BIN_PRICE_IGNUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32719") /* Tunable: FIXER_BIN_PRICE_IGNUS */;
                            }
                        }
                        break;

                    case /*Jubilee*/ (VehicleHash)461465043:
                        iVar1 = 1650000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32722") /* Tunable: FIXER_BIN_PRICE_JUBILEE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32722") /* Tunable: FIXER_BIN_PRICE_JUBILEE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1237500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32733") /* Tunable: FIXER_TRADE_PRICE_JUBILEE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32733") /* Tunable: FIXER_TRADE_PRICE_JUBILEE */;
                            }
                        }
                        break;

                    case /*Patriot3*/ (VehicleHash)3624880708:
                        iVar1 = 1710000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32721") /* Tunable: FIXER_BIN_PRICE_PATRIOT3 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32721") /* Tunable: FIXER_BIN_PRICE_PATRIOT3 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1282500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32736") /* Tunable: FIXER_TRADE_PRICE_PATRIOT3 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32736") /* Tunable: FIXER_TRADE_PRICE_PATRIOT3 */;
                            }
                        }
                        break;

                    case /*Champion*/ (VehicleHash)3379732821:
                        iVar1 = 3750000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_32715") /* Tunable: FIXER_BIN_PRICE_CHAMPION */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_32715") /* Tunable: FIXER_BIN_PRICE_CHAMPION */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2812500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32730") /* Tunable: FIXER_TRADE_PRICE_CHAMPION */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32730") /* Tunable: FIXER_TRADE_PRICE_CHAMPION */;
                            }
                        }
                        break;

                    case /*Reever*/ (VehicleHash)1993851908:
                        iVar1 = 1900000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32727") /* Tunable: FIXER_BIN_PRICE_REEVER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32727") /* Tunable: FIXER_BIN_PRICE_REEVER */;
                            }
                        }
                        break;

                    case /*Shinobi*/ (VehicleHash)1353120668:
                        iVar1 = 2480500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32729") /* Tunable: FIXER_BIN_PRICE_SHINOBI */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32729") /* Tunable: FIXER_BIN_PRICE_SHINOBI */;
                            }
                        }
                        break;

                    case /*Zeno*/ (VehicleHash)655665811:
                        iVar1 = 2820000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32726") /* Tunable: FIXER_BIN_PRICE_ZENO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32726") /* Tunable: FIXER_BIN_PRICE_ZENO */;
                            }
                        }
                        break;

                    case /*CoRSita*/ (VehicleHash)3540279623:
                        iVar1 = 1795000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33845") /* Tunable: SU22_BIN_PRICE_CORSITA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33845") /* Tunable: SU22_BIN_PRICE_CORSITA */;
                        }
                        break;

                    case /*Draugur*/ (VehicleHash)3526730918:
                        iVar1 = 1870000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33847") /* Tunable: SU22_BIN_PRICE_DRAUGUR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33847") /* Tunable: SU22_BIN_PRICE_DRAUGUR */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1402500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_33852") /* Tunable: SU22_TRADE_PRICE_DRAUGUR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_33852") /* Tunable: SU22_TRADE_PRICE_DRAUGUR */;
                            }
                        }
                        break;

                    case /*Greenwood*/ (VehicleHash)40817712:
                        iVar1 = 1465000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33838") /* Tunable: SU22_BIN_PRICE_GREENWOOD */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33838") /* Tunable: SU22_BIN_PRICE_GREENWOOD */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1098750;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_33851") /* Tunable: SU22_TRADE_PRICE_GREENWOOD */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_33851") /* Tunable: SU22_TRADE_PRICE_GREENWOOD */;
                            }
                        }
                        break;

                    case /*Kanjosj*/ (VehicleHash)4230891418:
                        iVar1 = 1370000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33849") /* Tunable: SU22_BIN_PRICE_KANJOSJ */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33849") /* Tunable: SU22_BIN_PRICE_KANJOSJ */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1027500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_33854") /* Tunable: SU22_TRADE_PRICE_KANJOSJ */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_33854") /* Tunable: SU22_TRADE_PRICE_KANJOSJ */;
                            }
                        }
                        break;

                    case /*Lm87*/ (VehicleHash)4284049613:
                        iVar1 = 2915000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33846") /* Tunable: SU22_BIN_PRICE_LM87 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33846") /* Tunable: SU22_BIN_PRICE_LM87 */;
                        }
                        break;

                    case /*Postlude*/ (VehicleHash)4000288633:
                        iVar1 = 1310000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33850") /* Tunable: SU22_BIN_PRICE_POSTLUDE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33850") /* Tunable: SU22_BIN_PRICE_POSTLUDE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 982500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_33855") /* Tunable: SU22_TRADE_PRICE_POSTLUDE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_33855") /* Tunable: SU22_TRADE_PRICE_POSTLUDE */;
                            }
                        }
                        break;

                    case /*Rhinehart*/ (VehicleHash)2439462158:
                        iVar1 = 1598000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33844") /* Tunable: SU22_BIN_PRICE_RHINEHART */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33844") /* Tunable: SU22_BIN_PRICE_RHINEHART */;
                        }
                        break;

                    case /*Sm722*/ (VehicleHash)775514032:
                        iVar1 = 2115000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33839") /* Tunable: SU22_BIN_PRICE_SM722 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33839") /* Tunable: SU22_BIN_PRICE_SM722 */;
                        }
                        break;

                    case /*Tenf*/ (VehicleHash)3400983137:
                        iVar1 = 1675000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33843") /* Tunable: SU22_BIN_PRICE_TENF */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33843") /* Tunable: SU22_BIN_PRICE_TENF */;
                        }
                        break;

                    case /*Torero2*/ (VehicleHash)4129572538:
                        iVar1 = 2890000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33842") /* Tunable: SU22_BIN_PRICE_TORERO2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33842") /* Tunable: SU22_BIN_PRICE_TORERO2 */;
                        }
                        break;

                    case /*Vigero2*/ (VehicleHash)2536587772:
                        iVar1 = 1947000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33841") /* Tunable: SU22_BIN_PRICE_VIGERO2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33841") /* Tunable: SU22_BIN_PRICE_VIGERO2 */;
                        }
                        break;

                    case /*Ruiner4*/ (VehicleHash)1706945532:
                        iVar1 = 1320000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33840") /* Tunable: SU22_BIN_PRICE_RUINER4 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33840") /* Tunable: SU22_BIN_PRICE_RUINER4 */;
                        }
                        break;

                    case /*Conada*/ (VehicleHash)3817135397:
                        iVar1 = 2450000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33848") /* Tunable: SU22_BIN_PRICE_CONADA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33848") /* Tunable: SU22_BIN_PRICE_CONADA */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1837500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_33853") /* Tunable: SU22_TRADE_PRICE_CONADA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_33853") /* Tunable: SU22_TRADE_PRICE_CONADA */;
                            }
                        }
                        break;

                    case /*OmniseGT*/ (VehicleHash)3789743831:
                        iVar1 = 1795000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_33837") /* Tunable: SU22_BIN_PRICE_OMNISEGT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_33837") /* Tunable: SU22_BIN_PRICE_OMNISEGT */;
                        }
                        break;

                    case /*Weevil2*/ (VehicleHash)3300595976:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_31023") /* Tunable: IH_TRADE_PRICE_WEEVIL */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case /*Tenf2*/ (VehicleHash)274946574:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_33843") /* Tunable: SU22_BIN_PRICE_TENF */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case /*Brioso3*/ (VehicleHash)15214558:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_31024") /* Tunable: IH_TRADE_PRICE_BRIOSO2 */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case /*Sentinel4*/ (VehicleHash)2938086457:
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_28724") /* Tunable: CH_TRADE_PRICE_SENTINAL3 */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        break;

                    case /*Brickade2*/ (VehicleHash)2718380883:
                        iVar1 = 1450000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34172") /* Tunable: XM22_BIN_PRICE_BRICKADE2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34172") /* Tunable: XM22_BIN_PRICE_BRICKADE2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 750000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_32912") /* Tunable: 2020894392 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32912") /* Tunable: 2020894392 */;
                            }
                        }
                        break;

                    case /*Journey2*/ (VehicleHash)2667889793:
                        iVar1 = 790000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34173") /* Tunable: XM22_BIN_PRICE_JOURNEY2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34173") /* Tunable: XM22_BIN_PRICE_JOURNEY2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 592500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_34188") /* Tunable: XM22_TRADE_PRICE_JOURNEY2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_34188") /* Tunable: XM22_TRADE_PRICE_JOURNEY2 */;
                            }
                        }
                        break;

                    case /*Surfer3*/ (VehicleHash)3259477733:
                        iVar1 = 590000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34174") /* Tunable: XM22_BIN_PRICE_SURFER3 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34174") /* Tunable: XM22_BIN_PRICE_SURFER3 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 442500/*func_884*/;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_34189") /* Tunable: XM22_TRADE_PRICE_SURFER3 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_34189") /* Tunable: XM22_TRADE_PRICE_SURFER3 */;
                            }
                        }
                        break;

                    case /*Panthere*/ (VehicleHash)2100457220:
                        iVar1 = 2170000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34176") /* Tunable: XM22_BIN_PRICE_PANTHERE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34176") /* Tunable: XM22_BIN_PRICE_PANTHERE */;
                        }
                        break;

                    case /*Tulip2*/ (VehicleHash)268758436:
                        iVar1 = 1658000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34178") /* Tunable: XM22_BIN_PRICE_TULIP2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34178") /* Tunable: XM22_BIN_PRICE_TULIP2 */;
                        }
                        break;

                    case /*Everon2*/ (VehicleHash)4163619118:
                        iVar1 = 1790000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34179") /* Tunable: XM22_BIN_PRICE_EVERON2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34179") /* Tunable: XM22_BIN_PRICE_EVERON2 */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 1342500;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_34190") /* Tunable: XM22_TRADE_PRICE_EVERON2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_34190") /* Tunable: XM22_TRADE_PRICE_EVERON2 */;
                            }
                        }
                        break;

                    case /*Broadway*/ (VehicleHash)2361724968:
                        iVar1 = 925000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34181") /* Tunable: XM22_BIN_PRICE_BROADWAY */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34181") /* Tunable: XM22_BIN_PRICE_BROADWAY */;
                        }
                        break;

                    case /*Boor*/ (VehicleHash)996383885:
                        iVar1 = 1280000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34183") /* Tunable: XM22_BIN_PRICE_BOOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34183") /* Tunable: XM22_BIN_PRICE_BOOR */;
                        }
                        break;

                    case /*Virtue*/ (VehicleHash)669204833:
                        iVar1 = 2980000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34185") /* Tunable: XM22_BIN_PRICE_VIRTUE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34185") /* Tunable: XM22_BIN_PRICE_VIRTUE */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 2235000;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_34191") /* Tunable: XM22_TRADE_PRICE_VIRTUE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_34191") /* Tunable: XM22_TRADE_PRICE_VIRTUE */;
                            }
                        }
                        break;

                    case /*R300*/ (VehicleHash)1076201208:
                        iVar1 = 2075000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34186") /* Tunable: XM22_BIN_PRICE_R300 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34186") /* Tunable: XM22_BIN_PRICE_R300 */;
                        }
                        break;

                    case /*PoweRSurge*/ (VehicleHash)2908631255:
                        iVar1 = 1605000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34184") /* Tunable: XM22_BIN_PRICE_POWERSURGE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34184") /* Tunable: XM22_BIN_PRICE_POWERSURGE */;
                        }
                        break;

                    case /*Issi8*/ (VehicleHash)1550581940:
                        iVar1 = 1835000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34182") /* Tunable: XM22_BIN_PRICE_ISSI8 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34182") /* Tunable: XM22_BIN_PRICE_ISSI8 */;
                        }
                        break;

                    case /*Eudora*/ (VehicleHash)3045179290:
                        iVar1 = 1250000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34180") /* Tunable: XM22_BIN_PRICE_EUDORA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34180") /* Tunable: XM22_BIN_PRICE_EUDORA */;
                        }
                        break;

                    case /*Tahoma*/ (VehicleHash)3833117047:
                        iVar1 = 1500000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34177") /* Tunable: XM22_BIN_PRICE_TAHOMA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34177") /* Tunable: XM22_BIN_PRICE_TAHOMA */;
                        }
                        break;

                    case /*Entity3*/ (VehicleHash)1748565021:
                        iVar1 = 2355000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_34175") /* Tunable: XM22_BIN_PRICE_ENTITY3 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_34175") /* Tunable: XM22_BIN_PRICE_ENTITY3 */;
                        }
                        break;

                    case /*L35*/ (VehicleHash)2531292011:
                        iVar1 = 1670000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35780") /* Tunable: SU23_BIN_PRICE_L35 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35780") /* Tunable: SU23_BIN_PRICE_L35 */;
                        }
                        break;

                    case /*Ratel*/ (VehicleHash)3758861739:
                        iVar1 = 1873000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35781") /* Tunable: SU23_BIN_PRICE_RATEL */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35781") /* Tunable: SU23_BIN_PRICE_RATEL */;
                        }
                        break;

                    case /*Monstrociti*/ (VehicleHash)802856453:
                        iVar1 = 1485000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35782") /* Tunable: SU23_BIN_PRICE_MONSTROCITI */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35782") /* Tunable: SU23_BIN_PRICE_MONSTROCITI */;
                        }
                        break;

                    case /*Brigham*/ (VehicleHash)3640468689:
                        iVar1 = 1499000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35785") /* Tunable: SU23_BIN_PRICE_BRIGHAM */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35785") /* Tunable: SU23_BIN_PRICE_BRIGHAM */;
                        }
                        break;

                    case /*Clique2*/ (VehicleHash)3315674721:
                        iVar1 = 1205000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35788") /* Tunable: SU23_BIN_PRICE_CLIQUE2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35788") /* Tunable: SU23_BIN_PRICE_CLIQUE2 */;
                        }
                        break;

                    case /*Inductor*/ (VehicleHash)3397143273:
                        iVar1 = 50000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35783") /* Tunable: SU23_BIN_PRICE_INDUCTOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35783") /* Tunable: SU23_BIN_PRICE_INDUCTOR */;
                        }
                        break;

                    case /*Inductor2*/ (VehicleHash)2311345272:
                        iVar1 = 50000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35784") /* Tunable: SU23_BIN_PRICE_INDUCTOR2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35784") /* Tunable: SU23_BIN_PRICE_INDUCTOR2 */;
                        }
                        break;

                    case /*Streamer216*/ (VehicleHash)191916658:
                        iVar1 = 2238000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35778") /* Tunable: SU23_BIN_PRICE_STREAMER216 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35778") /* Tunable: SU23_BIN_PRICE_STREAMER216 */;
                        }
                        break;

                    case /*Conada2*/ (VehicleHash)2635962482:
                        iVar1 = 3385000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35779") /* Tunable: SU23_BIN_PRICE_CONADA2 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35779") /* Tunable: SU23_BIN_PRICE_CONADA2 */;
                        }
                        break;

                    case /*Raiju*/ (VehicleHash)239897677:
                        iVar1 = 6855000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35777") /* Tunable: SU23_BIN_PRICE_RAIJU */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35777") /* Tunable: SU23_BIN_PRICE_RAIJU */;
                        }
                        if (bParam2)
                        {
                            iVar2 = iVar1;
                            iVar1 = 5141250;
                            if (bVar0 && Tunables.Global_262145.Value<int>("f_35791") /* Tunable: SU23_TRADE_PRICE_RAIJU */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_35791") /* Tunable: SU23_TRADE_PRICE_RAIJU */;
                            }
                        }
                        break;

                    case /*Stingertt*/ (VehicleHash)1447690049:
                        iVar1 = 2380000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35789") /* Tunable: SU23_BIN_PRICE_STINGERTT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35789") /* Tunable: SU23_BIN_PRICE_STINGERTT */;
                        }
                        break;

                    case /*Buffalo5*/ (VehicleHash)165968051:
                        iVar1 = 2140000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35790") /* Tunable: SU23_BIN_PRICE_BUFFALO5 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35790") /* Tunable: SU23_BIN_PRICE_BUFFALO5 */;
                        }
                        break;

                    case /*Coureur*/ (VehicleHash)610429990:
                        iVar1 = 1990000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35786") /* Tunable: SU23_BIN_PRICE_COUREUR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35786") /* Tunable: SU23_BIN_PRICE_COUREUR */;
                        }
                        break;

                    case /*Gauntlet6*/ (VehicleHash)1336514315:
                        iVar1 = 1810000;
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_35787") /* Tunable: SU23_BIN_PRICE_GAUNTLET6 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_35787") /* Tunable: SU23_BIN_PRICE_GAUNTLET6 */;
                        }
                        break;
                    case /*Iwagen*/ (VehicleHash)662793086:
                        iVar1 = 1720000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_32728") /* Tunable: FIXER_BIN_PRICE_IWAGEN */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_32728") /* Tunable: FIXER_BIN_PRICE_IWAGEN */;
                            }
                        }
                        break;
                }
            }
            switch ((VehicleHash)vehicleModel)
            {
                case VehicleHash.Paradise:
                    iVar1 = 50000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 25000;
                        if (Tunables.Global_262145.Value<int>("f_7798") /* Tunable: DLC_VEHICLE_BRAVADO_PARADISE */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7798") /* Tunable: DLC_VEHICLE_BRAVADO_PARADISE */;
                        }
                    }
                    break;

                case VehicleHash.Bifta:
                    iVar1 = 75000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7796") /* Tunable: DLC_VEHICLE_BF_BIFTA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7796") /* Tunable: DLC_VEHICLE_BF_BIFTA */;
                        }
                    }
                    break;

                case VehicleHash.Kalahari:
                    iVar1 = 40000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 40000;
                        if (Tunables.Global_262145.Value<int>("f_7797") /* Tunable: DLC_VEHICLE_CANIS_KALAHARI */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7797") /* Tunable: DLC_VEHICLE_CANIS_KALAHARI */;
                        }
                    }
                    break;

                case VehicleHash.Speeder:
                    iVar1 = 325000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7799") /* Tunable: DLC_VEHICLE_PEGASSI_SPEEDER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7799") /* Tunable: DLC_VEHICLE_PEGASSI_SPEEDER */;
                        }
                    }
                    break;

                case VehicleHash.BType:
                    iVar1 = 1150000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 750000;
                        if (Tunables.Global_262145.Value<int>("f_7138") /* Tunable: VALENTINE_MODIFIER_CADDY_SEDAN */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7138") /* Tunable: VALENTINE_MODIFIER_CADDY_SEDAN */;
                        }
                    }
                    break;

                case VehicleHash.Jester:
                    iVar1 = 240000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7110") /* Tunable: BUSINESS_VEHICLES_JESTER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7110") /* Tunable: BUSINESS_VEHICLES_JESTER */;
                        }
                    }
                    break;

                case VehicleHash.Turismor:
                    if (!bParam2)
                    {
                        iVar1 = 500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7112") /* Tunable: BUSINESS_VEHICLES_TURISMOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7112") /* Tunable: BUSINESS_VEHICLES_TURISMOR */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 0;
                    }
                    break;

                case VehicleHash.Alpha:
                    iVar1 = 150000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7108") /* Tunable: BUSINESS_VEHICLES_ALPHA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7108") /* Tunable: BUSINESS_VEHICLES_ALPHA */;
                        }
                    }
                    break;

                case VehicleHash.Vestra:
                    iVar1 = 950000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7163") /* Tunable: BUSINESS_VEHICLE_VESTRA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7163") /* Tunable: BUSINESS_VEHICLE_VESTRA */;
                        }
                    }
                    break;

                case VehicleHash.Massacro:
                    iVar1 = 275000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7111") /* Tunable: BUSINESS_VEHICLES_MASSACRO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7111") /* Tunable: BUSINESS_VEHICLES_MASSACRO */;
                        }
                    }
                    break;

                case VehicleHash.Zentorno:
                    iVar1 = 725000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7113") /* Tunable: BUSINESS_VEHICLES_ZENTORNO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7113") /* Tunable: BUSINESS_VEHICLES_ZENTORNO */;
                        }
                    }
                    break;

                case VehicleHash.Huntley:
                    if (!bParam2)
                    {
                        iVar1 = 195000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_7109") /* Tunable: BUSINESS_VEHICLES_HUNTLEY */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7109") /* Tunable: BUSINESS_VEHICLES_HUNTLEY */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 0;
                    }
                    break;

                case VehicleHash.Thrust:
                    iVar1 = 75000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7800") /* Tunable: DLC_VEHICLE_DINKA_THRUST */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7800") /* Tunable: DLC_VEHICLE_DINKA_THRUST */;
                        }
                    }
                    break;

                case VehicleHash.Blade:
                    iVar1 = 160000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_8276") /* Tunable: DLC_HIPSTER_CAR_MOD_VAPID_BLADE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8276") /* Tunable: DLC_HIPSTER_CAR_MOD_VAPID_BLADE */;
                        }
                    }
                    break;

                case VehicleHash.Warrener:
                    iVar1 = 125000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 120000;
                        if (Tunables.Global_262145.Value<int>("f_8279") /* Tunable: DLC_HIPSTER_CAR_MOD_VULCAR_WARRENER */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8279") /* Tunable: DLC_HIPSTER_CAR_MOD_VULCAR_WARRENER */;
                        }
                    }
                    break;

                case VehicleHash.Glendale:
                    iVar1 = 200000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_8277") /* Tunable: DLC_HIPSTER_CAR_MOD_BENEFACTOR_GLENDA */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_8277") /* Tunable: DLC_HIPSTER_CAR_MOD_BENEFACTOR_GLENDA */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = Round((200000) * 0.75f);
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26126") /* Tunable: AW_TRADE_PRICE_GLENDALE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26126") /* Tunable: AW_TRADE_PRICE_GLENDALE */;
                        }
                    }
                    break;

                case VehicleHash.Rhapsody:
                    iVar1 = 100000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 140000;
                        if (Tunables.Global_262145.Value<int>("f_8278") /* Tunable: DLC_HIPSTER_CAR_MOD_DECLASSE_RHAPSODY */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8278") /* Tunable: DLC_HIPSTER_CAR_MOD_DECLASSE_RHAPSODY */;
                        }
                    }
                    break;

                case VehicleHash.Panto:
                    iVar1 = 85000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_8280") /* Tunable: DLC_HIPSTER_CAR_MOD_BENEFACTOR_PANTO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8280") /* Tunable: DLC_HIPSTER_CAR_MOD_BENEFACTOR_PANTO */;
                        }
                    }
                    break;

                case VehicleHash.Dubsta3:
                    iVar1 = 249000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_8281") /* Tunable: DLC_HIPSTER_CAR_MOD_DUBSTA3 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8281") /* Tunable: DLC_HIPSTER_CAR_MOD_DUBSTA3 */;
                        }
                    }
                    break;

                case VehicleHash.Pigalle:
                    iVar1 = 400000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_8275") /* Tunable: DLC_HIPSTER_MODIFIER_VULCAR_PIGALLE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8275") /* Tunable: DLC_HIPSTER_MODIFIER_VULCAR_PIGALLE */;
                        }
                    }
                    break;

                case VehicleHash.Besra:
                    iVar1 = 658000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 1150000;
                        if (Tunables.Global_262145.Value<int>("f_8708") /* Tunable: PS_WESTERN_BESRA */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8708") /* Tunable: PS_WESTERN_BESRA */;
                        }
                    }
                    break;

                case VehicleHash.Miljet:
                    iVar1 = 1750000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 1700000;
                        if (Tunables.Global_262145.Value<int>("f_8709") /* Tunable: PS_BUCKINGHAM_MILJET */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8709") /* Tunable: PS_BUCKINGHAM_MILJET */;
                        }
                    }
                    break;

                case VehicleHash.Swift:
                    if (!bParam2)
                    {
                        iVar1 = 1500000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_8710") /* Tunable: PS_SWIFT_LIVERY_1 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_8710") /* Tunable: PS_SWIFT_LIVERY_1 */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 1600000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_8711") /* Tunable: PS_SWIFT_LIVERY_2 */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_8711") /* Tunable: PS_SWIFT_LIVERY_2 */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Coquette2:
                    if (bParam2)
                    {
                        iVar1 = 350000;
                        if (bVar0 || iParam3 == 1)
                        {
                            iVar1 = 665000;
                            if (Tunables.Global_262145.Value<int>("f_8706") /* Tunable: PS_INVERTO_COQUETTE_CLASSIC */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_8706") /* Tunable: PS_INVERTO_COQUETTE_CLASSIC */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 395000;
                        if (bVar0 || iParam3 == 1)
                        {
                            iVar1 = 665000;
                            if (Tunables.Global_262145.Value<int>("f_8707") /* Tunable: PS_INVERTO_COQUETTE_CLASSIC_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_8707") /* Tunable: PS_INVERTO_COQUETTE_CLASSIC_TOPLESS */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Sovereign:
                    iVar1 = 120000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_8450") /* Tunable: VEHICLE_INDEPENDENCEDAY_SOVEREIGN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8450") /* Tunable: VEHICLE_INDEPENDENCEDAY_SOVEREIGN */;
                        }
                    }
                    break;

                case VehicleHash.Monster:
                    iVar1 = 742000;
                    if (bVar0 || iParam3 == 1)
                    {
                        iVar1 = 742014;
                        if (Tunables.Global_262145.Value<int>("f_8449") /* Tunable: VEHICLE_INDEPENDENCEDAY_MONSTER */ >= 0 && bVar0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_8449") /* Tunable: VEHICLE_INDEPENDENCEDAY_MONSTER */;
                        }
                    }
                    break;

                case VehicleHash.Innovation:
                    iVar1 = 92500;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9024") /* Tunable: LTS_LCC_INNOVATION */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9024") /* Tunable: LTS_LCC_INNOVATION */;
                        }
                    }
                    break;

                case VehicleHash.Hakuchou:
                    iVar1 = 82000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9025") /* Tunable: LTS_SHITZU_HAKUCHOU */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9025") /* Tunable: LTS_SHITZU_HAKUCHOU */;
                        }
                    }
                    break;

                case VehicleHash.Furoregt:
                    iVar1 = 448000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9026") /* Tunable: LTS_LAMPADATI_FURORE_GT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9026") /* Tunable: LTS_LAMPADATI_FURORE_GT */;
                        }
                    }
                    break;

                case VehicleHash.Boxville4:
                    if (!bParam2)
                    {
                        iVar1 = 45000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9257") /* Tunable: VEHICLES_HEIST_BRUTE_BOXVILLE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9257") /* Tunable: VEHICLES_HEIST_BRUTE_BOXVILLE */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 59850;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20363") /* Tunable: VEHICLES_HEIST_BRUTE_BOXVILLE_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20363") /* Tunable: VEHICLES_HEIST_BRUTE_BOXVILLE_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Casco:
                    if (!bParam2)
                    {
                        iVar1 = 680000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9258") /* Tunable: VEHICLES_HEIST_LAMPADATI_CASCO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9258") /* Tunable: VEHICLES_HEIST_LAMPADATI_CASCO */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 904400;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20364") /* Tunable: VEHICLES_HEIST_LAMPADATI_CASCO_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20364") /* Tunable: VEHICLES_HEIST_LAMPADATI_CASCO_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Dinghy3:
                    if (!bParam2)
                    {
                        iVar1 = 125000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9259") /* Tunable: VEHICLES_HEIST_NAGASAKI_DINGHY */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9259") /* Tunable: VEHICLES_HEIST_NAGASAKI_DINGHY */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 166250;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20365") /* Tunable: VEHICLES_HEIST_NAGASAKI_DINGHY_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20365") /* Tunable: VEHICLES_HEIST_NAGASAKI_DINGHY_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Enduro:
                    iVar1 = 48000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9260") /* Tunable: VEHICLES_HEIST_DINKA_ENDURO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9260") /* Tunable: VEHICLES_HEIST_DINKA_ENDURO */;
                        }
                    }
                    break;

                case VehicleHash.GBurrito2:
                    if (!bParam2)
                    {
                        iVar1 = 65000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9261") /* Tunable: VEHICLES_HEIST_DECLASSE_GANG_BURRITO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9261") /* Tunable: VEHICLES_HEIST_DECLASSE_GANG_BURRITO */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 86450;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20366") /* Tunable: VEHICLES_HEIST_DECLASSE_GANG_BURRITO_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20366") /* Tunable: VEHICLES_HEIST_DECLASSE_GANG_BURRITO_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Guardian:
                    iVar1 = 375000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9262") /* Tunable: VEHICLES_HEIST_VAPID_GUADIAN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9262") /* Tunable: VEHICLES_HEIST_VAPID_GUADIAN */;
                        }
                    }
                    break;

                case VehicleHash.Hydra:
                    if (!bParam2)
                    {
                        iVar1 = 3000000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9263") /* Tunable: VEHICLES_HEIST_MAMMOTH_HYDRA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9263") /* Tunable: VEHICLES_HEIST_MAMMOTH_HYDRA */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 3990000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20367") /* Tunable: VEHICLES_HEIST_MAMMOTH_HYDRA_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20367") /* Tunable: VEHICLES_HEIST_MAMMOTH_HYDRA_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Insurgent:
                    if (!bParam2)
                    {
                        iVar1 = 1350000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9264") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9264") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 1795500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20368") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20368") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Insurgent2:
                    if (!bParam2)
                    {
                        iVar1 = 675000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9265") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9265") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 897750;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20369") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20369") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Kuruma:
                    if (!bParam2)
                    {
                        iVar1 = 95000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9266") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9266") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 126350;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20370") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20370") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Kuruma2:
                    if (!bParam2)
                    {
                        iVar1 = 525000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9267") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_ARMORED */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9267") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_ARMORED */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 698250;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20371") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_ARMORED_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20371") /* Tunable: VEHICLES_HEIST_KARIN_KURUMA_ARMORED_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Lectro:
                    if (!bParam2)
                    {
                        iVar1 = 750000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9268") /* Tunable: VEHICLES_HEIST_PRINCIPE_LECTRO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9268") /* Tunable: VEHICLES_HEIST_PRINCIPE_LECTRO */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 997500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20372") /* Tunable: VEHICLES_HEIST_PRINCIPE_LECTRO_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20372") /* Tunable: VEHICLES_HEIST_PRINCIPE_LECTRO_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.PBus:
                    if (!bParam2)
                    {
                        iVar1 = 550000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9274") /* Tunable: VEHICLES_HEIST_PBUS */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9274") /* Tunable: VEHICLES_HEIST_PBUS */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 731500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20378") /* Tunable: VEHICLES_HEIST_PBUS_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20378") /* Tunable: VEHICLES_HEIST_PBUS_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Mule3:
                    if (!bParam2)
                    {
                        iVar1 = 32500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9269") /* Tunable: VEHICLES_HEIST_MAIBATSU_MULE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9269") /* Tunable: VEHICLES_HEIST_MAIBATSU_MULE */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 43225;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20373") /* Tunable: VEHICLES_HEIST_MAIBATSU_MULE_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20373") /* Tunable: VEHICLES_HEIST_MAIBATSU_MULE_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Savage:
                    if (!bParam2)
                    {
                        iVar1 = 1950000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9270") /* Tunable: VEHICLES_HEIST_SAVAGE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9270") /* Tunable: VEHICLES_HEIST_SAVAGE */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 2593500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20374") /* Tunable: VEHICLES_HEIST_SAVAGE_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20374") /* Tunable: VEHICLES_HEIST_SAVAGE_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Valkyrie:
                    if (!bParam2)
                    {
                        iVar1 = 2850000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9272") /* Tunable: VEHICLES_HEIST_BUCKINGHAM_VALKYRIE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9272") /* Tunable: VEHICLES_HEIST_BUCKINGHAM_VALKYRIE */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 3790500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20376") /* Tunable: VEHICLES_HEIST_BUCKINGHAM_VALKYRIE_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20376") /* Tunable: VEHICLES_HEIST_BUCKINGHAM_VALKYRIE_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Technical:
                    if (!bParam2)
                    {
                        iVar1 = 950000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9271") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9271") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 1263500;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20375") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20375") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Velum2:
                    if (!bParam2)
                    {
                        iVar1 = 995000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9273") /* Tunable: VEHICLES_HEIST_VELUM */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9273") /* Tunable: VEHICLES_HEIST_VELUM */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 1323350;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_20377") /* Tunable: VEHICLES_HEIST_VELUM_BIN_PRICE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20377") /* Tunable: VEHICLES_HEIST_VELUM_BIN_PRICE */;
                            }
                        }
                    }
                    break;

                case VehicleHash.Dodo:
                    iVar1 = 500000;
                    if (bVar0)
                    {
                        if (!bParam2)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9361") /* Tunable: CGTONG_DODO */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9361") /* Tunable: CGTONG_DODO */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20381") /* Tunable: RETURNING_PRICE_DODO */;
                        }
                    }
                    break;

                case VehicleHash.Marshall:
                    iVar1 = 250000;
                    if (bVar0 || iParam3 == 1)
                    {
                        if (!bParam2)
                        {
                            iVar1 = 500000;
                            if (Tunables.Global_262145.Value<int>("f_9363") /* Tunable: CGTONG_CHEVAL_MARSHALL */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9363") /* Tunable: CGTONG_CHEVAL_MARSHALL */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20380") /* Tunable: RETURNING_PRICE_MARSHALL */;
                        }
                    }
                    break;

                case VehicleHash.Submersible2:
                    iVar1 = 1325000;
                    if (bVar0)
                    {
                        if (!bParam2)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9365") /* Tunable: CGTONG_SUBMERSIBLE */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9365") /* Tunable: CGTONG_SUBMERSIBLE */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20382") /* Tunable: RETURNING_PRICE_KRAKEN */;
                        }
                    }
                    break;

                case VehicleHash.Blista2:
                    iVar1 = 42000;
                    if (bVar0)
                    {
                        if (!bParam2)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9360") /* Tunable: CGTONG_DINKA_BLISTA_COMPACT */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9360") /* Tunable: CGTONG_DINKA_BLISTA_COMPACT */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20385") /* Tunable: RETURNING_PRICE_BLISTA */;
                        }
                    }
                    break;

                case VehicleHash.Stalion:
                    iVar1 = 71000;
                    if (bVar0)
                    {
                        if (!bParam2)
                        {
                            if (Tunables.Global_262145.Value<int>("f_9364") /* Tunable: CGTONG_DECLASSE_STALLION */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9364") /* Tunable: CGTONG_DECLASSE_STALLION */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20384") /* Tunable: RETURNING_PRICE_STALLION */;
                        }
                    }
                    break;

                case VehicleHash.Dukes:
                    iVar1 = 62000;
                    if (bVar0)
                    {
                        if (!bParam2)
                        {
                            iVar1 = 62000;
                            if (Tunables.Global_262145.Value<int>("f_9362") /* Tunable: CGTONG_IMPONTE_DUKES */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9362") /* Tunable: CGTONG_IMPONTE_DUKES */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20383") /* Tunable: RETURNING_PRICE_DUKES */;
                        }
                    }
                    break;

                case VehicleHash.Dukes2:
                    iVar1 = 279000;
                    if (bVar0 || iParam3 == 1)
                    {
                        if (!bParam2)
                        {
                            iVar1 = 665000;
                            if (Tunables.Global_262145.Value<int>("f_20379") /* Tunable: CGTONG_IMPONTE_DUKE_O_DEATH */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_20379") /* Tunable: CGTONG_IMPONTE_DUKE_O_DEATH */;
                            }
                        }
                        else
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_20386") /* Tunable: RETURNING_PRICE_DUKEODEATH */;
                        }
                    }
                    break;

                case VehicleHash.Stalion2:
                    iVar1 = 277000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_17543") /* Tunable: STUNT_DECLASSE_BURGER_SHOT_STALLION */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_17543") /* Tunable: STUNT_DECLASSE_BURGER_SHOT_STALLION */;
                        }
                    }
                    break;

                case VehicleHash.Dominator2:
                    iVar1 = 315000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_17541") /* Tunable: STUNT_VAPID_PISSWASSER_DOMINATOR */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_17541") /* Tunable: STUNT_VAPID_PISSWASSER_DOMINATOR */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = Round((315000) * 0.75f);
                    }
                    break;

                case VehicleHash.Gauntlet2:
                    iVar1 = 230000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_17542") /* Tunable: STUNT_BRAVADO_REDWOOD_GAUNTLET */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_17542") /* Tunable: STUNT_BRAVADO_REDWOOD_GAUNTLET */;
                        }
                    }
                    break;

                case VehicleHash.Buffalo3:
                    iVar1 = 535000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_17540") /* Tunable: STUNT_BRAVADO_SPRUNK_BUFFALO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_17540") /* Tunable: STUNT_BRAVADO_SPRUNK_BUFFALO */;
                        }
                    }
                    break;

                case VehicleHash.SlamVan:
                    iVar1 = 49500;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_9578") /* Tunable: VEHICLE_XMAS14_SLAMVAN */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_9578") /* Tunable: VEHICLE_XMAS14_SLAMVAN */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = Round((49500) * 0.75f);
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26127") /* Tunable: AW_TRADE_PRICE_SLAMVAN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26127") /* Tunable: AW_TRADE_PRICE_SLAMVAN */;
                        }
                    }
                    break;

                case VehicleHash.RatLoader2:
                    iVar1 = 37500;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_9577") /* Tunable: VEHICLE_XMAS14_RAT_TRUCK */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_9577") /* Tunable: VEHICLE_XMAS14_RAT_TRUCK */;
                    }
                    if (bParam2)
                    {
                        iVar2 = iVar1;
                        iVar1 = Round((37500) * 0.75f);
                        if (bVar0 && Tunables.Global_262145.Value<int>("f_26125") /* Tunable: AW_TRADE_PRICE_RATLOADER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_26125") /* Tunable: AW_TRADE_PRICE_RATLOADER */;
                        }
                    }
                    break;

                case VehicleHash.Jester2:
                    iVar1 = 350000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9575") /* Tunable: VEHICLE_XMAS14_DINKA_JESTER_RACECAR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9575") /* Tunable: VEHICLE_XMAS14_DINKA_JESTER_RACECAR */;
                        }
                    }
                    break;

                case VehicleHash.Massacro2:
                    iVar1 = 385000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9576") /* Tunable: VEHICLE_XMAS14_DEWBAUCHEE_MASSACRO_RACECAR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_9576") /* Tunable: VEHICLE_XMAS14_DEWBAUCHEE_MASSACRO_RACECAR */;
                        }
                    }
                    break;

                case VehicleHash.Feltzer3:
                    iVar1 = 975000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11233") /* Tunable: LUXE1_WEBSITE_BENEFACTOR_STIRLING_GT */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11233") /* Tunable: LUXE1_WEBSITE_BENEFACTOR_STIRLING_GT */;
                        }
                    }
                    break;

                case VehicleHash.Luxor2:
                    iVar1 = 10000000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11234") /* Tunable: LUXE1_WEBSITE_BUCKINGHAM_LUXOR_DELUXE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11234") /* Tunable: LUXE1_WEBSITE_BUCKINGHAM_LUXOR_DELUXE */;
                        }
                    }
                    break;

                case VehicleHash.Osiris:
                    iVar1 = 1950000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11235") /* Tunable: LUXE1_WEBSITE_PEGASSI_OSIRIS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11235") /* Tunable: LUXE1_WEBSITE_PEGASSI_OSIRIS */;
                        }
                    }
                    break;

                case VehicleHash.Swift2:
                    iVar1 = 5150000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11236") /* Tunable: LUXE1_WEBSITE_BUCKINGHAM_SWIFT_DELUXE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11236") /* Tunable: LUXE1_WEBSITE_BUCKINGHAM_SWIFT_DELUXE */;
                        }
                    }
                    break;

                case VehicleHash.Virgo:
                    iVar1 = 195000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11237") /* Tunable: LUXE1_WEBSITE_ALBANY_VIRGO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11237") /* Tunable: LUXE1_WEBSITE_ALBANY_VIRGO */;
                        }
                    }
                    break;

                case VehicleHash.Windsor:
                    if (!bParam2)
                    {
                        iVar1 = 845000;
                        if (bVar0)
                        {
                            if (Tunables.Global_262145.Value<int>("f_11238") /* Tunable: LUXE1_WEBSITE_ENUS_WINDSOR */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_11238") /* Tunable: LUXE1_WEBSITE_ENUS_WINDSOR */;
                            }
                        }
                    }
                    else
                    {
                        iVar1 = 0;
                    }
                    break;

                case VehicleHash.Brawler:
                    iVar1 = 715000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11532") /* Tunable: LUXE2_COIL_BRAWLER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11532") /* Tunable: LUXE2_COIL_BRAWLER */;
                        }
                    }
                    break;

                case VehicleHash.Chino:
                    iVar1 = 225000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11533") /* Tunable: LUXE2_VAPID_CHINO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11533") /* Tunable: LUXE2_VAPID_CHINO */;
                        }
                    }
                    break;

                case VehicleHash.Coquette3:
                    iVar1 = 695000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11534") /* Tunable: LUXE2_INVETERO_COQUETTE_BLACKFIN */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11534") /* Tunable: LUXE2_INVETERO_COQUETTE_BLACKFIN */;
                        }
                    }
                    break;

                case VehicleHash.T20:
                    iVar1 = 2200000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11535") /* Tunable: LUXE2_PROGEN_T20 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11535") /* Tunable: LUXE2_PROGEN_T20 */;
                        }
                    }
                    break;

                case VehicleHash.Toro:
                    iVar1 = 1750000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11536") /* Tunable: LUXE2_LAMPADATI_TORO */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11536") /* Tunable: LUXE2_LAMPADATI_TORO */;
                        }
                    }
                    break;

                case VehicleHash.Vindicator:
                    iVar1 = 630000;
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_11537") /* Tunable: LUXE2_DINKA_VINDICATOR */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_11537") /* Tunable: LUXE2_DINKA_VINDICATOR */;
                        }
                    }
                    break;

                case VehicleHash.Chino2:
                    iVar1 = 225000;
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12515") /* Tunable: WEBSITE_VAPID_CHINO__BENNYS_WEBSITE_ */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Primo2:
                    iVar1 = 100000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12514") /* Tunable: WEBSITE_ALBANY_PRIMO */ >= 0)
                    {
                        iVar1 = Round(Tunables.Global_262145.Value<int>("f_12514") /* Tunable: WEBSITE_ALBANY_PRIMO */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    }
                    break;

                case VehicleHash.Moonbeam:
                    iVar1 = 32500;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12511") /* Tunable: WEBSITE_DECLASSE_MOONBEAM */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12511") /* Tunable: WEBSITE_DECLASSE_MOONBEAM */;
                    }
                    break;

                case VehicleHash.Moonbeam2:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12511") /* Tunable: WEBSITE_DECLASSE_MOONBEAM */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Faction:
                    iVar1 = 36000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12510") /* Tunable: WEBSITE_WILLARD_FACTION */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12510") /* Tunable: WEBSITE_WILLARD_FACTION */;
                    }
                    break;

                case VehicleHash.Faction2:
                    iVar1 = 95000;
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12510") /* Tunable: WEBSITE_WILLARD_FACTION */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Buccaneer:
                    iVar1 = 29000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12512") /* Tunable: WEBSITE_ALBANY_BUCCANEER */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12512") /* Tunable: WEBSITE_ALBANY_BUCCANEER */;
                    }
                    break;

                case VehicleHash.Buccaneer2:
                    iVar1 = 85000;
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12512") /* Tunable: WEBSITE_ALBANY_BUCCANEER */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Voodoo2:
                    iVar1 = 5500;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12513") /* Tunable: WEBSITE_DECLASSE_VOODOO */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12513") /* Tunable: WEBSITE_DECLASSE_VOODOO */;
                    }
                    break;

                case VehicleHash.Voodoo:
                    iVar1 = 105000;
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12513") /* Tunable: WEBSITE_DECLASSE_VOODOO */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Dominator4*/ (VehicleHash)3606777648:
                case /*Dominator5*/ (VehicleHash)2919906639:
                case /*Dominator6*/ (VehicleHash)3001042683:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_26128") /* Tunable: AW_TRADE_PRICE_DOMINATOR */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Slamvan4*/ (VehicleHash)2233918197:
                case /*Slamvan5*/ (VehicleHash)373261600:
                case /*Slamvan6*/ (VehicleHash)1742022738:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_9578") /* Tunable: VEHICLE_XMAS14_SLAMVAN */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Issi4*/ (VehicleHash)628003514:
                case /*Issi5*/ (VehicleHash)1537277726:
                case /*Issi6*/ (VehicleHash)1239571361:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_24305") /* Tunable: ASSAULT_VEHICLES_WEENY_ISSI_CLASSIC */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Impaler2*/ (VehicleHash)1009171724:
                case /*Impaler3*/ (VehicleHash)2370166601:
                case /*Impaler4*/ (VehicleHash)2550461639:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_26129") /* Tunable: AW_TRADE_PRICE_IMPALER */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Deathbike*/ (VehicleHash)4267640610:
                case /*Deathbike2*/ (VehicleHash)2482017624:
                case /*Deathbike3*/ (VehicleHash)2920466844:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_26131") /* Tunable: AW_TRADE_PRICE_GARGOYLE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Monster3*/ (VehicleHash)1721676810:
                case /*Monster4*/ (VehicleHash)840387324:
                case /*Monster5*/ (VehicleHash)3579220348:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_26125") /* Tunable: AW_TRADE_PRICE_RATLOADER */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case /*Bruiser*/ (VehicleHash)668439077:
                case /*Bruiser2*/ (VehicleHash)2600885406:
                case /*Bruiser3*/ (VehicleHash)2252616474:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_26126") /* Tunable: AW_TRADE_PRICE_GLENDALE */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.BType2:
                    iVar1 = 550000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12732") /* Tunable: HALLOWEEN_2015_ALBANY_FRANKEN_STANGE */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12732") /* Tunable: HALLOWEEN_2015_ALBANY_FRANKEN_STANGE */;
                    }
                    break;

                case VehicleHash.Lurcher:
                    iVar1 = 650000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_12733") /* Tunable: HALLOWEEN_2015_CHARIOT_LURCHER */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_12733") /* Tunable: HALLOWEEN_2015_CHARIOT_LURCHER */;
                    }
                    break;

                case VehicleHash.Baller3:
                    iVar1 = 149000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13429") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13429") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE */;
                    }
                    break;

                case VehicleHash.Baller5:
                    iVar1 = 374000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13430") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13430") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE_ARMORED */;
                    }
                    break;

                case VehicleHash.Baller4:
                    iVar1 = 247000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13431") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE_LWB */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13431") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LE_LWB */;
                    }
                    break;

                case VehicleHash.Baller6:
                    iVar1 = 513000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13432") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LWB_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13432") /* Tunable: APARTMENT_WEBSITE_GALLIVANTER_BALLER_LWB_ARMORED */;
                    }
                    break;

                case VehicleHash.Cog55:
                    iVar1 = 154000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13433") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_55 */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13433") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_55 */;
                    }
                    break;

                case VehicleHash.Cog552:
                    iVar1 = 396000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13434") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_55_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13434") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_55_ARMORED */;
                    }
                    break;

                case VehicleHash.Cognoscenti:
                    iVar1 = 254000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13435") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13435") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI */;
                    }
                    break;

                case VehicleHash.Cognoscenti2:
                    iVar1 = 558000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13436") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13436") /* Tunable: APARTMENT_WEBSITE_ENUS_COGNOSCENTI_ARMORED */;
                    }
                    break;

                case VehicleHash.Limo2:
                    iVar1 = 1650000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13437") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_TURRETED_LIMO */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13437") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_TURRETED_LIMO */;
                    }
                    break;

                case VehicleHash.Mamba:
                    iVar1 = 995000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13438") /* Tunable: APARTMENT_WEBSITE_DECLASSE_MAMBA */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13438") /* Tunable: APARTMENT_WEBSITE_DECLASSE_MAMBA */;
                    }
                    break;

                case VehicleHash.Nightshade:
                    iVar1 = 585000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13439") /* Tunable: APARTMENT_WEBSITE_IMPONTE_NIGHT_SHADE */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13439") /* Tunable: APARTMENT_WEBSITE_IMPONTE_NIGHT_SHADE */;
                    }
                    break;

                case VehicleHash.Schafter3:
                    iVar1 = 116000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13440") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_V12 */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13440") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_V12 */;
                    }
                    break;

                case VehicleHash.Schafter5:
                    iVar1 = 325000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13441") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_V12_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13441") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_V12_ARMORED */;
                    }
                    break;

                case VehicleHash.Schafter4:
                    iVar1 = 208000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13442") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_LWB */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13442") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_LWB */;
                    }
                    break;

                case VehicleHash.Schafter6:
                    iVar1 = 438000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13443") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_LWB_ARMORED */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13443") /* Tunable: APARTMENT_WEBSITE_BENEFACTOR_SCHAFTER_LWB_ARMORED */;
                    }
                    break;

                case VehicleHash.Verlierer2:
                    iVar1 = 695000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13444") /* Tunable: APARTMENT_WEBSITE_BRAVADO_VERLIERER */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13444") /* Tunable: APARTMENT_WEBSITE_BRAVADO_VERLIERER */;
                    }
                    break;

                case VehicleHash.Supervolito:
                    iVar1 = 2113000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13445") /* Tunable: APARTMENT_WEBSITE_BUCKINGHAM_SUPERVOLITO */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13445") /* Tunable: APARTMENT_WEBSITE_BUCKINGHAM_SUPERVOLITO */;
                    }
                    break;

                case VehicleHash.Supervolito2:
                    iVar1 = 3330000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13446") /* Tunable: APARTMENT_WEBSITE_BUCKINGHAM_SUPERVOLITO_CARBON */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13446") /* Tunable: APARTMENT_WEBSITE_BUCKINGHAM_SUPERVOLITO_CARBON */;
                    }
                    break;

                case VehicleHash.Tampa:
                    iVar1 = 375000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13506") /* Tunable: XMAS2015_DECLASSE_TAMPA */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13506") /* Tunable: XMAS2015_DECLASSE_TAMPA */;
                    }
                    break;

                case VehicleHash.Sultan:
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13625") /* Tunable: BENNYSWEBSITE_KARIN_SULTAN_BENNYS */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13625") /* Tunable: BENNYSWEBSITE_KARIN_SULTAN_BENNYS */;
                    }
                    break;

                case VehicleHash.SultanRS:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_13625") /* Tunable: BENNYSWEBSITE_KARIN_SULTAN_BENNYS */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Banshee:
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13627") /* Tunable: UPGRADE_BRAVADO_BANSHEE_BENNYS */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13627") /* Tunable: UPGRADE_BRAVADO_BANSHEE_BENNYS */;
                    }
                    break;

                case VehicleHash.Banshee2:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_13627") /* Tunable: UPGRADE_BRAVADO_BANSHEE_BENNYS */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.BType3:
                    iVar1 = 982000;
                    if (bVar0 && Tunables.Global_262145.Value<int>("f_13655") /* Tunable: WEBSITE_VALENTINES2016_ALBANY_ROOSEVELT_VALOR */ >= 0)
                    {
                        iVar1 = Tunables.Global_262145.Value<int>("f_13655") /* Tunable: WEBSITE_VALENTINES2016_ALBANY_ROOSEVELT_VALOR */;
                    }
                    break;

                case VehicleHash.Faction3:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_12510") /* Tunable: WEBSITE_WILLARD_FACTION */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Minivan2:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_7120") /* Tunable: BUSINESS_VEHICLES_MINIVAN */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.SabreGT2:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_15204") /* Tunable: WEBSITE_BENNYS_DECLASSE_SABRE_TURBO */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.SlamVan3:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_9578") /* Tunable: VEHICLE_XMAS14_SLAMVAN */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Tornado5:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_15205") /* Tunable: WEBSITE_BENNYS_DECLASSE_TORNADO */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Virgo3:
                    iVar1 = Tunables.Global_262145.Value<int>("f_15203") /* Tunable: WEBSITE_BENNYS_DUNDREARY_VIRGO_CLASSIC */;
                    break;

                case VehicleHash.Virgo2:
                    iVar1 = Round(Tunables.Global_262145.Value<int>("f_15203") /* Tunable: WEBSITE_BENNYS_DUNDREARY_VIRGO_CLASSIC */ + VehicleCheckers.func_7073(vehicleModel, 2));
                    break;

                case VehicleHash.Technical3:
                    iVar1 = (950000 + VehicleCheckers.func_7073(vehicleModel, 2));
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9271") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL */ >= 0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_9271") /* Tunable: VEHICLES_HEIST_KARIN_TECHNICAL */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                    }
                    break;

                case VehicleHash.Insurgent3:
                    iVar1 = (1350000 + VehicleCheckers.func_7073(vehicleModel, 2));
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_9264") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP */ >= 0)
                        {
                            iVar1 = Round(Tunables.Global_262145.Value<int>("f_9264") /* Tunable: VEHICLES_HEIST_HVY_INSURGENT_PICKUP */ + VehicleCheckers.func_7073(vehicleModel, 2));
                        }
                    }
                    break;
            }
            switch ((VehicleHash)vehicleModel)
            {
                case VehicleHash.F620:
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7806") /* Tunable: DLC_VEHICLE_OCELOT_F620 */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7806") /* Tunable: DLC_VEHICLE_OCELOT_F620 */;
                        }
                    }
                    break;

                case VehicleHash.Fusilade:
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7807") /* Tunable: DLC_VEHICLE_SCHYSTER_FUSILADE */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7807") /* Tunable: DLC_VEHICLE_SCHYSTER_FUSILADE */;
                        }
                    }
                    break;

                case VehicleHash.Penumbra:
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7808") /* Tunable: DLC_VEHICLE_MAIBATSU_PENUMBRA */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7808") /* Tunable: DLC_VEHICLE_MAIBATSU_PENUMBRA */;
                        }
                    }
                    break;

                case VehicleHash.Sentinel:
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7809") /* Tunable: DLC_VEHICLE_UBERMACHT_SENTINEL_XS */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7809") /* Tunable: DLC_VEHICLE_UBERMACHT_SENTINEL_XS */;
                        }
                    }
                    break;

                case VehicleHash.Sentinel2:
                    if (bVar0)
                    {
                        if (Tunables.Global_262145.Value<int>("f_7810") /* Tunable: DLC_VEHICLE_UBERMACHT_SENTINEL */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_7810") /* Tunable: DLC_VEHICLE_UBERMACHT_SENTINEL */;
                        }
                    }
                    break;
            }
            if (bVar0)
            {
                switch ((VehicleHash)vehicleModel)
                {
                    case VehicleHash.Elegy2:
                        if (bParam2)
                        {
                            if (Tunables.Global_262145.Value<int>("f_4050") /* Tunable: ELEGY2_EXPENDITURE_MODIFIER */ >= 0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4050") /* Tunable: ELEGY2_EXPENDITURE_MODIFIER */;
                            }
                        }
                        break;

                    case VehicleHash.Khamelion:
                        if (Tunables.Global_262145.Value<int>("f_4066") /* Tunable: KHAMELION_EXPENDITURE_MODIFIER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_4066") /* Tunable: KHAMELION_EXPENDITURE_MODIFIER */;
                        }
                        break;

                    case VehicleHash.Hotknife:
                        if (Tunables.Global_262145.Value<int>("f_4060") /* Tunable: HOTKNIFE_EXPENDITURE_MODIFIER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_4060") /* Tunable: HOTKNIFE_EXPENDITURE_MODIFIER */;
                        }
                        break;

                    case VehicleHash.CarbonRS:
                        if (Tunables.Global_262145.Value<int>("f_4036") /* Tunable: CARBONRS_EXPENDITURE_MODIFIER */ >= 0)
                        {
                            iVar1 = Tunables.Global_262145.Value<int>("f_4036") /* Tunable: CARBONRS_EXPENDITURE_MODIFIER */;
                        }
                        break;
                }
            }
            if (bVar0 || iParam3 == 1)
            {
                if (bParam2)
                {
                    switch ((VehicleHash)vehicleModel)
                    {
                        case VehicleHash.Coquette:
                            iVar1 = 138000;
                            if (Tunables.Global_262145.Value<int>("f_7803") /* Tunable: DLC_VEHICLE_INVERTO_COQUETTE_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7803") /* Tunable: DLC_VEHICLE_INVERTO_COQUETTE_TOPLESS */;
                            }
                            break;

                        case VehicleHash.Banshee:
                            iVar1 = 126000;
                            if (Tunables.Global_262145.Value<int>("f_7802") /* Tunable: DLC_VEHICLE_BRAVADO_BANSHEE_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7802") /* Tunable: DLC_VEHICLE_BRAVADO_BANSHEE_TOPLESS */;
                            }
                            break;

                        case VehicleHash.Stinger:
                            iVar1 = 850000;
                            if (Tunables.Global_262145.Value<int>("f_7804") /* Tunable: DLC_VEHICLE_GROTTI_STINGER_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7804") /* Tunable: DLC_VEHICLE_GROTTI_STINGER_TOPLESS */;
                            }
                            break;

                        case VehicleHash.Voltic:
                            iVar1 = 150000;
                            if (Tunables.Global_262145.Value<int>("f_4106") /* Tunable: VOLTIC_EXPENDITURE_MODIFIER */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_4106") /* Tunable: VOLTIC_EXPENDITURE_MODIFIER */;
                            }
                            break;

                        case VehicleHash.Chino:
                            iVar1 = 225000;
                            if (Tunables.Global_262145.Value<int>("f_12515") /* Tunable: WEBSITE_VAPID_CHINO__BENNYS_WEBSITE_ */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_12515") /* Tunable: WEBSITE_VAPID_CHINO__BENNYS_WEBSITE_ */;
                            }
                            break;

                        case VehicleHash.Kalahari:
                            iVar1 = 40000;
                            if (Tunables.Global_262145.Value<int>("f_9027") /* Tunable: LTS_CANIS_KALAHARI_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_9027") /* Tunable: LTS_CANIS_KALAHARI_TOPLESS */;
                            }
                            break;

                        case VehicleHash.SlamVan:
                            iVar1 = 49500;
                            if (Tunables.Global_262145.Value<int>("f_15207") /* Tunable: WEBSITE_BENNYS_VAPID_SLAMVAN */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_15207") /* Tunable: WEBSITE_BENNYS_VAPID_SLAMVAN */;
                            }
                            if (bParam2)
                            {
                                iVar2 = iVar1;
                                iVar1 = Round((iVar1) * 0.75f);
                                if (bVar0 && Tunables.Global_262145.Value<int>("f_26127") /* Tunable: AW_TRADE_PRICE_SLAMVAN */ >= 0)
                                {
                                    iVar1 = Tunables.Global_262145.Value<int>("f_26127") /* Tunable: AW_TRADE_PRICE_SLAMVAN */;
                                }
                            }
                            break;

                        case VehicleHash.Minivan:
                            iVar1 = 30000;
                            if (Tunables.Global_262145.Value<int>("f_15206") /* Tunable: WEBSITE_BENNYS_VAPID_MINIVAN */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_15206") /* Tunable: WEBSITE_BENNYS_VAPID_MINIVAN */;
                            }
                            break;
                    }
                }
                else
                {
                    switch ((VehicleHash)vehicleModel)
                    {
                        case VehicleHash.Voltic:
                            if (Tunables.Global_262145.Value<int>("f_7801") /* Tunable: DLC_VEHICLE_COIL_VOLTIC_TOPLESS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_7801") /* Tunable: DLC_VEHICLE_COIL_VOLTIC_TOPLESS */;
                            }
                            break;

                        case VehicleHash.Banshee:
                            if (Tunables.Global_262145.Value<int>("f_13627") /* Tunable: UPGRADE_BRAVADO_BANSHEE_BENNYS */ >= 0 && bVar0)
                            {
                                iVar1 = Tunables.Global_262145.Value<int>("f_13627") /* Tunable: UPGRADE_BRAVADO_BANSHEE_BENNYS */;
                            }
                            break;
                    }
                }
            }
            if (iVar1 == -1)
            {
                return false;
            }
            if (iVar2 == -1)
            {
                iVar2 = iVar1;
            }

            iParam0.Value = iVar1;
            iParam0.f_3 = (int)Math.Floor((((int)Math.Floor(((iVar1) * 0.5f))) * 0.1f));
            iParam0.f_5 = (int)Math.Floor((((int)Math.Floor(((iVar1) * 0.5f))) * 0.25f));
            iParam0.f_1 = (int)Math.Floor(((iVar1) * 0.5f));
            if (!VehicleCheckers.func_7072(vehicleModel))
            {
                iParam0.f_2 = (int)Math.Floor((((int)Math.Floor(((iVar2) * 0.5f))) * 0.25f));
                iParam0.f_4 = (int)Math.Floor(((iParam0.f_2) * 0.1f));
                if (iParam0.f_4 > Tunables.Global_262145.Value<int>("f_16946") /* Tunable: VEINS_LOWER */ && iParam0.f_4 <= Tunables.Global_262145.Value<int>("f_16947") /* Tunable: VEINS_UPPER */)
                {
                    iParam0.f_4 = Tunables.Global_262145.Value<int>("f_16946") /* Tunable: VEINS_LOWER */;
                }
            }
            else
            {
                iParam0.f_2 = (int)Math.Floor(((iVar2) * 0.06f));
                iParam0.f_4 = (int)Math.Floor(((iParam0.f_2) * 0.1f));
                if (iParam0.f_4 > Tunables.Global_262145.Value<int>("f_24174") /* Tunable: WEAPONISEDVEHICLEINSURANCECAP */)
                {
                    iParam0.f_4 = Tunables.Global_262145.Value<int>("f_24174") /* Tunable: WEAPONISEDVEHICLEINSURANCECAP */;
                }
            }
            if (bVar0)
            {
                iParam0.f_3 = (int)Math.Floor(((iParam0.f_1) * 0.2f));
            }
            return true;
        }

    }
}
