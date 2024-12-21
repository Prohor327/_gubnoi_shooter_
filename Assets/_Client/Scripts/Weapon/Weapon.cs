using UnityEngine;
using Tools;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    private WeaponAnimations _animations;
    private WeaponState _state;
 
    private void Awake()
    {
        _animations = GetComponent<WeaponAnimations>();
        _state = WeaponState.Idle;
    }

    public Animator GetAnimator()
    {
        return _animations.GetAnimator();
    }

    public void Attack()
    {
        if(_state == WeaponState.Idle)
        {
            _state = WeaponState.Attack;
            _animations.PLayAttack();
        }
    }

    public void FinishAttack()
    {
        _state = WeaponState.Idle;
        print(_state);  
    }

    [ContextMenu("Reset state")]
    public void ResetState()
    {
        _state = WeaponState.Idle;
    }
}