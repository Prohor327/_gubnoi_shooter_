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

    public void SubscribePlayer()
    {
        _playerActions.MousePosition.performed += OnMousePosition;
        _playerActions.Move.performed += OnStartMove;
        _playerActions.Move.canceled += OnStopMove;
        _playerActions.Fire.performed += OnFire;
        _playerActions.Reload.performed += OnReload;
        _playerActions.Interact.started += OnInteract;
        _playerActions.Take.started += OnTake;
        _playerActions.FirstWeapon.started += OnFirstWeapon;
        _playerActions.SecondWeapon.started += OnSecondWeapon;
        _playerActions.ThirdWeapon.started += OnThirdWeapon;
        _playerActions.FourthWeapon.started += OnFourthWeapon;
        MonoBehaviour.print("Player subscribed");
    }

    public void UnsubscribePlayer()
    {
        _playerActions.MousePosition.performed -= OnMousePosition;
        _playerActions.Move.performed -= OnStartMove;
        _playerActions.Move.canceled -= OnStopMove;
        _playerActions.Fire.performed -= OnFire;
        _playerActions.Reload.performed -= OnReload;
        _playerActions.Interact.started -= OnInteract;
        _playerActions.Take.started -= OnTake;
        _playerActions.FirstWeapon.started -= OnFirstWeapon;
        _playerActions.SecondWeapon.started -= OnSecondWeapon;
        _playerActions.ThirdWeapon.started -= OnThirdWeapon;
        _playerActions.FourthWeapon.started -= OnFourthWeapon;
        MonoBehaviour.print("Player unsubscribed");
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        _player.Weapons.Attack();
    }

    private void OnTake(InputAction.CallbackContext context)
    {
        //_player.Hands.Take();
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        _player.Weapons.Reload();
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
    private void OnFirstWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(0);   
    }

    private void OnSecondWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(1);   
    }

    private void OnThirdWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(2);   
    }

    private void OnFourthWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(3);   
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