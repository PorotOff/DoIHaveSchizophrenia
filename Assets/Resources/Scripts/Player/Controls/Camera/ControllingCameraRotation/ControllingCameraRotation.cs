using UnityEngine;

public class ControllingCameraRotation : MonoBehaviour
{
    private IControllingCameraRotation controllingCameraRotation;

    public void Initialize(IControllingCameraRotation controllingCameraRotation)
    {
        this.controllingCameraRotation = controllingCameraRotation;
    }

    
}