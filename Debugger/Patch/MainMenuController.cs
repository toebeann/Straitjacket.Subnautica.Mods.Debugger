using Harmony;
using UnityEngine;

namespace Straitjacket.Subnautica.Mods.Debugger.Patch
{
    [HarmonyPatch(typeof(MainMenuController))]
    [HarmonyPatch("Update")]
    static class MainMenuController_Update
    {
        static void Postfix(MainMenuController __instance)
        {
            if (Input.GetKeyDown(Debugger.Options.ToggleDebuggerVisibilityKey))
            {
                Debugger.Enabled = !Debugger.Enabled;
            }

            if (Input.GetKeyDown(Debugger.Options.TogglePauseKey))
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
