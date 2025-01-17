using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnomalyRoomsContainer : MonoBehaviour
{
    private List<AnomalyRoom> anomalyRooms = new List<AnomalyRoom>();

    public void Initialise()
    {
        anomalyRooms = GetComponentsInChildren<AnomalyRoom>().ToList();

        foreach (AnomalyRoom anomalyRoom in anomalyRooms)
        {
            anomalyRoom.Initialise();
        }
    }

    public List<AnomalyRoom> GetAnomalyRooms()
    {
        return new List<AnomalyRoom>(anomalyRooms);
    }
}