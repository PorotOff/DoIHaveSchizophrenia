using UnityEngine;
using UnityEngine.UI;

public class SendAnomalyReport : MonoBehaviour
{
    private AnomalyFixingModel anomalyFixingModel;
    private Button button;

    private void Awake()
    {
        anomalyFixingModel = new AnomalyFixingModel();
        button = GetComponent<Button>();

        button.onClick.AddListener(anomalyFixingModel.Fix);
    }
}