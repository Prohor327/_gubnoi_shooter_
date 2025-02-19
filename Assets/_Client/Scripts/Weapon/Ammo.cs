using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

public class Ammo : MonoBehaviour 
{
    [SerializedDictionary("Ammo type", "Amount")]
    [SerializeField] protected SerializedDictionary<AmmoType, int> ammo;

    public Action OnAddedAmmo;

    public virtual int LoadClip(AmmoType ammoType, int clipSize, int amountAmmoInClip)
    {
        ammo[ammoType] += amountAmmoInClip;
        if(GetAmountAmmo(ammoType) >= clipSize)
        {
            ammo[ammoType] -= clipSize;
            return clipSize;
        }

        int result = GetAmountAmmo(ammoType);
        ammo[ammoType] = 0;
        return result;
    }

    public virtual int LoadClipShotgun(int amountAmmoInClip)
    {
        ammo[AmmoType.Fraction]--;
        return amountAmmoInClip + 1;
    }

    public int GetAmountAmmo(AmmoType ammoType)
    {
        return ammo[ammoType];
    }   

    public virtual void AddAmmo(AmmoType ammoType, int amount)
    {
        ammo[ammoType] += amount;
        OnAddedAmmo.Invoke();
    }

    // public int GetAmmoForClip(AmmoType ammoType, int clipSize)
    // {
    //     if(_ammo[ammoType] > clipSize)
    //     {

    //     }
    // }

    private void OnDisable()
    {
        OnAddedAmmo += () => {  };
    }
}