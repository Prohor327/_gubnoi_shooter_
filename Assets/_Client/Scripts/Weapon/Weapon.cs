using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    public Action OnEndAttack;

    public WeaponState State => state;

    protected Transform shootPoint;
    protected WeaponState state;
    protected WeaponAnimations _animations;

    private WeaponSound _sound;

    private void Awake()
    {
        _sound = GetComponent<WeaponSound>();
        _animations = GetComponent<WeaponAnimations>();
    }

    public void Initialize(Transform shootPoint, PlayerSound playerSound)
    {
        this.shootPoint = shootPoint;
        _sound.Initialize(playerSound);
        state = WeaponState.Idle;
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
        if(state == WeaponState.Idle)
        {
            state = WeaponState.Attack;
            _animations.PLayAttack();
        }
    }

    public void FinishAttack()
    {
        state = WeaponState.Idle;
        OnEndAttack.Invoke(); 
    }

    public void RemoveWeapon()
    {
        state = WeaponState.Idle;
    }

    protected virtual void Accept(IWeaponVisitor weaponVisitor) { }
}