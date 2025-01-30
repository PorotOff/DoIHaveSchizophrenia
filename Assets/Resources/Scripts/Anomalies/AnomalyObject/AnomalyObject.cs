using System.Collections.Generic;
using UnityEngine;
using System;

public class AnomalyObject : MonoBehaviour
{
    [field: SerializeField] public AnomalyObjectConfig AnomalyObjectConfig { get; private set; }

    public AnomalyRoom AnomalyRoom { get; private set; }

    private List<AnomalyData> notOccurredAnomalyDatas = new List<AnomalyData>();
    private List<AnomalyData> occurredAnomalyDatas = new List<AnomalyData>();

    public void Initialise(AnomalyRoom anomalyRoom)
    {
        AnomalyRoom = anomalyRoom;

        AddAnomalyComponentsOnObject();
    }

    public void OccurAnomaly(AnomalyData anomalyData)
    {
        anomalyData.Anomaly.Occur();

        OccurredAnomaliesContainer.AddOccurredAnomalyData(new OccurredAnomalyData(AnomalyRoom, anomalyData, this));
    }
    public void FixAnomaly(AnomalyData anomalyData)
    {
        anomalyData.Anomaly.Fix();

        OccurredAnomaliesContainer.RemoveOccurredAnomalyByData(new OccurredAnomalyData(AnomalyRoom, anomalyData, this));
    }

    #region Get data methods
    public List<AnomalyData> GetNotOccurredAnomalyDatas()
    {
        return new List<AnomalyData>(notOccurredAnomalyDatas);
    }


    public List<IAnomaly> GetAnomalies()
    {
        List<IAnomaly> anomalies = new List<IAnomaly>();

        foreach (var anomalyData in notOccurredAnomalyDatas)
        {
            anomalies.Add(anomalyData.Anomaly);
        }

        return anomalies;
    }
    #endregion

    private void AddAnomalyComponentsOnObject()
    {
        foreach (var anomalyConfig in AnomalyObjectConfig.AnomalyConfigs)
        {
            Type anomalyType = anomalyConfig.GetAnomalyAsType();

            Component newAnomalyComponent = gameObject.AddComponent(anomalyType);

            SetAnomalyData(anomalyConfig, newAnomalyComponent as IAnomaly);
        }
    }

    private void SetAnomalyData(AnomalyConfig anomalyConfig, IAnomaly anomaly)
    {
        notOccurredAnomalyDatas.Add(new AnomalyData(anomalyConfig, anomaly));
    }
}