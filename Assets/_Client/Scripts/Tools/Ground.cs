using UnityEngine;

public class Ground : MonoBehaviour 
{
    [SerializeField] private SurfaceType _surfaceType;    

    public SurfaceType Type => _surfaceType;
}