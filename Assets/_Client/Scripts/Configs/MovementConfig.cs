using UnityEngine;
using System;
using UnityEditor.ShaderGraph.Internal;

[Serializable]
public class MovementConfig
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _crouchHeight;
    [SerializeField] private float _crouchDuration;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _gravityMultiplier;

    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float CrouchHeight => _crouchHeight;
    public float CrouchDuration => _crouchDuration;
    public float CrouchSpeed => _crouchSpeed;
    public float GravityMultiplier => _gravityMultiplier;
}