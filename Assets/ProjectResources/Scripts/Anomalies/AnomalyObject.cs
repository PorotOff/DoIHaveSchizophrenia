using System.Collections.Generic;
using UnityEngine;

public class AnomalyObject : MonoBehaviour
{
    [field: SerializeField] public AnomalyObjectConfig anomalyObjectConfig { get; private set; }

    private List<IAnomaly> anomaliesOnCurrentObject = new List<IAnomaly>();

    private void Awake()
    {
        AddAnomaliesOnCurrentObject();
    }

    public string GetAnomalyObjectLocalizationKey()
    {
        return anomalyObjectConfig.LocalizationKey;
    }

    public string GetAnomalyLocalizationKey(int index)
    {
        return anomalyObjectConfig.Anomalies[index].LocalizationKey;
    }

    private void AddAnomaliesOnCurrentObject()
    {
        foreach (var anomalyConfig in anomalyObjectConfig.Anomalies)
        {
            // IAnomaly anomaly = anomalyConfig.GetAnomalyType();
            // gameObject.AddComponent(anomaly.GetType());
        }
    }
}