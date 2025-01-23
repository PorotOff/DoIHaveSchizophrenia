using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "CrosshairConfig", menuName = "CONFIGURATIONS/CrosshairConfig", order = 0)]
public class CrosshairConfig : ScriptableObject
{
    [field: Header("Transform settings")]
    [field: SerializeField] public float Size { get; private set; }

    [field: Header("Alpha settings")]
    [field: SerializeField] public float StandartAlpha { get; private set; }
    [field: SerializeField] public float OnHoveringAlpha { get; private set; }

    [field: Header("Animation settings")]
    [field: SerializeField] public float FadeDuration { get; private set; }
    [field: SerializeField] public Ease Ease { get; private set; }
}