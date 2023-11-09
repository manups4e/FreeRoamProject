using FreeRoamProject.Shared.Core;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    // TODO: WE NEED TO ADD KILLSTREAK TO THE STATS.. MAYBE TEMP STAT SO THAT WE CAN CHECK IT
    static class BaseEventsFreeRoam
    {
        // tlg:onPlayerDied: 3 params int deathType, int killer, int causeOfDeath, Position victimCoords
        // edit: from now on deatType is => 0: victim, 1: killer, 2: neither............... it was 0: suicide, -1 player dead (env), 1 killed by player, 

        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += FreeRoamLogin_OnPlayerJoined;
            AccessingEvents.OnFreeRoamLeave += FreeRoamLogin_OnPlayerLeft;
        }

        private static TimerBarPool _timerBarPool = new();
        private static ProgressTimerBar _respawnTimerBar;

        private static async Task DrawRespawnTimer()
        {
            _timerBarPool.Draw();
            _respawnTimerBar.Percentage += 0.0015f;
            if (Input.IsControlJustPressed(Control.Jump))
            {
                _respawnTimerBar.Percentage += 0.0180f;
            }
            if (_respawnTimerBar.Percentage >= 1)
            {
                ClientMain.Instance.RemoveTick(DrawRespawnTimer);
                _timerBarPool.Remove(_respawnTimerBar);
                ScaleformUI.Main.InstructionalButtons.ClearButtonList();
                int res = 0;
                int cases = NetworkQueryRespawnResults(ref res);
                Vector3 coords = Vector3.Zero;
                float heading = 0;
                NetworkGetRespawnResult(SharedMath.GetRandomInt(cases), ref coords, ref heading);
                Revive(coords, heading);
            }
            await Task.FromResult(0);
        }

        private static async void BeginRespawn()
        {
            Vector3 coords = PlayerCache.MyPlayer.Position.ToVector3;
            int flags = 2 + 16 + 32 + 2048 + 512 + 1024;
            NetworkStartRespawnSearchForPlayer(PlayerCache.MyPlayer.Player.Handle, coords.X, coords.Y, coords.Z, 100f, 0, 0, 0, flags);
            _respawnTimerBar = new ProgressTimerBar(Game.GetGXTEntry("KS_RESPAWN_B"));
            _timerBarPool.Add(_respawnTimerBar);
            ClientMain.Instance.AddTick(DrawRespawnTimer);
            ScaleformUI.Main.InstructionalButtons.AddInstructionalButton(new InstructionalButton(Control.Jump, Game.GetGXTEntry("HUD_INPUT27")));
        }

        private static void FreeRoamLogin_OnPlayerJoined(PlayerClient client)
        {
            InternalGameEvents.OnPedKilledByPlayer += OnPedKilledByPlayer;
            InternalGameEvents.OnPedDied += OnPedDied;
            InternalGameEvents.OnPedKilledByPed += OnPedKilledByPed;
            InternalGameEvents.OnPedKilledByVehicle += OnPedKilledByVehicle;
            Environment.EnablePvP(true);
        }
        // old method for "returning to lobby" we can keep it for team events or whatever
        private static void FreeRoamLogin_OnPlayerLeft(PlayerClient client)
        {
            InternalGameEvents.OnPedKilledByPlayer -= OnPedKilledByPlayer;
            InternalGameEvents.OnPedDied -= OnPedDied;
            InternalGameEvents.OnPedKilledByPed -= OnPedKilledByPed;
            InternalGameEvents.OnPedKilledByVehicle -= OnPedKilledByVehicle;
            Environment.EnablePvP(false);
        }

        private static async void OnPedKilledByVehicle(int ped, int vehicle, int weaponHash)
        {
            // if (ped != PlayerCache.MyPlayer.Ped.Handle) return;
            // TODO: ADVANCED CHECKS MUST BE MADE SO THAT WE CHECK IF PLAYERS ARE IN TEAMS.. GANGS.. CONCEALED.. DOING VS
            if (IsPedAPlayer(ped))
            {
                if (ped == PlayerPedId())
                {
                    Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
                    Game.PlaySound("Bed", "WastedSounds");
                    GameplayCamera.Shake(CameraShake.DeathFail, 1f);
                }
                Vehicle veh = new(vehicle);
                int laspe = GetLastPedInVehicleSeat(vehicle, (int)VehicleSeat.Driver);
                if (laspe != 0)
                {
                    Ped lastPed = new(laspe);
                    if (lastPed.IsPlayer) // vehicle driver is a player
                    {
                        Player playerKiller = new(NetworkGetPlayerIndexFromPed(lastPed.Handle));
                        // player it's not me
                        if (lastPed.Handle != PlayerCache.MyPlayer.Ped.Handle)
                        {
                            func_19419(DeathType.Victim, NetworkGetPlayerIndexFromPed(ped), playerKiller.Handle, false, weaponHash);
                            //EventDispatcher.Send("tlg:onPlayerDied", 1, playerKiller.Handle, GetEntityCoords(ped, false).ToPosition());
                        }
                        else if (lastPed.Handle == PlayerCache.MyPlayer.Ped.Handle)
                        {
                            func_19419(DeathType.Killer, NetworkGetPlayerIndexFromPed(ped), playerKiller.Handle, false, weaponHash);
                        }
                        else
                        {
                            func_19419(DeathType.Bystander, NetworkGetPlayerIndexFromPed(ped), playerKiller.Handle, false, weaponHash);
                        }
                    }
                    else
                        GetKillingLabel("TICK_DIED", NetworkGetPlayerIndexFromPed(ped), 0);
                }
                else
                    GetKillingLabel("TICK_DIED", NetworkGetPlayerIndexFromPed(ped), 0);

                if (ped == PlayerPedId())
                {
                    Game.PlaySound("TextHit", "WastedSounds");
                    ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), "");
                    BeginRespawn();
                    await BaseScript.Delay(1000);
                    if (laspe != 0)
                    {
                        Ped lastPed = new(laspe);
                        if (lastPed.IsPlayer) // vehicle driver is a player
                        {
                            NetworkSetOverrideSpectatorMode(true);
                            NetworkSetInSpectatorModeExtended(true, lastPed.Handle, true);
                            if (lastPed.IsInVehicle())
                                SetCinematicModeActive(true);
                            await BaseScript.Delay(3000);
                            NetworkSetInSpectatorModeExtended(false, PlayerPedId(), true);
                            NetworkSetOverrideSpectatorMode(false);
                        }
                    }
                }
            }
        }

        private static async void OnPedKilledByPed(int ped, int attackerPed, uint weaponHash, bool isMeleeDamage)
        {
            if (IsPedAPlayer(ped))
            {
                if (ped == PlayerPedId())
                {
                    Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
                    Game.PlaySound("Bed", "WastedSounds");
                    GameplayCamera.Shake(CameraShake.DeathFail, 1f);
                    EventDispatcher.Send("tlg:onPlayerDied", -1, attackerPed, GetEntityCoords(ped, false).ToPosition());
                    Game.PlaySound("TextHit", "WastedSounds");
                    ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), "");
                    await BaseScript.Delay(5000);
                    if (ped == PlayerPedId())
                    {
                        BeginRespawn();
                    }
                    func_19419(DeathType.Victim, NetworkGetPlayerIndexFromPed(ped), 0, false, (int)weaponHash);
                }
                else
                    func_19419(DeathType.Bystander, NetworkGetPlayerIndexFromPed(ped), 0, false, (int)weaponHash);
            }
        }

        private static async void OnPedDied(int ped, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            if (IsPedAPlayer(ped))
            {
                bool suicide = weaponHash == 3452007600;
                if (ped == PlayerPedId())
                {
                    Screen.Effects.Start(ScreenEffect.DeathFailMpIn);
                    Game.PlaySound("Bed", "WastedSounds");
                    GameplayCamera.Shake(CameraShake.DeathFail, 1f);
                    Game.PlaySound("TextHit", "WastedSounds");
                    ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage("~r~" + Game.GetGXTEntry("RESPAWN_W_MP"), "");
                    BeginRespawn();
                }
                EventDispatcher.Send("tlg:onPlayerDied", suicide ? 0 : -1, attacker, GetEntityCoords(ped, false).ToPosition());
                if (suicide)
                {
                    if (ped == PlayerPedId())
                    {
                        GetKillingLabel("DM_U_SUIC", 0, 0);
                    }
                    else
                    {
                        GetKillingLabel("DM_O_SUIC", NetworkGetPlayerIndexFromPed(ped), 0);
                    }
                }
                else
                {
                    GetKillingLabel("TICK_DIED", NetworkGetPlayerIndexFromPed(ped), 0);
                }
            }
        }

        private static async void OnPedKilledByPlayer(int ped, int killer, uint weaponHash, bool isMeleeDamage)
        {
            // WE HAVE 3 CASES..
            // CASE 1: WE ARE THE VICTIM
            // CASE 2: WE ARE THE KILLER
            // CASE 3: WE ARE NEITHER AND WE GET NEUTRAL "X KILLED Y" MESSAGE..
            // TODO: ADVANCED CHECKS MUST BE MADE SO THAT WE CHECK IF PLAYERS ARE IN TEAMS.. GANGS.. CONCEALED.. DOING VS
            if (IsPedAPlayer(ped))
            {
                Player killerPed = new(killer);
                bool isVictim = ped == PlayerPedId();
                if (isVictim)
                {
                    Screen.Effects.Start(ScreenEffect.DeathFailOut);
                    Game.PlaySound("Bed", "WastedSounds");
                    GameplayCamera.Shake(CameraShake.DeathFail, 1f);
                    Game.PlaySound("TextHit", "WastedSounds");
                    ScaleformUI.Main.BigMessageInstance.ShowMpWastedMessage(Game.GetGXTEntry("RESPAWN_W_MP"), "");
                }
                EventDispatcher.Send("tlg:onPlayerDied", 1, killerPed.ServerId, API.GetEntityCoords(ped, false).ToPosition());
                DeathType deathType;
                if (isVictim)
                    deathType = DeathType.Victim;
                else
                {
                    if (killer == PlayerId())
                        deathType = DeathType.Killer;
                    else
                        deathType = DeathType.Bystander;
                }

                int player = NetworkGetPlayerIndexFromPed(ped);
                if (player == -1)
                {
                    return; // Ped was not a player
                }
                func_19419(deathType, player, killer, false, (int)weaponHash);

                if (isVictim)
                {
                    Ped KilPed = killerPed.Character;
                    BeginRespawn();
                    await BaseScript.Delay(1000);
                    NetworkSetOverrideSpectatorMode(true);
                    NetworkSetInSpectatorModeExtended(true, KilPed.Handle, true);
                    if (KilPed.IsInVehicle())
                        SetCinematicModeActive(true);
                    await BaseScript.Delay(3000);
                    NetworkSetInSpectatorModeExtended(false, PlayerPedId(), true);
                    NetworkSetOverrideSpectatorMode(false);
                }
            }
        }


        private static async void Revive(Vector3 coords, float heading)
        {
            Screen.Fading.FadeOut(800);
            while (Screen.Fading.IsFadingOut) await BaseScript.Delay(50);

            Screen.Effects.Stop();

            // TODO: correct IsInvincible with Anticheat
            Position pos = PlayerCache.MyPlayer.Position;
            NetworkResurrectLocalPlayer(coords.X, coords.Y, coords.Z, heading, true, false);

            PlayerCache.MyPlayer.Ped.Health = 100;
            PlayerCache.MyPlayer.Ped.IsInvincible = false;
            PlayerCache.MyPlayer.Ped.ClearBloodDamage();
            Screen.Fading.FadeIn(800);
        }



        static void func_19419(DeathType typeOfEvent, int player1, int player2, bool execution, int causeOfDeath, bool teamDeath = false)//Position - 0x5E4A7A
        {
            //bparam1 is player1
            //bparam2 is player2 
            //in freeroam.c in many functions these 2 params are checked with GetPlayerName and GetPlayerTeam
            // to check for execution, we can use gangs, lester contracts.. events, minigames.. whatever for now we keep it at 0 (false)
            string Var0;
            int iVar1;
            int iVar2;
            int iVar3;
            int iVar4;

            if (teamDeath)
            {

                // if player is in a team (in italian is about relationship.. but could be a professional one or a romantic one?) 
                // in english:
                /*
                  "VT_TK_0": "The ~a~~HUD_COLOUR_WHITE~ broke you up",
                  "VT_TK_1": "You broke up the ~a~",
                  "VT_TK_2": "~a~~HUD_COLOUR_WHITE~ broke up the ~a~",
                 */

                if ((int)typeOfEvent != 1)
                {
                    iVar2 = GetPlayerTeam(PlayerId());
                    iVar3 = GetPlayerTeam(player1);
                    iVar4 = GetPlayerTeam(player2);
                    switch ((int)typeOfEvent)
                    {
                        case 0:
                            Var0 = "VT_TK_1";
                            if (iVar3 > -1 && iVar3 < 4)
                            {
                                //func_8802(Var0, &(Global_1837216[iVar3]), func_1549(bParam1, iVar3, 1, 0, 0));
                            }
                            break;

                        case 2:
                            if (iVar3 == iVar2) // we are player1
                            {
                                Var0 = "VT_TK_0";
                                if (iVar4 > -1 && iVar4 < 4)
                                {
                                    //func_8802(Var0, &(Global_1837216[iVar4]), func_1549(bParam2, iVar4, 1, 0, 0));
                                }
                            }
                            else
                            {
                                Var0 = "VT_TK_2";
                                if (iVar3 > -1 && iVar3 < 4)
                                {
                                    //func_19420(Var0, &(Global_1837216[iVar3]), bParam2, func_1549(bParam1, iVar3, 1, 0, 0), 0);
                                }
                            }
                            break;
                    }
                }
            }
            else if (execution)
            {
                switch ((int)typeOfEvent)
                {
                    case 0:
                        GetKillingLabel("DM_TK_EXE0", player1, 0, 0, 0, 1, 0);
                        break;

                    case 1:
                        GetKillingLabel("DM_TK_EXE1", player2, 0, 0, 0, 1, 0);
                        break;

                    case 2:
                        GetKillingLabel("DM_TK_EXE2", player2, player1, 0, 0);
                        break;
                }
            }
            else
            {
                switch (causeOfDeath)
                {
                    case 0:
                    case > 0 when causeOfDeath == GetHashKey("weapon_snowball"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_hit_by_water_cannon"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_electric_fence"):
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                GetKillingLabel("DM_TICK2", player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                GetKillingLabel("DM_TICK1", player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                GetKillingLabel("DM_TICK6", player2, player1, 0, 0);
                                break;

                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_fall"):
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                            case 1:
                            case 2:
                                GetKillingLabel("DM_TK_FALL0", player1, 0, 0, 0, 1, 0);
                                break;

                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_unarmed"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_bat"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_nightstick"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_hammer"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_crowbar"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_golfclub"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_knuckle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_hatchet"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_poolcue"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_wrench"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_flashlight"):
                        iVar1 = SharedMath.GetRandomInt(0, 5);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_MELEE0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_MELEE1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_MELEE2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_molotov"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_TORCH0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_TORCH1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_TORCH2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_knife"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_bottle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_dagger"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_battleaxe"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_machete"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_switchblade"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_KNIFE0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_KNIFE1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_KNIFE2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_pistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_combatpistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_appistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_snspistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_heavypistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_vintagepistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_marksmanpistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_machinepistol"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_revolver"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_pistol50"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_pistol_mk2"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_doubleaction"):
                        iVar1 = SharedMath.GetRandomInt(0, 5);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_PISTOL0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_PISTOL1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_PISTOL2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_smg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_microsmg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_combatpdw"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_minismg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_assaultsmg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_gusenberg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_smg_mk2"):
                        iVar1 = SharedMath.GetRandomInt(0, 4);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_SUB0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_SUB1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_SUB2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_assaultrifle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_carbinerifle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_carbinerifle_mk2"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_advancedrifle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_assaultrifle_mk2"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_specialcarbine"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_bullpuprifle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_musket"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_compactrifle"):
                        iVar1 = SharedMath.GetRandomInt(0, 4);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_ARIFLE0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_ARIFLE1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_ARIFLE2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_mg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_combatmg"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_player_bullet"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_combatmg_mk2"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_LIGHT0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_LIGHT1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_LIGHT2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_pumpshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_sawnoffshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_assaultshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_bullpupshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_heavyshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_dbshotgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_autoshotgun"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_SHOT0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_SHOT1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_SHOT2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_heavysniper"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_remotesniper"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_sniperrifle"):
                    case 392730790:
                    case > 0 when causeOfDeath == GetHashKey("weapon_marksmanrifle"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_heavysniper_mk2"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_SNIPE0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_SNIPE1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_SNIPE2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_explosion"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_grenadelauncher"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_flaregun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_rpg"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_vehicle_rocket"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_railgun"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_firework"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_hominglauncher"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_compactlauncher"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_airstrike_rocket"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_turret_technical"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_space_rocket"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_player_laser"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_player_buzzard"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_passenger_rocket"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_plane_rocket"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_dogfighter_missile"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_thruster_missile"):
                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_player_savage"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_HEAVY0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_HEAVY1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_HEAVY2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;

                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_minigun"):
                        iVar1 = SharedMath.GetRandomInt(0, 4);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_MINI0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_MINI1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_MINI2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_stickybomb"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_grenade"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_proxmine"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_pipebomb"):
                        iVar1 = SharedMath.GetRandomInt(0, 3);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_BOMB0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_BOMB1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_BOMB2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_bzgas"):
                        iVar1 = SharedMath.GetRandomInt(0, 2);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_GAS0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_GAS1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_GAS2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;
                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_tank"):
                        iVar1 = SharedMath.GetRandomInt(0, 2);
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                Var0 = "DM_TK_HEAVY0";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                Var0 = "DM_TK_HEAVY1";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                Var0 = "DM_TK_HEAVY2";
                                Var0 += iVar1;
                                GetKillingLabel(Var0, player2, player1, 0, 0);
                                break;

                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("vehicle_weapon_rotors"):
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                GetKillingLabel("DM_TK_VEH0", player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                GetKillingLabel("DM_TK_VEH1", player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                GetKillingLabel("DM_TK_VEH2", player2, player1, 0, 0);
                                break;

                        }
                        break;

                    case > 0 when causeOfDeath == GetHashKey("weapon_rammed_by_car"):
                    case > 0 when causeOfDeath == GetHashKey("weapon_run_over_by_car"):
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                GetKillingLabel("DM_TK_VK0", player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                GetKillingLabel("DM_TK_VK1", player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                GetKillingLabel("DM_TK_VK2", player2, player1, 0, 0);
                                break;

                        }
                        break;

                    default:
                        switch ((int)typeOfEvent)
                        {
                            case 0:
                                GetKillingLabel("DM_TICK2", player1, 0, 0, 0, 1, 0);
                                break;

                            case 1:
                                GetKillingLabel("DM_TICK1", player2, 0, 0, 0, 1, 0);
                                break;

                            case 2:
                                GetKillingLabel("DM_TICK6", player2, player1, 0, 0);
                                break;
                        }
                        break;
                }
            }
        }

        static void GetKillingLabel(string label, int player1, int player2, int unk0 = 0, int unk1 = 0, int unk2 = 0, int unk3 = 0, int unk4 = 0, int unk5 = 0)
        {
            BeginTextCommandThefeedPost(label);
            if (player1 != 0)
            {
                AddTextComponentSubstringPlayerName("<C>" + GetPlayerName(player1) + "</C>~s~");
            }
            if (player2 != 0)
            {
                AddTextComponentSubstringPlayerName("<C>" + GetPlayerName(player2) + "</C>~s~");
            }
            EndTextCommandThefeedPostTicker(false, true);
        }

    }
}
