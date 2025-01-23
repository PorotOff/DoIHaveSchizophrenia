using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [Header("Player rotation settings")]
    private ControllingPlayerRotation playerRotationController;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private PlayerRotationConfig cameraRotationConfig;

    [SerializeField] private Transform playerTransform;
    private Transform playerCameraTransform;

    [Header("Interaction settings")]
    [SerializeField] private RaycastHovering raycastDetection;
    [SerializeField] private InteractionConfig interactionSystemConfig;

    [SerializeField] private Crosshair crosshair;
    [SerializeField] private CrosshairConfig crosshairConfig;

    private void Awake()
    {
        #region Player camera settings
            playerRotationController = gameObject.AddComponent<MouseControllingPlayerRotation>();
    
            playerCameraTransform = playerCamera.GetComponent<Transform>();
    
            playerRotationController.Initialize(playerTransform, playerCameraTransform, cameraRotationConfig);
        #endregion

        raycastDetection.Initialize(interactionSystemConfig);

        crosshair.Initialize(crosshairConfig, raycastDetection);
    }
}