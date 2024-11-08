﻿using FreeRoamProject.Client.Handlers;
using System;

namespace FreeRoamProject.Client.Core.Utility
{
    internal static class Events
    {
        private static int timer = 0;

        public static void Init()
        {
            timer = GetNetworkTime();
            EventDispatcher.Mount("tlg:teleportCoords", new Action<Position>(teleportCoords));
            //EventDispatcher.Mount("tlg:onPlayerDeath", new Action<dynamic>(onPlayerDeath));
            EventDispatcher.Mount("tlg:sendUserInfo", new Action<string, string>(sendUserInfo));
            EventDispatcher.Mount("tlg:ObjectDeleteGun", new Action<string>(DelGun));
            EventDispatcher.Mount("tlg:ShowNotification", new Action<string>(notification));
            EventDispatcher.Mount("tlg:death", new Action(death));
            EventDispatcher.Mount("tlg:announce", new Action<string>(announce));
            EventDispatcher.Mount("tlg:reviveChar", new Action(Revive));
            EventDispatcher.Mount("tlg:spawnVehicle", new Action<string>(SpawnVehicle));
            EventDispatcher.Mount("tlg:deleteVehicle", new Action(DeleteVehicle));
            EventDispatcher.Mount("tlg:showSaving", new Action(Save));
            EventDispatcher.Mount("tlg:PlayerLeft", new Action<string, string>(PlayerLeft));
            EventDispatcher.Mount("tlg:removeWeaponComponent", new Action<string, string>(RemoveWeaponComponent));
            EventDispatcher.Mount("tlg:removeWeapon", new Action<string>(RemoveWeapon));
            EventDispatcher.Mount("tlg:addWeapon", new Action<string, int>(AddWeapon));
            EventDispatcher.Mount("tlg:addWeaponComponent", new Action<string, string>(AddWeaponComponent));
            EventDispatcher.Mount("tlg:addWeaponTint", new Action<string, int>(AddWeaponTint));
            ClientMain.Instance.StateBagsHandler.OnPlayerStateBagChange += OnSpawn;
        }

        private static void OnSpawn(int userId, string type, bool value)
        {
            // TODO: MOVE THIS TO WHEN THE PLAYER IS DONE WITH THE SWITCH CAMERA ANIMATION.
            if (type == "Spawned")
            {
                if (value)
                {
                    if (userId == PlayerCache.MyClient.Handle) return;
                    BeginTextCommandThefeedPost("TICK_JOIN");
                    AddTextComponentSubstringPlayerName("<C>" + GetPlayerName(GetPlayerFromServerId(userId)) + "</C>~s~");
                    EndTextCommandThefeedPostTicker(false, true);
                }
            }
        }

        public static void PlayerLeft(string name, string reason)
        {
            // TODO: HANDLE BUCKETS FOR MISSIONS/RACES/EVENTS 
            if (name == null) return;
            //TODO: shownotification with additional text, to be added as a separate function?
            if (reason == "kick")
                BeginTextCommandThefeedPost("TICK_LEFTKICK");
            else if (reason == "cheater")
                BeginTextCommandThefeedPost("TICK_LEFTCHEAT");
            else
                BeginTextCommandThefeedPost("TICK_LEFT");
            AddTextComponentSubstringPlayerName("<C>" + name + "</C>~s~");
            EndTextCommandThefeedPostTicker(false, true);
        }

        public static async void teleportCoords(Position pos)
        {
            Screen.Fading.FadeOut(500);
            await BaseScript.Delay(1000);
            StartPlayerTeleport(PlayerId(), pos.X, pos.Y, pos.Z, pos.Heading, true, true, true);
            while (!HasPlayerTeleportFinished(PlayerId())) await BaseScript.Delay(0);
            Screen.Fading.FadeIn(500);
            //Funzioni.Teleport(pos);
        }

        public static void sendUserInfo(string _char_data, string _group)
        {
            //PlayerCache.MyPlayer.User.char_data = _char_data;
            PlayerCache.MyClient.User.group = _group;
        }

        public static bool On = false;

