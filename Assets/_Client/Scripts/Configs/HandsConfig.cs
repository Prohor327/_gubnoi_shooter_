using System;
using UnityEngine;

[Serializable]
public class HandsConfig
{
    [SerializeField] private float _distance;

    public float Distance => _distance;
}
