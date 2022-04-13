using System;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using System.IO;

namespace UltraIsaacAudio
{
    [BepInPlugin("com.ultrakill.isaacrailcannon", "IsaacRailcannon", "0.1.0")]
    [BepInProcess("ULTRAKILL.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private static readonly string BaseDirectory = Directory.GetParent(Application.dataPath).FullName;
        internal static ManualLogSource Log;
        internal static readonly AssetBundle AudioAssetBundle = AssetBundle.LoadFromFile(Path.Combine(BaseDirectory, "BepInEx/plugins/IsaacRailcannon/Assets/IsaacRailcannon"));

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo("Loaded plugin");
        }

        private void Start()
        {
            Patcher.Patch();
        }
    }
}