using UnityEngine.Localization;

public class AnomalyReportMessageModel
{
    private AnomalyReportData anomalyReportData;

    private LocalizedString localizedMessage;
    private LocalizedString defaultLocalizedText;

    public AnomalyReportMessageModel(AnomalyReportData anomalyReportData, LocalizedString localizedMessage, LocalizedString defaultLocalizedText)
    {
        this.anomalyReportData = anomalyReportData;
        this.localizedMessage = localizedMessage;
        this.defaultLocalizedText = defaultLocalizedText;
    }

    public string GetFormattedMessage()
    {
        string anomalyRoomLocalizationKey = GetLocalizedValue("AnomalyLocations", anomalyReportData.GetAnomalyRoom()?.GetLocalizationKey());
        string anomalyTypeLocalizationKey = GetLocalizedValue("AnomalyTypes", anomalyReportData.GetAnomalyData()?.LocalizationKey);
        string anomalyObjectLocalizationKey = GetLocalizedValue("AnomalyObjects", anomalyReportData.GetAnomalyObject()?.GetLocalizationKey());
        string defaultLocalizedTextLocalizationKey = defaultLocalizedText.GetLocalizedString();

        string anomalyRoomLocalizationString = anomalyRoomLocalizationKey ?? defaultLocalizedTextLocalizationKey;
        string anomalyTypeLocalizationString = anomalyTypeLocalizationKey ?? defaultLocalizedTextLocalizationKey;
        string anomalyObjectLocalizationString = anomalyObjectLocalizationKey ?? defaultLocalizedTextLocalizationKey;

        string formattedMessage = localizedMessage.GetLocalizedString()
                .Replace("{anomalyRoom}", anomalyRoomLocalizationString)
                .Replace("{anomalyType}", anomalyTypeLocalizationString)
                .Replace("{anomalyObject}", anomalyObjectLocalizationString);

        return formattedMessage;
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