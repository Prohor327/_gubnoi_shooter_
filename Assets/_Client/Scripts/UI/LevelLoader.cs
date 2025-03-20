using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class LevelLoader : UIElement
{
    [SerializeField] private float _animationTimer;

    private VisualElement _fon;

    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMashine)
    {
        _gameMachine = gameMashine;

        _gameMachine.OnLoadGame += LoadLevel;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _fon = _UIElement.Q<VisualElement>("Fon");
    }

    public override void Open()
    {
        base.Open();
    }

    private void LoadLevel()
    {
        Open();
        _fon.schedule.Execute(StartAnimation);
    }

    private void StartAnimation()
    {
        _fon.style.backgroundColor = new Color(0, 0, 0, 1);
    }

    private void OnEndAnimation()
    {
        _gameMachine.OpenLevel();
    }

    private void Update()
    {
        if(_fon.style.backgroundColor == new Color(0, 0, 0, 1))
        {
            _animationTimer -= Time.deltaTime;
            if (_animationTimer <= 0)
                OnEndAnimation();
        }
    }
}
