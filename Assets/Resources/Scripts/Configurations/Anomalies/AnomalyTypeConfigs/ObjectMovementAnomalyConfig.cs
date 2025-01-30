using UnityEngine;

[CreateAssetMenu(fileName = "ObjectMovementAnomalyConfig", menuName = "CONFIGURATIONS/Anomalies/AnomalyTypes/ObjectMovementAnomalyConfig", order = 0)]
public class ObjectMovementAnomalyConfig : AnomalyConfig
{
    [SerializeField, Range(0, 10)] private float minForceImpulse;
    [SerializeField, Range(0, 10)] private float maxForceImpulse;

    private void OnValidate()
    {
        if (minForceImpulse > maxForceImpulse)
        {
            maxForceImpulse = minForceImpulse;
        }
    }

    public float GetRandomForceImpulse()
    {
        return Random.Range(minForceImpulse, maxForceImpulse);
    }
}