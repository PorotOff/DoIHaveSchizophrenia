using UnityEngine;
using UnityEngine.UI;

public class AnomalyFixing : MonoBehaviour
{
    private AnomalyFixingModel anomalyFixingModel;
    private Button button;

    public void Initialise(AnomalyReportData anomalyReportData)
    {
        anomalyFixingModel = new AnomalyFixingModel(anomalyReportData);
        button = GetComponent<Button>();

        button.onClick.AddListener(anomalyFixingModel.Fix);
    }
}