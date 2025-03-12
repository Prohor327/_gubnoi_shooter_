using UnityEngine;
using Zenject;

public class WeaponItem : Pickable 
{
    [SerializeField] private Weapon _weapon;

    private PlayerWeapons _playerWeapons;

    [Inject]
    private void Constuct(Player player)
    {
        _playerWeapons = player.Weapons;
    }

    public override void OnInteract()
    {
        base.OnInteract();
        _playerWeapons.AddWeapon(_weapon);
        _playerWeapons.ChangeWeapon(_weapon.Type);
        Destroy(gameObject);
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject.Invoke("[E] Подобрать " + _weapon.Name);
    }
}