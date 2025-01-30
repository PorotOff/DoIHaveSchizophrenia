using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyObject", menuName = "CONFIGURATIONS/Anomalies/AnomalyObject", order = 0)]
public class AnomalyObjectConfig : BaseAnomalyConfig
{
    [field: SerializeField] public List<AnomalyConfig> AnomalyConfigs { get; private set; }
}