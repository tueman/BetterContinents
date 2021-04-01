﻿using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace BetterContinents
{
    public partial class BetterContinents
    {
        // Debug mode helpers
        [HarmonyPatch(typeof(Console))]
        private class ConsolePatch
        {
            [HarmonyPrefix, HarmonyPatch("InputText")]
            private static void InputTextPrefix(Console __instance)
            {
                if (AllowDebugActions)
                {
                    string text = __instance.m_input.text.Trim();
                    if (text == "bc" || text == "bc help")
                    {
                        DebugUtils.ShowHelp();
                    }
                    else if (DebugUtils.Subcommand(ref text, "bc"))
                    {
                        DebugUtils.RunConsoleCommand(text);
                    }
                }
            }
        }
    }
}