using UnityEngine;

[CreateAssetMenu(menuName = "Game/ShakeCameraAnimationSO")]
public class ShakeCameraAnimationSO : ScriptableObject
{
    [SerializeField] private ShakeCameraAnimationConfig _shakeCameraAnimationConfig;

    public ShakeCameraAnimationConfig ShakeCameraAnimationConfig => _shakeCameraAnimationConfig;
}