using FreeRoamProject.Client.GameMode.FREEROAM.CharCreation;
using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Spawner
{
    public static class FreeRoamLogin
    {
        internal static async void Initialize()
        {
            // REMEMBER, WE ARE SWITCHED OUT (BIG CAMERA IN SKY) SO WE NEED TO "STOP SWITCH IF WE GO IN CREATION, OR FOCUS ON PED COORDINATES IF WE SPAWN
            FreeRoamChar roamchar = await EventDispatcher.Get<FreeRoamChar>("tlg:Select_FreeRoamChar", Cache.PlayerCache.MyPlayer.User.ID);
            PlayerCache.MyPlayer.User.Character = roamchar;

            if (roamchar.CharID == 0 && roamchar.Skin is null)
            {
                DoScreenFadeOut(800);
                await BaseScript.Delay(800);
                StopPlayerSwitch();
                RequestModel((uint)PedHash.FreemodeMale01);
                RequestModel((uint)PedHash.FreemodeFemale01);
                FreeRoamCreator.Init();
                string sex = SharedMath.GetRandomInt(0, 100) > 50 ? "Male" : "Female";
                await FreeRoamCreator.CharCreationMenu(sex);
                return;
            }

            await CaricaPlayer(roamchar);
        }

        public static async Task CaricaPlayer(FreeRoamChar roamchar)
        {
            PlayerCache.MyPlayer.Player.CanControlCharacter = false;
            PlayerCache.MyPlayer.Ped.IsPositionFrozen = true;

            if (PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeOutEntity(PlayerCache.MyPlayer.Ped.Handle, true, false);
            Vector3 apos = PlayerCache.MyPlayer.Ped.Position;
            Position rpos = roamchar.Position;

            if (rpos is null)
                rpos = Position.Zero; // TODO: to be changed?

            await BaseScript.Delay(2000);
            if (Screen.Fading.IsFadedOut) Screen.Fading.FadeIn(1000);

            Screen.LoadingPrompt.Show("Loading", LoadingSpinnerType.Clockwise1);

            await LoadChar();

            if (Screen.LoadingPrompt.IsActive) Screen.LoadingPrompt.Hide();
            Screen.LoadingPrompt.Show("Syncing with the server", LoadingSpinnerType.Clockwise1);
            NetworkClearClockTimeOverride();

            await BaseScript.Delay(7000);
            EventDispatcher.Send("SyncWeatherForMe", true);
            await BaseScript.Delay(2000);
            if (Screen.LoadingPrompt.IsActive) Screen.LoadingPrompt.Hide();

            if (PlayerCache.MyPlayer.User.Character.Position is null)
            {
                Vector3 vect = await new Vector3(0).GetVector3WithGroundZ();
                GetSafeCoordForPed(vect.X, vect.Y, vect.Z, true, ref vect, 16);
                PlayerCache.MyPlayer.Ped.Position = vect;
            }
            else
            {
                Vector3 vector = (await PlayerCache.MyPlayer.User.Character.Position.GetPositionWithGroundZ()).ToVector3;
                GetSafeCoordForPed(0, 0, 0, true, ref vector, 16);
                RequestCollisionAtCoord(vector.X, vector.Y, vector.Z);
                PlayerCache.MyPlayer.Ped.Position = vector;
            }

            // TODO: LOADING PROPERTIES (AND SPAWN IN PROPERTY IF DISCONNECTED INSIDE)
            // TODO: LOAD VEHICLES (AND SPAWN LAST USED VEHICLE IF DISCONNECTED ON THE STREET WITH ITS PERSONAL VEHICLE OUT)
            SwitchInPlayer(PlayerCache.MyPlayer.Ped.Handle);
            while (IsPlayerSwitchInProgress()) await BaseScript.Delay(0);
            if (!PlayerCache.MyPlayer.Ped.IsVisible) NetworkFadeInEntity(PlayerCache.MyPlayer.Ped.Handle, true);
            PlayerCache.MyPlayer.Ped.IsPositionFrozen = false;
            PlayerCache.MyPlayer.Player.CanControlCharacter = true;
            EventDispatcher.Send("worldEventsManage.Server:AddParticipant");
            AccessingEvents.FreeRoamSpawn(PlayerCache.MyPlayer);
            PlayerCache.MyPlayer.Status.PlayerStates.Spawned = true;
        }

        public static async Task LoadChar()
        {
            uint model = PlayerCache.MyPlayer.User.Character.Skin.Model;
            while (!await PlayerCache.MyPlayer.Player.ChangeModel(new Model((PedHash)model))) await BaseScript.Delay(0);

            Functions.UpdateFace(PlayerCache.MyPlayer.Ped.Handle, PlayerCache.MyPlayer.User.Character.Skin);
            Functions.UpdateDress(PlayerCache.MyPlayer.Ped.Handle, PlayerCache.MyPlayer.User.Character.Dressing);

            PlayerCache.MyPlayer.Ped.Weapons.RemoveAll();

            StatSetInt(Functions.HashUint("MP0_WALLET_BALANCE"), Cache.PlayerCache.MyPlayer.User.Money, true);
            StatSetInt(Functions.HashUint("BANK_BALANCE"), Cache.PlayerCache.MyPlayer.User.Bank, true);

        }

        public static void RestoreWeapons()
        {
            Dictionary<int, bool> ammoTypes = new();

            if (PlayerCache.MyPlayer.User.Character.Weapons.Count > 0)
            {
                PlayerCache.MyPlayer.Ped.Weapons.RemoveAll();
                List<Weapons> weaps = PlayerCache.MyPlayer.User.GetCharWeapons();

                for (int i = 0; i < weaps.Count; i++)
                {
                    string weaponName = weaps[i].Name;
                    uint weaponHash = Functions.HashUint(weaponName);
                    int tint = weaps[i].Tint;
                    PlayerCache.MyPlayer.Ped.Weapons.Give((WeaponHash)weaponHash, 0, false, false);
                    int ammoType = GetPedAmmoTypeFromWeapon(PlayerPedId(), weaponHash);

                    if (weaps[i].Components.Count > 0)
                        foreach (Components weaponComponent in weaps[i].Components)
                        {
                            uint componentHash = Functions.HashUint(weaponComponent.name);
                            if (weaponComponent.active) GiveWeaponComponentToPed(PlayerPedId(), weaponHash, componentHash);
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
