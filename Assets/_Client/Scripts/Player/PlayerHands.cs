using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private HandsConfig _handsConfig;

    private Transform _raycastPoint;
    private IInteractable _currentTarget;

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
            if (hit.transform.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(interactable != _currentTarget)
                {
                    _currentTarget = interactable;
                    _currentTarget.OnStartHover();
                }

                _currentTarget.OnHover();
            }
            else if(_currentTarget != null)
            {
                _currentTarget.OnEndHover();
                _currentTarget = null;
            }
        }
    }

    public void Interact()
    {
        _currentTarget?.OnInteract();
    }
}
