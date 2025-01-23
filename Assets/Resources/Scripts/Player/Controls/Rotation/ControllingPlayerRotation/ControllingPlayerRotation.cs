using UnityEngine;

public abstract class ControllingPlayerRotation : MonoBehaviour
{
    public abstract void Initialize(Transform playerTransform, Transform cameraTransform, PlayerRotationConfig cameraRotationConfig);
    public abstract void Rotate();
}