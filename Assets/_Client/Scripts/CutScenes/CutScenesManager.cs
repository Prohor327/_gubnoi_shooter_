using UnityEngine;
using UnityEngine.Playables;
using Zenject;
using AYellowpaper.SerializedCollections;

public class CutScenesManager : MonoBehaviour
{   
    [SerializedDictionary("Cut Scene Name", "Asset")]
    [SerializeField] private SerializedDictionary<CutSceneSO, CutScene> _cutScenes;

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
        _director = GetComponent<PlayableDirector>();
    }

    public void StartCutScene(CutSceneSO so)
    {
        _gameMachine.StartCutScene();
        _currentCutSceneSO = so;
        _director.playableAsset = _cutScenes[_currentCutSceneSO].Asset;
        _cutScenes[_currentCutSceneSO].Camera.gameObject.SetActive(true);
        _director.Play();
        print("Start cutscene: " + _currentCutSceneSO.Name);
    }
    
    public void EndCutScene()
    {
        _cutScenes[_currentCutSceneSO].Camera.gameObject.SetActive(false);
        _currentCutSceneSO = null;
        _director.time = 10000;
        _gameMachine.EndCutScene();
    }
}
