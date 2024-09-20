using BepInEx;
using BepInEx.Configuration;

namespace ItemsRebalanced
{
    public static class ItemsRebalancedConfig
    {
        // Commons
        public static ConfigEntry<int> EnableStunGrenadeRework { get; set; }
        public static ConfigEntry<int> EnableBisonSteakRework { get; set; }

        // Uncommons
        public static ConfigEntry<int> EnableLeechingSeedRework { get; set; }

        // Legendarys
        public static ConfigEntry<int> EnableAegisRework { get; set; }

        // Boss
        public static ConfigEntry<int> EnableTitanicKnurlRework { get; set; }

        // Void
        public static ConfigEntry<int> EnableLostSeersLensesRework { get; set; }

        public static void SetUpConfigs(BaseUnityPlugin plugin)
        {
            CommonConfig(plugin);
            //UncommonConfig(plugin);
            //LegendaryConfig(plugin);
            //BossConfig(plugin);
            //VoidConfig(plugin);
        }

        public static void CommonConfig(BaseUnityPlugin plugin)
        {
            // Stun Grenade
            //EnableStunGrenadeRework = plugin.Config.Bind(
            //    "Stun Grenade",
            //    "Toggle Rework", 1,
            //    new ConfigDescription(
            //        "[ 0 = Disabled | 1 = Enabled ]",
            //        new AcceptableValueRange<int>(0, 1)
            //    )
            //);

            // Bison Steak
            EnableBisonSteakRework = plugin.Config.Bind(
                "Bison Steak",
                "Toggle Rework", 1,
                new ConfigDescription(
                    "[ 0 = Disabled | 1 = Enabled ]",
                    new AcceptableValueRange<int>(0, 1)
                )
            );
        }

        public static void UncommonConfig(BaseUnityPlugin plugin)
        {
            // Leeching Seed
            EnableLeechingSeedRework = plugin.Config.Bind(
                "Leeching Seed",
                "Toggle Rework", 1,
                new ConfigDescription(
                    "[ 0 = Disabled | 1 = Enabled ]",
                    new AcceptableValueRange<int>(0, 1)
                )
            );
        }
        public static void LegendaryConfig(BaseUnityPlugin plugin)
        {
            // Aegis
            EnableAegisRework = plugin.Config.Bind(
                "Aegis",
                "Toggle Rework", 1,
                new ConfigDescription(
                    "[ 0 = Disabled | 1 = Enabled ]",
                    new AcceptableValueRange<int>(0, 1)
                )
            );
        }

        public static void BossConfig(BaseUnityPlugin plugin)
        {
            // Titanic Knurl
            EnableTitanicKnurlRework = plugin.Config.Bind(
                "TitanicKnurl",
                "Toggle Rework", 1,
                new ConfigDescription(
                    "[ 0 = Disabled | 1 = Enabled ]",
                    new AcceptableValueRange<int>(0, 1)
                )
            );
        }

        public static void VoidConfig(BaseUnityPlugin plugin)
        {
            // Lost Seer's Lenses
            EnableLostSeersLensesRework = plugin.Config.Bind(
                "Lost Seer's Lenses",
                "Toggle Rework", 1,
                new ConfigDescription(
                    "[ 0 = Disabled | 1 = Enabled ]",
                    new AcceptableValueRange<int>(0, 1)
                )
            );
        }
    }
}
