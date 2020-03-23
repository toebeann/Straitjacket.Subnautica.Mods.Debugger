using System.Collections.Generic;
using System.Linq;
using SMLHelper.V2.Handlers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

namespace Straitjacket.Subnautica.Mods.Debugger
{
    internal class Debugger
    {
        public static GameObject GameObject;
        public static Harmony.Debugger HarmonyDebugger;

        public static Options Options = new Options();

        public static void Initialise()
        {
            OptionsPanelHandler.RegisterModOptions(Options);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private static bool enabled = false;
        public static bool Enabled
        {
            get => HarmonyDebugger.enabled || enabled;
            set => HarmonyDebugger.enabled = enabled = value;
        }
        private static void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (new List<string> { "Main", "StartScreen" }.Contains(scene.name))
            {
                GameObject = new GameObject();
                HarmonyDebugger = GameObject.AddComponent<Harmony.Debugger>();
                if (scene.name == "StartScreen")
                {
                    Enabled = false;
                }
            }
        }

        private static bool paused = false;
        private static bool lockCursor = false;
        public static void TogglePause()
        {
            paused = !paused;

            if (paused)
            {
                UWE.FreezeTime.Begin("debugPause");
                lockCursor = UWE.Utils.lockCursor;
                UWE.Utils.lockCursor = false;
                SetGrayscaleValue(1f);
            }
            else
            {
                SetGrayscaleValue(0f);
                UWE.Utils.lockCursor = lockCursor;
                UWE.FreezeTime.End("debugPause");
            }
        }

        private static void SetGrayscaleValue(float amount)
        {
            int allCamerasCount = Camera.allCamerasCount;
            if (uGUI_FeedbackCollector.grayScaleEffectCameras == null || uGUI_FeedbackCollector.grayScaleEffectCameras.Length < allCamerasCount)
            {
                uGUI_FeedbackCollector.grayScaleEffectCameras = new Camera[allCamerasCount];
            }
            Camera.GetAllCameras(uGUI_FeedbackCollector.grayScaleEffectCameras);
            for (int i = 0; i < uGUI_FeedbackCollector.grayScaleEffectCameras.Length; i++)
            {
                var camera = uGUI_FeedbackCollector.grayScaleEffectCameras[i];
                if (!(camera == null))
                {
                    var component = camera.GetComponent<Grayscale>();
                    if (!(component == null))
                    {
                        component.effectAmount = amount;
                        component.enabled = (amount > 0f);
                    }
                }
            }
        }
    }
}
