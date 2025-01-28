using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Tools;

public class Menu : UIElement
{
    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _container.Q<Button>("Play");
        Button exit = _container.Q<Button>("Exit");

        play.clicked += () => Invoke(nameof(LoadGame), 0.4f); 
        exit.clicked += () => Invoke(nameof(Application.Quit), 0.4f);
    }

    public override void Open()
    {
        base.Open();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("The prologue");
    }
}
