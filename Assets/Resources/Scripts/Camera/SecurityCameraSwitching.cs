using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraSwitching : MonoBehaviour
{
    private List<SecurityCamera> securityCameras;
    private int currentSecurityCameraIndex;

    public void Initialise(List<SecurityCamera> securityCameras, int currentSecurityCameraIndex)
    {
        this.securityCameras = securityCameras;
        this.currentSecurityCameraIndex = currentSecurityCameraIndex;
    }

    public void SwitchCamera(SwitchingDirections switchingDirection)
    {
        DeactivateAllCameras();
        
        currentSecurityCameraIndex = (currentSecurityCameraIndex + (int)switchingDirection + securityCameras.Count) % securityCameras.Count;
        securityCameras[currentSecurityCameraIndex].Activate();
    }

    private void DeactivateAllCameras()
    {
        foreach (var securityCamera in securityCameras)
        {
            securityCamera.Deactivate();
        }
    }
}