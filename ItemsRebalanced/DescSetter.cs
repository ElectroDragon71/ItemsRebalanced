using R2API;
using System;

namespace ItemsRebalanced
{
    public class DescSetter
    {
        public static string BisonSteakName = "FLATHEALTH";
        public static string StunGrenadeName = "STUNCHANCEONHIT";
        public static void SetDesc()
        {
            string itemPrefix = "ITEM_";
            string pickupSuffix = "_PICKUP";
            string descSuffix = "_DESC";

            //if (ItemsRebalancedConfig.EnableStunGrenadeRework.Value == 1)
            //{
            //    string StunGrenadeInfo = "5% ".Style(DescColors.Color.cIsUtility) + "(+5% on stack) ".Style(DescColors.Color.cStack) + "chance on hit to " + "stun ".Style(DescColors.Color.cIsUtility) + "enemies for " + "2 seconds".Style(DescColors.Color.cIsUtility) + ".";
            //    LanguageAPI.Add(itemPrefix + StunGrenadeName + pickupSuffix, StunGrenadeInfo);
            //    LanguageAPI.Add(itemPrefix + StunGrenadeName + descSuffix, StunGrenadeInfo);
            //}
            if (ItemsRebalancedConfig.EnableBisonSteakRework.Value == 1)
            {
                string BisonSteakInfo = "While above " + "90% health ".Style(DescColors.Color.cIsHealth) + ", increase " + "movement speed ".Style(DescColors.Color.cIsUtility) + "by " + "28% ".Style(DescColors.Color.cIsUtility) + "(+28% per stack)".Style(DescColors.Color.cStack) + ".";
                LanguageAPI.Add(itemPrefix + BisonSteakName + pickupSuffix, BisonSteakInfo);
                LanguageAPI.Add(itemPrefix + BisonSteakName + descSuffix, BisonSteakInfo);
            }
        }
    }
}