using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class AnomalyReportMessageView : MonoBehaviour
{
    private AnomalyReportMessageModel anomalyReportMessageModel;

    [SerializeField] private LocalizedString localizedMessage;
    [SerializeField] private LocalizedString defaultLocalizedMessage;

    private TMP_Text reportMessage;

    private void Awake()
    {
        reportMessage = GetComponent<TMP_Text>();

        anomalyReportMessageModel = new AnomalyReportMessageModel(localizedMessage, defaultLocalizedMessage, reportMessage);
        anomalyReportMessageModel.UpdateReportMessage();
    }

    private void OnEnable()
    {
        AnomalyReportData.OnAnomalyReportDataChanged += anomalyReportMessageModel.UpdateReportMessage;
    }

    private void OnDisable()
    {
        AnomalyReportData.OnAnomalyReportDataChanged -= anomalyReportMessageModel.UpdateReportMessage;
    }
}
