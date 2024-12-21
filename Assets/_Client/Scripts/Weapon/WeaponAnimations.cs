using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimations : MonoBehaviour 
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PLayAttack()
    {
        _animator.Play("Attack");
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}