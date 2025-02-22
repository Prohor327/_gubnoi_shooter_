using System.Collections;
using UnityEngine;
using Zenject;

public class Lift : Interactable
{
    [SerializeField] private CutSceneSO _cutSceneSO;
    [SerializeField] private AudioClip _liftSound;
    [SerializeField] private AudioClip _buttonPressSound;
    [SerializeField] private AudioSource _liftAudioSource;
    [SerializeField] private LiftCallButton _liftCallButton;
    [SerializeField] private float _timeInLift;

    private AudioSource _audioSource;
    private CutScenesManager _cutScenesManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        _audioSource.PlayOneShot(_buttonPressSound);
        _liftCallButton.CloseDoors();
        StartCoroutine(StartCutScene());   
    }

    private IEnumerator StartCutScene()
    {
        base.OnInteract();
        _liftAudioSource.clip = _liftSound;
        yield return new WaitForSeconds(_timeInLift);
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}
