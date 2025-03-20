using UnityEngine;

public class Shotgun : RaycastWeapon
{
    public override void Initialize(Transform shootPoint, PlayerSound playerSound, Ammo ammo, SurfaceConfig surfaceConfig)
    {
        this.shootPoint = shootPoint;
        this.ammo = ammo;
        this.ammo.OnAddedAmmo += OnAddedAmmo;
        amountAmmoInClip = ammo.LoadClip(ammoType, clipSize, amountAmmoInClip);
        base.Initialize(playerSound, surfaceConfig);
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