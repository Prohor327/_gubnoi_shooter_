using UnityEngine;
using Zenject;

[RequireComponent(typeof(GameObjectContext))]
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Rig _rig;

    public override void InstallBindings()
    {
        Container.Bind<Rig>().FromInstance(_rig).AsSingle();

    }
}