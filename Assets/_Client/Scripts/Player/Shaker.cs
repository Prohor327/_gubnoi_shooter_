using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    public void ReactOnAttack(ShakeCameraAnimationConfig shakeCameraAnimationConfig)
    {
        AnimationShortCuts.ShakePositionAnimation(_transform, shakeCameraAnimationConfig.PositionConfig);
        AnimationShortCuts.ShakeRotationAnimation(_transform, shakeCameraAnimationConfig.RotationConfig);
    }
}