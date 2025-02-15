using UnityEngine;

public abstract class FirearmWeapon : Weapon
{
    [Header("Magazine")]
    [SerializeField] private int _clipSize;
    [SerializeField] private int _startAmountBullets;

    [Header("VFX")]
    [SerializeField] BulletHole bulletHole;

    protected int amountBulletsInCurrentClip;
    private int _amountBullets;

    public override void Initialize(Transform shootPoint, PlayerSound playerSound)
    {
        base.Initialize(shootPoint, playerSound);
        _amountBullets = _startAmountBullets;
        Reload();
    }

    protected void SpawnBulletHole(RaycastHit hit)
    {
        Instantiate(bulletHole.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }

    public override void PreformAttack()
    {
        if(amountBulletsInCurrentClip <= 0)        
        {
            if(_amountBullets > 0)
            {
                Reload();
            }
            return;
        }
        amountBulletsInCurrentClip--;

        print("amount bullets:" + _amountBullets + " _amountBulletsInCurrentClip: " + amountBulletsInCurrentClip);
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit);

    public void Reload()
    {
        if(_amountBullets >= _clipSize)
        {
            _amountBullets -= _clipSize;
            amountBulletsInCurrentClip = _clipSize;   
        }
        else
        {
            amountBulletsInCurrentClip = _amountBullets;
            _amountBullets = 0;
        }
        print("amount bullets:" + _amountBullets + " _amountBulletsInCurrentClip: " + amountBulletsInCurrentClip);
    }

    public void AddBullets(int amountBullets)
    {
        _amountBullets += amountBullets;
    }
}