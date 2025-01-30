public class OccurredAnomalyData
{
    public AnomalyRoom AnomalyRoom { get; private set; }
    public AnomalyData AnomalyData { get; private set; }
    public AnomalyObject AnomalyObject { get; private set; }

    public OccurredAnomalyData(AnomalyRoom anomalyRoom, AnomalyData anomalyData, AnomalyObject anomalyObject)
    {
        AnomalyRoom = anomalyRoom;
        AnomalyData = anomalyData;
        AnomalyObject = anomalyObject;
    }
}