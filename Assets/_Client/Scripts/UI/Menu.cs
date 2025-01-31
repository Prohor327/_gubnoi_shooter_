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

        play.clicked += () => SceneManager.LoadScene("Prologue"); ; 
        exit.clicked += () => Application.Quit();
    }

    public override void Open()
    {
        base.Open();
    }
}
