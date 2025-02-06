using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimations : MonoBehaviour 
{
    [SerializeField] private float _normalizedTransitionDurationAttack = 0.06f;

    private Animator _animator;

    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PLayAttack()
    {
        _animator.CrossFade(Attack, _normalizedTransitionDurationAttack);
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}