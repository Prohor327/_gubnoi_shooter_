using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimations : MonoBehaviour 
{
    private Animator _animator;

    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PLayAttack()
    {
        _animator.CrossFade(Attack, 0);
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}