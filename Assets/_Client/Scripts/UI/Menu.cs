using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Menu : UI
{
    protected override void Initialize()
    {
        base.Initialize();
        Open();

        Button play = _UIElement.Q<Button>("Play");
        //Button settings = _UIElement.Q<Button>("Settings");
        Button exit = _UIElement.Q<Button>("Exit");

        play.clicked += () => Invoke(nameof(LoadTest), 0.7f); 
        //settings.clicked += () => Open Settings;
        exit.clicked += () => Invoke(nameof(Application.Quit), 0.7f);
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
