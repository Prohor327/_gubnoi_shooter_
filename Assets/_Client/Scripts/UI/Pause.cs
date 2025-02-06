using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Cursor = UnityEngine.Cursor;
using Zenject;
using TMPro;

public class Pause : UIElement
{
    [SerializeField] private GameplayUI _gameplayUI;
    
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Button Continue = _container.Q<Button>("Continue");
        Button exit = _container.Q<Button>("Exit");

        Continue.clicked += Close;
        exit.clicked += () =>  SceneManager.LoadScene(1);
    }

    public override void Open()
    {
        if(_gameMachine.CurrentState == GameState.Game || _gameMachine.CurrentState == GameState.CutScene)
        {
            base.Open();
            _gameMachine.StopGame();
        }
    }

    private void Close()
    {
        if(_gameMachine.CurrentState == GameState.Pause)
        {
            _gameplayUI.Open();
            _gameMachine.ResumeGame();
        }
    }
}
