using System.Linq;
using SMLHelper.V2.Handlers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Straitjacket.Subnautica.Mods.Debugger
{
    internal class Debugger
    {
        public static GameObject GameObject;
        public static Harmony.Debugger HarmonyDebugger;
        private static bool enabled = false;
        public static bool Enabled
        {
            get => HarmonyDebugger.enabled || enabled;
            set => HarmonyDebugger.enabled = enabled = value;
        }
        
        public static Options Options = new Options();

        public static void Initialise()
        {
            OptionsPanelHandler.RegisterModOptions(Options);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private static void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (new string[] { "Main", "StartScreen" }.Contains(scene.name))
            {
                GameObject = new GameObject();
                HarmonyDebugger = GameObject.AddComponent<Harmony.Debugger>();
                if (scene.name == "StartScreen")
                {
                    Enabled = false;
                }
            }
        }
    }
}
