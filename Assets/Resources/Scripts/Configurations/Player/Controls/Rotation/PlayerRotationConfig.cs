using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRotationConfig", menuName = "CONFIGURATIONS/Player/Controls/PlayerRotationConfig", order = 0)]
public class PlayerRotationConfig : ScriptableObject
{
    [field: Header("Sensitivity settings")]
    [field: SerializeField] public float HorizontalAxisSensitivity { get; private set; }
    [field: SerializeField] public float VerticalAxisSensitivity { get; private set; }
    [field: SerializeField] public float SensitivityMultiplier { get; private set; }

    [field: Header("Smoothness settings")]
    [field: SerializeField] public float DampSmoothnes { get; private set; }

    [field: Header("Vertical clamp settings")]
    [field: SerializeField] public float TopClamp { get; private set; }
    [field: SerializeField] public float BottomClamp { get; private set; }
}