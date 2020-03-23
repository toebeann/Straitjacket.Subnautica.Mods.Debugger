using System.IO;
using System.Reflection;
using System.Text;
using LitJson;
using SMLHelper.V2.Options;
using UnityEngine;

namespace Straitjacket.Subnautica.Mods.Debugger
{
    internal struct OptionsObject
    {
        public KeyCode ToggleDebuggerVisibilityKey { get; set; }
        public KeyCode TogglePauseKey { get; set; }
        public bool VerboseDebugging { get; set; }
    }

    internal class Options : ModOptions
    {
        public KeyCode ToggleDebuggerVisibilityKey = KeyCode.F2;
        public KeyCode TogglePauseKey = KeyCode.Pause;
        public bool VerboseDebugging = false;
        private string ConfigPath
            => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");

        public Options() : base("Debugger")
        {
            KeybindChanged += Options_KeybindChanged;
            ToggleChanged += Options_ToggleChanged;

            if (!File.Exists(ConfigPath))
            {
                UpdateJSON();
            }
            else
            {
                ReadOptionsFromJSON();
            }

            Harmony.Debugger.Verbose = VerboseDebugging;
        }

        public override void BuildModOptions()
        {
            AddToggleOption("verboseDebugging", "Include Debug.Log calls in log", VerboseDebugging);
            AddKeybindOption("debuggerKey", "Show/hide Debugger",
                GameInput.GetPrimaryDevice(), ToggleDebuggerVisibilityKey);
            AddKeybindOption("pauseKey", "Toggle pause",
                GameInput.GetPrimaryDevice(), TogglePauseKey);
        }

        private void Options_KeybindChanged(object sender, KeybindChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "debuggerKey":
                    ToggleDebuggerVisibilityKey = e.Key;
                    break;
                case "pauseKey":
                    TogglePauseKey = e.Key;
                    break;
            }
            UpdateJSON();
        }

        private void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "verboseDebugging":
                    Harmony.Debugger.Verbose = VerboseDebugging = e.Value;
                    break;
            }
            UpdateJSON();
        }

        private void UpdateJSON()
        {
            var options = new OptionsObject
            {
                ToggleDebuggerVisibilityKey = ToggleDebuggerVisibilityKey,
                TogglePauseKey = TogglePauseKey,
                VerboseDebugging = VerboseDebugging
            };

            var stringBuilder = new StringBuilder();
            JsonMapper.ToJson(options, new JsonWriter(stringBuilder)
            {
                PrettyPrint = true
            });

            File.WriteAllText(ConfigPath, stringBuilder.ToString());
        }

        private void ReadOptionsFromJSON()
        {
            if (File.Exists(ConfigPath))
            {
                string optionsJSON = File.ReadAllText(ConfigPath);
                var options = JsonMapper.ToObject<OptionsObject>(optionsJSON);
                var data = JsonMapper.ToObject(optionsJSON);
                ToggleDebuggerVisibilityKey = data.ContainsKey("ToggleDebuggerVisibilityKey")
                    ? options.ToggleDebuggerVisibilityKey : ToggleDebuggerVisibilityKey;
                TogglePauseKey = data.ContainsKey("TogglePauseKey")
                    ? options.TogglePauseKey : TogglePauseKey;
                VerboseDebugging = data.ContainsKey("VerboseDebugging")
                    ? options.VerboseDebugging : VerboseDebugging;
                if (!data.ContainsKey("ToggleDebuggerVisibilityKey") ||
                    !data.ContainsKey("TogglePauseKey") ||
                    !data.ContainsKey("VerboseDebugging"))
                {
                    UpdateJSON();
                }
            }
            else
            {
                UpdateJSON();
            }
        }
    }
}
