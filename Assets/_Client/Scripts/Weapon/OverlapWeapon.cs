using Mono.Cecil;
using UnityEngine;

public abstract class OverlapWeapon : Weapon
{
    [Header("Overlap")]
    [SerializeField] private int _maxAmountColliders;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _overlapPoint;

    private void OnDrawGizmosSelected()
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
}
