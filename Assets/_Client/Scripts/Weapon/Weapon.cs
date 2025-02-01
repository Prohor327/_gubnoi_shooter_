using UnityEngine;
using Tools;
using System;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    private WeaponAnimations _animations;
    private WeaponState _state;
    
    public Action OnEndAttack;

    public WeaponState State => _state;
 
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
        print(_state);
    }

    public void FinishAttack()
    {
        _state = WeaponState.Idle;
        OnEndAttack.Invoke();
        print(_state);  
    }

    [ContextMenu("Reset state")]
    public void ResetState()
    {
        _state = WeaponState.Idle;
    }
}