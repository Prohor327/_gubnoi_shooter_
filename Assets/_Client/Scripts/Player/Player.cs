using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Shaker))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerWeapons))]
[RequireComponent(typeof(PlayerInteract))]
[RequireComponent(typeof(Unit))]
public class Player : Character
{
    [SerializeField] private PlayerSO _config;
    [SerializeField] private Rig _rig;

    private PlayerMotor _movement;
    private PlayerLook _look;
    private PlayerInput _input;
    private PlayerAnimations _animations;
    private PlayerWeapons _weapons;
    private PlayerInteract _hands;
    private PlayerState _state;
    private PlayerSound _sound;
    private Unit _unit;
    private Ammo _ammo;
    private Shaker _cameraShaker;
    private PlayerEvents _events;
    private GroundChecker _groundChecker;

    public PlayerMotor Movement => _movement;
    public PlayerLook View => _look;
    public PlayerInput Input => _input;
    public PlayerWeapons Weapons => _weapons;
    public PlayerAnimations Animations => _animations;
    public PlayerInteract Hands => _hands;
    public PlayerState State => _state;
    public Unit Unit => _unit;
    public Ammo Ammo => _ammo;
    public PlayerSound Sound => _sound;
    public Shaker CameraShaker => _cameraShaker;
    public PlayerEvents Events => _events;
    public GroundChecker GroundChecker => _groundChecker;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _movement = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _animations = GetComponent<PlayerAnimations>();
        _weapons = GetComponent<PlayerWeapons>();
        _hands = GetComponent<PlayerInteract>();
        _unit = GetComponent<Unit>();
        _ammo = GetComponent<Ammo>();
        _sound = GetComponent<PlayerSound>();
        _cameraShaker = GetComponent<Shaker>();
        _groundChecker = GetComponent<GroundChecker>();

        _events = new PlayerEvents();

        _movement.Initialize(_config.MovementConfig, this);
        _weapons.Initialize(_rig, this);
        _hands.Initialize(_rig, _config.HandsConfig, _events);
        _look.Initialize(_rig, _config.PlayerLookConfig);
        _unit.Initialize(this, _config.HealthConfig);
        _sound.Initialize(_groundChecker, this);
        _groundChecker.Initialize(_sound);

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