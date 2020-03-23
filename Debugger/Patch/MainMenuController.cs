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
            if (Input.GetKeyUp(Debugger.Options.ToggleDebuggerVisibilityKey))
            {
                Debugger.Enabled = !Debugger.Enabled;
            }

            if (Input.GetKeyUp(Debugger.Options.TogglePauseKey))
            {
                Debugger.TogglePause();
            }
        }
    }
}
