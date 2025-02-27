using System;

public class PlayerEvents 
{
    public Action<float> OnHealthChanged;
    public Action<string> OnStartHoverObject;
    public Action OnEndHoverObject;
    public Action OnStartMove;
    public Action OnEndMove;
    public Action<string> OnChangedAmountAmmo;
    public Action OnChangedAmmoType;
    public Action OnTakenItem;
    public Action OnPutAwayItem;
    public Action OnTakenAnyWeapon;
    public Action OnTakenShotgun;
    public Action OnTakenAxe;
    public Action OnTakenPistol;
    public Action OnTakenHands;
}   