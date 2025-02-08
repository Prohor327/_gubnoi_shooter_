using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Weapon[] _startedWeapons;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _indexCurrentWeapon = 0;
    private int _previousIndexWeapon;
    private Player _player;
    private Transform _rigPoint;
    private Transform _shootPoint;
    private PlayerAnimations _playerAnimations;
    private PlayerSound _playerSound;
    
    public int AmountWeapon => _startedWeapons.Length;

    public WeaponState GetWeaponState()
    {
        return _weapons[_indexCurrentWeapon].State;
    }

    [Inject]
    private void Construct(Rig rig)
    {
        _rigPoint = rig.RigPoint;
        _shootPoint = rig.PlayerCamera.transform;
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerAnimations = GetComponent<PlayerAnimations>();
        _playerSound = GetComponent<PlayerSound>();
        print(_playerSound);
    }

    private void Start()
    {
        if(_startedWeapons.Length != 0)
        {
            SpawnWeapon(0, _shootPoint, true);
            for(int i = 1; i < _startedWeapons.Length; i++)
            {
                SpawnWeapon(1, _shootPoint, false);
            }
            _playerAnimations.SetAnimator(_weapons[_indexCurrentWeapon].GetAnimator());
        }
    }

    private void SpawnWeapon(int indexInArray, Transform shootPoint, bool stateWeapon)
    {
        _weapons.Add(Instantiate(_startedWeapons[indexInArray].gameObject, _rigPoint).GetComponent<Weapon>());
        _weapons[indexInArray].Initialize(shootPoint, _playerSound);
        //_weapons[indexInArray].onShoot += shakeCameraOnWeaponAttack.ReactOnAttack;
        _weapons[indexInArray].gameObject.SetActive(stateWeapon);
        _weapons[indexInArray].OnEndAttack += EndAttack;
    }

    public void ChangeWeapon(int indexWeapon)
    {
        if(indexWeapon == _indexCurrentWeapon || indexWeapon > _weapons.Count)
        {
            return;
        }
        _weapons[_indexCurrentWeapon].RemoveWeapon();
        _weapons[_indexCurrentWeapon].gameObject.SetActive(false);
        _weapons[indexWeapon].gameObject.SetActive(true);
        _previousIndexWeapon = _indexCurrentWeapon;
        _indexCurrentWeapon = indexWeapon;
        _playerAnimations.SetAnimator(_weapons[_indexCurrentWeapon].GetAnimator());
    }

    public void Attack()
    {
        _weapons[_indexCurrentWeapon]?.Attack();
    }

    private void EndAttack()
    {
        switch(_player.State)
        {
            case PlayerState.Move:
                {
                    _playerAnimations.PlayWalk();
                    break;
                }
            case PlayerState.Idle:
                {
                    _playerAnimations.PlayIdle();
                    break;
                }
        }
    }

    private void TakeWeapon()
    {
        _weapons[_previousIndexWeapon].gameObject.SetActive(false);
        _weapons[_indexCurrentWeapon].gameObject.SetActive(true);
    }

    private void OnFinishGame()
    { 
        for(int i = 0; i < _startedWeapons.Length; i++)
        {
            _weapons[i].OnEndAttack -= EndAttack;
            //_weapons[i].onShoot -= shakeCameraOnWeaponAttack.ReactOnAttack;
        }
    }
}