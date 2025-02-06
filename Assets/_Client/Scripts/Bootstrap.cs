using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private GameMachine _gameMachine;

    [Inject]
    public void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    private void Start()
    {
        _gameMachine.Initialize();
    }
}