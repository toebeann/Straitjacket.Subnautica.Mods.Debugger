using System.Reflection;
using Harmony;

namespace Straitjacket.Subnautica.Mods.Debugger
{
    internal class HarmonyPatcher
    {
        public static void ApplyPatches()
        {
            var harmony = HarmonyInstance.Create("com.tobeyblaber.straitjacket.subnautica.debugger.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Debugger.Initialise();
        }
    }
}
