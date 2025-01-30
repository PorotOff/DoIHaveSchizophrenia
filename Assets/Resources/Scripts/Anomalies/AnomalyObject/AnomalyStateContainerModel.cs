using System.Collections.Generic;
using System.Linq;

public class AnomalyStateContainerModel
{
    private List<AnomalyData> notOccurredAnomalyDatas = new List<AnomalyData>();
    private List<AnomalyData> occurredAnomalyDatas = new List<AnomalyData>();

    public void AddNotOccurredAnomaly(AnomalyData anomalyData)
    {
        notOccurredAnomalyDatas.Add(anomalyData);
    }
    public void AddOccurredAnomaly(AnomalyData anomalyData)
    {
        occurredAnomalyDatas.Add(anomalyData);
    }

    public void RemoveNotOccurredAnomaly(AnomalyData anomalyData)
    {
        notOccurredAnomalyDatas.Remove(anomalyData);
    }
    public void RemoveOccurredAnomaly(AnomalyData anomalyData)
    {
        occurredAnomalyDatas.Remove(anomalyData);
    }

    public bool HasNotOccurredAnomalyDatas()
    {
        return notOccurredAnomalyDatas.Count > 0;
    }
    public bool HasOccurredAnomalyDatas()
    {
        return occurredAnomalyDatas.Count > 0;
    }

    public List<AnomalyData> GetNotOccurredAnomalyDatas()
    {
        return new List<AnomalyData>(notOccurredAnomalyDatas);
    }
    public List<AnomalyData> GetOccurredAnomalyDatas()
    {
        return new List<AnomalyData>(occurredAnomalyDatas);
    }

    public List<IAnomaly> GetAllAnomalies()
    {
        return notOccurredAnomalyDatas
            .Concat(occurredAnomalyDatas)
            .Select(anomalyData => anomalyData.Anomaly)
            .ToList();
    }
}