using UnityEngine;

public class Ground : MonoBehaviour 
{
    [SerializeField] private GroundType _groundType;    

    public GroundType Type => _groundType;
}