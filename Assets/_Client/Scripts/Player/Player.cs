using Tools;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerAnimations))]
public class Player : MonoBehaviour
{
    private PlayerMotor _movement;
    private PlayerLook _view;
    private PlayerInput _input;
    private PlayerAnimations _animations;
    private PlayerWeapons _weapons;
    private PlayerHands _hands;
    public PlayerState _state;

    public PlayerMotor Movement => _movement;
    public PlayerLook View => _view;
    public PlayerInput Input => _input;
    public PlayerWeapons Weapons => _weapons;
    public PlayerAnimations Animations => _animations;
    public PlayerHands Hands => _hands;
    public PlayerState State => _state;

    [Inject]
    private void Construct(Pause pause)
    {
        _movement = GetComponent<PlayerMotor>();
        _view = GetComponent<PlayerLook>();
        _animations = GetComponent<PlayerAnimations>();
        _weapons = GetComponent<PlayerWeapons>();
        _hands = GetComponent<PlayerHands>();

        _movement.Initialize(_animations);
        _input = new PlayerInput(this, pause);

        _state = PlayerState.Idle;
        _movement.OnEndMove += EndMove;
        _movement.OnStartMove += StartMove;
    }

    private void StartMove()
    {
        if(_weapons.CurrentWeaponState == WeaponState.Idle)
        {
            _animations.PlayWalk();
        }
        _state = PlayerState.Move;
    }

    private void EndMove()
    {
        _animations.PlayIdle();
        _state = PlayerState.Idle;
    }
}