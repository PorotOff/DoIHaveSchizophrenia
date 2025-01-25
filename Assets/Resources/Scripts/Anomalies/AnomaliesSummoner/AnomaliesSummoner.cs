using System.Collections;
using UnityEngine;

public class AnomaliesSummoner : MonoBehaviour
{
    private AnomaliesSummonerModel anomaliesSummonerModel;

    private AnomalyRoomsContainer anomalyRoomsContainer;  
    private AnomaliesSummonerConfig anomaliesSummonerConfig;

    public void Initialize(AnomalyRoomsContainer anomalyRoomsContainer, AnomaliesSummonerConfig anomaliesSummonerConfig)
    {
        anomaliesSummonerModel = new AnomaliesSummonerModel();

        this.anomalyRoomsContainer = anomalyRoomsContainer;
        this.anomaliesSummonerConfig = anomaliesSummonerConfig;
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
        AnomalyRoom randomAnomalyRoom = anomaliesSummonerModel.GetRandomAnomalyRoom(anomalyRoomsContainer);
        AnomalyObject randomAnomalyObject = anomaliesSummonerModel.GetRandomAnomalyObject(randomAnomalyRoom);
        IAnomaly randomAnomaly = anomaliesSummonerModel.GetRandomAnomaly(randomAnomalyObject);
        
        randomAnomaly.Occur();
    }
}