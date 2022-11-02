using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enumeration
{
    public enum LeatherType
    {
        Black,
        White,
        LeopardPrint,
        Grey
    }

    public static class LeatherProperties
    {
        public static Dictionary<string, float> LeatherPrices = new Dictionary<string, float>
        {
            {"Grey", 0},
            {"Black", 25},
            {"White", 50},
            {"LeopardPrint", 70}
        };
    }
}
