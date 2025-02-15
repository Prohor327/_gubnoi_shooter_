using System;
using UnityEngine;

[Serializable]
public class Rig
{
    [SerializeField] private Transform _rig;
    [SerializeField] private Transform _camerasParent;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private Camera _weaponCamera;

    public Transform RigPoint => _rig;
    public Camera PlayerCamera => _camera;
    public Camera WeaponCamera => _weaponCamera;
    public Transform WeaponPoint => _weaponPoint;
    public Transform CamerasParent => _camerasParent;
}