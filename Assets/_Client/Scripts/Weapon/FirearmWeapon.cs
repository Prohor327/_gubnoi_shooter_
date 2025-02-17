using System.Security.Principal;
using UnityEngine;
using Zenject;

public abstract class FirearmWeapon : Weapon
{
    [Header("Magazine")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _clipSize;

    [Header("VFX")]
    [SerializeField] BulletHole bulletHole;

    private int _amountBulletsInCurrentClip;
    private Ammo _clip;

    protected Transform shootPoint;

    private int _amountBullets => _clip.GetAmountAmmo(_ammoType);

    public virtual void Initialize(Transform shootPoint, PlayerSound playerSound, Ammo clip)
    {
        this.shootPoint = shootPoint;
        base.Initialize(playerSound);
        _clip = clip;
        Reload();
    }

    protected void SpawnBulletHole(RaycastHit hit)
    {
        Instantiate(bulletHole.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }

    public override void Attack()
    {
        if(_clip.GetAmountAmmo(_ammoType) <= 0)        
        {
            if(_clip.GetAmountAmmo(_ammoType) > 0)
            {
                Reload();
            }
            return;
        }
        base.Attack();
    }

    public override void PreformAttack()
    {
        _clip.TryShot(_ammoType);

        //print("amount bullets: " + _amountBullets + " _amountBulletsInCurrentClip: " + _amountBulletsInCurrentClip);
        print("amount bullets: " + _amountBullets);
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit);

    public void Reload()
    {
        
        //print("amount bullets: " + _amountBullets + " _amountBulletsInCurrentClip: " + _amountBulletsInCurrentClip);
        print("amount bullets: " + _amountBullets);
    }
}