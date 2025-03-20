using UnityEngine;
using Zenject;
using System;

public class GameMachine
{
    private ScenesOpener _scenesOpener;
    private bool _isCutScenePlaying;

    public GameState CurrentState {get; private set; }

    public Action OnStartGame;
    public Action OnLoadGame;
    public Action OnStopGame;
    public Action OnResumeGame;
    public Action OnStartCutScene;
    public Action OnEndCutScene;
    public Action OnFinishGame;
    public Action OnQuitGame;
    public Action OnLoadMenu;

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
        LoadMenu();
    }

    public void LoadLevel(string nameLevel)
    {
        if(CurrentState == GameState.Game || CurrentState == GameState.CutScene)
        {
            FinishGame();
        }
        UpdateGameState(GameState.LoadGame);
        _scenesOpener.LoadLevel(nameLevel);
        OnLoadGame?.Invoke();
    }

    public void OpenLevel()
    {
        _scenesOpener.OpenLevel();
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        OnStartGame?.Invoke();
        UpdateGameState(GameState.Game);
    }

    public void StopGame()
    {
        OnStopGame?.Invoke();
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UpdateGameState(GameState.Pause);
    }

    public void StartCutScene()
    {
        OnStartCutScene?.Invoke();
        _isCutScenePlaying = true;
        UpdateGameState(GameState.CutScene);
    }

    public void EndCutScene()
    {
        OnEndCutScene.Invoke();
        _isCutScenePlaying = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateGameState(GameState.Game);
    }

    public void ResumeGame()
    {
        OnResumeGame?.Invoke();
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
        OnFinishGame?.Invoke();
        ResetGameplayActions();
        UpdateGameState(GameState.FinishigGame);
    }

    public void LoadMenu()
    {
        UpdateGameState(GameState.Menu);
        OnLoadMenu?.Invoke();
        _scenesOpener.OpenMenu();
    }

    public void QuitGame()
    {
        OnQuitGame?.Invoke();
        ResetGameplayActions();
        OnLoadMenu += () => {};
        OnQuitGame += () => {}; 
        OnLoadGame += () => {};
        Application.Quit();
    }

    private void ResetGameplayActions()
    {
        OnStopGame += () => {};
        OnResumeGame += () => {};
        OnStartCutScene += () => {};
        OnEndCutScene += () => {};
        OnFinishGame += () => {};
    }

    private void UpdateGameState(GameState gameState)
    {
        if(gameState != CurrentState)
        {
            CurrentState = gameState;
        }
    }
}