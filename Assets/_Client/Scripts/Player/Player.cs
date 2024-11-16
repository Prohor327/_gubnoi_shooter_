using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerInstaller))]
[RequireComponent(typeof(PlayerView))]
public class Player : MonoBehaviour
{
    private PlayerMotor _movement;
    private PlayerView _view;
    private PlayerInput _input;

    public PlayerMotor Movement => _movement;
    public PlayerView View => _view;
    public PlayerInput Input => _input;

    private void Initialize()
    {
        _movement = GetComponent<PlayerMotor>();
        _view = GetComponent<PlayerView>();
        _input = new PlayerInput(this);
    }
}