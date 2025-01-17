using UnityEngine;

[CreateAssetMenu(fileName = "SecurityCameraConfig", menuName = "CONFIGURATIONS/Cameras/SecurityCameraConfig", order = 0)]
public class SecurityCameraConfig : ScriptableObject
{
    [field: SerializeField] public float RotationDuration { get; private set; }
    [field: SerializeField] public float WaitDuration { get; private set; }
}