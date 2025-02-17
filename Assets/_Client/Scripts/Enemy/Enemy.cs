using UnityEngine;

[RequireComponent(typeof(EnemyAnimations))]
[RequireComponent(typeof(Unit))]
public class Enemy : Character
{
    [SerializeField] private EnemySO _enemySO;

    private Unit _unit;
    private EnemyAnimations _animations;

    private void Start()
    {
        _animations = GetComponent<EnemyAnimations>();
        _unit = GetComponent<Unit>();
        _unit.Initialize(this, _enemySO.HealthConfig);
        _unit.OnTakenDamege += GetHit;
    }

    public override void Dead()
    {
        _animations.PlayDead();
        GetComponent<Collider>().enabled = false;
    }

    private void GetHit()
    {
        _animations.PlayGetHit();
    }
}