using UnityEngine;
using Zenject;

public class Lift : MonoBehaviour, IInteract
{
    [SerializeField] private CutSceneSO _cutSceneSO;

    private CutScenesManager _cutScenesManager;

    [Inject]
    private void Construct(CutScenesManager cutScenesManager)
    {
        _cutScenesManager = cutScenesManager;
    }
    
    public void CursorOnObject()
    {
    }

    public void Interact()
    {
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}
