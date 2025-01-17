using System;

public static class AnomalyReportData
{
    public static event Action OnAnomalyReportDataChanged;

    private static AnomalyRoom anomalyRoom = null;
    private static AnomalyData anomalyData = null;
    private static AnomalyObject anomalyObject = null;

    #region Set data methods
        public static void SetAnomalyRoom(AnomalyRoom anomalyRoom)
        {
            AnomalyReportData.anomalyRoom = anomalyRoom;

            anomalyData = null;
            anomalyObject = null;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    
        public static void SetAnomalyData(AnomalyData anomalyData)
        {
            AnomalyReportData.anomalyData = anomalyData;

            anomalyObject = null;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    
        public static void SetAnomalyObject(AnomalyObject anomalyObject)
        {
            AnomalyReportData.anomalyObject = anomalyObject;
    
            OnAnomalyReportDataChanged?.Invoke();
        }
    #endregion

    #region Get data methods
        public static AnomalyRoom GetAnomalyRoom()
        {
            return anomalyRoom;
        }
    
        public static AnomalyData GetAnomalyData()
        {
            return anomalyData;
        }
    
        public static AnomalyObject GetAnomalyObject()
        {
            return anomalyObject;
        }
    #endregion
}