 using UnityEngine;

public class GroundChecker : MonoBehaviour 
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _groundLayers;

    public bool IsGrounded { get; private set; }
    public GroundType CurrentGroundType { get; private set; }

    private PlayerSound _playerSound;
    private CharacterController _controller;

    public void Initialize(PlayerSound playerSound)
    {
        _playerSound = playerSound;
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(_controller.isGrounded)
        {
            RaycastHit hit;
            
            if(!IsGrounded)
            {
                IsGrounded = true;
                _playerSound.SoundLanding();
            }

            if(Physics.Raycast(transform.position, Vector3.down, out hit, _maxDistance, _groundLayers))
            {
                Ground ground;
                if(hit.collider.TryGetComponent<Ground>(out ground) && CurrentGroundType != ground.Type)
                {
                    CurrentGroundType = ground.Type;
                }
            }
        }
        else if(IsGrounded)
        {
            CurrentGroundType = GroundType.None;
            IsGrounded = false;
        }
    }    

    private void OnDrawGizmos() 
    {
        RaycastHit hit;

        bool isHited = Physics.Raycast(transform.position, Vector3.down, out hit, _maxDistance, _groundLayers);

        if(isHited)
        {
            Gizmos.DrawLine(transform.position, hit.point);
        }
    }
}