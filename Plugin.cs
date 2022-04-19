using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace MarryPoppins
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        bool gotGravity = false;
        public static bool umbrellaOpened;
        Vector3 originalGravity;

        private void resetGravity()
        {
            Physics.gravity = originalGravity;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            if (!gotGravity)
            {
                originalGravity = new Vector3(0f,-9.81f,0f);
                gotGravity = true;
            }
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            resetGravity();
        }

        void FixedUpdate()
        {
            if(inRoom)
            {
                if (umbrellaOpened) Physics.gravity = new Vector3(0f, -3.0f, 0f);
                else if (!umbrellaOpened) resetGravity();
            }
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
            resetGravity();
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
            resetGravity();
        }
    }
}
