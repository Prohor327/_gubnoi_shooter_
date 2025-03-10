using UnityEngine;

public class TransformSway : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private Vector2 _force = Vector2.one;
    [SerializeField, Min(0f)] private float _multiplier = 5f;
    [SerializeField] private bool _inverseX;
    [SerializeField] private bool _inverseY;

    [Header("Clamp")] 
    [SerializeField] private Vector2 _minMaxX;
    [SerializeField] private Vector2 _minMaxY;

    private float _mouseX;
    private float _mouseY;
    private Vector2 _mousePosition;

    private void OnValidate()
    {
        _minMaxX.y = -_minMaxX.x;
        _minMaxY.y = -_minMaxY.x;
    }

    private void LateUpdate()
    {
        PerformTransformSway();
    }

    private void PerformTransformSway()
    {
        float deltaTime = Time.deltaTime;
        float inverseSwayX = _inverseX ? -1f : 1f;
        float inverseSwayY = _inverseY ? -1f : 1f;

        _mouseX = _mousePosition.x * inverseSwayX;
        _mouseY = _mousePosition.y * inverseSwayY;
        
        OnSwayPerforming(deltaTime);

        float currentX = _mouseY * _force.y;
        float currentY = _mouseX * _force.x;

        float endEulerAngleX = Mathf.Clamp(currentX, _minMaxX.x, _minMaxX.y);
        float endEulerAngleY = Mathf.Clamp(currentY, _minMaxY.x, _minMaxY.y);

        float moment = deltaTime * _multiplier;
        Vector3 localEulerAngles = transform.localEulerAngles;
        
        localEulerAngles.x = Mathf.LerpAngle(localEulerAngles.x, endEulerAngleX, moment);
        localEulerAngles.y = Mathf.LerpAngle(localEulerAngles.y, endEulerAngleY, moment);
        localEulerAngles.z = 0f;

        transform.localEulerAngles = localEulerAngles;
    }
    
    protected virtual void OnSwayPerforming(in float deltaTime) { }

    public void SetMousePosition(Vector2 position)
    {
        _mousePosition = position;
    }
}