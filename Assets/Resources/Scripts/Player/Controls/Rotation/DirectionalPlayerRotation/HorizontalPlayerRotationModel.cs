using UnityEngine;

public class HorizontalPlayerRotationModel : BasePlayerRotationModel, IDirectionalCameraRotation
{
    public HorizontalPlayerRotationModel(Transform objectTransform, PlayerRotationConfig playerRotationConfig) : base(objectTransform, playerRotationConfig) { }

    public void Rotate(float axisInput)
    {
        float horizontalAxisSensitivity = playerRotationConfig.HorizontalAxisSensitivity;
        float sensitivityMultiplier = playerRotationConfig.SensitivityMultiplier;
        float dampSmoothnes = playerRotationConfig.DampSmoothnes;

        targetRotation += axisInput * horizontalAxisSensitivity * sensitivityMultiplier;
        currentRotation = Mathf.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, dampSmoothnes);

        objectTransform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);
    }
}