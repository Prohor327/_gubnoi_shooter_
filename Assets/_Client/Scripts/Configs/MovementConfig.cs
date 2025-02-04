using UnityEngine;
using System;

[Serializable]
public class MovementConfig
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
}