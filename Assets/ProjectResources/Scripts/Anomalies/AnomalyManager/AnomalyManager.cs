using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    private Transform roomsContainer;
    private List<Transform> rooms = new List<Transform>();

    [SerializeField] private float minAnomalyTimeSpan;
    [SerializeField] private float maxAnomalyTimeSpan;
    private Coroutine anomalyTimer;

    private void Awake()
    {
        roomsContainer = GetComponent<Transform>();

        FindAllAnomalyRooms();
    }

    private void Start()
    {
        anomalyTimer = StartCoroutine(AnomalyTimer());
    }

    private void FindAllAnomalyRooms()
    {
        for (int i = 0; i < roomsContainer.childCount; i++)
        {
            rooms.Add(roomsContainer.GetChild(i));
        }
    }

    private void RandomAnomalyOccur()
    {
        Transform randomRoom = rooms[Random.Range(0, rooms.Count)];

        IAnomaly[] anomalies = randomRoom.GetComponentsInChildren<IAnomaly>();

        if (anomalies.Length == 0) throw new System.Exception($"В комнате {randomRoom.name} закончились аномальные объекты");

        IAnomaly randomAnomaly = anomalies[Random.Range(0, anomalies.Length)];
        randomAnomaly.Occur();
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