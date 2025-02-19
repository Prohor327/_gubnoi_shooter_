using UnityEngine;

public class GroundChecker : MonoBehaviour 
{
    [SerializeField] private float _castDistance;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private LayerMask _groundLayers;

    private RaycastHit _hit;

    public bool IsGrounded { get; private set; }
    public GroundType CurrentGroundType { get; private set; }

    private void Update()
    {
        bool isHited = Physics.BoxCast(transform.position, _boxSize, -transform.up, out _hit, Quaternion.identity, _castDistance, _groundLayers);

        if(isHited)
        {
            if(!IsGrounded)
            {
                IsGrounded = true;
            }

            Ground ground;
            if(_hit.collider.TryGetComponent<Ground>(out ground) && CurrentGroundType != ground.Type)
            {
                CurrentGroundType = ground.Type;
            }
        }
        else if(!isHited && IsGrounded)
        {
            CurrentGroundType = GroundType.None;
            IsGrounded = false;
        }
    }    

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _castDistance, _boxSize);
    }
}