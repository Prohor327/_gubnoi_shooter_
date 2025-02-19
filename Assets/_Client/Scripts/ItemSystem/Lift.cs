using UnityEngine;
using Zenject;

public class Lift : Interactable
{
    [SerializeField] private CutSceneSO _cutSceneSO;

    private CutScenesManager _cutScenesManager;

    [Inject]
    private void Construct(CutScenesManager cutScenesManager)
    {
        _cutScenesManager = cutScenesManager;
    }

    public override void OnInteract()
    {
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}
