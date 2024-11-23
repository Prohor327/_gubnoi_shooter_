using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class Menu : UI
{
    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _UIElement.Q<Button>("Play");
        play.text = "Zalupa";
        //Button settings = _UIElement.Q<Button>("Settings");
        Button exit = _UIElement.Q<Button>("Exit");

        play.clicked += LoadTest;
        //settings.clicked += () => Open Settings;
        exit.clicked += () => Application.Quit();

    }

    protected override void Open()
    {
        base.Open();
    }

    private void LoadTest()
    {
        SceneManager.LoadScene("Test");
    }
}
