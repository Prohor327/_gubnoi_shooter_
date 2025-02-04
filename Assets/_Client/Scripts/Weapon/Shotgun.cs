using UnityEngine;
using Tools;

public class Shotgun : RaycastWeapon
{
    [SerializeField] private int _amountShots;
    [SerializeField] private float _spreading;
    [SerializeField] private float _scatter;

    public override void PreformAttack()
    {
        for (int i = 0; i < _amountShots; i++)
        {
            Vector3 direction = shootPoint.transform.forward;
            Vector3 spread = Vector3.zero;
            spread += shootPoint.transform.up * Random.Range(-_spreading, _spreading);
            spread += shootPoint.transform.right * Random.Range(-_spreading, _spreading);

            direction += spread.normalized * Random.Range(0f, _scatter);

            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, direction, out hit, distance))
            {
                HitScan(hit);
            }
        }
    }

    public override void Attack()
    {
        if(_state == WeaponState.Idle)
        {
            _state = WeaponState.Attack;
            _animations.PLayAttack();
            PreformAttack();
        }
    }
}
