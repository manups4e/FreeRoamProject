using System;
using System.Collections.Generic;

namespace FreeRoamProject.Client
{
    public delegate void VehicleDestroyedEvent(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag);
    public delegate void PedKilledByVehicleEvent(int ped, int vehicle);
    public delegate void PedKilledByPlayerEvent(int ped, int killer, uint weaponHash, bool isMeleeDamage);
    public delegate void PedKilledByPedEvent(int ped, int attackerPed, uint weaponHash, bool isMeleeDamage);
    public delegate void PedDiedEvent(int ped, int attacker, uint weaponHash, bool isMeleeDamage);
    public delegate void EntityKilledEvent(int entity, int attacker, uint weaponHash, bool isMeleeDamage);
    public delegate void VehicleDamagedEvent(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag);
    public delegate void EntityDamagedEvent(int entity, int attacker, uint weaponHash, bool isMeleeDamage);
    public delegate void PlayerJoined();

    // TODO: ADD AS MUCH EVENTS AS WE CAN, LESS TICKS.. LESS CHECKS.. LET THE GAME DO ITS THING SMOOTH AND FLAWLESS
    // all events here https://docs.fivem.net/docs/game-references/game-events/
    // some of them can be re-made by us using c# event system even tho we use the server to change buckets and such.. so..
    // i hope we can find more events to use yeah..
    public class InternalGameEvents
    {
        public const string damageEventName = "DamageEvents";

        public static void Init()
        {
            ClientMain.Instance.AddEventHandler("gameEventTriggered", new Action<string, List<object>>(GameEventTriggered));
        }

