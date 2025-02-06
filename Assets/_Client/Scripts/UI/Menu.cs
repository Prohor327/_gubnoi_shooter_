using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
public class Menu : UIElement
{
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _container.Q<Button>("Play");
        Button exit = _container.Q<Button>("Exit");

        play.clicked += () => _gameMachine.LoadLevel("Prologue");
        exit.clicked += () => Application.Quit();
    }

    public override void Open()
    {
        base.Open();
    }
}
