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
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStopMove;
        _playerActions.Fire.performed -= OnFire;
        _playerActions.Interact.started -= OnInteract;
    }

    public void UnsubscribePlayer()
    {
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStopMove;
        _playerActions.Fire.performed -= OnFire;
        _playerActions.Interact.started -= OnInteract;
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

    private void OnInteract(InputAction.CallbackContext context)
    {
        _player.Hands.Interact();   
    }

    public void Enable()
    {
        _playerActions.Enable();
    }

    public void Disable()
    {
        _playerActions.Disable();
    }
}