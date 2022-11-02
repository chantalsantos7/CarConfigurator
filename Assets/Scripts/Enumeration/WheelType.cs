using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enumeration
{
    public enum WheelType {
        Standard,
        AllTerrain,
        Booster,
        Winter
    }

    public static class WheelsProperties
    {
        public static Dictionary<string, float> WheelPrices = new Dictionary<string, float>
        {
            {"Standard", 200},
            {"AllTerrain", 500},
            {"Booster", 650},
            {"Winter", 250}
        };
    }
}