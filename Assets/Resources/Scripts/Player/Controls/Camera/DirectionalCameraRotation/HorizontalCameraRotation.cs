using UnityEngine;

public class HorizontalCameraRotation : BaseControllingCameraRotation, IDirectionalCameraRotation
{
    private float currentHorizontalRotation = 0f;

    public HorizontalCameraRotation(Transform cameraTransform) : base(cameraTransform) { }

    public void Rotate(float horizontalAxisInput, float sencetivity)
    {
        currentHorizontalRotation += horizontalAxisInput * sencetivity;

        cameraTransform.localRotation = Quaternion.Euler(0f, currentHorizontalRotation, 0f);
    }
}