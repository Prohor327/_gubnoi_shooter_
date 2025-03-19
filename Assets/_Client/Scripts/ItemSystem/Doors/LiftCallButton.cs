using UnityEngine;
using System.Collections;

public class LiftCallButton : Interactable
{
    [SerializeField] private float _liftArrivingTime;
    [SerializeField] private float _liftWaitingTime;
    [SerializeField] private AudioClip _liftRunningSound;
    [SerializeField] private AudioClip _pressButtonSound;
    [SerializeField] private LiftDoors _liftDoors;
    [SerializeField] private AudioSource _liftAudioSource;

    private bool _isArrived = false;
    private bool _isArriving = false;
    private AudioSource _buttonAudioSource;

    private void Start()
    {
        _buttonAudioSource = GetComponent<AudioSource>();
        _liftDoors.OnOpened += () => StartCoroutine(Wait());
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject.Invoke("[E] Вызвать лифт");
    }

    public override void OnInteract()
    {
        if(!_buttonAudioSource.isPlaying)
        {
            _buttonAudioSource.PlayOneShot(_pressButtonSound);
        }

        if(_liftDoors.IsOpen || _liftDoors.IsAnimationPlaying || _isArriving)
        {
            return;
        }

        if(!_isArrived)
        {
            StartCoroutine(CallLift());
        }
        else
        {
            _liftDoors.Open();
        }
        OnEndHover();
    }

    private IEnumerator CallLift()
    {
        _liftAudioSource.clip = _liftRunningSound;
        _liftAudioSource.Play();
        _isArriving = true;
        yield return new WaitForSeconds(_liftArrivingTime);
        _liftAudioSource.clip = null;
        _liftAudioSource.Stop();
        _isArriving = false;
        _isArrived = true;
        _liftDoors.Open();
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_liftWaitingTime);
        _liftDoors.Close();
    }
}
