using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public abstract class Weapon : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private WeaponType _type;

    [Header("Damage")]
    [SerializeField] private float _damage;

    [Header("Effects")]
    [SerializeField] private ShakeCameraAnimationSO _shakeCameraAnimationSO;

    public Action OnEndAttack;
    public Action OnTaken;
    public Action OnInitialize;
    public Action OnPerformAttack;
    public Action OnStartAttack;
    public Action<ShakeCameraAnimationConfig> OnPerformShakingCamera;
    public Action OnRemoveWeapon;

    public WeaponState State => state;
    public WeaponType Type => _type;
    public float Damage => _damage;

    protected WeaponState state;
    protected WeaponAnimations _animations;

    protected PlayerWeaponSound sound;

    private void Awake()
    {
        sound = GetComponent<PlayerWeaponSound>();
        _animations = GetComponent<WeaponAnimations>();
    }

    public virtual void Initialize(PlayerSound playerSound)
    {
        sound.Initialize(playerSound);
        state = WeaponState.Idle;
        OnInitialize?.Invoke();
    }

    public Animator GetAnimator()
    {
        return _animations.GetAnimator();
    }

    public virtual void Take()
    {
        OnTaken?.Invoke();
    }

    public virtual void Reload() {  }

    public virtual void PreformAttack() 
    {
        OnPerformAttack?.Invoke();
    }

    public virtual void Attack()
    {
        if(state == WeaponState.Idle)
        {
            state = WeaponState.Attack;
            _animations.PLayAttack();
            OnStartAttack?.Invoke();
        }
    }

    public void CameraShake()
    {
        OnPerformShakingCamera?.Invoke(_shakeCameraAnimationSO.ShakeCameraAnimationConfig);
    }

    public void FinishAttack()
    {
        state = WeaponState.Idle;
        OnEndAttack.Invoke(); 
    }

    public void RemoveWeapon()
    {
        state = WeaponState.Idle;
        OnRemoveWeapon?.Invoke();
    }

    protected virtual void OnDisable() 
    {
        OnInitialize += () => {};
        OnTaken += () => {};
        OnEndAttack += () => {};
        OnStartAttack += () => {};
        OnPerformAttack += () => {};
        OnRemoveWeapon += () => {};
    }
}