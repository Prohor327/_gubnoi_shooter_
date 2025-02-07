using UnityEngine;

static class InputHandler
{
    private static Input _input;
    private static Input.PlayerActions _playerActions;
    private static Input.CutSceneActions _cutSceneActions;
    private static Input.GameActions _gameActions;

    public static Input.PlayerActions PlayerActions => _playerActions;
    public static Input.CutSceneActions CutSceneActions => _cutSceneActions;
    public static Input.GameActions Game => _gameActions;

    public static void Initialize()
    {
        MonoBehaviour.print("Initialize Input Handler");
        _input = new Input();
        _input.Enable();
        _playerActions = _input.Player;
        _cutSceneActions = _input.CutScene;
        _gameActions = _input.Game;
    }

    public static void OnEnable()
    {
        _input.Enable();
    }

    public static void OnDisable()
    {
        _input.Disable();
    }
}