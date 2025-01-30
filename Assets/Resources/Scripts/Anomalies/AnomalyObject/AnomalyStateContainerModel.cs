using System.Collections.Generic;

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

    public List<AnomalyData> GetNotOccurredAnomalyDatas()
    {
        return new List<AnomalyData>(notOccurredAnomalyDatas);
    }
    public List<AnomalyData> GetOccurredAnomalyDatas()
    {
        return new List<AnomalyData>(occurredAnomalyDatas);
    }
}