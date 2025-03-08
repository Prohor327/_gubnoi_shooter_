using UnityEngine;
using System;

public abstract class FirearmWeapon : Weapon
{
    [Header("Magazine")]
    [SerializeField] protected AmmoType ammoType;
    [SerializeField] protected int clipSize;

    [Header("VFX")]
    [SerializeField] private BulletHole bulletHole;

    [SerializeField] protected int amountAmmoInClip;
    protected Ammo ammo;

    protected Transform shootPoint;

    public AmmoType AmmoType => ammoType;

    public Action<string> OnChangedAmountAmmoInClip;

    public override void Take()
    {
        base.Take();
        OnChangedAmountAmmoInClip.Invoke(amountAmmoInClip.ToString() + "/" + ammo.GetAmountAmmo(ammoType));
    }

    public virtual void Initialize(Transform shootPoint, PlayerSound playerSound, Ammo ammo)
    {
        this.shootPoint = shootPoint;
        this.ammo = ammo;
        this.ammo.OnAddedAmmo += OnAddedAmmo;
        base.Initialize(playerSound);
        PerformReload();
    }

    protected void OnAddedAmmo()
    {
        if(gameObject.activeSelf)
        {
            OnChangedAmountAmmoInClip.Invoke(amountAmmoInClip.ToString() + "/" + ammo.GetAmountAmmo(ammoType));
        }
    }

    protected void SpawnBulletHole(RaycastHit hit)
    {
        Instantiate(bulletHole.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }

    public override void Attack()
    {
        if(amountAmmoInClip <= 0)        
        {
            sound.SoundShotWithoutBullets();
            return;
        }
        base.Attack();
    }

    public override void PreformAttack()
    {
        amountAmmoInClip--;

        OnChangedAmountAmmoInClip.Invoke(amountAmmoInClip.ToString() + "/" + ammo.GetAmountAmmo(ammoType));
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit);

    public override void Reload()
    {
        if(state == WeaponState.Idle && ammo.GetAmountAmmo(ammoType) > 0)
        {
            state = WeaponState.Reload;
            animations.PlayReload();
        }
    }

    public virtual void PerformReload()
    {
        amountAmmoInClip = ammo.LoadClip(ammoType, clipSize, amountAmmoInClip);
        OnChangedAmountAmmoInClip?.Invoke(amountAmmoInClip.ToString() + "/" + ammo.GetAmountAmmo(ammoType));
    }

    public void FinishReload()
    {
        state = WeaponState.Idle;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        OnChangedAmountAmmoInClip += (string value) => {};
    }
}