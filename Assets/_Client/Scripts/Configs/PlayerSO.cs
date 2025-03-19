using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/PlayerConfig", order = 0)]
public class PlayerSO : ScriptableObject 
{
    [field: SerializeField] public MovementConfig MovementConfig { get; private set; }
    [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
    [field: SerializeField] public HandsConfig HandsConfig { get; private set; }
    [field: SerializeField] public PlayerLookConfig PlayerLookConfig { get; private set; }
}