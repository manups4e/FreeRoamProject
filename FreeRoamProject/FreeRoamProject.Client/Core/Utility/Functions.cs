using FreeRoamProject.Shared.Core.Character;
using FreeRoamProject.Shared.Core.FREEROAM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
//using FreeRoamProject.Shared.Vehicles;

namespace FreeRoamProject.Client.Core.Utility
{
    internal enum PedTypes
    {
        Player0,  // michael  
        Player1,  // franklin  
        MpPlayer, // mp character  
        Player2,  // trevor  
        CivMale,
        CivFemale,
        Cop,
        GangAlbanian,
        GangBiker,
        GangBiker2,
        GangItalian,
        GangRussian,
        GangRussian2,
        GangIrish,
        GangJamaican,
        GangAfricanAmerican,
        GangKorean,
        GangChineseJapanese,
        GangPuertorican,
        Dealer,
        Medic,
        Fireman,
        Criminal,
        Bum,
        Prostitute,
        Special,
        Mission,
        Swat,
        Animal,
        Army
    };

    internal static class Functions
    {
        private static Random random;
        static Functions()
        {
            random = new Random(DateTime.UtcNow.Millisecond);
        }
        /// <summary>
        /// Saves clientside arbitrary data
        /// </summary>
        public static void SaveKvpString(string key, string value) { SetResourceKvp(key, value); }

        /// <summary>
        /// Saves clientside arbitrary data
        /// </summary>
        private static void SaveKvp(string key, object value) { SetResourceKvp(key, value.ToJson()); }

        /// <summary>
        /// Saves clientside arbitrary data
        /// </summary>
        public static void SaveKvpInt(string key, int value) { SetResourceKvpInt(key, value); }

        /// <summary>
        /// Saves clientside arbitrary data
        /// </summary>
        public static void SaveKvpFloat(string key, float value) { SetResourceKvpFloat(key, value); }

        /// <summary>
        /// Loads arbitrary data saved clientside
        /// </summary>
        public static int LoadKvpInt(string key) { return GetResourceKvpInt(key); }

        /// <summary>
        /// Loads arbitrary data saved clientside
        /// </summary>
        public static float LoadKvpFloat(string key) { return GetResourceKvpFloat(key); }

        /// <summary>
        /// Loads arbitrary data saved clientside
        /// </summary>
        public static string LoadKvpString(string key) { return GetResourceKvpString(key); }

        /// <summary>
        /// Loads arbitrary data saved clientside
        /// </summary>
        public static T LoadKvp<T>(string key) { return GetResourceKvpString(key).FromJson<T>(); }

        public static User GetPlayerCharFromPlayerId(int id)
        {
            foreach (PlayerClient p in from p in ClientMain.Instance.Clients where GetPlayerFromServerId(p.Player.ServerId) == id select p) return p.User;
            return null;
        }

        public static User GetPlayerCharFromServerId(int id)
        {
            foreach (PlayerClient p in from p in ClientMain.Instance.Clients where p.Player.ServerId == id select p) return p.User;
            return null;
        }

        public static PlayerClient GetPlayerClientFromServerId(int id)
        {
            foreach (PlayerClient p in from p in ClientMain.Instance.Clients where p.Player.ServerId == id select p) return p;
            return null;
        }
        public static PlayerClient GetPlayerClientFromServerId(string id)
        {
            foreach (PlayerClient p in from p in ClientMain.Instance.Clients where p.Player.ServerId.ToString() == id select p) return p;
            return null;
        }

        public static User GetPlayerData(this Player player)
        {
            return player == PlayerCache.MyPlayer.Player ? PlayerCache.MyPlayer.User : GetPlayerCharFromServerId(player.ServerId);
        }

        /*
		public static void SendNuiMessage(object message)
		{
			SendNuiMessage(message.ToJson());
		}*/

        public static void ConcealPlayersNearby(Vector3 coord, float radius)
        {
            List<Player> players = GetPlayersInArea(coord, radius);
            foreach (Player pl in players)
                if (!NetworkIsPlayerConcealed(pl.Handle) && pl.Handle != PlayerCache.MyPlayer.Player.Handle)
                    NetworkConcealPlayer(pl.Handle, true, true);
        }

        public static void ConcealAllPlayers()
        {
            ClientMain.Instance.GetPlayers.ToList().ForEach(pl =>
            {
                if (!NetworkIsPlayerConcealed(pl.Handle) && pl.Handle != PlayerCache.MyPlayer.Player.Handle) NetworkConcealPlayer(pl.Handle, true, true);
            });
        }

        public static void RevealPlayersNearby(Vector3 coord, float radius)
        {
            List<Player> players = GetPlayersInArea(coord, radius);
            foreach (Player pl in players)
                if (NetworkIsPlayerConcealed(pl.Handle) && pl.Handle != PlayerCache.MyPlayer.Player.Handle)
                    NetworkConcealPlayer(pl.Handle, false, false);
        }

        public static void RevealAllPlayers()
        {
            ClientMain.Instance.GetPlayers.ToList().ForEach(pl =>
            {
                if (NetworkIsPlayerConcealed(pl.Handle) && pl.Handle != PlayerCache.MyPlayer.Player.Handle) NetworkConcealPlayer(pl.Handle, false, false);
            });
        }

        public static void UpdateFace(int Handle, Skin skin)
        {
            SetPedHeadBlendData(Handle, skin.Face.Mom, skin.Face.Dad, 0, skin.Face.Mom, skin.Face.Dad, 0, skin.Resemblance, skin.Skinmix, 0f, false);
            SetPedHeadOverlay(Handle, 0, skin.Blemishes.Style, skin.Blemishes.Opacity);
            SetPedHeadOverlay(Handle, 1, skin.FacialHair.Beard.Style, skin.FacialHair.Beard.Opacity);
            SetPedHeadOverlayColor(Handle, 1, 1, skin.FacialHair.Beard.Color[0], skin.FacialHair.Beard.Color[1]);
            SetPedHeadOverlay(Handle, 2, skin.FacialHair.Eyebrow.Style, skin.FacialHair.Eyebrow.Opacity);
            SetPedHeadOverlayColor(Handle, 2, 1, skin.FacialHair.Eyebrow.Color[0], skin.FacialHair.Eyebrow.Color[1]);
            SetPedHeadOverlay(Handle, 3, skin.Ageing.Style, skin.Ageing.Opacity);
            SetPedHeadOverlay(Handle, 4, skin.Makeup.Style, skin.Makeup.Opacity);
            SetPedHeadOverlay(Handle, 5, skin.Blusher.Style, skin.Blusher.Opacity);
            SetPedHeadOverlayColor(Handle, 5, 2, skin.Blusher.Color[0], skin.Blusher.Color[1]);
            SetPedHeadOverlay(Handle, 6, skin.Complexion.Style, skin.Complexion.Opacity);
            SetPedHeadOverlay(Handle, 7, skin.SkinDamage.Style, skin.SkinDamage.Opacity);
            SetPedHeadOverlay(Handle, 8, skin.Lipstick.Style, skin.Lipstick.Opacity);
            SetPedHeadOverlayColor(Handle, 8, 2, skin.Lipstick.Color[0], skin.Lipstick.Color[1]);
            SetPedHeadOverlay(Handle, 9, skin.Freckles.Style, skin.Freckles.Opacity);
            SetPedEyeColor(Handle, skin.Eye.Style);
            SetPedComponentVariation(Handle, 2, skin.Hair.Style, 0, 0);
            SetPedHairColor(Handle, skin.Hair.Color[0], skin.Hair.Color[1]);
            SetPedPropIndex(Handle, 2, skin.Ears.Style, skin.Ears.Color, false);
            for (int i = 0; i < skin.Face.Traits.Length; i++) SetPedFaceFeature(Handle, i, skin.Face.Traits[i]);
        }

