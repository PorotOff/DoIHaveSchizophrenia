public class OccuredAnomalyData
{
    public AnomalyObject anomalyObject { get; private set; }
    public IAnomaly anomaly { get; private set; }

    public OccuredAnomalyData(AnomalyObject anomalyObject, IAnomaly anomaly)
    {
        this.anomalyObject = anomalyObject;
        this.anomaly = anomaly;
    }
}