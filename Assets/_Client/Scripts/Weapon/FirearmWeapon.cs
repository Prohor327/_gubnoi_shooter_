using UnityEngine;
using System;

public abstract class FirearmWeapon : Weapon
{
    [Header("Magazine")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _clipSize;

    [Header("VFX")]
    [SerializeField] private BulletHole bulletHole;

    [SerializeField] private int _amountAmmoInClip;
    private Ammo _ammo;

    protected Transform shootPoint;

    public AmmoType AmmoType => _ammoType;

    public Action<string> OnChangedAmountAmmoInClip;

    public override void Take()
    {
        base.Take();
        OnChangedAmountAmmoInClip.Invoke(_amountAmmoInClip.ToString() + "/" + _ammo.GetAmountAmmo(_ammoType));
    }

    public virtual void Initialize(Transform shootPoint, PlayerSound playerSound, Ammo ammo)
    {
        this.shootPoint = shootPoint;
        base.Initialize(playerSound);
        _ammo = ammo;
        Reload();
    }

    protected void SpawnBulletHole(RaycastHit hit)
    {
        Instantiate(bulletHole.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }

    public override void Attack()
    {
        if(_amountAmmoInClip <= 0)        
        {
            Reload();
            return;
        }
        base.Attack();
    }

    public override void PreformAttack()
    {
        _amountAmmoInClip--;

        OnChangedAmountAmmoInClip.Invoke(_amountAmmoInClip.ToString() + "/" + _ammo.GetAmountAmmo(_ammoType));

        print("amount bullets: " + _ammo.GetAmountAmmo(_ammoType));
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit);

    public void Reload()
    {
        _amountAmmoInClip = _ammo.LoadClip(_ammoType, _clipSize, _amountAmmoInClip);
        OnChangedAmountAmmoInClip?.Invoke(_amountAmmoInClip.ToString() + "/" + _ammo.GetAmountAmmo(_ammoType));

        print("Reloading...");
        print("amount bullets: " + _ammo.GetAmountAmmo(_ammoType));
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        OnChangedAmountAmmoInClip += (string value) => {};
    }
}