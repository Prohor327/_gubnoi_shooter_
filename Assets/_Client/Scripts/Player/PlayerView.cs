using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _sens;

    private Transform _fpsRig;
    private float _xRotate;

    private void Construct(Rig rig)
    {
        _fpsRig = rig.RigPoint;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _sens;
        _xRotate = Mathf.Clamp(_xRotate, -80f, 80f);
        Quaternion fpsRigRotation = Quaternion.Euler(_xRotate, 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }
}