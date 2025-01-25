using UnityEngine;

public class BaseAnomalyType : MonoBehaviour, IAnomaly
{
    public bool isOccured { get; private set; }

    private AnomalyObject anomalyObject;

    public virtual void Initialise()
    {
        anomalyObject = GetComponent<AnomalyObject>();

        if (anomalyObject == null) Debug.LogWarning("На текущем объекте нет компонента AnomalyObject");
    }

    public virtual void Occur()
    {
        OccuredAnomaliesContainer.AddOccuredAnomalyData(new OccuredAnomalyData(anomalyObject, this));
    }

    public virtual void Fix()
    {
        OccuredAnomaliesContainer.RemoveOccuredAnomalyByData(new OccuredAnomalyData(anomalyObject, this));
    }
}