        public static void DelGun(string toggle)
        {
            switch (toggle)
            {
                case "on" when !On:
                    ScaleformUI.Notifications.ShowNotification("DelGun enabled!", NotificationColor.GreenLight);
                    On = true;
                    break;
                case "on" when On:
                    ScaleformUI.Notifications.ShowNotification("~y~DelGun already enabled!", NotificationColor.Yellow);
                    break;
                case "off" when On:
                    ScaleformUI.Notifications.ShowNotification("~b~DelGun disabled!", NotificationColor.GreenLight);
                    On = false;
                    break;
                case "off" when !On:
                    ScaleformUI.Notifications.ShowNotification("~y~DelGun already disabled!", NotificationColor.Yellow);
                    break;
            }
        }

        public static void notification(string text)
        {
            ScaleformUI.Notifications.ShowNotification(text);
        }

        public static void advancedNotification(string title, string subject, string msg, string icon, NotificationType iconType)
        {
            ScaleformUI.Notifications.ShowAdvancedNotification(title, subject, msg, icon, type: iconType);
        }

        public static void death()
        {
            PlayerCache.MyClient.Ped.Kill();
        }

        public static async void announce(string msg)
        {
            Game.PlaySound("DELETE", "HUD_DEATHMATCH_SOUNDSET");
            ScaleformUI.Main.BigMessageInstance.ShowSimpleShard("~r~ANNOUNCE TO ALL PLAYERS", msg);
        }

        public static async void Revive()
        {
            Screen.Fading.FadeOut(800);
            while (Screen.Fading.IsFadingOut) await BaseScript.Delay(50);
            // TODO: PLAYER MUST BE REVIVED NEAR THEIR CURRENT POSITION
            Functions.RespawnPed(PlayerCache.MyClient.Position);
            //BaseScript.TriggerServerEvent("tlg:updateCurChar", "needs", nee.ToJson());
            //BaseScript.TriggerServerEvent("tlg:setDeathStatus", false);
            Screen.Effects.Stop(ScreenEffect.DeathFailOut);
            Screen.Fading.FadeIn(800);
        }

        public static async void SpawnVehicle(string model)
        {
            Vector3 coords = PlayerCache.MyClient.Position.ToVector3;
            Vehicle Veh = await Functions.SpawnVehicle(model, coords, PlayerCache.MyClient.Ped.Heading);
            Veh.PreviouslyOwnedByPlayer = true;
            Veh.FadeEntity(false);
            await Veh.FadeEntityAsync(true);
        }

        public static void DeleteVehicle()
        {
            Entity vehicle = new Vehicle(Functions.GetVehicleInDirection());
            if (VehicleChecker.IsInVehicle) vehicle = VehicleChecker.CurrentVehicle;
            vehicle.Delete();
        }

        public static async void Save()
        {
            Screen.LoadingPrompt.Show("Saving...", LoadingSpinnerType.SocialClubSaving);
            await BaseScript.Delay(5000);
            Screen.LoadingPrompt.Hide();
        }

        public static void AddWeapon(string weaponName, int ammo)
        {
            WeaponHash weaponHash = (WeaponHash)GetHashKey(weaponName);
            GiveWeaponToPed(PlayerPedId(), (uint)weaponHash, ammo, true, false);
            SetPedAmmo(PlayerPedId(), (uint)weaponHash, ammo);
        }

        public static void RemoveWeapon(string weaponName)
        {
            WeaponHash weaponHash = (WeaponHash)GetHashKey(weaponName);
            RemoveWeaponFromPed(PlayerPedId(), (uint)weaponHash);
            SetPedAmmo(PlayerPedId(), (uint)weaponHash, 0);
        }

        public static void AddWeaponComponent(string weaponName, string weaponComponent)
        {
            uint weaponHash = Functions.HashUint(weaponName);
            uint componentHash = Functions.HashUint(weaponComponent);

            if (!Cache.PlayerCache.MyClient.User.HasWeaponComponent(weaponName, weaponComponent))
            {
                GiveWeaponComponentToPed(PlayerPedId(), weaponHash, componentHash);
            }
        }

        public static void RemoveWeaponComponent(string weaponName, string weaponComponent)
        {
            uint weaponHash = Functions.HashUint(weaponName);
            uint componentHash = Functions.HashUint(weaponComponent);
            RemoveWeaponComponentFromPed(PlayerPedId(), weaponHash, componentHash);
            Notifications.ShowNotification("Removed/a ~b~" + Functions.GetWeaponLabel(componentHash));
        }

        public static void AddWeaponTint(string weaponName, int tint)
        {
            uint weaponHash = Functions.HashUint(weaponName);
            SetPedWeaponTintIndex(PlayerPedId(), weaponHash, tint);
        }
    }
}