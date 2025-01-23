using UnityEngine;

[CreateAssetMenu(fileName = "InteractionConfig", menuName = "CONFIGURATIONS/Player/Controls/Interaction/InteractionConfig", order = 0)]
public class InteractionConfig : ScriptableObject
{
    [field: SerializeField] public float RaycastLenght { get; private set; }
}