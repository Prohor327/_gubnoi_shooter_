using UnityEngine;
using UnityEngine.TextCore;
using Zenject;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerWeapons))]
[RequireComponent(typeof(PlayerHands))]
[RequireComponent(typeof(Unit))]
public class Player : Character
{
    [SerializeField] private PlayerSO _playerSO;

    private PlayerMotor _movement;
    private PlayerLook _look;
    private PlayerInput _input;
    private PlayerAnimations _animations;
    private PlayerWeapons _weapons;
    private PlayerHands _hands;
    private PlayerState _state;
    private Unit _unit;
    private Rig _rig;

    public PlayerMotor Movement => _movement;
    public PlayerLook View => _look;
    public PlayerInput Input => _input;
    public PlayerWeapons Weapons => _weapons;
    public PlayerAnimations Animations => _animations;
    public PlayerHands Hands => _hands;
    public PlayerState State => _state;
    public Unit Unit => _unit;

    [Inject]
    private void Construct(Pause pause, GameMachine gameMachine, Rig rig)
    {
        _movement = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _animations = GetComponent<PlayerAnimations>();
        _weapons = GetComponent<PlayerWeapons>();
        _hands = GetComponent<PlayerHands>();
        _unit = GetComponent<Unit>();

        _movement.Initialize(_animations, _playerSO.MovementConfig);
        _look.Initialize(_playerSO.PlayerLookConfig);
        _unit.Initialize(this, _playerSO.HealthConfig);
        _hands.Initialize(_playerSO.HandsConfig);
        _input = new PlayerInput(this, pause);

        _state = PlayerState.Idle;
        _movement.OnEndMove += EndMove;
        _movement.OnStartMove += StartMove;
        gameMachine.OnStopGame += _input.UnsubscribeGamplayActions;
        gameMachine.OnResumeGame += _input.SubscribeGamplayActions;
        gameMachine.OnFinishGame += _input.UnsubscribePlayer;
        
        gameMachine.OnStartCutScene += DisablePlayerCameras;
        gameMachine.OnStartCutScene += EnablePlayerCameras;
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

    private void DisablePlayerCameras()
    {
        _rig.PlayerCamera.gameObject.SetActive(false);
        _rig.WeaponCamera.gameObject.SetActive(false);
    }
    private void EnablePlayerCameras()
    {
        _rig.PlayerCamera.gameObject.SetActive(true);
        _rig.WeaponCamera.gameObject.SetActive(true);
    }
}