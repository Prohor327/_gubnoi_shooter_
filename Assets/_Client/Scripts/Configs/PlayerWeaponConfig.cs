using System;
using UnityEngine;

[Serializable]
public class PlayerWeaponConfig : ScriptableObject 
{
    [SerializeField] private WeaponType[] _weapons;
}