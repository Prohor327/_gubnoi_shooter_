using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _currentAnimator;

    public void PlayWalk()
    {
        _currentAnimator.Play("Walk");
    }

    public void PlayIdle()
    {
        _currentAnimator.Play("Idle");
    }
}