using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/EnemyConfig", order = 0)]
public class EnemySO : ScriptableObject 
{
    [SerializeField] private HealthConfig _healthConfig;

    public HealthConfig HealthConfig => _healthConfig;
}