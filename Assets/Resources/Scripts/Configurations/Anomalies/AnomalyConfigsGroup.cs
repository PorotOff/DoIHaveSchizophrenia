using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyConfigsGroup", menuName = "CONFIGURATIONS/Anomalies/IDManagement/AnomalyConfigsGroup", order = 0)]
public class AnomalyConfigsGroup : ScriptableObject
{
    [field: SerializeField] public List<BaseAnomalyConfig> BaseAnomalyConfigs { get; private set; }
}