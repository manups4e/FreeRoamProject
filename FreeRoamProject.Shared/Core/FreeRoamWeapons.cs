using FreeRoamProject.Shared.Core.Character;
using System.Collections.Generic;

namespace FreeRoamProject.Shared.Core.FREEROAM
{
    public static class FreeRoamWeapons
    {
        #region Weapons
        public static Dictionary<string, Weapon> Weapons = new Dictionary<string, Weapon>()
        {
            ["WEAPON_KNIFE"] = new(),
            ["WEAPON_NIGHTSTICK"] = new(),
            ["WEAPON_HAMMER"] = new(),
            ["WEAPON_BAT"] = new(),
            ["WEAPON_GOLFCLUB"] = new(),
            ["WEAPON_CROWBAR"] = new(),
            ["WEAPON_RPG"] = new(),
            ["WEAPON_STINGER"] = new(),
            ["WEAPON_MINIGUN"] = new(),
            ["WEAPON_GRENADE"] = new(),
            ["WEAPON_STICKYBOMB"] = new(),
            ["WEAPON_SMOKEGRENADE"] = new(),
            ["WEAPON_BZGAS"] = new(),
            ["WEAPON_MOLOTOV"] = new(),
            ["WEAPON_FIREEXTINGUISHER"] = new(),
            ["WEAPON_PETROLCAN"] = new(),
            ["WEAPON_DIGISCANNER"] = new(),
            ["WEAPON_BALL"] = new(),
            ["WEAPON_BOTTLE"] = new(),
            ["WEAPON_DAGGER"] = new(),
            ["WEAPON_FIREWORK"] = new(),
            ["WEAPON_MUSKET"] = new(),
            ["WEAPON_STUNGUN"] = new(),
            ["WEAPON_HOMINGLAUNCHER"] = new(),
            ["WEAPON_PROXMINE"] = new(),
            ["WEAPON_SNOWBALL"] = new(),
            ["WEAPON_FLAREGUN"] = new(),
            ["WEAPON_GARBAGEBAG"] = new(),
            ["WEAPON_HANDCUFfs"] = new(),
            ["WEAPON_MARKSMANPISTOL"] = new(),
            ["WEAPON_HATCHET"] = new(),
            ["WEAPON_RAILGUN"] = new(),
            ["WEAPON_MACHETE"] = new(),
            ["WEAPON_DBSHOTGUN"] = new(),
            ["WEAPON_AUTOSHOTGUN"] = new(),
            ["WEAPON_BATTLEAXE"] = new(),
            ["WEAPON_COMPACTLAUNCHER"] = new(),
            ["WEAPON_PIPEBOMB"] = new(),
            ["WEAPON_POOLCUE"] = new(),
            ["WEAPON_WRENCH"] = new(),
            ["WEAPON_FLASHLIGHT"] = new(),
            ["GADGET_NIGHTVISION"] = new(),
            ["WEAPON_FLARE"] = new(),
            ["WEAPON_DOUBLEACTION"] = new(),
            ["WEAPON_PISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_PISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_PISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP_02", active = false},
                    new() {name = "COMPONENT_PISTOL_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_COMBATPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_COMBATPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_COMBATPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP", active = false},
                    new() {name = "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_APPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_APPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_APPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP_02", active = false},
                    new() {name = "COMPONENT_APPISTOL_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_PISTOL50"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_PISTOL50_CLIP_01", active = true},
                    new() {name = "COMPONENT_PISTOL50_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_PISTOL50_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_REVOLVER"] = new()
            {
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_SNSPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_SNSPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_SNSPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_HEAVYPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_HEAVYPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_HEAVYPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP", active = false},
                    new() {name = "COMPONENT_HEAVYPISTOL_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_VINTAGEPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_VINTAGEPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_VINTAGEPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MICROSMG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_MICROSMG_CLIP_01", active = true},
                    new() {name = "COMPONENT_MICROSMG_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_PI_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MACRO", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_MICROSMG_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_SMG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_SMG_CLIP_01", active = true},
                    new() {name = "COMPONENT_SMG_CLIP_01", active = false},
                    new() {name = "COMPONENT_SMG_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MACRO_02", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP", active = false},
                    new() {name = "COMPONENT_SMG_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_ASSAULTSMG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_ASSAULTSMG_CLIP_01", active = true},
                    new() {name = "COMPONENT_ASSAULTSMG_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP_02", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MACRO", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MINISMG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_MINISMG_CLIP_01", active = true},
                    new() {name = "COMPONENT_MINISMG_CLIP_02", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MACHINEPISTOL"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_MACHINEPISTOL_CLIP_01", active = true},
                    new() {name = "COMPONENT_MACHINEPISTOL_CLIP_02", active = false},
                    new() {name = "COMPONENT_MACHINEPISTOL_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_PI_SUPP", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_COMBATPDW"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_COMBATPDW_CLIP_01", active = true},
                    new() {name = "COMPONENT_COMBATPDW_CLIP_02", active = false},
                    new() {name = "COMPONENT_COMBATPDW_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_SMALL", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_PUMPSHOTGUN"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SR_SUPP", active = false},
                    new() {name = "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_SAWNOFfsHOTGUN"] = new()
            {
                components = { new() { name = "COMPONENT_SAWNOFfsHOTGUN_VARMOD_LUXE", active = false } },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_ASSAULTSHOTGUN"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_ASSAULTSHOTGUN_CLIP_01", active = true},
                    new() {name = "COMPONENT_ASSAULTSHOTGUN_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_BULLPUPSHOTGUN"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_HEAVYSHOTGUN"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_HEAVYSHOTGUN_CLIP_01", active = true},
                    new() {name = "COMPONENT_HEAVYSHOTGUN_CLIP_02", active = false},
                    new() {name = "COMPONENT_HEAVYSHOTGUN_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_ASSAULTRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_ASSAULTRIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_ASSAULTRIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_ASSAULTRIFLE_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MACRO", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_CARBINERIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_CARBINERIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_CARBINERIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_CARBINERIFLE_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MEDIUM", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_CARBINERIFLE_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_ADVANCEDRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_ADVANCEDRIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_ADVANCEDRIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_SMALL", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP", active = false},
                    new() {name = "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_SPECIALCARBINE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_SPECIALCARBINE_CLIP_01", active = true},
                    new() {name = "COMPONENT_SPECIALCARBINE_CLIP_02", active = false},
                    new() {name = "COMPONENT_SPECIALCARBINE_CLIP_03", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MEDIUM", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_BULLPUPRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_BULLPUPRIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_BULLPUPRIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_SMALL", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_BULLPUPRIFLE_VARMOD_LOW", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_COMPACTRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_COMPACTRIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_COMPACTRIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_COMPACTRIFLE_CLIP_03", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_MG_CLIP_01", active = true},
                    new() {name = "COMPONENT_MG_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_SMALL_02", active = false},
                    new() {name = "COMPONENT_MG_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_COMBATMG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_COMBATMG_CLIP_01", active = true},
                    new() {name = "COMPONENT_COMBATMG_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MEDIUM", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_COMBATMG_VARMOD_LOWRIDER", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_GUSENBERG"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_GUSENBERG_CLIP_01", active = true},
                    new() {name = "COMPONENT_GUSENBERG_CLIP_02", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_SNIPERRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_AT_SCOPE_LARGE", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MAX", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP_02", active = false},
                    new() {name = "COMPONENT_SNIPERRIFLE_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_HEAVYSNIPER"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_AT_SCOPE_LARGE", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_MAX", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MARKSMANRIFLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_MARKSMANRIFLE_CLIP_01", active = true},
                    new() {name = "COMPONENT_MARKSMANRIFLE_CLIP_02", active = false},
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM", active = false},
                    new() {name = "COMPONENT_AT_AR_SUPP", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_GRENADELAUNCHER"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_AT_AR_FLSH", active = false},
                    new() {name = "COMPONENT_AT_AR_AFGRIP", active = false},
                    new() {name = "COMPONENT_AT_SCOPE_SMALL", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_RPG"] = new()
            {
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_STINGER"] = new()
            {
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_MINIGUN"] = new()
            {
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
            ["WEAPON_KNUCKLE"] = new()
            {
                components =
                {
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_BASE", active = true},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_PIMP", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_BALLAS", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_DOLLAR", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_DIAMOND", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_HATE", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_LOVE", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_PLAYER", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_KING", active = false},
                    new() {name = "COMPONENT_KNUCKLE_VARMOD_VAGOS", active = false}
                },
                tints =
                {
                    new() {name = "WM_TINT0", value = 0}, new() {name = "WM_TINT1", value = 1},
                    new() {name = "WM_TINT2", value = 2}, new() {name = "WM_TINT3", value = 3},
                    new() {name = "WM_TINT4", value = 4}, new() {name = "WM_TINT5", value = 5},
                    new() {name = "WM_TINT6", value = 6}, new() {name = "WM_TINT7", value = 7}
                }
            },
        };
        #endregion

    }

    public class Weapon
    {
        public string? name;
        public List<Components> components = new List<Components>();
        public List<Tints> tints = new List<Tints>();
        public Weapon() { }
        public Weapon(string _name, List<Components> _comp, List<Tints> _tints)
        {
            name = _name;
            components = _comp;
            tints = _tints;
        }
    }
}
