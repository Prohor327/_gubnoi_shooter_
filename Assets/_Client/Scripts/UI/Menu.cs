using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : UIElement
{
    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _container.Q<Button>("Play");
        Button exit = _container.Q<Button>("Exit");

        play.clicked += () => Invoke(nameof(LoadTest), 0.7f); 
        exit.clicked += () => Invoke(nameof(Application.Quit), 0.7f);
    }

    public override void Open()
    {
        base.Open();
    }

    private void LoadTest()
    {
        SceneManager.LoadScene("Test");
    }
}
