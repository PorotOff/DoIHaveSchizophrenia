using System.Collections.Generic;
using UnityEngine;

public class AnomaliesSummonerModel
{
    public AnomalyRoom GetRandomAnomalyRoom(AnomalyRoomsContainer anomalyRoomsContainer)
    {
        return anomalyRoomsContainer.GetAnomalyRooms()[Random.Range(0, anomalyRoomsContainer.GetAnomalyRooms().Count)];
    }

    public AnomalyObject GetRandomAnomalyObject(AnomalyRoom anomalyRoom)
    {
        List<AnomalyObject> allAnomalyObjectsInRoom = anomalyRoom.GetAllActiveInHierarchyAnomalyObjects();
        if (allAnomalyObjectsInRoom == null) throw new System.Exception($"В комнате {anomalyRoom.name} закончились аномальные объекты");

        return allAnomalyObjectsInRoom[Random.Range(0, allAnomalyObjectsInRoom.Count)];
    }

    public IAnomaly GetRandomAnomaly(AnomalyObject anomalyObject)
    {
        List<IAnomaly> anomalies = anomalyObject.GetAnomalies();
        if (anomalies.Count == 0) throw new System.Exception($"На объекте {anomalyObject.name} в комнате нет аномалий");

        return anomalies[Random.Range(0, anomalies.Count)];
    }
}