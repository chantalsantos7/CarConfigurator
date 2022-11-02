using Assets.Scripts.Enumeration;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Vehicles
{
    public class Vehicle : MonoBehaviour
    {
        public float basePrice;
        public List<VehicleColour> possColours;
        public List<WheelType> wheelTypes;
        public List<EngineType> engineTypes;
        public List<LeatherType> leatherTypes;
        protected string carMake;
        public float rotationDegrees;
        protected bool rotationPaused;

        public virtual void ChangeColour(int colour) {}
        public string GetMake() { return carMake; }

        private void Update()
        {
            if (!rotationPaused)
            {
                transform.Rotate(new Vector3(0, rotationDegrees, 0) * Time.deltaTime);
            }
        }

        public void PauseRotation()
        {
            rotationPaused = true;
        }

        public void UnpauseRotation()
        {
            rotationPaused = false;
        }

    }
}

