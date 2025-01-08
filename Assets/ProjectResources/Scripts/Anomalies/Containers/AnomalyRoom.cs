using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class AnomalyRoom : MonoBehaviour
{
    [field: SerializeField] public RoomConfig RoomConfig { get; private set; }

    public List<AnomalyData> AnomalyDatas { get; private set; } = new List<AnomalyData>();
    public List<AnomalyObject> AnomalyObjects { get; private set; } = new List<AnomalyObject>();



    public List<IAnomaly> Anomalies { get; private set; } = new List<IAnomaly>();
    public List<AnomalyConfig> AnomalyConfigs { get; private set; } = new List<AnomalyConfig>();

    public List<AnomalyObject> UniqueAnomalyObjects { get; private set; } = new List<AnomalyObject>();
    public List<AnomalyObjectConfig> AnomalyObjectConfigs { get; private set; } = new List<AnomalyObjectConfig>();
    public List<AnomalyConfig> UniqueAnomalyConfigs { get; private set; } = new List<AnomalyConfig>();

    public void Initialise()
    {
        SetAllLists();
    }

    #region Lists setting methods
    private void SetAllLists()
    {
        SetAnomalyObjects();
        SetUniqueAnomalyObjects();
        SetAnomalyObjectConfigs();
        SetAnomalyConfigs();
        SetUniqueAnomalyConfigs();
    }

    private void SetAnomalyDatas()
    {
        List<IAnomaly> allAnomaliesOnAnomalyObjects = new List<IAnomaly>();
        foreach (var anomalyObject in AnomalyObjects)
        {
            List<IAnomaly> anomaliesOnAnomalyObject = anomalyObject.GetComponents<IAnomaly>().ToList();

            foreach (var anomaly in anomaliesOnAnomalyObject)
            {
                allAnomaliesOnAnomalyObjects.Add(anomaly);
            }
        }

        List<string> anomalyLocalizationKeysOnAnomalyObjects = new List<string>();
        foreach (var anomalyLocalizationKey in anomalyLocalizationKeysOnAnomalyObjects)
        {
            anomalyLocalizationKeysOnAnomalyObjects.Add(anomalyLocalizationKey);
        }

        for (int i = 0; i < allAnomaliesOnAnomalyObjects.Count; i++)
        {
            AnomalyData newAnomalyData = new AnomalyData(allAnomaliesOnAnomalyObjects[i], anomalyLocalizationKeysOnAnomalyObjects[i]);

            AnomalyDatas.Add(newAnomalyData);
        }
    }

    private void SetAnomalyObjects()
    {
        AnomalyObjects = GetComponentsInChildren<AnomalyObject>().ToList();
    }

    private void SetUniqueAnomalyObjects()
    {
        // Группировка объектов по конфигурации (или другому уникальному признаку)
        UniqueAnomalyObjects = AnomalyObjects
            .GroupBy(obj => obj.anomalyObjectConfig)
            .Select(group => group.First())
            .ToList();
    }

    private void SetAnomalyObjectConfigs()
    {
        AnomalyObjectConfigs = AnomalyObjects
            .Select(obj => obj.anomalyObjectConfig)
            .Distinct() // Убираем дубли
            .ToList();
    }

    private void SetAnomalyConfigs()
    {
        foreach (var anomalyObject in AnomalyObjects)
        {
            foreach (var anomalyConfig in anomalyObject.anomalyObjectConfig.Anomalies)
            {
                AnomalyConfigs.Add(anomalyConfig);
            }
        }
    }

    private void SetUniqueAnomalyConfigs()
    {
        UniqueAnomalyConfigs = AnomalyConfigs
            .GroupBy(config => config.Anomaly) // Группируем по уникальному признаку аномалии
            .Select(group => group.First())   // Берем первую аномалию из каждой группы
            .ToList();
    }
    #endregion

    #region Lists debug log
    public void LogAllLists()
    {
        LogAnomalyObjects();
        LogUniqueAnomalyObjects();
        LogAnomalyObjectConfigs();
        LogAnomalyConfigs();
        LogUniqueAnomalyConfigs();
    }

    public void LogAnomalyObjects()
    {
        Debug.Log($"AnomalyObjects in {gameObject.name}:");
        foreach (var obj in AnomalyObjects)
        {
            Debug.Log(obj);
        }
    }

    public void LogUniqueAnomalyObjects()
    {
        Debug.Log($"UniqueAnomalyObjects in {gameObject.name}:");
        foreach (var obj in UniqueAnomalyObjects)
        {
            Debug.Log(obj);
        }
    }

    public void LogAnomalyObjectConfigs()
    {
        Debug.Log($"AnomalyObjectConfigs in {gameObject.name}:");
        foreach (var config in AnomalyObjectConfigs)
        {
            Debug.Log(config);
        }
    }

    public void LogAnomalyConfigs()
    {
        Debug.Log($"AnomalyConfigs in {gameObject.name}:");
        foreach (var config in AnomalyConfigs)
        {
            Debug.Log(config);
        }
    }

    public void LogUniqueAnomalyConfigs()
    {
        Debug.Log($"UniqueAnomalyConfigs in {gameObject.name}:");
        foreach (var config in UniqueAnomalyConfigs)
        {
            Debug.Log(config);
        }
    }
    #endregion
}
