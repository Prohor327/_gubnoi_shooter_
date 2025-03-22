using UnityEngine;

public class LimitedLifeDecal : Decal
{
    [SerializeField] private float _lifetime;    

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}