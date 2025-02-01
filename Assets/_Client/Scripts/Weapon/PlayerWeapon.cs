using System;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    [SerializeField] protected WeaponAnimations weaponAnimations;
    //[SerializeField] private ShakeCameraAnimationSO _shakeAnimationConfig;

    public event Action onPutAway;
    //public event Action<ShakeCameraAnimationSO> onShoot;
}
