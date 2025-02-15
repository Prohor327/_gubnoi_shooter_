using System;
using UnityEngine;

[Serializable]
public class ShakeCameraAnimationConfig
{
    [SerializeField] private ShakeAnimationConfig _positionConfig;
    [SerializeField] private ShakeAnimationConfig _rotationConfig;

    public ShakeAnimationConfig positionConfig => _positionConfig;
    public ShakeAnimationConfig rotationConfig => _rotationConfig;
}