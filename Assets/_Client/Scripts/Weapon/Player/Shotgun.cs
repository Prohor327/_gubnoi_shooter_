using UnityEngine;

public class Shotgun : RaycastWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor.Visit(this, hit);
    }
}