using System;
using System.Collections.Generic;

public class OccuredAnomaliesContainer
{
    private List<OccuredAnomalyData> occuredAnomalies = new List<OccuredAnomalyData>();

    public void AddOcuredAnomaly(OccuredAnomalyData occuredAnomalyData)
    {
        occuredAnomalies.Add(occuredAnomalyData);
    }

    public void FixOccuredAnomaly(OccuredAnomalyData occuredAnomalyData)
    {
        int occuredAnomalyIndex = 0;

        foreach (var occuredAnomaly in occuredAnomalies)
        {
            if (occuredAnomaly.anomalyObject == occuredAnomalyData.anomalyObject && occuredAnomaly.anomaly == occuredAnomalyData.anomaly)
            {
                occuredAnomalyData.anomaly.Fix();
                occuredAnomalies.Remove(occuredAnomalies[occuredAnomalyIndex]);

                return;
            }
            
            occuredAnomalyIndex++;
        }

        throw new Exception("Нет такой произошедшей аномалии");
    }
}