using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public abstract class FillingContainerWithButtons : MonoBehaviour
{
    protected AnomalyReportData anomalyReportData;

    private Transform buttonsContainer;
    private Button buttonPrefab;

    public void Initialise(Button buttonPrefab)
    {
        this.buttonPrefab = buttonPrefab;
        
        buttonsContainer = GetComponent<Transform>();
    }
    public void Initialise(AnomalyReportData anomalyReportData, Button buttonPrefab)
    {
        Initialise(buttonPrefab);

        this.anomalyReportData = anomalyReportData;
    }

    private void OnDisable()
    {
        DestroyAllButtonsInContainer();
    }

    protected virtual void FillWithLocalizedButtons()
    {
        if (buttonsContainer == null) throw new Exception("Не назначен контейнер для кнопок");
        if (buttonPrefab == null) throw new Exception("Не назначен префаб кнопки");

        DestroyAllButtonsInContainer();

        var items = GetItems();
        foreach (var item in items)
        {
            LocalizedString localizedString = GetLocalizedString(item);

            Button newButton = Instantiate(buttonPrefab, buttonsContainer);
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();

            localizedString.StringChanged += (localizedText) =>
            {
                newButton.onClick.RemoveAllListeners();
                newButton.onClick.AddListener(() => OnButtonClick(item));

                buttonText.text = localizedText;
            };
        }
    }

    public void DestroyAllButtonsInContainer()
    {
        foreach (Transform button in buttonsContainer)
        {
            Destroy(button.gameObject);
        }
    }

    protected abstract IEnumerable<object> GetItems();
    protected abstract LocalizedString GetLocalizedString(object item);
    protected abstract void OnButtonClick(object item);
}