using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;


    private float _moveSpeed;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Vector3 _direction;

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

    public void ChangeDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
    }
}