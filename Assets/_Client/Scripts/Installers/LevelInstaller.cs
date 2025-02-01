using UnityEngine;
using Zenject;

public class LevelIntaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Pause _pause;

    private Player player;

    public override void InstallBindings()
    {
        InstallUI();
        InstallPlayer();
    }

    private void InstallPlayer()
    {
        player = Container.InstantiatePrefabForComponent<Player>(_player.gameObject, _spawnPoint.position, Quaternion.identity, null);
        Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
    }

    private void InstallUI()
    {
        Container.Bind<Pause>().FromInstance(_pause).AsSingle().NonLazy();
    }
}