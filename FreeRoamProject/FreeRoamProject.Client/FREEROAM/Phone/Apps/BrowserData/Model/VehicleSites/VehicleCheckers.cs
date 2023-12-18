namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model
{
    internal static class VehicleCheckers
    {
        private static int Global_75777 = 1338692320; // GetHashKey("apa_mp_apa_yacht");
        private static int Global_75778 = -994826917;
        private static int Global_75779 = 886151985;
        private static int Global_75780 = -1242692076;
        private static int Global_75781 = -451225720;

        internal static int func_7102(int iParam0)//Position - 0x247BB2
        {
            switch (iParam0)
            {
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 17:
                case 22:
                case 21:
                case 113:
                case 162:
                case 163:
                case 177:
                case 188:
                case 199:
                case 200:
                case 215:
                case 257:
                case 253:
                    return 1;
                case 20:
                case 19:
                case 15:
                case 16:
                case 164:
                case 185:
                case 187:
                case 217:
                case 243:
                case 244:
                case 254:
                    return 3;
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 102:
                case 173:
                case 201:
                case 224:
                case 258:
                case 533:
                case 525:
                    return 2;
            }
            return 0;
        }
        internal static bool func_6783(int iParam0)//Position - 0x21BE61
        {
            return iParam0 == 94 || iParam0 == 68 || iParam0 == 101 || iParam0 == 164 || iParam0 == 200 || iParam0 == 219 || iParam0 == 231 || iParam0 == 232 || iParam0 == 275 || iParam0 == 270 || iParam0 == 274 || iParam0 == 278 || iParam0 == 267 || iParam0 == 280 || iParam0 == 268 || iParam0 == 276 || iParam0 == 281 || iParam0 == 277 || iParam0 == 271 || iParam0 == 272 || iParam0 == 269 || iParam0 == 279 || iParam0 == 413 || iParam0 == 414;
        }
        internal static int func_7205(int iParam0, int iParam1)//Position - 0x253E78
        {
            switch (iParam0)
            {
                case 0:
                    return GetHashKey("ztype");
                case 1:
                    return GetHashKey("stinger");
                case 2:
                    return GetHashKey("jb700");
                case 3:
                    return GetHashKey("cheetah");
                case 4:
                    return GetHashKey("entityxf");
                case 5:
                    return GetHashKey("adder");
                case 6:
                    return GetHashKey("monroe");
                case 7:
                    return GetHashKey("cogcabrio");
                case 10:
                    return GetHashKey("shamal");
                case 11:
                    return GetHashKey("stunt");
                case 12:
                    return GetHashKey("cuban800");
                case 13:
                    return GetHashKey("duster");
                case 14:
                    return GetHashKey("luxor");
                case 15:
                    return GetHashKey("frogger");
                case 16:
                    return GetHashKey("maverick");
                case 17:
                    return GetHashKey("rhino");
                case 18:
                    return GetHashKey("titan");
                case 19:
                    return GetHashKey("cargobob");
                case 20:
                    return GetHashKey("buzzard");
                case 21:
                    return GetHashKey("crusader");
                case 22:
                    return GetHashKey("barracks");
                case 24:
                    return GetHashKey("marquis");
                case 25:
                    return GetHashKey("jetmax");
                case 27:
                    return GetHashKey("squalo");
                case 29:
                    return GetHashKey("tropic");
                case 30:
                    return GetHashKey("seashark");
                case 31:
                    return GetHashKey("submersible");
                case 32:
                    return GetHashKey("suntrap");
                case 258:
                    return GetHashKey("tug");
                case 33:
                    return GetHashKey("bmx");
                case 34:
                    return GetHashKey("scorcher");
                case 35:
                    return GetHashKey("tribike");
                case 36:
                    return GetHashKey("tribike2");
                case 37:
                    return GetHashKey("tribike3");
                case 38:
                    return GetHashKey("cruiser");
                case 39:
                    return GetHashKey("schwarzer");
                case 40:
                    return GetHashKey("zion");
                case 41:
                    return GetHashKey("gauntlet");
                case 42:
                    return GetHashKey("vigero");
                case 43:
                    return GetHashKey("issi2");
                case 44:
                    return GetHashKey("infernus");
                case 45:
                    return GetHashKey("surano");
                case 46:
                    return GetHashKey("vacca");
                case 47:
                    return GetHashKey("ninef");
                case 48:
                    return GetHashKey("comet2");
                case 49:
                    return GetHashKey("banshee");
                case 50:
                    return GetHashKey("feltzer2");
                case 51:
                    return GetHashKey("bfinjection");
                case 52:
                    return GetHashKey("sandking");
                case 53:
                    return GetHashKey("fugitive");
                case 54:
                    return GetHashKey("dilettante");
                case 55:
                    return GetHashKey("superd");
                case 56:
                    return GetHashKey("exemplar");
                case 57:
                    return GetHashKey("baller2");
                case 58:
                    return GetHashKey("cavalcade");
                case 59:
                    return GetHashKey("rocoto");
                case 60:
                    return GetHashKey("felon");
                case 61:
                    return GetHashKey("oracle2");
                case 62:
                    return GetHashKey("bati");
                case 63:
                    return GetHashKey("akuma");
                case 64:
                    return GetHashKey("ruffian");
                case 65:
                    return GetHashKey("vader");
                case 66:
                    return GetHashKey("blazer");
                case 67:
                    return GetHashKey("pcj");
                case 68:
                    return GetHashKey("sanchez");
                case 69:
                    return GetHashKey("faggio2");
                case 70:
                    return GetHashKey("bullet");
                case 71:
                    return GetHashKey("carbonizzare");
                case 72:
                    return GetHashKey("coquette");
                case 73:
                    return GetHashKey("ninef2");
                case 74:
                    return GetHashKey("rapidgt");
                case 75:
                    return GetHashKey("rapidgt2");
                case 76:
                    return GetHashKey("stingergt");
                case 77:
                    return GetHashKey("voltic");
                case 78:
                    return GetHashKey("annihilator");
                case 79:
                    return GetHashKey("mammatus");
                case 80:
                    return GetHashKey("velum");
                case 81:
                    return GetHashKey("dump");
                case 82:
                    return GetHashKey("airbus");
                case 83:
                    return GetHashKey("bus");
                case 84:
                    return GetHashKey("coach");
                case 85:
                    return GetHashKey("journey");
                case 86:
                    return GetHashKey("mule");
                case 87:
                    return GetHashKey("rentalbus");
                case 88:
                    return GetHashKey("stretch");
                case 89:
                    return GetHashKey("bison");
                case 90:
                    return GetHashKey("double");
                case 91:
                    return GetHashKey("felon2");
                case 92:
                    return GetHashKey("hexer");
                case 93:
                    return GetHashKey("zion2");
                case 94:
                    return GetHashKey("bati2");
                case 95:
                    return GetHashKey("elegy2");
                case 96:
                    return GetHashKey("khamelion");
                case 97:
                    return GetHashKey("hotknife");
                case 98:
                    return GetHashKey("carbonrs");
                case 99:
                    return GetHashKey("bifta");
                case 100:
                    return GetHashKey("kalahari");
                case 101:
                    return GetHashKey("paradise");
                case 102:
                    return GetHashKey("speeder");
                case 103:
                    return GetHashKey("bodhi2");
                case 104:
                    return GetHashKey("dune");
                case 105:
                    return GetHashKey("rebel");
                case 106:
                    return GetHashKey("sadler");
                case 107:
                    return GetHashKey("sanchez2");
                case 108:
                    return GetHashKey("sandking2");
                case 109:
                    return GetHashKey("btype");
                case 111:
                    return GetHashKey("jester");
                case 114:
                    return GetHashKey("massacro");
                case 112:
                    return GetHashKey("turismor");
                case 115:
                    return GetHashKey("zentorno");
                case 116:
                    return GetHashKey("huntley");
                case 110:
                    return GetHashKey("alpha");
                case 113:
                    return GetHashKey("vestra");
                case 117:
                    return GetHashKey("coquette");
                case 118:
                    return GetHashKey("banshee");
                case 119:
                    return GetHashKey("stinger");
                case 120:
                    return GetHashKey("voltic");
                case 121:
                    return GetHashKey("thrust");
                case 128:
                    return GetHashKey("asea");
                case 129:
                    return GetHashKey("asterope");
                case 130:
                    return GetHashKey("bobcatxl");
                case 131:
                    return GetHashKey("cavalcade2");
                case 132:
                    return GetHashKey("granger");
                case 133:
                    return GetHashKey("ingot");
                case 134:
                    return GetHashKey("intruder");
                case 135:
                    return GetHashKey("minivan");
                case 136:
                    return GetHashKey("premier");
                case 137:
                    return GetHashKey("radi");
                case 138:
                    return GetHashKey("rancherxl");
                case 139:
                    return GetHashKey("ratloader");
                case 140:
                    return GetHashKey("stanier");
                case 141:
                    return GetHashKey("stratum");
                case 142:
                    return GetHashKey("washington");
                case 122:
                    return GetHashKey("dominator");
                case 123:
                    return GetHashKey("f620");
                case 124:
                    return GetHashKey("fusilade");
                case 125:
                    return GetHashKey("penumbra");
                case 126:
                    return GetHashKey("sentinel");
                case 127:
                    return GetHashKey("sentinel2");
                case 143:
                    return GetHashKey("blade");
                case 144:
                    return GetHashKey("warrener");
                case 145:
                    return GetHashKey("glendale");
                case 146:
                    return GetHashKey("rhapsody");
                case 147:
                    return GetHashKey("panto");
                case 148:
                    return GetHashKey("dubsta3");
                case 149:
                    return GetHashKey("pigalle");
                case 150:
                    return GetHashKey("picador");
                case 151:
                    return GetHashKey("regina");
                case 152:
                    return GetHashKey("surfer");
                case 153:
                    return GetHashKey("youga");
                case 154:
                    return GetHashKey("blazer3");
                case 155:
                    return GetHashKey("rebel2");
                case 156:
                    return GetHashKey("primo");
                case 157:
                    return GetHashKey("buffalo");
                case 158:
                    return GetHashKey("buffalo2");
                case 159:
                    return GetHashKey("tailgater");
                case 160:
                    return GetHashKey("monster");
                case 161:
                    return GetHashKey("sovereign");
                case 162:
                    return GetHashKey("miljet");
                case 163:
                    return GetHashKey("besra");
                case 164:
                    return GetHashKey("swift");
                case 165:
                    return GetHashKey("coquette2");
                case 166:
                    return GetHashKey("coquette2");
                case 167:
                    return GetHashKey("innovation");
                case 168:
                    return GetHashKey("hakuchou");
                case 169:
                    return GetHashKey("furoregt");
                case 170:
                    return GetHashKey("kalahari");
                case 187:
                    return GetHashKey("valkyrie");
                case 177:
                    return GetHashKey("hydra");
                case 185:
                    return GetHashKey("savage");
                case 174:
                    return GetHashKey("enduro");
                case 171:
                    return GetHashKey("boxville4");
                case 172:
                    return GetHashKey("casco");
                case 173:
                    return GetHashKey("dinghy3");
                case 175:
                    return GetHashKey("gburrito2");
                case 176:
                    return GetHashKey("guardian");
                case 178:
                    return GetHashKey("insurgent");
                case 179:
                    return GetHashKey("insurgent2");
                case 183:
                    return GetHashKey("mule3");
                case 180:
                    return GetHashKey("kuruma");
                case 181:
                    return GetHashKey("kuruma2");
                case 182:
                    return GetHashKey("lectro");
                case 184:
                    return GetHashKey("pbus");
                case 186:
                    return GetHashKey("technical");
                case 188:
                    return GetHashKey("velum2");
                case 189:
                    return GetHashKey("gresley");
                case 190:
                    return GetHashKey("jackal");
                case 191:
                    return GetHashKey("landstalker");
                case 192:
                    return GetHashKey("mesa3");
                case 193:
                    return GetHashKey("nemesis");
                case 194:
                    return GetHashKey("oracle");
                case 195:
                    return GetHashKey("rumpo");
                case 196:
                    return GetHashKey("schafter2");
                case 197:
                    return GetHashKey("seminole");
                case 198:
                    return GetHashKey("surge");
                case 199:
                    return GetHashKey("dodo");
                case 200:
                    return GetHashKey("marshall");
                case 201:
                    return GetHashKey("submersible2");
                case 202:
                    return GetHashKey("blista2");
                case 203:
                    return GetHashKey("stalion");
                case 204:
                    return GetHashKey("dukes");
                case 205:
                    return GetHashKey("dukes2");
                case 206:
                    return GetHashKey("stalion2");
                case 207:
                    return GetHashKey("dominator2");
                case 208:
                    return GetHashKey("gauntlet2");
                case 209:
                    return GetHashKey("buffalo3");
                case 210:
                    return GetHashKey("slamvan");
                case 211:
                    return GetHashKey("ratloader2");
                case 212:
                    return GetHashKey("jester2");
                case 213:
                    return GetHashKey("massacro2");
                case 214:
                    return GetHashKey("feltzer3");
                case 215:
                    return GetHashKey("luxor2");
                case 216:
                    return GetHashKey("osiris");
                case 217:
                    return GetHashKey("swift2");
                case 218:
                    return GetHashKey("virgo");
                case 219:
                    return GetHashKey("windsor");
                case 220:
                    return GetHashKey("brawler");
                case 221:
                    return GetHashKey("chino");
                case 222:
                    return GetHashKey("coquette3");
                case 223:
                    return GetHashKey("t20");
                case 224:
                    return GetHashKey("toro");
                case 225:
                    return GetHashKey("vindicator");
                case 229:
                    return GetHashKey("primo");
                case 228:
                    return GetHashKey("moonbeam");
                case 227:
                    return GetHashKey("faction");
                case 226:
                    return GetHashKey("buccaneer");
                case 230:
                    return GetHashKey("voodoo2");
                case 263:
                    if (iParam1 == 0)
                        return GetHashKey("xls");
                    else if (iParam1 == 1)
                        return GetHashKey("xls2");
                    else
                        return GetHashKey("xls");
                    break;
                case 264:
                    return GetHashKey("seven70");
                case 259:
                    return GetHashKey("windsor2");
                case 260:
                    return GetHashKey("prototipo");
                case 261:
                    return GetHashKey("fmj");
                case 262:
                    return GetHashKey("bestiagts");
                case 265:
                    return GetHashKey("pfister811");
                case 266:
                    return GetHashKey("reaper");
                case 231:
                    return GetHashKey("btype2");
                case 232:
                    return GetHashKey("lurcher");
                case 233:
                    if (iParam1 == 0)
                        return GetHashKey("baller3");
                    else if (iParam1 == 1)
                        return GetHashKey("baller5");
                    else
                        return GetHashKey("baller3");
                case 234:
                    if (iParam1 == 0)
                        return GetHashKey("baller4");
                    else if (iParam1 == 1)
                        return GetHashKey("baller6");
                    else
                        return GetHashKey("baller4");
                case 235:
                    if (iParam1 == 0)
                        return GetHashKey("cog55");
                    else if (iParam1 == 1)
                        return GetHashKey("cog552");
                    else
                        return GetHashKey("cog55");
                case 236:
                    if (iParam1 == 0)
                        return GetHashKey("cognoscenti");
                    else if (iParam1 == 1)
                        return GetHashKey("cognoscenti2");
                    else
                        return GetHashKey("cognoscenti");
                case 237:
                    return GetHashKey("limo2");
                case 238:
                    return GetHashKey("mamba");
                case 239:
                    return GetHashKey("nightshade");
                case 240:
                    if (iParam1 == 0)
                        return GetHashKey("schafter3");
                    else if (iParam1 == 1)
                        return GetHashKey("schafter5");
                    else
                        return GetHashKey("schafter3");
                case 241:
                    if (iParam1 == 0)
                        return GetHashKey("schafter4");
                    else if (iParam1 == 1)
                        return GetHashKey("schafter6");
                    else
                        return GetHashKey("schafter4");
                case 242:
                    return GetHashKey("verlierer2");
                case 243:
                    return GetHashKey("supervolito");
                case 244:
                    return GetHashKey("supervolito2");
                case 245:
                    return Global_75777;
                case 251:
                    return GetHashKey("virgo3");
                case 250:
                    return GetHashKey("tornado");
                case 249:
                    return GetHashKey("sabregt");
                case 252:
                    return GetHashKey("faction");
                case 246:
                    return GetHashKey("tampa");
                case 247:
                    return GetHashKey("sultan");
                case 248:
                    return GetHashKey("btype3");
                case 253:
                    return GetHashKey("volatus");
                case 254:
                    return GetHashKey("cargobob2");
                case 255:
                    return GetHashKey("rumpo3");
                case 256:
                    return GetHashKey("brickade");
                case 257:
                    return GetHashKey("nimbus");
                case 267:
                    return GetHashKey("le7b");
                case 268:
                    return GetHashKey("omnis");
                case 269:
                    return GetHashKey("tropos");
                case 270:
                    return GetHashKey("brioso");
                case 271:
                    return GetHashKey("trophyTruck");
                case 272:
                    return GetHashKey("trophyTruck2");
                case 273:
                    return GetHashKey("contender");
                case 274:
                    return GetHashKey("cliffhanger");
                case 275:
                    return GetHashKey("bf400");
                case 279:
                    return GetHashKey("tyrus");
                case 280:
                    return GetHashKey("lynx");
                case 281:
                    return GetHashKey("sheava");
                case 276:
                    return GetHashKey("rallyTruck");
                case 277:
                    return GetHashKey("tampa2");
                case 278:
                    return GetHashKey("gargoyle");
                case 282:
                    return GetHashKey("bagger");
                case 283:
                    return GetHashKey("esskey");
                case 284:
                    return GetHashKey("nightblade");
                case 285:
                    return GetHashKey("defiler");
                case 286:
                    return GetHashKey("avarus");
                case 287:
                    return GetHashKey("zombiea");
                case 288:
                    return GetHashKey("zombieb");
                case 289:
                    return GetHashKey("chimera");
                case 290:
                    return GetHashKey("daemon2");
                case 291:
                    return GetHashKey("ratbike");
                case 292:
                    return GetHashKey("shotaro");
                case 293:
                    return GetHashKey("raptor");
                case 294:
                    return GetHashKey("hakuchou2");
                case 296:
                    return GetHashKey("blazer4");
                case 297:
                    return GetHashKey("sanctus");
                case 295:
                    return GetHashKey("vortex");
                case 298:
                    return GetHashKey("manchez");
                case 299:
                    return GetHashKey("tornado6");
                case 300:
                    return GetHashKey("youga2");
                case 301:
                    return GetHashKey("wolfsbane");
                case 302:
                    return GetHashKey("faggio3");
                case 303:
                    return GetHashKey("faggio");
                case 304:
                    return GetHashKey("dune5");
                case 305:
                    return GetHashKey("phantom2");
                case 306:
                    return GetHashKey("technical2");
                case 307:
                    return GetHashKey("blazer5");
                case 308:
                    return GetHashKey("boxville5");
                case 309:
                    return GetHashKey("wastelander");
                case 310:
                    return GetHashKey("ruiner2");
                case 311:
                    return GetHashKey("voltic2");
                case 312:
                    return GetHashKey("penetrator");
                case 313:
                    return GetHashKey("tempesta");
                case 314:
                    return GetHashKey("italigtb");
                case 315:
                    return GetHashKey("nero");
                case 316:
                    return GetHashKey("diablous");
                case 317:
                    return GetHashKey("fcr");
                case 318:
                    return GetHashKey("specter");
                case 319:
                    return GetHashKey("gp1");
                case 320:
                    return GetHashKey("infernus2");
                case 321:
                    return GetHashKey("ruston");
                case 322:
                    return GetHashKey("turismo2");
                case 323:
                    return Global_75778;
                case 324:
                    return Global_75779;
                case 325:
                    return GetHashKey("cheetah2");
                case 326:
                    return GetHashKey("torero");
                case 327:
                    return GetHashKey("vagner");
                case 328:
                    return GetHashKey("xa21");
                case 329:
                    return GetHashKey("apc");
                case 330:
                    return GetHashKey("dune3");
                case 331:
                    return GetHashKey("halfTrack");
                case 332:
                    return GetHashKey("oppressor");
                case 333:
                    return GetHashKey("tampa3");
                case 334:
                    return GetHashKey("trailerSmall2");
                case 335:
                    return GetHashKey("ardent");
                case 336:
                    return GetHashKey("nightshark");
                case 337:
                    return GetHashKey("lazer");
                case 338:
                    return GetHashKey("microlight");
                case 339:
                    return GetHashKey("mogul");
                case 340:
                    return GetHashKey("rogue");
                case 341:
                    return GetHashKey("starling");
                case 342:
                    return GetHashKey("seabreeze");
                case 343:
                    return GetHashKey("tula");
                case 344:
                    return GetHashKey("pyro");
                case 345:
                    return GetHashKey("molotok");
                case 346:
                    return GetHashKey("nokota");
                case 347:
                    return GetHashKey("bombushka");
                case 348:
                    return GetHashKey("hunter");
                case 349:
                    return GetHashKey("havok");
                case 350:
                    return GetHashKey("howard");
                case 351:
                    return GetHashKey("alphaz1");
                case 352:
                    return GetHashKey("cyclone");
                case 353:
                    return GetHashKey("visione");
                case 354:
                    return GetHashKey("retinue");
                case 355:
                    return GetHashKey("rapidgt3");
                case 356:
                    return GetHashKey("vigilante");
                case 357:
                    return Global_75780;
                case 358:
                    return GetHashKey("deluxo");
                case 359:
                    return GetHashKey("stromberg");
                case 360:
                    return GetHashKey("riot2");
                case 361:
                    return GetHashKey("chernobog");
                case 362:
                    return GetHashKey("khanjali");
                case 363:
                    return GetHashKey("akula");
                case 364:
                    return GetHashKey("thruster");
                case 365:
                    return GetHashKey("barrage");
                case 366:
                    return GetHashKey("volatol");
                case 367:
                    return GetHashKey("comet4");
                case 368:
                    return GetHashKey("neon");
                case 369:
                    return GetHashKey("streiter");
                case 370:
                    return GetHashKey("sentinel3");
                case 371:
                    return GetHashKey("yosemite");
                case 372:
                    return GetHashKey("sc1");
                case 373:
                    return GetHashKey("autarch");
                case 374:
                    return GetHashKey("gt500");
                case 375:
                    return GetHashKey("hustler");
                case 376:
                    return GetHashKey("revolter");
                case 377:
                    return GetHashKey("pariah");
                case 378:
                    return GetHashKey("raiden");
                case 379:
                    return GetHashKey("savestra");
                case 380:
                    return GetHashKey("riata");
                case 381:
                    return GetHashKey("hermes");
                case 382:
                    return GetHashKey("comet5");
                case 383:
                    return GetHashKey("z190");
                case 384:
                    return GetHashKey("viseris");
                case 385:
                    return GetHashKey("kamacho");
                case 386:
                    return GetHashKey("gb200");
                case 387:
                    return GetHashKey("fagaloa");
                case 388:
                    return GetHashKey("ellie");
                case 389:
                    return GetHashKey("issi3");
                case 390:
                    return GetHashKey("michelli");
                case 391:
                    return GetHashKey("flashgt");
                case 392:
                    return GetHashKey("hotring");
                case 393:
                    return GetHashKey("tezeract");
                case 394:
                    return GetHashKey("tyrant");
                case 395:
                    return GetHashKey("dominator3");
                case 396:
                    return GetHashKey("taipan");
                case 397:
                    return GetHashKey("entity2");
                case 398:
                    return GetHashKey("jester3");
                case 399:
                    return GetHashKey("cheburek");
                case 400:
                    return GetHashKey("caracara");
                case 401:
                    return GetHashKey("seasparrow");
                case 402:
                    return Global_75781;
                case 403:
                    return GetHashKey("mule4");
                case 404:
                    return GetHashKey("pounder2");
                case 405:
                    return GetHashKey("swinger");
                case 406:
                    return GetHashKey("menacer");
                case 407:
                    return GetHashKey("scramjet");
                case 408:
                    return GetHashKey("strikeforce");
                case 409:
                    return GetHashKey("oppressor2");
                case 410:
                    return GetHashKey("patriot2");
                case 411:
                    return GetHashKey("stafford");
                case 412:
                    return GetHashKey("freecrawler");
                case 415:
                    return GetHashKey("futo");
                case 416:
                    return GetHashKey("ruiner");
                case 417:
                    return GetHashKey("romero");
                case 418:
                    return GetHashKey("prairie");
                case 419:
                    return GetHashKey("baller");
                case 420:
                    return GetHashKey("serrano");
                case 421:
                    return GetHashKey("bjxl");
                case 422:
                    return GetHashKey("habanero");
                case 423:
                    return GetHashKey("fq2");
                case 424:
                    return GetHashKey("patriot");
                case 413:
                    return GetHashKey("blimp3");
                case 414:
                    return GetHashKey("pbus2");
                case 425:
                    return GetHashKey("cerberus");
                case 426:
                    return GetHashKey("cerberus2");
                case 427:
                    return GetHashKey("cerberus3");
                case 428:
                    return GetHashKey("brutus");
                case 429:
                    return GetHashKey("brutus2");
                case 430:
                    return GetHashKey("brutus3");
                case 431:
                    return GetHashKey("scarab");
                case 432:
                    return GetHashKey("scarab2");
                case 433:
                    return GetHashKey("scarab3");
                case 434:
                    return GetHashKey("imperator");
                case 435:
                    return GetHashKey("imperator2");
                case 436:
                    return GetHashKey("imperator3");
                case 437:
                    return GetHashKey("zr380");
                case 438:
                    return GetHashKey("zr3802");
                case 439:
                    return GetHashKey("zr3803");
                case 440:
                    return GetHashKey("impaler");
                case 450:
                    return GetHashKey("taxi");
                case 451:
                    return GetHashKey("bulldozer");
                case 452:
                    return GetHashKey("speedo2");
                case 453:
                    return GetHashKey("trash2");
                case 454:
                    return GetHashKey("barracks2");
                case 455:
                    return GetHashKey("mixer");
                case 456:
                    return GetHashKey("dune2");
                case 457:
                    return GetHashKey("tractor");
                case 458:
                    return GetHashKey("blista3");
                case 441:
                    return GetHashKey("vamos");
                case 442:
                    return GetHashKey("tulip");
                case 443:
                    return GetHashKey("deveste");
                case 444:
                    return GetHashKey("schlagen");
                case 445:
                    return GetHashKey("toros");
                case 446:
                    return GetHashKey("deviant");
                case 447:
                    return GetHashKey("clique");
                case 448:
                    return GetHashKey("italigto");
                case 449:
                    return GetHashKey("rcbandito");
                case 459:
                    return GetHashKey("thrax");
                case 460:
                    return GetHashKey("drafter");
                case 461:
                    return GetHashKey("locust");
                case 462:
                    return GetHashKey("novak");
                case 463:
                    return GetHashKey("zorrusso");
                case 464:
                    return GetHashKey("gauntlet3");
                case 465:
                    return GetHashKey("issi7");
                case 466:
                    return GetHashKey("zion3");
                case 467:
                    return GetHashKey("nebula");
                case 468:
                    return GetHashKey("hellion");
                case 469:
                    return GetHashKey("dynasty");
                case 470:
                    return GetHashKey("rrocket");
                case 471:
                    return GetHashKey("peyote2");
                case 472:
                    return GetHashKey("gauntlet4");
                case 473:
                    return GetHashKey("caracara2");
                case 474:
                    return GetHashKey("jugular");
                case 475:
                    return GetHashKey("s80");
                case 476:
                    return GetHashKey("krieger");
                case 477:
                    return GetHashKey("emerus");
                case 478:
                    return GetHashKey("neo");
                case 479:
                    return GetHashKey("paragon");
                case 480:
                    return GetHashKey("firetruk");
                case 481:
                    return GetHashKey("burrito2");
                case 482:
                    return GetHashKey("boxville");
                case 483:
                    return GetHashKey("stockade");
                case 484:
                    return GetHashKey("lguard");
                case 485:
                    return GetHashKey("blazer2");
                case 486:
                    return GetHashKey("zhaba");
                case 487:
                    return GetHashKey("minitank");
                case 488:
                    return GetHashKey("jb7002");
                case 489:
                    return GetHashKey("stryder");
                case 490:
                    return GetHashKey("vstr");
                case 491:
                    return GetHashKey("formula");
                case 492:
                    return GetHashKey("imorgon");
                case 493:
                    return GetHashKey("formula2");
                case 494:
                    return GetHashKey("furia");
                case 495:
                    return GetHashKey("rebla");
                case 496:
                    return GetHashKey("vagrant");
                case 497:
                    return GetHashKey("retinue2");
                case 498:
                    return GetHashKey("yosemite2");
                case 499:
                    return GetHashKey("komoda");
                case 500:
                    return GetHashKey("sultan2");
                case 501:
                    return GetHashKey("sugoi");
                case 502:
                    return GetHashKey("everon");
                case 503:
                    return GetHashKey("asbo");
                case 504:
                    return GetHashKey("kanjo");
                case 505:
                    return GetHashKey("outlaw");
                case 506:
                    return GetHashKey("club");
                case 507:
                    return GetHashKey("dukes3");
                case 508:
                    return GetHashKey("yosemite3");
                case 509:
                    return GetHashKey("penumbra2");
                case 510:
                    return GetHashKey("landstalker2");
                case 511:
                    return GetHashKey("seminole2");
                case 512:
                    return GetHashKey("tigon");
                case 513:
                    return GetHashKey("openwheel1");
                case 514:
                    return GetHashKey("openwheel2");
                case 515:
                    return GetHashKey("coquette4");
                case 516:
                    return GetHashKey("manana");
                case 517:
                    return GetHashKey("peyote");
                case 518:
                    return GetHashKey("kosatka");
                case 519:
                    return GetHashKey("italirsx");
                case 520:
                    return GetHashKey("slamTruck");
                case 521:
                    return GetHashKey("brioso2");
                case 522:
                    return GetHashKey("weevil");
                case 523:
                    return GetHashKey("alkonost");
                case 524:
                    return GetHashKey("annihilator2");
                case 525:
                    return GetHashKey("dinghy5");
                case 526:
                    return GetHashKey("manchez2");
                case 527:
                    return GetHashKey("patrolboat");
                case 528:
                    return GetHashKey("squaddie");
                case 529:
                    return GetHashKey("toreador");
                case 530:
                    return GetHashKey("verus");
                case 531:
                    return GetHashKey("vetir");
                case 532:
                    return GetHashKey("winky");
                case 533:
                    return GetHashKey("longfin");
                case 534:
                    return GetHashKey("veto");
                case 535:
                    return GetHashKey("veto2");
                case 543:
                    return GetHashKey("zr350");
                case 537:
                    return GetHashKey("comet6");
                case 540:
                    return GetHashKey("jester4");
                case 542:
                    return GetHashKey("vectre");
                case 538:
                    return GetHashKey("cypher");
                case 548:
                    return GetHashKey("tailgater2");
                case 550:
                    return GetHashKey("euros");
                case 551:
                    return GetHashKey("growler");
                case 536:
                    return GetHashKey("calico");
                case 541:
                    return GetHashKey("remus");
                case 539:
                    return GetHashKey("dominator7");
                case 546:
                    return GetHashKey("futo2");
                case 545:
                    return GetHashKey("rt3000");
                case 544:
                    return GetHashKey("warrener2");
                case 547:
                    return GetHashKey("sultan3");
                case 549:
                    return GetHashKey("dominator8");
                case 552:
                    return GetHashKey("previon");
                case 554:
                    return GetHashKey("comet7");
                case 555:
                    return GetHashKey("shinobi");
                case 556:
                    return GetHashKey("reever");
                case 557:
                    return GetHashKey("baller7");
                case 558:
                    return GetHashKey("cinquemila");
                case 559:
                    return GetHashKey("jubilee");
                case 560:
                    return GetHashKey("astron");
                case 561:
                    return GetHashKey("deity");
                case 562:
                    return GetHashKey("zeno");
                case 563:
                    return GetHashKey("champion");
                case 564:
                    return GetHashKey("ignus");
                case 565:
                    return GetHashKey("buffalo4");
                case 566:
                    return GetHashKey("granger2");
                case 567:
                    return GetHashKey("iwagen");
                case 568:
                    return GetHashKey("patriot3");
                case 553:
                    return GetHashKey("supervolito2");
                case 569:
                    return GetHashKey("tenf");
                case 570:
                    return GetHashKey("sm722");
                case 571:
                    return GetHashKey("torero2");
                case 572:
                    return GetHashKey("corsita");
                case 573:
                    return GetHashKey("lm87");
                case 574:
                    return GetHashKey("omnisegt");
                case 575:
                    return GetHashKey("rhinehart");
                case 576:
                    return GetHashKey("postlude");
                case 577:
                    return GetHashKey("kanjosj");
                case 578:
                    return GetHashKey("vigero2");
                case 579:
                    return GetHashKey("ruiner4");
                case 580:
                    return GetHashKey("draugur");
                case 581:
                    return GetHashKey("greenwood");
                case 582:
                    return GetHashKey("conada");
                case 583:
                    return GetHashKey("brickade2");
                case 584:
                    return GetHashKey("manchez3");
                case 585:
                    return GetHashKey("panthere");
                case 586:
                    return GetHashKey("tahoma");
                case 587:
                    return GetHashKey("tulip2");
                case 588:
                    return GetHashKey("everon2");
                case 589:
                    return GetHashKey("journey2");
                case 590:
                    return GetHashKey("surfer3");
                case 591:
                    return GetHashKey("virtue");
                case 592:
                    return GetHashKey("r300");
                case 593:
                    return GetHashKey("issi8");
                case 594:
                    return GetHashKey("entity3");
                case 595:
                    return GetHashKey("powersurge");
                case 596:
                    return GetHashKey("boor");
                case 597:
                    return GetHashKey("broadway");
                case 598:
                    return GetHashKey("eudora");
                case 599:
                    return GetHashKey("mesa");
                case 600:
                    return GetHashKey("l35");
                case 603:
                    return GetHashKey("brigham");
                case 604:
                    return GetHashKey("clique2");
                case 601:
                    return GetHashKey("ratel");
                case 602:
                    return GetHashKey("monstrociti");
                case 605:
                    return GetHashKey("inductor");
                case 606:
                    return GetHashKey("inductor2");
                case 607:
                    return GetHashKey("streamer216");
                case 608:
                    return GetHashKey("conada2");
                case 609:
                    return GetHashKey("raiju");
                case 610:
                    return GetHashKey("gauntlet6");
                case 611:
                    return GetHashKey("stingertt");
                case 612:
                    return GetHashKey("buffalo5");
                case 613:
                    return GetHashKey("coureur");
            }
            return 0;
        }
        internal static bool func_7267(int iParam0, bool bParam1, ref int iParam2)//Position - 0x25F316
        {

            int iVar0 = 0;
            if (bParam1)
            {
                iVar0 = (VehicleHash)iParam0 switch
                {
                    VehicleHash.Kalahari => GetHashKey("KALAHARI_TLESS"),
                    VehicleHash.Coquette => GetHashKey("COQUETTE_TLESS"),
                    VehicleHash.Banshee => GetHashKey("BANSHEE_TLESS"),
                    VehicleHash.Stinger => GetHashKey("STINGER_TLESS"),
                    VehicleHash.Voltic => GetHashKey("VOLTIC_HTOP"),
                    VehicleHash.Coquette2 => GetHashKey("COQUETTE2_TLESS"),
                    _ => iParam0,
                };
            }
            else
            {
                iVar0 = iParam0;
            }
            if (iVar0 == Tunables.Global_262145.Value<int>("f_13581") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE0 */)
            {
                iParam2 = 0;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13582") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE1 */)
            {
                iParam2 = 1;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13583") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE2 */)
            {
                iParam2 = 2;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13584") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE3 */)
            {
                iParam2 = 3;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13585") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE4 */)
            {
                iParam2 = 4;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13586") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE5 */)
            {
                iParam2 = 5;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13587") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE6 */)
            {
                iParam2 = 6;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13588") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE7 */)
            {
                iParam2 = 7;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13589") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE8 */)
            {
                iParam2 = 8;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13590") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE9 */)
            {
                iParam2 = 9;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13591") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE10 */)
            {
                iParam2 = 10;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13592") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE11 */)
            {
                iParam2 = 11;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13593") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE12 */)
            {
                iParam2 = 12;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13594") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE13 */)
            {
                iParam2 = 13;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13595") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE14 */)
            {
                iParam2 = 14;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13596") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE15 */)
            {
                iParam2 = 15;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13597") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE16 */)
            {
                iParam2 = 16;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13598") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE17 */)
            {
                iParam2 = 17;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13599") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE18 */)
            {
                iParam2 = 18;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13600") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE19 */)
            {
                iParam2 = 19;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35082") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE20 */)
            {
                iParam2 = 20;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35083") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE21 */)
            {
                iParam2 = 21;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35084") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE22 */)
            {
                iParam2 = 22;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35085") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE23 */)
            {
                iParam2 = 23;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35086") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE24 */)
            {
                iParam2 = 24;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35087") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE25 */)
            {
                iParam2 = 25;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35088") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE26 */)
            {
                iParam2 = 26;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35089") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE27 */)
            {
                iParam2 = 27;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35090") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE28 */)
            {
                iParam2 = 28;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35091") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE29 */)
            {
                iParam2 = 29;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35092") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE30 */)
            {
                iParam2 = 30;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35093") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE31 */)
            {
                iParam2 = 31;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35094") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE32 */)
            {
                iParam2 = 32;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35095") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE33 */)
            {
                iParam2 = 33;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35096") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE34 */)
            {
                iParam2 = 34;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35097") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE35 */)
            {
                iParam2 = 35;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35098") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE36 */)
            {
                iParam2 = 36;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35099") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE37 */)
            {
                iParam2 = 37;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35100") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE38 */)
            {
                iParam2 = 38;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35101") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE39 */)
            {
                iParam2 = 39;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35102") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE40 */)
            {
                iParam2 = 40;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35103") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE41 */)
            {
                iParam2 = 41;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35104") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE42 */)
            {
                iParam2 = 42;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35105") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE43 */)
            {
                iParam2 = 43;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35106") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE44 */)
            {
                iParam2 = 44;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35107") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE45 */)
            {
                iParam2 = 45;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35108") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE46 */)
            {
                iParam2 = 46;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35109") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE47 */)
            {
                iParam2 = 47;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35110") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE48 */)
            {
                iParam2 = 48;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35111") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE49 */)
            {
                iParam2 = 49;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35112") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE50 */)
            {
                iParam2 = 50;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35113") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE51 */)
            {
                iParam2 = 51;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35114") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE52 */)
            {
                iParam2 = 52;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35115") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE53 */)
            {
                iParam2 = 53;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35116") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE54 */)
            {
                iParam2 = 54;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35117") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE55 */)
            {
                iParam2 = 55;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35118") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE56 */)
            {
                iParam2 = 56;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35119") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE57 */)
            {
                iParam2 = 57;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35120") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE58 */)
            {
                iParam2 = 58;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35121") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE59 */)
            {
                iParam2 = 59;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35122") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE60 */)
            {
                iParam2 = 60;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35123") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE61 */)
            {
                iParam2 = 61;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35124") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE62 */)
            {
                iParam2 = 62;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35125") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE63 */)
            {
                iParam2 = 63;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35126") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE64 */)
            {
                iParam2 = 64;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35127") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE65 */)
            {
                iParam2 = 65;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35128") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE66 */)
            {
                iParam2 = 66;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35129") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE67 */)
            {
                iParam2 = 67;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35130") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE68 */)
            {
                iParam2 = 68;
                return true;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_35131") /* Tunable: OPTOUT_VEHICLEWEBSITE_SALE69 */)
            {
                iParam2 = 69;
                return true;
            }
            else
            {
                switch ((VehicleHash)iParam0)
                {
                    case VehicleHash.Elegy2:
                        iParam2 = 70;
                        return true;

                    case VehicleHash.Banshee:
                        iParam2 = 71;
                        return true;

                    case VehicleHash.Huntley:
                        iParam2 = 72;
                        return true;

                    case VehicleHash.Turismor:
                        iParam2 = 73;
                        return true;

                    case VehicleHash.Coquette2:
                        iParam2 = 74;
                        return true;

                    case VehicleHash.Windsor:
                        iParam2 = 75;
                        return true;

                    case VehicleHash.Vortex:
                        iParam2 = 76;
                        return true;

                    case VehicleHash.ZombieB:
                        iParam2 = 77;
                        return true;

                    case VehicleHash.Omnis:
                        iParam2 = 78;
                        return true;

                    case VehicleHash.Dune3:
                        iParam2 = 79;
                        return true;

                    case VehicleHash.Frogger:
                        iParam2 = 80;
                        return true;

                    case VehicleHash.CarbonRS:
                        iParam2 = 81;
                        return true;

                    case VehicleHash.Hotknife:
                        iParam2 = 82;
                        return true;

                    case VehicleHash.Submersible2:
                        iParam2 = 83;
                        return true;

                    case VehicleHash.Marshall:
                        iParam2 = 84;
                        return true;

                    case VehicleHash.Dukes2:
                        iParam2 = 85;
                        return true;

                    case VehicleHash.Khamelion:
                        iParam2 = 86;
                        return true;

                    case VehicleHash.Dukes:
                        iParam2 = 87;
                        return true;

                    case VehicleHash.Stalion:
                        iParam2 = 88;
                        return true;

                    case VehicleHash.Blista2:
                        iParam2 = 89;
                        return true;

                    case VehicleHash.Dodo:
                        iParam2 = 90;
                        return true;

                    case VehicleHash.Blista3:
                        iParam2 = 91;
                        return true;

                    case VehicleHash.Gauntlet2:
                        iParam2 = 92;
                        return true;

                    case VehicleHash.Stalion2:
                        iParam2 = 93;
                        return true;

                    case VehicleHash.Dominator2:
                        iParam2 = 94;
                        return true;

                    case VehicleHash.Buffalo3:
                        iParam2 = 95;
                        return true;
                }
            }
            iParam2 = -1;
            return false;
        }
        internal static bool func_3149(int iParam0)//Position - 0x10FBA0
        {
            return (VehicleHash)iParam0 switch
            {
                (VehicleHash)3147997943
                or (VehicleHash)668439077
                or (VehicleHash)3493417227
                or (VehicleHash)1721676810
                or (VehicleHash)3606777648
                or (VehicleHash)1009171724
                or (VehicleHash)444994115
                or (VehicleHash)628003514
                or (VehicleHash)4267640610
                or (VehicleHash)540101442
                or (VehicleHash)2233918197
                or (VehicleHash)2139203625
                or (VehicleHash)1637620610
                or (VehicleHash)3539435063
                or (VehicleHash)2920466844
                or (VehicleHash)2482017624
                or (VehicleHash)2370166601
                or (VehicleHash)2403970600
                or (VehicleHash)2600885406
                or (VehicleHash)373261600
                or (VehicleHash)1537277726
                or (VehicleHash)840387324
                or (VehicleHash)1542143200
                or (VehicleHash)679453769
                or (VehicleHash)2919906639
                or (VehicleHash)3188846534
                or (VehicleHash)2550461639
                or (VehicleHash)2038858402
                or (VehicleHash)2252616474
                or (VehicleHash)1742022738
                or (VehicleHash)1239571361
                or (VehicleHash)3579220348
                or (VehicleHash)3715219435
                or (VehicleHash)1909700336
                or (VehicleHash)3001042683
                or (VehicleHash)2816263004 => true,
                _ => false,
            };
        }
        internal static int func_7121(int iParam0)//Position - 0x24B5A5
        {
            return iParam0 switch
            {
                5 => Tunables.Global_262145.Value<int>("f_4020") /* Tunable: ADDER_EXPENDITURE_MODIFIER */,
                82 => Tunables.Global_262145.Value<int>("f_4021") /* Tunable: AIRBUS_EXPENDITURE_MODIFIER */,
                63 => Tunables.Global_262145.Value<int>("f_4022") /* Tunable: AKUMA_EXPENDITURE_MODIFIER */,
                78 => Tunables.Global_262145.Value<int>("f_4023") /* Tunable: ANNIHILATOR_EXPENDITURE_MODIFIER */,
                57 => Tunables.Global_262145.Value<int>("f_4024") /* Tunable: BALLER2_EXPENDITURE_MODIFIER */,
                22 => Tunables.Global_262145.Value<int>("f_4025") /* Tunable: BARRACKS_EXPENDITURE_MODIFIER */,
                62 => Tunables.Global_262145.Value<int>("f_4026") /* Tunable: BATI_EXPENDITURE_MODIFIER */,
                94 => Tunables.Global_262145.Value<int>("f_4027") /* Tunable: BATI2_EXPENDITURE_MODIFIER */,
                51 => Tunables.Global_262145.Value<int>("f_4028") /* Tunable: BFINJECTION_EXPENDITURE_MODIFIER */,
                89 => Tunables.Global_262145.Value<int>("f_4029") /* Tunable: BISON_EXPENDITURE_MODIFIER */,
                66 => Tunables.Global_262145.Value<int>("f_4030") /* Tunable: BLAZER_EXPENDITURE_MODIFIER */,
                33 => Tunables.Global_262145.Value<int>("f_4031") /* Tunable: BMX_EXPENDITURE_MODIFIER */,
                70 => Tunables.Global_262145.Value<int>("f_4032") /* Tunable: BULLET_EXPENDITURE_MODIFIER */,
                83 => Tunables.Global_262145.Value<int>("f_4033") /* Tunable: BUS_EXPENDITURE_MODIFIER */,
                20 => Tunables.Global_262145.Value<int>("f_4034") /* Tunable: BUZZARD_EXPENDITURE_MODIFIER */,
                71 => Tunables.Global_262145.Value<int>("f_4035") /* Tunable: CARBONIZZARE_EXPENDITURE_MODIFIER */,
                19 => -1,
                58 => Tunables.Global_262145.Value<int>("f_4037") /* Tunable: CAVALCADE_EXPENDITURE_MODIFIER */,
                3 => Tunables.Global_262145.Value<int>("f_4038") /* Tunable: CHEETAH_EXPENDITURE_MODIFIER */,
                84 => Tunables.Global_262145.Value<int>("f_4039") /* Tunable: COACH_EXPENDITURE_MODIFIER */,
                7 => Tunables.Global_262145.Value<int>("f_4040") /* Tunable: COGCABRIO_EXPENDITURE_MODIFIER */,
                48 => Tunables.Global_262145.Value<int>("f_4041") /* Tunable: COMET2_EXPENDITURE_MODIFIER */,
                72 => Tunables.Global_262145.Value<int>("f_4042") /* Tunable: COQUETTE_EXPENDITURE_MODIFIER */,
                38 => Tunables.Global_262145.Value<int>("f_4043") /* Tunable: CRUISER_EXPENDITURE_MODIFIER */,
                21 => Tunables.Global_262145.Value<int>("f_4044") /* Tunable: CRUSADER_EXPENDITURE_MODIFIER */,
                12 => Tunables.Global_262145.Value<int>("f_4045") /* Tunable: CUBAN800_EXPENDITURE_MODIFIER */,
                54 => Tunables.Global_262145.Value<int>("f_4046") /* Tunable: DILETTANTE_EXPENDITURE_MODIFIER */,
                90 => Tunables.Global_262145.Value<int>("f_4047") /* Tunable: DOUBLE_EXPENDITURE_MODIFIER */,
                81 => Tunables.Global_262145.Value<int>("f_4048") /* Tunable: DUMP_EXPENDITURE_MODIFIER */,
                13 => Tunables.Global_262145.Value<int>("f_4049") /* Tunable: DUSTER_EXPENDITURE_MODIFIER */,
                4 => Tunables.Global_262145.Value<int>("f_4051") /* Tunable: ENTITYXF_EXPENDITURE_MODIFIER */,
                56 => Tunables.Global_262145.Value<int>("f_4052") /* Tunable: EXEMPLAR_EXPENDITURE_MODIFIER */,
                69 => Tunables.Global_262145.Value<int>("f_4053") /* Tunable: FAGGIO2_EXPENDITURE_MODIFIER */,
                60 => Tunables.Global_262145.Value<int>("f_4054") /* Tunable: FELON_EXPENDITURE_MODIFIER */,
                91 => Tunables.Global_262145.Value<int>("f_4111") /* Tunable: FELON2_EXPENDITURE_MODIFIER */,
                50 => Tunables.Global_262145.Value<int>("f_4055") /* Tunable: FELTZER2_EXPENDITURE_MODIFIER */,
                15 => Tunables.Global_262145.Value<int>("f_4056") /* Tunable: FROGGER_EXPENDITURE_MODIFIER */,
                53 => Tunables.Global_262145.Value<int>("f_4057") /* Tunable: FUGITIVE_EXPENDITURE_MODIFIER */,
                41 => Tunables.Global_262145.Value<int>("f_4058") /* Tunable: GAUNTLET_EXPENDITURE_MODIFIER */,
                92 => Tunables.Global_262145.Value<int>("f_4059") /* Tunable: HEXER_EXPENDITURE_MODIFIER */,
                44 => Tunables.Global_262145.Value<int>("f_4061") /* Tunable: INFERNUS_EXPENDITURE_MODIFIER */,
                43 => Tunables.Global_262145.Value<int>("f_4062") /* Tunable: ISSI2_EXPENDITURE_MODIFIER */,
                2 => Tunables.Global_262145.Value<int>("f_4063") /* Tunable: JB700_EXPENDITURE_MODIFIER */,
                25 => Tunables.Global_262145.Value<int>("f_4064") /* Tunable: JETMAX_EXPENDITURE_MODIFIER */,
                85 => Tunables.Global_262145.Value<int>("f_4065") /* Tunable: JOURNEY_EXPENDITURE_MODIFIER */,
                14 => Tunables.Global_262145.Value<int>("f_4067") /* Tunable: LUXOR_EXPENDITURE_MODIFIER */,
                79 => Tunables.Global_262145.Value<int>("f_4068") /* Tunable: MAMMATUS_EXPENDITURE_MODIFIER */,
                24 => Tunables.Global_262145.Value<int>("f_4069") /* Tunable: MARQUIS_EXPENDITURE_MODIFIER */,
                16 => Tunables.Global_262145.Value<int>("f_4070") /* Tunable: MAVERICK_EXPENDITURE_MODIFIER */,
                6 => Tunables.Global_262145.Value<int>("f_4071") /* Tunable: MONROE_EXPENDITURE_MODIFIER */,
                86 => Tunables.Global_262145.Value<int>("f_4072") /* Tunable: MULE_EXPENDITURE_MODIFIER */,
                47 => Tunables.Global_262145.Value<int>("f_4073") /* Tunable: NINEF_EXPENDITURE_MODIFIER */,
                73 => Tunables.Global_262145.Value<int>("f_4074") /* Tunable: NINEF2_EXPENDITURE_MODIFIER */,
                61 => Tunables.Global_262145.Value<int>("f_4075") /* Tunable: ORACLE2_EXPENDITURE_MODIFIER */,
                67 => Tunables.Global_262145.Value<int>("f_4076") /* Tunable: PCJ_EXPENDITURE_MODIFIER */,
                74 => Tunables.Global_262145.Value<int>("f_4077") /* Tunable: RAPIDGT_EXPENDITURE_MODIFIER */,
                75 => Tunables.Global_262145.Value<int>("f_4078") /* Tunable: RAPIDGT2_EXPENDITURE_MODIFIER */,
                87 => Tunables.Global_262145.Value<int>("f_4079") /* Tunable: RENTALBUS_EXPENDITURE_MODIFIER */,
                17 => Tunables.Global_262145.Value<int>("f_4080") /* Tunable: RHINO_EXPENDITURE_MODIFIER */,
                59 => Tunables.Global_262145.Value<int>("f_4081") /* Tunable: ROCOTO_EXPENDITURE_MODIFIER */,
                64 => Tunables.Global_262145.Value<int>("f_4082") /* Tunable: RUFFIAN_EXPENDITURE_MODIFIER */,
                68 => Tunables.Global_262145.Value<int>("f_4083") /* Tunable: SANCHEZ_EXPENDITURE_MODIFIER */,
                52 => Tunables.Global_262145.Value<int>("f_4084") /* Tunable: SANDKING_EXPENDITURE_MODIFIER */,
                39 => Tunables.Global_262145.Value<int>("f_4085") /* Tunable: SCHWARZER_EXPENDITURE_MODIFIER */,
                34 => Tunables.Global_262145.Value<int>("f_4086") /* Tunable: SCORCHER_EXPENDITURE_MODIFIER */,
                30 => Tunables.Global_262145.Value<int>("f_4087") /* Tunable: SEASHARK_EXPENDITURE_MODIFIER */,
                10 => Tunables.Global_262145.Value<int>("f_4088") /* Tunable: SHAMAL_EXPENDITURE_MODIFIER */,
                27 => Tunables.Global_262145.Value<int>("f_4089") /* Tunable: SQUALO_EXPENDITURE_MODIFIER */,
                1 => Tunables.Global_262145.Value<int>("f_4090") /* Tunable: STINGER_EXPENDITURE_MODIFIER */,
                76 => Tunables.Global_262145.Value<int>("f_4091") /* Tunable: STINGERGT_EXPENDITURE_MODIFIER */,
                88 => Tunables.Global_262145.Value<int>("f_4092") /* Tunable: STRETCH_EXPENDITURE_MODIFIER */,
                11 => Tunables.Global_262145.Value<int>("f_4093") /* Tunable: STUNT_EXPENDITURE_MODIFIER */,
                32 => Tunables.Global_262145.Value<int>("f_4094") /* Tunable: SUNTRAP_EXPENDITURE_MODIFIER */,
                55 => Tunables.Global_262145.Value<int>("f_4095") /* Tunable: SUPERD_EXPENDITURE_MODIFIER */,
                45 => Tunables.Global_262145.Value<int>("f_4096") /* Tunable: SURANO_EXPENDITURE_MODIFIER */,
                18 => Tunables.Global_262145.Value<int>("f_4097") /* Tunable: TITAN_EXPENDITURE_MODIFIER */,
                35 => Tunables.Global_262145.Value<int>("f_4098") /* Tunable: TRIBIKE_EXPENDITURE_MODIFIER */,
                36 => Tunables.Global_262145.Value<int>("f_4099") /* Tunable: TRIBIKE2_EXPENDITURE_MODIFIER */,
                37 => Tunables.Global_262145.Value<int>("f_4100") /* Tunable: TRIBIKE3_EXPENDITURE_MODIFIER */,
                29 => Tunables.Global_262145.Value<int>("f_4101") /* Tunable: TROPIC_EXPENDITURE_MODIFIER */,
                46 => Tunables.Global_262145.Value<int>("f_4102") /* Tunable: VACCA_EXPENDITURE_MODIFIER */,
                65 => Tunables.Global_262145.Value<int>("f_4103") /* Tunable: VADER_EXPENDITURE_MODIFIER */,
                80 => Tunables.Global_262145.Value<int>("f_4104") /* Tunable: VELUM_EXPENDITURE_MODIFIER */,
                42 => Tunables.Global_262145.Value<int>("f_4105") /* Tunable: VIGERO_EXPENDITURE_MODIFIER */,
                77 => Tunables.Global_262145.Value<int>("f_7801") /* Tunable: DLC_VEHICLE_COIL_VOLTIC_TOPLESS */,
                40 => Tunables.Global_262145.Value<int>("f_4107") /* Tunable: ZION_EXPENDITURE_MODIFIER */,
                93 => Tunables.Global_262145.Value<int>("f_4108") /* Tunable: ZION2_EXPENDITURE_MODIFIER */,
                0 => Tunables.Global_262145.Value<int>("f_4109") /* Tunable: ZTYPE_EXPENDITURE_MODIFIER */,
                103 => Tunables.Global_262145.Value<int>("f_4741") /* Tunable: BODHI2_EXPENDITURE_MODIFIER */,
                104 => Tunables.Global_262145.Value<int>("f_4742") /* Tunable: DUNE_EXPENDITURE_MODIFIER */,
                105 => Tunables.Global_262145.Value<int>("f_4743") /* Tunable: REBEL_EXPENDITURE_MODIFIER */,
                106 => Tunables.Global_262145.Value<int>("f_4744") /* Tunable: SADLER_EXPENDITURE_MODIFIER */,
                107 => Tunables.Global_262145.Value<int>("f_4745") /* Tunable: SANCHEZ2_EXPENDITURE_MODIFIER */,
                108 => Tunables.Global_262145.Value<int>("f_4746") /* Tunable: SANDKING2_EXPENDITURE_MODIFIER */,
                128 => Tunables.Global_262145.Value<int>("f_4110") /* Tunable: ASEA_EXPENDITURE_MODIFIER */,
                129 => Tunables.Global_262145.Value<int>("f_7114") /* Tunable: BUSINESS_VEHICLES_ASTEROPE */,
                130 => Tunables.Global_262145.Value<int>("f_7115") /* Tunable: BUSINESS_VEHICLES_BOBCATXL */,
                131 => Tunables.Global_262145.Value<int>("f_7116") /* Tunable: BUSINESS_VEHICLES_CAVALCADE2 */,
                132 => Tunables.Global_262145.Value<int>("f_7117") /* Tunable: BUSINESS_VEHICLES_GRANGER */,
                133 => Tunables.Global_262145.Value<int>("f_7118") /* Tunable: BUSINESS_VEHICLES_INGOT */,
                134 => Tunables.Global_262145.Value<int>("f_7119") /* Tunable: BUSINESS_VEHICLES_INTRUDER */,
                135 => Tunables.Global_262145.Value<int>("f_7120") /* Tunable: BUSINESS_VEHICLES_MINIVAN */,
                136 => Tunables.Global_262145.Value<int>("f_7121") /* Tunable: BUSINESS_VEHICLES_PREMIER */,
                137 => Tunables.Global_262145.Value<int>("f_7122") /* Tunable: BUSINESS_VEHICLES_RADI */,
                138 => Tunables.Global_262145.Value<int>("f_7123") /* Tunable: BUSINESS_VEHICLES_RANCHERXL */,
                139 => Tunables.Global_262145.Value<int>("f_7143") /* Tunable: VALENTINE_MODIFIER_VEHICLE_RATLOADER */,
                140 => Tunables.Global_262145.Value<int>("f_7124") /* Tunable: BUSINESS_VEHICLES_STANIER */,
                141 => Tunables.Global_262145.Value<int>("f_7125") /* Tunable: BUSINESS_VEHICLES_STRATUM */,
                142 => Tunables.Global_262145.Value<int>("f_7126") /* Tunable: BUSINESS_VEHICLES_WASHINGTON */,
                150 => Tunables.Global_262145.Value<int>("f_8285") /* Tunable: DLC_HIPSTER_CAR_MOD_PICADOR */,
                151 => Tunables.Global_262145.Value<int>("f_8288") /* Tunable: DLC_HIPSTER_CAR_MOD_REGINA */,
                152 => Tunables.Global_262145.Value<int>("f_8289") /* Tunable: DLC_HIPSTER_CAR_MOD_SURFER */,
                153 => Tunables.Global_262145.Value<int>("f_8291") /* Tunable: DLC_HIPSTER_CAR_MOD_YOUGA */,
                154 => Tunables.Global_262145.Value<int>("f_8282") /* Tunable: DLC_HIPSTER_CAR_MOD_BLAZER3 */,
                155 => Tunables.Global_262145.Value<int>("f_8287") /* Tunable: DLC_HIPSTER_CAR_MOD_REBEL2 */,
                156 => Tunables.Global_262145.Value<int>("f_8286") /* Tunable: DLC_HIPSTER_CAR_MOD_PRIMO */,
                157 => Tunables.Global_262145.Value<int>("f_8283") /* Tunable: DLC_HIPSTER_CAR_MOD_BUFFALO */,
                158 => Tunables.Global_262145.Value<int>("f_8284") /* Tunable: DLC_HIPSTER_CAR_MOD_BUFFALO2 */,
                159 => Tunables.Global_262145.Value<int>("f_8290") /* Tunable: DLC_HIPSTER_CAR_MOD_TAILGATER */,
                _ => -1,
            };
        }
        internal static bool func_7123(int iParam0, int iParam1)//Position - 0x24BD3A
        {
            switch ((VehicleHash)iParam1)
            {
                case VehicleHash.LE7B:
                    if (Tunables.Global_262145.Value<int>("f_17485") != 1/* Tunable: ENABLESTUNT_LE7B */)
                        return false;
                    break;
                case VehicleHash.Omnis:
                    if (Tunables.Global_262145.Value<int>("f_17486") != 1/* Tunable: ENABLESTUNT_OMNIS */)
                        return false;
                    break;
                case VehicleHash.Tropos:
                    if (Tunables.Global_262145.Value<int>("f_17487") != 1/* Tunable: ENABLESTUNT_TROPOS_RALLYE */)
                        return false;
                    break;
                case VehicleHash.Brioso:
                    if (Tunables.Global_262145.Value<int>("f_17488") != 1/* Tunable: ENABLESTUNT_BRIOSO_RA */)
                        return false;
                    break;
                case VehicleHash.TrophyTruck:
                    if (Tunables.Global_262145.Value<int>("f_17489") != 1/* Tunable: ENABLESTUNT_TROPHY_TRUCK */)
                        return false;
                    break;
                case VehicleHash.TrophyTruck2:
                    if (Tunables.Global_262145.Value<int>("f_17490") != 1/* Tunable: ENABLESTUNT_TROPHY_CAR */)
                        return false;
                    break;
                case VehicleHash.Contender:
                    if (Tunables.Global_262145.Value<int>("f_17491") != 1/* Tunable: ENABLESTUNT_CONTENDER */)
                        return false;
                    break;
                case VehicleHash.Cliffhanger:
                    if (Tunables.Global_262145.Value<int>("f_17492") != 1/* Tunable: ENABLESTUNT_CLIFFHANGER */)
                        return false;
                    break;
                case VehicleHash.BF400:
                    if (Tunables.Global_262145.Value<int>("f_17493") != 1/* Tunable: ENABLESTUNT_BF400 */)
                        return false;
                    break;
                case VehicleHash.Tyrus:
                    if (Tunables.Global_262145.Value<int>("f_17483") != 1/* Tunable: ENABLESTUNT_TYRUS */)
                        return false;
                    break;
                case VehicleHash.Lynx:
                    if (Tunables.Global_262145.Value<int>("f_17494") != 1/* Tunable: ENABLESTUNT_LYNX */)
                        return false;
                    break;
                case VehicleHash.Sheava:
                    if (Tunables.Global_262145.Value<int>("f_17482") != 1/* Tunable: ENABLESTUNT_ET1 */)
                        return false;
                    break;
                case VehicleHash.RallyTruck:
                    if (Tunables.Global_262145.Value<int>("f_17496") != 1/* Tunable: ENABLESTUNT_RALLY_TRUCK */)
                        return false;
                    break;
                case VehicleHash.Tampa2:
                    if (Tunables.Global_262145.Value<int>("f_17484") != 1/* Tunable: ENABLESTUNT_DRIFT_TAMPA */)
                        return false;
                    break;
                case VehicleHash.Gargoyle:
                    if (Tunables.Global_262145.Value<int>("f_17495") != 1/* Tunable: ENABLESTUNT_GARGOYLE */)
                        return false;
                    break;
                case VehicleHash.Stalion2:
                    if ((Tunables.Global_262145.Value<int>("f_20402") != 1/* Tunable: ENABLE_RETURNING_CONTENT_VEHICLE */))
                    {
                        if (Tunables.Global_262145.Value<int>("f_17497") != 1/* Tunable: ENABLESTUNT_STALLION */)
                        {
                            return false;
                        }
                    }
                    break;
                case VehicleHash.Dominator2:
                    if ((Tunables.Global_262145.Value<int>("f_20402") != 1/* Tunable: ENABLE_RETURNING_CONTENT_VEHICLE */))
                    {
                        if (Tunables.Global_262145.Value<int>("f_17499") != 1/* Tunable: ENABLESTUNT_DOMINATOR */)
                        {
                            return false;
                        }
                    }
                    break;
                case VehicleHash.Gauntlet2:
                    if ((Tunables.Global_262145.Value<int>("f_20402") != 1/* Tunable: ENABLE_RETURNING_CONTENT_VEHICLE */))
                    {
                        if (Tunables.Global_262145.Value<int>("f_17498") != 1/* Tunable: ENABLESTUNT_GAUNTLET */)
                        {
                            return false;
                        }
                    }
                    break;
                case VehicleHash.Buffalo3:
                    if ((Tunables.Global_262145.Value<int>("f_20402") != 1/* Tunable: ENABLE_RETURNING_CONTENT_VEHICLE */))
                    {
                        if (Tunables.Global_262145.Value<int>("f_17500") != 1/* Tunable: ENABLESTUNT_BUFFALO */)
                        {
                            return false;
                        }
                    }
                    break;
                case VehicleHash.Esskey:
                    if (Tunables.Global_262145.Value<int>("f_17657") != 1/* Tunable: ENABLE_BIKER_ESSKEY */)
                        return false;
                    break;
                case VehicleHash.Nightblade:
                    if (Tunables.Global_262145.Value<int>("f_17655") != 1/* Tunable: ENABLE_BIKER_NIGHTBLADE */)
                        return false;
                    break;
                case VehicleHash.Defiler:
                    if (Tunables.Global_262145.Value<int>("f_17654") != 1/* Tunable: ENABLE_BIKER_DEFILER */)
                        return false;
                    break;
                case VehicleHash.Avarus:
                    if (Tunables.Global_262145.Value<int>("f_17658") != 1/* Tunable: ENABLE_BIKER_AVARUS */)
                        return false;
                    break;
                case VehicleHash.ZombieA:
                    if (Tunables.Global_262145.Value<int>("f_17656") != 1/* Tunable: ENABLE_BIKER_ZOMBIEA */)
                        return false;
                    break;
                case VehicleHash.ZombieB:
                    if (Tunables.Global_262145.Value<int>("f_17659") != 1/* Tunable: ENABLE_BIKER_ZOMBIEB */)
                        return false;
                    break;
                case VehicleHash.Chimera:
                    if (Tunables.Global_262145.Value<int>("f_17664") != 1/* Tunable: ENABLE_BIKER_CHIMERA */)
                        return false;
                    break;
                case VehicleHash.Daemon2:
                    if (Tunables.Global_262145.Value<int>("f_17666") != 1/* Tunable: ENABLE_BIKER_WESTERNDAEMON */)
                        return false;
                    break;
                case VehicleHash.RatBike:
                    if (Tunables.Global_262145.Value<int>("f_17675") != 1/* Tunable: ENABLE_BIKER_RATBIKE */)
                        return false;
                    break;
                case VehicleHash.Shotaro:
                    if (Tunables.Global_262145.Value<int>("f_17663") != 1/* Tunable: ENABLE_BIKER_SHOTARO */)
                        return false;
                    break;
                case VehicleHash.Raptor:
                    if (Tunables.Global_262145.Value<int>("f_17665") != 1/* Tunable: ENABLE_BIKER_RAPTOR */)
                        return false;
                    break;
                case VehicleHash.Hakuchou2:
                    if (Tunables.Global_262145.Value<int>("f_17661") != 1/* Tunable: ENABLE_BIKER_HAKUCHOU2 */)
                        return false;
                    break;
                case VehicleHash.Blazer4:
                    if (Tunables.Global_262145.Value<int>("f_17667") != 1/* Tunable: ENABLE_BIKER_BLAZER4 */)
                        return false;
                    break;
                case VehicleHash.Sanctus:
                    if (Tunables.Global_262145.Value<int>("f_17668") != 1/* Tunable: ENABLE_BIKER_SANCTUS */)
                        return false;
                    break;
                case VehicleHash.Vortex:
                    if (Tunables.Global_262145.Value<int>("f_17662") != 1/* Tunable: ENABLE_BIKER_VORTEX */)
                        return false;
                    break;
                case VehicleHash.Manchez:
                    if (Tunables.Global_262145.Value<int>("f_17669") != 1/* Tunable: ENABLE_BIKER_MANCHEZ */)
                        return false;
                    break;
                case VehicleHash.Tornado6:
                    if (Tunables.Global_262145.Value<int>("f_17673") != 1/* Tunable: ENABLE_BIKER_TORNADO6 */)
                        return false;
                    break;
                case VehicleHash.Youga2:
                    if (Tunables.Global_262145.Value<int>("f_17670") != 1/* Tunable: ENABLE_BIKER_YOUGA2 */)
                        return false;
                    break;
                case VehicleHash.Wolfsbane:
                    if (Tunables.Global_262145.Value<int>("f_17671") != 1/* Tunable: ENABLE_BIKER_WOLFSBANE */)
                        return false;
                    break;
                case VehicleHash.Faggio3:
                    if (Tunables.Global_262145.Value<int>("f_17672") != 1/* Tunable: ENABLE_BIKER_FAGGIO3 */)
                        return false;
                    break;
                case VehicleHash.Faggio:
                    if (Tunables.Global_262145.Value<int>("f_17660") != 1/* Tunable: ENABLE_BIKER_FAGGIO */)
                        return false;
                    break;
                case VehicleHash.Voltic2:
                    if (Tunables.Global_262145.Value<int>("f_19311") != 1/* Tunable: ENABLE_IE_VOLTIC2 */)
                        return false;
                    break;
                case VehicleHash.Ruiner2:
                    if (Tunables.Global_262145.Value<int>("f_19312") != 1/* Tunable: ENABLE_IE_RUINER2 */)
                        return false;
                    break;
                case VehicleHash.Dune4:
                    if (Tunables.Global_262145.Value<int>("f_19313") != 1/* Tunable: ENABLE_IE_DUNE4 */)
                        return false;
                    break;
                case VehicleHash.Dune5:
                    if (Tunables.Global_262145.Value<int>("f_19314") != 1/* Tunable: ENABLE_IE_DUNE5 */)
                        return false;
                    break;
                case VehicleHash.Phantom2:
                    if (Tunables.Global_262145.Value<int>("f_19315") != 1/* Tunable: ENABLE_IE_PHANTOM2 */)
                        return false;
                    break;
                case VehicleHash.Technical2:
                    if (Tunables.Global_262145.Value<int>("f_19316") != 1/* Tunable: ENABLE_IE_TECHNICAL2 */)
                        return false;
                    break;
                case VehicleHash.Boxville5:
                    if (Tunables.Global_262145.Value<int>("f_19317") != 1/* Tunable: ENABLE_IE_BOXVILLE5 */)
                        return false;
                    break;
                case VehicleHash.Wastelander:
                    if (Tunables.Global_262145.Value<int>("f_19318") != 1/* Tunable: ENABLE_IE_WASTELANDER */)
                        return false;
                    break;
                case VehicleHash.Blazer5:
                    if (Tunables.Global_262145.Value<int>("f_19319") != 1/* Tunable: ENABLE_IE_BLAZER5 */)
                        return false;
                    break;
                case VehicleHash.Comet2:
                    if (Tunables.Global_262145.Value<int>("f_19320") != 1/* Tunable: ENABLE_IE_COMET2 */)
                        return false;
                    break;
                case VehicleHash.Comet3:
                    if (Tunables.Global_262145.Value<int>("f_19321") != 1/* Tunable: ENABLE_IE_COMET3 */)
                        return false;
                    break;
                case VehicleHash.Diablous:
                    if (Tunables.Global_262145.Value<int>("f_19322") != 1/* Tunable: ENABLE_IE_DIABLOUS */)
                        return false;
                    break;
                case VehicleHash.Diablous2:
                    if (Tunables.Global_262145.Value<int>("f_19323") != 1/* Tunable: ENABLE_IE_DIABLOUS2 */)
                        return false;
                    break;
                case VehicleHash.Elegy:
                    if (Tunables.Global_262145.Value<int>("f_19324") != 1/* Tunable: ENABLE_IE_ELEGY */)
                        return false;
                    break;
                case VehicleHash.Elegy2:
                    if (Tunables.Global_262145.Value<int>("f_19325") != 1/* Tunable: ENABLE_IE_ELEGY2 */)
                        return false;
                    break;
                case VehicleHash.FCR:
                    if (Tunables.Global_262145.Value<int>("f_19326") != 1/* Tunable: ENABLE_IE_FCR */)
                        return false;
                    break;
                case VehicleHash.FCR2:
                    if (Tunables.Global_262145.Value<int>("f_19327") != 1/* Tunable: ENABLE_IE_FCR2 */)
                        return false;
                    break;
                case VehicleHash.ItaliGTB:
                    if (Tunables.Global_262145.Value<int>("f_19328") != 1/* Tunable: ENABLE_IE_ITALIGTB */)
                        return false;
                    break;
                case VehicleHash.ItaliGTB2:
                    if (Tunables.Global_262145.Value<int>("f_19329") != 1/* Tunable: ENABLE_IE_ITALIGTB2 */)
                        return false;
                    break;
                case VehicleHash.Nero:
                    if (Tunables.Global_262145.Value<int>("f_19330") != 1/* Tunable: ENABLE_IE_NERO */)
                        return false;
                    break;
                case VehicleHash.Nero2:
                    if (Tunables.Global_262145.Value<int>("f_19331") != 1/* Tunable: ENABLE_IE_NERO2 */)
                        return false;
                    break;
                case VehicleHash.Penetrator:
                    if (Tunables.Global_262145.Value<int>("f_19332") != 1/* Tunable: ENABLE_IE_PENETRATOR */)
                        return false;
                    break;
                case VehicleHash.Specter:
                    if (Tunables.Global_262145.Value<int>("f_19333") != 1/* Tunable: ENABLE_IE_SPECTER */)
                        return false;
                    break;
                case VehicleHash.Specter2:
                    if (Tunables.Global_262145.Value<int>("f_19334") != 1/* Tunable: ENABLE_IE_SPECTER2 */)
                        return false;
                    break;
                case VehicleHash.Tempesta:
                    if (Tunables.Global_262145.Value<int>("f_19335") != 1/* Tunable: ENABLE_IE_TEMPESTA */)
                        return false;
                    break;
                case VehicleHash.XA21:
                    if (Tunables.Global_262145.Value<int>("f_21274") != 1/* Tunable: ENABLE_XA21 */)
                        return false;
                    break;
                case VehicleHash.Cheetah2:
                    if (Tunables.Global_262145.Value<int>("f_21275") != 1/* Tunable: ENABLE_CHEETAH2 */)
                        return false;
                    break;
                case VehicleHash.Torero:
                    if (Tunables.Global_262145.Value<int>("f_21276") != 1/* Tunable: ENABLE_TORERO */)
                        return false;
                    break;
                case VehicleHash.Vagner:
                    if (Tunables.Global_262145.Value<int>("f_21277") != 1/* Tunable: ENABLE_VAGNER */)
                        return false;
                    break;
                case VehicleHash.Ardent:
                    if (Tunables.Global_262145.Value<int>("f_21278") != 1/* Tunable: ENABLE_ARDENT */)
                        return false;
                    break;
                case VehicleHash.NightShark:
                    if (Tunables.Global_262145.Value<int>("f_21279") != 1/* Tunable: ENABLE_NIGHTSHARK */)
                        return false;
                    break;
                case /*MicroLight*/ (VehicleHash)2531412055:
                    if (Tunables.Global_262145.Value<int>("f_22073") != 1/* Tunable: ENABLE_ULTRALIGHT */)
                        return false;
                    break;
                case /*Seabreeze*/ (VehicleHash)3902291871:
                    if (Tunables.Global_262145.Value<int>("f_22074") != 1/* Tunable: ENABLE_SEABREEZE */)
                        return false;
                    break;
                case /*Howard*/ (VehicleHash)3287439187:
                    if (Tunables.Global_262145.Value<int>("f_22075") != 1/* Tunable: ENABLE_HOWARD */)
                        return false;
                    break;
                case /*Rogue*/ (VehicleHash)3319621991:
                    if (Tunables.Global_262145.Value<int>("f_22076") != 1/* Tunable: ENABLE_ROGUE */)
                        return false;
                    break;
                case /*Alphaz1*/ (VehicleHash)2771347558:
                    if (Tunables.Global_262145.Value<int>("f_22077") != 1/* Tunable: ENABLE_ALPHAZ1 */)
                        return false;
                    break;
                case /*Havok*/ (VehicleHash)2310691317:
                    if (Tunables.Global_262145.Value<int>("f_22083") != 1/* Tunable: ENABLE_HAVOK */)
                        return false;
                    break;
                case /*Nokota*/ (VehicleHash)1036591958:
                    if (Tunables.Global_262145.Value<int>("f_22084") != 1/* Tunable: ENABLE_NOKOTA */)
                        return false;
                    break;
                case /*Mogul*/ (VehicleHash)3545667823:
                    if (Tunables.Global_262145.Value<int>("f_22085") != 1/* Tunable: ENABLE_MOGUL */)
                        return false;
                    break;
                case /*Starling*/ (VehicleHash)2594093022:
                    if (Tunables.Global_262145.Value<int>("f_22086") != 1/* Tunable: ENABLE_STARLING */)
                        return false;
                    break;
                case /*Hunter*/ (VehicleHash)4252008158:
                    if (Tunables.Global_262145.Value<int>("f_22087") != 1/* Tunable: ENABLE_HUNTER */)
                        return false;
                    break;
                case /*Pyro*/ (VehicleHash)2908775872:
                    if (Tunables.Global_262145.Value<int>("f_22088") != 1/* Tunable: ENABLE_PYRO */)
                        return false;
                    break;
                case /*Molotok*/ (VehicleHash)1565978651:
                    if (Tunables.Global_262145.Value<int>("f_22089") != 1/* Tunable: ENABLE_MOLOTOK */)
                        return false;
                    break;
                case /*Tula*/ (VehicleHash)1043222410:
                    if (Tunables.Global_262145.Value<int>("f_22090") != 1/* Tunable: ENABLE_TULA */)
                        return false;
                    break;
                case /*Bombushka*/ (VehicleHash)4262088844:
                    if (Tunables.Global_262145.Value<int>("f_22091") != 1/* Tunable: ENABLE_BOMBUSHKA */)
                        return false;
                    break;
                case VehicleHash.Lazer:
                    if (Tunables.Global_262145.Value<int>("f_22092") != 1/* Tunable: ENABLE_LAZER */)
                        return false;
                    break;
                case /*Cyclone*/ (VehicleHash)1392481335:
                    if (Tunables.Global_262145.Value<int>("f_22078") != 1/* Tunable: ENABLE_CYCLONE */)
                        return false;
                    break;
                case /*Visione*/ (VehicleHash)3296789504:
                    if (Tunables.Global_262145.Value<int>("f_22079") != 1/* Tunable: ENABLE_VISIONE */)
                        return false;
                    break;
                case /*Retinue*/ (VehicleHash)1841130506:
                    if (Tunables.Global_262145.Value<int>("f_22081") != 1/* Tunable: ENABLE_RETINUE */)
                        return false;
                    break;
                case /*RapidGT3*/ (VehicleHash)2049897956:
                    if (Tunables.Global_262145.Value<int>("f_22082") != 1/* Tunable: ENABLE_RAPIDGT3 */)
                        return false;
                    break;
                case /*Vigilante*/ (VehicleHash)3052358707:
                    if (Tunables.Global_262145.Value<int>("f_22080") != 1/* Tunable: ENABLE_VIGILANTE */)
                        return false;
                    break;
                case /*Deluxo*/ (VehicleHash)1483171323:
                    if (Tunables.Global_262145.Value<int>("f_23041") != 1/* Tunable: ENABLE_DELUXO */)
                        return false;
                    break;
                case /*Stromberg*/ (VehicleHash)886810209:
                    if (Tunables.Global_262145.Value<int>("f_23042") != 1/* Tunable: ENABLE_STROMBERG */)
                        return false;
                    break;
                case /*Riot2*/ (VehicleHash)2601952180:
                    if (Tunables.Global_262145.Value<int>("f_23043") != 1/* Tunable: ENABLE_RIOT2 */)
                        return false;
                    break;
                case /*Chernobog*/ (VehicleHash)3602674979:
                    if (Tunables.Global_262145.Value<int>("f_23044") != 1/* Tunable: ENABLE_CHERNOBOG */)
                        return false;
                    break;
                case /*Khanjali*/ (VehicleHash)2859440138:
                    if (Tunables.Global_262145.Value<int>("f_23045") != 1/* Tunable: ENABLE_KHANJALI */)
                        return false;
                    break;
                case /*Akula*/ (VehicleHash)1181327175:
                    if (Tunables.Global_262145.Value<int>("f_23046") != 1/* Tunable: ENABLE_AKULA */)
                        return false;
                    break;
                case /*Thruster*/ (VehicleHash)1489874736:
                    if (Tunables.Global_262145.Value<int>("f_23047") != 1/* Tunable: ENABLE_THRUSTER */)
                        return false;
                    break;
                case  /*Barrage*/ (VehicleHash)4081974053:
                    if (Tunables.Global_262145.Value<int>("f_23048") != 1/* Tunable: ENABLE_BARRAGE */)
                        return false;
                    break;
                case /*Volatol*/ (VehicleHash)447548909:
                    if (Tunables.Global_262145.Value<int>("f_23049") != 1/* Tunable: ENABLE_VOLATOL */)
                        return false;
                    break;
                case /*Comet4*/ (VehicleHash)1561920505:
                    if (Tunables.Global_262145.Value<int>("f_23050") != 1/* Tunable: ENABLE_COMET4 */)
                        return false;
                    break;
                case /*Neon*/ (VehicleHash)2445973230:
                    if (Tunables.Global_262145.Value<int>("f_23051") != 1/* Tunable: ENABLE_NEON */)
                        return false;
                    break;
                case /*Streiter*/ (VehicleHash)1741861769:
                    if (Tunables.Global_262145.Value<int>("f_23052") != 1/* Tunable: ENABLE_STREITER */)
                        return false;
                    break;
                case /*Sentinel3*/ (VehicleHash)1104234922:
                    if (Tunables.Global_262145.Value<int>("f_23053") != 1/* Tunable: ENABLE_SENTINEL3 */)
                        return false;
                    break;
                case /*Yosemite*/ (VehicleHash)1871995513:
                    if (Tunables.Global_262145.Value<int>("f_23054") != 1/* Tunable: ENABLE_YOSEMITE */)
                        return false;
                    break;
                case /*Sc1*/ (VehicleHash)1352136073:
                    if (Tunables.Global_262145.Value<int>("f_23055") != 1/* Tunable: ENABLE_SC1 */)
                        return false;
                    break;
                case /*Autarch*/ (VehicleHash)3981782132:
                    if (Tunables.Global_262145.Value<int>("f_23056") != 1/* Tunable: ENABLE_AUTARCH */)
                        return false;
                    break;
                case /*Gt500*/ (VehicleHash)2215179066:
                    if (Tunables.Global_262145.Value<int>("f_23057") != 1/* Tunable: ENABLE_GT500 */)
                        return false;
                    break;
                case /*Hustler*/ (VehicleHash)600450546:
                    if (Tunables.Global_262145.Value<int>("f_23058") != 1/* Tunable: ENABLE_HUSTLER */)
                        return false;
                    break;
                case /*Revolter*/ (VehicleHash)3884762073:
                    if (Tunables.Global_262145.Value<int>("f_23059") != 1/* Tunable: ENABLE_REVOLTER */)
                        return false;
                    break;
                case  /*Pariah*/ (VehicleHash)867799010:
                    if (Tunables.Global_262145.Value<int>("f_23060") != 1/* Tunable: ENABLE_PARIAH */)
                        return false;
                    break;
                case /*Raiden*/ (VehicleHash)2765724541:
                    if (Tunables.Global_262145.Value<int>("f_23061") != 1/* Tunable: ENABLE_RAIDEN */)
                        return false;
                    break;
                case  /*Savestra*/ (VehicleHash)903794909:
                    if (Tunables.Global_262145.Value<int>("f_23062") != 1/* Tunable: ENABLE_SAVESTRA */)
                        return false;
                    break;
                case  /*Riata*/ (VehicleHash)2762269779:
                    if (Tunables.Global_262145.Value<int>("f_23063") != 1/* Tunable: ENABLE_RIATA */)
                        return false;
                    break;
                case /*Hermes*/ (VehicleHash)15219735:
                    if (Tunables.Global_262145.Value<int>("f_23064") != 1/* Tunable: ENABLE_HERMES */)
                        return false;
                    break;
                case /*Comet5*/ (VehicleHash)661493923:
                    if (Tunables.Global_262145.Value<int>("f_23065") != 1/* Tunable: ENABLE_COMET5 */)
                        return false;
                    break;
                case /*Z190*/ (VehicleHash)838982985:
                    if (Tunables.Global_262145.Value<int>("f_23066") != 1/* Tunable: ENABLE_Z190 */)
                        return false;
                    break;
                case /*Viseris*/ (VehicleHash)3903371924:
                    if (Tunables.Global_262145.Value<int>("f_23067") != 1/* Tunable: ENABLE_VISERIS */)
                        return false;
                    break;
                case /*Kamacho*/ (VehicleHash)4173521127:
                    if (Tunables.Global_262145.Value<int>("f_23068") != 1/* Tunable: ENABLE_KAMACHO */)
                        return false;
                    break;
                case /*Gb200*/ (VehicleHash)1909189272:
                    if (Tunables.Global_262145.Value<int>("f_24263") != 1/* Tunable: ENABLE_GB200 */)
                        return false;
                    break;
                case /*Fagaloa*/ (VehicleHash)1617472902:
                    if (Tunables.Global_262145.Value<int>("f_24264") != 1/* Tunable: ENABLE_FAGALOA */)
                        return false;
                    break;
                case /*Ellie*/ (VehicleHash)3027423925:
                    if (Tunables.Global_262145.Value<int>("f_24268") != 1/* Tunable: ENABLE_ELLIE */)
                        return false;
                    break;
                case  /*Issi3*/ (VehicleHash)931280609:
                    if (Tunables.Global_262145.Value<int>("f_24271") != 1/* Tunable: ENABLE_ISSI3 */)
                        return false;
                    break;
                case /*Michelli*/ (VehicleHash)1046206681:
                    if (Tunables.Global_262145.Value<int>("f_24276") != 1/* Tunable: ENABLE_MICHELLI */)
                        return false;
                    break;
                case /*FlashGT*/ (VehicleHash)3035832600:
                    if (Tunables.Global_262145.Value<int>("f_24270") != 1/* Tunable: ENABLE_FLASHGT */)
                        return false;
                    break;
                case /*Hotring*/ (VehicleHash)1115909093:
                    if (Tunables.Global_262145.Value<int>("f_24262") != 1/* Tunable: ENABLE_HOTRING */)
                        return false;
                    break;
                case /*Tezeract*/ (VehicleHash)1031562256:
                    if (Tunables.Global_262145.Value<int>("f_24269") != 1/* Tunable: ENABLE_TEZERACT */)
                        return false;
                    break;
                case /*Tyrant*/ (VehicleHash)3918533058:
                    if (Tunables.Global_262145.Value<int>("f_24275") != 1/* Tunable: ENABLE_TYRANT */)
                        return false;
                    break;
                case /*Dominator3*/ (VehicleHash)3308022675:
                    if (Tunables.Global_262145.Value<int>("f_24274") != 1/* Tunable: ENABLE_DOMINATOR3 */)
                        return false;
                    break;
                case /*Taipan*/ (VehicleHash)3160260734:
                    if (Tunables.Global_262145.Value<int>("f_24265") != 1/* Tunable: ENABLE_TAIPAN */)
                        return false;
                    break;
                case /*Entity2*/ (VehicleHash)2174267100:
                    if (Tunables.Global_262145.Value<int>("f_24267") != 1/* Tunable: ENABLE_ENTITY2 */)
                        return false;
                    break;
                case /*Jester3*/ (VehicleHash)4080061290:
                    if (Tunables.Global_262145.Value<int>("f_24277") != 1/* Tunable: ENABLE_JESTER3 */)
                        return false;
                    break;
                case /*Cheburek*/ (VehicleHash)3306466016:
                    if (Tunables.Global_262145.Value<int>("f_24273") != 1/* Tunable: ENABLE_CHEBUREK */)
                        return false;
                    break;
                case /*Caracara*/ (VehicleHash)1254014755:
                    if (Tunables.Global_262145.Value<int>("f_24266") != 1/* Tunable: ENABLE_CARACARA */)
                        return false;
                    break;
                case /*Seasparrow*/ (VehicleHash)3568198617:
                    if (Tunables.Global_262145.Value<int>("f_24272") != 1/* Tunable: ENABLE_SEASPARROW */)
                        return false;
                    break;
                case /*Mule4*/ (VehicleHash)1945374990:
                    if (Tunables.Global_262145.Value<int>("f_24359") != 1/* Tunable: ENABLE_MULE4 */)
                        return false;
                    break;
                case /*Pounder2*/ (VehicleHash)1653666139:
                    if (Tunables.Global_262145.Value<int>("f_24358") != 1/* Tunable: ENABLE_POUNDER2 */)
                        return false;
                    break;
                case /*Swinger*/ (VehicleHash)500482303:
                    if (Tunables.Global_262145.Value<int>("f_24356") != 1/* Tunable: ENABLE_SWINGER */)
                        return false;
                    break;
                case /*Menacer*/ (VehicleHash)2044532910:
                    if (Tunables.Global_262145.Value<int>("f_24362") != 1/* Tunable: ENABLE_MENACER */)
                        return false;
                    break;
                case /*Scramjet*/ (VehicleHash)3656405053:
                    if (Tunables.Global_262145.Value<int>("f_24364") != 1/* Tunable: ENABLE_SCRAMJET */)
                        return false;
                    break;
                case /*Strikeforce*/ (VehicleHash)1692272545:
                    if (Tunables.Global_262145.Value<int>("f_24365") != 1/* Tunable: ENABLE_STRIKEFORCE */)
                        return false;
                    break;
                case  /*Oppressor2*/ (VehicleHash)2069146067:
                    if (Tunables.Global_262145.Value<int>("f_24363") != 1/* Tunable: ENABLE_OPPRESSOR2 */)
                        return false;
                    break;
                case /*Patriot2*/ (VehicleHash)3874056184:
                    if (Tunables.Global_262145.Value<int>("f_24355") != 1/* Tunable: ENABLE_PATRIOT2 */)
                        return false;
                    break;
                case /*Stafford*/ (VehicleHash)321186144:
                    if (Tunables.Global_262145.Value<int>("f_24357") != 1/* Tunable: ENABLE_STAFFORD */)
                        return false;
                    break;
                case /*Freecrawler*/ (VehicleHash)4240635011:
                    if (Tunables.Global_262145.Value<int>("f_24361") != 1/* Tunable: ENABLE_FREECRAWLER */)
                        return false;
                    break;
                case /*Blimp3*/ (VehicleHash)3987008919:
                    if (Tunables.Global_262145.Value<int>("f_24360") != 1/* Tunable: ENABLE_BLIMP3 */)
                        return false;
                    break;
                case /*Terbyte*/ (VehicleHash)2306538597:
                    if (Tunables.Global_262145.Value<int>("f_24353") != 1/* Tunable: ENABLE_TERBYTE */)
                        return false;
                    break;
                case /*PBus2*/ (VehicleHash)345756458:
                    if (Tunables.Global_262145.Value<int>("f_24354") != 1/* Tunable: ENABLE_PBUS2 */)
                        return false;
                    break;
                case VehicleHash.Futo:
                    if (Tunables.Global_262145.Value<int>("f_24366") != 1/* Tunable: ENABLE_FUTO */)
                        return false;
                    break;
                case VehicleHash.Ruiner:
                    if (Tunables.Global_262145.Value<int>("f_24367") != 1/* Tunable: ENABLE_RUINER */)
                        return false;
                    break;
                case VehicleHash.Romero:
                    if (Tunables.Global_262145.Value<int>("f_24368") != 1/* Tunable: ENABLE_HEARSE */)
                        return false;
                    break;
                case VehicleHash.Prairie:
                    if (Tunables.Global_262145.Value<int>("f_24369") != 1/* Tunable: ENABLE_PRAIRIE */)
                        return false;
                    break;
                case VehicleHash.Baller:
                    if (Tunables.Global_262145.Value<int>("f_24370") != 1/* Tunable: ENABLE_BALLER */)
                        return false;
                    break;
                case VehicleHash.Serrano:
                    if (Tunables.Global_262145.Value<int>("f_24371") != 1/* Tunable: ENABLE_SERRANO */)
                        return false;
                    break;
                case VehicleHash.BJXL:
                    if (Tunables.Global_262145.Value<int>("f_24372") != 1/* Tunable: ENABLE_BEEJAY_XL */)
                        return false;
                    break;
                case VehicleHash.Habanero:
                    if (Tunables.Global_262145.Value<int>("f_24375") != 1/* Tunable: ENABLE_HABANERO */)
                        return false;
                    break;
                case VehicleHash.FQ2:
                    if (Tunables.Global_262145.Value<int>("f_24373") != 1/* Tunable: ENABLE_FQ2 */)
                        return false;
                    break;
                case VehicleHash.Patriot:
                    if (Tunables.Global_262145.Value<int>("f_24374") != 1/* Tunable: ENABLE_PATRIOT */)
                        return false;
                    break;
                case /*Monster3*/ (VehicleHash)1721676810:
                    break;
                case /*Cerberus*/ (VehicleHash)3493417227:
                    break;
                case /*Cerberus2*/ (VehicleHash)679453769:
                    break;
                case /*Cerberus3*/ (VehicleHash)1909700336:
                    break;
                case /*Brutus*/ (VehicleHash)2139203625:
                    break;
                case /*Brutus2*/ (VehicleHash)2403970600:
                    break;
                case /*Brutus3*/ (VehicleHash)2038858402:
                    break;
                case /*Scarab*/ (VehicleHash)3147997943:
                    break;
                case /*Scarab2*/ (VehicleHash)1542143200:
                    break;
                case /*Scarab3*/ (VehicleHash)3715219435:
                    break;
                case /*Imperator*/ (VehicleHash)444994115:
                    break;
                case /*Imperator2*/ (VehicleHash)1637620610:
                    break;
                case /*Imperator3*/ (VehicleHash)3539435063:
                    break;
                case /*Zr380*/ (VehicleHash)540101442:
                    break;
                case /*Zr3802*/ (VehicleHash)3188846534:
                    break;
                case /*Zr3803*/ (VehicleHash)2816263004:
                    break;
                case /*Impaler*/ (VehicleHash)2198276962:
                    break;
                case /*Toros*/ (VehicleHash)3126015148:
                    if (Tunables.Global_262145.Value<int>("f_25969") != 1/* Tunable: ENABLE_VEHICLE_TOROS */)
                        return false;
                    break;
                case /*Clique*/ (VehicleHash)2728360112:
                    if (Tunables.Global_262145.Value<int>("f_25970") != 1/* Tunable: ENABLE_VEHICLE_CLIQUE */)
                        return false;
                    break;
                case /*ItaliGTo*/ (VehicleHash)3963499524:
                    if (Tunables.Global_262145.Value<int>("f_25971") != 1/* Tunable: ENABLE_VEHICLE_ITALIGTO */)
                        return false;
                    break;
                case /*Deviant*/ (VehicleHash)1279262537:
                    if (Tunables.Global_262145.Value<int>("f_25972") != 1/* Tunable: ENABLE_VEHICLE_DEVIANT */)
                        return false;
                    break;
                case /*Deveste*/ (VehicleHash)1591739866:
                    if (Tunables.Global_262145.Value<int>("f_26956") != 1/* Tunable: ENABLE_VEHICLE_DEVESTE */)
                        return false;
                    break;
                case /*Vamos*/ (VehicleHash)4245851645:
                    if (Tunables.Global_262145.Value<int>("f_26957") != 1/* Tunable: ENABLE_VEHICLE_VAMOS */)
                        return false;
                    break;
                case /*Tulip*/ (VehicleHash)1456744817:
                    if (Tunables.Global_262145.Value<int>("f_25973") != 1/* Tunable: ENABLE_VEHICLE_TULIP */)
                        return false;
                    break;
                case /*Schlagen*/ (VehicleHash)3787471536:
                    if (Tunables.Global_262145.Value<int>("f_25974") != 1/* Tunable: ENABLE_VEHICLE_SCHLAGEN */)
                        return false;
                    break;
                case /*Rcbandito*/ (VehicleHash)4008920556:
                    if (Tunables.Global_262145.Value<int>("f_25975") != 1/* Tunable: ENABLE_VEHICLE_BANDITO */)
                        return false;
                    break;
                case VehicleHash.Blista3:
                    if (Tunables.Global_262145.Value<int>("f_26816") == 1 /* Tunable: 732191263 */)
                        return false;
                    break;
                case /*Thrax*/ (VehicleHash)1044193113:
                    if (Tunables.Global_262145.Value<int>("f_25980") != 1/* Tunable: ENABLE_VEHICLE_THRAX */)
                        return false;
                    break;
                case /*Drafter*/ (VehicleHash)686471183:
                    if (Tunables.Global_262145.Value<int>("f_25981") != 1/* Tunable: ENABLE_VEHICLE_DRAFTER */)
                        return false;
                    break;
                case /*Locust*/ (VehicleHash)3353694737:
                    if (Tunables.Global_262145.Value<int>("f_25982") != 1/* Tunable: ENABLE_VEHICLE_LOCUST */)
                        return false;
                    break;
                case /*Novak*/ (VehicleHash)2465530446:
                    if (Tunables.Global_262145.Value<int>("f_25983") != 1/* Tunable: ENABLE_VEHICLE_NOVAK */)
                        return false;
                    break;
                case /*Zorrusso*/ (VehicleHash)3612858749:
                    if (Tunables.Global_262145.Value<int>("f_25984") != 1/* Tunable: ENABLE_VEHICLE_ZORRUSSO */)
                        return false;
                    break;
                case /*Gauntlet3*/ (VehicleHash)722226637:
                    if (Tunables.Global_262145.Value<int>("f_25985") != 1/* Tunable: ENABLE_VEHICLE_GAUNTLET3 */)
                        return false;
                    break;
                case /*Issi7*/ (VehicleHash)1854776567:
                    if (Tunables.Global_262145.Value<int>("f_25986") != 1/* Tunable: ENABLE_VEHICLE_ISSI7 */)
                        return false;
                    break;
                case /*Zion3*/ (VehicleHash)1862507111:
                    if (Tunables.Global_262145.Value<int>("f_25987") != 1/* Tunable: ENABLE_VEHICLE_ZION3 */)
                        return false;
                    break;
                case /*Nebula*/ (VehicleHash)3412338231:
                    if (Tunables.Global_262145.Value<int>("f_25988") != 1/* Tunable: ENABLE_VEHICLE_NEBULA */)
                        return false;
                    break;
                case /*Hellion*/ (VehicleHash)3932816511:
                    if (Tunables.Global_262145.Value<int>("f_25989") != 1/* Tunable: ENABLE_VEHICLE_HELLION */)
                        return false;
                    break;
                case /*Dynasty*/ (VehicleHash)310284501:
                    if (Tunables.Global_262145.Value<int>("f_25990") != 1/* Tunable: ENABLE_VEHICLE_DYNASTY */)
                        return false;
                    break;
                case /*Rrocket*/ (VehicleHash)916547552:
                    if (Tunables.Global_262145.Value<int>("f_25991") != 1/* Tunable: ENABLE_VEHICLE_RROCKET */)
                        return false;
                    break;
                case /*Peyote2*/ (VehicleHash)2490551588:
                    if (Tunables.Global_262145.Value<int>("f_25992") != 1/* Tunable: ENABLE_VEHICLE_PEYOTE2 */)
                        return false;
                    break;
                case /*Gauntlet4*/ (VehicleHash)1934384720:
                    if (Tunables.Global_262145.Value<int>("f_25993") != 1/* Tunable: ENABLE_VEHICLE_GAUNTLET4 */)
                        return false;
                    break;
                case /*Caracara2*/ (VehicleHash)2945871676:
                    if (Tunables.Global_262145.Value<int>("f_25994") != 1/* Tunable: ENABLE_VEHICLE_CARACARA2 */)
                        return false;
                    break;
                case /*Jugular*/ (VehicleHash)4086055493:
                    if (Tunables.Global_262145.Value<int>("f_25995") != 1/* Tunable: ENABLE_VEHICLE_JUGULAR */)
                        return false;
                    break;
                case /*S80*/ (VehicleHash)3970348707:
                    if (Tunables.Global_262145.Value<int>("f_25996") != 1/* Tunable: ENABLE_VEHICLE_S80 */)
                        return false;
                    break;
                case /*Krieger*/ (VehicleHash)3630826055:
                    if (Tunables.Global_262145.Value<int>("f_25997") != 1/* Tunable: ENABLE_VEHICLE_KRIEGER */)
                        return false;
                    break;
                case /*Emerus*/ (VehicleHash)1323778901:
                    if (Tunables.Global_262145.Value<int>("f_25998") != 1/* Tunable: ENABLE_VEHICLE_EMERUS */)
                        return false;
                    break;
                case /*Neo*/ (VehicleHash)2674840994:
                    if (Tunables.Global_262145.Value<int>("f_25999") != 1/* Tunable: ENABLE_VEHICLE_NEO */)
                        return false;
                    break;
                case /*Paragon*/ (VehicleHash)3847255899:
                    if (Tunables.Global_262145.Value<int>("f_26000") != 1/* Tunable: ENABLE_VEHICLE_PARAGON */)
                        return false;
                    break;
                case /*Asbo*/ (VehicleHash)1118611807:
                    if (Tunables.Global_262145.Value<int>("f_28820") != 1/* Tunable: ENABLE_VEHICLE_ASBO */)
                        return false;
                    break;
                case /*Kanjo*/ (VehicleHash)409049982:
                    if (Tunables.Global_262145.Value<int>("f_28821") != 1/* Tunable: ENABLE_VEHICLE_KANJO */)
                        return false;
                    break;
                case /*Everon*/ (VehicleHash)2538945576:
                    if (Tunables.Global_262145.Value<int>("f_28822") != 1/* Tunable: ENABLE_VEHICLE_EVERON */)
                        return false;
                    break;
                case /*Retinue2*/ (VehicleHash)2031587082:
                    if (Tunables.Global_262145.Value<int>("f_28823") != 1/* Tunable: ENABLE_VEHICLE_RETINUE2 */)
                        return false;
                    break;
                case /*Yosemite2*/ (VehicleHash)1693751655:
                    if (Tunables.Global_262145.Value<int>("f_28824") != 1/* Tunable: ENABLE_VEHICLE_YOSEMITE2 */)
                        return false;
                    break;
                case /*Sugoi*/ (VehicleHash)987469656:
                    if (Tunables.Global_262145.Value<int>("f_28825") != 1/* Tunable: ENABLE_VEHICLE_SUGOI */)
                        return false;
                    break;
                case /*Sultan2*/ (VehicleHash)872704284:
                    if (Tunables.Global_262145.Value<int>("f_28826") != 1/* Tunable: ENABLE_VEHICLE_SULTAN2 */)
                        return false;
                    break;
                case /*Outlaw*/ (VehicleHash)408825843:
                    if (Tunables.Global_262145.Value<int>("f_28827") != 1/* Tunable: ENABLE_VEHICLE_OUTLAW */)
                        return false;
                    break;
                case /*Vagrant*/ (VehicleHash)740289177:
                    if (Tunables.Global_262145.Value<int>("f_28828") != 1/* Tunable: ENABLE_VEHICLE_VAGRANT */)
                        return false;
                    break;
                case /*Komoda*/ (VehicleHash)3460613305:
                    if (Tunables.Global_262145.Value<int>("f_28829") != 1/* Tunable: ENABLE_VEHICLE_KOMODA */)
                        return false;
                    break;
                case /*Stryder*/ (VehicleHash)301304410:
                    if (Tunables.Global_262145.Value<int>("f_28830") != 1/* Tunable: ENABLE_VEHICLE_STRYDER */)
                        return false;
                    break;
                case /*Furia*/ (VehicleHash)960812448:
                    if (Tunables.Global_262145.Value<int>("f_28831") != 1/* Tunable: ENABLE_VEHICLE_FURIA */)
                        return false;
                    break;
                case /*Zhaba*/ (VehicleHash)1284356689:
                    if (Tunables.Global_262145.Value<int>("f_28832") != 1/* Tunable: ENABLE_VEHICLE_ZHABA */)
                        return false;
                    break;
                case /*JB7002*/ (VehicleHash)394110044:
                    if (Tunables.Global_262145.Value<int>("f_28833") != 1/* Tunable: ENABLE_VEHICLE_JB7002 */)
                        return false;
                    break;
                case VehicleHash.FireTruk:
                    if (Tunables.Global_262145.Value<int>("f_28834") != 1/* Tunable: ENABLE_VEHICLE_FIRETRUCK */)
                        return false;
                    break;
                case VehicleHash.Burrito2:
                    if (Tunables.Global_262145.Value<int>("f_28835") != 1/* Tunable: ENABLE_VEHICLE_BURRITO2 */)
                        return false;
                    break;
                case VehicleHash.Boxville:
                    if (Tunables.Global_262145.Value<int>("f_28836") != 1/* Tunable: ENABLE_VEHICLE_BOXVILLE */)
                        return false;
                    break;
                case VehicleHash.Stockade:
                    if (Tunables.Global_262145.Value<int>("f_28837") != 1/* Tunable: ENABLE_VEHICLE_STOCKADE */)
                        return false;
                    break;
                case /*Minitank*/ (VehicleHash)3040635986:
                    if (Tunables.Global_262145.Value<int>("f_28838") != 1/* Tunable: ENABLE_VEHICLE_MINITANK */)
                        return false;
                    break;
                case VehicleHash.Lguard:
                    if (Tunables.Global_262145.Value<int>("f_28839") != 1/* Tunable: ENABLE_VEHICLE_LGUARD */)
                        return false;
                    break;
                case VehicleHash.Blazer2:
                    if (Tunables.Global_262145.Value<int>("f_28840") != 1/* Tunable: ENABLE_VEHICLE_BLAZER2 */)
                        return false;
                    break;
                case /*Formula*/ (VehicleHash)340154634:
                    if (Tunables.Global_262145.Value<int>("f_28863") != 1/* Tunable: ENABLE_VEHICLE_FORMULA */)
                        return false;
                    break;
                case /*Formula2*/ (VehicleHash)2334210311:
                    if (Tunables.Global_262145.Value<int>("f_28866") != 1/* Tunable: ENABLE_VEHICLE_FORMULA2 */)
                        return false;
                    break;
                case /*Imorgon*/ (VehicleHash)3162245632:
                    if (Tunables.Global_262145.Value<int>("f_28871") != 1/* Tunable: ENABLE_VEHICLE_IMORGEN */)
                        return false;
                    break;
                case /*Rebla*/ (VehicleHash)83136452:
                    if (Tunables.Global_262145.Value<int>("f_28872") != 1/* Tunable: ENABLE_VEHICLE_REBLA */)
                        return false;
                    break;
                case /*Vstr*/ (VehicleHash)1456336509:
                    if (Tunables.Global_262145.Value<int>("f_28873") != 1/* Tunable: ENABLE_VEHICLE_VSTR */)
                        return false;
                    break;
                case /*Gauntlet5*/ (VehicleHash)2172320429:
                    if (Tunables.Global_262145.Value<int>("f_29889") != 1/* Tunable: ENABLE_VEH_GAUNTLET5 */)
                        return false;
                    break;
                case /*Club*/ (VehicleHash)2196012677:
                    if (Tunables.Global_262145.Value<int>("f_29540") != 1/* Tunable: ENABLE_VEH_CLUB */)
                        return false;
                    break;
                case /*Dukes3*/ (VehicleHash)2134119907:
                    if (Tunables.Global_262145.Value<int>("f_29541") != 1/* Tunable: ENABLE_VEH_DUKES3 */)
                        return false;
                    break;
                case /*Yosemite3*/ (VehicleHash)67753863:
                    if (Tunables.Global_262145.Value<int>("f_29887") != 1/* Tunable: ENABLE_VEH_YOSEMITE3 */)
                        return false;
                    break;
                case /*Peyote3*/ (VehicleHash)1107404867:
                    if (Tunables.Global_262145.Value<int>("f_29888") != 1/* Tunable: ENABLE_VEH_PEYOTE3 */)
                        return false;
                    break;
                case /*Glendale2*/ (VehicleHash)3381377750:
                    if (Tunables.Global_262145.Value<int>("f_29534") != 1/* Tunable: ENABLE_VEH_GLENDALE2 */)
                        return false;
                    break;
                case /*Penumbra2*/ (VehicleHash)3663644634:
                    if (Tunables.Global_262145.Value<int>("f_29535") != 1/* Tunable: ENABLE_VEH_PENUMBRA2 */)
                        return false;
                    break;
                case /*Landstalker2*/ (VehicleHash)3456868130:
                    if (Tunables.Global_262145.Value<int>("f_29536") != 1/* Tunable: ENABLE_VEH_LANDSTALKER2 */)
                        return false;
                    break;
                case /*Seminole2*/ (VehicleHash)2484160806:
                    if (Tunables.Global_262145.Value<int>("f_29537") != 1/* Tunable: ENABLE_VEH_SEMINOLE2 */)
                        return false;
                    break;
                case /*Tigon*/ (VehicleHash)2936769864:
                    if (Tunables.Global_262145.Value<int>("f_29883") != 1/* Tunable: ENABLE_VEH_TIGON */)
                        return false;
                    break;
                case /*Openwheel1*/ (VehicleHash)1492612435:
                    if (Tunables.Global_262145.Value<int>("f_29884") != 1/* Tunable: ENABLE_VEH_OPENWHEEL1 */)
                        return false;
                    break;
                case /*Openwheel2*/ (VehicleHash)1181339704:
                    if (Tunables.Global_262145.Value<int>("f_29885") != 1/* Tunable: ENABLE_VEH_OPENWHEEL2 */)
                        return false;
                    break;
                case /*Coquette4*/ (VehicleHash)2566281822:
                    if (Tunables.Global_262145.Value<int>("f_29886") != 1/* Tunable: ENABLE_VEH_COQUETTE4 */)
                        return false;
                    break;
                case /*Manana2*/ (VehicleHash)1717532765:
                    if (Tunables.Global_262145.Value<int>("f_29538") != 1/* Tunable: ENABLE_VEH_MANANA2 */)
                        return false;
                    break;
                case /*Youga3*/ (VehicleHash)1802742206:
                    if (Tunables.Global_262145.Value<int>("f_29539") != 1/* Tunable: ENABLE_VEH_YOUGA3 */)
                        return false;
                    break;
                case /*Toreador*/ (VehicleHash)1455990255:
                    if (Tunables.Global_262145.Value<int>("f_30348") != 1/* Tunable: ENABLE_VEHICLE_TOREADOR */)
                        return false;
                    break;
                case /*Annihilator2*/ (VehicleHash)295054921:
                    if (Tunables.Global_262145.Value<int>("f_30349") != 1/* Tunable: ENABLE_VEHICLE_ANNIHILATOR2 */)
                        return false;
                    break;
                case /*Alkonost*/ (VehicleHash)3929093893:
                    if (Tunables.Global_262145.Value<int>("f_30350") != 1/* Tunable: ENABLE_VEHICLE_ALKONOST */)
                        return false;
                    break;
                case /*Patrolboat*/ (VehicleHash)4018222598:
                    if (Tunables.Global_262145.Value<int>("f_30351") != 1/* Tunable: ENABLE_VEHICLE_PATROLBOAT */)
                        return false;
                    break;
                case /*Longfin*/ (VehicleHash)1861786828:
                    if (Tunables.Global_262145.Value<int>("f_30352") != 1/* Tunable: ENABLE_VEHICLE_LONGFIN */)
                        return false;
                    break;
                case /*Winky*/ (VehicleHash)4084658662:
                    if (Tunables.Global_262145.Value<int>("f_30353") != 1/* Tunable: ENABLE_VEHICLE_WINKY */)
                        return false;
                    break;
                case /*Veto*/ (VehicleHash)3437611258:
                    if (Tunables.Global_262145.Value<int>("f_30354") != 1/* Tunable: ENABLE_VEHICLE_VETO */)
                        return false;
                    break;
                case /*Veto2*/ (VehicleHash)2802050217:
                    if (Tunables.Global_262145.Value<int>("f_30355") != 1/* Tunable: ENABLE_VEHICLE_VETO2 */)
                        return false;
                    break;
                case /*ItaliRSx*/ (VehicleHash)3145241962:
                    if (Tunables.Global_262145.Value<int>("f_30356") != 1/* Tunable: ENABLE_VEHICLE_ITALIRSX */)
                        return false;
                    break;
                case /*Weevil*/ (VehicleHash)1644055914:
                    if (Tunables.Global_262145.Value<int>("f_30357") != 1/* Tunable: ENABLE_VEHICLE_WEEVIL */)
                        return false;
                    break;
                case /*Manchez2*/ (VehicleHash)1086534307:
                    if (Tunables.Global_262145.Value<int>("f_30358") != 1/* Tunable: ENABLE_VEHICLE_MANCHEZ2 */)
                        return false;
                    break;
                case /*SlamTruck*/ (VehicleHash)3249056020:
                    if (Tunables.Global_262145.Value<int>("f_30359") != 1/* Tunable: ENABLE_VEHICLE_SLAMTRUCK */)
                        return false;
                    break;
                case /*Vetir*/ (VehicleHash)2014313426:
                    if (Tunables.Global_262145.Value<int>("f_30360") != 1/* Tunable: ENABLE_VEHICLE_VETIR */)
                        return false;
                    break;
                case /*Squaddie*/ (VehicleHash)4192631813:
                    if (Tunables.Global_262145.Value<int>("f_30361") != 1/* Tunable: ENABLE_VEHICLE_SQUADDIE */)
                        return false;
                    break;
                case /*Brioso2*/ (VehicleHash)1429622905:
                    if (Tunables.Global_262145.Value<int>("f_30362") != 1/* Tunable: ENABLE_VEHICLE_BRIOSO2 */)
                        return false;
                    break;
                case /*Dinghy5*/ (VehicleHash)3314393930:
                    if (Tunables.Global_262145.Value<int>("f_30363") != 1/* Tunable: ENABLE_VEHICLE_DINGY5 */)
                        return false;
                    break;
                case /*Verus*/ (VehicleHash)298565713:
                    if (Tunables.Global_262145.Value<int>("f_30364") != 1/* Tunable: ENABLE_VEHICLE_VERUS */)
                        return false;
                    break;
                case /*Baller7*/ (VehicleHash)359875117:
                    if (Tunables.Global_262145.Value<int>("f_32113") != 1/* Tunable: ENABLE_VEHICLE_BALLER7 */)
                        return false;
                    break;
                case /*Shinobi*/ (VehicleHash)1353120668:
                    if (Tunables.Global_262145.Value<int>("f_32112") != 1/* Tunable: ENABLE_VEHICLE_SHINOBI */)
                        return false;
                    break;
                case /*Patriot3*/ (VehicleHash)3624880708:
                    if (Tunables.Global_262145.Value<int>("f_32111") != 1/* Tunable: ENABLE_VEHICLE_PATRIOT3 */)
                        return false;
                    break;
                case /*Granger2*/ (VehicleHash)4033620423:
                    if (Tunables.Global_262145.Value<int>("f_32110") != 1/* Tunable: ENABLE_VEHICLE_GRANGER2 */)
                        return false;
                    break;
                case /*Iwagen*/ (VehicleHash)662793086:
                    if (Tunables.Global_262145.Value<int>("f_32109") != 1/* Tunable: ENABLE_VEHICLE_IWAGEN */)
                        return false;
                    break;
                case /*Reever*/ (VehicleHash)1993851908:
                    if (Tunables.Global_262145.Value<int>("f_32108") != 1/* Tunable: ENABLE_VEHICLE_REEVER */)
                        return false;
                    break;
                case /*Zeno*/ (VehicleHash)655665811:
                    if (Tunables.Global_262145.Value<int>("f_32107") != 1/* Tunable: ENABLE_VEHICLE_ZENO */)
                        return false;
                    break;
                case /*Comet7*/ (VehicleHash)1141395928:
                    if (Tunables.Global_262145.Value<int>("f_32106") != 1/* Tunable: ENABLE_VEHICLE_COMET7 */)
                        return false;
                    break;
                case /*Astron*/ (VehicleHash)629969764:
                    if (Tunables.Global_262145.Value<int>("f_32105") != 1/* Tunable: ENABLE_VEHICLE_ASTRON */)
                        return false;
                    break;
                case /*Cinquemila*/ (VehicleHash)2767531027:
                    if (Tunables.Global_262145.Value<int>("f_32104") != 1/* Tunable: ENABLE_VEHICLE_CINQUEMILA */)
                        return false;
                    break;
                case /*Ignus*/ (VehicleHash)2850852987:
                    if (Tunables.Global_262145.Value<int>("f_32103") != 1/* Tunable: ENABLE_VEHICLE_IGNUS */)
                        return false;
                    break;
                case /*Jubilee*/ (VehicleHash)461465043:
                    if (Tunables.Global_262145.Value<int>("f_32102") != 1/* Tunable: ENABLE_VEHICLE_JUBILEE */)
                        return false;
                    break;
                case /*Deity*/ (VehicleHash)1532171089:
                    if (Tunables.Global_262145.Value<int>("f_32101") != 1/* Tunable: ENABLE_VEHICLE_DEITY */)
                        return false;
                    break;
                case /*Buffalo4*/ (VehicleHash)3675036420:
                    if (Tunables.Global_262145.Value<int>("f_32100") != 1/* Tunable: ENABLE_VEHICLE_BUFFALO4 */)
                        return false;
                    break;
                case /*Champion*/ (VehicleHash)3379732821:
                    if (Tunables.Global_262145.Value<int>("f_32099") != 1/* Tunable: ENABLE_VEHICLE_CHAMPION */)
                        return false;
                    break;
                case /*OmniseGT*/ (VehicleHash)3789743831:
                    if (Tunables.Global_262145.Value<int>("f_33341") != 1/* Tunable: ENABLE_VEHICLE_OMNISEGT */)
                        return false;
                    break;
                case /*Greenwood*/ (VehicleHash)40817712:
                    if (Tunables.Global_262145.Value<int>("f_33342") != 1/* Tunable: ENABLE_VEHICLE_GREENWOOD */)
                        return false;
                    break;
                case /*Torero2*/ (VehicleHash)4129572538:
                    if (Tunables.Global_262145.Value<int>("f_33343") != 1/* Tunable: ENABLE_VEHICLE_TORERO2 */)
                        return false;
                    break;
                case /*CoRSita*/ (VehicleHash)3540279623:
                    if (Tunables.Global_262145.Value<int>("f_33344") != 1/* Tunable: ENABLE_VEHICLE_CORSITA */)
                        return false;
                    break;
                case /*Lm87*/ (VehicleHash)4284049613:
                    if (Tunables.Global_262145.Value<int>("f_33345") != 1/* Tunable: ENABLE_VEHICLE_LM87 */)
                        return false;
                    break;
                case /*Conada*/ (VehicleHash)3817135397:
                    if (Tunables.Global_262145.Value<int>("f_33346") != 1/* Tunable: ENABLE_VEHICLE_CONADA */)
                        return false;
                    break;
                case /*Sm722*/ (VehicleHash)775514032:
                    if (Tunables.Global_262145.Value<int>("f_33347") != 1/* Tunable: ENABLE_VEHICLE_SM722 */)
                        return false;
                    break;
                case /*Draugur*/ (VehicleHash)3526730918:
                    if (Tunables.Global_262145.Value<int>("f_33348") != 1/* Tunable: ENABLE_VEHICLE_DRAUGUR */)
                        return false;
                    break;
                case /*Ruiner4*/ (VehicleHash)1706945532:
                    if (Tunables.Global_262145.Value<int>("f_33349") != 1/* Tunable: ENABLE_VEHICLE_RUINER4 */)
                        return false;
                    break;
                case /*Brioso3*/ (VehicleHash)15214558:
                    if (Tunables.Global_262145.Value<int>("f_33350") != 1/* Tunable: ENABLE_VEHICLE_BRIOSO3 */)
                        return false;
                    break;
                case /*Vigero2*/ (VehicleHash)2536587772:
                    if (Tunables.Global_262145.Value<int>("f_33351") != 1/* Tunable: ENABLE_VEHICLE_VIGERO2 */)
                        return false;
                    break;
                case /*Kanjosj*/ (VehicleHash)4230891418:
                    if (Tunables.Global_262145.Value<int>("f_33353") != 1/* Tunable: ENABLE_VEHICLE_KANJOSJ */)
                        return false;
                    break;
                case /*Postlude*/ (VehicleHash)4000288633:
                    if (Tunables.Global_262145.Value<int>("f_33354") != 1/* Tunable: ENABLE_VEHICLE_POSTLUDE */)
                        return false;
                    break;
                case /*Tenf*/ (VehicleHash)3400983137:
                    if (Tunables.Global_262145.Value<int>("f_33355") != 1/* Tunable: ENABLE_VEHICLE_TENF */)
                        return false;
                    break;
                case /*Rhinehart*/ (VehicleHash)2439462158:
                    if (Tunables.Global_262145.Value<int>("f_33356") != 1/* Tunable: ENABLE_VEHICLE_RHINEHART */)
                        return false;
                    break;
                case /*Weevil2*/ (VehicleHash)3300595976:
                    if (Tunables.Global_262145.Value<int>("f_33357") != 1/* Tunable: ENABLE_VEHICLE_WEEVIL2 */)
                        return false;
                    break;
                case /*Tenf2*/ (VehicleHash)274946574:
                    if (Tunables.Global_262145.Value<int>("f_33358") != 1/* Tunable: ENABLE_VEHICLE_TENF2 */)
                        return false;
                    break;
                case /*Sentinel4*/ (VehicleHash)2938086457:
                    if (Tunables.Global_262145.Value<int>("f_33359") != 1/* Tunable: ENABLE_VEHICLE_SENTINEL4 */)
                        return false;
                    break;
                case /*Brickade2*/ (VehicleHash)2718380883:
                    if (Tunables.Global_262145.Value<int>("f_34217") != 1/* Tunable: ENABLE_VEHICLE_BRICKADE2 */)
                        return false;
                    break;
                case /*Entity3*/ (VehicleHash)1748565021:
                    if (Tunables.Global_262145.Value<int>("f_34212") != 1/* Tunable: ENABLE_VEHICLE_ENTITY3 */)
                        return false;
                    break;
                case /*Journey2*/ (VehicleHash)2667889793:
                    if (Tunables.Global_262145.Value<int>("f_34214") != 1/* Tunable: ENABLE_VEHICLE_JOURNEY2 */)
                        return false;
                    break;
                case /*Surfer3*/ (VehicleHash)3259477733:
                    if (Tunables.Global_262145.Value<int>("f_34215") != 1/* Tunable: ENABLE_VEHICLE_SURFER3 */)
                        return false;
                    break;
                case /*R300*/ (VehicleHash)1076201208:
                    if (Tunables.Global_262145.Value<int>("f_34216") != 1/* Tunable: ENABLE_VEHICLE_R300 */)
                        return false;
                    break;
                case /*Tahoma*/ (VehicleHash)3833117047:
                    if (Tunables.Global_262145.Value<int>("f_34219") != 1/* Tunable: ENABLE_VEHICLE_TAHOMA */)
                        return false;
                    break;
                case /*PoweRSurge*/ (VehicleHash)2908631255:
                    if (Tunables.Global_262145.Value<int>("f_34220") != 1/* Tunable: ENABLE_VEHICLE_POWERSURGE */)
                        return false;
                    break;
                case /*Issi8*/ (VehicleHash)1550581940:
                    if (Tunables.Global_262145.Value<int>("f_34221") != 1/* Tunable: ENABLE_VEHICLE_ISSI8 */)
                        return false;
                    break;
                case /*Broadway*/ (VehicleHash)2361724968:
                    if (Tunables.Global_262145.Value<int>("f_34222") != 1/* Tunable: ENABLE_VEHICLE_BROADWAY */)
                        return false;
                    break;
                case /*Panthere*/ (VehicleHash)2100457220:
                    if (Tunables.Global_262145.Value<int>("f_34223") != 1/* Tunable: ENABLE_VEHICLE_PANTHERE */)
                        return false;
                    break;
                case /*Everon2*/ (VehicleHash)4163619118:
                    if (Tunables.Global_262145.Value<int>("f_34224") != 1/* Tunable: ENABLE_VEHICLE_EVERON2 */)
                        return false;
                    break;
                case /*Virtue*/ (VehicleHash)669204833:
                    if (Tunables.Global_262145.Value<int>("f_34225") != 1/* Tunable: ENABLE_VEHICLE_VIRTUE */)
                        return false;
                    break;
                case /*Eudora*/ (VehicleHash)3045179290:
                    if (Tunables.Global_262145.Value<int>("f_34226") != 1/* Tunable: ENABLE_VEHICLE_EUDORA */)
                        return false;
                    break;
                case /*Boor*/ (VehicleHash)996383885:
                    if (Tunables.Global_262145.Value<int>("f_34227") != 1/* Tunable: ENABLE_VEHICLE_BOOR */)
                        return false;
                    break;
                case VehicleHash.Taxi:
                    if (Tunables.Global_262145.Value<int>("f_34218") != 1/* Tunable: ENABLE_VEHICLE_TAXI */)
                        return false;
                    break;
            }
            switch ((VehicleHash)iParam1)
            {
                case VehicleHash.Exemplar:
                    if (Tunables.Global_262145.Value<int>("f_35167") != 1/* Tunable: ENABLE_VEHICLE_EXEMPLAR */)
                        return false;
                    break;
                case VehicleHash.CogCabrio:
                    if (Tunables.Global_262145.Value<int>("f_35169") != 1/* Tunable: ENABLE_VEHICLE_COGCABRIO */)
                        return false;
                    break;
                case VehicleHash.Thrust:
                    if (Tunables.Global_262145.Value<int>("f_35171") != 1/* Tunable: ENABLE_VEHICLE_THRUST */)
                        return false;
                    break;
                case VehicleHash.Vindicator:
                    if (Tunables.Global_262145.Value<int>("f_35173") != 1/* Tunable: ENABLE_VEHICLE_VINDICATOR */)
                        return false;
                    break;
                case VehicleHash.Coquette3:
                    if (Tunables.Global_262145.Value<int>("f_35175") != 1/* Tunable: ENABLE_VEHICLE_COQUETTE3 */)
                        return false;
                    break;
                case VehicleHash.Brawler:
                    if (Tunables.Global_262145.Value<int>("f_35177") != 1/* Tunable: ENABLE_VEHICLE_BRAWLER */)
                        return false;
                    break;
                case VehicleHash.Cognoscenti:
                    if (Tunables.Global_262145.Value<int>("f_35179") != 1/* Tunable: ENABLE_VEHICLE_COGNOSCENTI */)
                        return false;
                    break;
                case VehicleHash.Cognoscenti2:
                    if (Tunables.Global_262145.Value<int>("f_35181") != 1/* Tunable: ENABLE_VEHICLE_COGNOSCENTI2 */)
                        return false;
                    break;
                case VehicleHash.Cog55:
                    if (Tunables.Global_262145.Value<int>("f_35183") != 1/* Tunable: ENABLE_VEHICLE_COG55 */)
                        return false;
                    break;
                case VehicleHash.Cog552:
                    if (Tunables.Global_262145.Value<int>("f_35185") != 1/* Tunable: ENABLE_VEHICLE_COG552 */)
                        return false;
                    break;
                case VehicleHash.Superd:
                    if (Tunables.Global_262145.Value<int>("f_35187") != 1/* Tunable: ENABLE_VEHICLE_SUPERD */)
                        return false;
                    break;
                case VehicleHash.Schafter4:
                    if (Tunables.Global_262145.Value<int>("f_35189") != 1/* Tunable: ENABLE_VEHICLE_SCHAFTER4 */)
                        return false;
                    break;
                case VehicleHash.Schafter6:
                    if (Tunables.Global_262145.Value<int>("f_35191") != 1/* Tunable: ENABLE_VEHICLE_SCHAFTER6 */)
                        return false;
                    break;
                case VehicleHash.Alpha:
                    if (Tunables.Global_262145.Value<int>("f_35193") != 1/* Tunable: ENABLE_VEHICLE_ALPHA */)
                        return false;
                    break;
                case VehicleHash.Feltzer2:
                    if (Tunables.Global_262145.Value<int>("f_35195") != 1/* Tunable: ENABLE_VEHICLE_FELTZER2 */)
                        return false;
                    break;
                case VehicleHash.Massacro:
                    if (Tunables.Global_262145.Value<int>("f_35197") != 1/* Tunable: ENABLE_VEHICLE_MASSACRO */)
                        return false;
                    break;
                case VehicleHash.RapidGT:
                    if (Tunables.Global_262145.Value<int>("f_35199") != 1/* Tunable: ENABLE_VEHICLE_RAPIDGT */)
                        return false;
                    break;
                case VehicleHash.RapidGT2:
                    if (Tunables.Global_262145.Value<int>("f_35201") != 1/* Tunable: ENABLE_VEHICLE_RAPIDGT2 */)
                        return false;
                    break;
                case VehicleHash.Seven70:
                    if (Tunables.Global_262145.Value<int>("f_35203") != 1/* Tunable: ENABLE_VEHICLE_SEVEN70 */)
                        return false;
                    break;
                case VehicleHash.Jester:
                    if (Tunables.Global_262145.Value<int>("f_35205") != 1/* Tunable: ENABLE_VEHICLE_JESTER */)
                        return false;
                    break;
                case VehicleHash.BestiaGTS:
                    if (Tunables.Global_262145.Value<int>("f_35207") != 1/* Tunable: ENABLE_VEHICLE_BESTIAGTS */)
                        return false;
                    break;
                case VehicleHash.Carbonizzare:
                    if (Tunables.Global_262145.Value<int>("f_35209") != 1/* Tunable: ENABLE_VEHICLE_CARBONIZZARE */)
                        return false;
                    break;
                case VehicleHash.Coquette:
                    if (Tunables.Global_262145.Value<int>("f_35211") != 1/* Tunable: ENABLE_VEHICLE_COQUETTE */)
                        return false;
                    break;
                case VehicleHash.Furoregt:
                    if (Tunables.Global_262145.Value<int>("f_35213") != 1/* Tunable: ENABLE_VEHICLE_FUROREGT */)
                        return false;
                    break;
                case VehicleHash.Ninef:
                    if (Tunables.Global_262145.Value<int>("f_35215") != 1/* Tunable: ENABLE_VEHICLE_NINEF */)
                        return false;
                    break;
                case VehicleHash.Ninef2:
                    if (Tunables.Global_262145.Value<int>("f_35217") != 1/* Tunable: ENABLE_VEHICLE_NINEF2 */)
                        return false;
                    break;
                case VehicleHash.Verlierer2:
                    if (Tunables.Global_262145.Value<int>("f_35219") != 1/* Tunable: ENABLE_VEHICLE_VERLIERER2 */)
                        return false;
                    break;
                case VehicleHash.BType:
                    if (Tunables.Global_262145.Value<int>("f_35221") != 1/* Tunable: ENABLE_VEHICLE_BTYPE */)
                        return false;
                    break;
                case VehicleHash.Feltzer3:
                    if (Tunables.Global_262145.Value<int>("f_35223") != 1/* Tunable: ENABLE_VEHICLE_FELTZER3 */)
                        return false;
                    break;
                case VehicleHash.StingerGT:
                    if (Tunables.Global_262145.Value<int>("f_35225") != 1/* Tunable: ENABLE_VEHICLE_STINGERGT */)
                        return false;
                    break;
                case VehicleHash.Stinger:
                    if (Tunables.Global_262145.Value<int>("f_35227") != 1/* Tunable: ENABLE_VEHICLE_STINGER */)
                        return false;
                    break;
                case VehicleHash.Coquette2:
                    if (Tunables.Global_262145.Value<int>("f_35229") != 1/* Tunable: ENABLE_VEHICLE_COQUETTE2 */)
                        return false;
                    break;
                case VehicleHash.JB700:
                    if (Tunables.Global_262145.Value<int>("f_35231") != 1/* Tunable: ENABLE_VEHICLE_JB700 */)
                        return false;
                    break;
                case VehicleHash.Mamba:
                    if (Tunables.Global_262145.Value<int>("f_35233") != 1/* Tunable: ENABLE_VEHICLE_MAMBA */)
                        return false;
                    break;
                case VehicleHash.Monroe:
                    if (Tunables.Global_262145.Value<int>("f_35235") != 1/* Tunable: ENABLE_VEHICLE_MONROE */)
                        return false;
                    break;
                case VehicleHash.BType3:
                    if (Tunables.Global_262145.Value<int>("f_35237") != 1/* Tunable: ENABLE_VEHICLE_BTYPE3 */)
                        return false;
                    break;
                case VehicleHash.ZType:
                    if (Tunables.Global_262145.Value<int>("f_35239") != 1/* Tunable: ENABLE_VEHICLE_ZTYPE */)
                        return false;
                    break;
                case VehicleHash.Voltic:
                    if (Tunables.Global_262145.Value<int>("f_35241") != 1/* Tunable: ENABLE_VEHICLE_VOLTIC */)
                        return false;
                    break;
                case VehicleHash.Sheava:
                    if (Tunables.Global_262145.Value<int>("f_35243") != 1/* Tunable: ENABLE_VEHICLE_SHEAVA */)
                        return false;
                    break;
                case VehicleHash.Cheetah:
                    if (Tunables.Global_262145.Value<int>("f_35245") != 1/* Tunable: ENABLE_VEHICLE_CHEETAH */)
                        return false;
                    break;
                case VehicleHash.EntityXF:
                    if (Tunables.Global_262145.Value<int>("f_35247") != 1/* Tunable: ENABLE_VEHICLE_ENTITYXF */)
                        return false;
                    break;
                case VehicleHash.Infernus:
                    if (Tunables.Global_262145.Value<int>("f_35249") != 1/* Tunable: ENABLE_VEHICLE_INFERNUS */)
                        return false;
                    break;
                case VehicleHash.Vacca:
                    if (Tunables.Global_262145.Value<int>("f_35251") != 1/* Tunable: ENABLE_VEHICLE_VACCA */)
                        return false;
                    break;
                case VehicleHash.Bullet:
                    if (Tunables.Global_262145.Value<int>("f_35253") != 1/* Tunable: ENABLE_VEHICLE_BULLET */)
                        return false;
                    break;
                case VehicleHash.FMJ:
                    if (Tunables.Global_262145.Value<int>("f_35255") != 1/* Tunable: ENABLE_VEHICLE_FMJ */)
                        return false;
                    break;
                case VehicleHash.Baller2:
                    if (Tunables.Global_262145.Value<int>("f_35257") != 1/* Tunable: ENABLE_VEHICLE_BALLER2 */)
                        return false;
                    break;
                case VehicleHash.Baller3:
                    if (Tunables.Global_262145.Value<int>("f_35259") != 1/* Tunable: ENABLE_VEHICLE_BALLER3 */)
                        return false;
                    break;
                case VehicleHash.Baller5:
                    if (Tunables.Global_262145.Value<int>("f_35261") != 1/* Tunable: ENABLE_VEHICLE_BALLER5 */)
                        return false;
                    break;
                case VehicleHash.Baller4:
                    if (Tunables.Global_262145.Value<int>("f_35263") != 1/* Tunable: ENABLE_VEHICLE_BALLER4 */)
                        return false;
                    break;
                case VehicleHash.Baller6:
                    if (Tunables.Global_262145.Value<int>("f_35265") != 1/* Tunable: ENABLE_VEHICLE_BALLER6 */)
                        return false;
                    break;
                case VehicleHash.XLS:
                    if (Tunables.Global_262145.Value<int>("f_35267") != 1/* Tunable: ENABLE_VEHICLE_XLS */)
                        return false;
                    break;
                case VehicleHash.XLS2:
                    if (Tunables.Global_262145.Value<int>("f_35269") != 1/* Tunable: ENABLE_VEHICLE_XLS2 */)
                        return false;
                    break;
                case VehicleHash.Prairie:
                    if (Tunables.Global_262145.Value<int>("f_35271") != 1/* Tunable: ENABLE_VEHICLE_PRAIRIE */)
                        return false;
                    break;
                case VehicleHash.Issi2:
                    if (Tunables.Global_262145.Value<int>("f_35273") != 1/* Tunable: ENABLE_VEHICLE_ISSI2 */)
                        return false;
                    break;
                case VehicleHash.Dilettante:
                    if (Tunables.Global_262145.Value<int>("f_35275") != 1/* Tunable: ENABLE_VEHICLE_DILETTANTE */)
                        return false;
                    break;
                case VehicleHash.Felon:
                    if (Tunables.Global_262145.Value<int>("f_35277") != 1/* Tunable: ENABLE_VEHICLE_FELON */)
                        return false;
                    break;
                case VehicleHash.Felon2:
                    if (Tunables.Global_262145.Value<int>("f_35279") != 1/* Tunable: ENABLE_VEHICLE_FELON2 */)
                        return false;
                    break;
                case VehicleHash.F620:
                    if (Tunables.Global_262145.Value<int>("f_35281") != 1/* Tunable: ENABLE_VEHICLE_F620 */)
                        return false;
                    break;
                case VehicleHash.Jackal:
                    if (Tunables.Global_262145.Value<int>("f_35283") != 1/* Tunable: ENABLE_VEHICLE_JACKAL */)
                        return false;
                    break;
                case VehicleHash.Oracle2:
                    if (Tunables.Global_262145.Value<int>("f_35285") != 1/* Tunable: ENABLE_VEHICLE_ORACLE2 */)
                        return false;
                    break;
                case VehicleHash.Oracle:
                    if (Tunables.Global_262145.Value<int>("f_35287") != 1/* Tunable: ENABLE_VEHICLE_ORACLE */)
                        return false;
                    break;
                case VehicleHash.Sentinel2:
                    if (Tunables.Global_262145.Value<int>("f_35289") != 1/* Tunable: ENABLE_VEHICLE_SENTINEL2 */)
                        return false;
                    break;
                case VehicleHash.Zion:
                    if (Tunables.Global_262145.Value<int>("f_35291") != 1/* Tunable: ENABLE_VEHICLE_ZION */)
                        return false;
                    break;
                case VehicleHash.Zion2:
                    if (Tunables.Global_262145.Value<int>("f_35293") != 1/* Tunable: ENABLE_VEHICLE_ZION2 */)
                        return false;
                    break;
                case VehicleHash.Akuma:
                    if (Tunables.Global_262145.Value<int>("f_35295") != 1/* Tunable: ENABLE_VEHICLE_AKUMA */)
                        return false;
                    break;
                case VehicleHash.Double:
                    if (Tunables.Global_262145.Value<int>("f_35297") != 1/* Tunable: ENABLE_VEHICLE_DOUBLE */)
                        return false;
                    break;
                case VehicleHash.Enduro:
                    if (Tunables.Global_262145.Value<int>("f_35299") != 1/* Tunable: ENABLE_VEHICLE_ENDURO */)
                        return false;
                    break;
                case VehicleHash.Hexer:
                    if (Tunables.Global_262145.Value<int>("f_35301") != 1/* Tunable: ENABLE_VEHICLE_HEXER */)
                        return false;
                    break;
                case VehicleHash.Innovation:
                    if (Tunables.Global_262145.Value<int>("f_35303") != 1/* Tunable: ENABLE_VEHICLE_INNOVATION */)
                        return false;
                    break;
                case VehicleHash.Sanchez:
                    if (Tunables.Global_262145.Value<int>("f_35305") != 1/* Tunable: ENABLE_VEHICLE_SANCHEZ */)
                        return false;
                    break;
                case VehicleHash.Sanchez2:
                    if (Tunables.Global_262145.Value<int>("f_35307") != 1/* Tunable: ENABLE_VEHICLE_SANCHEZ2 */)
                        return false;
                    break;
                case VehicleHash.Bati2:
                    if (Tunables.Global_262145.Value<int>("f_35309") != 1/* Tunable: ENABLE_VEHICLE_BATI2 */)
                        return false;
                    break;
                case VehicleHash.Faggio2:
                    if (Tunables.Global_262145.Value<int>("f_35311") != 1/* Tunable: ENABLE_VEHICLE_FAGGIO2 */)
                        return false;
                    break;
                case VehicleHash.Ruffian:
                    if (Tunables.Global_262145.Value<int>("f_35313") != 1/* Tunable: ENABLE_VEHICLE_RUFFIAN */)
                        return false;
                    break;
                case VehicleHash.Nemesis:
                    if (Tunables.Global_262145.Value<int>("f_35315") != 1/* Tunable: ENABLE_VEHICLE_NEMESIS */)
                        return false;
                    break;
                case VehicleHash.Hakuchou:
                    if (Tunables.Global_262145.Value<int>("f_35317") != 1/* Tunable: ENABLE_VEHICLE_HAKUCHOU */)
                        return false;
                    break;
                case VehicleHash.PCJ:
                    if (Tunables.Global_262145.Value<int>("f_35319") != 1/* Tunable: ENABLE_VEHICLE_PCJ */)
                        return false;
                    break;
                case VehicleHash.Vader:
                    if (Tunables.Global_262145.Value<int>("f_35321") != 1/* Tunable: ENABLE_VEHICLE_VADER */)
                        return false;
                    break;
                case VehicleHash.Sovereign:
                    if (Tunables.Global_262145.Value<int>("f_35323") != 1/* Tunable: ENABLE_VEHICLE_SOVEREIGN */)
                        return false;
                    break;
                case VehicleHash.Gauntlet:
                    if (Tunables.Global_262145.Value<int>("f_35325") != 1/* Tunable: ENABLE_VEHICLE_GAUNTLET */)
                        return false;
                    break;
                case VehicleHash.RatLoader:
                    if (Tunables.Global_262145.Value<int>("f_35327") != 1/* Tunable: ENABLE_VEHICLE_RATLOADER */)
                        return false;
                    break;
                case VehicleHash.Picador:
                    if (Tunables.Global_262145.Value<int>("f_35329") != 1/* Tunable: ENABLE_VEHICLE_PICADOR */)
                        return false;
                    break;
                case VehicleHash.Vigero:
                    if (Tunables.Global_262145.Value<int>("f_35331") != 1/* Tunable: ENABLE_VEHICLE_VIGERO */)
                        return false;
                    break;
                case VehicleHash.Ruiner:
                    if (Tunables.Global_262145.Value<int>("f_35333") != 1/* Tunable: ENABLE_VEHICLE_RUINER */)
                        return false;
                    break;
                case VehicleHash.Tampa:
                    if (Tunables.Global_262145.Value<int>("f_35335") != 1/* Tunable: ENABLE_VEHICLE_TAMPA */)
                        return false;
                    break;
                case VehicleHash.Blade:
                    if (Tunables.Global_262145.Value<int>("f_35337") != 1/* Tunable: ENABLE_VEHICLE_BLADE */)
                        return false;
                    break;
                case VehicleHash.Bifta:
                    if (Tunables.Global_262145.Value<int>("f_35339") != 1/* Tunable: ENABLE_VEHICLE_BIFTA */)
                        return false;
                    break;
                case VehicleHash.Dune:
                    if (Tunables.Global_262145.Value<int>("f_35341") != 1/* Tunable: ENABLE_VEHICLE_DUNE */)
                        return false;
                    break;
                case VehicleHash.BfInjection:
                    if (Tunables.Global_262145.Value<int>("f_35343") != 1/* Tunable: ENABLE_VEHICLE_BFINJECTION */)
                        return false;
                    break;
                case VehicleHash.Bodhi2:
                    if (Tunables.Global_262145.Value<int>("f_35345") != 1/* Tunable: ENABLE_VEHICLE_BODHI2 */)
                        return false;
                    break;
                case VehicleHash.Kalahari:
                    if (Tunables.Global_262145.Value<int>("f_35347") != 1/* Tunable: ENABLE_VEHICLE_KALAHARI */)
                        return false;
                    break;
                case VehicleHash.RancherXL:
                    if (Tunables.Global_262145.Value<int>("f_35349") != 1/* Tunable: ENABLE_VEHICLE_RANCHERXL */)
                        return false;
                    break;
                case VehicleHash.Rebel2:
                    if (Tunables.Global_262145.Value<int>("f_35351") != 1/* Tunable: ENABLE_VEHICLE_REBEL2 */)
                        return false;
                    break;
                case VehicleHash.Rebel:
                    if (Tunables.Global_262145.Value<int>("f_35353") != 1/* Tunable: ENABLE_VEHICLE_REBEL */)
                        return false;
                    break;
                case VehicleHash.Blazer:
                    if (Tunables.Global_262145.Value<int>("f_35355") != 1/* Tunable: ENABLE_VEHICLE_BLAZER */)
                        return false;
                    break;
                case VehicleHash.Blazer3:
                    if (Tunables.Global_262145.Value<int>("f_35357") != 1/* Tunable: ENABLE_VEHICLE_BLAZER3 */)
                        return false;
                    break;
                case VehicleHash.Sandking2:
                    if (Tunables.Global_262145.Value<int>("f_35359") != 1/* Tunable: ENABLE_VEHICLE_SANDKING2 */)
                        return false;
                    break;
                case VehicleHash.Washington:
                    if (Tunables.Global_262145.Value<int>("f_35361") != 1/* Tunable: ENABLE_VEHICLE_WASHINGTON */)
                        return false;
                    break;
                case VehicleHash.Schafter2:
                    if (Tunables.Global_262145.Value<int>("f_35363") != 1/* Tunable: ENABLE_VEHICLE_SCHAFTER2 */)
                        return false;
                    break;
                case VehicleHash.Romero:
                    if (Tunables.Global_262145.Value<int>("f_35365") != 1/* Tunable: ENABLE_VEHICLE_ROMERO */)
                        return false;
                    break;
                case VehicleHash.Fugitive:
                    if (Tunables.Global_262145.Value<int>("f_35367") != 1/* Tunable: ENABLE_VEHICLE_FUGITIVE */)
                        return false;
                    break;
                case VehicleHash.Surge:
                    if (Tunables.Global_262145.Value<int>("f_35369") != 1/* Tunable: ENABLE_VEHICLE_SURGE */)
                        return false;
                    break;
                case VehicleHash.Asea:
                    if (Tunables.Global_262145.Value<int>("f_35371") != 1/* Tunable: ENABLE_VEHICLE_ASEA */)
                        return false;
                    break;
                case VehicleHash.Premier:
                    if (Tunables.Global_262145.Value<int>("f_35373") != 1/* Tunable: ENABLE_VEHICLE_PREMIER */)
                        return false;
                    break;
                case VehicleHash.Regina:
                    if (Tunables.Global_262145.Value<int>("f_35375") != 1/* Tunable: ENABLE_VEHICLE_REGINA */)
                        return false;
                    break;
                case VehicleHash.Asterope:
                    if (Tunables.Global_262145.Value<int>("f_35377") != 1/* Tunable: ENABLE_VEHICLE_ASTEROPE */)
                        return false;
                    break;
                case VehicleHash.Intruder:
                    if (Tunables.Global_262145.Value<int>("f_35379") != 1/* Tunable: ENABLE_VEHICLE_INTRUDER */)
                        return false;
                    break;
                case VehicleHash.Tailgater:
                    if (Tunables.Global_262145.Value<int>("f_35381") != 1/* Tunable: ENABLE_VEHICLE_TAILGATER */)
                        return false;
                    break;
                case VehicleHash.Stanier:
                    if (Tunables.Global_262145.Value<int>("f_35383") != 1/* Tunable: ENABLE_VEHICLE_STANIER */)
                        return false;
                    break;
                case VehicleHash.Ingot:
                    if (Tunables.Global_262145.Value<int>("f_35385") != 1/* Tunable: ENABLE_VEHICLE_INGOT */)
                        return false;
                    break;
                case VehicleHash.Warrener:
                    if (Tunables.Global_262145.Value<int>("f_35387") != 1/* Tunable: ENABLE_VEHICLE_WARRENER */)
                        return false;
                    break;
                case VehicleHash.Stratum:
                    if (Tunables.Global_262145.Value<int>("f_35389") != 1/* Tunable: ENABLE_VEHICLE_STRATUM */)
                        return false;
                    break;
                case VehicleHash.Schwarzer:
                    if (Tunables.Global_262145.Value<int>("f_35391") != 1/* Tunable: ENABLE_VEHICLE_SCHWARZER */)
                        return false;
                    break;
                case VehicleHash.Surano:
                    if (Tunables.Global_262145.Value<int>("f_35393") != 1/* Tunable: ENABLE_VEHICLE_SURANO */)
                        return false;
                    break;
                case VehicleHash.Buffalo:
                    if (Tunables.Global_262145.Value<int>("f_35395") != 1/* Tunable: ENABLE_VEHICLE_BUFFALO */)
                        return false;
                    break;
                case VehicleHash.Buffalo2:
                    if (Tunables.Global_262145.Value<int>("f_35397") != 1/* Tunable: ENABLE_VEHICLE_BUFFALO2 */)
                        return false;
                    break;
                case VehicleHash.Massacro2:
                    if (Tunables.Global_262145.Value<int>("f_35399") != 1/* Tunable: ENABLE_VEHICLE_MASSACRO2 */)
                        return false;
                    break;
                case VehicleHash.Jester2:
                    if (Tunables.Global_262145.Value<int>("f_35401") != 1/* Tunable: ENABLE_VEHICLE_JESTER2 */)
                        return false;
                    break;
                case VehicleHash.Futo:
                    if (Tunables.Global_262145.Value<int>("f_35403") != 1/* Tunable: ENABLE_VEHICLE_FUTO */)
                        return false;
                    break;
                case VehicleHash.Penumbra:
                    if (Tunables.Global_262145.Value<int>("f_35405") != 1/* Tunable: ENABLE_VEHICLE_PENUMBRA */)
                        return false;
                    break;
                case VehicleHash.Fusilade:
                    if (Tunables.Global_262145.Value<int>("f_35407") != 1/* Tunable: ENABLE_VEHICLE_FUSILADE */)
                        return false;
                    break;
                case VehicleHash.BType2:
                    if (Tunables.Global_262145.Value<int>("f_35409") != 1/* Tunable: ENABLE_VEHICLE_BTYPE2 */)
                        return false;
                    break;
                case VehicleHash.Pigalle:
                    if (Tunables.Global_262145.Value<int>("f_35411") != 1/* Tunable: ENABLE_VEHICLE_PIGALLE */)
                        return false;
                    break;
                case VehicleHash.Cavalcade:
                    if (Tunables.Global_262145.Value<int>("f_35413") != 1/* Tunable: ENABLE_VEHICLE_CAVALCADE */)
                        return false;
                    break;
                case VehicleHash.Cavalcade2:
                    if (Tunables.Global_262145.Value<int>("f_35415") != 1/* Tunable: ENABLE_VEHICLE_CAVALCADE2 */)
                        return false;
                    break;
                case VehicleHash.BJXL:
                    if (Tunables.Global_262145.Value<int>("f_35417") != 1/* Tunable: ENABLE_VEHICLE_BJXL */)
                        return false;
                    break;
                case VehicleHash.Serrano:
                    if (Tunables.Global_262145.Value<int>("f_35419") != 1/* Tunable: ENABLE_VEHICLE_SERRANO */)
                        return false;
                    break;
                case VehicleHash.Gresley:
                    if (Tunables.Global_262145.Value<int>("f_35421") != 1/* Tunable: ENABLE_VEHICLE_GRESLEY */)
                        return false;
                    break;
                case VehicleHash.Seminole:
                    if (Tunables.Global_262145.Value<int>("f_35423") != 1/* Tunable: ENABLE_VEHICLE_SEMINOLE */)
                        return false;
                    break;
                case VehicleHash.Granger:
                    if (Tunables.Global_262145.Value<int>("f_35425") != 1/* Tunable: ENABLE_VEHICLE_GRANGER */)
                        return false;
                    break;
                case VehicleHash.Landstalker:
                    if (Tunables.Global_262145.Value<int>("f_35427") != 1/* Tunable: ENABLE_VEHICLE_LANDSTALKER */)
                        return false;
                    break;
                case VehicleHash.Habanero:
                    if (Tunables.Global_262145.Value<int>("f_35429") != 1/* Tunable: ENABLE_VEHICLE_HABANERO */)
                        return false;
                    break;
                case VehicleHash.FQ2:
                    if (Tunables.Global_262145.Value<int>("f_35431") != 1/* Tunable: ENABLE_VEHICLE_FQ2 */)
                        return false;
                    break;
                case VehicleHash.Baller:
                    if (Tunables.Global_262145.Value<int>("f_35433") != 1/* Tunable: ENABLE_VEHICLE_BALLER */)
                        return false;
                    break;
                case VehicleHash.Patriot:
                    if (Tunables.Global_262145.Value<int>("f_35435") != 1/* Tunable: ENABLE_VEHICLE_PATRIOT */)
                        return false;
                    break;
                case VehicleHash.Rocoto:
                    if (Tunables.Global_262145.Value<int>("f_35437") != 1/* Tunable: ENABLE_VEHICLE_ROCOTO */)
                        return false;
                    break;
                case VehicleHash.Radi:
                    if (Tunables.Global_262145.Value<int>("f_35439") != 1/* Tunable: ENABLE_VEHICLE_RADI */)
                        return false;
                    break;
                case VehicleHash.Mesa3:
                    if (Tunables.Global_262145.Value<int>("f_35441") != 1/* Tunable: ENABLE_VEHICLE_MESA3 */)
                        return false;
                    break;
                case VehicleHash.Monster:
                    if (Tunables.Global_262145.Value<int>("f_35443") != 1/* Tunable: ENABLE_VEHICLE_MONSTER */)
                        return false;
                    break;
                case VehicleHash.Ruston:
                    if (Tunables.Global_262145.Value<int>("f_20394") != 1/* Tunable: ENABLERUSTON */)
                        return false;
                    break;
                case VehicleHash.Pfister811:
                    if (Tunables.Global_262145.Value<int>("f_14916") != 1/* Tunable: ENABLEEXEC1_PFISTER */)
                        return false;
                    break;
                case VehicleHash.GP1:
                    if (Tunables.Global_262145.Value<int>("f_20392") != 1/* Tunable: ENABLEGP1 */)
                        return false;
                    break;
                case VehicleHash.SabreGT:
                    if (Tunables.Global_262145.Value<int>("f_14909") != 1/* Tunable: ENABLE_LOWRIDER2_SABREGT */)
                        return false;
                    break;
                case VehicleHash.Tornado:
                    if (Tunables.Global_262145.Value<int>("f_14910") != 1/* Tunable: ENABLE_LOWRIDER2_TORNADO5 */)
                        return false;
                    break;
                case VehicleHash.Faction:
                    if (Tunables.Global_262145.Value<int>("f_14912") != 1/* Tunable: ENABLE_LOWRIDER2_FACTION */)
                        return false;
                    break;
                case VehicleHash.Virgo3:
                    if (Tunables.Global_262145.Value<int>("f_14908") != 1/* Tunable: ENABLE_LOWRIDER2_VIRGO3 */)
                        return false;
                    break;
                case VehicleHash.Bagger:
                    if (Tunables.Global_262145.Value<int>("f_17674") != 1/* Tunable: ENABLE_BIKER_BAGGER */)
                        return false;
                    break;
                case /*L35*/ (VehicleHash)2531292011:
                    if (Tunables.Global_262145.Value<int>("f_35462") != 1/* Tunable: ENABLE_VEHICLE_L35 */)
                        return false;
                    break;
                case /*Ratel*/ (VehicleHash)3758861739:
                    if (Tunables.Global_262145.Value<int>("f_35463") != 1/* Tunable: ENABLE_VEHICLE_RATEL */)
                        return false;
                    break;
                case /*Monstrociti*/ (VehicleHash)802856453:
                    if (Tunables.Global_262145.Value<int>("f_35464") != 1/* Tunable: ENABLE_VEHICLE_MONSTROCITI */)
                        return false;
                    break;
                case /*Clique2*/ (VehicleHash)3315674721:
                    if (Tunables.Global_262145.Value<int>("f_35465") != 1/* Tunable: ENABLE_VEHICLE_CLIQUE2 */)
                        return false;
                    break;
                case /*Stingertt*/ (VehicleHash)1447690049:
                    if (Tunables.Global_262145.Value<int>("f_35466") != 1/* Tunable: ENABLE_VEHICLE_STINGERTT */)
                        return false;
                    break;
                case /*Streamer216*/ (VehicleHash)191916658:
                    if (Tunables.Global_262145.Value<int>("f_35467") != 1/* Tunable: ENABLE_VEHICLE_STREAMER216 */)
                        return false;
                    break;
                case /*Raiju*/ (VehicleHash)239897677:
                    if (Tunables.Global_262145.Value<int>("f_35468") != 1/* Tunable: ENABLE_VEHICLE_RAIJU */)
                        return false;
                    break;
                case /*Buffalo5*/ (VehicleHash)165968051:
                    if (Tunables.Global_262145.Value<int>("f_35469") != 1/* Tunable: ENABLE_VEHICLE_BUFFALO5 */)
                        return false;
                    break;
                case (VehicleHash)3397143273: /*Inductor*/
                case (VehicleHash)2311345272: /*Inductor2*/
                    if (Tunables.Global_262145.Value<int>("f_35470") != 1/* Tunable: ENABLE_VEHICLE_INDUCTOR */)
                        return false;
                    break;
                case /*Coureur*/ (VehicleHash)610429990:
                    if (Tunables.Global_262145.Value<int>("f_35471") != 1/* Tunable: ENABLE_VEHICLE_COUREUR */)
                        return false;
                    break;
                case /*Conada2*/ (VehicleHash)2635962482:
                    if (Tunables.Global_262145.Value<int>("f_35472") != 1/* Tunable: ENABLE_VEHICLE_CONADA2 */)
                        return false;
                    break;
                case /*Gauntlet6*/ (VehicleHash)1336514315:
                    if (Tunables.Global_262145.Value<int>("f_35473") != 1/* Tunable: ENABLE_VEHICLE_GAUNTLET6 */)
                        return false;
                    break;
                case /*Brigham*/ (VehicleHash)3640468689:
                    if (Tunables.Global_262145.Value<int>("f_35474") != 1/* Tunable: ENABLE_VEHICLE_BRIGHAM */)
                        return false;
                    break;
            }
            return true;
        }
        internal static int func_5515(int iParam0)//Position - 0x1C4470
        {
            if (func_5518(iParam0))
            {
                return 33;
            }
            else if (func_5517(iParam0))
            {
                return 34;
            }
            else if (func_3149(iParam0))
            {
                return 38;
            }
            else if (func_552(iParam0) || (VehicleHash)iParam0 == /*Brickade2*/ (VehicleHash)2718380883)
            {
                return 38;
            }
            else if (func_5516(iParam0))
            {
                return 3;
            }
            else if (IsThisModelABike((uint)iParam0))
            {
                return 4;
            }
            return (VehicleHash)iParam0 switch
            {
                VehicleHash.Virgo2 => 10,
                VehicleHash.SlamVan3 => 11,
                VehicleHash.SultanRS => 6,
                VehicleHash.Banshee2 => 7,
                VehicleHash.BType3 => 5,
                VehicleHash.Faction3 => 3,
                VehicleHash.Minivan2 => 0,
                VehicleHash.SabreGT2 => 0,
                //VehicleHash.SlamVan3 => 0,
                VehicleHash.Tornado5 => 0,
                //VehicleHash.Virgo2 => 3,
                VehicleHash.Virgo3 => 3,
                VehicleHash.FCR => 0,
                VehicleHash.Diablous => 0,
                VehicleHash.Diablous2 => 28,
                VehicleHash.FCR2 => 28,
                VehicleHash.ItaliGTB => 3,
                VehicleHash.Specter => 3,
                VehicleHash.Nero => 3,
                VehicleHash.ItaliGTB2 => 27,
                VehicleHash.Specter2 => 27,
                VehicleHash.Nero2 => 27,
                VehicleHash.Comet3 => 26,
                VehicleHash.Elegy => 26,
                /*Youga3*/
                (VehicleHash)1802742206 => 27,
                /*Gauntlet5*/
                (VehicleHash)2172320429 => 27,
                /*Manana2*/
                (VehicleHash)1717532765 => 27,
                /*Peyote3*/
                (VehicleHash)1107404867 => 27,
                /*Yosemite3*/
                (VehicleHash)67753863 => 27,
                /*Glendale2*/
                (VehicleHash)3381377750 => 27,
                VehicleHash.Apc => 29,
                VehicleHash.HalfTrack => 29,
                VehicleHash.TrailerSmall2 => 29,
                /*Deluxo*/
                (VehicleHash)1483171323 => 29,
                /*Stromberg*/
                (VehicleHash)886810209 => 29,
                /*Caracara*/
                (VehicleHash)1254014755 => 29,
                VehicleHash.Dune3 => 30,
                VehicleHash.Insurgent3 => 30,
                VehicleHash.Tampa3 => 30,
                VehicleHash.Technical3 => 30,
                VehicleHash.Oppressor => 31,
                /*Oppressor2*/
                (VehicleHash)2069146067 => 31,
                VehicleHash.Phantom3 => 32,
                VehicleHash.Hauler2 => 32,
                VehicleHash.TrailerLarge => 32,
                /*Barrage*/
                (VehicleHash)4081974053 => 35,
                /*Mule4*/
                (VehicleHash)1945374990 => 37,
                /*Speedo4*/
                (VehicleHash)219613597 or
                /*speedo5*/
                (VehicleHash)4250167832 => 36,
                /*Pounder2*/
                (VehicleHash)1653666139 => 36,
                /*Rcbandito*/
                (VehicleHash)4008920556 => 39,
                /*Minitank*/
                (VehicleHash)3040635986 => 36,
                /*JB7002*/
                (VehicleHash)394110044 => 36,
                /*Vigilante*/
                VehicleHash.Adder => 3,
                VehicleHash.Airbus => 0,
                VehicleHash.Akuma => 4,
                VehicleHash.Alpha => 3,
                VehicleHash.Annihilator => 0,
                VehicleHash.Asea => 0,
                VehicleHash.Asterope => 0,
                VehicleHash.Baller2 => 2,
                VehicleHash.Banshee => 3,
                VehicleHash.Barracks => 0,
                VehicleHash.Bati => 4,
                VehicleHash.Bati2 => 4,
                VehicleHash.Besra => 0,
                VehicleHash.BfInjection => 0,
                VehicleHash.Bifta => 0,
                VehicleHash.Bison => 2,
                VehicleHash.Blade => 3,
                VehicleHash.Blazer => 0,
                VehicleHash.Blazer3 => 0,
                VehicleHash.Bmx => 0,
                VehicleHash.BobcatXL => 2,
                VehicleHash.Bodhi2 => 0,
                VehicleHash.BType => 0,
                VehicleHash.Buffalo => 0,
                VehicleHash.Buffalo2 => 1,
                VehicleHash.Bullet => 3,
                VehicleHash.Bus => 0,
                VehicleHash.Buzzard => 0,
                VehicleHash.Carbonizzare => 3,
                VehicleHash.CarbonRS => 3,
                VehicleHash.Cavalcade => 2,
                VehicleHash.Cavalcade2 => 2,
                VehicleHash.Cheetah => 3,
                VehicleHash.Coach => 0,
                VehicleHash.CogCabrio => 3,
                VehicleHash.Comet2 => 3,
                VehicleHash.Coquette => 3,
                VehicleHash.Coquette2 => 1,
                VehicleHash.Cruiser => 0,
                VehicleHash.Crusader => 0,
                VehicleHash.Cuban800 => 0,
                VehicleHash.Dilettante => 0,
                VehicleHash.Dilettante2 => 0,
                VehicleHash.Dominator => 1,
                VehicleHash.Dominator2 => 1,
                VehicleHash.Double => 4,
                VehicleHash.Dubsta3 => 3,
                VehicleHash.Dump => 0,
                VehicleHash.Dune => 0,
                VehicleHash.Duster => 0,
                VehicleHash.Elegy2 => 3,
                VehicleHash.EntityXF => 3,
                VehicleHash.Exemplar => 3,
                VehicleHash.F620 => 1,
                VehicleHash.Faggio2 => 4,
                VehicleHash.Felon => 0,
                VehicleHash.Felon2 => 0,
                VehicleHash.Feltzer2 => 3,
                VehicleHash.Frogger => 0,
                VehicleHash.Frogger2 => 0,
                VehicleHash.Fugitive => 0,
                VehicleHash.Fusilade => 1,
                VehicleHash.Gauntlet => 0,
                VehicleHash.Gauntlet2 => 0,
                VehicleHash.Glendale => 3,
                VehicleHash.Granger => 2,
                VehicleHash.Gresley => 2,
                VehicleHash.Hexer => 4,
                VehicleHash.Hotknife => 3,
                VehicleHash.Huntley => 1,
                VehicleHash.Hydra => 0,
                VehicleHash.Infernus => 3,
                VehicleHash.Ingot => 0,
                VehicleHash.Intruder => 0,
                VehicleHash.Issi2 => 0,
                VehicleHash.Jackal => 1,
                VehicleHash.JB700 => 3,
                VehicleHash.Jester => 3,
                VehicleHash.Jester2 => 3,
                VehicleHash.Jetmax => 0,
                VehicleHash.Journey => 0,
                VehicleHash.Kalahari => 0,
                VehicleHash.Khamelion => 3,
                VehicleHash.Landstalker => 2,
                VehicleHash.Luxor => 0,
                VehicleHash.Mammatus => 0,
                VehicleHash.Marquis => 0,
                VehicleHash.Massacro => 3,
                VehicleHash.Massacro2 => 3,
                VehicleHash.Maverick => 0,
                VehicleHash.Mesa => 2,
                VehicleHash.Mesa2 => 2,
                VehicleHash.Mesa3 => 2,
                VehicleHash.Miljet => 0,
                VehicleHash.Minivan => 0,
                VehicleHash.Monroe => 3,
                VehicleHash.Monster => 0,
                VehicleHash.Mule => 0,
                VehicleHash.Mule2 => 0,
                VehicleHash.Mule3 => 0,
                VehicleHash.Nemesis => 4,
                VehicleHash.Ninef => 3,
                VehicleHash.Ninef2 => 3,
                VehicleHash.Oracle => 1,
                VehicleHash.Oracle2 => 1,
                VehicleHash.Panto => 3,
                VehicleHash.Paradise => 0,
                VehicleHash.PCJ => 4,
                VehicleHash.Penumbra => 1,
                VehicleHash.Picador => 0,
                VehicleHash.Pigalle => 3,
                VehicleHash.Premier => 0,
                VehicleHash.Primo => 0,
                VehicleHash.Radi => 0,
                VehicleHash.RancherXL => 2,
                VehicleHash.RancherXL2 => 2,
                VehicleHash.RapidGT => 3,
                VehicleHash.RatLoader => 2,
                VehicleHash.RatLoader2 => 2,
                VehicleHash.Rebel => 2,
                VehicleHash.Rebel2 => 2,
                VehicleHash.Regina => 0,
                VehicleHash.RentalBus => 0,
                VehicleHash.Rhapsody => 3,
                VehicleHash.Rhino => 0,
                VehicleHash.Rocoto => 2,
                VehicleHash.Ruffian => 4,
                VehicleHash.Rumpo => 0,
                VehicleHash.Sadler => 2,
                VehicleHash.Sanchez => 4,
                VehicleHash.Sanchez2 => 4,
                VehicleHash.Sandking => 2,
                VehicleHash.Sandking2 => 2,
                VehicleHash.Schafter2 => 1,
                VehicleHash.Schwarzer => 1,
                VehicleHash.Scorcher => 0,
                VehicleHash.Seashark => 0,
                VehicleHash.Seminole => 2,
                VehicleHash.Sentinel => 1,
                VehicleHash.Sentinel2 => 1,
                VehicleHash.Shamal => 0,
                VehicleHash.Sovereign => 4,
                VehicleHash.Speeder => 0,
                VehicleHash.Squalo => 0,
                VehicleHash.Stanier => 0,
                VehicleHash.Stinger => 3,
                VehicleHash.StingerGT => 3,
                VehicleHash.Stratum => 0,
                VehicleHash.Stretch => 0,
                VehicleHash.Stunt => 0,
                VehicleHash.Suntrap => 0,
                VehicleHash.Superd => 3,
                VehicleHash.Surano => 3,
                VehicleHash.Surfer => 0,
                VehicleHash.Surge => 0,
                VehicleHash.Tailgater => 0,
                VehicleHash.Thrust => 4,
                VehicleHash.Titan => 0,
                VehicleHash.TriBike => 4,
                VehicleHash.TriBike2 => 4,
                VehicleHash.TriBike3 => 4,
                VehicleHash.Tropic => 0,
                VehicleHash.Turismor => 3,
                VehicleHash.Vacca => 3,
                VehicleHash.Vader => 4,
                VehicleHash.Valkyrie => 0,
                VehicleHash.Velum => 0,
                VehicleHash.Vestra => 0,
                VehicleHash.Vigero => 1,
                VehicleHash.Voltic => 3,
                VehicleHash.Warrener => 3,
                VehicleHash.Washington => 0,
                VehicleHash.Youga => 2,
                VehicleHash.Zentorno => 3,
                VehicleHash.Zion => 1,
                VehicleHash.Zion2 => 1,
                VehicleHash.ZType => 3,
                VehicleHash.Swift => 0,
                VehicleHash.Innovation => 4,
                VehicleHash.Hakuchou => 4,
                VehicleHash.Furoregt => 0,
                VehicleHash.Kuruma => 3,
                VehicleHash.Blista2 => 0,
                VehicleHash.Blista3 => 0,
                VehicleHash.Buffalo3 => 1,
                VehicleHash.Dodo => 0,
                VehicleHash.Dukes => 1,
                VehicleHash.Dukes2 => 0,
                VehicleHash.Marshall => 0,
                VehicleHash.Stalion => 0,
                VehicleHash.Stalion2 => 0,
                VehicleHash.Submersible => 0,
                VehicleHash.Submersible2 => 0,
                VehicleHash.Bagger => 4,
                VehicleHash.Baller => 2,
                VehicleHash.BJXL => 2,
                VehicleHash.Blista => 0,
                VehicleHash.Buccaneer => 0,
                VehicleHash.Daemon => 4,
                VehicleHash.DLoader => 0,
                VehicleHash.FQ2 => 0,
                VehicleHash.Habanero => 0,
                VehicleHash.Manana => 0,
                VehicleHash.Patriot => 2,
                VehicleHash.Peyote => 0,
                VehicleHash.Phoenix => 0,
                VehicleHash.Prairie => 0,
                VehicleHash.SabreGT => 0,
                VehicleHash.Serrano => 2,
                VehicleHash.Speedo => 0,
                VehicleHash.Speedo2 => 0,
                VehicleHash.Voodoo2 => 0,
                VehicleHash.Romero => 0,
                VehicleHash.Surfer2 => 0,
                VehicleHash.Emperor2 => 0,
                VehicleHash.Dubsta2 => 2,
                VehicleHash.Blazer2 => 0,
                VehicleHash.Dubsta => 2,
                VehicleHash.RapidGT2 => 1,
                VehicleHash.Boxville4 => 0,
                VehicleHash.Windsor or
                VehicleHash.Osiris or
                VehicleHash.Feltzer3 or
                VehicleHash.Virgo => 3,
                VehicleHash.Faction or
                VehicleHash.Faction2 or
                VehicleHash.Moonbeam2 or
                VehicleHash.Moonbeam => 3,
                VehicleHash.Buccaneer2 or
                VehicleHash.Chino2 or
                VehicleHash.Primo2 or
                VehicleHash.Voodoo => 0,
                VehicleHash.BType2 or
                VehicleHash.Lurcher => 3,
                VehicleHash.Omnis or
                VehicleHash.Tropos or
                VehicleHash.Brioso or
                VehicleHash.TrophyTruck or
                VehicleHash.TrophyTruck2 or
                VehicleHash.Cliffhanger or
                VehicleHash.BF400 or
                VehicleHash.RallyTruck or
                VehicleHash.Tampa2 or
                VehicleHash.Gargoyle or
                VehicleHash.Tyrus or
                VehicleHash.LE7B or
                VehicleHash.Lynx or
                VehicleHash.Sheava or
                VehicleHash.Ardent or
                VehicleHash.Cheetah2 or
                VehicleHash.Torero or
                VehicleHash.Vagner or
                VehicleHash.XA21 => 3,
                VehicleHash.Contender => 2,
                VehicleHash.Tampa3 or
                VehicleHash.Apc or
                VehicleHash.HalfTrack or
                VehicleHash.Dune3 or
                VehicleHash.TrailerSmall2 or
                VehicleHash.Insurgent3 or
                VehicleHash.Technical3 or
                /*Sentinel3*/
                (VehicleHash)1104234922 or
                 /*Riata*/
                 (VehicleHash)2762269779 => 3,
                /*Gb200*/
                (VehicleHash)1909189272 or
       /*Issi3*/ (VehicleHash)931280609 or
      /*Swinger*/ (VehicleHash)500482303 or
      /*Patriot2*/ (VehicleHash)3874056184 or
      /*Menacer*/ (VehicleHash)2044532910 or
      /*Freecrawler*/ (VehicleHash)4240635011 or
      /*Stafford*/ (VehicleHash)321186144 or
      /*Scramjet*/ (VehicleHash)3656405053 or
      /*Terbyte*/ (VehicleHash)2306538597 or
      /*Clique*/ (VehicleHash)2728360112 or
      /*Deveste*/ (VehicleHash)1591739866 or
      /*Deviant*/ (VehicleHash)1279262537 or
      /*Impaler*/ (VehicleHash)2198276962 or
      /*Scarab*/ (VehicleHash)3147997943 or
      /*Schlagen*/ (VehicleHash)3787471536 or
      /*Toros*/ (VehicleHash)3126015148 or
      /*Vamos*/ (VehicleHash)4245851645 or
      /*Tulip*/ (VehicleHash)1456744817 or
      /*Monster3*/ (VehicleHash)1721676810 or
      /*Impaler2*/ (VehicleHash)1009171724 or
      /*Bruiser*/ (VehicleHash)668439077 or
      /*Cerberus*/ (VehicleHash)3493417227 or
      /*Dominator4*/ (VehicleHash)3606777648 or
      /*Imperator*/ (VehicleHash)444994115 or
      /*Issi4*/ (VehicleHash)628003514 or
      /*ItaliGTo*/ (VehicleHash)3963499524 or
      /*Deathbike3*/ (VehicleHash)2920466844 or
      /*Slamvan4*/ (VehicleHash)2233918197 or
      /*Zr380*/ (VehicleHash)540101442 or
      /*Brutus*/ (VehicleHash)2139203625 or
      VehicleHash.Lguard or
      VehicleHash.Blazer2 or
      VehicleHash.FireTruk or
      VehicleHash.Burrito2 or
      VehicleHash.Boxville or
      VehicleHash.Stockade or
      /*Asbo*/ (VehicleHash)1118611807 or
      /*Kanjo*/ (VehicleHash)409049982 or
      /*Formula*/ (VehicleHash)340154634 or
      /*Imorgon*/ (VehicleHash)3162245632 or
      /*Komoda*/ (VehicleHash)3460613305 or
      /*Manana2*/ (VehicleHash)1717532765 or
      /*Rebla*/ (VehicleHash)83136452 or
      /*Sugoi*/ (VehicleHash)987469656 or
      /*Youga3*/ (VehicleHash)1802742206 or
      /*Zhaba*/ (VehicleHash)1284356689 or
      /*Vstr*/ (VehicleHash)1456336509 or
      /*Everon*/ (VehicleHash)2538945576 or
      /*Sultan2*/ (VehicleHash)872704284 or
      /*JB7002*/ (VehicleHash)394110044 or
      /*Outlaw*/ (VehicleHash)408825843 or
      /*Stryder*/ (VehicleHash)301304410 or
      /*Vagrant*/ (VehicleHash)740289177 or
      /*Formula2*/ (VehicleHash)2334210311 or
      /*Furia*/ (VehicleHash)960812448 or
      /*Yosemite2*/ (VehicleHash)1693751655 or
      /*Retinue2*/ (VehicleHash)2031587082 or
      /*Minitank*/ (VehicleHash)3040635986 or
      /*Gauntlet5*/ (VehicleHash)2172320429 or
      /*Club*/ (VehicleHash)2196012677 or
      /*Dukes3*/ (VehicleHash)2134119907 or
      /*Manchez2*/ (VehicleHash)1086534307 or
      /*Brioso2*/ (VehicleHash)1429622905 or
      /*Winky*/ (VehicleHash)4084658662 or
      /*Verus*/ (VehicleHash)298565713 or
      (VehicleHash)2588363614 /*Avisa*/ or
      /*Longfin*/ (VehicleHash)1861786828 or
      /*Patrolboat*/ (VehicleHash)4018222598 or
      /*Seasparrow3*/ (VehicleHash)1593933419 or
      /*SlamTruck*/ (VehicleHash)3249056020 or
      /*Vetir*/ (VehicleHash)2014313426 or
      /*ItaliRSx*/ (VehicleHash)3145241962 or
      /*Toreador*/ (VehicleHash)1455990255 or
      /*Weevil*/ (VehicleHash)1644055914 or
      /*Dinghy5*/ (VehicleHash)3314393930 or
      /*Squaddie*/ (VehicleHash)4192631813 or
      /*Veto*/ (VehicleHash)3437611258 or
      /*Veto2*/ (VehicleHash)2802050217 or
      /*Calico*/ (VehicleHash)3101054893 or
      /*Comet6*/ (VehicleHash)2568944644 or
      /*Cypher*/ (VehicleHash)1755697647 or
      /*Dominator7*/ (VehicleHash)426742808 or
      /*Jester4*/ (VehicleHash)2712905841 or
      /*Remus*/ (VehicleHash)1377217886 or
      /*Vectre*/ (VehicleHash)2754593701 or
      /*Zr350*/ (VehicleHash)2436313176 or
      /*Warrener2*/ (VehicleHash)579912970 or
      /*Rt3000*/ (VehicleHash)3842363289 or
      /*Peyote3*/ (VehicleHash)1107404867 or
      /*Yosemite3*/ (VehicleHash)67753863 or
      /*Glendale2*/ (VehicleHash)3381377750 or
      /*Penumbra2*/ (VehicleHash)3663644634 or
      /*Landstalker2*/ (VehicleHash)3456868130 or
      /*Seminole2*/ (VehicleHash)2484160806 or
      /*Tigon*/ (VehicleHash)2936769864 or
      /*Openwheel1*/ (VehicleHash)1492612435 or
      /*Coquette4*/ (VehicleHash)2566281822 or
      /*Openwheel2*/ (VehicleHash)1181339704 or
      /*Futo2*/ (VehicleHash)2787736776 or
      /*Tailgater2*/ (VehicleHash)3050505892 or
      /*Sultan3*/ (VehicleHash)4003946083 or
      /*Dominator8*/ (VehicleHash)736672010 or
      /*Euros*/ (VehicleHash)2038480341 or
      /*Growler*/ (VehicleHash)1304459735 or
      /*Previon*/ (VehicleHash)1416471345 or
      /*Baller7*/ (VehicleHash)359875117 or
      /*Astron*/ (VehicleHash)629969764 or
      /*Comet7*/ (VehicleHash)1141395928 or
      /*Ignus*/ (VehicleHash)2850852987 or
      (VehicleHash)1486521356 /*Youga4*/ or
      /*Zeno*/ (VehicleHash)655665811 or
      /*Cinquemila*/ (VehicleHash)2767531027 or
      (VehicleHash)1343932732 /*Mule5*/ or
      /*Iwagen*/ (VehicleHash)662793086 => 3,
                _ => 0,
            };
        }
        internal static bool func_552(int iParam0)//Position - 0x5517C
        {
            return iParam0 == GetHashKey("deity") ||
             iParam0 == GetHashKey("granger2") ||
             iParam0 == GetHashKey("buffalo4") ||
             iParam0 == GetHashKey("jubilee") ||
             iParam0 == GetHashKey("patriot3") ||
             iParam0 == GetHashKey("champion") ||
             iParam0 == GetHashKey("greenwood") ||
             iParam0 == GetHashKey("omnisegt") ||
             iParam0 == GetHashKey("virtue") ||
             iParam0 == GetHashKey("r300") ||
             iParam0 == GetHashKey("stingertt") ||
             iParam0 == GetHashKey("buffalo5") ||
             iParam0 == GetHashKey("coureur") ||
             iParam0 == GetHashKey("monstrociti");
        }
        internal static bool func_5516(int iParam0)//Position - 0x1C5769
        {
            return (VehicleHash)iParam0 == VehicleHash.Adder
                || (VehicleHash)iParam0 == VehicleHash.Banshee
                || (VehicleHash)iParam0 == VehicleHash.Bullet
                || (VehicleHash)iParam0 == VehicleHash.Carbonizzare
                || (VehicleHash)iParam0 == VehicleHash.CarbonRS
                || (VehicleHash)iParam0 == VehicleHash.Cheetah
                || (VehicleHash)iParam0 == VehicleHash.CogCabrio
                || (VehicleHash)iParam0 == VehicleHash.Comet2
                || (VehicleHash)iParam0 == VehicleHash.Coquette
                || (VehicleHash)iParam0 == VehicleHash.Elegy2
                || (VehicleHash)iParam0 == VehicleHash.EntityXF
                || (VehicleHash)iParam0 == VehicleHash.Exemplar
                || (VehicleHash)iParam0 == VehicleHash.Feltzer2
                || (VehicleHash)iParam0 == VehicleHash.Hotknife
                || (VehicleHash)iParam0 == VehicleHash.Infernus
                || (VehicleHash)iParam0 == VehicleHash.JB700
                || (VehicleHash)iParam0 == VehicleHash.Khamelion
                || (VehicleHash)iParam0 == VehicleHash.Monroe
                || (VehicleHash)iParam0 == VehicleHash.Ninef
                || (VehicleHash)iParam0 == VehicleHash.Ninef2
                || (VehicleHash)iParam0 == VehicleHash.RapidGT
                || (VehicleHash)iParam0 == VehicleHash.RapidGT2
                || (VehicleHash)iParam0 == VehicleHash.Stinger
                || (VehicleHash)iParam0 == VehicleHash.StingerGT
                || (VehicleHash)iParam0 == VehicleHash.Superd
                || (VehicleHash)iParam0 == VehicleHash.Surano
                || (VehicleHash)iParam0 == VehicleHash.Vacca
                || (VehicleHash)iParam0 == VehicleHash.Voltic
                || (VehicleHash)iParam0 == VehicleHash.ZType
                || (VehicleHash)iParam0 == VehicleHash.Dubsta3
                || (VehicleHash)iParam0 == VehicleHash.Blade
                || (VehicleHash)iParam0 == VehicleHash.Glendale
                || (VehicleHash)iParam0 == VehicleHash.Rhapsody
                || (VehicleHash)iParam0 == VehicleHash.Warrener
                || (VehicleHash)iParam0 == VehicleHash.Panto
                || (VehicleHash)iParam0 == VehicleHash.Pigalle
                || (VehicleHash)iParam0 == VehicleHash.Casco
                || (VehicleHash)iParam0 == VehicleHash.Kuruma2
                || (VehicleHash)iParam0 == VehicleHash.Lectro
                || (VehicleHash)iParam0 == VehicleHash.Insurgent
                || (VehicleHash)iParam0 == VehicleHash.Insurgent2
                || (VehicleHash)iParam0 == VehicleHash.Technical
                || (VehicleHash)iParam0 == VehicleHash.Windsor
                || (VehicleHash)iParam0 == VehicleHash.Osiris
                || (VehicleHash)iParam0 == VehicleHash.Feltzer3
                || (VehicleHash)iParam0 == VehicleHash.Virgo
                || (VehicleHash)iParam0 == VehicleHash.Faction
                || (VehicleHash)iParam0 == VehicleHash.Faction2
                || (VehicleHash)iParam0 == VehicleHash.Moonbeam
                || (VehicleHash)iParam0 == VehicleHash.Moonbeam2
                || (VehicleHash)iParam0 == VehicleHash.Faction3
                || (VehicleHash)iParam0 == VehicleHash.Virgo2
                || (VehicleHash)iParam0 == VehicleHash.Baller3
                || (VehicleHash)iParam0 == VehicleHash.Baller4
                || (VehicleHash)iParam0 == VehicleHash.Cognoscenti
                || (VehicleHash)iParam0 == VehicleHash.Cog55
                || (VehicleHash)iParam0 == VehicleHash.Limo2
                || (VehicleHash)iParam0 == VehicleHash.Mamba
                || (VehicleHash)iParam0 == VehicleHash.Nightshade
                || (VehicleHash)iParam0 == VehicleHash.Schafter3
                || (VehicleHash)iParam0 == VehicleHash.Schafter4
                || (VehicleHash)iParam0 == VehicleHash.Verlierer2
                || (VehicleHash)iParam0 == VehicleHash.Tampa
                || (VehicleHash)iParam0 == VehicleHash.Banshee2
                || (VehicleHash)iParam0 == VehicleHash.BestiaGTS
                || (VehicleHash)iParam0 == VehicleHash.Brickade
                || (VehicleHash)iParam0 == VehicleHash.FMJ
                || (VehicleHash)iParam0 == VehicleHash.Nimbus
                || (VehicleHash)iParam0 == VehicleHash.Pfister811
                || (VehicleHash)iParam0 == VehicleHash.Prototipo
                || (VehicleHash)iParam0 == VehicleHash.Rumpo3
                || (VehicleHash)iParam0 == VehicleHash.Seven70
                || (VehicleHash)iParam0 == VehicleHash.Tug
                || (VehicleHash)iParam0 == VehicleHash.Volatus
                || (VehicleHash)iParam0 == VehicleHash.Windsor2
                || (VehicleHash)iParam0 == VehicleHash.XLS
                || (VehicleHash)iParam0 == VehicleHash.XLS2
                || (VehicleHash)iParam0 == VehicleHash.Reaper
                || (VehicleHash)iParam0 == VehicleHash.Omnis
                || (VehicleHash)iParam0 == VehicleHash.Tropos
                || (VehicleHash)iParam0 == VehicleHash.Brioso
                || (VehicleHash)iParam0 == VehicleHash.TrophyTruck
                || (VehicleHash)iParam0 == VehicleHash.TrophyTruck2
                || (VehicleHash)iParam0 == VehicleHash.Cliffhanger
                || (VehicleHash)iParam0 == VehicleHash.BF400
                || (VehicleHash)iParam0 == VehicleHash.RallyTruck
                || (VehicleHash)iParam0 == VehicleHash.Tampa2
                || (VehicleHash)iParam0 == VehicleHash.Gargoyle
                || (VehicleHash)iParam0 == VehicleHash.Tyrus
                || (VehicleHash)iParam0 == VehicleHash.LE7B
                || (VehicleHash)iParam0 == VehicleHash.Lynx
                || (VehicleHash)iParam0 == VehicleHash.Sheava
                || (VehicleHash)iParam0 == VehicleHash.Avarus
                || (VehicleHash)iParam0 == VehicleHash.Defiler
                || (VehicleHash)iParam0 == VehicleHash.Nightblade
                || (VehicleHash)iParam0 == VehicleHash.ZombieA
                || (VehicleHash)iParam0 == VehicleHash.ZombieB
                || (VehicleHash)iParam0 == VehicleHash.Chimera
                || (VehicleHash)iParam0 == VehicleHash.Esskey
                || (VehicleHash)iParam0 == VehicleHash.RatBike
                || (VehicleHash)iParam0 == VehicleHash.Hakuchou2
                || (VehicleHash)iParam0 == VehicleHash.Daemon2
                || (VehicleHash)iParam0 == VehicleHash.Shotaro
                || (VehicleHash)iParam0 == VehicleHash.Raptor
                || (VehicleHash)iParam0 == VehicleHash.Blazer4
                || (VehicleHash)iParam0 == VehicleHash.Sanctus
                || (VehicleHash)iParam0 == VehicleHash.Vortex
                || (VehicleHash)iParam0 == VehicleHash.Manchez
                || (VehicleHash)iParam0 == VehicleHash.Tornado6
                || (VehicleHash)iParam0 == VehicleHash.Youga2
                || (VehicleHash)iParam0 == VehicleHash.Wolfsbane
                || (VehicleHash)iParam0 == VehicleHash.Faggio3
                || (VehicleHash)iParam0 == VehicleHash.Faggio
                || (VehicleHash)iParam0 == VehicleHash.Blazer5
                || (VehicleHash)iParam0 == VehicleHash.Boxville5
                || (VehicleHash)iParam0 == VehicleHash.Comet3
                || (VehicleHash)iParam0 == VehicleHash.Diablous
                || (VehicleHash)iParam0 == VehicleHash.Diablous2
                || (VehicleHash)iParam0 == VehicleHash.Dune4
                || (VehicleHash)iParam0 == VehicleHash.Dune5
                || (VehicleHash)iParam0 == VehicleHash.FCR
                || (VehicleHash)iParam0 == VehicleHash.FCR2
                || (VehicleHash)iParam0 == VehicleHash.ItaliGTB
                || (VehicleHash)iParam0 == VehicleHash.Nero
                || (VehicleHash)iParam0 == VehicleHash.Penetrator
                || (VehicleHash)iParam0 == VehicleHash.Phantom2
                || (VehicleHash)iParam0 == VehicleHash.Ruiner2
                || (VehicleHash)iParam0 == VehicleHash.Technical2
                || (VehicleHash)iParam0 == VehicleHash.Tempesta
                || (VehicleHash)iParam0 == VehicleHash.Voltic2
                || (VehicleHash)iParam0 == VehicleHash.Wastelander
                || (VehicleHash)iParam0 == VehicleHash.Elegy
                || (VehicleHash)iParam0 == VehicleHash.ItaliGTB2
                || (VehicleHash)iParam0 == VehicleHash.Nero2
                || (VehicleHash)iParam0 == VehicleHash.Ruiner3
                || (VehicleHash)iParam0 == VehicleHash.Specter
                || (VehicleHash)iParam0 == VehicleHash.Specter2
                || (VehicleHash)iParam0 == VehicleHash.GP1
                || (VehicleHash)iParam0 == VehicleHash.Ruston
                || (VehicleHash)iParam0 == VehicleHash.Infernus2
                || (VehicleHash)iParam0 == VehicleHash.Turismo2
                || (VehicleHash)iParam0 == VehicleHash.Ardent
                || (VehicleHash)iParam0 == VehicleHash.Vagner
                || (VehicleHash)iParam0 == VehicleHash.Cheetah2
                || (VehicleHash)iParam0 == VehicleHash.NightShark
                || (VehicleHash)iParam0 == VehicleHash.Torero
                || (VehicleHash)iParam0 == VehicleHash.XA21
                || (VehicleHash)iParam0 == VehicleHash.Tampa3
                || (VehicleHash)iParam0 == VehicleHash.Apc
                || (VehicleHash)iParam0 == VehicleHash.HalfTrack
                || (VehicleHash)iParam0 == VehicleHash.Dune3
                || (VehicleHash)iParam0 == VehicleHash.TrailerSmall2
                || (VehicleHash)iParam0 == VehicleHash.Insurgent3
                || (VehicleHash)iParam0 == VehicleHash.Technical3
                || (VehicleHash)iParam0 == VehicleHash.Phantom3
                || (VehicleHash)iParam0 == VehicleHash.Hauler2
                || (VehicleHash)iParam0 == /*Cyclone*/ (VehicleHash)1392481335
                || (VehicleHash)iParam0 == /*RapidGT3*/ (VehicleHash)2049897956
                || (VehicleHash)iParam0 == /*Retinue*/ (VehicleHash)1841130506
                || (VehicleHash)iParam0 == /*Visione*/ (VehicleHash)3296789504
                || (VehicleHash)iParam0 == /*Vigilante*/ (VehicleHash)3052358707
                || (VehicleHash)iParam0 == /*Deluxo*/ (VehicleHash)1483171323
                || (VehicleHash)iParam0 == /*Stromberg*/ (VehicleHash)886810209
                || (VehicleHash)iParam0 == /*Riot2*/ (VehicleHash)2601952180
                || (VehicleHash)iParam0 == /*Chernobog*/ (VehicleHash)3602674979
                || (VehicleHash)iParam0 == /*Khanjali*/ (VehicleHash)2859440138
                || (VehicleHash)iParam0 == /*Akula*/ (VehicleHash)1181327175
                || (VehicleHash)iParam0 == /*Thruster*/ (VehicleHash)1489874736
                || (VehicleHash)iParam0 == (VehicleHash)2176659152 /*Avenger*/
                || (VehicleHash)iParam0 == (VehicleHash)3868033424 /*Avenger3*/
                || (VehicleHash)iParam0 ==  /*Barrage*/ (VehicleHash)4081974053
                || (VehicleHash)iParam0 == /*Volatol*/ (VehicleHash)447548909
                || (VehicleHash)iParam0 == /*Comet4*/ (VehicleHash)1561920505
                || (VehicleHash)iParam0 == /*Neon*/ (VehicleHash)2445973230
                || (VehicleHash)iParam0 == /*Streiter*/ (VehicleHash)1741861769
                || (VehicleHash)iParam0 == /*Sentinel3*/ (VehicleHash)1104234922
                || (VehicleHash)iParam0 == /*Yosemite*/ (VehicleHash)1871995513
                || (VehicleHash)iParam0 == /*Sc1*/ (VehicleHash)1352136073
                || (VehicleHash)iParam0 == /*Autarch*/ (VehicleHash)3981782132
                || (VehicleHash)iParam0 == /*Gt500*/ (VehicleHash)2215179066
                || (VehicleHash)iParam0 == /*Hustler*/ (VehicleHash)600450546
                || (VehicleHash)iParam0 == /*Revolter*/ (VehicleHash)3884762073
                || (VehicleHash)iParam0 ==  /*Pariah*/ (VehicleHash)867799010
                || (VehicleHash)iParam0 == /*Raiden*/ (VehicleHash)2765724541
                || (VehicleHash)iParam0 ==  /*Savestra*/ (VehicleHash)903794909
                || (VehicleHash)iParam0 ==  /*Riata*/ (VehicleHash)2762269779
                || (VehicleHash)iParam0 == /*Hermes*/ (VehicleHash)15219735
                || (VehicleHash)iParam0 == /*Comet5*/ (VehicleHash)661493923
                || (VehicleHash)iParam0 == /*Z190*/ (VehicleHash)838982985
                || (VehicleHash)iParam0 == /*Viseris*/ (VehicleHash)3903371924
                || (VehicleHash)iParam0 == /*Kamacho*/ (VehicleHash)4173521127
                || (VehicleHash)iParam0 == /*Gb200*/ (VehicleHash)1909189272
                || (VehicleHash)iParam0 ==  /*Issi3*/ (VehicleHash)931280609
                || (VehicleHash)iParam0 == /*Ellie*/ (VehicleHash)3027423925
                || (VehicleHash)iParam0 == /*Fagaloa*/ (VehicleHash)1617472902
                || (VehicleHash)iParam0 == /*Michelli*/ (VehicleHash)1046206681
                || (VehicleHash)iParam0 == /*FlashGT*/ (VehicleHash)3035832600
                || (VehicleHash)iParam0 == /*Hotring*/ (VehicleHash)1115909093
                || (VehicleHash)iParam0 == /*Tezeract*/ (VehicleHash)1031562256
                || (VehicleHash)iParam0 == /*Tyrant*/ (VehicleHash)3918533058
                || (VehicleHash)iParam0 == /*Dominator3*/ (VehicleHash)3308022675
                || (VehicleHash)iParam0 == /*Taipan*/ (VehicleHash)3160260734
                || (VehicleHash)iParam0 == /*Entity2*/ (VehicleHash)2174267100
                || (VehicleHash)iParam0 == /*Jester3*/ (VehicleHash)4080061290
                || (VehicleHash)iParam0 == /*Cheburek*/ (VehicleHash)3306466016
                || (VehicleHash)iParam0 == /*Caracara*/ (VehicleHash)1254014755
                || (VehicleHash)iParam0 == /*Seasparrow*/ (VehicleHash)3568198617
                || (VehicleHash)iParam0 == /*Clique*/ (VehicleHash)2728360112
                || (VehicleHash)iParam0 == /*Deveste*/ (VehicleHash)1591739866
                || (VehicleHash)iParam0 == /*Deviant*/ (VehicleHash)1279262537
                || (VehicleHash)iParam0 == /*Impaler*/ (VehicleHash)2198276962
                || (VehicleHash)iParam0 == /*Scarab*/ (VehicleHash)3147997943
                || (VehicleHash)iParam0 == /*Schlagen*/ (VehicleHash)3787471536
                || (VehicleHash)iParam0 == /*Toros*/ (VehicleHash)3126015148
                || (VehicleHash)iParam0 == /*Vamos*/ (VehicleHash)4245851645
                || (VehicleHash)iParam0 == /*Tulip*/ (VehicleHash)1456744817
                || (VehicleHash)iParam0 == /*Monster3*/ (VehicleHash)1721676810
                || (VehicleHash)iParam0 == /*Impaler2*/ (VehicleHash)1009171724
                || (VehicleHash)iParam0 == /*Bruiser*/ (VehicleHash)668439077
                || (VehicleHash)iParam0 == /*Cerberus*/ (VehicleHash)3493417227
                || (VehicleHash)iParam0 == /*Dominator4*/ (VehicleHash)3606777648
                || (VehicleHash)iParam0 == /*Imperator*/ (VehicleHash)444994115
                || (VehicleHash)iParam0 == /*Issi4*/ (VehicleHash)628003514
                || (VehicleHash)iParam0 == /*ItaliGTo*/ (VehicleHash)3963499524
                || (VehicleHash)iParam0 == /*Deathbike3*/ (VehicleHash)2920466844
                || (VehicleHash)iParam0 == /*Slamvan4*/ (VehicleHash)2233918197
                || (VehicleHash)iParam0 == /*Brutus*/ (VehicleHash)2139203625
                || (VehicleHash)iParam0 == /*Imperator2*/ (VehicleHash)1637620610
                || (VehicleHash)iParam0 == /*Imperator3*/ (VehicleHash)3539435063
                || (VehicleHash)iParam0 == /*Deathbike3*/ (VehicleHash)2920466844
                || (VehicleHash)iParam0 == /*Deathbike2*/ (VehicleHash)2482017624
                || (VehicleHash)iParam0 == /*Impaler3*/ (VehicleHash)2370166601
                || (VehicleHash)iParam0 == /*Brutus2*/ (VehicleHash)2403970600
                || (VehicleHash)iParam0 == /*Bruiser2*/ (VehicleHash)2600885406
                || (VehicleHash)iParam0 == /*Slamvan5*/ (VehicleHash)373261600
                || (VehicleHash)iParam0 == /*Issi5*/ (VehicleHash)1537277726
                || (VehicleHash)iParam0 == /*Monster4*/ (VehicleHash)840387324
                || (VehicleHash)iParam0 == /*Scarab2*/ (VehicleHash)1542143200
                || (VehicleHash)iParam0 == /*Cerberus2*/ (VehicleHash)679453769
                || (VehicleHash)iParam0 == /*Dominator5*/ (VehicleHash)2919906639
                || (VehicleHash)iParam0 == /*Zr3802*/ (VehicleHash)3188846534
                || (VehicleHash)iParam0 == /*Impaler4*/ (VehicleHash)2550461639
                || (VehicleHash)iParam0 == /*Brutus3*/ (VehicleHash)2038858402
                || (VehicleHash)iParam0 == /*Bruiser3*/ (VehicleHash)2252616474
                || (VehicleHash)iParam0 == /*Slamvan6*/ (VehicleHash)1742022738
                || (VehicleHash)iParam0 == /*Issi6*/ (VehicleHash)1239571361
                || (VehicleHash)iParam0 == /*Monster5*/ (VehicleHash)3579220348
                || (VehicleHash)iParam0 == /*Scarab3*/ (VehicleHash)3715219435
                || (VehicleHash)iParam0 == /*Cerberus3*/ (VehicleHash)1909700336
                || (VehicleHash)iParam0 == /*Dominator6*/ (VehicleHash)3001042683
                || (VehicleHash)iParam0 == /*Zr3803*/ (VehicleHash)2816263004
                || (VehicleHash)iParam0 == /*Rcbandito*/ (VehicleHash)4008920556
                || (VehicleHash)iParam0 == /*Caracara2*/ (VehicleHash)2945871676
                || (VehicleHash)iParam0 == /*Drafter*/ (VehicleHash)686471183
                || (VehicleHash)iParam0 == /*Dynasty*/ (VehicleHash)310284501
                || (VehicleHash)iParam0 == /*Gauntlet3*/ (VehicleHash)722226637
                || (VehicleHash)iParam0 == /*Gauntlet4*/ (VehicleHash)1934384720
                || (VehicleHash)iParam0 == /*Hellion*/ (VehicleHash)3932816511
                || (VehicleHash)iParam0 == /*Issi7*/ (VehicleHash)1854776567
                || (VehicleHash)iParam0 == /*Krieger*/ (VehicleHash)3630826055
                || (VehicleHash)iParam0 == /*Locust*/ (VehicleHash)3353694737
                || (VehicleHash)iParam0 == /*Nebula*/ (VehicleHash)3412338231
                || (VehicleHash)iParam0 == /*Neo*/ (VehicleHash)2674840994
                || (VehicleHash)iParam0 == /*Novak*/ (VehicleHash)2465530446
                || (VehicleHash)iParam0 == /*S80*/ (VehicleHash)3970348707
                || (VehicleHash)iParam0 == /*Thrax*/ (VehicleHash)1044193113
                || (VehicleHash)iParam0 == /*Zion3*/ (VehicleHash)1862507111
                || (VehicleHash)iParam0 == /*Zorrusso*/ (VehicleHash)3612858749
                || (VehicleHash)iParam0 == /*Emerus*/ (VehicleHash)1323778901
                || (VehicleHash)iParam0 == /*Peyote2*/ (VehicleHash)2490551588
                || (VehicleHash)iParam0 == /*Rrocket*/ (VehicleHash)916547552
                || (VehicleHash)iParam0 == /*Jugular*/ (VehicleHash)4086055493
                || (VehicleHash)iParam0 == /*Paragon*/ (VehicleHash)3847255899
                || (VehicleHash)iParam0 == /*Paragon2*/ (VehicleHash)1416466158
                || (VehicleHash)iParam0 == VehicleHash.SlamVan2
                || (VehicleHash)iParam0 == /*Asbo*/ (VehicleHash)1118611807
                || (VehicleHash)iParam0 == /*Kanjo*/ (VehicleHash)409049982
                || (VehicleHash)iParam0 == /*Formula*/ (VehicleHash)340154634
                || (VehicleHash)iParam0 == /*Imorgon*/ (VehicleHash)3162245632
                || (VehicleHash)iParam0 == /*Komoda*/ (VehicleHash)3460613305
                || (VehicleHash)iParam0 == /*Manana2*/ (VehicleHash)1717532765
                || (VehicleHash)iParam0 == /*Rebla*/ (VehicleHash)83136452
                || (VehicleHash)iParam0 == /*Sugoi*/ (VehicleHash)987469656
                || (VehicleHash)iParam0 == /*Youga3*/ (VehicleHash)1802742206
                || (VehicleHash)iParam0 == /*Zhaba*/ (VehicleHash)1284356689
                || (VehicleHash)iParam0 == /*Vstr*/ (VehicleHash)1456336509
                || (VehicleHash)iParam0 == /*Everon*/ (VehicleHash)2538945576
                || (VehicleHash)iParam0 == /*Sultan2*/ (VehicleHash)872704284
                || (VehicleHash)iParam0 == /*JB7002*/ (VehicleHash)394110044
                || (VehicleHash)iParam0 == /*Outlaw*/ (VehicleHash)408825843
                || (VehicleHash)iParam0 == /*Stryder*/ (VehicleHash)301304410
                || (VehicleHash)iParam0 == /*Vagrant*/ (VehicleHash)740289177
                || (VehicleHash)iParam0 == /*Formula2*/ (VehicleHash)2334210311
                || (VehicleHash)iParam0 == /*Minitank*/ (VehicleHash)3040635986
                || (VehicleHash)iParam0 == /*Gauntlet5*/ (VehicleHash)2172320429
                || (VehicleHash)iParam0 == /*Dukes3*/ (VehicleHash)2134119907
                || (VehicleHash)iParam0 == /*Club*/ (VehicleHash)2196012677
                || (VehicleHash)iParam0 == /*Peyote3*/ (VehicleHash)1107404867
                || (VehicleHash)iParam0 == /*Glendale2*/ (VehicleHash)3381377750
                || (VehicleHash)iParam0 == /*Penumbra2*/ (VehicleHash)3663644634
                || (VehicleHash)iParam0 == /*Landstalker2*/ (VehicleHash)3456868130
                || (VehicleHash)iParam0 == /*Seminole2*/ (VehicleHash)2484160806
                || (VehicleHash)iParam0 == /*Tigon*/ (VehicleHash)2936769864
                || (VehicleHash)iParam0 == /*Openwheel1*/ (VehicleHash)1492612435
                || (VehicleHash)iParam0 == /*Coquette4*/ (VehicleHash)2566281822
                || (VehicleHash)iParam0 == /*Openwheel2*/ (VehicleHash)1181339704
                || (VehicleHash)iParam0 == /*Manchez2*/ (VehicleHash)1086534307
                || (VehicleHash)iParam0 == /*Brioso2*/ (VehicleHash)1429622905
                || (VehicleHash)iParam0 == /*Winky*/ (VehicleHash)4084658662
                || (VehicleHash)iParam0 == /*Verus*/ (VehicleHash)298565713
                || (VehicleHash)iParam0 == /*Alkonost*/ (VehicleHash)3929093893
                || (VehicleHash)iParam0 == (VehicleHash)2588363614 /*Avisa*/
                || (VehicleHash)iParam0 == /*Longfin*/ (VehicleHash)1861786828
                || (VehicleHash)iParam0 == /*Patrolboat*/ (VehicleHash)4018222598
                || (VehicleHash)iParam0 == /*Seasparrow2*/ (VehicleHash)1229411063
                || (VehicleHash)iParam0 == /*Seasparrow3*/ (VehicleHash)1593933419
                || (VehicleHash)iParam0 == /*SlamTruck*/ (VehicleHash)3249056020
                || (VehicleHash)iParam0 == /*Vetir*/ (VehicleHash)2014313426
                || (VehicleHash)iParam0 == /*Kosatka*/ (VehicleHash)1336872304
                || (VehicleHash)iParam0 == /*ItaliRSx*/ (VehicleHash)3145241962
                || (VehicleHash)iParam0 == /*Toreador*/ (VehicleHash)1455990255
                || (VehicleHash)iParam0 == /*Weevil*/ (VehicleHash)1644055914
                || (VehicleHash)iParam0 == /*Dinghy5*/ (VehicleHash)3314393930
                || (VehicleHash)iParam0 == /*Annihilator2*/ (VehicleHash)295054921
                || (VehicleHash)iParam0 == /*Squaddie*/ (VehicleHash)4192631813
                || (VehicleHash)iParam0 == /*Veto*/ (VehicleHash)3437611258
                || (VehicleHash)iParam0 == /*Veto2*/ (VehicleHash)2802050217
                || (VehicleHash)iParam0 == /*Calico*/ (VehicleHash)3101054893
                || (VehicleHash)iParam0 == /*Comet6*/ (VehicleHash)2568944644
                || (VehicleHash)iParam0 == /*Cypher*/ (VehicleHash)1755697647
                || (VehicleHash)iParam0 == /*Dominator7*/ (VehicleHash)426742808
                || (VehicleHash)iParam0 == /*Jester4*/ (VehicleHash)2712905841
                || (VehicleHash)iParam0 == /*Remus*/ (VehicleHash)1377217886
                || (VehicleHash)iParam0 == /*Vectre*/ (VehicleHash)2754593701
                || (VehicleHash)iParam0 == /*Zr350*/ (VehicleHash)2436313176
                || (VehicleHash)iParam0 == /*Warrener2*/ (VehicleHash)579912970
                || (VehicleHash)iParam0 == /*Rt3000*/ (VehicleHash)3842363289
                || (VehicleHash)iParam0 == /*Futo2*/ (VehicleHash)2787736776
                || (VehicleHash)iParam0 == /*Tailgater2*/ (VehicleHash)3050505892
                || (VehicleHash)iParam0 == /*Sultan3*/ (VehicleHash)4003946083
                || (VehicleHash)iParam0 == /*Dominator8*/ (VehicleHash)736672010
                || (VehicleHash)iParam0 == /*Euros*/ (VehicleHash)2038480341
                || (VehicleHash)iParam0 == /*Growler*/ (VehicleHash)1304459735
                || (VehicleHash)iParam0 == /*Previon*/ (VehicleHash)1416471345
                || (VehicleHash)iParam0 == /*Baller7*/ (VehicleHash)359875117
                || (VehicleHash)iParam0 == /*Astron*/ (VehicleHash)629969764
                || (VehicleHash)iParam0 == /*Buffalo4*/ (VehicleHash)3675036420
                || (VehicleHash)iParam0 == /*Comet7*/ (VehicleHash)1141395928
                || (VehicleHash)iParam0 == /*Deity*/ (VehicleHash)1532171089
                || (VehicleHash)iParam0 == /*Granger2*/ (VehicleHash)4033620423
                || (VehicleHash)iParam0 == /*Ignus*/ (VehicleHash)2850852987
                || (VehicleHash)iParam0 == /*Jubilee*/ (VehicleHash)461465043
                || (VehicleHash)iParam0 == /*Patriot3*/ (VehicleHash)3624880708
                || (VehicleHash)iParam0 == (VehicleHash)1486521356 /*Youga4*/
                || (VehicleHash)iParam0 == /*Zeno*/ (VehicleHash)655665811
                || (VehicleHash)iParam0 == (VehicleHash)1343932732 /*Mule5*/
                || (VehicleHash)iParam0 == /*Champion*/ (VehicleHash)3379732821
                || (VehicleHash)iParam0 == /*Iwagen*/ (VehicleHash)662793086
                || (VehicleHash)iParam0 == /*Reever*/ (VehicleHash)1993851908
                || (VehicleHash)iParam0 == /*Shinobi*/ (VehicleHash)1353120668
                || (VehicleHash)iParam0 == /*Brioso3*/ (VehicleHash)15214558
                || (VehicleHash)iParam0 == /*CoRSita*/ (VehicleHash)3540279623
                || (VehicleHash)iParam0 == /*Draugur*/ (VehicleHash)3526730918
                || (VehicleHash)iParam0 == /*Greenwood*/ (VehicleHash)40817712
                || (VehicleHash)iParam0 == /*Kanjosj*/ (VehicleHash)4230891418
                || (VehicleHash)iParam0 == /*Lm87*/ (VehicleHash)4284049613
                || (VehicleHash)iParam0 == /*Postlude*/ (VehicleHash)4000288633
                || (VehicleHash)iParam0 == /*Rhinehart*/ (VehicleHash)2439462158
                || (VehicleHash)iParam0 == /*Sm722*/ (VehicleHash)775514032
                || (VehicleHash)iParam0 == /*Tenf*/ (VehicleHash)3400983137
                || (VehicleHash)iParam0 == /*Tenf2*/ (VehicleHash)274946574
                || (VehicleHash)iParam0 == /*Torero2*/ (VehicleHash)4129572538
                || (VehicleHash)iParam0 == /*Vigero2*/ (VehicleHash)2536587772
                || (VehicleHash)iParam0 == /*Weevil2*/ (VehicleHash)3300595976
                || (VehicleHash)iParam0 == /*Ruiner4*/ (VehicleHash)1706945532
                || (VehicleHash)iParam0 == /*Sentinel4*/ (VehicleHash)2938086457
                || (VehicleHash)iParam0 == /*Conada*/ (VehicleHash)3817135397
                || (VehicleHash)iParam0 == /*OmniseGT*/ (VehicleHash)3789743831
                || (VehicleHash)iParam0 == /*Eudora*/ (VehicleHash)3045179290
                || (VehicleHash)iParam0 == /*Surfer3*/ (VehicleHash)3259477733
                || (VehicleHash)iParam0 == /*Journey2*/ (VehicleHash)2667889793
                || (VehicleHash)iParam0 == /*Entity3*/ (VehicleHash)1748565021
                || (VehicleHash)iParam0 == /*Panthere*/ (VehicleHash)2100457220
                || (VehicleHash)iParam0 == /*Boor*/ (VehicleHash)996383885
                || (VehicleHash)iParam0 == /*Everon2*/ (VehicleHash)4163619118
                || (VehicleHash)iParam0 == /*Tulip2*/ (VehicleHash)268758436
                || (VehicleHash)iParam0 == /*Issi8*/ (VehicleHash)1550581940
                || (VehicleHash)iParam0 == /*Broadway*/ (VehicleHash)2361724968
                || (VehicleHash)iParam0 == /*Tahoma*/ (VehicleHash)3833117047
                || (VehicleHash)iParam0 == /*Gauntlet6*/ (VehicleHash)1336514315
                || (VehicleHash)iParam0 == /*Brigham*/ (VehicleHash)3640468689
                || (VehicleHash)iParam0 == /*Clique2*/ (VehicleHash)3315674721
                || (VehicleHash)iParam0 == /*L35*/ (VehicleHash)2531292011
                || (VehicleHash)iParam0 == /*Ratel*/ (VehicleHash)3758861739;
        }
        internal static bool func_5517(int iParam0)//Position - 0x1C613A
        {
            return (VehicleHash)iParam0 == /*Hunter*/ (VehicleHash)4252008158 ||
             (VehicleHash)iParam0 == /*Bombushka*/ (VehicleHash)4262088844 ||
             (VehicleHash)iParam0 == /*Volatol*/ (VehicleHash)447548909 ||
             (VehicleHash)iParam0 == /*Akula*/ (VehicleHash)1181327175 ||
             (VehicleHash)iParam0 == /*Khanjali*/ (VehicleHash)2859440138 ||
             (VehicleHash)iParam0 == /*Strikeforce*/ (VehicleHash)1692272545 ||
             (VehicleHash)iParam0 == /*Alkonost*/ (VehicleHash)3929093893 ||
             (VehicleHash)iParam0 == /*Annihilator2*/ (VehicleHash)295054921 ||
             (VehicleHash)iParam0 == /*Conada2*/ (VehicleHash)2635962482 ||
             (VehicleHash)iParam0 == /*Streamer216*/ (VehicleHash)191916658 ||
             (VehicleHash)iParam0 == /*Raiju*/ (VehicleHash)239897677;
        }
        internal static bool func_5518(int iParam0)//Position - 0x1C6193
        {
            return (VehicleHash)iParam0 == /*Havok*/ (VehicleHash)2310691317 ||
             (VehicleHash)iParam0 == /*MicroLight*/ (VehicleHash)2531412055 ||
             (VehicleHash)iParam0 == /*Mogul*/ (VehicleHash)3545667823 ||
             (VehicleHash)iParam0 == /*Rogue*/ (VehicleHash)3319621991 ||
             (VehicleHash)iParam0 == /*Seabreeze*/ (VehicleHash)3902291871 ||
             (VehicleHash)iParam0 == /*Tula*/ (VehicleHash)1043222410 ||
             (VehicleHash)iParam0 == /*Pyro*/ (VehicleHash)2908775872 ||
             (VehicleHash)iParam0 == /*Alphaz1*/ (VehicleHash)2771347558 ||
             (VehicleHash)iParam0 == /*Howard*/ (VehicleHash)3287439187 ||
             (VehicleHash)iParam0 == /*Starling*/ (VehicleHash)2594093022 ||
             (VehicleHash)iParam0 == /*Molotok*/ (VehicleHash)1565978651 ||
             (VehicleHash)iParam0 == /*Nokota*/ (VehicleHash)1036591958 ||
             (VehicleHash)iParam0 == VehicleHash.Cuban800 ||
             (VehicleHash)iParam0 == (VehicleHash)2176659152 /*Avenger*/ ||
             (VehicleHash)iParam0 == /*Thruster*/ (VehicleHash)1489874736 ||
             (VehicleHash)iParam0 == /*Riot2*/ (VehicleHash)2601952180 ||
             (VehicleHash)iParam0 == /*Chernobog*/ (VehicleHash)3602674979 ||
             (VehicleHash)iParam0 == /*Volatol*/ (VehicleHash)447548909 ||
             (VehicleHash)iParam0 == /*Seasparrow*/ (VehicleHash)3568198617 ||
             (VehicleHash)iParam0 == (VehicleHash)1229411063 /*Seasparrow2*/ ||
             (VehicleHash)iParam0 == (VehicleHash)3868033424 /*Avenger3*/;
        }
        internal static bool func_7087(int iParam0)//Position - 0x2439A4
        {
            return func_7088(iParam0) != 114;
        }
        internal static int func_7088(int iParam0)//Position - 0x2439B5
        {
            if (func_5728())
            {
                return iParam0 switch
                {
                    330 => 6,
                    295 => 7,
                    268 => 8,
                    15 => 9,
                    288 => 10,
                    112 => 11,
                    219 => 12,
                    49 => 13,
                    165 => 14,
                    116 => 15,
                    _ => 114
                }; ;
            }
            return 114;
        }
        internal static bool func_5728()//Position - 0x1D4344
        {
            return (func_5730() || func_5729());
        }

        internal static bool func_5729()//Position - 0x1D435A
        {
            return N_0x155467aca0f55705() switch // GET_USER_STARTER_ACCESS
            {
                1
                or 2
                or 3
                or 4 => true,
                _ => false,
            };
        }

        internal static bool func_5730()//Position - 0x1D4388
        {
            return N_0x754615490a029508() switch // GET_USER_PREMIUM_ACCESS
            {
                1
                or 2
                or 3
                or 4 => true,
                _ => false,
            };
        }
        internal static int func_7266(int iParam0, int iParam1, bool bParam2, ref int iParam3)//Position - 0x25ECF5
        {
            int iVar0;

            if (Tunables.Global_262145.Value<int>("f_13536") == 1/* Tunable: REBATE_VEHICLE_DOCK */ && iParam0 == 13)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_DOCK");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13537") == 1/* Tunable: REBATE_VEHICLE_WAR */ && iParam0 == 12)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_WAR");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13538") == 1/* Tunable: REBATE_VEHICLE_LEGENDARY */ && iParam0 == 10)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_LEGENDARY");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13539") == 1/* Tunable: REBATE_VEHICLE_ELITAS */ && iParam0 == 11)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_ELITAS");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13540") == 1/* Tunable: REBATE_VEHICLE_BENNY */ && iParam0 == 26)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_BENNY");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13541") == 1/* Tunable: REBATE_VEHICLE_SSASA */ && iParam0 == 16)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_SSASA");
                return 1;
            }
            else if (Tunables.Global_262145.Value<int>("f_13542") == 1/* Tunable: REBATE_VEHICLE_PANDMCYCLES */ && iParam0 == 15)
            {
                iParam3 = GetHashKey("REBATE_VEHICLE_PANDMCYCLES");
                return 1;
            }
            iVar0 = 0;
            if (bParam2)
            {
                iVar0 = (VehicleHash)iParam1 switch
                {
                    VehicleHash.Kalahari => GetHashKey("KALAHARI_TLESS"),
                    VehicleHash.Coquette => GetHashKey("COQUETTE_TLESS"),
                    VehicleHash.Banshee => GetHashKey("BANSHEE_TLESS"),
                    VehicleHash.Stinger => GetHashKey("STINGER_TLESS"),
                    VehicleHash.Voltic => GetHashKey("VOLTIC_HTOP"),
                    VehicleHash.Coquette2 => GetHashKey("COQUETTE2_TLESS"),
                    _ => iParam1,
                };
            }
            else
                iVar0 = iParam1;
            if (iVar0 == Tunables.Global_262145.Value<int>("f_12888") /* Tunable: REBATE_VEHICLE_0 */)
            {
                iParam3 = 0;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12889") /* Tunable: REBATE_VEHICLE_1 */)
            {
                iParam3 = 1;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12890") /* Tunable: REBATE_VEHICLE_2 */)
            {
                iParam3 = 2;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12891") /* Tunable: REBATE_VEHICLE_3 */)
            {
                iParam3 = 3;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12892") /* Tunable: REBATE_VEHICLE_4 */)
            {
                iParam3 = 4;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12893") /* Tunable: REBATE_VEHICLE_5 */)
            {
                iParam3 = 5;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12894") /* Tunable: REBATE_VEHICLE_6 */)
            {
                iParam3 = 6;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12895") /* Tunable: REBATE_VEHICLE_7 */)
            {
                iParam3 = 7;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12896") /* Tunable: REBATE_VEHICLE_8 */)
            {
                iParam3 = 8;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12897") /* Tunable: REBATE_VEHICLE_9 */)
            {
                iParam3 = 9;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12898") /* Tunable: REBATE_VEHICLE_10 */)
            {
                iParam3 = 10;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12899") /* Tunable: REBATE_VEHICLE_11 */)
            {
                iParam3 = 11;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12900") /* Tunable: REBATE_VEHICLE_12 */)
            {
                iParam3 = 12;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12901") /* Tunable: REBATE_VEHICLE_13 */)
            {
                iParam3 = 13;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12902") /* Tunable: REBATE_VEHICLE_14 */)
            {
                iParam3 = 14;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12903") /* Tunable: REBATE_VEHICLE_15 */)
            {
                iParam3 = 15;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12904") /* Tunable: REBATE_VEHICLE_16 */)
            {
                iParam3 = 16;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12905") /* Tunable: REBATE_VEHICLE_17 */)
            {
                iParam3 = 17;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12906") /* Tunable: REBATE_VEHICLE_18 */)
            {
                iParam3 = 18;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12907") /* Tunable: REBATE_VEHICLE_19 */)
            {
                iParam3 = 19;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12908") /* Tunable: REBATE_VEHICLE_20 */)
            {
                iParam3 = 20;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12909") /* Tunable: REBATE_VEHICLE_21 */)
            {
                iParam3 = 21;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12910") /* Tunable: REBATE_VEHICLE_22 */)
            {
                iParam3 = 22;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12911") /* Tunable: REBATE_VEHICLE_23 */)
            {
                iParam3 = 23;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12912") /* Tunable: REBATE_VEHICLE_24 */)
            {
                iParam3 = 24;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12913") /* Tunable: REBATE_VEHICLE_25 */)
            {
                iParam3 = 25;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12914") /* Tunable: REBATE_VEHICLE_26 */)
            {
                iParam3 = 26;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12915") /* Tunable: REBATE_VEHICLE_27 */)
            {
                iParam3 = 27;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12916") /* Tunable: REBATE_VEHICLE_28 */)
            {
                iParam3 = 28;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12917") /* Tunable: REBATE_VEHICLE_29 */)
            {
                iParam3 = 29;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12918") /* Tunable: REBATE_VEHICLE_30 */)
            {
                iParam3 = 30;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12919") /* Tunable: REBATE_VEHICLE_31 */)
            {
                iParam3 = 31;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12920") /* Tunable: REBATE_VEHICLE_32 */)
            {
                iParam3 = 32;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12921") /* Tunable: REBATE_VEHICLE_33 */)
            {
                iParam3 = 33;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12922") /* Tunable: REBATE_VEHICLE_34 */)
            {
                iParam3 = 34;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12923") /* Tunable: REBATE_VEHICLE_35 */)
            {
                iParam3 = 35;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12924") /* Tunable: REBATE_VEHICLE_36 */)
            {
                iParam3 = 36;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12925") /* Tunable: REBATE_VEHICLE_37 */)
            {
                iParam3 = 37;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12926") /* Tunable: REBATE_VEHICLE_38 */)
            {
                iParam3 = 38;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12927") /* Tunable: REBATE_VEHICLE_39 */)
            {
                iParam3 = 39;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12928") /* Tunable: REBATE_VEHICLE_40 */)
            {
                iParam3 = 40;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12929") /* Tunable: REBATE_VEHICLE_41 */)
            {
                iParam3 = 41;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12930") /* Tunable: REBATE_VEHICLE_42 */)
            {
                iParam3 = 42;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12931") /* Tunable: REBATE_VEHICLE_43 */)
            {
                iParam3 = 43;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12932") /* Tunable: REBATE_VEHICLE_44 */)
            {
                iParam3 = 44;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12933") /* Tunable: REBATE_VEHICLE_45 */)
            {
                iParam3 = 45;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12934") /* Tunable: REBATE_VEHICLE_46 */)
            {
                iParam3 = 46;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12935") /* Tunable: REBATE_VEHICLE_47 */)
            {
                iParam3 = 47;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12936") /* Tunable: REBATE_VEHICLE_48 */)
            {
                iParam3 = 48;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12937") /* Tunable: REBATE_VEHICLE_49 */)
            {
                iParam3 = 49;
                return 1;
            }
            iParam3 = -1;
            return 0;
        }
        internal static int func_7191(int iParam0)//Position - 0x253645
        {
            return (VehicleHash)iParam0 switch
            {
                /*Raiju*/
                (VehicleHash)239897677 => 0,
                /*Squaddie*/
                (VehicleHash)4192631813 => 1,
                /*Manchez2*/
                (VehicleHash)1086534307 => 2,
                _ => -1,
            };
        }
        internal static int func_7192(int iParam0)//Position - 0x253673
        {
            return (VehicleHash)iParam0 switch
            {
                /*Journey2*/
                (VehicleHash)2667889793 => 0,
                /*Surfer3*/
                (VehicleHash)3259477733 => 1,
                /*Virtue*/
                (VehicleHash)669204833 => 2,
                /*Hotring*/
                (VehicleHash)1115909093 => 3,
                /*Everon2*/
                (VehicleHash)4163619118 => 4,
                VehicleHash.Taxi => 5,
                /*Brickade2*/
                (VehicleHash)2718380883 => 6,
                _ => -1,
            };
        }
        internal static int func_7193(int iParam0)//Position - 0x2536C9
        {
            return (VehicleHash)iParam0 switch
            {
                /*Kanjosj*/
                (VehicleHash)4230891418 => 0,
                /*Postlude*/
                (VehicleHash)4000288633 => 1,
                /*Greenwood*/
                (VehicleHash)40817712 => 2,
                /*Draugur*/
                (VehicleHash)3526730918 => 3,
                /*Conada*/
                (VehicleHash)3817135397 => 4,
                _ => -1,
            };
        }
        internal static int func_7194(int iParam0)//Position - 0x25370B
        {
            return (VehicleHash)iParam0 switch
            {
                /*Baller7*/
                (VehicleHash)359875117 => 0,
                /*Buffalo4*/
                (VehicleHash)3675036420 => 1,
                /*Champion*/
                (VehicleHash)3379732821 => 2,
                /*Deity*/
                (VehicleHash)1532171089 => 3,
                /*Granger2*/
                (VehicleHash)4033620423 => 4,
                /*Jubilee*/
                (VehicleHash)461465043 => 5,
                (VehicleHash)1343932732 /*Mule5*/ => 6,
                /*Patriot3*/
                (VehicleHash)3624880708 => 7,
                (VehicleHash)1486521356 /*Youga4*/ => 8,
                _ => -1,
            };
        }
        internal static int func_7195(int iParam0)//Position - 0x253776
        {
            return (VehicleHash)iParam0 switch
            {
                /*Zr350*/
                (VehicleHash)2436313176 => 0,
                /*Comet6*/
                (VehicleHash)2568944644 => 1,
                /*Jester4*/
                (VehicleHash)2712905841 => 2,
                /*Vectre*/
                (VehicleHash)2754593701 => 3,
                /*Cypher*/
                (VehicleHash)1755697647 => 4,
                /*Tailgater2*/
                (VehicleHash)3050505892 => 5,
                /*Euros*/
                (VehicleHash)2038480341 => 6,
                /*Growler*/
                (VehicleHash)1304459735 => 7,
                /*Calico*/
                (VehicleHash)3101054893 => 8,
                /*Remus*/
                (VehicleHash)1377217886 => 9,
                /*Dominator7*/
                (VehicleHash)426742808 => 10,
                /*Futo2*/
                (VehicleHash)2787736776 => 11,
                /*Rt3000*/
                (VehicleHash)3842363289 => 12,
                /*Warrener2*/
                (VehicleHash)579912970 => 13,
                /*Sultan3*/
                (VehicleHash)4003946083 => 14,
                /*Dominator8*/
                (VehicleHash)736672010 => 15,
                /*Previon*/
                (VehicleHash)1416471345 => 16,
                _ => -1,
            };
        }
        internal static int func_7198(int iParam0)//Position - 0x253A09
        {
            return (VehicleHash)iParam0 switch
            {
                /*Cerberus*/
                (VehicleHash)3493417227 => 0,
                /*Cerberus2*/
                (VehicleHash)679453769 => 1,
                /*Cerberus3*/
                (VehicleHash)1909700336 => 2,
                /*Brutus*/
                (VehicleHash)2139203625 => 3,
                /*Brutus2*/
                (VehicleHash)2403970600 => 4,
                /*Brutus3*/
                (VehicleHash)2038858402 => 5,
                /*Scarab*/
                (VehicleHash)3147997943 => 6,
                /*Scarab2*/
                (VehicleHash)1542143200 => 7,
                /*Scarab3*/
                (VehicleHash)3715219435 => 8,
                /*Imperator*/
                (VehicleHash)444994115 => 9,
                /*Imperator2*/
                (VehicleHash)1637620610 => 10,
                /*Imperator3*/
                (VehicleHash)3539435063 => 11,
                /*Zr380*/
                (VehicleHash)540101442 => 12,
                /*Zr3802*/
                (VehicleHash)3188846534 => 13,
                /*Zr3803*/
                (VehicleHash)2816263004 => 14,
                VehicleHash.RatLoader2 => 15,
                VehicleHash.Glendale => 16,
                VehicleHash.SlamVan => 17,
                VehicleHash.Dominator => 18,
                /*Impaler*/
                (VehicleHash)2198276962 => 19,
                /*Issi3*/
                (VehicleHash)931280609 => 20,
                VehicleHash.Gargoyle => 21,
                _ => -1,
            };
        }
        internal static int func_7199(int iParam0)//Position - 0x253B03
        {
            return (VehicleHash)iParam0 switch
            {
                /*Mule4*/
                (VehicleHash)1945374990 => 0,
                /*Pounder2*/
                (VehicleHash)1653666139 => 1,
                /*Oppressor2*/
                (VehicleHash)2069146067 => 2,
                /*PBus2*/
                (VehicleHash)345756458 => 3,
                /*Patriot2*/
                (VehicleHash)3874056184 => 4,
                /*Blimp3*/
                (VehicleHash)3987008919 => 5,
                _ => -1,
            };
        }
        internal static int func_7200(int iParam0)//Position - 0x253B61
        {
            return (VehicleHash)iParam0 switch
            {
                /*Deluxo*/
                (VehicleHash)1483171323 => 0,
                /*Akula*/
                (VehicleHash)1181327175 => 1,
                /*Riot2*/
                (VehicleHash)2601952180 => 2,
                /*Stromberg*/
                (VehicleHash)886810209 => 3,
                /*Chernobog*/
                (VehicleHash)3602674979 => 4,
                /*Barrage*/
                (VehicleHash)4081974053 => 5,
                /*Khanjali*/
                (VehicleHash)2859440138 => 6,
                /*Volatol*/
                (VehicleHash)447548909 => 7,
                /*Thruster*/
                (VehicleHash)1489874736 => 8,
                _ => -1,
            };
        }
        internal static int func_7201(int iParam0)//Position - 0x253BE7
        {
            return (VehicleHash)iParam0 switch
            {
                /*MicroLight*/
                (VehicleHash)2531412055 => Tunables.Global_262145.Value<int>("f_22892") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_MICROLIGHT */,
                /*Rogue*/
                (VehicleHash)3319621991 => Tunables.Global_262145.Value<int>("f_22893") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_ROGUE */,
                /*Alphaz1*/
                (VehicleHash)2771347558 => Tunables.Global_262145.Value<int>("f_22894") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_ALPHAZ1 */,
                /*Havok*/
                (VehicleHash)2310691317 => Tunables.Global_262145.Value<int>("f_22895") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_HAVOK */,
                /*Starling*/
                (VehicleHash)2594093022 => Tunables.Global_262145.Value<int>("f_22896") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_STARLING */,
                /*Molotok*/
                (VehicleHash)1565978651 => Tunables.Global_262145.Value<int>("f_22897") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_MOLOTOK */,
                /*Tula*/
                (VehicleHash)1043222410 => Tunables.Global_262145.Value<int>("f_22898") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_TULA */,
                /*Bombushka*/
                (VehicleHash)4262088844 => Tunables.Global_262145.Value<int>("f_22899") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_BOMBUSHKA */,
                /*Howard*/
                (VehicleHash)3287439187 => Tunables.Global_262145.Value<int>("f_22900") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_HOWARD */,
                /*Mogul*/
                (VehicleHash)3545667823 => Tunables.Global_262145.Value<int>("f_22901") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_MOGUL */,
                /*Pyro*/
                (VehicleHash)2908775872 => Tunables.Global_262145.Value<int>("f_22902") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_PYRO */,
                /*Seabreeze*/
                (VehicleHash)3902291871 => Tunables.Global_262145.Value<int>("f_22903") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_SEABREEZE */,
                /*Nokota*/
                (VehicleHash)1036591958 => Tunables.Global_262145.Value<int>("f_22904") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_NOKOTA */,
                /*Hunter*/
                (VehicleHash)4252008158 => Tunables.Global_262145.Value<int>("f_22905") /* Tunable: SMUG_NUMBER_OF_STEAL_MISSIONS_TO_UNLOCK_HUNTER */,
                _ => 0,
            };
        }
        internal static int func_7202(int iParam0)//Position - 0x253CD7
        {
            return (VehicleHash)iParam0 switch
            {
                VehicleHash.Dune3 => 0,
                VehicleHash.HalfTrack => 1,
                VehicleHash.TrailerSmall2 => 2,
                VehicleHash.Apc => 3,
                VehicleHash.Tampa3 => 4,
                VehicleHash.Oppressor => 5,
                _ => -1,
            };
        }
        internal static int func_7204(int iParam0)//Position - 0x253DEF
        {
            int iVar0;

            iVar0 = iParam0;
            return (VehicleHash)iVar0 switch
            {
                VehicleHash.Technical2 => 0,
                VehicleHash.Boxville5 => 1,
                VehicleHash.Wastelander => 2,
                VehicleHash.Phantom2 => 3,
                VehicleHash.Voltic2 => 4,
                VehicleHash.Dune4 => 5,
                VehicleHash.Dune5 => 5,
                VehicleHash.Ruiner2 => 6,
                VehicleHash.Blazer5 => 7,
                _ => -1,
            };
        }
        internal static int func_7196(int iParam0)//Position - 0x253839
        {
            return (VehicleHash)iParam0 switch
            {
                /*Vetir*/
                (VehicleHash)2014313426 => 0,
                /*Winky*/
                (VehicleHash)4084658662 => 1,
                /*Longfin*/
                (VehicleHash)1861786828 => 2,
                /*Annihilator2*/
                (VehicleHash)295054921 => 3,
                /*Alkonost*/
                (VehicleHash)3929093893 => 4,
                /*Patrolboat*/
                (VehicleHash)4018222598 => 5,
                /*Brioso2*/
                (VehicleHash)1429622905 => 6,
                /*Weevil*/
                (VehicleHash)1644055914 => 7,
                /*ItaliRSx*/
                (VehicleHash)3145241962 => 8,
                _ => -1,
            };
        }
        internal static int func_7197(int iParam0)//Position - 0x2538BF
        {
            return (VehicleHash)iParam0 switch
            {
                VehicleHash.FireTruk => 0,
                VehicleHash.Burrito2 => 1,
                VehicleHash.Boxville => 2,
                VehicleHash.Stockade => 3,
                /*Asbo*/
                (VehicleHash)1118611807 => 4,
                /*Kanjo*/
                (VehicleHash)409049982 => 5,
                /*Everon*/
                (VehicleHash)2538945576 => 6,
                /*Retinue2*/
                (VehicleHash)2031587082 => 7,
                /*Yosemite2*/
                (VehicleHash)1693751655 => 8,
                /*Sugoi*/
                (VehicleHash)987469656 => 9,
                /*Sultan2*/
                (VehicleHash)872704284 => 10,
                /*Outlaw*/
                (VehicleHash)408825843 => 11,
                /*Vagrant*/
                (VehicleHash)740289177 => 12,
                /*Komoda*/
                (VehicleHash)3460613305 => 13,
                /*Stryder*/
                (VehicleHash)301304410 => 14,
                /*Furia*/
                (VehicleHash)960812448 => 15,
                /*Zhaba*/
                (VehicleHash)1284356689 => 16,
                /*Jugular*/
                (VehicleHash)4086055493 => 17,
                /*Sentinel3*/
                (VehicleHash)1104234922 => 18,
                /*Gauntlet3*/
                (VehicleHash)722226637 => 19,
                /*Ellie*/
                (VehicleHash)3027423925 => 20,
                VehicleHash.Defiler => 21,
                VehicleHash.Manchez => 22,
                _ => -1,
            };
        }
        internal static int func_7085(int iParam0)//Position - 0x2438EF
        {
            return (VehicleHash)iParam0 switch
            {
                /*Penumbra2*/
                (VehicleHash)3663644634 => 0,
                /*Seminole2*/
                (VehicleHash)2484160806 => 1,
                /*Landstalker2*/
                (VehicleHash)3456868130 => 2,
                VehicleHash.Wolfsbane => 3,
                /*Club*/
                (VehicleHash)2196012677 => 4,
                /*Dukes3*/
                (VehicleHash)2134119907 => 5,
                _ => -1,
            };
        }
        internal static int func_830(int iParam0)//Position - 0x60456
        {
            return (VehicleHash)iParam0 switch
            {
                VehicleHash.ZType => 0,
                VehicleHash.Stinger => 1,
                VehicleHash.JB700 => 2,
                VehicleHash.Cheetah => 3,
                VehicleHash.EntityXF => 4,
                VehicleHash.Adder => 5,
                VehicleHash.Monroe => 6,
                VehicleHash.CogCabrio => 7,
                VehicleHash.Shamal => 10,
                VehicleHash.Stunt => 11,
                VehicleHash.Cuban800 => 12,
                VehicleHash.Duster => 13,
                VehicleHash.Luxor => 14,
                VehicleHash.Frogger => 15,
                VehicleHash.Maverick => 16,
                VehicleHash.Rhino => 17,
                VehicleHash.Titan => 18,
                VehicleHash.Cargobob => 19,
                VehicleHash.Buzzard => 20,
                VehicleHash.Crusader => 21,
                VehicleHash.Barracks => 22,
                VehicleHash.Marquis => 24,
                VehicleHash.Jetmax => 25,
                VehicleHash.Squalo => 27,
                VehicleHash.Tropic => 29,
                VehicleHash.Seashark => 30,
                VehicleHash.Submersible => 31,
                VehicleHash.Suntrap => 32,
                VehicleHash.Tug => 258,
                VehicleHash.Bmx => 33,
                VehicleHash.Scorcher => 34,
                VehicleHash.TriBike => 35,
                VehicleHash.TriBike2 => 36,
                VehicleHash.TriBike3 => 37,
                VehicleHash.Cruiser => 38,
                VehicleHash.Schwarzer => 39,
                VehicleHash.Zion => 40,
                VehicleHash.Gauntlet => 41,
                VehicleHash.Vigero => 42,
                VehicleHash.Issi2 => 43,
                VehicleHash.Infernus => 44,
                VehicleHash.Surano => 45,
                VehicleHash.Vacca => 46,
                VehicleHash.Ninef => 47,
                VehicleHash.Comet2 => 48,
                VehicleHash.Banshee => 49,
                VehicleHash.Feltzer2 => 50,
                VehicleHash.BfInjection => 51,
                VehicleHash.Sandking => 52,
                VehicleHash.Fugitive => 53,
                VehicleHash.Dilettante => 54,
                VehicleHash.Superd => 55,
                VehicleHash.Exemplar => 56,
                VehicleHash.Baller2 => 57,
                VehicleHash.Cavalcade => 58,
                VehicleHash.Rocoto => 59,
                VehicleHash.Felon => 60,
                VehicleHash.Oracle2 => 61,
                VehicleHash.Bati => 62,
                VehicleHash.Akuma => 63,
                VehicleHash.Ruffian => 64,
                VehicleHash.Vader => 65,
                VehicleHash.Blazer => 66,
                VehicleHash.PCJ => 67,
                VehicleHash.Sanchez => 68,
                VehicleHash.Faggio2 => 69,
                VehicleHash.Airbus => 82,
                VehicleHash.Annihilator => 78,
                VehicleHash.Bati2 => 94,
                VehicleHash.Bison => 89,
                VehicleHash.Bullet => 70,
                VehicleHash.Bus => 83,
                VehicleHash.Carbonizzare => 71,
                VehicleHash.Coach => 84,
                VehicleHash.Coquette => 72,
                VehicleHash.Double => 90,
                VehicleHash.Dump => 81,
                VehicleHash.Felon2 => 91,
                VehicleHash.Hexer => 92,
                VehicleHash.Journey => 85,
                VehicleHash.Mammatus => 79,
                VehicleHash.Mule => 86,
                VehicleHash.Ninef2 => 73,
                VehicleHash.RapidGT => 74,
                VehicleHash.RapidGT2 => 75,
                VehicleHash.RentalBus => 87,
                VehicleHash.StingerGT => 76,
                VehicleHash.Stretch => 88,
                VehicleHash.Velum => 80,
                VehicleHash.Voltic => 77,
                VehicleHash.Zion2 => 93,
                VehicleHash.Elegy2 => 95,
                VehicleHash.Khamelion => 96,
                VehicleHash.Hotknife => 97,
                VehicleHash.CarbonRS => 98,
                VehicleHash.Bodhi2 => 103,
                VehicleHash.Dune => 104,
                VehicleHash.Rebel => 105,
                VehicleHash.Sadler => 106,
                VehicleHash.Sanchez2 => 107,
                VehicleHash.Sandking2 => 108,
                VehicleHash.Asea => 128,
                VehicleHash.Asterope => 129,
                VehicleHash.BobcatXL => 130,
                VehicleHash.Cavalcade2 => 131,
                VehicleHash.Granger => 132,
                VehicleHash.Ingot => 133,
                VehicleHash.Intruder => 134,
                VehicleHash.Minivan => 135,
                VehicleHash.Premier => 136,
                VehicleHash.Radi => 137,
                VehicleHash.RancherXL => 138,
                VehicleHash.RatLoader => 139,
                VehicleHash.Stanier => 140,
                VehicleHash.Stratum => 141,
                VehicleHash.Washington => 142,
                VehicleHash.Dominator => 122,
                VehicleHash.F620 => 123,
                VehicleHash.Fusilade => 124,
                VehicleHash.Penumbra => 125,
                VehicleHash.Sentinel => 126,
                VehicleHash.Sentinel2 => 127,
                VehicleHash.Picador => 150,
                VehicleHash.Regina => 151,
                VehicleHash.Surfer => 152,
                VehicleHash.Youga => 153,
                VehicleHash.Blazer3 => 154,
                VehicleHash.Rebel2 => 155,
                VehicleHash.Primo => 156,
                VehicleHash.Buffalo => 157,
                VehicleHash.Buffalo2 => 158,
                VehicleHash.Tailgater => 159,
                VehicleHash.Bifta => 99,
                VehicleHash.Kalahari => 100,
                VehicleHash.Paradise => 101,
                VehicleHash.Speeder => 102,
                (VehicleHash)117401876 /*Roosevelt*/ or VehicleHash.BType => 109,
                VehicleHash.Jester => 111,
                VehicleHash.Massacro => 114,
                VehicleHash.Turismor => 112,
                VehicleHash.Zentorno => 115,
                VehicleHash.Huntley => 116,
                VehicleHash.Alpha => 110,
                VehicleHash.Vestra => 113,
                VehicleHash.Thrust => 121,
                VehicleHash.Blade => 143,
                VehicleHash.Warrener => 144,
                VehicleHash.Glendale => 145,
                VehicleHash.Rhapsody => 146,
                VehicleHash.Panto => 147,
                VehicleHash.Dubsta3 => 148,
                VehicleHash.Pigalle => 149,
                VehicleHash.Monster => 160,
                VehicleHash.Sovereign => 161,
                VehicleHash.Miljet => 162,
                VehicleHash.Besra => 163,
                VehicleHash.Swift => 164,
                VehicleHash.Coquette2 => 165,
                VehicleHash.Innovation => 167,
                VehicleHash.Hakuchou => 168,
                VehicleHash.Furoregt => 169,
                VehicleHash.Valkyrie => 187,
                VehicleHash.Hydra => 177,
                VehicleHash.Savage => 185,
                VehicleHash.Enduro => 174,
                VehicleHash.Boxville4 => 171,
                VehicleHash.Casco => 172,
                VehicleHash.Dinghy3 => 173,
                VehicleHash.Guardian => 176,
                VehicleHash.Insurgent => 178,
                VehicleHash.Mule3 => 183,
                VehicleHash.Insurgent2 => 179,
                VehicleHash.Lectro => 182,
                VehicleHash.PBus => 184,
                VehicleHash.Technical => 186,
                VehicleHash.Velum2 => 188,
                VehicleHash.Gresley => 189,
                VehicleHash.Jackal => 190,
                VehicleHash.Kuruma => 180,
                VehicleHash.Kuruma2 => 181,
                VehicleHash.Landstalker => 191,
                VehicleHash.Mesa3 => 192,
                VehicleHash.Nemesis => 193,
                VehicleHash.Oracle => 194,
                VehicleHash.Rumpo => 195,
                VehicleHash.Schafter2 => 196,
                VehicleHash.Seminole => 197,
                VehicleHash.Surge => 198,
                VehicleHash.Dodo => 199,
                VehicleHash.Marshall => 200,
                VehicleHash.Submersible2 => 201,
                VehicleHash.Blista2 => 202,
                VehicleHash.Stalion => 203,
                VehicleHash.Dukes => 204,
                VehicleHash.Dukes2 => 205,
                VehicleHash.Stalion2 => 206,
                VehicleHash.Dominator2 => 207,
                VehicleHash.Gauntlet2 => 208,
                VehicleHash.Buffalo3 => 209,
                VehicleHash.SlamVan => 210,
                VehicleHash.RatLoader2 => 211,
                VehicleHash.Jester2 => 212,
                VehicleHash.Massacro2 => 213,
                VehicleHash.Feltzer3 => 214,
                VehicleHash.Luxor2 => 215,
                VehicleHash.Osiris => 216,
                VehicleHash.Swift2 => 217,
                VehicleHash.Virgo => 218,
                VehicleHash.Windsor => 219,
                VehicleHash.Brawler => 220,
                VehicleHash.Chino => 221,
                VehicleHash.Coquette3 => 222,
                VehicleHash.T20 => 223,
                VehicleHash.Toro => 224,
                VehicleHash.Vindicator => 225,
                VehicleHash.Moonbeam => 228,
                VehicleHash.Faction => 227,
                VehicleHash.Buccaneer => 226,
                VehicleHash.Voodoo2 => 230,
                VehicleHash.BType2 => 231,
                VehicleHash.Lurcher => 232,
                VehicleHash.Virgo3 => 251,
                VehicleHash.Tornado => 250,
                VehicleHash.SabreGT => 249,
                VehicleHash.Baller3 or VehicleHash.Baller5 => 233,
                VehicleHash.Baller4 or VehicleHash.Baller6 => 234,
                VehicleHash.Cog55 => 235,
                VehicleHash.Cognoscenti => 236,
                VehicleHash.Limo2 => 237,
                VehicleHash.Mamba => 238,
                VehicleHash.Nightshade => 239,
                VehicleHash.Schafter3 or VehicleHash.Schafter5 => 240,
                VehicleHash.Schafter4 or VehicleHash.Schafter6 => 241,
                VehicleHash.Verlierer2 => 242,
                VehicleHash.Supervolito => 243,
                VehicleHash.Supervolito2 => 244,
                (VehicleHash)1338692320/*Apa_mp_apa_yacht*/ => 245,
                VehicleHash.Tampa => 246,
                VehicleHash.Sultan => 247,
                (VehicleHash)117401876 /*Roosevelt2*/ or VehicleHash.BType3 => 248,
                VehicleHash.Volatus => 253,
                VehicleHash.Cargobob2 => 254,
                VehicleHash.Rumpo3 => 255,
                VehicleHash.Brickade => 256,
                VehicleHash.Nimbus => 257,
                VehicleHash.Windsor2 => 259,
                VehicleHash.Prototipo => 260,
                VehicleHash.FMJ => 261,
                VehicleHash.BestiaGTS => 262,
                VehicleHash.XLS or VehicleHash.XLS2 => 263,
                VehicleHash.Seven70 => 264,
                VehicleHash.Pfister811 => 265,
                VehicleHash.Reaper => 266,
                VehicleHash.LE7B => 267,
                VehicleHash.Omnis => 268,
                VehicleHash.Tropos => 269,
                VehicleHash.Brioso => 270,
                VehicleHash.TrophyTruck => 271,
                VehicleHash.TrophyTruck2 => 272,
                VehicleHash.Contender => 273,
                VehicleHash.Cliffhanger => 274,
                VehicleHash.BF400 => 275,
                VehicleHash.Tyrus => 279,
                VehicleHash.Lynx => 280,
                VehicleHash.Sheava => 281,
                VehicleHash.RallyTruck => 276,
                VehicleHash.Tampa2 => 277,
                VehicleHash.Gargoyle => 278,
                VehicleHash.Bagger => 282,
                VehicleHash.Esskey => 283,
                VehicleHash.Nightblade => 284,
                VehicleHash.Defiler => 285,
                VehicleHash.Avarus => 286,
                VehicleHash.ZombieA => 287,
                VehicleHash.ZombieB => 288,
                VehicleHash.Chimera => 289,
                VehicleHash.Daemon2 => 290,
                VehicleHash.RatBike => 291,
                VehicleHash.Shotaro => 292,
                VehicleHash.Raptor => 293,
                VehicleHash.Hakuchou2 => 294,
                VehicleHash.Blazer4 => 296,
                VehicleHash.Sanctus => 297,
                VehicleHash.Vortex => 295,
                VehicleHash.Manchez => 298,
                VehicleHash.Tornado6 => 299,
                VehicleHash.Youga2 => 300,
                VehicleHash.Wolfsbane => 301,
                VehicleHash.Faggio3 => 302,
                VehicleHash.Faggio => 303,
                VehicleHash.Dune5 => 304,
                VehicleHash.Phantom2 => 305,
                VehicleHash.Technical2 => 306,
                VehicleHash.Blazer5 => 307,
                VehicleHash.Boxville5 => 308,
                VehicleHash.Wastelander => 309,
                VehicleHash.Ruiner2 => 310,
                VehicleHash.Voltic2 => 311,
                VehicleHash.Penetrator => 312,
                VehicleHash.Tempesta => 313,
                VehicleHash.ItaliGTB => 314,
                VehicleHash.Nero => 315,
                VehicleHash.Diablous => 316,
                VehicleHash.FCR => 317,
                VehicleHash.Specter => 318,
                VehicleHash.GP1 => 319,
                VehicleHash.Infernus2 => 320,
                VehicleHash.Ruston => 321,
                VehicleHash.Turismo2 => 322,
                (VehicleHash)886151985 => 324,
                VehicleHash.Cheetah2 => 325,
                VehicleHash.Torero => 326,
                VehicleHash.Vagner => 327,
                VehicleHash.XA21 => 328,
                VehicleHash.Apc => 329,
                VehicleHash.Dune3 => 330,
                VehicleHash.HalfTrack => 331,
                VehicleHash.Oppressor => 332,
                VehicleHash.Tampa3 => 333,
                VehicleHash.TrailerSmall2 => 334,
                VehicleHash.Ardent => 335,
                VehicleHash.NightShark => 336,
                VehicleHash.Lazer => 337,
                /*MicroLight*/
                (VehicleHash)2531412055 => 338,
                /*Mogul*/
                (VehicleHash)3545667823 => 339,
                /*Rogue*/
                (VehicleHash)3319621991 => 340,
                /*Starling*/
                (VehicleHash)2594093022 => 341,
                /*Seabreeze*/
                (VehicleHash)3902291871 => 342,
                /*Tula*/
                (VehicleHash)1043222410 => 343,
                /*Pyro*/
                (VehicleHash)2908775872 => 344,
                /*Molotok*/
                (VehicleHash)1565978651 => 345,
                /*Nokota*/
                (VehicleHash)1036591958 => 346,
                /*Bombushka*/
                (VehicleHash)4262088844 => 347,
                /*Hunter*/
                (VehicleHash)4252008158 => 348,
                /*Havok*/
                (VehicleHash)2310691317 => 349,
                /*Howard*/
                (VehicleHash)3287439187 => 350,
                /*Alphaz1*/
                (VehicleHash)2771347558 => 351,
                /*Cyclone*/
                (VehicleHash)1392481335 => 352,
                /*Visione*/
                (VehicleHash)3296789504 => 353,
                /*Retinue*/
                (VehicleHash)1841130506 => 354,
                /*RapidGT3*/
                (VehicleHash)2049897956 => 355,
                /*Vigilante*/
                (VehicleHash)3052358707 => 356,
                /*Deluxo*/
                (VehicleHash)1483171323 => 358,
                /*Stromberg*/
                (VehicleHash)886810209 => 359,
                /*Riot2*/
                (VehicleHash)2601952180 => 360,
                /*Chernobog*/
                (VehicleHash)3602674979 => 361,
                /*Khanjali*/
                (VehicleHash)2859440138 => 362,
                /*Akula*/
                (VehicleHash)1181327175 => 363,
                /*Thruster*/
                (VehicleHash)1489874736 => 364,
                /*Barrage*/
                (VehicleHash)4081974053 => 365,
                /*Volatol*/
                (VehicleHash)447548909 => 366,
                /*Comet4*/
                (VehicleHash)1561920505 => 367,
                /*Neon*/
                (VehicleHash)2445973230 => 368,
                /*Streiter*/
                (VehicleHash)1741861769 => 369,
                /*Sentinel3*/
                (VehicleHash)1104234922 => 370,
                /*Yosemite*/
                (VehicleHash)1871995513 => 371,
                /*Sc1*/
                (VehicleHash)1352136073 => 372,
                /*Autarch*/
                (VehicleHash)3981782132 => 373,
                /*Gt500*/
                (VehicleHash)2215179066 => 374,
                /*Hustler*/
                (VehicleHash)600450546 => 375,
                /*Revolter*/
                (VehicleHash)3884762073 => 376,
                /*Pariah*/
                (VehicleHash)867799010 => 377,
                /*Raiden*/
                (VehicleHash)2765724541 => 378,
                /*Savestra*/
                (VehicleHash)903794909 => 379,
                /*Riata*/
                (VehicleHash)2762269779 => 380,
                /*Hermes*/
                (VehicleHash)15219735 => 381,
                /*Comet5*/
                (VehicleHash)661493923 => 382,
                /*Z190*/
                (VehicleHash)838982985 => 383,
                /*Viseris*/
                (VehicleHash)3903371924 => 384,
                /*Kamacho*/
                (VehicleHash)4173521127 => 385,
                /*Gb200*/
                (VehicleHash)1909189272 => 386,
                /*Fagaloa*/
                (VehicleHash)1617472902 => 387,
                /*Ellie*/
                (VehicleHash)3027423925 => 388,
                /*Issi3*/
                (VehicleHash)931280609 => 389,
                /*Michelli*/
                (VehicleHash)1046206681 => 390,
                /*FlashGT*/
                (VehicleHash)3035832600 => 391,
                /*Hotring*/
                (VehicleHash)1115909093 => 392,
                /*Tezeract*/
                (VehicleHash)1031562256 => 393,
                /*Tyrant*/
                (VehicleHash)3918533058 => 394,
                /*Dominator3*/
                (VehicleHash)3308022675 => 395,
                /*Taipan*/
                (VehicleHash)3160260734 => 396,
                /*Entity2*/
                (VehicleHash)2174267100 => 397,
                /*Jester3*/
                (VehicleHash)4080061290 => 398,
                /*Cheburek*/
                (VehicleHash)3306466016 => 399,
                /*Caracara*/
                (VehicleHash)1254014755 => 400,
                /*Seasparrow*/
                (VehicleHash)3568198617 => 401,
                /*Mule4*/
                (VehicleHash)1945374990 => 403,
                /*Pounder2*/
                (VehicleHash)1653666139 => 404,
                /*Swinger*/
                (VehicleHash)500482303 => 405,
                /*Menacer*/
                (VehicleHash)2044532910 => 406,
                /*Scramjet*/
                (VehicleHash)3656405053 => 407,
                /*Strikeforce*/
                (VehicleHash)1692272545 => 408,
                /*Oppressor2*/
                (VehicleHash)2069146067 => 409,
                /*Patriot2*/
                (VehicleHash)3874056184 => 410,
                /*Stafford*/
                (VehicleHash)321186144 => 411,
                /*Freecrawler*/
                (VehicleHash)4240635011 => 412,
                VehicleHash.Futo => 415,
                VehicleHash.Ruiner => 416,
                VehicleHash.Romero => 417,
                VehicleHash.Prairie => 418,
                VehicleHash.Baller => 419,
                VehicleHash.Serrano => 420,
                VehicleHash.BJXL => 421,
                VehicleHash.Habanero => 422,
                VehicleHash.FQ2 => 423,
                VehicleHash.Patriot => 424,
                /*Blimp3*/
                (VehicleHash)3987008919 => 413,
                /*PBus2*/
                (VehicleHash)345756458 => 414,
                /*Cerberus*/
                (VehicleHash)3493417227 => 425,
                /*Cerberus2*/
                (VehicleHash)679453769 => 426,
                /*Cerberus3*/
                (VehicleHash)1909700336 => 427,
                /*Brutus*/
                (VehicleHash)2139203625 => 428,
                /*Brutus2*/
                (VehicleHash)2403970600 => 429,
                /*Brutus3*/
                (VehicleHash)2038858402 => 430,
                /*Scarab*/
                (VehicleHash)3147997943 => 431,
                /*Scarab2*/
                (VehicleHash)1542143200 => 432,
                /*Scarab3*/
                (VehicleHash)3715219435 => 433,
                /*Imperator*/
                (VehicleHash)444994115 => 434,
                /*Imperator2*/
                (VehicleHash)1637620610 => 435,
                /*Imperator3*/
                (VehicleHash)3539435063 => 436,
                /*Zr380*/
                (VehicleHash)540101442 => 437,
                /*Zr3802*/
                (VehicleHash)3188846534 => 438,
                /*Zr3803*/
                (VehicleHash)2816263004 => 439,
                /*Impaler*/
                (VehicleHash)2198276962 => 440,
                VehicleHash.Taxi => 450,
                VehicleHash.Bulldozer => 451,
                VehicleHash.Speedo2 => 452,
                VehicleHash.Trash2 => 453,
                VehicleHash.Barracks2 => 454,
                VehicleHash.Mixer => 455,
                VehicleHash.Dune2 => 456,
                VehicleHash.Tractor => 457,
                VehicleHash.Blista3 => 458,
                /*Vamos*/
                (VehicleHash)4245851645 => 441,
                /*Tulip*/
                (VehicleHash)1456744817 => 442,
                /*Deveste*/
                (VehicleHash)1591739866 => 443,
                /*Schlagen*/
                (VehicleHash)3787471536 => 444,
                /*Toros*/
                (VehicleHash)3126015148 => 445,
                /*Deviant*/
                (VehicleHash)1279262537 => 446,
                /*Clique*/
                (VehicleHash)2728360112 => 447,
                /*ItaliGTo*/
                (VehicleHash)3963499524 => 448,
                /*Rcbandito*/
                (VehicleHash)4008920556 => 449,
                /*Thrax*/
                (VehicleHash)1044193113 => 459,
                /*Drafter*/
                (VehicleHash)686471183 => 460,
                /*Locust*/
                (VehicleHash)3353694737 => 461,
                /*Novak*/
                (VehicleHash)2465530446 => 462,
                /*Zorrusso*/
                (VehicleHash)3612858749 => 463,
                /*Gauntlet3*/
                (VehicleHash)722226637 => 464,
                /*Issi7*/
                (VehicleHash)1854776567 => 465,
                /*Zion3*/
                (VehicleHash)1862507111 => 466,
                /*Nebula*/
                (VehicleHash)3412338231 => 467,
                /*Hellion*/
                (VehicleHash)3932816511 => 468,
                /*Dynasty*/
                (VehicleHash)310284501 => 469,
                /*Rrocket*/
                (VehicleHash)916547552 => 470,
                /*Peyote2*/
                (VehicleHash)2490551588 => 471,
                /*Gauntlet4*/
                (VehicleHash)1934384720 => 472,
                /*Caracara2*/
                (VehicleHash)2945871676 => 473,
                /*Jugular*/
                (VehicleHash)4086055493 => 474,
                /*S80*/
                (VehicleHash)3970348707 => 475,
                /*Krieger*/
                (VehicleHash)3630826055 => 476,
                /*Emerus*/
                (VehicleHash)1323778901 => 477,
                /*Neo*/
                (VehicleHash)2674840994 => 478,
                /*Paragon*/
                (VehicleHash)3847255899 => 479,
                VehicleHash.FireTruk => 480,
                VehicleHash.Burrito2 => 481,
                VehicleHash.Boxville => 482,
                VehicleHash.Stockade => 483,
                VehicleHash.Lguard => 484,
                VehicleHash.Blazer2 => 485,
                /*JB7002*/
                (VehicleHash)394110044 => 488,
                /*Zhaba*/
                (VehicleHash)1284356689 => 486,
                /*Minitank*/
                (VehicleHash)3040635986 => 487,
                /*Stryder*/
                (VehicleHash)301304410 => 489,
                /*Vstr*/
                (VehicleHash)1456336509 => 490,
                /*Formula*/
                (VehicleHash)340154634 => 491,
                /*Imorgon*/
                (VehicleHash)3162245632 => 492,
                /*Formula2*/
                (VehicleHash)2334210311 => 493,
                /*Furia*/
                (VehicleHash)960812448 => 494,
                /*Rebla*/
                (VehicleHash)83136452 => 495,
                /*Vagrant*/
                (VehicleHash)740289177 => 496,
                /*Retinue2*/
                (VehicleHash)2031587082 => 497,
                /*Yosemite2*/
                (VehicleHash)1693751655 => 498,
                /*Komoda*/
                (VehicleHash)3460613305 => 499,
                /*Sultan2*/
                (VehicleHash)872704284 => 500,
                /*Sugoi*/
                (VehicleHash)987469656 => 501,
                /*Everon*/
                (VehicleHash)2538945576 => 502,
                /*Asbo*/
                (VehicleHash)1118611807 => 503,
                /*Kanjo*/
                (VehicleHash)409049982 => 504,
                /*Outlaw*/
                (VehicleHash)408825843 => 505,
                /*Club*/
                (VehicleHash)2196012677 => 506,
                /*Dukes3*/
                (VehicleHash)2134119907 => 507,
                /*Yosemite3*/
                (VehicleHash)67753863 => 508,
                /*Penumbra2*/
                (VehicleHash)3663644634 => 509,
                /*Landstalker2*/
                (VehicleHash)3456868130 => 510,
                /*Seminole2*/
                (VehicleHash)2484160806 => 511,
                /*Tigon*/
                (VehicleHash)2936769864 => 512,
                /*Openwheel1*/
                (VehicleHash)1492612435 => 513,
                /*Openwheel2*/
                (VehicleHash)1181339704 => 514,
                /*Coquette4*/
                (VehicleHash)2566281822 => 515,
                VehicleHash.Peyote => 517,
                VehicleHash.Manana => 516,
                /*Kosatka*/
                (VehicleHash)1336872304 => 518,
                /*ItaliRSx*/
                (VehicleHash)3145241962 => 519,
                /*SlamTruck*/
                (VehicleHash)3249056020 => 520,
                /*Brioso2*/
                (VehicleHash)1429622905 => 521,
                /*Weevil*/
                (VehicleHash)1644055914 => 522,
                /*Alkonost*/
                (VehicleHash)3929093893 => 523,
                /*Annihilator2*/
                (VehicleHash)295054921 => 524,
                /*Dinghy5*/
                (VehicleHash)3314393930 => 525,
                /*Manchez2*/
                (VehicleHash)1086534307 => 526,
                /*Patrolboat*/
                (VehicleHash)4018222598 => 527,
                /*Squaddie*/
                (VehicleHash)4192631813 => 528,
                /*Toreador*/
                (VehicleHash)1455990255 => 529,
                /*Verus*/
                (VehicleHash)298565713 => 530,
                /*Vetir*/
                (VehicleHash)2014313426 => 531,
                /*Winky*/
                (VehicleHash)4084658662 => 532,
                /*Longfin*/
                (VehicleHash)1861786828 => 533,
                /*Veto*/
                (VehicleHash)3437611258 => 534,
                /*Veto2*/
                (VehicleHash)2802050217 => 535,
                /*Calico*/
                (VehicleHash)3101054893 => 536,
                /*Comet6*/
                (VehicleHash)2568944644 => 537,
                /*Cypher*/
                (VehicleHash)1755697647 => 538,
                /*Dominator7*/
                (VehicleHash)426742808 => 539,
                /*Jester4*/
                (VehicleHash)2712905841 => 540,
                /*Remus*/
                (VehicleHash)1377217886 => 541,
                /*Vectre*/
                (VehicleHash)2754593701 => 542,
                /*Zr350*/
                (VehicleHash)2436313176 => 543,
                /*Warrener2*/
                (VehicleHash)579912970 => 544,
                /*Rt3000*/
                (VehicleHash)3842363289 => 545,
                /*Futo2*/
                (VehicleHash)2787736776 => 546,
                /*Sultan3*/
                (VehicleHash)4003946083 => 547,
                /*Tailgater2*/
                (VehicleHash)3050505892 => 548,
                /*Dominator8*/
                (VehicleHash)736672010 => 549,
                /*Euros*/
                (VehicleHash)2038480341 => 550,
                /*Growler*/
                (VehicleHash)1304459735 => 551,
                /*Previon*/
                (VehicleHash)1416471345 => 552,
                /*Comet7*/
                (VehicleHash)1141395928 => 554,
                /*Shinobi*/
                (VehicleHash)1353120668 => 555,
                /*Reever*/
                (VehicleHash)1993851908 => 556,
                /*Baller7*/
                (VehicleHash)359875117 => 557,
                /*Cinquemila*/
                (VehicleHash)2767531027 => 558,
                /*Jubilee*/
                (VehicleHash)461465043 => 559,
                /*Astron*/
                (VehicleHash)629969764 => 560,
                /*Deity*/
                (VehicleHash)1532171089 => 561,
                /*Zeno*/
                (VehicleHash)655665811 => 562,
                /*Champion*/
                (VehicleHash)3379732821 => 563,
                /*Ignus*/
                (VehicleHash)2850852987 => 564,
                /*Buffalo4*/
                (VehicleHash)3675036420 => 565,
                /*Granger2*/
                (VehicleHash)4033620423 => 566,
                /*Iwagen*/
                (VehicleHash)662793086 => 567,
                /*Patriot3*/
                (VehicleHash)3624880708 => 568,
                /*Tenf*/
                (VehicleHash)3400983137 => 569,
                /*OmniseGT*/
                (VehicleHash)3789743831 => 574,
                /*Greenwood*/
                (VehicleHash)40817712 => 581,
                /*Sm722*/
                (VehicleHash)775514032 => 570,
                /*Ruiner4*/
                (VehicleHash)1706945532 => 579,
                /*Vigero2*/
                (VehicleHash)2536587772 => 578,
                /*Torero2*/
                (VehicleHash)4129572538 => 571,
                /*Rhinehart*/
                (VehicleHash)2439462158 => 575,
                /*CoRSita*/
                (VehicleHash)3540279623 => 572,
                /*Lm87*/
                (VehicleHash)4284049613 => 573,
                /*Draugur*/
                (VehicleHash)3526730918 => 580,
                /*Kanjosj*/
                (VehicleHash)4230891418 => 577,
                /*Postlude*/
                (VehicleHash)4000288633 => 576,
                /*Conada*/
                (VehicleHash)3817135397 => 582,
                /*Brickade2*/
                (VehicleHash)2718380883 => 583,
                (VehicleHash)1384502824 /*Manchez3*/ => 584,
                /*Journey2*/
                (VehicleHash)2667889793 => 589,
                /*Panthere*/
                (VehicleHash)2100457220 => 585,
                /*Tahoma*/
                (VehicleHash)3833117047 => 586,
                /*Tulip2*/
                (VehicleHash)268758436 => 587,
                /*Everon2*/
                (VehicleHash)4163619118 => 588,
                /*Eudora*/
                (VehicleHash)3045179290 => 598,
                /*Broadway*/
                (VehicleHash)2361724968 => 597,
                /*Issi8*/
                (VehicleHash)1550581940 => 593,
                /*Boor*/
                (VehicleHash)996383885 => 596,
                /*PoweRSurge*/
                (VehicleHash)2908631255 => 595,
                /*Virtue*/
                (VehicleHash)669204833 => 591,
                /*R300*/
                (VehicleHash)1076201208 => 592,
                /*Entity3*/
                (VehicleHash)1748565021 => 594,
                /*Surfer3*/
                (VehicleHash)3259477733 => 590,
                VehicleHash.Mesa => 599,
                /*L35*/
                (VehicleHash)2531292011 => 600,
                /*Brigham*/
                (VehicleHash)3640468689 => 603,
                /*Clique2*/
                (VehicleHash)3315674721 => 604,
                /*Ratel*/
                (VehicleHash)3758861739 => 601,
                /*Monstrociti*/
                (VehicleHash)802856453 => 602,
                (VehicleHash)3397143273 /*Inductor */=> 605,
                (VehicleHash)2311345272 /*Inductor2 */=> 606,
                /*Streamer216*/
                (VehicleHash)191916658 => 607,
                /*Conada2*/
                (VehicleHash)2635962482 => 608,
                /*Raiju*/
                (VehicleHash)239897677 => 609,
                /*Gauntlet6*/
                (VehicleHash)1336514315 => 610,
                /*Stingertt*/
                (VehicleHash)1447690049 => 611,
                /*Buffalo5*/
                (VehicleHash)165968051 => 612,
                /*Coureur*/
                (VehicleHash)610429990 => 613,
                _ => -1
            };
        }
        internal static bool func_7072(int iParam0)//Position - 0x242DE3
        {
            switch ((VehicleHash)iParam0)
            {
                case VehicleHash.Apc:
                case VehicleHash.Dune3:
                case VehicleHash.HalfTrack:
                case VehicleHash.Oppressor:
                case VehicleHash.Tampa3:
                case VehicleHash.Technical3:
                case VehicleHash.Insurgent3:
                case /*Vigilante*/ (VehicleHash)3052358707:
                case  /*Barrage*/ (VehicleHash)4081974053:
                case VehicleHash.Ardent:
                case VehicleHash.NightShark:
                case /*Deluxo*/ (VehicleHash)1483171323:
                case /*Stromberg*/ (VehicleHash)886810209:
                case /*Comet4*/ (VehicleHash)1561920505:
                case /*Revolter*/ (VehicleHash)3884762073:
                case  /*Savestra*/ (VehicleHash)903794909:
                case /*Viseris*/ (VehicleHash)3903371924:
                case /*Thruster*/ (VehicleHash)1489874736:
                case /*Riot2*/ (VehicleHash)2601952180:
                case /*Chernobog*/ (VehicleHash)3602674979:
                case /*Khanjali*/ (VehicleHash)2859440138:
                case VehicleHash.Technical2:
                case VehicleHash.Boxville5:
                case VehicleHash.Wastelander:
                case VehicleHash.Phantom2:
                case VehicleHash.Voltic2:
                case VehicleHash.Dune5:
                case VehicleHash.Ruiner2:
                case VehicleHash.Blazer5:
                case /*Caracara*/ (VehicleHash)1254014755:
                case /*Mule4*/ (VehicleHash)1945374990:
                case /*Pounder2*/ (VehicleHash)1653666139:
                case /*Scramjet*/ (VehicleHash)3656405053:
                case  /*Oppressor2*/ (VehicleHash)2069146067:
                case /*Menacer*/ (VehicleHash)2044532910:
                case /*Paragon2*/ (VehicleHash)1416466158:
                    return true;
                default:
                    if (func_3149(iParam0))
                        return true;
                    break;
            }
            return false;
        }
        internal static int func_7073(int iParam0, int iParam1)//Position - 0x242EF7
        {
            switch ((VehicleHash)iParam0)
            {
                case VehicleHash.Chino2:
                    return Tunables.Global_262145.Value<int>("f_12517") /* Tunable: MOD_SHOP_UPGRADE_VAPID_CHINO_CUSTOM */;
                case VehicleHash.Primo2:
                    return Tunables.Global_262145.Value<int>("f_12520") /* Tunable: MOD_SHOP_UPGRADE_ALBANY_PRIMO_CUSTOM */;
                case VehicleHash.Moonbeam2:
                    return Tunables.Global_262145.Value<int>("f_12519") /* Tunable: MOD_SHOP_UPGRADE_DECLASSE_MOONBEAM_CUSTOM */;
                case VehicleHash.Faction2:
                    return Tunables.Global_262145.Value<int>("f_12518") /* Tunable: MOD_SHOP_UPGRADE_WILLARD_FACTION_CUSTOM */;
                case VehicleHash.Buccaneer2:
                    return Tunables.Global_262145.Value<int>("f_12516") /* Tunable: MOD_SHOP_UPGRADE_ALBANY_BUCCANEER_CUSTOM */;
                case VehicleHash.Voodoo:
                    return Tunables.Global_262145.Value<int>("f_12521") /* Tunable: MOD_SHOP_UPGRADE_DECLASSE_VOODOO_CUSTOM */;
                case VehicleHash.SultanRS:
                    return Tunables.Global_262145.Value<int>("f_13626") /* Tunable: BENNYSWEBSITE_KARIN_SULTAN_RS_UPGRADE */;
                case VehicleHash.Banshee2:
                    return Tunables.Global_262145.Value<int>("f_13628") /* Tunable: UPGRADE_BRAVADO_BANSHEE_900R_UPGRADE */;
                case VehicleHash.Faction3:
                    return Tunables.Global_262145.Value<int>("f_15208") /* Tunable: CAR_MODS_WILLARD_FACTION_CUSTOM_DONK_UPGRADE */;
                case VehicleHash.Minivan2:
                    return Tunables.Global_262145.Value<int>("f_15209") /* Tunable: CAR_MODS_VAPID_MINIVAN_CUSTOM_UPGRADE */;
                case VehicleHash.SabreGT2:
                    return Tunables.Global_262145.Value<int>("f_15210") /* Tunable: CAR_MODS_DECLASSE_SABRE_TURBO_CUSTOM_UPGRADE */;
                case VehicleHash.SlamVan3:
                    return Tunables.Global_262145.Value<int>("f_15211") /* Tunable: CAR_MODS_VAPID_SLAMVAN_CUSTOM_UPGRADE */;
                case VehicleHash.Tornado5:
                    return Tunables.Global_262145.Value<int>("f_15212") /* Tunable: CAR_MODS_DECLASSE_TORNADO_CUSTOM_UPGRADE */;
                case VehicleHash.Virgo2:
                    return Tunables.Global_262145.Value<int>("f_15213") /* Tunable: CAR_MODS_DUNDREARY_VIRGO_CLASSIC_CUSTOM_UPGRADE */;
                case VehicleHash.Comet3:
                    return Tunables.Global_262145.Value<int>("f_19821") /* Tunable: IMPEXP_COMET3_UPGRADE_PRICE */;
                case VehicleHash.Diablous2:
                    return Tunables.Global_262145.Value<int>("f_19825") /* Tunable: IMPEXP_DIABLOUS2_UPGRADE_PRICE */;
                case VehicleHash.FCR2:
                    return Tunables.Global_262145.Value<int>("f_19823") /* Tunable: IMPEXP_FCR2_UPGRADE_PRICE */;
                case VehicleHash.ItaliGTB2:
                    return Tunables.Global_262145.Value<int>("f_19815") /* Tunable: IMPEXP_ITALIGTB2_UPGRADE_PRICE */;
                case VehicleHash.Specter2:
                    return Tunables.Global_262145.Value<int>("f_19817") /* Tunable: IMPEXP_SPECTER2_UPGRADE_PRICE */;
                case VehicleHash.Nero2:
                    return Tunables.Global_262145.Value<int>("f_19819") /* Tunable: IMPEXP_NERO2_UPGRADE_PRICE */;
                case VehicleHash.Elegy:
                    return Tunables.Global_262145.Value<int>("f_19820") /* Tunable: IMPEXP_ELEGY_UPGRADE_PRICE */;
                case VehicleHash.Technical3:
                    return Tunables.Global_262145.Value<int>("f_21551") /* Tunable: 424298680 */;
                case VehicleHash.Insurgent3:
                    return Tunables.Global_262145.Value<int>("f_21550") /* Tunable: 2123626407 */;
                case /*Bruiser*/ (VehicleHash)668439077:
                    return Tunables.Global_262145.Value<int>("f_26176") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_GLENDALE */;
                case /*Monster3*/ (VehicleHash)1721676810:
                    return Tunables.Global_262145.Value<int>("f_26175") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_RATLOADER */;
                case /*Impaler2*/ (VehicleHash)1009171724:
                    return Tunables.Global_262145.Value<int>("f_26179") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_IMPALER */;
                case /*Issi4*/ (VehicleHash)628003514:
                    return Tunables.Global_262145.Value<int>("f_26180") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_ISSI */;
                case /*Deathbike*/ (VehicleHash)4267640610:
                    return Tunables.Global_262145.Value<int>("f_26181") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_GARGOYLE */;
                case /*Dominator4*/ (VehicleHash)3606777648:
                    return Tunables.Global_262145.Value<int>("f_26178") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_DOMINATOR */;
                case /*Slamvan4*/ (VehicleHash)2233918197:
                    return Tunables.Global_262145.Value<int>("f_26177") /* Tunable: AW_UPGRADE_PRICE_APOCALYPSE_SLAMVAN */;
                case /*Deathbike3*/ (VehicleHash)2920466844:
                    return Tunables.Global_262145.Value<int>("f_26195") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_GARGOYLE */;
                case /*Deathbike2*/ (VehicleHash)2482017624:
                    return Tunables.Global_262145.Value<int>("f_26188") /* Tunable: AW_UPGRADE_PRICE_SCIFI_GARGOYLE */;
                case /*Impaler3*/ (VehicleHash)2370166601:
                    return Tunables.Global_262145.Value<int>("f_26186") /* Tunable: AW_UPGRADE_PRICE_SCIFI_IMPALER */;
                case /*Bruiser2*/ (VehicleHash)2600885406:
                    return Tunables.Global_262145.Value<int>("f_26183") /* Tunable: AW_UPGRADE_PRICE_SCIFI_GLENDALE */;
                case /*Slamvan5*/ (VehicleHash)373261600:
                    return Tunables.Global_262145.Value<int>("f_26184") /* Tunable: AW_UPGRADE_PRICE_SCIFI_SLAMVAN */;
                case /*Issi5*/ (VehicleHash)1537277726:
                    return Tunables.Global_262145.Value<int>("f_26187") /* Tunable: AW_UPGRADE_PRICE_SCIFI_ISSI */;
                case /*Monster4*/ (VehicleHash)840387324:
                    return Tunables.Global_262145.Value<int>("f_26182") /* Tunable: AW_UPGRADE_PRICE_SCIFI_RATLOADER */;
                case /*Dominator5*/ (VehicleHash)2919906639:
                    return Tunables.Global_262145.Value<int>("f_26185") /* Tunable: AW_UPGRADE_PRICE_SCIFI_DOMINATOR */;
                case /*Impaler4*/ (VehicleHash)2550461639:
                    return Tunables.Global_262145.Value<int>("f_26193") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_IMPALER */;
                case /*Bruiser3*/ (VehicleHash)2252616474:
                    return Tunables.Global_262145.Value<int>("f_26190") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_GLENDALE */;
                case /*Slamvan6*/ (VehicleHash)1742022738:
                    return Tunables.Global_262145.Value<int>("f_26191") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_SLAMVAN */;
                case /*Issi6*/ (VehicleHash)1239571361:
                    return Tunables.Global_262145.Value<int>("f_26194") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_ISSI */;
                case /*Monster5*/ (VehicleHash)3579220348:
                    return Tunables.Global_262145.Value<int>("f_26189") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_RATLOADER */;
                case /*Dominator6*/ (VehicleHash)3001042683:
                    return Tunables.Global_262145.Value<int>("f_26192") /* Tunable: AW_UPGRADE_PRICE_CONSUMERISM_DOMINATOR */;
                case /*Youga3*/ (VehicleHash)1802742206:
                    return Tunables.Global_262145.Value<int>("f_29583") /* Tunable: SUM_UPGRADE_PRICE_YOUGA3 */;
                case /*Gauntlet5*/ (VehicleHash)2172320429:
                    return Tunables.Global_262145.Value<int>("f_29578") /* Tunable: SUM_UPGRADE_PRICE_GAUNTLET5 */;
                case /*Manana2*/ (VehicleHash)1717532765:
                    return Tunables.Global_262145.Value<int>("f_29582") /* Tunable: SUM_UPGRADE_PRICE_MANANA2 */;
                case /*Peyote3*/ (VehicleHash)1107404867:
                    return Tunables.Global_262145.Value<int>("f_29580") /* Tunable: SUM_UPGRADE_PRICE_PEYOTE3 */;
                case /*Yosemite3*/ (VehicleHash)67753863:
                    return Tunables.Global_262145.Value<int>("f_29579") /* Tunable: SUM_UPGRADE_PRICE_YOSEMITE3 */;
                case /*Glendale2*/ (VehicleHash)3381377750:
                    return Tunables.Global_262145.Value<int>("f_29581") /* Tunable: SUM_UPGRADE_PRICE_GLENDALE2 */;
                case /*Tenf2*/ (VehicleHash)274946574:
                    return Tunables.Global_262145.Value<int>("f_32899") /* Tunable: SUM2_UPGRADE_PRICE_TENF2 */;
                case /*Weevil2*/ (VehicleHash)3300595976:
                    return Tunables.Global_262145.Value<int>("f_32900") /* Tunable: SUM2_UPGRADE_PRICE_WEEVIL2 */;
                case /*Brioso3*/ (VehicleHash)15214558:
                    return Tunables.Global_262145.Value<int>("f_32901") /* Tunable: SUM2_UPGRADE_PRICE_BRIOSO3 */;
                case /*Sentinel4*/ (VehicleHash)2938086457:
                    return Tunables.Global_262145.Value<int>("f_32902") /* Tunable: SUM2_UPGRADE_PRICE_SENTINEL4 */;
                case /*Brickade2*/ (VehicleHash)2718380883:
                    return Tunables.Global_262145.Value<int>("f_32913") /* Tunable: ACID_LAB_UPGRADE_EQUIPMENT_PRICE */;
                case (VehicleHash)3868033424 /*Avenger3*/:
                    if (iParam1 == 61)
                        return Tunables.Global_262145.Value<int>("f_35164") /* Tunable: -1950969733 */;
                    else if (iParam1 == 103)
                        return Tunables.Global_262145.Value<int>("f_35165") /* Tunable: 1508502907 */;
                    break;
            }
            return 0;
        }

    }
}
