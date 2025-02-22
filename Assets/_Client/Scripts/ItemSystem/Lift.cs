using System.Collections;
using UnityEngine;
using Zenject;

public class Lift : Interactable
{
    [SerializeField] private CutSceneSO _cutSceneSO;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    private CutScenesManager _cutScenesManager;

    [Inject]
    private void Construct(CutScenesManager cutScenesManager)
    {
        _cutScenesManager = cutScenesManager;
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject("[E] Спустьтся");
    }

    public override void OnInteract()
    {
        StartCoroutine(InLift());   
    }

    private IEnumerator InLift()
    {
        base.OnInteract();
        _source.clip = _clip;
        // door close
        yield return new WaitForSeconds(30f);
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}
