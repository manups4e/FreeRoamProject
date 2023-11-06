using FreeRoamProject.Server.Core.PlayerChar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeRoamProject.Server.Core
{
    public static class Functions
    {
        public static Player GetPlayerFromId(int id)
        {
            return ServerMain.Instance.GetPlayers[id];
        }

        public static Player GetPlayerFromId(string id)
        {
            return ServerMain.Instance.GetPlayers[Convert.ToInt32(id)];
        }

        public static Dictionary<uint, string> HASH_TO_LABEL = new()
        {
            [(uint)GetHashKey("WEAPON_UNARMED")] = "WT_UNARMED",
            [(uint)GetHashKey("WEAPON_ANIMAL")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_COUGAR")] = "WT_RAGE",
            [(uint)GetHashKey("WEAPON_KNIFE")] = "WT_KNIFE",
            [(uint)GetHashKey("WEAPON_NIGHTSTICK")] = "WT_NGTSTK",
            [(uint)GetHashKey("WEAPON_HAMMER")] = "WT_HAMMER",
            [(uint)GetHashKey("WEAPON_BAT")] = "WT_BAT",
            [(uint)GetHashKey("WEAPON_GOLFCLUB")] = "WT_GOLFCLUB",
            [(uint)GetHashKey("WEAPON_CROWBAR")] = "WT_CROWBAR",
            [(uint)GetHashKey("WEAPON_PISTOL")] = "WT_PIST",
            [(uint)GetHashKey("WEAPON_COMBATPISTOL")] = "WT_PIST_CBT",
            [(uint)GetHashKey("WEAPON_APPISTOL")] = "WT_PIST_AP",
            [(uint)GetHashKey("WEAPON_PISTOL50")] = "WT_PIST_50",
            [(uint)GetHashKey("WEAPON_MICROSMG")] = "WT_SMG_MCR",
            [(uint)GetHashKey("WEAPON_SMG")] = "WT_SMG",
            [(uint)GetHashKey("WEAPON_ASSAULTSMG")] = "WT_SMG_ASL",
            [(uint)GetHashKey("WEAPON_ASSAULTRIFLE")] = "WT_RIFLE_ASL",
            [(uint)GetHashKey("WEAPON_CARBINERIFLE")] = "WT_RIFLE_CBN",
            [(uint)GetHashKey("WEAPON_ADVANCEDRIFLE")] = "WT_RIFLE_ADV",
            [(uint)GetHashKey("WEAPON_MG")] = "WT_MG",
            [(uint)GetHashKey("WEAPON_COMBATMG")] = "WT_MG_CBT",
            [(uint)GetHashKey("WEAPON_PUMPSHOTGUN")] = "WT_SG_PMP",
            [(uint)GetHashKey("WEAPON_SAWNOFfsHOTGUN")] = "WT_SG_SOF",
            [(uint)GetHashKey("WEAPON_ASSAULTSHOTGUN")] = "WT_SG_ASL",
            [(uint)GetHashKey("WEAPON_BULLPUPSHOTGUN")] = "WT_SG_BLP",
            [(uint)GetHashKey("WEAPON_STUNGUN")] = "WT_STUN",
            [(uint)GetHashKey("WEAPON_SNIPERRIFLE")] = "WT_SNIP_RIF",
            [(uint)GetHashKey("WEAPON_HEAVYSNIPER")] = "WT_SNIP_HVY",
            [(uint)GetHashKey("WEAPON_REMOTESNIPER")] = "WT_SNIP_RMT",
            [(uint)GetHashKey("WEAPON_GRENADELAUNCHER")] = "WT_GL",
            [(uint)GetHashKey("WEAPON_GRENADELAUNCHER_SMOKE")] = "WT_GL_SMOKE",
            [(uint)GetHashKey("WEAPON_RPG")] = "WT_RPG",
            [(uint)GetHashKey("WEAPON_PASSENGER_ROCKET")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_AIRSTRIKE_ROCKET")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_STINGER")] = "WT_RPG",
            [(uint)GetHashKey("WEAPON_MINIGUN")] = "WT_MINIGUN",
            [(uint)GetHashKey("WEAPON_GRENADE")] = "WT_GNADE",
            [(uint)GetHashKey("WEAPON_STICKYBOMB")] = "WT_GNADE_STK",
            [(uint)GetHashKey("WEAPON_SMOKEGRENADE")] = "WT_GNADE_SMK",
            [(uint)GetHashKey("WEAPON_BZGAS")] = "WT_BZGAS",
            [(uint)GetHashKey("WEAPON_MOLOTOV")] = "WT_MOLOTOV",
            [(uint)GetHashKey("WEAPON_FIREEXTINGUISHER")] = "WT_FIRE",
            [(uint)GetHashKey("WEAPON_PETROLCAN")] = "WT_PETROL",
            [(uint)GetHashKey("WEAPON_DIGISCANNER")] = "WT_DIGI",
            [(uint)GetHashKey("GADGET_NIGHTVISION")] = "WT_NV",
            [(uint)GetHashKey("OBJECT")] = "WT_OBJECT",
            [(uint)GetHashKey("WEAPON_BRIEFCASE")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_BRIEFCASE_02")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_BALL")] = "WT_BALL",
            [(uint)GetHashKey("WEAPON_FLARE")] = "WT_FLARE",
            [(uint)GetHashKey("WEAPON_ELECTRIC_FENCE")] = "WT_ELCFEN",
            [(uint)GetHashKey("VEHICLE_WEAPON_TANK")] = "WT_V_TANK",
            [(uint)GetHashKey("VEHICLE_WEAPON_SPACE_ROCKET")] = "WT_V_SPACERKT",
            [(uint)GetHashKey("VEHICLE_WEAPON_PLAYER_LASER")] = "WT_V_PLRLSR",
            [(uint)GetHashKey("AMMO_RPG")] = "WT_A_RPG",
            [(uint)GetHashKey("AMMO_TANK")] = "WT_A_TANK",
            [(uint)GetHashKey("AMMO_SPACE_ROCKET")] = "WT_A_SPACERKT",
            [(uint)GetHashKey("AMMO_PLAYER_LASER")] = "WT_A_PLRLSR",
            [(uint)GetHashKey("AMMO_ENEMY_LASER")] = "WT_A_ENMYLSR",
            [(uint)GetHashKey("WEAPON_RAMMED_BY_CAR")] = "WT_PIST",
            [(uint)GetHashKey("WEAPON_BOTTLE")] = "WT_BOTTLE",
            [(uint)GetHashKey("WEAPON_GUSENBERG")] = "WT_GUSENBERG",
            [(uint)GetHashKey("WEAPON_SNSPISTOL")] = "WT_SNSPISTOL",
            [(uint)GetHashKey("WEAPON_VINTAGEPISTOL")] = "WT_VPISTOL",
            [(uint)GetHashKey("WEAPON_DAGGER")] = "WT_DAGGER",
            [(uint)GetHashKey("WEAPON_FLAREGUN")] = "WT_FLAREGUN",
            [(uint)GetHashKey("WEAPON_HEAVYPISTOL")] = "WT_HEAVYPSTL",
            [(uint)GetHashKey("WEAPON_SPECIALCARBINE")] = "WT_RIFLE_SCBN",
            [(uint)GetHashKey("WEAPON_MUSKET")] = "WT_MUSKET",
            [(uint)GetHashKey("WEAPON_FIREWORK")] = "WT_FWRKLNCHR",
            [(uint)GetHashKey("WEAPON_MARKSMANRIFLE")] = "WT_MKRIFLE",
            [(uint)GetHashKey("WEAPON_HEAVYSHOTGUN")] = "WT_HVYSHOT",
            [(uint)GetHashKey("WEAPON_PROXMINE")] = "WT_PRXMINE",
            [(uint)GetHashKey("WEAPON_HOMINGLAUNCHER")] = "WT_HOMLNCH",
            [(uint)GetHashKey("WEAPON_HATCHET")] = "WT_HATCHET",
            [(uint)GetHashKey("WEAPON_COMBATPDW")] = "WT_COMBATPDW",
            [(uint)GetHashKey("WEAPON_KNUCKLE")] = "WT_KNUCKLE",
            [(uint)GetHashKey("WEAPON_MARKSMANPISTOL")] = "WT_MKPISTOL",
            [(uint)GetHashKey("WEAPON_MACHETE")] = "WT_MACHETE",
            [(uint)GetHashKey("WEAPON_MACHINEPISTOL")] = "WT_MCHPIST",
            [(uint)GetHashKey("WEAPON_FLASHLIGHT")] = "WT_FLASHLIGHT",
            [(uint)GetHashKey("WEAPON_DBSHOTGUN")] = "WT_DBSHGN",
            [(uint)GetHashKey("WEAPON_COMPACTRIFLE")] = "WT_CMPRIFLE",
            [(uint)GetHashKey("WEAPON_SWITCHBLADE")] = "WT_SWBLADE",
            [(uint)GetHashKey("WEAPON_REVOLVER")] = "WT_REVOLVER",
            [(uint)GetHashKey("WEAPON_FIRE")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_HELI_CRASH")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_RUN_OVER_BY_CAR")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_HIT_BY_WATER_CANNON")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_EXHAUSTION")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_FALL")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_EXPLOSION")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_BLEEDING")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_DROWNING_IN_VEHICLE")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_DROWNING")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_BARBED_WIRE")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_VEHICLE_ROCKET")] = "WT_INVALID",
            [(uint)GetHashKey("WEAPON_SNSPISTOL_MK2")] = "WT_SNSPISTOL2",
            [(uint)GetHashKey("WEAPON_REVOLVER_MK2")] = "WT_REVOLVER2",
            [(uint)GetHashKey("WEAPON_DOUBLEACTION")] = "WT_REV_DA",
            [(uint)GetHashKey("WEAPON_SPECIALCARBINE_MK2")] = "WT_SPCARBINE2",
            [(uint)GetHashKey("WEAPON_BULLPUPRIFLE_MK2")] = "WT_BULLRIFLE2",
            [(uint)GetHashKey("WEAPON_PUMPSHOTGUN_MK2")] = "WT_SG_PMP2",
            [(uint)GetHashKey("WEAPON_MARKSMANRIFLE_MK2")] = "WT_MKRIFLE2",
            [(uint)GetHashKey("WEAPON_POOLCUE")] = "WT_POOLCUE",
            [(uint)GetHashKey("WEAPON_WRENCH")] = "WT_WRENCH",
            [(uint)GetHashKey("WEAPON_BATTLEAXE")] = "WT_BATTLEAXE",
            [(uint)GetHashKey("WEAPON_MINISMG")] = "WT_MINISMG",
            [(uint)GetHashKey("WEAPON_BULLPUPRIFLE")] = "WT_BULLRIFLE",
            [(uint)GetHashKey("WEAPON_AUTOSHOTGUN")] = "WT_AUTOSHGN",
            [(uint)GetHashKey("WEAPON_RAILGUN")] = "WT_RAILGUN",
            [(uint)GetHashKey("WEAPON_COMPACTLAUNCHER")] = "WT_CMPGL",
            [(uint)GetHashKey("WEAPON_SNOWBALL")] = "WT_SNWBALL",
            [(uint)GetHashKey("WEAPON_PIPEBOMB")] = "WT_PIPEBOMB",
            [(uint)GetHashKey("GADGET_NIGHTVISION")] = "WT_NV",
            [(uint)GetHashKey("GADGET_PARACHUTE")] = "WT_PARA",
            [(uint)GetHashKey("WEAPON_STONE_HATCHET")] = "WT_SHATCHET",
            [(uint)GetHashKey("COMPONENT_AT_PI_FLSH")] = "WCT_FLASH",
            [(uint)GetHashKey("COMPONENT_PISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_PISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_PI_SUPP_02")] = "WCT_SUPP",
            [(uint)GetHashKey("COMPONENT_PISTOL_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_COMBATPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_COMBATPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_PI_SUPP")] = "WCT_SUPP",
            [(uint)GetHashKey("COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_APPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_APPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_APPISTOL_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_PISTOL50_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_PISTOL50_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_AR_SUPP_02")] = "WCT_SUPP",
            [(uint)GetHashKey("COMPONENT_PISTOL50_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_SNSPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_SNSPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_SNSPISTOL_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_HEAVYPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_HEAVYPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_HEAVYPISTOL_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_VINTAGEPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_VINTAGEPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_MICROSMG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_MICROSMG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_MACRO")] = "WCT_SCOPE_MAC",
            [(uint)GetHashKey("COMPONENT_MICROSMG_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_SMG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_SMG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_SMG_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_MACRO_02")] = "WCT_SCOPE_MAC",
            [(uint)GetHashKey("COMPONENT_SMG_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_ASSAULTSMG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_ASSAULTSMG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_MINISMG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_MINISMG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_MACHINEPISTOL_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_MACHINEPISTOL_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_MACHINEPISTOL_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_COMBATPDW_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_COMBATPDW_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_COMBATPDW_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_AT_AR_AFGRIP")] = "WCT_GRIP",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_SMALL")] = "WCT_SCOPE_SML",
            [(uint)GetHashKey("COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_SAWNOFfsHOTGUN_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_ASSAULTSHOTGUN_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_ASSAULTSHOTGUN_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_ASSAULTRIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_ASSAULTRIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_ASSAULTRIFLE_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_ASSAULTRIFLE_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_CARBINERIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_CARBINERIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_CARBINERIFLE_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_MEDIUM")] = "WCT_SCOPE_MED",
            [(uint)GetHashKey("COMPONENT_CARBINERIFLE_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_ADVANCEDRIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_ADVANCEDRIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_SPECIALCARBINE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_SPECIALCARBINE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_SPECIALCARBINE_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_BULLPUPRIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_BULLPUPRIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_BULLPUPRIFLE_VARMOD_LOW")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_COMPACTRIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_COMPACTRIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_COMPACTRIFLE_CLIP_03")] = "WCT_CLIP_DRM",
            [(uint)GetHashKey("COMPONENT_MG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_MG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_MG_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_COMBATMG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_COMBATMG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_COMBATMG_VARMOD_LOWRIDER")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_GUSENBERG_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_GUSENBERG_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_LARGE")] = "WCT_SCOPE_LRG",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_MAX")] = "WCT_SCOPE_MAX",
            [(uint)GetHashKey("COMPONENT_SNIPERRIFLE_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("COMPONENT_MARKSMANRIFLE_CLIP_01")] = "WCT_CLIP1",
            [(uint)GetHashKey("COMPONENT_MARKSMANRIFLE_CLIP_02")] = "WCT_CLIP2",
            [(uint)GetHashKey("COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM")] = "WCT_SCOPE_LRG",
            [(uint)GetHashKey("COMPONENT_MARKSMANRIFLE_VARMOD_LUXE")] = "WCT_VAR_GOLD",
            [(uint)GetHashKey("WM_TINT0")] = "WM_TINT0",
            [(uint)GetHashKey("WM_TINT1")] = "WM_TINT1",
            [(uint)GetHashKey("WM_TINT2")] = "WM_TINT2",
            [(uint)GetHashKey("WM_TINT3")] = "WM_TINT3",
            [(uint)GetHashKey("WM_TINT4")] = "WM_TINT4",
            [(uint)GetHashKey("WM_TINT5")] = "WM_TINT5",
            [(uint)GetHashKey("WM_TINT6")] = "WM_TINT6",
            [(uint)GetHashKey("WM_TINT7")] = "WM_TINT7",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_BASE")] = "WCT_KNUCK_01",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_PIMP")] = "WCT_KNUCK_02",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_BALLAS")] = "WCT_KNUCK_BG",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_DOLLAR")] = "WCT_KNUCK_DLR",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_DIAMOND")] = "WCT_KNUCK_DMD",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_HATE")] = "WCT_KNUCK_HT",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_LOVE")] = "WCD_VAR_DESC",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_PLAYER")] = "WCT_KNUCK_PC",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_KING")] = "WCT_KNUCK_SLG",
            [(uint)GetHashKey("COMPONENT_KNUCKLE_VARMOD_VAGOS")] = "WCT_KNUCK_VG",
            [(uint)GetHashKey("COMPONENT_SWITCHBLADE_VARMOD_BASE")] = "WCT_SB_BASE",
            [(uint)GetHashKey("COMPONENT_SWITCHBLADE_VARMOD_VAR1")] = "WCT_SB_VAR1",
            [(uint)GetHashKey("COMPONENT_SWITCHBLADE_VARMOD_VAR2")] = "WCT_SB_VAR2"
        };

        public static string GetWeaponLabel(uint hash)
        {
            if (HASH_TO_LABEL.ContainsKey(hash))
            {
                string label = HASH_TO_LABEL[hash];

                if (label != null) return label;
            }
            else
            {
                ServerMain.Logger.Error("Hash error /" + hash.ToString() + "/ per weapon/component. Maybe it was never added?");
            }

            return "WT_INVALID";
        }

        public static bool IsPlayerAndHasPermission(int player, int level)
        {
            if (player != 0)
            {
                Player p = GetPlayerFromId(player);
                User Char = GetUserFromPlayerId(p.Handle);

                if ((int)Char.group_level >= level) return true;
            }

            return false;
        }

        public static List<PlayerClient> GetClosestClients(PlayerClient client, float radius)
        {
            return ServerMain.Instance.Clients.Where(x => Vector3.Distance(x.Ped.Position, client.Ped.Position) <= radius).ToList();
        }

        public static List<PlayerClient> GetClosestClients(Ped client, float radius)
        {
            return ServerMain.Instance.Clients.Where(x => Vector3.Distance(x.Ped.Position, client.Position) <= radius).ToList();
        }

        public static List<PlayerClient> GetClosestClients(Player client, float radius)
        {
            return ServerMain.Instance.Clients.Where(x => Vector3.Distance(x.Ped.Position, client.Character.Position) <= radius).ToList();
        }

        public static bool IsPlayerAndHasPermission(int player, UserGroup level)
        {
            if (player == 0) return false;
            Player p = GetPlayerFromId(player);
            User Char = GetUserFromPlayerId(p.Handle);

            return Char.group_level >= level;
        }

        public static bool IsPlayerAndHasPermission(Player player, int level)
        {
            User Char = GetUserFromPlayerId(player.Handle);

            return (int)Char.group_level >= level;
        }

        public static bool IsPlayerAndHasPermission(Player player, UserGroup level)
        {
            User Char = GetUserFromPlayerId(player.Handle);

            return Char.group_level >= level;
        }

        public static DateTime TimeStamp2DateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }

        public static double DateTime2TimeStamp(DateTime dateTime) { return (TimeZoneInfo.ConvertTimeToUtc(dateTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds; }

        public static User GetUserFromPlayerId(string id)
            => ServerMain.Instance.Clients.SingleOrDefault(x => id == x.Handle.ToString())?.User;

        public static User GetUserFromPlayerId(int id)
            => ServerMain.Instance.Clients.SingleOrDefault(x => id == x.Handle)?.User;

        public static PlayerClient GetClientFromPlayerId(int id)
            => ServerMain.Instance.Clients.SingleOrDefault(x => id == x.Handle);

        public static PlayerClient GetClientFromPlayerId(string id)
            => ServerMain.Instance.Clients.SingleOrDefault(x => id == x.Handle.ToString());

        public static User GetCurrentChar(this Player player)
            => ServerMain.Instance.Clients.SingleOrDefault(x => player.Handle == x.Handle.ToString()).User;
    }
}