        public static void UpdateDress(int Handle, Dressing dress)
        {
            if (dress.ComponentDrawables.Face != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Face, dress.ComponentDrawables.Face, dress.ComponentTextures.Face, 2);

            if (dress.ComponentDrawables.Mask != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Mask, dress.ComponentDrawables.Mask, dress.ComponentTextures.Mask, 2);

            if (dress.ComponentDrawables.Torso != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Torso, dress.ComponentDrawables.Torso, dress.ComponentTextures.Torso, 2);

            if (dress.ComponentDrawables.Pants != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Pants, dress.ComponentDrawables.Pants, dress.ComponentTextures.Pants, 2);

            if (dress.ComponentDrawables.Bag_Parachute != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Bag_Parachute, dress.ComponentDrawables.Bag_Parachute, dress.ComponentTextures.Bag_Parachute, 2);

            if (dress.ComponentDrawables.Shoes != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Shoes, dress.ComponentDrawables.Shoes, dress.ComponentTextures.Shoes, 2);

            if (dress.ComponentDrawables.Accessories != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Accessories, dress.ComponentDrawables.Accessories, dress.ComponentTextures.Accessories, 2);

            if (dress.ComponentDrawables.Undershirt != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Undershirt, dress.ComponentDrawables.Undershirt, dress.ComponentTextures.Undershirt, 2);

            if (dress.ComponentDrawables.Kevlar != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Kevlar, dress.ComponentDrawables.Kevlar, dress.ComponentTextures.Kevlar, 2);

            if (dress.ComponentDrawables.Badge != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Badge, dress.ComponentDrawables.Badge, dress.ComponentTextures.Badge, 2);

            if (dress.ComponentDrawables.Torso_2 != -1)
                SetPedComponentVariation(Handle, (int)DrawableIndexes.Torso_2, dress.ComponentDrawables.Torso_2, dress.ComponentTextures.Torso_2, 2);

            if (dress.PropIndices.Hats_masks == -1)
                ClearPedProp(Handle, 0);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Hats_Masks, dress.PropIndices.Hats_masks, dress.PropTextures.Hats_masks, false);
            if (dress.PropIndices.Ears == -1)
                ClearPedProp(Handle, 2);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Ears, dress.PropIndices.Ears, dress.PropTextures.Ears, false);
            if (dress.PropIndices.Glasses == -1)
                ClearPedProp(Handle, 1);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Glasses, dress.PropIndices.Glasses, dress.PropTextures.Glasses, true);
            if (dress.PropIndices.Unk_3 == -1)
                ClearPedProp(Handle, 3);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Unk_3, dress.PropIndices.Unk_3, dress.PropTextures.Unk_3, true);
            if (dress.PropIndices.Unk_4 == -1)
                ClearPedProp(Handle, 4);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Unk_4, dress.PropIndices.Unk_4, dress.PropTextures.Unk_4, true);
            if (dress.PropIndices.Unk_5 == -1)
                ClearPedProp(Handle, 5);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Unk_5, dress.PropIndices.Unk_5, dress.PropTextures.Unk_5, true);
            if (dress.PropIndices.Watches == -1)
                ClearPedProp(Handle, 6);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Watches, dress.PropIndices.Watches, dress.PropTextures.Watches, true);
            if (dress.PropIndices.Bracelets == -1)
                ClearPedProp(Handle, 7);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Bracelets, dress.PropIndices.Bracelets, dress.PropTextures.Bracelets, true);
            if (dress.PropIndices.Unk_8 == -1)
                ClearPedProp(Handle, 8);
            else
                SetPedPropIndex(Handle, (int)PropIndexes.Unk_8, dress.PropIndices.Unk_8, dress.PropTextures.Unk_8, true);
        }

        /// <summary>
        /// Gets any ped's mugshot
        /// </summary>
        /// <param name="ped"></param>
        /// <param name="transparent"></param>
        /// <returns></returns>
        public static async Task<Tuple<int, string>> GetPedMugshotAsync(Ped ped, bool transparent = false)
        {
            int mugshot = RegisterPedheadshot(ped.Handle);
            if (transparent) mugshot = RegisterPedheadshotTransparent(ped.Handle);
            while (!IsPedheadshotReady(mugshot)) await BaseScript.Delay(1);
            string txd = GetPedheadshotTxdString(mugshot);

            return new Tuple<int, string>(mugshot, txd);
        }

        public static bool IsAnyControlJustPressed() { return Enum.GetValues(typeof(Control)).Cast<Control>().ToList().Any(value => Input.IsControlJustPressed(value)); }

        public static bool IsAnyControlPressed() { return Enum.GetValues(typeof(Control)).Cast<Control>().ToList().Any(value => Input.IsControlPressed(value)); }

        public static async Task<VehProp> GetVehicleProperties(this Vehicle veh)
        {
            bool[] extras = new bool[13];
            for (int i = 0; i < 13; i++) extras[i] = veh.IsExtraOn(i);
            List<VehMod> mods = veh.Mods.GetAllMods().Select(mod => new VehMod((int)mod.ModType, mod.Index, mod.LocalizedModName, mod.LocalizedModTypeName)).ToList();
            VehProp vehi = new VehProp(veh.Model, veh.LocalizedName, veh.Mods.LicensePlate, (int)veh.Mods.LicensePlateStyle, veh.BodyHealth, veh.EngineHealth, veh.FuelLevel, veh.DirtLevel, (int)veh.Mods.PrimaryColor, (int)veh.Mods.SecondaryColor, veh.Mods.CustomPrimaryColor, veh.Mods.CustomSecondaryColor, veh.Mods.IsPrimaryColorCustom, veh.Mods.IsSecondaryColorCustom, (int)veh.Mods.PearlescentColor, (int)veh.Mods.RimColor, (int)veh.Mods.WheelType, (int)veh.Mods.WindowTint, new bool[4] { veh.Mods.HasNeonLight(VehicleNeonLight.Left), veh.Mods.HasNeonLight(VehicleNeonLight.Right), veh.Mods.HasNeonLight(VehicleNeonLight.Front), veh.Mods.HasNeonLight(VehicleNeonLight.Back) }, extras, veh.Mods.NeonLightsColor, veh.Mods.TireSmokeColor, !(GetVehicleModKit(veh.Handle) == 65535), mods, veh.Mods.Livery);
            return vehi;
        }

        public static async void SetVehicleProperties(this Vehicle veh, VehProp props)
        {
            veh.Mods.LicensePlate = props.Plate;
            if (props.ModKitInstalled) veh.Mods.InstallModKit();
            veh.Mods.LicensePlateStyle = (LicensePlateStyle)props.PlateIndex;
            veh.BodyHealth = props.BodyHealth;
            veh.EngineHealth = props.EngineHealth;
            //veh.SetVehicleFuelLevel(props.FuelLevel);
            veh.DirtLevel = props.DirtLevel;
            veh.Mods.PrimaryColor = (VehicleColor)props.PrimaryColor;
            veh.Mods.SecondaryColor = (VehicleColor)props.SecondaryColor;
            veh.Mods.CustomPrimaryColor = props.CustomPrimaryColor;
            veh.Mods.CustomSecondaryColor = props.CustomSecondaryColor;
            //veh.Mods.IsPrimaryColorCustom = props.HasCustomPrimaryColor;
            //veh.Mods.IsSecondaryColorCustom = props.HasCustomSecondaryColor;
            veh.Mods.PearlescentColor = (VehicleColor)props.PearlescentColor;
            veh.Mods.RimColor = (VehicleColor)props.WheelColor;
            veh.Mods.WheelType = (VehicleWheelType)props.Wheels;
            veh.Mods.WindowTint = (VehicleWindowTint)props.WindowTint;
            for (int i = 0; i < props.NeonEnabled.Length; i++) veh.Mods.SetNeonLightsOn((VehicleNeonLight)i, props.NeonEnabled[i]);
            for (int i = 0; i < 13; i++) veh.ToggleExtra(i, props.Extras[i]);
            veh.Mods.NeonLightsColor = props.NeonColor;
            veh.Mods.TireSmokeColor = props.TireSmokeColor;
            VehicleMod[] mods = veh.Mods.GetAllMods();
            foreach (VehMod mod in props.Mods) SetVehicleMod(veh.Handle, mod.ModIndex, mod.Value, mods.ToList().FirstOrDefault(x => (int)x.ModType == mod.ModIndex).Variation);
            veh.Mods.Livery = props.ModLivery;
        }

        // Apparently there's a built-in native for this...
        // TODO: Replace with that
        public static string GetEntityType(int entityHandle)
        {
            try
            {
                if (IsEntityAPed(entityHandle)) return "PED";
                if (IsEntityAVehicle(entityHandle)) return "VEH";
                if (IsEntityAnObject(entityHandle)) return "OBJ";
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error($"WorldProbe GetEntityType Error: {ex.Message}");
            }

            return "UNK";
        }
        public static async void Teleport(Vector3 coords)
        {
            Ped playerPed = PlayerCache.MyPlayer.Ped;
            ClearPedTasksImmediately(playerPed.Handle);
            playerPed.IsPositionFrozen = true;
            if (playerPed.IsVisible) NetworkFadeOutEntity(playerPed.Handle, true, false);
            DoScreenFadeOut(500);
            while (!IsScreenFadedOut()) await BaseScript.Delay(0);
            RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
            NewLoadSceneStart(coords.X, coords.Y, coords.Z, coords.X, coords.Y, coords.Z, 50f, 0);
            int tempTimer = GetNetworkTimeAccurate();

            // Wait for the new scene to be loaded.
            while (IsNetworkLoadingScene())
            {
                // If this takes longer than 1 second, just abort. It's not worth waiting that long.
                if (GetNetworkTimeAccurate() - tempTimer > 1000)
                {
                    ClientMain.Logger.Warning("Waiting for the scene to load is taking too long (more than 1s). Breaking from wait loop.");
                    break;
                }
                await BaseScript.Delay(0);
            }
            SetEntityCoords(playerPed.Handle, coords.X, coords.Y, coords.Z, false, false, false, false);
            tempTimer = GetNetworkTimeAccurate();
            // Wait for the collision to be loaded around the entity in this new location.
            while (!HasCollisionLoadedAroundEntity(playerPed.Handle))
            {
                // If this takes too long, then just abort, it's not worth waiting that long since we haven't found the real ground coord yet anyway.
                if (GetNetworkTimeAccurate() - tempTimer > 1000)
                {
                    ClientMain.Logger.Warning("Waiting for the collision is taking too long (more than 1s). Breaking from wait loop.");
                    break;
                }
                await BaseScript.Delay(0);
            }
            NetworkFadeInEntity(playerPed.Handle, true);
            playerPed.IsPositionFrozen = false;
            DoScreenFadeIn(500);
            SetGameplayCamRelativePitch(0.0f, 1.0f);
        }

        public static async void TeleportWithVeh(Vector3 coords)
        {
            Ped playerPed = PlayerCache.MyPlayer.Ped;
            ClearPedTasksImmediately(playerPed.Handle);
            playerPed.IsPositionFrozen = true;
            if (playerPed.IsVisible) NetworkFadeOutEntity(playerPed.Handle, true, false);
            DoScreenFadeOut(500);
            while (!IsScreenFadedOut()) await BaseScript.Delay(0);
            RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
            NewLoadSceneStart(coords.X, coords.Y, coords.Z, coords.X, coords.Y, coords.Z, 50f, 0);
            int tempTimer = GetNetworkTimeAccurate();

            // Wait for the new scene to be loaded.
            while (IsNetworkLoadingScene())
            {
                // If this takes longer than 1 second, just abort. It's not worth waiting that long.
                if (GetNetworkTimeAccurate() - tempTimer > 1000)
                {
                    ClientMain.Logger.Warning("Waiting for the scene to load is taking too long (more than 1s). Breaking from wait loop.");

                    break;
                }

                await BaseScript.Delay(0);
            }

            SetPedCoordsKeepVehicle(playerPed.Handle, coords.X, coords.Y, coords.Z);
            tempTimer = GetNetworkTimeAccurate();

            // Wait for the collision to be loaded around the entity in this new location.
            while (!HasCollisionLoadedAroundEntity(playerPed.Handle))
            {
                // If this takes too long, then just abort, it's not worth waiting that long since we haven't found the real ground coord yet anyway.
                if (GetNetworkTimeAccurate() - tempTimer > 1000)
                {
                    ClientMain.Logger.Warning("Waiting for the collision is taking too long (more than 1s). Breaking from wait loop.");

                    break;
                }

                await BaseScript.Delay(0);
            }

            NetworkFadeInEntity(playerPed.Handle, true);
            playerPed.IsPositionFrozen = false;
            DoScreenFadeIn(500);
            SetGameplayCamRelativePitch(0.0f, 1.0f);
        }

        public static void DeleteObject(int oggetto)
        {
            SetEntityAsMissionEntity(oggetto, false, true);
            DeleteObject(oggetto);
        }

        public static int GetVehicleInDirection()
        {
            int ped = PlayerCache.MyPlayer.Ped.Handle;
            Vector3 coords = PlayerCache.MyPlayer.Ped.Position;
            Vector3 inDirection = GetOffsetFromEntityInWorldCoords(ped, 0.0f, 5.0f, 0.0f);
            int rayHandle = CastRayPointToPoint(coords.X, coords.Y, coords.Z, inDirection.X, inDirection.Y, inDirection.Z, 10, ped, 0);
            bool a = false;
            Vector3 b = new Vector3();
            Vector3 c = new Vector3();
            int vehicle = 0;
            GetRaycastResult(rayHandle, ref a, ref b, ref c, ref vehicle);

            return vehicle;
        }

        #region SpawnVehicle

        #region spawnaInside


        public static async Task<Vehicle> SpawnVehicle(string modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicle(a, coords, heading);
        }

        public static async Task<Vehicle> SpawnVehicle(int modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicle(a, coords, heading);

        }

        public static async Task<Vehicle> SpawnVehicle(VehicleHash modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicle(a, coords, heading);
        }

        private static async Task<Vehicle> SpawnVehicle(Model vehicleModel, Vector3 coords, float heading)
        {
            if (vehicleModel.IsValid)
            {
                //Screen.Fading.FadeOut(250);
                //while (!Screen.Fading.IsFadedOut) await BaseScript.Delay(100);

                if (!vehicleModel.IsLoaded) await vehicleModel.Request(3000); // for when you stream resources.

                if (!IsSpawnPointClear(coords, 2f))
                    GetVehiclesInArea(coords, 2).ToList().ForEach(x => x.Delete());

                int callback =
                    await EventDispatcher.Get<int>("tlg:entity:spawnVehicle", (uint)vehicleModel.Hash, new Position(coords.X, coords.Y, -190f, heading));
                Vehicle result = (Vehicle)Entity.FromNetworkId(callback);
                while (result == null || !result.Exists()) await BaseScript.Delay(50);

                //Vehicle result = new(CreateVehicle((uint)vehicleModel.Hash, coords.X, coords.Y, coords.Z, heading, true, false));

                result.Position = coords;

                /*
                if (PlayerCache.ActualMode == ServerMode.Roleplay)
                {
                    result.NeedsToBeHotwired = false;
                    result.RadioStation = RadioStation.RadioOff;
                    result.IsEngineStarting = false;
                    result.IsEngineRunning = false;
                    result.IsDriveable = false;
                    result.PreviouslyOwnedByPlayer = true;
                }
                */
                result.IsPersistent = true;
                result.PlaceOnGround();
                TaskWarpPedIntoVehicle(PlayerCache.MyPlayer.Ped.Handle, result.Handle, -1);
                vehicleModel.MarkAsNoLongerNeeded();
                return result;
            }
            BaseScript.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO car] = ", "nome modello non corretto!" }, color = new[] { 255, 0, 0 } });
            return null;
        }
        #endregion

        #region spawnaOutside
        public static async Task<Vehicle> SpawnVehicleNoPlayerInside(int modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicleNoPlayerInside(a, coords, heading);
        }

        public static async Task<Vehicle> SpawnVehicleNoPlayerInside(string modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicleNoPlayerInside(a, coords, heading);
        }

        public static async Task<Vehicle> SpawnVehicleNoPlayerInside(VehicleHash modelName, Vector3 coords, float heading)
        {
            Model a = new Model(modelName);
            return await SpawnVehicleNoPlayerInside(a, coords, heading);
        }

        private static async Task<Vehicle> SpawnVehicleNoPlayerInside(Model vehicleModel, Vector3 coords, float heading)
        {
            if (vehicleModel.IsValid)
            {
                if (!vehicleModel.IsLoaded) await vehicleModel.Request(3000); //for when you stream resources.

                if (!IsSpawnPointClear(coords, 2f))
                    ClearArea(coords.X, coords.Y, coords.Z, 2f, true, false, false, true);

                int callback = await EventDispatcher.Get<int>("tlg:entity:spawnVehicle", (uint)vehicleModel.Hash, new Position(
                    coords.X, coords.Y, coords.Z, heading));
                Vehicle result = (Vehicle)Entity.FromNetworkId(callback);
                while (result == null || !result.Exists()) await BaseScript.Delay(50);

                result.NeedsToBeHotwired = false;
                result.RadioStation = RadioStation.RadioOff;
                result.IsEngineStarting = false;
                result.IsEngineRunning = false;
                result.IsDriveable = false;
                result.IsPersistent = true;
                result.PreviouslyOwnedByPlayer = true;

                result.PlaceOnGround();
                vehicleModel.MarkAsNoLongerNeeded();
                //var ready = await ClientMain.Instance.Eventi.Request<bool>("cullingEntity", result.NetworkId);
                return result;
            }

            BaseScript.TriggerEvent("chat:addMessage", new { args = new[] { "[COMANDO car] = ", "nome modello non corretto!" }, color = new[] { 255, 0, 0 } });

            return null;
        }
        #endregion

        #region spawnaLocal
        public static async Task<Vehicle> SpawnLocalVehicle(int vehicleModel, Vector3 coords, float heading)
        {
            Model a = new Model(vehicleModel);
            return await SpawnLocalVehicle(a, coords, heading);
        }

        public static async Task<Vehicle> SpawnLocalVehicle(string vehicleModel, Vector3 coords, float heading)
        {
            Model a = new Model(vehicleModel);
            return await SpawnLocalVehicle(a, coords, heading);
        }

        public static async Task<Vehicle> SpawnLocalVehicle(VehicleHash vehicleModel, Vector3 coords, float heading)
        {
            Model a = new Model(vehicleModel);
            return await SpawnLocalVehicle(a, coords, heading);
        }

        private static async Task<Vehicle> SpawnLocalVehicle(Model vehicleModel, Vector3 coords, float heading)
        {
            if (!vehicleModel.IsValid) return null;
            if (!vehicleModel.IsLoaded) await vehicleModel.Request(3000); // for when you stream resources.

            if (!IsSpawnPointClear(coords, 2f))
                ClearArea(coords.X, coords.Y, coords.Z, 2f, true, false, false, true);

            Vehicle vehicle = new Vehicle(CreateVehicle((uint)vehicleModel.Hash, coords.X, coords.Y, coords.Z, heading, false, false));
            while (!vehicle.Exists()) await BaseScript.Delay(0);
            vehicle.IsPersistent = true;
            vehicle.NeedsToBeHotwired = false;
            vehicle.RadioStation = RadioStation.RadioOff;
            vehicle.IsEngineRunning = true;
            vehicle.IsDriveable = true;
            vehicle.PlaceOnGround();
            vehicleModel.MarkAsNoLongerNeeded();

            //SetVehicleEngineOn(vehicle.Handle, false, true, true);
            return vehicle;

        }
        #endregion

        #endregion

        #region SpawnProps

        public static async Task<Prop> CreateProp(int modelName, Vector3 coords, Vector3 rot, bool placeOnGround = true)
        {
            Model a = new Model(modelName);
            return await CreateProp(a, coords, rot, placeOnGround);
        }

        public static async Task<Prop> CreateProp(string modelName, Vector3 coords, Vector3 rot, bool placeOnGround = true)
        {
            Model a = new Model(modelName);
            return await CreateProp(a, coords, rot, placeOnGround);
        }

        public static async Task<Prop> CreateProp(ObjectHash modelName, Vector3 coords, Vector3 rot, bool placeOnGround = true)
        {
            Model a = new Model((int)modelName);
            return await CreateProp(a, coords, rot, placeOnGround);
        }

        private static async Task<Prop> CreateProp(Model propModel, Vector3 coords, Vector3 rot, bool placeOnGround = true)
        {
            if (propModel.IsValid)
            {
                if (!propModel.IsLoaded) await propModel.Request(3000); //for when you stream resources.

                if (!IsSpawnPointClear(coords, 2f))
                    ClearArea(coords.X, coords.Y, coords.Z, 2f, true, false, false, true);

                int callback = await EventDispatcher.Get<int>("tlg:entity:spawnProp", propModel.Hash,
                    new Position(coords, rot));
                Prop result = (Prop)Entity.FromNetworkId(callback);
                while (result == null || !result.Exists()) await BaseScript.Delay(50);
                if (placeOnGround) PlaceObjectOnGroundProperly(result.Handle);
                result.IsPersistent = true;
                propModel.MarkAsNoLongerNeeded();
                return result;
            }
            return null;
        }


        public static async Task<Prop> SpawnLocalProp(int modelName, Vector3 coords, bool dynamic, bool placeOnGround)
        {
            Model model = new(modelName);

            if (!await model.Request(1000)) return null;
            Prop p = new(CreateObject(model.Hash, coords.X, coords.Y, coords.Z, false, false, dynamic));
            if (placeOnGround) PlaceObjectOnGroundProperly(p.Handle);
            model.MarkAsNoLongerNeeded();
            return p;
        }

        #endregion

        /// <summary>
        /// Spawns a <see cref="Ped"/> of the given <see cref="Model"/> at the position and heading specified.
        /// </summary>
        /// <param name="model">The <see cref="Model"/> of the <see cref="Ped"/>.</param>
        /// <param name="position">The position to spawn the <see cref="Ped"/> at.</param>
        /// <param name="heading">The heading of the <see cref="Ped"/>.</param>
        /// <remarks>returns <c>null</c> if the <see cref="Ped"/> could not be spawned</remarks>
        public static async Task<Ped> CreatePedLocally(dynamic model, Vector3 position, float heading = 0f, PedTypes PedType = PedTypes.Mission)
        {
            Model mod = new(model);

            if (!mod.IsPed || !await mod.Request(3000)) return null;
            Ped p = new(CreatePed((int)PedType, (uint)mod.Hash, position.X, position.Y, position.Z, heading, false, false));
            while (!p.Exists()) await BaseScript.Delay(0);

            return p;
        }

        #region SpawnPed

        /// <summary>
        /// Spawns a <see cref="Ped"/> of the given <see cref="Model"/> at the position and heading specified.
        /// </summary>
        /// <param name="model">The <see cref="Model"/> of the <see cref="Ped"/>.</param>
        /// <param name="position">The position to spawn the <see cref="Ped"/> at.</param>
        /// <param name="heading">The heading of the <see cref="Ped"/>.</param>
        /// <param name="pedType"></param>
        /// <remarks>returns <c>null</c> if the <see cref="Ped"/> could not be spawned</remarks>
        public static async Task<Ped> SpawnPed(int model, Position position, PedTypes pedType = PedTypes.Mission)
        {
            Model a = new Model(model);
            return await SpawnPed(a, position, pedType);

        }

        public static async Task<Ped> SpawnPed(string model, Position position, PedTypes pedType = PedTypes.Mission)
        {
            Model a = new Model(model);
            return await SpawnPed(a, position, pedType);

        }

        public static async Task<Ped> SpawnPed(PedHash model, Position position, PedTypes pedType = PedTypes.Mission)
        {
            Model a = new Model(model);
            return await SpawnPed(a, position, pedType);
        }

        private static async Task<Ped> SpawnPed(Model pedModel, Position position, PedTypes pedType = PedTypes.Mission)
        {
            if (pedModel.IsValid)
            {
                if (!pedModel.IsLoaded) await pedModel.Request(3000); // for when you stream resources.

                if (!IsSpawnPedPointClear(position.ToVector3, 2f))
                    ClearArea(position.ToVector3.X, position.ToVector3.Y, position.ToVector3.Z, 2f, true, false, false, true);
            }

            int callback = await EventDispatcher.Get<int>("tlg:entity:spawnPed", (uint)pedModel.Hash, position, (int)pedType);

            Ped ped = (Ped)Entity.FromNetworkId(callback);
            while (!ped.Exists()) await BaseScript.Delay(50);
            ped.IsPersistent = true;
            return ped;
        }

        /// <summary>
        /// Spawns a <see cref="Ped"/> of a random <see cref="Model"/> at the position specified.
        /// </summary>
        /// <param name="position">The position to spawn the <see cref="Ped"/> at.</param>
        public static async Task<Ped> SpawnRandomPed(Vector3 position)
        {
            Ped ped = new Ped(CreateRandomPed(position.X, position.Y, position.Z));
            while (!ped.Exists()) await BaseScript.Delay(0);
            return ped;
        }
        #endregion

        /// <summary>
        /// Activates the wait for the player to enter text
        /// </summary>
        /// <param name="windowTitle">Window title</param>
        /// <param name="defaultText">Default test if there is one</param>
        /// <param name="maxLength">Length of the input</param>
        /// <returns></returns>
        public static async Task<string> GetUserInput(string windowTitle, string defaultText, int maxLength)
        {
            ClearKeyboard(windowTitle, defaultText, maxLength);
            while (UpdateOnscreenKeyboard() == 0)
            {
                Game.DisableAllControlsThisFrame(0);
                Game.DisableAllControlsThisFrame(1);
                Game.DisableAllControlsThisFrame(2);
                Game.EnableControlThisFrame(0, Control.FrontendCancel);
                Game.EnableControlThisFrame(1, Control.FrontendCancel);
                Game.EnableControlThisFrame(2, Control.FrontendCancel);
                Game.EnableControlThisFrame(0, Control.FrontendAccept);
                Game.EnableControlThisFrame(1, Control.FrontendAccept);
                Game.EnableControlThisFrame(2, Control.FrontendAccept);
                await BaseScript.Delay(0);
            }
            return UpdateOnscreenKeyboard() == 2 ? "" : GetOnscreenKeyboardResult();
        }

        private static void ClearKeyboard(string windowTitle, string defaultText, int maxLength)
        {
            AddTextEntry("FMlprp_KEY_TIP1", windowTitle);
            DisplayOnscreenKeyboard(1, "FMlprp_KEY_TIP1", null, defaultText, null, null, null, maxLength + 1);
        }

        public async static Task FadeEntityAsync(this Entity entity, bool fadeIn, bool fadeOutNormal = false, bool slow = true)
        {
            if (fadeIn)
                Function.Call(Hash.NETWORK_FADE_IN_ENTITY, entity.Handle, fadeOutNormal, slow);
            else
                NetworkFadeOutEntity(entity.Handle, fadeOutNormal, slow);

            while (NetworkIsEntityFading(entity.Handle)) await BaseScript.Delay(0);
        }

        public static void FadeEntity(this Entity entity, bool fadeIn, bool fadeOutNormal = false, bool slow = true)
        {
            if (fadeIn)
                Function.Call(Hash.NETWORK_FADE_IN_ENTITY, entity.Handle, fadeOutNormal, slow);
            else
                NetworkFadeOutEntity(entity.Handle, fadeOutNormal, slow);
        }
        public static void RespawnPed(Position coords)
        {
            Cache.PlayerCache.MyPlayer.Ped.Position = coords.ToVector3;
            NetworkResurrectLocalPlayer(coords.X, coords.Y, coords.Z, coords.Heading, true, false);
            Cache.PlayerCache.MyPlayer.Ped.Health = 100;
            Cache.PlayerCache.MyPlayer.Ped.IsInvincible = false;
            Cache.PlayerCache.MyPlayer.Ped.ClearBloodDamage();
        }

        public static void spectatePlayer(int targetPed, int targetId, string name, bool enableSpectate)
        {
            int mio = PlayerPedId();
            enableSpectate = true;

            if (targetId == mio)
            {
                enableSpectate = false;
                Notifications.ShowNotification("~r~Cannot spectate yourself!!");
            }

            if (enableSpectate)
            {
                Vector3 coords = GetEntityCoords(PlayerPedId(), true);
                RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
                NetworkSetInSpectatorMode(true, targetPed);
            }
            else
            {
                Vector3 coords = GetEntityCoords(PlayerPedId(), true);
                RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);
                NetworkSetInSpectatorMode(false, targetPed);
            }
        }

        /// <summary>
        /// Returns all players in that area
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static List<Player> GetPlayersInArea(Vector3 coords, float area, bool ignoreCallerPlayer = true)
        {
            List<Player> playersInArea = ignoreCallerPlayer ? ClientMain.Instance.GetPlayers.ToList().FindAll(p => Vector3.Distance(p.Character.Position, coords) < area && p != PlayerCache.MyPlayer.Player) : ClientMain.Instance.GetPlayers.ToList().FindAll(p => Vector3.Distance(p.Character.Position, coords) < area);

            return playersInArea;
        }

        /// <summary>
        /// Returns all peds in that area
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static List<Ped> GetPlayersPedsInArea(Vector3 coords, float area)
        {
            return ClientMain.Instance.GetPlayers.ToList().Select(p => p.Character).Where(target => target.IsInRangeOf(coords, area)).ToList();
        }

        #region Closest Methods

        #region Vehicles

        public static Vehicle GetClosestVehicle(this Entity entity) { return World.GetClosest(entity.Position, World.GetAllVehicles()); }

        public static Vehicle GetClosestVehicle(this Entity entity, string model) { return GetClosestVehicle(entity, new Model(model)); }

        public static Vehicle GetClosestVehicle(this Entity entity, Model model)
        {
            if (model.IsValid && model.IsVehicle) return World.GetClosest(entity.Position, World.GetAllVehicles().Where(x => x.Model.Hash == model.Hash).ToArray());

            return null;
        }

        public static Vehicle GetClosestVehicle(this Entity entity, VehicleHash hash) { return World.GetClosest(entity.Position, World.GetAllVehicles().Where(x => x.Model.Hash == (int)hash).ToArray()); }

        public static Vehicle GetClosestVehicle(this Entity entity, List<VehicleHash> hashes) { return World.GetClosest(entity.Position, World.GetAllVehicles().Where(x => hashes.Contains((VehicleHash)x.Model.Hash)).ToArray()); }

        public static Vehicle GetClosestVehicle(this Entity entity, List<string> models)
        {
            List<int> hashes = models.ConvertAll(x => GetHashKey(x));

            return World.GetClosest(entity.Position, World.GetAllVehicles().Where(x => hashes.Contains(x.Model.Hash)).ToArray());
        }

        public static Vehicle GetClosestVehicle(this Entity entity, List<Model> models) { return World.GetClosest(entity.Position, World.GetAllVehicles().Where(x => models.Contains(x.Model)).ToArray()); }

        public static Tuple<Vehicle, float> GetClosestVehicleWithDistance(this Ped entity)
        {
            Vehicle veh = World.GetClosest(entity.Position, World.GetAllVehicles());
            float dist = Vector3.Distance(entity.Position, veh.Position);

            return new Tuple<Vehicle, float>(veh, dist);
        }

        #endregion

        #region Peds

        public static Ped GetClosestPed(this Entity entity) { return World.GetClosest(entity.Position, World.GetAllPeds()); }

        public static Ped GetClosestPed(this Entity entity, string model) { return GetClosestPed(entity, new Model(model)); }

        public static Ped GetClosestPed(this Entity entity, Model model)
        {
            if (model.IsValid && model.IsPed) return World.GetClosest(entity.Position, World.GetAllPeds().Where(x => x.Model.Hash == model.Hash).ToArray());

            return null;
        }

        public static Ped GetClosestPed(this Entity entity, PedHash hash) { return World.GetClosest(entity.Position, World.GetAllPeds().Where(x => (PedHash)x.Model.Hash == hash).ToArray()); }

        public static Ped GetClosestPed(this Entity entity, List<PedHash> hashes) { return World.GetClosest(entity.Position, World.GetAllPeds().Where(x => hashes.Contains((PedHash)x.Model.Hash)).ToArray()); }

        public static Ped GetClosestPed(this Entity entity, List<string> models)
        {
            List<int> hashes = models.ConvertAll(x => GetHashKey(x));

            return World.GetClosest(entity.Position, World.GetAllPeds().Where(x => hashes.Contains(x.Model.Hash)).ToArray());
        }

        public static Ped GetClosestPed(this Entity entity, List<Model> models) { return World.GetClosest(entity.Position, World.GetAllPeds().Where(x => models.Contains(x.Model)).ToArray()); }

        public static Tuple<Ped, float> GetClosestPedWithDistance(this Ped entity)
        {
            Ped ped = World.GetClosest(entity.Position, World.GetAllPeds());
            float dist = Vector3.Distance(entity.Position, ped.Position);

            return new Tuple<Ped, float>(ped, dist);
        }

        #endregion

        #region Props

        public static Prop GetClosestProp(this Entity entity) { return World.GetClosest(entity.Position, World.GetAllProps()); }

        public static Prop GetClosestProp(this Entity entity, Entity ignored) { return World.GetClosest(entity.Position, World.GetAllProps().Where(x => x.Handle != ignored.Handle).ToArray()); }
        public static Prop GetClosestProp(this Entity entity, List<Entity> ignored) { return World.GetClosest(entity.Position, World.GetAllProps().Where(x => ignored.All(y => x.Handle != y.Handle)).ToArray()); }

        public static Prop GetClosestProp(this Entity entity, string model) { return GetClosestProp(entity, new Model(model)); }

        public static Prop GetClosestProp(this Entity entity, Model model)
        {
            if (model.IsValid && model.IsProp) return World.GetClosest(entity.Position, World.GetAllProps().Where(x => x.Model.Hash == model.Hash).ToArray());

            return null;
        }

        public static Prop GetClosestProp(this Entity entity, ObjectHash hash) { return World.GetClosest(entity.Position, World.GetAllProps().Where(x => (ObjectHash)x.Model.Hash == hash).ToArray()); }

        public static Prop GetClosestProp(this Entity entity, List<ObjectHash> hashes) { return World.GetClosest(entity.Position, World.GetAllProps().Where(x => hashes.Contains((ObjectHash)x.Model.Hash)).ToArray()); }

        public static Prop GetClosestProp(this Entity entity, List<string> models)
        {
            List<int> hashes = models.ConvertAll(x => GetHashKey(x));

            return World.GetClosest(entity.Position, World.GetAllProps().Where(x => hashes.Contains(x.Model.Hash)).ToArray());
        }

        public static Prop GetClosestProp(this Entity entity, List<Model> models) { return World.GetClosest(entity.Position, World.GetAllProps().Where(x => models.Contains(x.Model)).ToArray()); }

        public static Tuple<Prop, float> GetClosestPropWithDistance(this Prop entity)
        {
            Prop ped = World.GetClosest(entity.Position, World.GetAllProps());
            float dist = Vector3.Distance(entity.Position, ped.Position);

            return new Tuple<Prop, float>(ped, dist);
        }

        #endregion

        #endregion

        public static float Rad2deg(float rad) => rad * (180.0f / (float)Math.PI);
        public static float Deg2rad(float deg) => deg * ((float)Math.PI / 180.0f);
        public static float Convert180to360(float deg) => (deg + 450) % 360;
        public static float Normalize(float value, float min, float max) => (value - min) / (max - min);
        public static float Denormalize(float normalized, float min, float max) => (normalized * (max - min) + min);

        public static Player GetPlayerFromPed(Ped ped)
        {
            return ClientMain.Instance.GetPlayers.ToList().FirstOrDefault(pl => pl.Character.NetworkId == ped.NetworkId);
        }

        /// <summary>
        /// Gets closest player to yourself
        /// </summary>
        public static Tuple<Player, float> GetClosestPlayer() { return GetClosestPlayer(PlayerCache.MyPlayer.Position.ToVector3); }

        /// <summary>
        /// Gets closest player to coordinates
        /// </summary>
        /// <param name="coords"></param>
        public static Tuple<Player, float> GetClosestPlayer(Vector3 coords)
        {
            if (ClientMain.Instance.GetPlayers.ToList().Count <= 1) return new Tuple<Player, float>(null, -1);
            Player closestPlayer = ClientMain.Instance.GetPlayers.ToList().OrderBy(x => Vector3.Distance(x.Character.Position, coords)).FirstOrDefault(x => x != PlayerCache.MyPlayer.Player);

            return new Tuple<Player, float>(closestPlayer, Vector3.Distance(coords, closestPlayer.Character.Position));
        }

        /// <summary>
        /// GetHashKey uint
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static uint HashUint(string str) { return (uint)Game.GenerateHash(str); }

        /// <summary>
        /// GetHashKey int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int HashInt(string str) { return Game.GenerateHash(str); }

        /// <summary>
        /// Si connette al server e ritorna tutti i personaggi online e i loro dati
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, User>> GetOnlinePlayersAndTheirData()
        {
            return await EventDispatcher.Get<Dictionary<string, User>>("tlg:callPlayers");
        }

        /// <summary>
        /// Si connette al server e al DB e ritorna tutti i personaggi salvati nel db stesso
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, User>> GetAllPlayersAndTheirData()
        {
            return await EventDispatcher.Get<Dictionary<string, User>>("tlg:callDBPlayers");
        }

        public static bool IsSpawnPointClear(this Vector3 pos, float Radius)
        {
            Vehicle[] vehs = GetVehiclesInArea(pos, Radius);
            return vehs.Length < 1 ? true : false;
        }

        public static bool IsSpawnObjPointClear(this Vector3 pos, float Radius)
        {
            Prop[] vehs = GetPropsInArea(pos, Radius);
            return vehs.Length < 1 ? true : false;
        }

        public static bool IsSpawnPedPointClear(this Vector3 pos, float Radius)
        {
            Ped[] vehs = GetPedsInArea(pos, Radius);
            return vehs.Length < 1;
        }

        public static Vehicle[] GetVehiclesInArea(this Vector3 Coords, float Radius) => World.GetAllVehicles().Where(x => x.IsInRangeOf(Coords, Radius)).ToArray();

        public static Prop[] GetPropsInArea(this Vector3 Coords, float Radius) => World.GetAllProps().Where(x => x.IsInRangeOf(Coords, Radius)).ToArray();

        public static Ped[] GetPedsInArea(this Vector3 Coords, float Radius) => World.GetAllPeds().Where(x => x.IsInRangeOf(Coords, Radius)).ToArray();

        private static Vector3 PolarSphereToWorld3D(Vector3 center, float radius, float polarAngleDeg, float azimuthAngleDeg)
        {
            double polarAngleRad = polarAngleDeg * (Math.PI / 180.0f);
            double azimuthAngleRad = azimuthAngleDeg * (Math.PI / 180.0f);
            return new Vector3(
                center.X + radius * ((float)Math.Sin(azimuthAngleRad) * (float)Math.Cos(polarAngleRad)),
                center.Y - radius * ((float)Math.Sin(azimuthAngleRad) * (float)Math.Sin(polarAngleRad)),
                center.Z - radius * (float)Math.Cos(azimuthAngleRad));
        }

        public static PointF WorldToScreen(Vector3 position)
        {
            float screenX = 0, screenY = 0;
            return !World3dToScreen2d(position.X, position.Y, position.Z, ref screenX, ref screenY) ? PointF.Empty : new(screenX, screenY);
        }

        public static PointF WorldToScreenShifted(Vector3 position)
        {
            float screenX = 0, screenY = 0;
            return !World3dToScreen2d(position.X, position.Y, position.Z, ref screenX, ref screenY)
                ? PointF.Empty
                : (new((screenX - 0.5f) * 2, (screenY - 0.5f) * 2));
        }
        private static Vector3 RotationToDirection(Vector3 rotation)
        {
            float z = Deg2rad(rotation.Z);
            float x = Deg2rad(rotation.X);
            float num = (float)Math.Abs(Math.Cos(x));
            return new((float)-Math.Sin(z) * num, (float)Math.Cos(z) * num, (float)Math.Sin(x));
        }

        private static PointF processCoordinates(PointF coords)
        {
            int screenX = 0, screenY = 0;
            GetActiveScreenResolution(ref screenX, ref screenY);
            float relativeX = 1 - (coords.X / screenX) * 1.0f * 2;
            float relativeY = 1 - (coords.Y / screenY) * 1.0f * 2;
            if (relativeX > 0.0f)
                relativeX = -relativeX;
            else
                relativeX = Math.Abs(relativeX);

            if (relativeY > 0.0f)
                relativeY = -relativeY;
            else
                relativeY = Math.Abs(relativeY);

            return new(relativeX, relativeY);
        }


        private static Vector3 s2w(Vector3 camPos, float relX, float relY)
        {
            Vector3 camRot = GetGameplayCamRot(0);
            Vector3 camForward = RotationToDirection(camRot);
            Vector3 rotUp = Vector3.Add(camRot, new Vector3(10f, 0, 0));
            Vector3 rotDown = Vector3.Add(camRot, new Vector3(-10f, 0, 0));
            Vector3 rotLeft = Vector3.Add(camRot, new Vector3(0f, 0, -10f));
            Vector3 rotRight = Vector3.Add(camRot, new Vector3(0f, 0, 10f));

            Vector3 camRight = Vector3.Subtract(RotationToDirection(rotRight), RotationToDirection(rotLeft));
            Vector3 camUp = Vector3.Subtract(RotationToDirection(rotUp), RotationToDirection(rotDown));


            float rollRad = -Deg2rad(camRot.Y);
            Vector3 camRightRoll = Vector3.Subtract(Vector3.Multiply(camRight, (float)Math.Cos(rollRad)), Vector3.Multiply(camUp, (float)Math.Sin(rollRad)));
            Vector3 camUpRoll = Vector3.Add(Vector3.Multiply(camRight, (float)Math.Sin(rollRad)), Vector3.Multiply(camUp, (float)Math.Cos(rollRad)));

            Vector3 point3D = Vector3.Add(Vector3.Add(Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f)), camRightRoll), camUpRoll);
            PointF point2D = WorldToScreenShifted(point3D);

            if (point2D == PointF.Empty)
                return Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f));

            Vector3 point3DZero = Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f));
            PointF point2DZero = WorldToScreenShifted(point3DZero);

            if (point2DZero == PointF.Empty)
                return Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f));

            double eps = 0.001;

            if (Math.Abs(point2D.X - point2DZero.X) < eps || Math.Abs(point2D.Y - point2DZero.Y) < eps)
                return Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f));

            float scaleX = (relX - point2DZero.X) / (point2D.X - point2DZero.X);
            float scaleY = (relY - point2DZero.Y) / (point2D.Y - point2DZero.Y);
            Vector3 point3Dret = Vector3.Add(Vector3.Add(Vector3.Add(camPos, Vector3.Multiply(camForward, 10.0f)), Vector3.Multiply(camRightRoll, scaleX)), Vector3.Multiply(camUpRoll, scaleY));
            return point3Dret;
        }

        public static RaycastResult ScreenToWorld(IntersectOptions flags, Entity ignore)
        {
            // provare sennò usare funzione simile a NativeUI (MouseInBounds) per avere la posizione del cursore
            Vector3 pos = GetPauseMenuCursorPosition();
            float absoluteX = Math.Abs(pos.X);
            float absoluteY = Math.Abs(pos.Y);

            Vector3 camPos = GetGameplayCamCoord();
            PointF processedCoords = processCoordinates(new(absoluteX, absoluteY));
            Vector3 target = s2w(camPos, absoluteX, absoluteY);

            Vector3 dir = Vector3.Subtract(target, camPos);
            Vector3 from = Vector3.Add(camPos, Vector3.Multiply(dir, 0.05f));
            Vector3 to = Vector3.Add(camPos, Vector3.Multiply(dir, 300f));

            return World.Raycast(from, to, flags, ignore);
        }

        public static void StartScenario(this Ped ped, string scenario) { TaskStartScenarioInPlace(ped.Handle, scenario, 0, true); }

        public static string GetWeaponLabel(WeaponHash hash)
        {
            return GetWeaponLabel((uint)hash);
        }

        public static string GetWeaponLabel(uint hash)
        {
            if (hash == HashUint("WEAPON_COUGAR")) return Game.GetGXTEntry("WT_RAGE");
            else if (hash == HashUint("WEAPON_KNIFE")) return Game.GetGXTEntry("WT_KNIFE");
            else if (hash == HashUint("WEAPON_NIGHTSTICK")) return Game.GetGXTEntry("WT_NGTSTK");
            else if (hash == HashUint("WEAPON_HAMMER")) return Game.GetGXTEntry("WT_HAMMER");
            else if (hash == HashUint("WEAPON_BAT")) return Game.GetGXTEntry("WT_BAT");
            else if (hash == HashUint("WEAPON_GOLFCLUB")) return Game.GetGXTEntry("WT_GOLFCLUB");
            else if (hash == HashUint("WEAPON_CROWBAR")) return Game.GetGXTEntry("WT_CROWBAR");
            else if (hash == HashUint("WEAPON_PISTOL")) return Game.GetGXTEntry("WT_PIST");
            else if (hash == HashUint("WEAPON_COMBATPISTOL")) return Game.GetGXTEntry("WT_PIST_CBT");
            else if (hash == HashUint("WEAPON_APPISTOL")) return Game.GetGXTEntry("WT_PIST_AP");
            else if (hash == HashUint("WEAPON_PISTOL50")) return Game.GetGXTEntry("WT_PIST_50");
            else if (hash == HashUint("WEAPON_MICROSMG")) return Game.GetGXTEntry("WT_SMG_MCR");
            else if (hash == HashUint("WEAPON_SMG")) return Game.GetGXTEntry("WT_SMG");
            else if (hash == HashUint("WEAPON_ASSAULTSMG")) return Game.GetGXTEntry("WT_SMG_ASL");
            else if (hash == HashUint("WEAPON_ASSAULTRIFLE")) return Game.GetGXTEntry("WT_RIFLE_ASL");
            else if (hash == HashUint("WEAPON_CARBINERIFLE")) return Game.GetGXTEntry("WT_RIFLE_CBN");
            else if (hash == HashUint("WEAPON_ADVANCEDRIFLE")) return Game.GetGXTEntry("WT_RIFLE_ADV");
            else if (hash == HashUint("WEAPON_MG")) return Game.GetGXTEntry("WT_MG");
            else if (hash == HashUint("WEAPON_COMBATMG")) return Game.GetGXTEntry("WT_MG_CBT");
            else if (hash == HashUint("WEAPON_PUMPSHOTGUN")) return Game.GetGXTEntry("WT_SG_PMP");
            else if (hash == HashUint("WEAPON_SAWNOFFSHOTGUN")) return Game.GetGXTEntry("WT_SG_SOF");
            else if (hash == HashUint("WEAPON_ASSAULTSHOTGUN")) return Game.GetGXTEntry("WT_SG_ASL");
            else if (hash == HashUint("WEAPON_BULLPUPSHOTGUN")) return Game.GetGXTEntry("WT_SG_BLP");
            else if (hash == HashUint("WEAPON_STUNGUN")) return Game.GetGXTEntry("WT_STUN");
            else if (hash == HashUint("WEAPON_SNIPERRIFLE")) return Game.GetGXTEntry("WT_SNIP_RIF");
            else if (hash == HashUint("WEAPON_HEAVYSNIPER")) return Game.GetGXTEntry("WT_SNIP_HVY");
            else if (hash == HashUint("WEAPON_REMOTESNIPER")) return Game.GetGXTEntry("WT_SNIP_RMT");
            else if (hash == HashUint("WEAPON_GRENADELAUNCHER")) return Game.GetGXTEntry("WT_GL");
            else if (hash == HashUint("WEAPON_GRENADELAUNCHER_SMOKE")) return Game.GetGXTEntry("WT_GL_SMOKE");
            else if (hash == HashUint("WEAPON_RPG")) return Game.GetGXTEntry("WT_RPG");
            else if (hash == HashUint("WEAPON_STINGER")) return Game.GetGXTEntry("WT_RPG");
            else if (hash == HashUint("WEAPON_MINIGUN")) return Game.GetGXTEntry("WT_MINIGUN");
            else if (hash == HashUint("WEAPON_GRENADE")) return Game.GetGXTEntry("WT_GNADE");
            else if (hash == HashUint("WEAPON_STICKYBOMB")) return Game.GetGXTEntry("WT_GNADE_STK");
            else if (hash == HashUint("WEAPON_SMOKEGRENADE")) return Game.GetGXTEntry("WT_GNADE_SMK");
            else if (hash == HashUint("WEAPON_BZGAS")) return Game.GetGXTEntry("WT_BZGAS");
            else if (hash == HashUint("WEAPON_MOLOTOV")) return Game.GetGXTEntry("WT_MOLOTOV");
            else if (hash == HashUint("WEAPON_FIREEXTINGUISHER")) return Game.GetGXTEntry("WT_FIRE");
            else if (hash == HashUint("WEAPON_PETROLCAN")) return Game.GetGXTEntry("WT_PETROL");
            else if (hash == HashUint("WEAPON_DIGISCANNER")) return Game.GetGXTEntry("WT_DIGI");
            else if (hash == HashUint("GADGET_NIGHTVISION")) return Game.GetGXTEntry("WT_NV");
            else if (hash == HashUint("OBJECT")) return Game.GetGXTEntry("WT_OBJECT");
            else if (hash == HashUint("WEAPON_BALL")) return Game.GetGXTEntry("WT_BALL");
            else if (hash == HashUint("WEAPON_FLARE")) return Game.GetGXTEntry("WT_FLARE");
            else if (hash == HashUint("WEAPON_ELECTRIC_FENCE")) return Game.GetGXTEntry("WT_ELCFEN");
            else if (hash == HashUint("VEHICLE_WEAPON_TANK")) return Game.GetGXTEntry("WT_V_TANK");
            else if (hash == HashUint("VEHICLE_WEAPON_SPACE_ROCKET")) return Game.GetGXTEntry("WT_V_SPACERKT");
            else if (hash == HashUint("VEHICLE_WEAPON_PLAYER_LASER")) return Game.GetGXTEntry("WT_V_PLRLSR");
            else if (hash == HashUint("AMMO_RPG")) return Game.GetGXTEntry("WT_A_RPG");
            else if (hash == HashUint("AMMO_TANK")) return Game.GetGXTEntry("WT_A_TANK");
            else if (hash == HashUint("AMMO_SPACE_ROCKET")) return Game.GetGXTEntry("WT_A_SPACERKT");
            else if (hash == HashUint("AMMO_PLAYER_LASER")) return Game.GetGXTEntry("WT_A_PLRLSR");
            else if (hash == HashUint("AMMO_ENEMY_LASER")) return Game.GetGXTEntry("WT_A_ENMYLSR");
            else if (hash == HashUint("WEAPON_RAMMED_BY_CAR")) return Game.GetGXTEntry("WT_PIST");
            else if (hash == HashUint("WEAPON_BOTTLE")) return Game.GetGXTEntry("WT_BOTTLE");
            else if (hash == HashUint("WEAPON_GUSENBERG")) return Game.GetGXTEntry("WT_GUSENBERG");
            else if (hash == HashUint("WEAPON_SNSPISTOL")) return Game.GetGXTEntry("WT_SNSPISTOL");
            else if (hash == HashUint("WEAPON_VINTAGEPISTOL")) return Game.GetGXTEntry("WT_VPISTOL");
            else if (hash == HashUint("WEAPON_DAGGER")) return Game.GetGXTEntry("WT_DAGGER");
            else if (hash == HashUint("WEAPON_FLAREGUN")) return Game.GetGXTEntry("WT_FLAREGUN");
            else if (hash == HashUint("WEAPON_HEAVYPISTOL")) return Game.GetGXTEntry("WT_HEAVYPSTL");
            else if (hash == HashUint("WEAPON_SPECIALCARBINE")) return Game.GetGXTEntry("WT_RIFLE_SCBN");
            else if (hash == HashUint("WEAPON_MUSKET")) return Game.GetGXTEntry("WT_MUSKET");
            else if (hash == HashUint("WEAPON_FIREWORK")) return Game.GetGXTEntry("WT_FWRKLNCHR");
            else if (hash == HashUint("WEAPON_MARKSMANRIFLE")) return Game.GetGXTEntry("WT_MKRIFLE");
            else if (hash == HashUint("WEAPON_HEAVYSHOTGUN")) return Game.GetGXTEntry("WT_HVYSHOT");
            else if (hash == HashUint("WEAPON_PROXMINE")) return Game.GetGXTEntry("WT_PRXMINE");
            else if (hash == HashUint("WEAPON_HOMINGLAUNCHER")) return Game.GetGXTEntry("WT_HOMLNCH");
            else if (hash == HashUint("WEAPON_HATCHET")) return Game.GetGXTEntry("WT_HATCHET");
            else if (hash == HashUint("WEAPON_COMBATPDW")) return Game.GetGXTEntry("WT_COMBATPDW");
            else if (hash == HashUint("WEAPON_KNUCKLE")) return Game.GetGXTEntry("WT_KNUCKLE");
            else if (hash == HashUint("WEAPON_MARKSMANPISTOL")) return Game.GetGXTEntry("WT_MKPISTOL");
            else if (hash == HashUint("WEAPON_MACHETE")) return Game.GetGXTEntry("WT_MACHETE");
            else if (hash == HashUint("WEAPON_MACHINEPISTOL")) return Game.GetGXTEntry("WT_MCHPIST");
            else if (hash == HashUint("WEAPON_FLASHLIGHT")) return Game.GetGXTEntry("WT_FLASHLIGHT");
            else if (hash == HashUint("WEAPON_DBSHOTGUN")) return Game.GetGXTEntry("WT_DBSHGN");
            else if (hash == HashUint("WEAPON_COMPACTRIFLE")) return Game.GetGXTEntry("WT_CMPRIFLE");
            else if (hash == HashUint("WEAPON_SWITCHBLADE")) return Game.GetGXTEntry("WT_SWBLADE");
            else if (hash == HashUint("WEAPON_REVOLVER")) return Game.GetGXTEntry("WT_REVOLVER");
            else if (hash == HashUint("WEAPON_SNSPISTOL_MK2")) return Game.GetGXTEntry("WT_SNSPISTOL2");
            else if (hash == HashUint("WEAPON_REVOLVER_MK2")) return Game.GetGXTEntry("WT_REVOLVER2");
            else if (hash == HashUint("WEAPON_DOUBLEACTION")) return Game.GetGXTEntry("WT_REV_DA");
            else if (hash == HashUint("WEAPON_SPECIALCARBINE_MK2")) return Game.GetGXTEntry("WT_SPCARBINE2");
            else if (hash == HashUint("WEAPON_BULLPUPRIFLE_MK2")) return Game.GetGXTEntry("WT_BULLRIFLE2");
            else if (hash == HashUint("WEAPON_PUMPSHOTGUN_MK2")) return Game.GetGXTEntry("WT_SG_PMP2");
            else if (hash == HashUint("WEAPON_MARKSMANRIFLE_MK2")) return Game.GetGXTEntry("WT_MKRIFLE2");
            else if (hash == HashUint("WEAPON_POOLCUE")) return Game.GetGXTEntry("WT_POOLCUE");
            else if (hash == HashUint("WEAPON_WRENCH")) return Game.GetGXTEntry("WT_WRENCH");
            else if (hash == HashUint("WEAPON_BATTLEAXE")) return Game.GetGXTEntry("WT_BATTLEAXE");
            else if (hash == HashUint("WEAPON_MINISMG")) return Game.GetGXTEntry("WT_MINISMG");
            else if (hash == HashUint("WEAPON_BULLPUPRIFLE")) return Game.GetGXTEntry("WT_BULLRIFLE");
            else if (hash == HashUint("WEAPON_AUTOSHOTGUN")) return Game.GetGXTEntry("WT_AUTOSHGN");
            else if (hash == HashUint("WEAPON_RAILGUN")) return Game.GetGXTEntry("WT_RAILGUN");
            else if (hash == HashUint("WEAPON_COMPACTLAUNCHER")) return Game.GetGXTEntry("WT_CMPGL");
            else if (hash == HashUint("WEAPON_SNOWBALL")) return Game.GetGXTEntry("WT_SNWBALL");
            else if (hash == HashUint("WEAPON_PIPEBOMB")) return Game.GetGXTEntry("WT_PIPEBOMB");
            else if (hash == HashUint("GADGET_NIGHTVISION")) return Game.GetGXTEntry("WT_NV");
            else if (hash == HashUint("GADGET_PARACHUTE")) return Game.GetGXTEntry("WT_PARA");
            else if (hash == HashUint("WEAPON_STONE_HATCHET")) return Game.GetGXTEntry("WT_SHATCHET");
            else if (hash == HashUint("COMPONENT_AT_PI_FLSH")) return Game.GetGXTEntry("WCT_FLASH");
            else if (hash == HashUint("COMPONENT_PISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_PISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_PI_SUPP_02")) return Game.GetGXTEntry("WCT_SUPP");
            else if (hash == HashUint("COMPONENT_PISTOL_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_COMBATPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_COMBATPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_PI_SUPP")) return Game.GetGXTEntry("WCT_SUPP");
            else if (hash == HashUint("COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_APPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_APPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_APPISTOL_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_PISTOL50_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_PISTOL50_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_AR_SUPP_02")) return Game.GetGXTEntry("WCT_SUPP");
            else if (hash == HashUint("COMPONENT_PISTOL50_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_SNSPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_SNSPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_SNSPISTOL_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_HEAVYPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_HEAVYPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_HEAVYPISTOL_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_VINTAGEPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_VINTAGEPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_MICROSMG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_MICROSMG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_MACRO")) return Game.GetGXTEntry("WCT_SCOPE_MAC");
            else if (hash == HashUint("COMPONENT_MICROSMG_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_SMG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_SMG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_SMG_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_MACRO_02")) return Game.GetGXTEntry("WCT_SCOPE_MAC");
            else if (hash == HashUint("COMPONENT_SMG_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_ASSAULTSMG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_ASSAULTSMG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_MINISMG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_MINISMG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_MACHINEPISTOL_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_MACHINEPISTOL_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_MACHINEPISTOL_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_COMBATPDW_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_COMBATPDW_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_COMBATPDW_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_AT_AR_AFGRIP")) return Game.GetGXTEntry("WCT_GRIP");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_SMALL")) return Game.GetGXTEntry("WCT_SCOPE_SML");
            else if (hash == HashUint("COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_SAWNOFfsHOTGUN_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_ASSAULTSHOTGUN_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_ASSAULTSHOTGUN_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_ASSAULTRIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_ASSAULTRIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_ASSAULTRIFLE_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_ASSAULTRIFLE_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_CARBINERIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_CARBINERIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_CARBINERIFLE_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_MEDIUM")) return Game.GetGXTEntry("WCT_SCOPE_MED");
            else if (hash == HashUint("COMPONENT_CARBINERIFLE_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_ADVANCEDRIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_ADVANCEDRIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_SPECIALCARBINE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_SPECIALCARBINE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_SPECIALCARBINE_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_BULLPUPRIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_BULLPUPRIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_BULLPUPRIFLE_VARMOD_LOW")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_COMPACTRIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_COMPACTRIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_COMPACTRIFLE_CLIP_03")) return Game.GetGXTEntry("WCT_CLIP_DRM");
            else if (hash == HashUint("COMPONENT_MG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_MG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_MG_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_COMBATMG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_COMBATMG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_COMBATMG_VARMOD_LOWRIDER")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_GUSENBERG_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_GUSENBERG_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_LARGE")) return Game.GetGXTEntry("WCT_SCOPE_LRG");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_MAX")) return Game.GetGXTEntry("WCT_SCOPE_MAX");
            else if (hash == HashUint("COMPONENT_SNIPERRIFLE_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("COMPONENT_MARKSMANRIFLE_CLIP_01")) return Game.GetGXTEntry("WCT_CLIP1");
            else if (hash == HashUint("COMPONENT_MARKSMANRIFLE_CLIP_02")) return Game.GetGXTEntry("WCT_CLIP2");
            else if (hash == HashUint("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM")) return Game.GetGXTEntry("WCT_SCOPE_LRG");
            else if (hash == HashUint("COMPONENT_MARKSMANRIFLE_VARMOD_LUXE")) return Game.GetGXTEntry("WCT_VAR_GOLD");
            else if (hash == HashUint("WM_TINT0")) return Game.GetGXTEntry("WM_TINT0");
            else if (hash == HashUint("WM_TINT1")) return Game.GetGXTEntry("WM_TINT1");
            else if (hash == HashUint("WM_TINT2")) return Game.GetGXTEntry("WM_TINT2");
            else if (hash == HashUint("WM_TINT3")) return Game.GetGXTEntry("WM_TINT3");
            else if (hash == HashUint("WM_TINT4")) return Game.GetGXTEntry("WM_TINT4");
            else if (hash == HashUint("WM_TINT5")) return Game.GetGXTEntry("WM_TINT5");
            else if (hash == HashUint("WM_TINT6")) return Game.GetGXTEntry("WM_TINT6");
            else if (hash == HashUint("WM_TINT7")) return Game.GetGXTEntry("WM_TINT7");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_BASE")) return Game.GetGXTEntry("WCT_KNUCK_01");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_PIMP")) return Game.GetGXTEntry("WCT_KNUCK_02");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_BALLAS")) return Game.GetGXTEntry("WCT_KNUCK_BG");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_DOLLAR")) return Game.GetGXTEntry("WCT_KNUCK_DLR");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_DIAMOND")) return Game.GetGXTEntry("WCT_KNUCK_DMD");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_HATE")) return Game.GetGXTEntry("WCT_KNUCK_HT");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_LOVE")) return Game.GetGXTEntry("WCD_VAR_DESC");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_PLAYER")) return Game.GetGXTEntry("WCT_KNUCK_PC");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_PLAYER")) return Game.GetGXTEntry("WCT_KNUCK_PC");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_KING")) return Game.GetGXTEntry("WCT_KNUCK_SLG");
            else if (hash == HashUint("COMPONENT_KNUCKLE_VARMOD_VAGOS")) return Game.GetGXTEntry("WCT_KNUCK_VG");
            else if (hash == HashUint("COMPONENT_SWITCHBLADE_VARMOD_BASE")) return Game.GetGXTEntry("WCT_SB_BASE");
            else if (hash == HashUint("COMPONENT_SWITCHBLADE_VARMOD_VAR1")) return Game.GetGXTEntry("WCT_SB_VAR1");
            else if (hash == HashUint("COMPONENT_SWITCHBLADE_VARMOD_VAR2")) return Game.GetGXTEntry("WCT_SB_VAR2");

            else if (hash == HashUint("WEAPON_ANIMAL") || hash == HashUint("WEAPON_PASSENGER_ROCKET") || hash == HashUint("WEAPON_AIRSTRIKE_ROCKET") || hash == HashUint("WEAPON_BRIEFCASE") || hash == HashUint("WEAPON_BRIEFCASE_02") || hash == HashUint("WEAPON_FIRE") || hash == HashUint("WEAPON_HELI_CRASH") || hash == HashUint("WEAPON_RUN_OVER_BY_CAR") || hash == HashUint("WEAPON_HIT_BY_WATER_CANNON") || hash == HashUint("WEAPON_EXHAUSTION") || hash == HashUint("WEAPON_FALL") || hash == HashUint("WEAPON_EXPLOSION") || hash == HashUint("WEAPON_BLEEDING") || hash == HashUint("WEAPON_DROWNING_IN_VEHICLE") || hash == HashUint("WEAPON_DROWNING") || hash == HashUint("WEAPON_BARBED_WIRE") || hash == HashUint("WEAPON_VEHICLE_ROCKET"))
            {
                ClientMain.Logger.Error("Error retreiving hash /" + hash.ToString() + "/ for weapon/component. Maybe it was never added?");

                return Game.GetGXTEntry("WT_INVALID");
            }
            else
            {
                ClientMain.Logger.Error("Error retreiving hash /" + hash.ToString() + "/ for weapon/component. Maybe it was never added?");
                return Game.GetGXTEntry("WT_INVALID");
            }
        }

        public static string GetVehColorLabel(int color)
        {
            switch (color)
            {
                case 0:
                    return Game.GetGXTEntry("BLACK");
                case 1:
                    return Game.GetGXTEntry("GRAPHITE");
                case 2:
                    return Game.GetGXTEntry("BLACK_STEEL");
                case 3:
                    return Game.GetGXTEntry("DARK_SILVER");
                case 4:
                    return Game.GetGXTEntry("SILVER");
                case 5:
                    return Game.GetGXTEntry("BLUE_SILVER");
                case 6:
                    return Game.GetGXTEntry("ROLLED_STEEL");
                case 7:
                    return Game.GetGXTEntry("SHADOW_SILVER");
                case 8:
                    return Game.GetGXTEntry("STONE_SILVER");
                case 9:
                    return Game.GetGXTEntry("MIDNIGHT_SILVER");
                case 10:
                    return Game.GetGXTEntry("CAST_IRON_SIL");
                case 11:
                    return Game.GetGXTEntry("ANTHR_BLACK");
                case 12:
                    return Game.GetGXTEntry("BLACK");
                case 13:
                    return Game.GetGXTEntry("GREY");
                case 14:
                    return Game.GetGXTEntry("LIGHT_GREY");
                case 15:
                    return Game.GetGXTEntry("BLACK");
                case 16:
                    return Game.GetGXTEntry("FMMC_COL1_1");
                case 27:
                    return Game.GetGXTEntry("RED");
                case 28:
                    return Game.GetGXTEntry("TORINO_RED");
                case 29:
                    return Game.GetGXTEntry("FORMULA_RED");
                case 30:
                    return Game.GetGXTEntry("BLAZE_RED");
                case 31:
                    return Game.GetGXTEntry("GRACE_RED");
                case 32:
                    return Game.GetGXTEntry("GARNET_RED");
                case 33:
                    return Game.GetGXTEntry("SUNSET_RED");
                case 34:
                    return Game.GetGXTEntry("CABERNET_RED");
                case 35:
                    return Game.GetGXTEntry("CANDY_RED");
                case 36:
                    return Game.GetGXTEntry("SUNRISE_ORANGE");
                case 37:
                    return Game.GetGXTEntry("GOLD");
                case 38:
                    return Game.GetGXTEntry("ORANGE");
                case 39:
                    return Game.GetGXTEntry("RED");
                case 40:
                    return Game.GetGXTEntry("DARK_RED");
                case 41:
                    return Game.GetGXTEntry("ORANGE");
                case 42:
                    return Game.GetGXTEntry("YELLOW");
                case 49:
                    return Game.GetGXTEntry("DARK_GREEN");
                case 50:
                    return Game.GetGXTEntry("RACING_GREEN");
                case 51:
                    return Game.GetGXTEntry("SEA_GREEN");
                case 52:
                    return Game.GetGXTEntry("OLIVE_GREEN");
                case 53:
                    return Game.GetGXTEntry("BRIGHT_GREEN");
                case 54:
                    return Game.GetGXTEntry("PETROL_GREEN");
                case 55:
                    return Game.GetGXTEntry("LIME_GREEN");
                case 61:
                    return Game.GetGXTEntry("GALAXY_BLUE");
                case 62:
                    return Game.GetGXTEntry("DARK_BLUE");
                case 63:
                    return Game.GetGXTEntry("SAXON_BLUE");
                case 64:
                    return Game.GetGXTEntry("BLUE");
                case 65:
                    return Game.GetGXTEntry("MARINER_BLUE");
                case 66:
                    return Game.GetGXTEntry("HARBOR_BLUE");
                case 67:
                    return Game.GetGXTEntry("DIAMOND_BLUE");
                case 68:
                    return Game.GetGXTEntry("SURF_BLUE");
                case 69:
                    return Game.GetGXTEntry("NAUTICAL_BLUE");
                case 70:
                    return Game.GetGXTEntry("ULTRA_BLUE");
                case 71:
                    return Game.GetGXTEntry("PURPLE");
                case 72:
                    return Game.GetGXTEntry("SPIN_PURPLE");
                case 73:
                    return Game.GetGXTEntry("RACING_BLUE");
                case 74:
                    return Game.GetGXTEntry("LIGHT_BLUE");
                case 82:
                    return Game.GetGXTEntry("DARK_BLUE");
                case 83:
                    return Game.GetGXTEntry("BLUE");
                case 84:
                    return Game.GetGXTEntry("MIDNIGHT_BLUE");
                case 88:
                    return Game.GetGXTEntry("YELLOW");
                case 89:
                    return Game.GetGXTEntry("RACE_YELLOW");
                case 90:
                    return Game.GetGXTEntry("BRONZE");
                case 91:
                    return Game.GetGXTEntry("FLUR_YELLOW");
                case 92:
                    return Game.GetGXTEntry("LIME_GREEN");
                case 94:
                    return Game.GetGXTEntry("UMBER_BROWN");
                case 95:
                    return Game.GetGXTEntry("CREEK_BROWN");
                case 96:
                    return Game.GetGXTEntry("CHOCOLATE_BROWN");
                case 97:
                    return Game.GetGXTEntry("MAPLE_BROWN");
                case 98:
                    return Game.GetGXTEntry("SADDLE_BROWN");
                case 99:
                    return Game.GetGXTEntry("STRAW_BROWN");
                case 100:
                    return Game.GetGXTEntry("MOSS_BROWN");
                case 101:
                    return Game.GetGXTEntry("BISON_BROWN");
                case 102:
                    return Game.GetGXTEntry("WOODBEECH_BROWN");
                case 103:
                    return Game.GetGXTEntry("BEECHWOOD_BROWN");
                case 104:
                    return Game.GetGXTEntry("SIENNA_BROWN");
                case 105:
                    return Game.GetGXTEntry("SANDY_BROWN");
                case 106:
                    return Game.GetGXTEntry("BLEECHED_BROWN");
                case 107:
                    return Game.GetGXTEntry("CREAM");
                case 111:
                    return Game.GetGXTEntry("WHITE");
                case 112:
                    return Game.GetGXTEntry("FROST_WHITE");
                case 117:
                    return Game.GetGXTEntry("BR_STEEL");
                case 118:
                    return Game.GetGXTEntry("BR BLACK_STEEL");
                case 119:
                    return Game.GetGXTEntry("BR_ALUMINIUM");
                case 120:
                    return Game.GetGXTEntry("CHROME");
                case 128:
                    return Game.GetGXTEntry("GREEN");
                case 131:
                    return Game.GetGXTEntry("WHITE");
                case 135:
                    return Game.GetGXTEntry("HOT PINK");
                case 136:
                    return Game.GetGXTEntry("SALMON_PINK");
                case 137:
                    return Game.GetGXTEntry("PINK");
                case 138:
                    return Game.GetGXTEntry("BRIGHT_ORANGE");
                case 141:
                    return Game.GetGXTEntry("MIDNIGHT_BLUE");
                case 143:
                    return Game.GetGXTEntry("WINE_RED");
                case 145:
                    return Game.GetGXTEntry("BRIGHT_PURPLE");
                case 146:
                    return Game.GetGXTEntry("MIGHT_PURPLE");
                case 147:
                    return Game.GetGXTEntry("BLACK_GRAPHITE");
                case 148:
                    return Game.GetGXTEntry("Purple");
                case 149:
                    return Game.GetGXTEntry("MIGHT_PURPLE");
                case 150:
                    return Game.GetGXTEntry("LAVA_RED");
                case 151:
                    return Game.GetGXTEntry("MATTE_FOR");
                case 152:
                    return Game.GetGXTEntry("MATTE_OD");
                case 153:
                    return Game.GetGXTEntry("MATTE_DIRT");
                case 154:
                    return Game.GetGXTEntry("MATTE_DESERT");
                case 155:
                    return Game.GetGXTEntry("MATTE_FOIL");
                case 158:
                    return Game.GetGXTEntry("GOLD_P");
                case 159:
                    return Game.GetGXTEntry("GOLD_S");
                default:
                    return "Color name not found";
            }
        }

        public static string GetSourceOfDeath(uint hash) { return DeathReasons.DeathReasonsDict[hash]; }
    }
}