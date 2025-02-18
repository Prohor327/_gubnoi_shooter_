using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]

public class PlayerMotor : MonoBehaviour
{
    private MovementConfig _movementConfig;
    private float _moveSpeed;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Vector3 _direction;
    private PlayerEvents _playerEvents;

    public void Initialize(MovementConfig movementConfig, PlayerEvents playerEvents)
    {
        _movementConfig = movementConfig;
        _moveSpeed = _movementConfig.WalkSpeed;
        _controller = GetComponent<CharacterController>();
        _playerEvents = playerEvents;
    }

    private void Update()
    {
        _controller.Move(transform.TransformDirection(_direction) * _moveSpeed * Time.deltaTime);
        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        if (_controller.isGrounded)
        {
            if (_playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

        }
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void StartMove(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
        _playerEvents.OnStartMove.Invoke();
    }

    public void StopMove()
    {
        _direction = Vector3.zero;
        _playerEvents.OnEndMove.Invoke();
    }
}
