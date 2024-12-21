using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _currentAnimator;

    public void PlayWalk()
    {
        _currentAnimator.Play("Walk");
    }

    public void PlayIdle()
    {
        _currentAnimator.Play("Idle");
    }

    public void SetAnimator(Animator animator)
    {
        _currentAnimator = animator;
    }
}