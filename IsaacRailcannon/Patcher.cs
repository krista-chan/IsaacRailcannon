using HarmonyLib;
using UnityEngine;

namespace UltraIsaacAudio
{
    public static class Patcher
    {
        public static void Patch()
        {
            var h = new Harmony("com.ultrakill.patch.isaac");
            h.PatchAll();

            Plugin.Log.LogInfo("Applied harmony patches");
        }
    }

    [HarmonyPatch(typeof(Railcannon), "OnEnable")]
    internal class Patch01
    {
        static void Postfix(Railcannon __instance)
        {
            AudioClip clip = Plugin.AudioAssetBundle.LoadAsset<AudioClip>("dogma_brimstone_short_(no head).wav"); 
            __instance.fireSound.GetComponent<AudioSource>().clip = clip;
        }
    }
}