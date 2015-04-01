using System;
using System.Collections.Generic;
using System.Reflection;
using ColossalFramework.Plugins;
using ICities;
using UnityEngine;

namespace TileAutoBuy
{
    public class TileAutoBuyLoader : ILoadingExtension
    {

        private IManagers managers;

        public void OnLevelLoaded(LoadMode mode)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "TileAutoBuy goes");
            if (mode != LoadMode.NewGame)
                return;
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "TileAutoBuy goes +mode");

            // buy tiles to 0, 0
            this.managers.areas.UnlockArea(1, 2, false);
            this.managers.areas.UnlockArea(0, 2, false);
            this.managers.areas.UnlockArea(0, 1, false);
            this.managers.areas.UnlockArea(0, 0, false);

            // buy the rest
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    if (!this.managers.areas.IsAreaUnlocked(x, y))
                    {
                        this.managers.areas.UnlockArea(x, y, false);
                    }
                }
            }
        }

        public void OnCreated(ILoading loading)
        {
            this.managers = loading.managers;
        }

        public void OnLevelUnloading()
        {
        }

        public void OnReleased()
        {
        }
    }
}
