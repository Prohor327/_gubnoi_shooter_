using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerView))]
[RequireComponent(typeof(PlayerAnimations))]
public class Player : MonoBehaviour
{
    private PlayerMotor _movement;
    private PlayerView _view;
    private PlayerInput _input;
    private PlayerAnimations _animations;

    public PlayerMotor Movement => _movement;
    public PlayerView View => _view;
    public PlayerInput Input => _input;

    private void Start()
    {
        _movement = GetComponent<PlayerMotor>();
        _view = GetComponent<PlayerView>();
        _animations = GetComponent<PlayerAnimations>();

        _movement.Initialize(_animations);
        _input = new PlayerInput(this);
    }
}