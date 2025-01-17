using UnityEngine;

[CreateAssetMenu(fileName = "AnomaliesSummonerConfig", menuName = "CONFIGURATIONS/Anomalies/AnomaliesSummonerConfig", order = 0)]
public class AnomaliesSummonerConfig : ScriptableObject
{
    [field: SerializeField] public float minAnomalyTimeSpan { get; private set; }
    [field: SerializeField] public float maxAnomalyTimeSpan { get; private set; }
}