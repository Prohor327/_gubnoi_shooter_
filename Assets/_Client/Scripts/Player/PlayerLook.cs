using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    private PlayerLookConfig _playerLookConfig;
    private Transform _fpsRig;
    private float _xRotate;

    public void Initialize(Rig rig, PlayerLookConfig playerLookConfig)
    {
        _fpsRig = rig.RigPoint;
        _playerLookConfig = playerLookConfig;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _playerLookConfig.Sensivity);
        _xRotate -= mousePosition.y * Time.deltaTime * _playerLookConfig.Sensivity;
        _xRotate = Mathf.Clamp(_xRotate, -_playerLookConfig.YRotateLimit, _playerLookConfig.YRotateLimit);
        Quaternion fpsRigRotation = Quaternion.Euler(_xRotate, 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}