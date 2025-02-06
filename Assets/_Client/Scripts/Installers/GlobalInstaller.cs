using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallScenesOpener();
        InstallGameMachine();
    }

    private void InstallScenesOpener()
    {
        Container.Bind<ScenesOpener>().AsSingle().NonLazy();
    }

    private void InstallGameMachine()
    {
        Container.Bind<GameMachine>().AsSingle().NonLazy();
    }
}