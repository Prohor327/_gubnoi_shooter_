using UnityEngine;

public class Shotgun : RaycastWeapon
{
    public override void Initialize(Transform shootPoint, PlayerSound playerSound, Ammo ammo)
    {
        this.shootPoint = shootPoint;
        base.Initialize(playerSound);
        this.ammo = ammo;
        this.ammo.OnAddedAmmo += OnAddedAmmo;
        amountAmmoInClip = ammo.LoadClip(ammoType, clipSize, amountAmmoInClip);
    }

    public override void Reload()
    {
        if(amountAmmoInClip < clipSize)
        {
            base.Reload();
        }
    }

    public override void PerformReload()
    {
        amountAmmoInClip = ammo.LoadClipShotgun(amountAmmoInClip);
        OnChangedAmountAmmoInClip?.Invoke(amountAmmoInClip.ToString() + "/" + ammo.GetAmountAmmo(ammoType));
    }

    protected override void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor.Visit(this, hit);
    }
}