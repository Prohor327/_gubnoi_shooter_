using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public virtual void Dead() 
    {  
        Destroy(gameObject);
    }
}