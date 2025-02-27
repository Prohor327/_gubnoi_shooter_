using UnityEngine;
using System;
using UnityEditor.ShaderGraph.Internal;

[Serializable]
public class MovementConfig
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpHeight;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpHeight => _jumpHeight;
}