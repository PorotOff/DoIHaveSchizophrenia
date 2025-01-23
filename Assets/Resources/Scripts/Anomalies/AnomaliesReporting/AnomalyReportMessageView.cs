using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class AnomalyReportMessageView : MonoBehaviour
{
    private AnomalyReportData anomalyReportData;
    private AnomalyReportMessageModel anomalyReportMessageModel;

    [SerializeField] private LocalizedString localizedMessage;
    [SerializeField] private LocalizedString defaultLocalizedText;

    private TMP_Text reportMessage;

    public void Initialise(AnomalyReportData anomalyReportData)
    {
        this.anomalyReportData = anomalyReportData;

        reportMessage = GetComponent<TMP_Text>();

        anomalyReportMessageModel = new AnomalyReportMessageModel(anomalyReportData, localizedMessage, defaultLocalizedText);
    }

    private void OnEnable()
    {
        anomalyReportData.OnAnomalyReportDataChanged += UpdateReportMessage;
        StartCoroutine(LateUpdateReportMessage());
    }
    private void OnDisable()
    {
        anomalyReportData.OnAnomalyReportDataChanged -= UpdateReportMessage;
    }

    private void UpdateReportMessage()
    {
        reportMessage.text = anomalyReportMessageModel.GetFormattedMessage();
    }

    // Этот костыль создан для того, чтобы ReportMessage обновлялся стабильно
    // исключая ошибок из-за порядка вызова всяких методов.
    private IEnumerator LateUpdateReportMessage()
    {
        yield return null;
        UpdateReportMessage();
    }
}
