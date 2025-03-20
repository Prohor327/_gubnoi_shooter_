using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class AnimationConfig
{
    [field: SerializeField] public bool isOn { get; private set; } = true;
    [field: SerializeField] public float Duration { get; private set; } = 1f;
    [field: SerializeField] public Ease ease { get; private set; } = DOTween.defaultEaseType;
}