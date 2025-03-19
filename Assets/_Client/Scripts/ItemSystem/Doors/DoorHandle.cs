using UnityEngine;
using DG.Tweening;

public class DoorHandle : Interactable
{
    [SerializeField] private AudioClip _doorHandleSound;
    [SerializeField] private Door _door;

    private AudioSource _audioSource;

    private const string OpenedDoorText = "[E] Заркыть";
    private const string ClosedDoorText = "[E] Открыть";

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartHover()
    {
        if(_door.IsOpen)
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
        if(!_door.IsAnimationPlaying)
        {
            if(_door.IsOpen)
            {
                _door.Close();
            }
            else
            {
                _door.Open();
            }
        }
        base.OnInteract();
    }
}