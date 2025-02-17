using UnityEngine;
using AYellowpaper.SerializedCollections;

public class Ammo : MonoBehaviour 
{
    [SerializedDictionary("Ammo type", "Amount")]
    [SerializeField] private SerializedDictionary<AmmoType, int> _ammo;

    public bool TryShot(AmmoType ammoType)
    {
        if(_ammo[ammoType] <= 0)    
        {
            return false;
        }
        else
        {
            _ammo[ammoType]--;
            return true;
        }
    }

    public int GetAmountAmmo(AmmoType ammoType)
    {
        return _ammo[ammoType];
    }   

    public void AddAmmo(AmmoType ammoType, int amount)
    {
        _ammo[ammoType] += amount;
    }   

    // public int GetAmmoForClip(AmmoType ammoType, int clipSize)
    // {
    //     if(_ammo[ammoType] > clipSize)
    //     {
            
    //     }
    // }
}