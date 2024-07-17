using System;
using System.Collections.Generic;
using HarmonyLib;
using static TransferrableObject;

namespace MarryPoppins.Patches
{

    [HarmonyPatch(typeof(UmbrellaItem))]
    [HarmonyPatch("OnActivate", MethodType.Normal)]
    class LateUpdatePatch
    {
        public static void Postfix(UmbrellaItem __instance)
        {
            if (__instance.myOnlineRig.OwningNetPlayer.IsLocal)
            {
                if (__instance.itemState == ItemStates.State0) Plugin.umbrellaOpened = true;
                if (__instance.itemState == ItemStates.State1) Plugin.umbrellaOpened = false;
            }
        }
    }
}