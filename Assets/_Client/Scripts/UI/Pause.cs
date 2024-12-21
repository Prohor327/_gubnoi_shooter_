using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Cursor = UnityEngine.Cursor;

public class Pause : UIElement
{
    private bool _onPause;
    [SerializeField] private GameplayUI _gameplayUI;
    
    protected override void Initialize()
    {
        base.Initialize();

        Button Continue = _container.Q<Button>("Continue");
        Button exit = _container.Q<Button>("Exit");

        Continue.clicked += Open;
        exit.clicked += () =>  SceneManager.LoadScene(1);
    }

    public override void Open()
    {
        base.Open();

        _onPause = !_onPause;

        if (_onPause)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            _gameplayUI.Open();
        }
    }
}
