using UnityEngine;
using Zenject;

public class Shaker : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    public void ReactOnAttack(ShakeCameraAnimationConfig shakeCameraAnimationConfig)
    {
        AnimationShortCuts.ShakePositionAnimation(_transform, shakeCameraAnimationConfig.positionConfig);
        AnimationShortCuts.ShakeRotationAnimation(_transform, shakeCameraAnimationConfig.rotationConfig);
    }
}