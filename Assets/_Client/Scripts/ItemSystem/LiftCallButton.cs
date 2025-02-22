using UnityEngine;
using DG.Tweening;
using System.Collections;

public class LiftCallButton : Door
{
    [SerializeField] private Transform _door1;
    [SerializeField] private Transform _door2;
    [SerializeField] private float _liftArrivingTime;
    [SerializeField] private float _liftWaitingTime;
    [SerializeField] private AudioClip _liftSound;
    [SerializeField] private AudioClip _pressButtonSound;
    [SerializeField] private AudioSource _liftAudioSource;

    private Vector3 _door1DefaultPos;
    private Vector3 _door2DefaultPos;
    private bool _isArrived = false;
    private bool _isArriving = false;

    protected override void Start()
    {
        base.Start();
        _door1DefaultPos = _door1.localPosition;
        _door2DefaultPos = _door2.localPosition;
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject.Invoke("[E] Вызвать лифт");
    }

    public override void OnInteract()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(_pressButtonSound);
        }

        if(isOpen || isAnimationPlaying || _isArriving)
        {
            return;
        }

        if(!_isArrived)
        {
            StartCoroutine(CallLift());
        }
        else
        {
            Open();
        }
    }

    private IEnumerator CallLift()
    {
        _liftAudioSource.clip = _liftSound;
        _liftAudioSource.Play();
        _isArriving = true;
        yield return new WaitForSeconds(_liftArrivingTime);
        _liftAudioSource.clip = null;
        _liftAudioSource.Stop();
        _isArriving = false;
        _isArrived = true;
        Open();
    }

    protected override void Open()
    {   
        _door1.DOLocalMoveX(_door1DefaultPos.x - 2, openningDuration);
        _door2.DOLocalMoveX(_door2DefaultPos.x + 2, openningDuration).onComplete = OnEndOpen;
        _liftAudioSource.PlayOneShot(_openningSound);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_liftWaitingTime);
        Close();
    }

    protected override void Close()
    {
        _door1.DOLocalMoveX(_door1DefaultPos.x, openningDuration);
        _door2.DOLocalMoveX(_door2DefaultPos.x, openningDuration).onComplete = OnEndClose;
        _liftAudioSource.PlayOneShot(_openningSound);
    }

    public void CloseDoors()
    {
        Close();
    }
}
