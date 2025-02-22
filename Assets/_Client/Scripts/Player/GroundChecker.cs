using NUnit.Framework;
using UnityEngine;

public class GroundChecker : MonoBehaviour 
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _groundLayers;

    public bool IsGrounded { get; private set; }
    public GroundType CurrentGroundType { get; private set; }

    private void Update()
    {
        RaycastHit hit;

        bool isHited = Physics.Raycast(transform.position, Vector3.down, out hit, _maxDistance, _groundLayers);

        if(isHited)
        {
            if(!IsGrounded)
            {
                IsGrounded = true;
            }

            Ground ground;
            if(hit.collider.TryGetComponent<Ground>(out ground) && CurrentGroundType != ground.Type)
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
        RaycastHit hit;

        bool isHited = Physics.Raycast(transform.position, Vector3.down, out hit, _maxDistance, _groundLayers);

        if(isHited)
        {
            Gizmos.DrawLine(transform.position, hit.point);
        }
    }
}