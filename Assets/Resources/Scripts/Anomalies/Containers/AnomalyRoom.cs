using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnomalyRoom : MonoBehaviour
{
    [field: SerializeField] public AnomalyRoomConfig AnomalyRoomConfig { get; private set; }

    private List<AnomalyObject> allAnomalyObjects = new List<AnomalyObject>();
    private List<AnomalyObject> uniqueAnomalyObjects = new List<AnomalyObject>();

    private List<AnomalyData> allAnomalyDatas = new List<AnomalyData>();
    private List<AnomalyData> uniqueAnomalyDatas = new List<AnomalyData>();

    public void Initialise()
    {
        SetAllAnomalyObjects();

        InitialiseAllAnomalyObjects();

        SetUniqueAnomalyObjects();
        SetAllAnomalyDatas();
        SetUniqueAnomalyDatas();
    }

    #region Get data methods
    public List<AnomalyObject> GetAllAnomalyObjects()
    {
        return new List<AnomalyObject>(allAnomalyObjects);
    }
    public List<AnomalyObject> GetAllActiveInHierarchyAnomalyObjects()
    {
        List<AnomalyObject> activeInHierarchyAnomalyObjects = new List<AnomalyObject>();

        foreach (var anomalyObject in GetAllAnomalyObjects())
        {
            if (anomalyObject.gameObject.activeInHierarchy)
            {
                activeInHierarchyAnomalyObjects.Add(anomalyObject);
            }
        }

        return activeInHierarchyAnomalyObjects;
    }

    public List<AnomalyObject> GetUniqueAnomalyObjects()
    {
        return new List<AnomalyObject>(uniqueAnomalyObjects);
    }

    public List<AnomalyData> GetAllAnomalyDatas()
    {
        return new List<AnomalyData>(allAnomalyDatas);
    }

    public List<AnomalyData> GetUniqueAnomalyDatas()
    {
        return new List<AnomalyData>(uniqueAnomalyDatas);
    }
    #endregion

    private void InitialiseAllAnomalyObjects()
    {
        foreach (var anomalyObject in allAnomalyObjects)
        {
            anomalyObject.Initialise(this);
        }
    }

    #region Set data methods
    private void SetAllAnomalyObjects()
    {
        allAnomalyObjects = GetComponentsInChildren<AnomalyObject>().ToList();
    }

    private void SetUniqueAnomalyObjects()
    {
        uniqueAnomalyObjects = allAnomalyObjects
            .GroupBy(anomalyObject => anomalyObject.AnomalyObjectConfig)
            .Select(group => group.First())
            .ToList();
    }

    private void SetAllAnomalyDatas()
    {
        foreach (var anomalyObject in allAnomalyObjects)
        {
            foreach (var anomalyData in anomalyObject.GetNotOccurredAnomalyDatas())
            {
                allAnomalyDatas.Add(anomalyData);
            }
        }
    }

    private void SetUniqueAnomalyDatas()
    {
        uniqueAnomalyDatas = allAnomalyDatas
            .GroupBy(anomalyData => anomalyData.Anomaly.GetType())
            .Select(group => group.First())
            .ToList();
    }
    #endregion

    #region List Logging Methods
    public void LogAllLists()
    {
        LogAllAnomalyObjects();
        LogUniqueAnomalyObjects();
        LogAllAnomalyDatas();
        LogUniqueAnomalyDatas();
    }

    public void LogAllAnomalyObjects()
    {
        foreach (var anomalyObject in allAnomalyObjects)
        {
            Debug.Log($"Room {name}: {anomalyObject}");
        }
    }

    public void LogUniqueAnomalyObjects()
    {
        foreach (var anomalyObject in uniqueAnomalyObjects)
        {
            Debug.Log($"Room {name}: {anomalyObject}");
        }
    }

    public void LogAllAnomalyDatas()
    {
        Debug.Log($"AllAnomalyDatas in room {name}");

        foreach (var anomalyData in allAnomalyDatas)
        {
            Debug.Log($"Room {name}: Anomaly: {anomalyData.Anomaly}, LocalizationKey: {anomalyData.AnomalyConfig.LocalizationKey}");
        }
    }

    public void LogUniqueAnomalyDatas()
    {
        Debug.Log($"UniqueAnomalyDatas in room {name}");

        foreach (var anomalyData in uniqueAnomalyDatas)
        {
            Debug.Log($"Room {name}: Anomaly: {anomalyData.Anomaly}, LocalizationKey: {anomalyData.AnomalyConfig.LocalizationKey}");
        }
    }
    #endregion

}