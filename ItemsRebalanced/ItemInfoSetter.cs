using ItemsRebalanced.Items.Common;
using R2API;

namespace ItemsRebalanced
{
    public class ItemInfoSetter
    {
        // Sets the item descriptions
        public ItemInfoSetter()
        {
            // Commons

            // Bison Steak
            if (BisonSteak.Rework.Value > 0)
            {
                SetDesc(new BisonSteak(BisonSteak.Rework.Value));
            }
        }

        // Sets Description and Name
        private static void SetDesc(ItemBase Item)
        {
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_PICKUP", Item.ItemDesc);
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_DESC", Item.ItemDesc);
            LanguageAPI.Add("ITEM_" + Item.ItemInternalName + "_NAME", Item.ItemName);
        }
    }

    // The base class for items
    internal class ItemBase
    {
        public string ItemName;
        public string ItemInternalName;
        public string ItemDesc;
    }
}