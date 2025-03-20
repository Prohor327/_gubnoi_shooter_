using UnityEngine;
using System;
using TMPro;
using UnityEditor.Search;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponAnimations))]
[RequireComponent(typeof(PlayerWeaponSound))]
public abstract class Weapon : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private WeaponType _type;
    [SerializeField] private string _name; 

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
    public string Name => _name;

    protected WeaponState state;
    protected PlayerWeaponSound sound;
    protected WeaponAnimations animations;
    protected SurfaceConfig surfaceConfig;

    public virtual void Initialize(PlayerSound playerSound, SurfaceConfig surfaceConfig)
    {
        state = WeaponState.Idle;
        OnInitialize?.Invoke();
        sound = GetComponent<PlayerWeaponSound>();
        sound.Initialize(playerSound);
        animations = GetComponent<WeaponAnimations>();
        this.surfaceConfig = surfaceConfig;
        animations.Initialize();
    }

    public Animator GetAnimator()
    {
        return animations.GetAnimator();
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
            animations.PLayAttack();
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