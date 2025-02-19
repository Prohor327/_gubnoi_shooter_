using UnityEngine;
using Zenject;

public class AmmoPack : Interactable
{
    [SerializeField] private AmmoPackSO _ammoPackSO;

    private Ammo _playerAmmo;

    [Inject]    
    private void Construct(Player player)
    {
        _playerAmmo = player.Ammo;
    }

    public override void OnInteract()
    {
        _playerAmmo.AddAmmo(_ammoPackSO.AmmoType, _ammoPackSO.AmountAmmo);
        base.OnInteract();
        DestroyImmediate(gameObject);
    }
}