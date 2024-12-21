using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;

public class PlayerInput
{
    private Player _player;
    private Pause _pause;
    private Input.PlayerActions _playerActions => InputHandler.PlayerActions;

    public PlayerInput(Player player, Pause pause)
    {
        _pause = pause;
        _player = player;
        SubscribePlayer();
    }

    public void SubscribePlayer()
    {
        SubscribeGamplayActions();
        _playerActions.Pause.performed += OnPause;
    }

    public void UnsubscribePlayer()
    {
        UnsubscribeGamplayActions();
        _playerActions.Pause.performed -= OnPause;
    }

    public void UnsubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStartMove;
        _playerActions.Fire.performed -= OnFire;
    }

    public void SubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed += OnMousePosition;
        _playerActions.Move.performed += OnStartMove;
        _playerActions.Move.canceled += OnStopMove;
        _playerActions.Fire.performed += OnFire;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        _player.Weapons.Attack();
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _player.View.RotateCamera(context.ReadValue<Vector2>());
    }

    private void OnStartMove(InputAction.CallbackContext context)
    {
        _player.Movement.StartMove(context.ReadValue<Vector2>());
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
        _player.Movement.StopMove();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        _pause.Open();
    }
}