using UnityEngine;
using UnityEngine.EventSystems;

public class MouseCameraRotationModel : MonoBehaviour, IControllingCameraRotation, IPointerMoveHandler
{
    private IDirectionalCameraRotation horizontalCameraRotataion;
    private IDirectionalCameraRotation verticalCameraRotation;

    private CameraRotationConfig cameraRotationConfig;

    public void Initialize(Transform cameraTransform, CameraRotationConfig cameraRotationConfig)
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.cameraRotationConfig = cameraRotationConfig;

        horizontalCameraRotataion = new HorizontalCameraRotation(cameraTransform);
        verticalCameraRotation = new VerticalCameraRotation(cameraTransform, cameraRotationConfig.minVerticalLookRestriction, cameraRotationConfig.maxVerticalLookRestriction);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Rotate();
    }

    public void Rotate()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        verticalCameraRotation.Rotate(verticalInput, cameraRotationConfig.sencetivity);
        horizontalCameraRotataion.Rotate(horizontalInput, cameraRotationConfig.sencetivity);
    }
}