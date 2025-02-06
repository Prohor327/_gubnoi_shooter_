using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    public Action OnEndAttack;

    public WeaponState State => _state;

    protected Transform shootPoint;
    protected WeaponState _state;
    protected WeaponAnimations _animations;

    private void Awake()
    {
        _animations = GetComponent<WeaponAnimations>();
        _state = WeaponState.Idle;
    }

    public Animator GetAnimator()
    {
        return _animations.GetAnimator();
    }

    public virtual void PreformAttack()
    {

    }

    public virtual void Attack()
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
        OnEndAttack.Invoke(); 
    }

    protected virtual void Accept(IWeaponVisitor weaponVisitor) { }
}