using UnityEngine;
using RoR2;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using R2API;
using System.Collections.Generic;
using System;
using RoR2.Items;
using ItemsRebalanced.Items.Common;

namespace ItemsRebalanced.Items.Behavior
{
    public class BisonSteakBehavior : BaseItemBodyBehavior
    {
        [ItemDefAssociation(useOnServer = true, useOnClient = false)]
        public static ItemDef GetItemDef()
        {
            if (BisonSteak.Rework.Value > 1)
            {
                return RoR2Content.Items.FlatHealth;
            }
            else return null;
        }

        private void FixedUpdate()
        {

        }
    }
}