using BepInEx.Configuration;
using System;
using static ItemsRebalanced.DescColors;

namespace ItemsRebalanced.Items.Common
{
    internal class BisonSteak : ItemBase
    {
        public BisonSteak(int Enabled)
        {
            ItemInternalName = "FLATHEALTH";
            ItemName = "Bison Steak";
            if (Enabled > 0)
            {
                ItemDesc = "While above " + "90% health ".Style(DescColors.Color.cIsHealth) + ", increase " + "movement speed ".Style(DescColors.Color.cIsUtility) + "by " + "28% ".Style(DescColors.Color.cIsUtility) + "(+28% per stack)".Style(DescColors.Color.cStack) + ".";
            }
            if (Enabled == 2)
            {
                ItemName = "Steak";
            }
        }
        public static ConfigEntry<int> Rework;
        public static string Name = "BisonSteak";
    }
}