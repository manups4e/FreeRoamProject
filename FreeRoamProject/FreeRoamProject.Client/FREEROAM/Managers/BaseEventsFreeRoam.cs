using CitizenFX.Core.Native;
using FreeRoamProject.Client.GameMode.FREEROAM.Spawner;


namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    static class BaseEventsFreeRoam
    {
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += FreeRoamLogin_OnPlayerJoined;
            AccessingEvents.OnFreeRoamLeave += FreeRoamLogin_OnPlayerLeft;
        }

        private static void FreeRoamLogin_OnPlayerJoined(PlayerClient client)
        {
            InternalGameEvents.OnPedKilledByPlayer += OnPedKilledByPlayer;
            InternalGameEvents.OnPedDied += OnPedDied;
            InternalGameEvents.OnPedKilledByPed += OnPedKilledByPed;
            InternalGameEvents.OnPedKilledByVehicle += OnPedKilledByVehicle;
            Environment.EnablePvP(true);
        }
        private static void FreeRoamLogin_OnPlayerLeft(PlayerClient client)
        {
            InternalGameEvents.OnPedKilledByPlayer -= OnPedKilledByPlayer;
            InternalGameEvents.OnPedDied -= OnPedDied;
            InternalGameEvents.OnPedKilledByPed -= OnPedKilledByPed;
            InternalGameEvents.OnPedKilledByVehicle -= OnPedKilledByVehicle;
            Environment.EnablePvP(false);
        }

        private static async void OnPedKilledByVehicle(int ped, int vehicle)
        {
            Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
            Game.PlaySound("Bed", "WastedSounds");
            GameplayCamera.Shake(CameraShake.DeathFail, 1f);
            if (ped != PlayerCache.MyPlayer.Ped.Handle) return;
            Vehicle veh = new(vehicle);
            int laspe = GetLastPedInVehicleSeat(vehicle, (int)VehicleSeat.Driver);
            if (laspe != 0)
            {
                Ped lastPed = new(laspe);
                if (lastPed.IsPlayer)
                {
                    if (lastPed.Handle != PlayerCache.MyPlayer.Ped.Handle)
                    {
                        Player playerKiller = new(NetworkGetPlayerIndexFromPed(lastPed.Handle));
                        EventDispatcher.Send("lpop:onPlayerDied", 1, playerKiller.Handle, GetEntityCoords(ped, false).ToPosition());
                    }
                    else
                        EventDispatcher.Send("lpop:onPlayerDied", 0, -1, GetEntityCoords(ped, false).ToPosition());
                }
                else
                    EventDispatcher.Send("lpop:onPlayerDied", -1, -1, GetEntityCoords(ped, false).ToPosition());
            }
            else
                EventDispatcher.Send("lpop:onPlayerDied", -1, -1, GetEntityCoords(ped, false).ToPosition());
            Game.PlaySound("TextHit", "WastedSounds");
            ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), "");
            await BaseScript.Delay(5000);
            Revive();
        }

        private static async void OnPedKilledByPed(int ped, int attackerPed, uint weaponHash, bool isMeleeDamage)
        {
            if (ped != PlayerCache.MyPlayer.Ped.Handle) return;
            Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
            Game.PlaySound("Bed", "WastedSounds");
            GameplayCamera.Shake(CameraShake.DeathFail, 1f);
            EventDispatcher.Send("lpop:onPlayerDied", -1, attackerPed, GetEntityCoords(ped, false).ToPosition());
            Game.PlaySound("TextHit", "WastedSounds");
            ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), "");
            await BaseScript.Delay(5000);
            Revive();
        }

        private static async void OnPedDied(int ped, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            if (ped != PlayerCache.MyPlayer.Ped.Handle) return;
            bool suicidato = weaponHash == 3452007600;
            Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
            Game.PlaySound("Bed", "WastedSounds");
            GameplayCamera.Shake(CameraShake.DeathFail, 1f);
            EventDispatcher.Send("lpop:onPlayerDied", suicidato ? 0 : -1, attacker, API.GetEntityCoords(ped, false).ToPosition());
            Game.PlaySound("TextHit", "WastedSounds");
            ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), suicidato ? "Ti Sei suicidato" : "");
            await BaseScript.Delay(5000);
            Revive();
        }

        private static async void OnPedKilledByPlayer(int ped, int killer, uint weaponHash, bool isMeleeDamage)
        {
            if (ped != PlayerCache.MyPlayer.Ped.Handle) return;
            Player killerPed = new(killer);
            Screen.Effects.Start(ScreenEffect.DeathFailOut);
            Game.PlaySound("Bed", "WastedSounds");
            GameplayCamera.Shake(CameraShake.DeathFail, 1f);
            Game.PlaySound("TextHit", "WastedSounds");
            EventDispatcher.Send("lpop:onPlayerDied", 1, killerPed.ServerId, API.GetEntityCoords(ped, false).ToPosition());
            ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage(Game.GetGXTEntry("RESPAWN_W_MP"), $"{killerPed.Name} ti ha ucciso");
            await BaseScript.Delay(5000);
            Revive();
        }


        private static async void Revive()
        {
            Screen.Fading.FadeOut(800);
            while (Screen.Fading.IsFadingOut) await BaseScript.Delay(50);

            Screen.Effects.Stop();

            // TODO: correggere IsInvincible con l'Anticheat
            Position pos = PlayerCache.MyPlayer.Position;
            Vector3 outpos = Vector3.Zero;
            if (!GetSafeCoordForPed(pos.X, pos.Y, pos.Z, true, ref outpos, 16))
                outpos = pos.ToVector3;

            StartPlayerTeleport(PlayerCache.MyPlayer.Player.Handle, outpos.X, outpos.Y, outpos.Z, pos.Heading, true, true, true);
            while (!HasPlayerTeleportFinished(PlayerId())) await BaseScript.Delay(0);

            NetworkResurrectLocalPlayer(outpos.X, outpos.Y, outpos.Z, pos.Heading, true, false);
            PlayerCache.MyPlayer.Ped.Health = 100;
            PlayerCache.MyPlayer.Ped.IsInvincible = false;
            PlayerCache.MyPlayer.Ped.ClearBloodDamage();
            Screen.Fading.FadeIn(800);
        }
    }
}
