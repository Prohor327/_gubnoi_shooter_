using UnityEngine;

public abstract class RaycastWeapon : FirearmWeapon
{

    [Header("Shoot")]
    [SerializeField] private int _amountShots;
    [SerializeField] protected float distance;

    [Header("Shoot")]
    [SerializeField] private bool _useSpread;
    [SerializeField] private float _spreading;

    public override void PreformAttack()
    {
        base.PreformAttack();
        for (int i = 0; i < _amountShots; i++)
        {
            Vector3 direction = shootPoint.transform.forward;
            if(_useSpread)
            {
                Vector3 spread = new Vector3(Random.Range(-_spreading, _spreading),
                Random.Range(-_spreading, _spreading),
                Random.Range(-_spreading, _spreading));
                direction += spread;
            }
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, direction, out hit, distance))
            {
                SpawnBulletHole(hit);
                HitScan(hit);
            }
        }
    }

    protected void HitScan(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor, hit);
        }
    }
}
