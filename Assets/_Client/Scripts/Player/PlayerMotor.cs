using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;


    private float _moveSpeed;
    private PlayerAnimations _animations;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Vector3 _direction;

    public Action OnEndMove;
    public Action OnStartMove;

    public void Initialize(PlayerAnimations playerAnimations)
    {
        _animations = playerAnimations;
    }

    private void Awake()
    {
        _moveSpeed = _walkSpeed;
        _controller = GetComponent<CharacterController>();
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
        OnStartMove.Invoke();
    }

    public void StopMove()
    {
        _direction = Vector3.zero;
        OnEndMove.Invoke();
    }
}
