using UnityEngine;
using Zenject;

public class RaycastWeapon : Weapon
{
    [SerializeField] private GameObject _decal;
    [SerializeField] private float _decalLifetime;

    [SerializeField] protected float distance;

    [Inject]
    private void Construct(Rig rig)
    {
        shootPoint = rig.PlayerCamera.transform;
    }

    public override void PreformAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, distance))
        {
            HitScan(hit);
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
