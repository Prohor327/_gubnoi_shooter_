using UnityEngine;

public class RaycastWeapon : Weapon
{
    [SerializeField] private float _distance;

    public override void PreformAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, _distance))
        {
            HitScan(hit);
        }

    }

    protected void HitScan(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }
}
