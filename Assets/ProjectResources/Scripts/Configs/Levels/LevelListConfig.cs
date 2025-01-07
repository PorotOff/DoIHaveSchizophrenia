using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "CONFIGURATIONS/LevelList", order = 0)]
public class LevelListConfig : ScriptableObject
{
    [field: SerializeField] public List<LevelConfig> levelConfigs { get; private set; }
}