using System.Collections.Generic;
using UnityEngine;

public class AnomaliesSummonerModel
{
    public AnomalyRoom GetRandomAnomalyRoom(AnomalyRoomsContainer anomalyRoomsContainer)
    {
        List<AnomalyRoom> anomalyRoomsForChoice = new List<AnomalyRoom>();

        foreach (var anomalyRoom in anomalyRoomsContainer.GetAnomalyRooms())
        {
            if (anomalyRoom.GetAllActiveInHierarchyAnomalyObjects().Count > 0)
            {
                anomalyRoomsForChoice.Add(anomalyRoom);
            }
        }

        if (anomalyRoomsForChoice.Count <= 0) throw new System.Exception("Во всех комнатах закончились аномальные объекты");

        return anomalyRoomsForChoice[Random.Range(0, anomalyRoomsForChoice.Count)];;
    }

    public AnomalyObject GetRandomAnomalyObject(AnomalyRoom anomalyRoom)
    {
        List<AnomalyObject> allAnomalyObjectsInRoom = anomalyRoom.GetAllActiveInHierarchyAnomalyObjects();
        if (allAnomalyObjectsInRoom.Count <= 0) throw new System.Exception($"В комнате {anomalyRoom.name} закончились аномальные объекты");

        return allAnomalyObjectsInRoom[Random.Range(0, allAnomalyObjectsInRoom.Count)];
    }

    public IAnomaly GetRandomAnomaly(AnomalyObject anomalyObject)
    {
        List<IAnomaly> anomalies = anomalyObject.GetAnomalies();
        if (anomalies.Count == 0) throw new System.Exception($"На объекте {anomalyObject.name} нет аномалий");

        return anomalies[Random.Range(0, anomalies.Count)];
    }
}