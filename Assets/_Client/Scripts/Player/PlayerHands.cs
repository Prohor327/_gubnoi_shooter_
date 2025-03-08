using UnityEngine;

public class PlayerHands : MonoBehaviour 
{
    private PlayerWeapons _playerWeapons;
    private PlayerEvents _playerEvents;

    public HandsState State { private set; get; }

    public void Initialize(Player player)
    {
        _playerWeapons = player.Weapons;
        _playerEvents = player.Events;
        State = HandsState.Hands;
    }

    public void Take()
    {
        State = HandsState.Hands;
        _playerEvents.OnChangedAmountAmmo.Invoke("");
        _playerEvents.OnTakenHands.Invoke();
        _playerWeapons.RemoveWeapon();
    }

    public void PutAway()
    {
        State = HandsState.Weapon;
    }
}