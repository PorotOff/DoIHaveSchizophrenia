using DG.Tweening;
using UnityEngine;

public class BackAndForthAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 startRotationPosition;
    [SerializeField] private Vector3 endRotationPosition;

    private SecurityCameraConfig videoCameraConfig;

    private Sequence backAndForthSequence;

    public void Initialise(SecurityCameraConfig videoCameraConfig)
    {
        this.videoCameraConfig = videoCameraConfig;

        MoveBackAndForth();
    }

    private void OnDestroy()
    {
        backAndForthSequence.Kill();
    }

    private void MoveBackAndForth()
    {
        transform.rotation = Quaternion.Euler(startRotationPosition);

        backAndForthSequence = DOTween.Sequence();

        backAndForthSequence
            .Append(transform
                .DORotate(endRotationPosition, videoCameraConfig.RotationDuration)
                .SetEase(Ease.Linear))
            .AppendInterval(videoCameraConfig.WaitDuration)
            .Append(transform
                .DORotate(startRotationPosition, videoCameraConfig.RotationDuration)
                .SetEase(Ease.Linear))
            .AppendInterval(videoCameraConfig.WaitDuration)
            .SetLoops(-1, LoopType.Restart);


        backAndForthSequence.Play();
    }
}