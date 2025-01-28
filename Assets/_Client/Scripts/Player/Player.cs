using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerView))]
[RequireComponent(typeof(PlayerAnimations))]
public class Player : MonoBehaviour
{
    private PlayerMotor _movement;
    private PlayerView _view;
    private PlayerInput _input;
    private PlayerAnimations _animations;
    private PlayerWeapons _weapons;

    public PlayerMotor Movement => _movement;
    public PlayerView View => _view;
    public PlayerInput Input => _input;
    public PlayerWeapons Weapons => _weapons;

    [Inject]
    private void Construct(Pause pause)
    {
        _movement = GetComponent<PlayerMotor>();
        _view = GetComponent<PlayerView>();
        _animations = GetComponent<PlayerAnimations>();
        _weapons = GetComponent<PlayerWeapons>();

        _movement.Initialize(_animations);
        _input = new PlayerInput(this, pause);
    }

    public void HasShow(bool show)
    {
        gameObject.SetActive(show);
    }
}