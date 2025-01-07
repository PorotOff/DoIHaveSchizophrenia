using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public abstract class FillingContainerWithButtons : MonoBehaviour
{
    private Transform buttonsContainer;
    private Button buttonPrefab;

    public void Initialise(Button buttonPrefab)
    {
        buttonsContainer = GetComponent<Transform>();
        this.buttonPrefab = buttonPrefab;
    }

    private void OnEnable()
    {
        ReportWindowAnimation.OnReportWindowOpening += DestroyAllButtonsInContainer;
    }
    private void OnDisable()
    {
        ReportWindowAnimation.OnReportWindowOpening -= DestroyAllButtonsInContainer;
    }

    public virtual void FillWithLocalizedButtons()
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

    private void DestroyAllButtonsInContainer()
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