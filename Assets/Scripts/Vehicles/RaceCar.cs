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

        private void Start()
        {
            initialRotation = transform.rotation;
        }

        public override void ChangeColour(int colour)
        {
            var body = transform.GetChild(0);
            MeshRenderer meshRenderer = body.GetComponent<MeshRenderer>();
            meshRenderer.material = altColours[colour];  
        }

        public override void Rotate()
        {
            transform.Rotate(new Vector3(0, rotationDegrees, 0) * Time.deltaTime);
        }

        public override void ResetRotation()
        {
            PauseRotation();
            transform.SetPositionAndRotation(transform.position, initialRotation);
        }
    }
}