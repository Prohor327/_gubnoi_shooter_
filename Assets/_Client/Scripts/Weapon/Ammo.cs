using UnityEngine;
using AYellowpaper.SerializedCollections;

public class Ammo : MonoBehaviour 
{
    [SerializedDictionary("Ammo type", "Amount")]
    [SerializeField] protected SerializedDictionary<AmmoType, int> ammo;

    public virtual bool TryShot(AmmoType ammoType)
    {
        if(ammo[ammoType] <= 0)    
        {
            return false;
        }
        else
        {
            ammo[ammoType]--;
            return true;
        }
    }

    public int GetAmountAmmo(AmmoType ammoType)
    {
        return ammo[ammoType];
    }   

    public virtual void AddAmmo(AmmoType ammoType, int amount)
    {
        ammo[ammoType] += amount;
    }   

    // public int GetAmmoForClip(AmmoType ammoType, int clipSize)
    // {
    //     if(_ammo[ammoType] > clipSize)
    //     {
            
    //     }
    // }
}