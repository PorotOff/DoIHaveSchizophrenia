using System.Collections;
using UnityEngine;

public class AnomaliesSummoner : MonoBehaviour
{
    private AnomaliesSummonerModel anomaliesSummonerModel;

    private AnomalyRoomsContainer anomalyRoomsContainer;  
    private AnomaliesSummonerConfig anomaliesSummonerConfig;

    public void Initialize(AnomalyRoomsContainer anomalyRoomsContainer, AnomaliesSummonerConfig anomaliesSummonerConfig)
    {
        this.anomalyRoomsContainer = anomalyRoomsContainer;
        this.anomaliesSummonerConfig = anomaliesSummonerConfig;

        anomaliesSummonerModel = new AnomaliesSummonerModel();
    }

    public void StartUp()
    {
        StartCoroutine(SummonAnomalies());
    }

    private IEnumerator SummonAnomalies()
    {
        while (true)
        {
            float randomTimeSpan = Random.Range(anomaliesSummonerConfig.minAnomalyTimeSpan, anomaliesSummonerConfig.maxAnomalyTimeSpan);
            yield return new WaitForSeconds(randomTimeSpan);

            SummonRandomAnomaly();
        }
    }

    private void SummonRandomAnomaly()
    {
        AnomalyRoom anomalyRoom = anomaliesSummonerModel.GetRandomAnomalyRoom(anomalyRoomsContainer);
        AnomalyObject anomalyObject = anomaliesSummonerModel.GetRandomAnomalyObject(anomalyRoom);
        AnomalyData anomalyData = anomaliesSummonerModel.GetRandomAnomaly(anomalyObject);
        
        anomalyObject.OccurAnomaly(anomalyData);
    }
}