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
            if (Input.GetKeyUp(Debugger.Options.ToggleDebuggerVisibilityKey))
            {
                Debugger.Enabled = !Debugger.Enabled;
            }

            if (!WaitScreen.main.isShown
                && Input.GetKeyUp(Debugger.Options.TogglePauseKey))
            {
                Debugger.TogglePause();
            }
        }
    }
}
