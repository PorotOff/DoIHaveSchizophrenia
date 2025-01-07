using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class FillingContainerWithAnomalyObjectButtons : FillingContainerWithButtons
{
    private AnomalyRoom anomalyRoom;

    public void Initialise(AnomalyRoom anomalyRoom)
    {
        this.anomalyRoom = anomalyRoom;

        FillWithLocalizedButtons();
    }

    protected override IEnumerable<object> GetItems()
    {
        return anomalyRoom.UniqueAnomalyObjects;
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var anomalyObject = item as AnomalyObject;
        var anomalyObjectConfig = anomalyObject.anomalyObjectConfig;

        return new LocalizedString
        {
            TableReference = "AnomalyObjects",
            TableEntryReference = anomalyObjectConfig.LocalizationKey
        };
    }

    protected override void OnButtonClick(object item)
    {
        var anomalyObject = item as AnomalyObject;
        var anomalyObjectLocalizationKey = anomalyObject.anomalyObjectConfig.LocalizationKey;

        AnomalyReportData.SetAnomalyObject(anomalyObject);

        Debug.Log($"Нажата кнопка {anomalyObjectLocalizationKey}");
    }
}