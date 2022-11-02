using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtons : MonoBehaviour
{
    public GameObject rotateObj;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (isPressed)
        {
            RotateByDegrees(rotateObj);
        }
    }

    public void RotateLeft()
    {

    }

    public void RotateRight()
    {

    }

    public void RotateByDegrees(GameObject obj) 
    {
        Vector3 RotationToAdd = new Vector3(0, 25, 0);
        obj.transform.Rotate(RotationToAdd);
    }
}
