using UnityEngine;

public class BaseControllingPlayerRotation : ControllingPlayerRotation
{
    protected IDirectionalCameraRotation horizontalCameraRotataion;
    protected IDirectionalCameraRotation verticalCameraRotation;

    protected PlayerRotationConfig playerRotationConfig;

    public override void Initialize(Transform playerTransform, Transform cameraTransform, PlayerRotationConfig playerRotationConfig)
    {
        horizontalCameraRotataion = new HorizontalPlayerRotationModel(playerTransform, playerRotationConfig);
        verticalCameraRotation = new VerticalPlayerRotationModel(cameraTransform, playerRotationConfig);

        this.playerRotationConfig = playerRotationConfig;
    }

    public override void Rotate()
    {
        
    }
}