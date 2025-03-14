using UnityEngine;
using Zenject;

public class PrologueStartCutSceneStarter : MonoBehaviour 
{
    [SerializeField] private CutSceneSO _cutSceneSO;

    private CutScenesManager _cutScenesManager;

    [Inject]
    private void Construct(CutScenesManager cutScenesManager)
    {
        _cutScenesManager = cutScenesManager;
    }

    private void Start()
    {
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}