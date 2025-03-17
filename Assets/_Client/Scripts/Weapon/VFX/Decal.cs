using UnityEngine;

public class Decal : MonoBehaviour
{
    private ParticleSystem decal;

    private void Start()
    {
        decal = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(!decal.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}