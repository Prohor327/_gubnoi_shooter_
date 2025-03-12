using UnityEngine;
using Zenject;

public class AmmoPack : Pickable
{
    [SerializeField] private AmmoPackSO _ammoPackSO;

    private Ammo _playerAmmo;

    [Inject]    
    protected override void Construct(Player player)
    {
        _playerAmmo = player.Ammo;
        base.Construct(player);
    }

    public override void OnInteract()
    {
        base.OnInteract();
        _playerAmmo.AddAmmo(_ammoPackSO.AmmoType, _ammoPackSO.AmountAmmo);
        DestroyImmediate(gameObject);
    }
}