using UnityEngine;
using Zenject;

public class Shaker : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    // [Inject]
    // private void Construct(Rig rig)
    // {
    //     _cameraTransform = rig.CamerasParent;
    // }

    public void ReactOnAttack(ShakeCameraAnimationConfig shakeCameraAnimationConfig)
    {
        AnimationShortCuts.ShakePositionAnimation(_transform, shakeCameraAnimationConfig.positionConfig);
        AnimationShortCuts.ShakeRotationAnimation(_transform, shakeCameraAnimationConfig.rotationConfig);
    }
}