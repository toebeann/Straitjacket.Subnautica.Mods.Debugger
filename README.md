# Straitjacket Subnautica Debugger
Straitjacket Subnautica Debugger (SSD) is a runtime debug utility for Subnautica modders built on top of Harmony, the QMods framework, and Straitjacket's own Harmony utilities library<sup>[[1]](#Notes)</sup>.

## Features
- Live, filterable debug logs with file paths and line numbers<sup>[[2]](#Notes)</sup>.
- Live tabbed watch variables, object instances, properties, fields etc., regardless of whether they are private, public, internal etc.
- Pause the game at any point to inspect your watched properties and logs.
- Automatically pause and inspect watched properties when a breakpoint is hit in code.

## Dependencies
- [QModManager](https://www.nexusmods.com/subnautica/mods/201 "QModManager") (v3.0 minimum)
- [SMLHelper (ModdingHelper)](https://www.nexusmods.com/subnautica/mods/113 "SMLHelper (ModdingHelper)") (v2.4.0 minimum)

## Installation
1. Install [QModManager](https://www.nexusmods.com/subnautica/mods/201 "QModManager")
1. Install [SMLHelper (ModdingHelper)](https://www.nexusmods.com/subnautica/mods/113 "SMLHelper (ModdingHelper)")
1. Download and extract the [latest Debugger release](https://github.com/tobeyStraitjacket/Straitjacket.Subnautica.Mods.Debugger/releases/latest/download/Debugger.zip "latest Debugger release"), placing the `Straitjacket Subnautica Debugger` folder in your `Subnautica\QMods` directory

## Usage
See the [wiki](https://github.com/tobeyStraitjacket/Straitjacket.Subnautica.Mods.Debugger/wiki "Straitjacket Subnautica Debugger wiki") for usage details.

### Notes
1. <sup>[^](#Straitjacket-Subnautica-Debugger)</sup> GitHub: [Straitjacket.Harmony](https://github.com/tobeyStraitjacket/Straitjacket.Harmony "Straitjacket.Harmony on GitHub")
1. <sup>[^](#Features)</sup> File paths and line numbers can only be gathered from calls made explicitly to Debugger.Log() or variants rather than UnityEngine's Debug.Log() method variants.
