using Tools;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon _currentWeapon;

    private PlayerAnimations _animations;
    private Player _player;

    public WeaponState CurrentWeaponState => _currentWeapon.State;

    private void Awake()
    {
        _animations = GetComponent<PlayerAnimations>();
        _player = GetComponent<Player>();
        _currentWeapon.OnEndAttack += EndAttack;
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

    private void EndAttack()
    {
        switch(_player.State)
        {
            case PlayerState.Move:
                {
                    _animations.PlayWalk();
                    print("Walk");
                    break;
                }
            case PlayerState.Idle:
                {
                    _animations.PlayIdle();
                    print("Idle");
                    break;
                }
        }
    }
}