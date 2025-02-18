using Zenject;

public class PlayerAmmo : Ammo
{
    private PlayerEvents _playerEvents;
    private AmmoType _currentAmmoType;

    public void Initialize(PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;
    }

    public override void AddAmmo(AmmoType ammoType, int amount)
    {
        base.AddAmmo(ammoType, amount);
        if(_currentAmmoType == ammoType)
        {
            _playerEvents.OnChangedAmountAmmo("1/" + ammo[ammoType]);
        }
    }

    public override bool TryShot(AmmoType ammoType)
    {
        if(ammo[ammoType] <= 0)    
        {
            return false;
        }
        else
        {
            ammo[ammoType]--;
            _playerEvents.OnChangedAmountAmmo("1/" + ammo[ammoType]);
            return true;
        }
    }

    public void ChangeAmmoType(AmmoType ammoType)
    {
        if(_currentAmmoType == ammoType)
        {
            return;
        }

        _currentAmmoType = ammoType;
        if(_currentAmmoType == AmmoType.Nothing)
        {
            _playerEvents.OnChangedAmountAmmo("	∞");    
            return;
        }
        _playerEvents.OnChangedAmountAmmo("1/" + ammo[ammoType]);
    }
}