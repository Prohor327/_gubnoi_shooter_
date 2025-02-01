using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _currentAnimator;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");

    public void PlayWalk()
    {
        _currentAnimator.CrossFade(Walk, 0);
    }

    public void PlayIdle()
    {
        _currentAnimator.CrossFade(Idle, 0);
    }

    public void SetAnimator(Animator animator)
    {
        _currentAnimator = animator;
    }
}