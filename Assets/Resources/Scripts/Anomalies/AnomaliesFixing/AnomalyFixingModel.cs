public class AnomalyFixingModel
{
    public void Fix()
    {
        AnomalyObject anomalyObject = AnomalyReportData.GetAnomalyObject();
        AnomalyData anomalyData = AnomalyReportData.GetAnomalyData();
        OccuredAnomalyData newOccuredAnomalyData = new OccuredAnomalyData(anomalyObject, anomalyData.Anomaly);
        
        OccuredAnomalyData occuredAnomalyDataForFix = OccuredAnomaliesContainer.GetOccuredAnomalyDataByData(newOccuredAnomalyData);

        occuredAnomalyDataForFix.Anomaly.Fix();
    }
}