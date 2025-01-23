using UnityEngine;

public class AnomalyFixingModel
{
    public void Fix()
    {
        AnomalyObject anomalyObject = AnomalyReportData.GetAnomalyObject();
        AnomalyData anomalyData = AnomalyReportData.GetAnomalyData();
        OccuredAnomalyData newOccuredAnomalyData = new OccuredAnomalyData(anomalyObject, anomalyData.Anomaly);

        AnomalyObject occuredAnomalyObject = OccuredAnomaliesContainer.GetOccuredAnomalyObjectByData(newOccuredAnomalyData);
        OccuredAnomalyData occuredAnomalyDataForFix = OccuredAnomaliesContainer.GetOccuredAnomalyDataByData(newOccuredAnomalyData);

        Debug.Log($"Попытка починить аномалию {occuredAnomalyDataForFix.Anomaly.GetType().Name} на объекте {occuredAnomalyObject.name}");
        occuredAnomalyObject.AnomalyFix(occuredAnomalyDataForFix.Anomaly);
    }
}