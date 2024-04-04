using FreeRoamProject.Client.Handlers;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.Negozi
{
    //TODO: THIS CLASS HAS 2 MENUS.. A WORKING ONE CUSTOM WITH WEAPON SHOWN ONTO THE SHOP DESK..
    //THE OTHER ONE IS A WORK IN PROGRESS TRYING TO EMULATE GTA:O SHOPS CAMERA AND WEAPONS
    static class WeaponShops
    {
        private static readonly string anim = "random@shop_gunstore";
        private static readonly string granadesProp = "lr2_prop_gc_grenades_02";
        private static readonly string v_gun2_wall = "ch_prop_board_wpnwall_01a";
        private static readonly string v_gun_wall = "ch_prop_board_wpnwall_02a";
        private static readonly string lightProp = "v_lirg_gunlight";
        private static Prop Walls;
        private static Prop Weaps;
        private static Ped spawned_shopkeeper;
        private static WeaponShopCamera ShopCamera = new();
        private static InteractionModel InteractionModel;
        private static bool MenuAperto = false;
        private static bool ShopLoaded = false;
        private static int ShopId = -1;
        private static int CurrentWeaponIndex;
        private static WeaponInfo CurrentWeaponSelected;
        private static readonly List<WeaponInfo> WeaponsObjects = [];
        private static readonly List<InputController> inputs = [];
        public static List<SharedWeapon> Weapons;
        private static readonly List<Blip> blips = [];
        private static readonly List<Position> negozi =
        [
            new(21.852f, -1106.65f, 29.61f),
            new(1693.4f, 3759.5f, 33.7f),
            new(252.3f, -50.0f, 68.9f),
            new(842.4f, -1033.4f, 27.1f),
            new(-330.2f, 6083.8f, 30.4f),
            new(-662.1f, -935.3f, 20.8f),
            new(-1306.2f, -394.0f, 35.6f),
            new(-1117.5f, 2698.6f, 17.5f),
            new(-3172.317f, 1087.959f, 20.83873f),
            new(2567.6f, 294.3f, 107.7f),
            new(810.2f, -2157.3f, 28.6f),
        ];

        private static int neutralToIdle;
        private static int greetingToIdle;
        private static int goodBye;
        private static int impatient_a;
        private static int impatitent_b;
        private static int idle_a;
        private static int positive_a;


        private static readonly List<Vector3> Entrances =
        [
            new(17.6804f, -1114.288f, 28.797f),
            new(1697.979f, 3753.2f, 33.7053f),
            new(245.2711f, -45.8126f, 68.941f),
            new(844.1248f, -1025.571f, 27.1948f),
            new(-325.8904f, 6077.026f, 30.4548f),
            new(-664.2178f, -943.3646f, 20.8292f),
            new(-1313.948f, -390.9637f, 35.592f),
            new(-1111.238f, 2688.463f, 17.6131f),
            new(-3165.231f, 1082.855f, 19.8438f),
            new(2569.612f, 302.576f, 107.7349f),
            new(811.8699f, -2149.102f, 28.6363f)
        ];
        private static Camera ArmCam;

        public static float Global_4534055;
        public static float Global_4534056;
        public static float Global_4534053;
        public static float Global_4534054;
        public static float Global_4534057;
        public static float Global_4534058;
        private static bool keyboardActive;
        private static float fLocal_1297;
        private static float fLocal_1298;
        private static bool iLocal_1091;
        private static bool iLocal_1089;
        private static int iLocal_1087;
        private static bool iLocal_1088;
        private static readonly bool some_unkown_bool;

        public static async void Init()
        {
            foreach (Vector3 v in Entrances)
            {
                Blip bliparmi = World.CreateBlip(v);
                bliparmi.Sprite = BlipSprite.AmmuNation;
                SetBlipDisplay(bliparmi.Handle, 4);
                bliparmi.Scale = 1f;
                bliparmi.Color = BlipColor.Green;
                bliparmi.IsShortRange = true;
                bliparmi.Name = Game.GetGXTEntry("BLIP_110");
                blips.Add(bliparmi);
                // this whole code is for experimenting with the vanilla ammunations to replicate them.. i can't make the camera work when pressing E... maybe i'm missing something..
                // but i don't know what am i missing... old code (commented) is about another ammunation i made with weapons being spawned on the counter and camera centered from above.

                /*
				var inp = new InputController(Control.Context, v, "Press ~INPUT_CONTEXT~ per accedere all'armeria", new((MarkerType)(-1), v, Colors.Transparent), ModalitaServer.FreeRoam, action: new Action<Ped, object[]>(MenuArmeria));
				InputHandler.AddInput(inp);
				inputs.Add(inp);
				*/
            }
            Weapons = await EventDispatcher.Get<List<SharedWeapon>>("tlg:getWeaponsConfig");
            TickController.TickOnFoot.Add(ArmeriaTick);
        }

        public static void Stop()
        {
            blips.ForEach(v => v.Delete());
            blips.Clear();
            /*
			inputs.ForEach(x => InputHandler.RemoveInput(x));
			inputs.Clear();
			*/
            TickController.TickOnFoot.Remove(ArmeriaTick);
        }

        public static async Task ArmeriaTick()
        {
            if (!ShopLoaded)
            {
                foreach (Vector3 pos in Entrances)
                {
                    if (PlayerCache.MyClient.Position.IsInRangeOf(pos, 50))
                    {
                        ShopLoaded = true;
                        ShopId = Entrances.IndexOf(pos) + 28;
                        HideIplProps(pos);

                        RequestModel(Functions.HashUint(granadesProp));
                        while (!HasModelLoaded(Functions.HashUint(granadesProp))) await BaseScript.Delay(0);
                        RequestModel(Functions.HashUint(v_gun2_wall));
                        while (!HasModelLoaded(Functions.HashUint(v_gun2_wall))) await BaseScript.Delay(0);
                        RequestModel(Functions.HashUint(v_gun_wall));
                        while (!HasModelLoaded(Functions.HashUint(v_gun_wall))) await BaseScript.Delay(0);

                        if (ShopId == 28 || ShopId == 38)
                        {
                            Vector3 Var33 = new(21.852f, -1106.65f, 29.61f);
                            Vector3 Var36 = new(0f, 0f, -20f);
                            func_212(28, ShopId, ref Var33);
                            func_208(28, ShopId, ref Var36);

                            Vector3 Var39 = new(22.2036f, -1106.676f, 30.2385f);
                            Vector3 Var42 = new(0f, 0f, -20f);
                            func_212(28, ShopId, ref Var39);
                            func_208(28, ShopId, ref Var42);

                            Weaps = new(CreateObjectNoOffset(Functions.HashUint(granadesProp), Var33.X, Var33.Y, Var33.Z, false, true, false));
                            Weaps.Rotation = Var36;

                            Walls = new(CreateObjectNoOffset(Functions.HashUint(v_gun_wall), Var39.X, Var39.Y, Var39.Z, false, true, false));
                            Walls.Rotation = Var42;
                        }
                        else
                        {
                            Vector3 Var33 = new(-1305.318f, -394.031f, 36.51f);
                            Vector3 Var36 = new(0f, 0f, -105f);
                            func_212(34, ShopId, ref Var33);
                            func_208(34, ShopId, ref Var36);

                            Vector3 Var39 = new(-1305.308f, -394.3083f, 37.1373f);
                            Vector3 Var42 = new(0f, 0f, -104.22f);
                            func_212(34, ShopId, ref Var39);
                            func_208(34, ShopId, ref Var42);

                            Weaps = new(CreateObjectNoOffset(Functions.HashUint(granadesProp), Var33.X, Var33.Y, Var33.Z, false, true, false));
                            Weaps.Rotation = Var36;

                            Walls = new(CreateObjectNoOffset(Functions.HashUint(v_gun2_wall), Var39.X, Var39.Y, Var39.Z, false, true, false));
                            Walls.Rotation = Var42;
                        }
                        for (int i = 0; i < 22; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                WeaponInfo info = GetWeaponValues(i, j);
                                if (info != null)
                                {
                                    uint hash = Functions.HashUint(info.Model);
                                    int weapon;
                                    if (info.Type == 0)
                                    {
                                        RequestModel(hash);
                                        while (!HasModelLoaded(hash)) await BaseScript.Delay(0);
                                        weapon = CreateObjectNoOffset(hash, info.Coords.X, info.Coords.Y, info.Coords.Z, false, false, false);
                                    }
                                    else
                                    {
                                        RequestWeaponAsset(hash, 31, 0);
                                        while (!HasWeaponAssetLoaded(hash)) await BaseScript.Delay(0);
                                        weapon = Function.Call<int>(Hash.CREATE_WEAPON_OBJECT, hash, 0, info.Coords.X, info.Coords.Y, info.Coords.Z, true, 1f, 0, 0, 1);
                                        SetWeaponObjectTintIndex(weapon, 0);
                                    }
                                    SetEntityVisible(weapon, true, false);
                                    SetEntityCoordsNoOffset(weapon, info.Coords.X, info.Coords.Y, info.Coords.Z, false, false, true);
                                    SetEntityAlpha(weapon, 255, 1);
                                    SetEntityRotation(weapon, info.Rotation.X, info.Rotation.Y, info.Rotation.Z, 2, true);
                                    SetEntityCanBeDamaged(weapon, false);
                                    info.Weapon = new(weapon);
                                    WeaponsObjects.Add(info);
                                }
                            }
                        }

                        ShopkeeperModel shopkeeper_model = func_1184();
                        if (shopkeeper_model != null)
                        {
                            uint keeperHash = Functions.HashUint(shopkeeper_model.Model);
                            RequestModel(keeperHash);
                            while (!HasModelLoaded(keeperHash)) await BaseScript.Delay(0);
                            spawned_shopkeeper = new Ped(CreatePed(2, keeperHash, shopkeeper_model.Coords.X, shopkeeper_model.Coords.Y, shopkeeper_model.Coords.Z, shopkeeper_model.Heading, false, false));
                            while (!spawned_shopkeeper.Exists()) await BaseScript.Delay(0);
                            switch (ShopId)
                            {

                                case 28:
                                case 29:
                                    SetPedDefaultComponentVariation(spawned_shopkeeper.Handle);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 1, 0, 0, false);
                                    break;
                                case 30:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 1, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 1, 0, 0, false);
                                    break;
                                case 31:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 0, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    break;
                                case 32:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 2, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 10, 0, 0, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 1, 0, 0, false);
                                    break;
                                case 33:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 2, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 1, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 1, 0, 0, false);
                                    break;
                                case 34:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 2, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 0, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 1, 0, 0, false);
                                    break;
                                case 35:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 2, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 10, 0, 1, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    break;
                                case 36:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 2, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 10, 0, 0, 0);
                                    break;
                                case 37:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 0, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    break;
                                case 38:
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 0, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 3, 0, 0, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 4, 0, 1, 0);
                                    SetPedComponentVariation(spawned_shopkeeper.Handle, 8, 0, 1, 0);
                                    SetPedPropIndex(spawned_shopkeeper.Handle, 0, 0, 0, false);
                                    break;
                            }
                        }

                        SetPedCombatMovement(spawned_shopkeeper.Handle, 0);
                        SetPedAsEnemy(spawned_shopkeeper.Handle, false);
                        SetPedConfigFlag(spawned_shopkeeper.Handle, 185, true);
                        SetPedCanRagdollFromPlayerImpact(spawned_shopkeeper.Handle, false);

                        SetModelAsNoLongerNeeded(Functions.HashUint(granadesProp));
                        SetModelAsNoLongerNeeded(Functions.HashUint(v_gun2_wall));
                        SetModelAsNoLongerNeeded(Functions.HashUint(v_gun_wall));
                        SetModelAsNoLongerNeeded(Functions.HashUint(shopkeeper_model.Model));
                    }
                }
            }
            else
            {
                Vector3 pos = Entrances[ShopId - 28];

                for (int i = 0; i < 3; i++)
                {
                    InteractionModel model = func_1141(i);
                    if (model != null)
                    {
                        if (IsEntityInAngledArea(PlayerPedId(), model.Coords_02.X, model.Coords_02.Y, model.Coords_02.Z, model.Coords_03.X, model.Coords_03.Y, model.Coords_03.Z, model.Heading_01, false, true, 1) || IsEntityInAngledArea(PlayerPedId(), model.Coords_04.X, model.Coords_04.Y, model.Coords_04.Z, model.Coords_05.X, model.Coords_05.Y, model.Coords_05.Z, model.Heading_02, false, true, 1))
                        {
                            if (IsPedHeadingTowardsPosition(PlayerPedId(), model.Coords_01.X, model.Coords_01.Y, model.Coords_01.Z, 100f))
                            {
                                Notifications.ShowHelpNotification(Game.GetGXTEntry(model.Helptext));
                                if (Input.IsControlJustPressed(Control.Context))
                                {
                                    InteractionModel = model;
                                    CurrentWeaponSelected = WeaponsObjects[0];
                                    ClientMain.Logger.Debug(CurrentWeaponSelected.ToJson());
                                    CurrentWeaponIndex = 0;
                                    func_943();
                                    func_938(true, 2000);
                                    iLocal_1089 = true;
                                    iLocal_1091 = true;
                                    Vector3 Var38 = GetObjectOffsetFromCoords(CurrentWeaponSelected.Coords.X, CurrentWeaponSelected.Coords.Y, CurrentWeaponSelected.Coords.Z, CurrentWeaponSelected.Rotation.Z, CurrentWeaponSelected.OffsetCoords.X, CurrentWeaponSelected.OffsetCoords.Y, CurrentWeaponSelected.OffsetCoords.Z);
                                    Vector3 Var35 = ShopCamera.Coords;
                                    ShopCamera.Coords += Var38 - Var35 * new Vector3(0.6f);
                                    MenuAperto = true;
                                }
                            }
                        }
                    }
                }
                if (MenuAperto)
                {

                    func_590(false, CurrentWeaponSelected, false);
                    func_583();
                    func_932();
                }
                if (!PlayerCache.MyClient.Position.IsInRangeOf(pos, 200))
                {
                    if (ShopLoaded)
                    {
                        ShopLoaded = false;
                        ShowIplProps(pos);
                        if (Walls is not null && Walls.Exists()) Walls.Delete();
                        Walls = null;
                        if (Weaps is not null && Weaps.Exists()) Weaps.Delete();
                        Weaps = null;
                        if (spawned_shopkeeper is not null && spawned_shopkeeper.Exists()) spawned_shopkeeper.Delete();
                        spawned_shopkeeper = null;
                    }
                }
            }
        }


        private static void MenuArmeria(Ped p, object[] _)
        {
            if (ArmCam is null)
                ArmCam = World.CreateCamera(new Vector3(-662.5455f, -934.1703f, 22.72922f), new Vector3(-89.34778f, 0, 0), 52f);
            RenderScriptCams(true, true, 1000, false, true);
            PlayerCache.MyClient.Player.CanControlCharacter = false;
            Armeria();
        }

        private static async void Armeria()
        {
            Prop armaObj = null;
            UIMenu armeria = new("", "", new PointF(20, 20), new KeyValuePair<string, string>("ShopUI_Title_GunClub", "ShopUI_Title_GunClub"));
            Position coords = PlayerCache.MyClient.Position;
            Prop pp = new(GetClosestObjectOfType(coords.X, coords.Y, coords.Z, 10, 1948561556, false, true, true));
            Vector3 left = pp.Position + (pp.RightVector * 0.6f) + (pp.UpVector * 0.2f);
            armeria.InstructionalButtons.Add(new(InputGroup.INPUTGROUP_FRONTEND_DPAD_LR, "Scegli arma"));

            for (int i = 0; i < Weapons.Count; i++)
            {
                UIMenuItem weap = new(Game.GetGXTEntry(Weapons[i].Label.Name), Weapons[i].Description != null ? Weapons[i].Description.Hash : 0);
                weap.SetRightBadge(BadgeIcon.NONE);
                armeria.AddItem(weap);
            }

            armeria.OnIndexChange += async (a, b) =>
            {
                if (armaObj != null && armaObj.Exists())
                    armaObj.Delete();
                RequestWeaponAsset(Weapons[b].UintHash, 31, 0);
                while (!HasWeaponAssetLoaded(Weapons[b].UintHash)) await BaseScript.Delay(0);
                Vector3 pos = new(-662.4155f, -934.2104f, pp.Position.Z);
                armaObj = new Prop(CreateWeaponObject(Weapons[b].UintHash, 50, pos.X, pos.Y, left.Z, true, 1.0f, 0));
                armaObj.PositionNoOffset = pos;
                RemoveWeaponAsset(Weapons[b].UintHash);
                armaObj.Rotation = new Vector3(90);
                armaObj.IsPositionFrozen = true;
            };

            armeria.OnMenuClose += (a) =>
            {
                if (armaObj != null && armaObj.Exists())
                    armaObj.Delete();
                PlayerCache.MyClient.Player.CanControlCharacter = true;
                RenderScriptCams(false, true, 2000, false, true);
                ArmCam = null;
            };
            armeria.Visible = true;
        }

        private static void HideIplProps(Vector3 pos)
        {
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_ilev_gc_weapons"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_ilev_gc_handguns"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("p_parachute_s"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_7_wallhooks"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_22_wallhooks"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_ilev_gc_grenades"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 2f, Functions.HashUint("prop_box_ammo07b"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 2f, Functions.HashUint("v_ret_gc_calc"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 2f, Functions.HashUint("v_ret_gc_mags"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_7_wallguns"), true);
            CreateModelHide(pos.X, pos.Y, pos.Z, 20f, Functions.HashUint("v_22_wallguns"), true);
        }

        private static void ShowIplProps(Vector3 pos)
        {
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_ilev_gc_weapons"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_ilev_gc_handguns"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("p_parachute_s"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_7_wallhooks"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_22_wallhooks"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_ilev_gc_grenades"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 2.0f, Functions.HashUint("prop_box_ammo07b"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 2.0f, Functions.HashUint("v_ret_gc_calc"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 2.0f, Functions.HashUint("v_ret_gc_mags"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_7_wallguns"), false);
            Function.Call(Hash.REMOVE_MODEL_HIDE, pos.X, pos.Y, pos.Z, 20.0f, Functions.HashUint("v_22_wallguns"), false);
        }

        private static async void ShopKeeperAnimLoading()
        {
            string sLocal_154 = "random@shop_gunstore";
            RequestAnimDict(sLocal_154);
            while (!HasAnimDictLoaded(sLocal_154)) await BaseScript.Delay(0);

            OpenSequenceTask(ref neutralToIdle);
            TaskPlayAnim(0, sLocal_154, "_neutral_to_idle", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle_a", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle_b", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle_a", 8f, -8f, -1, 262144, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -8f, -1, 262145, 0f, false, false, false);
            CloseSequenceTask(neutralToIdle);
            OpenSequenceTask(ref greetingToIdle);
            TaskPlayAnim(0, sLocal_154, "_greeting", 8f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(greetingToIdle);
            OpenSequenceTask(ref goodBye);
            TaskPlayAnim(0, sLocal_154, "_positive_goodbye", 8f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(goodBye);
            OpenSequenceTask(ref impatient_a);
            TaskPlayAnim(0, sLocal_154, "_impatient_a", 8f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(impatient_a);
            OpenSequenceTask(ref impatitent_b);
            TaskPlayAnim(0, sLocal_154, "_impatient_b", 8f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(impatitent_b);
            OpenSequenceTask(ref idle_a);
            TaskPlayAnim(0, sLocal_154, "_idle_a", 4f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(idle_a);
            OpenSequenceTask(ref positive_a);
            TaskPlayAnim(0, sLocal_154, "_positive_a", 8f, -8f, -1, 786432, 0f, false, false, false);
            TaskPlayAnim(0, sLocal_154, "_idle", 8f, -2f, -1, 786433, 0f, false, false, false);
            CloseSequenceTask(positive_a);
        }

        private static ShopkeeperModel func_1184()
        {
            int identifier;
            ShopkeeperModel model = null;

            if (ShopId == 28 || ShopId == 38)
            {
                identifier = 28;
                model = new ShopkeeperModel("s_m_y_ammucity_01", 23.3396f, -1105.384f, 28.797f, 142.4851f, 23.3396f, -1105.384f, 28.797f, 142.4851f);
            }
            else
            {
                identifier = 29;
                model = new ShopkeeperModel("s_m_y_ammucity_01", 1692.38f, 3761.682f, 33.7053f, 213.3571f, 1692.38f, 3761.682f, 33.7053f, 213.3571f);
            }

            if (ShopId == 29 || ShopId == 32 || ShopId == 35 || ShopId == 36)
            {
                model.Model = "s_m_m_ammucountry";
            }

            func_212(identifier, ShopId, ref model.Coords);
            func_212(identifier, ShopId, ref model.OffsetCoords);
            func_1142(identifier, ShopId, ref model.Heading);
            func_1142(identifier, ShopId, ref model.OffsetHeading);

            return model;
        }

        private static WeaponInfo GetWeaponValues(int iParam3, int iParam4)
        {
            Vector3 Var17;
            Vector3 Var20;
            int iVar33;
            WeaponInfo info = null;
            if (ShopId == 28 || ShopId == 38)
            {
                Var17 = new(23f, -1108.65f, 29.55f);
                Var20 = new(23.07f, -1108.5f, 29.55f);
                iVar33 = 28;
                switch (iParam3)
                {
                    case 0:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(0, "p_parachute_s_shop", 19.7012f, -1103.268f, 31.3153f, -10.75f, 0f, -200f, 0f, 0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 1:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_microsmg", 19.6809f, -1103.098f, 30.753f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_smg", 19.5978f, -1103.076f, 30.361f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 2:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultsmg", 20.7097f, -1103.477f, 31.489f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_pumpshotgun", 20.5371f, -1103.415f, 31.131f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 2:
                                info = new WeaponInfo(1, "weapon_assaultshotgun", 20.5226f, -1103.468f, 30.781f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 3:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultrifle", 21.62219f, -1103.803f, 31.471f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_carbinerifle", 21.6639f, -1103.817f, 31.156f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 2:
                                info = new WeaponInfo(1, "weapon_advancedrifle", 21.6752f, -1103.849f, 30.745f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 4:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_sniperrifle", 22.61f, -1104.16f, 30.78f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_heavysniper", 22.56f, -1104.14f, 30.35f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 5:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_mg", 20.4875f, -1103.447f, 30.36f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_combatmg", 21.5992f, -1103.867f, 30.36f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 6:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_rpg", 24.37f, -1104.84f, 31.44f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_grenadelauncher", 24.0825f, -1104.755f, 31.1125f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_minigun", 23.9675f, -1104.77f, 30.757f, 0f, 0f, -20f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_raycarbine", 25.2725f, -1105.213f, 31.427f, 0f, 0f, -20f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_rayminigun", 25.22f, -1105.228f, 31.057f, 0f, 0f, -20f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 7:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(0, "prop_w_me_knife_01", 19.647f, -1105.051f, 29.54f, -89.9802f, 65f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_nightstick", 19.881f, -1105.446f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_hammer", 20.411f, -1105.616f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(0, "prop_w_me_bottle", 19.597f, -1105.301f, 29.56f, -89.966f, 110f, 0f, 0f, 0f, 0.475f, 75f, -60f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_knuckle", 20.147f, -1105.131f, 29.56f, -2.5f, 95f, 168f, 0f, 0f, 0.475f, 265f, 210f, 30f);
                                break;
                        }
                        break;
                    case 8:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_stungun", 21.925f, -1105.835f, 29.5454f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_appistol", 22.1775f, -1106.162f, 29.5387f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_combatpistol", 22.284f, -1105.931f, 29.5407f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_pistol", 22.5315f, -1106.292f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_pistol50", 22.914f, -1106.419f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;
                        }
                        break;
                    case 9:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_smokegrenade", 23.2676f, -1107.351f, 29.6454f, 0f, 0f, 245f, 0f, 0f, 0.475f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_grenade", 23.0382f, -1108.005f, 29.5878f, 0f, 0f, 245f, 0f, 0f, 0.475f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_stickybomb", Var17.X, Var17.Y, Var17.Z, 0f, 0f, 25f, 0f, 0f, 0.475f, 90f, 0f, -135f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_proxmine", Var20.X, Var20.Y, Var20.Z, 0f, 0f, 25f, 0f, 0f, 0.475f, 90f, 0f, -135f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_pipebomb", 23.15f, -1108.4f, 29.546f, 90f, -154f, 0f, 0f, 0f, 0.475f, 90f, -26f, -60f);
                                break;
                        }
                        break;
                    case 10:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_petrolcan", 22.9739f, -1109.181f, 29.6053f, 90f, 0f, 115f, -0.278f, -0.073f, 0.693f, -90f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_doubleaction", 22.8f, -1108.48f, 29.545f, -90f, 0f, -110f, 0f, 0f, 0.475f, 90f, 0f, 0f);
                                break;
                        }
                        break;
                    case 11:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultsmg", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_bullpupshotgun", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_gusenberg", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_specialcarbine", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 12:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_bullpuprifle", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_musket", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_heavyshotgun", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_marksmanrifle", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 13:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_combatpdw", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_marksmanpistol", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_railgun", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 14:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_autoshotgun", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 15:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_raypistol", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 16:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_unarmed", 16.2547f, -1110.088f, 30.7311f, 0f, 0f, 70f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_unarmed", 16.4693f, -1109.498f, 30.7311f, 0f, 0f, 70f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_unarmed", 16.6786f, -1108.923f, 30.7311f, 0f, 0f, 70f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_unarmed", 16.3512f, -1109.822f, 29.9462f, 0f, 0f, 70f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_unarmed", 16.5802f, -1109.193f, 29.9462f, 0f, 0f, 70f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 17:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_machete", 20.767f, -1105.751f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(0, "prop_w_me_dagger", 19.687f, -1105.151f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_switchblade", 19.762f, -1105.274f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_flashlight", 20.141f, -1105.416f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(0, "prop_w_me_hatchet", 20.201f, -1105.496f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;
                        }
                        break;
                    case 18:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_snspistol", 21.6115f, -1105.967f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_heavypistol", 21.859f, -1106.075f, 29.562f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_vintagepistol", 22.959f, -1106.185f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_flaregun", 23.15f, -1107.6f, 29.545f, -90f, -0.5f, -110f, 0f, 0f, 0.475f, 90f, 0f, 0f);
                                break;
                        }
                        break;
                    case 19:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 25.573f, -1106.415f, 32f, 0f, 0f, -120f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 20:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_revolver", 21.6059f, -1105.711f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_machinepistol", 21.9285f, -1105.841f, 29.562f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_compactlauncher", 22.92f, -1108.18f, 29.545f, -90f, 0f, -110f, 0f, 0f, 0.475f, 90f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_hominglauncher", 24.4025f, -1104.853f, 30.3595f, 0f, 0f, -20f, 0.35f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_ceramicpistol", 22.654f, -1106.072f, 29.5416f, -90f, 0f, 6f, 0f, 0f, 0.475f, 90f, 0f, -26f);
                                break;
                        }
                        break;
                    case 21:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_poolcue", 20.434f, -1105.161f, 29.54f, 0f, 90f, -19.5f, 0f, 0f, 0.43f, 0f, -45f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_battleaxe", 20.994f, -1105.771f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.43f, 45f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_wrench", 20.634f, -1105.671f, 29.54f, -89.98f, 60f, 0f, 0f, 0f, 0.475f, 75f, -20f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_marksmanrifle", 25.3925f, -1105.182f, 30.732f, 0f, 0f, -20f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_heavyshotgun", 25.4075f, -1105.167f, 30.367f, 0f, 0f, -20f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                }

                if (info != null)
                {
                    if (iParam3 == 11 || iParam3 == 12 || iParam3 == 13 || iParam3 == 14 || iParam3 == 15)
                    {
                        switch (iParam4)
                        {
                            case 0:
                                info.Coords.Z = 31.365f;
                                break;
                            case 1:
                                info.Coords.Z = 31.017f;
                                break;
                            case 2:
                                info.Coords.Z = 30.681f;
                                break;
                            case 3:
                                info.Coords.Z = 30.265f;
                                break;
                        }
                    }

                    if (info.Model == "weapon_musket")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.15f, 0f, 0f);
                    }

                    if (info.Model == "weapon_firework")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, 0.245f, 0f, 0f);
                    }

                    if (info.Model == "weapon_specialcarbine")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.05f, 0f, 0.03f);
                    }

                    if (info.Model == "weapon_bullpupshotgun")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.05f, 0f, 0f);
                    }

                    if (info.Model == "weapon_combatpdw")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, 0.05f, 0f, 0f);
                    }

                    if (info.Model == "weapon_navyrevolver")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.15f, 0f, 0f);
                    }

                    if (info.Model == "weapon_hominglauncher")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.15f, 0f, 0f);
                    }

                    if (info.Model == "weapon_heavyshotgun")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.01f, 0f, 0f);
                    }

                    float z_offset_1 = -0.05f;
                    float z_offset_2 = 0.92f;
                    float z_offset_3 = 1.94f;
                    float z_offset_4 = 2.99f;
                    float z_offset_5 = 3.7f;

                    if (iParam3 == 11)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_1, 0f, 0f);
                    }

                    if (iParam3 == 12)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_2, 0f, 0f);
                    }

                    if (iParam3 == 13)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_3, 0f, 0f);
                    }

                    if (iParam3 == 14)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_4, 0f, 0f);
                    }

                    if (iParam3 == 15)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_5, 0f, 0f);
                    }
                }
            }
            else
            {
                Var17 = new(1695.31f, 3760.17f, 34.46f);
                Var20 = new(1695.22f, 3760.29f, 34.457f);
                iVar33 = 29;
                switch (iParam3)
                {
                    case 0:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(0, "p_parachute_s_shop", 1689.082f, 3759.161f, 36.2236f, 0f, 0f, -132f, 0f, 0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 1:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_microsmg", 1688.883f, 3759.17f, 35.67f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_smg", 1688.82f, 3759.1f, 35.27f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 2:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultsmg", 1689.693f, 3760.031f, 36.398f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_pumpshotgun", 1689.51f, 3759.83f, 36.04f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 2:
                                info = new WeaponInfo(1, "weapon_assaultshotgun", 1689.612f, 3759.863f, 35.69f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 3:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultrifle", 1690.327f, 3760.753f, 36.38f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_carbinerifle", 1690.367f, 3760.793f, 36.03f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 2:
                                info = new WeaponInfo(1, "weapon_advancedrifle", 1690.379f, 3760.773f, 35.65f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 4:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_sniperrifle", 1691.02f, 3761.51f, 35.685f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                            case 1:
                                info = new WeaponInfo(1, "weapon_heavysniper", 1690.99f, 3761.47f, 35.28f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 5:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_mg", 1689.604f, 3759.869f, 35.27f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_combatmg", 1690.387f, 3760.716f, 35.28f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 6:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_rpg", 1692.32f, 3762.84f, 36.38f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_grenadelauncher", 1692.104f, 3762.608f, 36.03f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_minigun", 1692.062f, 3762.524f, 35.675f, 0f, 0f, 47.3919f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_raycarbine", 1692.995f, 3763.491f, 36.35f, 0f, 0f, 47.3919f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_rayminigun", 1692.971f, 3763.463f, 35.99f, 0f, 0f, 47.3919f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 7:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(0, "prop_w_me_knife_01", 1690.703f, 3758.437f, 34.449f, -90f, 0f, 0f, 0f, 0f, 0.475f, 35f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_nightstick", 1691.133f, 3758.507f, 34.4425f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_hammer", 1691.5f, 3758.95f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(0, "prop_w_me_bottle", 1690.903f, 3758.287f, 34.466f, -89.9657f, 42.9f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_knuckle", 1690.943f, 3758.847f, 34.415f, -182f, 96.0003f, 41f, 0f, 0f, 0.475f, 90f, 0f, 0f);
                                break;
                        }
                        break;
                    case 8:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_stungun", 1692.277f, 3760.185f, 34.4537f, -90f, -73f, 0f, 0f, 0f, 0.475f, 90f, 73f, 45f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_appistol", 1692.722f, 3760.345f, 34.447f, -90f, -73f, 0f, 0f, 0f, 0.475f, 90f, 73f, 45f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_combatpistol", 1692.542f, 3760.539f, 34.449f, -90f, -73f, 0f, 0f, 0f, 0.475f, 90f, 73f, 45f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_pistol", 1692.989f, 3760.618f, 34.4499f, -90f, -72.5f, 0f, 0f, 0f, 0.475f, 90f, 72.5f, 45f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_pistol50", (1693.159f + 0.07f), (3760.838f + 0.09f), 34.4499f, -90f, -72.5f, 0f, 0f, 0f, 0.475f, 90f, 72.5f, 45f);
                                break;
                        }
                        break;
                    case 9:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_smokegrenade", 1694.224f, 3760.886f, 34.5537f, 0f, 0f, 310f, 0f, 0f, 0.475f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_grenade", 1694.739f, 3760.423f, 34.4961f, 0f, 0f, 310f, 0f, 0f, 0.475f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_stickybomb", Var17.X, Var17.Y, Var17.Z, 0f, 0f, 90f, 0f, 0f, 0.475f, 90f, 0f, -135f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_proxmine", Var20.X, Var20.Y, Var20.Z, 0f, 0f, 90f, 0f, 0f, 0.475f, 90f, 0f, -135f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_pipebomb", 1695.15f, 3760.39f, 34.455f, 90f, -90f, 0f, 0f, 0f, 0.475f, 90f, -90f, 0f);
                                break;
                        }
                        break;
                    case 10:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_petrolcan", 1695.804f, 3759.918f, 34.5136f, -90f, 0f, 2.5f, -0.278f, -0.073f, 0.693f, 90f, 0f, -2.5f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_doubleaction", 1695.07f, 3760.02f, 34.454f, -90f, -47f, -88f, 0f, 0f, 0.475f, 90f, 47f, 45f);
                                break;
                        }
                        break;
                    case 11:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_assaultsmg", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0.3f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_bullpupshotgun", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0.3f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_gusenberg", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0.3f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_specialcarbine", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0.3f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 12:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_bullpuprifle", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_musket", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_heavyshotgun", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_marksmanrifle", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 13:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_combatpdw", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_marksmanpistol", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_railgun", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 14:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_autoshotgun", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 15:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_raypistol", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;

                    case 16:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_unarmed", 1694.045f, 3753.344f, 35.6458f, 0f, 0f, 137.392f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_unarmed", 1693.583f, 3753.768f, 35.6458f, 0f, 0f, 137.392f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_unarmed", 1693.133f, 3754.183f, 35.6458f, 0f, 0f, 137.392f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_unarmed", 1693.838f, 3753.535f, 34.8608f, 0f, 0f, 137.392f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_unarmed", 1693.345f, 3753.988f, 34.8608f, 0f, 0f, 137.392f, 0f, -0.565f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 17:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_machete", 1691.765f, 3759.2f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(0, "prop_w_me_dagger", 1690.813f, 3758.442f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_switchblade", 1690.95f, 3758.485f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_flashlight", 1691.223f, 3758.727f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(0, "prop_w_me_hatchet", 1691.323f, 3758.79f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;
                        }
                        break;
                    case 18:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_snspistol", 1692.289f, 3759.878f, 34.4499f, -90f, -72f, 0f, 0f, 0f, 0.475f, 90f, 72f, 45f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_heavypistol", 1692.489f, 3760.065f, 34.447f, -90f, -73f, 0f, 0f, 0f, 0.475f, 90f, 73f, 45f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_vintagepistol", 1693.049f, 3761.088f, 34.4537f, -90f, -72.5f, 0f, 0f, 0f, 0.475f, 90f, 72.5f, 45f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_flaregun", 1694.41f, 3760.68f, 34.4537f, -90f, -47f, -88f, 0f, 0f, 0.475f, 90f, 47f, 45f);
                                break;
                        }
                        break;
                    case 19:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_snowball", 1694.283f, 3763.622f, 37.06f, 0f, 0f, -42.608f, 0f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                    case 20:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_revolver", 1692.054f, 3759.98f, 34.4499f, -90f, -72f, 0f, 0f, 0f, 0.475f, 90f, 72f, 45f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_machinepistol", 1692.312f, 3760.233f, 34.447f, -90f, -73f, 0f, 0f, 0f, 0.475f, 90f, 73f, 45f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_compactlauncher", 1694.83f, 3760.25f, 34.454f, -90f, -47f, -88f, 0f, 0f, 0.475f, 90f, 47f, 45f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_hominglauncher", 1692.281f, 3762.843f, 35.28f, 0f, 0f, 47.3919f, 0.35f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_ceramicpistol", 1692.794f, 3760.81f, 34.4499f, -90f, -72f, 0f, 0f, 0f, 0.475f, 90f, 72f, 45f);
                                break;
                        }
                        break;
                    case 21:
                        switch (iParam4)
                        {
                            case 0:
                                info = new WeaponInfo(1, "weapon_poolcue", 1691.15f, 3759.175f, 34.449f, -89.9657f, 42.9f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 1:
                                info = new WeaponInfo(1, "weapon_battleaxe", 1691.895f, 3759.38f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 2:
                                info = new WeaponInfo(1, "weapon_wrench", 1691.645f, 3759.11f, 34.449f, -89.9657f, -2.39193f, 0f, 0f, 0f, 0.475f, 45f, 0f, 0f);
                                break;

                            case 3:
                                info = new WeaponInfo(1, "weapon_marksmanrifle", 1693.021f, 3763.663f, 35.65f, 0f, 0f, 47.3919f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;

                            case 4:
                                info = new WeaponInfo(1, "weapon_heavyshotgun", 1693.031f, 3763.693f, 35.29f, 0f, 0f, 47.3919f, -0.5f, -0.755f, 0f, 0f, 0f, 0f);
                                break;
                        }
                        break;
                }
                if (info != null)
                {
                    if (iParam3 == 11 || iParam3 == 12 || iParam3 == 13 || iParam3 == 14 || iParam3 == 15)
                    {
                        info.Coords.Z -= 0.15f;
                        switch (iParam4)
                        {
                            case 0:
                                info.Coords.Z = 36.275f;
                                break;
                            case 1:
                                info.Coords.Z = 35.929f;
                                break;
                            case 2:
                                info.Coords.Z = 35.593f;
                                break;
                            case 3:
                                info.Coords.Z = 35.177f;
                                break;
                            default:
                                break;
                        }
                    }

                    if (info.Model == "weapon_musket")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.15f, 0f, 0f);
                    }

                    if (info.Model == "weapon_firework")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, 0.245f, 0f, 0f);
                    }

                    if (info.Model == "weapon_specialcarbine")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.05f, 0f, 0.03f);
                    }

                    if (info.Model == "weapon_bullpupshotgun")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.05f, 0f, 0f);
                    }

                    if (info.Model == "weapon_combatpdw")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, 0.05f, 0f, 0f);
                    }

                    if (info.Model == "weapon_navyrevolver")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.15f, 0f, 0f);
                    }

                    if (info.Model == "weapon_hominglauncher")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, 0.4f, 0f, 0f);
                    }

                    if (info.Model == "weapon_heavyshotgun")
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.01f, 0f, 0f);
                    }

                    float z_offset_1 = -0.05f;
                    float z_offset_2 = 0.92f;
                    float z_offset_3 = 1.94f;
                    float z_offset_4 = 2.99f;
                    float z_offset_5 = 3.7f;

                    if (iParam3 == 11)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_1, 0f, 0f);
                    }

                    if (iParam3 == 12)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_2, 0f, 0f);
                    }

                    if (iParam3 == 13)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_3, 0f, 0f);
                    }

                    if (iParam3 == 14)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_4, 0f, 0f);
                    }

                    if (iParam3 == 15)
                    {
                        info.Coords = GetObjectOffsetFromCoords(info.Coords.X, info.Coords.Y, info.Coords.Z, info.Rotation.Z, -0.4f + z_offset_5, 0f, 0f);
                    }
                }
            }
            if (info != null)
            {
                func_212(iVar33, ShopId, ref info.Coords);
                func_208(iVar33, ShopId, ref info.Rotation);
            }
            return info;
        }

        private static bool HasPedMK2Variant(WeaponHash variant)
        {
            return variant switch
            {
                WeaponHash.Pistol => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.PistolMk2),
                WeaponHash.SMG => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.SMGMk2),
                WeaponHash.HeavySniper => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.HeavySniperMk2),
                WeaponHash.CombatMG => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.CombatMGMk2),
                WeaponHash.AssaultRifle => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.AssaultRifleMk2),
                WeaponHash.CarbineRifle => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.CarbineRifleMk2),
                WeaponHash.PumpShotgun => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.PumpShotgunMk2),
                WeaponHash.SpecialCarbine => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.SpecialCarbineMk2),
                WeaponHash.SNSPistol => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.SNSPistolMk2),
                WeaponHash.MarksmanRifle => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.MarksmanRifleMk2),
                WeaponHash.Revolver => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.RevolverMk2),
                WeaponHash.BullpupRifle => PlayerCache.MyClient.Ped.Weapons.HasWeapon(WeaponHash.BullpupRifleMk2),
                _ => false,
            };
        }

        static void func_208(int iParam0, int iParam1, ref Vector3 uParam2)
        {
            Vector3 uVar0 = Vector3.Zero;
            Vector3 Var3 = Vector3.Zero;
            Vector3 uVar6 = Vector3.Zero;
            Vector3 Var9 = Vector3.Zero;

            func_209(iParam0, ref uVar0, ref Var3, -1);
            func_209(iParam1, ref uVar6, ref Var9, -1);
            while (Var9.Z > 180f) Var9.Z -= 360f;
            while (Var9.Z < -180f) Var9.Z += 360f;
            while (Var3.Z > 180f) Var3.Z -= 360f;
            while (Var3.Z < -180f) Var3.Z += 360f;
            uParam2.Z += (Var9.Z - Var3.Z);
            while (uParam2.Z > 180f) uParam2.Z -= 360f;
            while (uParam2.Z < -180f) uParam2.Z += 360f;
        }
        static int func_209(int iParam0, ref Vector3 uParam1, ref Vector3 uParam2, int iParam3)
        {
            uParam1 = Vector3.Zero;
            uParam2 = Vector3.Zero;
            switch (iParam0)
            {
                case -1:
                    break;

                case 28:
                    uParam1 = new Vector3(23.6862f, -1106.461f, 29.9159f);
                    uParam2 = new Vector3(0f, 0f, 160f);
                    break;

                case 29:
                    uParam1 = new Vector3(1693.572f, 3761.601f, 34.8242f);
                    uParam2 = new Vector3(0f, 0f, -132.6081f);
                    break;

                case 30:
                    uParam1 = new Vector3(252.8583f, -51.6284f, 70.06f);
                    uParam2 = new Vector3(0f, 0f, 69.9999f);
                    break;

                case 31:
                    uParam1 = new Vector3(841.0564f, -1034.762f, 28.3137f);
                    uParam2 = new Vector3(0f, 0f, 0f);
                    break;

                case 32:
                    uParam1 = new Vector3(-330.2908f, 6085.548f, 31.5737f);
                    uParam2 = new Vector3(0f, 0f, -135.0001f);
                    break;

                case 33:
                    uParam1 = new Vector3(-660.9294f, -934.1031f, 21.9481f);
                    uParam2 = new Vector3(0f, 0f, 180f);
                    break;

                case 34:
                    uParam1 = new Vector3(-1304.976f, -395.8181f, 36.8147f);
                    uParam2 = new Vector3(0f, 0f, 75.7783f);
                    break;

                case 35:
                    uParam1 = new Vector3(-1117.612f, 2700.264f, 18.673f);
                    uParam2 = new Vector3(0f, 0f, -138.1729f);
                    break;

                case 36:
                    uParam1 = new Vector3(-3172.511f, 1089.412f, 20.9576f);
                    uParam2 = new Vector3(0f, 0f, -113.4187f);
                    break;

                case 37:
                    uParam1 = new Vector3(2566.592f, 293.1332f, 108.8538f);
                    uParam2 = new Vector3(0f, 0f, 0f);
                    break;

                case 38:
                    uParam1 = new Vector3(808.8609f, -2158.508f, 29.7379f);
                    uParam2 = new Vector3(0f, 0f, 0f);
                    break;
            }
            if (func_210(uParam1, Vector3.Zero, false) && func_210(uParam2, Vector3.Zero, false))
            {
                return 0;
            }
            return 1;
        }

        static bool func_210(Vector3 Param0, Vector3 Param3, bool bParam6)
        {
            if (bParam6)
            {
                return (Param0.X == Param3.X && Param0.Y == Param3.Y);
            }
            return ((Param0.X == Param3.X && Param0.Y == Param3.Y) && Param0.Z == Param3.Z);
        }

        static void func_212(int iParam0, int iParam1, ref Vector3 uParam2)
        {
            Vector3 Var0 = Vector3.Zero;
            Vector3 Var3 = Vector3.Zero;
            Vector3 Var6 = Vector3.Zero;
            Vector3 Var9 = Vector3.Zero;
            Vector3 Var12 = Vector3.Zero;

            if (func_210(uParam2, Vector3.Zero, false))
            {
                return;
            }
            func_209(iParam0, ref Var0, ref Var3, -1);
            func_209(iParam1, ref Var6, ref Var9, -1);
            Var12 = uParam2 - Var0;
            Var12 = func_15(Var12, -Var3.Z);
            Var12 = func_15(Var12, Var9.Z);
            uParam2 = GetObjectOffsetFromCoords(Var6.X, Var6.Y, Var6.Z, 0f, Var12.X, Var12.Y, Var12.Z);
        }

        static Vector3 func_15(Vector3 Param0, float fParam3)
        {
            float fVar3 = Sin(fParam3);
            float fVar4 = Cos(fParam3);
            return new((Param0.X * fVar4) - (Param0.Y * fVar3), (Param0.X * fVar3) + (Param0.Y * fVar4), Param0.Z);
        }

        static void func_1142(int iParam0, int iParam1, ref float uParam2)
        {
            Vector3 uVar0 = Vector3.Zero;
            Vector3 Var3 = Vector3.Zero;
            Vector3 uVar6 = Vector3.Zero;
            Vector3 Var9 = Vector3.Zero;

            func_209(iParam0, ref uVar0, ref Var3, -1);
            func_209(iParam1, ref uVar6, ref Var9, -1);
            uParam2 += (Var9.Z - Var3.Z);
        }

        static void PlaySound(int iParam0)
        {
            switch (iParam0)
            {
                case int a when a == Functions.HashInt("weapon_pistol"):
                case int b when b == Functions.HashInt("weapon_appistol"):
                case int c when c == Functions.HashInt("weapon_combatpistol"):
                case int d when d == Functions.HashInt("weapon_stungun"):
                case int e when e == Functions.HashInt("weapon_snspistol"):
                case int f when f == Functions.HashInt("weapon_heavypistol"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_HANDGUN", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_pumpshotgun"):
                case int b when b == Functions.HashInt("weapon_sawnoffshotgun"):
                case int c when c == Functions.HashInt("weapon_assaultshotgun"):
                case int d when d == Functions.HashInt("weapon_bullpupshotgun"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_SHOTGUN", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_advancedrifle"):
                case int b when b == Functions.HashInt("weapon_carbinerifle"):
                case int d when d == Functions.HashInt("weapon_specialcarbine"):
                case int e when e == Functions.HashInt("weapon_assaultrifle"):
                case int f when f == Functions.HashInt("weapon_mg"):
                case int g when g == Functions.HashInt("weapon_combatmg"):
                case int h when h == Functions.HashInt("weapon_bullpuprifle"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_RIFLE", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_grenadelauncher"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_GRENADE_LAUNCHER", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_rpg"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_RPG_LAUNCHER", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_knife"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_KNIFE", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_nightstick"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_BATON", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("gadget_parachute"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_PARACHUTE", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_petrolcan"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_FUEL_CAN", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                case int a when a == Functions.HashInt("weapon_unarmed"):
                    PlaySoundFrontend(-1, "WEAPON_SELECT_ARMOR", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;

                default:
                    PlaySoundFrontend(-1, "WEAPON_SELECT_OTHER", "HUD_AMMO_SHOP_SOUNDSET", true);
                    break;
            }
        }


        public static InteractionModel func_1141(int interaction_id)
        {
            int identifier;
            InteractionModel model = null;

            if (ShopId == 28 || ShopId == 38)
            {
                identifier = 28;
                switch (interaction_id)
                {
                    case 0:
                        model = new InteractionModel(9, "GS_BROWSE_W", 22.99f, -1104.26f, 30.31f, 19.35751f, -1106.22f, 28.60952f, 23.10207f, -1107.574f, 30.48993f, 1.9375f, 21.54607f, -1107.329f, 28.73452f, 23.31161f, -1110.421f, 30.29702f, 1.375f, 20.2672f, -1105.993f, 29.7959f, 341.6826f, 20.11896f, -1107.994f, 29.96737f, 3.655659f, 0f, 2.415002f);
                        break;
                    case 1:
                        model = new InteractionModel(12, "GS_BROWSE_A", 16.59f, -1109.52f, 30.72f, 18.24785f, -1111.273f, 28.73452f, 19.0786f, -1108.969f, 30.29702f, 1.25f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 20.2672f, -1105.993f, 29.7959f, 341.6826f, 20.11896f, -1107.994f, 29.96737f, 3.655659f, 0f, 2.415002f);
                        break;
                    case 2:
                        model = new InteractionModel(5, "", 22.1f, -1112.37f, 30.06f, 22.55885f, -1110.589f, 28.73452f, 20.68537f, -1114.135f, 30.29702f, 1.375f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 20.2672f, -1105.993f, 29.7959f, 341.6826f, 20.11896f, -1107.994f, 29.96737f, 3.655659f, 0f, 2.415002f);
                        break;
                }
            }
            else
            {
                identifier = 29;
                switch (interaction_id)
                {
                    case 0:
                        model = new InteractionModel(9, "GS_BROWSE_W", 1691.06f, 3761.59f, 35.55f, 1691.783f, 3757.687f, 33.59764f, 1694.417f, 3760.594f, 35.26825f, 1.9375f, 1693.513f, 3759.068f, 33.58032f, 1697.123f, 3759.268f, 35.22161f, 1.3125f, 1692.063f, 3758.62f, 34.7052f, 42.0427f, 1694.004f, 3757.726f, 34.87201f, 3.240859f, 0f, 74.72784f); ;
                        break;
                    case 1:
                        model = new InteractionModel(12, "GS_BROWSE_A", 1693.65f, 3753.87f, 35.63f, 1695.99f, 3754.741f, 33.64282f, 1694.252f, 3756.362f, 35.20532f, 1.25f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1692.063f, 3758.62f, 34.7052f, 42.0427f, 1694.004f, 3757.726f, 34.87201f, 3.240859f, 0f, 74.72784f);
                        break;
                    case 2:
                        model = new InteractionModel(5, "", 1699.32f, 3759.06f, 34.85f, 1697.625f, 3759.942f, 33.51783f, 1700.24f, 3757.387f, 35.70533f, 1.25f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1692.063f, 3758.62f, 34.7052f, 42.0427f, 1694.004f, 3757.726f, 34.87201f, 3.240859f, 0f, 74.72784f);
                        break;
                }
            }

            func_212(identifier, ShopId, ref model.Coords_01);
            func_212(identifier, ShopId, ref model.Coords_02);
            func_212(identifier, ShopId, ref model.Coords_03);
            func_212(identifier, ShopId, ref model.Coords_04);
            func_212(identifier, ShopId, ref model.Coords_05);
            func_212(identifier, ShopId, ref model.UnkCoords);
            func_212(identifier, ShopId, ref model.Coords_Camera);
            func_208(identifier, ShopId, ref model.Rotation_Camera);
            func_1142(identifier, ShopId, ref model.UnkHeading);

            return model;
        }


        #region camera


        static void func_938(bool interpolate, int time)
        {
            if (ShopCamera.Camera == null)
            {
                ShopCamera = func_939();
                ShopCamera.Camera = World.CreateCamera(ShopCamera.Coords, ShopCamera.Rotation, ShopCamera.FoV);
            }
            if (!ShopCamera.Camera.IsActive)
                ShopCamera.Camera.IsActive = true;
            RenderScriptCams(true, true, time, true, false);
        }

        /*
			func_1008();
			func_593();
			func_585();
			func_583();
			func_580();
			func_443();
		*/

        static WeaponShopCamera func_939()
        {
            WeaponShopCamera Var22 = new();

            Vector3 Var3 = new(-10.583f, 0f, -19.206f);
            Vector3 Var6 = new(-4.33f, -1.21f, -0.75f);
            Vector3 Var9 = PlayerCache.MyClient.Ped.Position;
            Vector3 Var12 = Var9 - GetOffsetFromEntityInWorldCoords(PlayerCache.MyClient.Ped.Handle, 0f, 0f, 1f);
            Vector3 Var15 = Var9 - GetOffsetFromEntityInWorldCoords(PlayerCache.MyClient.Ped.Handle, 1f, 0f, 0f);
            Vector3 Var18 = Var9 - GetOffsetFromEntityInWorldCoords(PlayerCache.MyClient.Ped.Handle, 0f, 1f, 0f);
            func_820(ref Var12);
            func_820(ref Var15);
            func_820(ref Var18);
            Vector3 Var0 = new(func_940(Var6, Var18), func_940(Var6, Var15), func_940(Var6, Var12));
            float fVar21 = GetEntityHeading(PlayerPedId());
            fVar21 += 180f;
            while (fVar21 > 180f)
                fVar21 -= 360f;
            Var22.Coords = Vector3.Add(Var9, Var0);
            Var22.Rotation = Var3 + new Vector3(fVar21, 0f, 0f);
            Var22.FoV = 25f;
            return Var22;
        }

        static float func_940(Vector3 Param0, Vector3 Param3) => (Param0.X * Param3.X) + (Param0.Y * Param3.Y) + (Param0.Z * Param3.Z);

        static void SetCameraOffsets(int iParam0, int CurrentWeaponSelected, int iParam3)
        {
            int iVar11;

            ShopCamera.UpdateOffsets(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0);
            if (iParam0 == 28 || iParam0 == 38)
            {
                switch (CurrentWeaponSelected)
                {
                    case 0:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 0.566872f, 0f, 2.197579f, 34.66004f, 1);
                        break;

                    case 1:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -2.634378f, 0f, 2.197579f, 34.66004f, 1);
                        break;

                    case 2:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -1.074794f, 0f, -5.846583f, 34.66004f, 1);
                        break;

                    case 3:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -16.70481f, 34.66004f, 1);
                        break;

                    case 4:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -28.87151f, 34.66004f, 1);
                        break;

                    case 5:
                        if (iParam3 == 0)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -1.074794f, 0f, -5.846583f, 34.66004f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -16.70481f, 34.66004f, 1);
                        }
                        break;

                    case 6:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -42.47814f, 34.66004f, 1);
                        break;

                    case 7:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -1.56577f, 34.66004f, 1);
                        break;

                    case 8:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -32.85397f, 34.66004f, 1);
                        break;

                    case 9:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -8.769061f, -1E-06f, -71.69663f, 34.66004f, 1);
                        break;

                    case 10:
                        if (iParam3 == 1)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -8.769061f, -1E-06f, -71.69663f, 34.66004f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -8.978215f, -1E-06f, -95.29707f, 34.66004f, 1);
                        }
                        break;

                    case 11:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 0.436189f, 0f, -64.68348f, 34.66004f, 1);
                        break;

                    case 12:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 1.380731f, 0f, -73.16987f, 34.66004f, 1);
                        break;

                    case 13:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 2.167335f, 0f, -83.37527f, 34.66004f, 1);
                        break;

                    case 14:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 2.465499f, 0f, -92.22768f, 34.66004f, 1);
                        break;

                    case 15:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, 2.465499f, 0f, -92.22768f, 34.66004f, 1);
                        break;

                    case 16:
                        ShopCamera.UpdateOffsets(19.48048f, -1109.81f, 30.57601f, -5.691335f, 0f, 87.05898f, 35.47426f, 1);
                        break;

                    case 17:
                        ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -1.56577f, 34.66004f, 1);
                        break;

                    case 18:
                        if (iParam3 == 3)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -8.769061f, -1E-06f, -71.69663f, 34.66004f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -32.85397f, 34.66004f, 1);
                        }
                        break;

                    case 20:
                        if (iParam3 == 2)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -8.769061f, -1E-06f, -71.69663f, 34.66004f, 1);
                        }
                        else if (iParam3 == 3)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -42.47814f, 34.66004f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -32.85397f, 34.66004f, 1);
                        }
                        break;

                    case 21:
                        if (iParam3 == 3 || iParam3 == 4)
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -0.828544f, 0f, -42.47814f, 34.66004f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(20.36131f, -1108.527f, 30.41068f, -4.603421f, 0f, -1.56577f, 34.66004f, 1);
                        }
                        break;
                }
            }
            else
            {
                switch (CurrentWeaponSelected)
                {
                    case 0:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, 2.523056f, 0f, 71.52591f, 34.57779f, 1);
                        break;

                    case 1:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 71.52591f, 34.57779f, 1);
                        break;

                    case 2:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 61.35044f, 34.57779f, 1);
                        break;

                    case 3:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 51.69053f, 34.57779f, 1);
                        break;

                    case 4:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 38.13562f, 34.57779f, 1);
                        break;

                    case 5:
                        if (iParam3 == 0)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 61.35044f, 34.57779f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 51.69053f, 34.57779f, 1);
                        }
                        break;

                    case 6:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 26.75984f, 34.57779f, 1);
                        break;

                    case 7:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -6.234849f, 0f, 69.07542f, 34.57779f, 1);
                        break;

                    case 8:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, 32.3488f, 34.57779f, 1);
                        break;

                    case 9:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, -7.361619f, 34.57779f, 1);
                        break;

                    case 10:
                        if (iParam3 == 1)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, -7.361619f, 34.57779f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.975378f, 0f, -27.66626f, 34.57779f, 1);
                        }
                        break;

                    case 11:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.74f, 35.33629f, 0.797561f, 0f, 1.527526f, 34.57778f, 1);
                        break;

                    case 12:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.74f, 35.33629f, 0.797561f, 0f, -5.563872f, 34.57778f, 1);
                        break;

                    case 13:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.74f, 35.33629f, 0.797561f, 0f, -17.42436f, 34.57778f, 1);
                        break;

                    case 14:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.74f, 35.33629f, 0.797561f, 0f, -25.75269f, 34.57778f, 1);
                        break;

                    case 15:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.74f, 35.33629f, 0.797561f, 0f, -25.75269f, 34.57778f, 1);
                        break;

                    case 16:
                        ShopCamera.UpdateOffsets(1695.161f, 3756.454f, 35.4219f, -4.419658f, 0f, 153.8496f, 35.08089f, 1);
                        break;

                    case 17:
                        ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -6.234849f, 0f, 69.07542f, 34.57779f, 1);
                        break;

                    case 18:
                        if (iParam3 == 3 || iParam3 == 4)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, -7.361619f, 34.57779f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, 32.3488f, 34.57779f, 1);
                        }
                        break;

                    case 20:
                        if (iParam3 == 2)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, -7.361619f, 34.57779f, 1);
                        }
                        else if (iParam3 == 3)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 26.75984f, 34.57779f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -8.694158f, 0f, 32.3488f, 34.57779f, 1);
                        }
                        break;

                    case 21:
                        if (iParam3 == 3 || iParam3 == 4)
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -0.509445f, 0f, 26.75984f, 34.57779f, 1);
                        }
                        else
                        {
                            ShopCamera.UpdateOffsets(1694.177f, 3757.739f, 35.33628f, -6.234849f, 0f, 69.07542f, 34.57779f, 1);
                        }
                        break;
                }
            }

            if (ShopId == 28 || ShopId == 38)
            {
                iVar11 = 28;
            }
            else
            {
                iVar11 = 29;
            }

            func_212(iVar11, iParam0, ref ShopCamera.Coords);
            func_208(iVar11, iParam0, ref ShopCamera.Rotation);
        }

        static void func_943()
        {
            float fVar0;
            Vector3 Var1;
            Vector3 Var4;
            Vector3 Var7;
            Vector3 Var10;
            Vector3 Var13;
            float fVar16;
            float fVar17;
            Vector3 Var18;
            float fVar21;
            float fVar22;
            fVar0 = 0.2f;

            if (Functions.HashInt(CurrentWeaponSelected.Model) != 0)
            {
                SetCameraOffsets(ShopId, CurrentWeaponIndex, 0);
                //uParam1->f_3 = index of weapon (0-21)
                //
                //func_707 / func_708
                //func_725 / func_726

                Var1 = new(0f, 0f, 0f);
                if (ShopId == 28)
                {
                    switch (CurrentWeaponSelected.Model)
                    {
                        case "weapon_pistol":
                            Var1 = new(5f, 0f, 0f);
                            break;
                        case "weapon_combatpistol":
                            Var1 = new(1.255f, 0f, 0f);
                            break;
                        case "weapon_appistol":
                            Var1 = new(0.5f, 0f, 0f);
                            break;
                        case "weapon_flare":
                            Var1 = new(0f, -1.72f, 0f);
                            break;
                        case "weapon_snspistol":
                            Var1 = new(7f, 0f, 0f);
                            break;
                        case "weapon_ceramicpistol":
                            Var1 = new(7f, 0f, 0f);
                            break;
                        case "weapon_pistol50":
                            Var1 = new(9.5f, 0f, 0f);
                            break;
                        case "weapon_vintagepistol":
                            Var1 = new(11.5f, 0f, 0f);
                            break;
                        case "weapon_bottle":
                            break;
                        case "weapon_nightstick":
                        case "weapon_machete":
                        case "weapon_hatchet":
                        case "weapon_flashlight":
                        case "weapon_hammer":
                        case "weapon_battleaxe":
                        case "weapon_wrench":
                            Var1 = new(1.955f, 0f, 0f);
                            break;
                        case "weapon_stickybomb":
                            Var1 = new(0f, -2.25f, 0f);
                            break;
                        case "weapon_proxmine":
                            Var1 = new(0f, -2.23f, 0f);
                            break;
                        case "weapon_smokegrenade":
                            Var1 = new(0f, -2f, 0f);
                            break;
                        case "weapon_doubleaction":
                            Var1 = new(0f, 2f, 0f);
                            break;
                        case "weapon_smg":
                        case "weapon_assaultshotgun":
                        case "weapon_advancedrifle":
                        case "weapon_heavysniper":
                        case "weapon_combatmg":
                            Var1 = new(0f, 0f, -0.5f);
                            break;
                        case "weapon_mg":
                        case "weapon_sniperrifle":
                            Var1 = new(0f, 0f, -0.5f);
                            break;
                        case "weapon_heavyshotgun":
                        case "weapon_marksmanrifle":
                        case "weapon_rayminigun":
                        case "weapon_raycarbine":
                            Var1 = new(5f, 0f, 0f);
                            break;
                    }
                    /*
					else if (CurrentWeaponSelected->f_24 == 7 && uParam1->f_1 == 3)
					{
						Var1 = new(0f, 0f, -1f);
					}
					else if (CurrentWeaponSelected->f_24 == 7 && uParam1->f_1 == 2)
					{
						Var1 = new(0f, 0f, -0.5f);
					}
					*/
                }
                else if (CurrentWeaponSelected.Model == "weapon_pistol")
                {
                    Var1 = new(2.575f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_combatpistol")
                {
                    Var1 = new(1f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_appistol")
                {
                    Var1 = new(0.5f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_flare")
                {
                    Var1 = new(0f, -1.72f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_snspistol")
                {
                    Var1 = new(7f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_ceramicpistol")
                {
                    Var1 = new(3f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_pistol50")
                {
                    Var1 = new(4.5f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_vintagepistol")
                {
                    Var1 = new(6f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_bottle")
                {
                }
                else if (CurrentWeaponSelected.Model == "weapon_nightstick" || CurrentWeaponSelected.Model == "weapon_machete" || CurrentWeaponSelected.Model == "weapon_hatchet" || CurrentWeaponSelected.Model == "weapon_flashlight" || CurrentWeaponSelected.Model == "weapon_hammer" || CurrentWeaponSelected.Model == "weapon_battleaxe" || CurrentWeaponSelected.Model == "weapon_wrench")
                {
                    Var1 = new(1.955f, 0f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_stickybomb")
                {
                    Var1 = new(0f, -2.25f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_proxmine")
                {
                    Var1 = new(0f, -2.23f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_smokegrenade")
                {
                    Var1 = new(0f, -2f, 0f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_doubleaction")
                {
                    Var1 = new(0f, 2f, 0f);
                }
                else if (((CurrentWeaponSelected.Model == "weapon_smg" || CurrentWeaponSelected.Model == "weapon_assaultshotgun" || CurrentWeaponSelected.Model == "weapon_advancedrifle") || CurrentWeaponSelected.Model == "weapon_heavysniper") || CurrentWeaponSelected.Model == "weapon_combatmg")
                {
                    Var1 = new(0f, 0f, -0.5f);
                }
                else if (CurrentWeaponSelected.Model == "weapon_mg" || CurrentWeaponSelected.Model == "weapon_sniperrifle")
                {
                    Var1 = new(0f, 0f, -0.5f);
                }
                else if (((CurrentWeaponSelected.Model == "weapon_heavyshotgun" || CurrentWeaponSelected.Model == "weapon_marksmanrifle") || CurrentWeaponSelected.Model == "weapon_rayminigun") || CurrentWeaponSelected.Model == "weapon_raycarbine")
                {
                    Var1 = new(5f, 0f, 0f);
                }
                /*
				else if (CurrentWeaponSelected->f_24 == 7 && uParam1->f_1 == 3)
				{
					Var1 = new(0f, 0f, -1f);
				}
				else if (CurrentWeaponSelected->f_24 == 7 && uParam1->f_1 == 2)
				{
					Var1 = new(0f, 0f, -0.5f);
				}
				*/

                Vector3 aa = CurrentWeaponSelected.OffsetCoords + Var1;
                Var4 = GetObjectOffsetFromCoords(CurrentWeaponSelected.Coords.X, CurrentWeaponSelected.Coords.Y, CurrentWeaponSelected.Coords.Z, CurrentWeaponSelected.Rotation.Z, aa.X, aa.Y, aa.Z);
                Var7 = ShopCamera.Coords;
                Var10 = Var4 - Var7;
                Var13 = GetObjectOffsetFromCoords(Var7.X, Var7.Y, Var7.Z, ShopCamera.Rotation.Z, 0f, 1f, 0f) - Var7;
                fVar16 = Atan2(Var10.Z, Vmag(Var10.X, Var10.Y, 0f));
                func_820(ref Var10);
                func_820(ref Var13);
                fVar17 = GetAngleBetween_2dVectors(Var13.X, Var13.Y, Var10.X, Var10.Y);
                Var18 = func_944(Var13, Var10);
                if (Var18.Z > 0f)
                    fVar17 = Absf(fVar17);
                else
                    fVar17 = Absf(fVar17) * -1f;
                fVar21 = (fVar16 - ShopCamera.Rotation.X) * fVar0; // rotation.X? the script doesn't mention so it should be
                fVar22 = fVar17 * fVar0;
                ShopCamera.Rotation.X += fVar21;
                ShopCamera.Rotation.Z += fVar22;
            }
        }

        static Vector3 func_944(Vector3 Param0, Vector3 Param3)
        {
            return new((Param0.Y * Param3.Z) - (Param0.Z * Param3.Y), (Param0.Z * Param3.X) - (Param0.X * Param3.Z), (Param0.X * Param3.Y) - (Param0.Y * Param3.X));
        }

        static void func_583()
        {
            float fVar0 = 0f;
            Vector3 Var1;
            Vector3 Var4;
            float fVar7;
            Vector3 Var8;
            float fVar11;
            Vector3 Var12;
            float fVar15;

            if (ShopCamera is not null && ShopCamera.Camera is not null && ShopCamera.Camera.Exists())
            {
                Var1 = GetFinalRenderedCamCoord();
                Var4 = GetFinalRenderedCamRot(2);
                fVar7 = GetFinalRenderedCamFov();
                Var8 = Var1 + InteractionModel.Coords_Camera - Var1 * new Vector3(0.2f, 0.2f, 0.2f);
                fVar11 = fVar7 + ((ShopCamera.FoV - fVar7) * 0.2f);

                /*
				Var8 =  Var1 + InteractionModel.Coords_Camera.X - Var1 * new Vector3(0.2f, 0.2f, 0.2f);
				fVar15 = (InteractionModel.Rotation_Camera.Z - Var4.Z);
				while (fVar15 < -180f)
					fVar15 += 360f;
				while (fVar15 > 180f)
					fVar15 -= 360f;
                Var12 = new(Var4.X + ((InteractionModel.Rotation_Camera.X - Var4.X) * 0.2f), Var4.Y + ((InteractionModel.Rotation_Camera.Y - Var4.Y) * 0.2f), Var4.Z + (fVar15 * 0.2f));
				*/

                fVar15 = (ShopCamera.Rotation.Z - Var4.Z);
                while (fVar15 < -180f)
                    fVar15 += 360f;
                while (fVar15 > 180f)
                    fVar15 -= 360f;
                Var12 = new((Var4.X + ((ShopCamera.Rotation.X - Var4.X) * 0.2f)), (Var4.Y + ((ShopCamera.Rotation.Y - Var4.Y) * 0.2f)), (Var4.Z + (fVar15 * 0.2f)));

                if (IsUsingKeyboard(2))
                {
                    if (Global_4534053 > (1f - 0.05f))
                    {
                        keyboardActive = true;
                        fVar15 = ((0.05f - (1f - Global_4534053)) * -30f);
                        SetMouseCursorSprite(7);
                    }
                    else if (Global_4534053 < 0.05f)
                    {
                        keyboardActive = true;
                        fVar15 = ((0.05f - Global_4534053) * 30f);
                        SetMouseCursorSprite(6);
                    }
                    else if (keyboardActive)
                    {
                        fVar15 = 0f;
                    }
                    if (Global_4534054 > (1f - 0.03f))
                    {
                        keyboardActive = true;
                        fVar0 = ((0.03f - (1f - Global_4534054)) * -30f);
                        SetMouseCursorSprite(9);
                    }
                    else if (Global_4534054 < 0.03f)
                    {
                        keyboardActive = true;
                        fVar0 = ((0.03f - Global_4534054) * 30f);
                        SetMouseCursorSprite(8);
                    }
                    else if (keyboardActive)
                    {
                        fVar0 = 0f;
                    }
                }
                else
                {
                    keyboardActive = false;
                }
                if (keyboardActive)
                {
                    Var12.X = func_584((Var4.X + fVar0), -9.2f, 12.7f);
                    Var12.Y = (Var4.Y + ((ShopCamera.Rotation.Y - Var4.Y) * 0.2f));
                    func_1183(ShopId, ref fLocal_1297, ref fLocal_1298);
                    if (fLocal_1297 < -80f)
                    {
                        Var12.Z = (Var4.Z + fVar15);
                        if (Var12.Z < 0f && Var12.Z > fLocal_1297)
                        {
                            Var12.Z = fLocal_1297;
                        }
                        else if (Var12.Z > 0f && Var12.Z < fLocal_1298)
                        {
                            Var12.Z = fLocal_1298;
                        }
                    }
                    else if (fLocal_1297 > fLocal_1298)
                    {
                        Var12.Z = func_584((Var4.Z + fVar15), fLocal_1298, fLocal_1297);
                    }
                    else
                    {
                        Var12.Z = func_584((Var4.Z + fVar15), fLocal_1297, fLocal_1298);
                    }
                }
                else
                {
                    Var12 = new(Var4.X + ((ShopCamera.Rotation.X - Var4.X) * 0.2f), Var4.Y + ((ShopCamera.Rotation.Y - Var4.Y) * 0.2f), Var4.Z + (fVar15 * 0.2f));
                }
                ShopCamera.Camera.Position = Var8;
                ShopCamera.Camera.Rotation = Var12;
                ShopCamera.Camera.FieldOfView = fVar11;
            }
        }

        static float func_584(float fParam0, float fParam1, float fParam2)
        {
            if (fParam0 > fParam2)
            {
                return fParam2;
            }
            else if (fParam0 < fParam1)
            {
                return fParam1;
            }
            return fParam0;
        }

        static void func_1183(int iParam0, ref float fParam1, ref float fParam2)
        {
            switch (iParam0)
            {
                case 35:
                    fParam1 = 68f;
                    break;

                case 28:
                    fParam1 = 4f;
                    break;

                case 31:
                    fParam1 = -154f;
                    break;

                case 36:
                    fParam1 = 93f;
                    break;

                case 33:
                    fParam1 = 26f;
                    break;

                case 34:
                    fParam1 = -79f;
                    break;

                case 32:
                    fParam1 = 71f;
                    break;

                case 29:
                    fParam1 = 74f;
                    break;

                case 30:
                    fParam1 = -85f;
                    break;

                case 37:
                    fParam1 = -155f;
                    break;

                case 38:
                    fParam1 = -155f;
                    break;

                default:
                    fParam1 = 68f;
                    break;
            }
            fParam2 = (fParam1 - 100f);
            while (fParam2 > 180f)
                fParam2 -= 360f;
            while (fParam2 < -180f)
                fParam2 += 360f;
        }
        static void func_932()
        {
            Global_4534055 = Global_4534053;
            Global_4534056 = Global_4534054;
            Global_4534053 = GetDisabledControlNormal(2, 239);
            Global_4534054 = GetDisabledControlNormal(2, 240);
            Global_4534057 = Global_4534053 - Global_4534055;
            Global_4534058 = (Global_4534054 - Global_4534056);
        }

        static void func_820(ref Vector3 Param0)
        {
            float fVar0;
            float fVar1;
            fVar0 = Vmag(Param0.X, Param0.Y, Param0.Z);
            if (fVar0 != 0f)
            {
                fVar1 = (1f / fVar0);
                Param0 *= new Vector3(fVar1);
            }
            else
            {
                Param0 = new(0f);
            }
        }
        #endregion

        static void func_590(bool bParam2, WeaponInfo iParam3, bool bParam4)
        {
            Vector3 Var0;
            Vector3 Var3;
            Vector3 Var6;
            Vector3 Var9 = Vector3.Zero;
            float uVar12 = 0;
            float uVar13 = 0;
            float iVar14 = 0;
            float iVar15 = 0;
            int iVar16;
            Vector3 Var17;
            Vector3 Var20;
            Vector3 Var23;
            Vector3 Var26;
            Vector3 Var29;

            if (DoesEntityExist(iParam3.Weapon.Handle))
            {
                Var0 = GetEntityCoords(iParam3.Weapon.Handle, true);
                if (bParam4)
                {
                    Var3 = GetObjectOffsetFromCoords(iParam3.Coords.X, iParam3.Coords.Y, iParam3.Coords.Z, iParam3.Rotation.Z, iParam3.OffsetCoords.X, iParam3.OffsetCoords.Y, iParam3.OffsetCoords.Z);
                    Var6 = Var0;
                    Var6 = Var6 + Var3 - Var0 * new Vector3(0.25f, 0.25f, 0.25f);
                    if (((Var6.X > (Var3.X - 0.01f) && Var6.X < (Var3.X + 0.01f)) && Var6.Y > (Var3.Y - 0.01f)) && Var6.Y < (Var3.Y + 0.01f))
                    {
                        if (iLocal_1091)
                        {
                            Settimerb(1);
                            iLocal_1091 = false;
                        }
                        if (iParam3.Model == "weapon_knuckle" || iParam3.Model == "weapon_switchblade")
                        {
                            Var6.Z += Sin(ToFloat((Timerb() / 8))) * 0.001f;
                        }
                        else
                        {
                            Var6.Z += Sin(ToFloat(Timerb() / 8)) * 0.003f;
                        }
                    }
                    SetEntityCoords(iParam3.Weapon.Handle, Var6.X, Var6.Y, Var6.Z, true, false, false, true);
                    if (!MenuHandler.IsAnyMenuOpen)
                    {
                        if (!IsUsingKeyboard(2))
                        {
                            func_592(ref uVar12, ref uVar13, ref iVar14, ref iVar15, false);
                            if (iLocal_1089)
                            {
                                if (((iVar15 > -64 && iVar15 < 64) && iVar14 > -64) && iVar14 < 64)
                                {
                                    iLocal_1089 = false;
                                }
                                else
                                {
                                    iVar15 = 0;
                                    iVar14 = 0;
                                }
                            }
                            if (IsLookInverted())
                            {
                                iVar15 = (iVar15 * -1);
                            }
                            if (((iVar14 < -32 || iVar14 > 32) || iVar15 < -32) || iVar15 > 32)
                            {
                                iLocal_1087 = GetTimeOffset(GetNetworkTime(), 300);
                                iLocal_1088 = true;
                            }
                            else if ((IsTimeMoreThan(GetNetworkTime(), iLocal_1087)))
                            {
                                iLocal_1088 = false;
                            }
                            if ((iVar14 < 32 && iVar14 > -32) && (iVar15 < 32 && iVar15 > -32))
                            {
                                if (iVar14 < 32 && iVar14 > -32)
                                {
                                    iVar14 = 0;
                                }
                                else if (iVar14 < 0)
                                {
                                    iVar14 = (iVar14 - 32);
                                }
                                else
                                {
                                    iVar14 += 32;
                                }
                                if (iVar15 < 32 && iVar15 > -32)
                                {
                                    iVar15 = 0;
                                }
                                else if (iVar15 < 0)
                                {
                                    iVar15 = (iVar15 - 32);
                                }
                                else
                                {
                                    iVar15 += 32;
                                }
                            }
                            if (iParam3.Model == "gadget_parachute")
                            {
                                iVar15 = (iVar15 * -1);
                            }
                            Var9 = iParam3.Rotation + iParam3.OffsetRotation;
                            if ((((ShopId != 48 && ShopId != 49) && ShopId != 52) && ShopId != 53) && ShopId != 56)
                            {
                                if (iParam3.Model == "weapon_heavysniper_mk2")
                                {
                                    Var9.X += ((iVar15) * 0.5f);
                                    Var9.Z += ((iVar14) * 0.25f);
                                }
                                else
                                {
                                    Var9.X += ((iVar15) * 0.5f);
                                    Var9.Z += ((iVar14) * 0.35f);
                                }
                            }
                            else
                            {
                                Var9.X += ((iVar15) * 0.5f);
                                Var9.Z += ((iVar14) * 0.11f);
                            }
                        }
                        /* // keyboard controls too fucked up to track atm
						else
						{
							iVar16 = 0;
							if (some_unkown_bool)
							{
								if (Global_4534059 == -1)
								{
									if (IsControlPressed(2, 237))
									{
										iVar16 = 1;
										SetMouseCursorSprite(4);
									}
									else
									{
										SetMouseCursorSprite(3);
										iVar16 = 0;
									}
								}
								else if (Global_4534059 > -1)
								{
									SetMouseCursorSprite(1);
									iVar16 = 0;
								}
								else if (Global_4534059 == -2 || Global_4534059 == -3)
								{
									SetMouseCursorSprite(1);
									iVar16 = 0;
								}
								else
								{
									SetMouseCursorSprite(2);
									iVar16 = 0;
								}
							}
							else if (iLocal_1294 == 1)
							{
								if (Global_4534059 == -1)
								{
									SetMouseCursorSprite(4);
									iVar16 = 1;
								}
							}
							if (iVar16 == 1)
							{
								Var9 = iParam3.Rotation + iParam3.OffsetRotation;
								Local_1299.X = (Local_1299.X + (Global_4534058 * 400f));
								if (Local_1299.X < -64f)
								{
									Local_1299.X = -64f;
								}
								else if (Local_1299.X > 64f)
								{
									Local_1299.X = 64f;
								}
								if (iParam3.Model == "gadget_parachute")
								{
									Local_1299.Z = (Local_1299.Z + func_584((-Global_4534057 * 400f), -32f, 32f));
								}
								else
								{
									Local_1299.Z = (Local_1299.Z + func_584((Global_4534057 * 400f), -32f, 32f));
								}
								if (Local_1299.Z < -32f)
								{
									Local_1299.Z = -32f;
								}
								else if (Local_1299.Z > 32f)
								{
									Local_1299.Z = 32f;
								}
								Var9 = Var9 + Local_1299;
							}
							else
							{
								Var9 = iParam3.Rotation + iParam3.OffsetRotation;
							}
						}
						*/
                        else // added as keyboard substitute
                        {
                            Var9 = iParam3.Rotation + iParam3.OffsetRotation;
                        }
                        Var17 = CurrentWeaponSelected.Rotation;
                        Var17 = Var17 + Var9 - CurrentWeaponSelected.Rotation * new Vector3(0.25f, 0.25f, 0.25f);
                        if (iParam3.Model == "weapon_pumpshotgun_mk2")
                        {
                            Var17.X -= 21.5f;
                            Var17.Z += 5f;
                        }
                        SetEntityRotation(iParam3.Weapon.Handle, Var17.X, Var17.Y, Var17.Z, 2, true);
                        CurrentWeaponSelected.Rotation = Var17;
                    }
                }
                if (!bParam4)
                {
                    Var20 = iParam3.Coords;
                    Var23 = Var0;
                    Var23 += Var20 - Var0 * new Vector3(0.35f, 0.35f, 0.35f);
                    SetEntityCoords(iParam3.Weapon.Handle, Var23.X, Var23.Y, Var23.Z, true, false, false, true);
                    Var26 = iParam3.Rotation;
                    Var29 = CurrentWeaponSelected.Rotation;
                    Var29 = Var29 + Var26 - CurrentWeaponSelected.Rotation * new Vector3(0.3f, 0.3f, 0.3f);
                    SetEntityRotation(iParam3.Weapon.Handle, Var29.X, Var29.Y, Var29.Z, 2, true);
                    CurrentWeaponSelected.Rotation = Var29;
                    if (func_591(Var0, Var20, 0.01f, false))
                    {
                        if (func_591(CurrentWeaponSelected.Rotation, Var26, 0.1f, false))
                        {
                            bParam2 = false;
                        }
                    }
                }
            }
        }

        static bool func_591(Vector3 Param0, Vector3 Param3, float fParam6, bool bParam7)
        {
            if (fParam6 < 0f)
            {
                fParam6 = 0f;
            }
            if (!bParam7)
            {
                if (Absf((Param0.X - Param3.X)) <= fParam6)
                {
                    if (Absf((Param0.Y - Param3.Y)) <= fParam6)
                    {
                        if (Absf((Param0.Z - Param3.Z)) <= fParam6)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (Absf((Param0.X - Param3.X)) <= fParam6)
            {
                if (Absf((Param0.Y - Param3.Y)) <= fParam6)
                {
                    return true;
                }
            }
            return false;
        }

        static void func_592(ref float uParam0, ref float uParam1, ref float uParam2, ref float uParam3, bool bParam4)
        {
            uParam0 = Floor((GetControlNormal(2, 218) * 127f));
            uParam1 = Floor((GetControlNormal(2, 219) * 127f));
            uParam2 = Floor((GetControlNormal(2, 220) * 127f));
            uParam3 = Floor((GetControlNormal(2, 221) * 127f));
            if (bParam4)
            {
                if ((float)(uParam0) == 0f && (float)(uParam1) == 0f)
                {
                    uParam0 = Floor((GetDisabledControlNormal(2, 218) * 127f));
                    uParam1 = Floor((GetDisabledControlNormal(2, 219) * 127f));
                }
                if ((float)(uParam2) == 0f && (float)(uParam3) == 0f)
                {
                    uParam2 = Floor((GetDisabledControlNormal(2, 220) * 127f));
                    uParam3 = Floor((GetDisabledControlNormal(2, 221) * 127f));
                }
            }
        }
    }

    public class WeaponInfo
    {
        public int Type;
        public string Model;
        public Vector3 Coords;
        public Vector3 Rotation;
        public Vector3 OffsetCoords;
        public Vector3 OffsetRotation;
        public Prop Weapon;
        public WeaponInfo(int type, string model, Vector3 coords, Vector3 rot, Vector3 offc, Vector3 offr)
        {
            Type = type;
            Model = model;
            Coords = coords;
            Rotation = rot;
            OffsetCoords = offc;
            OffsetRotation = offr;
        }
        public WeaponInfo(int type, string model, float coords, float coords_1, float coords_2, float rot, float rot_1, float rot_2, float offc, float offc_1, float offc_2, float offr, float offr_1, float offr_2)
        {
            Type = type;
            Model = model;
            Coords = new(coords, coords_1, coords_2);
            Rotation = new(rot, rot_1, rot_2);
            OffsetCoords = new(offc, offc_1, offc_2);
            OffsetRotation = new(offr, offr_1, offr_2);
        }
    }

    internal class ShopkeeperModel
    {
        public string Model;
        public Vector3 Coords;
        public float Heading;
        public Vector3 OffsetCoords;
        public float OffsetHeading;

        public ShopkeeperModel(string model, float coords_x, float coords_y, float coords_z, float heading, float offset_coords_x, float offset_coords_y, float offset_coords_z, float offset_heading)
        {
            Model = model;
            Coords = new Vector3(coords_x, coords_y, coords_z);
            Heading = heading;
            OffsetCoords = new Vector3(offset_coords_x, offset_coords_y, offset_coords_z);
            OffsetHeading = offset_heading;
        }
    }

    internal class InteractionModel
    {
        public int Type;
        public string Helptext;
        public Vector3 Coords_01;
        public Vector3 Coords_02;
        public Vector3 Coords_03;
        public Vector3 Coords_04;
        public Vector3 Coords_05;
        public Vector3 UnkCoords;
        public Vector3 Coords_Camera;
        public Vector3 Rotation_Camera;
        public float Heading_01;
        public float Heading_02;
        public float UnkHeading;

        public InteractionModel(int type, string helptext, float coords_01_x, float coords_01_y, float coords_01_z, float coords_02_x, float coords_02_y, float coords_02_z, float coords_03_x, float coords_03_y, float coords_03_z, float heading_01, float coords_04_x, float coords_04_y, float coords_04_z, float coords_05_x, float coords_05_y, float coords_05_z, float heading_02, float coords_unknown_x, float coords_unknown_y, float coords_unknown_z, float heading_unkown, float coords_camera_x, float coords_camera_y, float coords_camera_z, float rotation_camera_pitch, float rotation_camera_roll, float rotation_camera_yaw)
        {
            Type = type;
            Helptext = helptext;
            Coords_01 = new Vector3(coords_01_x, coords_01_y, coords_01_z);
            Coords_02 = new Vector3(coords_02_x, coords_02_y, coords_02_z);
            Coords_03 = new Vector3(coords_03_x, coords_03_y, coords_03_z);
            Coords_04 = new Vector3(coords_04_x, coords_04_y, coords_04_z);
            Coords_05 = new Vector3(coords_05_x, coords_05_y, coords_05_z);
            UnkCoords = new Vector3(coords_unknown_x, coords_unknown_y, coords_unknown_z);
            Coords_Camera = new Vector3(coords_camera_x, coords_camera_y, coords_camera_z);
            Rotation_Camera = new Vector3(rotation_camera_pitch, rotation_camera_roll, rotation_camera_yaw);
            Heading_01 = heading_01;
            Heading_02 = heading_02;
            UnkHeading = heading_unkown;
        }
    }

    public class WeaponShopCamera
    {
        public Vector3 Coords;
        public Vector3 Rotation;
        public float FoV;
        public int unknownInt;
        public Camera Camera;

        public WeaponShopCamera() { }
        public void UpdateOffsets(float coords, float coords_1, float coords_2, float rotation, float rotation_1, float rotation_2, float fov, int unkn)
        {
            Coords = new(coords, coords_1, coords_2);
            Rotation = new(rotation, rotation_1, rotation_2);
            FoV = fov;
            unknownInt = unkn;
        }

    }

}