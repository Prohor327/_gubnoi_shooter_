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

    private const string OpenedDoorText = "[E] Заркыть";
    private const string ClosedDoorText = "[E] Открыть";

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartHover()
    {
        if(isOpen)
        {
            playerEvents.OnStartHoverObject.Invoke(OpenedDoorText);
        }
        else
        {
            playerEvents.OnStartHoverObject.Invoke(ClosedDoorText);
        }
    }

    public override void OnInteract()
    {
        if(!isAnimationPlaying)
        {
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
        base.OnInteract();
    }

    [ContextMenu("Open")]
    protected virtual void Open()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 100), openningDuration).onComplete = () => isAnimationPlaying = false;
        audioSource.PlayOneShot(_openningSound);
        isOpen = true;
    }

    [ContextMenu("Close")]
    protected virtual void Close()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 0), openningDuration).onComplete = () => isAnimationPlaying = false;
        audioSource.PlayOneShot(_closingSound);
        isOpen = false;
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