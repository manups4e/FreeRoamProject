using FreeRoamProject.Client.Handlers;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Spawner
{
    public static class FreeRoamLogin
    {
        public static async Task LoadPlayer()
        {
            PlayerCache.MyClient.Player.CanControlCharacter = false;
            PlayerCache.MyClient.Ped.IsPositionFrozen = true;

            if (PlayerCache.MyClient.Ped.IsVisible)
                await Functions.FadeEntityAsync(PlayerCache.MyClient.Ped, false, false, false);
            await BaseScript.Delay(2000);
            if (Screen.Fading.IsFadedOut) Screen.Fading.FadeIn(1000);

            Screen.LoadingPrompt.Show("Loading", LoadingSpinnerType.Clockwise1);

            uint model = PlayerCache.MyClient.User.Character.Skin.Model;
            while (!await PlayerCache.MyClient.Player.ChangeModel(new Model((PedHash)model))) await BaseScript.Delay(0);

            Functions.UpdateFace(PlayerCache.MyClient.Ped.Handle, PlayerCache.MyClient.User.Character.Skin);
            Functions.UpdateDress(PlayerCache.MyClient.Ped.Handle, PlayerCache.MyClient.User.Character.Dressing);
            RestoreWeapons();

            // TODO: HIDE THIS FROM THE PLAYER VIEW WHILE CAMERA IS UP IN THE AIR
            StatSetInt(Functions.HashUint("MP0_WALLET_BALANCE"), Cache.PlayerCache.MyClient.User.Money, true);
            StatSetInt(Functions.HashUint("BANK_BALANCE"), Cache.PlayerCache.MyClient.User.Bank, true);

            if (Screen.LoadingPrompt.IsActive) Screen.LoadingPrompt.Hide();
            Screen.LoadingPrompt.Show("Syncing with the server", LoadingSpinnerType.Clockwise1);
            // TODO: TURN THIS INTO A GET (CALLBACK) RETURNING THE BUCKET ID
            EventDispatcher.Send("tlg:addPlayerToBucket");
            NetworkClearClockTimeOverride();
            await BaseScript.Delay(7000);
            EventDispatcher.Send("SyncWeatherForMe", true);
            await BaseScript.Delay(2000);
            if (Screen.LoadingPrompt.IsActive)
                Screen.LoadingPrompt.Hide();

            ClientMain.Logger.Warning("PlayerCache.MyPlayer.User.Character.Position: " + PlayerCache.MyClient.User.Character.Position);
            ClientMain.Logger.Warning("Ped.Position: " + PlayerCache.MyClient.Ped.Position);
            if (PlayerCache.MyClient.User.Character.Position is null)
            {
                ClientMain.Logger.Debug("player coord are null");
                Vector3 vect = await new Vector3(0).GetVector3WithGroundZ();
                GetSafeCoordForPed(vect.X, vect.Y, vect.Z, true, ref vect, 16);
                PlayerCache.MyClient.Ped.Position = vect;
            }
            else
            {
                PlayerCache.MyClient.Ped.Position = (await PlayerCache.MyClient.User.Character.Position.GetPositionWithGroundZ()).ToVector3;
            }

            // TODO: LOADING PROPERTIES (AND SPAWN IN PROPERTY IF DISCONNECTED INSIDE)
            // TODO: LOAD VEHICLES (AND SPAWN LAST USED VEHICLE IF DISCONNECTED ON THE STREET WITH ITS PERSONAL VEHICLE OUT)
            ClearFocus();
            SwitchInPlayer(PlayerPedId());
            while (IsPlayerSwitchInProgress())
                await BaseScript.Delay(0);
            DisplayHud(true);
            MinimapHandler.EnableMinimap = true;
            Function.Call(Hash.NETWORK_FADE_IN_ENTITY, PlayerCache.MyClient.Ped.Handle, true, 1);
            if (!PlayerCache.MyClient.Ped.IsVisible)
                await Functions.FadeEntityAsync(PlayerCache.MyClient.Ped, true, false, true);
            PlayerCache.MyClient.Ped.IsPositionFrozen = false;
            PlayerCache.MyClient.Player.CanControlCharacter = true;
            EventDispatcher.Send("worldEventsManage.Server:AddParticipant");
            AccessingEvents.FreeRoamSpawn(PlayerCache.MyClient);
            PlayerCache.MyClient.Status.PlayerStates.Spawned = true;
        }

        public static void RestoreWeapons()
        {
            Dictionary<int, bool> ammoTypes = new();

            if (PlayerCache.MyClient.User.Character.Weapons.Count > 0)
            {
                PlayerCache.MyClient.Ped.Weapons.RemoveAll();
                List<Weapons> weaps = PlayerCache.MyClient.User.GetCharWeapons();

                for (int i = 0; i < weaps.Count; i++)
                {
                    string weaponName = weaps[i].Name;
                    uint weaponHash = Functions.HashUint(weaponName);
                    int tint = weaps[i].Tint;
                    PlayerCache.MyClient.Ped.Weapons.Give((WeaponHash)weaponHash, 0, false, false);
                    int ammoType = GetPedAmmoTypeFromWeapon(PlayerPedId(), weaponHash);

                    if (weaps[i].Components.Count > 0)
                    {
                        foreach (Components weaponComponent in weaps[i].Components)
                        {
                            uint componentHash = Functions.HashUint(weaponComponent.name);
                            if (weaponComponent.active) GiveWeaponComponentToPed(PlayerPedId(), weaponHash, componentHash);
                        }
                    }

                    SetPedWeaponTintIndex(PlayerPedId(), weaponHash, tint);

                    if (ammoTypes.ContainsKey(ammoType)) continue;
                    AddAmmoToPed(PlayerPedId(), weaponHash, weaps[i].Ammo);
                    ammoTypes[ammoType] = true;
                }
            }
        }
    }
}
