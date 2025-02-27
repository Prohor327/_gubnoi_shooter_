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
        if (_cutScenesManager == null) 
        {
            print("Cut Scene Manager is null");
        }
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}