using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Vehicles
{
    public class RaceCar : Vehicle
    {
        public List<Material> altColours;
       

        private void Awake()
        {
            carMake = "Umbra Guardian";
        }

        public override void ChangeColour(int colour)
        {
            var body = transform.GetChild(0);
            MeshRenderer meshRenderer = body.GetComponent<MeshRenderer>();
            meshRenderer.material = altColours[colour];  
        }
    }
}