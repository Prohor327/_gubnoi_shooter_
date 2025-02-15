using UnityEngine;

public class Pistol : RaycastWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor.Visit(this, hit);
    }
}