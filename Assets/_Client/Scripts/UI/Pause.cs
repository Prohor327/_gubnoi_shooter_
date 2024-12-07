using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Cursor = UnityEngine.Cursor;

public class Pause : UI
{
    private bool _onPause;
    [SerializeField] private GameUI _gameUI;
    
    protected override void Initialize()
    {
        base.Initialize();

        Button Continue = _UIElement.Q<Button>("Continue");
        Button exit = _UIElement.Q<Button>("Exit");

        Continue.clicked += OpenPause;
        exit.clicked += () =>  SceneManager.LoadScene(1);
    }

    protected override void Open()
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
            _gameUI.OpenGU();
        }
    }

    public void OpenPause() => Open(); 
}
