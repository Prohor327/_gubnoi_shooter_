using UnityEngine;
using Zenject;

public class ShakeCameraOnWeaponAttack : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    // [Inject]
    // private void Construct(Rig rig)
    // {
    //     _cameraTransform = rig.CamerasParent;
    // }

    public void ReactOnAttack(ShakeCameraAnimationConfig shakeCameraAnimationConfig)
    {
        AnimationShortCuts.ShakePositionAnimation(_cameraTransform, shakeCameraAnimationConfig.positionConfig);
        AnimationShortCuts.ShakeRotationAnimation(_cameraTransform, shakeCameraAnimationConfig.rotationConfig);
    }
}