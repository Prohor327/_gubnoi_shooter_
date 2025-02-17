using UnityEngine;
using Zenject;

public class AmmoPack : MonoBehaviour, IInteractable
{
    [SerializeField] private AmmoPackSO _ammoPackSO;

    private Ammo _playerAmmo;

    [Inject]    
    private void Construct(Player player)
    {
        _playerAmmo = player.Ammo;
    }

    public void OnHover()
    {
        print(_ammoPackSO.AmmoType + " " + _ammoPackSO.AmountAmmo);
    }

    public void OnInteract()
    {
        _playerAmmo.AddAmmo(_ammoPackSO.AmmoType, _ammoPackSO.AmountAmmo);
        Destroy(gameObject);
    }

    public void OnStartHover() {   }

    public void OnEndHover() {   }
}