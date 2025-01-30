using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Anomaly", menuName = "CONFIGURATIONS/Anomalies/AnomalyTypes/Anomaly", order = 0)]
public class AnomalyConfig : BaseAnomalyConfig
{
    [field: SerializeField] public MonoScript Anomaly { get; private set; }

    public Type GetAnomalyAsType()
    {
        Type anomalyType = Anomaly.GetClass();

        if (anomalyType == null) throw new Exception("anomalyType не содержит валидного класса");
        if (!typeof(IAnomaly).IsAssignableFrom(anomalyType)) throw new Exception("anomalyType не имплементирует IAnomaly");
        if (!typeof(MonoBehaviour).IsAssignableFrom(anomalyType)) throw new Exception("anomalyType не наследуется от MonoBehaviour");

        return anomalyType;
    }
}