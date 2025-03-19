using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class ShakeAnimationConfig : AnimationConfig
{
    [field: SerializeField] public ShakeRandomnessMode RandomnessMode { get; private set; }
    [field: SerializeField] public Vector3 Strength { get; private set; }
    [field: SerializeField] public float Randomness { get; private set; }
    [field: SerializeField] public int Vibrato { get; private set; }
    [field: SerializeField] public bool Snapping { get; private set; }
}