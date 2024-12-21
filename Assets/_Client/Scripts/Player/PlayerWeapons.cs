using UnityEngine;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon _currentWeapon;

    private PlayerAnimations _animations;

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        ChangeWeapon(0);
    }

    public void ChangeWeapon(int indexWeapon)
    {
        _animations.SetAnimator(_currentWeapon.GetAnimator());
    }

    public void Attack()
    {
        _currentWeapon.Attack();
    }
}