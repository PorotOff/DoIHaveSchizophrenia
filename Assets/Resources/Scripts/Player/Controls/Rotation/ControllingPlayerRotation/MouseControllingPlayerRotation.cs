using UnityEngine;

public class MouseControllingPlayerRotation : BaseControllingPlayerRotation
{
    public override void Initialize(Transform playerTransform, Transform cameraTransform, PlayerRotationConfig cameraRotationConfig)
    {
        base.Initialize(playerTransform, cameraTransform, cameraRotationConfig);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    public override void Rotate()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        verticalCameraRotation.Rotate(verticalInput);
        horizontalCameraRotataion.Rotate(horizontalInput);
    }
}