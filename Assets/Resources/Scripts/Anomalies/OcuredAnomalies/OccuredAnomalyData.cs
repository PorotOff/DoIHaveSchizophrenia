using System;

public class OccuredAnomalyData
{
    public AnomalyObject AnomalyObject { get; private set; }
    public IAnomaly Anomaly { get; private set; }

    public OccuredAnomalyData(AnomalyObject anomalyObject, IAnomaly anomaly)
    {
        if (anomalyObject == null) throw new Exception("Нельзя создать OccuredAnomalyData: anomalyObject null.");
        if (anomaly == null) throw new Exception("Нельзя создать OccuredAnomalyData: anomaly null.");

        AnomalyObject = anomalyObject;
        Anomaly = anomaly;
    }
}