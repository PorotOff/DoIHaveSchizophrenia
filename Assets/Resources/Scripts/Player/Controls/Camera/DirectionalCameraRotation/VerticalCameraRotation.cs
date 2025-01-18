using UnityEngine;

public class VerticalCameraRotation : BaseControllingCameraRotation, IDirectionalCameraRotation
{
    private float verticalCameraRotation = 0f;

    private float minVerticalLookRestriction;
    private float maxVerticalLookRestriction;

    public VerticalCameraRotation(Transform cameraTransform, float minVerticalLookRestriction, float maxVerticalLookRestriction) : base(cameraTransform)
    {
        this.minVerticalLookRestriction = minVerticalLookRestriction;
        this.maxVerticalLookRestriction = maxVerticalLookRestriction;
    }

    public void Rotate(float verticalAxisInput, float sencetivity)
    {
        verticalCameraRotation -= verticalAxisInput * sencetivity;
        verticalCameraRotation = Mathf.Clamp(verticalCameraRotation, minVerticalLookRestriction, maxVerticalLookRestriction);

        cameraTransform.localRotation = Quaternion.Euler(verticalCameraRotation, 0f, 0f);
    }
}