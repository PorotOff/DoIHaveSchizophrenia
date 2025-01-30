using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class FillingContainerWithAnomalyObjectButtons : FillingContainerWithButtons
{
    private AnomalyRoom anomalyRoom;
    private IAnomaly anomaly;

    public void Initialise(AnomalyRoom anomalyRoom, IAnomaly anomaly)
    {
        this.anomalyRoom = anomalyRoom;
        this.anomaly = anomaly;

        FillWithLocalizedButtons();
    }

    protected override IEnumerable<object> GetItems()
    {
        List<AnomalyObject> anomalyObjectsSortedByAnomaly = new List<AnomalyObject>();

        foreach (var anomalyObject in anomalyRoom.GetUniqueAnomalyObjects())
        {
            foreach (var anomaly in anomalyObject.GetAnomalies())
            {
                if (anomaly.GetType() == this.anomaly.GetType())
                {
                    anomalyObjectsSortedByAnomaly.Add(anomalyObject);
                    break;
                }
            }
        }

        return anomalyObjectsSortedByAnomaly;
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var anomalyObject = item as AnomalyObject;

        return new LocalizedString
        {
            TableReference = "AnomalyObjects",
            TableEntryReference = anomalyObject.AnomalyObjectConfig.LocalizationKey
        };
    }

    protected override void OnButtonClick(object item)
    {        
        var anomalyObject = item as AnomalyObject;

        AnomalyReportData.SetAnomalyObject(anomalyObject);
    }
}