using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private HandsConfig _handsConfig;

    private Transform _raycastPoint;
    private Interactable _currentTarget;

    public void Initialize(Rig rig, HandsConfig handsConfig)
    {
        _raycastPoint = rig.PlayerCamera.transform;
        _handsConfig = handsConfig;
    }

    public void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(_raycastPoint.position, _raycastPoint.TransformDirection(Vector3.forward), out hit, _handsConfig.Distance))
        {
            if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if(interactable != _currentTarget)
                {
                    _currentTarget?.OnEndHover();
                    _currentTarget = interactable;
                    _currentTarget?.OnStartHover();
                    return;
                }

                _currentTarget?.OnHover();
            }
            else if(_currentTarget != null)
            {
                _currentTarget?.OnEndHover();
                _currentTarget = null;
            }
        }
    }

    public void Interact()
    {
        _currentTarget?.OnInteract();
        _currentTarget = null;
    }
}
