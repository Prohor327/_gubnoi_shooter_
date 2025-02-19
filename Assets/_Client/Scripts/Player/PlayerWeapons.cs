using UnityEngine;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon[] _startedWeapons;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _currentWeaponIndex;
    private Player _player;
    private Transform _shootPoint;
    private Transform _weaponPoint;
    
    public int AmountWeapon => _startedWeapons.Length;

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
            SpawnWeapon(0, _shootPoint, true);
            _weapons[0].Take();
            for(int i = 1; i < AmountWeapon; i++)
            {
                SpawnWeapon(i, _shootPoint, false);
            }
            _player.Animations.SetAnimator(_weapons[_currentWeaponIndex].GetAnimator());
            // _player.Events.OnTakenItem += PutAwayCurrentWeapon;
            // _player.Events.OnPutAwayItem += TakeCurrentWeapon;
        }
    }

    private void SpawnWeapon(int index, Transform shootPoint, bool stateWeapon)
    {
        switch(_startedWeapons[index])
        {
            case FirearmWeapon:
            {
                FirearmWeapon weapon = Instantiate(_startedWeapons[index].gameObject, _weaponPoint).GetComponent<FirearmWeapon>();
                weapon.Initialize(shootPoint, _player.Sound, _player.Ammo);
                weapon.OnChangedAmountAmmoInClip += (string text) => _player.Events.OnChangedAmountAmmo(text);
                _weapons.Add(weapon);
            }
            break;
            case OverlapWeapon:
            {
                OverlapWeapon weapon = Instantiate(_startedWeapons[index].gameObject, _weaponPoint).GetComponent<OverlapWeapon>();
                weapon.Initialize(_player.Sound);
                weapon.OnTake += () => _player.Events.OnChangedAmountAmmo.Invoke("∞");
                _weapons.Add(weapon);
            }
            break;
        }
        _weapons[index].OnPerformShakingCamera += _player.CameraShaker.ReactOnAttack;
        //_weapons[index].OnTake
        _weapons[index].gameObject.SetActive(stateWeapon);
        _weapons[index].OnEndAttack += EndAttack;
    }

    public void ChangeWeapon(int indexWeapon)
    {
        if(indexWeapon == _currentWeaponIndex || indexWeapon > _weapons.Count - 1)
        {
            return;
        }
        _weapons[_currentWeaponIndex].RemoveWeapon();
        _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        _currentWeaponIndex = indexWeapon;
        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
        _weapons[_currentWeaponIndex].Take();
        _player.Animations.SetAnimator(_weapons[_currentWeaponIndex].GetAnimator());
    }

    public void Attack()
    {
        _weapons[_currentWeaponIndex].Attack();
    }

    public void Reload()
    {
        _weapons[_currentWeaponIndex].Reload();
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
        return _weapons[_currentWeaponIndex].State;
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