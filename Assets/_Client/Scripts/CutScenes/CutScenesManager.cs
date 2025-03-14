using UnityEngine;
using UnityEngine.Playables;
using Zenject;
using UnityEngine.InputSystem;
using AYellowpaper.SerializedCollections;
using UnityEngine.Events;

public class CutScenesManager : MonoBehaviour
{   
    [SerializedDictionary("Cut Scene Name", "Asset")]
    [SerializeField] private SerializedDictionary<CutSceneSO, CutScene> _cutScenes;

    private PlayableDirector _director; 
    private GameMachine _gameMachine;
    private CutSceneSO _currentCutSceneSO;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        InputHandler.CutSceneActions.Skip.started += SkipCutScene;
        _gameMachine.OnFinishGame += OnFinishGame;
        InputHandler.CutSceneActions.Disable();
    }

    public void StartCutScene(CutSceneSO so)
    {
        _currentCutSceneSO = so;
        _director.playableAsset = _cutScenes[_currentCutSceneSO].Asset;
        _director.time = 0;
        _gameMachine.StartCutScene();
        InputHandler.CutSceneActions.Enable();
        _cutScenes[_currentCutSceneSO].Camera.gameObject.SetActive(true);
        _director.Play();
        print("Start cutscene: " + so.Name);
    }
    
    public void EndCutScene()
    {
        _cutScenes[_currentCutSceneSO].Camera.gameObject.SetActive(false);
        _director.time = 100000;
        InputHandler.CutSceneActions.Disable();
        _gameMachine.EndCutScene();
    }

    private void SkipCutScene(InputAction.CallbackContext context)
    {
        EndCutScene();
    }

    public void LoadLevel(string levelName)
    {
        _gameMachine.LoadLevel(levelName);
    }

    private void OnFinishGame()
    {
        InputHandler.CutSceneActions.Skip.started -= SkipCutScene;
    }
}