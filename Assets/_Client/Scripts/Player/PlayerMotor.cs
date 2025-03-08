using UnityEngine;
using DG.Tweening;
using UnityEditor;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    private MovementConfig _movementConfig;
    private float _moveSpeed;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Vector3 _direction;
    private PlayerEvents _playerEvents;
    private float _height;
    private bool _isChangingHeight;

    private void OnDrawGizmos()
    {
        if (Selection.Contains(gameObject))
        {
            return;
        }
        if(_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
        DebugDrawer.DrawWireCapsule(transform.position, transform.rotation, _controller.radius * transform.localScale.z, _controller.height * transform.localScale.y, Color.green);
    }

    public void Initialize(MovementConfig movementConfig, Player player)
    {
        _movementConfig = movementConfig;
        _moveSpeed = _movementConfig.WalkSpeed;
        _controller = GetComponent<CharacterController>();
        _playerEvents = player.Events;
        _height = _controller.height;
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

    public void Jump()
    {
        if(_controller.isGrounded)
        {
            //_playerSound.SoundJump();
            _playerVelocity.y += Mathf.Sqrt(_movementConfig.JumpHeight * -2.0f * Physics.gravity.y);
        }
    }

    public void Crouch()
    {
        if(_isChangingHeight)
        {
            return;
        }
        _isChangingHeight = true;
        if(_controller.height == _movementConfig.CrouchHeight)
        {
            _moveSpeed = _movementConfig.WalkSpeed;
            DOTween.To(() =>  _controller.height, x => _controller.height = x, _height, _movementConfig.CrouchDuration).OnComplete(() => {_isChangingHeight = false;});
        }
        else
        {
            _moveSpeed = _movementConfig.CrouchSpeed;
            DOTween.To(() =>  _controller.height, x => _controller.height = x, _movementConfig.CrouchDuration,
             _movementConfig.CrouchDuration).OnComplete(() => {_isChangingHeight = false;});
        }
    }
}
