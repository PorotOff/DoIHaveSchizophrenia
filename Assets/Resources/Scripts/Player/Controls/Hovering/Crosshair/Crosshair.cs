using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Crosshair : MonoBehaviour, IHoverable
{
    private CanvasGroup canvasGroup;
    private Sequence sequence;

    private CrosshairConfig crosshairConfig;
    private RaycastHovering raycastDetection;

    public void Initialize(CrosshairConfig crosshairConfig, RaycastHovering raycastDetection)
    {
        canvasGroup = GetComponent<CanvasGroup>();

        this.crosshairConfig = crosshairConfig;
        this.raycastDetection = raycastDetection;

        LightDownCrosshair();

        transform.localScale = new Vector3(crosshairConfig.Size, crosshairConfig.Size, crosshairConfig.Size);
    }

    public void OnHover()
    {
        LightUpCrosshair();
    }
    public void OnUnhover()
    {
        LightDownCrosshair();
    }

    private void LightUpCrosshair()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence.Append(canvasGroup
            .DOFade(crosshairConfig.OnHoveringAlpha, crosshairConfig.FadeDuration)
            .SetEase(crosshairConfig.Ease));

        sequence.Play();
    }

    private void LightDownCrosshair()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence.Append(canvasGroup
            .DOFade(crosshairConfig.StandartAlpha, crosshairConfig.FadeDuration)
            .SetEase(crosshairConfig.Ease));

        sequence.Play();
    }
}