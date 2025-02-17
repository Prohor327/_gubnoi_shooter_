using UnityEngine;

[CreateAssetMenu(fileName = "AmmoPack", menuName = "Game/AmmoPackSO", order = 0)]
public class AmmoPackSO : ItemSO 
{
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _amountAmmo;


    public int AmountAmmo => _amountAmmo;
    public AmmoType AmmoType => _ammoType;
}