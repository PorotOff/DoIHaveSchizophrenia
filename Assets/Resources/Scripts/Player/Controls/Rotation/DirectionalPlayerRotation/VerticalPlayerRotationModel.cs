using UnityEngine;

public class VerticalPlayerRotationModel : BasePlayerRotationModel, IDirectionalCameraRotation
{
    public VerticalPlayerRotationModel(Transform objectTransform, PlayerRotationConfig playerRotationConfig) : base(objectTransform, playerRotationConfig) { }

    public void Rotate(float verticalAxisInput)
    {
        float verticalAxisSensitivity = playerRotationConfig.VerticalAxisSensitivity;
        float sensitivityMultiplier = playerRotationConfig.SensitivityMultiplier;

        float topClamp = playerRotationConfig.TopClamp;
        float bottomClamp = playerRotationConfig.BottomClamp;

        float dampSmoothnes = playerRotationConfig.DampSmoothnes;

        targetRotation -= verticalAxisInput * verticalAxisSensitivity * sensitivityMultiplier;
        targetRotation = Mathf.Clamp(targetRotation, bottomClamp, topClamp);
        currentRotation = Mathf.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, dampSmoothnes);

        objectTransform.localRotation = Quaternion.Euler(currentRotation, 0f, 0f);
    }
}