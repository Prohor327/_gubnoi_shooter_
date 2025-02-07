using UnityEngine;
using Zenject;

[RequireComponent(typeof(GameObjectContext))]
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Rig _rig;

    public override void InstallBindings()
    {
        InstallRig();
        InstallPlayerSound();
        print("Player Installed");
    }

    private void InstallRig()
    {
        Container.Bind<Rig>().FromInstance(_rig).AsSingle().NonLazy();
        print("Rig Installed");
    }

    private void InstallPlayerSound()
    {
        Container.Bind<PlayerSound>().FromInstance(GetComponent<PlayerSound>()).AsSingle();
        print("PlayerSound Installed");
    }
}