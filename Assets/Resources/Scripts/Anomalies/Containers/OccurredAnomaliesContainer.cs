using System.Collections.Generic;
using UnityEngine;

public static class OccurredAnomaliesContainer
{
    private static List<OccurredAnomalyData> occurredAnomalyDatas = new List<OccurredAnomalyData>();

    public static void AddOccurredAnomalyData(OccurredAnomalyData occurredAnomalyData)
    {
        occurredAnomalyDatas.Add(occurredAnomalyData);
    }

    public static void RemoveOccurredAnomalyByData(OccurredAnomalyData occurredAnomalyData)
    {
        occurredAnomalyDatas.Remove(GetOccurredAnomalyDataByData(occurredAnomalyData));
    }

    public static OccurredAnomalyData GetOccurredAnomalyDataByData(OccurredAnomalyData occurredAnomalyData)
    {
        int anomalyRoomID = occurredAnomalyData.AnomalyRoom.AnomalyRoomConfig.ID;
        int anomalyID = occurredAnomalyData.AnomalyData.AnomalyConfig.ID;
        int anomalyObjectID = occurredAnomalyData.AnomalyObject.AnomalyObjectConfig.ID;

        foreach (var oAD in occurredAnomalyDatas)
        {
            if (oAD.AnomalyRoom.AnomalyRoomConfig.ID == anomalyRoomID
            && oAD.AnomalyData.AnomalyConfig.ID == anomalyID
            && oAD.AnomalyObject.AnomalyObjectConfig.ID == anomalyObjectID)
            {
                return oAD;
            }
        }

        Debug.Log("Такая аномалия ещё не произошла. Возврат null.");
        return null;
    }
}