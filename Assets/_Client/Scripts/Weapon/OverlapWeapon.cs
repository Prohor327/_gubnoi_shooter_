using UnityEngine;

public abstract class OverlapWeapon : Weapon
{
    [Header("Overlap")]
    [SerializeField] private int _maxAmountColliders;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _overlapPoint;
    [SerializeField] private LimitedLifeDecal _scratch;

    private void OnDrawGizmos()
    {
        if(_overlapPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_overlapPoint.position, _attackRange);
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(_overlapPoint.position, 0.02f);
        }
    }

    public override void PreformAttack()
    {
        Collider[] hitColliders = new Collider[_maxAmountColliders];
        int amountColliders = Physics.OverlapSphereNonAlloc(_overlapPoint.position, _attackRange, hitColliders);
        TryPerformAttack(hitColliders, amountColliders);
        RaycastHit hitForVFX;
        if(Physics.Raycast(_overlapPoint.position, _overlapPoint.forward, out hitForVFX, _attackRange))
        {
            SpawnVFX(hitForVFX);
        }
    }

    private void TryPerformAttack(Collider[] colliders, int amountColliders)
    {
        for(int i = 0; i < amountColliders; i++)
        {
            if(colliders[i].gameObject.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                Accept(weaponVisitor);
            }
        }
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor);

    protected override void SpawnVFX(RaycastHit hit)
    {
        if(surfaceConfig.Scratches.ContainsKey(1 << hit.transform.gameObject.layer))
        {
            Instantiate(surfaceConfig.Scratches[1 << hit.transform.gameObject.layer].gameObject, hit.point, Quaternion.LookRotation(hit.normal));
        }
        base.SpawnVFX(hit);
    }
}
