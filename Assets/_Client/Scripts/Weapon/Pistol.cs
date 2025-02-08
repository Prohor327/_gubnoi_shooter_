using UnityEngine;

public class Pistol : RaycastWeapon
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

    [ContextMenu("Reset state")]
    private void ResetState()
    {
        state = WeaponState.Idle;
    }
}