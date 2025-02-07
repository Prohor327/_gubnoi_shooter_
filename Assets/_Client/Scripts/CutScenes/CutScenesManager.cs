using UnityEngine;
using UnityEngine.Playables;
using Zenject;
using UnityEngine.InputSystem;
using AYellowpaper.SerializedCollections;

public class CutScenesManager : MonoBehaviour
{   
    [SerializedDictionary("Cut Scene Name", "Asset")]
    [SerializeField] private SerializedDictionary<CutSceneSO, CutScene> _cutScenes;
    [SerializeField] private Camera[] _cameras;

    private PlayableDirector _director; 
    private CutSceneSO _currentCutSceneSO;
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    private void Start()
    {
        InputHandler.CutSceneActions.Skip.started += SkipCutScene;
        _gameMachine.OnFinishGame += OnFinishGame;
        InputHandler.CutSceneActions.Disable();
        _director = GetComponent<PlayableDirector>();
    }

    public void StartCutScene(CutSceneSO so)
    {
        _gameMachine.StartCutScene();
        _currentCutSceneSO = so;
        _director.playableAsset = _cutScenes[_currentCutSceneSO].Asset;
        InputHandler.CutSceneActions.Enable();
        _cameras[_currentCutSceneSO.Id].gameObject.SetActive(true);
        print(_currentCutSceneSO.Id);
        _director.time = 0;
        _director.Play();
        print("Start cutscene: " + _currentCutSceneSO.Name);
    }
    
    public void EndCutScene()
    {
        _cameras[_currentCutSceneSO.Id].gameObject.SetActive(false);
        print("End cutscene: " + _currentCutSceneSO.Name);
        _currentCutSceneSO = null;
        _director.time = 10000;
        InputHandler.CutSceneActions.Disable();
        _gameMachine.EndCutScene();
    }

    private void SkipCutScene(InputAction.CallbackContext context)
    {
        EndCutScene();
    }

    private void OnFinishGame()
    {
        InputHandler.CutSceneActions.Skip.started -= SkipCutScene;
    }
}
