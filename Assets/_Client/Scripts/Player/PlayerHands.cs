using UnityEngine;
using Zenject;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private HandsConfig _handsConfig;

    private Transform _raycastPoint;
    private bool InteractButtonIsPressed;

    public void Initialize(HandsConfig handsConfig)
    {
        _handsConfig = handsConfig;
    }

    [Inject]
    public void Construct(Rig rig)
    {
        _raycastPoint = rig.PlayerCamera.transform;
    }

    public void LateUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(_raycastPoint.position, _raycastPoint.TransformDirection(Vector3.forward), out hit, _handsConfig.Distance))
        {
            if (hit.transform.gameObject.TryGetComponent<IInteract>(out IInteract interact))
            {
                print("aasdasd");
                if(InteractButtonIsPressed)
                {
                    interact.Interact();
                    InteractButtonIsPressed = false;
                    return;
                }

                interact.CursorOnObject();
            }
        }
    }

    public void Interact()
    {

        InteractButtonIsPressed = true;
    }
}
