using UnityEngine;
using System;
using UnityEditor.ShaderGraph.Internal;

[Serializable]
public class MovementConfig
{
    [field: SerializeField] public float RunSpeed { get; private set; }
    [field: SerializeField] public float WalkSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float CrouchHeight { get; private set; }
    [field: SerializeField] public float CrouchDuration { get; private set; }
    [field: SerializeField] public float CrouchSpeed { get; private set; }
    [field: SerializeField] public float GravityMultiplier { get; private set; }
}