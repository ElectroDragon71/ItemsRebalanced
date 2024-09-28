using System;
using BepInEx;
using R2API;
using RoR2;
using On.RoR2;
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
using UnityEngine.Networking;
using ItemsRebalanced.Items.Common;

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
            new ItemInfoSetter();

            SetUpCommonItems();


            // Subscribe to health changes
            On.RoR2.HealthComponent.TakeDamage += OnTakeDamage;
            On.RoR2.HealthComponent.Heal += OnCharacterHeal;

        }

        private void SetUpCommonItems()
        {
            // Bison Steak
            if (BisonSteak.Rework.Value > 0)
            {
                // Remove Current Effect
                IL.RoR2.CharacterBody.RecalculateStats += (il) =>
                {
                    ILCursor c = new ILCursor(il);
                    if (c.TryGotoNext(
                        x => x.MatchLdloc(out _),
                        x => x.MatchLdloc(out _),
                        x => x.MatchConvR4(),
                        x => x.MatchLdcR4(out _)
                    ))
                    {
                        c.Index += 3;
                        c.Next.Operand = 0.0f;
                    }
                    else
                    {
                        Logger.LogWarning(BisonSteak.Name + " #0 - IL Fail #1");
                    }

                };

                // Add New Effect
                On.RoR2.CharacterBody.RecalculateStats += ReworkBisonSteak;
            }
        }

        // Called when a character takes damage
        private void OnTakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, RoR2.HealthComponent self, RoR2.DamageInfo damageInfo)
        {
            orig(self, damageInfo);

            // Force a stat recalculation after taking damage
            if (self.body)
            {
                self.body.RecalculateStats();
            }
        }

        // Called when a character heals
        private float OnCharacterHeal(On.RoR2.HealthComponent.orig_Heal orig, RoR2.HealthComponent self, float healAmount, RoR2.ProcChainMask procChainMask, bool nonRegen)
        {
            float result = orig(self, healAmount, procChainMask, nonRegen);

            // Force a stat recalculation after healing
            if (self.body)
            {
                self.body.RecalculateStats();
            }

            return result;
        }

        // Bison Steak New Effect
        private void ReworkBisonSteak(On.RoR2.CharacterBody.orig_RecalculateStats orig, RoR2.CharacterBody self)
        {
            orig(self);  // Call the original method to retain default functionality
            if (!NetworkServer.active) return;  // Ensure the effect only applies on the server side

            if (self.healthComponent != null)
            {
                // Get the item count for the Bison Steak
                int itemCount = self.inventory ? self.inventory.GetItemCount(RoR2.RoR2Content.Items.FlatHealth) : 0;
                if (itemCount > 0)
                {
                    // Calculate the current percentage of health
                    float percentHealth = self.healthComponent.health / self.healthComponent.fullHealth;

                    // Calculate the Bison Steak movement speed bonus (example: 21% per item)
                    float bisonSteakSpeedBonus = percentHealth >= 1f ? 0.21f * itemCount : 0f;

                    // Apply the speed bonus without overwriting existing move speed
                    float speedBonus = self.baseMoveSpeed * bisonSteakSpeedBonus;
                    self.moveSpeed += speedBonus;  // Add Bison Steak bonus to existing move speed

                    Logger.LogInfo($"Bison Steak rework activated. Item count: {itemCount}, Percent health: {percentHealth}, MoveSpeed: {self.moveSpeed}");
                }
            }
            else
            {
                Logger.LogWarning("HealthComponent is null, cannot apply Bison Steak rework.");
            }
        }


    }
}