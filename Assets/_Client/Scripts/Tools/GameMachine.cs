using UnityEngine;
using Zenject;
using System;

public class GameMachine
{
    private ScenesOpener _scenesOpener;
    private bool _isCutScenePlaying;

    public GameState CurrentState {get; private set; }

    public Action OnStartGame;
    public Action OnStopGame;
    public Action OnResumeGame;
    public Action OnStartCutScene;
    public Action OnEndCutScene;
    public Action OnFinishGame;

    [Inject]
    public GameMachine(ScenesOpener scenesOpener)
    {
        UpdateGameState(GameState.Bootstrap);
        _scenesOpener = scenesOpener;
    }

    public void Initialize()
    {
        UpdateGameState(GameState.Initialize);
        InputHandler.Initialize();
        _scenesOpener.OpenMenu();
        UpdateGameState(GameState.Menu);
    }

    public void LoadLevel(string nameLevel)
    {
        UpdateGameState(GameState.LoadGame);
        _scenesOpener.OpenLevel(nameLevel);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateGameState(GameState.Game);
    }

    public void StopGame()
    {
        OnStopGame.Invoke();
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UpdateGameState(GameState.Pause);
    }

    public void StartCutScene()
    {
        OnStartCutScene.Invoke();
        _isCutScenePlaying = true;
        UpdateGameState(GameState.CutScene);
    }

    public void EndCutScene()
    {
        OnEndCutScene.Invoke();
        _isCutScenePlaying = false;
        UpdateGameState(GameState.Game);
    }

    public void ResumeGame()
    {
        OnResumeGame.Invoke();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if(!_isCutScenePlaying)
        {
            UpdateGameState(GameState.Game);
        }
        else
        {
            UpdateGameState(GameState.CutScene);
        }
    }

    public void FinishGame()
    {
        OnFinishGame.Invoke();
        OnStopGame += () => {};
        OnResumeGame += () => {};
        OnStartCutScene += () => {};
        OnEndCutScene += () => {};
        OnFinishGame += () => {};
        UpdateGameState(GameState.Menu);
        _scenesOpener.OpenMenu();
    }

    private void UpdateGameState(GameState gameState)
    {
        if(gameState != CurrentState)
        {
            CurrentState = gameState;
        }
    }
}