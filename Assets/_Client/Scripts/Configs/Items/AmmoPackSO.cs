using UnityEngine;

[CreateAssetMenu(fileName = "AmmoPack", menuName = "Game/AmmoPackSO", order = 0)]
public class AmmoPackSO : ItemSO 
{
    [field: SerializeField] public AmmoType AmmoType { get; private set; }
    [field: SerializeField] public int AmountAmmo { get; private set; }
}