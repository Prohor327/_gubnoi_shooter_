using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class ShakeAnimationConfig : AnimationConfig
{
    public ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full;
    public Vector3 strength = Vector3.one;
    public float randomness = 90f;
    public int vibrato = 10;
    public bool snapping;
}