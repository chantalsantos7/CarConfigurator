using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Enumeration
{
    public enum EngineType
    {
        Standard,
        Turbo,
        SpeedDemon
    }

    public static class EngineProperties
    {
        public static Dictionary<string, float> EnginePrices = new Dictionary<string, float> {
            {"Standard", 150 },
            {"Turbo", 300 },
            {"SpeedDemon", 250 }
        };
    }
}