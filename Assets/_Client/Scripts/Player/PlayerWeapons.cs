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
    public bool isWeaponActive { private set; get; }
    
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
        _weapons[index].OnTake += OnTakenWeapon;
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
        if(indexWeapon == _currentWeaponIndex || indexWeapon > _weapons.Count)
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

        _weapons[_currentWeaponIndex].RemoveWeapon();
        _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        _currentWeaponIndex = indexWeapon;
        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
        _player.Animations.SetAnimator(_weapons[_currentWeaponIndex].GetAnimator());
        _weapons[_currentWeaponIndex].Take();
    }

    private void RemoveWeapon()
    {
        _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        _player.Events.OnPutAwayAnyWeapon.Invoke();
        isWeaponActive = true;
    }

    public void Attack()
    {
        if(!isWeaponActive)
        {
            _weapons[_currentWeaponIndex].Attack();
        }
    }

    public void Reload()
    {
        if(!isWeaponActive)
        {
            _weapons[_currentWeaponIndex].Reload();
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