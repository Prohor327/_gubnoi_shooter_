using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private float _normalizedTransitionDurationDeath = 0.06f;

    private static readonly int Attack = Animator.StringToHash("Death");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDead()
    {
        _animator.CrossFade(Attack, _normalizedTransitionDurationDeath);
    }
}