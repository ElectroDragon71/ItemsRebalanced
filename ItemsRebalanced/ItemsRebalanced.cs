using BepInEx;
using R2API;
using RoR2;
//using On.RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using IL.RoR2;
//using IL.RoR2.Items;
using RoR2.Items;
using RoR2.Orbs;
using RoR2.Projectile;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using UnityEngine.UIElements.UIR;

namespace ItemsRebalanced
{
    // This attribute specifies that we have a dependency on a given BepInEx Plugin,
    // We need the R2API ItemAPI dependency because we are using for adding our item to the game.
    // You don't need this if you're not using R2API in your plugin,
    // it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
    [BepInDependency(ItemAPI.PluginGUID)]

    // This one is because we use a .language file for language tokens
    // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
    [BepInDependency(LanguageAPI.PluginGUID)]

    // This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    // This is the main declaration of our plugin class.
    // BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    // BaseUnityPlugin itself inherits from MonoBehaviour,
    // so you can use this as a reference for what you can declare and use in your plugin class
    // More information in the Unity Docs: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class ItemsRebalanced : BaseUnityPlugin
    {
        // The Plugin GUID should be a unique ID for this plugin,
        // which is human readable (as it is used in places like the config).
        // If we see this PluginGUID as it is on thunderstore,
        // we will deprecate this mod.
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Egglectro";
        public const string PluginName = "ItemsRebalanced";
        public const string PluginVersion = "0.0.1";

        // The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            // Init our logging class so that we can properly log for debugging
            Log.Init(Logger);
            ItemsRebalancedConfig.SetUpConfigs(this);
            DescSetter.SetDesc();

            // Common Items
            if (ItemsRebalancedConfig.EnableBisonSteakRework.Value == 1)
            {
                IL.RoR2.CharacterBody.RecalculateStats += (il) =>
                {
                    ILCursor c = new ILCursor(il);
                    c.GotoNext(
                        x => x.MatchLdloc(62),
                        x => x.MatchLdloc(36),
                        x => x.MatchConvR4(),
                        x => x.MatchLdcR4(25)
                    );
                    c.Index += 3;
                    c.Next.Operand = 0.0f;
                };
            }
        }
    }
}
