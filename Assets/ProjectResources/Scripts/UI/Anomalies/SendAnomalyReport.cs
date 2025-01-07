using System;
using UnityEngine;
using UnityEngine.UI;

public class SendAnomalyReport : MonoBehaviour
{
    public static event Action OnAnomalyReportSended;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        OnAnomalyReportSended?.Invoke();
    }
}