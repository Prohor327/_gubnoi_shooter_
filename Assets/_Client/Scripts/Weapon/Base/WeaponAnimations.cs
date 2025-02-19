using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimations : MonoBehaviour 
{
    [SerializeField] private float _normalizedTransitionDurationAttack = 0.06f;
    [SerializeField] private float _normalizedTransitionDurationReload = 0.06f;

    private Animator _animator;

    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Reload = Animator.StringToHash("Reload");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PLayAttack()
    {
        _animator.CrossFade(Attack, _normalizedTransitionDurationAttack);
    }

    public void PlayReload()
    {
        _animator.CrossFade(Reload, _normalizedTransitionDurationReload);
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}