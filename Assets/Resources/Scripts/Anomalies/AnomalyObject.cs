using System.Collections.Generic;
using UnityEngine;
using System;

public class AnomalyObject : MonoBehaviour
{
    [field: SerializeField] public AnomalyObjectConfig anomalyObjectConfig { get; private set; }

    private List<AnomalyData> anomalyDatas = new List<AnomalyData>();

    public void Initialise()
    {
        AddAnomalyComponents();
        InitialiseAllAnomalies();
    }

    #region Get data methods
    public List<AnomalyData> GetAnomalyDatas()
    {
        return new List<AnomalyData>(anomalyDatas);
    }

    public List<IAnomaly> GetAnomalies()
    {
        List<IAnomaly> anomalies = new List<IAnomaly>();

        foreach (var anomalyData in anomalyDatas)
        {
            anomalies.Add(anomalyData.Anomaly);
        }

        return anomalies;
    }

    public IAnomaly GetAnomalyByAnomalyType(IAnomaly anomalyType)
    {
        foreach (var anomaly in GetAnomalies())
        {
            if (anomaly.GetType() == anomalyType.GetType())
            {
                return anomaly;
            }
        }

        Debug.Log($"Не найдена аномалия по такому типу аномалии. Возврат null");
        return null;
    }

    public string GetLocalizationKey()
    {
        return anomalyObjectConfig.LocalizationKey;
    }
    #endregion

    public bool HasAnomalyByAnomalyType(IAnomaly anomalyType)
    {
        foreach (var anomalyData in anomalyDatas)
        {
            if (anomalyData.Anomaly.GetType() == anomalyType.GetType())
            {
                return true;
            }
        }

        Debug.Log($"Не найдена аномалия по такому типу аномалии.");
        return false;
    }

    private void AddAnomalyComponents()
    {
        foreach (var anomalyConfig in anomalyObjectConfig.Anomalies)
        {
            Type anomalyType = anomalyConfig.GetAnomaly();

            Component newAnomalyComponent = gameObject.AddComponent(anomalyType);

            SetAnomalyData(newAnomalyComponent as IAnomaly, anomalyConfig.LocalizationKey);
        }
    }

    private void SetAnomalyData(IAnomaly anomaly, string localizationKey)
    {
        anomalyDatas.Add(new AnomalyData(anomaly, localizationKey));
    }

    private void InitialiseAllAnomalies()
    {
        foreach (var anomalyData in anomalyDatas)
        {
            anomalyData.Anomaly.Initialise();
        }
    }
}