using UnityEditor.PackageManager;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Shaker))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerWeapons))]
[RequireComponent(typeof(PlayerHands))]
[RequireComponent(typeof(Unit))]
public class Player : Character
{
    [SerializeField] private PlayerSO _config;

    private PlayerMotor _movement;
    private PlayerLook _look;
    private PlayerInput _input;
    private PlayerAnimations _animations;
    private PlayerWeapons _weapons;
    private PlayerHands _hands;
    private PlayerState _state;
    private PlayerSound _sound;
    private Unit _unit;
    private Rig _rig;
    private PlayerAmmo _ammo;
    private Shaker _cameraShaker;
    private PlayerEvents _events;

    public PlayerMotor Movement => _movement;
    public PlayerLook View => _look;
    public PlayerInput Input => _input;
    public PlayerWeapons Weapons => _weapons;
    public PlayerAnimations Animations => _animations;
    public PlayerHands Hands => _hands;
    public PlayerState State => _state;
    public Unit Unit => _unit;
    public PlayerAmmo Ammo => _ammo;
    public PlayerSound Sound => _sound;
    public Shaker CameraShaker => _cameraShaker;
    public PlayerEvents Events => _events;

    [Inject]
    private void Construct(GameMachine gameMachine, Rig rig)
    {
        _rig = rig;
        _movement = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _animations = GetComponent<PlayerAnimations>();
        _weapons = GetComponent<PlayerWeapons>();
        _hands = GetComponent<PlayerHands>();
        _unit = GetComponent<Unit>();
        _ammo = GetComponent<PlayerAmmo>();
        _sound = GetComponent<PlayerSound>();
        _cameraShaker = GetComponent<Shaker>();

        _events = new PlayerEvents();

        _movement.Initialize(_config.MovementConfig, _events);
        _weapons.Initialize(rig, this);
        _hands.Initialize(rig, _config.HandsConfig);
        _look.Initialize(rig, _config.PlayerLookConfig);
        _unit.Initialize(this, _config.HealthConfig);
        _ammo.Initialize(_events);

        _input = new PlayerInput(this);

        _state = PlayerState.Idle;
        _events.OnEndMove += EndMove;
        _events.OnStartMove += StartMove;

        _unit.OnHealthChanged += OnHealthChanged;

        gameMachine.OnStopGame += _input.Disable;
        gameMachine.OnResumeGame += _input.Enable;
        gameMachine.OnFinishGame += _input.UnsubscribePlayer;

        gameMachine.OnStartCutScene += OnStartCutScene;
        gameMachine.OnEndCutScene += OnEndCutScene;
    }

    private void OnHealthChanged(float value)
    {
        _events.OnHealthChanged.Invoke(value);
    }

    private void StartMove()
    {
        if(_weapons.AmountWeapon != 0)
        {
            if(_weapons.GetWeaponState() == WeaponState.Idle)
            {
                _animations.PlayWalk();
            }
        }
        else
        {
            _animations.PlayWalk();
        }
        _state = PlayerState.Move;
    }

    private void EndMove()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _animations.PlayIdle();
        _state = PlayerState.Idle;
    }

    private void OnStartCutScene()
    {
        _input.Disable();
        gameObject.SetActive(false);
    }
    private void OnEndCutScene()
    {
        gameObject.SetActive(true);
        _input.Enable();
    }
}