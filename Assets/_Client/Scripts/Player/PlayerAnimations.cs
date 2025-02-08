using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private float _normalizedTransitionDurationWalk = 0.3f;
    [SerializeField] private float _normalizedTransitionDurationIdle = 0.3f;
    [SerializeField] private Animator _currentAnimator;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");

    public void PlayWalk()
    {
        _currentAnimator.CrossFade(Walk, _normalizedTransitionDurationIdle);
    }

    public void PlayIdle()
    {
        _currentAnimator.CrossFade(Idle, _normalizedTransitionDurationIdle);
    }

    public void SetAnimator(Animator animator)
    {
        _currentAnimator = animator;
    }
}