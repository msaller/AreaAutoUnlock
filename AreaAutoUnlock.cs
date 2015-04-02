using System;
using System.IO;
using System.Reflection;
using ICities;
using UnityEngine;
using ColossalFramework.Plugins;

namespace AreaAutoUnlock
{


    public class AreaAutoUnlock : IUserMod
    {
        public void OnLoad()
        {

        }

        public void OnUnload()
        {
        }

        public string Name
        {
            get { return "TileAutoBuy"; }
        }

        public string Description
        {
            get { return "Automatically unlock all 25 areas"; }
        }
    }

    public class AreaAutoUnlockAreasExtension : AreasExtensionBase
    {
        public override void OnCreated(IAreas areas)
        {
            areas.maxAreaCount = 25;
        }
    }

    public class AreaAutoUnlockLoadingExtension : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode != LoadMode.NewGame)
                return;

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
    }
}