using System;

public static class AnomalyReportData
{
    public static event Action OnAnomalyReportDataChanged;

    private static AnomalyRoom anomalyRoom { get; set; }
    private static IAnomaly anomaly { get; set; }
    private static AnomalyObject anomalyObject { get; set; }

    public static void SetAnomalyRoom(AnomalyRoom anomalyRoom)
    {
        AnomalyReportData.anomalyRoom = anomalyRoom;

        OnAnomalyReportDataChanged?.Invoke();
    }

    public static void SetAnomaly(IAnomaly anomaly)
    {
        AnomalyReportData.anomaly = anomaly;

        OnAnomalyReportDataChanged?.Invoke();
    }

    public static void SetAnomalyObject(AnomalyObject anomalyObject)
    {
        AnomalyReportData.anomalyObject = anomalyObject;

        OnAnomalyReportDataChanged?.Invoke();
    }

    public static AnomalyRoom GetAnomalyRoom()
    {
        if (anomalyRoom == null) throw new Exception("Ещё не выбрана комната");

        return anomalyRoom;
    }

    public static IAnomaly GetAnomaly()
    {
        if (anomaly == null) throw new Exception("Ещё не выбрана аномалия");

        return anomaly;
    }

    public static AnomalyObject GetAnomalyObject()
    {
        if (anomalyObject == null) throw new Exception("Ещё не выбран объект");

        return anomalyObject;
    }
}