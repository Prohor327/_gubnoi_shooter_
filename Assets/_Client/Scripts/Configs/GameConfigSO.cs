using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
public class GameConfigSO : ScriptableObjectInstaller<GameConfigSO>
{
    [SerializeField] private SurfaceConfig _surfaceConfig;

    public override void InstallBindings()
    {
        Container.Bind<SurfaceConfig>().FromInstance(_surfaceConfig).NonLazy();
    }
}