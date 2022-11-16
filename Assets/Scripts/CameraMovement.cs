using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera configCam;
    [SerializeField] private CinemachineVirtualCamera checkoutCam;

    public void SwitchCamView(bool onCheckout)
    {
        if (onCheckout)
        {
            configCam.enabled = false;
            checkoutCam.enabled = true;
        } else
        {
            checkoutCam.enabled = false;
            configCam.enabled = true;
        }
    }
}
