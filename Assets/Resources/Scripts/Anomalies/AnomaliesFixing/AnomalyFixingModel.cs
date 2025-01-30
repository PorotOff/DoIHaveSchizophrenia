public class AnomalyFixingModel
{
    public void Fix()
    {
        AnomalyRoom anomalyRoom = AnomalyReportData.GetAnomalyRoom();
        AnomalyData anomalyData = AnomalyReportData.GetAnomalyData();
        AnomalyObject anomalyObject = AnomalyReportData.GetAnomalyObject();

        OccurredAnomalyData occurredAnomalyData = new OccurredAnomalyData(anomalyRoom, anomalyData, anomalyObject);

        OccurredAnomalyData occurredAnomalyDataForFix = OccurredAnomaliesContainer.GetOccurredAnomalyDataByData(occurredAnomalyData);
        AnomalyData anomalyDataForFix = occurredAnomalyDataForFix.AnomalyData;
        AnomalyObject anomalyObjectForFix = occurredAnomalyDataForFix.AnomalyObject;

        anomalyObjectForFix.FixAnomaly(anomalyDataForFix);
    }
}