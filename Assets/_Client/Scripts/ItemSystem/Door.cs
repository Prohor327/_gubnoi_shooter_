using UnityEngine;
using DG.Tweening;

public class Door : Interactable
{
    [SerializeField] protected float openningDuration;
    [SerializeField] protected AudioClip _openningSound;
    [SerializeField] protected AudioClip _closingSound;

    protected bool isOpen = false;
    protected bool isAnimationPlaying = false;

    protected AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartHover()
    {
        if(isOpen)
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
        if(!isAnimationPlaying)
        {
            base.OnInteract();
            isAnimationPlaying = true;

            if(isOpen)
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
    protected virtual void Open()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 100), openningDuration).onComplete = OnEndOpen;
        audioSource.PlayOneShot(_openningSound);
    }

    [ContextMenu("Close")]
    protected virtual void Close()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 0), openningDuration).onComplete = OnEndClose;
        audioSource.PlayOneShot(_closingSound);
    }

    protected void OnEndOpen()
    {
        isAnimationPlaying = false;
        isOpen = true;
    }

    protected void OnEndClose()
    {
        isAnimationPlaying = false;
        isOpen = false;
    }
}