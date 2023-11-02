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
        private static UIMenuItem hu = new UIMenuItem("Hunger");
        private static UIMenuItem th = new UIMenuItem("Thirst");
        private static UIMenuItem ti = new UIMenuItem("Tireness");
        private static UIMenuItem si = new UIMenuItem("Sickness");

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
        public static List<dynamic> gps = new List<dynamic>()
        {
            "None",
            Game.GetGXTEntry("BLIP_HOSP"),
            Game.GetGXTEntry("FMMC_HS_2"),
            Game.GetGXTEntry("RE_SR_BL_SHP"),
            Game.GetGXTEntry("BLIP_110"),
            "Clothes shop",
            "Barber shop",
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
            Player me = PlayerCache.MyPlayer.Player;
            Point pos = new Point(50, 50);
            UIMenu PersonalMenu = new UIMenu(Game.Player.Name, Game.GetGXTEntry("PIM_TITLE1"), pos, "commonmenu", "interaction_bgd", false, true);

            #region Quick GPS
            UIMenuListItem gpsItem = new UIMenuListItem(Game.GetGXTEntry("PIM_TQGPS"), gps, 0);
            PersonalMenu.AddItem(gpsItem);
            PersonalMenu.OnListSelect += async (menu, _item, _itemIndex) =>
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

            #region Vehicle controls
            UIMenuItem vehContrItem = new UIMenuItem("Vehicle controls");
            UIMenu vehContr = new("Vehicle controls", Game.GetGXTEntry("PIM_TITLE1"));
            vehContrItem.BindItemToMenu(vehContr);
            PersonalMenu.AddItem(vehContrItem);
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
            PersonalMenu.AddItem(AnimAndStyleItem);
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

            #region Gangs

            UIMenuItem gangsItem = new("Criminal gangs", "Establish and manage your own criminal gang!");
            UIMenu gangsMenu = new("Criminal gangs", Game.GetGXTEntry("PIM_TITLE1"));
            gangsItem.BindItemToMenu(gangsMenu);
            PersonalMenu.AddItem(gangsItem);

            if (me.GetPlayerData().Character.Gang.Name == "Uncensored")
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
                    if (me.GetPlayerData().Bank > 5000)
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
                if (me.GetPlayerData().Character.Gang.Grade > 4)
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
                        //Main.ActiveGangs.Remove(me.GetPlayerData().Character.Gang);
                        ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("Retired", $"You're no longer the boss of the ~o~{me.GetPlayerData().Character.Gang.Name}~w~ gang.");
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
                        ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("Retired", $"You're not a member of the ~o~{me.GetPlayerData().Character.Gang.Name}~w~ gang anymore.");
                        Game.PlaySound("Boss_Message_Orange", "GTAO_Boss_Goons_FM_Soundset");
                        PlayerCache.MyPlayer.User.Character.Gang = new Gang("Uncensored", 0);
                    };
                }
            }

            #endregion

            #region Suicide

            UIMenuListItem suicide = new UIMenuListItem(Game.GetGXTEntry("PIM_TKILS"), new List<dynamic>() { "Drugs", "Pistol" }, 0, "⚠️ ~r~WARNING~w~, assisted suicide is a very dangerous RP gamble.\nThe respawn time will be much less than usual and you will lose everything!");
            PersonalMenu.AddItem(suicide);
            suicide.OnListSelected += async (item, index) =>
            {
                RequestAnimDict("mp_suicide");
                while (!HasAnimDictLoaded("mp_suicide")) await BaseScript.Delay(0);
                string var = item.Items[index] as string;
                string Anim = "";

                //TODO: TO BE CHECKED IF PLAYER HAS A GUN OR DRUGS WITH HIM
                switch (item.Index)
                {
                    case 0:
                        Anim = me.GetPlayerData().Character.Skin.Sex == "Male" ? "pill" : "pill_fp";
                        break;
                    case 1:
                        Anim = me.GetPlayerData().Character.Skin.Sex == "Male" ? "PISTOL" : "PISTOL_FP";
                        break;
                }

                if (Anim == "PISTOL" || Anim == "PISTOL_FP")
                {
                    if (playerPed.Weapons.HasWeapon(WeaponHash.Pistol))
                    {
                        playerPed.Weapons.Select(WeaponHash.Pistol);
                    }
                    else
                    {
                        Notifications.ShowNotification("You can't commit gun suicide without having a gun!");

                        return;
                    }
                }

                MenuHandler.CloseAndClearHistory();
                TaskPlayAnim(PlayerPedId(), "MP_SUICIDE", Anim, 8f, -8f, -1, 270540800, 0, false, false, false);
                while (GetEntityAnimCurrentTime(PlayerPedId(), "MP_SUICIDE", Anim) < 0.99f) await BaseScript.Delay(0);
                playerPed.Weapons.Select(WeaponHash.Unarmed);
                BaseScript.TriggerEvent("DamageEvents:PedDied", playerPed.Handle, playerPed.Handle, 3452007600, false);
            };

            #endregion

            PersonalMenu.OnMenuClose += (a) =>
            {
                open = false;
            };
            PersonalMenu.Visible = true;
        }

        public static async Task Enable()
        {
            if (Input.IsControlPressed(Control.InteractionMenu) && !MenuHandler.IsAnyMenuOpen)
            {
                if (await Input.IsControlStillPressedAsync(Control.InteractionMenu) && !open)
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