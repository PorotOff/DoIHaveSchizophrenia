using System;

public class AnomalyFixingModel
{
    private OccuredAnomaliesContainer occuredAnomaliesContainer;

    public AnomalyFixingModel(OccuredAnomaliesContainer occuredAnomaliesContainer)
    {
        this.occuredAnomaliesContainer = occuredAnomaliesContainer;
    }

    public void Fix()
    {
        AnomalyObject anomalyObject = AnomalyReportData.GetAnomalyObject();
        IAnomaly anomaly = AnomalyReportData.GetAnomaly();

        OccuredAnomalyData occuredAnomalyData = new OccuredAnomalyData(anomalyObject, anomaly);

        occuredAnomaliesContainer.FixOccuredAnomaly(occuredAnomalyData);
    }
}