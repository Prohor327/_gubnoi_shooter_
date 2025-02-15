using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Pistol pistol, RaycastHit hit);
    public void Visit(Shotgun shotgun, RaycastHit hit);
    public void Visit(Axe axe);
}
