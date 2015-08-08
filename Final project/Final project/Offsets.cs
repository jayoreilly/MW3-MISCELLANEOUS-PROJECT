using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiwi_modz
{
    class Offsets
    {
        public static UInt32 Add_Ammo = 0x18a29c;
        public static UInt32 BG_GetWeaponIndexForName = 0x3d434;
        public static UInt32 BG_TakePlayerWeapon = 0x1c409c;
        public static UInt32 ButtonMonitoring = 0x158;
        public static UInt32 cl_ingame = 0x7f0734;
        public static UInt32 ClientAssists = 0x3324;
        public static UInt32 ClientDeaths = 0x331c;
        public static UInt32 ClientKills = 0x3320;
        public static UInt32 ClientName = 0x338c;
        public static UInt32 FuncAddr = 0x277208;
        public static UInt32 G_Client = 0x110a280;
        public static UInt32 G_ClientSize = 0x3980;
        public static UInt32 G_Entity = 0xfca280;
        public static UInt32 G_EntitySize = 640;
        public static UInt32 G_GivePlayerWeapon = 0x1c3034;
        public static UInt32 G_HudElems = 0xf0e10c;
        public static UInt32 G_InitializeAmmo = 0x18a29c;
        public static UInt32 G_LocalizedStringIndex = 0x1be6cc;
        public static UInt32 G_MaterialIndex = 0x1be744;
        public static UInt32 G_SetModel = 0x1bef5c;
        public static UInt32 HudelemSize = 0xb8;
        public static UInt32 Lethal = 0x41b;
        public static UInt32 LevelTime = 0xfc3db0;
        public static UInt32 mFlag = 0x35fc;
        public static UInt32 PlayerName = 0x1bbbc2c;
        public static UInt32 PrimaryWeapon = 0x27c;
        public static UInt32 RedBoxes = 0x13;
        public static UInt32 SecondaryWeapon = 0x274;
        public static UInt32 SV_GameSendServerCommand = 0x228fa8;
        public static UInt32 SV_ExecuteClientCommand = 0x228178;
        public static UInt32 Tactial = 0x283;
        public static UInt32 Team = 0x33d4;

        public class Funcs
        {
            public static UInt32 G_Client(Int32 clientIndex, UInt32 Mod = 0)
            {
                return ((Offsets.G_Client + Mod) + ((UInt32)(Offsets.G_ClientSize * clientIndex)));
            }

            public static UInt32 G_Entity(Int32 clientIndex, UInt32 Mod = 0)
            {
                return ((Offsets.G_Entity + Mod) + ((UInt32)(Offsets.G_EntitySize * clientIndex)));
            }
        }

        public class Weapons
        {
            public static String weapon_minigun = "weapon_minigun";
            public static String ac130_105mm_mp = "ac130_105mm_mp";
            public static String ac130_25mm_mp = "ac130_25mm_mp";
            public static String ac130_40mm_mp = "ac130_40mm_mp";
            public static String airdrop_escort_marker_mp = "airdrop_escort_marker_mp";
            public static String airdrop_juggernaut_mp = "airdrop_juggernaut_mp";
            public static String airdrop_marker_mp = "airdrop_marker_mp";
            public static String airdrop_sentry_marker_mp = "airdrop_sentry_marker_mp";
            public static String airdrop_tank_marker_mp = "airdrop_tank_marker_mp";
            public static String airdrop_trap_explosive_mp = "airdrop_trap_explosive_mp";
            public static String airdrop_trap_marker_mp = "airdrop_trap_marker_mp";
            public static String apache_minigun_mp = "apache_minigun_mp";
            public static String artillery_mp = "artillery_mp";
            public static String bomb_site_mp = "bomb_site_mp";
            public static String bouncingbetty_mp = "bouncingbetty_mp";
            public static String briefcase_bomb_defuse_mp = "briefcase_bomb_defuse_mp";
            public static String briefcase_bomb_mp = "briefcase_bomb_mp";
            public static String c4_mp = "c4_mp";
            public static String c4death_mp = "c4death_mp";
            public static String claymore_mp = "claymore_mp";
            public static String cobra_20mm_mp = "cobra_20mm_mp";
            public static String concussion_grenade_mp = "concussion_grenade_mp";
            public static String defaultweapon_mp = "defaultweapon_mp";
            public static String deployable_vest_marker_mp = "deployable_vest_marker_mp";
            public static String destructible_car = "destructible_car";
            public static String destructible_toy = "destructible_toy";
            public static String emp_grenade_mp = "emp_grenade_mp";
            public static String flare_mp = "flare_mp";
            public static String flash_grenade_mp = "flash_grenade_mp";
            public static String frag_grenade_mp = "frag_grenade_mp";
            public static String frag_grenade_short_mp = "frag_grenade_short_mp";
            public static String harrier_20mm_mp = "harrier_20mm_mp";
            public static String harrier_ffar_mp = "harrier_ffar_mp";
            public static String harrier_missile_mp = "harrier_missile_mp";
            public static String heli_remote_mp = "heli_remote_mp";
            public static String ims_projectile_mp = "ims_projectile_mp";
            public static String iw5__usp45_mp = "iw5_usp45_mp";
            public static String iw5_1887_mp = "iw5_1887_mp";
            public static String iw5_196a1_mp = "iw5_l96a1_mp";
            public static String iw5_44magnum_mp = "iw5_44magnum_mp";
            public static String iw5_aa12_mp = "iw5_aa12_mp";
            public static String iw5_acr_mp = "iw5_acr_mp";
            public static String iw5_ak7_mp = "iw5_ak47_mp";
            public static String iw5_as50_mp = "iw5_as50_mp";
            public static String iw5_barrett_mp = "iw5_barrett_mp";
            public static String iw5_cm901_mp = "iw5_cm901_mp";
            public static String iw5_deserteagle_mp = "iw5_deserteagle_mp";
            public static String iw5_dragunov_mp = "iw5_dragunov_mp";
            public static String iw5_fad_mp = "iw5_fad_mp";
            public static String iw5_fmg9_mp = "iw5_fmg9_mp";
            public static String iw5_fnfiveseven_mp = "iw5_fnfiveseven_mp";
            public static String iw5_g18_mp = "iw5_g18_mp";
            public static String iw5_g36c_mp = "iw5_g36c_mp";
            public static String iw5_gl_mp = "gl_mp";
            public static String iw5_javelin_mp = "javelin_mp";
            public static String iw5_ksg_mp = "iw5_ksg_mp";
            public static String iw5_m16_mp = "iw5_m16_mp";
            public static String iw5_m320_mp = "m320_mp";
            public static String iw5_m4_mp = "iw5_m4_mp";
            public static String iw5_m60_mp = "iw5_m60_mp";
            public static String iw5_m60jugg_mp = "iw5_m60jugg_mp";
            public static String iw5_m9_mp = "iw5_m9_mp";
            public static String iw5_mg36_mp = "iw5_mg36_mp";
            public static String iw5_mk14_mp = "iw5_mk14_mp";
            public static String iw5_mk46_mp = "iw5_mk46_mp";
            public static String iw5_mp412_mp = "iw5_mp412_mp";
            public static String iw5_mp412jugg_mp = "iw5_mp412jugg_mp";
            public static String iw5_mp5_mp = "iw5_mp5_mp";
            public static String iw5_mp7_mp = "iw5_mp7_mp";
            public static String iw5_mp9_mp = "iw5_mp9_mp";
            public static String iw5_msr_mp = "iw5_msr_mp";
            public static String iw5_p90_mp = "iw5_p90_mp";
            public static String iw5_p99_mp = "iw5_p99_mp";
            public static String iw5_pecheneg_mp = "iw5_pecheneg_mp";
            public static String iw5_pp90m1_mp = "iw5_pp90m1_mp";
            public static String iw5_riotshieldjugg_mp = "iw5_riotshieldjugg_mp";
            public static String iw5_rpg_mp = "rpg_mp";
            public static String iw5_rsass_mp = "iw5_rsass_mp";
            public static String iw5_sa80_mp = "iw5_sa80_mp";
            public static String iw5_scar_mp = "iw5_scar_mp";
            public static String iw5_skorpion_mp = "iw5_skorpion_mp";
            public static String iw5_smaw_mp = "iw5_smaw_mp";
            public static String iw5_spas12_mp = "iw5_spas12_mp";
            public static String iw5_stinger_mp = "stinger_mp";
            public static String iw5_striker_mp = "iw5_striker_mp";
            public static String iw5_type95_mp = "iw5_type95_mp";
            public static String iw5_ump45_mp = "iw5_ump45_mp";
            public static String iw5_usas12_mp = "iw5_usas12_mp";
            public static String iw5_usp45jugg_mp = "iw5_usp45jugg_mp";
            public static String iw5_xm25_mp = "xm25_mp";
            public static String killstreak_ac130_mp = "killstreak_ac130_mp";
            public static String killstreak_counter_uav_mp = "killstreak_counter_uav_mp";
            public static String killstreak_emp_mp = "killstreak_emp_mp";
            public static String killstreak_helicopter_flares_mp = "killstreak_helicopter_flares_mp";
            public static String killstreak_helicopter_minigun_mp = "killstreak_helicopter_minigun_mp";
            public static String killstreak_helicopter_mp = "killstreak_helicopter_mp";
            public static String killstreak_ims_mp = "killstreak_ims_mp";
            public static String killstreak_precision_airstrike_mp = "killstreak_precision_airstrike_mp";
            public static String killstreak_predator_missile_mp = "killstreak_predator_missile_mp";
            public static String killstreak_remote_mortar_mp = "killstreak_remote_mortar_mp";
            public static String killstreak_remote_tank_laptop_mp = "killstreak_remote_tank_laptop_mp";
            public static String killstreak_remote_tank_mp = "killstreak_remote_tank_mp";
            public static String killstreak_remote_tank_remote_mp = "killstreak_remote_tank_remote_mp";
            public static String killstreak_remote_turret_laptop_mp = "killstreak_remote_turret_laptop_mp";
            public static String killstreak_remote_turret_mp = "killstreak_remote_turret_mp";
            public static String killstreak_remote_turret_remote_mp = "killstreak_remote_turret_remote_mp";
            public static String killstreak_remote_uav_mp = "killstreak_remote_uav_mp";
            public static String killstreak_sentry_mp = "killstreak_sentry_mp";
            public static String killstreak_stealth_airstrike_mp = "killstreak_stealth_airstrike_mp";
            public static String killstreak_triple_uav_mp = "killstreak_triple_uav_mp";
            public static String killstreak_uav_mp = "killstreak_uav_mp";
            public static String littlebird_20mm_mp = "littlebird_20mm_mp";
            public static String littlebird_guard_minigun_mp = "littlebird_guard_minigun_mp";
            public static String mortar_remote_mp = "mortar_remote_mp";
            public static String mortar_remote_zoom_mp = "mortar_remote_zoom_mp";
            public static String none = "none";
            public static String nuke_mp = "nuke_mp";
            public static String osprey_minigun_mp = "osprey_minigun_mp";
            public static String osprey_player_minigun_mp = "osprey_player_minigun_mp";
            public static String pavelow_minigun_mp = "pavelow_minigun_mp";
            public static String portable_radar_mp = "portable_radar_mp";
            public static String remote_mortar_missile_mp = "remote_mortar_missile_mp";
            public static String remote_tank_projectile_mp = "remote_tank_projectile_mp";
            public static String remote_turret_mp = "remote_turret_mp";
            public static String remotemissile_projectile_mp = "remotemissile_projectile_mp";
            public static String riotshield_mp = "riotshield_mp";
            public static String sam_mp = "sam_mp";
            public static String sam_projectile_mp = "sam_projectile_mp";
            public static String scavenger_bag_mp = "scavenger_bag_mp";
            public static String scrambler_mp = "scrambler_mp";
            public static String semtex_mp = "semtex_mp";
            public static String sentry_minigun_mp = "sentry_minigun_mp";
            public static String smoke_grenade_mp = "smoke_grenade_mp";
            public static String stealth_bomb_mp = "stealth_bomb_mp";
            public static String throwingknife_mp = "throwingknife_mp";
            public static String trophy_mp = "trophy_mp";
            public static String uav_remote_mp = "uav_remote_mp";
            public static String uav_strike_marker_mp = "uav_strike_marker_mp";
            public static String uav_strike_projectile_mp = "uav_strike_projectile_mp";
            public static String ugv_turret_mp = "ugv_turret_mp";
        }
    }
}
