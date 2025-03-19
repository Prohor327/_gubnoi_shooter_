using UnityEngine;

[CreateAssetMenu(menuName = "Game/ShakeCameraAnimationSO")]
public class ShakeCameraAnimationSO : ScriptableObject
{
    [field: SerializeField] public ShakeCameraAnimationConfig ShakeCameraAnimationConfig { get; private set; }
}