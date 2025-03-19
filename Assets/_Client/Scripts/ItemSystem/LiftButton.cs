using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class LiftButton : Interactable
{
    [SerializeField] private CutSceneSO _cutSceneSO;
    [SerializeField] private AudioClip _liftRunningSound;
    [SerializeField] private AudioClip _liftMusic;
    [SerializeField] private AudioClip _buttonPressSound;
    [SerializeField] private AudioSource _liftAudioSource;
    [SerializeField] private AudioSource _liftSpeakerSource;
    [SerializeField] private LiftCallButton _liftCallButton;
    [SerializeField] private LiftDoors _liftDoors;
    [SerializeField] private float _timeInLift;

    private AudioSource _audioSource;
    private CutScenesManager _cutScenesManager;
    private bool _isRunning = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _liftDoors.OnClosed += () => StartCoroutine(StartCutScene());
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
            playerEvents.OnStartHoverObject("[E] Спустииться");
        }
    }

    public override void OnInteract()
    {
        if(!_isRunning)
        {
            _isRunning = true;
            _audioSource.PlayOneShot(_buttonPressSound);
            _liftCallButton.StopAllCoroutines();
            if(_liftDoors.IsOpen)
            {
                _liftDoors.Close();
            }
        }
    }

    private IEnumerator StartCutScene()
    {
        if(_isRunning)
        {
            _liftAudioSource.clip = _liftRunningSound;
            _liftAudioSource.Play();
            _liftSpeakerSource.clip = _liftMusic;
            _liftSpeakerSource.Play();
            yield return new WaitForSeconds(_timeInLift);
            _cutScenesManager.StartCutScene(_cutSceneSO);
        }
    }
}
