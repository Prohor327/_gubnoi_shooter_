using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput
{
    private Player _player;
    private Input.PlayerActions _playerActions => InputHandler.PlayerActions;

    public PlayerInput(Player player)
    {
        _player = player;
        SubscribePlayer();
    }

    public void SubscribePlayer()
    {
        SubscribeGamplayActions();
    }

    public void UnsubscribePlayer()
    {
        UnsubscribeGamplayActions();
    }

    public void UnsubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnChangeDirection;
        _playerActions.Move.canceled -= OnChangeDirection;
    }

    public void SubscribeGamplayActions()
    {
        _playerActions.MousePosition.performed += OnMousePosition;
        _playerActions.Move.performed += OnChangeDirection;
        _playerActions.Move.canceled += OnChangeDirection;
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _player.View.RotateCamera(context.ReadValue<Vector2>());
    }

    private void OnChangeDirection(InputAction.CallbackContext context)
    {
        _player.Movement.ChangeDirection(context.ReadValue<Vector2>());
    }
}