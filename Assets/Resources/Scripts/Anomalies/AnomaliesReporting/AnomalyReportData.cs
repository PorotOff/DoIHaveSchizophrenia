using System;
using UnityEngine;

public class AnomalyReportData
{
    public event Action OnAnomalyReportDataChanged;

    private AnomalyRoom anomalyRoom;
    private AnomalyData anomalyData;
    private AnomalyObject anomalyObject;

    #region Set data methods
    public void SetAnomalyRoom(AnomalyRoom anomalyRoom)
        {
            this.anomalyRoom = anomalyRoom;

            anomalyData = null;
            anomalyObject = null;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    
        public void SetAnomalyData(AnomalyData anomalyData)
        {
            this.anomalyData = anomalyData;

            anomalyObject = null;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    
        public void SetAnomalyObject(AnomalyObject anomalyObject)
        {
            this.anomalyObject = anomalyObject;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    #endregion

    #region Get data methods
        public AnomalyRoom GetAnomalyRoom()
        {
            Debug.Log($"Getting anomaly room: {anomalyRoom.name}");

            return anomalyRoom;
        }
    
        public AnomalyData GetAnomalyData()
        {
            Debug.Log($"Getting anomaly data: anomaly: {anomalyData.Anomaly}, localizationKey: {anomalyData.LocalizationKey}");

            return anomalyData;
        }
    
        public AnomalyObject GetAnomalyObject()
        {
            Debug.Log($"Getting anomaly object: {anomalyObject.name}");

            return anomalyObject;
        }
    #endregion
}