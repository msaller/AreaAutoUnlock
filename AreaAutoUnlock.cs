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
            get { return "AreaAutoUnlock"; }
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
        public override bool OnCanUnlockArea(int x, int z, bool originalResult)
        {
            return true;
        }
    }

    public class AreaAutoUnlockLoadingExtension : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode != LoadMode.NewGame)
                return;

            // set unlockproperties to null temporarily so the unlock check won't fail
            var propertiesTemp = UnlockManager.instance.m_properties;
            UnlockManager.instance.m_properties = null;

            // buy tiles to 0, 0
            GameAreaManager.instance.UnlockArea(7);
            GameAreaManager.instance.UnlockArea(2);
            GameAreaManager.instance.UnlockArea(1);
            GameAreaManager.instance.UnlockArea(0);

            // buy the rest
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    GameAreaManager.instance.UnlockArea(x*5 + y);
                }
            }

            UnlockManager.instance.m_properties = propertiesTemp;
        }
    }
}