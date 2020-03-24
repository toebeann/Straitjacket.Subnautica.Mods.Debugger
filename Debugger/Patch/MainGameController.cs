using Harmony;
using UnityEngine;

namespace Straitjacket.Subnautica.Mods.Debugger.Patch
{
    [HarmonyPatch(typeof(MainGameController))]
    [HarmonyPatch("Update")]
    static class MainGameController_Update
    {
        static void Postfix(MainGameController __instance)
        {
            if (Input.GetKeyDown(Debugger.Options.ToggleDebuggerVisibilityKey))
            {
                Debugger.Enabled = !Debugger.Enabled;
            }

            if (!WaitScreen.main.isShown
                && Input.GetKeyDown(Debugger.Options.TogglePauseKey))
            {
                Debugger.TogglePause();
            }

            if (Debugger.Paused)
            {
                UWE.Utils.lockCursor = false;
            }
        }
    }
}
