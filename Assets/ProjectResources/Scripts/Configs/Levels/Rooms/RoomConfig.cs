using UnityEngine;

[CreateAssetMenu(fileName = "RoomConfig", menuName = "CONFIGURATIONS/RoomConfig", order = 0)]
public class RoomConfig : ScriptableObject
{
    [field: SerializeField] public string LocalisationKey { get; private set; }
}