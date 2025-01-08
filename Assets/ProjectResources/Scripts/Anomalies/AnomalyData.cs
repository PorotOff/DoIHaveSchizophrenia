public class AnomalyData
{
    public IAnomaly Anomaly { get; private set; }
    public string LocalizationKey { get; private set; }

    public AnomalyData(IAnomaly anomaly, string localizationKey)
    {
        Anomaly = anomaly;
        LocalizationKey = localizationKey;
    }
}