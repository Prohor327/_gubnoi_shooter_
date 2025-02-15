using UnityEngine;

public class Axe : OverlapWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor.Visit(this);
    }
}