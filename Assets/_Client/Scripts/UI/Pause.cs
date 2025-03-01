using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Zenject;

public class Pause : UIElement
{
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        _gameMachine.OnFinishGame += OnFinishGame;
        InputHandler.Game.Pause.started += OnPause;

        base.Initialize();

        Button Continue = _UIElement.Q<Button>("Continue");
        Button exit = _UIElement.Q<Button>("Exit");

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
            _gameMachine.ResumeGame();
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        Open();
    }

    private void OnFinishGame()
    {
        InputHandler.Game.Pause.started -= OnPause;
    }
}
