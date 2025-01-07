using System;
using UnityEngine;

public class AnomalyFixing : MonoBehaviour
{
    private void OnEnable()
    {
        SendAnomalyReport.OnAnomalyReportSended += Fix;
    }
    private void OnDisable()
    {
        SendAnomalyReport.OnAnomalyReportSended -= Fix;
    }

    private void Fix()
    {
        AnomalyConfig anomalyConfig = AnomalyReportData.GetAnomaly();


        // anomaly.Fix();
    }
}