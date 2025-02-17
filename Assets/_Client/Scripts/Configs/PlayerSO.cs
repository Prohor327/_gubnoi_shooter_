using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/PlayerConfig", order = 0)]
public class PlayerSO : ScriptableObject 
{
    [SerializeField] private MovementConfig _movementConfig;
    [SerializeField] private HealthConfig _healthConfig;
    [SerializeField] private HandsConfig _handsConfig;
    [SerializeField] private PlayerLookConfig _playerLookConfig;
    //[SerializeField] private PlayerWeaponConfig _playerWeaponConfig;

    public MovementConfig MovementConfig => _movementConfig;
    public HealthConfig HealthConfig => _healthConfig;
    public HandsConfig HandsConfig => _handsConfig;
    public PlayerLookConfig PlayerLookConfig => _playerLookConfig;
    //public PlayerWeaponConfig PlayerWeaponConfig => _playerWeaponConfig;
}