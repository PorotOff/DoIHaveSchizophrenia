using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyConfig", menuName = "CONFIGURATIONS/Anomalies/AnomalyConfig", order = 0)]
public class AnomalyConfig : ScriptableObject
{
    [field: SerializeField] public MonoScript anomaly { get; private set; }
    [field: SerializeField] public string LocalizationKey { get; private set; }

    // public Type GetAnomalyType()
    // {
    //     Type anomalyType = anomaly.GetClass();

    //     if (anomalyType == null) throw new Exception("anomalyType не содержит валидного класса");
    //     if (!typeof(IAnomaly).IsAssignableFrom(anomalyType)) throw new Exception("anomalyType не имплементирует IAnomaly");
    //     if (!typeof(MonoBehaviour).IsAssignableFrom(anomalyType)) throw new Exception("anomalyType не наследуется от MonoBehaviour");

    //     return anomalyType;
    // }
}