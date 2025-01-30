public class AnomalyData
{
    public AnomalyConfig AnomalyConfig { get; private set; }
    public IAnomaly Anomaly { get; private set; }

    public AnomalyData(AnomalyConfig anomalyConfig, IAnomaly anomaly)
    {
        AnomalyConfig = anomalyConfig;
        Anomaly = anomaly;
    }
}