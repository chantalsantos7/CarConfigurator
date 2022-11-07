using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Vehicles
{
    public class RetroCar : Vehicle
    {
        private List<GameObject> carModels = new List<GameObject>();
        private Quaternion prevRotation;

        private void Awake()
        {
            carMake = "Neptune Crusader";
        }

        void Start()
        {
            foreach (Transform child in transform) 
            {
                carModels.Add(child.gameObject);
                if (child.gameObject.activeInHierarchy)
                {
                    initialRotation = child.transform.rotation;
                }
            }
        }
        //get prev car's Y rotation, start the next car from that rotation
        public override void Rotate()
        {
            foreach (var carModel in carModels)
            {
                if (carModel.activeInHierarchy)
                {
                    carModel.transform.Rotate(new Vector3(0, rotationDegrees, 0) * Time.deltaTime);
                    prevRotation = carModel.transform.rotation;
                }
            }
        }

        public override void ChangeColour(int colour)
        {
            for (int i = 0; i < carModels.Count; i++)
            {
                if (i == colour)
                {
                    carModels[i].SetActive(true);
                    carModels[i].transform.SetPositionAndRotation(carModels[i].transform.position, prevRotation);
                } else
                {
                    carModels[i].SetActive(false);
                }
            }

        }

        public override void ResetRotation()
        {
            PauseRotation();
            foreach (var carModel in carModels)
            {
                if (carModel.activeInHierarchy)
                {
                    carModel.transform.SetPositionAndRotation(carModel.transform.position, initialRotation);
                }
            }
        }
    }
}