        public static event VehicleDestroyedEvent OnVehicleDestroyed;
        public static event PedKilledByVehicleEvent OnPedKilledByVehicle;
        public static event PedKilledByPlayerEvent OnPedKilledByPlayer;
        public static event PedKilledByPedEvent OnPedKilledByPed;
        public static event PedDiedEvent OnPedDied;
        public static event EntityKilledEvent OnEntityKilled;
        public static event VehicleDamagedEvent OnVehicleDamaged;
        public static event EntityDamagedEvent OnEntityDamaged;
        public static event PlayerJoined PlayerJoined;
        /// <summary>
        /// Event gets triggered whenever a vehicle is destroyed.
        /// </summary>
        /// <param name="vehicle">The vehicle that got destroyed.</param>
        /// <param name="attacker">The attacker handle of what destroyed the vehicle.</param>
        /// <param name="weaponHash">The weapon hash that was used to destroy the vehicle.</param>
        /// <param name="isMeleeDamage">True if the damage dealt was using any melee weapon (including unarmed).</param>
        /// <param name="vehicleDamageTypeFlag">Vehicle damage type flag, 93 is vehicle tires damaged, others unknown.</param>
        private static void VehicleDestroyed(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag)
        {
            OnVehicleDestroyed?.Invoke(vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
            BaseScript.TriggerEvent(damageEventName + ":VehicleDestroyed", vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
            ClientMain.Logger.Debug($"[{damageEventName}:VehicleDestroyed] vehicle: {vehicle}, attacker: {attacker}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}, vehicleDamageTypeFlag: {vehicleDamageTypeFlag}");
        }

        /// <summary>
        /// Event gets triggered whenever a ped was killed by a vehicle without a driver.
        /// </summary>
        /// <param name="ped">Ped that got killed.</param>
        /// <param name="vehicle">Vehicle that was used to kill the ped.</param>
        private static void PedKilledByVehicle(int ped, int vehicle)
        {
            OnPedKilledByVehicle?.Invoke(ped, vehicle);
            BaseScript.TriggerEvent(damageEventName + ":PedKilledByVehicle", ped, vehicle);
            ClientMain.Logger.Debug($"[{damageEventName}:PedKilledByVehicle] ped: {ped}, vehicle: {vehicle}");
        }

        /// <summary>
        /// Event gets triggered whenever a ped is killed by a player.
        /// </summary>
        /// <param name="ped">The ped that got killed.</param>
        /// <param name="killerPlayer">The player that killed the ped.</param>
        /// <param name="weaponHash">The weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True if the ped was killed with a melee weapon (including unarmed).</param>
        private static void PedKilledByPlayer(int ped, int killerPlayer, uint weaponHash, bool isMeleeDamage)
        {
            OnPedKilledByPlayer(ped, killerPlayer, weaponHash, isMeleeDamage);
            BaseScript.TriggerEvent(damageEventName + ":PedKilledByPlayer", ped, killerPlayer, weaponHash, isMeleeDamage);
            ClientMain.Logger.Debug($"[{damageEventName}:PedKilledByPlayer] ped: {ped}, player: {killerPlayer}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}");
        }

        /// <summary>
        /// Event gets triggered whenever a ped is killed by another (non-player) ped.
        /// </summary>
        /// <param name="ped">Ped that got killed.</param>
        /// <param name="attackerPed">Ped that killed the victim ped.</param>
        /// <param name="weaponHash">Weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True if the ped was killed using a melee weapon (including unarmed).</param>
        private static void PedKilledByPed(int ped, int attackerPed, uint weaponHash, bool isMeleeDamage)
        {
            OnPedKilledByPed?.Invoke(ped, attackerPed, weaponHash, isMeleeDamage);
            BaseScript.TriggerEvent(damageEventName + ":PedKilledByPed", ped, attackerPed, weaponHash, isMeleeDamage);
            ClientMain.Logger.Debug($"[{damageEventName}:PedKilledByPed] ped: {ped}, attackerPed: {attackerPed}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}");
        }

        /// <summary>
        /// Event gets triggered whenever a ped died, but only if the other (more detailed) events weren't triggered.
        /// </summary>
        /// <param name="ped">The ped that died.</param>
        /// <param name="attacker">The attacker (can be the same as the ped that died).</param>
        /// <param name="weaponHash">Weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True whenever the ped was killed using a melee weapon (including unarmed).</param>
        private static void PedDied(int ped, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            OnPedDied.Invoke(ped, attacker, weaponHash, isMeleeDamage);
            BaseScript.TriggerEvent(damageEventName + ":PedDied", ped, attacker, weaponHash, isMeleeDamage);
            ClientMain.Logger.Debug($"[{damageEventName}:PedDied] ped: {ped}, attacker: {attacker}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}");
        }

        /// <summary>
        /// Gets triggered whenever an entity died, that's not a vehicle, or a ped.
        /// <param name="entity">Entity that was killed/destroyed.</param>
        /// <param name="attacker">The attacker that destroyed/killed the entity.</param>
        /// <param name="weaponHash">The weapon hash used to kill/destroy the entity.</param>
        /// <param name="isMeleeDamage">True whenever the entity was killed/destroyed with a melee weapon.</param>
        private static void EntityKilled(int entity, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            OnEntityKilled.Invoke(entity, attacker, weaponHash, isMeleeDamage);
            BaseScript.TriggerEvent(damageEventName + ":EntityKilled", entity, attacker, weaponHash, isMeleeDamage);
            ClientMain.Logger.Debug($"[{damageEventName}:EntityKilled] entity: {entity}, attacker: {attacker}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}");
        }

        /// <summary>
        /// Event gets triggered whenever a vehicle is damaged, but not destroyed.
        /// </summary>
        /// <param name="vehicle">Vehicle that got damaged.</param>
        /// <param name="attacker">Attacker that damaged the vehicle.</param>
        /// <param name="weaponHash">Weapon hash used to damage the vehicle.</param>
        /// <param name="isMeleeDamage">True whenever the vehicle was damaged using a melee weapon (including unarmed).</param>
        /// <param name="vehicleDamageTypeFlag">Vehicle damage type flag, 93 is vehicle tire damage, others are unknown.</param>
        private static void VehicleDamaged(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag)
        {
            OnVehicleDamaged?.Invoke(vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
            BaseScript.TriggerEvent(damageEventName + ":VehicleDamaged", vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
            ClientMain.Logger.Debug($"[{damageEventName}:VehicleDamaged] vehicle: {vehicle}, attacker: {attacker}, weaponHash: {weaponHash}, vehicleDamageTypeFlag: {vehicleDamageTypeFlag}");
        }

        /// <summary>
        /// Event gets triggered whenever an entity is damaged but hasn't died from the damage.
        /// </summary>
        /// <param name="entity">Entity that got damaged.</param>
        /// <param name="attacker">The attacker that damaged the entity.</param>
        /// <param name="weaponHash">The weapon hash used to damage the entity.</param>
        /// <param name="isMeleeDamage">True if the damage was done using a melee weapon (including unarmed).</param>
        private static void EntityDamaged(int entity, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            OnEntityDamaged?.Invoke(entity, attacker, weaponHash, isMeleeDamage);
            BaseScript.TriggerEvent(damageEventName + ":EntityDamaged", entity, attacker, weaponHash, isMeleeDamage);
            ClientMain.Logger.Debug($"[{damageEventName}:EntityDamaged] entity: {entity}, attacker: {attacker}, weaponHash: {weaponHash}, isMeleeDamage: {isMeleeDamage}");
        }

        /// <summary>
        /// Used internally to trigger the other events.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        private static void GameEventTriggered(string eventName, List<object> data)
        {
            ClientMain.Logger.Debug($"game event {eventName} ({string.Join(", ", data.ToArray())})");
            switch (eventName)
            {
                case "CEventNetworkEntityDamage":
                    {
                        Entity victim = Entity.FromHandle(int.Parse(data[0].ToString()));
                        Entity attacker = Entity.FromHandle(int.Parse(data[1].ToString()));
                        int attackerint = int.Parse(data[1].ToString());

                        bool victimDied = int.Parse(data[5].ToString()) == 1;

                        uint weaponHash = (uint)int.Parse(data[6].ToString());

                        bool isMeleeDamage = int.Parse(data[9].ToString()) != 0;
                        int vehicleDamageTypeFlag = int.Parse(data[10].ToString());

                        if (victim == null) return;

                        if (attacker != null && attackerint != -1)
                        {
                            if (victimDied)
                            {
                                // victim died
                                // vehicle destroyed
                                if (victim.Model.IsVehicle)
                                {
                                    VehicleDestroyed(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
                                }
                                // other entity died
                                else
                                {
                                    // victim is a ped
                                    if (victim is Ped ped)
                                        switch (attacker)
                                        {
                                            case Vehicle veh:
                                                PedKilledByVehicle(victim.Handle, veh.Handle);

                                                break;
                                            case Ped p when p.IsPlayer:
                                                int player = NetworkGetPlayerIndexFromPed(p.Handle);
                                                PedKilledByPlayer(ped.Handle, player, weaponHash, isMeleeDamage);

                                                break;
                                            case Ped p:
                                                PedKilledByPed(ped.Handle, p.Handle, weaponHash, isMeleeDamage);

                                                break;
                                            default:
                                                PedDied(ped.Handle, attacker.Handle, weaponHash, isMeleeDamage);

                                                break;
                                        }
                                    // victim is not a ped
                                    else
                                        EntityKilled(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                                }
                            }
                            else
                            {
                                // only damaged
                                if (!victim.Model.IsVehicle)
                                    EntityDamaged(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                                else
                                    VehicleDamaged(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
                            }
                        }
                        else
                        {
                            if (victimDied)
                                PedDied(victim.Handle, -1, weaponHash, isMeleeDamage);
                            else
                            {
                                // only damaged
                                if (!victim.Model.IsVehicle)
                                    EntityDamaged(victim.Handle, -1, weaponHash, isMeleeDamage);
                                else
                                    VehicleDamaged(victim.Handle, -1, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
                            }
                        }
                    }
                    break;
                case "CEventNetworkStartSession": // when player logs into the server (not working on restart, please check NewServerEntrance.cs for debug)
                    {
                        PlayerJoined?.Invoke();
                    }
                    break;
            }
        }
    }
}