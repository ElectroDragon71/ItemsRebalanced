using ItemsRebalanced.Items.Common;
using R2API;

namespace ItemsRebalanced
{
    public class ItemInfoSetter
    {
        public ItemInfoSetter()
        {
            if (BisonSteak.Rework.Value == 1)
            {
                SetDesc(new BisonSteak(BisonSteak.Rework.Value));
            }
        }
        //public static string BisonSteakName = "FLATHEALTH";
        //public static string StunGrenadeName = "STUNCHANCEONHIT";
        //string itemPrefix = "ITEM_";
        //string pickupSuffix = "_PICKUP";
        //string descSuffix = "_DESC";

        //    //if (ItemsRebalancedConfig.EnableStunGrenadeRework.Value == 1)
        //    //{
        //    //    string StunGrenadeInfo = "5% ".Style(DescColors.Color.cIsUtility) + "(+5% on stack) ".Style(DescColors.Color.cStack) + "chance on hit to " + "stun ".Style(DescColors.Color.cIsUtility) + "enemies for " + "2 seconds".Style(DescColors.Color.cIsUtility) + ".";
        //    //    LanguageAPI.Add(itemPrefix + StunGrenadeName + pickupSuffix, StunGrenadeInfo);
        //    //    LanguageAPI.Add(itemPrefix + StunGrenadeName + descSuffix, StunGrenadeInfo);
        //    //}
        //    if (ItemsRebalancedConfig.EnableBisonSteakRework.Value == 1)
        //    {
        //        string BisonSteakInfo = "While above " + "90% health ".Style(DescColors.Color.cIsHealth) + ", increase " + "movement speed ".Style(DescColors.Color.cIsUtility) + "by " + "28% ".Style(DescColors.Color.cIsUtility) + "(+28% per stack)".Style(DescColors.Color.cStack) + ".";
        //LanguageAPI.Add(itemPrefix + BisonSteakName + pickupSuffix, BisonSteakInfo);
        //        LanguageAPI.Add(itemPrefix + BisonSteakName + descSuffix, BisonSteakInfo);
        //    }
        private static void SetDesc(ItemBase Item)
        {
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_PICKUP", Item.ItemDesc);
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_DESC", Item.ItemDesc);
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_NAME", Item.ItemName);
        }
    }
    internal class ItemBase
    {
        public string ItemName;
        public string ItemInternalName;
        public string ItemDesc;
    }
}