using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyObjectConfig", menuName = "CONFIGURATIONS/Anomalies/AnomalyObjectConfig", order = 0)]
public class AnomalyObjectConfig : ScriptableObject
{
    [field: SerializeField] public string LocalizationKey { get; private set; }

    [field: SerializeField] public List<AnomalyConfig> Anomalies { get; private set; }
}