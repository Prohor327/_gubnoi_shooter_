using System;
using UnityEngine;

[Serializable]
public class Rig
{
    [SerializeField] private Transform _rig;
    [SerializeField] private Transform _camera;

    public Transform RigPoint => _rig;
    public Transform CameraPoint => _camera;
}