using System;
using UnityEngine;

[Serializable]
public class ShakeCameraAnimationConfig
{
    [field: SerializeField] public ShakeAnimationConfig PositionConfig { get; private set; }
    [field: SerializeField] public ShakeAnimationConfig RotationConfig { get; private set; }
}