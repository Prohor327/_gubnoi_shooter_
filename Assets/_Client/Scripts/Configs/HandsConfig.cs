using System;
using UnityEngine;

[Serializable]
public class HandsConfig
{
    [SerializeField] private float _distance;
    [SerializeField] private float _throwingForce;

    public float Distance => _distance;
    public float ThrowingForce => _throwingForce;
}
