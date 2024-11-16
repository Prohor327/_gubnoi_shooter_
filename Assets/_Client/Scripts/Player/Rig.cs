using System;
using UnityEngine;

[Serializable]
public class Rig
{
    [SerializeField] private Transform _rig;

    public Transform RigPoint => _rig;
}