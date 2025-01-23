using UnityEngine;

public class BasePlayerRotationModel
{
    protected Transform objectTransform;
    protected PlayerRotationConfig playerRotationConfig;

    protected float currentRotation = 0f;
    protected float targetRotation = 0f;
    protected float rotationVelocity = 0f;

    public BasePlayerRotationModel(Transform objectTransform, PlayerRotationConfig playerRotationConfig)
    {
        this.objectTransform = objectTransform;
        this.playerRotationConfig = playerRotationConfig;
    }
}