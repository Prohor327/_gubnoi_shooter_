using UnityEngine;
using DG.Tweening;

public class Door : Interactable
{
    [SerializeField] private float _openningDuration;
    [SerializeField] private AudioClip _openningSound;
    [SerializeField] private AudioClip _closingSound;

    private bool _isOpen = false;
    private bool _isAnimationPlaying = false;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartHover()
    {
        if(_isOpen)
        {
            playerEvents.OnStartHoverObject.Invoke("[E] Закрыть");
        }
        else
        {
            playerEvents.OnStartHoverObject.Invoke("[E] Открыть");
        }
    }

    public override void OnInteract()
    {
        if(!_isAnimationPlaying)
        {
            base.OnInteract();
            _isAnimationPlaying = true;

            if(_isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    [ContextMenu("Open")]
    private void Open()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 100), _openningDuration).onComplete = OnEndOpen;
        _audioSource.PlayOneShot(_openningSound);
    }

    [ContextMenu("Close")]
    private void Close()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 0), _openningDuration).onComplete = OnEndClose;
        _audioSource.PlayOneShot(_closingSound);
    }

    private void OnEndOpen()
    {
        _isAnimationPlaying = false;
        _isOpen = true;
    }

    private void OnEndClose()
    {
        _isAnimationPlaying = false;
        _isOpen = false;
    }
}