using System;
using System.Collections.Generic;
using HarmonyLib;

namespace MarryPoppins.Patches
{

    [HarmonyPatch(typeof(UmbrellaItem))]
    [HarmonyPatch("OnActivate", MethodType.Normal)]
    class LateUpdatePatch
    {
        public static void Postfix(UmbrellaItem __instance)
        {
            if (__instance.myOnlineRig.photonView.Owner == Photon.Pun.PhotonNetwork.LocalPlayer)
            {
                if (__instance.myState == 1) Plugin.umbrellaOpened = true;
                if (__instance.myState == 0) Plugin.umbrellaOpened = false;
            }
        }
    }
}