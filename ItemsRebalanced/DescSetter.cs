using R2API;
using System;

namespace ItemsRebalanced
{
    public class DescSetter
    {
        public static string BisonSteakName = "FLATHEALTH";
        public static void SetDesc(string itemPrefix = "ITEM_")
        {
            if (ItemsRebalancedConfig.EnableBisonSteakRework.Value == 1)
            {
                string BisonSteakInfo = "While above " + "90% health ".Style(DescColors.Color.cIsHealth) + ", increase " + "movement speed ".Style(DescColors.Color.cIsUtility) + "by " + "30% ".Style(DescColors.Color.cIsUtility) + "(+30% per stack)".Style(DescColors.Color.cStack) + ".";
                LanguageAPI.Add(itemPrefix + BisonSteakName + "_PICKUP", BisonSteakInfo);
                LanguageAPI.Add(itemPrefix + BisonSteakName + "_DESC", BisonSteakInfo);
            }
        }
    }
}