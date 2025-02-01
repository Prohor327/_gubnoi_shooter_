using UnityEngine;

public class Unit : MonoBehaviour, IWeaponVisitor
{
    public void Visit(RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }
}
