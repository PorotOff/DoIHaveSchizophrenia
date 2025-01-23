using UnityEngine;

public class CameraRayProviderModel
{
    private Camera playerCamera;

    public CameraRayProviderModel(Camera camera)
    {
        playerCamera = camera;
    }

    public Ray GetRay()
    {
        Vector3 startRayPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

        return playerCamera.ScreenPointToRay(startRayPosition);
    }
}