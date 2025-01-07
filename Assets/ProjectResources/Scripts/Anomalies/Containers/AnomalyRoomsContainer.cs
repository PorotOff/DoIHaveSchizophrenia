using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnomalyRoomsContainer : MonoBehaviour
{
    public List<AnomalyRoom> anomalyRooms { get; private set; } = new List<AnomalyRoom>();

    public void Initialise()
    {
        anomalyRooms = GetComponentsInChildren<AnomalyRoom>().ToList();

        foreach (AnomalyRoom anomalyRoom in anomalyRooms)
        {
            anomalyRoom.Initialise();
        }
    }
}