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
        _playerActions.Jump.started += OnJump;
        _playerActions.Crouch.started += OnCrouch;
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
        _playerActions.Jump.started -= OnJump;
        _playerActions.Crouch.started -= OnCrouch;
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
        _player.WeaponTransformSway.SetMousePosition(context.ReadValue<Vector2>());
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
        _player.Interact.Interact();   
    }
    private void OnFirstWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(WeaponType.Axe);
    }

    private void OnSecondWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(WeaponType.Pistol); 
    }

    private void OnThirdWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChangeWeapon(WeaponType.Shotgun);   
    }

    private void OnFourthWeapon(InputAction.CallbackContext context)
    {
        _player.Hands.Take();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _player.Movement.Jump();
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        _player.Movement.Crouch();
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