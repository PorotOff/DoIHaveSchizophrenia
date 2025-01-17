using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInformation", menuName = "CONFIGURATIONS/LevelConfig", order = 0)]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public SceneAsset Scene { get; private set; }
    [field: SerializeField] public string LocalizationKey { get; private set; }
}