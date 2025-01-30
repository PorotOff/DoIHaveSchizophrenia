using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyConfigsIDManager", menuName = "CONFIGURATIONS/Anomalies/IDManagement/AnomalyConfigsIDManager", order = 0)]
public class AnomalyConfigsIDManager : ScriptableObject
{
    [SerializeField] private List<AnomalyConfigsGroup> anomalyConfigsGroups = new List<AnomalyConfigsGroup>();

    private void OnValidate()
    {
        SetIDForAll();
    }

    private void SetIDForAll()
    {
        foreach (var anomalyConfigGroup in anomalyConfigsGroups)
        {
            int id = 0;

            foreach (var baseAnomalyConfig in anomalyConfigGroup.BaseAnomalyConfigs)
            {
                baseAnomalyConfig.SetID(id);
                id++;
            }
        }
    }
}