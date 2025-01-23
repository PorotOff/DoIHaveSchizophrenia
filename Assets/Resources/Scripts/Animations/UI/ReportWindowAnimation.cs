using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class ReportWindowAnimation : MonoBehaviour
{
    [SerializeField] private GameObject reportWindowBody;

    [SerializeField] private Button reportWindowButton;
    [SerializeField] private LocalizeStringEvent buttonLocalizedText;
    [SerializeField] private string openWindowLocalizedString;
    [SerializeField] private string closeWindowLocalizedString;

    private Sequence sequence;
    [SerializeField] private float animationDuration;

    private void Awake()
    {
        buttonLocalizedText.StringReference.TableEntryReference = openWindowLocalizedString;
        reportWindowButton.onClick.AddListener(UpWindow);

        reportWindowButton.gameObject.SetActive(true);
        reportWindowBody.SetActive(false);
    }

    private void UpWindow()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => reportWindowButton.gameObject.SetActive(false))
            .AppendCallback(() => reportWindowBody.SetActive(true))
            .Append(reportWindowBody.transform
                .DOLocalMoveY(GetReportWindowHeight(), animationDuration)
                .From(0)
                .SetEase(Ease.OutCubic))
            .Join(GetReportWindowCanvasGroup()
                .DOFade(1, animationDuration)
                .From(0)
                .SetEase(Ease.OutCubic))
            .AppendCallback(() => buttonLocalizedText.StringReference.TableEntryReference = closeWindowLocalizedString)
            .AppendCallback(() => reportWindowButton.onClick.RemoveAllListeners())
            .AppendCallback(() => reportWindowButton.onClick.AddListener(DownWindow))
            .AppendCallback(() => reportWindowButton.gameObject.SetActive(true));

        sequence.Play();
    }

    private void DownWindow()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => reportWindowButton.gameObject.SetActive(false))
            .Append(reportWindowBody.transform
                .DOLocalMoveY(0, animationDuration)
                .SetEase(Ease.OutCubic))
            .Join(GetReportWindowCanvasGroup()
                .DOFade(0, animationDuration)
                .SetEase(Ease.OutCubic))
            .AppendCallback(() => reportWindowBody.SetActive(false))
            .AppendCallback(() => buttonLocalizedText.StringReference.TableEntryReference = openWindowLocalizedString)
            .AppendCallback(() => reportWindowButton.onClick.RemoveAllListeners())
            .AppendCallback(() => reportWindowButton.onClick.AddListener(UpWindow))
            .AppendCallback(() => reportWindowButton.gameObject.SetActive(true));

        sequence.Play();
    }

    private float GetReportWindowHeight()
    {
        return reportWindowBody.GetComponent<RectTransform>().rect.height / 2;
    }

    private float GetButtonHeight()
    {
        return reportWindowButton.GetComponent<RectTransform>().rect.height;
    }

    private CanvasGroup GetReportWindowCanvasGroup()
    {
        return reportWindowBody.GetComponent<CanvasGroup>();
    }
}