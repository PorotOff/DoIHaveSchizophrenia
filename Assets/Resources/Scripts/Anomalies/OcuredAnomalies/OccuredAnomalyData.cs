public class OccuredAnomalyData
{
    public AnomalyObject AnomalyObject { get; private set; }
    public IAnomaly Anomaly { get; private set; }

    public OccuredAnomalyData(AnomalyObject anomalyObject, IAnomaly anomaly)
    {
        AnomalyObject = anomalyObject;
        Anomaly = anomaly;
    }
}