using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sens;
    [SerializeField] private Transform _fpsRig;

    private float _xRotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _sens;
        _xRotate = Mathf.Clamp(_xRotate, -80f, 80f);
        Quaternion fpsRigRotation = Quaternion.Euler(_xRotate, 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }

    private void OnDisable()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }
}