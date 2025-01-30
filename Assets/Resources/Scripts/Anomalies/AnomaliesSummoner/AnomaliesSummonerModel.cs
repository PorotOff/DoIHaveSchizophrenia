using System.Collections.Generic;
using UnityEngine;

public class AnomaliesSummonerModel
{
    public AnomalyRoom GetRandomAnomalyRoom(AnomalyRoomsContainer anomalyRoomsContainer)
    {
        List<AnomalyRoom> anomalyRooms = new List<AnomalyRoom>();

        foreach (var anomalyRoom in anomalyRoomsContainer.GetAnomalyRooms())
        {
            if (anomalyRoom.GetAnomalyObjectsWithNotOccuredAnomalies().Count > 0)
            {
                anomalyRooms.Add(anomalyRoom);
            }
        }

        if (anomalyRooms.Count <= 0) Debug.LogError("Во всех комнатах не обнаружено аномалий");

        return anomalyRooms[Random.Range(0, anomalyRooms.Count)];
    }

    public AnomalyObject GetRandomAnomalyObject(AnomalyRoom anomalyRoom)
    {
        List<AnomalyObject> anomalyObjects = anomalyRoom.GetAnomalyObjectsWithNotOccuredAnomalies();
        if (anomalyObjects.Count <= 0) Debug.LogError($"В комнате {anomalyRoom.name} закончились аномальные объекты");

        return anomalyObjects[Random.Range(0, anomalyObjects.Count)];
    }

    public AnomalyData GetRandomAnomaly(AnomalyObject anomalyObject)
    {
        List<AnomalyData> anomalies = anomalyObject.AnomalyStateContainerModel.GetNotOccurredAnomalyDatas();
        if (anomalies.Count <= 0) Debug.LogError($"На объекте {anomalyObject.name} нет аномалий");

        return anomalies[Random.Range(0, anomalies.Count)];
    }
}