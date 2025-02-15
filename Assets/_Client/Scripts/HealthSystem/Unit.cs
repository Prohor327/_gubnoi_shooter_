using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private HealthConfig _healthConfig;
    private Character _character;
    private float _health;

    public Action<float> OnHealthChanged; 

    public void Initialize(Character character, HealthConfig healthConfig)
    {
        _character = character;
        _healthConfig = healthConfig;
        _health = _healthConfig.Health;
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health);
        if(_health <= 0)
        {
            _character.Dead();
        }
    }

    public void Heal(float points)
    {
        _health += points;
        if(_health > _healthConfig.Health)
        {
            _health = _healthConfig.Health;
        }
        OnHealthChanged?.Invoke(_health);
    }
    
}