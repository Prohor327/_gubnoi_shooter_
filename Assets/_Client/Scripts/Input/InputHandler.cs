using UnityEngine;

static class InputHandler
{
    private static Input _input;
    private static Input.PlayerActions _playerActions;

    public static Input.PlayerActions PlayerActions => _playerActions;

    public static void Initialize()
    {
        _playerActions = _input.Player;

        MonoBehaviour.print("Initialize Input Handler");
    }

    public static void OnEnable()
    {
        _input = new Input();
        _input.Enable();
    }

    public static void OnDisable()
    {
        _input.Disable();
    }
}