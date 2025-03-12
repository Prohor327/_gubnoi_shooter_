using UnityEngine;
using Zenject;

public class LevelInitializer : MonoBehaviour 
{
    private GameMachine _gameMachine;

    [Inject]
    private void Constuct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    private void Start()
    {
        _gameMachine.StartGame();
        Destroy(gameObject);
    }
}