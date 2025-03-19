using UnityEngine;
using DG.Tweening;
using System;

public class Door : MonoBehaviour
{
    public bool IsOpen { get; private set; } = false;
    public bool IsAnimationPlaying { get; private set; } = false;

    public Action OnOpened;
    public Action OnClosed;

    [SerializeField] protected float openningDuration;
    [SerializeField] protected AudioClip _openningSound;
    [SerializeField] protected AudioClip _closingSound;

    protected AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [ContextMenu("Open")]
    public virtual void Open()
    {
        IsAnimationPlaying = true;
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 100), openningDuration).onComplete = () => IsAnimationPlaying = false;
        audioSource.PlayOneShot(_openningSound);
        IsOpen = true;
    }

    [ContextMenu("Close")]
    public virtual void Close()
    {
        IsAnimationPlaying = true;
        transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 0), openningDuration).onComplete = () => IsAnimationPlaying = false;
        audioSource.PlayOneShot(_closingSound);
        IsOpen = false;
    }

    protected void OnEndOpen()
    {
        IsAnimationPlaying = false;
        IsOpen = true;
        OnOpened?.Invoke();
    }

    protected void OnEndClose()
    {
        IsAnimationPlaying = false;
        IsOpen = false;
        OnClosed?.Invoke();
    }
}