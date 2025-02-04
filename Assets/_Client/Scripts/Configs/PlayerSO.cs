using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig", order = 0)]
public class PlayerSO : ScriptableObject 
{
    [SerializeField] private MovementConfig _movementConfig;
    [SerializeField] private HealthConfig _healthConfig;
    [SerializeField] private HandsConfig _handsConfig;
    [SerializeField] private PlayerLookConfig _playerLookConfig;

    public MovementConfig MovementConfig => _movementConfig;
    public HealthConfig HealthConfig => _healthConfig;
    public HandsConfig HandsConfig => _handsConfig;
    public PlayerLookConfig PlayerLookConfig => _playerLookConfig;
}