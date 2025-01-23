using UnityEngine;

public class AnomalyFixingModel
{
    private AnomalyReportData anomalyReportData;

    public AnomalyFixingModel(AnomalyReportData anomalyReportData)
    {
        this.anomalyReportData = anomalyReportData;
    }

    public void Fix()
    {
        AnomalyObject anomalyObject = anomalyReportData.GetAnomalyObject();
        AnomalyData anomalyData = anomalyReportData.GetAnomalyData();
        OccuredAnomalyData newOccuredAnomalyData = new OccuredAnomalyData(anomalyObject, anomalyData.Anomaly);

        AnomalyObject occuredAnomalyObject = OccuredAnomaliesContainer.GetOccuredAnomalyObjectByData(newOccuredAnomalyData);
        OccuredAnomalyData occuredAnomalyDataForFix = OccuredAnomaliesContainer.GetOccuredAnomalyDataByData(newOccuredAnomalyData);

        occuredAnomalyObject.AnomalyFix(occuredAnomalyDataForFix.Anomaly);

        Debug.Log($"Чинится аномалия {occuredAnomalyDataForFix.Anomaly.GetType().Name} на объекте {occuredAnomalyObject.name}");
    }
}