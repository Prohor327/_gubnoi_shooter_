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
    private bool _isRunning = false;

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
        if(!_isRunning)
        {
            playerEvents.OnStartHoverObject("[E] Спустьтся");
        }
    }

    public override void OnInteract()
    {
        if(!_isRunning)
        {
            _isRunning = true;
            _audioSource.PlayOneShot(_buttonPressSound);
            _liftCallButton.CloseDoors();
            _liftCallButton.StopAllCoroutines();
            StartCoroutine(StartCutScene());   
        }
    }

    private IEnumerator StartCutScene()
    {
        base.OnInteract();
        yield return new WaitForSeconds(1f);
        _liftAudioSource.PlayOneShot(_liftSound);
        yield return new WaitForSeconds(_timeInLift);
        _cutScenesManager.StartCutScene(_cutSceneSO);
    }
}
