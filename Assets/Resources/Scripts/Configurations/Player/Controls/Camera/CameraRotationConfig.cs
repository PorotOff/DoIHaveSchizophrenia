using UnityEngine;

[CreateAssetMenu(fileName = "CameraRotationConfig", menuName = "CONFIGURATIONS/Player/Controls/Camera/CameraRotationConfig", order = 0)]
public class CameraRotationConfig : ScriptableObject
{
    [field: SerializeField] public float minVerticalLookRestriction { get; private set; }
    [field: SerializeField] public float maxVerticalLookRestriction { get; private set; }

    [field: SerializeField] public float sencetivity { get; private set; }
}