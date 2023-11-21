using FreeRoamProject.Client;
using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace TheLastPlanet.Client.GameMode.ROLEPLAY.Personale
{
    internal static class InteractionMenu
    {

        // TODO: MAKE THE GAME COUNT IDLING OF PLAYER, IF MORE THAN 15 MINUTES THEN KICK IT..
        // WE CAN SEND SHOWNOTIFICATION WITH LABEL "HUD_ILDETIME" WITH TIME REMAINING
        // IF TIME FINISH.. PLAYER IS KICKED OUT OF THE SERVER.
        // game checks using IsInPowerSavingMode() and GetPowerSavingModeDuration()

        // TODO: IN THE PERSONAL MENU EVENTS, ADD THE SPAWNED EVENT AND RE-APPLY EVERY SETTING BEFORE THE PLAYER CAN SEE IT

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
        public static UIMenu MainMenu = null;
        public static UIMenu GangsMenu = null;
        public static UIMenu ObjectivesMenu = null;
        public static UIMenu StyleMenu = null;
        public static UIMenu VehContr = null;
        public static UIMenu ServicesMenu = null;
        public static UIMenu MapBlipOptMenu = null;
        public static UIMenu ImpromptuRaceMenu = null;
        public static UIMenu HighlightPlayerMenu = null;

        #region to be saved in char data
        public static int[] SavedHelmet = new int[2] { 16, 0 };
        public static bool VisorUp = true;
        public static int VisorUpDown = 0;
        public static int AutoShowHelmet = 1;
        public static int AutoShowAircraft = 1;
        public static int SavedAction = 0;
        public static int SavedMood = 4;
        public static int SavedWalkStyle = 0;
        public static int SavedGlowIndex = PlayerCache.MyPlayer.Status.FreeRoamStates.IlluminatedClothing;
        #endregion

        // TODO: Since i want to keep performances at their best!
        // All the UIMenuListItem must be converted to UIMenuDynamicListItem.. why?
        // Now.. for each description.. list option.. whatever label.. i'm calling Game.GetGXTEntry (GetLabelText),
        // it's a lot of pressure on the game.. so.. with UIMenuDynamicListItem.. we handle the list values before
        // and we return the GXT only when changed.. so 1 gxt per item.. instead of hundreds of them! so yeah...
        // TODO TODO TODO WITH EXTREME URGENCY FOR AAAAAAAAAAAAAAAAAAAAAAAAAALLLLLLLLLL MENUUUUSSSSS



        // TODO: THE QUICK GPS MUST BE HANDLED ON MENU BUILDING.. SO THAT WE CAN CHECK WHAT TO ADD AND WHAT NOT
        // FOR EXAMPLE GARAGES, PERSONAL VEHICLES, SIMEON, LESTER, HOME, ETC
        public static List<dynamic> gps = new List<dynamic>()
        {
            Game.GetGXTEntry("PIM_QGPS_PROP5"), // "Home 5",
            Game.GetGXTEntry("PIM_QGPS_PROP5B"), // "Garage 5",
            Game.GetGXTEntry("PIM_QGPS_PROP6"), // "Home 6",
            Game.GetGXTEntry("PIM_QGPS_PROP6B"), // "Garage 6",
            Game.GetGXTEntry("PIM_QGPS_PROP7"), // "Home 7",
            Game.GetGXTEntry("PIM_QGPS_PROP7B"), // "Garage 7",
            Game.GetGXTEntry("PIM_QGPS_PROP8"), // "Home 8",
            Game.GetGXTEntry("PIM_QGPS_PROP8B"), // "Garage 8",
            Game.GetGXTEntry("PIM_QGPS_PROP9"), // "Home 9",
            Game.GetGXTEntry("PIM_QGPS_PROP9B"), // "Garage 9",
            Game.GetGXTEntry("PIM_QGPS_PROP10"), // "Home 10",
            Game.GetGXTEntry("PIM_QGPS_PROP10B"), // "Garage 10",
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

            float safeSize = GetSafeZoneSize(); // 0.9f to 1.0f
            int x = 0; int y = 0;
            GetActiveScreenResolution(ref x, ref y);
            safeSize = (safeSize * 100) - 90;
            safeSize = 10 - safeSize;
            float height = safeSize * 5.4f;
            float width = safeSize * ((x / y) * 5.4f);
            PointF pos = new PointF(width, height);
            MainMenu = new UIMenu(Game.Player.Name, Game.GetGXTEntry("PIM_TITLE1"), pos, "commonmenu", "interaction_bgd", true, true, 0);
            MainMenu.EnableAnimation = false;
            MainMenu.Enabled3DAnimations = false;
            MainMenu.BuildingAnimation = MenuBuildingAnimation.NONE;
            MainMenu.SetMouse(true, true, true, false, false);
            GangsMenu = new(playerName, Game.GetGXTEntry("PIM_REGBOSSTIT"));
            ObjectivesMenu = new(playerName, Game.GetGXTEntry("PIM_TITLE_67"));
            StyleMenu = new(playerName, Game.GetGXTEntry("PIM_TITLESTYL"));
            VehContr = new(playerName, Game.GetGXTEntry("PIM_TITLE1"));
            ServicesMenu = new(playerName, Game.GetGXTEntry("PIM_HSECTIT"));
            MapBlipOptMenu = new(playerName, Game.GetGXTEntry("PIM_TITHS"));
            ImpromptuRaceMenu = new(playerName, Game.GetGXTEntry("R2P_MENU"));
            HighlightPlayerMenu = new(playerName, Game.GetGXTEntry("PIM_TITLE12"));


            #region Quick GPS
            // TODO: MAKE THE QUICK_GPS LIST ON RUNTIME.. YOU NEVER KNOW WHAT MUST BE ADDED AND WHAT NOT..
            // SO WE CAN'T CHECK BY THE INDEX, BUT BY THE LIST CURRENT INDEX LABEL.
            // BEFORE USING THIS.. BLIPS MUST BE MADE 😅🥲
            int currentGPS = 0;
            UIMenuDynamicListItem gpsItem = new(Game.GetGXTEntry("PIM_TQGPS"), Game.GetGXTEntry("PIM_HQGPS"), Game.GetGXTEntry($"PIM_QGPS{currentGPS}"), async (item, direction) =>
            {
                int var = currentGPS switch
                {
                    2 => 407,
                    3 => 60,
                    4 => 80,
                    5 => 108,
                    6 => 52,
                    7 => 154,
                    8 => 463,
                    9 => 225,
                    10 => 50,
                    11 => 73,
                    12 => 71,
                    13 => 408,
                    _ => 0,
                };
                /*
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
                */
                return Game.GetGXTEntry(Game.GetGXTEntry($"PIM_QGPS{currentGPS}"));
            });
            gpsItem.Enabled = false;
            MainMenu.AddItem(gpsItem);

            #endregion

            // TODO: IN THE ONLINE THIS IS A DYNAMIC OPTION.. THAT APPEAR/DISAPPEAR BASED ON NUMBER OF GANGS IN THE GAME..
            #region Gangs

            UIMenuItem gangsItem = new(Game.GetGXTEntry("PIM_REGBOSS"), Game.GetGXTEntry("PIM_REGMAGHELPB"));
            gangsItem.BindItemToMenu(GangsMenu);
            MainMenu.AddItem(gangsItem);

            // TODO: UNCENSORED IS SO ESX... WE WANT A GANG NAME BUT ALSO A SIMPLE CHECK IsBoss true/false...
            if (PlayerCache.MyPlayer.User.Character.Gang.Name == "Uncensored")
            {
                UIMenuItem becomeBoss = new UIMenuItem("Become a gang boss!");
                List<dynamic> job = new List<dynamic>() { Game.GetGXTEntry("FE_HLP31"), Game.GetGXTEntry("FE_HLP29") };
                UIMenuListItem lookingForJob = new UIMenuListItem("Looking for a \"Job\"", job, 0, GetLabelText("PIM_MAGH0D"));
                GangsMenu.AddItem(becomeBoss);
                GangsMenu.AddItem(lookingForJob);
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
                    GangsMenu.AddItem(hireItem);
                    GangsMenu.AddItem(manageItem);
                    GangsMenu.AddItem(featuresBossItem);


                    UIMenuItem retire = new UIMenuItem("Retire", "Warning.. you won't be able to set up a new gang before 6 hours!");
                    GangsMenu.AddItem(retire);
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
                    GangsMenu.AddItem(retire);
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
            objectives.Enabled = false;
            objectives.Description = "Feature not yet available, stay tuned for when this feature will be enabled!!";
            objectives.BindItemToMenu(ObjectivesMenu);
            MainMenu.AddItem(objectives);

            #endregion

            #region Inventory

            UIMenuItem inventory = new UIMenuItem(Game.GetGXTEntry("PIM_TINVE"), Game.GetGXTEntry("PIM_HINVE"));
            UIMenu inventoryMenu = new UIMenu(playerName, Game.GetGXTEntry("PIM_TITLE2"));
            inventory.BindItemToMenu(inventoryMenu);
            MainMenu.AddItem(inventory);

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
            style.BindItemToMenu(StyleMenu);
            MainMenu.AddItem(style);


            // TODO: LINK TO THE FREEROAMSTATES
            // I DON'T REALLY LIKE THIS TO BE SAVED IN STATES... BUT APPARENTLY R* DOES SOMETHING SIMILAR..
            int[] SavedHelmet = PlayerCache.Character.Stats.SavedHelmet;
            int VisorUpDown = PlayerCache.Character.Stats.VisorUpDown;
            int AutoShowHelmet = PlayerCache.Character.Stats.AutoShowHelmet;
            int AutoShowAircraft = PlayerCache.Character.Stats.AutoShowAircraft;
            int SavedAction = PlayerCache.Character.Stats.SavedAction;
            int SavedMood = PlayerCache.Character.Stats.SavedMood;
            int SavedWalkStyle = PlayerCache.Character.Stats.SavedWalkStyle;
            int SavedGlowIndex = PlayerCache.Character.Stats.IlluminatedClothing;


            /*
              "PIM_FCHAP": "You cannot change the character appearance at this time.",
              "PIM_FCHAP0": "It is not safe to change the character appearance at this time.",
              "PIM_FCHAP1": "You cannot change your character's appearance while a purchase is in progress.",
              "PIM_FCHAP2": "You cannot change your character's appearance while a save is in progress.",
              "PIM_FCHAP3": "You cannot change your character's appearance while on a Job.",
              "PIM_FCHAP4": "You cannot change your character's appearance while in an Organization or Motorcycle Club.",
              "PIM_FCHAP5": "You cannot afford to change your character's appearance.",
              "PIM_FCHAP8": "You have changed your appearance too recently, please try again later.",
              "PIM_FCHAP8_00": "You have changed your appearance too recently, the option will be available again in 0~1~:0~1~.",
              "PIM_FCHAP8_01": "You have changed your appearance too recently, the option will be available again in 0~1~:~1~.",
              "PIM_FCHAP8_10": "You have changed your appearance too recently, the option will be available again in ~1~:0~1~.",
              "PIM_FCHAP8_11": "You have changed your appearance too recently, the option will be available again in ~1~:~1~.",
              "PIM_FCHAP9": "You have changed your appearance too often, please try again later.",
              "PIM_FCHAP9_00": "You have changed your appearance too often, the option will be available again in 0~1~:0~1~.",
              "PIM_FCHAP9_01": "You have changed your appearance too often, the option will be available again in 0~1~:~1~.",
              "PIM_FCHAP9_10": "You have changed your appearance too often, the option will be available again in ~1~:0~1~.",
              "PIM_FCHAP9_11": "You have changed your appearance too often, the option will be available again in ~1~:~1~.",
              "PIM_FCHAP10": "The option to change your appearance will unlock when you reach Rank ~1~.",
             */
            UIMenuItem changeAppear = new UIMenuItem(Game.GetGXTEntry("PIM_TCHAP"), Game.GetGXTEntry("PIM_HCHAP"));
            changeAppear.SetRightLabel(Game.GetGXTEntry("ITEM_COST").Replace("~1~", "100000"));
            changeAppear.Activated += (item, index) =>
            {
                // this is the warning to show if the item is selected
                //"PIM_WCHAP": "Are you sure you want to pay $~1~ to change your character's appearance? You will be charged even if you make no changes.~n~All unsaved progress will be lost.",
            };
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

            /* description and confirmation
              "PIM_HOUTF": "Select a saved outfit to wear.",
              "PIM_HOUTFD": "Confirm to delete the selected outfit.",
             */
            List<dynamic> savedOutfits = new List<dynamic>() { Game.GetGXTEntry("PIM_NOUTF") };
            UIMenuListItem outfit = new UIMenuListItem(Game.GetGXTEntry("PIM_TOUTF"), savedOutfits, 0, Game.GetGXTEntry("PIM_HOUTF"));

            List<dynamic> racingOutfits = new List<dynamic>() { Game.GetGXTEntry("PIM_NRAO") };
            UIMenuListItem racingOutfit = new UIMenuListItem(Game.GetGXTEntry("PIM_TRAO"), racingOutfits, 0, Game.GetGXTEntry("PIM_HRAO"));

            //TODO: SAVE IT AND RELOAD ON LOGIN :D
            string prop = $"HE_FM{(PlayerCache.Character.Skin.Sex == "Male" ? "M" : "F")}_{SavedHelmet[1]}_{SavedHelmet[0]}";
            UIMenuDynamicListItem bikeHelmet = new(Game.GetGXTEntry("PIM_TBIH"), Game.GetGXTEntry("PIM_HBIH"), Game.GetGXTEntry(prop), async (item, direction) =>
            {
                if (direction == UIMenuDynamicListItem.ChangeDirection.Left)
                {
                    SavedHelmet[0]--;
                    if (SavedHelmet[0] < 0)
                    {
                        SavedHelmet[0] = 7;
                        SavedHelmet[1]--;
                        if (SavedHelmet[1] < 16)
                            SavedHelmet[1] = 18;
                    }
                }
                else
                {
                    SavedHelmet[0]++;
                    if (SavedHelmet[0] > 7)
                    {
                        SavedHelmet[0] = 0;
                        SavedHelmet[1]++;
                        if (SavedHelmet[1] > 18)
                            SavedHelmet[1] = 16;
                    }
                }

                bool isMale = PlayerCache.Character.Skin.Sex == "Male";
                string prop = $"HE_FM{(isMale ? "M" : "F")}_{SavedHelmet[1]}_{SavedHelmet[0]}";
                //values are 16 to 18 with textures 0 to 7 (total 24) (131 - 154 in the scripts when saving player stat int (subtract 131)), 
                int currentHelmet = SavedHelmet[1];
                if (currentHelmet == 18)
                {
                    currentHelmet = VisorUp ? 66 : 81;
                    if (isMale)
                        currentHelmet++;
                }
                playerPed.RemoveHelmet(true);
                if (AutoShowHelmet == 1)
                {

                    SetPedPropIndex(playerPed.Handle, 0, currentHelmet, SavedHelmet[0], false);
                    SetPedHelmetPropIndex(playerPed.Handle, currentHelmet);
                    SetPedHelmetTextureIndex(playerPed.Handle, SavedHelmet[0]);

                    if (currentHelmet == 66 || currentHelmet == 81)
                    {
                        int nextDraw = currentHelmet == 66 ? 81 : 66;
                        if (isMale)
                        {
                            currentHelmet++;
                            nextDraw++;
                        }
                        bool isAlt = false;
                        AltPropVariationData[] newHelmetData = Game.GetAltPropVariationData(playerPed.Handle, 0);
                        if (DoesShopPedApparelHaveRestrictionTag((uint)GetHashNameForProp(playerPed.Handle, 0, newHelmetData[0].altPropVariationIndex, newHelmetData[0].altPropVariationTexture), Functions.HashUint("ALT_HELMET"), 1))
                            isAlt = true;
                        else
                            isAlt = false;
                        SetPedHelmetUnk(playerPed.Handle, isAlt, currentHelmet, nextDraw);
                    }
                }
                PlayerCache.MyPlayer.User.SetPlayerStat("SavedHelmet", SavedHelmet[1], SavedHelmet[0]);

                return Game.GetGXTEntry(prop);
            });

            /* descriptions to change based on player availability and player choice (default PIM_HHELVN)
            "PIM_HHELV0": "Have the visor down for certain helmets.",
            "PIM_HHELV1": "Have the visor up for certain helmets.",
            "PIM_HHELVN": "Equip a helmet with a visor to change your preference.",
             */
            UIMenuDynamicListItem bikeVisor = new(Game.GetGXTEntry("PIM_THELV"), Game.GetGXTEntry("PIM_HHELVN"), Game.GetGXTEntry($"PIM_HELV{VisorUpDown}"), async (item, direction) =>
            {
                VisorUpDown += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (VisorUpDown < 0) VisorUpDown = 1;
                if (VisorUpDown > 1) VisorUpDown = 0;

                Ped playerPed = PlayerCache.MyPlayer.Ped;
                int pedHandle = playerPed.Handle;
                int component = GetPedPropIndex(pedHandle, 0);
                int texture = GetPedPropTextureIndex(pedHandle, 0);
                if (component == 66 || component == 81 || component == 67 || component == 82)
                {
                    int nextDraw = component == 66 ? 81 : 66;
                    if (PlayerCache.Character.Skin.Sex == "Male")
                    {
                        component++;
                        nextDraw++;
                    }
                    AltPropVariationData[] newHelmetData = Game.GetAltPropVariationData(playerPed.Handle, 0);
                    bool isAlt = DoesShopPedApparelHaveRestrictionTag((uint)GetHashNameForProp(playerPed.Handle, 0, newHelmetData[0].altPropVariationIndex, newHelmetData[0].altPropVariationTexture), Functions.HashUint("ALT_HELMET"), 1);
                    SetPedHelmetUnk(playerPed.Handle, isAlt, component, newHelmetData[0].altPropVariationIndex);
                    await InteractionMethods.SwitchComponent(false, VisorUpDown);
                }
                PlayerCache.MyPlayer.User.SetPlayerStat("VisorUpDown", VisorUpDown);
                return Game.GetGXTEntry($"PIM_HELV{VisorUpDown}");
            });


            List<dynamic> autoShowBikeHelmetList = new List<dynamic>() { Game.GetGXTEntry("PIM_AHLM0"), Game.GetGXTEntry("PIM_AHLM1") };
            UIMenuDynamicListItem autoShowBikeHelmet = new(Game.GetGXTEntry("PIM_TAHLM"), Game.GetGXTEntry("PIM_HAHLM"), Game.GetGXTEntry($"PIM_AHLM{AutoShowHelmet}"), async (item, direction) =>
            {
                AutoShowHelmet += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (AutoShowHelmet < 0) AutoShowHelmet = 1;
                if (AutoShowHelmet > 1) AutoShowHelmet = 0;
                SetPedConfigFlag(playerPed.Handle, 380, AutoShowHelmet == 0);
                PlayerCache.MyPlayer.User.SetPlayerStat("AutoShowHelmet", AutoShowHelmet);
                return Game.GetGXTEntry($"PIM_AHLM{AutoShowHelmet}");
            });


            UIMenuDynamicListItem autoShowAircraftHelmet = new(Game.GetGXTEntry("PIM_TAAHLM"), Game.GetGXTEntry("PIM_HAAHLM"), Game.GetGXTEntry($"PIM_AAHLM{AutoShowAircraft}"), async (item, direction) =>
            {
                AutoShowAircraft += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (AutoShowAircraft < 0) AutoShowAircraft = 1;
                if (AutoShowAircraft > 1) AutoShowAircraft = 0;
                SetPedConfigFlag(playerPed.Handle, 381, AutoShowAircraft == 0);
                PlayerCache.MyPlayer.User.SetPlayerStat("AutoShowAircraft", AutoShowAircraft);
                return Game.GetGXTEntry($"PIM_AAHLM{AutoShowAircraft}");
            });

            /*
              "PIM_HANIM": "The selected action will be stored as your Quickplay Action. Press or hold the Quickplay Action buttons to alter how you will perform this action.",
              "PIM_HANIM2": "The selected action will be stored as your Quickplay Action. Press, double tap or hold the Quickplay Action buttons to alter how you perform this action.",
              "PIM_HANIM3": "The selected action will be stored as your Quickplay Action and take $~1~ from your wallet with each use. Press, double tap or hold the Quickplay Action buttons to alter how you perform this action.",
              "PIM_HANIM4": "The selected Quickplay Action requires Blêuter'd Champagne purchased from the Arena War Spectator Box. Press, double tap or hold the Quickplay Action buttons to perform the action and remove a bottle of Blêuter'd Champagne from your inventory.",
              "PIM_HANIM5": "The selected Quickplay Action requires a Horror Pumpkin Mask to be equipped. Press or hold the Quickplay Action buttons to perform the action.",
             */
            string currentAction = Game.GetGXTEntry("IAP_NONE");
            UIMenuDynamicListItem action = new UIMenuDynamicListItem(Game.GetGXTEntry(VehicleChecker.IsInVehicle ? "PIM_TANIMP" : "PIM_TANIMF"), Game.GetGXTEntry("PIM_HANIM"), currentAction, async (sender, direction) =>
            {
                // items in game are hanlded like a dynamiclistitem via a function with a check if the ped is in vehicle and the current index i think..
                SavedAction = direction == UIMenuDynamicListItem.ChangeDirection.Left ? SavedAction - 1 : SavedAction + 1;
                int currentSituation = 2;
                int max = 66;
                if (VehicleChecker.IsInVehicle)
                {
                    currentSituation = 0;
                    max = 42;
                }

                /*
                 if we are in a crew, currentSituation = 1 and max = 3
                 */

                if (SavedAction < 0)
                    SavedAction = max;
                if (SavedAction > max)
                    SavedAction = 0;
                string result = GetAnimName(currentSituation, SavedAction);

                InteractionMethods.CurrentAnimMode = currentSituation;
                InteractionMethods.CurrentAnimSelection = SavedAction;

                //TODO: FIND CORRECT ANIMATION AND SAVE IT FOR WHEN THE PLAYER DECIDES TO USE IT

                bool value = currentSituation switch
                {
                    1 => SavedAction switch
                    {
                        0 or 3 => false,
                        _ => true,
                    },
                    2 => SavedAction switch
                    {
                        0 or 60 or 61 or 63 or 64 or 65 or 66 => false,
                        _ => true,
                    },
                    3 => SavedAction switch
                    {
                        0 or 1 or 2 or 3 => false,
                        _ => true,
                    },
                    _ => false,
                };
                sender.Description = SavedAction switch
                {
                    39 when PlayerCache.MyPlayer.Ped.IsOnFoot => Game.GetGXTEntry("PIM_HANIM3"),
                    62 when PlayerCache.MyPlayer.Ped.IsOnFoot => Game.GetGXTEntry("PIM_HANIM4"),
                    58 => Game.GetGXTEntry("PIM_HANIM5"),
                    _ => VehicleChecker.IsInVehicle || !value ? Game.GetGXTEntry("PIM_HANIM") : Game.GetGXTEntry("PIM_HANIM2"),
                };

                PlayerCache.MyPlayer.User.SetPlayerStat("SavedAction", SavedAction);
                return Game.GetGXTEntry(result);
            });

            if (playerPed.IsOnBike)
            {
                action.Enabled = false;
            }

            /* titles(default PIM_TMOODN)
              "PIM_TMOODD": "Player Mood (Deathmatch)",
              "PIM_TMOODN": "Player Mood",
              "PIM_TMOODR": "Player Mood (Race)",
             */
            /* descriptions (default PIM_HMOODN)
              "PIM_HMOODD": "Sets your character's facial expression during Deathmatches.",
              "PIM_HMOODN": "Sets your character's facial expression.",
              "PIM_HMOODR": "Sets your character's facial expression during Races.",
             */
            UIMenuDynamicListItem playerMood = new(Game.GetGXTEntry("PIM_TMOODN"), Game.GetGXTEntry("PIM_HMOODN"), Game.GetGXTEntry($"PM_MOOD_{SavedMood}"), async (item, direction) =>
            {
                Ped ped = PlayerCache.MyPlayer.Ped;

                SavedMood += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (SavedMood < 0)
                    SavedMood = 7;
                if (SavedMood > 7)
                    SavedMood = 0;

                if (!ped.IsInjured)
                {
                    if (!ped.GetConfigFlag(418) && !ped.GetConfigFlag(419))
                    {
                        if (InteractionMethods.MoodCam == null || !InteractionMethods.MoodCam.Exists())
                        {
                            ped.Task.ClearAll();
                            Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, false, 0);
                            SetPlayerControl(PlayerId(), false, 2560);
                            Position coords = PlayerCache.MyPlayer.Position;
                            InteractionMethods.MoodCam = new Camera(CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", coords.X, coords.Y, coords.Z, 0f, 0f, 0f, 50f, false, 2));
                            InteractionMethods.MoodCam.AttachTo(ped.Bones[31086], new Vector3(0f, 0.9f, 0f));
                            PointCamAtPedBone(InteractionMethods.MoodCam.Handle, ped.Handle, 31086, 0, 0, 0, true);
                            InteractionMethods.MoodCam.FieldOfView = 50f;
                            InteractionMethods.MoodCam.IsActive = true;
                            RenderScriptCams(true, false, 3000, true, false);
                        }
                    }
                }
                InteractionMethods.SetFacialAnim(SavedMood);
                PlayerCache.MyPlayer.User.SetPlayerStat("SavedMood", SavedMood);
                return Game.GetGXTEntry($"PM_MOOD_{SavedMood}");
            });

            UIMenuDynamicListItem playerWalkStyle = new(Game.GetGXTEntry("PIM_TWALKN"), Game.GetGXTEntry("PIM_HWALKN"), Game.GetGXTEntry($"PM_WALK_{SavedWalkStyle}"), async (item, direction) =>
            {
                SavedWalkStyle += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (SavedWalkStyle < 0)
                    SavedWalkStyle = 5;
                if (SavedWalkStyle > 5)
                    SavedWalkStyle = 0;
                InteractionMethods.SetWalkingStyle(SavedWalkStyle);
                PlayerCache.MyPlayer.User.SetPlayerStat("SavedWalkStyle", SavedWalkStyle);
                return Game.GetGXTEntry($"PM_WALK_{SavedWalkStyle}");
            });

            /* descriptions (default PIM_HILLUN)
              "PIM_HILLUN": "Set the type of glow applied to illuminated clothing items.",
              "PIM_HILLUNM": "This feature is not available on this mode.",
             */
            UIMenuDynamicListItem illuminatedClothing = new UIMenuDynamicListItem(Game.GetGXTEntry("PIM_TILLUN"), Game.GetGXTEntry("PIM_HILLUN"), Game.GetGXTEntry($"PM_ILLU_{SavedGlowIndex}"), async (item, direction) =>
            {
                // SHOP_CONTROLLER.C
                // here we take the loaded param..
                int ped = playerPed.Handle;
                int hashName = GetHashNameForComponent(ped, 11, GetPedDrawableVariation(ped, 11), GetPedTextureVariation(ped, 11));
                SavedGlowIndex += direction == UIMenuDynamicListItem.ChangeDirection.Left ? -1 : 1;
                if (SavedGlowIndex < 0)
                    SavedGlowIndex = 3;
                if (SavedGlowIndex > 3)
                    SavedGlowIndex = 0;
                if (!(DoesShopPedApparelHaveRestrictionTag((uint)hashName, Functions.HashUint("DEADLINE_OUTFIT"), 0) || DoesShopPedApparelHaveRestrictionTag((uint)hashName, Functions.HashUint("MORPH_SUIT"), 0) || DoesShopPedApparelHaveRestrictionTag((uint)hashName, Functions.HashUint("LIGHT_UP"), 0) || Function.Call<bool>((Hash)0x7796B21B76221BC5, ped, 8, Functions.HashUint("LIGHT_UP")) || Function.Call<bool>((Hash)0xD726BAB4554DA580, ped, 0, Functions.HashUint("LIGHT_UP")) || Function.Call<bool>((Hash)0xD726BAB4554DA580, ped, 6, Functions.HashUint("LIGHT_UP")) || Function.Call<bool>((Hash)0xD726BAB4554DA580, ped, 7, Functions.HashUint("LIGHT_UP")) || Function.Call<bool>((Hash)0x7796B21B76221BC5, ped, 6, Functions.HashUint("LIGHT_UP")) || Function.Call<bool>((Hash)0x7796B21B76221BC5, ped, 1, Functions.HashUint("LIGHT_UP"))))
                {
                    SavedGlowIndex = 0;
                    PlayerCache.MyPlayer.User.SetPlayerStat("IlluminatedClothing", SavedGlowIndex);
                    // if loaded param != 0 then loaded param = 0 and we save, and we set a statebag with the value
                }
                else
                {
                    if (PlayerCache.Character.Stats.IlluminatedClothing != SavedGlowIndex)
                        PlayerCache.MyPlayer.User.SetPlayerStat("IlluminatedClothing", SavedGlowIndex);
                    // if loaded param != index then loaded param = index and we save, and we set a statebag with the value
                    // R* handles luminescent clothing per ped on each client.. it's not networked..
                    // so we have to loop all clients in the server to handle their blooming
                    // Code is preatty easy.. just a for cycle and based on player choice we handle the blooming
                }
                return Game.GetGXTEntry($"PM_ILLU_{SavedGlowIndex}");
            });

            /* descriptions (default PIM_HCHOOD)
              "PIM_HCHOOD": "Set your Character's hood style.",
              "PIM_HCHOOD0": "You cannot set the style of this hood.",
              "PIM_HCHOOD1": "You cannot set your Character's hood style while in a vehicle.",
              "PIM_HCHOOD2": "You cannot set your Character's hood style while wearing this outfit.",
              "PIM_HCHOOD3": "You are able to set your Character's hood style while wearing certain hoods.",
             */
            List<dynamic> hoodList = new List<dynamic>()
            {
               Game.GetGXTEntry("PM_CHOOD_0"), // "Down",
               Game.GetGXTEntry("PM_CHOOD_1"), // "Up",
               Game.GetGXTEntry("PM_CHOOD_2"), // "Tucked",
            };

            //TODO: SOLVE FUNCTION func_867 IN AM_PI_MENU.. WITHOUT IT WE CAN'T GO ON....
            //also func_1072 is the one that sets the player hood

            int choodSelection = PlayerCache.Character.Stats.CurrentHoodSetting;
            UIMenuDynamicListItem hood = new UIMenuDynamicListItem(Game.GetGXTEntry("PIM_TCHOOD"), Game.GetGXTEntry("PIM_HCHOOD"), Game.GetGXTEntry($"PM_CHOOD_{choodSelection}"), async (item, direction) =>
            {
                switch (direction)
                {
                    case UIMenuDynamicListItem.ChangeDirection.Left:
                        choodSelection--;
                        break;
                    default:
                        choodSelection++;
                        break;
                }
                PlayerCache.MyPlayer.User.SetPlayerStat("CHood", choodSelection);
                return Game.GetGXTEntry($"PM_CHOOD_{choodSelection}");
            });
            hood.Enabled = false;


            /* descriptions (default PIM_HCJACK)
                "PIM_HCJACK": "Set your Character's jacket style.",
                "PIM_HCJACK0": "You cannot set your Character's jacket style while in a vehicle.",
                "PIM_HCJACK1": "You cannot set your Character's jacket style while wearing this outfit.",
                "PIM_HCJACK2": "You cannot set the style of this jacket.",
                "PIM_HCJACK3": "You are able to set your Character's jacket style while wearing a jacket.",
             */
            List<dynamic> jacketList = new List<dynamic>()
            {
               Game.GetGXTEntry("PM_CJACK_0"), // Open
               Game.GetGXTEntry("PM_CJACK_1"), // Closed
            };
            //TODO: SOLVE FUNCTION func_867 IN AM_PI_MENU.. WITHOUT IT WE CAN'T GO ON....
            //also func_1031 is the one that sets the player jacket
            UIMenuListItem jacket = new UIMenuListItem(Game.GetGXTEntry("PIM_TCJACK"), jacketList, 0, Game.GetGXTEntry("PIM_HCJACK"));
            jacket.OnListChanged += (item, index) =>
            {
                int ped = playerPed.Handle;
            };

            StyleMenu.AddItem(changeAppear);

            accessoriesItem.BindItemToMenu(accessoriesMenu);
            StyleMenu.AddItem(accessoriesItem);

            parachuteItem.BindItemToMenu(parachuteMenu);
            StyleMenu.AddItem(parachuteItem);

            StyleMenu.AddItem(outfit);
            StyleMenu.AddItem(racingOutfit);
            StyleMenu.AddItem(bikeHelmet);
            StyleMenu.AddItem(bikeVisor);
            StyleMenu.AddItem(autoShowBikeHelmet);
            StyleMenu.AddItem(autoShowAircraftHelmet);
            StyleMenu.AddItem(action);
            StyleMenu.AddItem(playerMood);
            StyleMenu.AddItem(playerWalkStyle);
            StyleMenu.AddItem(illuminatedClothing);
            StyleMenu.AddItem(hood);
            StyleMenu.AddItem(jacket);

            StyleMenu.OnIndexChange += (menu, index) =>
            {
                PlayerCache.MyPlayer.Player.CanControlCharacter = true;
                if (InteractionMethods.MoodCam != null && InteractionMethods.MoodCam.Exists())
                {
                    InteractionMethods.MoodCam.IsActive = false;
                    RenderScriptCams(false, false, 3000, true, false);
                    InteractionMethods.MoodCam.Delete();
                }
                if (PlayerCache.MyPlayer.Ped.IsWearingHelmet && !PlayerCache.MyPlayer.Ped.IsOnBike)
                {
                    SetPedHelmet(playerPed.Handle, false);
                    RemovePedHelmet(playerPed.Handle, true);
                }
            };

            StyleMenu.OnMenuOpen += (menu, data) =>
            {
                bikeHelmet.Enabled = playerPed.IsOnBike;
                bikeVisor.Enabled = playerPed.IsOnBike;

                #region hood
                int hoodComponent = GetPedDrawableVariation(playerPed.Handle, 11);
                int hoodTexture = GetPedTextureVariation(playerPed.Handle, 11);
                int hoodHash = GetHashNameForComponent(playerPed.Handle, 11, hoodComponent, hoodTexture);
                bool isHooded = DoesShopPedApparelHaveRestrictionTag((uint)hoodHash, Functions.HashUint("HOODED_JACKET"), 0);

                if (playerPed.IsInVehicle())
                {
                    hood.Enabled = false;
                    hood.Description = Game.GetGXTEntry("PIM_HCHOOD1");
                }
                if (!isHooded)
                    hood.Description = Game.GetGXTEntry("PIM_HCHOOD3");
                else
                {
                    int variantHoodHash = -1;
                    CanHood(!isHooded, false, ref variantHoodHash);
                    bool someBool = false;
                    int iParam3 = GetHashNameForComponent(playerPed.Handle, 1, GetPedDrawableVariation(playerPed.Handle, 1), GetPedTextureVariation(playerPed.Handle, 1));
                    int iParam4 = GetHashNameForProp(playerPed.Handle, 0, GetPedPropIndex(playerPed.Handle, 0), GetPedPropTextureIndex(playerPed.Handle, 0));
                    if (DoesShopPedApparelHaveRestrictionTag((uint)variantHoodHash, Functions.HashUint("HOODED_JACKET"), 0))
                    {
                        if (DoesShopPedApparelHaveRestrictionTag((uint)variantHoodHash, Functions.HashUint("FITTED_HOOD"), 0))
                        {
                            if (!DoesShopPedApparelHaveRestrictionTag((uint)iParam4, Functions.HashUint("HOOD_HAT"), 1) && GetPedPropIndex(playerPed.Handle, 0) != -1)
                            {
                                someBool = false;
                            }
                            if ((!DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HOOD_COMPAT"), 0) && !DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HAZ_MASK"), 0)) && GetPedDrawableVariation(playerPed.Handle, 1) != 0)
                            {
                                if (DoesShopPedApparelHaveRestrictionTag((uint)iParam4, Functions.HashUint("HOOD_HAT"), 1))
                                {
                                    if (DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("SKI_MASK"), 0) || DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("BIKER_MASK"), 0))
                                    {
                                    }
                                    else
                                    {
                                        someBool = false;
                                    }
                                }
                                else if (DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("BIKER_MASK"), 0))
                                {
                                }
                                else
                                {
                                    someBool = false;
                                }
                            }
                            if (DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("NIGHT_VISION"), 0))
                            {
                                someBool = false;
                            }
                        }
                        else
                        {
                            if (GetPedPropIndex(playerPed.Handle, 0) != -1)
                            {
                                someBool = false;
                            }
                            if ((!DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HOOD_COMPAT"), 0) && !DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HAZ_MASK"), 0)) && GetPedDrawableVariation(playerPed.Handle, 1) != 0)
                            {
                                someBool = false;
                            }
                        }
                        someBool = true;
                    }

                    if (!someBool && !CanHood(false, true, ref variantHoodHash) && !CanHood(false, false, ref variantHoodHash))
                    {
                        hood.Enabled = false;
                        hood.Description = Game.GetGXTEntry("PIM_HCHOOD0");
                    }
                    else
                    {
                        hood.Description = Game.GetGXTEntry("PIM_HCHOOD");
                    }
                }



                #endregion
            };


            StyleMenu.OnMenuClose += (menu) =>
            {
                PlayerCache.MyPlayer.Player.CanControlCharacter = true;
                if (InteractionMethods.MoodCam != null && InteractionMethods.MoodCam.Exists())
                {
                    InteractionMethods.MoodCam.IsActive = false;
                    RenderScriptCams(false, false, 3000, true, false);
                    InteractionMethods.MoodCam.Delete();
                }
            };


            #endregion

            #region Vehicles
            // also PIM_HVEHIUNAVIL for when inside the Moblie Operations Center
            UIMenuItem vehContrItem = new UIMenuItem(Game.GetGXTEntry("PIM_TVEHI"), Game.GetGXTEntry("PIM_HVEHI"));
            vehContrItem.BindItemToMenu(VehContr);
            MainMenu.AddItem(vehContrItem);
            UIMenuItem fuel = new UIMenuItem("Vehicle fuel saved");
            UIMenuCheckboxItem save = new UIMenuCheckboxItem("Save Vehicle", saved);
            UIMenuCheckboxItem close = new UIMenuCheckboxItem("Door lock", closed);
            UIMenuListItem doors = new UIMenuListItem("Open/Close Door", portiere, 0);
            UIMenuCheckboxItem engine = new UIMenuCheckboxItem("Remote On/Off", InteractionMethods.saveVehicle != null ? InteractionMethods.saveVehicle.IsEngineRunning : false);
            VehContr.AddItem(fuel);
            VehContr.AddItem(save);
            VehContr.AddItem(close);
            VehContr.AddItem(doors);
            VehContr.AddItem(engine);

            if (!PlayerCache.MyPlayer.Status.PlayerStates.InVehicle)
            {
                close.Enabled = false;
                doors.Enabled = false;
                engine.Enabled = false;
            }

            VehContr.OnCheckboxChange += async (_menu, _item, _checked) =>
            {
                if (_item == close)
                    InteractionMethods.Lock(_checked);
                else if (_item == save)
                {
                    switch (_checked)
                    {
                        case true when PlayerCache.MyPlayer.Status.PlayerStates.InVehicle:
                            {
                                InteractionMethods.Save(_checked);

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
                            InteractionMethods.Save(_checked);
                            close.Enabled = false;
                            doors.Enabled = false;
                            engine.Enabled = false;
                            fuel.SetRightLabel("No vehicle saved");
                            break;
                        default:
                            Notifications.ShowNotification("You must be in a vehicle to activate the save function", true);
                            break;
                    }
                }
                else if (_item == engine) InteractionMethods.engine(_checked);
            };
            VehContr.OnListSelect += (_menu, _listItem, _itemIndex) =>
            {
                if (_listItem == doors)
                    InteractionMethods.VehDorrs(_listItem.Items[_listItem.Index].ToString());
            };

            #endregion

            #region Services
            // PIM_HSERVICES for not having... PIM_HSERVICES2 for when unlocked
            UIMenuItem services = new UIMenuItem("Services", Game.GetGXTEntry("PIM_HSERVICES"));
            services.BindItemToMenu(ServicesMenu);
            MainMenu.AddItem(services);

            #endregion

            #region MapBlipOptions
            UIMenuItem mapBlipOpt = new UIMenuItem(Game.GetGXTEntry("PIM_THIDE"), Game.GetGXTEntry("PIM_HHIDS"));
            mapBlipOpt.BindItemToMenu(MapBlipOptMenu);
            MainMenu.AddItem(mapBlipOpt);

            #endregion

            #region ImpromptuRace

            UIMenuItem impromptuRace = new UIMenuItem(Game.GetGXTEntry("PIM_TITLE11"), Game.GetGXTEntry("PIM_HR2P"));
            impromptuRace.BindItemToMenu(ImpromptuRaceMenu);
            MainMenu.AddItem(impromptuRace);

            #endregion

            #region Highlight player

            // TODO: FIND CORRECT DESCRIPTION IN GTA:O
            UIMenuItem highlightPlayer = new UIMenuItem(Game.GetGXTEntry("PIM_THIGH"), Game.GetGXTEntry("PIM_HHIGH"));
            highlightPlayer.BindItemToMenu(HighlightPlayerMenu);
            MainMenu.AddItem(highlightPlayer);

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
            MainMenu.AddItem(voiceChat);

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
            MainMenu.AddItem(spawnLoc);

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
            MainMenu.AddItem(playerTargeting);

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
            MainMenu.AddItem(AnimAndStyleItem);
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

            MainMenu.AddItem(suicide);
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
                TaskPlayAnim(playerPed.Handle, "MP_SUICIDE", Anim, 8f, -8f, -1, 270540800, 0, false, false, false);
                while (GetEntityAnimCurrentTime(playerPed.Handle, "MP_SUICIDE", Anim) < 0.99f) await BaseScript.Delay(0);
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
            MainMenu.AddItem(passive);


            #endregion

            MainMenu.OnMenuClose += (a) =>
            {
                open = false;
            };
            MainMenu.Visible = true;
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

        static string GetAnimName(int iParam0, int chood)//Position - 0x23849A
        {
            switch (iParam0)
            {
                case 0:
                    switch (chood)
                    {
                        case 0:
                            return "IAP_NONE";
                        case 1:
                            return "IAPS_SMOK";
                        case 2:
                            return "IAPS_FING";
                        case 3:
                            return "IAPS_DANCE";
                        case 4:
                            return "IAPS_ROCK";
                        case 5:
                            return "IAPS_WANK";
                        case 7:
                            return "IAP_DLC37";
                        case 8:
                            return "IAP_DLC12";
                        case 9:
                            return "IAP_DLC18";
                        case 10:
                            return "IAP_DLC23";
                        case 6:
                            return "IAP_DLC1";
                        case 11:
                            return "IAP_DLC42";
                        case 12:
                            return "IAP_DLC5";
                        case 13:
                            return "IAP_DLC4";
                        case 14:
                            return "IAP_DLC35";
                        case 15:
                            return "IAP_DLC2";
                        case 17:
                            return "D_IAP_DLC44";
                        case 16:
                            return "D_IAP_DLC29";
                        case 18:
                            return "D_IAP_DLC45";
                        case 19:
                            return "D_IAP_DLC46";
                        case 20:
                            return "D_IAP_DLC47";
                        case 21:
                            return "D_IAP_DLC48";
                        case 22:
                            return "D_IAP_DLC49";
                        case 23:
                            return "D_IAP_DLC20";
                        case 25:
                            return "D_IAP_DLC9";
                        case 24:
                            return "D_IAP_DLC30";
                        case 28:
                            return "D_IAP_DLC28";
                        case 27:
                            return "D_IAP_DLC21";
                        case 26:
                            return "D_IAP_DLC32";
                        case 29:
                            return "D_IAP_DLC34";
                        case 30:
                            return "D_IAP_DLC3";
                        case 31:
                            return "D_IAP_CAS_2";
                        case 32:
                            return "D_IAP_CAS_3";
                        case 33:
                            return "D_IAP_CAS_4";
                        case 34:
                            return "D_IAP_CAS_6";
                        case 35:
                            return "D_IAP_CAS_7";
                        case 36:
                            return "D_IAP_CAS_5";
                        case 37:
                            return "IAP_CAS_H_1";
                        case 38:
                            return "IAP_CAS_H_2";
                        case 39:
                            return "IAP_CAS_H_3";
                        case 40:
                            return "IAP_CAS_H_4";
                        case 41:
                            return "IAP_CAS_H_5";
                        case 42:
                            return "IAP_CAS_H_6";
                    }
                    break;

                case 1:
                    switch (chood)
                    {
                        case 0:
                            return "IAC_BROL";
                        case 1:
                            return "IAC_FING";
                        case 2:
                            return "IAC_WANK";
                        case 3:
                            return "IAC_UPYO";
                    }
                    break;

                case 2:
                    switch (chood)
                    {
                        case 0:
                            return "IAP_NONE";
                        case 1:
                            return "IAP_FING";
                        case 2:
                            return "IAP_ROCK";
                        case 3:
                            return "IAP_SALU";
                        case 4:
                            return "IAP_WANK";
                        case 59:
                            return "IAP_SMOKE";
                        case 60:
                            return "IAP_DRINK1";
                        case 61:
                            return "IAP_DRINK2";
                        case 62:
                            return "IAP_DRINK3";
                        case 63:
                            return "IAP_DRINK4";
                        case 64:
                            return "IAP_EAT1";
                        case 65:
                            return "IAP_EAT2";
                        case 66:
                            return "IAP_EAT3";
                        case 6:
                            return "IAP_DLC37";
                        case 7:
                            return "IAP_DLC12";
                        case 8:
                            return "IAP_DLC18";
                        case 5:
                            return "IAP_DLC1";
                        case 9:
                            return "IAP_DLC42";
                        case 10:
                            return "IAP_DLC5";
                        case 11:
                            return "IAP_DLC4";
                        case 12:
                            return "IAP_DLC35";
                        case 13:
                            return "IAP_DLC2";
                        case 15:
                            return "D_IAP_DLC44";
                        case 14:
                            return "D_IAP_DLC29";
                        case 16:
                            return "D_IAP_DLC45";
                        case 17:
                            return "D_IAP_DLC46";
                        case 18:
                            return "D_IAP_DLC47";
                        case 19:
                            return "D_IAP_DLC48";
                        case 20:
                            return "D_IAP_DLC49";
                        case 21:
                            return "D_IAP_DLC20";
                        case 23:
                            return "D_IAP_DLC9";
                        case 22:
                            return "D_IAP_DLC30";
                        case 24:
                            return "D_IAP_DLC32";
                        case 25:
                            return "D_IAP_DLC21";
                        case 26:
                            return "D_IAP_DLC28";
                        case 27:
                            return "D_IAP_DLC34";
                        case 28:
                            return "D_IAP_DLC3";
                        case 30:
                            return "D_IAP_BB_1";
                        case 29:
                            return "D_IAP_BB_1L";
                        case 31:
                            return "D_IAP_BB_1R";
                        case 32:
                            return "D_IAP_BB_2";
                        case 33:
                            return "D_IAP_BB_3";
                        case 34:
                            return "D_IAP_BB_4";
                        case 35:
                            return "D_IAP_BB_5";
                        case 36:
                            return "D_IAP_BB_6";
                        case 37:
                            return "D_IAP_BB_7";
                        case 38:
                            return "D_IAP_BB_8";
                        case 40:
                            return "D_IAP_CAS_2";
                        case 41:
                            return "D_IAP_CAS_3";
                        case 42:
                            return "D_IAP_CAS_4";
                        case 43:
                            return "D_IAP_CAS_6";
                        case 44:
                            return "D_IAP_CAS_7";
                        case 45:
                            return "D_IAP_CAS_5";
                        case 46:
                            return "IAP_CAS_H_1";
                        case 47:
                            return "IAP_CAS_H_2";
                        case 48:
                            return "IAP_CAS_H_3";
                        case 49:
                            return "IAP_CAS_H_4";
                        case 50:
                            return "IAP_CAS_H_5";
                        case 51:
                            return "IAP_CAS_H_6";
                        case 39:
                            return "D_IAP_AW_1";
                        case 58:
                            return "PIM_MASK_SFX_T";
                        case 52:
                            return "D_IAP_HI_1";
                        case 53:
                            return "D_IAP_HI_2";
                        case 54:
                            return "D_IAP_HI_3";
                        case 55:
                            return "D_IAP_HI_4";
                        case 56:
                            return "D_IAP_HI_5";
                        case 57:
                            return "D_IAP_HI_6";
                    }
                    break;
            }
            return "";
        }

        private static bool CanHood(bool bParam1, bool bParam2, ref int hoodVariantHash)
        {
            int ped = PlayerPedId();
            int component = GetPedDrawableVariation(ped, 11);
            int texture = GetPedTextureVariation(ped, 11);
            int hoodHash = GetHashNameForComponent(ped, 11, component, texture);

            int hoodCount = GetShopPedApparelVariantComponentCount((uint)hoodHash);
            if (hoodCount > 0)
            {
                hoodVariantHash = -1;
                int iVar3 = 0;
                int var2 = 0;
                for (int i = 0; i < hoodCount; i++)
                {
                    GetVariantComponent((uint)hoodHash, i, ref hoodVariantHash, ref var2, ref iVar3);
                    if (iVar3 == 11 && hoodVariantHash != 0 && (uint)hoodVariantHash != Functions.HashUint("0") && bParam1 == DoesShopPedApparelHaveRestrictionTag((uint)hoodVariantHash, Functions.HashUint("HOOD_UP"), 0) && bParam2 == DoesShopPedApparelHaveRestrictionTag((uint)hoodVariantHash, Functions.HashUint("HOOD_TUCKED"), 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool func_889(uint iParam0, int iParam1, ref int iParam2, int iParam3)//Position - 0x975D5
        {
            int iVar0;
            int iVar1;
            int uVar2 = 0;
            int iVar3 = 0;

            iVar0 = GetShopPedApparelVariantComponentCount(iParam0);
            iVar1 = 0;
            while (iVar1 < iVar0)
            {
                GetVariantComponent(iParam0, iVar1, ref iParam2, ref uVar2, ref iVar3);
                if (iVar3 == iParam1)
                {
                    if (iParam2 != 0 && iParam2 != Functions.HashInt("0"))
                    {
                        if (iParam3 == -1 || DoesShopPedApparelHaveRestrictionTag((uint)iParam2, (uint)iParam3, iVar3))
                        {
                            return true;
                        }
                    }
                }
                iVar1++;
            }
            return false;
        }

        static bool func_890(int iParam0, int iParam1, int iParam2)//Position - 0x97640
        {
            int iVar0;
            int iVar1;
            int iVar2 = 0;
            int uVar3 = 0;
            int iVar4 = 0;

            if (iParam0 != -1)
            {
                iVar0 = GetShopPedApparelForcedComponentCount((uint)iParam0);
                iVar1 = 0;
                while (iVar1 < iVar0)
                {
                    GetForcedComponent((uint)iParam0, iVar1, ref iVar2, ref uVar3, ref iVar4);
                    if (iVar4 == iParam1 && (iParam2 == -1 || iParam2 == iVar2))
                    {
                        return true;
                    }
                    iVar1++;
                }
            }
            return false;
        }

        static bool func_891(int iParam0, bool bParam1, bool bParam2, ref int iParam3)//Position - 0x97698
        {
            int iVar0;
            int iVar1;
            int uVar2 = 0;
            int iVar3 = 0;

            iParam3 = -1;
            iVar0 = GetShopPedApparelVariantComponentCount((uint)iParam0);
            iVar1 = 0;
            while (iVar1 < iVar0)
            {
                GetVariantComponent((uint)iParam0, iVar1, ref iParam3, ref uVar2, ref iVar3);
                if ((((iVar3 == 11 && iParam3 != 0) && iParam3 != Functions.HashInt("0")) && bParam1 == DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HOOD_UP"), 0)) && bParam2 == DoesShopPedApparelHaveRestrictionTag((uint)iParam3, Functions.HashUint("HOOD_TUCKED"), 0))
                {
                    return true;
                }
                iVar1++;
            }
            return false;
        }

        static async Task<int> func_81(int iParam0, int iParam1, int iParam2, int iParam3)//Position - 0x3C36
        {
            int iVar0;
            int iVar1;
            int iVar2 = 0;
            int iVar3;

            iVar0 = func_77(iParam3);
            iVar1 = GetNumberOfPedDrawableVariations(iParam0, iVar0);
            iVar3 = 0;
            while (iVar3 <= (iVar1 - 1))
            {
                await BaseScript.Delay(0);
                if (iVar3 != iParam1)
                {
                    iVar2 += GetNumberOfPedTextureVariations(iParam0, iVar0, iVar3);
                }
                else
                {
                    iVar2 += iParam2;
                    return iVar2;
                }
                iVar3++;
            }
            return -99;
        }

        static int func_77(int iParam0)//Position - 0x3A24
        {
            return iParam0 switch
            {
                0 => 0,
                2 => 2,
                3 => 3,
                4 => 4,
                6 => 6,
                5 => 5,
                8 => 8,
                9 => 9,
                10 => 10,
                1 => 1,
                7 => 7,
                11 => 11,
                _ => 0,
            };
        }

    }
}