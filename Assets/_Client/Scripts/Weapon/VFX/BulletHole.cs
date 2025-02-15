using UnityEngine;

public class BulletHole : Decal
{
    [SerializeField] private float _lifetime;    

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}