using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    private AnomalyRoomsContainer anomalyRoomsContainer;
    private OccuredAnomaliesContainer occuredAnomaliesContainer;

    [SerializeField] private float minAnomalyTimeSpan;
    [SerializeField] private float maxAnomalyTimeSpan;
    private Coroutine anomalyTimer;

    public void Initialize(AnomalyRoomsContainer anomalyRoomsContainer, OccuredAnomaliesContainer occuredAnomaliesContainer)
    {
        this.anomalyRoomsContainer = anomalyRoomsContainer;
        this.occuredAnomaliesContainer = occuredAnomaliesContainer;
    }

    public void StartUp()
    {
        anomalyTimer = StartCoroutine(AnomalyTimer());
    }

    private void RandomAnomalyOccur()
    {
        AnomalyRoom randomAnomalyRoom = anomalyRoomsContainer.anomalyRooms[Random.Range(0, anomalyRoomsContainer.anomalyRooms.Count)];
        
        AnomalyObject randomAnomalyObject = randomAnomalyRoom.AnomalyObjects[Random.Range(0, randomAnomalyRoom.AnomalyObjects.Count)];
        if (randomAnomalyObject == null) throw new System.Exception($"В комнате {randomAnomalyRoom.name} закончились аномальные объекты");

        List<IAnomaly> anomalies = randomAnomalyObject.GetComponents<IAnomaly>().ToList();
        if (anomalies.Count == 0) throw new System.Exception($"На объекте {randomAnomalyObject.name} в комнате {randomAnomalyRoom.name} нет аномалий");

        IAnomaly randomAnomaly = anomalies[Random.Range(0, anomalies.Count)];
        
        randomAnomaly.Occur();

        OccuredAnomalyData newOccuredAnomaly = new OccuredAnomalyData(randomAnomalyObject, randomAnomaly);
        occuredAnomaliesContainer.AddOcuredAnomaly(newOccuredAnomaly);
    }

    private IEnumerator AnomalyTimer()
    {
        while (true)
        {
            float randomTimeSpan = Random.Range(minAnomalyTimeSpan, maxAnomalyTimeSpan);
            yield return new WaitForSeconds(randomTimeSpan);

            RandomAnomalyOccur();
        }
    }
}