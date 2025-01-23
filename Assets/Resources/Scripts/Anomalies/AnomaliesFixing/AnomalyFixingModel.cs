public class AnomalyFixingModel
{
    public void Fix()
    {
        AnomalyObject anomalyObject = AnomalyReportData.GetAnomalyObject();
        AnomalyData anomalyData = AnomalyReportData.GetAnomalyData();
        OccuredAnomalyData newOccuredAnomalyData = new OccuredAnomalyData(anomalyObject, anomalyData.Anomaly);

        AnomalyObject occuredAnomalyObject = OccuredAnomaliesContainer.GetOccuredAnomalyObjectByData(newOccuredAnomalyData);
        OccuredAnomalyData occuredAnomalyDataForFix = OccuredAnomaliesContainer.GetOccuredAnomalyDataByData(newOccuredAnomalyData);

        occuredAnomalyObject.AnomalyFix(occuredAnomalyDataForFix.Anomaly);
    }
}