using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/EnemyConfig", order = 0)]
public class EnemySO : ScriptableObject 
{
    [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
}