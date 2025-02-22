using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private HandsConfig _handsConfig;
    private Transform _raycastPoint;
    private Transform _itemPoint;
    private Interactable _currentTarget;
    private PlayerEvents _playerEvents;
    private bool _isHandsBasied = false;

    private void OnDrawGizmos()
    {
        if(_raycastPoint == null)
        {
            return;
        }

        RaycastHit hit;
        if(Physics.Raycast(_raycastPoint.position, _raycastPoint.TransformDirection(Vector3.forward), out hit, _handsConfig.Distance))
        {
            Debug.DrawLine(_raycastPoint.position, hit.point, Color.blue, 1f);
        }
    }

    public void Initialize(Rig rig, HandsConfig handsConfig, PlayerEvents playerEvents)
    {
        _raycastPoint = rig.PlayerCamera.transform;
        _handsConfig = handsConfig;
        _playerEvents = playerEvents;
    }

    public void Update()
    {
        if(_isHandsBasied)
        {
            return;
        }

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

    // public void Take()
    // {
    //     if(_currentTarget.IsTakable)
    //     {
    //         _currentTarget.transform.SetParent(_itemPoint);
    //         _playerEvents.OnTakenItem.Invoke();
    //         _isHandsBasied = true;
    //     }

    //     if(_isHandsBasied)
    //     {
    //         PutAwayItem();
    //         _currentTarget = null;
    //     }
    // }

    // private void PutAwayItem()
    // {
    //     _currentTarget.transform.SetParent(null);
    //     _isHandsBasied = false;
    // }

    // public void ThrowItem()
    // {
    //     PutAwayItem();
    //     _currentTarget.GetComponent<Rigidbody>().AddForce(Vector3.forward * _handsConfig.ThrowingForce);
    //     _currentTarget = null;
    // }
}
