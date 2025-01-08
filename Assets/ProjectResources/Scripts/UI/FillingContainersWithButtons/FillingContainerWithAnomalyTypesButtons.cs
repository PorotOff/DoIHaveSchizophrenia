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
        return anomalyRoom.UniqueAnomalyConfigs;
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var anomalyConfig = item as AnomalyConfig;
        return new LocalizedString
        {
            TableReference = "AnomalyTypes",
            TableEntryReference = anomalyConfig?.LocalizationKey
        };
    }

    protected override void OnButtonClick(object item)
    {        
        var anomalyConfig = item as AnomalyConfig;

        // AnomalyReportData.SetAnomalyType(anomalyConfig);

        anomalyObjectsButtonsFiller.Initialise(anomalyRoom);
        anomalyObjectsButtonsFiller.FillWithLocalizedButtons();
    }
}