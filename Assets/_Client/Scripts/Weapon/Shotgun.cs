using UnityEngine;

public class Shotgun : RaycastWeapon
{
    public override void Attack()
    {
        if(state == WeaponState.Idle)
        {
            state = WeaponState.Attack;
            _animations.PLayAttack();
            PreformAttack();
        }
    }
}
