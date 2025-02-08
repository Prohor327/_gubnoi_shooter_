using UnityEngine;
using Zenject;

public class RaycastWeapon : Weapon
{
    [SerializeField] private GameObject _decal;
    [SerializeField] private float _decalLifetime;

    [SerializeField] private int _amountShots;

    [SerializeField] private bool _useSpread;
    [SerializeField] private float _spreading;

    [SerializeField] protected float distance;

    [Inject]
    private void Construct(Rig rig)
    {
        shootPoint = rig.PlayerCamera.transform;
    }

    public override void PreformAttack()
    {
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
                HitScan(hit);
            }
        }
    }

    protected void HitScan(RaycastHit hit)
    {
        GameObject decal = Instantiate(_decal, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
        Destroy(decal, _decalLifetime);

        if (hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }
}
