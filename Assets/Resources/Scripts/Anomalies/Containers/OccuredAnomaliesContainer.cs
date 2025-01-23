using System.Collections.Generic;
using UnityEngine;

public static class OccuredAnomaliesContainer
{
    private static List<OccuredAnomalyData> occuredAnomalyDatas = new List<OccuredAnomalyData>();

    public static void AddOccuredAnomalyData(OccuredAnomalyData occuredAnomalyData)
    {
        occuredAnomalyDatas.Add(occuredAnomalyData);
    }

    public static void RemoveOccuredAnomalyByData(OccuredAnomalyData occuredAnomalyData)
    {
        occuredAnomalyDatas.Remove(GetOccuredAnomalyDataByData(occuredAnomalyData));
    }

    public static AnomalyObject GetOccuredAnomalyObjectByData(OccuredAnomalyData occuredAnomalyData)
    {
        return GetOccuredAnomalyDataByData(occuredAnomalyData).AnomalyObject;
    }

    public static OccuredAnomalyData GetOccuredAnomalyDataByData(OccuredAnomalyData occuredAnomalyData)
    {
        foreach (var occuredAnomData in occuredAnomalyDatas)
        {
            if (occuredAnomData.AnomalyObject.GetType() == occuredAnomalyData.AnomalyObject.GetType()
            && occuredAnomData.Anomaly.GetType() == occuredAnomalyData.Anomaly.GetType())
            {
                return occuredAnomData;
            }
        }

        Debug.Log("Неправильная проверка данных или такая аномалия ещё не произошла. Возврат null.");
        return null;
    }
}