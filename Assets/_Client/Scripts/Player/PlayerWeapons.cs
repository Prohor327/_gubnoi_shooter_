using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon[] _startedWeapons;

    private Dictionary<WeaponType, Weapon> _weapons = new Dictionary<WeaponType, Weapon>();
    private Player _player;
    
    public int AmountWeapon => _startedWeapons.Length;
    public WeaponType CurrentWeaponType { private set; get; }
    public WeaponType PreviousWeaponType { private set; get; }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        if(AmountWeapon != 0)
        {
            for(int i = 0; i < AmountWeapon; i++)
            {
                AddWeapon(_startedWeapons[i]);
            }
        }
    }

    public void AddWeapon(Weapon addedWeapon)
    {
        if(_weapons.ContainsKey(addedWeapon.Type))
        {
            return;
        }

        Weapon weapon = Instantiate(addedWeapon.gameObject, _player.Rig.WeaponPoint).GetComponent<Weapon>();
        _weapons.Add(weapon.Type, weapon);

        switch(addedWeapon.Type)
        {
            case WeaponType.Shotgun:
            {
                InitializeFirearmWeapon(weapon.ConvertTo<Shotgun>());
                _weapons[weapon.Type].OnTaken += _player.Events.OnTakenShotgun.Invoke;
            }
            break;
            case WeaponType.Pistol:
            {
                InitializeFirearmWeapon(weapon.ConvertTo<Pistol>());
                _weapons[weapon.Type].OnTaken += _player.Events.OnTakenPistol.Invoke;
            }
            break;
            case WeaponType.Axe:
            {
                InitializeOverlapWeapon(weapon.ConvertTo<Axe>());
                _weapons[weapon.Type].OnTaken += _player.Events.OnTakenAxe.Invoke;
            }
            break;
        }
        _weapons[weapon.Type].OnPerformShakingCamera += _player.CameraShaker.ReactOnAttack;
        _weapons[weapon.Type].gameObject.SetActive(false);
        _weapons[weapon.Type].OnEndAttack += EndAttack;
        _weapons[weapon.Type].OnTaken += OnTakenWeapon;
    }

    private void InitializeFirearmWeapon(FirearmWeapon weapon)
    {               
        weapon.Initialize(_player.Rig.PlayerCamera.transform, _player.Sound, _player.Ammo);
        weapon.OnChangedAmountAmmoInClip += (string text) => _player.Events.OnChangedAmountAmmo(text);
    }

    private void InitializeOverlapWeapon(OverlapWeapon weapon)
    {
        weapon.Initialize(_player.Sound);
        weapon.OnTaken += () => _player.Events.OnChangedAmountAmmo.Invoke("∞");
    }

    private void OnTakenWeapon()
    {
        if(_player.State == PlayerState.Move)
        {
            _player.Animations.PlayWalk();
        }
    }

    public void ChangeWeapon(WeaponType weaponType)
    {
        if(_player.Hands.State == HandsState.Hands)
        {
            _player.Hands.PutAway();
        }
        if(weaponType == CurrentWeaponType || !_weapons.ContainsKey(weaponType))
        {
            return;
        }

        PreviousWeaponType = CurrentWeaponType;
        CurrentWeaponType = weaponType;
        if(PreviousWeaponType != WeaponType.None)
        {
            _weapons[PreviousWeaponType].RemoveWeapon();
            _weapons[PreviousWeaponType].gameObject.SetActive(false);
        }
        _weapons[CurrentWeaponType].gameObject.SetActive(true);
        _player.Animations.SetAnimator(_weapons[CurrentWeaponType].GetAnimator());
        _weapons[CurrentWeaponType].Take();
    }

    public void RemoveWeapon()
    {
        if(CurrentWeaponType == WeaponType.None)
        {
            return;
        }
        _weapons[CurrentWeaponType].gameObject.SetActive(false);
        PreviousWeaponType = CurrentWeaponType;
        CurrentWeaponType = WeaponType.None;
    }

    public void Attack()
    {
        if(_player.Hands.State == HandsState.Weapon)
        {
            _weapons[CurrentWeaponType].Attack();
        }
    }

    public void Reload()
    {
        if(_player.Hands.State == HandsState.Weapon)
        {
            _weapons[CurrentWeaponType].Reload();
        }
    }

    private void EndAttack()
    {
        switch(_player.State)
        {
            case PlayerState.Move:
                {
                    _player.Animations.PlayWalk();
                    break;
                }
            case PlayerState.Idle:
                {
                    _player.Animations.PlayIdle();
                    break;
                }
        }
    }

    public bool CanWalkPlayAnimation()
    {
        if(_weapons[CurrentWeaponType].State == WeaponState.Idle)
        {
            return true;
        }
        return false;
    }

    public bool CanSoundWalk()
    {
        if(_weapons[CurrentWeaponType].State != WeaponState.Idle)
        {
            return true;
        }
        return false;
    }
}