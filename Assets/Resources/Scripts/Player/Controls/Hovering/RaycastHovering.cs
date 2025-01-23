using UnityEngine;

public class RaycastHovering : MonoBehaviour
{
    private CameraRayProviderModel rayProvider;
    private DebugRayDrawerModel debugRayDrawer;

    private InteractionConfig interactionSystemConfig;
    private float raycastLenght;

    private IHoverable hoverable;

    public void Initialize(InteractionConfig interactionSystemConfig)
    {
        Camera playerCamera = GetComponentInChildren<Camera>();

        this.interactionSystemConfig = interactionSystemConfig;
        raycastLenght = interactionSystemConfig.RaycastLenght;

        rayProvider = new CameraRayProviderModel(playerCamera);
        debugRayDrawer = new DebugRayDrawerModel();
    }

    private void Update()
    {
        GetDetectedObject();
    }

    public void GetDetectedObject()
    {
        Ray cameraRay = rayProvider.GetRay();
        debugRayDrawer.DebugDrawRay(cameraRay, raycastLenght, Color.green);
        raycastLenght = interactionSystemConfig.RaycastLenght;

        RaycastHit hitted;

        if (Physics.Raycast(cameraRay, out hitted))
        {
            hoverable = hitted.collider.gameObject.GetComponent<IHoverable>();

            Hover(hoverable);

            raycastLenght = hitted.distance;

            Debug.Log($"Object detected: {hitted.collider.gameObject.name}");
            return;
        }

        Unhover(hoverable);
    }

    private void Hover(IHoverable hoverable)
    {
        if (hoverable != null)
        {
            hoverable.OnHover();
        }
    }
    private void Unhover(IHoverable hoverable)
    {
        if (hoverable != null)
        {
            hoverable.OnUnhover();
        }
    }
}