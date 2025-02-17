using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private float _normalizedTransitionDurationDeath = 0.06f;
    [SerializeField] private float _normalizedTransitionDurationHit = 0.06f;

    private static readonly int Attack = Animator.StringToHash("Death");
    private static readonly int GetHit = Animator.StringToHash("GetHit");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDead()
    {
        _animator.CrossFade(Attack, _normalizedTransitionDurationDeath);
    }

    public void PlayGetHit()
    {
        _animator.CrossFade(GetHit, _normalizedTransitionDurationHit);
    }
}