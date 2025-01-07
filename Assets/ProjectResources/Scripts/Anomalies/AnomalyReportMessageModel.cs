using TMPro;
using UnityEngine.Localization;

public class AnomalyReportMessageModel
{
    private LocalizedString localizedMessage { get; set; }
    private LocalizedString defaultLocalizedMessage { get; set; }

    private TMP_Text reportMessage { get; set; }

    public AnomalyReportMessageModel(LocalizedString localizedMessage, LocalizedString defaultLocalizedMessage, TMP_Text reportMessage)
    {
        this.localizedMessage = localizedMessage;
        this.defaultLocalizedMessage = defaultLocalizedMessage;

        this.reportMessage = reportMessage;
    }

    public void UpdateReportMessage()
    {
        localizedMessage.StringChanged -= OnStringChanged;
        localizedMessage.StringChanged += OnStringChanged;

        OnStringChanged(localizedMessage.GetLocalizedString());
        localizedMessage.RefreshString();
    }

    private void OnStringChanged(string localizedString)
    {
        string anomalyRoomLocalizationKey = GetLocalizedValue("AnomalyLocations", AnomalyReportData.GetAnomalyRoom()?.RoomConfig?.LocalisationKey);
        string anomalyTypeLocalizationKey = GetLocalizedValue("AnomalyTypes", AnomalyReportData.GetAnomaly()?.LocalizationKey);
        string anomalyObjectLocalizationKey = GetLocalizedValue("AnomalyObjects", AnomalyReportData.GetAnomalyObject()?.anomalyObjectConfig.LocalizationKey);
        string defaultLocalizedMessageLocalizationKey = defaultLocalizedMessage.GetLocalizedString();

        string anomalyRoomLocalizationString = anomalyRoomLocalizationKey ?? defaultLocalizedMessageLocalizationKey;
        string anomalyTypeLocalizationString = anomalyTypeLocalizationKey ?? defaultLocalizedMessageLocalizationKey;
        string anomalyObjectLocalizationString = anomalyObjectLocalizationKey ?? defaultLocalizedMessageLocalizationKey;

        string formattedMessage = localizedString
                .Replace("{anomalyRoom}", anomalyRoomLocalizationString)
                .Replace("{anomalyType}", anomalyTypeLocalizationString)
                .Replace("{anomalyObject}", anomalyObjectLocalizationString);

        reportMessage.text = formattedMessage;
    }

    private string GetLocalizedValue(string tableReference, string localizationKey)
    {
        if (string.IsNullOrEmpty(tableReference)) return null;
        if (string.IsNullOrEmpty(localizationKey)) return null;

        LocalizedString newLocalizedString = new LocalizedString
        {
            TableReference = tableReference,
            TableEntryReference = localizationKey
        };

        return newLocalizedString.GetLocalizedString();
    }
}