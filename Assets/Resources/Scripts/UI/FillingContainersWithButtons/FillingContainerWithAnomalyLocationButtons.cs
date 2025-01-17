using System.Collections.Generic;
using UnityEngine.Localization;

public class FillingContainerWithAnomalyLocationButtons : FillingContainerWithButtons
{
    private AnomalyRoomsContainer anomalyRoomsContainer;

    private FillingContainerWithAnomalyTypesButtons anomalyTypesButtonsFiller;
    private FillingContainerWithAnomalyObjectButtons anomalyObjectsButtonsFiller;

    public void Initialise(
        AnomalyRoomsContainer anomalyRoomsContainer,
        FillingContainerWithAnomalyTypesButtons anomalyTypesButtonsFiller,
        FillingContainerWithAnomalyObjectButtons anomalyObjectsButtonsFiller)
    {
        this.anomalyRoomsContainer = anomalyRoomsContainer;

        this.anomalyTypesButtonsFiller = anomalyTypesButtonsFiller;
        this.anomalyObjectsButtonsFiller = anomalyObjectsButtonsFiller;
    }

    private void OnEnable()
    {
        FillWithLocalizedButtons();
    }

    protected override IEnumerable<object> GetItems()
    {
        return anomalyRoomsContainer.GetAnomalyRooms();
    }

    protected override LocalizedString GetLocalizedString(object item)
    {
        var anomalyRoom = item as AnomalyRoom;

        return new LocalizedString
        {
            TableReference = "AnomalyLocations",
            TableEntryReference = anomalyRoom.GetLocalizationKey()
        };
    }

    protected override void OnButtonClick(object item)
    {
        var anomalyRoom = item as AnomalyRoom;

        AnomalyReportData.SetAnomalyRoom(anomalyRoom);

        anomalyTypesButtonsFiller.Initialise(anomalyRoom, anomalyObjectsButtonsFiller);
        anomalyObjectsButtonsFiller.DestroyAllButtonsInContainer();
    }
}