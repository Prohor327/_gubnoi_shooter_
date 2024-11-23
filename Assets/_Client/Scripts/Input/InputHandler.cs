using UnityEngine;

static class InputHandler
{
    private static Input _input;
    private static Input.PlayerActions _playerActions;

    public static Input.PlayerActions PlayerActions => _playerActions;

    public static void Initialize()
    {
        MonoBehaviour.print("Initialize Input Handler");
        _input = new Input();
        _input.Enable();
        _playerActions = _input.Player;
    }

    public static void OnEnable()
    {

    }

    public static void OnDisable()
    {
        _input.Disable();
    }
}