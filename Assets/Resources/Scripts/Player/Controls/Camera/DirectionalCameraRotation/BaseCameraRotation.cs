using UnityEngine;

public class BaseControllingCameraRotation
{
    protected Transform cameraTransform;

    public BaseControllingCameraRotation(Transform cameraTransform)
    {
        this.cameraTransform = cameraTransform;
    }
}