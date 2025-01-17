using System.Collections.Generic;
using UnityEngine.Localization;

public class FillingContainerWithAnomalyTypesButtons : FillingContainerWithButtons
{
    private AnomalyRoom anomalyRoom;
    private FillingContainerWithAnomalyObjectButtons anomalyObjectsButtonsFiller;

    public void Initialise(AnomalyRoom anomalyRoom, FillingContainerWithAnomalyObjectButtons anomalyObjectsButtonsFiller)
    {
        this.anomalyRoom = anomalyRoom;
        this.anomalyObjectsButtonsFiller = anomalyObjectsButtonsFiller;

        FillWithLocalizedButtons();
    }

    protected override IEnumerable<object> GetItems()
    {
        return anomalyRoom.GetUniqueAnomalyDatas();
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var anomalyData = item as AnomalyData;

        return new LocalizedString
        {
            TableReference = "AnomalyTypes",
            TableEntryReference = anomalyData.LocalizationKey
        };
    }

    protected override void OnButtonClick(object item)
    {        
        var anomalyData = item as AnomalyData;

        AnomalyReportData.SetAnomalyData(anomalyData);

        anomalyObjectsButtonsFiller.Initialise(anomalyRoom, anomalyData.Anomaly);
    }
}