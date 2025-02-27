using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon[] _startedWeapons;

    private List<Weapon> _weapons = new List<Weapon>();
    private Player _player;
    private Transform _shootPoint;
    private Transform _weaponPoint;
    public bool isWeaponActive { private set; get; }
    
    public int AmountWeapon => _startedWeapons.Length;
    public int CurrentWeaponIndex {private set; get; }
    public int PreviousWeaponIndex {private set; get; }

    public void Initialize(Rig rig, Player player)
    {
        _shootPoint = rig.PlayerCamera.transform;
        _weaponPoint = rig.WeaponPoint;

        _player = player;
    }

    private void Start()
    {
        if(AmountWeapon != 0)
        {
            SpawnWeapon(0, true);
            _weapons[0].Take();
            for(int i = 1; i < AmountWeapon; i++)
            {
                SpawnWeapon(i, false);
            }
            _player.Animations.SetAnimator(_weapons[CurrentWeaponIndex].GetAnimator());
        }
    }

    private void SpawnWeapon(int index, bool stateWeapon)
    {
        switch(_startedWeapons[index].Type)
        {
            case WeaponType.Shotgun:
            {
                InitializeFirearmWeapon(Instantiate(_startedWeapons[index].gameObject, _weaponPoint).GetComponent<Shotgun>());
                _weapons[index].OnTaken += _player.Events.OnTakenShotgun.Invoke;
            }
            break;
            case WeaponType.Pistol:
            {
                InitializeFirearmWeapon(Instantiate(_startedWeapons[index].gameObject, _weaponPoint).GetComponent<Pistol>());
                _weapons[index].OnTaken += _player.Events.OnTakenPistol.Invoke;
            }
            break;
            case WeaponType.Axe:
            {
                InitializeOverlapWeapon(Instantiate(_startedWeapons[index].gameObject, _weaponPoint).GetComponent<Axe>());
                _weapons[index].OnTaken += _player.Events.OnTakenAxe.Invoke;
            }
            break;
        }
        _weapons[index].OnPerformShakingCamera += _player.CameraShaker.ReactOnAttack;
        _weapons[index].gameObject.SetActive(stateWeapon);
        _weapons[index].OnEndAttack += EndAttack;
        _weapons[index].OnTaken += OnTakenWeapon;
    }

    private void InitializeFirearmWeapon(FirearmWeapon weapon)
    {               
        weapon.Initialize(_shootPoint, _player.Sound, _player.Ammo);
        weapon.OnChangedAmountAmmoInClip += (string text) => _player.Events.OnChangedAmountAmmo(text);
        _weapons.Add(weapon);
    }

    private void InitializeOverlapWeapon(OverlapWeapon weapon)
    {
        weapon.Initialize(_player.Sound);
        weapon.OnTaken += () => _player.Events.OnChangedAmountAmmo.Invoke("∞");
        _weapons.Add(weapon);
    }

    private void OnTakenWeapon()
    {
        if(_player.State == PlayerState.Move)
        {
            _player.Animations.PlayWalk();
        }
    }

    public void ChangeWeapon(int indexWeapon)
    {
        if(indexWeapon == CurrentWeaponIndex || indexWeapon > _weapons.Count)
        {
            return;
        }

        if(indexWeapon == 3)
        {
            RemoveWeapon();
            return;
        }

        if(isWeaponActive)
        {
            isWeaponActive = false;
            _player.Events.OnTakenAnyWeapon.Invoke();
        }

        _weapons[CurrentWeaponIndex].RemoveWeapon();
        _weapons[CurrentWeaponIndex].gameObject.SetActive(false);
        PreviousWeaponIndex = CurrentWeaponIndex;
        CurrentWeaponIndex = indexWeapon;
        _weapons[CurrentWeaponIndex].gameObject.SetActive(true);
        _player.Animations.SetAnimator(_weapons[CurrentWeaponIndex].GetAnimator());
        _weapons[CurrentWeaponIndex].Take();
    }

    private void RemoveWeapon()
    {
        _weapons[CurrentWeaponIndex].gameObject.SetActive(false);
        _player.Events.OnTakenHands.Invoke();
        isWeaponActive = true;
    }

    public void Attack()
    {
        if(!isWeaponActive)
        {
            _weapons[CurrentWeaponIndex].Attack();
        }
    }

    public void Reload()
    {
        if(!isWeaponActive)
        {
            _weapons[CurrentWeaponIndex].Reload();
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

    public WeaponState GetWeaponState()
    {
        return _weapons[CurrentWeaponIndex].State;
    }

    // private void PutAwayCurrentWeapon()
    // {
    //     _weapons[_currentWeaponIndex].RemoveWeapon();
    //     _weapons[_currentWeaponIndex].gameObject.SetActive(false);
    // }

    // private void TakeCurrentWeapon()
    // {
    //     _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    //     _weapons[_currentWeaponIndex].Take();
    // }
}