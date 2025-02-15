using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public abstract class Weapon : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float _damage;

    [Header("Effects")]
    [SerializeField] private ShakeCameraAnimationSO _shakeCameraAnimationSO;

    public Action OnEndAttack;
    public Action OnInitialize;
    public Action OnPerformAttack;
    public Action OnStartAttack;
    public Action<ShakeCameraAnimationConfig> OnPerformShakingCamera;
    public Action OnRemoveWeapon;

    public WeaponState State => state;
    public float Damage => _damage;

    protected Transform shootPoint;
    protected WeaponState state;
    protected WeaponAnimations _animations;

    private PlayerWeaponSound _sound;

    private void Awake()
    {
        _sound = GetComponent<PlayerWeaponSound>();
        _animations = GetComponent<WeaponAnimations>();
    }

    public virtual void Initialize(Transform shootPoint, PlayerSound playerSound)
    {
        this.shootPoint = shootPoint;
        _sound.Initialize(playerSound);
        state = WeaponState.Idle;
        OnInitialize?.Invoke();
    }

    public Animator GetAnimator()
    {
        return _animations.GetAnimator();
    }

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
        OnEndAttack += () => {};
        OnStartAttack += () => {};
        OnPerformAttack += () => {};
        OnRemoveWeapon += () => {};
    }
}