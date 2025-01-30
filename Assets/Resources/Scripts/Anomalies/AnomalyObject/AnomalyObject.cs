using UnityEngine;
using System;

public class AnomalyObject : MonoBehaviour
{
    [field: SerializeField] public AnomalyObjectConfig AnomalyObjectConfig { get; private set; }

    public AnomalyRoom AnomalyRoom { get; private set; }

    public AnomalyStateContainerModel AnomalyStateContainerModel { get; private set; }

    public void Initialise(AnomalyRoom anomalyRoom)
    {
        AnomalyRoom = anomalyRoom;

        AnomalyStateContainerModel = new AnomalyStateContainerModel();

        AddAnomalyComponentsOnObject();
    }

    public void OccurAnomaly(AnomalyData anomalyData)
    {
        anomalyData.Anomaly.Occur();

        AnomalyStateContainerModel.RemoveNotOccurredAnomaly(anomalyData);
        AnomalyStateContainerModel.AddOccurredAnomaly(anomalyData);

        OccurredAnomaliesContainer.AddOccurredAnomalyData(new OccurredAnomalyData(AnomalyRoom, anomalyData, this));

        Debug.Log($"На объекте {name}, произошла аномалия {anomalyData.Anomaly.GetType().Name}");
    }
    public void FixAnomaly(AnomalyData anomalyData)
    {
        anomalyData.Anomaly.Fix();

        AnomalyStateContainerModel.RemoveOccurredAnomaly(anomalyData);
        AnomalyStateContainerModel.AddNotOccurredAnomaly(anomalyData);

        OccurredAnomaliesContainer.RemoveOccurredAnomalyByData(new OccurredAnomalyData(AnomalyRoom, anomalyData, this));

        Debug.Log($"На объекте {name}, починилась аномалия {anomalyData.Anomaly.GetType().Name}");
    }

    private void AddAnomalyComponentsOnObject()
    {
        foreach (var anomalyConfig in AnomalyObjectConfig.AnomalyConfigs)
        {
            Type anomalyType = anomalyConfig.GetAnomalyAsType();

            Component newAnomalyComponent = gameObject.AddComponent(anomalyType);

            AddNotOccurredAnomaly(anomalyConfig, newAnomalyComponent as IAnomaly);
        }
    }

    private void AddNotOccurredAnomaly(AnomalyConfig anomalyConfig, IAnomaly anomaly)
    {
        AnomalyStateContainerModel.AddNotOccurredAnomaly(new AnomalyData(anomalyConfig, anomaly));
    }
}