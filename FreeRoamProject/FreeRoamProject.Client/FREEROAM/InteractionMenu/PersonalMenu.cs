using FreeRoamProject.Client;
using FreeRoamProject.Shared.Core.Character;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace TheLastPlanet.Client.GameMode.ROLEPLAY.Personale
{
    internal static class PersonalMenu
    {

        // TODO: MAKE THE GAME COUNT IDLING OF PLAYER, IF MORE THAN 15 MINUTES THEN KICK IT..
        // WE CAN SEND SHOWNOTIFICATION WITH LABEL "HUD_ILDETIME" WITH TIME REMAINING
        // IF TIME FINISH.. PLAYER IS KICKED OUT OF THE SERVER.
        // game checks using IsInPowerSavingMode() and GetPowerSavingModeDuration()

        public static List<dynamic> chars = new List<dynamic>();
        public static float interactionDistance = 3.5f;
        public static int lockDistance = 25;
        public static string itemgps = "None";
        public static bool saved = false;
        public static bool on = false;
        public static bool closed = false;
        public static bool enabled = false;
        public static bool CinematicGrain = false;
        private static bool open = false;
        private static float fuelint = 0;
        // TODO: THE QUICK GPS MUST BE HANDLED ON MENU BUILDING.. SO THAT WE CAN CHECK WHAT TO ADD AND WHAT NOT
        // FOR EXAMPLE GARAGES, PERSONAL VEHICLES, SIMEON, LESTER, HOME, ETC
        public static List<dynamic> gps = new List<dynamic>()
        {
            Game.GetGXTEntry("PIM_QGPS0"), // None
            Game.GetGXTEntry("PIM_QGPS1"), // Mission Objective
            Game.GetGXTEntry("PIM_QGPS1B"), // Garage
            Game.GetGXTEntry("PIM_QGPS2"), // Simeon
            Game.GetGXTEntry("PIM_QGPS3"), // Lester
            Game.GetGXTEntry("PIM_QGPS4"), // Trevor
            Game.GetGXTEntry("PIM_QGPS5"), // Personal Vehicle
            Game.GetGXTEntry("PIM_QGPS6"), // Mors Mutual
            Game.GetGXTEntry("PIM_QGPS7"), // Wanted Vehicle
            Game.GetGXTEntry("PIM_QGPS8"), // Target
            Game.GetGXTEntry("PIM_QGPS8B"), // Garage
            Game.GetGXTEntry("PIM_QGPS9"), // Home
            Game.GetGXTEntry("PIM_QGPS9B"), // Garage
            Game.GetGXTEntry("PIM_QGPS10"), // Home 2
            Game.GetGXTEntry("PIM_QGPS10B"), // Garage 2
            Game.GetGXTEntry("PIM_QGPS11"), // Home 3
            Game.GetGXTEntry("PIM_QGPS11B"), // Garage 3
            Game.GetGXTEntry("PIM_QGPS12"), // Home 4
            Game.GetGXTEntry("PIM_QGPS12B"), // Garage 4
            Game.GetGXTEntry("PIM_QGPS13"), // Ammu-Nation
            Game.GetGXTEntry("PIM_QGPS14"), // ATM
            Game.GetGXTEntry("PIM_QGPS15"), // Barber Shop
            Game.GetGXTEntry("PIM_QGPS16"), // Tattoo Parlor
            Game.GetGXTEntry("PIM_QGPS17"), // Pegasus Vehicle
            Game.GetGXTEntry("PIM_QGPS18"), // Mod Shop
            Game.GetGXTEntry("PIM_QGPS19"), // Clothes Store
            Game.GetGXTEntry("PIM_QGPS20"), // Time Trial
            Game.GetGXTEntry("PIM_QGPS21"), // Dead Drop
            Game.GetGXTEntry("PIM_QGPS22"), // Hot Property
            Game.GetGXTEntry("PIM_QGPS23"), // Moving Target
            Game.GetGXTEntry("PIM_QGPS24"), // King of the Castle
            Game.GetGXTEntry("PIM_QGPS25"), // Penned In
            Game.GetGXTEntry("PIM_QGPS26"), // Kill List
            Game.GetGXTEntry("PIM_QGPS26X"), // Kill List Competitive
            Game.GetGXTEntry("PIM_QGPS27"), // Hold the Wheel
            Game.GetGXTEntry("PIM_QGPS28"), // Lamar
            Game.GetGXTEntry("PIM_QGPSC"), // Capture Objective
            Game.GetGXTEntry("PIM_QGPSDO"), // Destination
        };

        private static List<dynamic> portiere = new List<dynamic>()
        {
            Game.GetGXTEntry("PM_DPV1"),
            Game.GetGXTEntry("PM_DPV2"),
            Game.GetGXTEntry("PM_DPV3"),
            Game.GetGXTEntry("PM_DPV4"),
            Game.GetGXTEntry("PM_DPV5"),
            Game.GetGXTEntry("PM_DPV6"),
            Game.GetGXTEntry("PM_DPV7"),
        };
        private static List<dynamic> chiusure = new List<dynamic>() { "Locked", "Unlocked" };
        public static Blip b;
        public static bool blipFound = false;

        public static async void menuPersonal()
        {
            MenuHandler.CloseAndClearHistory();
            Ped playerPed = PlayerCache.MyPlayer.Ped;
            Player player = PlayerCache.MyPlayer.Player;
            string playerName = player.Name;

            Point pos = new Point(5, 5);
            UIMenu interactionMenu = new UIMenu(Game.Player.Name, Game.GetGXTEntry("PIM_TITLE1"), pos, "commonmenu", "interaction_bgd", true, true);
            interactionMenu.BuildingAnimation = MenuBuildingAnimation.NONE;

            #region Quick GPS
            // TODO: MAKE THE QUICK_GPS LIST ON RUNTIME.. YOU NEVER KNOW WHAT MUST BE ADDED AND WHAT NOT..
            // SO WE CAN'T CHECK BY THE INDEX, BUT BY THE LIST CURRENT INDEX LABEL.
            UIMenuListItem gpsItem = new UIMenuListItem(Game.GetGXTEntry("PIM_TQGPS"), gps, 0);
            interactionMenu.AddItem(gpsItem);
            interactionMenu.OnListSelect += async (menu, _item, _itemIndex) =>
            {
                if (_item != gpsItem) return;
                int var;

                switch (_item.Index)
                {
                    case 2:
                        var = 407;
                        break;
                    case 3:
                        var = 60;
                        break;
                    case 4:
                        var = 80;
                        break;
                    case 5:
                        var = 108;
                        break;
                    case 6:
                        var = 52;
                        break;
                    case 7:
                        var = 154;
                        break;
                    case 8:
                        var = 463;
                        break;
                    case 9:
                        var = 225;
                        break;
                    case 10:
                        var = 50;
                        break;
                    case 11:
                        var = 73;
                        break;
                    case 12:
                        var = 71;
                        break;
                    case 13:
                        var = 408;
                        break;
                    default:
                        var = 0;
                        break;
                }

                if ((string)_item.Items[_item.Index] == "None")
                {
                    try
                    {
                        if (b.Exists())
                        {
                            SetWaypointOff();
                            b.ShowRoute = false;
                            ClientMain.Instance.RemoveTick(routeColor);
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        ClientMain.Logger.Debug(e.ToString() + e.StackTrace);
                    }
                }
                else
                {
                    Blip[] test = World.GetAllBlips((BlipSprite)var);
                    Notifications.ShowNotification("GPS: loading..");
                    await BaseScript.Delay(1000);
                    b = test.ToList().OrderBy(x => PlayerCache.MyPlayer.Position.Distance(x.Position)).FirstOrDefault();
                    Notifications.ShowNotification("GPS: loading..").Hide();

                    if (b != null)
                    {
                        b.ShowRoute = true;
                        Notifications.ShowNotification($"Nearest destination found for {_item.Items[_item.Index]}.");
                        ClientMain.Instance.AddTick(routeColor);
                    }
                    else
                    {
                        Notifications.ShowNotification("Destination not found!");
                    }
                }
            };

            #endregion

            // TODO: IN THE ONLINE THIS IS A DYNAMIC OPTION.. THAT APPEAR/DISAPPEAR BASED ON NUMBER OF GANGS IN THE GAME..
            #region Gangs

            UIMenuItem gangsItem = new(Game.GetGXTEntry("PIM_REGBOSS"), Game.GetGXTEntry("PIM_REGMAGHELPB"));
            UIMenu gangsMenu = new(playerName, Game.GetGXTEntry("PIM_REGBOSSTIT"));
            gangsItem.BindItemToMenu(gangsMenu);
            interactionMenu.AddItem(gangsItem);

            // TODO: UNCENSORED IS SO ESX... WE WANT A GANG NAME BUT ALSO A SIMPLE CHECK IsBoss true/false...
            if (PlayerCache.MyPlayer.User.Character.Gang.Name == "Uncensored")
            {
                UIMenuItem becomeBoss = new UIMenuItem("Become a gang boss!");
                List<dynamic> job = new List<dynamic>() { Game.GetGXTEntry("FE_HLP31"), Game.GetGXTEntry("FE_HLP29") };
                UIMenuListItem lookingForJob = new UIMenuListItem("Looking for a \"Job\"", job, 0, GetLabelText("PIM_MAGH0D"));
                gangsMenu.AddItem(becomeBoss);
                gangsMenu.AddItem(lookingForJob);
                // GB_BECOMEB = You are now the CEO of ~a~~s~
                // GB_GOON_OPEN = Hold ~INPUT_VEH_EXIT~to open the door for your Boss
                becomeBoss.Activated += async (menu, item) =>
                {
                    if (PlayerCache.MyPlayer.User.Bank > 5000)
                    {
                        // TODO: ADD CHECK FOR ACTIVE CONCURRENT GANGS (CEO, BIKERS, WHATEVER) PER BUCKET
                        //if (Main.ActiveGangs.Count < 3)
                        {
                            string gname = await Functions.GetUserInput("Gang name", "", 15);
                            MenuHandler.CloseAndClearHistory();
                            ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("Boss", $"You have become the Boss of the ~o~{gname}~w~ gang.");
                            Game.PlaySound("Boss_Message_Orange", "GTAO_Boss_Goons_FM_Soundset");
                            PlayerCache.MyPlayer.User.Character.Gang = new Gang(gname, 5);
                            //Main.ActiveGangs.Add(new Gang(gname, Main.ActiveGangs.Count + 1));

                        }
                        /*
                        else
                        {
                            Notifications.ShowNotification("There are already too many active Criminal Gangs in session.~n~Please try again at another time.", NotificationColor.Red, true);
                        }
                        */
                    }
                    else
                    {
                        Notifications.ShowNotification("You don't have enough bank funds to become a Boss!", NotificationColor.Red, true);
                    }
                };
            }
            else
            {
                if (PlayerCache.MyPlayer.User.Character.Gang.Grade > 4)
                {
                    UIMenuItem hireItem = new UIMenuItem("Recruit members");
                    UIMenu hire = new("Recruit members", Game.GetGXTEntry("PIM_TITLE1"));
                    UIMenuItem manageItem = new UIMenuItem("Gang management");
                    UIMenu manage = new("Gang management", Game.GetGXTEntry("PIM_TITLE1"));
                    UIMenuItem featuresBossItem = new UIMenuItem("Boss's features");
                    UIMenu featuresBoss = new("Boss's features", Game.GetGXTEntry("PIM_TITLE1"));
                    hireItem.BindItemToMenu(hire);
                    manageItem.BindItemToMenu(manage);
                    featuresBossItem.BindItemToMenu(featuresBoss);
                    gangsMenu.AddItem(hireItem);
                    gangsMenu.AddItem(manageItem);
                    gangsMenu.AddItem(featuresBossItem);


                    UIMenuItem retire = new UIMenuItem("Retire", "Warning.. you won't be able to set up a new gang before 6 hours!");
                    gangsMenu.AddItem(retire);
                    retire.Activated += (menu, item) =>
                    {
                        MenuHandler.CloseAndClearHistory();
                        //Main.ActiveGangs.Remove(PlayerCache.MyPlayer.User.Character.Gang);
                        ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("Retired", $"You're no longer the boss of the ~o~{PlayerCache.MyPlayer.User.Character.Gang.Name}~w~ gang.");
                        Game.PlaySound("Boss_Message_Orange", "GTAO_Boss_Goons_FM_Soundset");
                        PlayerCache.MyPlayer.User.Character.Gang = new Gang("Uncensored", 0);
                    };
                }
                else
                {
                    UIMenuItem retire = new UIMenuItem("Retire", "Stop working for your current boss");
                    gangsMenu.AddItem(retire);
                    retire.Activated += (menu, item) =>
                    {
                        MenuHandler.CloseAndClearHistory();
                        ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("Retired", $"You're not a member of the ~o~{PlayerCache.MyPlayer.User.Character.Gang.Name}~w~ gang anymore.");
                        Game.PlaySound("Boss_Message_Orange", "GTAO_Boss_Goons_FM_Soundset");
                        PlayerCache.MyPlayer.User.Character.Gang = new Gang("Uncensored", 0);
                    };
                }
            }

            #endregion

            #region Objectives

            UIMenuItem objectives = new UIMenuItem(Game.GetGXTEntry("PIM_TDOBJ"), Game.GetGXTEntry("PIM_HDOBJ"));
            UIMenu objectivesMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLE_67"));
            objectives.BindItemToMenu(objectivesMenu);
            interactionMenu.AddItem(objectives);

            #endregion

            #region Inventory

            UIMenuItem inventory = new UIMenuItem(Game.GetGXTEntry("PIM_TINVE"), Game.GetGXTEntry("PIM_HINVE"));
            UIMenu inventoryMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLE2"));
            inventory.BindItemToMenu(inventoryMenu);
            interactionMenu.AddItem(inventory);

            UIMenuItem radioStationItem = new UIMenuItem(Game.GetGXTEntry("PIM_FAV_RS"), Game.GetGXTEntry("PIM_FAV_RS_TT"));
            UIMenu radioStationMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_FAV_RS_U"));

            UIMenuItem phoneContactsItem = new UIMenuItem(Game.GetGXTEntry("PIM_FAV_CONT"), Game.GetGXTEntry("PIM_FAV_CONT_TT"));
            UIMenu phoneContactsMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_FAV_CONT_U"));

            UIMenuItem cashItem = new UIMenuItem(Game.GetGXTEntry("PIM_TCASH"), Game.GetGXTEntry("PIM_HCASH"));
            UIMenu cashMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLE50"));

            UIMenuItem bodyArmorItem = new UIMenuItem(Game.GetGXTEntry("PIM_TARMOR"), Game.GetGXTEntry("PIM_HARMOR"));
            UIMenu bodyArmorMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_UARMOR"));

            /* TODO: Handle snacks subtitles
                "PIM_HSNAC": "Look through and use held snacks, drinks, and smokes.",
                "PIM_HSNACB": "Snacks are unavailable while you are The Beast.",
                "PIM_HSNAE": "Snacks are unavailable while wearing Ballistic Equipment.",
                "PIM_HSNAJ": "Snacks are unavailable during this Job.",
             */
            UIMenuItem snacksItem = new UIMenuItem(Game.GetGXTEntry("PIM_TSNAC"), Game.GetGXTEntry("PIM_HSNAC"));
            UIMenu snacksMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_USNAC"));

            UIMenuItem ammoItem = new UIMenuItem(Game.GetGXTEntry("PIM_TAMMOW"), Game.GetGXTEntry("PIM_HAMMOW"));
            UIMenu ammoMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_UAMMOW"));

            /* label to be changed on selection
             "PIM_DISWLAY": Disable Custom Weapon Loadout
             "PIM_ENWLAY": Enable Custom Weapon Loadout
             */

            /* descriptions to be changed on the go. 
                "PIM_WEAPLAY_D_1": "You can not change your weapon loadout while passive mode is active.",
                "PIM_WEAPLAY_D_2": "You haven't got a customized weapon loadout. Go to the Gun Locker in your property to customize weapon loadout.",
                "PIM_WEAPLAY_D_3": "Enable your customized weapon loadout.",
                "PIM_WEAPLAY_D_4": "Disable your customized weapon loadout.",
                "PIM_WEAPLAY_D_5": "Custom Weapon Loadout is not currently available.",
             */
            UIMenuItem customWeaponLayout = new UIMenuItem(Game.GetGXTEntry("PIM_DISWLAY"), Game.GetGXTEntry("PIM_WEAPLAY_D_4"));

            /* available descriptions (default is d_1)
              "PIM_BALLIS_D_1": "Ballistic Equipment Services options.",
              "PIM_BALLIS_D_2": "Request Ballistic Equipment",
              "PIM_BALLIS_D_3": "Remove Ballistic Equipment",
              "PIM_BALLIS_D_4": "You do not currently own the Ballistic Equipment. Purchase it at www.warstock-cache-and-carry.com.",
             */
            UIMenuItem ballisticEqItem = new UIMenuItem(Game.GetGXTEntry("PIM_BALLIS"), Game.GetGXTEntry("PIM_BALLIS_D_1"));
            UIMenu ballisticEqMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TBALLI"));

            /* available descriptions (default is PIM_DRONEPUR or PIM_DRONSTAR)
              "PIM_DRONAMISO": "Nano Drone is not available while active on this mission.",
              "PIM_DRONAMOS": "You are not in a safe place to launch the Nano Drone.",
              "PIM_DRONAVT": "Nano Drone available again in ~a~.",
              "PIM_DRONEPUR": "You do not currently own the Nano Drone. Purchase the Drone Station upgrade in the Arcade Property to gain access.",
              "PIM_DRONEUNP": "Nano Drone unavailable while inside a property.",
              "PIM_DRONEUNV": "Nano Drone unavailable while in a vehicle.",
              "PIM_DRONSTAR": "Deploy your Nano Drone.",
             */
            UIMenuItem nanoDroneItem = new UIMenuItem(Game.GetGXTEntry("PIM_REQDRONE"), Game.GetGXTEntry("PIM_DRONEPUR"));
            UIMenu nanoDroneMenu = new UIMenu(playerName, Game.GetGXTEntry("")); // disabled in my game..
            //TODO: BUY A NANO DRONE ONLINE.

            // Collectibles (to be collected all around)
            // Daily collectibles (to be collected all around)
            // Vehicle discount (to be understood before)

            inventoryMenu.AddItem(radioStationItem);
            radioStationItem.BindItemToMenu(radioStationMenu);

            inventoryMenu.AddItem(phoneContactsItem);
            phoneContactsItem.BindItemToMenu(phoneContactsMenu);

            inventoryMenu.AddItem(cashItem);
            cashItem.BindItemToMenu(cashMenu);

            inventoryMenu.AddItem(bodyArmorItem);
            bodyArmorItem.BindItemToMenu(bodyArmorMenu);

            inventoryMenu.AddItem(snacksItem);
            snacksItem.BindItemToMenu(snacksMenu);

            inventoryMenu.AddItem(ammoItem);
            ammoItem.BindItemToMenu(ammoMenu);

            inventoryMenu.AddItem(customWeaponLayout);

            inventoryMenu.AddItem(ballisticEqItem);
            ballisticEqItem.BindItemToMenu(ballisticEqMenu);

            inventoryMenu.AddItem(nanoDroneItem);
            nanoDroneItem.BindItemToMenu(nanoDroneMenu);

            #endregion

            #region Style

            UIMenuItem style = new UIMenuItem(Game.GetGXTEntry("PIM_TSTYL"), Game.GetGXTEntry("PIM_HSTYL"));
            UIMenu styleMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLESTYL"));
            style.BindItemToMenu(styleMenu);
            interactionMenu.AddItem(style);

            UIMenuItem changeAppear = new UIMenuItem(Game.GetGXTEntry("PIM_TCHAP"), Game.GetGXTEntry("PIM_HCHAP"));
            changeAppear.SetRightLabel("$");
            // TODO: in my GTA:O i have to pay 100000$ i think the amount changes based on the XP? CHECK IF THIS CHANGES SOMEHOW

            /* available descriptions (default PIM_HACCE, in my online is PIM_HACCEO.. dunno why)
              "PIM_HACCE": "Swap between accessories for a new look.",
              "PIM_HACCEB": "Accessories are unavailable while you are The Beast.",
              "PIM_HACCEG": "Accessories are unavailable with this outfit.",
              "PIM_HACCEJ": "Accessories are unavailable during this Job.",
              "PIM_HACCEO": "Accessories are unavailable at this time.",
              "PIM_HACCEP": "Accessories are unavailable during this Job.",
             */
            UIMenuItem accessoriesItem = new UIMenuItem(Game.GetGXTEntry("PIM_TACCE"), Game.GetGXTEntry("PIM_HACCE"));
            UIMenu accessoriesMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_UACCE"));

            UIMenuItem parachuteItem = new UIMenuItem(Game.GetGXTEntry("PIM_TCHUTE"), Game.GetGXTEntry("PIM_HCHUTE"));
            UIMenu parachuteMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_PARAT"));

            // TODO: FINISH THIS

            styleMenu.AddItem(changeAppear);

            accessoriesItem.BindItemToMenu(accessoriesMenu);
            styleMenu.AddItem(accessoriesItem);

            parachuteItem.BindItemToMenu(parachuteMenu);
            styleMenu.AddItem(parachuteItem);


            #endregion

            #region Vehicles
            // also PIM_HVEHIUNAVIL for when inside the Moblie Operations Center
            UIMenuItem vehContrItem = new UIMenuItem(Game.GetGXTEntry("PIM_TVEHI"), Game.GetGXTEntry("PIM_HVEHI"));
            UIMenu vehContr = new("Vehicle controls", Game.GetGXTEntry("PIM_TITLE1"));
            vehContrItem.BindItemToMenu(vehContr);
            interactionMenu.AddItem(vehContrItem);
            UIMenuItem fuel = new UIMenuItem("Vehicle fuel saved");
            UIMenuCheckboxItem save = new UIMenuCheckboxItem("Save Vehicle", saved);
            UIMenuCheckboxItem close = new UIMenuCheckboxItem("Door lock", closed);
            UIMenuListItem doors = new UIMenuListItem("Open/Close Door", portiere, 0);
            UIMenuCheckboxItem engine = new UIMenuCheckboxItem("Remote On/Off", EventsPersonalMenu.saveVehicle != null ? EventsPersonalMenu.saveVehicle.IsEngineRunning : false);
            vehContr.AddItem(fuel);
            vehContr.AddItem(save);
            vehContr.AddItem(close);
            vehContr.AddItem(doors);
            vehContr.AddItem(engine);

            if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle)
            {
                close.Enabled = false;
                doors.Enabled = false;
                engine.Enabled = false;
            }

            vehContr.OnCheckboxChange += async (_menu, _item, _checked) =>
            {
                if (_item == close)
                    EventsPersonalMenu.Lock(_checked);
                else if (_item == save)
                    switch (_checked)
                    {
                        case true when PlayerCache.MyPlayer.Status.PlayerStates.InVehicle:
                            {
                                EventsPersonalMenu.Save(_checked);

                                if (_checked)
                                {
                                    close.Enabled = true;
                                    doors.Enabled = true;
                                    engine.Enabled = true;
                                    fuel.SetRightLabel(fuelint + "%");
                                }
                                else
                                {
                                    close.Enabled = false;
                                    doors.Enabled = false;
                                    engine.Enabled = false;
                                    fuel.SetRightLabel("No vehicle saved");
                                }

                                break;
                            }
                        case false:
                            EventsPersonalMenu.Save(_checked);
                            close.Enabled = false;
                            doors.Enabled = false;
                            engine.Enabled = false;
                            fuel.SetRightLabel("No vehicle saved");
                            break;
                        default:
                            Notifications.ShowNotification("You must be in a vehicle to activate the save function", true);
                            break;
                    }
                else if (_item == engine) EventsPersonalMenu.engine(_checked);
            };
            vehContr.OnListSelect += (_menu, _listItem, _itemIndex) =>
            {
                if (_listItem == doors)
                    EventsPersonalMenu.VehDorrs(_listItem.Items[_listItem.Index].ToString());
            };

            #endregion

            #region Services
            // PIM_HSERVICES for not having... PIM_HSERVICES2 for when unlocked
            UIMenuItem services = new UIMenuItem("Services", Game.GetGXTEntry("PIM_HSERVICES"));
            UIMenu servicesMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_HSECTIT"));
            services.BindItemToMenu(servicesMenu);
            interactionMenu.AddItem(services);

            #endregion

            #region MapBlipOptions
            UIMenuItem mapBlipOpt = new UIMenuItem(Game.GetGXTEntry("PIM_THIDE"), Game.GetGXTEntry("PIM_HHIDS"));
            UIMenu mapBlipOptMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITHS"));
            mapBlipOpt.BindItemToMenu(mapBlipOptMenu);
            interactionMenu.AddItem(mapBlipOpt);

            #endregion

            #region ImpromptuRace

            UIMenuItem impromptuRace = new UIMenuItem(Game.GetGXTEntry("PIM_TITLE11"), Game.GetGXTEntry("PIM_HR2P"));
            UIMenu impromptuRaceMenu = new UIMenu(playerName, Game.GetGXTEntry("R2P_MENU"));
            impromptuRace.BindItemToMenu(impromptuRaceMenu);
            interactionMenu.AddItem(impromptuRace);

            #endregion

            #region Highlight player

            // TODO: FIND CORRECT DESCRIPTION IN GTA:O
            UIMenuItem highlightPlayer = new UIMenuItem(Game.GetGXTEntry("PIM_THIGH"), Game.GetGXTEntry("PIM_HHIGH"));
            UIMenu highlightPlayerMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLE12"));
            highlightPlayer.BindItemToMenu(highlightPlayerMenu);
            interactionMenu.AddItem(highlightPlayer);

            #endregion

            #region VoiceChat

            // TODO: FIND CORRECT DESCRIPTION IN GTA:O
            // TODO: SAVE, APPLY AND REAPPLY ON JOIN
            //ADD CHECK FOR ORGANIZATION, GANG, MC TO ADD VOICE OPTION ONLY FOR TEAM
            /*
            "PM_CHT5": "Organization",
            "PM_CHT5X0": "Gang",
            "PM_CHT5X1": "Motorcycle Club",
             */
            List<dynamic> voices = new List<dynamic>()
            {
                Game.GetGXTEntry("PM_CHT0"),
                Game.GetGXTEntry("PM_CHT1"),
                Game.GetGXTEntry("PM_CHT2"),
                Game.GetGXTEntry("PM_CHT3"),
                Game.GetGXTEntry("PM_CHT4"),
            };

            UIMenuListItem voiceChat = new UIMenuListItem(Game.GetGXTEntry("PIM_TCHT"), voices, 0, Game.GetGXTEntry("PIM_HCHT"));
            interactionMenu.AddItem(voiceChat);

            #endregion

            #region Spawn Location

            // TODO: add spawn locations... maybe this item is avail only when properties are purchased? if not.. we can choose only last one or random..
            // TODO: SAVE, APPLY AND REAPPLY ON JOIN
            List<dynamic> spawnLocsList = new List<dynamic>()
            {
                Game.GetGXTEntry("PM_SPAWN_LL"),
                Game.GetGXTEntry("PM_SPAWN_R")
            };
            UIMenuListItem spawnLoc = new UIMenuListItem(Game.GetGXTEntry("PIM_TSPL"), spawnLocsList, 0, Game.GetGXTEntry("PIM_HSPL").Replace("GTA Online", "The Last Galaxy"));
            interactionMenu.AddItem(spawnLoc);

            #endregion

            #region Player Targeting mode

            // TODO: SAVE, APPLY AND REAPPLY ON JOIN
            List<dynamic> targetingList = new List<dynamic>()
            {
                Game.GetGXTEntry("PIM_AAF0"),// "Everyone",
                Game.GetGXTEntry("PIM_AAF1"),// "Strangers",
                Game.GetGXTEntry("PIM_AAF2"),// "Attackers",
            };

            // TODO IN THE INDEXCHANGED EVENT.. UPDATE DESCRIPTION BASED ON THE SELECTION
            /*
                "PIM_HAAF0": "Treat all players (friends and non-friends) as threats.",
                "PIM_HAAF1": "Treat all non-friend players as threats.",
                "PIM_HAAF2": "Treat all non-friend players who damage you as threats.",
            */


            UIMenuListItem playerTargeting = new UIMenuListItem(Game.GetGXTEntry("PIM_TAAF"), targetingList, 0, Game.GetGXTEntry("PIM_HSPL").Replace("GTA Online", "The Last Galaxy"));
            interactionMenu.AddItem(playerTargeting);

            #endregion

            #region Animations and style

            List<dynamic> moods = new List<dynamic>()
                {
                "Determined",
                "Sad",
                "Depressed",
                "Bored",
                "Impatient",
                "Shy",
                "Moody",
                "Stressed",
                "Lazy"
                };
            List<dynamic> attitude = new List<dynamic>()
            {
                "Fierce",
                "Bad",
                "Gangster",
                "Cold",
                "Empty inside",
                "Pompous",
                "Lost",
                "Intimidating",
                "Rich",
                "Aggressive",
                "Imposing",
                "Exhibitionist"
            };
            List<dynamic> feminine = new List<dynamic>()
            {
                "Arrogant",
                "Classy",
                "Fragile",
                "Femme Fatale",
                "Wingless absorbent",
                "Sad",
                "Rebel",
                "Sexy",
                "With butt fat",
                "Fierce"
            };

            UIMenuItem AnimAndStyleItem = new("Animations and Style");
            UIMenu AnimAndStyle = new("Animations and Style", Game.GetGXTEntry("PIM_TITLE1"));
            UIMenuItem moodItem = new("Walking style");
            UIMenu mood = new("Walking style", Game.GetGXTEntry("PIM_TITLE1"));
            AnimAndStyleItem.BindItemToMenu(AnimAndStyle);
            moodItem.BindItemToMenu(mood);
            interactionMenu.AddItem(AnimAndStyleItem);
            AnimAndStyle.AddItem(moodItem);

            UIMenuListItem Item1 = new UIMenuListItem("Moods", moods, 0, "How your character feels today?");
            UIMenuListItem Item2 = new UIMenuListItem("Style", attitude, 0, "What attitude does your character have??");
            UIMenuListItem Item3 = new UIMenuListItem("Feminine", feminine, 0, "Because we care about the fairer sex!");
            UIMenuItem Item4 = new UIMenuItem("~r~Reset", "Why pose when you can walk normally?", SColor.HUD_Reddark, SColor.HUD_Red);
            mood.AddItem(Item1);
            mood.AddItem(Item2);
            mood.AddItem(Item3);
            mood.AddItem(Item4);
            mood.OnListSelect += (_menu, _listItem, _itemIndex) =>
            {
                if (_listItem == Item1) // add check if not player died
                {
                    switch (_listItem.Index)
                    {
                        case 0:
                            playerPed.MovementAnimationSet = "move_m@brave";
                            break;
                        case 1:
                            playerPed.MovementAnimationSet = "move_m@sad@a";
                            break;
                        case 2:
                            playerPed.MovementAnimationSet = "move_m@depressed@a";
                            break;
                        case 3:
                            playerPed.MovementAnimationSet = "move_characters@michael@fire";
                            break;
                        case 4:
                            playerPed.MovementAnimationSet = "move_m@quick";
                            break;
                        case 5:
                            playerPed.MovementAnimationSet = "move_m@confident";
                            break;
                        case 6:
                        case 7:
                            playerPed.MovementAnimationSet = "move_m@hurry@a";
                            break;
                        case 8:
                            playerPed.MovementAnimationSet = "move_characters@jimmy@slow@";
                            break;
                    }
                }
                else if (_listItem == Item2) // add check if not player died
                {
                    switch (_listItem.Index)
                    {
                        case 0:
                            playerPed.MovementAnimationSet = "move_m@business@a";
                            break;
                        case 1:
                            playerPed.MovementAnimationSet = "move_m@casual@d";
                            break;
                        case 2:
                            playerPed.MovementAnimationSet = "move_m@casual@e";
                            break;
                        case 3:
                            playerPed.MovementAnimationSet = "move_m@buzzed";
                            break;
                        case 4:
                            playerPed.MovementAnimationSet = "move_m@depressed@b";
                            break;
                        case 5:
                            playerPed.MovementAnimationSet = "move_m@sassy";
                            break;
                        case 6:
                            playerPed.MovementAnimationSet = "move_m@hobo@b";
                            break;
                        case 7:
                            playerPed.MovementAnimationSet = "move_m@intimidation@1h";
                            break;
                        case 8:
                            playerPed.MovementAnimationSet = "move_m@money";
                            break;
                        case 9:
                            playerPed.MovementAnimationSet = "move_m@fire";
                            break;
                        case 10:
                            playerPed.MovementAnimationSet = "move_m@gangster@generic";
                            break;
                        case 11:
                            playerPed.MovementAnimationSet = "move_m@swagger";
                            break;
                    }
                }
                else if (_listItem == Item3) // add check if not player died
                {
                    switch (_listItem.Index)
                    {
                        case 0:
                            playerPed.MovementAnimationSet = "move_f@arrogant@a";
                            break;
                        case 1:
                            playerPed.MovementAnimationSet = "move_characters@amanda@bag";
                            break;
                        case 2:
                            playerPed.MovementAnimationSet = "move_f@femme@";
                            break;
                        case 3:
                            playerPed.MovementAnimationSet = "move_f@gangster@ng";
                            break;
                        case 4:
                            playerPed.MovementAnimationSet = "move_f@heels@c";
                            break;
                        case 5:
                            playerPed.MovementAnimationSet = "move_f@sad@a";
                            break;
                        case 6:
                            playerPed.MovementAnimationSet = "move_f@sassy";
                            break;
                        case 7:
                            playerPed.MovementAnimationSet = "move_f@sexy@a";
                            break;
                        case 8:
                            playerPed.MovementAnimationSet = "move_f@tough_guy@";
                            break;
                        case 9:
                            playerPed.MovementAnimationSet = "move_f@tool_belt@a";
                            break;
                    }
                }
                else if (_listItem == Item4) // add check if not player died
                {
                    playerPed.MovementAnimationSet = null;
                }
                else
                {
                    Notifications.ShowNotification("You're hurt! you can't perform this action!", NotificationColor.Red, true);
                }
            };
            UIMenuItem animMenuItem = new UIMenuItem("Animations", "~g~When RolePlay also becomes fun");
            UIMenuItem animMenu1Item = new UIMenuItem("Party", "~g~To have fun");
            UIMenu animMenu = new("Animations", Game.GetGXTEntry("PIM_TITLE1"));
            UIMenu animMenu1 = new("Party", Game.GetGXTEntry("PIM_TITLE1"));
            animMenuItem.BindItemToMenu(animMenu);
            animMenu1Item.BindItemToMenu(animMenu1);
            AnimAndStyle.AddItem(animMenuItem);
            animMenu.AddItem(animMenu1Item);
            UIMenuItem item1 = new UIMenuItem("Playing");
            UIMenuItem item2 = new UIMenuItem("Dj");
            UIMenuItem item3 = new UIMenuItem("Drink a beverage");
            UIMenuItem item4 = new UIMenuItem("Drink a beer");
            UIMenuItem item5 = new UIMenuItem("Air Guitar");
            UIMenuItem item6 = new UIMenuItem("Air Shagging");
            UIMenuItem item7 = new UIMenuItem("Rock 'n Roll");
            UIMenuItem item8 = new UIMenuItem("Smoking a joint");
            UIMenuItem item9 = new UIMenuItem("Drunk");
            animMenu1.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item1)
                        playerPed.Task.StartScenario("WORLD_HUMAN_MUSICIAN", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item2)
                        playerPed.Task.PlayAnimation("anim@mp_player_intcelebrationmale@dj", "dj");
                    else if (_item == item3)
                        playerPed.Task.StartScenario("WORLD_HUMAN_DRINKING", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item4)
                        playerPed.Task.StartScenario("WORLD_HUMAN_PARTYING", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item5)
                        playerPed.Task.PlayAnimation("anim@mp_player_intcelebrationmale@air_guitar", "air_guitar");
                    else if (_item == item6)
                        playerPed.Task.PlayAnimation("anim@mp_player_intcelebrationfemale@air_shagging", "air_shagging");
                    else if (_item == item7)
                        playerPed.Task.PlayAnimation("mp_player_int_upperrock", "mp_player_int_rock");
                    else if (_item == item8)
                        playerPed.Task.StartScenario("WORLD_HUMAN_SMOKING_POT", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item9) playerPed.Task.PlayAnimation("amb@world_human_bum_standing@drunk@idle_a", "idle_a");
                }
                else
                {
                    Notifications.ShowNotification("Can't use this animation now!!", NotificationColor.Red);
                }
            };
            animMenu1.AddItem(item1);
            animMenu1.AddItem(item2);
            animMenu1.AddItem(item3);
            animMenu1.AddItem(item4);
            animMenu1.AddItem(item5);
            animMenu1.AddItem(item6);
            animMenu1.AddItem(item7);
            animMenu1.AddItem(item8);
            animMenu1.AddItem(item9);
            UIMenuItem animMenu2Item = new UIMenuItem("Greetings");
            UIMenu animMenu2 = new("Greetings", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu2Item.BindItemToMenu(animMenu2);
            animMenu.AddItem(animMenu2Item);
            UIMenuItem item10 = new UIMenuItem("Greeting");
            UIMenuItem item11 = new UIMenuItem("Greetings between friends");
            UIMenuItem item12 = new UIMenuItem("Greeting in Gang");
            UIMenuItem item13 = new UIMenuItem("Military salute");
            animMenu2.AddItem(item10);
            animMenu2.AddItem(item11);
            animMenu2.AddItem(item12);
            animMenu2.AddItem(item13);
            animMenu2.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item10)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_hello");
                    else if (_item == item11)
                        playerPed.Task.PlayAnimation("mp_ped_interaction", "handshake_guy_a");
                    else if (_item == item12)
                        playerPed.Task.PlayAnimation("mp_ped_interaction", "hugs_guy_a");
                    else if (_item == item13) playerPed.Task.PlayAnimation("mp_player_int_uppersalute", "mp_player_int_salute");
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu3Item = new UIMenuItem("Jobs", "~g~RolePlay is not only a game!");
            UIMenu animMenu3 = new("Jobs", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu3Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu3Item);
            UIMenuItem item14 = new UIMenuItem("Surrender to the police");
            UIMenuItem item15 = new UIMenuItem("Fisherman");
            UIMenuItem item16 = new UIMenuItem("Farmer - Harvest");
            UIMenuItem item17 = new UIMenuItem("Mechanic - Repair vehicle");
            UIMenuItem item18 = new UIMenuItem("Mechanic - Repair the engine");
            UIMenuItem item19 = new UIMenuItem("Police - Manage Traffic");
            UIMenuItem item20 = new UIMenuItem("Police - Investigate");
            UIMenuItem item21 = new UIMenuItem("Binoculars");
            UIMenuItem item22 = new UIMenuItem("Doctor - Check the patient");
            UIMenuItem item23 = new UIMenuItem("Taxi - Talking to the customer");
            UIMenuItem item24 = new UIMenuItem("Taxi - Give the bill");
            UIMenuItem item25 = new UIMenuItem("Grocery store - give the stuff");
            UIMenuItem item26 = new UIMenuItem("Photographer");
            UIMenuItem item27 = new UIMenuItem("Annotate");
            UIMenuItem item28 = new UIMenuItem("Hammering");
            UIMenuItem item29 = new UIMenuItem("Begging");
            UIMenuItem item30 = new UIMenuItem("Make the Statue");
            //UIMenuItem item31 = new UIMenuItem();
            animMenu3.AddItem(item14);
            animMenu3.AddItem(item15);
            animMenu3.AddItem(item16);
            animMenu3.AddItem(item17);
            animMenu3.AddItem(item18);
            animMenu3.AddItem(item19);
            animMenu3.AddItem(item20);
            animMenu3.AddItem(item21);
            animMenu3.AddItem(item22);
            animMenu3.AddItem(item23);
            animMenu3.AddItem(item24);
            animMenu3.AddItem(item25);
            animMenu3.AddItem(item26);
            animMenu3.AddItem(item27);
            animMenu3.AddItem(item28);
            animMenu3.AddItem(item29);
            animMenu3.AddItem(item30);
            animMenu3.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item14)
                        playerPed.Task.PlayAnimation("random@arrests@busted", "idle_c");
                    else if (_item == item15)
                        playerPed.Task.StartScenario("world_human_stand_fishing", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item16)
                        playerPed.Task.StartScenario("world_human_gardener_plant", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item17)
                        playerPed.Task.StartScenario("world_human_vehicle_mechanic", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item18)
                        playerPed.Task.PlayAnimation("mini@repair", "fixing_a_ped");
                    else if (_item == item19)
                        playerPed.Task.StartScenario("WORLD_HUMAN_CAR_PARK_ATTENDANT", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item20)
                        playerPed.Task.PlayAnimation("amb@code_human_police_investigate@idle_b", "idle_f");
                    else if (_item == item21)
                        playerPed.Task.StartScenario("WORLD_HUMAN_BINOCULARS", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item22)
                        playerPed.Task.StartScenario("CODE_HUMAN_MEDIC_KNEEL", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item23)
                        playerPed.Task.PlayAnimation("oddjobs@taxi@driver", "leanover_idle");
                    else if (_item == item24)
                        playerPed.Task.PlayAnimation("oddjobs@taxi@cyi", "std_hand_off_ps_passenger");
                    else if (_item == item25)
                        playerPed.Task.PlayAnimation("mp_am_hold_up", "purchase_beerbox_shopkeeper");
                    else if (_item == item26)
                        playerPed.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item27)
                        playerPed.Task.StartScenario("WORLD_HUMAN_CLIPBOARD", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item28)
                        playerPed.Task.StartScenario("WORLD_HUMAN_HAMMERING", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item29)
                        playerPed.Task.StartScenario("WORLD_HUMAN_BUM_FREEWAY", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item30) playerPed.Task.StartScenario("WORLD_HUMAN_HUMAN_STATUE", PlayerCache.MyPlayer.Position.ToVector3);
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu4Item = new UIMenuItem("Mood", "~g~What you want to say with your body?");
            UIMenu animMenu4 = new("Mood", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu4Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu4Item);
            UIMenuItem item31 = new UIMenuItem("Congratulate");
            UIMenuItem item32 = new UIMenuItem("Super");
            UIMenuItem item33 = new UIMenuItem("Indicate");
            UIMenuItem item34 = new UIMenuItem("What do you want?");
            UIMenuItem item35 = new UIMenuItem("I fucking knew it!");
            UIMenuItem item36 = new UIMenuItem("Facepalm");
            UIMenuItem item37 = new UIMenuItem("Calm down");
            UIMenuItem item38 = new UIMenuItem("Fright");
            UIMenuItem item39 = new UIMenuItem("Submit");
            UIMenuItem item40 = new UIMenuItem("Get ready");
            UIMenuItem item41 = new UIMenuItem("It's not possible!");
            UIMenuItem item42 = new UIMenuItem("Hug");
            UIMenuItem item43 = new UIMenuItem("Middle Finger");
            UIMenuItem item44 = new UIMenuItem("Wanker");
            UIMenuItem item45 = new UIMenuItem("Suicide");
            animMenu4.AddItem(item31);
            animMenu4.AddItem(item32);
            animMenu4.AddItem(item33);
            animMenu4.AddItem(item34);
            animMenu4.AddItem(item35);
            animMenu4.AddItem(item36);
            animMenu4.AddItem(item37);
            animMenu4.AddItem(item38);
            animMenu4.AddItem(item39);
            animMenu4.AddItem(item40);
            animMenu4.AddItem(item41);
            animMenu4.AddItem(item42);
            animMenu4.AddItem(item43);
            animMenu4.AddItem(item44);
            animMenu4.AddItem(item45);
            animMenu4.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item31)
                        playerPed.Task.StartScenario("WORLD_HUMAN_CHEERING", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item32)
                        playerPed.Task.PlayAnimation("mp_action", "thanks_male_06");
                    else if (_item == item33)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_point");
                    else if (_item == item34)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_bring_it_on");
                    else if (_item == item35)
                        playerPed.Task.PlayAnimation("anim@am_hold_up@male", "shoplift_high");
                    else if (_item == item36)
                        playerPed.Task.PlayAnimation("anim@mp_player_intcelebrationmale@face_palm", "face_palm");
                    else if (_item == item37)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_easy_now");
                    else if (_item == item38)
                        playerPed.Task.PlayAnimation("oddjobs@assassinate@multi@", "react_big_variations_a");
                    else if (_item == item39)
                        playerPed.Task.PlayAnimation("amb@code_human_cower_stand@male@react_cowering", "base_right");
                    else if (_item == item40)
                        playerPed.Task.PlayAnimation("anim@deathmatch_intros@unarmed", "intro_male_unarmed_e");
                    else if (_item == item41)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_damn");
                    else if (_item == item42)
                        playerPed.Task.PlayAnimation("mp_ped_interaction", "kisses_guy_a");
                    else if (_item == item43)
                        playerPed.Task.PlayAnimation("mp_player_int_upperfinger", "mp_player_int_finger_01_enter");
                    else if (_item == item44)
                        playerPed.Task.PlayAnimation("mp_player_int_upperwank", "mp_player_int_wank_01");
                    else if (_item == item45) playerPed.Task.PlayAnimation("mp_suicide", "pistol");
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu5Item = new UIMenuItem("Sports", "~g~Keeping yourself in shape..");
            UIMenu animMenu5 = new("Sports", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu5Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu5Item);
            UIMenuItem item46 = new UIMenuItem("Show off your muscles");
            UIMenuItem item47 = new UIMenuItem("Do weights");
            UIMenuItem item48 = new UIMenuItem("Doing push-ups");
            UIMenuItem item49 = new UIMenuItem("Doing sit-ups");
            UIMenuItem item50 = new UIMenuItem("Yoga");
            animMenu5.AddItem(item46);
            animMenu5.AddItem(item47);
            animMenu5.AddItem(item48);
            animMenu5.AddItem(item49);
            animMenu5.AddItem(item50);
            animMenu5.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item46)
                        playerPed.Task.PlayAnimation("amb@world_human_muscle_flex@arms_at_side@base", "base");
                    else if (_item == item47)
                        playerPed.Task.PlayAnimation("amb@world_human_muscle_free_weights@male@barbell@base", "base");
                    else if (_item == item48)
                        playerPed.Task.PlayAnimation("amb@world_human_push_ups@male@base", "base");
                    else if (_item == item49)
                        playerPed.Task.PlayAnimation("amb@world_human_sit_ups@male@base", "base");
                    else if (_item == item50) playerPed.Task.PlayAnimation("amb@world_human_yoga@male@base", "base_a");
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu6Item = new UIMenuItem("Various", "~g~For everyday life");
            UIMenu animMenu6 = new("Various", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu6Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu6Item);
            UIMenuItem item51 = new UIMenuItem("Drink a coffee");
            UIMenuItem item52 = new UIMenuItem("Sit down");
            UIMenuItem item53 = new UIMenuItem("Sit on the floor");
            UIMenuItem item54 = new UIMenuItem("Lean against the wall");
            UIMenuItem item55 = new UIMenuItem("Sunbathing");
            UIMenuItem item56 = new UIMenuItem("Lying on your stomach");
            UIMenuItem item57 = new UIMenuItem("Clean");
            UIMenuItem item58 = new UIMenuItem("Take a selfie");
            animMenu6.AddItem(item51);
            animMenu6.AddItem(item52);
            animMenu6.AddItem(item53);
            animMenu6.AddItem(item54);
            animMenu6.AddItem(item55);
            animMenu6.AddItem(item56);
            animMenu6.AddItem(item57);
            animMenu6.AddItem(item58);
            animMenu6.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item51)
                        playerPed.Task.PlayAnimation("amb@world_human_aa_coffee@idle_a", "idle_a");
                    else if (_item == item52)
                        playerPed.Task.PlayAnimation("anim@heists@prison_heistunfinished_biztarget_idle", "target_idle");
                    else if (_item == item53)
                        playerPed.Task.StartScenario("WORLD_HUMAN_PICNIC", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item54)
                        playerPed.Task.StartScenario("world_human_leaning", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item55)
                        playerPed.Task.StartScenario("WORLD_HUMAN_SUNBATHE_BACK", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item56)
                        playerPed.Task.StartScenario("WORLD_HUMAN_SUNBATHE", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item57)
                        playerPed.Task.StartScenario("world_human_maid_clean", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item58) playerPed.Task.StartScenario("world_human_tourist_mobile", PlayerCache.MyPlayer.Position.ToVector3);
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu7Item = new UIMenuItem("Hard", "~g~Life can take unexpected turns in RolePlay");
            UIMenu animMenu7 = new("Hard", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu7Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu7Item);
            UIMenuItem item59 = new UIMenuItem("Man gets fucked in car", "Better than this!");
            UIMenuItem item60 = new UIMenuItem("The woman gives a BJ in the car", "Thumbs UP! ..and not only that ;)");
            UIMenuItem item61 = new UIMenuItem("Man sex in car", "Great!");
            UIMenuItem item62 = new UIMenuItem("Woman sex in car", "Congratulations!");
            UIMenuItem item63 = new UIMenuItem("Cougar?");
            UIMenuItem item64 = new UIMenuItem("Being charming!");
            UIMenuItem item65 = new UIMenuItem("How beautiful am I??");
            UIMenuItem item66 = new UIMenuItem("Show breasts");
            UIMenuItem item67 = new UIMenuItem("Strip Tease 1");
            UIMenuItem item68 = new UIMenuItem("Strip Tease 2");
            UIMenuItem item69 = new UIMenuItem("Strip Tease 3(On the ground)");
            animMenu7.AddItem(item59);
            animMenu7.AddItem(item60);
            animMenu7.AddItem(item61);
            animMenu7.AddItem(item62);
            animMenu7.AddItem(item63);
            animMenu7.AddItem(item64);
            animMenu7.AddItem(item65);
            animMenu7.AddItem(item66);
            animMenu7.AddItem(item67);
            animMenu7.AddItem(item68);
            animMenu7.AddItem(item69);
            animMenu7.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item59)
                        playerPed.Task.PlayAnimation("oddjobs@towing", "m_blow_job_loop");
                    else if (_item == item60)
                        playerPed.Task.PlayAnimation("oddjobs@towing", "f_blow_job_loop");
                    else if (_item == item61)
                        playerPed.Task.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_sex_loop_player");
                    else if (_item == item62)
                        playerPed.Task.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_sex_loop_female");
                    else if (_item == item63)
                        playerPed.Task.PlayAnimation("mp_player_int_uppergrab_crotch", "mp_player_int_grab_crotch");
                    else if (_item == item64)
                        playerPed.Task.PlayAnimation("mini@strip_club@idles@stripper", "stripper_idle_02");
                    else if (_item == item65)
                        playerPed.Task.StartScenario("WORLD_HUMAN_PROSTITUTE_HIGH_CLASS", PlayerCache.MyPlayer.Position.ToVector3);
                    else if (_item == item66)
                        playerPed.Task.PlayAnimation("mini@strip_club@backroom@", "stripper_b_backroom_idle_b");
                    else if (_item == item67)
                        playerPed.Task.PlayAnimation("mini@strip_club@lap_dance@ld_girl_a_song_a_p1", "ld_girl_a_song_a_p1_f");
                    else if (_item == item68)
                        playerPed.Task.PlayAnimation("mini@strip_club@private_dance@part2", "priv_dance_p2");
                    else if (_item == item69) playerPed.Task.PlayAnimation("mini@strip_club@private_dance@part3", "priv_dance_p3");
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            UIMenuItem animMenu8Item = new UIMenuItem("New", "~g~Because we are evolving~w~");
            UIMenu animMenu8 = new("New", Game.GetGXTEntry("PIM_TITLE1"));
            animMenu8Item.BindItemToMenu(animMenu3);
            animMenu.AddItem(animMenu8Item);
            UIMenuItem item70 = new UIMenuItem("Facepalm", "Idiots' mom is always pregnant");
            UIMenuItem item71 = new UIMenuItem("Cross your arms", "Serious!");
            UIMenuItem item72 = new UIMenuItem("Damn");
            UIMenuItem item73 = new UIMenuItem("Failure");
            UIMenuItem item74 = new UIMenuItem("Cross your arms2", "Serious!");
            UIMenuItem item75 = new UIMenuItem("clap your hands sarcastically");
            UIMenuItem item76 = new UIMenuItem("Keep the crowd down", "calm down");
            UIMenuItem item77 = new UIMenuItem("Hold the crowd2", "I said calm down");
            animMenu7.OnItemSelect += (_menu, _item, _index) =>
            {
                if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle && playerPed.IsAlive)
                {
                    if (_item == item70)
                        playerPed.Task.PlayAnimation("anim@mp_player_intupperface_palm", "idle_a");
                    else if (_item == item71)
                        playerPed.Task.PlayAnimation("oddjobs@assassinate@construction@", "unarmed_fold_arms");
                    else if (_item == item72)
                        playerPed.Task.PlayAnimation("gestures@m@standing@casual", "gesture_damn");
                    else if (_item == item73)
                        playerPed.Task.PlayAnimation("random@car_thief@agitated@idle_a", "agitated_idle_a");
                    else if (_item == item74)
                        playerPed.Task.PlayAnimation("oddjobs@assassinate@construction@", "idle_a");
                    else if (_item == item75)
                        playerPed.Task.PlayAnimation("anim@mp_player_intcelebrationmale@slow_clap", "slow_clap");
                    else if (_item == item76)
                        playerPed.Task.PlayAnimation("amb@code_human_police_crowd_control@idle_a", "idle_a");
                    else if (_item == item77) playerPed.Task.PlayAnimation("amb@code_human_police_crowd_control@idle_b", "idle_d");
                }
                else
                {
                    Notifications.ShowNotification("You can't use this animation at the moment!!", NotificationColor.Red);
                }
            };
            animMenu8.AddItem(item70);
            animMenu8.AddItem(item71);
            animMenu8.AddItem(item72);
            animMenu8.AddItem(item73);
            animMenu8.AddItem(item74);
            animMenu8.AddItem(item75);
            animMenu8.AddItem(item76);
            animMenu8.AddItem(item77);

            #endregion

            #region Suicide

            UIMenuItem suicide = new(Game.GetGXTEntry("PIM_TKILS"), Game.GetGXTEntry("PIM_HKILS"));
            suicide.SetRightLabel(Game.GetGXTEntry("PM_KYCOST"));
            // TODO: handle when impossible to kill myself by disabling item and adding description:
            // "PIM_HKILN": "No easy way out this time.",

            interactionMenu.AddItem(suicide);
            suicide.Activated += async (item, index) =>
            {
                RequestAnimDict("mp_suicide");
                while (!HasAnimDictLoaded("mp_suicide")) await BaseScript.Delay(0);
                string Anim = "";

                //TODO: TO BE CHECKED IF PLAYER HAS A GUN OR DRUGS WITH HIM

                if (PlayerCache.MyPlayer.User.HasWeapon(WeaponHash.Pistol) || PlayerCache.MyPlayer.User.HasWeapon(WeaponHash.PistolMk2))
                {
                    if (PlayerCache.MyPlayer.User.GetWeapon(WeaponHash.Pistol).Item2.Ammo > 0)
                    {
                        playerPed.Weapons.Select(WeaponHash.Pistol);
                    }
                    else if (PlayerCache.MyPlayer.User.GetWeapon(WeaponHash.PistolMk2).Item2.Ammo > 0)
                    {
                        playerPed.Weapons.Select(WeaponHash.Pistol);
                    }
                    Anim = "PISTOL";
                }
                else
                {
                    playerPed.Weapons.Select(WeaponHash.Unarmed);
                    Anim = "PILL";
                }

                MenuHandler.CloseAndClearHistory();
                TaskPlayAnim(PlayerPedId(), "MP_SUICIDE", Anim, 8f, -8f, -1, 270540800, 0, false, false, false);
                while (GetEntityAnimCurrentTime(PlayerPedId(), "MP_SUICIDE", Anim) < 0.99f) await BaseScript.Delay(0);
                playerPed.Weapons.Select(WeaponHash.Unarmed);
                // change events
                BaseScript.TriggerEvent("DamageEvents:PedDied", playerPed.Handle, playerPed.Handle, 3452007600, false);
            };

            #endregion

            #region PassiveMode

            /*
              "PIM_HPASI0": "Passive Mode prevents physical contact with other players and some Freemode activities. Passive Mode is disabled in Weaponized Vehicles.",
              "PIM_HPASI1": "Passive Mode is not currently available.",
              "PIM_HPASI2": "Passive Mode is not available when you have a Bounty on your head.",
              "PIM_HPASI3": "Passive Mode will next be available in ~a~",
              "PIM_HPASI4": "Passive Mode is not available when you are on a One on One Deathmatch.",
              "PIM_HPASI5": "Passive Mode is not available.",
              "PIM_HPASI6": "Passive Mode is not available while you are a key player in an Event.",
              "PIM_HPASI7": "Enabling Passive Mode while active in this Event will remove you from the event.",
              "PIM_HPASI8": "Passive mode cannot be changed while taking part in this event.",
              "PIM_HPASI9": "You can't afford to use Passive Mode.",
              "PIM_HPASI10": "Passive Mode is disabled when playing as a Boss.",
              "PIM_HPASI11": "Passive Mode is disabled when playing as a Bodyguard, an Associate or a MC Member.",
              "PIM_HPASI12": "Passive Mode is disabled when taking part in Freemode Work.",
              "PIM_HPASI13": "Passive Mode is disabled while you are a key player in Freemode Work.",
              "PIM_HPASI14": "Passive Mode is disabled when taking part in a Club activity.",
              "PIM_HPASI15": "Passive Mode is disabled while you are a key player in a Club activity.",
              "PIM_HPASI16": "Passive mode is disabled while using the Mobile Operations Center with the Command Center installed.",
              "PIM_HPASI17": "Passive mode is disabled while using the Avenger.",
              "PIM_HPASI18": "Passive Mode is disabled when using any form of Weaponized Vehicle.",
              "PIM_HPASI19": "Passive Mode is disabled as you have recently killed a player. It will be available in ~a~",
              "PIM_HPASI21": "Passive mode is disabled while using the Nerve Center.",
            */
            UIMenuItem passive = new UIMenuItem(Game.GetGXTEntry("PM_SETTING_0"), Game.GetGXTEntry("PIM_HPASI0"));
            interactionMenu.AddItem(passive);


            #endregion

            interactionMenu.OnMenuClose += (a) =>
            {
                open = false;
            };
            interactionMenu.Visible = true;
        }

        public static async Task Enable()
        {
            if (MenuHandler.IsAnyMenuOpen) return;
            if (!IsUsingKeyboard(2))
            {
                if (Input.IsControlPressed(Control.InteractionMenu))
                {
                    if (await Input.IsControlStillPressedAsync(Control.InteractionMenu) && !open)
                    {
                        menuPersonal();
                        open = true;
                    }
                }
            }
            else
            {
                if (Input.IsControlJustPressed(Control.InteractionMenu))
                {
                    menuPersonal();
                    open = true;
                }
            }

            await Task.FromResult(0);
        }

        public enum RouteColor
        {
            Red = 1,
            Green = 2,
            Blue = 3,
            Yellow = 5
        }

        public static async Task routeColor()
        {
            Player me = PlayerCache.MyPlayer.Player;
            if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) > 5000f)
                SetBlipRouteColour(b.Handle, (int)RouteColor.Red);
            else if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) < 5000f && Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) > 4500f)
                SetBlipRouteColour(b.Handle, (int)RouteColor.Blue);
            else if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) < 4500f && Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) > 2500f)
                SetBlipRouteColour(b.Handle, (int)RouteColor.Yellow);
            else if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) < 2500f && Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) > 1500f)
                SetBlipRouteColour(b.Handle, (int)RouteColor.Yellow);
            else if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) < 1500f) SetBlipRouteColour(b.Handle, (int)RouteColor.Green);

            if (Vector3.Distance(PlayerCache.MyPlayer.Position.ToVector3, b.Position) < 20)
            {
                Notifications.ShowNotification("GPS: You arrived at your ~b~Destination~w~!", NotificationColor.GreenDark, true);
                b.ShowRoute = false;
                ClientMain.Instance.RemoveTick(routeColor);
            }

            await Task.FromResult(0);
        }

        public static string getStat(string name)
        {
            int val = 0;
            StatGetInt((uint)Game.GenerateHash(name), ref val, -1);

            return val.ToString();
        }
    }
}