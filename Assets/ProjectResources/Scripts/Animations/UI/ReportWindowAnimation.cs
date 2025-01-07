using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class ReportWindowAnimation : MonoBehaviour
{
    public static event Action OnReportWindowOpening;

    [SerializeField] private GameObject window;

    [SerializeField] private Button button;
    [SerializeField] private LocalizeStringEvent buttonLocalizedText;
    [SerializeField] private string openWindowLocalizedString;
    [SerializeField] private string closeWindowLocalizedString;

    private Sequence sequence;
    [SerializeField] private float animationDuration;

    private void Awake()
    {
        // buttonLocalizedText = button.GetComponent<TMP_Text>().GetComponent<LocalizeStringEvent>();

        buttonLocalizedText.StringReference.TableEntryReference = openWindowLocalizedString;
        button.onClick.AddListener(UpWindow);

        button.gameObject.SetActive(true);
        window.SetActive(false);
    }

    public void UpWindow()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => button.gameObject.SetActive(false))
            .AppendCallback(() => window.SetActive(true))
            .AppendCallback(() => OnReportWindowOpening?.Invoke())
            .Append(window.transform
                .DOMoveY(GetReportWindowHeight() + GetButtonHeight(), animationDuration)
                .From(0)
                .SetEase(Ease.OutCubic))
            .Join(GetReportWindowCanvasGroup()
                .DOFade(1, animationDuration)
                .From(0)
                .SetEase(Ease.OutCubic))
            .AppendCallback(() => buttonLocalizedText.StringReference.TableEntryReference = closeWindowLocalizedString)
            .AppendCallback(() => button.onClick.RemoveAllListeners())
            .AppendCallback(() => button.onClick.AddListener(DownWindow))
            .AppendCallback(() => button.gameObject.SetActive(true));

        sequence.Play();
    }

    public void DownWindow()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => button.gameObject.SetActive(false))
            .Append(window.transform
                .DOMoveY(0, animationDuration)
                .SetEase(Ease.OutCubic))
            .Join(GetReportWindowCanvasGroup()
                .DOFade(0, animationDuration)
                .SetEase(Ease.OutCubic))
            .AppendCallback(() => window.SetActive(false))
            .AppendCallback(() => buttonLocalizedText.StringReference.TableEntryReference = openWindowLocalizedString)
            .AppendCallback(() => button.onClick.RemoveAllListeners())
            .AppendCallback(() => button.onClick.AddListener(UpWindow))
            .AppendCallback(() => button.gameObject.SetActive(true));

        sequence.Play();
    }

    private float GetReportWindowHeight()
    {
        return window.GetComponent<RectTransform>().rect.height;
    }

    private float GetButtonHeight()
    {
        return button.GetComponent<RectTransform>().rect.height * 2;
    }

    private CanvasGroup GetReportWindowCanvasGroup()
    {
        return window.GetComponent<CanvasGroup>();
    }
}