using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(RaycastHit hit);
}
