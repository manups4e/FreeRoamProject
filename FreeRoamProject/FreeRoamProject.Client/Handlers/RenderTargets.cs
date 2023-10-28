namespace FreeRoamProject.Client
{
    internal static class RenderTargets
    {
        public static int CreateNamedRenderTargetForModel(string name, uint model)
        {
            int handle = 0;
            if (!IsNamedRendertargetRegistered(name)) RegisterNamedRendertarget(name, false);
            if (!IsNamedRendertargetLinked(model)) LinkNamedRendertarget(model);
            if (IsNamedRendertargetRegistered(name)) handle = GetNamedRendertargetRenderId(name);

            return handle;
        }

        public static string GetTargetFromObjHash(ObjectHash target)
        {
            switch (target)
            {
                case ObjectHash.v_ilev_cin_screen:
                    return "cinscreen";
                case ObjectHash.apa_prop_ap_port_text:
                    return "port_text";
                case ObjectHash.apa_prop_ap_starb_text:
                    return "starb_text";
                case ObjectHash.apa_prop_ap_stern_text:
                    return "stern_text";
                case ObjectHash.prop_npc_phone:
                    return "npcphone";
                case ObjectHash.prop_monitor_01b:
                case ObjectHash.prop_laptop_lester2:
                case ObjectHash.prop_tv_flat_02:
                case ObjectHash.prop_tv_flat_02b:
                case ObjectHash.prop_tv_03:
                case ObjectHash.prop_tv_03_overlay:
                case ObjectHash.prop_tv_flat_01:
                case ObjectHash.prop_tv_flat_01_screen:
                case ObjectHash.des_tvsmash_start:
                case ObjectHash.v_ilev_mm_scre_off:
                case ObjectHash.v_ilev_mm_screen2:
                case ObjectHash.v_ilev_mm_screen2_vl:
                case ObjectHash.prop_trev_tv_01:
                case ObjectHash.prop_tt_screenstatic:
                case ObjectHash.prop_tv_flat_michael:
                    return "tvscreen";
                case ObjectHash.w_am_digiscanner:
                    return "digiscanner";
                case ObjectHash.prop_huge_display_01:
                case ObjectHash.prop_huge_display_02:
                    return "big_Disp";
                case ObjectHash.prop_ecg_01:
                    return "ECG";
                case ObjectHash.prop_taxi_meter_1:
                case ObjectHash.prop_taxi_meter_2:
                    return "taxi";
            }

            return null;
        }
    }
}