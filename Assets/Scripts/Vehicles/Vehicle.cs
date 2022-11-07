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
        protected Quaternion initialRotation;

        public virtual void ChangeColour(int colour) {}
        public string GetMake() { return carMake; }

        private void Update()
        {
            if (!rotationPaused)
            {
                Rotate();
            }
        }

        public virtual void Rotate() { }
        public virtual void ResetRotation() { }
        
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

