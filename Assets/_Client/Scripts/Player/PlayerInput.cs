using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerInput
{
    private Player _player;
    private Input.PlayerActions _playerActions => InputHandler.PlayerActions;

    public PlayerInput(Player player)
    {
        _player = player;
        SubscribePlayer();
    }

    public void SubscribePlayer() => SubscribeGamplayActions();

    public void UnsubscribePlayer() => UnsubscribeGamplayActions();

    public void UnsubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStartMove;
        _playerActions.Pause.performed -= OnPause;
    }

    public void SubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed += OnMousePosition;
        _playerActions.Move.performed += OnStartMove;
        _playerActions.Move.canceled += OnStopMove;
        _playerActions.Pause.performed += OnPause;
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
        _player._pause.OpenPause();
    }
}