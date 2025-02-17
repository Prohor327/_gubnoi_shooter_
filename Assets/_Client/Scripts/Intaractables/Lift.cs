using UnityEngine;
using Zenject;

public class Lift : MonoBehaviour, IInteractable
{
    [SerializeField] private CutSceneSO _cutSceneSO;

    private CutScenesManager _cutScenesManager;

    [Inject]
    private void Construct(CutScenesManager cutScenesManager)
    {
        _cutScenesManager = cutScenesManager;
    }

    public void OnInteract()
    {
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }

    public void OnStartHover() {   }

    public void OnEndHover() {   }

    public void OnHover() {   }
}
